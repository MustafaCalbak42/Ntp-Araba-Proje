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
    public partial class frmMusteriListele : Form
    {
        Galeri_Otomasyonu galeriotomasyo = new Galeri_Otomasyonu();
        public frmMusteriListele()
        {
            InitializeComponent();
        }

        private void frmMusteriListele_Load(object sender, EventArgs e)
        {
            YenileListele();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Green;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Red;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.Red;
        }

        private void YenileListele()
        {
            string cümle = "select *from musteri";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = galeriotomasyo.listele(adtr2, cümle);
            dataGridView1.Columns[0].HeaderText = "TC";
            dataGridView1.Columns[1].HeaderText = "AD SOYAD";
            dataGridView1.Columns[2].HeaderText = "TELEFON";
            dataGridView1.Columns[3].HeaderText = "ADRES";
            dataGridView1.Columns[4].HeaderText = "E-MAİL";
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cümle = "select *from musteri where tc like '%"+textBox1.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter(); 
            dataGridView1.DataSource = galeriotomasyo.listele(adtr2, cümle);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtTc.Text = satir.Cells[0].Value.ToString();
            txtAdSoyad.Text = satir.Cells[1].Value.ToString();
            txtTelefon.Text = satir.Cells[2].Value.ToString();
            txtAdres.Text = satir.Cells[3].Value.ToString();
            txtEmail.Text = satir.Cells[4].Value.ToString();

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "update musteri set adsoyad=@adsoyad, telefon=@telefon, adres=@adres, email=@email where tc=@tc";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut2.Parameters.AddWithValue("@email", txtEmail.Text);
            galeriotomasyo.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            YenileListele();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string cümle = "delete from musteri where tc='"+satir.Cells["tc"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            galeriotomasyo.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            YenileListele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
