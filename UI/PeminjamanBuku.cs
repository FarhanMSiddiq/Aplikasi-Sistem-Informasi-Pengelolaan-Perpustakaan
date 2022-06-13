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
using MySql.Data.MySqlClient;

namespace Aplikasi_Pengelolaan_Perpustakaan.UI
{
    public partial class PeminjamanBuku : Form
    {
        PeminjamanBukuController controller = new PeminjamanBukuController();

        public PeminjamanBuku()
        {
            InitializeComponent();
        }

        private void PeminjamanBuku_Load(object sender, EventArgs e)
        {
            DataTable dt = controller.ambilDataBuku();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "judul_buku";
            comboBox1.ValueMember = "id_buku";

            DataTable dt2 = controller.ambilDataMember();
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "nama_lengkap";
            comboBox2.ValueMember = "id_member";

            DataTable dt3 = controller.ambilDataOperator();
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "nama_lengkap";
            comboBox3.ValueMember = "id_operator";

            textBox1.Text = controller.generateIdPeminjam();

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

            if (LoginSession.Level=="operator")
            {
                label4.Visible = false;
                comboBox3.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginSession.Level == "operator")
            {
                if (
                   textBox1.Text == "" ||
                   textBox2.Text == "" ||
                   comboBox1.SelectedValue.ToString() == "0" ||
                   comboBox2.SelectedValue.ToString() == "0" 
                )
                {
                    MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
                }
                else
                {

                    bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);

                    if (checkDataDuplicateId)
                    {
                        MessageBox.Show("Data Peminjaman Ini Sudah Terdaftar Di Database!", "Pemberitahuan");
                        return;
                    }
                    else
                    {
                        Peminjaman pb = new Peminjaman(
                           textBox1.Text,
                           comboBox1.SelectedValue.ToString(),
                           comboBox2.SelectedValue.ToString(),
                           LoginSession.Id,
                           dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                           "",
                           dateTimePicker1.Value.AddDays(Int32.Parse(textBox2.Text)).ToString("yyyy-MM-dd"),
                           Int32.Parse(textBox2.Text),
                           0,
                           0,
                           0
                       );

                        bool tambah = controller.TambahData(pb);

                        if (tambah)
                        {
                            DataSet ds = controller.ambilData();
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "data";
                        }
                    }

                }
            }
            else
            {
                if (
                   textBox1.Text == "" ||
                   textBox2.Text == "" ||
                   comboBox1.SelectedValue.ToString() == "0" ||
                   comboBox2.SelectedValue.ToString() == "0" ||
                   comboBox3.SelectedValue.ToString() == "0"
                )
                {
                    MessageBox.Show("Data Belum Terisi Semua!", "Pemberitahuan");
                }
                else
                {

                    bool checkDataDuplicateId = controller.checkDuplicate(textBox1.Text);

                    if (checkDataDuplicateId)
                    {
                        MessageBox.Show("Data Peminjaman Ini Sudah Terdaftar Di Database!", "Pemberitahuan");
                        return;
                    }
                    else
                    {
                        Peminjaman pb = new Peminjaman(
                           textBox1.Text,
                           comboBox1.SelectedValue.ToString(),
                           comboBox2.SelectedValue.ToString(),
                           comboBox3.SelectedValue.ToString(),
                           dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                           "",
                           dateTimePicker1.Value.AddDays(Int32.Parse(textBox2.Text)).ToString("yyyy-MM-dd"),
                           Int32.Parse(textBox2.Text),
                           0,
                           0,
                           0
                       );

                        bool tambah = controller.TambahData(pb);

                        if (tambah)
                        {
                            DataSet ds = controller.ambilData();
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "data";
                        }
                    }

                }

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                MySqlDataReader rd = controller.ambilDetail(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[0].Value.ToString();
                if (rd.Read())
                {
                    textBox2.Text = rd[7].ToString();
                    comboBox1.SelectedValue = rd[1].ToString();
                    comboBox2.SelectedValue = rd[2].ToString();
                    comboBox3.SelectedValue = rd[3].ToString();
                    string[] tglPinjam = rd[4].ToString().Split(' ')[0].Split('/');
                    dateTimePicker1.Value = new DateTime(int.Parse(tglPinjam[2]), int.Parse(tglPinjam[1]), int.Parse(tglPinjam[0]));
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
                var confirmResult = MessageBox.Show("Apakah Anda Yakin Akan Menghapus Data Peminjaman dengan ID Peminjaman " + textBox1.Text + " ??",
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

        private void button4_Click(object sender, EventArgs e)
        {

            textBox1.Text = controller.generateIdPeminjam();
            textBox2.Text = "";
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void ExportExcel(DataGridView dataGrid, string filename)
        {
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

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xls)|*.xls";
            save.FileName = "DataPeminjamanBuku.xls";

            if (save.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(dataGridView1, save.FileName);
            }
        }
    }
}
