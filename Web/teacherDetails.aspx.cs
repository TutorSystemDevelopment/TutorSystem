using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;

public partial class Web_teacherDetails : System.Web.UI.Page
{

    private string tutorid = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        tutorid = Request["tutorid"] == null ? "57" : Request["tutorid"].ToString();
        //tutorid = Session["tutorid"] == null ? "1" : Session["tutorid"].ToString();
        tuid.InnerText = tutorid;
        if (!IsPostBack)
        {
            BindGradeBT();
            BindCourseBT();
            BindIntro();
            BindAdvice();
            BindTimeLine();
            BindHead();
            BindFooter();
          //  string i = Request["selectcourse"] == null ? null : Request["selectcourse"];
        }
    }


    private void BindTimeLine()
    {
        string html = de.GetTimeLineHtml(tutorid);
        timeline_year.InnerHtml = html;
    }

    private void BindAdvice()
    {
        string ad = de.GetAdvice(tutorid);
        recommend.InnerHtml = ad;
    }


    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
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

   

    private DetailsControl de = new DetailsControl();

    private void BindGradeBT()
    {
        string html = de.GetGradeBTHtml(tutorid);
        info_Grade.InnerHtml = html;
    }



    private void BindCourseBT()
    {
        string html = de.GetCourseBTHtml(tutorid);
        info_course.InnerHtml = html;
    }

    

    private void BindIntro()
    {
        DataRow dr = de.GetTutorBYID(tutorid);
        info_name.InnerText = hidtutorname.Value = dr["Name"].ToString();
        info_intro.InnerHtml = dr["Intro"].ToString();
        info_resume.InnerHtml = dr["Resume"].ToString();
        info_img.Src = "../images/" + dr["Photo"].ToString();
        li_Uni.InnerText = dr["University"].ToString();
        li_sex.InnerText = dr["Gender"].ToString() ;
    }



    protected void info_reser_Click(object sender, EventArgs e)
    {
        string grade = selectgrade.InnerText.ToString();
        string course = selectcourse.InnerText.ToString();

    }

    protected void return_Click(object sender, EventArgs e)
    {
        Response.Redirect("allTeachers.aspx");
    }

    protected void info_reser_ServerClick(object sender, EventArgs e)
    {
        string course = hidcourse.Value.ToString();
        string grade = hidgrade.Value.ToString();
        if (Session["usertype"] == null || !Session["usertype"].Equals("0") || Session["ID"] == null)
        {
            Response.Write(Util.ShowMessage("请登录！", "login.aspx"));
            return;
        }
        if(grade.Trim().Equals("")||course.Trim().Equals(""))
        {
            Response.Write(Util.ShowMessage("请选择年级和科目！"));
            return ;
        }
        grade = "所选年级：" + grade;
        
        course=course.Substring(0,course.LastIndexOf(','));
        course = "所选科目：" + course;
        string tutor = "任课教师：" + hidtutorname.Value;
        sure_gade.InnerText = grade;
        sure_course.InnerText = course;
        sure_tutor.InnerText = tutor;
        
        light.Attributes.Add("style", "display:block");
        fade.Attributes.Add("style", "display:block");

    }


    protected void sure_btsure_ServerClick(object sender, EventArgs e)
    {
        string grade = hidgrade.Value.ToString();
        string course = hidcourse.Value.ToString();
        string stuid = Session["ID"].ToString();
        //string stuid = "0";
        Mail mail = new Mail();
        try
        {
            de.InsertReservation(tutorid, stuid, course, grade);
            Response.Write(Util.ShowMessage("预约成功,管理员稍后会与您进行联系！"));
            light.Attributes.Add("style", "display:none");
            fade.Attributes.Add("style", "display:none");
            try
            {
                mail.SendMail("499048451@qq.com", "收到新的预约", "有新的教师预约，请注意查收！");
            }
            catch
            {

            }
        }
        catch
        {
            Response.Write(Util.ShowMessage("预约失败,请于管理员进行联系！"));
        }
       
         
    }
    protected void sure_btcancel_ServerClick(object sender, EventArgs e)
    {
        hidcourse.Value = "";
        hidgrade.Value = "";
        light.Attributes.Add("style", "display:none");
        fade.Attributes.Add("style", "display:none");
    }
}