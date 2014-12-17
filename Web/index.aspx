<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Web_index"  MaintainScrollPositionOnPostback="true"  %>

<%@ Register Src="~/Web/head.ascx" TagPrefix="uc1" TagName="head" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="icon" href="../images/icon.ico"/>
<title>极致141</title>
<!-- Bootstrap -->
<link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />  
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<meta name="viewport" content="width=device-width, initial-scale=1"/>
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
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<!-- start slider -->
<link href="css/slider.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="js/modernizr.custom.28468.js"></script>
<script type="text/javascript" src="js/jquery.cslider.js"></script>
	<script type="text/javascript">
	    $(function () {
	        $('#da-slider').cslider({
	            autoplay: true,
	            bgincrement: 450
	        });
	    });
		</script>
<!-- Owl Carousel Assets -->
<link href="css/owl.carousel.css" rel="stylesheet"/>
<script src="js/owl.carousel.js"></script>
		<script>
		    $(document).ready(function () {

		        $("#owl_demo").owlCarousel({
		            items: 4,
		            lazyLoad: true,
		            autoPlay: true,
		            navigation: true,
		            navigationText: ["", ""],
		            rewindNav: false,
		            scrollPerPage: false,
		            pagination: false,
		            paginationNumbers: false,
		        });

		    });
		</script>
		<!-- //Owl Carousel Assets -->
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
<style type="text/css">
        #info {
            height: 887px;
        }
</style>
<%--浮动框的样式--%>

 
</head>
<body>
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>

    <div id="maininfo" >
        <div class="main_bg">
            <div class="container">
                <div id="newtop" class="row" runat="server">
                </div>
            </div>
        </div>
        <div>
            <!-- start main_btm -->
        <div id="tutor_re">
            <iframe id="info" src="IndexPart2.aspx" frameborder="no" scrolling="auto" width="100%" allowtransparency="true" ></iframe>
        </div>
        </div>
        <!----//End-img-cursual---->
        <div class="main_bg">
            <!-- start main -->
            <div class="container" style="padding: 0px; padding-top: 3px;">
                <h3 style="background-color: #f0f0f0; text-align: center; margin: 0px; border-bottom: 3px solid; border-bottom-color: #f00">选择极致的理由<br />
                    Reasons for choosing us</h3>
                <div class="main row">
                    <div class="col-md-3 images_1_of_4 text-center">
                        <span class="bg"><i class="fa fa-group"></i></span>
                        <h4><a>凝聚的团队</a></h4>
                        <p class="para">我们拥有最优秀的团队，团队成员来自不同的大学，却有着极强的凝聚力和相同的目标：为洞口打造一个便捷，可靠的家庭教育平台，让洞口学子能享受到最佳的教育资源</p>
                    </div>
                    <div class="col-md-3 images_1_of_4 bg1 text-center">
                        <span class="bg"><i class="fa fa-globe"></i></span>
                        <h4><a>先进的理念</a></h4>
                        <p class="para">在这里，一切都走上正轨，我们用企业化的理念管理我们的团队，无论是网站还是微信平台，都是为了广大学子和家长的用户体验，Online才是互联网时代的最先进的理念</p>
                    </div>
                    <div class="col-md-3 images_1_of_4 bg1 text-center">
                        <span class="bg"><i class="fa fa-book"></i></span>
                        <h4><a>优秀的师资</a></h4>
                        <p class="para">所有的教师都会经过我们的岗前培训，由家教经验丰富的优秀教师主讲，同时我们还有专业的心理咨询师为教师分析授课问题，每个有志学子都可以从极致迈出工作的第一步</p>
                    </div>
                    <div class="col-md-3 images_1_of_4 bg1 text-center">
                        <span class="bg"><i class="fa fa-cogs"></i></span>
                        <h4><a>无缝的接合</a></h4>
                        <p class="para">团队的线上平台和线下服务近乎无缝接合，实体信息与线上数据库完全同步，用户完全无需担心时效性。家教信息我们均有审核流程，真正做到所见即所得</p>
                    </div>
                </div>
            </div>
        </div>
     </div> <!-- end main -->
    
    <div class="footer_bg" runat="server" id="footer"><!-- start footer -->
	
</div>
    

    <%--浮动框的效果--%>
  <div id="rightButton">
	<ul id="right_ul">
		<li id="right_qq"   class="right_ico" ><a id="A_ModifyInfo" runat="server"  href="infoManagement.aspx" style="width:68px;height:77px;display:block"></a></li>
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
</body>
<script>
    $("#reserved").click(function () {
        //document.getElementById("tag1").style.background = "#ff5454";
        //background: #ff5454;color: #ffffff;text-decoration:none;
        //$("#tag1").addClass("test");
        alert("该功能暂未开放，尽请期待");
    });
</script>


 <%--浮动框的效果--%>
<script type="text/javascript" src="js/scrolltool.js"></script>
</html>
