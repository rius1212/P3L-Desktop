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
    public partial class CekTransaksi02 : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public string x;
        public CekTransaksi02()
        {
            InitializeComponent();
        }

        public void FillDGV()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT a.KODE_SPAREPART as KODE, z.NAMA_SPAREPART as SPAREPART, a.JUMLAH_SPAREPART as JUMLAH,a.SUBTOTAL_SP as SUBTOTAL FROM detil_sparepart a JOIN transaksi_penjualan b on a.NO_TRANSAKSI=b.NO_TRANSAKSI JOIN sparepart z on a.KODE_SPAREPART=z.KODE_SPAREPART WHERE a.NO_TRANSAKSI=@kode", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@kode", CekRiwayat.kode);

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridsP.RowTemplate.Height = 60;
            dataGridsP.AllowUserToAddRows = false;
            dataGridsP.DataSource = table;
            dataGridsP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void FillDGV2()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT a.ID_JASA_SERVICE as KODE, z.NAMA_JASA as SERVICE, a.JUMLAH_SERVICE as JUMLAH,a.JUMLAH_SERVICE as SUBTOTAL, c.NOPOL AS PLAT, A.MONTIR AS MONTIR FROM detil_service a JOIN transaksi_penjualan b on a.NO_TRANSAKSI=b.NO_TRANSAKSI join kendaraan c on a.ID_KENDARAAN=c.ID_KENDARAAN JOIN jasa_service z on a.ID_JASA_SERVICE=z.ID_JASA_SERVICE WHERE a.NO_TRANSAKSI=@kode", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@kode", CekRiwayat.kode);

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridSv.RowTemplate.Height = 60;
            dataGridSv.AllowUserToAddRows = false;
            dataGridSv.DataSource = table;
            dataGridSv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CekRiwayat dd = new CekRiwayat();
            dd.Show();
            this.Hide();
        }
   
        private void CekTransaksi02_Load(object sender, EventArgs e)
        {
            FillDGV();
            FillDGV2();
            namatb.Text = CekRiwayat.cust;
            telptb.Text = CekRiwayat.hp;
            
        }

        private void stuk_Click(object sender, EventArgs e)
        {
            
            string sql = "SELECT  a.KEMBALIAN FROM transaksi_penjualan a where a.NO_TRANSAKSI=@kode";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kode", CekRiwayat.kode);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                x = reader.GetString(0);
                //   tahunCb.Items.Add(reader["tahun"]);
            }
            // tahunCb.SelectedIndex = 0;
            conn.Close();
            if (x == "-1")
            {
                MessageBox.Show("Transaksi tersebut belum melakukan pembayaran");

            }
            else {
                Struk02 f23 = new Struk02();
                f23.Show();
            }
        }
        public string checkID()
        {
            
            string q3;
          

                char[] separator = { '-' };
                string[] str = null;
                str = CekRiwayat.kode.Split(separator);
                q3 = str[0];



            return q3;
            
            // idmax.Text = reader.GetString(0);

        }
        private void spk_Click(object sender, EventArgs e)
        {
            if (checkID() == "SP")
            {
                MessageBox.Show("Transaksi : " + CekRiwayat.kode + " merupakan transaksi Sparepart !");
            }
            else {

            }
        }
    }
}
