using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models.Repository;

namespace SportsStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetCategories()
        {
            return new Repository().Products.Select(p => p.Category).Distinct().OrderBy(x => x);
        }


        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = Request.QueryString["category"];

            return string.Format("<a href='/Pages/Listing.aspx?category={0}' {1}>{0}</a>",
                category, category == selectedCategory ? "class='selected'" : "");

        }


    }
}