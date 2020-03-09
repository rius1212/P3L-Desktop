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
    public partial class Form1 : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public Form1()
        {
            InitializeComponent();
          
            UpdateBtn.Enabled = false;
          
            UpdateBtn.BackColor = Color.White;
        }
        Pegawai c = new Pegawai();
        //private object pdal;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataPegGridView.DataSource = c.Select();
            string query = "SELECT * FROM cabang";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cabangtb.Items.Add(reader["NAMA_CABANG"]);
                
            }
            conn.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void caritb_TextChanged(object sender, EventArgs e)
        {
            string key = caritb.Text;
            if (key != null)
            {
                DataTable dt = c.search(key);
                dataPegGridView.DataSource = dt;
            }
            else
            {
                DataTable dt = c.Select();
                dataPegGridView.DataSource = dt;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
            c.Name = Nametb.Text;
            c.Username = Usernametb.Text;
            c.Password = Passwordtb.Text;
            c.Alamat = alamattb.Text;
            if (Gajitb.Text == "")
            {
                Gajitb.Text = "0";
            }
            c.Gaji = float.Parse(Gajitb.Text);
            c.Telepon = telepontb.Text;
            c.Role = Rolecb.Text;
            c.cabang = cabangtb.Text;

            if ( c.Name == "" || c.Username == "" || c.Password == "" || c.Alamat == "" || c.Telepon == "" || c.Role == "" || c.cabang == "" || cabangtb==null || Rolecb==null)
            {
                MessageBox.Show("Ada Inputan belum diisi");
            }
            else if(Passwordtb.Text.Length<8)
            {
                MessageBox.Show("password minimal 8 digit");
            }
            else if (c.Gaji == 0)
            {
                MessageBox.Show("Kolom Gaji bernilai nol");
            }
            else {
                   bool successz = c.validateUsername(c);
                if (successz ==true)
                {
                    MessageBox.Show("Username " + Usernametb.Text + " sudah ada, silahkan memasukan ulang username anda");
                    Clear();
                }
                else {
                bool success = c.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("Pegawai Baru Telah di tambahkan");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menambah Pegawai");
                    Clear();
                }
                DataTable dt = c.Select();
                dataPegGridView.DataSource = dt; }
                
            }
            

        }

        private void dataPegGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            Nametb.Text ="";
             Usernametb.Text = "";
             Passwordtb.Text = "";
            alamattb.Text = "";
            Gajitb.Text = "";
            telepontb.Text = "";
            Rolecb.Text = "";
            Idtb.Text = "";
            cabangtb.Text = "";
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //
            c.IDPEG = Idtb.Text;
            c.Name = Nametb.Text;
            c.Username = Usernametb.Text;
            c.Password = Passwordtb.Text;
            c.Alamat = alamattb.Text;
            c.Gaji = float.Parse(Gajitb.Text);
            c.Telepon = telepontb.Text;
            c.Role = Rolecb.Text;
            c.cabang = cabangtb.Text;
            if (Gajitb.Text == "")
            {
                Gajitb.Text = "0";
            }
            c.Gaji = float.Parse(Gajitb.Text);
            c.Telepon = telepontb.Text;
            c.Role = Rolecb.Text;
            c.cabang = cabangtb.Text;

            if (c.Name == "" || c.Username == "" || c.Password == "" || c.Alamat == "" || c.Telepon == "" || c.Role == "" || c.cabang == "" || cabangtb == null || Rolecb == null)
            {
                MessageBox.Show("Ada Inputan belum diisi");
            }
            else if (c.Gaji == 0)
            {
                MessageBox.Show("Kolom Gaji bernilai nol");
            }
            else {
                bool success = c.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Pegawai  Telah di Ubah");
                    DataTable dt = c.Select();
                    dataPegGridView.DataSource = dt;

                    UpdateBtn.Enabled = false;

                    UpdateBtn.BackColor = Color.White;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Mengubah Pegawai");

                }
            }
           
        }

        private void dataPegGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Idtb.Text = dataPegGridView.Rows[rowIndex].Cells[0].Value.ToString();
            Nametb.Text = dataPegGridView.Rows[rowIndex].Cells[3].Value.ToString();
            Usernametb.Text = dataPegGridView.Rows[rowIndex].Cells[1].Value.ToString();
            Passwordtb.Text = dataPegGridView.Rows[rowIndex].Cells[2].Value.ToString();
            alamattb.Text = dataPegGridView.Rows[rowIndex].Cells[4].Value.ToString();
            telepontb.Text = dataPegGridView.Rows[rowIndex].Cells[5].Value.ToString();
            Gajitb.Text = dataPegGridView.Rows[rowIndex].Cells[6].Value.ToString();
            Rolecb.Text = dataPegGridView.Rows[rowIndex].Cells[7].Value.ToString();
            cabangtb.Text = dataPegGridView.Rows[rowIndex].Cells[8].Value.ToString();
           
            UpdateBtn.Enabled = true;

          
            UpdateBtn.BackColor = Color.Blue;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            UpdateBtn.Enabled = false;

            UpdateBtn.BackColor = Color.White;
        }

        private void Deletebtn(object sender, EventArgs e)
        {
            c.IDPEG = Idtb.Text;
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus pegawai ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                bool success = c.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("Pegawai  Telah di Hapus ");
                    DataTable dt = c.Select();
                    dataPegGridView.DataSource = dt;
                    
                    UpdateBtn.Enabled = false;
                 
                    UpdateBtn.BackColor = Color.White;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus Pegawai");

                }
            }
            else
            {
                MessageBox.Show("Pegawai Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void load_Click(object sender, EventArgs e)
        {
          
            dataPegGridView.DataSource = c.Select();
        }

        private void Idtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gajitb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void telepontb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           AdminView peg = new AdminView();
            peg.Show();
            this.Hide();
        }

        private void dataPegGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            c.IDPEG = Idtb.Text;
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus pegawai ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                bool success = c.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("Pegawai  Telah di Hapus ");
                    DataTable dt = c.Select();
                    dataPegGridView.DataSource = dt;
                   
                    UpdateBtn.Enabled = false;
                    
                    UpdateBtn.BackColor = Color.White;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus Pegawai");

                }
            }
            else
            {
                MessageBox.Show("Pegawai Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Passwordtb_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
