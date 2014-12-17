using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// StaffControl 的摘要说明
/// </summary>
public class StaffControl
{
    StaffDAO st = new StaffDAO();
	public StaffControl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public string GetStaffHtmlByDepartment(string departmentId, string filePath)
    {
        string xmlpath = filePath + "Web\\Content.xml";

        string html = Util.ReadInfoFromXML(xmlpath, "department_body");
        string result = null;

        DataSet ds = st.GetStaffByDepartment(departmentId);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string[] str = new string[3];
            str[0] = "../images/" + ds.Tables[0].Rows[i]["Photo"].ToString();
            str[1] = ds.Tables[0].Rows[i]["Name"].ToString();
            str[2] = ds.Tables[0].Rows[i]["Intro"].ToString();
            result += string.Format(html, str);
        }
        return result;
    }
}