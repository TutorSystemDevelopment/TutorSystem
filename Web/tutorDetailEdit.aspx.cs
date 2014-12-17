using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Web_tutorDetailEdit : System.Web.UI.Page
{

    private string tutorid="1";
    private TutorDao tu = new TutorDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1") || Session["ID"] == null) Response.Redirect("PermissionsError.aspx");
        tutorid = Session["ID"].ToString();
        if (!IsPostBack)
        {
            BindInfo();
        }
    }

    public void BindInfo()
    {
        DataSet ds = tu.GetTutorByID(tutorid);
        InfoEdit.Text = ds.Tables[0].Rows[0]["Resume"].ToString();
    }


    protected void bt_sure_Click(object sender, EventArgs e)
    {
        string content = InfoEdit.Text;
        Boolean b = tu.UpdateResume(content,tutorid);
        if (b)
        {
            Response.Write(Util.ShowMessage("修改成功！"));
        }
        else
            Response.Write(Util.ShowMessage("修改失败！"));
    }
}