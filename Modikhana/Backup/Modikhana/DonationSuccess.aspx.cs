using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Configuration;

namespace Modikhana
{
    public partial class DonationSuccess : System.Web.UI.Page
    {
        string authToken, txToken, query;
        string strResponse;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["tx"] != null)
                {
                    Modikhana.BAL.PaymentGatewayDetail PaymentGatewayDetailObj = new Modikhana.BAL.PaymentGatewayDetail();
                    Modikhana.DAL.tblPaymentGatewayDetail PaymentGatewayDetail = new Modikhana.DAL.tblPaymentGatewayDetail();
                    PaymentGatewayDetail = PaymentGatewayDetailObj.SelectPaymentGatewayDetail();

                    authToken = PaymentGatewayDetail.PDTToken;

                    //read in txn token from querystring
                    txToken = Request.QueryString.Get("tx");


                    query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);

                    // Create the request back
                    string url = WebConfigurationManager.AppSettings["PayPalSubmitUrl"];
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                    // Set values for the request back
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = query.Length;

                    // Write the request back IPN strings
                    StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                    stOut.Write(query);
                    stOut.Close();

                    // Do the request to PayPal and get the response
                    StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
                    strResponse = stIn.ReadToEnd();
                    stIn.Close();


                    // If response was SUCCESS, parse response string and output details
                    if (strResponse.StartsWith("SUCCESS"))
                    {
                        Modikhana.Commom.PDTHolder pdt = Modikhana.Commom.PDTHolder.Parse(strResponse);
                        Modikhana.BAL.PayPalReceipt PayPalReceiptObj = new Modikhana.BAL.PayPalReceipt();
                        Boolean chk = PayPalReceiptObj.InsertPayPalReceipt(pdt.TransactionId, pdt.PayerEmail, pdt.PayerFirstName, pdt.PayerLastName, pdt.GrossTotal.ToString(), DateTime.Now, Convert.ToString(Session["Dname"]), Convert.ToString(Session["DPurpose"]), Convert.ToString(Session["DAmmount"]), "PayPal");
                        if (chk == true)
                        {
                            Session["Dname"] = null;
                            Session["DAmmount"] = null;
                            Session["DPurpose"] = null;
                        }
                    }
                    else
                    {
                        Response.Redirect("DonationFail.aspx");
                    }
                }
            }
        }
    }
}