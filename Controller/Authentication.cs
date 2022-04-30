using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Pengelolaan_Perpustakaan.Config;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Aplikasi_Pengelolaan_Perpustakaan.Model;

namespace Aplikasi_Pengelolaan_Perpustakaan.Controller
{
    class Authentication
    {
        Connection connection = new Connection();

        public bool cek_login(string username , string password , string level)
        {
            try
            {
                connection.OpenConection();
                if (level == "admin")
                {
                    MySqlDataReader reader = connection.reader("select * from tbl_admin where username='" + username + "' and password='" + password + "'");
                    if (reader.Read())
                    {
                        LoginSession.Id = reader[0].ToString();
                        LoginSession.Username = reader[2].ToString();
                        LoginSession.NamaLengkap = reader[1].ToString();
                        LoginSession.Level = "admin";
                        connection.CloseConnection();
                        return true;
                    }
                    else
                    {
                        connection.CloseConnection();
                        return false;
                    }

                }else{
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
