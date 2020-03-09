using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmaAuto
{
    class Pegawai
    {
        public string IDPEG { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
        public float Gaji { get; set; }
        public string Role { get; set; }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrg"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM pegawai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
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
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO pegawai(NAMA_PEGAWAI,USERNAME,PASSWORD,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,GAJI,ROLE) VALUES(@NAMA_PEGAWAI,@USERNAME,@PASSWORD,@ALAMAT_PEGAWAI,@NO_TELP_PEGAWAI,@GAJI,@ROLE)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue ("@NAMA_PEGAWAI", p.Name);
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
                else {
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
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE pegawai SET NAMA_PEGAWAI=@NAMA_PEGAWAI,USERNAME=@USERNAME,PASSWORD=@PASSWORD,ALAMAT_PEGAWAI=@ALAMAT_PEGAWAI,NO_TELP_PEGAWAI=@NO_TELP_PEGAWAI,GAJI=@GAJI,ROLE=@ROLE WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                SqlCommand cmd = new SqlCommand(sql, conn);

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
        public bool Delete(Pegawai p)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM pegawai  WHERE NAMA_PEGAWAI=@NAMA_PEGAWAI ";
                SqlCommand cmd = new SqlCommand(sql, conn);

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
