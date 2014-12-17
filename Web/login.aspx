<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Web_login" %>

<!DOCTYPE html>

<html>
  <head id="Head1"><link rel="icon" href="../images/icon.ico" />
   <title>
	您好,请登录
   </title>
      <style type="text/css" media=screen>
body
{
margin:0px;
padding:0px;
}
#bg
{
height:7px;
width:100%;
}
#head
{
height:800px;
width:100%;
}
#back
{
height:100%;
width:1170px;
margin:0 auto;
background-image:url(../images/login_back.jpg);
}
#right
{
height:100%;
width:370px;
float:right;
}
#login_box
{
height:280px;
width:304px;
margin-top:240px;
background-color:#414141;
}
#username
{
height:auto;
width:auto;
margin-left: 30px;
}
.f1
{
float: left;
height: 25px;
font-size: 18px;
font-family: "Microsoft YaHei";
line-height: 25px;
text-indent: 0;
margin-left:30px;
color:#EEEEEE;
}
.f2
{
float: left;
height: 25px;
font-size: 18px;
font-family: "Microsoft YaHei";
line-height: 25px;
text-indent: 0;
color:#33FFFF;
}
#a1
{
height:40px;
clear:both;
}
#password
{
height:auto;
width:auto;
margin-top: 10px;
margin-left: 30px;
}
.login_button
{
float: left;
width: 100px;
height: 36px;
margin-top: 30px;
margin-left: 160px;
background-color: #CCFF00;
border: none;
color: #414141;
font-size: 15px;
font-family: "Microsoft YaHei";
line-height: 36px;
}
#register
{
height:auto;
width:auto;
margin-top: 80px;
margin-left: 25px;
}
#end
{
height:180px;
width:auto;
}
#center
{
height:auto;
width:1170px;
margin:0 auto;
}
#text
{
height:auto;
width:auto;
margin-top:50px;
}
.f3
{
text-align:center;
height: 25px;
font-size: 14px;
font-family: "Microsoft YaHei";
line-height: 25px;
text-indent: 0;
color:#3b3b3b;
}
</style>
  </head>

  <body>
      <form runat="server">
    <div id="bg" style="clear:both"></div> 
    <div id="head">
     <div id="back">
      <div id="right">
       <div id="login_box">
        <div>
	<div id="a1" runat="server"></div>
	<span class="f1" style="margin-top:2px;">用户名</span>
	<input type="text" name="username" size=19 style="background-color: #EEEEEE;width:135px" runat="server" id="username">
	</div>
           <br />
	<div runat="server">
	<span class="f1" style="margin-top:8px;">密　码</span>
	<input type="password" name="password" size=19 style="background-color: #EEEEEE;width:135px;" runat="server" id="password">
	</div>
       <asp:Button Text="登 陆" CssClass="login_button" ID="loginBtn" runat="server" OnClick="loginBtn_Click"/>
	<div id="register">
	<span class="f1">还没有账号?</span><a href="StudentRegister.aspx"><span class="f2">点我注册>></span></a>
        </div>
	</div>
       </div>
      </div>
     </div>
    <div id="end">
     <div id="center">
       <div id="text">
	<p class="f3">
	  <span>
              Powered by Vincent Zoe&LuckyBear, HIT<br/>
              Copyright &copy; 2014.Supreme One For One All rights reserved.
              <br/>极致141 版权所有
          </span>

	</p>
       </div>
     </div>
    </div>
          </form>
  </body>
</html>