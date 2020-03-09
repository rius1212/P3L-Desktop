using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AtmaAuto.ClassAA
{
    class LoginDAL
    {
        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = null;
            try
            {
             //   string myconnstrng = "server=192.168.19.140;user id=pp8832;database=8832";
         // string myconnstrng = "server=localhost; database=8832;uid=root;password=;";
               string myconnstrng = "server=192.168.19.140; database=8832;uid=pp8832;password=8832;";

                conn = new MySqlConnection(myconnstrng);
            }
            catch (MySqlException sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return conn;
        }
        
    }
}
