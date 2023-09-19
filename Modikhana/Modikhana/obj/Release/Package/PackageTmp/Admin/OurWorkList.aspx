<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    StylesheetTheme="ButtonSkin" CodeBehind="OurWorkList.aspx.cs" Inherits="Modikhana.Admin.OurWorkList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="postedit" class="clearfix">
        <h2 class="ico_mug">
            List of Our Work</h2>
        <div id="success" runat="server" style="display: none;" class="info_div">
            <span class="ico_success">Yeah! Delete Successfully!</span></div>
        <div id="fail" runat="server" style="display: none;" class="info_div">
            <span class="ico_cancel">Ups, There was an error</span></div>
        <div class="section" id="GridDiv">
            <asp:GridView ID="GridOurWork" Width="100%" AutoGenerateColumns="false" runat="server"
                DataKeyNames="ID" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE"
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                PageSize="20" OnPageIndexChanging="GridOurWork_PageIndexChanging" OnRowDeleting="GridOurWork_RowDeleting"
                OnRowUpdating="GridOurWork_RowUpdating">
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
                    <asp:TemplateField HeaderText="Email Address">
                        <ItemTemplate>
                            <img src='<%#Eval("WorkImagePath")%>' width="40" height="40" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="middle">
                        <ItemTemplate>
                            <%#Eval("WorkName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order" ItemStyle-CssClass="middle">
                        <ItemTemplate>
                            <%#Eval("WorkOrder")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="middle">
                        <ItemTemplate>
                            <%#Eval("WorkStatus")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CommandName="Update" SkinID="GridEditButton" />
                            <asp:ImageButton ID="btndelete" runat="server" CommandName="Delete" SkinID="GridDeleteButton"
                                OnClientClick="return confirm('Are you sure you want to delete this record ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
