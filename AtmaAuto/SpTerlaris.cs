using AtmaAuto.ClassAA;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmaAuto
{
    public partial class SpTerlaris : Form
    {
        SparepartTerlaris sp = new SparepartTerlaris();
        MySqlConnection conn = LoginDAL.getConnection();
        public SpTerlaris()
        {
            InitializeComponent();
        }
        public void CekBulan(string tahun)

        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Bulan", typeof(string));
            kons.Columns.Add("NamaBarang", typeof(string));
            kons.Columns.Add("Tipe", typeof(string));
            kons.Columns.Add("Jumlah", typeof(string));
            kons.Columns.Add("Tahun", typeof(string));


            string sql = "SELECT bln, thn,nama,tipe,kode FROM (SELECT monthname(b.TANGGAL_TRANS) as Bln, year(b.TANGGAL_TRANS) as thn,c.NAMA_SPAREPART as nama,c.TIPEBARANG as tipe,COUNT(a.KODE_SPAREPART) as kode from transaksi_penjualan b join detil_sparepart a ON a.NO_TRANSAKSI = b.NO_TRANSAKSI JOIN sparepart c on a.KODE_SPAREPART=c.KODE_SPAREPART WHERE YEAR(b.TANGGAL_TRANS)=@tahun group by monthname(b.TANGGAL_TRANS) UNION SELECT m.bulan AS bln, year(p.TANGGAL_TRANS) as thn,'-' as nama,'-' as tipe, '-' as kode FROM (SELECT 'January' AS bulan UNION SELECT 'February' AS bulan UNION SELECT 'March' AS bulan UNION SELECT 'April' AS bulan UNION SELECT 'May' AS bulan UNION SELECT 'June' AS bulan UNION SELECT 'July' AS bulan UNION SELECT 'August' AS bulan UNION SELECT 'September' AS bulan UNION SELECT 'October' AS bulan UNION SELECT 'November' AS bulan UNION SELECT 'December' AS bulan ) AS m LEFT JOIN transaksi_penjualan p ON MONTHNAME(p.TANGGAL_TRANS) = m.bulan) a GROUP BY bln, thn HAVING @tahun ORDER BY str_to_date(bln,'%M')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            MySqlDataReader reader = cmd.ExecuteReader();
            int x=0;
            while (reader.Read())
            {
                x = x + 1;
              //  string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(reader.GetString(0)));
                DataRow row = kons.NewRow();
                row["No"] = x;
                row["Jumlah"] = reader.GetString(4);
                row["NamaBarang"] = reader.GetString(2);
                row["Tipe"] = reader.GetString(3);
                row["Bulan"] = reader.GetString(0);
                row["Tahun"] = tahun;
                kons.Rows.Add(row);
            }
            conn.Close();
            sp.Database.Tables["SpTerlaris"].SetDataSource(kons);
        }
        private void SpTerlaris_Load(object sender, EventArgs e)
        {
            string sql = "select DISTINCT year(b.TANGGAL_TRANS) as tahun from detil_sparepart a join transaksi_penjualan b ON a.NO_TRANSAKSI = b.NO_TRANSAKSI";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
            TahunCb.Items.Add("==Pilih==");
            TahunCb.SelectedIndex = 0;
            while (reader.Read())
            {
                TahunCb.Items.Add(reader["tahun"]);
            }
            conn.Close();
           
            
            crystalReportSp.ReportSource = sp;
        }

        private void TahunCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TahunCb.Text == "==Pilih==" || TahunCb.Text == "" || TahunCb.SelectedIndex == 0)
            {
                crystalReportSp.ReportSource = null;
            }
            else
            {
                CekBulan(TahunCb.Text);

            }
        }
    }
}
