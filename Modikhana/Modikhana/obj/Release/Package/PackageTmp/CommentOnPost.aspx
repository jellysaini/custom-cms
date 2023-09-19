<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" StylesheetTheme="ButtonSkin" CodeBehind="CommentOnPost.aspx.cs"
    Inherits="Modikhana.CommentOnPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%
        Modikhana.BAL.DiscussionTopic DiscussionTopicObj = new Modikhana.BAL.DiscussionTopic();
        Modikhana.DAL.SelectDiscusstionTopicByIdResult DiscussionTopicData = new Modikhana.DAL.SelectDiscusstionTopicByIdResult();
        DiscussionTopicData = DiscussionTopicObj.SelectDiscussionTopicById(Convert.ToInt32(Request.QueryString["Post"]));
    %>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-left: 25px;">
            <tr>
                <td>
                    <h2>
                        <%
                            Response.Write(DiscussionTopicData.TopicName.ToString());
                        %>
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Created by&nbsp;&nbsp;<%
                                                    Response.Write(DiscussionTopicData.LoginName.ToString());
                    %>,&nbsp&nbsp;&nbsp; Created on&nbsp;
                        <%
                            Response.Write(String.Format("{0:d/M/yyyy}", DiscussionTopicData.CreateedOn));
                        %>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 900px;">
                        <tr>
                            <td>
                                <p>
                                    <%
                                        Response.Write(DiscussionTopicData.TopicDescription.ToString());
                                    %>
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>
                        Comments On Post !
                    </h3>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 900px;">
                        <tr>
                            <td>
                                <asp:GridView runat="server" AutoGenerateColumns="false" ID="CommentGridView" DataKeyNames="ID"
                                    OnRowDeleting="CommentGridView_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div style="width: 900px;">
                                                    <div style="float: left; width: auto">
                                                        <b>Comment by :-</b>&nbsp;<%#Eval("LoginName")%>&nbsp;&nbsp;</div>
                                                    <div style="float: left; width: 350px;">
                                                        <b>Comment on :-</b>&nbsp;<%#Eval("CreateedOn")%></div>
                                                    <div style="float: right;">
                                                        <asp:ImageButton ID="btndelete" runat="server" CausesValidation="false" Visible='<%#Convert.ToInt32(Eval("UserId"))==Convert.ToInt32(Session["UserId"])?true:false %>'
                                                            CommandName="Delete" SkinID="GridTopicDeleteButton" OnClientClick="return confirm('Are you sure you want to delete this record ?');" />
                                                    </div>
                                                </div>
                                                <div style="clear: both; width: 870px;">
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
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="lblNormal" runat="server" Width="700" Height="90" ID="txtPostComment"
                        ValidationGroup="comment" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtPostComment" ForeColor="Red" Display="Dynamic"
                        ValidationGroup="comment" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required field cannot be left blank."></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button CssClass="lblNormal" SkinID="ChgPawdButton" runat="server" ID="btnComment"
                        ValidationGroup="comment" Text="Comment !" OnClick="btnComment_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Font-Bold="true" ID="lblMsg"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="cols5-bottom">
    </div>
    <hr class="noscreen" />
    <script type="text/javascript">
        $("#Forums").addClass("tray-active");
    </script>
</asp:Content>
