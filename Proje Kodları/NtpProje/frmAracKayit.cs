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
    public partial class frmAracKayit : Form
    {
        Galeri_Otomasyonu galerikira = new Galeri_Otomasyonu();
        public frmAracKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if(Markacombo.SelectedItem.ToString()=="Ford")
                {
                    Sericombo.Items.Add("Focus");
                    Sericombo.Items.Add("Courier");
                }
                else if(Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("G Class");
                }
                else if(Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("Egea");
                    Sericombo.Items.Add("Fiorino");
                }
                else if(Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("X5");
                }
                else
                {
                    Sericombo.Items.Add("Clio");
                    Sericombo.Items.Add("Megane");
                }
            }
            catch
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cümle = "insert into arac(plaka, marka, seri, yıl, renk, km, yakıt, kiraücreti, resim, tarih, durumu) values(@plaka, @marka, @seri, @yıl, @renk, @km, @yakıt, @kiraücreti, @resim, @tarih, @durumu)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
                komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
                komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
                komut2.Parameters.AddWithValue("@yıl", Yıltxt.Text);
                komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
                komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
                komut2.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);

                if (int.TryParse(Ücretcombo.Text, out int kiraUcreti))
                {
                    komut2.Parameters.AddWithValue("@kiraücreti", kiraUcreti);
                }
                else
                {
                    MessageBox.Show("Kira ücreti geçerli bir sayı değil.");
                    return;
                }

                komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut2.Parameters.AddWithValue("@durumu", "BOŞ");
                galerikira.ekle_sil_guncelle(komut2, cümle);

                Sericombo.Items.Clear();
                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                        item.Text = "";
                    else if (item is ComboBox)
                        item.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            pictureBox1.ImageLocation = "";

        }
        

        private void frmAracKayit_Load(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Green;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.Red;
        }

        private void Ücrettxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
