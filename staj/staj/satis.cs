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
    public partial class satis : Form
    {
        SqlConnection connection = Proje.connection;
        DataSet ds = new DataSet();
        public satis()
        {
            InitializeComponent();
        }

        
        bool move;
        int mouse_x;
        int mouse_y;

        private void smsCheck_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void smsCheck_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void smsCheck_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmekle_Click(object sender, EventArgs e)
        {
            MusteriEkle ekle = new MusteriEkle();
            ekle.ShowDialog();
        }

        private void btnMlistele_Click(object sender, EventArgs e)
        {
            MusteriListele list = new MusteriListele();
            list.ShowDialog();
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            UrunEkle ue = new UrunEkle();
            ue.ShowDialog();
        }
        private void btnKategori_Click(object sender, EventArgs e)
        {
            Kategori fk = new Kategori();
            fk.ShowDialog();
        }
        private void btnMarka_Click(object sender, EventArgs e)
        {
            Marka fm = new Marka();
            fm.ShowDialog();
        }
        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            UrunListele ul = new UrunListele();
            ul.ShowDialog();
        }
        bool durum;
        private void barkodKontrol()
        {
            durum = true;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from sepet",connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (textBarkod.Text==read["barkodno"].ToString())
                {
                    durum = false;
                }
            }
        }
        private void satis_Load(object sender, EventArgs e)
        {
            sepet_Listele();
        }
        private void sepet_Listele()
        {
            
        }
        private void Hesapla()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select sum(toplamfiyati) from sepet",connection);
                lblGenelToplam.Text = cmd.ExecuteScalar()+"TL";
                connection.Close();
            }
            catch(Exception)
            {
                ;
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_sil = new SqlCommand("delete from sepet where barkodno= '" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "' ", connection);
            command_sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Silindi."); 
            ds.Tables["sepet"].Clear();
            sepet_Listele();
            Hesapla();
        }
        private void textTC_TextChanged(object sender, EventArgs e)
        {
            if (textTC.Text=="")
            {
                textAdSoyad.Text = "";
                textTel.Text = "";
            }
            connection.Open();
            SqlCommand command = new SqlCommand("select *from Müşteri where tc like '"+textTC.Text +"'",connection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                textAdSoyad.Text = read["adsoyad"].ToString();
                textTel.Text = read["telefon"].ToString();
            }
            connection.Close();
        }
        private void textBarkod_TextChanged(object sender, EventArgs e)
        {
            temizle();
            connection.Open();
            SqlCommand command = new SqlCommand("select *from urunekle where barkodno like '" + textBarkod.Text + "'", connection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                textÜrün.Text = read["urunadi"].ToString();
                textSatis.Text = read["satisfiyati"].ToString();
            }
            connection.Close();
        }
        private void temizle()
        {
            if (textBarkod.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != textMiktar)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            barkodKontrol();
            if (durum==true)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into sepet (tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values('" + textTC.Text + "','" + textAdSoyad.Text + "','" + textTel.Text + "','" + textBarkod.Text + "','" + textÜrün.Text + "','" + int.Parse(textMiktar.Text) + "','" + Double.Parse(textSatis.Text) + "','" + Double.Parse(textToplam.Text) + "','" + DateTime.Now.ToString() + "')", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Open();
                SqlCommand command2 = new SqlCommand("update sepet miktari=miktari+'"+int.Parse(textMiktar.Text)+ "' where barkodno='" + textBarkod.Text + "' ", connection);
                command2.ExecuteNonQuery();
                SqlCommand command3 = new SqlCommand("update sepet toplamfiyati=miktari*satisfiyati where barkodno='" + textBarkod.Text + "'", connection);              
                command3.ExecuteNonQuery();
                connection.Close();
            }
            textMiktar.Text = "1";
            ds.Tables["sepet"].Clear();
            sepet_Listele();
            Hesapla();
            foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != textMiktar)
                        {
                            item.Text = "";
                        }
                    }
                }
        }
        private void textMiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textToplam.Text = (double.Parse(textMiktar.Text) * double.Parse(textSatis.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }
        private void textSatis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textToplam.Text = (double.Parse(textMiktar.Text) * double.Parse(textSatis.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }
        private void btnSatisİptal_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_sil = new SqlCommand("delete from sepet ", connection);
            command_sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Silindi.");
            ds.Tables["sepet"].Clear();
            sepet_Listele();
            Hesapla();          
        }

        private void btnSatisListele_Click(object sender, EventArgs e)
        {
            SatislariListele sl = new SatislariListele();
            sl.ShowDialog();
        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into satis (tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values('" + textTC.Text + "','" + textAdSoyad.Text + "','" + textTel.Text + "','" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["urunadi"].Value.ToString() + "','" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "','" + Double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()) + "','" + Double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()) + "','" + DateTime.Now.ToString() + "')", connection);
                command.ExecuteNonQuery();
                
                SqlCommand cmd = new SqlCommand("update urunekle set miktari=miktari-'" + int.Parse(dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "' where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "','" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
               
            }
            connection.Open();
            SqlCommand command_sil = new SqlCommand("delete from sepet ", connection);
            command_sil.ExecuteNonQuery();
            connection.Close();
            ds.Tables["sepet"].Clear();
            sepet_Listele();
            Hesapla();
        }
    }
}
