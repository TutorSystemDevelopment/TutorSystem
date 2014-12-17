using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Web_index : System.Web.UI.Page
{

    private IndexControl indcon = new IndexControl();
    //private string toptutorid;

    private string usertype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //string FilePath = Server.MapPath("..//");
        //string xmlpath = FilePath + "Web\\Content.xml";
        //owl_demo.InnerHtml = Util.ReadInfoNewTop(xmlpath, "test");
        //string target = Request["tagname"] == null ? null : Request["tagname"].ToString();
        //if(target!=null) 
       // toptutorid = Request["toptutor"] == null ? "1" : Request["toptutor"].ToString(); 
        usertype = Session["usertype"] == null ? "-1" : Session["usertype"].ToString();
       

        if (!IsPostBack)
        {
            
            //BindTopTutor();
           // BindTopTutorInfo();
            BindHead();
            BindFooter();
            BindTopNew();
        }
        
    }

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


    private void BindTopNew()
    {
        string FilePath = Server.MapPath("..//");
        try
        {
            string html = indcon.GetTopNewHtml(FilePath);
            newtop.InnerHtml = html;
            //if (html == null)
            //{
            //    Response.Redirect("PermissionsError.aspx");
            //}
        }
        catch (Exception e)
        {
            Response.Redirect("PermissionsError.aspx");
        }
    }

    //private void BindTopTutor()
    //{
    //    string html = indcon.GetTopTutorHtml();
    //    owl_demo.InnerHtml = html;
    //    //owl_demo.InnerHtml="";
    //}

    //private void BindTopTutorInfo()
    //{
    //    if (toptutorid != null)
    //    {
    //        Session["tutorid"] = toptutorid;
    //        DataRow dr = indcon.GetTutorIntro(toptutorid);
    //        string i = "../images/" + dr["Photo"];
    //        info_pic.Attributes.Add("src", "../images/" + dr["Photo"]);
    //        string temp = string.Format("012理科实验班班主任<br /><span>特级教师：{0}</span>", dr["Name"]);
    //        info_title.InnerHtml = temp;
    //        info_intro.InnerText = dr["Intro"].ToString();
    //        info_readmore.Attributes.Add("href", "teacherDetails.aspx?tutorid=" + toptutorid);
    //    }
    //}




}