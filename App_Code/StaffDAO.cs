using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// StaffDAO 的摘要说明
/// </summary>
public class StaffDAO
{
    BasicDao ba = new BasicDao();
	public StaffDAO()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    // ~StaffDAO()
    //{
    //    ba.Close();
    //}

    public DataSet GetStaffByDepartment(string departmentId)
    {
        string sql = "select * from Staff where DepartmentID = " + departmentId;
        return ba.GetDataSet(sql, null);
    }
}