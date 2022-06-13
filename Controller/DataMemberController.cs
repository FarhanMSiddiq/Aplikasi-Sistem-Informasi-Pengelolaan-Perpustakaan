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
    class DataMemberController
    {
        Connection connection = new Connection();

        public DataSet ambilData()
        {
            try
            {
                connection.OpenConection();

               
                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select * from tbl_member");
                da.Fill(ds, "data");
                return ds;
   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public string generateIdMember()
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select id_member from tbl_member where id_member in(select max(id_member) from tbl_member) order by id_member desc");
                if (reader.Read())
                {

                    long hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_member"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    return "MB" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    return "MB001";
                }
                connection.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool TambahData(Member m)
        {
            try
            {
                connection.OpenConection();
                string sql = "insert into tbl_member (id_member, username, password, nama_lengkap, jenis_kelamin, no_telp, tanggal_lahir) values('" + m.IdMember + "','" + m.Username + "','" + m.Password + "','" + m.NamaLengkap + "','" + m.JenisKelamin + "','" + m.NoTelp + "','" + m.TanggalLahir + "')";
                connection.command(sql);
                MessageBox.Show("Berhasi Menambahkan Data Member");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool UbahData(Member m)
        {
            try
            {
                connection.OpenConection();
                string sql = "update tbl_member set username='" + m.Username + "',password='" + m.Password + "',nama_lengkap='" + m.NamaLengkap + "',jenis_kelamin='" + m.JenisKelamin + "',no_telp='" + m.NoTelp + "',tanggal_lahir='" + m.TanggalLahir + "' where id_member="+"'"+m.IdMember+"'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengubah Data Member");
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
                MySqlDataReader reader = connection.reader("select * from tbl_member where id_member="+"'"+id+"'");
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
                string sql = "delete from tbl_member where id_member=" + "'" + id + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengahapus Data Member");
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
