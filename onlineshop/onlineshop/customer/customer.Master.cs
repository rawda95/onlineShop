﻿using System;

namespace onlineshop.customer
{
    public partial class customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lb_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer/products.aspx");
        }

        protected void contact_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ContactPage.aspx");

        }

        protected void lb_about_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AboutUs.aspx");
        }
    }
}
