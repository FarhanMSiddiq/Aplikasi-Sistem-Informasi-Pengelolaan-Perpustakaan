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

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class DataMember : Form
    {
        DataMemberController controller = new DataMemberController();

        public DataMember()
        {
            InitializeComponent();
        }

        private void DataMember_Load_1(object sender, EventArgs e)
        {
            DataSet ds = controller.ambilData();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            dataGridView1.Columns[0].HeaderText = "ID Member";
            dataGridView1.Columns[1].HeaderText = "Username";
            dataGridView1.Columns[2].HeaderText = "Password";
            dataGridView1.Columns[3].HeaderText = "Nama Lengkap";
            dataGridView1.Columns[4].HeaderText = "Jenis Kelamin";
            dataGridView1.Columns[5].HeaderText = "No.Telepon";
            dataGridView1.Columns[5].HeaderText = "Tanggal Lahir";

            textBox1.Text = controller.generateIdMember();

        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                string[] tglLahir = row.Cells[6].Value.ToString().Split(' ')[0].Split('/');
                dateTimePicker1.Value = new DateTime(int.Parse(tglLahir[2]), int.Parse(tglLahir[1]), int.Parse(tglLahir[0]));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                comboBox1.Text == ""
            )
            {
                MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
            }
            else
            {
              
                bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);

                if (checkDataDuplicateId)
                {
                    MessageBox.Show("Data Member Ini Sudah Terdaftar Di Database!", "Pemberitahuan");
                    return;
                }
                else
                {
                    Member op = new Member(
                       textBox1.Text,
                       textBox2.Text,
                       textBox3.Text,
                       textBox4.Text,
                       comboBox1.Text,
                       textBox5.Text,
                       dateTimePicker1.Value.ToString("yyyy-MM-dd")
                   );

                    bool tambah = controller.TambahData(op);

                    if (tambah)
                    {
                        DataSet ds = controller.ambilData();
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "data";
                    }
                }

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = controller.generateIdMember();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (
               textBox1.Text == "" ||
               textBox2.Text == "" ||
               textBox3.Text == "" ||
               textBox4.Text == "" ||
               textBox5.Text == "" ||
               comboBox1.Text == ""
           )
            {
                MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
            }
            else
            {

                Member op = new Member(
                       textBox1.Text,
                       textBox2.Text,
                       textBox3.Text,
                       textBox4.Text,
                       comboBox1.Text,
                       textBox5.Text,
                       dateTimePicker1.Value.ToString("yyyy-MM-dd")
                   );

                bool ubah = controller.UbahData(op);

                if (ubah)
                {
                    DataSet ds = controller.ambilData();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "data";
                }

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);
            if (!checkDataDuplicateId)
            {
                MessageBox.Show("Data Belum Tersedia , Tidak Dapat Dihapus!", "Pemberitahuan");
            }
            else
            {
                var confirmResult = MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data Member dengan ID Member " + textBox1.Text + " ??",
                                   "Konfirmasi Hapus Data!!",
                                   MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool hapus = controller.hapusData(textBox1.Text);
                    if (hapus)
                    {
                        DataSet ds = controller.ambilData();
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "data";
                    }
                }
            }

        }
    }
}
