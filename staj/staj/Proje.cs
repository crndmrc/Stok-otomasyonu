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
    public partial class Proje : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source = LAPTOP-KA3PMMLM; Initial Catalog=Text; Integrated Security=TRUE;");
        public Proje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x;
        int mouse_y;
      

        private void Proje_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Proje_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Proje_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Gray;
                textBox2.PasswordChar = '*';
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }
     
        private void login_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
            bool isThere=false;

            connection.Open();
            SqlCommand command= new SqlCommand("Select *from Staj", connection);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                if (username==Kriptoloji.Decryption(reader["username"].ToString().TrimEnd(), 2) && pass==Kriptoloji.Decryption(reader["pass"].ToString().TrimEnd(),2))
                {
                    isThere = true;
                    Staj.username=username;
                    break;
                }
                else
                {
                    isThere = false;
                }
            }
            connection.Close();            
            if (isThere)
            {
                //MessageBox.Show("Giriş yapıldı.");
                SqlCommand command_active = new SqlCommand("Select active from Staj where username='"+Kriptoloji.Encryption(username,2)+"'",connection);
                command_active.Connection = connection;
                connection.Open();                  
                if (Convert.ToBoolean(command_active.ExecuteScalar().ToString()))
                {
                    satis sms = new satis();
                    sms.Show(); 
                }
                else
                {
                    Staj panel = new Staj();
                    panel.Show();
                }
                connection.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.","Program");
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Proje2 proje2 = new Proje2();
            proje2.Show();
        }
    }
}
