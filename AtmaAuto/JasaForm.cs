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
    public partial class JasaForm : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public JasaForm()
        {
            InitializeComponent();
        }

        Jasa c = new Jasa();
        private void JasaForm_Load(object sender, EventArgs e)
        {
            JasaDG.DataSource = c.Select();
            BiayaJasaTB.Text = "0";
            setBtn();

        }

        public void setBtnActive()
        {
           
            UpdateBtn.Enabled = true;
           
            UpdateBtn.BackColor = Color.Blue;
        }
        public void setBtn()
        {
           
            UpdateBtn.Enabled = false;
           
            UpdateBtn.BackColor = Color.White;
        }
        private void caritb_TextChanged(object sender, EventArgs e)
        {
            string key = caritb.Text;
            if (key != null)
            {
                DataTable dt = c.search(key);
                JasaDG.DataSource = dt;
            }
            else
            {
                DataTable dt = c.Select();
                JasaDG.DataSource = dt;
            }
        }

       

        private void AddBtn_Click(object sender, EventArgs e)
        {

            c.ID = idtb.Text;
            c.Name = NamaJasaTB.Text;
            
            if (BiayaJasaTB.Text == "")
            {
                BiayaJasaTB.Text = "0";
            }
            c.biaya = float.Parse(BiayaJasaTB.Text);
            if (c.ID == "" && c.Name == "")
            {
                MessageBox.Show("Ada Inputan belum diisi kosong");
            }
            else if (c.biaya == 0)
            {
                MessageBox.Show("Kolom biaya bernilai nol");
            }
            else if (validid(idtb.Text) == true)
            {
                MessageBox.Show("Data di ID tersebut sudah ada ! ");
            }
            else
            {

                bool success = c.Insert(c);
                if (success == true)
                {
                    MessageBox.Show("jasa Telah di tambahkan");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menambah jasa");
                    Clear();
                }
                DataTable dt = c.Select();
                JasaDG.DataSource = dt;
            }
            
        }
        

      
        public void Clear()
        {
            NamaJasaTB.Text = "";
            idtb.Text = "";
            BiayaJasaTB.Text = "";
            
        }
        
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //

            c.ID = idtb.Text;
            c.Name = NamaJasaTB.Text;
            if (BiayaJasaTB.Text == "")
            {
                BiayaJasaTB.Text = "0";
            }
            c.biaya = float.Parse(BiayaJasaTB.Text);


            if (c.ID == "" && c.Name == "")
            {
                MessageBox.Show("Ada Inputan belum diisi kosong");
            }
            else if (c.biaya == 0)
            {
                MessageBox.Show("Kolom Gaji bernilai nol");
            }
            else {
                bool success = c.Update(c);
                if (success == true)
                {
                    MessageBox.Show("Jasa Telah di Ubah");
                    DataTable dt = c.Select();
                    JasaDG.DataSource = dt;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Mengubah jasa");
                    Clear();
                }
            }
           
            setBtn();
        }
        public bool validid(string s)
        {
            //bool istrue = false;
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


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            UpdateBtn.Enabled = false;

            UpdateBtn.BackColor = Color.White;
        }

        private void Deletebtn(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus jasa service ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                c.ID = idtb.Text;
                bool success = c.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("jasa  Telah di Hapus ");
                    DataTable dt = c.Select();
                    JasaDG.DataSource = dt;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus jasa");
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Jasa Service Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            setBtn();
        }

        private void load_Click(object sender, EventArgs e)
        {
         
            JasaDG.DataSource = c.Select();
           
        }

      

        private void biayatb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JasaDG_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            idtb.Text = JasaDG.Rows[rowIndex].Cells[0].Value.ToString();
            NamaJasaTB.Text = JasaDG.Rows[rowIndex].Cells[1].Value.ToString();
            BiayaJasaTB.Text = JasaDG.Rows[rowIndex].Cells[2].Value.ToString();
            setBtnActive();

        }

        private void Home_Click(object sender, EventArgs e)
        {
            AdminView peg = new AdminView();
            peg.Show();
            this.Hide();
        }

        private void JasaDG_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            idtb.Text = JasaDG.Rows[rowIndex].Cells[0].Value.ToString();
            NamaJasaTB.Text = JasaDG.Rows[rowIndex].Cells[1].Value.ToString();
            BiayaJasaTB.Text = JasaDG.Rows[rowIndex].Cells[2].Value.ToString();

            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus jasa service ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                c.ID = idtb.Text;
                bool success = c.Delete(c);
                if (success == true)
                {
                    MessageBox.Show("jasa  Telah di Hapus ");
                    DataTable dt = c.Select();
                    JasaDG.DataSource = dt;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus jasa");
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Jasa Service Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            setBtn();
        }
    }
}
