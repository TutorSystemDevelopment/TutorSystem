<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacherRecommend.aspx.cs" Inherits="Web_teacherRecommend" validateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="../Web/css/bootstrap.css" rel='stylesheet' type='text/css' />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="../Web/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../Web/css/mystyle.css" rel="stylesheet" type="text/css" />
<!-- start plugins -->
<script type="text/javascript" src="../Web/js/jquery.min.js"></script>
<script type="text/javascript" src="../Web/js/bootstrap.js"></script>
<script type="text/ecmascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="../Web/fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_btm">
        <div class="container">
        <div class="col-md-6">
            <div class="headupload">
                <h2 style="margin-top:0px;">上传教师照片</h2>
                <img id="preview" src="../images/c4.jpg" runat="server" style="width:220px;height:220px;" />
                <asp:FileUpload ID="info_photo" runat="server" CssClass="upload_style"/>
                <%--<input type="file" id="info_photo" style="margin-left:200px;margin-top:10px;" runat="server"/>--%>
            </div>
        </div>
        <div class="col-md-6">
            <h4>首页推荐</h4>
            <asp:CheckBox ID="iftop" runat="server" Text="勾选上首页"/>
            <asp:Label ID="lb_filename" runat="server" Text="Label" Visible="False"></asp:Label>
            <h4>推荐理由</h4>
            <asp:TextBox id="txtContent" class="ckeditor" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="bt_back" runat="server" Text="返回" OnClick="bt_back_Click" CssClass="generalbtn right-align"/>
            <asp:Button ID="bt_sure" runat="server" Text="确认推荐" OnClick="bt_sure_Click" CssClass="generalbtn right-align"/>
        </div>
        </div>
        
    </div>
    </form>
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
</body>
</html>
