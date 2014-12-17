using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_MenegeUtil : System.Web.UI.Page
{

    private string pagenum = "1";
    private string backpage = "teacherManagement.aspx";
    private string way = "";
    private string tutorid = "";
    private TutorDao tu = new TutorDao();
    protected void Page_Load(object sender, EventArgs e)
    {

        pagenum = Request["pagenum"] == null ? "1" : Request["pagenum"].ToString();
       // backpage = Request["backpage"] == null ? "index.aspx" : Request["backpage"].ToString();
        way=Request["way"]== null ? "" : Request["way"].ToString();
        tutorid=Request["tutorid"]== null ? "" : Request["tutorid"].ToString();
        if (way.Equals("pass")&&!tutorid.Trim().Equals(""))
        {
            PassTutor(tutorid);
        }
        if (way.Equals("deletetop") && !tutorid.Trim().Equals(""))
        {
            deletetop(tutorid);
        }
    }

    public void deletetop(string tutorid)
    {
        try
        {
            tu.DeleteTopTutor(tutorid);
            Response.Write(Util.ShowMessage("修改成功！"));
        }
        catch
        {
            Response.Write(Util.ShowMessage("修改失败！"));
        }
        finally
        {
            string url = backpage + "?pagenum=" + pagenum;
            Response.Redirect(url);
        }
    }



    public void PassTutor(string tutorid)
    {
        try
        {
            tu.PassTutor(tutorid);
            Response.Write(Util.ShowMessage("通过成功！"));
        }
        catch
        {
            Response.Write(Util.ShowMessage("操作失败！"));
        }
        finally
        {
            string url = backpage + "?pagenum=" + pagenum;
            Response.Redirect(url);
        }

    }
}