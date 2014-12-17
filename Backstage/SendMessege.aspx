<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="SendMessege.aspx.cs" Inherits="Web_SendMessege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link href="../Web/css/bootstrap.min.css" rel="stylesheet" />
  <link href="../Web/fonts/css/font-awesome.min.css" rel="stylesheet" />
  <link rel="stylesheet" href="../Web/css/jquery.qeditor.css" type="text/css" />
  <style type="text/css" media="screen">
  .textarea {
    background-color: #ffffff;
    border: 1px solid #cccccc;
    -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
    -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
    box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
    -webkit-transition: border linear .2s, box-shadow linear .2s;
    -moz-transition: border linear .2s, box-shadow linear .2s;
    -o-transition: border linear .2s, box-shadow linear .2s;
    transition: border linear .2s, box-shadow linear .2s;
    padding: 4px 6px;
    font-size: 14px;
    line-height: 20px;
    color: #555555;
    -webkit-border-radius: 4px;
    -moz-border-radius: 4px;
    border-radius: 4px;
    vertical-align: middle;
    outline: none;
    height: 400px;
  }
  </style>
  <script src="../Web/js/jquery.min.js" type="text/javascript"></script>
  <script src="../Web/js/jquery.qeditor.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" class="form-horizontal">
  <div class="container">
      
    <h2>发送邮件</h2>
      <h4 id="t_name" runat="server"></h4>
    
      <div class="control-group">
        <label class="control-label" >Title</label>
        <div class="controls">
          <input type="text"  id="title" runat="server" placeholder="Type your title" />
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" >Body</label>
        <div class="controls">
           <textarea id="post_body" runat="server" name="body" class="textarea" placeholder="Type your post"></textarea>
        </div>
      </div>
      <div class="control-group">
        <div class="controls">
          <button type="submit" id="submit" class="btn btn-success" runat="server" onserverclick="submit_ServerClick">确认发送</button>  
          <button class="btn" id="back" runat="server" onserverclick="back_ServerClick" >取消</button>
        </div>
      </div>
    
    <script type="text/javascript">
        $("#post_body").qeditor({});

        // Custom a toolbar icon
        var toolbar = $("#post_body").parent().find(".qeditor_toolbar");
        var link = $("<a href='#'><span class='icon-smile' title='smile'></span></a>");
        link.click(function () {
            alert("Put you custom toolbar event in here.");
            return false;
        });
        toolbar.append(link);

        // Custom Insert Image icon event
        function changeInsertImageIconWithCustomEvent() {
            var link = toolbar.find("a.qe-image");
            link.attr("data-action", "");
            link.click(function (e) {
                alert("New insert image event");
                return false;
            });
            alert("Image icon event has changed, you can click it to test");
            return false;
        }

        $("#submit").click(function () {
            alert($("#post_body").val());
        });
    </script>
  </div>
        </form>
</body>
</html>
