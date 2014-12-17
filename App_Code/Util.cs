using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// Util 的摘要说明
/// </summary>
public class Util
{
    public Util()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }





    public static string ShowMessage(string s, string url)
    {
        string str;
        str = "<script language=javascript>alert('" + s + "');location='" + url + "'</script>";
        return str;
    }

    public static string ShowMessage(string s)
    {
        string str;
        str = "<script language=javascript>alert('" + s + "');</script>";
        return str;
    }


    #region index.aspx
    /// <summary>
    /// 得到老师的滚动条的信息
    /// </summary>
    /// <returns></returns>
    public static string ReturnTutorTopItems()
    {
        StringBuilder str = new StringBuilder();
        str.Append("<div class=\"item\">");
        str.Append("<div class=\"cau_left\"><img class=\"lazyOwl\" src=\"{4}\" style=\"height:220px;\" alt=\"Lazy Owl Image\"></div>");
        //str.Append("<img class=\"lazyOwl\" src=\"../images/test.jpg\" alt=\"Lazy Owl Image\">");
        str.Append("<div class=\"cau_left\"><h4><a href=\"{0}\">{1}</a></h4><p>{2}<br />{3}</p></div>");
        str.Append("</div>");
        return str.ToString();

    }



    public static string ReturnNewTop2()
    {
        StringBuilder str = new StringBuilder();
        str.Append(" <div style=\"position:relative;\" >");
        str.Append("<div  style=\"position:absolute;z-index:1000;top:340px;left:60px;\" >");
        str.Append(" <h2><a  href=\"{0}\" class=\"newa\">{1}</a></h2> </div>");
        str.Append("<a href=\"{2}\"><img  src=\"{3}\" alt=\"\" class=\"col-md-6 test-1 zoomimg\" /></a>");
        str.Append("</div>");
        return str.ToString();
    }

    #endregion


    /// <summary>
    /// 返回contene.xml
    /// 定义的html
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="nodename"></param>
    /// <returns></returns>
    public static string ReadInfoFromXML(string filename, string nodename)
    {
        //ArrayList str = new ArrayList();
        Dictionary<string, string> dic = new Dictionary<string, string>();

        XmlDocument xml = new XmlDocument();
        try
        {
            xml.Load(filename);
            XmlNode root = xml.SelectSingleNode("root");
            XmlNode xnl = root.SelectSingleNode(nodename);

            string TopNewsHtml = xnl.InnerText;
            return TopNewsHtml;
        }
        catch (Exception e)
        {
            throw e;
        }

    }


    /// <summary>
    /// 得到导师的grade和course 按钮html
    /// </summary>
    /// <returns></returns>
    public static string ReturnDetailsBT(string id, string content)
    {
        string html = "<button id=\"{0}\" class=\"selectbutton\">{1}</button>";
        //string html = "<asp:Button ID=\"{0}\" runat=\"server\" Text=\"{1}\" OnClick=\"GraBT_click\"  ></asp:Button> ";
        return string.Format(html, id, content);

    }

    /// <summary>
    /// 得到搜索的按钮
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ReTurnSearchBT(string id, string text)
    {
        string html = "<button id=\"{0}\" class=\"searchbutton\" runat=\"server\"   onserverclick=\"bt_course_ServerClick\" style=\"height:30px;margin-left:30px;\">{1}</button>";
        //string html="<a id=\"{0}\" class=\"searchbutton\" href=\"#\" style=\"text-decoration:none;height:30px;margin-left:30px;\"> {1}</a>";
        return string.Format(html, id, text);

    }


    /// <summary>
    /// new  界面 作者绑定
    /// </summary>
    /// <param name="image"></param>
    /// <param name="href"></param>
    /// <param name="name"></param>
    /// <param name="uni"></param>
    /// <param name="course"></param>
    /// <returns></returns>
    public static string ReNewAuthor(string image,string href,string name,string uni,string course)
    {
        string html = "<div class=\"cau_left\"><a href=\"{1}\"><img style=\"weight:220px;height:220px;\" class=\"lazyOwl\" src=\"../images/{0}\" alt=\"Lazy Owl Image\"/><a/></div><div class=\"cau_left\"><h4><a href=\"{1}\">{2}</a></h4><p>{3}<br />擅长科目：{4}</p></div>";
        string re = string.Format(html, image, href, name, uni, course);
        return re;
    }

    /// <summary>
    ///  教师详细信息 的极致推荐
    /// </summary>
    /// <param name="commend"></param>
    /// <returns></returns>
    public static string ReRecommend(string commend)
    {
        string html = "<label class=\"redtitile\">极致推荐</label>"
                    + "<p  class=\"para\">{0} </p>";
        return string.Format(html, commend);
    }





#region  detail.aspx
    public static string GetNodeTimeLine(string time,string title,string content)
    {
        string html = "<li class=\"cls highlight\"><p class=\"date\">{0}</p><p class=\"intro\">{1}</p><p class=\"version\">&nbsp;</p><div class=\"more\"><p>{2}</p></div></li>";
        return string.Format(html, time,title, content);
    }

    public static string GetYearNodeTimeLine(string year,string NodeContent)
    {
        string html = "  <div class=\"year\"><h2><a href=\"#\">{0}<i></i></a></h2><div id=\"timeline_month\" class=\"list\" ><ul>{1}</ul></div></div>";
        return string.Format(html,year,NodeContent);
    }
#endregion




    #region allnews.aspx
    public static string GetNewsNode(string imgurl,string url,string title,string content)
    {
        string html="<div class=\"newsitem col-md-12\" >"+
                    "<div class=\"col-md-4\">"+
                       " <img src=\"../images/{0}\" class=\"news_node_img\"/>"+
                    "</div>"+
                    "<div class=\"col-md-8\">"+
                        "<span style=\"font-size:16px;\"><a href=\"{1}\">{2}</a></span>"+
                        "<p>{3}</p>"+
                    "</div>"+
                "</div>";
        return string.Format(html, imgurl,url,title,content);
    }

    public static string GetNewsRoll(string url,string title,string img)
    {
        string html = "<li style=\"height:216px;width:325px;\"><a href=\"{0}\" title=\"{1}\"><img src=\"../images/{2}\" style=\"width:100%\"/></a></li>";
        return string.Format(html, url, title, img);
    }



    public static string GetTopNews(string index,string url,string title)
    {
        string html = "<div  class=\"topnewsitem\">" +
                        "<span style=\"height:20px;width:20px;background-color:red;display:inline-block;text-align:center\">{0}</span>" +
                        "<a href=\"{1}\">{2}</a>" +
                        "<br /></div>";
        return string.Format(html, index, url, title);
    }

    public static string GetTutorNode(string id,string img,string name)
    {
        string html = "<li><a href=\"teacherDetails.aspx?tutorId={0}\" ><img src=\"../images/{1}\" class=\"teacherAds\"/> </a><a href=\"teacherDetails.aspx?tutorId={0}\"><h4 style=\"text-align:center;margin:0px;\">{2}</h4></a></li>";
        return string.Format(html, id, img, name);

    }





    #endregion

    //public static string GetComment(string name, string star, string content, string extrainfo)
    //{

    //    string name = ReadInfoFromXML();

    //}

    /// <summary>
    /// 得到星数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string GetStar(int num)
    {
        string off = "star-off.png";
        string on = "star-on.png";
        string html="<img src=\"../images/{0}\"/>";
        string re = "";
        for (int i = 0; i < num&&i<5; i++)
        {
            re += string.Format(html, on);
        }
        for (int i = num; i < 5; i++)
        {
            re += string.Format(html, off);
        }
        return re;
    }

    public static string GetRegularDate(string date)
    {
        string newdate;
        string[] temp = date.Split('-');
        return null;
    }


}