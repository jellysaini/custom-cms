<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="AboutUs.aspx.cs" Inherits="Modikhana.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(6);
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left;">
            <table style="margin: 15px;">
                <tr>
                    <td>
                        <h2>
                            <%
                                Response.Write(PageData.LinkName.ToString());
                            %>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <%
                                Response.Write(PageData.LinkContent.ToString());
                                PageData = null;
                                objPage = null;
                            %>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
</asp:Content>
