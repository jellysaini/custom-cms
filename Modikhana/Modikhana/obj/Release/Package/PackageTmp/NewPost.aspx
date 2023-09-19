<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="NewPost.aspx.cs" Inherits="Modikhana.NewPost" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left;">
            <table style="margin-left: 15px;">
                <tr>
                    <td colspan="2">
                        <h2>
                            <%
                                if (Request.QueryString["PostId"] == null)
                                {
                                    Response.Write("Create A New Post");
                                }
                                else
                                {
                                    Response.Write("Edit Post");
                                }
                            %>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <td>
                            &nbsp;
                        </td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        Post Name :
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txtWidthHeight" ValidationGroup="post" ID="txtPostName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="post" ControlToValidate="txtPostName"
                            ForeColor="Red" Display="Static" runat="server" ErrorMessage="This field is required."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        Post Description:
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="ckPostDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button runat="server" SkinID="NormalButton" ValidationGroup="post" ID="btnSave"
                            Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" SkinID="NormalButton" CausesValidation="false" ID="btnClear"
                            Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label runat="server" Font-Bold="true" ID="lblmsg"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
    <script type="text/javascript">
        $("#Forums").addClass("tray-active");
    </script>
</asp:Content>
