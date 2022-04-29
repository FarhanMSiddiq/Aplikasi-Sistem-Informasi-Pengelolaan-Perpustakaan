using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Pengelolaan_Perpustakaan.Entity
{
    class Operator
    {
        private string operatorId , username , level ,  jenisKelamin , noTelp , tanggalLahir, statusAktif;

        public Operator(string _operatorId, string _username,  string _level, string _jenisKelamin, string _noTelp , string _tanggalLahir , string _statusAktif)
        {
            this.operatorId = _operatorId;
            this.username = _username;
            this.level = _level;
            this.jenisKelamin = _jenisKelamin;
            this.noTelp = _noTelp;
            this.tanggalLahir = _tanggalLahir;
            this.statusAktif = _statusAktif;

        }

        public string OperatorId
        {
            get { return operatorId; }
            set { operatorId = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        public string JenisKelamin
        {
            get { return jenisKelamin; }
            set { jenisKelamin = value; }
        }

        public string NoTelp
        {
            get { return noTelp; }
            set { noTelp = value; }
        }

        public string TanggalLahir
        {
            get { return tanggalLahir; }
            set { tanggalLahir = value; }
        }


    }
}
