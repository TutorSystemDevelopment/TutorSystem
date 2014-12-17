<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Web_Comment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="css/mystyle.css" rel="stylesheet" type="text/css" />
<%--<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>--%>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<%--<script type="text/javascript" src="js/bootstrap.js"></script>--%>
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
<!--left navigation-->
<script src="js/tendina.js"></script>
<link rel="stylesheet" href="css/jquery.leftnavi.css"/>
</head>
<body>
    <form id="form1" runat="server">
     <div id="main" class="col-md-12" style="margin-top:10px;padding-left:0px;padding-bottom:10px;padding-right:0px;" >
            <div style="border:1px solid lightgrey;background:#f6f6f6">
                <h4 style="padding-left:43px;margin-top:15px;margin-bottom:15px;">教师教学评价：<span id="avestar" runat="server" style="color:red" >4.7</span>星<span id="comnum"  runat="server" style="font-size:12px;color:lightgrey"> 共40次打分</span></h4>
            </div>

            <div id="comment" runat="server">

               <div class="col-md-12" style="padding-top:10px;padding-bottom:10px;border-bottom:1px solid lightgrey;">
                <div class="col-md-2" style="padding-left:0px;text-align:center;float:left">
                    <img src="../images/logo.jpg" style="width:50%"/><br />
                    <span>曾宇锟</span>
                </div>
                <div class="col-md-10">
                    <h4 style="margin:0px;color:red;margin-bottom:5px;">教学评价：<img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/></h4>
                    <p style="color:grey;">这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错</p>
                    <h6>2014年06月12日 09:48 颜色分类:大红色  鞋码:39</h6>
                    </div>
            </div>
               <div class="col-md-12" style="padding-top:10px;padding-bottom:10px;border-bottom:1px solid lightgrey;">
                <div class="col-md-2" style="padding-left:0px;text-align:center;float:left">
                    <img src="../images/logo.jpg" style="width:50%"/><br />
                    <span>曾宇锟</span>
                </div>
                <div class="col-md-10">
                    <h4 style="margin:0px;color:red;margin-bottom:5px;">教学评价：<img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/><img src="../images/star-off.png"/></h4>
                    <p style="color:grey;">这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错这个老师真的很不错</p>
                    <h6>2014年06月12日 09:48 颜色分类:大红色  鞋码:39</h6>
                    </div>
            </div>

            </div>


              
            
          <div id="paginate" runat="server" class="container">
                    <br />
                    <br />
                    <div class="col-md-12">
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
    </form>
</body>
</html>
