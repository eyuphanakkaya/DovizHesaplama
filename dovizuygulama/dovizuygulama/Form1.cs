using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dovizuygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xlmdosya = new XmlDocument();
            xlmdosya.Load(bugun);

            string dolaralis = xlmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldolaralıs.Text = dolaralis;
            string dolarsatis = xlmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatıs.Text = dolarsatis;
            string euroalis = xlmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroalıs.Text = euroalis;
            string eurosatis = xlmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatıs.Text = eurosatis;

        }

        private void btndolarsatıs_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsatıs.Text;
            
        }

        private void btndolaralıs_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolaralıs.Text;
        }

        private void btneurosatis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosatıs.Text;
        }

        private void btneuroalıs_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalıs.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtkur.Text);
            miktar = Convert.ToDouble(txtmiktar.Text);
            tutar = kur * miktar;
            txttutar.Text = tutar.ToString();
        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = txtkur.Text.Replace(".", ",");
        }
    }
}
