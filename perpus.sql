-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 13 Jun 2022 pada 03.55
-- Versi server: 10.4.22-MariaDB
-- Versi PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `perpus`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `id_admin` int(11) NOT NULL,
  `nama_lengkap` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_admin`
--

INSERT INTO `tbl_admin` (`id_admin`, `nama_lengkap`, `username`, `password`) VALUES
(1, 'Farhan MS', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_buku`
--

CREATE TABLE `tbl_buku` (
  `id_buku` varchar(12) NOT NULL,
  `judul_buku` varchar(50) NOT NULL,
  `kategori_buku` varchar(30) NOT NULL,
  `hlm_buku` int(8) NOT NULL,
  `penerbit_buku` varchar(50) NOT NULL,
  `penulis_buku` varchar(100) NOT NULL,
  `isbn_buku` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_buku`
--

INSERT INTO `tbl_buku` (`id_buku`, `judul_buku`, `kategori_buku`, `hlm_buku`, `penerbit_buku`, `penulis_buku`, `isbn_buku`) VALUES
('BK001', 'Buku Pertamaku', 'Bacaan', 0, 'PT.Cahaya', 'Farhan', '192.168.1.2'),
('BK002', 'Ubah Buku Kedua', 'Ubah Bacaan', 300, 'PT.Cahaya Ubah Bangsa', 'Maulana', '192.168.1.22'),
('BK003', 'Buku Tester', 'Tester Program', 300, 'PT.Cahaya Abadi', 'Farhan', '192.168.1.23');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_member`
--

CREATE TABLE `tbl_member` (
  `id_member` varchar(12) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `nama_lengkap` varchar(50) NOT NULL,
  `jenis_kelamin` enum('Laki-laki','Perempuan') NOT NULL,
  `no_telp` varchar(15) NOT NULL,
  `tanggal_lahir` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_member`
--

INSERT INTO `tbl_member` (`id_member`, `username`, `password`, `nama_lengkap`, `jenis_kelamin`, `no_telp`, `tanggal_lahir`) VALUES
('MB001', 'Farhan', 'Farhan', 'Farhan Maulana Siddiq', 'Laki-laki', '08981323730', '2022-05-02'),
('MB002', 'maulana', 'maulana', 'Maulana', 'Laki-laki', '0898132312', '2022-05-01');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_operator`
--

CREATE TABLE `tbl_operator` (
  `id_operator` varchar(12) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `nama_lengkap` varchar(50) NOT NULL,
  `jenis_kelamin` enum('Laki-laki','Perempuan') NOT NULL,
  `no_telp` varchar(15) NOT NULL,
  `tanggal_lahir` date NOT NULL,
  `status_aktif` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_operator`
--

INSERT INTO `tbl_operator` (`id_operator`, `username`, `password`, `nama_lengkap`, `jenis_kelamin`, `no_telp`, `tanggal_lahir`, `status_aktif`) VALUES
('OP001', 'panjul', 'panjul', 'Panjul', 'Laki-laki', '08981323730', '2022-03-08', 1),
('OP002', 'andre', 'andre', 'Andre Taulani', 'Laki-laki', '08981323730', '2002-08-23', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_peminjaman`
--

CREATE TABLE `tbl_peminjaman` (
  `id_peminjaman` varchar(12) NOT NULL,
  `id_buku` varchar(12) NOT NULL,
  `id_member` varchar(12) NOT NULL,
  `id_operator` varchar(12) NOT NULL,
  `tanggal_pinjam` date NOT NULL,
  `estimasi_tanggal_kembali` date NOT NULL,
  `tanggal_kembali` date DEFAULT NULL,
  `estimasi_pinjam` int(3) NOT NULL,
  `status` enum('0','1','2') NOT NULL,
  `denda` int(1) NOT NULL,
  `bayar_denda` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbl_peminjaman`
--

INSERT INTO `tbl_peminjaman` (`id_peminjaman`, `id_buku`, `id_member`, `id_operator`, `tanggal_pinjam`, `estimasi_tanggal_kembali`, `tanggal_kembali`, `estimasi_pinjam`, `status`, `denda`, `bayar_denda`) VALUES
('PB001', 'BK001', 'MB001', 'OP001', '2022-05-01', '2022-05-02', '2022-05-03', 1, '2', 1, 2000),
('PB002', 'BK001', 'MB001', 'OP001', '2022-06-06', '2022-06-08', '2022-06-06', 2, '1', 0, 0),
('PB003', 'BK001', 'MB001', 'OP002', '2022-06-04', '2022-06-05', NULL, 1, '0', 0, 0),
('PB004', 'BK001', 'MB001', 'OP001', '2022-06-06', '2022-06-07', '2022-06-08', 1, '2', 1, 2000);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indeks untuk tabel `tbl_buku`
--
ALTER TABLE `tbl_buku`
  ADD PRIMARY KEY (`id_buku`);

--
-- Indeks untuk tabel `tbl_member`
--
ALTER TABLE `tbl_member`
  ADD PRIMARY KEY (`id_member`);

--
-- Indeks untuk tabel `tbl_operator`
--
ALTER TABLE `tbl_operator`
  ADD PRIMARY KEY (`id_operator`);

--
-- Indeks untuk tabel `tbl_peminjaman`
--
ALTER TABLE `tbl_peminjaman`
  ADD PRIMARY KEY (`id_peminjaman`),
  ADD KEY `id_buku` (`id_buku`),
  ADD KEY `id_member` (`id_member`),
  ADD KEY `id_operator` (`id_operator`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `id_admin` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tbl_peminjaman`
--
ALTER TABLE `tbl_peminjaman`
  ADD CONSTRAINT `tbl_peminjaman_ibfk_1` FOREIGN KEY (`id_buku`) REFERENCES `tbl_buku` (`id_buku`),
  ADD CONSTRAINT `tbl_peminjaman_ibfk_2` FOREIGN KEY (`id_member`) REFERENCES `tbl_member` (`id_member`),
  ADD CONSTRAINT `tbl_peminjaman_ibfk_3` FOREIGN KEY (`id_operator`) REFERENCES `tbl_operator` (`id_operator`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
