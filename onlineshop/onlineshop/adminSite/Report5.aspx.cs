﻿using onlineshop.BL;
using System;
namespace onlineshop.adminSite
{
    public partial class Report5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            string productname = txt_product.Text;
            grd_viewallshops.DataSource = Shop.viewshopspecificproduct(productname);
            grd_viewallshops.DataBind();
        }
    }
}
