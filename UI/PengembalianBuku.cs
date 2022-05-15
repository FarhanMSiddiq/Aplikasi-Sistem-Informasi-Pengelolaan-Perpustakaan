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
using MySql.Data.MySqlClient;

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class PengembalianBuku : Form
    {
        PengembalianBukuController controller = new PengembalianBukuController();

        public PengembalianBuku()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader rd = controller.ambilDetail(textBox1.Text);
            if (rd.Read())
            {
                
                if (rd[7].ToString()!="0")
                {
                    MessageBox.Show("Data Peminjaman Ini Sudah Selesai Dikembalikan");
                }
                else
                {
                    button2.Visible = true;

                    textBox2.Text = rd[0].ToString();
                    textBox3.Text = rd[1].ToString();
                    textBox4.Text = rd[2].ToString();
                    textBox5.Text = rd[3].ToString();
                    textBox6.Text = rd[4].ToString().Split(' ')[0];
                    textBox7.Text = rd[5].ToString().Split(' ')[0];
                    textBox8.Text = rd[6].ToString();


                    DateTime tanggal1 = Convert.ToDateTime(rd[5].ToString().Split(' ')[0]);
                    DateTime tanggal2 = DateTime.Today;
                    TimeSpan ts = new TimeSpan();
                    ts = tanggal2.Subtract(tanggal1);
                    if (ts.Days > 0)
                    {
                        textBox9.Text = (ts.Days * 2000).ToString();
                    }

                }
            }
        }

        private void PengembalianBuku_Load(object sender, EventArgs e)
        {
            DataSet ds = controller.ambilData();
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

            if (textBox2.Text == "-")
            {
                button2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int statusPeminjaman = 1;
            int statusDenda = 0;
            string bayarDenda = "0";

            if (textBox9.Text!="-")
            {
                statusPeminjaman = 2;
                statusDenda = 1;
                bayarDenda = textBox9.Text;
            }

            var confirmResult = MessageBox.Show("Apakah Anda Yakin Akan Mengembalikan Buku dengan ID Peminjaman " + textBox2.Text + " ??",
                                  "Konfirmasi Pengembalian Buku!!",
                                  MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool kembalikan = controller.kembalikanBuku(textBox2.Text,statusPeminjaman.ToString(),statusDenda.ToString(),bayarDenda);
                if (kembalikan)
                {
                    DataSet ds = controller.ambilData();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "data";
                }
            }

        }
    }
}
