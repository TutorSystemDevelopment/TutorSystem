using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Text;
using System.Collections;

/// <summary>
/// AllteacherControl 的摘要说明
/// </summary>
public class AllteacherControl
{
    public AllteacherControl()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        //ds = tu.GetAllTutor();
    }


    private TutorDao tu = new TutorDao();
    private DataSet allds;

    public string GetTutorNode(string Filepath, int pagenum, int pagesize, string sex, string course, string pri)
    {
        string html = Util.ReadInfoFromXML(Filepath, "allteacher_Node");
        string re = "";

        string imgtemp = "img";
        DataSet ds = GetSearchTutor(sex, course, pri);
        allds = ds;
        for (int i = (pagenum - 1) * pagesize; i < pagenum * pagesize && i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            re += string.Format(html, imgtemp + i, dr["Name"], dr["Intro"], "teacherDetails.aspx?tutorid=" + dr["TutorID"], "../images/" + dr["Photo"], dr["University"], dr["Gender"], dr["RankName"]);
        }
        return re;

    }

    public string GetTutorNodeByName(string Filepath, int pagenum, int pagesize, string tutorname)
    {
        string html = Util.ReadInfoFromXML(Filepath, "allteacher_Node");
        string re = "";
        string imgtemp = "img";
        DataSet ds = tu.GetTutorByName(tutorname);
        allds = ds;
        for (int i = (pagenum - 1) * pagesize; i < pagenum * pagesize && i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = ds.Tables[0].Rows[i];
            re += string.Format(html, imgtemp + i, dr["Name"], dr["Intro"], "teacherDetails.aspx?tutorid=" + dr["TutorID"], "../images/" + dr["Photo"], dr["University"], dr["Gender"]);
        }
        return re;
    }



    public int GetALLNodeNum()
    {
        return allds.Tables[0].Rows.Count;

    }

    public string GetSearchBT(string temp)
    {
        DataSet ds = tu.GetCourseName();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sb.Append(Util.ReTurnSearchBT(temp + i, ds.Tables[0].Rows[i]["CourseName"].ToString()));
        }
        return sb.ToString();
    }

    /// <summary>
    /// 得到搜索后的老师的集合 如果普通查询的话  全部传入“”
    /// </summary>
    /// <param name="sex"></param>
    /// <param name="course"></param>
    /// <param name="pri"></param>
    /// <returns></returns>
    public DataSet GetSearchTutor(string sex, string course, string pri)
    {
        if (!course.Trim().Equals(""))
        {
            course = course.Remove(course.LastIndexOf(','));
            course.Replace(",", "','");
            course = "('" + course + "')";

        }
        return tu.GetSerachTutor(sex, course, pri);
    }

    public ArrayList GetAllCourse()
    {
        DataSet ds = tu.GetCourseName();
        ArrayList ar = new ArrayList();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            ar.Add(ds.Tables[0].Rows[i]["CourseName"]);
        return ar;
    }






}