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

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class DashboardOperator : Form
    {
        public DashboardOperator()
        {
            InitializeComponent();
        }

        private void DashboardOperator_Load(object sender, EventArgs e)
        {
            label1.Text = "Selamat Datang , " + LoginSession.NamaLengkap;
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
