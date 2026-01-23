# Fitur Tukar Point Member

## Deskripsi
Fitur ini memungkinkan kasir untuk menukarkan point member dengan barang hadiah.

## Struktur Database

### Tabel: tbl_penukaran_point
- **Id** (int, AUTO_INCREMENT, PRIMARY KEY): ID unik transaksi penukaran
- **Id_kasir** (char(15)): ID kasir yang melakukan transaksi
- **Id_member** (char(15)): ID member yang menukar point
- **Point** (decimal(19,4)): Jumlah point yang digunakan
- **Nama_barang** (char(100)): Nama barang yang ditukar
- **Created_at** (datetime(6)): Waktu transaksi

## Instalasi

1. Jalankan script SQL untuk membuat tabel:
   ```bash
   mysql -u root -p kasir_app_schema < create_tukar_point_table.sql
   ```
   
   Atau import file `kasir_app_schema.sql` yang sudah diperbarui.

2. Build ulang project VB.NET untuk mengkompilasi form baru.

## Cara Penggunaan

1. Buka menu **Member** dari dashboard
2. Klik tombol **TUKAR POINT** (warna orange)
3. Isi data penukaran:
   - **ID Member**: Masukkan ID member, tekan Enter untuk memuat data
   - **Nama Member**: Otomatis terisi
   - **Point Tersedia**: Otomatis terisi (read-only)
   - **Nama Barang**: Masukkan nama barang yang akan ditukar
   - **Point Digunakan**: Masukkan jumlah point yang akan digunakan
4. Klik tombol **TUKAR** untuk memproses
5. Point member akan otomatis berkurang sesuai jumlah yang digunakan

## Validasi
- ID Member harus ada di database
- Point yang digunakan tidak boleh melebihi point tersedia
- Point yang digunakan harus lebih dari 0
- Semua field harus diisi

## Fitur
- ✅ Input ID member dengan auto-load data
- ✅ Validasi point tersedia
- ✅ Pencatatan transaksi penukaran
- ✅ Pengurangan otomatis point member
- ✅ Form dengan desain user-friendly
- ✅ Tombol Tukar (hijau) dan Batal (merah)
- ✅ Integrasi dengan modul KONEKSI untuk manajemen database

## Screenshot Form
Form terdiri dari:
- Header biru navy dengan judul "TUKAR POINT MEMBER"
- 5 input field (ID Member, Nama Member, Point Tersedia, Nama Barang, Point Digunakan)
- 2 tombol aksi (TUKAR dan BATAL)

## Notes
- Transaksi penukaran point tercatat dengan timestamp
- ID kasir otomatis diambil dari session login
- History penukaran tersimpan di tabel tbl_penukaran_point
