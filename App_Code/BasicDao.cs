using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// BasicDao 的摘要说明
/// </summary>
public class BasicDao
{

    private SqlConnection conn;
    private SqlTransaction tran;
	public BasicDao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public void Open()
    {
        if(conn==null)
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            conn.Open();
        }
        else if (conn.State == System.Data.ConnectionState.Closed)
        {
            conn.Open();
        }
    }


    public void Close()
    {
        if (conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
        }
        tran = null;
    }

    public SqlParameter MakeInPara(string parameterName, SqlDbType dbType, int size, object value)
    {
        SqlParameter para;
        if (size <= 0&&size!=-1)
        {
            para = new SqlParameter(parameterName, dbType);
        }
        else
        {
            para = new SqlParameter(parameterName, dbType, size);
        }
        para.Direction = System.Data.ParameterDirection.Input;
        if (value != null)
        {
            para.Value = value;
        }
        return para;
    }

    public SqlCommand GetCMD(string sql,SqlParameter[] paras)
    {
        this.Open();
        SqlCommand cmd = new SqlCommand(sql,conn);
        if (paras != null)
        {
            foreach(SqlParameter p in paras)
            {
                cmd.Parameters.Add(p);
            }
        }
        //this.Close();
        return cmd;
    }


    public SqlDataAdapter GetADP(string sql, SqlParameter[] paras)
    {
        this.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);       //
        da.SelectCommand.CommandType=CommandType.Text;
        if (paras != null)
        {
            foreach (SqlParameter p in paras)
            {
                //Console.Write(p.Value);
                da.SelectCommand.Parameters.Add(p);

            }
        }
        //this.Close();
        return da;
    }


    public void OpenTransaction()
    {
        this.Open();
        tran = conn.BeginTransaction();
    }


    public SqlTransaction GetTransaction()
    {
        return tran;
    }

    public void Commit()
    {
        if (tran != null)
            tran.Commit();
        tran = null;
    }

    public void Roback()
    {
        if (tran != null)
            tran.Rollback();
    }


    public int ExecNonQuery(string sql, SqlParameter[] paras)
    {
        this.Open();                                        
        int change_line = 0;                              
        SqlCommand cmd = this.GetCMD(sql, paras);         
        //SqlTransaction tran = conn.BeginTransaction();    
        if(tran!=null)
            cmd.Transaction = tran;                           
        try                                              
        {                                                  
            change_line = cmd.ExecuteNonQuery();                                        
        }
        catch (Exception e)
        {
            throw e;
        }
        return change_line;
    }


    public DataSet GetDataSet(string sql, SqlParameter[] para,string table_name)
    {
        SqlDataAdapter da = this.GetADP(sql, para);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, table_name);
        }
        catch (Exception e)
        {
            throw e;
        }
       
        return ds;
    }

    /// <summary>
    /// 返回dataset的执行函数  不指定表名
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="para"></param>
    /// <returns></returns>
    public DataSet GetDataSet(string sql, SqlParameter[] para)
    {
        SqlDataAdapter da = this.GetADP (sql, para);
        if (tran != null)
            da.SelectCommand.Transaction = tran;
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return ds;
    }

  
 
    /// <summary>
    /// 返回指定行相应列的内容
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="para"></param>
    /// <param name="cow"> 列的引索</param>
    /// <returns></returns>
    public string ReString(string sql, SqlParameter[] para, int cow)
    {
        DataSet ds = this.GetDataSet(sql, para);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count!=0)
            {
                return ds.Tables[0].Rows[0][cow].ToString();
            }
            return "";
        }
        else
        {
            return "" ;
        }
    }

    public string ReString(string sql, SqlParameter[] para, string cowname)
    {
        DataSet ds = this.GetDataSet(sql, para);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0][cowname].ToString();
            }
            return "";
        }
        else
        {
            return "";
        }
    }


    /// <summary>
    /// 执行查找的存储过程 
    /// </summary>
    /// <param name="procedureName"></param>
    /// <param name="para"></param>
    /// <returns></returns>
    public DataSet ExecStoredProcedure(string procedureName, SqlParameter[] para)
    {
        this.Open();
        //SqlDataAdapter da = new SqlDataAdapter(); 
        //da.SelectCommand = new SqlCommand(); 
        //da.SelectCommand.Connection = conn; 
        //da.SelectCommand.CommandText = procedureName; 
        //da.SelectCommand.CommandType = CommandType.StoredProcedure;
       
        
        SqlCommand com = new SqlCommand(procedureName, conn);
        com.CommandType = CommandType.StoredProcedure;
        if (tran != null)
            com.Transaction = tran;

        for (int i = 0; i < para.Length; i++)
        {
            com.Parameters.Add(para[i]);
        }

        SqlDataAdapter da = new SqlDataAdapter(com);
        DataSet ds = new DataSet();
        da.Fill(ds);
       // string re = com.Parameters["@id"].Value.ToString();
        this.Close();
        //return re;
        return ds;
        //return da.SelectCommand.ExecuteNonQuery();
    }


    /// <summary>
    /// 执行插入的存储过程
    /// </summary>
    /// <param name="procedureName"></param>
    /// <param name="para"></param>
    public void ExecNonQueryStoredProcedure(string procedureName, SqlParameter[] para)
    {
        this.Open();
        SqlCommand com = new SqlCommand(procedureName, conn);
        com.CommandType = CommandType.StoredProcedure;
        if (tran != null)
            com.Transaction = tran;

        for (int i = 0; i < para.Length; i++)
        {
            com.Parameters.Add(para[i]);
        }
        com.ExecuteNonQuery();
        
        this.Close();
      
    }




}