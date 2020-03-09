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
    public partial class PendapatanBln : Form
    {
        CrystalReportPenBulanan sp = new CrystalReportPenBulanan();
        MySqlConnection conn = LoginDAL.getConnection();
        public PendapatanBln()
        {
            InitializeComponent();
        }
        public void CekBulan(string tahun)

        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Bulan", typeof(string));
            kons.Columns.Add("Service", typeof(double));
            kons.Columns.Add("Sparepart", typeof(double));
            kons.Columns.Add("Total", typeof(double));
            kons.Columns.Add("Tahun", typeof(string));


            string sql = "SELECT bln, tahun, sum(service), sum(sparepart), sum(service) + sum(sparepart) FROM(SELECT m.bulan AS bln, year(p.TANGGAL_TRANS) as tahun, 0 as service, 0 as sparepart FROM(SELECT 'January' AS bulan UNION SELECT 'February' AS bulan UNION SELECT 'March' AS bulan UNION SELECT 'April' AS bulan UNION SELECT 'May' AS bulan UNION SELECT 'June' AS bulan UNION SELECT 'July' AS bulan UNION SELECT 'August' AS bulan UNION SELECT 'September' AS bulan UNION SELECT 'October' AS bulan UNION SELECT 'November' AS bulan UNION SELECT 'December' AS bulan) AS m LEFT JOIN transaksi_penjualan p ON MONTHNAME(p.TANGGAL_TRANS) = m.bulan  UNION  SELECT MONTHNAME(TANGGAL_TRANS) as bln, year(TANGGAL_TRANS) as tahun, SUBTOTAL as service, 0 as sparepart FROM transaksi_penjualan JOIN detil_service USING(NO_TRANSAKSI) where year(TANGGAL_TRANS)=@tahun UNION ALL SELECT MONTHNAME(TANGGAL_TRANS) as bln, year(TANGGAL_TRANS) as tahun, 0 as service, SUBTOTAL_SP as sparepart FROM transaksi_penjualan JOIN detil_sparepart USING(NO_TRANSAKSI) where year(TANGGAL_TRANS)=@tahun) a  GROUP BY bln ORDER BY str_to_date(bln, '%M')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
           
            while (reader.Read())
            {
                x = x + 1;
               // string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(reader.GetString(0)));
                DataRow row = kons.NewRow();
                row["No"] = x;
                row["Sparepart"] = double.Parse(reader.GetString(3));
                row["Service"] = double.Parse(reader.GetString(2));
                row["Total"] = double.Parse(reader.GetString(4));
                row["Bulan"] = reader.GetString(0);
                row["Tahun"] = tahun;
                kons.Rows.Add(row);
            }
            conn.Close();
            
            sp.Database.Tables["PendapatanBulanan"].SetDataSource(kons);
        }

        private void PendapatanBln_Load(object sender, EventArgs e)
        {
            string sql = "select DISTINCT year(b.TANGGAL_TRANS) as tahun from detil_sparepart a join transaksi_penjualan b ON a.NO_TRANSAKSI = b.NO_TRANSAKSI";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
          
           
            while (reader.Read())
            {
                tahunCb.Items.Add(reader["tahun"]);
            }
            tahunCb.SelectedIndex = 0;
            conn.Close();


            crystalReportViewer1.ReportSource = sp;
        }
        private void TahunCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tahunCb.Text == "==Pilih==" || tahunCb.Text == "" )
            {
                crystalReportViewer1.ReportSource = null;
                
            }
            else
            {
                MessageBox.Show("cekcek");
                conn.Close();
                CekBulan(tahunCb.Text);

            }
        }
    }

}
