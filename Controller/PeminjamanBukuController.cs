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
    class PeminjamanBukuController
    {
        Connection connection = new Connection();

        public DataSet ambilData()
        {
            try
            {
                connection.OpenConection();


                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select tbl_peminjaman.id_peminjaman,tbl_peminjaman.tanggal_pinjam,  tbl_peminjaman.estimasi_tanggal_kembali ,  tbl_peminjaman.estimasi_pinjam  , case when tbl_peminjaman.tanggal_kembali is null then '-' else tbl_peminjaman.tanggal_kembali end as tanggal_kembali , tbl_operator.nama_lengkap as nama_operator , tbl_member.nama_lengkap as nama_member , tbl_buku.judul_buku , case when tbl_peminjaman.status = '0' then 'Sedang Di Pinjam' when tbl_peminjaman.status = '1' then 'Sudah Dikembalikan' when tbl_peminjaman.status = '2' then 'Sudah Dikembalikan Dan Didenda' end as status_text from tbl_peminjaman inner join tbl_buku on tbl_buku.id_buku = tbl_peminjaman.id_buku inner join tbl_operator on tbl_operator.id_operator = tbl_peminjaman.id_operator inner join tbl_member on tbl_member.id_member = tbl_peminjaman.id_member");
                da.Fill(ds, "data");
                return ds;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public MySqlDataReader ambilDetail(string id)
        {
            try
            {
                connection.OpenConection();
                DataSet ds = new DataSet();
                MySqlDataReader dr = connection.reader("select * from tbl_peminjaman where id_peminjaman='" + id + "'");
                return dr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public string generateIdPeminjam()
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select id_peminjaman from tbl_peminjaman where id_peminjaman in(select max(id_peminjaman) from tbl_peminjaman) order by id_peminjaman desc");
                if (reader.Read())
                {

                    long hitung = Convert.ToInt64(reader[0].ToString().Substring(reader["id_peminjaman"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    return "PB" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    return "PB001";
                }
                connection.CloseConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool TambahData(Peminjaman pb)
        {
            try
            {
                connection.OpenConection();
                string sql = "insert into tbl_peminjaman (id_peminjaman, id_buku, id_member, id_operator, tanggal_pinjam, estimasi_tanggal_kembali , estimasi_pinjam, status, denda, bayar_denda) values('" + pb.IdPeminjaman + "','" + pb.IdBuku + "','" + pb.Idmember + "','" + pb.IdOperator + "','" + pb.TanggalPinjam + "','" + pb.EstimasiTanggalKembali + "','" + pb.EstimasiPinjam + "','" + pb.StatusPinjam + "','" + pb.StatusDenda.ToString() + "','" + pb.BayarDenda.ToString() + "')";
                connection.command(sql);
                MessageBox.Show("Berhasi Menambahkan Data Peminjam");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool UbahData(Peminjaman pb)
        {
            try
            {
                connection.OpenConection();
                string sql = "update tbl_peminjaman set id_buku='" + pb.IdBuku + "',id_member='" + pb.Idmember + "',id_operator='" + pb.IdOperator + "',tanggal_pinjam='" + pb.TanggalPinjam + "',estimasi_pinjam='" + pb.EstimasiPinjam + "',status='" + pb.StatusPinjam.ToString() + "',denda='" + pb.StatusDenda.ToString() + "',bayar_denda='" + pb.BayarDenda.ToString() + "' where id_peminjaman=" + "'" + pb.IdPeminjaman + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengubah Data Peminjam");
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
                MySqlDataReader reader = connection.reader("select * from tbl_peminjaman where id_peminjaman=" + "'" + id + "'");
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
                string sql = "delete from tbl_peminjaman where id_peminjaman=" + "'" + id + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengahapus Data Peminjam");
                connection.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public DataTable ambilDataBuku()
        {
            try
            {
                connection.OpenConection();


                DataTable dt = new DataTable();
                DataRow row = dt.NewRow();
                MySqlDataAdapter da = connection.adapter("select id_buku , judul_buku from tbl_buku");
                da.Fill(dt);
                row[0] = 0;
                row[1] = "Pilih Data Buku";
                dt.Rows.InsertAt(row, 0);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public DataTable ambilDataMember()
        {
            try
            {
                connection.OpenConection();


                DataTable dt = new DataTable();
                DataRow row = dt.NewRow();
                MySqlDataAdapter da = connection.adapter("select id_member , nama_lengkap from tbl_member");
                da.Fill(dt);
                row[0] = 0;
                row[1] = "Pilih Data Member";
                dt.Rows.InsertAt(row, 0);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }


        public DataTable ambilDataOperator()
        {
            try
            {
                connection.OpenConection();


                DataTable dt = new DataTable();
                DataRow row = dt.NewRow();
                MySqlDataAdapter da = connection.adapter("select id_operator , nama_lengkap from tbl_operator");
                da.Fill(dt);
                row[0] = 0;
                row[1] = "Pilih Data Operator";
                dt.Rows.InsertAt(row, 0);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

    }
}
