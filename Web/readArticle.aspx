<%@ Page Language="C#" AutoEventWireup="true" CodeFile="readArticle.aspx.cs" Inherits="Web_readArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- Bootstrap -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="css/mystyle.css" rel="stylesheet" type="text/css" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/mystyle.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="parent_block">
        <h3 class="block_title">我的文章</h3>
        <div class="all_parent">
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" CellPadding="4" ForeColor="#333333" ItemStyle-Width="100%" Width="100%" Font-Size="Medium">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <HeaderTemplate>
                <table style="width:100%;table-layout:fixed">
                    <tr>
                        <td class="auto-style1">
                            文章标题
                        </td>
                        <td class="auto-style2">
                            发布日期
                        </td>
                        <td class="auto-style3">
                            文章操作
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table style="width:100%;table-layout:fixed">
                    <tr>
                        <td class="auto-style1">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "news.aspx?newsid="+DataBinder.Eval(Container.DataItem,"NewsID") %>' Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:HyperLink>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Date") %>'></asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="Button1" runat="server" CommandName="edit" Text="编辑" />
                            &nbsp;
                            <asp:Button ID="Button2" runat="server" CommandName="delete" Text="删除" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
            </div>
        <div class="all_parent" style="text-align:center;font-size:medium;">
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server">首页</asp:HyperLink>
            &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server">上一页</asp:HyperLink>
            &nbsp;
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            &nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server">下一页</asp:HyperLink>
            &nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server">尾页</asp:HyperLink>
            </div>
    </div>
    </form>
</body>
</html>
