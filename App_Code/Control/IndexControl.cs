using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// IndexControl 的摘要说明
/// </summary>
public class IndexControl
{
	public IndexControl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private NewsDao ne = new NewsDao();
    private TutorDao tu = new TutorDao();


    public string GetTopNewHtml(string FilePath)
    {

        string xmlpath = FilePath + "Web\\Content.xml";
        

        string html = Util.ReadInfoFromXML(xmlpath, "index_newstop");
        DataSet ds = ne.GetTopNews();
        int rowscount = ds.Tables[0].Rows.Count;
        int culcount=ds.Tables[0].Columns.Count;
        if (rowscount <= 0)
            return null;
        string[] str = new string[15];

        for (int j = 0; j < rowscount; j++)
        {
            str[j * 2] = ds.Tables[0].Rows[j]["Title"].ToString();
            str[j * 2 + 1] = "../images/" + ds.Tables[0].Rows[j]["TitlePic"].ToString();
            str[j + 10] = "news.aspx?newsid=" + ds.Tables[0].Rows[j]["NewsID"].ToString();
        }

        html = string.Format(html, str);
        //Console.Write(html);
        return html;

    }



    public string GetTopTutorHtml()
    {
        string html = Util.ReturnTutorTopItems();
        string re = "";
        DataSet ds=tu.GetTopTutor();
        if (ds == null)
        {
            return null;
        }
        int rowcount=ds.Tables[0].Rows.Count;
        DataRow dr;
        string url = "IndexPart2.aspx?toptutor=";
        //string linkid = "tutor_";
        for(int i=0;i<rowcount;i++)
        {
            //"&tagname=tutorinfo"
            dr=ds.Tables[0].Rows[i];
            string id = dr["TutorID"].ToString();
            string goodclass = GetGoodClass(id);
            goodclass="擅长科目："+goodclass;
            re += string.Format(html, url + id + "&tagname=tutorinfo", dr["name"].ToString(), dr["University"], goodclass, "../images/" + dr["IndexPic"].ToString());
        }
        return re;
    }



    private string GetGoodClass(string id)
    {
        DataSet ds = tu.GetTutorClassInfo(id);
        string tmep = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            tmep += ds.Tables[0].Rows[i]["CourseName"].ToString()+",";
            //if (i / 2 > 0&&i%2==0&&i!=ds.Tables[0].Rows.Count-1)
            //{
            //    tmep += "<br/>";
            //}
        }
        if(!tmep.Trim().Equals(""))
            tmep=tmep.Remove(tmep.LastIndexOf(',') );
        return tmep;
    }

    public DataRow GetTutorIntro(string id)
    {
        if (tu.GetTutorByID(id).Tables[0].Rows.Count <= 0)
        {
            return null;
        }
        DataRow dr = tu.GetTutorByID(id).Tables[0].Rows[0];
        return dr;
    }



}