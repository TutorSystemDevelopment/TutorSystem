using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// TutorDao 的摘要说明
/// </summary>
public class TutorDao
{
	public TutorDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    // ~TutorDao()
    //{
    //    ba.Close();
    //}

    private BasicDao ba = new BasicDao();
    private UserDao us = new UserDao();

    public DataSet GetTopTutor()
    {
        //string sql = "select top 8 * from Tutor where Rank=1";
        string sql = "select top 8 * from TutorAndTop where iftop = 1";
        return ba.GetDataSet(sql, null);
    }

    public DataSet GetAllTutor()
    {
        string sql = "select * from Tutor ";
        return ba.GetDataSet(sql, null);
    }


    public DataSet GetTutorClassInfo(string tutorid)
    {
        //string sql = "select * from TutorAndCourse where TutorID=@id and IsGood=1";
        string sql = "select * from TutorAndCourse where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
        return ba.GetDataSet(sql, pa);
    }

    public DataSet GetTutorByID(string id)
    {
        string sql = "select * from TutorAndCourse where TutorID=@id";
        SqlParameter[] pa = { new SqlParameter("@id", id) };
        return ba.GetDataSet(sql, pa);
    }

     public DataSet GetCourseName()
    {
        string sql = "select * from Course";
        return ba.GetDataSet(sql, null);
    }

     public DataSet GetSerachTutor(string sex, string course, string pri)
     {


         string sql = "select distinct TutorID,Intro,Photo,Name,Gender,QQ,University,RankName,Rank from TutorAndCourse where Rank>=0";//创建一个存储过程
         if (!sex.Trim().Equals(""))
         {
             sql += " and Gender='" + sex + "' ";

         }
         if (!pri.Trim().Equals(""))
         {
             int temp=int.Parse(pri);
             sql += " and ";
             sql += "Cost<=" + pri;
             if (temp > 50)
             {
                 sql += " and Cost>50";
             }
             else
                sql += " and Cost>" + (temp - 10); 
         }
         if (!course.Trim().Equals(""))
         {

             sql += " and ";
             sql += "CourseName in " + course;
         }
         //sql += "  order by TutorID desc";
         sql = "select * from (" + sql + ")as Info order by Rank desc";

         return ba.GetDataSet(sql, null);

     }





    private void InsertCourse(string[] cou ,string[] se,int cost,string tutorid)
    {
        for (int i = 0; i < se.Length; i++)
        {
            for (int j = 0; j < cou.Length; j++)
            {
                string sql = "insert into CourseJoin values(@id,@coursid,0,@se,@cost)";
                SqlParameter[] pa = { new SqlParameter("@id", tutorid), new SqlParameter("@coursid", cou[j]), new SqlParameter("@se", se[i]), new SqlParameter("@cost", cost) };
                ba.ExecNonQuery(sql, pa);
            }
        }
    }

    private string InsertTutor(string mail, string qq, string sex, string name, string uni, string phone, string backtime
        , string leavetime, string intro, string photo)
    {
        SqlParameter[] pa ={new SqlParameter("@email",mail),new SqlParameter("@sex",sex),
                               new SqlParameter("@qq",qq),new SqlParameter("@name",name),new SqlParameter("@Uni",uni),
             new SqlParameter("@phone",phone),new SqlParameter("@backtime",backtime),new SqlParameter("@leavetime",leavetime),
             new SqlParameter("@intro",intro),new SqlParameter("@pic",photo)};
        string sql = "insert into Tutor (Name,Gender,QQ,University,Phone,Photo,BackTime,LeaveTime,Mail,Intro,Rank) values (@name,@sex,@qq,@Uni,@phone,@pic,@backtime,@leavetime,@email,@intro,-1);";
        ba.ExecNonQuery(sql, pa);
        sql = "select @@IDENTITY;";
        return  ba.ReString(sql, null, 0);
    }

    private void InsertUser(string mail, string psd, int type, string id)
    {
        string sql = "insert into tb_user values(@mail,@psd,@type,@id)";
        SqlParameter[] pa = { new SqlParameter("@mail", mail), new SqlParameter("@psd", psd), new SqlParameter("@type", type), new SqlParameter("@id", id) };
        ba.ExecNonQuery(sql, pa);
    }




     public string InsertTutorInfo(string mail, string psd, string qq, string sex, string name, string uni, string phone, string backtime
        , string leavetime, string course, string senir, string intro, string photo)
     {
         string[] cou = course.Split(',');
         string[] se = senir.Split(',');
         ba.OpenTransaction();
         try
         {
             //string id=ba.ExecStoredProcedure("TutorRegister",pa);
             string id = InsertTutor(mail, qq, sex, name, uni, phone, backtime, leavetime, intro, photo);
             InsertUser(mail, psd, 1, id);
             InsertCourse(cou, se, 50, id);
             ba.Commit();
             return id;
         }
         catch (Exception e)
         {
             ba.Roback();
             throw e;
         }
         
     }


     public Boolean CheckPhone(string phone)
     {
         string sql = "select count(*) from Tutor where Phone=@phone";
         SqlParameter[] pa = { new SqlParameter("@phone", phone) };
         string temp = ba.ReString(sql, pa, 0);
         int i = int.Parse(temp);
         if (i > 0)
             return true;
         else
             return false;

     }

    /// <summary>
    /// 可以使用存储过程  根据 新闻id  得到对应新闻的老师信息
    /// </summary>
    /// <param name="newid"></param>
    /// <returns></returns>
     public DataSet GetTutorByNewid(string newid)
     {
         string sql = "select * from News where NewsID=@id and ifadmin=0";
         SqlParameter[] pa={new SqlParameter("@id",newid)};
         
         string tutorid = ba.ReString(sql, pa, "TutorID");
         DataSet ds = null;
         if (!tutorid.Trim().Equals(""))
         {

             ds = this.GetTutorByID(tutorid);
         }
         return ds;

     }


     public DataSet GetTopTutorByID(string id)
     {
         string sql = "select * from TutorAndTop where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", id) };
         return ba.GetDataSet(sql, pa);

     }




     public DataSet GetTutorTimeLineByOrder(string tutorid)
     {
         string sql = "select * from TutorTimeLine where TutorID=@id order by Year desc,Month desc";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         return ba.GetDataSet(sql, pa);
     }

     public DataSet GetTutorTimeLineByLineID(string LineID)
     {
         string sql = "select * from TutorTimeLine where LineID=@LineID";
         SqlParameter[] pa = { new SqlParameter("@LineID", LineID) };
         return ba.GetDataSet(sql, pa);
     }



     public DataSet GetSingleTutor()
     {
         string sql = "select * from Tutor";
         return ba.GetDataSet(sql, null);
     }
     public DataSet GetPassTutor()
     {
         string sql = "select * from Tutor where rank>=0";
         return ba.GetDataSet(sql, null);
     }
     public DataSet GetNotPassTutor()
     {
         string sql = "select * from Tutor where rank<0";
         return ba.GetDataSet(sql, null);
     }

     public DataSet GetSingleTutorByid(string tutorid)
     {
         string sql = "select * from Tutor where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         return ba.GetDataSet(sql, pa);
         
     }




     public void InsertintoTopTutor(string pic ,string advice,string id ,int iftop)
     {
         string sql = "insert into TopTutor values(@id,@advice,@pic,@iftop)";
         SqlParameter[] pa = { new SqlParameter("@advice", advice), new SqlParameter("@id", id), new SqlParameter("@pic", pic), new SqlParameter("@iftop", iftop) };
         ba.ExecNonQuery(sql, pa);
     }

     public Boolean HasTopTutor(string tutorid)
     {
         string sql = "select * from TopTutor where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         DataSet ds = ba.GetDataSet(sql, pa);
         return ds.Tables[0].Rows.Count > 0 ? true : false;
     }

     public void UpTopTutor(string pic, string advice, string id, int iftop)
     {
         SqlParameter[] pa = { new SqlParameter("@advice", advice), new SqlParameter("@id", id), new SqlParameter("@pic", pic), new SqlParameter("@iftop", iftop) };
         string sql = "update TopTutor set Advice=@advice,IndexPic=@pic,iftop=@iftop where TutorID=@id";
         ba.ExecNonQuery(sql, pa);
     }


     public DataSet GetAllTopTutor()
     {
         string sql = "select * from TutorAndTop ";
         return ba.GetDataSet(sql, null);
     }


     public DataSet GetAllIndexTopTutor()
     {
         //string sql = "select top 8 * from Tutor where Rank=1";
         string sql = "select  * from TutorAndTop where iftop = 1";
         return ba.GetDataSet(sql, null);
     }

     public Boolean TutorIsTop(string tutorid)
     {

         string sql = "select  * from TutorAndTop where iftop = 1 and TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         DataSet ds = ba.GetDataSet(sql, pa);
         return ds.Tables[0].Rows.Count > 0 ? true : false;

     }


     public void PassTutor(string tutorid)
     {
         string sql = "update Tutor set Rank=0 where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         ba.ExecNonQuery(sql, pa);
     }

     public void DeleteTopTutor(string tutorid)
     {
         string sql = "update TopTutor set iftop=0 where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", tutorid) };
         ba.ExecNonQuery(sql, pa);
     }

     /// <summary>
     /// 得到totutor  随机的num位教师
     /// </summary>
     /// <param name="num"></param>
     /// <returns></returns>
     public DataSet RandomRecommend(int num)
     {
         string sql = "select top " + num + " * from TopTutor where iftop = 1 order by newid()";
         DataSet ds = ba.GetDataSet(sql, null);
         return ds;
     }


   /// <summary>
   /// 得到审核通过的随机num为老师
   /// </summary>
   /// <param name="num"></param>
   /// <returns></returns>
     public DataSet RandomTutor(int num)
     {
         string sql = "select top " + num + " * from Tutor where Rank >=0 order by newid()";
         DataSet ds = ba.GetDataSet(sql, null);
         return ds;


     }


    /// <summary> 
    /// 可以写存储过程 得到课程
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
     public string GetGoodClass(string id)
     {
         DataSet ds = GetTutorClassInfo(id);
         string tmep = "";
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
             tmep += ds.Tables[0].Rows[i]["CourseName"].ToString() + ",";
             //if (i / 2 > 0&&i%2==0&&i!=ds.Tables[0].Rows.Count-1)
             //{
             //    tmep += "<br/>";
             //}
         }
         if (!tmep.Trim().Equals(""))
             tmep = tmep.Remove(tmep.LastIndexOf(','));
         return tmep;
     }

     public void UpdateTutor(string TutorID, string QQ, string Phone, string University, string Intro, string Photo)
     {// 修改家教个人信息
         //string sql = "update Tutor set (QQ, Phone, University, Intro, Photo) = (@QQ, @Phone, @University, @Intro, @Photo) where tutorid=@tutorid";
         string sql = "update Tutor set QQ = @QQ, Phone = @Phone, University = @University, Intro = @Intro, Photo = @Photo where TutorID = @TutorID";
         SqlParameter[] pa = { new SqlParameter("@TutorID", TutorID),
                               new SqlParameter("@QQ", QQ),
                               new SqlParameter("@Phone", Phone),
                               new SqlParameter("@University", University),
                               new SqlParameter("@Intro", Intro),
                               new SqlParameter("@Photo", Photo)};
         ba.ExecNonQuery(sql, pa);
     }

     public void DeleteTutorTimeLine(string LineID)
     {
         string sql = "delete from TutorTimeLine where LineID=@LineID";
         SqlParameter[] pa = { new SqlParameter("@LineID", LineID) };
         ba.ExecNonQuery(sql, pa);
     }

     public void InsertTutorTimeLine(string Year, string Month, string Title, string Items, string TutorID)
     {
         string sql = "insert into TutorTimeLine (Year, Month, Title, Items, TutorID) values (@Year, @Month, @Title, @Items, @TutorID)";
         SqlParameter[] pa = { new SqlParameter("@Year", Year),
                              new SqlParameter("@Month", Month),
                              new SqlParameter("@Title", Title),
                             new SqlParameter("@Items", Items),
                             new SqlParameter("@TutorID", TutorID)};
         ba.ExecNonQuery(sql, pa);
     }

     public void UpdateTutorTimeLine(string LineID, string Year, string Month, string Title, string Items)
     {
         string sql = "update TutorTimeLine set Year=@Year, Month=@Month, Title=@Title, Items=@Items where LineID = @LineID";
         SqlParameter[] pa = { new SqlParameter("@LineID", LineID),
                               new SqlParameter("@Year", Year),
                              new SqlParameter("@Month", Month),
                              new SqlParameter("@Title", Title),
                             new SqlParameter("@Items", Items)};
         ba.ExecNonQuery(sql, pa);
     }

     public Boolean UpdateResume(string content, string id)
     {
         string sql = "update Tutor set Resume=@content where TutorID=@id";
         SqlParameter[] pa = { new SqlParameter("@id", id), new SqlParameter("@content", content) };
         int line = ba.ExecNonQuery(sql, pa);
         return line > 0 ? true : false;

     }

     public DataSet GetTutorByName(string name)
     {
         string sql = "select * from Tutor where Rank>=0 and Name like '%" + name + "%'";
         //SqlParameter[] pa = { new SqlParameter("@name", name) };
         return ba.GetDataSet(sql, null);
     }


     public string GetTopTutorRandomID()
     {
         string sql = "select * from TopTutor order by newid() ";
         return ba.ReString(sql, null, "TutorID");

     }


}