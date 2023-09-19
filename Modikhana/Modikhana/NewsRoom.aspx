<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="NewsRoom.aspx.cs" Inherits="Modikhana.NewsRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tb
        {
            margin-left: 30px;
        }
        a
        {
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(3);
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
            <img src="design/news.gif" alt="" />
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
                            Modikhana charitable trust latest news section !
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat="server" CssClass="tb" AutoGenerateColumns="false" ID="GridViewNews"
                            AllowPaging="True" OnPageIndexChanging="GridViewNews_PageIndexChanging" PageSize="20">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div style="width: 900px; height: 100px;">
                                            <div style="float: left; width: 150px;">
                                                <img src='<%# "Handler/Thumbnail150x90.ashx?ImURL="+Eval("NewsImagePath") %>'  alt="" />
                                            </div>
                                            <div style="float: left; margin-left: 15px; width: 700px;">
                                                <span style="font-size: large;"><a href="NewsRoomDetail.aspx?News=<%#Eval("ID")%>">
                                                    <%#Eval("NewsName")%></a></span>
                                                <div>
                                                    <%#Convert.ToString(Eval("NewsDescription")).Length <= 330 ? Eval("NewsDescription").ToString() : Eval("NewsDescription").ToString().Substring(0, 330)%>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="clear: both; float: left; height: 30px;">
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
</asp:Content>
