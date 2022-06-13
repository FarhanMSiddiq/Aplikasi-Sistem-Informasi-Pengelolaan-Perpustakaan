using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace Aplikasi_Pengelolaan_Perpustakaan.Config
{
    class Connection
    {
        string connectionString = "Server=localhost;Database=perpus;Uid=root;Pwd=;";
        MySqlConnection con;

        // Koneksi Menggunakan ODBC Connector
        public OdbcConnection getConnection()
        {
            return new OdbcConnection("DSN=dbperpus");
        }

        public void closeConnection(OdbcConnection _conn)
        {
            _conn.Close();
        }

        // Koneksi Menggunakan Mysql Data Connector

        public void OpenConection()
        {
            con = new MySqlConnection(connectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public MySqlDataReader reader(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query , con);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public MySqlDataAdapter adapter(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            return da;
        }

        public void command(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
            
    }
}
