using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_news : System.Web.UI.Page
{
    private string newsId = "8";
    private NewsControl ne = new NewsControl();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            newsId = Request.QueryString["newsid"] == null ? "8" : Request.QueryString["newsid"];
            BindHead();
            BindBody();
            BindTags();
            BindTeacherAds();
            BindAuthor();
            BindFooter();
            ne.AddClick(newsId);
        }
    }


    private void BindAuthor()
    {
        string html=ne.GetAuthor(newsId);
        if (!html.Trim().Equals(""))
        {
            html = "<h2 style=\"color:red\">文章人物</h2><br/>" + html;
            author.InnerHtml = html;
        }
    }

    private void BindHead()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        string html = Util.ReadInfoFromXML(FilePath, "head");
        string usertype = Session["usertype"] == null ? "-1" : Session["usertype"].ToString();
        string ty = "";
        string name = "";
        if (usertype.Equals("-1"))
        {
            A_ModifyInfo.HRef = "login.aspx";
            ty = "游客  ";
            name = "请登录>>>";
        }
        else if (usertype.Equals("0"))
        {
            A_ModifyInfo.HRef = "StuInfoMenegement.aspx";
            ty = "学生  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("1"))
        {
            A_ModifyInfo.HRef = "infoManagement.aspx";
            ty = "老师  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("2"))
        {
            A_ModifyInfo.HRef = "../Backstage/teacherManagement.aspx";
            ty = "管理员  ";
            name = "";
        }
        navbar.InnerHtml = string.Format(html, ty, name);
    }

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }
    private void BindBody() {
        string filePath = Server.MapPath("..//");
        string html = ne.GetNewsHtmlById(filePath, this.newsId);
        newsbody.InnerHtml = html;
    }
    private void BindTags() {
        string html = ne.GetTagsHtmlById(this.newsId);
        newstag.InnerHtml = html;
    }
    private void BindTeacherAds()
    {
        string html = ne.GetTeacherAdsHtml();
        teacherAds.InnerHtml = html;
    }
}