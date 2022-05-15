using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Pengelolaan_Perpustakaan.Config;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using Aplikasi_Pengelolaan_Perpustakaan.Model;

namespace Aplikasi_Pengelolaan_Perpustakaan.Controller
{
    class DataBukuController
    {
        Connection connection = new Connection();

        public DataSet ambilData()
        {
            try
            {
                connection.OpenConection();


                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select * from tbl_buku");
                da.Fill(ds, "data");
                return ds;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public string generateIdBuku()
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select id_buku from tbl_buku where id_buku in(select max(id_buku) from tbl_buku) order by id_buku desc");
                if (reader.Read())
                {

                    long hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_buku"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    return "BK" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    return "BK001";
                }
                connection.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool TambahData(Buku b)
        {
            try
            {
                connection.OpenConection();
                string sql = "insert into tbl_buku (id_buku , judul_buku , kategori_buku , hlm_buku , penerbit_buku , penulis_buku , isbn_buku ) values('" + b.IdBuku + "','" + b.JudulBuku + "','" + b.KategoriBuku + "','" + b.HlmBuku + "','" + b.PenerbitBuku + "','" + b.PenulisBuku + "','" + b.IsbnBuku + "')";
                connection.command(sql);
                MessageBox.Show("Berhasi Menambahkan Data Buku");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool UbahData(Buku b)
        {
            try
            {
                connection.OpenConection();
                string sql = "update tbl_buku set judul_buku='" + b.JudulBuku + "',kategori_buku='" + b.KategoriBuku + "',hlm_buku='" + b.HlmBuku + "',hlm_buku='" + b.HlmBuku + "',penerbit_buku='" + b.PenerbitBuku + "',penulis_buku='" + b.PenulisBuku + "',isbn_buku='" + b.IsbnBuku + "' where id_buku=" + "'" + b.IdBuku + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengubah Data Buku");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool checkDuplicate(string id)
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select * from tbl_buku where id_buku=" + "'" + id + "'");
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
                connection.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool hapusData(string id)
        {
            try
            {
                connection.OpenConection();
                string sql = "delete from tbl_buku where id_buku=" + "'" + id + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengahapus Data Buku");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
