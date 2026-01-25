Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FR_TENTANG_BACKRESDB
    Dim STR As String
    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader

    Function BackupDatabase(filePath As String) As Boolean
        Try
            BUKA_KONEKSI()

            Using writer As New StreamWriter(filePath, False, System.Text.Encoding.UTF8)
                ' Write header
                writer.WriteLine("-- MySQL Database Backup")
                writer.WriteLine("-- Database: TOKO_KASIR")
                writer.WriteLine("-- Date: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                writer.WriteLine("-- Version: " & VERSI)
                writer.WriteLine()
                writer.WriteLine("SET FOREIGN_KEY_CHECKS=0;")
                writer.WriteLine()

                ' Get all tables
                STR = "SHOW TABLES"
                CMD = New MySqlCommand(STR, CONN)
                RD = CMD.ExecuteReader()

                Dim tables As New List(Of String)
                While RD.Read()
                    tables.Add(RD.GetString(0))
                End While
                RD.Close()

                ' Backup each table
                For Each tableName As String In tables
                    writer.WriteLine()
                    writer.WriteLine("-- Table: " & tableName)
                    writer.WriteLine("DROP TABLE IF EXISTS `" & tableName & "`;")

                    ' Get CREATE TABLE statement
                    STR = "SHOW CREATE TABLE `" & tableName & "`"
                    CMD = New MySqlCommand(STR, CONN)
                    RD = CMD.ExecuteReader()
                    If RD.Read() Then
                        writer.WriteLine(RD.GetString(1) & ";")
                    End If
                    RD.Close()

                    writer.WriteLine()

                    ' Get table data
                    STR = "SELECT * FROM `" & tableName & "`"
                    CMD = New MySqlCommand(STR, CONN)
                    RD = CMD.ExecuteReader()

                    If RD.HasRows Then
                        While RD.Read()
                            Dim values As New List(Of String)
                            For i As Integer = 0 To RD.FieldCount - 1
                                If RD.IsDBNull(i) Then
                                    values.Add("NULL")
                                Else
                                    Dim value As String = RD.GetValue(i).ToString()
                                    value = value.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n").Replace(vbCr, "\r").Replace(vbLf, "\n")
                                    values.Add("'" & value & "'")
                                End If
                            Next
                            writer.WriteLine("INSERT INTO `" & tableName & "` VALUES (" & String.Join(",", values) & ");")
                        End While
                    End If
                    RD.Close()
                    writer.WriteLine()
                Next

                writer.WriteLine()
                writer.WriteLine("SET FOREIGN_KEY_CHECKS=1;")
            End Using

            Return True

        Catch ex As Exception
            MsgBox("Error saat backup: " & ex.Message, vbCritical)
            Return False
        End Try
    End Function

    Function RestoreDatabase(filePath As String) As Boolean
        Try
            BUKA_KONEKSI()

            Using reader As New StreamReader(filePath, System.Text.Encoding.UTF8)
                Dim sqlScript As String = reader.ReadToEnd()
                Dim sqlCommands() As String = sqlScript.Split(New String() {";" & vbCrLf, ";" & vbLf}, StringSplitOptions.RemoveEmptyEntries)

                For Each sqlCommand As String In sqlCommands
                    Dim trimmedCommand As String = sqlCommand.Trim()
                    If trimmedCommand.Length > 0 AndAlso Not trimmedCommand.StartsWith("--") Then
                        Try
                            CMD = New MySqlCommand(trimmedCommand, CONN)
                            CMD.ExecuteNonQuery()
                        Catch ex As Exception
                            ' Skip comments and empty commands
                        End Try
                    End If
                Next
            End Using

            Return True

        Catch ex As Exception
            MsgBox("Error saat restore: " & ex.Message, vbCritical)
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

                    If BackupDatabase(SaveFileDialog1.FileName) Then
                        MsgBox("Database berhasil dibackup!" & vbCrLf & "Lokasi: " & SaveFileDialog1.FileName, vbInformation)
                        TUTUP_FORM()
                    End If

                    BTNSIMPAN.Enabled = True
                    Me.Cursor = Cursors.Default
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

                    If RestoreDatabase(TXTFILE.Text) Then
                        MsgBox("Database berhasil direstore!", vbInformation)
                        With FR_TENTANG
                            .Enabled = True
                        End With
                        My.Settings.ID_ACCOUNT = 0
                        FR_LOGIN.Show()
                        FR_TENTANG.Close()
                        Me.Close()
                    End If

                    BTNSIMPAN.Enabled = True
                    Me.Cursor = Cursors.Default
                End If
            End If
        Else
            MsgBox("Silahkan pilih action!")
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