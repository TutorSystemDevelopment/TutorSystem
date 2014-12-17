<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allTeachers.aspx.cs" Inherits="Web_allTeachers" %>

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
    <form id="Form1" runat="server"  >
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server">

        </div>
    </div>
    <div class="container" style="padding:0px;">
        <div class="alert alert-warning alert-dismissable" style="margin-bottom:0px;">
			  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
			  <strong>老师太少？</strong>团队初定7月10日进行第一轮家教面试，目前已有注册但未面试教师接近100余人，面试后这里将增添更多新面孔~
		</div>
    </div>
    <div class="container">
        <div class="half_parent">
                <h4 style="margin-left:10px;">所有分类 ></h4>
                    <asp:Label ID="lb_course" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lb_price" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lb_sex" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        <div class="half_parent">
            <asp:LinkButton ID="bt_serchname" CssClass="sort_btn" runat="server" OnClick="bt_serchname_Click">搜索<i class="fa fa-search"></i></asp:LinkButton>
            <input id="find_tutorname"  runat="server" type="text" style="float:right;width:50%;height:28px;margin-top:4px;" class="form-control"/>
        </div>
        <div class="clearfix"></div>
        <div class="all_parent" style="border:1px solid #e8e8e8;">
            <div class="all_parent sort_div">
                <div style="display:block;width:5%;float:left;color:#999">
                    <h5>性别:</h5>
                </div>
                <div style="display:block;width:95%;float:left;">
                    <ul id="find_sex" runat="server" class="sort_menu">
                     <li><a id="bt_sex0" runat="server" onserverclick="bt_sex_ServerClick">男</a></li>
                     <li><a id="bt_sex1" runat="server" onserverclick="bt_sex_ServerClick">女</a></li>
                    </ul>
                </div>
            </div>
            <div class="all_parent sort_div">
                <div style="display:block;width:5%;float:left;color:#999">
                    <h5>价格:</h5>
                </div>
                <div style="display:block;width:95%;float:left;">
                    <ul id="find_price" runat="server" class="sort_menu">
                     <li><a id="bt_pri1"  runat="server"   onserverclick="bt_pri_ServerClick">20~30</a></li>
                     <li><a id="bt_pri2"  runat="server"   onserverclick="bt_pri_ServerClick">30~40</a></li>
                     <li><a id="bt_pri3"  runat="server"   onserverclick="bt_pri_ServerClick">40~50</a></li>
                     <li><a id="bt_pri4"  runat="server"   onserverclick="bt_pri_ServerClick" class="last">50~200</a></li>
                    </ul>
                </div>
            </div>
            <div class="all_parent sort_div">
                <div style="display:block;width:5%;float:left;color:#999">
                    <h5>课程:</h5>
                </div>
                <div style="display:block;width:95%;float:left;">
                    <ul id="find_course" runat="server" class="sort_menu">
                     
                    </ul>
                </div>
            </div>
            
            <div class="all_parent" style="height:38px;">
                <asp:LinkButton ID="sort_accept" runat="server" OnClick="bt_sure_Click" CssClass="sort_btn">按条件筛选</asp:LinkButton>
                <asp:LinkButton ID="sort_clear" runat="server" OnClick="sort_clear_Click" CssClass="sort_btn">清空筛选条件</asp:LinkButton>
            </div>
        </div>
  </div>

   <%-- <div id="search" runat="server" class="tutorsearch  container" style="margin-top:10px; border:1px solid #d1cece; padding:0px;">
        <h4>所有分类 ></h4>
         <div  style="margin-top:2px; border-bottom:1px solid #d1cece"> 
            <div class="searchleft">
                <span  style="color:#52a0ea">性别：</span>
            </div>

            <div id="s_sex" runat="server">
             <a id="bt_sex0" runat="server"   onserverclick="bt_sex_ServerClick"  style="height:30px;margin-left:30px;">男</a>
             <button id="bt_sex1" runat="server"   onserverclick="bt_sex_ServerClick"  class="searchbutton" style="height:30px;margin-left:30px;">女</button>
             
            </div>
        </div>
            
        
        <div   style="margin-top:2px; border-bottom:1px solid #d1cece">

            <div id="left"  class="searchleft" >
                <span  style="color:#52a0ea">价格（左右）：</span>
                
            </div>

            <div  id="s_price" runat="server">
             
             <button id="bt_pri1"  runat="server"   onserverclick="bt_pri_ServerClick" class="searchbutton" style="height:30px;margin-left:30px;">50</button>
             <button id="bt_pri2" runat="server"   onserverclick="bt_pri_ServerClick" class="searchbutton" style="height:30px;margin-left:30px;">150</button>
             <button id="bt_pri3" runat="server"   onserverclick="bt_pri_ServerClick" class="searchbutton" style="height:30px;margin-left:30px;">250</button>
             <button id="bt_pri4" runat="server"   onserverclick="bt_pri_ServerClick" class="searchbutton" style="height:30px;margin-left:30px;">350</button>
               
             
            </div>
        </div>

        <div  style="margin-top:2px;" > 
            <div   class="searchleft">
                <span  style="color:#52a0ea">课程：</span>
                
            </div>

            <div  id="s_course" runat="server">
             
            </div>
        </div>
    </div>--%>    
    <%--<div class="tutorsearch  container">
        <%--<label id="lb_sex" runat="server"  ></label>
        <label id="lb_course" runat="server" ></label>
        <label id="lb_price" runat="server" ></label>--%>        <%--<asp:Label ID="lb_sex" runat="server" Text=""></asp:Label>--%>
        
        <%--<asp:Button ID="bt_sure" runat="server" Text="查询"  CssClass="right-align " OnClick="bt_sure_Click" />
    </div>--%>



    <div class="main_bg"><!-- start main -->
	<div class="container">
        <h2>教师列表</h2>
        <p>&nbsp;</p>
		<div id="tutornode" runat="server" class="technology row" style="padding-top:0px;">
			
           
            
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
       
       
			<div class="alert alert-warning alert-dismissable">
			  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
			  <strong>Warning!</strong> Better check yourself, you're not looking too good.
			</div>
	</div>
</div><!-- end main -->


        <%--<script>
            $(".searchbutton").click(function () { //主要的作用是改变颜色

              
                var id = $(this).attr("id");
                if (id.indexOf("bt_course") >= 0) {
                    ChangeState(this);
                    readGradeBT("bt_course", "lb_course");
                }
                else if (id.indexOf("bt_pri") >= 0)
                {
                    $("[id^=bt_pri]").each(function () {
                        if (id != $(this).attr("id")) {
                            if ($(this).attr("style").indexOf("background-color:#ff5454") >= 0) {
                                //alert("hha");
                                $(this).attr("style", "background-color:#333;height:30px;margin-left:30px; ");
                            }
                        }
                    });
                    ChangeStateforOne(this, "lb_price");
                    
                    
                }
                else if (id.indexOf("bt_sex") >= 0) {
                    
                    $("[id^=bt_sex]").each(function () {
                        
                        if (id != $(this).attr("id")) {
                            if ($(this).attr("style").indexOf("background-color:#ff5454") >= 0) {
                                //alert("hha");
                                $(this).attr("style", "background-color:#333;height:30px;margin-left:30px; ");
                            }
                        }
                    });
                    ChangeStateforOne(this,"lb_sex");
                   
                    
                }

                //readCourseBT();
            });

            function ChangeStateforOne(bt,lb) {
                // var temp = $(bt).hasClass("active");
                var re = "";
                var temp = $(bt).attr("style");
                if (temp.indexOf("background-color:#ff5454") >= 0) {
                    $(bt).attr("style", "background-color:#333;height:30px;margin-left:30px; ");
                }
                else {
                    $(bt).attr("style", "background-color:#ff5454;height:30px;margin-left:30px;");
                    re = $(bt).text()
                    }
                document.getElementById(lb).setAttribute("Text", re) ;
                alert(re);
            }


            function ChangeState(bt) {
               // var temp = $(bt).hasClass("active");
                var temp = $(bt).attr("style");
                if (temp.indexOf("background-color:#ff5454")>=0) {
                    $(bt).attr("style", "background-color:#333;height:30px;margin-left:30px; ");
                }
                else {
                    $(bt).attr("style", "background-color:#ff5454;height:30px;margin-left:30px;");
                }
            }


            function readGradeBT(idname,lb) {
                var temp = "";
                var pre = "[id^=" + idname + "]";
                //alert(pre);
                $(pre).each(function () {
                    if ($(this).attr("style").indexOf("background-color:#ff5454") >= 0) {
                        //alert("hha");
                        temp += $(this).text()+",";
                    }
                });
                document.getElementById(lb).innerText = temp;
                //alert(document.getElementById(lb).innerText);
            }




        </script>--%>
<div class="footer_bg" runat="server" id="footer"><!-- start footer -->
	
</div>
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
<%--浮动框的效果--%>
<script type="text/javascript" src="js/scrolltool.js"></script>
</html>

