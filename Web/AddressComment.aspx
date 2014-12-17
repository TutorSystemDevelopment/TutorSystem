<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddressComment.aspx.cs" Inherits="Web_AddressComment" %>

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
    <script>

        $(document).ready(function () {

            var tutorid = "1";
            var commenturl = "Comment.aspx?tutorid=" + tutorid;

            var frame = "<iframe name=\"right\" id=\"rightMain\" src=\"" + commenturl + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1200px\" allowtransparency=\"true\"/>";

            $("#li_comment").click(function () {

                $("#main").html(frame);

            })
            var resframe = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "TutorOrder.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";

            $("#li_res").click(function () {
                $("#main").html(resframe);
            })

            var notiframe = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "Timeline.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";

            $("#li_timeline").click(function () {
                $("#main").html(notiframe);
            })

            var baicinfo = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "basicInfo.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_basicinfo").click(function () {
                $("#main").html(baicinfo);
            })
            var pubarticle = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "articlePub.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"1500px\" allowtransparency=\"true\"/>";
            $("#li_pubarticle").click(function () {
                $("#main").html(baicinfo);
            })

            var select = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "SelectClass.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"700px\" allowtransparency=\"true\"/>";
            $("#li_selectclass").click(function () {
                $("#main").html(select);
            })

            var modify = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "Chatlist.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"700px\" allowtransparency=\"true\"/>";
            $("#li_notification").click(function () {
                $("#main").html(modify);
            })

            var infoedit = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "tutorDetailEdit.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"700px\" allowtransparency=\"true\"/>";
            $("#li_infoedit").click(function () {
                $("#main").html(infoedit);
            })

            var articlePub = "<iframe name=\"right\" id=\"rightMain\" src=\"" + "articlePub.aspx" + "\" frameborder=\"no\" scrolling=\"auto\" width=\"100%\" height=\"700px\" allowtransparency=\"true\"/>";
            $("#li_pubarticle").click(function () {
                $("#main").html(articlePub);
            })
        })
    </script>
    <style>
 .functions .demo {
  margin-bottom: 10px;
}

.functions .item {
  background-color: #FEFEFE;
  border-radius: 4px;
  display: inline-block;
  margin-bottom: 5px;
  padding: 5px 10px;
}

.functions .item a {
  border: 1px solid #CCC;
  margin-left: 10px;
  padding: 5px;
  text-decoration: none;
}

.functions .item input {
  display: inline-block;
  margin-left: 2px;
  padding: 5px 6px;
  width: 120px;
}

.functions .item label {
  display: inline-block;
  font-size: 1.1em;
  font-weight: bold;
}

.hint {
  text-align: center;
  width: 160px
}

div.hint {
  font-size: 1.4em;
  height: 46px;
  margin-top: 15px;
  padding: 7px
}

.white {
  background-color: #FFF
}
</style>
<link rel="stylesheet" href="lib/jquery.raty.css"/>
</head>
    <body>
    <form id="form1" runat="server">

        <div class="parent_block" style="margin-top:10px;padding-left:0px;padding-bottom:10px;padding-right:0px;background-color:#f6f6f6;min-height:500px;max-height:800px;">
            <div class="half_parent">
                <h4 style="font-weight:600;text-align:left;padding-top:5px;padding-bottom:5px;">其他学生，需要你的宝贵建议哦！</h4>
                <span style="float:left;padding:5px;padding-top:0px;color:red">教学评分：</span>
                <div id="rating" style="text-align:left" runat="server"></div>
                <%--<textarea runat="server" id="hidrating"></textarea>--%>
                <input type="hidden" runat="server" id="hidrating" />
                <textarea id="comment" runat="server" class="form-control" style="height:200px;width:100%;margin-left:5px;margin-top:5px;" onfocus="if (value =='说点什么吧...'){value =''}"
    onblur="if (value ==''){value='说点什么吧...'}">说点什么吧...</textarea>
                <asp:Label ID="lb_recid" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="lb_tutorid" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="lb_stuid" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Button class="generalbtn" style="float:right" ID="Button1" runat="server"  Text="提交评价" OnClick="Submit_ServerClick" />
            </div>
            <div id="Div1" class="half_parent" runat="server">
                <h4 style="background-color:#ebebeb;text-align:center;padding-top:5px;padding-bottom:5px;">其他人对TA的评价</h4>
                <div class="all_parent" runat="server" id ="ranComments">
                </div>
            </div>
        </div>

    </form>
    <%--浮动框的效果--%>
    <script type="text/javascript" src="js/scrolltool.js"></script>
    <script>
        $('.dropdown').tendina({
            animate: true,
            speed: 500,
            openCallback: function ($clickedEl) {
                console.log($clickedEl);
            },
            closeCallback: function ($clickedEl) {
                console.log($clickedEl);
            }
        })
    </script>
    <script type="text/ecmascript" src="lib/jquery.raty.js"></script>
    <script>
        $.fn.raty.defaults.path = 'lib/images';
        $(function () {
            $('#rating').raty({
                click: function (score, evt) {
                    document.getElementById('hidrating').value = score;
                }
            });
            $("[id^=label_]").each(function () {
                var star;
                star = parseInt($(this).text());
                var pre = $(this).attr("id");
                var num = pre.split("_")[1];
                var starid = "#star_" + num;
                $(starid).raty({ readOnly: true, score: star });
            });

        });
    </script>
</body>

</html>
