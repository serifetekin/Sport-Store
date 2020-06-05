using System;
using System.Collections.Generic;
using System.Linq;

using SportsStore.Models;
using SportsStore.Models.Repository;


namespace SportsStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repObj = new Repository();

        private int pageSize = 4;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                int seciliUrunId = Convert.ToInt32(Request.Form["ekle"]);

                Sepet sepetim = (Sepet)Session["Sepet"];

                if(sepetim == null)
                {
                    sepetim = new Sepet();
                }

                Product seciliUrun = repObj.Products.Where(p => p.ProductID == seciliUrunId).FirstOrDefault();

                sepetim.SepeteEkle(seciliUrun, 1);

                Session["Sepet"] = sepetim; // sepeti güncelledi.

                // Programımızı başka bir sayfaya yönlendirmeye yarar.
                Response.Redirect("/Pages/SepetiGoster.aspx");


                // int.TryParse(Request.Form["ekle"], out seciliUrunId);

            }
        }

        protected int CurrentPage
        {
            get
            {
                int pageNumber;
                if (int.TryParse(Request.QueryString["page"], out pageNumber)) {

                    if (pageNumber > MaxPage)
                        return MaxPage;
                    else if (pageNumber < 1)
                        return 1;
                    else
                        return pageNumber;
                }
                else
                    return 1;
            }
        }

        protected string CurrentCategory
        {
            get
            {
                string category = Request.QueryString["category"];
                return category==null ? "" : category;
            }
        }


        protected int MaxPage
        {
            get
            {
                int maxPage = (int)Math.Ceiling((decimal)FilterProducts().Count() / pageSize);
                return maxPage;
            }
        } 

        protected IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> pObj = repObj.Products;

            string category = Request.QueryString["category"];

            if(category == null || category == "")
            {
                return pObj;
            }
            else
            {
                return pObj.Where(p => p.Category == category);
            }
        }


        // Veri tabanın içerisinde bulunduğu listeyi return eder.
        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts().OrderBy(p => p.ProductID)
                                  .Skip(( CurrentPage -1 ) * pageSize)
                                  .Take(pageSize);
        }
    }
}