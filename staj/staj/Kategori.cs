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
    public partial class Kategori : Form
    {
        SqlConnection connection = Proje.connection;
        public Kategori()
        { 
            InitializeComponent();
        }

        bool durum;
        private void kategorikontrol()
        {
            durum = true;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from kategoribilgileri", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (TextKategori.Text==read["kategori"].ToString() || TextKategori.Text=="")
                {
                    durum = false;
                }
            }
            connection.Close();
        }
        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if (durum == true)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into kategoribilgileri (kategori) values ('" + TextKategori.Text + "')", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kategori eklendi.");
            }
            else
            {
                MessageBox.Show("Mevcut kategori girdiniz!!","Uyarı");
            }
            
        }
    }
}
