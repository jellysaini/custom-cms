using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventId"] != null)
            {
                if (!IsPostBack)
                {
                    GetEventData(Convert.ToInt32(Request.QueryString["EventId"]));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblEvent eventData = new Modikhana.DAL.tblEvent();
                eventData.EventDescription = ckEventDescription.Text;
                eventData.EventEndDate = Convert.ToDateTime(txtEventEndDate.Text);
                eventData.EventName = txtEventName.Text;
                eventData.EventStartDate = Convert.ToDateTime(txtEventStartDate.Text);
                eventData.EventStatus = Convert.ToBoolean(chkEventStatus.Checked);
                Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
                if (Request.QueryString["EventId"] == null)
                {
                    if (EventObj.InsertEvent(eventData) == true)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("EventList.aspx");
                    }

                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    eventData = null;
                }
                else
                {
                    eventData.ID = Convert.ToInt32(Request.QueryString["EventId"]);
                    if (EventObj.UpdateEvent(eventData) == true)
                    {
                        Response.Redirect("EventList.aspx");
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

        private void GetEventData(Int32 EventId)
        {
            Modikhana.DAL.tblEvent eventData = new Modikhana.DAL.tblEvent();
            Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
            eventData = EventObj.SelectEventById(EventId);
            ckEventDescription.Text = eventData.EventDescription;
            txtEventEndDate.Text = eventData.EventEndDate.ToString();
            txtEventName.Text = eventData.EventName;
            txtEventStartDate.Text = eventData.EventStartDate.ToString();
            chkEventStatus.Checked = Convert.ToBoolean(eventData.EventStatus);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventList.aspx");
        }
    }
}