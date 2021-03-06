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
        With My.Computer.Registry
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Nama_toko", TOKO)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Alamat_toko", ALAMAT)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "No_toko", NO)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Printer_nota", PRINTER)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Url_logo", Convert.ToBase64String(URLLOGO))
        End With

        AMBIL_DATA_REGISTRY()
    End Sub

    Public Sub AMBIL_DATA_REGISTRY()
        NAMA_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Nama_toko”, Nothing)
        ALAMAT_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Alamat_toko”, Nothing)
        NO_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “No_toko”, Nothing)
        PRINTER_NOTA = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Printer_nota”, Nothing)
        URL_LOGO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Url_logo”, Nothing)
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
