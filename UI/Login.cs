using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

using Aplikasi_Pengelolaan_Perpustakaan.Controller;

namespace Aplikasi_Pengelolaan_Perpustakaan
{
    public partial class Login : Form
    {

        CekLogin cek = new CekLogin();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (edt_username.Text == "" || edt_password.Text == "")
            {
                MessageBox.Show("Username Atau Password Tidak Boleh Kosong", "Gagal Login");
            }
            else
            {
                bool status = cek.cek_login(edt_username.Text, edt_password.Text);
                if (status)
                {
                    DashboardAdmin ds = new DashboardAdmin();
                    MessageBox.Show("Berhasil Login", "Berhasil");
                    ds.Show();
                }
                else
                {
                    MessageBox.Show("Akun Tidak Ditemukan!", "Gagal");
                }


            }


        }
    }
}
