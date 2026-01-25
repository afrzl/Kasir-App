Imports MySql.Data.MySqlClient
Imports Microsoft.SqlServer
Imports Microsoft.Win32

Module KONEKSI
    Public CONN As MySqlConnection
    Public NAMA_LOGIN As String = ""
    Public ROLE As Integer = 0

    Public NAMA_TOKO As String
    Public ALAMAT_TOKO As String
    Public NO_TOKO As String
    Public PRINTER_NOTA As String
    Public CUSTOMER_DISPLAY As Boolean
    Public KONVERSI_POINT As Integer
    Public URL_LOGO As String

    Public VERSI As String = "V3.5.1"

    Public Sub MASUK_REGISTRY(ByVal TOKO As String, ByVal ALAMAT As String, ByVal NO As String, ByVal PRINTER As String, ByVal URLLOGO As Byte(), ByVal CUSTOMERDISPLAY As Boolean, ByVal KONVERSIPOINT As Integer)
        With My.Computer.Registry
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Nama_toko", TOKO)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Alamat_toko", ALAMAT)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "No_toko", NO)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Printer_nota", PRINTER)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Customer_display", CUSTOMERDISPLAY)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Konversi_point", KONVERSIPOINT)
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Url_logo", Convert.ToBase64String(URLLOGO))
        End With

        AMBIL_DATA_REGISTRY()
    End Sub

    Public Sub REG_CUSTOMER_DISPLAY(ByVal CUSTOMERDISPLAY As Boolean)
        With My.Computer.Registry
            .SetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Customer_display", CUSTOMERDISPLAY)
        End With

        AMBIL_DATA_REGISTRY()
    End Sub

    Public Sub AMBIL_DATA_REGISTRY()
        NAMA_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Nama_toko”, Nothing)
        ALAMAT_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Alamat_toko”, Nothing)
        NO_TOKO = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “No_toko”, Nothing)
        PRINTER_NOTA = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Printer_nota”, Nothing)
        CUSTOMER_DISPLAY = My.Computer.Registry.GetValue(“HKEY_CURRENT_USER\Software\Aplikasi Kasir”, “Customer_display”, Nothing)

        KONVERSI_POINT = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Konversi_point", 1000)
        URL_LOGO = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Aplikasi Kasir", "Url_logo", Nothing)
    End Sub

    Public Sub KONEKAN()
        CONN = New MySqlConnection()

        ' Ambil server dari settings
        Dim serverSetting As String = My.Settings.SERVER
        Dim serverHost As String = "localhost"
        Dim serverPort As String = "3306" ' Default MySQL port

        ' Pisahkan server dan port jika ada tanda ":"
        If Not String.IsNullOrEmpty(serverSetting) AndAlso serverSetting.Contains(":") Then
            Dim serverParts() As String = serverSetting.Split(":"c)
            serverHost = serverParts(0)
            If serverParts.Length > 1 AndAlso Not String.IsNullOrEmpty(serverParts(1)) Then
                serverPort = serverParts(1)
            End If
        ElseIf Not String.IsNullOrEmpty(serverSetting) Then
            ' Jika tidak ada ":", gunakan sebagai host saja
            serverHost = serverSetting
        End If

        ' Buat connection string dengan server dan port yang sudah dipisah
        ' Menambahkan parameter untuk mencegah datetime invalid (0000-00-00)
        CONN.ConnectionString = $"server={serverHost};port={serverPort};uid={My.Settings.USER};pwd={My.Settings.PASSWORD};database={My.Settings.DATABASE};charset=utf8;Allow Zero Datetime=False;Convert Zero Datetime=False"

        AMBIL_DATA_REGISTRY()
    End Sub

    ''' <summary>
    ''' Membuka koneksi database jika belum terbuka
    ''' </summary>
    Public Sub BUKA_KONEKSI()
        If CONN Is Nothing Then
            KONEKAN()
        End If
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub

    ''' <summary>
    ''' Menutup koneksi database jika masih terbuka
    ''' </summary>
    Public Sub TUTUP_KONEKSI()
        If CONN IsNot Nothing AndAlso CONN.State = ConnectionState.Open Then
            CONN.Close()
        End If
    End Sub

    ''' <summary>
    ''' Mengeksekusi query SELECT dan mengembalikan DataReader
    ''' Koneksi harus ditutup manual setelah selesai membaca data
    ''' </summary>
    Public Function EXECUTE_READER(ByVal query As String) As MySqlDataReader
        BUKA_KONEKSI()
        Dim CMD As New MySqlCommand(query, CONN)
        Return CMD.ExecuteReader()
    End Function

    ''' <summary>
    ''' Mengeksekusi query INSERT/UPDATE/DELETE
    ''' </summary>
    Public Function EXECUTE_NONQUERY(ByVal query As String) As Integer
        BUKA_KONEKSI()
        Dim CMD As New MySqlCommand(query, CONN)
        Dim result As Integer = CMD.ExecuteNonQuery()
        TUTUP_KONEKSI()
        Return result
    End Function

    ''' <summary>
    ''' Mengeksekusi query dan mengembalikan nilai pertama (untuk COUNT, SUM, dll)
    ''' </summary>
    Public Function EXECUTE_SCALAR(ByVal query As String) As Object
        BUKA_KONEKSI()
        Dim CMD As New MySqlCommand(query, CONN)
        Dim result As Object = CMD.ExecuteScalar()
        TUTUP_KONEKSI()
        Return result
    End Function

End Module
