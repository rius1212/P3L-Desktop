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
    public partial class PendapatanTahunForm : Form
    {
        CrystalReportPenTahunan pt = new CrystalReportPenTahunan();
        MySqlConnection conn = LoginDAL.getConnection();
        public PendapatanTahunForm()
        {
            InitializeComponent();
        }

        private void PendapatanTahunForm_Load(object sender, EventArgs e)
        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Tahun", typeof(string));
            kons.Columns.Add("Cabang", typeof(string));
            kons.Columns.Add("Total", typeof(double));

            string thn=null;
            string sql = "SELECT ALL CABANG , SUM(TOTAL_HARGA), YEAR(TANGGAL_TRANS) as tahun FROM transaksi_penjualan JOIN pegawai on NAMA_PEGAWAI=cs GROUP BY CABANG, tahun";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
           
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                
                DataRow row = kons.NewRow();
                if (thn == reader.GetString(2))
                {
                    row["Cabang"] = reader.GetString(0);
                    row["Total"] = reader.GetString(1);

                }
                else {
                    x = x + 1;
                    row["No"] = x;
                    row["Tahun"] = reader.GetString(2);
                    row["Cabang"] = reader.GetString(0);
                    row["Total"] = reader.GetString(1);
                    thn = reader.GetString(2); ;
                }
               

                kons.Rows.Add(row);
            }
            conn.Close();
            pt.Database.Tables["PenTahunan"].SetDataSource(kons);
            crystalReportViewPt.ReportSource = pt;
        }
    }
}
