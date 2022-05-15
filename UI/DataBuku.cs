using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikasi_Pengelolaan_Perpustakaan.Controller;
using Aplikasi_Pengelolaan_Perpustakaan.Model;

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class DataBuku : Form
    {
        DataBukuController controller = new DataBukuController();
        public DataBuku()
        {
            InitializeComponent();
        }

        private void ExportExcel(DataGridView dataGrid, string filename) {
            string Output = "";
            string Headers = "";

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                string Line = "";
                Headers += Line.ToString() + Convert.ToString(dataGrid.Columns[i].HeaderText) + "\t";
            }
            Output += Headers + "\r\n";

            for (int i = 0; i < dataGrid.RowCount - 1; i++)
            {
                string Line = "";
                for (int j = 0; j < dataGrid.Rows[i].Cells.Count; j++)
                {
                    Line = Line.ToString() + Convert.ToString(dataGrid.Rows[i].Cells[j].Value) + "\t";
                }
                Output += Line + "\r\n";
            }

            Encoding encoding = Encoding.GetEncoding(1254);
            byte[] Outputs = encoding.GetBytes(Output);
            FileStream file = new FileStream(filename, FileMode.Create);
            BinaryWriter binary = new BinaryWriter(file);

            binary.Write(Outputs, 0, Output.Length);
            binary.Flush();
            binary.Close();
            file.Close();
        }   

        private void DataBuku_Load(object sender, EventArgs e)
        {
            DataSet ds = controller.ambilData();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "data";
            dataGridView1.Columns[0].HeaderText = "ID Buku";
            dataGridView1.Columns[1].HeaderText = "Judul Buku";
            dataGridView1.Columns[2].HeaderText = "Kategori Buku";
            dataGridView1.Columns[3].HeaderText = "Halaman Buku";
            dataGridView1.Columns[4].HeaderText = "Penerbit Buku";
            dataGridView1.Columns[5].HeaderText = "Penulis Buku";
            dataGridView1.Columns[6].HeaderText = "ISBN Buku";

            textBox1.Text = controller.generateIdBuku();
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
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                textBox7.Text == "" 
            )
            {
                MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
            }
            else
            {

                bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);

                if (checkDataDuplicateId)
                {
                    MessageBox.Show("Data Buku Ini Sudah Terdaftar Di Database!", "Pemberitahuan");
                    return;
                }
                else
                {
                    Buku bk = new Buku(
                       textBox1.Text,
                       textBox2.Text,
                       textBox3.Text,
                       textBox4.Text,
                       textBox5.Text,
                       textBox6.Text,
                       textBox7.Text
                   );

                    bool tambah = controller.TambahData(bk);

                    if (tambah)
                    {
                        DataSet ds = controller.ambilData();
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "data";
                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.generateIdBuku();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                textBox7.Text == ""
           )
            {
                MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
            }
            else
            {


                Buku bk = new Buku(
                   textBox1.Text,
                   textBox2.Text,
                   textBox3.Text,
                   textBox4.Text,
                   textBox5.Text,
                   textBox6.Text,
                   textBox7.Text
               );

                bool ubah = controller.UbahData(bk);

                if (ubah)
                {
                    DataSet ds = controller.ambilData();
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "data";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);
            if (!checkDataDuplicateId)
            {
                MessageBox.Show("Data Belum Tersedia , Tidak Dapat Dihapus!", "Pemberitahuan");
            }
            else
            {
                var confirmResult = MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data Buku dengan ID Buku " + textBox1.Text + " ??",
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

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xls)|*.xls";
            save.FileName = "DataBuku.xls";

            if (save.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(dataGridView1, save.FileName);
            }
        }
    }
}
