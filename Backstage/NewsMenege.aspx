<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsMenege.aspx.cs" Inherits="Backstage_NewsMenege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <!----font-Awesome----->
<link rel="stylesheet" href="../Web/fonts/css/font-awesome.min.css"/>
<!----font-Awesome----->
<script type="text/javascript" src="../Web/js/jquery.min.js"></script>
<script type="text/javascript" src="../Web/js/bootstrap.js"></script>
<script type="text/javascript" src="../Web/js/jquery.min.js"></script>
    <style type="text/css">
        .auto-style8 {
            width: 116px;
        }
        .auto-style12 {
            width: 597px;
        }
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div id="head" runat="server">

        </div>

        <div id="main" class="container">
            

        <div id="tab_bt">
                <ul class="tabpanel">
                    <li class="singletab"><a  id="abt_all"  runat="server" onserverclick="bt_all_Click" href="#tab_bt" class="tablink"><span>全部新闻</span></a></li>
                    <li class="singletab"><a id="abt_pass" runat="server" onserverclick="bt_pass_Click" href="#allpage" class="tablink"><span>审核通过</span></a></li>
                    <li class="singletab"><a id="abt_notpass" runat="server" onserverclick="bt_notpass_Click" href="#tab_bt" class="tablink"><span>正在审核</span></a></li>
                </ul>
        </div>
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" Width="1200px">
            <ItemTemplate>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style8" rowspan="5">
                            <asp:Image ID="img_pic" runat="server" Height="192px" ImageUrl='<%# "../images/"+DataBinder.Eval(Container.DataItem,"TitlePic") %>' Width="240px" />
                        </td>
                        <td class="auto-style12">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_content2" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text="状态:    "></asp:Label>
                            <asp:Label ID="lb_state" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text='<%# DataBinder.Eval(Container.DataItem,"ifpass") %>'></asp:Label>
                            <asp:Label ID="lb_newid" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text='<%# DataBinder.Eval(Container.DataItem,"NewsID") %>' Visible="False"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lb_top" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text='<%# DataBinder.Eval(Container.DataItem,"IsTop") %>'></asp:Label>
                            &nbsp;<asp:Label ID="lb_tutorid" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text='<%# DataBinder.Eval(Container.DataItem,"TutorID") %>' Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_title" runat="server" Font-Names="微软雅黑" Font-Size="Large" ForeColor="#428BCA" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_content" runat="server" Font-Names="微软雅黑" Font-Size="Small" Text='<%# DataBinder.Eval(Container.DataItem,"Body") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label6" runat="server" Font-Names="微软雅黑" Font-Size="Small" ForeColor="Gray" Text="时间：  "></asp:Label>
                            <asp:Label ID="lb_time" runat="server" Font-Names="微软雅黑" Font-Size="Small" ForeColor="Gray" Text='<%# DataBinder.Eval(Container.DataItem,"Date") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label7" runat="server" Font-Names="微软雅黑" Font-Size="Small" ForeColor="Gray" Text="作者：  "></asp:Label>
                            <asp:Label ID="lb_writer" runat="server" Font-Names="微软雅黑" Font-Size="Small" ForeColor="Gray" Text='<%# DataBinder.Eval(Container.DataItem,"Author") %>'></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style12">&nbsp;</td>
                        <td>
                            <asp:Button ID="bt_delete" runat="server" CommandName="delete" CssClass="btn-success" Height="21px" Text="首页移除" OnClientClick="javascript:return confirm('确定取消预约吗?'）" />
                            <asp:Button ID="bt_top" runat="server" CommandName="top" CssClass="btn-success" Height="21px" OnClientClick="javascript:return confirm('确定取消预约吗?'）" Text="上首页" />
                            <asp:Button ID="bt_pass" runat="server" CommandName="pass" CssClass="btn-success" Height="21px" OnClientClick="javascript:return confirm('确定取消预约吗?'）" Text="审核通过" />
                            <asp:Button ID="bt_send" runat="server" CommandName="send" CssClass="btn-success" Height="21px" Text="发送修改提示" />
                        </td>
                    </tr>
                </table>
                <hr aria-orientation="horizontal" />
                
            </ItemTemplate>
        </asp:DataList>

           <div id="paginate" runat="server" class="all_parent" style="text-align:right">
            <br /><br />
            <div class="col-md-12">
            <a id="a_pre" class="prenext" href="#" runat="server" onserverclick="a_front_ServerClick"><-上一页</a>
            <a id="a_1" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">1</a>
            <a id="a_2" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a>
            <a id="a_3" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a>
            <a id="a_4" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a>
            <a id="a_5" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a>
            <a id="a_6"  runat="server"  >....</a>
            <a id="a_next" class="prenext" href="#" runat="server" onserverclick="a_last_ServerClick">下一页-></a>
                <br /><br />
             <label>共有</label>  <label id="allpage" runat="server" ></label><label>页</label>
               <label id="nowpageindex" runat="server" style="display:none">1</label>
             <label>第</label><label id="nowpagenum" runat="server" >1</label><label>页</label>
            </div>
        </div>
       </div>

        <div class="footer_bg" runat="server" id="footer"><!-- start footer -->
        </div>
           
    </div>
    </form>


</body>
</html>
