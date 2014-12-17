using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// AllNewsC 的摘要说明
/// </summary>
public class AllNewsC
{
	public AllNewsC()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        ds = ne.GetAllPassNews();
	}


    private NewsDao ne = new NewsDao();
    private TutorDao tu = new TutorDao();
    private DataSet ds;
    public string GetAllNewsNode(int pageindex,int pagesize)
    {
        string re = "";
        if(ds==null)
            ds = ne.GetAllPassNews();
        int allnum = ds.Tables[0].Rows.Count;
        for (int i = (pageindex - 1) * pagesize; i < pageindex * pagesize&&i<allnum; i++)
        {
            DataRow dr=ds.Tables[0].Rows[i];

            string content = dr["Body"].ToString();
           
            if (content.IndexOf('<') > 0 && content.IndexOf('<') < 130)
            {
                content = content.Substring(0, content.IndexOf('<')) + ".....";
            }
            else if (content.Length > 130)
            {
                content = content.Substring(0, 130) + ".....";
            }
            re += Util.GetNewsNode(dr["TitlePic"].ToString(), "news.aspx?newsid=" + dr["NewsID"].ToString(), dr["Title"].ToString(), content);
        }
        return re;

    }


    public int GetAllNewsNum()
    {
        if (ds != null)
            return ds.Tables[0].Rows.Count;
        else
            return 0;
    }

    public string GetNewsRoll()
    {
        string re = "";
        DataSet rands = ne.GetRDNews(5);
        int allnum = rands.Tables[0].Rows.Count;
        for (int i = 0; i < allnum; i++)
        {
            DataRow dr = rands.Tables[0].Rows[i];
            string title = dr["Title"].ToString();
            if (title.IndexOf("<br/>")>=0)
             title = title.Substring(0, title.IndexOf("<br/>"));
            re += Util.GetNewsRoll("news.aspx?newsid=" + dr["NewsID"].ToString(), title, dr["TitlePic"].ToString());
            //re += Util.GetNewsNode(dr["TitlePic"].ToString(), "news.aspx?newsid=" + dr["NewsID"].ToString(), dr["Title"].ToString(), content);
        }
        return re;

    }

    public string GetTopNews(int num)
    {
        string re = "";
        DataSet rands = ne.GetClickNews(num);
        int allnum = rands.Tables[0].Rows.Count;
        for (int i = 0; i < allnum; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            re += Util.GetTopNews((i + 1).ToString(), "news.aspx?newsid=" + dr["NewsID"].ToString(), dr["Title"].ToString());
            //re += Util.GetNewsNode(dr["TitlePic"].ToString(), "news.aspx?newsid=" + dr["NewsID"].ToString(), dr["Title"].ToString(), content);
        }
        return re;

    }

    public string GetTeacherAdsHtml(int num)
    {
        string re = "";
        DataSet ds = tu.RandomTutor(num);

        for (int i = 0; i < num; i++)
        {
            DataRow dr=ds.Tables[0].Rows[i];
            re += Util.GetTutorNode(dr["TutorID"].ToString(), dr["Photo"].ToString(), dr["Name"].ToString());
        }
        
        return re;
    }


}