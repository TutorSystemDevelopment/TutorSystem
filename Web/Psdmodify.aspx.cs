using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;

public partial class Web_Psdmodify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null) Response.Redirect("PermissionsError.aspx");
        uid = Session["Uid"].ToString();
    }

    private string  uid = "27";
    private UserDao us = new UserDao();

    private Boolean CheckUsr(string psd)
    {
        return us.CheckUser(uid, psd);
    }

    protected void bt_sure_Click(object sender, EventArgs e)
    {
        string last = tb_lastpsd.Value.ToString();
        last = FormsAuthentication.HashPasswordForStoringInConfigFile(last, "MD5").ToLower().Substring(8, 16);
        Boolean b = CheckUsr(last);
        if (b)
        {
            string newpsd = info_password.Value.Trim();
            newpsd = FormsAuthentication.HashPasswordForStoringInConfigFile(newpsd, "MD5").ToLower().Substring(8, 16);
            Boolean flag = us.UserChangePSD(uid, newpsd);
            if (flag)
            {
                Response.Write(Util.ShowMessage("修改成功！"));
            }
            else
            {
                Response.Write(Util.ShowMessage("修改失败！"));
            }
        }
        else
        {
            Response.Write(Util.ShowMessage("旧密码错误!"));
        }
    }
}