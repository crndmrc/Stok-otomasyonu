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
    public partial class MusteriEkle : Form
    {
        SqlConnection connection = Proje.connection;
        public MusteriEkle()
        {
            InitializeComponent();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void MusteriEkle_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void MusteriEkle_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void MusteriEkle_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into Müşteri (tc,adsoyad,telefon,adres,email) values('"+textTC.Text+ "','"+textAdSoyad.Text+ "','"+textTel.Text+ "','"+textAdres.Text+ "','"+textEmail.Text+"')", connection);          
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt tamamlandı.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Close();
        }
    }
}
