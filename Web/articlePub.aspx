<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="articlePub.aspx.cs" Inherits="Web_articlePub" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

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
<!--left navigation-->
<script src="js/tendina.js"></script>
<link rel="stylesheet" href="css/jquery.leftnavi.css"/>
</head>
<body style="height: 293px">
    <form id="form1" runat="server">
        <div class="all_parent" style="margin-top:10px;padding-left:0px;padding-bottom:10px;padding-right:0px;background-color:#f7f7f7;color:#555;">
            <h3 style="border-top:2px solid red;">文章发布</h3>
            <div class="half_parent">
                <h4 style="color:red">标题</h4>
                <asp:TextBox ID="TextBox1" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
                <h4 style="color:red">为你的文章选择配图<i class="fa fa-arrow-down"></i></h4>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
            </div>
            <div class="half_parent">
                <div style="width:100%;height:100px;">
                    <h4 style="color:red">自定义新标签</h4>
                    <input type="text" id="diytag" runat="server" class="form-control" maxlength="2" style="width:250px;"/>
                    <h4 style="color:red">选择文章标签</h4>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="all_parent">
                <asp:Image ID="Image1" runat="server" Height="412px" Width="100%" ImageUrl="~/images/news_1.jpg"/>
            </div>
            <div class="all_parent">
                <h4 style="color:red">正文</h4>
                <%--<asp:TextBox ID="TextBox3" runat="server" Height="350px" Width="100%" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <br />--%>
                <CKEditor:CKEditorControl ID="TextBox3" runat="server" Height="450px"></CKEditor:CKEditorControl>
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="发布文章" CssClass="generalbtn right-align"/>
                </div>
            </div>
</form>
<%--浮动框的效果--%>

<script>
    $('.dropdown').tendina({
        animate: true,
        speed: 500,
        openCallback: function ($clickedEl) {
            console.log($clickedEl);
        },
        closeCallback: function ($clickedEl) {
            console.log($clickedEl);
        }
    })
    $('#FileUpload1').change(function () {
        var objUrl = getObjectURL(this.files[0]);
        console.log("objUrl = " + objUrl);
        if (objUrl) {
            $("#Image1").attr("src", objUrl);
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
