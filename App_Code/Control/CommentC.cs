using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// CommentC 的摘要说明
/// </summary>
public class CommentC
{
	public CommentC()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}


    private TutorDao tu = new TutorDao();
    private TutorCommentDao tuC = new TutorCommentDao();
    private ReservationDao rec = new ReservationDao();
    private CommentDao cc = new CommentDao();

    private int allnum = 0;


    //private DataSet allds;
    public string GetComment(string tutorid, string filename,int pagesize,int pagenum)
    {
        DataSet ds = tuC.GetTutorComment(tutorid);
        int num = allnum = ds.Tables[0].Rows.Count;
        string re = "";
        for (int i = (pagenum - 1) * pagesize; i < pagenum * pagesize && i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            string recid = dr["ReservationID"].ToString();
            string time = dr["Time"].ToString();
            string star = dr["Start"].ToString();
            string comment = dr["Comment"].ToString();
            DataSet per = rec.GetRecPersonInfo(recid);
            DataSet dscour = rec.GetRecCourse(recid);
            string name="";
            string grade = "";
            string course = "";
            if (per.Tables[0].Rows.Count > 0)
            {
                name = per.Tables[0].Rows[0]["StuName"].ToString();
            }
            if (dscour.Tables[0].Rows.Count > 0)
            {
                 grade = dscour.Tables[0].Rows[0]["Grade"].ToString();
                 for (int j = 0; j < dscour.Tables[0].Rows.Count; j++)
                 {
                     course += dscour.Tables[0].Rows[j]["CourseName"].ToString() + ",";
                 }
            }
            string extra = time+"  "+"课程："+course+"  年级:"+grade;
            re += GetCommentTemp(name, int.Parse(star), comment, extra, filename);
        }
        return re;

    }

    public string GetRandomCommentHTML(string path, string tid){
        string node = Util.ReadInfoFromXML(path, "random_comment");
        string html = "";
        DataSet ds = cc.GetRandomComments(tid);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string[] str = new string[6];
            str[0] = ds.Tables[0].Rows[i]["Comment"].ToString();
            str[1] = "label_" + i;
            str[2] = ds.Tables[0].Rows[i]["Start"].ToString();
            str[3] = "star_" + i;
            str[4] = ds.Tables[0].Rows[i]["Name"].ToString();
            str[5] = ds.Tables[0].Rows[i]["Time"].ToString();
            html += string.Format(node, str);
        }
        return html;
    }

    public int GetAllNodeNum()
    {
        return allnum;
    }



   

    private string GetCommentTemp(string name, int star, string content, string extrainfo, string filename)
    {
        string restar = Util.GetStar(star);
        string temp = Util.ReadInfoFromXML(filename, "comment");
        string re = string.Format(temp, name, restar, content, extrainfo);
        return re;
    }


}