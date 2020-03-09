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

namespace AtmaAuto
{
    class Pegawai
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public string IDPEG { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
        public float Gaji { get; set; }
        public string Role { get; set; }

        public string cabang { get; set; }
        public DataTable Select()
        {
         
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM pegawai WHERE NOT  ROLE='Owner'";
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
               // MessageBox.Show(ex);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(Pegawai p)
        {
            bool isSuccess = false;
            //SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            try
            {
                string sql = "INSERT INTO pegawai(NAMA_PEGAWAI,USERNAME,PASSWORD,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,GAJI,ROLE,CABANG) VALUES(@NAMA_PEGAWAI,@USERNAME,@PASSWORD,@ALAMAT_PEGAWAI,@NO_TELP_PEGAWAI,@GAJI,@ROLE,@CABANG)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@IDPEGAWAI", p.IDPEG);
                cmd.Parameters.AddWithValue ("@NAMA_PEGAWAI", p.Name);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                cmd.Parameters.AddWithValue("@ROLE", p.Role);
                cmd.Parameters.AddWithValue("@CABANG", p.cabang);
                //   conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else {
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
        public bool Update(Pegawai p)
        {
            bool isSuccess = false;
            conn.Open();
            try
            {
                string sql = "UPDATE pegawai SET NAMA_PEGAWAI=@NAMA_PEGAWAI,USERNAME=@USERNAME,PASSWORD=@PASSWORD,ALAMAT_PEGAWAI=@ALAMAT_PEGAWAI,NO_TELP_PEGAWAI=@NO_TELP_PEGAWAI,GAJI=@GAJI,ROLE=@ROLE, CABANG=@CABANG WHERE IDPEGAWAI=@IDPEGAWAI  ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDPEGAWAI", p.IDPEG);
                cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                cmd.Parameters.AddWithValue("@ROLE", p.Role);
                cmd.Parameters.AddWithValue("@CABANG", p.cabang);
                // conn.Open();
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
        public bool Delete(Pegawai p)
        {
            bool isSuccess = false;
           // conn.Open();
            try
            {
                string sql = "DELETE FROM pegawai  WHERE IDPEGAWAI=@IDPEGAWAI";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IDPEGAWAI", p.IDPEG);
              

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
            string sql = "SELECT * FROM pegawai WHERE IDPEGAWAI LIKE '%" + key + "%' OR NAMA_PEGAWAI LIKE '%" + key + "%' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        
            conn.Open();
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
        public bool validateUsername(Pegawai p)
        {
            string str = "select * from pegawai";
            conn.Open();
          MySqlCommand  command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("USERNAME");
                if (str == p.Username)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

    }
}
