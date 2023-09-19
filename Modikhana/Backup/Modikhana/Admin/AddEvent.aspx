<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddEvent.aspx.cs" Inherits="Modikhana.Admin.AddEvent" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Event Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["EventId"] == null)
                    {
                        Response.Write("Create an Event");
                    }
                    else
                    {
                        Response.Write("Edit an Event");
                    }
                %></span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Event Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="AddEvent" ID="txtEventName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtEventName" ForeColor="Red" ValidationGroup="AddEvent"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Event Start Date:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="AddEvent" ID="txtEventStartDate"></asp:TextBox>
                          <asp:CalendarExtender ID="txtEventStartDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtEventStartDate">
                        </asp:CalendarExtender>
                        &nbsp;&nbsp;MM/DD/YYYY
                        <asp:RequiredFieldValidator ControlToValidate="txtEventStartDate" ForeColor="Red"
                            ValidationGroup="AddEvent" Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Event End Date:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="AddEvent" ID="txtEventEndDate"></asp:TextBox>
                        <asp:CalendarExtender ID="txtEventEndDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtEventEndDate">
                        </asp:CalendarExtender>
                        &nbsp;&nbsp;MM/DD/YYYY
                        <asp:RequiredFieldValidator ControlToValidate="txtEventEndDate" ForeColor="Red" ValidationGroup="AddEvent"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%-- <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Event Image:
                        </label>
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="EventImage" Width="395" />
                    </td>
                </tr>--%>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Event Description:
                        </label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckEventDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkEventStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="AddEvent" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
