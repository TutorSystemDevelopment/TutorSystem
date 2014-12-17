<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegister.aspx.cs" Inherits="Web_StudentRegister" %>

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
    <link href="css/mystyle.css" rel="stylesheet" type="text/css" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
<link href="css/xiniu.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />

        <%--浮动框的效果--%>
<script type="text/javascript" src="js/scrolltool.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server">
            <uc1:head runat="server" id="head" />
            <div id="navbar" runat="server"></div>
        </div>
    <div class="container" style="padding-top:20px;">
        <div class="col-md-3" style="background-color:#f9f9f9;border-top:2px solid red;margin-right:10px;height:456px;">
            <h2 style="color:red;padding-bottom:20px;">账户信息<span style="font-size:12px;color:black;">（用于预约家教）</span></h2>
            <div style="padding-left: 0px; padding-right: 30px;width:250px;height:90px;">
                <h4>邮箱（账户名）</h4>
                <input type="email" id="stu_mail" runat="server" class="form-control"/>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="stu_mail" ID="RegularExpressionValidator1" runat="server" ErrorMessage="您输入的邮箱不正确，请重新输入" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="stu_mail" ForeColor="Red" ErrorMessage="请输入你的邮箱作为网站账户名，可用于预约家教"></asp:RequiredFieldValidator>
            </div>
            <div style="padding-left: 0px; padding-right: 30px;width:250px;height:100px;">
                <h4>登录密码</h4>
                <span>
                    <input type="password" class="form-control" id="info_password" runat="server" /></span>
                <div class="col-md-12" style="height:19px;width:220px;padding:0px;">
                    <div class="ywz_zhuce_huixian" id='pwdLevel_1'> </div>
                        <div class="ywz_zhuce_huixian" id='pwdLevel_2'> </div>
                        <div class="ywz_zhuce_huixian" id='pwdLevel_3'> </div>
                        <div class="ywz_zhuce_hongxianwenzi"> 弱</div>
                        <div class="ywz_zhuce_hongxianwenzi"> 中</div>
                        <div class="ywz_zhuce_hongxianwenzi"> 强</div>
                </div>
            </div>
            <div style="padding-left: 0px; padding-right: 30px;width:250px;">
                <h4>确认密码</h4>
                <span>
                    <input type="password" class="form-control" id="info_comparison" runat="server" /></span>
            </div><asp:CompareValidator Display="Dynamic" ID="passwordEnsure" runat="server" ControlToValidate="info_password" ControlToCompare="info_comparison"
            ErrorMessage="对不起，您两次输入密码不相符，请检查！" Type="String" Operator="Equal" Font-Names="Microsoft YaHei UI"
            Font-Size="X-Small" ForeColor="Red" ValidationGroup="register_group"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="info_password" Display="Dynamic" ErrorMessage="请为您的账户设置一个密码"></asp:RequiredFieldValidator>
            
        </div>

        <div class="col-md-6" style="font-size:16px;background-color:#f9f9f9;border-top:2px solid red;">
            <h2 style="text-align:right;color:red;">基本信息</h2>
            <div class="col-md-6" style="padding-left:0px;">
                <div class="col-md-12">
                    <h4>姓名</h4><input type="text" id="stu_name" runat="server" class="form-control"/>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ControlToValidate="stu_name" ErrorMessage="请输入你的姓名！" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-12" style="padding-right:0px;">
                <h4>选择性别</h4>
                    <div class="col-md-6" style="padding-left:0px;padding-top:5px;">
                        <input type="radio" name="gender" value="1" style="margin-top:10px;" id="info_male" runat="server" checked="true"/><i class="fa fa-male"></i>男
                    </div>
                    <div class="col-md-6" style="text-align:right;padding-top:7px;">
                        <input type="radio" name="gender" value="0" style="margin-top:10px;margin-left:50px;" id="info_female" runat="server"/><i class="fa fa-female"></i>女
                    </div>
                </div>
                <div class="col-md-12">
                    <h4>监护人姓名</h4><input type="text" id="stu_guardname" runat="server" class="form-control"/>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="请输入监护人（父母）的姓名!" ControlToValidate="stu_guardname"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6" style="font-size:16px;">
                <h4>QQ（非必填）</h4>
                <input type="text" id="stu_qq" runat="server" class="form-control"/>
                <div class="col-md-12">
                    <h4>年级：</h4>
                    <asp:DropDownList ID="stu_grade" runat="server" Height="35px" Width="97px" CssClass="form-control">
                        <asp:ListItem Selected="True">小学</asp:ListItem>
                        <asp:ListItem>初中</asp:ListItem>
                        <asp:ListItem>高中</asp:ListItem>
                    </asp:DropDownList>
                </div>                
                <div class="col-md-12">
                    <h4>监护人电话</h4><input type="tel" id="stu_guardphone" runat="server" class="form-control"/>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="stu_guardphone" runat="server" ErrorMessage="请输入正确的手机号码（用于家教联系，非常重要！）" ForeColor="Red" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                </div>
                
            </div>
            <div class="col-md-12">
                <h4>家庭住址</h4>
                <textarea id="stu_address" runat="server" class="form-control" style="height:100px;"></textarea>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="请输入正确的住址！（非常重要）" ControlToValidate="stu_address"></asp:RequiredFieldValidator>
                <br />
                <div class="col-md-12" style="text-align:right;padding:0px;">
                    <asp:Button ID="bt_suer" runat="server" Text="确认无误，我要报名" OnClick="bt_suer_Click" CssClass="selectbutton"/>
                </div>
            </div>
            
        </div>
        <div class="col-md-3" style="border-top:2px solid red;width:23%;margin-left:10px;background-color:#f9f9f9;height:456px;">
            <h2 style="color:red">温馨提示</h2>
            <p>
                1.我们注重保护用户隐私和信息加密，无需担心隐私泄露<br/><br/>
                2.账户信息用于网上择师功能，注册完成后将可以直接在网上选择您喜欢的家教<br/><br/>
                3.请如实填写监护人信息和家庭住址，这些将被告知您所选择的家教<br/><br/>
                4.网站账户名和密码在所有功能上线后可用于修改个人信息，请牢记
            </p>
            <div class="company_ad" style="text-align:center">
                        <br /><br />
		                <h2 style="color:red">直接联系我们</h2>
		                <address>
		                    <p>洞口县极致141团队</p>
		                    <p>手机:(+86) 15080901002</p>
		                    <p>邮箱：<a href="mailto:supreme141@hotmail.com">jizhi141(at)hotmail.com</a></p>
		                    <p>请关注: <a href="http://weibo.com/u/3144730605">新浪微博</a>,<a href="http://page.renren.com/601890416">人人主页</a></p>
	                    </address>
	                </div>
        </div>
        
    </div>
    <script type="text/javascript">

        $('#info_password').focus(function () {
            $('#pwdLevel_1').attr('class', 'ywz_zhuce_hongxian');
            $('#info_password').keyup();
        });

        $('#info_password').keyup(function () {
            var __th = $(this);

            if (!__th.val()) {
                $('#pwd_tip').hide();
                $('#pwd_err').show();
                Primary();
                return;
            }
            if (__th.val().length < 6) {
                $('#pwd_tip').hide();
                $('#pwd_err').show();
                Weak();
                return;
            }
            var _r = checkPassword(__th);
            if (_r < 1) {
                $('#pwd_tip').hide();
                $('#pwd_err').show();
                Primary();
                return;
            }

            if (_r > 0 && _r < 2) {
                Weak();
            } else if (_r >= 2 && _r < 4) {
                Medium();
            } else if (_r >= 4) {
                Tough();
            }

            $('#pwd_tip').hide();
            $('#pwd_err').hide();
        });



        function Primary() {
            $('#pwdLevel_1').attr('class', 'ywz_zhuce_huixian');
            $('#pwdLevel_2').attr('class', 'ywz_zhuce_huixian');
            $('#pwdLevel_3').attr('class', 'ywz_zhuce_huixian');
        }

        function Weak() {
            $('#pwdLevel_1').attr('class', 'ywz_zhuce_hongxian');
            $('#pwdLevel_2').attr('class', 'ywz_zhuce_huixian');
            $('#pwdLevel_3').attr('class', 'ywz_zhuce_huixian');
        }

        function Medium() {
            $('#pwdLevel_1').attr('class', 'ywz_zhuce_hongxian');
            $('#pwdLevel_2').attr('class', 'ywz_zhuce_hongxian2');
            $('#pwdLevel_3').attr('class', 'ywz_zhuce_huixian');
        }

        function Tough() {
            $('#pwdLevel_1').attr('class', 'ywz_zhuce_hongxian');
            $('#pwdLevel_2').attr('class', 'ywz_zhuce_hongxian2');
            $('#pwdLevel_3').attr('class', 'ywz_zhuce_hongxian3');
        }

        function checkPassword(pwdinput) {
            var maths, smalls, bigs, corps, cat, num;
            var str = $(pwdinput).val()
            var len = str.length;

            var cat = /.{16}/g
            if (len == 0) return 1;
            if (len > 16) { $(pwdinput).val(str.match(cat)[0]); }
            cat = /.*[\u4e00-\u9fa5]+.*$/
            if (cat.test(str)) {
                return -1;
            }
            cat = /\d/;
            var maths = cat.test(str);
            cat = /[a-z]/;
            var smalls = cat.test(str);
            cat = /[A-Z]/;
            var bigs = cat.test(str);
            var corps = corpses(pwdinput);
            var num = maths + smalls + bigs + corps;

            if (len < 6) { return 1; }

            if (len >= 6 && len <= 8) {
                if (num == 1) return 1;
                if (num == 2 || num == 3) return 2;
                if (num == 4) return 3;
            }

            if (len > 8 && len <= 11) {
                if (num == 1) return 2;
                if (num == 2) return 3;
                if (num == 3) return 4;
                if (num == 4) return 5;
            }

            if (len > 11) {
                if (num == 1) return 3;
                if (num == 2) return 4;
                if (num > 2) return 5;
            }
        }

        function corpses(pwdinput) {
            var cat = /./g
            var str = $(pwdinput).val();
            var sz = str.match(cat)
            for (var i = 0; i < sz.length; i++) {
                cat = /\d/;
                maths_01 = cat.test(sz[i]);
                cat = /[a-z]/;
                smalls_01 = cat.test(sz[i]);
                cat = /[A-Z]/;
                bigs_01 = cat.test(sz[i]);
                if (!maths_01 && !smalls_01 && !bigs_01) { return true; }
            }
            return false;
        }
    </script>
        <div id="footer" runat="server">

        </div>
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

    </form>
</body>

</html>
