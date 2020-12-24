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
    public partial class Staj : Form
    {
        SqlConnection connection = Proje.connection;
        internal static string username { get; set; }
        public Staj()
        {
            InitializeComponent();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Staj_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Staj_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Staj_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Staj_Load(object sender, EventArgs e)
        {
            label3.Text = username;
            selectMail();
            selectGuard();
        }
        private void selectMail()
        {
            SqlCommand command = new SqlCommand("Select e_mail from Staj where username='" + Kriptoloji.Encryption(username, 2) + "'",connection);
            label4.Text= Kriptoloji.Decryption(command.ExecuteScalar().ToString(),2);
            connection.Close();
        }
        private void selectGuard()
        {
            SqlCommand command = new SqlCommand("Select active from Staj where username='" + Kriptoloji.Encryption(username, 2) + "'", connection);
            connection.Open();
            checkBox1.Checked = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();

        }

        private void update_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Staj set active='"+ checkBox1.Checked.ToString().ToLower()+"'where username= '"+ Kriptoloji.Encryption(username, 2) + "' ",connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("update","Program");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
