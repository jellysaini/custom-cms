<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="AddBanner.aspx.cs" Inherits="Modikhana.Admin.AddBanner" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Banner Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Save Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
       
        <fieldset>
            <legend><span class="spanFieldSet">
                <%
                    if (Request.QueryString["BannerId"] == null)
                    {
                        Response.Write("Create a New  Banner");
                    }
                    else
                    {
                        Response.Write("Edit Banner");
                    }
                %></span></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Banner Name:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ID="txtBannerName" ValidationGroup="AddBanner"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtBannerName" ForeColor="Red" ValidationGroup="AddBanner"
                            Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Banner Image:
                        </label>
                    </td>
                    <td>
                        <asp:FileUpload Width="395" ID="BannerImage" runat="server" />  <span style="color: Red;">&nbsp;Image size must be 949x310</span>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Order No.:
                        </label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtNormal" ID="txtOrder" ValidationGroup="AddBanner"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtOrder" ForeColor="Red" ValidationGroup="AddBanner"
                            Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ValidationGroup="AddBanner"
                            Display="Dynamic" ControlToValidate="txtOrder" Operator="DataTypeCheck" runat="server"
                            Type="Integer" ErrorMessage="Order no must be interger."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Banner Description:
                        </label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckBannerDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Status:
                        </label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="BannerStatus" CssClass="noborder" />
                    </td>
                </tr>
                <tr>
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Save" CssClass="buttonSave" ValidationGroup="AddBanner" runat="server"
                            ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button Text="Cancel" CssClass="buttonSave" CausesValidation="false" runat="server"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
