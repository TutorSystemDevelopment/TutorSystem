<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BasicInfo.aspx.cs" Inherits="Web_BasicInfo" %>

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
    <form id="form1" runat="server">
    <div class="all_parent" style="height:1000px;" runat="server">
        <div class="half_parent" style="width:40%;height:330px;" runat="server">
            <h3 class="block_title" style="margin-top:0px;background:#f7f7f7">基本信息修改</h3>
            <div class="all_parent" runat="server">
                <h4>QQ</h4>
                <input runat="server" class="form-control" id="info_qq"/>
                <br />
                <h4>手机号码</h4>
                <input runat="server" class="form-control" id="info_phone"/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="info_phone" ErrorMessage="请输入正确的手机号码！" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="info_phone" ErrorMessage="对不起，您的手机号码不能为空！"></asp:RequiredFieldValidator>
                <br />
                <h4>就读大学</h4>
                <input runat="server" class="form-control" id="info_university" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="info_university" ErrorMessage="对不起，就读大学不能为空！"></asp:RequiredFieldValidator>
                <br /><br />
                <h4 style="text-align:left">个人简介</h4>
            </div>
            <div class="clearfix"></div>
        </div>
        <h3 style="text-align:center;background:#f7f7f7" class="block_title">修改你的照片</h3>
        <div class="half_parent" style="width:60%;height:330px;">
                <label style="display:none" id="photoname" runat="server"></label>
                <img id="preview" src="../images/pic1.jpg" runat="server" style="width:100%;height:300px;"/>
            <asp:FileUpload ID="info_photo" runat="server" CssClass="upload_style" />
                <%--<input type="file" id="info_photo" style="margin-left:200px;margin-top:10px;" runat="server"/>--%>
        </div>
        <div class="all_parent" style="height:240px;">
            <textarea runat="server" class="form-control" id="info_intro" style="height:240px;width:100%;"></textarea>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="info_intro" ErrorMessage="对不起，个人简介不能为空！"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="text-align: right" Text="确认" CssClass="generalbtn right-align"/>    
        </div>
    </div>
    </form>
</body>
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
