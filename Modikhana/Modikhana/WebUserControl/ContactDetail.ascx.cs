using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.WebUserControl
{
    public partial class ContactDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }
        private void BindRepeater()
        {
            Modikhana.BAL.ContactDetail ContactDetailObj = new Modikhana.BAL.ContactDetail();
            contactDetailRepeater.DataSource = ContactDetailObj.SelectAllContactDetail();
            contactDetailRepeater.DataBind();
        }

    }
}