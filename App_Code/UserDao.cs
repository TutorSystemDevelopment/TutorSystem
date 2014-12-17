using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// UserDao 的摘要说明
/// </summary>
public class UserDao
{
	public UserDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    
    //~UserDao()
    //{
    //    ba.Close();
    //}

    private BasicDao ba = new BasicDao();

    public Boolean CheckUser(string name)
    {
        string sql = "select count(*) from tb_user where UserName=@mail";
        SqlParameter[] pa = { new SqlParameter("@mail", name) };
        string temp = ba.ReString(sql, pa, 0);
        int i = int.Parse(temp);
        if (i>0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="recid">接受方的uuid</param>
    /// <param name="sendUid">发送方的UUID</param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public Boolean InsertChat(string recuid, string sendUid, string title, string content)
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd");
        //time.Replace('-', '/');
        string sql = "insert into Chat (SendUID,RecieveUID,Title,ChatContent,Time,IsRead) values (@sendid,@recid,@title,@content,@time,0)";
        //string findsql="select * from tb_User where ID=";
        //string recUid = ba.ReString(findsql+recid, null, "UUID");
        //string sendUid = ba.ReString(findsql + sendid, null, "UUID");
        SqlParameter[] pa = { new SqlParameter("@sendid", sendUid), new SqlParameter("@recid", recuid), new SqlParameter("@title", title), new SqlParameter("@content", content), new SqlParameter("@time", time) };
        ba.OpenTransaction();
        try
        {
            ba.ExecNonQuery(sql, pa);
            ba.Commit();
            return true;
        }
        catch
        {
            ba.Roback();
            return false;
        }
        finally
        {
            ba.Close();
        }
    }

    /// <summary>
    /// 根据id  得到用户的名字
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetName(string type,string id)
    {
        string re = "";
        string sql="select Name from ";
        if (type.Equals("0"))
        {
            sql += "Student where StuID=@id";
        }
        else if (type.Equals("1"))
        {
            sql += "Tutor where TutorID=@id";
        }
        else
            return "";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        re = ba.ReString(sql, pa, 0);
        return re;
    }


    public string GetUid(string type, string id)
    {
        string re = "";
        string sql = "select UUID from tb_User where Type=@type and ID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id), new SqlParameter("@type",type) };
        re = ba.ReString(sql, pa, 0);
        return re;

    }


	public DataRow userLogin(string username, string password)
    {
        string sql = "select * from tb_User where UserName = @username and Password = @passwd and Type<>2";
        SqlParameter[] para = new SqlParameter[2]{new SqlParameter("@username", username), new SqlParameter("@passwd", password)};
        DataSet ds = ba.GetDataSet(sql, para);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return null;
        }
        else
        {
            return ds.Tables[0].Rows[0];
        }
    }

    public DataRow adminLogin(string username, string password)
    {
        string sql = "select * from tb_User where UserName = @username and Password = @passwd and Type=2";
        SqlParameter[] para = new SqlParameter[2] { new SqlParameter("@username", username), new SqlParameter("@passwd", password) };
        DataSet ds = ba.GetDataSet(sql, para);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return null;
        }
        else
        {
            return ds.Tables[0].Rows[0];
        }
    }

    public Boolean CheckUser(string uid, string password)
    {
        string sql = "select * from tb_User where UUID = @uid and Password = @passwd";
        SqlParameter[] para = new SqlParameter[2] { new SqlParameter("@uid", uid), new SqlParameter("@passwd", password) };
        DataSet ds = ba.GetDataSet(sql, para);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Boolean UserChangePSD(string uid, string newpsd)
    {
        string sql = "update tb_User set Password=@psd where UUID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", uid), new SqlParameter("@psd", newpsd) };
        int line = ba.ExecNonQuery(sql, pa);
        return line > 0 ? true : false;
    }


    public string GetUUIDByIDAndType(string id, string type)
    {
        string sql = "select UUID from tb_User where ID=@id and Type=@type ";
        SqlParameter[] pa = { new SqlParameter("@id", id), new SqlParameter("@type", type) };
        return ba.ReString(sql, pa, 0);
    }

}