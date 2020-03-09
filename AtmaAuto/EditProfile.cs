using AtmaAuto.ClassAA;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmaAuto
{
    public partial class EditProfile : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public EditProfile()
        {
            InitializeComponent();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT USERNAME,PASSWORD,NAMA_PEGAWAI,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI FROM pegawai WHERE IDPEGAWAI=@IDPEGAWAI ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IDPEGAWAI", AtmaAuto.idpeg);
                //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nametb.Text = reader.GetString(2); 
                    Usernametb.Text = reader.GetString(0);
                    Passwordtb.Text = reader.GetString(1);
                    alamattb.Text = reader.GetString(3);
                    telepontb.Text = reader.GetString(4);
                    //MessageBox.Show("Data Terupdate !");
                }
                
                //adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (Nametb.Text == "" || Usernametb.Text == "" || Passwordtb.Text == "" || alamattb.Text == "" || telepontb.Text == "")
            {
                MessageBox.Show("Ada Inputan belum diisi");
            }
            else {
                conn.Open();
                try
                {
                    string sql = "UPDATE pegawai SET NAMA_PEGAWAI=@NAMA_PEGAWAI,USERNAME=@USERNAME,PASSWORD=@PASSWORD,ALAMAT_PEGAWAI=@ALAMAT_PEGAWAI,NO_TELP_PEGAWAI=@NO_TELP_PEGAWAI WHERE IDPEGAWAI=@IDPEGAWAI  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@IDPEGAWAI", AtmaAuto.idpeg);
                    cmd.Parameters.AddWithValue("@NAMA_PEGAWAI", Nametb.Text);
                    cmd.Parameters.AddWithValue("@USERNAME", Usernametb.Text);
                    cmd.Parameters.AddWithValue("@PASSWORD", Passwordtb.Text);
                    cmd.Parameters.AddWithValue("@ALAMAT_PEGAWAI", alamattb.Text);
                    cmd.Parameters.AddWithValue("@NO_TELP_PEGAWAI", telepontb.Text);

                    // conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Data Terupdate !");
                        AdminView.nama = Nametb.Text;
                        AtmaAuto frm2 = new AtmaAuto();
                        if (AtmaAuto.ted=="Owner")
                        {
                            AdminView obj = (AdminView)Application.OpenForms["AdminView"];
                            obj.Close();
                        }
                        else {
                           
                            User obj = (User)Application.OpenForms["User"];
                            obj.Close();
                        }
                        
                       
                        AtmaAuto.log = "LogOut";
                        frm2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak terupdate !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    
                    conn.Close();
                    this.Close();
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Passwordtb.UseSystemPasswordChar = false;
            }
            else
            {
                Passwordtb.UseSystemPasswordChar = true;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Nametb.Text = "";
            Usernametb.Text = "";
            Passwordtb.Text = "";
            alamattb.Text = "";
           
            telepontb.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
