<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="NewsRoomDetail.aspx.cs" Inherits="Modikhana.NewsRoomDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.News NewsObj = new Modikhana.BAL.News();
        Modikhana.DAL.tblNew NewsData = new Modikhana.DAL.tblNew();
        NewsData = NewsObj.SelectNewsById(Convert.ToInt32(Request.QueryString["News"]));
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 15px; margin-right: 15px;"
            width="930px;">
            <tr style="margin-top: 5px;">
                <td>
                    <h2>
                        <%
                            Response.Write(NewsData.NewsName.ToString());
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
                    <div style="float: right; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;
                        width: 520px;">
                        <img src="<%Response.Write(NewsData.NewsImagePath.ToString());%>" style="width: 500px;
                            height: 350px;" alt="" />
                        <br />
                        <span style="font-size: 11px;">
                            <%
                                Response.Write(NewsData.NewsName.ToString());
                            %></span>
                    </div>
                    <p>
                        <%
                            Response.Write(NewsData.NewsDescription.ToString());
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
        $("#NewsRoom").addClass("tray-active");
    </script>
</asp:Content>
