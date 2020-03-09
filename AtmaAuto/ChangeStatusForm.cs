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
    public partial class ChangeStatusForm : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public ChangeStatusForm()
        {
            InitializeComponent();
        }
        public void FillDGV()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT a.ID_DETIL_SERVICE as ID , a.NO_TRANSAKSI as TRANSAKSI, k.TANGGAL_TRANS as TANGGAL, V.NAMA_KONSUMEN AS CUSTOMER, b.NOPOL AS PLAT,c.NAMA_JASA AS JASA, a.STATUS as STATUS,x.NAMA_PEGAWAI as CS FROM detil_service a JOIN kendaraan b on b.ID_KENDARAAN=a.ID_KENDARAAN join jasa_service c on a.ID_JASA_SERVICE=c.ID_JASA_SERVICE join pegawai x on x.NAMA_PEGAWAI=a.MONTIR JOIN transaksi_penjualan k on k.NO_TRANSAKSI=a.NO_TRANSAKSI JOIN konsumen V ON V.ID_KONSUMEN=K.ID_KONSUMEN where a.STATUS='N' AND  x.CABANG=@cbg ", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@cbg",AtmaAuto.cbg );

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridChange.RowTemplate.Height = 60;
            dataGridChange.AllowUserToAddRows = false;
            dataGridChange.DataSource = table;
            dataGridChange.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void ChangeStatusForm_Load(object sender, EventArgs e)
        {
            FillDGV();
        }
        private void cariSp_TextChanged(object sender, EventArgs e)
        {
            string key = cari.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                dataGridChange.DataSource = dt;
            }
            else
            {
                FillDGV();
            }
        }
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT a.ID_DETIL_SERVICE as ID , a.NO_TRANSAKSI as TRANSAKSI, b.NOPOL AS PLAT,c.NAMA_JASA AS JASA, a.STATUS as STATUS FROM detil_service a JOIN kendaraan b on b.ID_KENDARAAN=a.ID_KENDARAAN join jasa_service c on a.ID_JASA_SERVICE=c.ID_JASA_SERVICE WHERE  a.NO_TRANSAKSI LIKE '%" + key + "%' OR b.NOPOL LIKE '%" + key + "%'";
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
        private void dataGridChange_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengganti status pengerjaan ini ?", "Ganti Status", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                    conn.Open();
                string sql = "UPDATE detil_service SET STATUS='Y' WHERE ID_DETIL_SERVICE=@a ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@a", dataGridChange.Rows[rowIndex].Cells[0].Value.ToString());

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Berhasil mengubah status !");
                }
                else
                {
                    MessageBox.Show(" gagal mengubah status !");

                }
            }
           
            FillDGV();
           
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
