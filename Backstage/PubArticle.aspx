<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubArticle.aspx.cs" Inherits="Backstage_PubArticle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="../Web/css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="../Web/css/mystyle.css" rel="stylesheet" type="text/css" />
<%--<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>--%>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="head" runat="server">

       </div>

        <div id="mian" class="container">
            <div class="col-md-12" style="margin-top:10px;padding-left:0px;padding-bottom:10px;padding-right:0px;background-color:#f7f7f7;color:#555;">
            <h3 style="border-top:2px solid red;">文章发布</h3>
            <div class="col-md-6">
                <h4 style="color:red">标题</h4>
                <asp:TextBox ID="TextBox1" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
                <h4 style="color:red">选择文章标签</h4>
                <div style="width:100%;height:100px;">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"></asp:CheckBoxList>
                    <h4 style="color:red">自定义新标签</h4>
                    <input type="text" id="diytag" runat="server" class="form-control" maxlength="2" style="width:250px;"/>
                </div>
                <br /><br />
                <h4 style="color:red">为你的文章选择配图>></h4>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
            </div>
            <div class="col-md-6">
                <asp:Image ID="Image1" runat="server" Height="412px" Width="100%" ImageUrl="~/images/default.jpg"/>
            </div>
            <div class="col-md-12">
                <h4 style="color:red">正文</h4>
                <%--<asp:TextBox ID="TextBox3" runat="server" Height="350px" Width="100%" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <br />--%>
                <CKEditor:CKEditorControl ID="TextBox3" runat="server" Height="450px"></CKEditor:CKEditorControl>
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="发布文章" CssClass="generalbtn right-align"/>
            </div>
        </div>
        </div>
        <div class="footer_bg" runat="server" id="footer"><!-- start footer -->
	
        </div>
    </div>
    </form>
</body>
</html>
