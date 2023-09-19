<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="OurWorkDetail.aspx.cs" Inherits="Modikhana.OurWorkDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.OurWork OurWorkObj = new Modikhana.BAL.OurWork();
        Modikhana.DAL.tblOurWork OurWorkData = new Modikhana.DAL.tblOurWork();
        OurWorkData = OurWorkObj.SelectOurWorkById(Convert.ToInt32(Request.QueryString["OurWork"]));
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 15px; margin-right: 15px;"
            width="930px;">
            <tr style="margin-top: 5px;">
                <td colspan="3">
                    <h2>
                        <%
                            Response.Write(OurWorkData.WorkName.ToString());
                        %>
                    </h2>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: right; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;
                        width: 520px;">
                        <img src="<%Response.Write(OurWorkData.WorkImagePath.ToString());%>" style="width: 500px;
                            height: 350px;" alt="" />
                    </div>
                    <p>
                        <%
                            Response.Write(OurWorkData.WorkDescription.ToString());
                        %>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
    <script type="text/javascript">
        $("#OurWork").addClass("tray-active");
    </script>
</asp:Content>
