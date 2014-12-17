<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuReservation.aspx.cs" Inherits="Web_StuReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../images/icon.ico" rel="icon" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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
        .auto-style3 {
            width: 144px;
        }
        .auto-style4 {
            width: 207px;
        }
        .auto-style6 {
            width: 162px;
        }
        .auto-style7 {
            width: 170px;
        }
        .auto-style8 {
            width: 108px;
        }
        .activebtn {
            color:blue;
        }
        .activebtn:hover {
            color:red;
        }
        .auto-style9 {
            width: 108px;
            height: 12px;
        }
        .auto-style10 {
            width: 170px;
            height: 12px;
        }
        .auto-style11 {
            width: 162px;
            height: 12px;
        }
        .auto-style12 {
            width: 207px;
            height: 12px;
        }
        .auto-style13 {
            height: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3 style="border-top: 2px #ff4401 solid; text-align: center; margin-top: 0px; padding: 7px; background-color: #f7f7f7;">我的预约</h3>
        <div class="blockdiv">


            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
                <ItemTemplate>
                    <div class=" reseritem" style="width: 870px">
                        <div class="resertitle">
                            <div class="" style="float: left;">
                                <span style="margin-right: 10px; padding-left: 19px;">预约时间：</span><asp:Label ID="lb_time" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Time") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 预约状态：<asp:Label ID="lb_state" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ispass") %>'></asp:Label>
                                &nbsp;<asp:Label ID="lb_tutorid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TutorID") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lb_resid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ReservationID") %>' Visible="False"></asp:Label>
                            </div>
                            <div class="" style="text-align: right;">
                                &nbsp;<asp:LinkButton ID="bt_send" runat="server" CommandName="send">发送私信</asp:LinkButton>
                                <asp:LinkButton ID="bt_comment" runat="server" CommandName="comment"> 教师评论</asp:LinkButton>
                                &nbsp;
                            <asp:LinkButton ID="lb_delete" runat="server" CommandName="delete" OnClientClick="javascript:return confirm('确定取消预约吗?')">删除预约</asp:LinkButton>
                            </div>
                        </div>
                        <div class="" style="padding-top: 20px; top: 0px; left: 0px; width: 866px;">
                            <table style="width: 870px; text-align: center;">
                                <tr style="font-family: 'Microsoft YaHei'; color: red;">
                                    <th class="auto-style8" style="text-align: center;">老师姓名</th>
                                    <th class="auto-style7" style="text-align: center;">大学</th>
                                    <th class="auto-style6" style="text-align: center;">联系方式</th>
                                    <th class="auto-style4" style="text-align: center;">科目</th>
                                    <th class="auto-style22" style="text-align: center;">年级</th>
                                    <th class="auto-style22" style="text-align: center;">查看详情</th>
                                </tr>
                                <tr style="font-family: 'Microsoft YaHei'; color: red;">
                                    <th class="auto-style9" style="text-align: center;"></th>
                                    <th class="auto-style10" style="text-align: center;"></th>
                                    <th class="auto-style11" style="text-align: center;"></th>
                                    <th class="auto-style12" style="text-align: center;"></th>
                                    <th class="auto-style13" style="text-align: center;"></th>
                                    <th class="auto-style13" style="text-align: center;"></th>
                                </tr>
                                <tr>
                                    <td class="auto-style8">
                                        <asp:Label ID="lb_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:Label ID="lb_Uni" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"University") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style6">
                                        <asp:Label ID="lb_phone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lb_course" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:Label ID="lb_grade" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Grade") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:LinkButton CommandName="check" runat="server" CssClass="activebtn"><i style="color:gray" class="fa-search fa"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
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



    </div>
    </form>
</body>
</html>
