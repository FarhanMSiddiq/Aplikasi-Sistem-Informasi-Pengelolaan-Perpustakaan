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
    class DataOperatorController
    {
        Connection connection = new Connection();

        public DataSet ambilData()
        {
            try
            {
                connection.OpenConection();

               
                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select * from tbl_operator");
                da.Fill(ds, "data");
                return ds;
   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public string generateIdOperator()
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select id_operator from tbl_operator where id_operator in(select max(id_operator) from tbl_operator) order by id_operator desc");
                if (reader.Read())
                {

                    long hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_operator"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    return "OP" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    return "OP001";
                }
                connection.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool TambahData(Operator op)
        {
            try
            {
                connection.OpenConection();
                string sql = "insert into tbl_operator (id_operator, username, password, nama_lengkap, jenis_kelamin, no_telp, tanggal_lahir , status_aktif) values('" + op.Id + "','" + op.Username + "','" + op.Password + "','" + op.NamaLengkap + "','" + op.JenisKelamin + "','" + op.NoTelp + "','" + op.TanggalLahir + "','" + op.StatusAktif.ToString() + "')";
                connection.command(sql);
                MessageBox.Show("Berhasi Menambahkan Data Operator");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool UbahData(Operator op)
        {
            try
            {
                connection.OpenConection();
                string sql = "update tbl_operator set username='" + op.Username + "',password='" + op.Password + "',nama_lengkap='" + op.NamaLengkap + "',jenis_kelamin='" + op.JenisKelamin + "',no_telp='" + op.NoTelp + "',tanggal_lahir='" + op.TanggalLahir + "',status_aktif='" + op.StatusAktif.ToString() + "' where id_operator="+"'"+op.Id+"'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengubah Data Operator");
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
                MySqlDataReader reader = connection.reader("select * from tbl_operator where id_operator="+"'"+id+"'");
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
                string sql = "delete from tbl_operator where id_operator=" + "'" + id + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengahapus Data Operator");
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
