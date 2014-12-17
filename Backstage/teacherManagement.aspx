<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacherManagement.aspx.cs" Inherits="Web_teacherManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="../Web/css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="../Web/css/mystyle.css" rel="stylesheet" type="text/css" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="../Web/css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="../Web/js/jquery.min.js"></script>
<script type="text/javascript" src="../Web/js/bootstrap.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="../Web/fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
</head>
<body>
    <form id="Form1" runat="server"  >
        
    <div id="head" runat="server">

    </div>
      <div class="container">
        <div id="tab_bt">
                <ul class="tabpanel">
                    <li class="singletab"><a  id="abt_all"  runat="server" onserverclick="bt_all_Click" href="#tab_bt" class="tablink"><span>全部预约</span></a></li>
                    <li class="singletab"><a id="abt_pass" runat="server" onserverclick="bt_pass_Click" href="#allpage" class="tablink"><span>审核通过</span></a></li>
                    <li class="singletab"><a id="abt_notpass" runat="server" onserverclick="bt_notpass_Click" href="#tab_bt" class="tablink"><span>正在审核</span></a></li>
                    <li class="singletab"><a id="abt_recommand" runat="server" onserverclick="bt_recommand_Click" href="#tab_bt" class="tablink"><span>推荐教师</span></a></li>
                    <li class="singletab"><a id="abt_index" runat="server" onserverclick="bt_index_Click" href="#tab_bt" class="tablink"><span>首页教师</span></a></li>
                </ul>
        </div>
        <label id="flag" runat="server" style="display:none" >0</label>
      </div>
    <div class="main_bg"><!-- start main -->
	<div class="container">
        <h2>教师列表</h2>
        <p>&nbsp;</p>

        <div style="border:1px;border-color:lightgrey;">
            
        </div>
		<div id="tutornode" runat="server" class="technology row" style="padding-top:0px;">
			
             
           
            
		</div>
        
       <%-- <ul id="pagenum" runat="server" class="pagination">
			  <li><a id="a_front" href="#" runat="server" onserverclick="a_front_ServerClick">&laquo;</a></li>
			  <li><a id="a_1" href="#" runat="server" onserverclick="Unnamed_ServerClick" >1</a></li>
			  <li><a id="a_2" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a></li>
			  <li><a id="a_3" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a></li>
			  <li><a id="a_4" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a></li>
			  <li><a id="a_5" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a></li>
			  <li><a id="a_last" runat="server" onserverclick="a_last_ServerClick" href="#">&raquo;</a></li>
		</ul>--%>

         <div id="paginate" runat="server" class="all_parent" style="text-align:right;height:60px;">
            <a id="a_pre" class="prenext" href="#" runat="server" onserverclick="a_front_ServerClick"><-上一页</a>
            <a id="a_1" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">1</a>
            <a id="a_2" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a>
            <a id="a_3" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a>
            <a id="a_4" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a>
            <a id="a_5" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a>
            <a id="a_6"  runat="server"  >....</a>
            <a id="a_next" class="prenext" href="#" runat="server" onserverclick="a_last_ServerClick">下一页-></a>
             <br /><br />
             <label>共有</label>  <label id="allpage" runat="server" ></label><label>页</label>
               <label id="nowpageindex" runat="server" style="display:none">1</label>
             <label>第</label><label id="nowpagenum" runat="server" >1</label><label>页</label>
        </div>
         
       
       
			<div class="alert alert-warning alert-dismissable">
			  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
			  <strong>Warning!</strong> Better check yourself, you're not looking too good.
			</div>
	</div>
</div><!-- end main -->
    <div class="footer_bg" runat="server" id="footer"><!-- start footer -->
	
    </div>
    </form>
    <script>
        function add() {
            alert("为什么");
            var div = document.createElement("div");
            div.style.position = "absolute";
            div.style.left = "0px";
            div.style.top = "0px";
            div.style.width = "100%";
            div.style.height = "100%";
            div.style.backgroundColor = "black";
            div.style.filter = "alpha(opacity=40)";
            div.style.opacity = .4;
            div.setAttribute("id", "div");
            var div2 = document.createElement("div");
            var input1 = document.createElement("input");
            input1.type = "text";
            input1.value = "input";
            input1.setAttribute("id", "test");
            div2.appendChild(input1);
            var input2 = document.createElement("input");
            input2.type = "button";
            input2.value = "提交";
            input2.onclick = subs;
            div2.appendChild(input2);
            var input3 = document.createElement("input");
            input3.type = "button";
            input3.value = "取消";
            input3.onclick = cancel;
            div2.appendChild(input3);
            var c = document.createElement("center");
            c.appendChild(div2);
            div.appendChild(c);
            document.body.appendChild(div);
        }
        function subs() {
            var a = document.getElementById("test").value;
            window.location.href = "http://www.baidu.com/s?wd=" + a;
        }
        function cancel() {
            var p = document.getElementById("div");
            document.body.removeChild(p);
        }
    </script>
</body>
</html>
