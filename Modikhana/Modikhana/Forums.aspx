<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="Forums.aspx.cs" Inherits="Modikhana.Forums" %>

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
        PageData = objPage.SelectByPageId(7);
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
            <img src="design/forums.jpg" alt="" />
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
                <tr style="height: 30px;">
                    <td>
                        <h4>
                            Welcome to the Modikhana Charitable Trust Forums !
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" SkinID="BigWidth" Text="Start A New Post" ID="btnNewPost"
                            OnClick="btnNewPost_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" SkinID="NormalButton" Text="My Posts" ID="btnMyPost" OnClick="btnMyPost_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat="server" CssClass="tb" AutoGenerateColumns="false" ID="GridViewForums"
                            AllowPaging="True" PageSize="20" OnPageIndexChanging="GridViewForums_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div style="width: 900px; height: 100px;">
                                            <div style="float: left; margin-left: 15px; width: 800px;">
                                                <span style="font-size: 16px; font-weight: bold;"><a style="color: Maroon;" href="CommentOnPost.aspx?Post=<%#Eval("ID")%>">
                                                    <%#Eval("TopicName")%></a></span>
                                                <br />
                                                <span>Created&nbsp;by&nbsp;&nbsp;<%#Eval("LoginName")%>,&nbsp;&nbsp Created on
                                                    <%#String.Format("{0:d/M/yyyy}", Eval("CreateedOn"))%>
                                                </span>
                                                <div>
                                                    <%#Convert.ToString(Eval("TopicDescription")).Length <= 330 ? Eval("TopicDescription").ToString() : Eval("TopicDescription").ToString().Substring(0, 330)%>
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
