﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineshop.adminSite
{
    public partial class manageusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/adminSite/allsellers.aspx");

        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/adminSite/allcustomers.aspx");

        }
    }
}