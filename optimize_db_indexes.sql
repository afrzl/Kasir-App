-- ========================================
-- OPTIMASI DATABASE INDEXES UNTUK PERFORMA
-- ========================================
-- File: optimize_db_indexes.sql
-- Tujuan: Membuat index untuk mempercepat query laporan
-- Jalankan di MySQL untuk aplikasi kasir
-- ========================================

-- 1. Index untuk Id_trans (prefix search dengan LIKE 'K%', 'M%', dll)
ALTER TABLE tbl_transaksi_child 
ADD INDEX idx_id_trans (Id_trans);

ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_id_trans (Id_trans);

-- 2. Index untuk Tgl (filter by date range)
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_tgl (Tgl);

-- 3. Index untuk Id_kasir (filter by kasir)
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_id_kasir (Id_kasir);

-- 4. Index untuk Jenis (filter K/M/C/R)
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_jenis (Jenis);

-- 5. Index untuk Kode barang (JOIN dengan tbl_barang)
ALTER TABLE tbl_transaksi_child 
ADD INDEX idx_kode (Kode);

-- 6. Composite index untuk query yang sering dipakai
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_tgl_jenis_kasir (Tgl, Jenis, Id_kasir);

-- 7. Index untuk tbl_karyawan
ALTER TABLE tbl_karyawan 
ADD INDEX idx_id (Id);

-- 8. Index untuk tbl_barang
ALTER TABLE tbl_barang 
ADD INDEX idx_kode (Kode);

-- ========================================
-- VERIFIKASI INDEX
-- ========================================
-- Cek index yang sudah dibuat:
SHOW INDEX FROM tbl_transaksi_parent;
SHOW INDEX FROM tbl_transaksi_child;
SHOW INDEX FROM tbl_karyawan;
SHOW INDEX FROM tbl_barang;
