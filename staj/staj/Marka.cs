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
    public partial class Marka : Form
    {
        public Marka()
        {
            InitializeComponent();
        }
        SqlConnection connection = Proje.connection;
        private void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            markakontrol();
            if (durum==true)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into markabilgileri (kategori,marka) values ('" + comboBox1.Text + "','" + TextKategori.Text + "')", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Marka eklendi.");
            }
            else
            {
                MessageBox.Show("Mevcut marka girdiniz!!","Uyarı");
            }
            TextKategori.Text = "";
            comboBox1.Text = "";
        }
        bool durum;
        private void markakontrol()
        {
            durum = true;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from markabilgileri", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text==read["kategori"].ToString() && TextKategori.Text == read["marka"].ToString() || comboBox1.Text=="" || TextKategori.Text == "")
                {
                    durum = false;
                }
            }
            connection.Close();
        }
        private void Marka_Load(object sender, EventArgs e)
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
                comboBox1.Items.Add(reader["kategori"].ToString());
            }
            connection.Close();
        }
    }
}
