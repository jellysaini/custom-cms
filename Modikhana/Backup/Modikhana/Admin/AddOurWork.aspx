<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddOurWork.aspx.cs" Inherits="Modikhana.Admin.AddOurWork" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h2 class="ico_mug">
            Our Work Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["OurWorkId"] == null)
                    {
                        Response.Write("Create a New Our Work");
                    }
                    else
                    {
                        Response.Write("Edit Our Work");
                    }
                %></span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Work Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="AddOurWork" ID="txtOurWorkName"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOurWorkName" ForeColor="Red" ValidationGroup="AddOurWork"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Work Image:
                        </label>
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="OurWorkImage" Width="395" /><span style="color: Red;">&nbsp;Image
                            size must be 500x350</span>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Order No.:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ValidationGroup="AddOurWork" ID="txtOrder"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOrder" ForeColor="Red" ValidationGroup="AddOurWork"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="AddOurWork"
                            Display="Dynamic" ControlToValidate="txtOrder" Operator="DataTypeCheck" runat="server"
                            Type="Integer" ErrorMessage="Order no must be interger."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Work Description:
                        </label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckOurWorkDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="OurWorkStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="AddOurWork" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
