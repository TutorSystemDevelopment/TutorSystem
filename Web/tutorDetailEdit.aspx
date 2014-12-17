<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tutorDetailEdit.aspx.cs" Inherits="Web_tutorDetailEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/mystyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <CKEditor:CKEditorControl ID="InfoEdit" runat="server" Height="614px"></CKEditor:CKEditorControl>
        <br />
        <asp:Button ID="bt_sure" runat="server" OnClick="bt_sure_Click" Text="确认" CssClass="generalbtn right-align" Font-Names="Microsoft YaHei UI"/>
    </div>
        
    </form>
</body>
</html>
