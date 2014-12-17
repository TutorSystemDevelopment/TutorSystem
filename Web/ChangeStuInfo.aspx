<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeStuInfo.aspx.cs" Inherits="Web_ChangeStuInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="parent_block">
        <h3 class="block_title">学生信息修改</h3>
        <div class="half_parent">
            <h4>学生姓名</h4>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <h4>QQ</h4>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="half_parent">
            <h4>监护人姓名</h4>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
            <h4>监护人手机</h4>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    <div class="all_parent">
        <h4>家庭住址</h4>
        <asp:TextBox ID="TextBox2" Width="100%" Height="200px" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认修改" CssClass="generalbtn right-align"/><div class="clearfix"></div>
    </div>
    </div>
    </form>
</body>
</html>
