<%@ Page Language="C#" AutoEventWireup="true" CodeFile="departmentDetails.aspx.cs" Inherits="Web_departmentDetails" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>
	<div class="container">
			<h2 style="text-transform:uppercase" class="red_span" runat="server" id="departmentName">部员简介</h2>
    </div><!-- end main -->
    <div id="body" runat="server">
        
    </div>

    <div class="footer_bg" id="footer" runat="server"><!-- start footer -->

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
    </form>
</body>
    <script type="text/javascript" src="js/scrolltool.js"></script>
</html>
