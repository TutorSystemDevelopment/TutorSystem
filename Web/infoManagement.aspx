<%@ Page Language="C#" AutoEventWireup="true" CodeFile="infoManagement.aspx.cs" Inherits="Web_infoManagement" %>

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
<!----font-Awesome----->
<!--left navigation-->
<script src="js/tendina.js"></script>
<link rel="stylesheet" href="css/jquery.leftnavi.css"/>
    <script>
      
        $(document).ready(function () {
         
            var tutorid = "1";
            var commenturl = "Comment.aspx?tutorid=" + tutorid;
          
            var frame = "<iframe name=\"right\" id=\"rightMain\" src=\"" + commenturl + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1200px\" allowtransparency=\"true\"/>";
          
            $("#li_comment").click(function () {
              
                  $("#main").html(frame);
              
            })
            var resframe = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "TutorOrder.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";

            $("#li_res").click(function () {
                $("#main").html(resframe);
            })

            var notiframe = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "Timeline.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";

            $("#li_timeline").click(function () {
                $("#main").html(notiframe);
            })

            var baicinfo = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "basicInfo.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_basicinfo").click(function () {
                $("#main").html(baicinfo);
            })
            var pubarticle = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "articlePub.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_pubarticle").click(function () {
                $("#main").html(baicinfo);
            })

            var select = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "SelectClass.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1000px\" allowtransparency=\"true\"/>";
            $("#li_selectclass").click(function () {
                $("#main").html(select);
            })

            var modify = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "Chatlist.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1000px\" allowtransparency=\"true\"/>";
            $("#li_notification").click(function () {
                $("#main").html(modify);
            })

            var infoedit = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "tutorDetailEdit.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1000px\" allowtransparency=\"true\"/>";
            $("#li_infoedit").click(function () {
                $("#main").html(infoedit);
            })

            var articlePub = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "articlePub.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_pubarticle").click(function () {
                $("#main").html(articlePub);
            })

            var readArticle = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "readArticle.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_readarticle").click(function () {
                $("#main").html(readArticle);
            })

            var psdmodefy = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "Psdmodify.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"600px\" allowtransparency=\"true\"/>";
            $("#li_modefypsd").click(function () {
                $("#main").html(psdmodefy);
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>
    <div class="container" style="padding-left:0px;padding-right:0px;" >

        <div id="menu_left">
        <div class="col-md-3" style="margin-top:10px;padding:0px;height:1250px;">
            <ul class="dropdown" style="padding-top:5px;">
                <h3 style="color:red;margin-top:0px;margin-bottom:5px;border-bottom:2px solid red;padding-bottom:5px;">个人中心</h3>
              <li>
                <a id="li_notification" href ="#">通知中心</a>
               
              </li>
              <li>
                <a href="#">信息修改</a>
                <ul>
                  <li><a id="li_timeline" href="#">简历时间轴</a></li>
                  <li><a id="li_basicinfo" href="#">基本信息</a></li>
                  <li><a id="li_selectclass" href="#">授课课程</a></li>
                  <li><a id="li_infoedit" href="#">详细信息修改</a></li>
                  <li><a id="li_modefypsd" href="#">修改密码</a></li>
                </ul>
              </li>
              <li>
                <a href="#">我的文章</a>
                  <ul>
                      <li><a id="li_readarticle"  href="#">查看文章</a></li>
                      <li><a id="li_pubarticle" href="#">发布文章</a></li>
                  </ul>
              </li>
              <li>
                <a href="#">家教授课</a>
                <ul>
                  <li><a id="li_comment" href="#" >学生评论</a></li>
                  <li><a id="li_res" href="#" >授课预约</a></li>
                </ul>
              </li>
            </ul>
        </div>
        </div>
        
        <div id="main"  class="col-md-9" style="margin-top:10px;padding-left:0px;padding-bottom:10px;padding-right:0px;" >

        </div>

    </div>
       
    <div id="footer" runat="server" class="footer_bg">

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
<script>
    $('.dropdown').tendina({
        animate: true,
        speed: 500,
        openCallback: function ($clickedEl) {
            console.log($clickedEl);
        },
        closeCallback: function ($clickedEl) {
            console.log($clickedEl);
        }
    })
</script>

</html>
