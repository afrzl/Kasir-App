-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 23, 2025 at 02:58 PM
-- Server version: 9.3.0
-- PHP Version: 8.3.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kasir_app_schema`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_barang`
--

CREATE TABLE `tbl_barang` (
  `Kode` char(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Barang` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Satuan` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Harga1` decimal(19,4) DEFAULT NULL,
  `End1` decimal(24,4) DEFAULT NULL,
  `Harga2` decimal(19,4) DEFAULT NULL,
  `End2` decimal(24,4) DEFAULT NULL,
  `Harga3` decimal(19,4) DEFAULT NULL,
  `End3` decimal(24,4) DEFAULT NULL,
  `Harga4` decimal(19,4) DEFAULT NULL,
  `End4` decimal(24,4) DEFAULT NULL,
  `Harga5` decimal(19,4) DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tbl_barang`
--

INSERT INTO `tbl_barang` (`Kode`, `Barang`, `Satuan`, `Harga1`, `End1`, `Harga2`, `End2`, `Harga3`, `End3`, `Harga4`, `End4`, `Harga5`, `Created_at`, `Modified_at`) VALUES
('00001', 'SWALLOW KARAKTER DEWASA', 'Pcs', 13000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2024-01-15 12:52:42.000000', NULL),
('00002', 'SWALLOW SAFARI TANGGUNG', 'Pcs', 11000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2024-01-15 12:54:27.000000', NULL),
('000571392', 'CD DEWASA MEVILLON', 'Pcs', 20000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2024-08-11 15:59:40.000000', NULL),
('000612', 'ATK.TEPAK DOMPET PERAHU 5', 'Pcs', 10000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2023-05-02 13:23:20.000000', '2024-07-16 19:27:12.000000'),
('0007', 'B.KOTAK MAKAN SEKAT HIJAU', 'Pcs', 9000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2024-05-06 15:00:35.000000', '2025-06-23 17:04:14.000000'),
('001', 'SANDAL SWALLOW (NO 9-9,5)', 'Pcs', 11000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, NULL, '2023-04-27 09:31:07.000000'),
('001107', 'ATK.TEPAK DOMPET SEGITIGA BESAR 9/16', 'Pcs', 10000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2023-06-05 17:01:51.000000', '2024-07-16 19:29:37.000000'),
('00115', 'ROTI MINI PIZZA', 'Pcs', 3500.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, '2023-02-15 14:14:25.000000', '2023-11-25 14:41:22.000000'),
('001190', 'ATK.TEPAK DOMPET MEDIUM', 'Pcs', 5000.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, NULL, '2024-07-16 19:26:59.000000'),
('001239', 'ATK.BOLPEN PILOT HITAM', 'Pcs', 2500.0000, 11.0000, 1700.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, NULL, '2024-11-21 09:31:47.000000');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_data_voucher`
--

CREATE TABLE `tbl_data_voucher` (
  `Id` int NOT NULL,
  `Jenis` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Nama` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Harga` decimal(19,4) DEFAULT NULL,
  `Harga_jual` decimal(19,4) DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tbl_data_voucher`
--

INSERT INTO `tbl_data_voucher` (`Id`, `Jenis`, `Nama`, `Harga`, `Harga_jual`, `Created_at`, `Modified_at`) VALUES
(1, 'Voucher', 'VOUCHER BELANJA 100RB', 100.0000, 100000.0000, '2023-01-30 22:59:37.000000', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_diskon`
--

CREATE TABLE `tbl_diskon` (
  `Id` int NOT NULL,
  `Jenis` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kode` char(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Min_transaksi` decimal(19,4) DEFAULT NULL,
  `Jenis_nominal` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Diskon` int DEFAULT NULL,
  `Tgl_awal` date DEFAULT NULL,
  `Tgl_akhir` date DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_karyawan`
--

CREATE TABLE `tbl_karyawan` (
  `Id` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Nama` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` char(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Alamat` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tgl_lahir` date DEFAULT NULL,
  `JK` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `No_hp` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tbl_karyawan`
--

INSERT INTO `tbl_karyawan` (`Id`, `Nama`, `Password`, `Role`, `Alamat`, `Tgl_lahir`, `JK`, `No_hp`, `Created_at`, `Modified_at`) VALUES
('19800912002', 'ISWADI', '12345678', '1', 'PURWOSARI COMAL', '1980-09-12', 'L', '081234567890', NULL, NULL),
('19800924003', 'NINIK', '12345678', '1', 'PURWOSARI COMAL', '1980-09-24', 'P', '081234567890', NULL, NULL),
('19800924014', 'PRIHATINI', '12345678', '2', 'PURWOSARI', '1980-09-24', 'P', '081234567890', '2023-03-11 06:06:36.000000', '2023-03-11 06:09:14.000000'),
('19830121001', 'Chotim', '12345678', '1', 'Purwosari', '1983-01-21', 'P', '081234567890', NULL, NULL),
('20050406020', 'SINTIA ANDINI', '12345678', '3', 'PURWOSARI', '2005-04-06', 'P', '081234567890', '2023-12-25 22:05:15.000000', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_member`
--

CREATE TABLE `tbl_member` (
  `Id` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Nama` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Alamat` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `No_hp` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `JK` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Points` decimal(19,4) DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tbl_member`
--

INSERT INTO `tbl_member` (`Id`, `Nama`, `Alamat`, `No_hp`, `JK`, `Points`, `Created_at`, `Modified_at`) VALUES
('123456768', 'TEST', 'TEST', '08123', 'L', 0.0000, '2023-01-30 23:11:46.000000', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_penukaran_point`
--

CREATE TABLE `tbl_penukaran_point` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_kasir` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Id_member` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Point` decimal(19,4) NOT NULL,
  `Nama_barang` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stok`
--

CREATE TABLE `tbl_stok` (
  `Kode` char(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Stok` decimal(24,4) DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tbl_stok`
--

INSERT INTO `tbl_stok` (`Kode`, `Stok`, `Created_at`, `Modified_at`) VALUES
('00001', 2.0000, '2024-01-15 12:52:42.000000', '2024-02-29 18:54:55.000000'),
('00002', 0.0000, '2024-01-15 12:54:27.000000', '2024-02-26 14:34:29.000000'),
('000571392', 3.0000, '2024-08-11 15:59:40.000000', '2025-05-15 07:28:07.000000'),
('000612', 0.0000, '2023-05-02 13:23:20.000000', '2023-06-10 16:04:51.000000'),
('0007', 3.0000, '2024-05-06 15:00:35.000000', '2025-07-12 19:33:59.000000'),
('001', 0.0000, NULL, '2024-10-18 15:55:34.000000'),
('001107', 1.0000, '2023-06-05 17:01:51.000000', '2023-07-04 17:44:02.000000'),
('00115', 0.0000, '2023-02-15 14:14:25.000000', '2025-01-03 21:16:42.000000'),
('001190', 0.0000, NULL, '2023-06-02 10:28:17.000000'),
('001239', 99.0000, NULL, '2025-07-12 18:36:42.000000');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaksi_child`
--

CREATE TABLE `tbl_transaksi_child` (
  `Id` int NOT NULL,
  `Id_awal` int DEFAULT NULL,
  `Id_trans` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Kode` char(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Jumlah` decimal(24,4) NOT NULL,
  `Harga_beli` decimal(19,4) DEFAULT NULL,
  `Harga` decimal(19,4) NOT NULL,
  `Diskon` decimal(19,4) DEFAULT NULL,
  `Harga_akhir` decimal(19,4) DEFAULT NULL,
  `Stok` decimal(24,4) DEFAULT NULL,
  `Tgl_exp` date DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaksi_parent`
--

CREATE TABLE `tbl_transaksi_parent` (
  `Id` int NOT NULL,
  `Id_trans` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Id_kasir` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Id_member` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tgl` datetime(6) NOT NULL,
  `Jenis` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Person` char(100) DEFAULT NULL,
  `Harga` decimal(19,4) DEFAULT NULL,
  `Diskon` int DEFAULT NULL,
  `Jumlah_item` decimal(25,4) DEFAULT NULL,
  `Harga_total` decimal(19,4) DEFAULT NULL,
  `Harga_tunai` decimal(19,4) DEFAULT NULL,
  `Harga_kembali` decimal(19,4) DEFAULT NULL,
  `Modified_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaksi_voucher`
--

CREATE TABLE `tbl_transaksi_voucher` (
  `Id` int NOT NULL,
  `Id_data` int NOT NULL,
  `Id_kasir` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Id_member` char(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Harga` decimal(19,4) DEFAULT NULL,
  `Kode` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Created_at` datetime(6) DEFAULT NULL,
  `Updated_at` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_barang`
--
ALTER TABLE `tbl_barang`
  ADD PRIMARY KEY (`Kode`);

--
-- Indexes for table `tbl_data_voucher`
--
ALTER TABLE `tbl_data_voucher`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tbl_diskon`
--
ALTER TABLE `tbl_diskon`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tbl_karyawan`
--
ALTER TABLE `tbl_karyawan`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tbl_member`
--
ALTER TABLE `tbl_member`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tbl_stok`
--
ALTER TABLE `tbl_stok`
  ADD PRIMARY KEY (`Kode`);

--
-- Indexes for table `tbl_transaksi_child`
--
ALTER TABLE `tbl_transaksi_child`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tbl_transaksi_parent`
--
ALTER TABLE `tbl_transaksi_parent`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_trans` (`Id_trans`);

--
-- Indexes for table `tbl_transaksi_voucher`
--
ALTER TABLE `tbl_transaksi_voucher`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_data_voucher`
--
ALTER TABLE `tbl_data_voucher`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_diskon`
--
ALTER TABLE `tbl_diskon`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_transaksi_child`
--
ALTER TABLE `tbl_transaksi_child`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_transaksi_parent`
--
ALTER TABLE `tbl_transaksi_parent`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_transaksi_voucher`
--
ALTER TABLE `tbl_transaksi_voucher`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
