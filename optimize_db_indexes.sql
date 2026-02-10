-- ========================================
-- OPTIMASI DATABASE INDEXES UNTUK PERFORMA
-- ========================================
-- File: optimize_db_indexes.sql
-- Tujuan: Membuat index untuk mempercepat query laporan
-- Jalankan di MySQL untuk aplikasi kasir
-- PENTING: Jalankan script ini di database MySQL anda!
-- ========================================

-- Cek jumlah data dulu (untuk tahu seberapa besar tabel)
SELECT 'tbl_transaksi_parent' AS tabel, COUNT(*) AS jumlah_row FROM tbl_transaksi_parent
UNION ALL
SELECT 'tbl_transaksi_child', COUNT(*) FROM tbl_transaksi_child
UNION ALL
SELECT 'tbl_barang', COUNT(*) FROM tbl_barang;

-- 1. Index untuk Id_trans (JOIN antara parent-child)
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

-- 4. Index untuk Jenis (filter K/M/C/R) - PALING PENTING
-- Semua query sekarang pakai Jenis IN ('K','C') atau Jenis IN ('M','R')
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_jenis (Jenis);

-- 5. Index untuk Kode barang (JOIN dengan tbl_barang)
ALTER TABLE tbl_transaksi_child 
ADD INDEX idx_kode (Kode);

-- 6. Composite index untuk query laporan (Jenis + Tgl = paling sering dipakai)
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_jenis_tgl (Jenis, Tgl);

-- 7. Composite index untuk query kasir tertentu
ALTER TABLE tbl_transaksi_parent 
ADD INDEX idx_jenis_tgl_kasir (Jenis, Tgl, Id_kasir);

-- 8. Index untuk tbl_karyawan
ALTER TABLE tbl_karyawan 
ADD INDEX idx_id (Id);

-- 9. Index untuk tbl_barang
ALTER TABLE tbl_barang 
ADD INDEX idx_kode (Kode);

-- 10. Composite index untuk child: Id_trans + Kode (untuk subquery SUM per Id_trans)
ALTER TABLE tbl_transaksi_child 
ADD INDEX idx_id_trans_kode (Id_trans, Kode);

-- ========================================
-- VERIFIKASI INDEX SUDAH TERBUAT
-- ========================================
SHOW INDEX FROM tbl_transaksi_parent;
SHOW INDEX FROM tbl_transaksi_child;
