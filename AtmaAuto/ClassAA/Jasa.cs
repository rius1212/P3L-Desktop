using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using AtmaAuto.ClassAA;
using System.Windows.Forms;
namespace AtmaAuto.ClassAA
{
    class Jasa
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public string ID { get; set; }
        public string Name { get; set; }
        public float biaya { get; set; }


        public DataTable Select()
        {
           
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM jasa_service";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                return dt;
                         }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(Jasa p)
        {
            bool isSuccess = false;
           
            conn.Open();
            try
            {
                string sql = "INSERT INTO jasa_service(ID_JASA_SERVICE,NAMA_JASA,HARGA_JASA) VALUES(@ID,@NAMA,@HARGA)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", p.ID);
                cmd.Parameters.AddWithValue("@NAMA", p.Name);
                cmd.Parameters.AddWithValue("@HARGA", p.biaya);
               
               int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool validId(string s)
        {
            
            string str = "select * from jasa_service";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("ID_JASA_SERVICE");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public bool Update(Jasa p)
        {
            bool isSuccess = false;
    
            conn.Open();
            try
            {
                string sql = "UPDATE jasa_service SET NAMA_JASA=@NAMA,HARGA_JASA=@HARGA WHERE ID_JASA_SERVICE=@ID  ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", p.ID);
                cmd.Parameters.AddWithValue("@NAMA", p.Name);
                cmd.Parameters.AddWithValue("@HARGA", p.biaya);

             
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(Jasa p)
        {
            bool isSuccess = false;
            // conn.Open();
            try
            {
                string sql = "DELETE FROM jasa_service  WHERE ID_JASA_SERVICE=@ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", p.ID);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                 conn.Open();
                string sql = "SELECT * FROM jasa_service WHERE ID_JASA_SERVICE LIKE '%" + key + "%' OR NAMA_JASA LIKE '%" + key + "%' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
              
                //conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        
    }
}
