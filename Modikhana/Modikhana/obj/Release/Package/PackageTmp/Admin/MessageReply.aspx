<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="MessageReply.aspx.cs" Inherits="Modikhana.Admin.MessageReply" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Message Reply</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! mail sent successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error or content is empty</span></div>
        <div class="section" id="main">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="height: 30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            User Name :
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Jarnail Singh" ID="lblUserName"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            User Email :
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="jellysaini@gmail.com" ID="lblUserEmail"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td class="tdWidth">
                        <label class="lblNormal">
                            Message :
                        </label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail  jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail jarnail"
                            ID="lblMessage"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td style="vertical-align: top;" class="tdWidth">
                        <label class="lblNormal">
                            Your Message :
                        </label>
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckMessage" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td class="tdWidth">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button Text="Send" CssClass="buttonSaveReply" runat="server" ID="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button Text="Clear" CssClass="buttonSaveReply" CausesValidation="false" runat="server"
                            OnClick="btnCancel_Click" ID="btnCancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
