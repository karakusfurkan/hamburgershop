using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YG35426_HamburgerDukkani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void VarsayilanGorunumeDon()
        {
            cmbMenuler.SelectedIndex = 0;
            nuAdet.Value = 1;
            rbOrta.Checked = true;
            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                    item.Checked = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * MENÜLER - FİYATLAR
             * BigMac Menü - 8.00
             * SteakHouse Menü - 12.00
             * Çocuk Menüsü - 6.00
             * Whooper Menü - 10.00
             * Chicken Royale Menü - 7.00
             */
            string[] menuler = { "BigMac Menü", "SteakHouse Menü", "Çocuk Menüsü", "Whooper Menü", "Chicken Royale Menü" };
            cmbMenuler.Items.AddRange(menuler);
            cmbMenuler.SelectedIndex = 0;
        }
        Siparis SiparisOlustur()
        {
            Siparis s = new Siparis();
            //MENU
            s.Menu = cmbMenuler.SelectedItem.ToString();
            //BOYUT
            if (rbBuyuk.Checked)
                s.Boyut = rbBuyuk.Text;
            else if (rbKing.Checked)
                s.Boyut = rbKing.Text;
            else if (rbOrta.Checked)
                s.Boyut = rbOrta.Text;
            //EXTRALAR
            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                    s.Extralar += item.Text + ",";
            }
            if (!string.IsNullOrEmpty(s.Extralar))
                s.Extralar = s.Extralar.Remove(s.Extralar.Length - 1);
            //ADET
            s.Adet = Convert.ToInt32(nuAdet.Value);
            s.TutarHesapla();
            return s;
        }
        private void btnSiparisAl_Click(object sender, EventArgs e)
        {
            Siparis yeniSiparis = SiparisOlustur();
            lstSiparisler.Items.Add(yeniSiparis);
            VarsayilanGorunumeDon();
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            foreach (var item in lstSiparisler.Items)
            {
                Siparis s = (Siparis)item;
                toplamTutar += s.SiparisTutari;
            }
            MessageBox.Show(string.Format("Toplamda {0} adet sipariş bulunmaktadır.\nToplam Tutar: {1:C2}",lstSiparisler.Items.Count,toplamTutar));
        }
    }
}
