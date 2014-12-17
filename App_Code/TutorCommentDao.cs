using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// TutorCommentDao 的摘要说明
/// </summary>
public class TutorCommentDao
{
	public TutorCommentDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    // ~TutorCommentDao()
    //{
    //    ba.Close();
    //}
    private BasicDao ba=new BasicDao();

    public DataSet GetTutorComment(string  id)
    {
        string sql = "select * from TutorComment where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        return ba.GetDataSet(sql, pa);
    }

    public DataSet RandomTutorComment(string id, int num)
    {
        string sql = "select top @num * from TutorComment where TutorID = @id order by newid()";
        SqlParameter[] pa = { new SqlParameter("@num", num), new SqlParameter("@id", id)};
        return ba.GetDataSet(sql, pa);
    }

    public float GetAverageStar(string id)
    {
        string sql = "select avg(Start) from TutorComment where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        DataSet ds = ba.GetDataSet(sql, pa);
        try
        {
            float f = float.Parse(ds.Tables[0].Rows[0][0].ToString());
            return f;
        }
        catch
        {
            return 0;
        }

    }



    public string GetAllComNum(string id)
    {
        string sql = "select count(*) from TutorComment where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        //DataSet ds = ba.GetDataSet(sql, pa);
        return ba.ReString(sql, pa, 0);
    }
}