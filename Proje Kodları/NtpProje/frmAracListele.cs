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
    public partial class frmAracListele : Form
    {
        Galeri_Otomasyonu galeriarackira = new Galeri_Otomasyonu();
        public frmAracListele()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboAraclar.SelectedIndex == 0)
                {
                    YenileAraclarListesi();
                }
                else if (comboAraclar.SelectedIndex == 1)
                {
                    string cümle = "select *from arac where durumu='BOŞ'";
                    SqlDataAdapter adrt2 = new SqlDataAdapter();
                    dataGridView1.DataSource = galeriarackira.listele(adrt2, cümle);
                }
                else if (comboAraclar.SelectedIndex == 2)
                {
                    string cümle = "select *from arac where durumu = 'DOLU'";
                    SqlDataAdapter adrt2 = new SqlDataAdapter();
                    dataGridView1.DataSource = galeriarackira.listele(adrt2, cümle);
                }
               
            }
            catch
            {
                ;
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            Plakatxt.Text = satir.Cells["plaka"].Value.ToString();
            Markacombo.Text = satir.Cells["marka"].Value.ToString();
            Sericombo.Text = satir.Cells["seri"].Value.ToString();
            Yıltxt.Text = satir.Cells["yıl"].Value.ToString();
            Renktxt.Text = satir.Cells["renk"].Value.ToString();
            Kmtxt.Text = satir.Cells["km"].Value.ToString();
            Yakıtcombo.Text = satir.Cells["yakıt"].Value.ToString();
            Ücretcombo.Text = satir.Cells["kiraücreti"].Value.ToString();
            pictureBox2.ImageLocation = satir.Cells["resim"].Value.ToString();
           
        }

        private void frmAracListele_Load(object sender, EventArgs e)
        {
            YenileAraclarListesi();
            try
            {
                comboAraclar.SelectedIndex = 0;

            }
            catch
            {
                ;
            }
            btnsil.FlatStyle = FlatStyle.Flat;
            btnsil.FlatAppearance.BorderColor = Color.Red;
            btniptal.FlatStyle = FlatStyle.Flat;
            btniptal.FlatAppearance.BorderColor = Color.Red;
            bttnguncelle.FlatStyle = FlatStyle.Flat;
            bttnguncelle.FlatAppearance.BorderColor = Color.Blue;

        }

        private void YenileAraclarListesi()
        {
            string cümle = "select *from arac ";
            SqlDataAdapter adrt2 = new SqlDataAdapter();           
            dataGridView1.DataSource= galeriarackira.listele(adrt2, cümle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void bttnguncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update arac set marka=@marka , seri = @seri, yıl = @yıl, renk=@renk , km =@km , yakıt=@yakıt ,kiraücreti=@kiraücreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yıl", Yıltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraücreti", Ücretcombo.Text);
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            galeriarackira.ekle_sil_guncelle(komut2, cümle);

            Sericombo.Items.Clear();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                    item.Text = "";
                else if (item is ComboBox)
                    item.Text = "";
            }
            pictureBox2.ImageLocation = "";
            YenileAraclarListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from arac where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            galeriarackira.ekle_sil_guncelle(komut2, cümle);
            YenileAraclarListesi();
            pictureBox2.ImageLocation = "";
            Sericombo.Items.Clear();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                    item.Text = "";
                else if (item is ComboBox)
                    item.Text = "";
            }
        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedItem.ToString() == "Ford")
                {
                    Sericombo.Items.Add("Focus");
                    Sericombo.Items.Add("Courier");
                }
                else if (Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("G Class");
                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("Egea");
                    Sericombo.Items.Add("Fiorino");
                }
                else if (Markacombo.SelectedIndex == 3)
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

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
