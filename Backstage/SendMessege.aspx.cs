using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_SendMessege : System.Web.UI.Page
{
    private string recid="1";
    private string senduid = "19";
    private string pageback = "";
    private string pagenum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["backpage"] == null)
            pageback = Session["backpage"] == null ? "../Web/index.aspx" : Session["backpage"].ToString();
        else
            pageback = Request["backpage"].ToString();

        if (Request["recid"] == null || Session["Uid"] == null) Response.Redirect(pageback);
        senduid = Session["Uid"].ToString();
        recid = Request["recid"].ToString();
        pagenum = Request["pagenum"] == null ? "-1" : Request["pagenum"].ToString();
        
        if (!IsPostBack)
        {
            BindName();
        }
    }


    private TutorDao tu = new TutorDao();
    private UserDao us = new UserDao();
    private void BindName()
    {
        //string name = tu.GetSingleTutorByid(uid).Tables[0].Rows[0]["Name"].ToString();
        if (Request["Name"] != null)
        {
            string name = Request["Name"].ToString();
            t_name.InnerText = "收件人：" + name;
        }
        else
            t_name.InnerText = "收件人ID：" + recid;
        if (!Session["usertype"].ToString().Equals("2"))
        {
            back.Visible = false;
        }
    }


    protected void submit_ServerClick(object sender, EventArgs e)
    {
        string tit = title.Value;
        string content = post_body.InnerText;
        Boolean b = us.InsertChat(recid, senduid, tit, content);
        if (b)
        {
            Response.Write(Util.ShowMessage("发送成功!"));
        }
        else
        {
            Response.Write(Util.ShowMessage("发送失败！"));
        }
    }

    protected void back_ServerClick(object sender, EventArgs e)
    {
        string url="";
        if (!pagenum.Equals("-1"))
        {
            url = pageback + "?pagenum=" + pagenum;
        }
        else
        {
            url = pageback;
        }
        Response.Redirect(url);
    }
}