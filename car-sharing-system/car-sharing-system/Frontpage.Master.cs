﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace car_sharing_system
{
    public partial class Frontpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session["UserId"] != null) {
				Debug.WriteLine("uid = " + Session["UserId"].ToString());
			}

		}
	}
}