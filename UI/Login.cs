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
using Aplikasi_Pengelolaan_Perpustakaan.UI;

namespace Aplikasi_Pengelolaan_Perpustakaan
{
    public partial class Login : Form
    {

        Authentication auth = new Authentication();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (edt_username.Text == "" || edt_password.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Level Atau Username Atau Password Tidak Boleh Kosong", "Gagal Login");
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    bool status = auth.cek_login(edt_username.Text, edt_password.Text, "admin");
                    if (status)
                    {
                        DashboardAdmin da = new DashboardAdmin();
                        MessageBox.Show("Berhasil Login", "Berhasil");
                        this.Hide();
                        da.Show();
                    }
                    else
                    {
                        MessageBox.Show("Akun Tidak Ditemukan!", "Gagal");
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    bool status = auth.cek_login(edt_username.Text, edt_password.Text, "operator");
                    if (status)
                    {
                        DashboardOperator d0 = new DashboardOperator();
                        MessageBox.Show("Berhasil Login", "Berhasil");
                        this.Hide();
                        d0.Show();
                    }
                    else
                    {
                        MessageBox.Show("Akun Tidak Ditemukan!", "Gagal");
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    bool status = auth.cek_login(edt_username.Text, edt_password.Text, "member");
                    if (status)
                    {
                        DashboardMember d1 = new DashboardMember();
                        MessageBox.Show("Berhasil Login", "Berhasil");
                        this.Hide();
                        d1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Akun Tidak Ditemukan!", "Gagal");
                    }
                }

            }


        }
    }
}
