using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// NewsDao 的摘要说明
/// </summary>
public class NewsDao
{
	public NewsDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}




    // ~NewsDao()
    //{
    //    ba.Close();
    //}

    private BasicDao ba = new BasicDao();

    public void OpenSqlTransaction()
    {
        ba.OpenTransaction();
    }

    public void Commit()
    {
        ba.Commit();
    }

    public void RollBack()
    {
        ba.Roback();
    }


    public DataSet GetTopNews()
    {
        string sql = "select top 5  * from News where IsTop=1 order by newid()";
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public DataSet GetNewsById(string newsId)
    {
        string sql = "select * from News where NewsID = " + newsId;
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public DataSet GetNewsByTutorID(string TutorID)
    {
        string sql = "select * from News where TutorID = " + TutorID;
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public DataSet GetAllTags()
    {
        string sql = "select top 10 * from Tags order by newid()";
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public DataSet GetTagsByNewsId(string newsId)
    {
        string sql = "select * from NewsTag where NewsID = " + newsId;
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

   

    public void AddClick(string newsId)
    {
        string sql = "update News set Click = Click + 1 where NewsID = " + newsId.ToString();
        ba.OpenTransaction();
        try
        {
            ba.ExecNonQuery(sql, null);
            ba.Commit();
        }
        catch 
        {
            ba.Roback();
        }
        ba.Close();
    }


    public DataSet GetNewsByifpass(int type)
    {
        string sql = "";
        if (type == 0 || type == 1)
        {
            sql = "select * from News where ifpass=" + type.ToString() + " order by Date desc";
        }
        else
        {
            sql = "select * from News  order by Date desc";
        }
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public int GetNewsNumByType(int type)
    {
        string sql = "";
        if (type == 0 || type == 1)
        {
            sql = "select count(*) from News where ifpass=" + type.ToString() ;
        }
        else
        {
            sql = "select count(*) from News  ";
        }
        string re = ba.ReString(sql, null, 0);
        if (re.Trim().Equals("")) return 0;
        return int.Parse(re);
    }


    public Boolean ChangeTopStateNews(string newid, int istop)
    {
        string sql = "update News set IsTop=@istop where NewsID=@id";
        SqlParameter[] pa = { new SqlParameter("@istop", istop), new SqlParameter("@id", newid) };
        int line = ba.ExecNonQuery(sql, pa);
        return line > 0 ? true : false;

    }
    public Boolean ChangeStateNews(string newid, int ifpass)
    {
        if (ifpass != 0 && ifpass != 1) return false;
        string sql = "update News set ifpass=@ifp where NewsID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", newid), new SqlParameter("@ifp", ifpass) };
        int line = ba.ExecNonQuery(sql, pa);
        return line>0?true:false;
    }



    public DataSet GetAllPassNews()
    {
        string sql = "select * from News where ifpass=1 order by newid()";
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public int  GetAllNewsNum()
    {
        string sql = "select count(*) from News";
        string num = ba.ReString(sql, null, 0);
        return  int.Parse(num);
    }


    public DataSet GetRDNews(int newsnum)
    {
        string sql = "select top " + newsnum + " * from News where ifpass=1 order by newid()";
        
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;
    }

    public DataSet GetClickNews(int num)
    {
        string sql = "select top " + num + " * from News where ifpass=1 order by Click";
        DataSet ds = ba.GetDataSet(sql, null);
        return ds;

    }

    public void insertNews(string Title, string Body, string Author, string Date, string TutorID, string TitlePic, string ifadmin, string ifpass)
    { // 添加一条News
        string sql = "insert into News (Title, Body, Author, Date, TutorID, TitlePic,   IsTop,Click,ifadmin,ifpass) values (@Title, @Body, @Author, @Date, @TutorID, @TitlePic,    0,100,@ifadmin, @ifpass)";
        SqlParameter[] pa = { new SqlParameter("@Title", Title),
                              new SqlParameter("@Body", Body),
                              new SqlParameter("@Author", Author),
                              new SqlParameter("@Date", Date),
                              new SqlParameter("@TutorID", TutorID),
                              new SqlParameter("@TitlePic", TitlePic),
                              new SqlParameter("@ifadmin", ifadmin),
                              new SqlParameter("@ifpass", ifpass)};
        ba.ExecNonQuery(sql, pa);
    }

    public DataSet GetLastNews()
    { // 得到最后一条新闻
        string sql = "select top 1 * from News order by NewsID desc";
        return ba.GetDataSet(sql, null);
    }

    public void insertNewsTag(string NewsID, string TagID)
    { // 添加一条NewsTag
        string sql = "insert into NewsTag (NewsID, TagID) values (@NewsID, @TagID)";
        SqlParameter[] pa = { new SqlParameter("@NewsID", NewsID),
                              new SqlParameter("@TagID", TagID)};
        ba.ExecNonQuery(sql, pa);
    }

    public void deleteNewsByNewsID(string NewsID)
    {
        string sql = "delete from News where NewsID = " + NewsID;
        ba.ExecNonQuery(sql, null);
    }

    public void updateNews(string NewsID, string Title, string Body, string TitlePic)
    {
        string sql = "update News set Title=@Title,Body=@Body,TitlePic=@TitlePic where NewsID=@NewsID";
        SqlParameter[] pa = { new SqlParameter("@NewsID", NewsID),
                              new SqlParameter("@Title", Title),
                              new SqlParameter("@Body", Body),
                              new SqlParameter("@TitlePic", TitlePic)};
        ba.ExecNonQuery(sql, pa);
    }

    public void insertTags(string TagName)
    { // 添加一条Tags
        string sql = "insert into Tags (TagName) values (@TagName)";
        SqlParameter[] pa = { new SqlParameter("@TagName", TagName) };
        ba.ExecNonQuery(sql, pa);
    }

    public DataSet GetLastTags()
    { // 得到最后一条标签
        string sql = "select top 1 * from Tags order by TagID desc";
        return ba.GetDataSet(sql, null);
    }

    public DataSet GetTagsByNewsID(string NewsID)
    { // 得到文章标签
        string sql = "select * from NewsTag where NewsID = " + NewsID;
        return ba.GetDataSet(sql, null);
    }

    public void DeleteNewsTagByNewsID(string NewsID)
    {
        string sql = "delete from NewsTag where NewsID = " + NewsID;
        ba.ExecNonQuery(sql, null);
    }
}