<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexPart2.aspx.cs" Inherits="Web_IndexPart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />  
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
 <!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>

    <link href="css/owl.carousel.css" rel="stylesheet"/>
<script src="js/owl.carousel.js"></script>
		<script>
		    $(document).ready(function () {

		        $("#owl_demo").owlCarousel({
		            items: 4,
		            lazyLoad: true,
		            autoPlay: 2000,
		            navigation: true,
                    navigationText:false,
		            rewindNav: true,
		            scrollPerPage: false,
		            pagination: false,
		            paginationNumbers: false,
		        });

		    });
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
            <div class="container" style="padding: 0px;">
                <!----start-img-cursual---->
             <h3 style="background-color: #f0f0f0; color: #474747; text-align: center; margin: 0px; border-bottom: 3px solid; border-bottom-color: #f00">教师推荐<br />
                    Teacher Recommend</h3>


              <a id="tutorinfo"></a>  

                
                <div id="owl_demo" class="owl-carousel text-center" runat="server">
                    <%--<div class="item"><div class="cau_left"><img class="lazyOwl" src="../images/test.jpg" alt="Lazy Owl Image"></div><div class="cau_left"><h4><a href="index.aspx?toptutor=10&amp;tagname=tutorinfo">曹梦</a></h4><p>厦门大学<br>擅长科目：语文,数学,英语,物理</p></div></div>--%>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>--%>
                    
                </div>
                

                <div class="main row" style="padding: 0%;">
                    <div class="col-md-6 content_left">
                        <img id="info_pic" src="../images/zhouhong.jpg" alt="" class="img-responsive" runat="server" style="height:409px;width:585px;"/>
                    </div>
                    <div class="col-md-6 content_right" style="position: relative;">
                        <h4 id="info_title" style="margin-top: 0px; margin-bottom: 2%;" runat="server"></h4>
                        <p id="info_intro" class="para" runat="server">周鸿(Red chou )（1976年1月27日－），中国实验物理学家。祖籍湖南省邵阳市黄桥镇，华裔美国人，现任美国麻省理工学院教授，曾获得1976年诺贝尔物理学奖。他曾发现一种新的基本粒子，并以物理文献中习惯用来表示电磁流的拉丁字母“J”将那种新粒子命名为“J粒子”。询委员会主席。世界著名科学家，空气动力学家，中国载人航天奠基人，中国科学院及中国工程院院士，中国两弹一星功勋奖章获得者，被誉为“中国航天之父”“中国导弹之父”“中国自动化控制之父”和“火箭之王”，由于钱学森回国效力，中国导弹、原子弹的发射向前推进了至少20年。</p>
                        <a id="info_readmore"  href="#" class="fa-btn btn-1 btn-1e right-align" style="position: absolute; top: 350px; left: 400px;" >readmore</a>
                        <label id="lb_tutorid" runat="server" style="display:none"></label>
                    </div>
                </div>
            </div>


    </div>
    </form>
    <script>
        $("#info_readmore").click(function () {
            var url = document.getElementById("lb_tutorid").innerText;
           // alert(url);
            top.location.href = url;
        })
    </script>
</body>
</html>
