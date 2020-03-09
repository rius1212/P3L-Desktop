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
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
namespace AtmaAuto
{
    public partial class KelolaSparepart : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        //MySqlCommand command;
        List<Merk> merk = new List<Merk>();
        List<Tipe> tipe = new List<Tipe>();
        string nd = "";
        string codes = "";
        string kode1 = "";
        string kode2 = "";
        string kode3 = "";
        public string datein;
        public KelolaSparepart()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {

                pictureSelect.Image = Image.FromFile(opf.FileName);
            }
        }
        public void setBtnActive()
        {
            DeleteBtn.Enabled = true;
            UpdateBtn.Enabled = true;
            DeleteBtn.BackColor = Color.Red;
            UpdateBtn.BackColor = Color.Blue;
        }
        public void setBtn()
        {
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            DeleteBtn.BackColor = Color.White;
            UpdateBtn.BackColor = Color.White;
        }
        public void clear()
        {
            combo1.Text = "";
            combo2.Text = "";
            kodeSp.Text = "";
            kode01.Text = "";
            kode.Text = "";
            kode02.Text = "";
            NamaSp.Text = "";
            MerkCb.Text = "";
            TipeCb.Text = "";
            HargaSp.Text = "";
            hargabel.Text = "";
            Stok.Text = "";
            pictureSelect.Image = null;
        }
        public void FillDGV()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT KODE_SPAREPART as KODE,RAK , NAMA_SPAREPART as NAMA, MERK,TIPE, STOK, HARGA_JUAL,HARGA_BELI, GAMBAR,TIPEBARANG as BARANG FROM sparepart", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            sparepartDGV.RowTemplate.Height = 60;
            sparepartDGV.AllowUserToAddRows = false;
            sparepartDGV.DataSource = table;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();

            imgCol = (DataGridViewImageColumn)sparepartDGV.Columns[8];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            sparepartDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sparepartDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setBtnActive();
            Byte[] img = (Byte[])sparepartDGV.CurrentRow.Cells[8].Value;
            int rowIndex = e.RowIndex;
            MemoryStream ms = new MemoryStream(img);
            pictureSelect.Image = Image.FromStream(ms);
            NamaSp.Text = sparepartDGV.Rows[rowIndex].Cells[2].Value.ToString();
            MerkCb.Text = sparepartDGV.Rows[rowIndex].Cells[3].Value.ToString();
            Stok.Text = sparepartDGV.Rows[rowIndex].Cells[5].Value.ToString();
            HargaSp.Text = sparepartDGV.Rows[rowIndex].Cells[6].Value.ToString();
            hargabel.Text = sparepartDGV.Rows[rowIndex].Cells[7].Value.ToString();
            TipeCb.Text = sparepartDGV.Rows[rowIndex].Cells[4].Value.ToString();
            tipebarangtb.Text= sparepartDGV.Rows[rowIndex].Cells[9].Value.ToString();
            spiltRak(sparepartDGV.Rows[rowIndex].Cells[1].Value.ToString());
            spiltKode(sparepartDGV.Rows[rowIndex].Cells[0].Value.ToString());

            kode02.Enabled = false;
            kode01.Enabled = false;
            kode.Enabled = false;
        }
        private void spiltKode(string kodes)
        {
            char[] separator = { '-' };
            string[] str = null;
            str = kodes.Split(separator);
            kode.Text = str[0];
            kode01.Text = str[1];
            kode02.Text = str[2];


        }
        private void spiltRak(string kode)
        {
            char[] separator = { '-' };
            string[] str = null;
            str = kode.Split(separator);
            combo1.Text = str[0];
            combo2.Text = str[1];
            kodeSp.Text = str[2];


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
            datein = q3 + "-" + q1 + "-" + q2;

        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
        

            byte[] img = null;

            nd = combo1.Text + "-" + combo2.Text + "-" + kodeSp.Text;
            codes = kode.Text + "-" + kode01.Text + "-" + kode02.Text;

            if (hargabel.Text == "")
            {
                hargabel.Text = "0";
            }
            if (HargaSp.Text == "")
            {
                HargaSp.Text = "0";
            }
            if (kode.Text == "" || kode01.Text == "" || kode02.Text == "")
            {
                MessageBox.Show("Kode Sparepart Masih Kosong !");

            }
            else if (validKodeSparepart(codes) == true)
            {
                MessageBox.Show("Kode Sparepart Sudah Ada");
            }
            else if (combo1.Text == "" || combo1.Text == "" || kodeSp.Text == "")
            {
                MessageBox.Show("Rak Masih Kosong !");

            }
            else if (int.Parse(kodeSp.Text) >= 99)
            {
                MessageBox.Show("Nomor Rak Sparepart Harus 2 digit !");
            }

            else if (NamaSp.Text == "" || MerkCb.Text == "" || TipeCb.Text == "" || tipebarangtb.Text=="")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else if (float.Parse(HargaSp.Text) == 0 || float.Parse(hargabel.Text) == 0)
            {
                MessageBox.Show("Harga beli atau harga jual Bernilai nol");

            }
            else if (pictureSelect.Image == null) {
                MessageBox.Show("Gambar belum Ada ");
            }
            else
            {

                if (pictureSelect.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                   
                    pictureSelect.Image.Save(ms, pictureSelect.Image.RawFormat);
                    img = ms.GetBuffer();
                    conn.Open();
                    string sql = "INSERT INTO sparepart(KODE_SPAREPART,RAK, NAMA_SPAREPART, MERK, STOK, HARGA_JUAL,HARGA_BELI, GAMBAR, TIPE,TIPEBARANG) VALUES(@id,@rak,@namasp,@merksp,@stoksp,@harga,@hargabel,@gambar,@tipe,@tipbar)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@rak", nd);
                    cmd.Parameters.AddWithValue("@id", codes);
                    cmd.Parameters.AddWithValue("@namasp", NamaSp.Text);
                    cmd.Parameters.AddWithValue("@tipbar", tipebarangtb.Text);
                    cmd.Parameters.AddWithValue("@merksp", MerkCb.Text);
                    cmd.Parameters.AddWithValue("@stoksp", int.Parse(Stok.Text));
                    cmd.Parameters.AddWithValue("@harga", float.Parse(HargaSp.Text));
                    cmd.Parameters.AddWithValue("@hargabel", float.Parse(hargabel.Text));
                    cmd.Parameters.AddWithValue("@tipe", TipeCb.Text);
                    cmd.Parameters.AddWithValue("@gambar", img);

                    if (cmd.ExecuteNonQuery() == 1)

                    {
                        MessageBox.Show("success");
                    }
                    else
                    {
                        MessageBox.Show("Gagal");
                    }
                    conn.Close();
                   
                    conn.Open();
                    string sql2 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,NOW(),@jum,@ket,@stok)";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@jum", Stok.Text);
                    cmd2.Parameters.AddWithValue("@stok", Stok.Text);
                    cmd2.Parameters.AddWithValue("@ket", "Masuk");
                    cmd2.Parameters.AddWithValue("@id", codes);
                    cmd2.Parameters.AddWithValue("@tggl", datein+DateTime.Now.ToLongTimeString());
                    if (cmd2.ExecuteNonQuery() == 1)

                    {
                       // MessageBox.Show("success");
                    }
                    else
                    {
                        MessageBox.Show("Gagal (2)");
                    }
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Gambar belum Ada ");
                }
                FillDGV();
                clear();
            }
        }
        public bool validKodeSparepart(string s)
        {
            //bool istrue = false;
            string str = "select * from sparepart";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("KODE_SPAREPART");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public bool rakValid(string s)
        {
            //bool istrue = false;
            string str = "select * from sparepart";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("RAK");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public void tipebarang()
        {
            string sql = "select * from tipesparepart ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                tipebarangtb.Items.Add(reader["TIPE_SPAREPART"]);
            }
            tipebarangtb.SelectedIndex = 0;
            conn.Close();
        }
        public void KelolaSparepart_Load(object sender, EventArgs e)
        {
            setBtn();
            spiltconcatDate(DateTime.Now.ToShortDateString());
            FillDGV();
            tipebarang();
            string query = "SELECT * FROM merk";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MerkCb.Items.Add(reader["MERK"]);
                merk.Add(new Merk()
                {
                    id = ((int)reader["IDMERK"]),
                    merk = reader["MERK"] as string
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
                    id = ((int)reader2["ID"]),
                    tipe = reader2["TIPE"] as string,
                    merkid = ((int)reader2["IDMERK"])

                });
            }
            conn.Close();

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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            kode.Enabled = true;
            kode01.Enabled = true;
            kode02.Enabled = true;
            clear();
            setBtn();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (hargabel.Text == "")
            {
                hargabel.Text = "0";
            }
            if (HargaSp.Text == "")
            {
                HargaSp.Text = "0";
            }
            if (kode.Text == "" || kode01.Text == "" || kode02.Text == "")
            {
                MessageBox.Show("Kode Sparepart Masih Kosong !");

            }
            else if (combo1.Text== "" || combo1.Text == "" || kodeSp.Text == "")
            {
                MessageBox.Show("Rak Sparepart Masih Kosong !");

            }
            else if (NamaSp.Text == "" || MerkCb.Text == "" || TipeCb.Text == "" || tipebarangtb.Text=="")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else if ((float.Parse(HargaSp.Text) == 0))
            {
                MessageBox.Show("Harga Bernilai nol");

            }
            else if (float.Parse(hargabel.Text) == 0)
            {
                MessageBox.Show("Harga Bernilai nol");
            }
            else

            if (pictureSelect.Image != null)
            {
                nd = combo1.Text + "-" + combo2.Text + "-" + kodeSp.Text;
                codes = kode.Text + "-" + kode01.Text + "-" + kode02.Text;
                byte[] img = null;
                MemoryStream ms = new MemoryStream();
                // pictureSelect.Image.Save(ms,pictureSelect.Image.RawFormat);
                pictureSelect.Image.Save(ms, pictureSelect.Image.RawFormat);
                img = ms.GetBuffer();
                conn.Open();
                string sql = "UPDATE sparepart SET NAMA_SPAREPART=@namasp,RAK=@rak,MERK=@merksp, STOK=@stoksp, HARGA_JUAL=@harga,HARGA_BELI=@hargabel, GAMBAR=@gambar,TIPEBARANG=@tipbar WHERE KODE_SPAREPART=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rak", nd);
                cmd.Parameters.AddWithValue("@id", codes);
                cmd.Parameters.AddWithValue("@namasp", NamaSp.Text);
                cmd.Parameters.AddWithValue("@merksp", MerkCb.Text);
                cmd.Parameters.AddWithValue("@tipbar", tipebarangtb.Text);
                cmd.Parameters.AddWithValue("@stoksp", int.Parse(Stok.Text));
                cmd.Parameters.AddWithValue("@harga", float.Parse(HargaSp.Text));
                cmd.Parameters.AddWithValue("@hargabel", float.Parse(hargabel.Text));
                cmd.Parameters.AddWithValue("@tipe", TipeCb.Text);
                cmd.Parameters.AddWithValue("@gambar", img);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Update Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal Update !");
                }
                conn.Close();
                conn.Open();
                string sql2 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,@tggl,@jum,@ket,@stok)";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@jum", Stok.Text);
                cmd2.Parameters.AddWithValue("@stok", Stok.Text);
                cmd2.Parameters.AddWithValue("@ket", "Masuk");
                cmd2.Parameters.AddWithValue("@id", codes);
                cmd2.Parameters.AddWithValue("@tggl", datein + DateTime.Now.ToLongTimeString());
                if (cmd2.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal (2)");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Gambar belum Ada ");
            }

            kode02.Enabled = true;
            kode01.Enabled = true;
            kode.Enabled = true;
            FillDGV();
            clear();
            setBtn();
        }

        private void HargaSp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void Stok_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus Sparepart ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                codes = kode.Text + "-" + kode01.Text + "-" + kode02.Text;

                conn.Open();
                string sql = "DELETE FROM sparepart WHERE KODE_SPAREPART=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",codes);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                string sql2 = "DELETE FROM histori_barang WHERE KODE_SPAREPART=@id";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", codes);

                if (cmd2.ExecuteNonQuery() == 1)

                {
                  //  MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Sparepart Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            setBtn();

            kode02.Enabled = true;
            kode01.Enabled = true;
            kode.Enabled = true;
            FillDGV();
            clear();
        }

        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT SELECT KODE_SPAREPART,RAK as KODE, NAMA_SPAREPART as NAMA, MERK,TIPE, STOK, HARGA_JUAL,HARGA_BELI, GAMBAR,TIPEBARANG as BARANG FROM sparepart WHERE KODE_SPAREPART LIKE '%" + key + "%' OR NAMA_SPAREPART LIKE '%" + key + "%' ";
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

        private void caritb_TextChanged(object sender, EventArgs e)
        {
            string key = caritb.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                sparepartDGV.DataSource = dt;
            }
            else
            {
                FillDGV();
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            AdminView peg = new AdminView();
            peg.Show();
            this.Hide();
        }
    }

}
[Serializable]
class Merk
{
    public int id { get; set; }
    public string merk { get; set; }
}
[Serializable]
class Tipe
{
    public int id { get; set; }
    public string tipe { get; set; }
    public int merkid { get; set; }
}