using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddContactDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ContactDetailId"] != null)
            {
                if (!IsPostBack)
                {
                    GetContactData(Convert.ToInt32(Request.QueryString["ContactDetailId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblContactDetail contactData = new Modikhana.DAL.tblContactDetail();
                contactData.Address = txtAddress.Text;
                contactData.City = txtCity.Text;
                contactData.Email = txtEmail.Text;
                contactData.Mobile = txtMobile.Text;
                contactData.OfficeLocation = txtOfficeLocation.Text;
                contactData.State = txtState.Text;
                contactData.Telephone = txtTelephone.Text;

                Modikhana.BAL.ContactDetail ContactDetailObj = new Modikhana.BAL.ContactDetail();
                if (Request.QueryString["ContactDetailId"] == null)
                {
                    int Result = ContactDetailObj.InsertContactDetail(contactData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("ContactDetailList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    ContactDetailObj = null;
                }
                else
                {
                    contactData.ID = Convert.ToInt32(Request.QueryString["ContactDetailId"]);
                    if (ContactDetailObj.UpdateContactDetail(contactData) == true)
                    {
                        Response.Redirect("ContactDetailList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                }
            }
            catch (Exception)
            {
                fail.Style.Add("display", "");
            }
        }

        private void GetContactData(Int32 ContactId)
        {
            Modikhana.DAL.tblContactDetail contactData = new Modikhana.DAL.tblContactDetail();
            Modikhana.BAL.ContactDetail ContactDetailObj = new Modikhana.BAL.ContactDetail();
            contactData = ContactDetailObj.SelectContactDetailById(ContactId);
            txtAddress.Text = contactData.Address;
            txtCity.Text = contactData.City;
            txtEmail.Text = contactData.Email;
            txtMobile.Text = contactData.Mobile;
            txtOfficeLocation.Text = contactData.OfficeLocation;
            txtState.Text = contactData.State;
            txtTelephone.Text = contactData.Telephone;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactDetailList.aspx");
        }
    }
}