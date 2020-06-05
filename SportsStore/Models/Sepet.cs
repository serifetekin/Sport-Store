using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    public class Sepet
    {
        private List<SepetElemani> sepetim = new List<SepetElemani>();

        public void SepeteEkle(Product _urun, int sayi)
        {

            // Sepete eklemek istediğimiz ürünün daha önce sepette olup olmadığını kontrol ediyoruz
            SepetElemani sElemani = sepetim.Where(p => p.urun.ProductID == _urun.ProductID).FirstOrDefault();

            if(sElemani == null)
            {
                // SepetElemani sObj = new SepetElemani();
                // sObj.adet = sayi;
                // sObj.urun = _urun;
                // sepetim.Add(sObj);

                sepetim.Add(new SepetElemani { adet = sayi, urun = _urun });
            }
            else
            {
                sElemani.adet += sayi;
            }
        }

        public void SepettenSil(Product _urun)
        {
            sepetim.RemoveAll(p => p.urun.ProductID == _urun.ProductID);
        }

        public decimal SepetToplaminiHesapla()
        {
            return sepetim.Sum(p => p.urun.Price * p.adet);
        }

        public void SepetiTemizle()
        {
            sepetim.Clear();
        }

        public IEnumerable<SepetElemani> benimSepetim
        {
            get
            {
                return sepetim;
            }
        }
    }


    public class SepetElemani
    {
        public int adet { set; get; }

        public Product urun { set; get; }
    }
}