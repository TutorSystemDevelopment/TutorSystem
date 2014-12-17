<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectClass.aspx.cs" Inherits="Web_xuanke" %>

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
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<style>
        th {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="all_parent" style="font-size:medium">
        <div class="half_parent" style="text-align:center;">
            <div class="parent_block" style="background-color:#f7f7f7;">
                <h3 class="block_title">当前课表</h3>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="100%" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Grade" HeaderText="年级"/>
                <asp:BoundField DataField="CourseID" HeaderText="科目"/>
                <asp:BoundField DataField="Cost" HeaderText="价格"/>
                <asp:BoundField DataField="JoinID" HeaderText="课程号"/>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True"/>
            </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings Visible="False" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                <br />
                <div class="all_parent" style="font-size:small">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">首页</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">上一页</asp:LinkButton>
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">下一页</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">尾页</asp:LinkButton>
                    &nbsp;跳转到第<asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    页
                </div>
            </div>
        </div>
        <div class="half_parent">
            <div class="parent_block" style="background-color:#f7f7f7;height:227px;">
                <h3 class="block_title" style="text-align:center">科目添加</h3>
                <div class="half_parent">
                    <h4>授课年级</h4>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="80px" CssClass="form-control">
                        <asp:ListItem>高中</asp:ListItem>
                        <asp:ListItem>初中</asp:ListItem>
                        <asp:ListItem>小学</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <h4>科目选择</h4>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Width="80px">
                        <asp:ListItem Value="1">语文</asp:ListItem>
                        <asp:ListItem Value="2">数学</asp:ListItem>
                        <asp:ListItem Value="3">英语</asp:ListItem>
                        <asp:ListItem Value="4">物理</asp:ListItem>
                        <asp:ListItem Value="5">化学</asp:ListItem>
                        <asp:ListItem Value="6">生物</asp:ListItem>
                        <asp:ListItem Value="7">生物</asp:ListItem>
                        <asp:ListItem Value="8">艺术类</asp:ListItem>
                        <asp:ListItem Value="9">地理</asp:ListItem>
                        <asp:ListItem Value="10">程序设计</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="half_parent">
                    <h4>预计价格（元/小时）</h4>
                    <asp:TextBox ID="TextBox1" runat="server" Width="80px" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="generalbtn"/>
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
