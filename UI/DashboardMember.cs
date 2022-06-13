using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikasi_Pengelolaan_Perpustakaan.Controller;
using Aplikasi_Pengelolaan_Perpustakaan.Model;
using MySql.Data.MySqlClient;

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class DashboardMember : Form
    {
        DashboardMemberController dmc = new DashboardMemberController();

        public DashboardMember()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          

        }

        private void DashboardMember_Load(object sender, EventArgs e)
        {
            label1.Text = "Selamat Datang , " + LoginSession.NamaLengkap;
            MySqlDataReader data = dmc.ambil_data_member(LoginSession.Id);
            if (data.Read())
            {
                label3.Text = data[0].ToString();
                label4.Text = data[1].ToString();
                label6.Text = data[3].ToString();
                label8.Text = data[4].ToString();
                label10.Text = data[5].ToString();
                label12.Text = data[6].ToString();
            }

            DataSet ds = dmc.ambil_data_peminjaman(LoginSession.Id);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            dataGridView1.Columns[0].HeaderText = "ID Peminjaman";
            dataGridView1.Columns[1].HeaderText = "Tanggal Peminjaman";
            dataGridView1.Columns[2].HeaderText = "Estimasi Tanggal Pengembalian";
            dataGridView1.Columns[3].HeaderText = "Estimasi Pinjam (Hari)";
            dataGridView1.Columns[4].HeaderText = "Tanggal Pengembalian";
            dataGridView1.Columns[5].HeaderText = "Nama Operator Melayani";
            dataGridView1.Columns[6].HeaderText = "Nama Member Peminjam";
            dataGridView1.Columns[7].HeaderText = "Judul Buku";
            dataGridView1.Columns[8].HeaderText = "Keterangan Peminjaman";

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
