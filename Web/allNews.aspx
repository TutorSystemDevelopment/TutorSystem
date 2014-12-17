<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allNews.aspx.cs" Inherits="Web_allNews" %>

<%@ Register Src="~/Web/head.ascx" TagPrefix="uc1" TagName="head" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="css/mystyle.css" rel="stylesheet" type="text/css" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!--picture slider-->
<link href="css/jquery.slideBox.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="js/jquery.slideBox.min.js" type="text/javascript"></script>
<script>
    jQuery(function ($) {
       
        $('#demo3').slideBox({
            duration: 0.3,//滚动持续时间，单位：秒
            easing: 'linear',//swing,linear//滚动特效
            delay: 5,//滚动延迟时间，单位：秒
            hideClickBar: false,//不自动隐藏点选按键
            clickBarRadius: 10
        });
      
    });
</script>
<!----font-Awesome----->
    <style>
        body {
            font-size:12px;
        }
    </style>
</head>
<body style="width:1366px;">
    <form id="form1" runat="server">
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server">

        </div>
    </div>

    <div class="container" id="all_news">
        <h2 style="margin-bottom:0px;margin-top:10px;color:black">极致新闻</h2>
        <div class="parent_block">
            <!--left news items-->
            <div class="col-md-8" style="padding-left:0px;">
                <div id="new_node" runat="server">
                 <div class="newsitem col-md-12" style="border-top:2px solid red;">
                    <div class="col-md-4"">
                        <img src="../images/default.jpg.jpg" style="width:100%;"/>
                    </div>
                    <div class="col-md-8">
                        <span style="font-size:20px;"><a href="http://douban.fm/">豆瓣电台</a></span>
                        <p>豆瓣电台牛逼哎</p>
                    </div>
                </div>
                    <div class="clearfix"></div>
                <div id="paginate" runat="server" class="all_parent paginate_div">
                    <br />
                        <a id="a_pre" class="prenext" href="#" runat="server" onserverclick="a_front_ServerClick"><-上一页</a>
                        <a id="a_1" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">1</a>
                        <a id="a_2" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a>
                        <a id="a_3" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a>
                        <a id="a_4" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a>
                        <a id="a_5" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a>
                        <a id="a_6" runat="server">....</a>
                        <a id="a_next" class="prenext" href="#" runat="server" onserverclick="a_last_ServerClick">下一页-></a>
                        <label>共有</label>
                        <label id="allpage" runat="server"></label>
                        <label>页</label>
                        <label id="nowpageindex" runat="server" style="display: none">1</label>
                        <label>第</label><label id="nowpagenum" runat="server">1</label><label>页</label>
                </div>
            </div>
            </div>
            <!--right news items-->
            <div class="col-md-4" style="float:right">
                <div class="newspiece">
                    <h3>图片新闻</h3>
                    <div id="demo3" class="all_parent slideBox" style="padding-right:0px;">
                      <ul id="new_roll" class="items" runat="server">
                        <li><a href="http://www.jq22.com/" title="这里是测试标题一"><img src="../images/default.jpg.jpg" style="width:100%"/></a></li>
                        <li><a href="http://www.jq22.com/" title="这里是测试标题二"><img src="../images/default.jpg.jpg" style="width:100%"/></a></li>
                        <li><a href="http://www.jq22.com/" title="这里是测试标题三"><img src="../images/default.jpg.jpg" style="width:100%"/></a></li>
                        <li><a href="http://www.jq22.com/" title="这里是测试标题四"><img src="../images/default.jpg.jpg" style="width:100%"/></a></li>
                        <li><a href="http://www.jq22.com/" title="这里是测试标题五"><img src="../images/default.jpg.jpg" style="width:100%"/></a></li>
                      </ul>
                    </div>
                </div>
                <div class="newspiece">
                    <h3>Top新闻</h3>
                    <div id="new_top" runat="server" >

                    <div id="Div1"  runat="server" class="topnewsitem">
                        <span style="height:20px;width:20px;background-color:red;display:inline-block;text-align:center">1</span>

                        <a href="http://www.ifeng.com/">应届生高考志愿填报指南</a>
           
                        <br />
                    </div>
                    
                    </div>
                </div>
                <div class="newspiece">
                    <h3>教师推荐</h3>
                    <ul class="ads_nav list-unstyled" id="teacherAds" runat="server">
					    
						<li><a href="#" ><img src="../images/messi.jpg" class="teacherAds"/> </a><a href="#"><h4 style="text-align:center;margin:0px;">梅西</h4></a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a><a href="#"><h4 style="text-align:center;margin:0px;">梅西</h4></a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a><a href="#"><h4 style="text-align:center;margin:0px;">梅西</h4></a></li>
						<li><a href="#"><img src="../images/messi.jpg" class="teacherAds"/> </a><a href="#"><h4 style="text-align:center;margin:0px;">梅西</h4></a></li>
					    
				    </ul>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
            
        <div class="clearfix"></div>
    </div>
    
    <div class="footer_bg" runat="server" id="footer"><!-- start footer -->
	      
    </div>

   <div id="rightButton">
	<ul id="right_ul">
		<li id="right_qq"  class="right_ico" ><a id="A_ModifyInfo" runat="server" href="infoManagement.aspx" style="width:68px;height:77px;display:block"></a></li>
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
