<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMain.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Modikhana.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content_main" class="clearfix">
        <div id="main_panel_container" class="left">
            <div id="dashboard">
                <h2 class="ico_mug">
                    Dashboard</h2>
                <%
                    Modikhana.BAL.Dashboard DashboardObj = new Modikhana.BAL.Dashboard();
                    Modikhana.DAL.DashboardTotalResult DashboardData = new Modikhana.DAL.DashboardTotalResult();
                    DashboardData = DashboardObj.SelectDashboardTotal();
                %>
                <div class="clearfix">
                    <div class="left quickview" style="margin-left: 80px; height: 235px;">
                        <h3>
                            Overview</h3>
                        <ul>
                            <li>Total # of Users: <span class="number"><%Response.Write(DashboardData.user); %></span></li>
                            <li>Total # of Pages: <span class="number"><%Response.Write(DashboardData.pages); %></span></li>
                            <li>Total # of Banners: <span class="number"><%Response.Write(DashboardData.banner); %></span></li>
                            <li>Total # of Our Work: <span class="number"><%Response.Write(DashboardData.outwork); %></span></li>
                            <li>Total # of Events: <span class="number"><%Response.Write(DashboardData.@event); %></span></li>
                            <li>Total # of News: <span class="number"><%Response.Write(DashboardData.news); %></span></li>
                            <li>Total # of Contact Details: <span class="number"><%Response.Write(DashboardData.contactdetail); %></span></li>
                            <li>Total # of Supposers: <span class="number"><%Response.Write(DashboardData.supposer); %></span></li>
                            <li>Total # of Donations: <span class="number"><%Response.Write(DashboardData.donation); %></span></li>
                        </ul>
                    </div>
                    <div class="quickview left" style="margin-left: 80px; height: 235px;">
                        <h3>
                            Message Data</h3>
                        <ul>
                            <li>Feedback: <span class="number"><%Response.Write(DashboardData.feedback); %></span></li>
                            <li>Contact Us: <span class="number"><%Response.Write(DashboardData.contactus); %></span></li>
                            <li>Help Me: <span class="number"><%Response.Write(DashboardData.help); %></span></li>
                        </ul>
                    </div>
                    <div class="quickview left" style="margin-left: 80px; height: 235px;">
                        <h3>
                            Forms Data</h3>
                        <ul>
                            <li>Total # of Active Posts: <span class="number"><%Response.Write(DashboardData.activepost); %></span></li>
                            <li>Total # of Inactive Posts: <span class="number"><%Response.Write(DashboardData.inactivepost); %></span></li>
                            <li>Total # of Comments: <span class="number"><%Response.Write(DashboardData.comments); %></span></li>
                        </ul>
                    </div>
                </div>
                <!-- end #dashboard -->
                <div id="shortcuts" class="clearfix">
                    <h2 class="ico_mug">
                        Panel shortcuts</h2>
                    <ul>
                        <li class="first_li"><a href="PagesList.aspx">
                            <img src="img/theme.jpg" alt="Pages" /><span>Pages</span></a></li>
                        <li><a href="UserList.aspx">
                            <img src="img/users.jpg" alt="Users" /><span>Users</span></a></li>
                        <li><a href="BannerList.aspx">
                            <img src="img/gallery.jpg" alt="Banner" /><span>Banners</span></a></li>
                        <li><a href="DiscussionTopicsList.aspx">
                            <img src="img/comments.jpg" alt="Forums" /><span>Forums</span></a></li>
                        <li><a href="EventList.aspx">
                            <img src="img/events.png" alt="Events" /><span>Events</span></a></li>
                        <li><a href="NewsList.aspx">
                            <img src="img/news.png" alt="News" /><span>News</span></a></li>
                        <li><a href="OurWorkList.aspx">
                            <img src="img/work.png" alt="Our Worl" /><span>Our Works</span></a></li>
                        <li><a href="DonationList.aspx">
                            <img src="img/donate.png" alt="Donate" /><span>Donations</span></a></li>
                        <li><a href="EmailSetting.aspx">
                            <img src="img/setting.png" alt="Setting" /><span>Email-Setting</span></a></li>
                        <li><a href="ContactUs.aspx">
                            <img src="img/messages.png" alt="Message" /><span>Messages</span></a></li>
                    </ul>
                </div>
                <!-- end #shortcuts -->
            </div>
        </div>
</asp:Content>
