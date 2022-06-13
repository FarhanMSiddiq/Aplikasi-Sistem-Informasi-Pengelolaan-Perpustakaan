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
    class PengembalianBukuController
    {
        Connection connection = new Connection();

        public DataSet ambilData()
        {
            try
            {
                connection.OpenConection();


                DataSet ds = new DataSet();
                MySqlDataAdapter da = connection.adapter("select tbl_peminjaman.id_peminjaman,tbl_peminjaman.tanggal_pinjam,  tbl_peminjaman.estimasi_tanggal_kembali ,  tbl_peminjaman.estimasi_pinjam  , case when tbl_peminjaman.tanggal_kembali is null then '-' else tbl_peminjaman.tanggal_kembali end as tanggal_kembali , tbl_operator.nama_lengkap as nama_operator , tbl_member.nama_lengkap as nama_member , tbl_buku.judul_buku , case when tbl_peminjaman.status = '0' then 'Sedang Di Pinjam' when tbl_peminjaman.status = '1' then 'Sudah Dikembalikan' when tbl_peminjaman.status = '2' then 'Sudah Dikembalikan Dan Didenda' end as status_text from tbl_peminjaman inner join tbl_buku on tbl_buku.id_buku = tbl_peminjaman.id_buku inner join tbl_operator on tbl_operator.id_operator = tbl_peminjaman.id_operator inner join tbl_member on tbl_member.id_member = tbl_peminjaman.id_member where status = '1' or status = '2'");
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
                MySqlDataReader dr = connection.reader("select tbl_peminjaman.id_peminjaman,  tbl_buku.judul_buku , tbl_member.nama_lengkap as nama_member  , tbl_operator.nama_lengkap as nama_operator , tbl_peminjaman.tanggal_pinjam,  tbl_peminjaman.estimasi_tanggal_kembali ,  tbl_peminjaman.estimasi_pinjam , tbl_peminjaman.status  from tbl_peminjaman inner join tbl_buku on tbl_buku.id_buku = tbl_peminjaman.id_buku inner join tbl_operator on tbl_operator.id_operator = tbl_peminjaman.id_operator inner join tbl_member on tbl_member.id_member = tbl_peminjaman.id_member  where id_peminjaman='" + id + "'");
                return dr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public bool kembalikanBuku(string id,string status , string statusDenda , string bayarDenda)
        {
            try
            {
                connection.OpenConection();
                string sql = "update tbl_peminjaman set status='" + status + "',denda='" + statusDenda + "',bayar_denda='" + bayarDenda + "' , tanggal_kembali='" + DateTime.Today.ToString("yyyy-MM-dd") + "' where id_peminjaman=" + "'" + id + "'";
                connection.command(sql);
                MessageBox.Show("Berhasi Mengembalikan Buku");
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
