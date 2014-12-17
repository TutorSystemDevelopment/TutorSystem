<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacherRegister.aspx.cs" Inherits="Web_teacherRegister" %>

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
</head>
<body>
<form runat="server">
    <div runat="server">
        <uc1:head runat="server" id="head" />
        <div id="navbar" runat="server"></div>
    </div>

    <div class="maininfo"><!-- start main -->
	<div class="container">
		<div class="main row" style="padding-top:5%;">
			<div class="col-md-6 blog_left">
		            <div class="contact-form">
				  	        <h2>报名(请务必真实填写）</h2>
                        <div style="width:555px;padding:0px;" class="container">
                            <div class="col-md-6 left-align" style="padding-left:0px;">
                                        <div style="padding-right:30px;padding-left:0px;">
                                            <span>您的邮箱（用户名）</span>
						    	            <span><input type="email" class="form-control" id="info_mail" runat="server"/></span>
                                            <asp:RequiredFieldValidator ControlToValidate="info_mail" ErrorMessage="您的输入格式有误，请输入正确可用的邮箱地址！" 
                                            Font-Names="Microsoft YaHei UI" runat="server" Display="Dynamic" Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="info_mail" ErrorMessage="您的输入格式有误，请输入正确可用的邮箱地址！" 
                                            Font-Names="Microsoft YaHei UI" runat="server" Display="Dynamic" Font-Size="X-Small" ForeColor="Red"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="register_group"></asp:RegularExpressionValidator>
                                            </div>
                                        <div style="padding-left:0px;padding-right:30px;">
                                            <span>登录密码</span>
						    	            <span><input type="password" class="form-control" id="info_password" runat="server"/></span>
                                            <asp:RequiredFieldValidator ControlToValidate="info_password" ErrorMessage="请为您的账号设置一个简单密码！" 
                                            Font-Names="Microsoft YaHei UI" runat="server" Display="Dynamic" Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group"></asp:RequiredFieldValidator>
                                        </div>
                                        <div style="padding-left:0px;padding-right:30px;">
                                            <span>确认密码</span>
						    	            <span><input type="password" class="form-control" id="info_comparison" runat="server"/></span>
                                        </div>
                                        <asp:CompareValidator ID="passwordEnsure" runat="server" ControlToValidate="info_password" ControlToCompare="info_comparison"
                                        ErrorMessage="对不起，您两次输入密码不相符，请检查！" Type="String" Operator="Equal" Display="Dynamic" Font-Names="Microsoft YaHei UI"
                                        Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group"></asp:CompareValidator>
                                        <div style="padding-left:0px;padding-right:30px;">
                                            <span>QQ号码（非必填）</span>
						    	            <span><input type="text" class="form-control" id="info_qq" runat="server"/></span>
                                        </div>
                                        <div style="padding-left:0px;padding-right:30px;">
                                            <span>回家时间（用于了解授课时间）</span>
                                            <span><input class="form-control" type="date" id="info_backtime" runat="server"/></span>
                                        </div>
                                    </div>
                                    <div class="col-md-6 right-align" style="padding-right:0px;">
                                        <div style="padding-bottom:16px;padding-left:30px;font-size:16px;">
                                            <span>选择性别</span>
                                            <input type="radio" name="gender" value="1" style="margin-top:10px;" id="info_male" runat="server" checked="true"/><i class="fa fa-male"></i>男
						    	            <input type="radio" name="gender" value="0" style="margin-top:10px;margin-left:50px;" id="info_female" runat="server"/><i class="fa fa-female"></i>女
                                            
                                        </div>
                                        <div style="padding-left:30px;padding-right:0px;">
                                            <span>真实姓名</span>
						    	            <span><input type="text" class="form-control" id="info_name" runat="server"/></span>
                                            <asp:RequiredFieldValidator  ControlToValidate="info_mail" ErrorMessage="请输入您的真实姓名！" 
                                            Font-Names="Microsoft YaHei UI" runat="server" Display="Dynamic" Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group"></asp:RequiredFieldValidator>
                                        </div>
                                        <div style="padding-left:30px;padding-right:0px;">
                                            <span>就读大学</span>
						    	            <span><input type="text" class="form-control" id="info_university" runat="server"/></span>
                                        </div>
                                        <div style="padding-left:30px;padding-right:0px;">
                                            <span>手机号码</span>
						    	            <span><input type="tel" class="form-control" id="info_phone" runat="server"/></span>
                                            <asp:RegularExpressionValidator runat="server" ErrorMessage="请输入正确的联系方式（家教联系用，非常重要！）" Display="Dynamic"
                                                 ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)" 
                                                ControlToValidate="info_phone" Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group" Font-Names="Microsoft YaHei UI"></asp:RegularExpressionValidator>
                                        </div>
                                        <div style="padding-right:0px;padding-left:30px;">
                                            <span>返校时间</span>
                                            <span><input class="form-control" type="date" id="info_leavetime" runat="server"/></span>
                                            <asp:CompareValidator runat="server" ControlToValidate="info_backtime" ControlToCompare="info_leavetime" Type="Date" Display="Dynamic" ErrorMessage="对不起，回家时间应该早于返校时间！" Operator="LessThan" Font-Size="X-Small" ForeColor="Red"></asp:CompareValidator>
                                        </div>
                                        
                                    </div>
                        </div>
                                    
                        <div style="width:550px;height:100px;">
                            <div class="col-md-8" style="padding:0px;">
                                <h5>科目</h5>
                                <asp:CheckBoxList ID="courseBox" runat="server" RepeatDirection="Horizontal" RepeatColumns="5" Height="17px" Width="400px" Font-Names="微软雅黑" ForeColor="#5B5B5B" ValidationGroup="register_group"></asp:CheckBoxList>
                            </div>
                            <div class="col-md-4" style="padding-right:0px;">
                                <div>
                                    <h5 style="float:right;">年级</h5>
                                    <div class="clearfix"></div>
                                    <div style="float:right">
                                        <asp:CheckBox id="primaryBox" runat="server" Height="17px" Font-Names="微软雅黑" ForeColor="#5B5B5B" Text="小学"/>
                                        <asp:CheckBox id="middleBox" runat="server" Height="17px" Font-Names="微软雅黑" ForeColor="#5B5B5B" Text="初中"/><br />
                                        <asp:CheckBox id="seniorBox" runat="server" Height="17px" Font-Names="微软雅黑" ForeColor="#5B5B5B" Text="高中"/>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div>
						    <span>个人简介（将成为学生选择家教的重要依据，请认真填写）</span>
						    <span><textarea style="height:190px;color:#555" id="info_intro" runat="server"> </textarea></span>
                            <asp:RequiredFieldValidator ErrorMessage="请输入你的个人简介，这将公示给所有学生作为选择参考" ControlToValidate="info_intro"
                                 Display="Dynamic" Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group" Font-Names="Microsoft YaHei UI" runat="server"></asp:RequiredFieldValidator>
						</div>
                            <button id="registerButton" validationgroup="register_group" class="auto-btn btn-1 btn-1e" style="float:right;" runat="server" onserverclick="registerButton_ServerClick" type="submit">申请加入</button>
				        </div>
                    <div class="company_ad">
                        <br /><br />
		                <h2>报名提示</h2>
		                <address>
		                    <p>1.我们注重保护用户隐私和信息加密，无需担心隐私泄露</p>
		                    <p>2.为了保护家长和学生的知情权，请如实填写您的个人信息</p>
		                    <p>3.回家和返校时间用于计算可任教时间</p>
		                    <p>4.网站用户名和密码在所有功能上线后可用于修改个人信息，请牢记</p>
		                    <p>5.家教信息收集完毕后我们将集中进行面试和家教培训，届时请务必到场</p>
	                    </address>
	                </div>
			   </div>
            <div class="col-md-6 blog_right">
				<!-- start social_network_likes -->
                    <div class="headupload">
                        <h2 style="text-align:center;margin-top:0px;">上传你的照片</h2>
                        <img id="preview" src="../images/pic1.jpg" runat="server" style="width:100%;height:380px;"/>
                        <asp:FileUpload runat="server" ID="info_photo" CssClass="upload_style"/>
                        <%--<input type="file" id="info_photo" style="margin-left:200px;margin-top:10px;" runat="server"/>--%>
                    </div>

                    <div class="company_ad" style="text-align:center">
                        <br /><br />
		                <h2>直接联系我们</h2>
		                <address>
		                    <p>洞口县极致141团队</p>
		                    <p>手机:(+86) 15080901002</p>
		                    <p>邮箱：<a href="mailto:supreme141@hotmail.com">jizhi141(at)hotmail.com</a></p>
		                    <p>请关注: <a href="http://weibo.com/u/3144730605">新浪微博</a>,<a href="http://page.renren.com/601890416">人人主页</a></p>
	                    </address>

	                </div>
                <div class="social_network_likes">
                    <h2 style="text-align:center">关注团队的最新动态</h2>
				    <ul class="list-unstyled">
				      	<li><a href="http://www.twitter.com" target="view_window" class="tweets"><div class="followers"><p><span>2k</span>Followers</p></div><div class="social_network"><i class="twitter-icon"> </i> </div></a></li>
				      	<li><a href="http://www.facebook.com" target="view_window" class="facebook-followers"><div class="followers"><p><span>5k</span>Followers</p></div><div class="social_network"><i class="facebook-icon"> </i> </div></a></li>
				      	<li><a href="http://www.gmail.com" target="view_window" class="email"><div class="followers"><p><span>7.5k</span>members</p></div><div class="social_network"><i class="email-icon"> </i></div> </a></li>
				      	<li><a href="http://www.linkedin.com" target="view_window" class="dribble"><div class="followers"><p><span>10k</span>Followers</p></div><div class="social_network"><i class="dribble-icon"> </i></div></a></li>
				      	<div class="clear"> </div>
				    </ul>
                    </div>
                </div>
			</div>
			<div class="clearfix"></div>
		</div>
</div><!-- end main -->
<div class="footer_bg" id="footer" runat="server"><!-- start footer -->
	
</div>
</form>
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

<script>
    $("#info_photo").change(function () {
        var objUrl = getObjectURL(this.files[0]);
        console.log("objUrl = " + objUrl);
        if (objUrl) {
            $("#preview").attr("src", objUrl);
        }
    });
    //建立一個可存取到該file的url
    function getObjectURL(file) {
        var url = null;
        if (window.createObjectURL != undefined) { // basic
            url = window.createObjectURL(file);
        } else if (window.URL != undefined) { // mozilla(firefox)
            url = window.URL.createObjectURL(file);
        } else if (window.webkitURL != undefined) { // webkit or chrome
            url = window.webkitURL.createObjectURL(file);
        }
        return url;
    }
</script>

</html>