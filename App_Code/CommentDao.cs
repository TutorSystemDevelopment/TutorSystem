using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// CommentDao 的摘要说明
/// </summary>
public class CommentDao
{
	public CommentDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    // ~CommentDao()
    //{
    //    ba.Close();
    //}

    private BasicDao ba = new BasicDao();

    public Boolean insertTutorComment(string TutorID, string StuID, string Comment, string Start, string Time, string ReservationID)
    { // 添加一条Reservation
        string sql = "insert into TutorComment (TutorID, StuID, Comment, Start, Time, ReservationID) values (@TutorID, @StuID, @Comment, @Start, @Time, @ReservationID)";
        SqlParameter[] pa = { new SqlParameter("@TutorID", TutorID),
                              new SqlParameter("@StuID", StuID),
                              new SqlParameter("@Comment", Comment),
                              new SqlParameter("@Start", Start),
                              new SqlParameter("@Time", Time),
                              new SqlParameter("@ReservationID", ReservationID)};
        int line= ba.ExecNonQuery(sql, pa);
        return line > 0 ? true : false;
    }

    public DataSet GetRandomComments(string tid)
    {
        SqlParameter[] pa = { new SqlParameter("@tid", tid) };
        DataSet ds = ba.ExecStoredProcedure("RandomCommentById", pa);
        return ds;
    }
}