using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


using System.Data;
using System.Collections;
/// <summary>
/// DetailsControl 的摘要说明
/// </summary>
public class DetailsControl
{
	public DetailsControl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    


    private TutorDao tu = new TutorDao();
    private ReservationDao res = new ReservationDao();
    public string GetGradeBTHtml(string id)
    {
        StringBuilder html=new StringBuilder();
        string bt="gra_bt";
        DataSet ds = tu.GetTutorClassInfo(id);
        ArrayList temp = new ArrayList();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string grade=ds.Tables[0].Rows[i]["Grade"].ToString();
            if (!temp.Contains(grade))
            {
                html.Append(Util.ReturnDetailsBT(bt + i + 1, grade));
                temp.Add(grade);
            }
        }
        //html.Append(Util.ReturnDetailsBT(bt + 2, "Middle"));
        //html.Append(Util.ReturnDetailsBT(bt + 3, "Senior"));
        return html.ToString();
        //return temp;

    }

    //private DataSet classinfo;


    public string GetCourseBTHtml(string id)
    {
        DataSet ds = tu.GetTutorClassInfo(id);
        StringBuilder html = new StringBuilder();
        ArrayList temp = new ArrayList();
        string bname = "course_bt";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (!temp.Contains(ds.Tables[0].Rows[i]["CourseName"].ToString()))
            {
                temp.Add(ds.Tables[0].Rows[i]["CourseName"].ToString());
                html.Append(Util.ReturnDetailsBT(bname + i, ds.Tables[0].Rows[i]["CourseName"].ToString()));
            }
        }
        return html.ToString();
    }


    

    public ArrayList GetCourseBT(string id)
    {
        DataSet ds = tu.GetTutorClassInfo(id);
        ArrayList list = new ArrayList();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            list.Add(ds.Tables[0].Rows[i]["CourseName"].ToString());
        }
        return list;
    }



    public DataSet GetCourseBTByid(string id)
    {
        DataSet ds = tu.GetTutorClassInfo(id);
        return ds;
    }

    public DataRow GetTutorBYID(string id)
    {
        DataSet ds = tu.GetTutorByID(id);
        return ds.Tables[0].Rows[0];

    }

    public string GetAdvice(string id)
    {
        DataSet ds = tu.GetTopTutorByID(id);
        string advice = "";
        if(ds.Tables[0].Rows.Count > 0)
            advice = ds.Tables[0].Rows[0]["Advice"].ToString();
        string re = "";
        if (!advice.Trim().Equals(""))
        {
            re = Util.ReRecommend(advice);

        }
        return re ;
    }


    public string GetTimeLineHtml(string tutorid)
    {
        DataSet ds = tu.GetTutorTimeLineByOrder(tutorid);
        string re = "";
        if (ds != null)
        {
            
            int rowcount = ds.Tables[0].Rows.Count;
            //DataRow dr=ds.Tables[0].Rows
            string lastyear = "";
            string node="";
            
            for (int i = 0; i < rowcount; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                if (!lastyear.Equals(dr["Year"].ToString()))
                {
                    if (!node.Equals(""))
                    {
                        re += Util.GetYearNodeTimeLine(lastyear, node);
                    }
                    lastyear = dr["Year"].ToString();
                    node = "";
                }
                node+=Util.GetNodeTimeLine(dr["Month"].ToString()+"月",dr["Title"].ToString(),dr["Items"].ToString());
            }
            re += Util.GetYearNodeTimeLine(lastyear, node);


        }
        return re;
    }

    public void InsertReservation(string tutorid, string stuid, string course, string grade)
    {
        res.InsertReservationAndCourse(tutorid, stuid, course, grade);
    }



}