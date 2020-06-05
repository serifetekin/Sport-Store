using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;

using SportsStore.Models.Repository;

namespace SportsStore.Pages
{
    public partial class SepetiGoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                Repository repository = new Repository();

                int silinecekUrunId = Convert.ToInt32(Request.Form["sil"]);

                Sepet sepetim = (Sepet)Session["Sepet"];

                if (sepetim == null)
                {
                    sepetim = new Sepet();
                }

                Product silinecekUrun = repository.Products.Where(p => p.ProductID == silinecekUrunId).FirstOrDefault();

                if(silinecekUrun != null)
                {
                    sepetim.SepettenSil(silinecekUrun);
                }


                Session["Sepet"] = sepetim; // sepeti güncelledi.

                // int.TryParse(Request.Form["ekle"], out seciliUrunId);

            }
        }

        public IEnumerable<SportsStore.Models.SepetElemani> SepetElemanlariniGetir() // Liste fonksiyonu
        {
            Sepet sepetim = (Sepet)Session["Sepet"];

            if(sepetim == null)
            {
                sepetim = new Sepet();
            }

            return sepetim.benimSepetim;
        }

        public decimal SepetToplami // property
        {
            get
            {
                Sepet sepetim = (Sepet)Session["Sepet"];

                if(sepetim == null)
                    sepetim = new Sepet();

                    return sepetim.SepetToplaminiHesapla();

                
            }
           
        
        
        }
        
    }
}