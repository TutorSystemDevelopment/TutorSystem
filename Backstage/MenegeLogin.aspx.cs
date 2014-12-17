using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Web_Default3 : System.Web.UI.Page
{
    private UserDao ud = new UserDao();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if(TextBox1.Text != null && TextBox2.Text != null)
        {
            string psd = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "MD5").ToLower().Substring(8, 16);
            DataRow dr = ud.adminLogin(TextBox1.Text, psd);
            if (dr != null)
            {
                Session["Uid"] = dr["UUID"].ToString();
                Session["Name"] = "管理员";
                Session["usertype"] = dr["Type"].ToString();
                Session["ID"] = dr["ID"].ToString();

                Response.Write(Util.ShowMessage("登录成功！", "teacherManagement.aspx"));
            }
            else Response.Write("<script language=\"JavaScript\">alert(\"登陆失败!\")</script>");
        }
        else Response.Write("<script language=\"JavaScript\">alert(\"请输入完整的用户名和密码!\")</script>");
    }
}