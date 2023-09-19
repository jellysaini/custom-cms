<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="OurWork.aspx.cs" Inherits="Modikhana.OurWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        a
        {
            text-decoration: none;
        }
        .tb
        {
            margin-left:50px;
        }
        .tb tr
        {
            height:40px;
        }
        .tb td
        {
            width:350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(2);
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left; width: 660px;">
            <table style="margin-left: 15px;">
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
        <div style="float: right; margin-right: 20px; margin-top: 25px; width: 270px">
            <img src="design/ourwork.gif" alt="" />
        </div>
        <div style="clear: both;">
            <table style="margin-left: 15px;">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>
                            Our world changing deeds !
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList runat="server" CssClass="tb" ID="OurWorkDataList" RepeatColumns="2">
                            <ItemTemplate>
                                <a href="OurWorkDetail.aspx?OurWork=<%#Eval("ID")%>">
                                    <img src="design/tick.png" alt="" /><%#Eval("WorkName")%></a>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
</asp:Content>
