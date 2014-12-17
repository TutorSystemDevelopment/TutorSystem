<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservationManagement.aspx.cs" Inherits="Backstage_ReservationManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link href="../images/icon.ico" rel="icon" />
<title>极致141</title>
<!-- Bootstrap -->
<link href="../Web/css/bootstrap.css" rel='stylesheet' type='text/css' />
<link href="../Web/css/mystyle.css" rel="stylesheet" type="text/css" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
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

    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
       
    <div id="head" runat="server">

    </div>


    <div id="main" class="container">
        
         <div id="tab_bt">
                <ul class="tabpanel">
                    <li class="singletab"><a  id="abt_all"  runat="server" onserverclick="bt_all_Click" href="#tab_bt" class="tablink"><span>全部预约</span></a></li>
                    <li class="singletab"><a id="abt_pass" runat="server" onserverclick="bt_pass_Click" href="#allpage" class="tablink"><span>审核通过</span></a></li>
                    <li class="singletab"><a id="abt_notpass" runat="server" onserverclick="bt_notpass_Click" href="#tab_bt" class="tablink"><span>正在审核</span></a></li>
                    <li class="singletab"><a id="abt_cancel" runat="server" onserverclick="bt_cancel_Click" href="#tab_bt" class="tablink"><span>取消预约</span></a></li>
                    <li class="singletab"><a id="abt_finish" runat="server" onserverclick="abt_finish_ServerClick" href="#tab_bt" class="tablink"><span>完成预约</span></a></li>
                </ul>
        </div>



        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div class="reseritem" >
                    <div class="resertitle">
                        <div class="" style="float: left;">
                            <span style="margin-right: 10px; padding-left: 19px;">预约时间：</span><asp:Label ID="lb_time" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Time") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 预约状态：<asp:Label ID="lb_state" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ispass") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 预订单号：<asp:Label ID="lb_resid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ReservationID") %>'></asp:Label>
                            <asp:Label ID="lb_stuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StuID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lb_tuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TutorID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lb_stumail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StuMail") %>' Visible="False"></asp:Label>
                        </div>
                        <div class="" style="text-align: right;">
                            &nbsp;<asp:LinkButton ID="bt_finish" runat="server" CommandName="finish" OnClientClick="javascript:return confirm('确定结课吗?')">结课</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="bt_check" runat="server" CommandName="pass" OnClientClick="javascript:return confirm('确定通过吗?')">审核通过</asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lb_delete" runat="server" CommandName="delete" OnClientClick="javascript:return confirm('确定取消预约吗?')">取消预约</asp:LinkButton>
                        </div>
                    </div>
                    <div class="" style="padding-top: 20px; top: 0px; left: 0px; width: 1138px;">
                        <table style="width: 1127px; text-align: center;">
                            <tr style="font-family: 'Microsoft YaHei'; color: red;">
                                <th class="auto-style1" style="text-align: center;">学会姓名</th>
                                <th class="auto-style14" style="text-align: center;">住址</th>
                                <th class="auto-style24" style="text-align: center;">监护人</th>
                                <th class="auto-style16" style="text-align: center;">联系方式</th>
                                <th class="auto-style18" style="text-align: center;">科目</th>
                                <th class="auto-style22" style="text-align: center;">年级</th>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lb_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StuName") %>'></asp:Label>
                                </td>
                                <td class="auto-style15">
                                    <asp:Label ID="lb_Address" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StuAddress") %>'></asp:Label>
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
                             <tr style="font-family: 'Microsoft YaHei'; color: red;">
                                    <th class="auto-style1" style="text-align: center;">老师姓名</th>
                                    <th class="auto-style7" style="text-align: center;">QQ</th>
                                    <th class="auto-style6" style="text-align: center;">大学</th>
                                    <th class="auto-style4" style="text-align: center;">联系方式</th>
                                    <th class="auto-style22" style="text-align: center;">性别</th>
                                    <th class="auto-style22" style="text-align: center;">邮箱</th>
                                </tr>
                             <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:Label ID="lb_Uni" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"QQ") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style6">
                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"University") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Phone") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Gender") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style23">
                                        <asp:Label ID="lb_tutormail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Mail") %>'></asp:Label>
                                    </td>
                                </tr>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
            




        </asp:DataList>
       <%--   <ul id="pagenum" runat="server" class="pagination" style="float:right;">
                <li><a id="a_front" href="#" runat="server" onserverclick="a_front_ServerClick">&laquo;</a></li>
                <li><a id="a_1" href="#" runat="server" onserverclick="Unnamed_ServerClick">1</a></li>
                <li><a id="a_2" href="#" runat="server" onserverclick="Unnamed_ServerClick">2</a></li>
                <li><a id="a_3" href="#" runat="server" onserverclick="Unnamed_ServerClick">3</a></li>
                <li><a id="a_4" href="#" runat="server" onserverclick="Unnamed_ServerClick">4</a></li>
                <li><a id="a_5" href="#" runat="server" onserverclick="Unnamed_ServerClick">5</a></li>
                <li><a id="a_last" runat="server" onserverclick="a_last_ServerClick" href="#">&raquo;</a></li>
		      </ul>
            <label id="allpage" runat="server" style="display:none"></label>
            <label id="nowpage" runat="server" style="display:none"></label>--%>
         <div id="paginate" runat="server" class="all_parent" style="height:60px;text-align:right">
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

    </form>
</body>
</html>
