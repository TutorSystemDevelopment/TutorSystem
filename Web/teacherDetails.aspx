<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacherDetails.aspx.cs" Inherits="Web_teacherDetails" %>

<%@ Register Src="~/Web/head.ascx" TagPrefix="uc1" TagName="head" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
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
<link href="css/timestyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>
        <label id="tuid" runat="server" style="display:none" ></label>
        <div class="container" style="padding-top:15px;">
            <div class="container">
            <div class="main row" style="padding-top:0px;padding-bottom:0px;">
                <div class="col-md-6 content_left" style="padding-left:0px;">
                    <img id="info_img" runat="server" src="../images/pic1.jpg" alt="" class="img-responsive" />
                    <div class="blog_list">
                        <br />
                        <ul class="list-unstyled">
                            <li ><i class="fa fa-tag"></i><span runat="server" id="li_rank">金牌教师</span></li>
                            <li><i class="fa fa-building"></i><span runat="server" id="li_Uni">Harvard Uni</span></li>
                            <li><i class="fa fa-user"></i><span runat="server" id="li_sex">Harvard Uni</span></li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-6 content_right">
                        <h3 id="info_name" class="redtitile" style="margin-top:0px;" runat="server">曾宇锟</h3>
                    <textarea class="textarea_para" readonly="readonly" runat="server" id="info_intro" style="width:550px;"></textarea>
                    <%--<p id="info_intro" runat="server" class="introduction">
                        "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words. "
                    </p>--%>
                    <label class="normaltitle">Grade</label>
                    <div id="info_Grade" runat="server" class="selectdiv" >
                    </div>
                    <label class="normaltitle">Course</label>
                    <div  id="info_course" runat="server" class="selectdiv" >
                    </div>
                    <br />
                       <label id="selectcourse" runat="server" style="display:none">""</label>
                       <label id="selectgrade" runat="server" style="display:none">""</label>
                </div>
            </div>
            </div>

            <form id="Form1" runat="server" >
            
                    <div style="text-align:right">
                       <button id="info_reser" class="auto-btn btn-1 btn-1e" runat="server"  onserverclick="info_reser_ServerClick">预订此教师</button>
                        <%--< id="info_reser"  class="auto-btn btn-1 btn-1e" >Reservation</asp:Button>--%>
                        <span style="padding-left:280px;"></span>
                        <button class="auto-btn btn-1 btn-1e" id="return_btn" runat="server"  onserverclick="return_Click">查看其他教师</button>
                   </div>

                <input type="hidden"  runat="server"  id="hidcourse" />
                <input type="hidden"  runat="server"  id="hidgrade" />
                <input type="hidden"  runat="server"  id="hidtutorname" />
                <input type="hidden"  runat="server"  id="hidmail" />
             <div id="timeline" class="content">
                    <div class="wrapper">
                        <div class="light"><i></i></div>
                        <hr class="line-left" />
                        <hr class="line-right" />
                        <div class="main">
                            <h1 class="title">时间轴</h1>
                            <div id="timeline_year"  runat="server" >
                               
                            </div>
                           </div>
                         </div>
                 </div>
             <div class="main_btm">
                <div id="recommend" class="about row" style="padding-top:10px;" runat="server">
			         
			        <%--<p class="para">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words. </p>--%>
		        </div>
            </div>

             <%--<div class="main_btm">

             </div>--%>
            <%--<form runat="server">--%>
           
            <div id="Alldetail"  >

                <div id="tab_bt">
                <ul class="tabpanel">
                    <li class="singletab"><a  id="bt_selfintro" href="#tab_bt" class="tablink">个人简介</a></li>
                    <li class="singletab"><a id="bt_comment" href="#allpage" class="tablink">学生评论</a></li>
                    <li class="singletab"><a id="bt_statistics" href="#tab_bt" class="tablink">统计</a></li>
                </ul>
                </div>

               <div id="all_resume" runat="server">
                <div class="main_btm">
                    <div class="about row" style="padding-top:10px;">
                        <label class="redtitile">个人简介</label>
                        <p id="info_resume" runat="server" class="para">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.<br />
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words. </p>
                        <%--<p class="para">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words. </p>--%>
                    </div>
                </div>
              </div>

              <div id="all_comment" runat="server"> 

              </div>

               <div id="all_statistic" runat="server">
               </div>
                  






                <div id="all_stucommend" runat="server">

                </div>

                <div id="all_statistics" runat="server">
                    
                </div>
            </div>

                <div id="light" class="white_content" runat="server">
                    <div class="all_parent">
                        <h3>预约确认</h3>
                        <span id="sure_gade" runat="server">所选年级：小学</span><br />
                        <span id="sure_course" runat="server">所选科目：数学</span><br />
                        <span id="sure_tutor" runat="server">任课教师：</span><br />
                        <div class="col-md-6" style="padding-left: 0px;">
                            <input id="sure_btsure" type="button" style="float: left;" class="generalbtn" value="确定" runat="server" onserverclick="sure_btsure_ServerClick" />
                        </div>
                        <div class="col-md-6">
                            <input id="sure_btcancel" runat="server" type="button" style="float: right" class="generalbtn" value="取消" onserverclick="sure_btcancel_ServerClick" />
                        </div>
                    </div>
                </div>
                <div id="fade" class="black_overlay" runat="server"></div>
                   </form>
         <%--</form>--%>
            </div> 

   <%-- //class="white_content"--%>
       <%--  <div id="light"  runat="server">
                    <div class="col-md-3">
                        <h3>预约确认</h3>
                        <span id="sure_gade" runat="server">所选年级：小学</span><br />
                        <span id="sure_course" runat="server">所选科目：数学</span><br />
                        <span id="sure_tutor" runat="server">任课教师：</span><br />
                        <div class="col-md-6" style="padding-left: 0px;">
                            <input id="sure_btsure" type="button" style="float: left;" class="generalbtn" value="确定" runat="server" onserverclick="sure_btsure_ServerClick" />
                        </div>
                        <div class="col-md-6">
                            <input id="sure_btcancel" runat="server" type="button" style="float: right" class="generalbtn" value="取消" onserverclick="sure_btcancel_ServerClick" />
                        </div>
                    </div>
                </div>
                <div id="fade" class="black_overlay" runat="server"></div>--%>
       

  
   
            
        
        <div class="footer_bg" id="footer" runat="server"><!-- start footer -->

        </div>


    <script>
            //$("#info_reser").click(function(){
            //    alert("预约功能将在7月10日面试结束后开放，尽请期待！");
            //});
            $("#tag1").click(function () {
                $("#tag1").addClass("active");
                //document.getElementById("tag1").style.background = "#ff5454";
                //background: #ff5454;color: #ffffff;text-decoration:none;
                //$("#tag1").addClass("test");
               // alert("123s");
            });
            $("#primary").click(function () {
                $(this).addClass("active");
            })

            $("[id^=gra_bt]").click(function () { //主要的作用是改变颜色
                //alert("haha");
                var temp = $(this).hasClass("active");
                //var temp = $(this);
                //alert(temp);
                //[id^=gra_bt]
                if (temp) {
                    $(this).addClass("inactive");
                    $(this).removeClass("active");
                   // $("#selectgrade").text = "haha";
                    //alert($("#selectgrade").text);
                    //var temp = document.getElementById("");
                }
                else {
                    $(this).addClass("active");
                    $(this).removeClass("inactive");
                    
                }
                readGradeBT();
                //$(this).addClass("active");
                // $("#selectgrade").text = "";
                
            });

            function readGradeBT()
            {
                var temp = "";
                document.getElementById("hidgrade").value = temp;
                $("[id^=gra_bt]").each(function () {
                    if ($(this).hasClass("active"))
                        temp = $(this).text();
                });
                document.getElementById("selectgrade").innerText = temp;
                document.getElementById("hidgrade").value = temp;
            }

            function readCourseBT() {
                var temp = "";
                document.getElementById("hidcourse").value = temp;
                $("[id^=course_bt]").each(function () {
                    if ($(this).hasClass("active"))
                        temp += $(this).text()+",";
                });
                document.getElementById("selectcourse").innerText = temp;
                document.getElementById("hidcourse").value = temp;

            }

            $("[id^=course_bt]").click(function () { //主要的作用是改变颜色
                //alert("haha");
                var temp = $(this).hasClass("active");
                //var temp = $(this);
                //alert(temp);
                //[id^=gra_bt]
                if (temp) {
                    $(this).addClass("inactive");
                    $(this).removeClass("active");
                    // $("#selectgrade").text = "haha";
                    //alert($("#selectgrade").text);
                    //var temp = document.getElementById("");
                }
                else {
                    $(this).addClass("active");
                    $(this).removeClass("inactive");
                   
                }
                readCourseBT();
                //$(this).addClass("active");
                // $("#selectgrade").text = "";

            });


        </script>

    
    <script>
    $(".main .year .list").each(function (e, target) {
        var $target = $(target),
	        $ul = $target.find("ul");
        $target.height($ul.outerHeight()), $ul.css("position", "absolute");
    });
    $(".main .year>h2>a").click(function (e) {
        e.preventDefault();
        $(this).parents(".year").toggleClass("tclose");
    });
	</script>


    <script>
        $(document).ready(function () {
            var txt = $("#tuid").text();
            
            var url = "Comment.aspx?ID=" + txt;
            //alert(url);
            //$("#all_stucommend").load("Comment.aspx?tutorid=" + txt);
            $("#all_stucommend").html("<iframe name=\"right\" id=\"rightMain\" src=\"" + url + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1200px\" allowtransparency=\"true\"/>")
            $("#all_stucommend").hide();

            $("#bt_comment").click(function () {
                $("#all_resume").hide();
                $("#all_stucommend").show();
                $("#bt_comment").attr("style", "color:#f40;");
                $("#bt_selfintro").removeAttr("style");
            });

            $("#bt_selfintro").click(function () {
                $("#all_resume").show();
                $("#all_stucommend").hide();
               
                $("#bt_selfintro").attr("style", "color:#f40;");
                //$("#bt_comment").attr("style", "");
                $("#bt_comment").removeAttr("style");
            });

        })


    </script>
        
 <div id="rightButton">
	<ul id="right_ul">
		<li id="right_qq" class="right_ico" ><a id="A_ModifyInfo" runat="server" href="infoManagement.aspx" style="width:68px;height:77px;display:block"></a></li>
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
    <%--浮动框的效果--%>
<script type="text/javascript" src="js/scrolltool.js"></script>
</html>
