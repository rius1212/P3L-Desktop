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
    public partial class CabangForm : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public string id;
        public CabangForm()
        {
            InitializeComponent();
        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" && alamattb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }

            else
            {
                conn.Open();
                string sql = "INSERT INTO cabang(NAMA_CABANG, ALAMAT_CABANG) VALUES(@nama,@alamat)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nama", namatb.Text);
                cmd.Parameters.AddWithValue("@alamat", alamattb.Text);


                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal");
                }
                conn.Close();

            }
            FillDGVS();
            clear();
        }

        public void FillDGVS()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT ID_CABANG as ID, NAMA_CABANG as NAMA ,ALAMAT_CABANG as ALAMAT FROM cabang", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridVCbg.RowTemplate.Height = 60;
            dataGridVCbg.AllowUserToAddRows = false;
            dataGridVCbg.DataSource = table;
            dataGridVCbg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void dataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            namatb.Text = dataGridVCbg.Rows[rowIndex].Cells[1].Value.ToString();
            alamattb.Text = dataGridVCbg.Rows[rowIndex].Cells[2].Value.ToString();
            id = dataGridVCbg.Rows[rowIndex].Cells[0].Value.ToString();
            upbtn.Enabled = true;
            addbtn.Enabled = false;
            upbtn.BackColor = Color.Blue;

        }
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT ID_CABANG as ID, NAMA_CABANG as NAMA ,ALAMAT_CABANG as ALAMAT FROM cabang WHERE NAMA_CABANG LIKE '%" + key + "%' ";
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                dataGridVCbg.DataSource = dt;
            }
            else
            {
                FillDGVS();
            }
        }
        public void clear()
        {
            namatb.Text = "";
            alamattb.Text = "";
            id = null;
        }
        private void upbtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" || alamattb.Text == "" )
            {
                    MessageBox.Show("Ada Inputan yang Masih kosong ! ");

               
            }
            else
            {
                string sql = "UPDATE cabang SET NAMA_CABANG=@jml ,ALAMAT_CABANG=@sub WHERE ID_CABANG=@id";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@jml", namatb.Text);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@sub", alamattb.Text);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("update Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                upbtn.Enabled = false;
                upbtn.BackColor = Color.White;
                addbtn.Enabled = true;
                FillDGVS();
                clear();
                conn.Close();


            }
        }

        private void CabangForm_Load(object sender, EventArgs e)
        {
            FillDGVS();
            upbtn.Enabled = false;
            upbtn.BackColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridVCbg_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            namatb.Text = dataGridVCbg.Rows[rowIndex].Cells[1].Value.ToString();
            alamattb.Text = dataGridVCbg.Rows[rowIndex].Cells[2].Value.ToString();
            id = dataGridVCbg.Rows[rowIndex].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus Cabang ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                
                conn.Open();
                string sql = "DELETE FROM cabang WHERE ID_CABANG=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                
               
                string sql2 = "DELETE FROM pegawai WHERE CABANG=@cbg";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@cbg",namatb.Text );

                if (cmd2.ExecuteNonQuery() == 1)

                {
                   // MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                  //  MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Tidak jadi dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            clear();
            FillDGVS();
        }
    }
}
