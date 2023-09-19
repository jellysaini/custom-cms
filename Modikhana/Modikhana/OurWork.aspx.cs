using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana
{
    public partial class OurWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataList();
            }
        }

        private void BindDataList()
        {
            Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
            OurWorkDataList.DataSource = OurWorkObj.SelectAllOurWorkByTrueStatus();
            OurWorkDataList.DataBind();
        }
    }
}