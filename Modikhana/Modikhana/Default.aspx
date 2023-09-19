<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Modikhana.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="BannerScript/themes/default/default.css" type="text/css"
        media="screen" />
    <link rel="stylesheet" href="BannerScript/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="BannerScript/style.css" type="text/css" media="screen" />
    <link href="css/periscope-theme-switcher.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.scrollTo.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery.infinite-carousel.js">
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#slider-stage').carousel('#previous', '#next');
            jQuery('#viewport').carousel('#simplePrevious', '#simpleNext');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="col-top">
    </div>
    <div id="col" runat="server" style="height: 350px;" class="box">
        <div id="wrapper">
            <div class="slider-wrapper theme-default">
                <div class="ribbon">
                </div>
                <div id="slider" class="nivoSlider">
                    <asp:Repeater runat="server" ID="RepeaterBanner">
                        <ItemTemplate>
                            <img src="<%# Eval("BannerImagePath") %>" style="width: 949px; height: 310px;" alt=""
                                title="<%#Eval("BannerName") %>" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="BannerScript/jquery.nivo.slider.pack.js"></script>
        <script type="text/javascript">
            $(window).load(function () {
                $('#slider').nivoSlider();
            });
        </script>
    </div>
    <!-- /col -->
    <div id="col-bottom">
    </div>
    <hr class="noscreen" />
    <!-- 2 columns -->
    <div id="cols2-top">
    </div>
    <div id="cols2" class="box">
        <%
            Modikhana.DAL.tblContentManagement contentData = new Modikhana.DAL.tblContentManagement();
            Modikhana.BAL.ContentManagement contentObj = new Modikhana.BAL.ContentManagement();
            contentData = contentObj.SelectByPageId(8);
        %>
        <div id="col-left">
            <div class="title">
                <h4>
                    <%
                        Response.Write(contentData.LinkName);
                    %>
                </h4>
            </div>
            <%
                Response.Write(contentData.LinkContent);
                contentData = null;
                contentObj = null;
            %>
            <div class="col-more1">
                <a href="AboutUs.aspx">
                    <img src="design/cols2-more.gif" alt="More" /></a></div>
        </div>
        <!-- /col-left -->
        <hr class="noscreen" />
        <!-- Testimonials -->
        <div id="col-right">
            <h4>
                <span>Latest News</span></h4>
            <asp:Repeater runat="server" ID="RepeaterNews">
                <ItemTemplate>
                    <div class="box">
                        <div class="col-right-img">
                            <a href="NewsRoomDetail.aspx?News=<%#Eval("ID")%>">
                                <img src='<%# "Handler/Thumbnail65x65.ashx?ImURL="+Eval("NewsImagePath") %>' width="65"
                                    height="50" alt="" />
                            </a>
                        </div>
                        <div class="col-right-text">
                            <p>
                                <%#Convert.ToString(Eval("NewsDescription")).Length <= 150 ? Eval("NewsDescription").ToString() : Eval("NewsDescription").ToString().Substring(0, 150)%>
                            </p>
                            <p class="high smaller">
                                &ndash; <cite>"<%# Eval("NewsName") %>"</cite>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!-- /box -->
        </div>
        <!-- /col-right -->
    </div>
    <!-- /cols2 -->
    <div id="cols2-bottom">
    </div>
    <!-- 3 columns -->
    <div id="cols3-top">
    </div>
    <div id="cols3" class="box">
        <!-- Column I. -->
        <div class="col">
            <h3>
                <a href="OurWork.aspx">Our Work</a></h3>
            <p class="nom t-center">
                <a href="#">
                    <img src="design/ourworkmain.jpg" alt="" width="200" height="140" /></a></p>
            <div class="col-text">
                <p>
                    Welcome to Modilhana Charitable Trust Our Work.</p>
                <ul class="ul-01">
                    <asp:Repeater runat="server" ID="RepeaterOurWork">
                        <ItemTemplate>
                            <li><a style="text-decoration: none;" href="OurWorkDetail.aspx?OurWork=<%#Eval("ID")%>">
                                <%# Eval("WorkName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!-- /col-text -->
            <div class="col-more">
                <a href="OurWork.aspx">
                    <img src="design/cols3-more.gif" alt="" /></a></div>
        </div>
        <!-- /col -->
        <hr class="noscreen" />
        <!-- Column II. -->
        <div class="col">
            <h3>
                <a href="Forums.aspx">Latest Post</a></h3>
            <p class="nom t-center">
                <a href="#">
                    <img src="design/posts.jpg" alt="" width="200" height="140" /></a></p>
            <div class="col-text">
                <p>
                    Welcome to Modikhana Charitable Trust Latest Forums.</p>
                <ul class="ul-01">
                    <asp:Repeater runat="server" ID="RepeaterForums">
                        <ItemTemplate>
                            <li><a style="text-decoration: none;" href="CommentOnPost.aspx?Post=<%#Eval("ID")%>">
                                <%# Eval("TopicName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!-- /col-text -->
            <div class="col-more">
                <a href="Forums.aspx">
                    <img src="design/cols3-more.gif" alt="" /></a></div>
        </div>
        <!-- /col -->
        <hr class="noscreen" />
        <!-- Column III. -->
        <div class="col last">
            <h3>
                <a href="Event.aspx">Events</a></h3>
            <p class="nom t-center">
                <a href="#">
                    <img src="design/events-icon.gif" alt="" width="200" height="140" /></a></p>
            <div class="col-text">
                <p>
                    Welcome to Modilhana Charitable Trust Events.</p>
                <ul class="ul-01">
                    <asp:Repeater runat="server" ID="RepeaterEvents">
                        <ItemTemplate>
                            <li><a style="text-decoration: none;" href="EventDetail.aspx?Event=<%#Eval("ID")%>">
                                <%# Eval("EventName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!-- /col-text -->
            <div class="col-more">
                <a href="Event.aspx">
                    <img src="design/cols3-more.gif" alt="" /></a></div>
        </div>
        <!-- /col -->
        <hr class="noscreen" />
    </div>
    <!-- /cols3 -->
    <div id="cols3-bottom">
    </div>
    <hr class="noscreen" />
    <div id="cols5-top">
    </div>
    <div id="cols5" class="box">
        <div class="col">
            <h3>
                <a href="#">Supposers</a></h3>
        </div>
        <div style="clear: both; height: 170px; width: 950px;">
            <div id="corousel">
                <div>
                    <div class="demo">
                        <div id="sliderBloc">
                            <a id="previous">Previous</a>
                            <div style="" id="slider-stage">
                                <div style="width: 950px;" id="slider-list">
                                    <asp:Repeater ID="RepeaterImages" runat="server">
                                        <ItemTemplate>
                                            <a class="theme">
                                                <img src="<%# Eval("SupposerImagePath") %>" alt="Periscope angels " height="143"
                                                    width="224" /><span class="nameVignette">"<%# Eval("SupposerName")%>"</span></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <a id="next">Next</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="cols5-bottom">
    </div>
    <script>
        var max_height = 0;
        $(".col-text").each(function () {

            current_height = $(this).height();

            if (current_height > max_height) {

                max_height = current_height;

            }

        });

        $(".col-text").height(max_height);

    </script>
</asp:Content>
