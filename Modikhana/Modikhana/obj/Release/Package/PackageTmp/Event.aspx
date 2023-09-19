<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="Event.aspx.cs" Inherits="Modikhana.Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        a
        {
            text-decoration: none;
        }
        .tb
        {
            margin-left: 10px;
        }
        .tb tr
        {
            height: 40px;
        }
        .tb td
        {
            width: 320px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.ContentManagement objPage = new Modikhana.BAL.ContentManagement();
        Modikhana.DAL.tblContentManagement PageData = new Modikhana.DAL.tblContentManagement();
        PageData = objPage.SelectByPageId(4);
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
        <div style="float: right; margin-right: 5px; margin-top: 15px; width: 270px">
            <img src="design/events.jpg" alt="" />
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
                        <asp:DataList runat="server" CssClass="tb" ID="EventDataList" RepeatColumns="3">
                            <ItemTemplate>
                                <div style="width:300px;">
                                    <div style="float: left;">
                                        <a style="color: Maroon; font-weight: bold;" href="EventDetail.aspx?Event=<%#Eval("ID")%>">
                                            <%#Eval("EventName")%></a>
                                    </div>
                                    <div style="float: left; clear: both;">
                                        <b>
                                            <%# String.Format("{0:d/M/yyyy}", Eval("EventStartDate"))%>
                                            -
                                            <%# String.Format("{0:d/M/yyyy}", Eval("EventEndDate"))%>
                                        </b>
                                    </div>
                                    <div style="float: left; clear: both;">
                                        <p>
                                            <%#Eval("EventDescription").ToString().Substring(0, 200)%></p>
                                    </div>
                                    <div style="height: 30px; float: left; clear: both;">
                                        &nbsp;
                                    </div>
                                </div>
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
