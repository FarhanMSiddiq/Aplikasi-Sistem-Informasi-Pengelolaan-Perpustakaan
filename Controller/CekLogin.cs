using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Pengelolaan_Perpustakaan.Config;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Aplikasi_Pengelolaan_Perpustakaan.Controller
{
    class CekLogin
    {
        Connection connection = new Connection();

        public bool cek_login(string username , string password)
        {
            try
            {
                connection.OpenConection();
                MySqlDataReader reader = connection.reader("select * from tbl_admin where username='" + username + "' and password='" + password + "'");
                if (reader.Read())
                {
                    connection.CloseConnection();
                    return true;
                }
                else
                {
                    connection.CloseConnection();
                    return false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

    }
}
