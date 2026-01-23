-- Script untuk menambahkan tabel penukaran point
-- Jalankan script ini di database MySQL

USE kasir_app_schema;

-- Buat tabel tbl_penukaran_point
CREATE TABLE IF NOT EXISTS `tbl_penukaran_point` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_kasir` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Id_member` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Point` decimal(19,4) NOT NULL,
  `Nama_barang` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Menampilkan struktur tabel
DESCRIBE tbl_penukaran_point;
