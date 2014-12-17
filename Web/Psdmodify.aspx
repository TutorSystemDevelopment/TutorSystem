<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Psdmodify.aspx.cs" Inherits="Web_Psdmodify" %>

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
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="parent_block" style="border-top:2px solid red;text-align:center;">
                <h3 style="text-align:left;">修改密码</h3>
                <div class="half_parent" style="text-align:center;width:30%;left:35%;position:absolute;">
                <h4 style="text-align:left">你的旧密码</h4>
                <input class="form-control" runat="server" id="tb_lastpsd" style="width:100%;line-height:none;" type="password"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tb_lastpsd" Display="Dynamic" runat="server" ErrorMessage="请输入你的旧密码" ForeColor="Red"></asp:RequiredFieldValidator>
                <h4 style="text-align:left">设置新密码</h4>
                <input id="info_password" runat="server" class="form-control" type="password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="info_password" Display="Dynamic" runat="server" ErrorMessage="请输入你的新密码" ForeColor="Red"></asp:RequiredFieldValidator>
                <div class="col-md-12" style="height:30px;width:220px;padding:0px;">
                    <div class="ywz_zhuce_huixian" id='pwdLevel_1'> </div>
                    <div class="ywz_zhuce_huixian" id='pwdLevel_2'> </div>
                    <div class="ywz_zhuce_huixian" id='pwdLevel_3'> </div>
                    <div class="ywz_zhuce_hongxianwenzi">弱</div>
                    <div class="ywz_zhuce_hongxianwenzi">中</div>
                    <div class="ywz_zhuce_hongxianwenzi">强</div>
                </div>
                <h4 style="text-align:left;">确认密码</h4> <span>
                <input id="info_comparison" runat="server" class="form-control" type="password" /></span>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="info_comparison" ControlToCompare="info_password" ErrorMessage="您两次输入的密码不相符，请检查!" ForeColor="Red"></asp:CompareValidator>
                <asp:Button ID="bt_sure" runat="server" OnClick="bt_sure_Click" Text="确认修改" CssClass="generalbtn right-align"/>
            </div>
        </div>
    </form>
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
  
</body>
</html>
