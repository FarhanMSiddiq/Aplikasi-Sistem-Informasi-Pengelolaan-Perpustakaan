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

namespace Aplikasi_Pengelolaan_Perpustakaan
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection cnn = new OdbcConnection("DSN=dbperpus");

            try
            {
                cnn.Open();
                OdbcDataReader dr;
                OdbcCommand cmd;
                string sql = "select * from tbl_users where username='" + edt_username.Text + "' and password='" + edt_password.Text + "'";
                cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnn;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string username = dr["username"].ToString();
                        MessageBox.Show(username);
                    }

                }else{

                    MessageBox.Show("Akun tidak ditemukan!");

                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("kesalahan saat mengakses database!");
            }

        }
    }
}
