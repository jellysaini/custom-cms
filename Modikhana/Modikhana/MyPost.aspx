<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="MyPost.aspx.cs" Inherits="Modikhana.MyPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tb
        {
            width: 900px;
            margin-left: 20px;
        }
        .tb th
        {
            text-align: left;
        }
        .tb td
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div style="float: left;">
            <table style="margin-left: 15px;">
                <tr>
                    <td>
                        <h2>
                            All Forums My Posts
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblMsg" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat="server" CssClass="tb" AutoGenerateColumns="False" DataKeyNames="ID"
                            ID="MyPostGridView" OnPageIndexChanging="MyPostGridView_PageIndexChanging" OnRowDeleting="MyPostGridView_RowDeleting"
                            OnRowUpdating="MyPostGridView_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="Post Name" HeaderStyle-Width="450" HeaderStyle-Height="30">
                                    <ItemTemplate>
                                        <%# Eval("TopicName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Post Status" HeaderStyle-Width="150" HeaderStyle-Height="30">
                                    <ItemTemplate>
                                        <%# Eval("TopicStatus") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actions" HeaderStyle-Width="100" HeaderStyle-Height="30">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Update" SkinID="GridEditButton" />
                                        <asp:ImageButton ID="btndelete" runat="server" CommandName="Delete" SkinID="GridDeleteButton"
                                            OnClientClick="return confirm('Are you sure you want to delete this record ?');" />
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
    <script type="text/javascript">
        $("#Forums").addClass("tray-active");
    </script>
</asp:Content>
