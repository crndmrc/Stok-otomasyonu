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
    public partial class SatislariListele : Form
    {
        public SatislariListele()
        {
            InitializeComponent();
        }
        SqlConnection connection = Proje.connection;
        DataSet ds = new DataSet();
        private void SatislariListele_Load(object sender, EventArgs e)
        {
            Satislari_Listele();
        }
        private void Satislari_Listele()
        {
            connection.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select *from satis ", connection);
            adap.Fill(ds, "satis");
            dataGridView1.DataSource = ds.Tables["satis"];
            connection.Close();
        }
    }
}
