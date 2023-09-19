<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="TopicComment.aspx.cs" StylesheetTheme="ButtonSkin" Inherits="Modikhana.Admin.TopicComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/MyStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            Topic Comment Mangement</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Post Comment Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <fieldset>
            <legend><span class="spanFieldSet">Post Topic Comment</span></legend>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 200px;">
                        <label class="lblNormal">
                            Select Topic:
                        </label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpTopics" Width="250" Height="28">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnSearch" Text="Search" CausesValidation="false" Height="28" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridTopicsComment" Width="100%" AutoGenerateColumns="false" runat="server"
                            DataKeyNames="ID" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                            PageSize="20" OnRowDeleting="GridTopicsComment_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" Font-Bold="True" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div>
                                            <div style="float: left; width: auto">
                                                <b>Comment By :-</b>&nbsp;<%#Eval("LoginName")%>&nbsp;&nbsp;</div>
                                            <div style="float: left; width: 350px;">
                                                <b>Comment On :-</b>&nbsp;<%#Eval("CreateedOn")%></div>
                                            <div style="float: right;">
                                                <asp:ImageButton ID="btndelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                    SkinID="GridTopicDeleteButton" OnClientClick="return confirm('Are you sure you want to delete this record ?');" />
                                            </div>
                                        </div>
                                        <div style="clear: both;">
                                            <%#Eval("TopicComment")%>
                                        </div>
                                        <div style="height: 25px; clear: both;">
                                            &nbsp;
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox CssClass="lblNormal" runat="server" Width="500" Height="80" ID="txtTopicComment"
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtTopicComment" ForeColor="Red" Display="Dynamic"
                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="lblNormal" runat="server" ID="btnComment" Text="Comment !"
                            OnClick="btnComment_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
