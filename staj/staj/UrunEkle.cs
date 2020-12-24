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
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }
        SqlConnection connection = Proje.connection;
        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from urunekle", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (textBarkod.Text==read["barkodno"].ToString() || textBarkod.Text=="")
                {
                    durum = false;
                }
            }
            connection.Close();
        }
        private void UrunEkle_Load(object sender, EventArgs e)
        {
            kategori_getir();
        }
        private void kategori_getir()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select *from kategoribilgileri", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBoxKategori.Items.Add(reader["kategori"].ToString());
            }
            connection.Close();
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

        private void btnYurunEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum== true)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into urunekle (barkodno,kategori,marka,urunadi,miktari,alisfiyati,satisfiyati,tarih) values('" + textBarkod.Text + "', '" + comboBoxKategori.Text + "', '" + comboBoxMarka.Text + "', '" + textUrunAdı.Text + "', '" + int.Parse(textMiktar.Text) + "', '" + Double.Parse(textAlisF.Text) + "', '" + Double.Parse(textSatisF.Text) + "', '" + DateTime.Now.ToString() + "')", connection);

                command.ExecuteNonQuery();
                connection.Close();
                comboBoxMarka.Items.Clear();
                MessageBox.Show("Yeni ürün eklendi.");
            }
            else
            {
                MessageBox.Show("Mevcut Barkodno girdiniz!!");
            }
            
        }

        private void BarkodNoTxt_TextChanged(object sender, EventArgs e)
        {
            if (BarkodNoTxt.Text=="")
            {
                lblMiktari.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from urunekle where barkodno like '" + BarkodNoTxt.Text + "'", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                KategoriTxt.Text = read["kategori"].ToString();
                MarkaTxt.Text = read["marka"].ToString();
                UrunTxt.Text = read["urunadi"].ToString();
                lblMiktari.Text = read["miktari"].ToString();
                AlisFTxt.Text = read["alisfiyati"].ToString();
                SatisFTxt.Text = read["satisfiyati"].ToString();
            }
            connection.Close();
        }

        private void btnVUrunEkle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update urunekle set miktari='"+int.Parse(MiktarTxt.Text)+"' where barkodno='"+BarkodNoTxt.Text+"'",connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("Var olan ürüne ekleme yapıldı.");
        }
    }
}
