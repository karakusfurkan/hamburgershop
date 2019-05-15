using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG35426_HamburgerDukkani
{
    class Siparis
    {
        public string Menu { get; set; }
        public string Boyut { get; set; }
        public string Extralar { get; set; }
        public int Adet { get; set; }
        public decimal SiparisTutari { get; set; }
        public void TutarHesapla()
        {
            SiparisTutari = 0;
            switch (Menu)
            {
                case "BigMac Menü":
                    SiparisTutari = 8;
                    break;
                case "SteakHouse Menü":
                    SiparisTutari = 12;
                    break;
                case "Çocuk Menüsü":
                    SiparisTutari = 6;
                    break;
                case "Whooper Menü":
                    SiparisTutari = 10;
                    break;
                case "Chicken Royale Menü":
                    SiparisTutari = 7;
                    break;
            }
            switch (Boyut)
            {
                case "Büyük":
                    SiparisTutari += 3;
                    break;
                case "King":
                    SiparisTutari += 5;
                    break;
            }
            if (!string.IsNullOrEmpty(Extralar))
            {
                int extraSayisi = Extralar.Split(',').Length;
                SiparisTutari += extraSayisi * 0.20m;
            }
            SiparisTutari *= Adet;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Extralar))
                return string.Format("{0} adet {1} boy {2} - Fiyatı: {3:C2}", Adet, Boyut, Menu, SiparisTutari);
            else
                return string.Format("{0} adet {1} boy {2} ({3}) - Fiyatı: {4:C2}", Adet, Boyut, Menu, Extralar, SiparisTutari);
        }
    }
}
