using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikasi_Pengelolaan_Perpustakaan.Model;
using Aplikasi_Pengelolaan_Perpustakaan.UI;

namespace Aplikasi_Pengelolaan_Perpustakaan
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {

            label1.Text = "Selamat Datang , " + LoginSession.NamaLengkap;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataOperator formOperator = new DataOperator();
            formOperator.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataMember formMember = new DataMember();
            formMember.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DataBuku formBuku = new DataBuku();
            formBuku.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PeminjamanBuku formPeminjaman = new PeminjamanBuku();
            formPeminjaman.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PengembalianBuku formPengembalian = new PengembalianBuku();
            formPengembalian.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void dataOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataOperator formOperator = new DataOperator();
            formOperator.Show();
        }

        private void dataMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataMember formMember = new DataMember();
            formMember.Show();
        }

        private void dataBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBuku formBuku = new DataBuku();
            formBuku.Show();
        }

        private void peminjamanBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeminjamanBuku formPeminjaman = new PeminjamanBuku();
            formPeminjaman.Show();
        }

        private void pengembalianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PengembalianBuku formPengembalian = new PengembalianBuku();
            formPengembalian.Show();
        }
    }
}
