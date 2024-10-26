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

namespace NtpProje
{
    public partial class GirisPaneli : Form
    {
        public GirisPaneli()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Galeri_Otomasyonu;Integrated Security=True");

        private void GirisPaneli_Load(object sender, EventArgs e)
        {
            btngiris.FlatStyle = FlatStyle.Flat;
            btngiris.FlatAppearance.BorderColor = Color.Green;
         
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "select *from guvenlik where Ad=@adi AND Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if(dt.Rows.Count  > 0)
                {
                    frmAnaSayfa anasayfa = new frmAnaSayfa();
                    anasayfa.Show();                }
            }
            catch
            {
                MessageBox.Show("Hatalı Giriş");    
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngiris_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SifreDegistir sifre = new SifreDegistir();
            sifre.Show();
        }
    }
}
