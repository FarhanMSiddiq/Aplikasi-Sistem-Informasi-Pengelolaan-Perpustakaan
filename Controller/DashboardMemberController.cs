using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Pengelolaan_Perpustakaan.Config;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Aplikasi_Pengelolaan_Perpustakaan.Model;
using System.Data;

namespace Aplikasi_Pengelolaan_Perpustakaan.Controller
{
    class DashboardMemberController
    {
        Connection connection = new Connection();

        public MySqlDataReader ambil_data_member(string id_member)
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select * from tbl_member where id_member='" + id_member+ "'");
                return reader;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public DataSet ambil_data_peminjaman(string id_member)
        {
            

            try
            {
                connection.OpenConection();


                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select tbl_peminjaman.id_peminjaman,tbl_peminjaman.tanggal_pinjam,  tbl_peminjaman.estimasi_tanggal_kembali ,  tbl_peminjaman.estimasi_pinjam  , case when tbl_peminjaman.tanggal_kembali is null then '-' else tbl_peminjaman.tanggal_kembali end as tanggal_kembali , tbl_operator.nama_lengkap as nama_operator , tbl_member.nama_lengkap as nama_member , tbl_buku.judul_buku , case when tbl_peminjaman.status = '0' then 'Sedang Di Pinjam' when tbl_peminjaman.status = '1' then 'Sudah Dikembalikan' when tbl_peminjaman.status = '2' then 'Sudah Dikembalikan Dan Didenda' end as status_text from tbl_peminjaman inner join tbl_buku on tbl_buku.id_buku = tbl_peminjaman.id_buku inner join tbl_operator on tbl_operator.id_operator = tbl_peminjaman.id_operator inner join tbl_member on tbl_member.id_member = tbl_peminjaman.id_member where tbl_peminjaman.id_member = '"+ id_member+"'");
                da.Fill(ds, "data");
                return ds;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

    }
}
