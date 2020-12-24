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
    public partial class Proje2 : Form
    {
        SqlConnection connection = Proje.connection;
        public Proje2()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }
        
        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Password")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Gray;
                textBox5.PasswordChar = '*';
            }
        }
        char? none = null;
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Password";
                textBox5.ForeColor = Color.Silver;
                textBox5.PasswordChar = Convert.ToChar(none);
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Re_Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Gray;
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Re_Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "e-Mail")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "e-Mail";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Phone Number")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Phone Number";
                textBox4.ForeColor = Color.Silver;
            }
        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void Proje2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }

        }

        private void Proje2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Proje2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into Staj (username,pass,re_pass,e_mail,phone) values ('"+ Kriptoloji.Encryption(textBox1.Text,2) + "','" + Kriptoloji.Encryption(textBox5.Text,2) + "','" + Kriptoloji.Encryption(textBox2.Text,2) + "','" + Kriptoloji.Encryption(textBox3.Text,2) + "','" + Kriptoloji.Encryption(textBox4.Text,2) + "') ", connection);
            
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Tamamlandı.");
        }

    }
}
