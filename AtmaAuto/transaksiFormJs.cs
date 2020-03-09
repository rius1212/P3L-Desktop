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
    public partial class transaksiFormJs : Form
    {
        public transaksiFormJs()
        {
            InitializeComponent();
        }

        private void transaksiFormJs_Load(object sender, EventArgs e)
        {
            setBtnKenAll(false, false);
            setBtnDeactive();
            FillDGVKonsumen();
            if (TransaksiJs.notrans != null)
            {
                string sql = "SELECT * FROM konsumen";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (TransaksiJs.idkonsave.ToString() == reader.GetString(0))
                    {
                        IDtb.Text = reader.GetString(0);
                        namatb.Text = reader.GetString(1);
                        nohptb.Text = reader.GetString(3);
                        alamattb.Text = reader.GetString(2);
                    }

                }
                setBtnKenAll(true, false);
                setBtnKonAll(false, false);
                addken.BackColor = Color.Lime;
                labelnama.Text = namatb.Text;

                ClearBtn.Text = "Ganti Konsumen";
                ClearBtn.Enabled = false;

                notranssave = TransaksiJs.notrans;
                conn.Close();
                FillDGVKendaraan();
                string query = "SELECT * FROM merk";
                conn.Open();
                MySqlCommand cmdx = new MySqlCommand(query, conn);
                MySqlDataReader readerx = cmdx.ExecuteReader();
                while (readerx.Read())
                {
                    MerkCb.Items.Add(readerx["merk"]);
                    merk.Add(new Merk()
                    {
                        id = ((int)readerx["idmerk"]),
                        merk = readerx["merk"] as string
                    });
                }
                conn.Close();
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM `tipe`", conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    tipe.Add(new Tipe()
                    {
                        id = ((int)reader2["id"]),
                        tipe = reader2["tipe"] as string,
                        merkid = ((int)reader2["idmerk"])

                    });
                }
                conn.Close();
            }
            else
            {

                string query = "SELECT * FROM merk";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MerkCb.Items.Add(reader["merk"]);
                    merk.Add(new Merk()
                    {
                        id = ((int)reader["idmerk"]),
                        merk = reader["merk"] as string
                    });
                }
                conn.Close();
                conn.Open();
                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM `tipe`", conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    tipe.Add(new Tipe()
                    {
                        id = ((int)reader2["id"]),
                        tipe = reader2["tipe"] as string,
                        merkid = ((int)reader2["idmerk"])

                    });
                }
                conn.Close();
            }
        }
        MySqlConnection conn = LoginDAL.getConnection();
        List<Merk> merk = new List<Merk>();
        List<Tipe> tipe = new List<Tipe>();
        public static string nama;
        public static int idkon;
        public static string nohp;
        public static int idken;
        public static string nopol;
        public static string merkken;
        public static string tipeken;
        public static string motor;
        public static int noken=-1;
        public int tekan = 0;
        public static string notranssave;
        
        public void clear()
        {
            IDtb.Text = "";
            namatb.Text = "";
            alamattb.Text = "";
            nohptb.Text = "";
        }
        public void cleark()
        {
            nopoltb.Text = "";
            MerkCb.Text = "";
            TipeCb.Text = "";
        }
        public void FillDGVKonsumen()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM konsumen", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridKonsumen.RowTemplate.Height = 60;
            dataGridKonsumen.AllowUserToAddRows = false;
            dataGridKonsumen.DataSource = table;
            dataGridKonsumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void FillDGVKendaraan()
        {

            MySqlCommand cmd = new MySqlCommand("SELECT ID_KENDARAAN, NOPOL,MERK_KEN,TIPE_KEN FROM kendaraan WHERE ID_KONSUMEN=@id", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", IDtb.Text);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridKendaraan.RowTemplate.Height = 60;
            dataGridKendaraan.AllowUserToAddRows = false;
            dataGridKendaraan.DataSource = table;
            dataGridKendaraan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public bool validIdKonsum(string s)
        {
            //bool istrue = false;
            string str = "select * from konsumen";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("ID_KONSUMEN");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

       
        private string[] GetTipeById(int id)
        {
            return tipe.Where(line => line.merkid == id).Select(l => l.tipe).ToArray();
        }


        private void MerkCb_SelectedIndexChanged(object sender, EventArgs e)
        {

            TipeCb.Items.Clear();
            int id = merk[MerkCb.SelectedIndex].id;
            foreach (string name in GetTipeById(id))
            {
                this.TipeCb.Items.Add(name);
            }
        }
        public void setBtnActive()
        {
            DeleteBtn.Enabled = true;
            UpdateBtn.Enabled = true;
            DeleteBtn.BackColor = Color.Red;
            UpdateBtn.BackColor = Color.Blue;
        }
        public void setBtnKenAll(bool cos, bool sin)
        {
            nopoltb.Enabled = cos;
            MerkCb.Enabled = cos;
            TipeCb.Enabled = cos;
            carikentb.Enabled = cos;
            dataGridKendaraan.Enabled = cos;
            delken.Enabled = sin;
            upken.Enabled = sin;
            addken.Enabled = cos;
            carikentb.Enabled = cos;
            delken.BackColor = Color.White;
            upken.BackColor = Color.White;
            addken.BackColor = Color.White;
        }
        public void setBtnKonAll(bool cos, bool sin)
        {
            IDtb.Enabled = cos;
            namatb.Enabled = cos;
            alamattb.Enabled = cos;
            nohptb.Enabled = cos;
            dataGridKonsumen.Enabled = cos;
            DeleteBtn.Enabled = sin;
            UpdateBtn.Enabled = sin;
            InsertBtn.Enabled = cos;
            DeleteBtn.BackColor = Color.White;
            UpdateBtn.BackColor = Color.White;
            InsertBtn.BackColor = Color.White;
            textBox1.Enabled = cos;
        }
        public void setBtnDeactive()
        {
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            DeleteBtn.BackColor = Color.White;
            UpdateBtn.BackColor = Color.White;
        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" && alamattb.Text == "" && nohptb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else if (validIdKonsum(IDtb.Text) == true)
            {
                MessageBox.Show("ID Konsumen sudah ada !");
            }
            else
            {
                conn.Open();
                string sql = "INSERT INTO konsumen(NAMA_KONSUMEN, ALAMAT_KON,NO_TELP_KON) VALUES(@nama,@alamat,@telp)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@telp", nohptb.Text);
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
                FillDGVKonsumen();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nohptb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void dataGridKonsumen_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            IDtb.Text = dataGridKonsumen.Rows[rowIndex].Cells[0].Value.ToString();
            namatb.Text = dataGridKonsumen.Rows[rowIndex].Cells[1].Value.ToString();
            alamattb.Text = dataGridKonsumen.Rows[rowIndex].Cells[2].Value.ToString();
            nohptb.Text = dataGridKonsumen.Rows[rowIndex].Cells[3].Value.ToString();

            setBtnActive();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" && alamattb.Text == "" && nohptb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else
            {
                conn.Open();
                string sql = "UPDATE konsumen SET NAMA_KONSUMEN=@nama, ALAMAT_KON=@alamat,NO_TELP_KON=@notlp WHERE ID_KONSUMEN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", IDtb.Text);
                cmd.Parameters.AddWithValue("@notlp", nohptb.Text);
                cmd.Parameters.AddWithValue("@nama", namatb.Text);
                cmd.Parameters.AddWithValue("@alamat", alamattb.Text);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Update Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal Update !");
                }
                FillDGVKonsumen();
                setBtnDeactive();
                clear();
                conn.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus konsumen ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                conn.Open();
                string sql = "DELETE FROM konsumen WHERE ID_KONSUMEN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", IDtb.Text);

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
                MessageBox.Show("Konsumen Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FillDGVKonsumen();
            setBtnDeactive();
            clear();
        }
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM konsumen WHERE NAMA_KONSUMEN LIKE '%" + key + "%' ";
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
        private void ClearBtn_Click(object sender, EventArgs e)
        {

            if (tekan == 1)
            {
                setBtnKonAll(true, false);
                InsertBtn.BackColor = Color.Lime;
                labelnama.Text = "";
                ClearBtn.Text = "Kelola Kendaraan";
                setBtnKenAll(false, false);

                tekan = 0;
            }
            else if (IDtb.Text == "")
            {
                MessageBox.Show("Calon Konsumen belum Ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tekan = 1;
                setBtnKenAll(true, false);
                setBtnKonAll(false, false);
                addken.BackColor = Color.Lime;
                labelnama.Text = namatb.Text;
                FillDGVKendaraan();
                ClearBtn.Text = "Ganti Konsumen";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                dataGridKonsumen.DataSource = dt;
            }
            else
            {
                FillDGVKonsumen();
            }
        }

        private void dataGridKendaraan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridKendaraan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            nopoltb.Text = dataGridKendaraan.Rows[rowIndex].Cells[1].Value.ToString();
            MerkCb.Text = dataGridKendaraan.Rows[rowIndex].Cells[2].Value.ToString();
            TipeCb.Text = dataGridKendaraan.Rows[rowIndex].Cells[3].Value.ToString();
            noken = int.Parse(dataGridKendaraan.Rows[rowIndex].Cells[0].Value.ToString());
            idken = int.Parse(dataGridKendaraan.Rows[rowIndex].Cells[0].Value.ToString());
            delken.Enabled = true;
            upken.Enabled = true;
            delken.BackColor = Color.Red;
            upken.BackColor = Color.Blue;
        }
        public bool nopolValid(string s)
        {
            //bool istrue = false;
            string str = "select * from kendaraan";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("NOPOL");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        private void addken_Click(object sender, EventArgs e)
        {

            if (nopoltb.Text == "" && MerkCb.Text == "" && TipeCb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else if (nopolValid(nopoltb.Text) == true)
            {
                MessageBox.Show("Nomor Kendaraan " + nopoltb.Text + " telah ada !");
            }
            else
            {
                conn.Open();
                string sql = "INSERT INTO kendaraan(NOPOL,MERK_KEN,TIPE_KEN,ID_KONSUMEN) VALUES(@nopol,@merk,@tipe,@idkon)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nopol", nopoltb.Text);
                cmd.Parameters.AddWithValue("@merk", MerkCb.Text);
                cmd.Parameters.AddWithValue("@tipe", TipeCb.Text);
                cmd.Parameters.AddWithValue("@idkon", int.Parse(IDtb.Text));

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal");
                }
                conn.Close();
                FillDGVKendaraan();
                cleark();

            }
        }

        private void delken_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus data kendaraan ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                conn.Open();
                string sql = "DELETE FROM kendaraan WHERE ID_KENDARAAN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", noken);

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
                MessageBox.Show("Kendaraan Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FillDGVKendaraan();
            setBtnKenAll(true, false);
            addken.BackColor = Color.Lime;
            cleark();

        }

        private void upken_Click(object sender, EventArgs e)
        {
            if (nopoltb.Text == "" && MerkCb.Text == "" && TipeCb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else
            {
                conn.Open();
                string sql = "UPDATE kendaraan SET NOPOL=@nopol, MERK_KEN=@merk,TIPE_KEN=@tipe WHERE ID_KENDARAAN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nopol", nopoltb.Text);
                cmd.Parameters.AddWithValue("@merk", MerkCb.Text);
                cmd.Parameters.AddWithValue("@tipe", TipeCb.Text);
                cmd.Parameters.AddWithValue("@id", noken);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Update Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal Update !");
                }
                FillDGVKendaraan();
                setBtnKenAll(true, false);
                addken.BackColor = Color.Lime;
                cleark();
                conn.Close();
            }
        }
        public DataTable searchken(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM kendaraan WHERE NOPOL LIKE '%" + key + "%' AND ID_KONSUMEN=@idkon";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idkon", int.Parse(IDtb.Text));
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

        private void carikentb_TextChanged(object sender, EventArgs e)
        {
            string key = carikentb.Text;
            if (key != null)
            {
                DataTable dt = searchken(key);
                dataGridKendaraan.DataSource = dt;
            }
            else
            {
                FillDGVKendaraan();
            }
        }
        public bool checkken()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT ID_KENDARAAN,STATUS FROM detil_service", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                if (noken.ToString() == reader.GetString(0) && reader.GetString(1) == "N")
                {
                    conn.Close();
                    return true;
                }
            }

            conn.Close();
            return false;
        }
        private void clearken_Click(object sender, EventArgs e)
        {

            
                if (namatb.Text == "" || IDtb.Text == "" || nopoltb.Text == "")
                {
                    MessageBox.Show("data konsumen belum lengkap ! ");
                }
                else if (nopoltb.Text == "" || MerkCb.Text == "" || TipeCb.Text == "")
                {
                    MessageBox.Show("data kendaraan belum lengkap ! ");
                }
                else if (noken == -1)
                {
                    MessageBox.Show("anda belum memilih motor ");
                }
                else if (checkken() == true)
                {
                    MessageBox.Show("kendaraan tersebut sedang dalam proses pengerjaan !");
                }
                else
                {
                    nama = namatb.Text;
                    idkon = int.Parse(IDtb.Text);
                    // idken = int.Parse(idken.Text);
                    nohp = nohptb.Text;
                    nopol = nopoltb.Text;
                    merkken = MerkCb.Text;
                    tipeken = TipeCb.Text;
                    motor = merkken + " " + tipeken + " " + nopol;
                    TransaksiJs admin = new TransaksiJs();
                    admin.Show();
                    this.Hide();
                }
          


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
