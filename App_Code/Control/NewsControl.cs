using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// NewsControl 的摘要说明
/// </summary>
public class NewsControl
{
    public NewsControl()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private NewsDao ne = new NewsDao();
    private TutorDao tu = new TutorDao();

    public string GetNewsHtmlById(string filePath, string newsId) {
        string xmlpath = filePath + "Web\\Content.xml";

        string html = Util.ReadInfoFromXML(xmlpath, "news_body");
        DataSet ds = ne.GetNewsById(newsId);

        string[] str = new string[6];

        str[0] = ds.Tables[0].Rows[0]["Title"].ToString();
        str[1] = "../images/" + ds.Tables[0].Rows[0]["TitlePic"].ToString();
        str[2] = ds.Tables[0].Rows[0]["Date"].ToString();
        str[3] = ds.Tables[0].Rows[0]["Author"].ToString();
        str[4] = ds.Tables[0].Rows[0]["Click"].ToString();
        str[5] = ds.Tables[0].Rows[0]["Body"].ToString();

        html = string.Format(html, str);
        //Console.Write(html);
        return html;
    }
    public string GetTagsHtmlById(string newsId)
    {
        string html = "<h4>标签</h4>";
        string sufHtml = "<div class=\"clearfix\"></div>";
        DataSet ds = ne.GetAllTags();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
        {
            if (IsTagRelated(newsId, ds.Tables[0].Rows[i]["TagID"].ToString()))
                html += "<li class=\"active\"><a href=\"#\">" + 
                    ds.Tables[0].Rows[i]["TagName"].ToString() +"</a></li>";
            else
                html += "<li><a href=\"#\">" +
                    ds.Tables[0].Rows[i]["TagName"].ToString() + "</a></li>";
        }
        html += sufHtml;
        return html;
    }
    public bool IsTagRelated(string newsId, string tagId) {
        DataSet ds = ne.GetTagsByNewsId(newsId);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string temp = ds.Tables[0].Rows[i]["TagID"].ToString();
            if (tagId.Equals(temp))
                return true;
        }
        return false;
    }
    public string GetTopNewHtml(string FilePath)
    {

        string xmlpath = FilePath + "Web\\Content.xml";


        string html = Util.ReadInfoFromXML(xmlpath, "index_newstop");
        DataSet ds = ne.GetTopNews();
        int rowscount = ds.Tables[0].Rows.Count;
        int culcount = ds.Tables[0].Columns.Count;

        string[] str = new string[15];

        for (int j = 0; j < rowscount; j++)
        {
            str[j * 2] = ds.Tables[0].Rows[j]["Title"].ToString();
            str[j * 2 + 1] = "../images/" + ds.Tables[0].Rows[j]["TitlePic"].ToString();
        }
        for (int j = 10; j < 15; j++)
        {
            str[j] = "#";
        }

        html = string.Format(html, str);
        //Console.Write(html);
        return html;

    }

    
    public string GetTeacherAdsHtml()
    {
        string html = "<h4>推荐教师</h4>";
        string sufHtml = "<div class=\"clearfix\"></div>";
        DataSet ds = tu.RandomRecommend(4);
        if (ds.Tables[0].Rows.Count>0)
        {
            for (int i = 0; i < 4 && i < ds.Tables[0].Rows.Count; i++)
            {
                string src = "../images/" + ds.Tables[0].Rows[i]["IndexPic"].ToString();
                string link = "teacherDetails.aspx?tutorId="
                    + ds.Tables[0].Rows[i]["TutorID"].ToString();
                html += "<li><a href=\"" + link
                    + "\"><img style=\"height:100%;\" src=\"" + src + "\" class=\"teacherAds\"/> </a></li>";
            }
            html += sufHtml;
        }
        return html;
    }



    public string GetTopTutorHtml()
    {
        string html = Util.ReturnTutorTopItems();
        string re = "";
        DataSet ds = tu.GetTopTutor();
        int rowcount = ds.Tables[0].Rows.Count;
        DataRow dr;
        string url = "IndexPart2.aspx?toptutor=";
        //string linkid = "tutor_";
        for (int i = 0; i < rowcount; i++)
        {
            //"&tagname=tutorinfo"
            dr = ds.Tables[0].Rows[i];
            string id = dr["TutorID"].ToString();
            string goodclass = GetGoodClass(id);
            goodclass = "擅长科目：" + goodclass;
            re += string.Format(html, url + id + "&tagname=tutorinfo", dr["name"].ToString(), dr["University"], goodclass, "../images/test.jpg");
        }
        return re;
    }



    private string GetGoodClass(string id)
    {
        DataSet ds = tu.GetTutorClassInfo(id);
        string tmep = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            tmep += ds.Tables[0].Rows[i]["CourseName"].ToString() + ",";
            //if (i / 2 > 0&&i%2==0&&i!=ds.Tables[0].Rows.Count-1)
            //{
            //    tmep += "<br/>";
            //}
        }
        if (!tmep.Trim().Equals(""))
            tmep = tmep.Remove(tmep.LastIndexOf(','));
        return tmep;
    }

    public DataRow GetTutorIntro(string id)
    {
        DataRow dr = tu.GetTutorByID(id).Tables[0].Rows[0];
        return dr;
    }

    public void AddClick(string newsId) 
    {
        ne.AddClick(newsId);
    }



    public string GetAuthor(string newid)
    {
        //string html = Util.ReturnTutorTopItems();
        string re = "";
        DataSet ds = tu.GetTutorByNewid(newid);
        if (ds == null) return "";

        int rowcount = ds.Tables[0].Rows.Count;
        DataRow dr;
        string url = "teacherDetails.aspx?tutorid=";
        //string linkid = "tutor_";
        for (int i = 0; i < rowcount; i++)
        {
            //"&tagname=tutorinfo"
            dr = ds.Tables[0].Rows[i];
            string id = dr["TutorID"].ToString();
            string goodclass = GetGoodClass(id);
            //goodclass = "擅长科目：" + goodclass;
            re += Util.ReNewAuthor(dr["Photo"].ToString(), url + id, dr["Name"].ToString(), dr["University"].ToString(), goodclass);
            break;
        }
        return re;
    }

}