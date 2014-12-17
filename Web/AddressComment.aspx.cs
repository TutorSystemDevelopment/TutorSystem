using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_AddressComment : System.Web.UI.Page
{
    private string tid = "1";
    private string sid = "0";
    private string rid = "2";
    private CommentC cc = new CommentC();
    private CommentDao cd = new CommentDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("0") || Session["ID"] == null)
                Response.Redirect("PermissionsError.aspx");
            //pageindex = Session["pageindex"] == null ? 1 : int.Parse(Session["pageindex"].ToString());
            lb_stuid.Text = Session["ID"].ToString();
            lb_recid.Text = Request["resid"].ToString();
            lb_tutorid.Text = Request["tutorid"].ToString();
            BindRandomComment();
        }
    }
    protected void Submit_ServerClick(object sender, EventArgs e)
    {
        string star = hidrating.Value.ToString();
        Boolean b= cd.insertTutorComment(lb_tutorid.Text, lb_stuid.Text, comment.InnerText, star, DateTime.Now.ToString("yyyy-MM-dd"), lb_recid.Text);
        if (b)
        {
            Response.Write(Util.ShowMessage("评论成功！"));
            BindRandomComment();
        }
        else
        {
            Response.Write(Util.ShowMessage("评论失败！"));
        }
    }

    protected void BindRandomComment()
    {
        string path = Server.MapPath("..//") + "Web\\Content.xml";
        ranComments.InnerHtml = cc.GetRandomCommentHTML(path, lb_tutorid.Text);
    }
}