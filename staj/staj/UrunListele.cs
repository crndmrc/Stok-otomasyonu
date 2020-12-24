using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace staj
{
    public partial class UrunListele : Form
    {
        public UrunListele()
        {
            InitializeComponent();
        }
        SqlConnection connection = Proje.connection;
        DataSet ds = new DataSet();
        private void UrunListele_Load(object sender, EventArgs e)
        {
            Urun_Listele();
        }
        private void Urun_Listele()
        {
            connection.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select *from urunekle ", connection);
            adap.Fill(ds, "urunekle");
            dataGridView1.DataSource = ds.Tables["urunekle"];
            connection.Close();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update urunekle set urunadi= '" + UrunTxt.Text + "', miktari='" + int.Parse(MiktarTxt.Text) + "',alisfiyati='"+Double.Parse(AlisFTxt.Text)+"',satisfiyati='"+Double.Parse(SatisFTxt.Text)+"') where barkodno= '" + BarkodNoTxt.Text + "' ", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncellendi.");
            ds.Tables["urunekle"].Clear();
            Urun_Listele();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BarkodNoTxt.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            KategoriTxt.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            MarkaTxt.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            UrunTxt.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            MiktarTxt.Text = dataGridView1.CurrentRow.Cells["miktari"].Value.ToString();
            AlisFTxt.Text = dataGridView1.CurrentRow.Cells["alisfiyati"].Value.ToString();
            SatisFTxt.Text = dataGridView1.CurrentRow.Cells["satisfiyati"].Value.ToString();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_sil = new SqlCommand("delete from urunekle where barkodno= '" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "' ", connection);
            command_sil.ExecuteNonQuery();
            connection.Close();
            ds.Tables["urunekle"].Clear();
            Urun_Listele();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void btnMarkaGuncelle_Click(object sender, EventArgs e)
        {
            if (BarkodNoTxt.Text!="")
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update urunekle set kategori='" + comboBoxKategori.Text + "',marka= '" +comboBoxMarka.Text + "' ", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Güncellendi.");
                ds.Tables["urunekle"].Clear();
                Urun_Listele();
            }
            else
            {
                MessageBox.Show("Barkod no seçili değil.");
            }
        }
        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMarka.Items.Clear();
            comboBoxMarka.Text = "";
            connection.Open();
            SqlCommand command = new SqlCommand("select  *from markabilgileri where kategori = '" + comboBoxKategori.SelectedItem + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBoxKategori.Items.Add(reader["kategori"].ToString());
            }
            connection.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from urunekle where barkodno like '%" + textBox2.Text + "%' ", connection);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            connection.Close();
        }
    }
}
