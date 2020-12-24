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
    public partial class MusteriListele : Form
    {
        SqlConnection connection = Proje.connection;
        DataSet ds = new DataSet();
        public MusteriListele()
        {
            InitializeComponent();
        }    
        bool move;
        int mouse_x;
        int mouse_y;

        private void MusteriListele_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void MusteriListele_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void MusteriListele_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
        private void MusteriListele_Load(object sender, EventArgs e)
        {
            Musteri_Listele();
        }
        private void Musteri_Listele()
        {
            connection.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select *from Müşteri ", connection);
            adap.Fill(ds, "Müşteri");
            dataGridView1.DataSource = ds.Tables["Müşteri"];
            connection.Close();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Müşteri set adsoyad='" + textAdSoyad.Text + "',telefon= '" + textTel.Text + "',adres= '" + textAdres.Text + "', email='" + textEmail.Text + "') where tc= '"+ textTC.Text+"' ", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncellendi.");
            ds.Tables["Müşteri"].Clear();
            Musteri_Listele();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textTC.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            textTel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            textAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_sil = new SqlCommand("delete from Müşteri where tc= '"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString() +"' ",connection);
            command_sil.ExecuteNonQuery();
            connection.Close();
            ds.Tables["Müşteri"].Clear();
            Musteri_Listele();
            MessageBox.Show("Kayıt Silindi.");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Müşteri where tc like '%"+textBox1.Text+"%' ",connection);
            da.Fill(tablo);
            dataGridView1.DataSource=tablo;
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
