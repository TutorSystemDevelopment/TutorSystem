using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Web_IndexPart2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        toptutorid = Request["toptutor"] == null ? "-1" : Request["toptutor"].ToString(); 
        if (!IsPostBack)
        {
            
            BindTopTutor();
            BindTopTutorInfo(); 
        }
    }
    private IndexControl indcon = new IndexControl();
    private TutorDao tu = new TutorDao();
    private string toptutorid;
    private void BindTopTutor()
    {
        string html = indcon.GetTopTutorHtml();
        //if (html == null)
        //{
        //    Response.Redirect("PermissionsError.aspx");
        //}
        owl_demo.InnerHtml = html;
        //owl_demo.InnerHtml="";
    }

    private void BindTopTutorInfo()
    {

        if (toptutorid == null || toptutorid.Equals("-1"))
        {
            toptutorid = tu.GetTopTutorRandomID();
        }
            Session["tutorid"] = toptutorid;
            DataRow dr = indcon.GetTutorIntro(toptutorid);
            try
            {
                string i = "images/" + dr["Photo"];
                info_pic.Attributes.Add("src", "../images/" + dr["Photo"]);
                string temp = string.Format("极致141<br /><span>金牌教师：{0}</span>", dr["Name"]);
                info_title.InnerHtml = temp;
                info_intro.InnerHtml = dr["Intro"].ToString();
                //info_readmore.Attributes.Add("href", "teacherDetails.aspx?tutorid=" + toptutorid);
                //info_readmore.Attributes.Add("title", "teacherDetails.aspx?tutorid=" + toptutorid);
                lb_tutorid.InnerText = "teacherDetails.aspx?tutorid=" + toptutorid;
            }
            catch
            {

            }
        
       
    }
}