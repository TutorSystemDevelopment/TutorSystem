using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// CourseDAO 的摘要说明
/// </summary>
public class CourseDAO
{
    BasicDao ba = new BasicDao();
	public CourseDAO()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    // ~CourseDAO()
    //{
    //    ba.Close();
    //}

    public DataSet GetAllCourses()
    {
        string sql = "select * from Course";
        return ba.GetDataSet(sql, null);
    }

}