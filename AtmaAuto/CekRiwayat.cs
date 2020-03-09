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
    public partial class CekRiwayat : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public static string kode;
        public static string cust;
        public static string hp;
        public CekRiwayat()
        {
            InitializeComponent();
        }
        public void FillDGV()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT a.NO_TRANSAKSI as TRANSAKSI,a.TANGGAL_TRANS as TANGGAL,c.NAMA_KONSUMEN AS CUSTOMER ,C.NO_TELP_KON AS TELEPON,A.CS AS CS FROM konsumen c join transaksi_penjualan a on c.ID_KONSUMEN=a.ID_KONSUMEN JOIN pegawai b on a.CS=b.NAMA_PEGAWAI WHERE b.CABANG=@cbg ", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@cbg", AtmaAuto.cbg);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewFull.RowTemplate.Height = 60;
            dataGridViewFull.AllowUserToAddRows = false;
            dataGridViewFull.DataSource = table;
            dataGridViewFull.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void CekRiwayat_Load(object sender, EventArgs e)
        {
            FillDGV();
        }
       
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT a.NO_TRANSAKSI as TRANSAKSI,a.TANGGAL_TRANS as TANGGAL,c.NAMA_KONSUMEN AS CUSTOMER ,C.NO_TELP_KON AS TELEPON,A.CS AS CS  FROM konsumen c join transaksi_penjualan a on c.ID_KONSUMEN=a.ID_KONSUMEN JOIN pegawai b on a.CS=b.NAMA_PEGAWAI WHERE b.CABANG=@cbg AND a.NO_TRANSAKSI LIKE '%" + key + "%' OR c.NAMA_KONSUMEN LIKE '%" + key + "%' OR c.NO_TELP_KON LIKE '%" + key + "%'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cbg", AtmaAuto.cbg);
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
        private void cari_TextChanged(object sender, EventArgs e)
        {
            string key = cari.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                dataGridViewFull.DataSource = dt;
            }
            else
            {
                FillDGV();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewFull_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            kode = dataGridViewFull.Rows[rowIndex].Cells[0].Value.ToString();
            cust = dataGridViewFull.Rows[rowIndex].Cells[2].Value.ToString();
            hp = dataGridViewFull.Rows[rowIndex].Cells[3].Value.ToString();
            DialogResult result = MessageBox.Show("Cek Transaksi dari nomor transaksi : "+kode+ " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                CekTransaksi02 dd = new CekTransaksi02();
                dd.Show();
                this.Hide();

            }

           
        }
    }
}
