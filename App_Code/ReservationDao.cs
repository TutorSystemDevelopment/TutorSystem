using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// ReservationDao 的摘要说明
/// </summary>
public class ReservationDao
{
	public ReservationDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    // ~ReservationDao()
    //{
    //    ba.Close();
    //}

    private BasicDao ba = new BasicDao();


    /// <summary>
    /// 得到某个订单的人员信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DataSet GetRecPersonInfo(string id)
    {
        SqlParameter[] pa = { new SqlParameter("@resid", id) };
        DataSet ds= ba.ExecStoredProcedure("ResPersonInfo", pa);
        return ds;
    }

    public DataSet GetRecCourse(string id)
    {
        SqlParameter[] pa = { new SqlParameter("@resid", id)};
        DataSet ds = ba.ExecStoredProcedure("ResCourse", pa);
        return ds;
    }

    /// <summary>
    /// 返回订单学生的基本信息
    /// </summary>
    /// <returns></returns>
    public DataSet GetAllResStuBYTutorID(string id)
    {
        string sql = "select * from ResStu where TutorID=@id order by Time desc";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        DataSet ds = ba.GetDataSet(sql, pa);
        return ds;
    }

    public int GetAllNumResStuBYTutorID(string id)
    {
        string sql = "select count(*) from ResStu where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        string num = ba.ReString(sql, pa, 0);
        return int.Parse(num);
    }

    public DataSet GetTutorAndStuBYStuid(string uid)
    {
        string sql = "select * from TutorAndStu where StuID=@id order by Time desc";
        SqlParameter[] pa = { new SqlParameter("@id", uid) };
        DataSet ds = ba.GetDataSet(sql, pa);
        return ds;
    }

    

    public int GetAllNumResStuBYStuID(string id)
    {
        string sql = "select count(*) from TutorAndStu where StuID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        string num = ba.ReString(sql, pa, 0);
        return int.Parse(num);
    }

    public DataSet GetAllTutorAndStu(int type)
    {
        string sql="";
        if (type == -1 || type == 0 || type == 1 || type == 2)
            sql = "select * from TutorAndStu where ispass="+type+"  order by Time desc";
        else
            sql = "select * from TutorAndStu  order by Time desc";
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public int GetAllNumTutorAndStu(int type)
    {
        string sql="";
        if (type == -1 || type == 0 || type == 1 || type == 2)
            sql = "select count(*) from TutorAndStu where ispass=" + type  ;
        else
             sql = "select count(*) from TutorAndStu  ";
        string num = ba.ReString(sql, null, 0);
        return int.Parse(num);
    }
    /// <summary>
    /// 改变 预订的状态  
    /// </summary>
    /// <param name="recid"></param>
    /// <param name="state">0为正在审核 1审核通过 -1取消 2结课</param>
    /// <returns></returns>
    public Boolean ChangeStateReservation(string recid,int state)
    {
        string sql = "update Reservation set ispass=@state where ReservationID=@id";
        SqlParameter[] pa={new SqlParameter("@id",recid),new SqlParameter("@state",state)};
        int line = ba.ExecNonQuery(sql, pa);
        return line > 0 ? true : false;
    }

    public string insertReservation(string StuID, string TutorID, string Time, string Grade)
    {
        string sql = "insert into Reservation (StuID, TutorID, Time,Grade,ispass) values (@StuID, @TutorID, @Time,@grade,0)";
        SqlParameter[] pa = { new SqlParameter("@StuID", StuID),
                              new SqlParameter("@TutorID", TutorID),
                              new SqlParameter("@Time", Time),
                              new SqlParameter("@grade",Grade)};
        int i=ba.ExecNonQuery(sql, pa);
        if (i <= 0)
            throw new Exception();
        sql = "select @@IDENTITY";
        return ba.ReString(sql, null, 0);
    }

    public void insertCourse(string resid, string courseid, string grade)
    {
        string sql = "insert into CourseReservation (ReservationID,CourseID, Grade) values (@resid,@courseid, @grade)";
        SqlParameter[] pa = { new SqlParameter("@courseid", courseid),
                              new SqlParameter("@grade", grade),
                              new SqlParameter("@resid",resid)};
        int i=ba.ExecNonQuery(sql, pa);
        if (i <= 0)
            throw new Exception();
    }



    //public string insertReservation(string StuID, string TutorID, string Time)
    //{ // 添加一条Reservation
    //    string sql = "insert into Reservation (StuID, TutorID, Time) values (@StuID, @TutorID, @Time)";
    //    SqlParameter[] pa = { new SqlParameter("@StuID", StuID),
    //                          new SqlParameter("@TutorID", TutorID),
    //                          new SqlParameter("@Time", Time),};
    //    ba.ExecNonQuery(sql, pa);
    //    sql = "select @@IDENTITY";
    //    return ba.ReString(sql, null, 0);
    //    //if(line<=0) throw
    //    //return getReservationID();
    //}






    public void deleteReservation(string ReservationID)
    { // 删除一条一条Reservation
        string sql = "delete from Reservation where ReservationID = @ReservationID";
        SqlParameter[] pa = { new SqlParameter("@ReservationID", ReservationID) };
        ba.ExecNonQuery(sql, pa);
    }

    public DataSet GetTopReservation()
    {
        string sql = "select top 1 * from Reservation order by ReservationID desc";
        return ba.GetDataSet(sql, null);
    }

    public string getReservationID()
    {
        DataSet ds = this.GetTopReservation();
        return ds.Tables[0].Rows[0][1].ToString();

        string id;
        SqlParameter[] pa = { new SqlParameter("@resid", id) };
        DataSet d = ba.ExecStoredProcedure("ResCourse", pa);
        return d.Tables[0].Rows[0][1].ToString();
    }




    public void InsertReservationAndCourse(string tutorid, string stuid, string course, string grade)
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd");
        string resid;
        course = course.Substring(0, course.LastIndexOf(','));
        string[] courses = course.Split(',');
        DataSet dscoursename = GetAllCourses();
        string gradeid = "";
        if (grade.Equals("小学"))
            gradeid = "0";
        else if (grade.Equals("初中"))
            gradeid = "1";
        else if (grade.Equals("高中"))
            gradeid = "2";
        ba.OpenTransaction();
        try
        {
            resid = this.insertReservation(stuid, tutorid, time, grade);
            for (int i = 0; i < courses.Length; i++)
            {
                string courid = "";
                for (int j = 0; j < dscoursename.Tables[0].Rows.Count; j++)
                {
                    if (courses[i] .Equals(dscoursename.Tables[0].Rows[j]["CourseName"].ToString()))
                    {
                        courid = dscoursename.Tables[0].Rows[j]["CourseID"].ToString();
                        break;
                    }
                }
                this.insertCourse(resid, courid, gradeid);
            }
            ba.Commit();
        }
        catch (Exception e) 
        {
            ba.Roback();
            throw e;
        }
    }

    public DataSet GetAllCourses()
    {
        string sql = "select * from Course";
        return ba.GetDataSet(sql, null);
    }








}