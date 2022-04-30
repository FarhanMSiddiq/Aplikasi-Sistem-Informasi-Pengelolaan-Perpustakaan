using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Pengelolaan_Perpustakaan.Model
{
    class Operator
    {
        string id, username, password, namaLengkap, jenisKelamin, noTelp, tanggalLahir;
        int statusAktif;

        public Operator(string id, string username, string password, string namaLengkap, string jenisKelamin, string noTelp, string tanggalLahir, int statusAktif)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.NamaLengkap = namaLengkap;
            this.JenisKelamin = jenisKelamin;
            this.NoTelp = noTelp;
            this.TanggalLahir = tanggalLahir;
            this.StatusAktif = statusAktif;
        }

        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string JenisKelamin { get => jenisKelamin; set => jenisKelamin = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
        public int StatusAktif { get => statusAktif; set => statusAktif = value; }
    }
}
