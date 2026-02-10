Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.ComponentModel

Public Class FR_TENTANG_BACKRESDB
    Dim STR As String
    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader

    Private WithEvents bgWorker As New BackgroundWorker()
    Private _operationType As String = "" ' "backup" or "restore"
    Private _filePath As String = ""
    Private _errorMessage As String = ""

    Function BackupDatabase(filePath As String) As Boolean
        Dim localConn As New MySqlConnection()
        Try
            ' Pakai koneksi sendiri supaya tidak conflict dengan UI thread
            localConn.ConnectionString = CONN.ConnectionString
            localConn.Open()

            Using writer As New StreamWriter(filePath, False, System.Text.Encoding.UTF8, 65536)
                ' Write header
                writer.WriteLine("-- MySQL Database Backup")
                writer.WriteLine("-- Database: TOKO_KASIR")
                writer.WriteLine("-- Date: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                writer.WriteLine("-- Version: " & VERSI)
                writer.WriteLine()
                writer.WriteLine("SET FOREIGN_KEY_CHECKS=0;")
                writer.WriteLine("SET UNIQUE_CHECKS=0;")
                writer.WriteLine("SET AUTOCOMMIT=0;")
                writer.WriteLine()

                ' Get all tables
                Dim cmdTables As New MySqlCommand("SHOW TABLES", localConn)
                Dim rdTables As MySqlDataReader = cmdTables.ExecuteReader()

                Dim tables As New List(Of String)
                While rdTables.Read()
                    tables.Add(rdTables.GetString(0))
                End While
                rdTables.Close()

                ' Backup each table
                For Each tableName As String In tables
                    writer.WriteLine()
                    writer.WriteLine("-- Table: " & tableName)
                    writer.WriteLine("DROP TABLE IF EXISTS `" & tableName & "`;")

                    ' Get CREATE TABLE statement
                    Dim cmdCreate As New MySqlCommand("SHOW CREATE TABLE `" & tableName & "`", localConn)
                    Dim rdCreate As MySqlDataReader = cmdCreate.ExecuteReader()
                    If rdCreate.Read() Then
                        writer.WriteLine(rdCreate.GetString(1) & ";")
                    End If
                    rdCreate.Close()

                    writer.WriteLine()

                    ' Get table data - batch INSERT (500 rows per statement)
                    Dim cmdData As New MySqlCommand("SELECT * FROM `" & tableName & "`", localConn)
                    cmdData.CommandTimeout = 300
                    Dim rdData As MySqlDataReader = cmdData.ExecuteReader()

                    If rdData.HasRows Then
                        Dim rowCount As Integer = 0
                        Dim batchSize As Integer = 500
                        Dim sb As New System.Text.StringBuilder(65536)
                        Dim isFirstRow As Boolean = True

                        ' Get column count once
                        Dim fieldCount As Integer = rdData.FieldCount

                        While rdData.Read()
                            ' Build values string
                            Dim values As New System.Text.StringBuilder(256)
                            values.Append("(")
                            For i As Integer = 0 To fieldCount - 1
                                If i > 0 Then values.Append(",")
                                If rdData.IsDBNull(i) Then
                                    values.Append("NULL")
                                Else
                                    Dim rawValue As Object = rdData.GetValue(i)
                                    Dim value As String

                                    ' Format DateTime ke format MySQL (yyyy-MM-dd HH:mm:ss)
                                    If TypeOf rawValue Is DateTime Then
                                        Dim dtVal As DateTime = CDate(rawValue)
                                        If dtVal.TimeOfDay = TimeSpan.Zero Then
                                            value = dtVal.ToString("yyyy-MM-dd")
                                        Else
                                            value = dtVal.ToString("yyyy-MM-dd HH:mm:ss")
                                        End If
                                    ElseIf TypeOf rawValue Is Decimal OrElse TypeOf rawValue Is Double OrElse TypeOf rawValue Is Single Then
                                        ' Angka desimal pakai titik, bukan koma
                                        value = Convert.ToString(rawValue, System.Globalization.CultureInfo.InvariantCulture)
                                    Else
                                        value = rawValue.ToString()
                                    End If

                                    value = value.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n").Replace(vbCr, "\r").Replace(vbLf, "\n")
                                    values.Append("'")
                                    values.Append(value)
                                    values.Append("'")
                                End If
                            Next
                            values.Append(")")

                            If isFirstRow OrElse rowCount >= batchSize Then
                                ' Close previous batch if exists
                                If Not isFirstRow Then
                                    sb.AppendLine(";")
                                    writer.Write(sb.ToString())
                                    sb.Clear()
                                End If
                                ' Start new batch INSERT
                                sb.Append("INSERT INTO `")
                                sb.Append(tableName)
                                sb.Append("` VALUES ")
                                sb.Append(values.ToString())
                                rowCount = 1
                                isFirstRow = False
                            Else
                                sb.Append(",")
                                sb.Append(values.ToString())
                                rowCount += 1
                            End If
                        End While

                        ' Write remaining batch
                        If sb.Length > 0 Then
                            sb.AppendLine(";")
                            writer.Write(sb.ToString())
                        End If
                    End If
                    rdData.Close()
                    writer.WriteLine()
                Next

                writer.WriteLine()
                writer.WriteLine("COMMIT;")
                writer.WriteLine("SET FOREIGN_KEY_CHECKS=1;")
                writer.WriteLine("SET UNIQUE_CHECKS=1;")
                writer.WriteLine("SET AUTOCOMMIT=1;")
            End Using

            localConn.Close()
            Return True

        Catch ex As Exception
            _errorMessage = ex.Message
            If localConn.State = ConnectionState.Open Then localConn.Close()
            Return False
        End Try
    End Function

    Function RestoreDatabase(filePath As String) As Boolean
        Dim localConn As New MySqlConnection()
        Try
            ' Pakai koneksi sendiri supaya tidak conflict dengan UI thread
            localConn.ConnectionString = CONN.ConnectionString
            localConn.Open()

            ' Disable checks untuk percepat restore
            Dim cmdInit As New MySqlCommand("SET FOREIGN_KEY_CHECKS=0; SET UNIQUE_CHECKS=0; SET AUTOCOMMIT=0;", localConn)
            cmdInit.ExecuteNonQuery()

            Using reader As New StreamReader(filePath, System.Text.Encoding.UTF8, True, 65536)
                Dim sb As New System.Text.StringBuilder(65536)
                Dim line As String

                While Not reader.EndOfStream
                    line = reader.ReadLine()

                    ' Skip comments dan baris kosong
                    If line Is Nothing OrElse line.TrimStart().StartsWith("--") OrElse line.Trim().Length = 0 Then
                        Continue While
                    End If

                    sb.Append(line)

                    ' Cek apakah statement sudah lengkap (diakhiri ;)
                    If line.TrimEnd().EndsWith(";") Then
                        Dim sqlCommand As String = sb.ToString().Trim()
                        If sqlCommand.Length > 0 Then
                            Try
                                Dim cmdExec As New MySqlCommand(sqlCommand, localConn)
                                cmdExec.CommandTimeout = 300
                                cmdExec.ExecuteNonQuery()
                            Catch ex As Exception
                                ' Skip error per statement (misal table sudah ada)
                            End Try
                        End If
                        sb.Clear()
                    Else
                        sb.Append(vbLf)
                    End If
                End While

                ' Execute remaining statement jika ada
                Dim remaining As String = sb.ToString().Trim()
                If remaining.Length > 0 AndAlso Not remaining.StartsWith("--") Then
                    Try
                        Dim cmdRem As New MySqlCommand(remaining, localConn)
                        cmdRem.CommandTimeout = 300
                        cmdRem.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                End If
            End Using

            ' Commit dan restore checks
            Dim cmdFinish As New MySqlCommand("COMMIT; SET FOREIGN_KEY_CHECKS=1; SET UNIQUE_CHECKS=1; SET AUTOCOMMIT=1;", localConn)
            cmdFinish.ExecuteNonQuery()

            localConn.Close()
            Return True

        Catch ex As Exception
            _errorMessage = ex.Message
            If localConn.State = ConnectionState.Open Then localConn.Close()
            Return False
        End Try
    End Function

    Sub TUTUP_FORM()
        With FR_TENTANG
            .Enabled = True
        End With
        Me.Close()
    End Sub
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        TUTUP_FORM()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CB_ACTION.SelectedIndex > 0 Then
            If CB_ACTION.SelectedIndex = 1 Then
                ' Backup Database
                SaveFileDialog1.FileName = "DB TOKO_KASIR " & VERSI & " " & Format(Date.Now(), "yyyyMMddHHmmss") & ".sql"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    BTNSIMPAN.Enabled = False
                    CB_ACTION.Enabled = False
                    BTNCLOSE.Enabled = False

                    _operationType = "backup"
                    _filePath = SaveFileDialog1.FileName
                    _errorMessage = ""
                    bgWorker.RunWorkerAsync()
                End If

            ElseIf CB_ACTION.SelectedIndex = 2 Then
                ' Restore Database
                If TXTFILE.Text = "" Then
                    MsgBox("File restore tidak ditemukan!")
                    Exit Sub
                End If

                If MsgBox("Apakah anda yakin akan restore database?" & vbCrLf & "Data yang ada sekarang akan ditimpa!", vbYesNo + vbExclamation) = vbYes Then
                    Me.Cursor = Cursors.WaitCursor
                    BTNSIMPAN.Enabled = False
                    CB_ACTION.Enabled = False
                    BTNCLOSE.Enabled = False

                    _operationType = "restore"
                    _filePath = TXTFILE.Text
                    _errorMessage = ""
                    bgWorker.RunWorkerAsync()
                End If
            End If
        Else
            MsgBox("Silahkan pilih action!")
        End If
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        If _operationType = "backup" Then
            e.Result = BackupDatabase(_filePath)
        ElseIf _operationType = "restore" Then
            e.Result = RestoreDatabase(_filePath)
        End If
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        Me.Cursor = Cursors.Default
        BTNSIMPAN.Enabled = True
        CB_ACTION.Enabled = True
        BTNCLOSE.Enabled = True

        If e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message, vbCritical)
            Return
        End If

        Dim success As Boolean = CBool(e.Result)

        If _operationType = "backup" Then
            If success Then
                MsgBox("Database berhasil dibackup!" & vbCrLf & "Lokasi: " & _filePath, vbInformation)
                TUTUP_FORM()
            Else
                MsgBox("Error saat backup: " & _errorMessage, vbCritical)
            End If
        ElseIf _operationType = "restore" Then
            If success Then
                MsgBox("Database berhasil direstore!", vbInformation)
                With FR_TENTANG
                    .Enabled = True
                End With
                My.Settings.ID_ACCOUNT = 0
                FR_LOGIN.Show()
                FR_TENTANG.Close()
                Me.Close()
            Else
                MsgBox("Error saat restore: " & _errorMessage, vbCritical)
            End If
        End If
    End Sub

    Private Sub BTN_LOCATION_Click(sender As Object, e As EventArgs) Handles BTN_LOCATION.Click
        OpenFileDialog1.Filter = "SQL Files (*.sql)|*.sql"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TXTFILE.Text = OpenFileDialog1.FileName
        End If
        BTNSIMPAN.Select()
    End Sub

    Private Sub TXTNFILE_Click(sender As Object, e As EventArgs) Handles TXTFILE.Click
        OpenFileDialog1.Filter = "SQL Files (*.sql)|*.sql"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TXTFILE.Text = OpenFileDialog1.FileName
        End If
        BTNSIMPAN.Select()
    End Sub

    Private Sub CB_ACTION_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_ACTION.SelectedValueChanged
        If CB_ACTION.SelectedIndex = 2 Then
            Label2.Visible = True
            Label3.Visible = True
            TXTFILE.Visible = True
            BTN_LOCATION.Visible = True
        Else
            Label3.Visible = False
            Label2.Visible = False
            TXTFILE.Visible = False
            BTN_LOCATION.Visible = False
        End If
    End Sub

    Private Sub FR_TENTANG_BACKRESDB_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label3.Text = "Hanya gunakan DB backup dengan versi " & VERSI.Remove(4, 2) & " atau " & VERSI.Remove(5, 1) & "x."
    End Sub
End Class