<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="EventDetail.aspx.cs" Inherits="Modikhana.EventDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Modikhana.BAL.Event EventObj = new Modikhana.BAL.Event();
        Modikhana.DAL.tblEvent EventData = new Modikhana.DAL.tblEvent();
        EventData = EventObj.SelectEventById(Convert.ToInt32(Request.QueryString["Event"]));
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box" style="width: 960px; min-height: 390px;">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 30px;" width="880px;">
            <tr style="margin-top: 5px;">
                <td>
                    <h2>
                        <%
                            Response.Write(EventData.EventName.ToString());
                        %>
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                    <h4>
                        Start Date :-
                        <%
                            Response.Write(String.Format("{0:d/M/yyyy}", EventData.EventStartDate));
                        %>
                    </h4>
                </td>
            </tr>
            <tr>
                <td>
                    <h4>
                        End Date :-
                        <%
                            Response.Write(String.Format("{0:d/M/yyyy}", EventData.EventEndDate));
                        %>
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
                    <p style="margin-right: 70px;">
                        <%
                            Response.Write(EventData.EventDescription.ToString());
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
        $("#Event").addClass("tray-active");
    </script>
</asp:Content>
