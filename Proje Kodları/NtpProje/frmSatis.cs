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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        Galeri_Otomasyonu arac = new Galeri_Otomasyonu();
        private void frmSatis_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select *from satış";
            SqlDataAdapter adtr = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr ,sorgu2);
            arac.satishesapla(label1);
        }
    }
}
