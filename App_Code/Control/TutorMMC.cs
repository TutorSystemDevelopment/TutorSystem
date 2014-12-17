using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// TutorMMC 的摘要说明
/// </summary>
public class TutorMMC
{
	public TutorMMC()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}


    private TutorDao tu = new TutorDao();
    private DataSet allds;
    private UserDao us = new UserDao();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Filepath"></param>
    /// <param name="pagenum"></param>
    /// <param name="flag"> 0 all,1 pass,2 not pass</param>
    /// <returns></returns>
    public string GetTutorNode(string Filepath, int pagenum,int pagesize,int flag)
    {
        string html = Util.ReadInfoFromXML(Filepath, "MenegeTutorNode");
        string re = "";

        string display="display:none";
        
        DataSet ds = null; ;
        if (flag == 0)
            ds = tu.GetSingleTutor();
        else if (flag == 1)
            ds = tu.GetPassTutor();
        else if (flag == 2)
            ds = tu.GetNotPassTutor();
        else if (flag == 3)
            ds = tu.GetAllTopTutor();
        else if (flag == 4) 
            ds = tu.GetAllIndexTopTutor();
            if (ds != null)
            {
                allds = ds;
                for (int i = (pagenum - 1) * pagesize; i < pagenum * pagesize && i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    int rank = int.Parse(dr["Rank"].ToString());
                    string temp = "";
                    Boolean b = tu.TutorIsTop(dr["TutorID"].ToString());
                    if (rank >= 0)
                        temp = "已通过审核";
                    else
                        temp = "未通过审核";
                    string uuid = us.GetUUIDByIDAndType(dr["TutorID"].ToString(), "1");
                    re += string.Format(html, "../images/" + dr["Photo"], dr["University"], dr["Gender"], dr["Name"], dr["Intro"], temp, dr["TutorID"], pagenum, rank >= 0 ? "" : display, b ? "" : display, uuid, dr["Phone"]);
                }
            }
        return re;

    }


    public int GetALLNodeNum()
    {
        return allds.Tables[0].Rows.Count;

    }

   
}