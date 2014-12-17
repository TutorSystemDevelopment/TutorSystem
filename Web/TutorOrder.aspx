<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TutorOrder.aspx.cs" Inherits="Web_TutorOrder" %>

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
    <style type="text/css">
        .auto-style6 {
            width: 100px;
        }
        .auto-style7 {
            width: 100px;
            height: 16px;
        }
        .auto-style14 {
            width: 238px;
            height: 16px;
        }
        .auto-style15 {
            width: 238px;
        }
        .auto-style16 {
            width: 142px;
            height: 16px;
        }
        .auto-style17 {
            width: 142px;
        }
        .auto-style18 {
            width: 225px;
            height: 16px;
        }
        .auto-style19 {
            width: 225px;
        }
        .auto-style22 {
            width: 125px;
            height: 16px;
        }
        .auto-style23 {
            width: 125px;
        }
        .auto-style24 {
            width: 109px;
            height: 16px;
        }
        .auto-style25 {
            width: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <h3 style="border-top:2px #ff4401 solid;text-align:center;margin-top:0px;padding:7px;background-color:#f7f7f7;">我的预约</h3>
            <div class="blockdiv">

                <div id="findbox" >

                </div>



                <asp:DataList ID="DataList1" runat="server" Width="16px" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div class=" reseritem" style="width:870px">
                            <div class="resertitle">
                                <div class="" style="float:left;">
                                    <span style="margin-right:10px;padding-left:19px;">预约时间：</span><asp:Label ID="lb_time" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Time") %>'></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 预约状态：<asp:Label ID="lb_state" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ispass") %>'></asp:Label>
&nbsp;<asp:Label ID="lb_stuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StuID") %>'></asp:Label>
                                    <asp:Label ID="lb_resid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ReservationID") %>' Visible="False"></asp:Label>
                                </div>
                                <div class="" style="text-align:right;">
                                    &nbsp;<asp:LinkButton ID="bt_send" runat="server" CommandName="send" >发送私信</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="lb_delete" runat="server" CommandName="delete" OnClientClick="javascript:return confirm('确定取消预约吗?'）">删除预约</asp:LinkButton>
                                </div>
                            </div>
                            <div class="" style="padding-top:20px; top: 0px; left: 0px; width: 878px;">
                                <table style="width:870px; text-align:center;">
                                    <tr style="font-family:'Microsoft YaHei';color:red;">
                                        <th style="text-align:center;" class="auto-style7">姓名</th>
                                        <th style="text-align:center;" class="auto-style14">住址</th>
                                        <th style="text-align:center;" class="auto-style24">监护人</th>
                                        <th style="text-align:center;" class="auto-style16">联系方式</th>
                                        <th style="text-align:center;" class="auto-style18">科目</th>
                                        <th style="text-align:center;" class="auto-style22">年级</th>
                                    </tr>

                                    
                                    <tr>
                                        <td class="auto-style6">
                                            <asp:Label ID="lb_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style15">
                                            <asp:Label ID="lb_Address" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Address") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style25">
                                            <asp:Label ID="lb_guardian" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GuardianName") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style17">
                                            <asp:Label ID="lb_phone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GuardianPhone") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style19">
                                            <asp:Label ID="lb_course" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="auto-style23">
                                            <asp:Label ID="lb_grade" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Grade") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

                <br />
                <div id="paginate" runat="server" class="container">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <a id="a_pre" class="prenext" href="#" runat="server" onserverclick="a_front_ServerClick"><-上一页</a>
                        <a id="a_1" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">1</a>
                        <a id="a_2" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a>
                        <a id="a_3" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a>
                        <a id="a_4" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a>
                        <a id="a_5" class="pagenum" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a>
                        <a id="a_6" runat="server">....</a>
                        <a id="a_next" class="prenext" href="#" runat="server" onserverclick="a_last_ServerClick">下一页-></a>
                        <label>共有</label>
                        <label id="allpage" runat="server"></label>
                        <label>页</label>
                        <label id="nowpageindex" runat="server" style="display: none">1</label>
                        <label>第</label><label id="nowpagenum" runat="server">1</label><label>页</label>
                    </div>
                </div>

                </div>
    </form>
</body>
</html>
