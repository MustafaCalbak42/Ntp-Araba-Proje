using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpProje
{
    class Galeri_Otomasyonu
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Galeri_Otomasyonu;Integrated Security=True");
        DataTable tablo;
        public void ekle_sil_guncelle(SqlCommand komut , string sorgu)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = sorgu;
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Hata durumuyla ilgili bir işlem yapabilirsiniz.
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();

            try
            {
                adtr = new SqlDataAdapter(sorgu, baglanti);
                adtr.Fill(tablo);
            }
            finally
            {
                // Veri çekme işlemi bittikten sonra bağlantıyı kapat
                baglanti.Close();
            }

            return tablo;
        }
        public void BosAraclar(ComboBox combo , string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu , baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                combo.Items.Add(read["plaka"].ToString()); 
            }
            baglanti.Close();
        }
        public void TC_Ara(TextBox tcara, TextBox tc , TextBox adsoyad, TextBox telefon, string sorgu) 
        { 
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand(sorgu, baglanti); 
            SqlDataReader read = komut.ExecuteReader(); 
            while (read.Read()) 
            {
                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString(); 
                telefon.Text = read["telefon"].ToString(); 
            } 
            baglanti.Close(); 
        }
        public void Ucret_Hesapla(ComboBox combokirasekli, TextBox ucret, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (combokirasekli.SelectedIndex == 0) ucret.Text = (int.Parse(read["kiraücreti"].ToString()) * 1).ToString();
                else if (combokirasekli.SelectedIndex == 1) ucret.Text = (int.Parse(read["kiraücreti"].ToString())*0.80).ToString();
                else if (combokirasekli.SelectedIndex == 2) ucret.Text = (int.Parse(read["kiraücreti"].ToString()) * 0.70).ToString();



            }
            baglanti.Close();
        }
        public void CombodanGetir(ComboBox araclar ,TextBox marka, TextBox seri, TextBox yil, TextBox renk ,string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
               
                    marka.Text = read["marka"].ToString();
                    seri.Text = read["seri"].ToString();
                    yil.Text = read["yıl"].ToString();
                    renk.Text = read["renk"].ToString();
            
            }
            baglanti.Close();
        }
        public void satishesapla(Label lbl)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satış ",baglanti);
            lbl.Text = "Toplam Tutar =" + komut.ExecuteScalar() + " TL";
            baglanti.Close();
        }
    }
}
