using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpProje
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMusteriListele fr3 = new frmMusteriListele();
            fr3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMusteriEkle fr2 = new frmMusteriEkle();
            fr2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAracListele fr5 = new frmAracListele();
            fr5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAracKayit fr4 = new frmAracKayit();
            fr4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSozlesme fr6 = new frmSozlesme();
            fr6.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatis fr7 = new frmSatis();
            fr7.ShowDialog();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderColor = Color.Black;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderColor = Color.Black;
        }
    }
}
