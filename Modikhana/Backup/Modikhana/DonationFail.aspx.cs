using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class DonationFail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Dname"] = null;
            Session["DAmmount"] = null;
            Session["DPurpose"] = null;
        }
    }
}