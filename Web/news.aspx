<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="Web_news" %>

<%@ Register Src="~/Web/head.ascx" TagPrefix="uc1" TagName="head" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!-- Bootstrap -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/mystyle.css" rel="stylesheet" type="text/css" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>

    <div class="main_bg" style="padding-top:1%;"><!-- start main -->
	<div class="container">
		<div class="main row" style="padding:0px;">
			<div class="col-md-8 blog_left">
                <div id ="newsbody" runat="server">
                    <%--<h2>Lorem Ipsum is simply dummy text of the printingy</h2>
				    <img src="../images/messi.jpg" alt="" class="blog_img img-responsive" style="width:750px;height:500px;"/>
				    <div class="blog_list">
					      <ul class="list-unstyled">
						    <li><i class="fa fa-calendar-o"></i><span>June 3, 2013</span></li>
						    <li><a href="#"><i class="fa fa-comment"></i><span>Comments</span></a></li>
				  		    <li><a href="#"><i class="fa fa-user"></i><span>Admin</span></a></li>
				  		    <li><a href="#"><i class="fa fa-eye"></i><span>124 views</span></a></li>
					      </ul>
				    </div>
				    <p class="para">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing</p>--%>
                </div>
			</div>
            <div class="col-md-4 blog_right">
                <!-- start social_network_likes -->
                
                <div  class="owl-item" style="width: 266px;">
                    
                    <div class="item" id="author" runat="server">
                       
                        
                    </div>
                </div>

				<ul class="tag_nav list-unstyled" id="newstag" runat="server">
					<%--<h4>tags</h4>
						<li class="active"><a href="#">art</a></li>
						<li><a href="#">awesome</a></li>
						<li><a href="#">classic</a></li>
						<li><a href="#">photo</a></li>
						<li><a href="#">wordpress</a></li>
						<li><a href="#">videos</a></li>
						<li><a href="#">standard</a></li>
						<li><a href="#">gaming</a></li>
						<li><a href="#">photo</a></li>
						<li><a href="#">music</a></li>
						<li><a href="#">data</a></li>
						<div class="clearfix"></div>--%>
				</ul>
                <ul class="ads_nav list-unstyled" id="teacherAds" runat="server">
					<%--<h4>推荐教师</h4>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a></li>
					<div class="clearfix"></div>--%>
				</ul>
                <div class="social_network_likes" style="margin-top:25px;">
				      		 <ul class="list-unstyled">
				      		 	<li><a href="http://www.twitter.com" target="view_window" class="tweets"><div class="followers"><p><span>2k</span>Followers</p></div><div class="social_network"><i class="twitter-icon"> </i> </div></a></li>
				      			<li><a href="http://www.facebook.com" target="view_window" class="facebook-followers"><div class="followers"><p><span>5k</span>Followers</p></div><div class="social_network"><i class="facebook-icon"> </i> </div></a></li>
				      			<li><a href="http://www.gmail.com" target="view_window" class="email"><div class="followers"><p><span>7.5k</span>members</p></div><div class="social_network"><i class="email-icon"> </i></div> </a></li>
				      			<li><a href="http://www.linkedin.com" target="view_window" class="dribble"><div class="followers"><p><span>10k</span>Followers</p></div><div class="social_network"><i class="dribble-icon"> </i></div></a></li>
				      			
				    		</ul>
		          	</div>

			</div>
			<div class="clearfix"></div>
		</div>
	</div>
</div><!-- end main -->
<div class="footer_bg" id="footer" runat="server"><!-- start footer -->

</div>
 <div id="rightButton">
	<ul id="right_ul">
		<li id="right_qq" runat="server" class="right_ico" ><a id="A_ModifyInfo" runat="server" href="infoManagement.aspx" style="width:68px;height:77px;display:block"></a></li>

		<li id="right_tel" class="right_ico" ></li>
        <li id="right_tip" class="png">
		<p class="flagShow_p1 flag_tel">咨询电话</p>
		<p class="flagShow_p2 flag_tel line91" style="font-size:small">(+86) 15080901002</p>
        </li>
	</ul>
</div>

<div id="backToTop">
	<a href="javascript:;" onfocus="this.blur();" class="backToTop_a png"></a>
</div>

    </form>
</body>
    <%--浮动框的效果--%>
<script type="text/javascript" src="js/scrolltool.js"></script>
</html>
