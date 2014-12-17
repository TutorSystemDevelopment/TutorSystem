<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="Web_Default2" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

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
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div　class="fixed_height_container">
        <div class="all_parent">
            <h3 class="block_title" style="text-align:center;background-color:#f7f7f7">时间线列表</h3>
                <asp:GridView AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" ID="GridView1" Font-Size="Small" runat="server" AutoGenerateColumns="False" Width="100%" style="text-align: left" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="时间">                   
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                            年 <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("Month") %>'></asp:Label>
                            月
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="标题" >
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="详细条目">
                        <ItemTemplate>
                          <%# Eval("Items").ToString().Length>50?Eval("Items").ToString().Substring(0,50)+" ... ":Eval("Items").ToString() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="条目操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_delete" runat="server" CommandName="deleteor">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div class="all_parent" style="max-height:500px;">
            <h3 class="block_title" style="text-align:center;background-color:#f7f7f7">时间线添加</h3>
            <div class="half_parent">
                <h4 style="float:left">标题</h4>
                <div class="all_parent" style="float:left">
                    <asp:TextBox ID="TitleText" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                </div>
            <div class="half_parent">
                <h4>事件时间</h4>
                    <div class="half_parent" style="padding:0px;">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control left-align" Width="100px">
                        </asp:DropDownList>
                        <span style="font-size:medium;float:left;margin:5px;">年</span>
                    </div>
                    <div class="half_parent" style="padding:0px;">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control left-align" Width="100px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList><span style="font-size:medium;float:left;margin:5px;">月</span>
                    </div>
                </div>
            <div class="clearfix"></div>
            <div class="all_parent">
                <h4>详细条目</h4>
                <%# Eval("Items").ToString().Length>50?Eval("Items").ToString().Substring(0,50)+" ... ":Eval("Items").ToString() %>
                <CKEditor:CKEditorControl ID="TextArea1" runat="server" Height="180px"></CKEditor:CKEditorControl>
                <asp:Button ID="Button1" runat="server" Text="提交事件" OnClick="Button1_Click" CssClass="generalbtn right-align"/>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
        <div class="clearfix"></div>
        
    </div>
    </form>
</body>
</html>
