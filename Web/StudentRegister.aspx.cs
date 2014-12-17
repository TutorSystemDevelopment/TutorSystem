using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

public partial class Web_StudentRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHead();
            BindFooter();
        }
    }

    private BasicDao ba = new BasicDao();

    private void BindHead()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        string html = Util.ReadInfoFromXML(FilePath, "head");
        string usertype = Session["usertype"] == null ? "-1" : Session["usertype"].ToString();
        string ty = "";
        string name = "";
        if (usertype.Equals("-1"))
        {
            A_ModifyInfo.HRef = "login.aspx";
            ty = "游客  ";
            name = "请登录>>>";
        }
        else if (usertype.Equals("0"))
        {
            A_ModifyInfo.HRef = "StuInfoMenegement.aspx";
            ty = "学生  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("1"))
        {
            A_ModifyInfo.HRef = "infoManagement.aspx";
            ty = "老师  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("2"))
        {
            A_ModifyInfo.HRef = "../Backstage/teacherManagement.aspx";
            ty = "管理员  ";
            name = "";
        }
        navbar.InnerHtml = string.Format(html, ty, name);
    }

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }

    protected void bt_suer_Click(object sender, EventArgs e)
    {
        string username = stu_mail.Value.ToString();
        string psd = info_password.Value;
        psd = FormsAuthentication.HashPasswordForStoringInConfigFile(psd, "MD5").ToLower().Substring(8, 16);
        string sex = info_male.Checked ? info_male.Value : info_female.Value;
        if (sex.Equals("1"))
            sex = "男";
        else
            sex = "女";
        string name = stu_name.Value.ToString();
        string qq = stu_qq.Value.ToString();
        string add = stu_address.Value.ToString();
        string guardname = stu_guardname.Value.ToString();
        string guardphone = stu_guardphone.Value.ToString();
        string grade = stu_grade.SelectedItem.Value.ToString();
        string mail = stu_mail.Value.ToString();

        SqlParameter[] pa={new SqlParameter("@username",mail),new SqlParameter("@psd",psd),new SqlParameter("@name",name),
                           new SqlParameter("@gender",sex),new SqlParameter("@address",add),new SqlParameter("@qq",qq),
                           new SqlParameter("@guardianname",guardname),new SqlParameter("@guardphone",guardphone),
                           new SqlParameter("@mail",mail),new SqlParameter("@re",SqlDbType.Int),
                          new SqlParameter("@uid",SqlDbType.Int)};


        pa[9].Direction=ParameterDirection.ReturnValue;
        pa[10].Direction = ParameterDirection.Output;
        ba.ExecNonQueryStoredProcedure("StudentRegister",pa);

        if (pa[9].Value.ToString().Equals("0"))
        {
            Response.Write(Util.ShowMessage("注册失败！"));

        }
        else if (pa[9].Value.ToString().Equals("-1"))
        {
            Response.Write(Util.ShowMessage("用户名已存在！"));
        }
        else
        {

            Session["usertype"] = 0;//表示学生
            Session["ID"] = pa[9].Value.ToString();
            Session["Uid"] = pa[10].Value.ToString();
            Session["Name"] = name;
            Response.Write(Util.ShowMessage("注册成功！", "index.aspx"));
        }

    }
}