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

namespace AtmaAuto.ClassAA
{
    class User
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public int IDPEG { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
        public float Gaji { get; set; }
        public string Role { get; set; }

        //static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrg"].ConnectionString;
        private User(int id, String u, String p, String name, String alamat, String telp, float gj, String rol)
        {
            IDPEG = id;
            Username = u;
            Password = p;
            Name = name;
            Alamat = alamat;
            Telepon = telp;
            Gaji = gj;
            Role = rol;
        }
        public static List<User> GetUsers()
        {
            MySqlConnection conn = LoginDAL.getConnection();
            List<User> users = new List<User>();

            String query = "SELECT * FROM pegawai";

            MySqlCommand cmd = new MySqlCommand(query,conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["IDPEGAWAI"];

                String username = reader["USERNAME"].ToString();
                String password = reader["PASSWORD"].ToString();
                String nama = reader["NAMA_PEGAWAI"].ToString();
                String alamat = reader["ALAMAT_PEGAWAI"].ToString();
                String telp = reader["NO_TELP_PEGAWAI"].ToString();
                float gj= (float)reader["GAJI"];
                String rol= reader["ROLE"].ToString();
                User u = new User(id, username, password,nama,alamat,telp,gj,rol);

                users.Add(u);
            }

            reader.Close();

            conn.Close();

            return users;
        }

        public  User Insert( String nama, String u, String p, String alamat, String telp, float gj, String rol)
        {
            String query = string.Format("INSERT INTO   pegawai(NAMA_PEGAWAI,USERNAME,PASSWORD,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,GAJI,ROLE)  VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}')", nama, u,p, alamat, telp, gj, rol);

            MySqlCommand cmd = new MySqlCommand(query, conn);

           conn.Open();

            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;

            User user = new User(id, u, p, nama, alamat, telp, gj, rol);
            conn.Close();

            return user;

        }
        /*public void Update(string u, string p)
        {
            String query = string.Format("UPDATE users SET username='{0}', password='{1}' WHERE ID={2}", u, p, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }

        public void Delete()
        {
            String query = string.Format("DELETE FROM users WHERE ID={0}", Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }*/
        /*  public bool Insert(Pegawai p)
          {
              bool isSuccess = false;
              //SqlConnection conn = new SqlConnection(myconnstrng);
              conn.Open();
              try
              {
                  string sql = "INSERT INTO pegawai(NAMA_PEGAWAI,USERNAME,PASSWORD,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,GAJI,ROLE) VALUES(@NAMA_PEGAWAI,@USERNAME,@PASSWORD,@ALAMAT_PEGAWAI,@NO_TELP_PEGAWAI,@GAJI,@ROLE)";
                  MySqlCommand cmd = new MySqlCommand(sql, conn);

                  cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                  cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                  cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                  cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                  cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                  cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                  cmd.Parameters.AddWithValue("@ROLE", p.Role);

                  //   conn.Open();
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
              //SqlConnection conn = new SqlConnection(myconnstrng);
              conn.Open();
              try
              {
                  string sql = "UPDATE pegawai SET NAMA_PEGAWAI=@NAMA_PEGAWAI,USERNAME=@USERNAME,PASSWORD=@PASSWORD,ALAMAT_PEGAWAI=@ALAMAT_PEGAWAI,NO_TELP_PEGAWAI=@NO_TELP_PEGAWAI,GAJI=@GAJI,ROLE=@ROLE WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                  MySqlCommand cmd = new MySqlCommand(sql, conn);

                  cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                  cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                  cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                  cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                  cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                  cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                  cmd.Parameters.AddWithValue("@ROLE", p.Role);

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
              conn.Open();
              try
              {
                  string sql = "DELETE FROM pegawai  WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                  MySqlCommand cmd = new MySqlCommand(sql, conn);

                  cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                  cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                  cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                  cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                  cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                  cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                  cmd.Parameters.AddWithValue("@ROLE", p.Role);

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

              }
              finally
              {
                  conn.Close();
              }
              return isSuccess;
          }*/
    }
}

/*
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

        //static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrg"].ConnectionString;
        private Pegawai(String id, String u, String p, String name, String alamat, String telp, float gj, String rol)
        {
            IDPEG = id;
            Username = u;
            Password = p;
            Name = name;
            Alamat = alamat;
            Telepon = telp;
            Gaji = gj;
            Role = rol;
        }
        public DataTable Select()
        {
            // SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM pegawai";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                // MySqlDataAdapter reader = cmd.ExecuteAdapter();
                //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // conn.Open();
                //  adapter.Fill(dt);
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
        public bool Insert(Pegawai p)
        {
            bool isSuccess = false;
            //SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            try
            {
                string sql = "INSERT INTO pegawai(NAMA_PEGAWAI,USERNAME,PASSWORD,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,GAJI,ROLE) VALUES(@NAMA_PEGAWAI,@USERNAME,@PASSWORD,@ALAMAT_PEGAWAI,@NO_TELP_PEGAWAI,@GAJI,@ROLE)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                cmd.Parameters.AddWithValue("@ROLE", p.Role);

                //   conn.Open();
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
            //SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            try
            {
                string sql = "UPDATE pegawai SET NAMA_PEGAWAI=@NAMA_PEGAWAI,USERNAME=@USERNAME,PASSWORD=@PASSWORD,ALAMAT_PEGAWAI=@ALAMAT_PEGAWAI,NO_TELP_PEGAWAI=@NO_TELP_PEGAWAI,GAJI=@GAJI,ROLE=@ROLE WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                cmd.Parameters.AddWithValue("@ROLE", p.Role);

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
            conn.Open();
            try
            {
                string sql = "DELETE FROM pegawai  WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", p.Name);
                cmd.Parameters.AddWithValue("@USERNAME", p.Username);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", p.Alamat);
                cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", p.Telepon);
                cmd.Parameters.AddWithValue("@GAJI", p.Gaji);
                cmd.Parameters.AddWithValue("@ROLE", p.Role);

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

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
*/