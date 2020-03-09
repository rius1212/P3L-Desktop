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
    public partial class TransaksiLanjutForm : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public string dateboom;
        public string datein;
        public float subtotal1sp;
        public float subtotal1js;
        public int maxid;
        public int stok;
        public static string nama;
        public static int idken;
        public static string hp;
        public static string motor;
        public static int idkonsave;
        public string iddetilsp;
        public string iddetiljs;
       public static string notrans;
        public static string montir;
        public static float totfullsp;
        public static float totfulljs;
        public static float subtotal;
        public static int tesmasuk;
      

        public TransaksiLanjutForm()
        {
            InitializeComponent();
        }

      

        public void FillDGVSparepart()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT KODE_SPAREPART,RAK,NAMA_SPAREPART,STOK,GAMBAR, HARGA_JUAL,MERK FROM sparepart WHERE MERK=@merk", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@merk", TransaksiForm.merkken);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridsp.RowTemplate.Height = 60;
            dataGridsp.AllowUserToAddRows = false;
            dataGridsp.DataSource = table;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridsp.Columns[4];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void FillDGVJasa()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM jasa_service", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridJs.RowTemplate.Height = 60;
            dataGridJs.AllowUserToAddRows = false;
            dataGridJs.DataSource = table;
            dataGridJs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void FillDGVDetilSparepart()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM detil_sparepart WHERE NO_TRANSAKSI=@kode AND NOKEN=@noken", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@kode",notrans);
            cmd.Parameters.AddWithValue("@noken", TransaksiForm.noken);
            DataTable table = new DataTable();
            adapter.Fill(table);
            
            detiSpDataGrid.RowTemplate.Height = 60;
            detiSpDataGrid.AllowUserToAddRows = false;
            detiSpDataGrid.DataSource = table;
            detiSpDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void FillDGVDetilJasa()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM detil_service WHERE NO_TRANSAKSI=@kode AND ID_KENDARAAN=@idken", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@kode", notrans);
            cmd.Parameters.AddWithValue("@idken", TransaksiForm.noken);
            DataTable table = new DataTable();
            adapter.Fill(table);

            detilJsDataGrid.RowTemplate.Height = 60;
            detilJsDataGrid.AllowUserToAddRows = false;
            detilJsDataGrid.DataSource = table;
            detilJsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public DataTable searchSp(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT  KODE_SPAREPART,RAK,NAMA_SPAREPART,STOK,GAMBAR, HARGA_JUAL,MERK  FROM sparepart WHERE KODE_SPAREPART LIKE '%" + key + "%' OR NAMA_SPAREPART LIKE '%" + key + "%'  WHERE MERK=@merk";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@merk", TransaksiForm.merkken);
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


        public DataTable searchJs(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                string sql = "SELECT * FROM jasa_service WHERE ID_JASA_SERVICE LIKE '%" + key + "%' OR NAMA_JASA LIKE '%" + key + "%' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                //conn.Open();
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

        private void spiltconcatDate(string kodes)
        {
            string q1;
            string q2;
            string q3;
            char[] separator = { '/' };
            string[] str = null;
            str = kodes.Split(separator);

            q1 = str[0];
            q2 = str[1];
            q3 = str[2];
            if (q1.Length <= 1)
            {
                q1 = "0" + q1;
            }
            if (q2.Length <= 1)
            {
                q2 = "0" + q2;
            }
            var length = q3.Length;
            var firstHalf = q3.Substring(0, length / 2);
            var secondHalf = q3.Substring(length / 2, length - (length / 2));
            dateboom = q2+q1+secondHalf;
            datein = q3 +"-"+ q1 + "-"+ q2;

        }
        public int checkmaxID()
        {
            int value = 0;
            string q3;
            string sql = "SELECT NO_TRANSAKSI FROM transaksi_penjualan";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                char[] separator = { '-' };
                string[] str = null;
                str = reader.GetString(0).Split(separator);
                q3 = str[2];

                if (int.Parse(q3) > value)
                {
                    value = int.Parse(q3);
                }
            }
            conn.Close();
            return value;
            // idmax.Text = reader.GetString(0);

        }
        public void MakeIDtrans(int maxid)
        {
            int value = maxid + 1;
            idmax21.Text = value.ToString();

             notrans = "SS-" + tgltrans.Text +"-"+value.ToString();
            string sql = "INSERT INTO transaksi_penjualan(NO_TRANSAKSI,ID_KONSUMEN) VALUES(@notrans,@idkon) ";

            conn.Open();
           
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans",notrans );
            cmd.Parameters.AddWithValue("@idkon", TransaksiForm.idkon);
            cmd.Parameters.AddWithValue("@tggl", datein);

            if (cmd.ExecuteNonQuery() == 1)

            {
//                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("Terjadi Kesalahan dalam Generate ID Transaksi");
            }
            conn.Close();
        }
         public void montira()
        {
            string query = "SELECT * FROM pegawai where CABANG=@cbg";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cbg", AtmaAuto.cbg);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader.GetString(7)) == "Montir")
                {
                    MontirCb.Items.Add(reader["NAMA_PEGAWAI"]);
                }

            }
            conn.Close();
        }
        private void TransaksiLanjutForm_Load(object sender, EventArgs e)
        {
            //idmax21.Text= checkmaxID().ToString();
            
            FillDGVSparepart();
            FillDGVJasa();
            timerup.Start();
            idkonsave = TransaksiForm.idkon;
            //dateboom =;
            spiltconcatDate(DateTime.Now.ToShortDateString());
            tgltrans.Text = dateboom;
            dateshow.Text = DateTime.Now.ToLongDateString();
            timeshow.Text = DateTime.Now.ToLongTimeString();
            namatbx.Text = TransaksiForm.nama;
            idken = TransaksiForm.noken;
            nohptbx.Text = TransaksiForm.nohp;
            motortbx.Text = TransaksiForm.motor;
            nama = namatbx.Text;
            hp = nohptbx.Text;
            motor = motortbx.Text;
            upbtn.Enabled = false;
            upBtnJs.Enabled = false;
            upBtnJs.BackColor = Color.White;
            upBtnJs.Text = "";
            upbtn.BackColor = Color.White;
            upbtn.Text = "";
            montira();
            if (TransaksiForm.notranssave != null)
            {
                string q3;
                char[] separator = { '-' };
                string[] str = null;
                str = TransaksiForm.notranssave.Split(separator);
                q3 = str[2];
                tgltrans.Text = str[1];
                idmax21.Text = q3;
            }
            else {
                MakeIDtrans(checkmaxID());
            }

        }

        private void cariSp_TextChanged(object sender, EventArgs e)
        {
            string key = cariSp.Text;
            if (key != null)
            {
                DataTable dt = searchSp(key);
                dataGridsp.DataSource = dt;
            }
            else 
            {
                FillDGVSparepart();
            }
        }

        private void CariJs_TextChanged(object sender, EventArgs e)
        {
            string key = CariJs.Text;
            if (key != null)
            {
                DataTable dt = searchJs(key);
                dataGridJs.DataSource = dt;
            }
            else
            {
                FillDGVJasa();
            }
        }

        private void timerup_Tick(object sender, EventArgs e)
        {
            timeshow.Text = DateTime.Now.ToLongTimeString();
            timerup.Start();
        }

       

       

        private void dataGridsp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (int.Parse(dataGridsp.Rows[rowIndex].Cells[3].Value.ToString()) == 0)
            {
                MessageBox.Show("Stok Sparepart tersebut kosong ! ");
            }
            else {
                stok = int.Parse(dataGridsp.Rows[rowIndex].Cells[3].Value.ToString());
            
                kodesptb.Text = dataGridsp.Rows[rowIndex].Cells[0].Value.ToString();
                namasptb.Text = dataGridsp.Rows[rowIndex].Cells[2].Value.ToString();
                raksptb.Text = dataGridsp.Rows[rowIndex].Cells[1].Value.ToString();
                hargasptb.Text = dataGridsp.Rows[rowIndex].Cells[5].Value.ToString();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            TransaksiLanjutForm.notrans = null;
            tesmasuk = 0;
        }

        private void jumlahsptb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (jumlahsptb.Text == "")
                {
                    totsptb.Text = "";
                }
                totsptb.Text=(float.Parse(hargasptb.Text)*float.Parse(jumlahsptb.Text)).ToString();
                
            }
            catch
            {

            }
        }

        public void clear()

        {
            kodesptb.Text = "";
            raksptb.Text = "";
            namasptb.Text = "";
            hargasptb.Text = "";
            jumlahsptb.Text = "0";
            totsptb.Text = "0";
        }
        public int fullTotal()
        {
            int value = 0;
            string q3;
            string sql = "SELECT SUBTOTAL_SP FROM detil_sparepart WHERE NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    value = value + int.Parse(reader.GetString(0));
                
            }
            fulltot.Text = value.ToString();
            conn.Close();
            return value;
            // idmax.Text = reader.GetString(0);

        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (kodesptb.Text == "" || jumlahsptb.Text == "" || totsptb.Text == "" || totsptb.Text == "0")
            {
                totsptb.Text = "0";
                if (idJstb.Text == "")
                {
                    MessageBox.Show("Sparepart belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah item masih nol");
                }

            }
            else if (int.Parse(jumlahsptb.Text) > stok)
            {
                MessageBox.Show("Jumlah sparepart melebihi jumlah stok sparepart !" + stok);
            }
            else
            {
                string sql = "INSERT INTO detil_sparepart(NO_TRANSAKSI,KODE_SPAREPART,JUMLAH_SPAREPART,SUBTOTAL_SP,NOKEN) VALUES(@notrans,@kodesp,@jml,@subttl,@noken) ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notrans", notrans);
                cmd.Parameters.AddWithValue("@kodesp", kodesptb.Text);
                cmd.Parameters.AddWithValue("@noken", TransaksiForm.noken);
                cmd.Parameters.AddWithValue("@jml", jumlahsptb.Text);
                cmd.Parameters.AddWithValue("@subttl", totsptb.Text);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }


                conn.Close();
              
                fullTotal();
                
                FillDGVDetilSparepart();
                clear();
            }
            
        }

        private void jumlahsptb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void detiSpDataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int tem;
            kodesptb.Text = detiSpDataGrid.Rows[rowIndex].Cells[2].Value.ToString();
            jumlahsptb.Text = detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString();
            iddetilsp = detiSpDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
            tem = int.Parse(detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString());
            upbtn.Enabled = true;
            upbtn.BackColor = Color.Blue;
            upbtn.Text = "UPDATE";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT KODE_SPAREPART,RAK,NAMA_SPAREPART,HARGA_JUAL,STOK FROM sparepart ", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@sp", kodesptb.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (kodesptb.Text == reader.GetString(0) )
                {
                    raksptb.Text = reader.GetString(1);
                    namasptb.Text = reader.GetString(2);
                    hargasptb.Text = reader.GetString(3);
                    stok = int.Parse(reader.GetString(4)) + tem;
                }
            }
            
            conn.Close();
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            if (kodesptb.Text == "" || jumlahsptb.Text == "" || totsptb.Text == "" || totsptb.Text == "0")
            {
                totsptb.Text = "0";
                if (kodesptb.Text == "")
                {
                    MessageBox.Show("Sparepart belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah item masih nol");
                }

            }
            else
            {
                string sql = "UPDATE detil_sparepart SET JUMLAH_SPAREPART=@jml ,SUBTOTAL_SP=@sub WHERE ID_DETIL_SPAREPART=@id";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@jml", jumlahsptb.Text);
                cmd.Parameters.AddWithValue("@id",iddetilsp);
                cmd.Parameters.AddWithValue("@sub", totsptb.Text);
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
                upbtn.Text = "";
                
                conn.Close();
               
                FillDGVSparepart();
                FillDGVDetilSparepart();
              
                fullTotal();
                clear();
            }
        }

        private void detiSpDataGrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus Sparepart ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                int rowIndex = e.RowIndex;
                int sr;
                string kode;
                
                iddetilsp = detiSpDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
                sr = int.Parse(detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString());
                kode= detiSpDataGrid.Rows[rowIndex].Cells[2].Value.ToString();
                
                conn.Open();
                string sql = "DELETE FROM detil_sparepart WHERE ID_DETIL_SPAREPART=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", iddetilsp);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
                
            }
            else
            {
                MessageBox.Show("Sparepart Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fullTotal();
            FillDGVSparepart();
            upbtn.Enabled = false;
            upbtn.BackColor = Color.White;
            upbtn.Text = "";
            FillDGVDetilSparepart();
            
            clear(); 
        }
        ///////////////////////////////////////////////////// Jasa Service//////////////////////////////////////////////
        private void dataGridJs_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            idJstb.Text = dataGridJs.Rows[rowIndex].Cells[0].Value.ToString();
            namaJstb.Text = dataGridJs.Rows[rowIndex].Cells[1].Value.ToString();
            hargaJstb.Text = dataGridJs.Rows[rowIndex].Cells[2].Value.ToString();
            
        }

        private void jumJstb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void jumJstb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (jumJstb.Text == "")
                {
                    totJstb.Text = "";
                }
                totJstb.Text = (float.Parse(hargaJstb.Text) * float.Parse(jumJstb.Text)).ToString();

            }
            catch
            {
                
            }
        }
        public void clearJs()

        {
            idJstb.Text = "";
            namaJstb.Text = "";
            hargaJstb.Text = "";
            jumJstb.Text = "";
            totJstb.Text = "0";
        }
        public int fullTotalJs()
        {
            int value = 0;
            string q3;
            string sql = "SELECT SUBTOTAL FROM detil_service WHERE NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                value = value + int.Parse(reader.GetString(0));

            }
            fulltotJs.Text = value.ToString();
            conn.Close();
            return value;
            // idmax.Text = reader.GetString(0);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (idJstb.Text == "" || namaJstb.Text == "" || totJstb.Text == "" || totJstb.Text == "0")
            {
                totJstb.Text = "0";
                if (kodesptb.Text == "")
                {
                    MessageBox.Show("Jasa Service belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah Jasa masih nol");
                }

            }
            else if (MontirCb.Text == "")
            {
                MessageBox.Show("Montir belum terpilih ! ");
            }
            else
            {
                montir = MontirCb.Text;
                string sql = "INSERT INTO detil_service(NO_TRANSAKSI,ID_JASA_SERVICE,ID_KENDARAAN,STATUS,JUMLAH_SERVICE,SUBTOTAL,Montir) VALUES(@notrans,@id,@idken,@st,@jml,@subttl,@mon) ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notrans", notrans);
                cmd.Parameters.AddWithValue("@id", idJstb.Text);
                cmd.Parameters.AddWithValue("@idken", TransaksiForm.noken);
                cmd.Parameters.AddWithValue("@st", "N");
                cmd.Parameters.AddWithValue("@mon", montir);
                cmd.Parameters.AddWithValue("@jml", jumJstb.Text);
                cmd.Parameters.AddWithValue("@subttl", totJstb.Text);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                FillDGVDetilJasa();
                conn.Close();
                fullTotalJs();
                clearJs();
            }

        }

        private void detilJsDataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            idJstb.Text = detilJsDataGrid.Rows[rowIndex].Cells[2].Value.ToString();
            jumJstb.Text = detilJsDataGrid.Rows[rowIndex].Cells[6].Value.ToString();
            iddetiljs = detilJsDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
            upBtnJs.Enabled = true;
            upBtnJs.BackColor = Color.Blue;
            upBtnJs.Text = "UPDATE";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM jasa_service", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@js", idJstb.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
         
                if (idJstb.Text == reader.GetString(0))
                {
                    namaJstb.Text = reader.GetString(1);
                    hargaJstb.Text = reader.GetString(2);
                }
            }

            conn.Close();
        }

        private void upBtnJs_Click(object sender, EventArgs e)
        {
            if (idJstb.Text == "" || namaJstb.Text == "" || totJstb.Text == "" || totJstb.Text == "0")
            {
                totJstb.Text = "0";
                if (idJstb.Text == "")
                {
                    MessageBox.Show("Jasa belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah Jasa masih nol");
                }

            }
            else if (MontirCb.Text == "")
            {
                MessageBox.Show("Montir belum terpilih ! ");
            }
            else
            {
                montir = MontirCb.Text;
                string sql = "UPDATE detil_service SET JUMLAH_SERVICE=@jml,SUBTOTAL=@sub,Montir=@mon WHERE ID_DETIL_SERVICE=@id";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@jml", jumJstb.Text);
                cmd.Parameters.AddWithValue("@id", iddetiljs);
                cmd.Parameters.AddWithValue("@mon", montir);
                cmd.Parameters.AddWithValue("@sub", totJstb.Text);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("update Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                upBtnJs.Enabled = false;
                upBtnJs.BackColor = Color.White;
                upBtnJs.Text = "";
                FillDGVDetilJasa();
                conn.Close();
                fullTotalJs();
                clearJs();
            }
        }

        private void detilJsDataGrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus jasa Service ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                int rowIndex = e.RowIndex;
                iddetiljs = detilJsDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
                conn.Open();
                string sql = "DELETE FROM detil_service WHERE ID_DETIL_SERVICE=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", iddetiljs);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Jasa Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fullTotalJs();
            upBtnJs.Enabled = false;
            upBtnJs.BackColor = Color.White;
            upBtnJs.Text = "";
            FillDGVDetilJasa();
            conn.Close();
            clearJs();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (fulltot.Text == "" && fulltotJs.Text == "")
            {
                MessageBox.Show("data masih kosong !");
            }
            else
            {
                if (fulltot.Text == "")
                {
                    fulltot.Text = "0";

                }
                if (fulltotJs.Text == "")
                {
                    fulltotJs.Text = "0";
                }
                totfulljs = float.Parse(fulltotJs.Text);
                totfullsp = float.Parse(fulltot.Text);
                subtotal = totfulljs + totfullsp;
                tesmasuk = 1;
               
                conn.Open();
                string sql = "UPDATE transaksi_penjualan SET SUB_TOTAL=@sub,CS=@cs,KEMBALIAN=-1,TANGGAL_TRANS=@tggl WHERE NO_TRANSAKSI=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@sub", subtotal);
                cmd.Parameters.AddWithValue("@tggl", datein + " " + DateTime.Now.ToLongTimeString());
                cmd.Parameters.AddWithValue("@cs", AtmaAuto.namas); 
                cmd.Parameters.AddWithValue("@id", notrans);
             
                if (cmd.ExecuteNonQuery() == 1)

                {
                   //MessageBox.Show("Transaksi Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal transaksi");
                }

                conn.Close();
                KonfirmasiSp admin = new KonfirmasiSp();
                 admin.Show();
                 


            }
        }
    }
}
