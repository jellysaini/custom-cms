using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modikhana.Admin
{
    public partial class AddBankDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BankinfoId"] != null)
            {
                if (!IsPostBack)
                {
                    GetBankData(Convert.ToInt32(Request.QueryString["BankinfoId"]));
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Modikhana.DAL.tblOnlineBankInfo onlinebankinfoData = new Modikhana.DAL.tblOnlineBankInfo();
                onlinebankinfoData.AccountHolder = txtAccountHolder.Text;
                onlinebankinfoData.AccountNo = txtAccountNo.Text;
                onlinebankinfoData.AccountType = txtAccountType.Text;
                onlinebankinfoData.BankName = txtBankName.Text;
                onlinebankinfoData.Branch = txtBranchName.Text;
                onlinebankinfoData.IFSCCode = txtIFSCCode.Text;
                onlinebankinfoData.Status = BankStatus.Checked;

                Modikhana.BAL.OnlineBankInfo OnlineBankInfoObj = new Modikhana.BAL.OnlineBankInfo();
                if (Request.QueryString["BankinfoId"] == null)
                {
                    int Result = OnlineBankInfoObj.InsertOnlineBankInfo(onlinebankinfoData);
                    if (Result == 1)
                    {
                        success.Style.Add("display", "");
                        Response.Redirect("BankDetailList.aspx");
                    }
                    else
                    {
                        fail.Style.Add("display", "");
                    }
                    OnlineBankInfoObj = null;
                }
                else
                {
                    onlinebankinfoData.ID = Convert.ToInt32(Request.QueryString["BankinfoId"]);
                    if (OnlineBankInfoObj.UpdateOnlineBankInfo(onlinebankinfoData) == true)
                    {
                        Response.Redirect("BankDetailList.aspx");
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

        private void GetBankData(Int32 BankInfoId)
        {
            Modikhana.DAL.tblOnlineBankInfo onlinebankinfoData = new Modikhana.DAL.tblOnlineBankInfo();
            Modikhana.BAL.OnlineBankInfo OnlineBankInfoObj = new Modikhana.BAL.OnlineBankInfo();
            onlinebankinfoData = OnlineBankInfoObj.SelectOnlineBankInfoById(BankInfoId);
            txtAccountHolder.Text = onlinebankinfoData.AccountHolder;
            txtAccountNo.Text = onlinebankinfoData.AccountNo;
            txtAccountType.Text = onlinebankinfoData.AccountType;
            txtBankName.Text = onlinebankinfoData.BankName;
            txtBranchName.Text = onlinebankinfoData.Branch;
            txtIFSCCode.Text = onlinebankinfoData.IFSCCode;
            BankStatus.Checked =Convert.ToBoolean(onlinebankinfoData.Status);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BankDetailList.aspx");
        }

    }
}