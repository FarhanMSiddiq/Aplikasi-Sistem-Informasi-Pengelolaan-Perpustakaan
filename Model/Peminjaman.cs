using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Pengelolaan_Perpustakaan.Model
{
    class Peminjaman
    {
        string idPeminjaman, idBuku, idmember, idOperator, tanggalPinjam, tanggalKembali , estimasiTanggalKembali;
        int estimasiPinjam, statusPinjam , statusDenda, bayarDenda;

        public Peminjaman(string idPeminjaman, string idBuku, string idmember, string idOperator, string tanggalPinjam, string tanggalKembali, string estimasiTanggalKembali, int estimasiPinjam, int statusPinjam, int statusDenda, int bayarDenda)
        {
            this.IdPeminjaman = idPeminjaman;
            this.IdBuku = idBuku;
            this.Idmember = idmember;
            this.IdOperator = idOperator;
            this.TanggalPinjam = tanggalPinjam;
            this.TanggalKembali = tanggalKembali;
            this.EstimasiTanggalKembali = estimasiTanggalKembali;
            this.EstimasiPinjam = estimasiPinjam;
            this.StatusPinjam = statusPinjam;
            this.StatusDenda = statusDenda;
            this.BayarDenda = bayarDenda;
        }

        public string IdPeminjaman { get => idPeminjaman; set => idPeminjaman = value; }
        public string IdBuku { get => idBuku; set => idBuku = value; }
        public string Idmember { get => idmember; set => idmember = value; }
        public string IdOperator { get => idOperator; set => idOperator = value; }
        public string TanggalPinjam { get => tanggalPinjam; set => tanggalPinjam = value; }
        public string TanggalKembali { get => tanggalKembali; set => tanggalKembali = value; }
        public string EstimasiTanggalKembali { get => estimasiTanggalKembali; set => estimasiTanggalKembali = value; }
        public int EstimasiPinjam { get => estimasiPinjam; set => estimasiPinjam = value; }
        public int StatusPinjam { get => statusPinjam; set => statusPinjam = value; }
        public int StatusDenda { get => statusDenda; set => statusDenda = value; }
        public int BayarDenda { get => bayarDenda; set => bayarDenda = value; }
    }
}
