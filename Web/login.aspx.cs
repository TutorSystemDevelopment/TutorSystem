using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        UserDao ud = new UserDao();
        string uid = username.Value.ToString();
        string pwd = password.Value.ToString();
        pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5").ToLower().Substring(8, 16);
        DataRow dr = ud.userLogin(uid, pwd);
        if (dr == null)
        {
            Response.Write("<script>alert('您的帐户名或密码有误，请确保它们正确并重新登陆！');</script>");
        }
        else
        {
            Session["Uid"] = dr["UUID"].ToString();
            Session["ID"] = dr["ID"].ToString();
            Session["usertype"] = dr["Type"].ToString();
            string name = ud.GetName(dr["Type"].ToString(), dr["ID"].ToString());
            Session["Name"] = name;
            Response.Redirect("index.aspx");
        }
    }
}