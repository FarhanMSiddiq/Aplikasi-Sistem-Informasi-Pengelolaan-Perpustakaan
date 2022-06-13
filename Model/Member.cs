using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Pengelolaan_Perpustakaan.Model
{
    class Member
    {
        string idMember, username, password, namaLengkap, jenisKelamin, noTelp, tanggalLahir;

        public Member(string idMember, string username, string password, string namaLengkap, string jenisKelamin, string noTelp, string tanggalLahir)
        {
            this.IdMember = idMember;
            this.Username = username;
            this.Password = password;
            this.NamaLengkap = namaLengkap;
            this.JenisKelamin = jenisKelamin;
            this.NoTelp = noTelp;
            this.TanggalLahir = tanggalLahir;
        }

        public string IdMember { get => idMember; set => idMember = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string JenisKelamin { get => jenisKelamin; set => jenisKelamin = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
    }
}
