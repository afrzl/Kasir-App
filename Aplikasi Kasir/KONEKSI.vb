Imports System.Data.SqlClient
Imports Microsoft.Win32
Module KONEKSI
    Public CONN As SqlConnection
    Public NAMA_LOGIN As String = ""
    Public ROLE As Integer = 0

    Public NAMA_TOKO As String
    Public ALAMAT_TOKO As String
    Public NO_TOKO As String
    Public PRINTER_NOTA As String
    Public URL_LOGO As String

    Public Sub MASUK_REGISTRY(ByVal TOKO As String, ByVal ALAMAT As String, ByVal NO As String, ByVal PRINTER As String, ByVal URLLOGO As Byte())
        Call SaveSetting("POS", "Setting", "Nama_toko", TOKO)
        Call SaveSetting("POS", "Setting", "Alamat_toko", ALAMAT)
        Call SaveSetting("POS", "Setting", "No_toko", NO)
        Call SaveSetting("POS", "Setting", "Printer_nota", PRINTER)
        Call SaveSetting("POS", "Setting", "Url_logo", Convert.ToBase64String(URLLOGO))

        AMBIL_DATA_REGISTRY()
    End Sub

    Public Sub AMBIL_DATA_REGISTRY()
        NAMA_TOKO = GetSetting("POS", "Setting", "Nama_toko", "")
        ALAMAT_TOKO = GetSetting("POS", "Setting", "Alamat_toko", "")
        NO_TOKO = GetSetting("POS", "Setting", "No_toko", "")
        PRINTER_NOTA = GetSetting("POS", "Setting", "Printer_nota", "")
        URL_LOGO = GetSetting("POS", "Setting", "Url_logo", "")
    End Sub

    Public Sub KONEKAN()
        'SERVER=NAMA SERVER;USER ID=USERID;PASSWORD=PASSWORD;DATABASE=DATABASE;'
        Dim STR As String = "SERVER=" & My.Settings.SERVER & ";USER ID=" & My.Settings.USER & ";PASSWORD=" & My.Settings.PASSWORD & ";DATABASE=" & My.Settings.DATABASE & ";"
        Try
            CONN = New SqlConnection(STR)
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi dengan database gagal!")
            With My.Settings
                .SERVER = ""
                .USER = ""
                .PASSWORD = ""
                .DATABASE = ""
                .Save()
            End With
            End
        End Try

        AMBIL_DATA_REGISTRY()
    End Sub
End Module
