<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aboutUs.aspx.cs" Inherits="Web_aboutUs" %>

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
        <uc1:head runat="server" ID="head" />
        <div id="navbar" runat="server">

        </div>
    </div>
    <div class="main_bg"><!-- start main -->
	<div class="container">
		<div class="technology row" style="padding-top:0px;">
            <div class="alert alert-warning alert-dismissable">
			  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
			  <strong>加入我们：</strong>离开电脑，与我们一起追逐梦想！
			</div>
			<h2 style="margin-bottom:45px;">团队简介</h2>
			<div class="technology_list">
				<h4 style="color:red">网络技术部</h4>
				<div class="col-md-10 tech_para">
					<p class="para">网络技术部主要负责团队网络平台的搭建，比如微信公共平台和您正在使用的141网站，都是网技人在无数个黑暗的夜晚对着寂寞的电脑显示器一行行代码撸出来的。有时候在您看来一个简单的功能，却需要我们花几个小时或是整天整夜才能实现。为了保证用户的体验，我们不惜牺牲我们的身体健康，但我们从来不会再公众面前说一句话，因为我们天生如此，愿意站在背后低调地默默奉献，用我们的技术感动每一位用户。我们虽然站在背后，但我们却始终为用户着想，在未来网技人会不断完善团队的网络平台，致力于带给用户最舒适的使用感受。网技人永远在路上。</p>
				</div>
				<div class="col-md-2 images_1_of_4 bg1 pull-right">
					<span class="bg"><i class="fa fa-laptop"></i> </span>
				</div>
				<div class="clearfix"></div>
				<div class="read_more">
					<a href="departmentDetails.aspx?departmentId=4" class="fa-btn btn-1 btn-1e">部门详情</a>
				</div>	
			</div>
			<div class="technology_list1">
				<h4 style="color:red">市场执行部</h4>
				<div class="col-md-10 tech_para">
					<p class="para">执行监督部门主要负责团队和公司总体运营把握；团队战略目标和方针的制定；团队的定位；进一步把握发展情况、形成团队核心竞争力；进行具体工作的执行和监督。如：教师面试资料审查、客户教师群体矛盾调和、市场推广监督，各单位以及对外代表等具体监督等工作。</p>
				</div>
				<div class="col-md-2 images_1_of_4 bg1">
					<span class="bg"><i class="fa fa-legal"></i> </span>
				</div>
				<div class="clearfix"></div>
				<div class="read_more">
					<a href="departmentDetails.aspx?departmentId=5" class="fa-btn btn-1 btn-1e">部门详情</a>
				</div>	
			</div>
			<div class="technology_list1">
				<h4 style="color:red">人力资源部</h4>
				<div class="col-md-10 tech_para">
					<p class="para">人力资源部职能方向有两方面，对外进行教师以及各部门临时志愿者的招募、面试，培训等，以及负责客户的订购与投诉服务。对内则主责内部的联络、交流，协调等工作。</p>
				</div>
				<div class="col-md-2 images_1_of_4 bg1">
					<span class="bg"><i class="fa fa-group"></i></span>
				</div>
				<div class="clearfix"></div>
				<div class="read_more">
					<a href="departmentDetails.aspx?departmentId=2" class="fa-btn btn-1 btn-1e">部门详情</a>
				</div>	
			</div>
			<div class="technology_list1">
				<h4 style="color:red">财务部门</h4>
				<div class="col-md-10 tech_para">
					<p class="para">公司财务支出与收入账务明细，按照要求向执行监督部门报账，各项支出收入账目上报。各老师的酬劳和薪水的提成，学生费用的收取。各部门招新后，工作志愿者的工资支出领取。按劳分配，各董事工资和红利分配工作。</p>
				</div>
				<div class="col-md-2 images_1_of_4 bg1">
					<span class="bg"><i class="fa fa-money"></i> </span>
				</div>
				<div class="clearfix"></div>
				<div class="read_more">
					<a href="departmentDetails.aspx?departmentId=1" class="fa-btn btn-1 btn-1e">部门详情</a>
				</div>	
			</div>
            <div class="technology_list1">
				<h4 style="color:red">宣传推广部</h4>
				<div class="col-md-10 tech_para">
					<p class="para">市场推广部主要负责团队推广，教师及管理层包装，业务拓展，市场开拓；其中分为线上和线下两部分。线上主要包括极致141网站推广栏中团队成员和教师的包装宣传，微信平台（微信号：supreme141）和微博平台（昵称：oneforone微博）推送的团队成员介绍和老师推荐文章以及团队最新动态。线下主要包括在电视，报纸，海报，传单，名片上对团队的包装和推广。我们部门一直致力于让不知道我们的人知道我们，让知道我们的人更加了解我们。在未来，我们会探索更多的方向，用最炽热的心最真诚的方式把我们的理念和服务传达给每一位用户。</p>
				</div>
				<div class="col-md-2 images_1_of_4 bg1">
					<span class="bg"><i class="fa fa-rss"></i> </span>
				</div>
				<div class="clearfix"></div>
				<div class="read_more">
					<a href="departmentDetails.aspx?departmentId=3" class="fa-btn btn-1 btn-1e">部门详情</a>
				</div>	
			</div>
		</div>
	</div>
</div><!-- end main -->

<div class="footer_bg" id="footer" runat="server"><!-- start footer -->
</div>

        <%--浮动框的效果--%>
 <div id="rightButton">
	<ul id="right_ul">
		<li id="right_qq" r class="right_ico" ><a  id="A_ModifyInfo" runat="server" href="infoManagement.aspx" style="width:68px;height:77px;display:block"></a></li>
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
