<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chatlist.aspx.cs" Inherits="Web_chatlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<!-- start plugins -->
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<!----font-Awesome----->
<link rel="stylesheet" href="fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-9" style="text-align:center">
        <h4 style="background-color:#c1d9f3;text-align:center">一周内</h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"  OnRowDataBound="GridView1_RowDataBound" Width="100%" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5" OnRowCommand="GridView1_RowCommand" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="35px" Width="35px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SendUID" HeaderText="发送方" />
                <asp:BoundField DataField="Title" HeaderText="主题" />
                <asp:BoundField HeaderText="内容" DataField="ChatContent" />
                <asp:BoundField DataField="Time" HeaderText="日期" />
                <asp:BoundField HeaderText="是否已读" DataField="IsRead" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="" Text="查看" CommandArgument='<%#Container.DataItemIndex%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ChatID" HeaderText="ChatID" />
                <asp:BoundField HeaderText="发送方ID" />
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
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">首页</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">上一页</asp:LinkButton>
            &nbsp;<asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
            &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">下一页</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">尾页</asp:LinkButton>
            &nbsp;跳转到第<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            页<br />
            <br />
            <asp:Label ID="lb_rid" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="lb_cid" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="lb_Rname" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="content1" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<h4 style="background-color:#c1d9f3;text-align:center;">更早</h4>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" Width="100%" AllowPaging="True" PageSize="5" OnRowCommand="GridView2_RowCommand" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" Height="35px" Width="35px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SendUID" HeaderText="发送方" />
                    <asp:BoundField DataField="Title" HeaderText="主题" />
                    <asp:BoundField DataField="ChatContent" HeaderText="内容" />
                    <asp:BoundField DataField="Time" HeaderText="日期" />
                    <asp:BoundField DataField="IsRead" HeaderText="是否已读" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="" CommandArgument='<%#Container.DataItemIndex%>' Text="查看" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ChatID" HeaderText="ChatID" />
                    <asp:BoundField HeaderText="发送方ID" />
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
            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">首页</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">上一页</asp:LinkButton>
            &nbsp;<asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
            &nbsp;<asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">下一页</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">尾页</asp:LinkButton>
            &nbsp;跳转到第<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            页<br /><br />
    </div>
        <%--<button runat="server" onserverclick="check_ServerClick" id="check_btn">点我试试</button>--%>
        <div class="white_content" runat="server" id="dialog">
            <h4>私信查看</h4>
            <div class="col-md-12">
                <div style="display:block;min-height:100px;width:100%">
                    <p runat="server" id="chatDetails">

                    </p>
                </div>
                <input type="button" class="generalbtn" value="回复" id="confirm_btn" runat="server" onserverclick="confirm_btn_ServerClick" />
                <input type="button" class="generalbtn" style="float:right;" value="取消" id="cancel_btn" runat="server" onserverclick="cancel_btn_ServerClick"/>
            </div>
        </div>
        <div class="black_overlay" runat="server" id="background"></div>
    </form>
</body>
</html>
