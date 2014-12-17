using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Collections;

public partial class Web_allTeachers : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        pageindex = Session["pageindex"] == null ? 1 : int.Parse(Session["pageindex"].ToString());
        //usertype = Session["usertype"] == null ? "-1" : Session["usertype"].ToString();
        BindSearchCourse();
        if (!IsPostBack)
        {
            initpage();
            BindTutorNode(1);
            BindHead();
            BindPageIndex();
            BindFooter();
        }
    }

    private AllteacherControl all = new AllteacherControl();

    private int pagesize = 10;
    private int pageindex = 1;
    //private int actualallpage = 0;

    private void BindSearchCourse()
    {
        //s_course.InnerHtml = all.GetSearchBT("bt_course");
        ArrayList ar = all.GetAllCourse();
        for (int i = 0; i < ar.Count; i++)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlAnchor a=new HtmlAnchor();
            a.ID="bt_course" + i;
            a.ServerClick +=bt_course_ServerClick;
            a.InnerText=ar[i].ToString();
            li.Controls.Add(a);
            
            
            //Button bt = new Button();
            //bt.ID = "bt_course" + i;
            //bt.Click += bt_course_ServerClick;
            //bt.CssClass = "searchbutton";
            //bt.Attributes["style"] = "background-color:#333;height:30px;margin-left:30px;";
            //bt.Text = ar[i].ToString();
            find_course.Controls.Add(li);
        }
    }

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }

    private void BindTutorNode(int index)
    {
        string path = Server.MapPath("..//") + "Web\\Content.xml";
        tutornode.InnerHtml = all.GetTutorNode(path, index, pagesize, lb_sex.Text, lb_course.Text, lb_price.Text);
    }


    private void BindTutorByName(int index,string tutorname)
    {
        string path = Server.MapPath("..//") + "Web\\Content.xml";
        tutornode.InnerHtml = all.GetTutorNodeByName(path, index, pagesize, tutorname);
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
    /// <summary>
    /// 单击页面所触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor a = sender as HtmlAnchor;
        int num = int.Parse(a.InnerText);
        nowpagenum.InnerText = num.ToString();
        SetPageBT(num);
        BindTutorNode(num);
    }

    /// <summary>
    /// 单击最后所触发的事件
    /// </summary>
    /// <param name="sender"></param>nowpagenum
    /// <param name="e"></param>
    protected void a_last_ServerClick(object sender, EventArgs e)
    {
        int npge = int.Parse(nowpagenum.InnerText);
        int actualallpage = int.Parse(allpage.InnerText);
        int npgeindex = int.Parse(nowpageindex.InnerText);
        if (npge < npgeindex * 5 && npge < actualallpage)
        {
            npge++;
            nowpagenum.InnerText = npge.ToString();
            BindTutorNode(npge);
            //改变按钮的颜色

        }
        else if (npge == npgeindex * 5 && npge < actualallpage)
        {
            npge++;
            nowpagenum.InnerText = npge.ToString();
            npgeindex++;
            nowpageindex.InnerText = npgeindex.ToString();
            a_1.InnerText = (5 * npgeindex - 4).ToString();
            a_2.InnerText = (5 * npgeindex - 3).ToString();
            a_3.InnerText = (5 * npgeindex - 2).ToString();
            a_4.InnerText = (5 * npgeindex - 1).ToString();
            a_5.InnerText = (5 * npgeindex).ToString();
            BindTutorNode(npge);

            BindPageIndex();
        }
        SetPageBT(npge);

    }

    private void SetPageBT(int num)
    {
        string fre = "a_";
        int index = num % 5 == 0 ? 5 : num % 5;
        for (int i = 1; i < 6; i++)
        {
            HtmlAnchor a = paginate.FindControl(fre + i) as HtmlAnchor;
            a.Attributes.Remove("style");
        }
        HtmlAnchor temp = paginate.FindControl(fre + index) as HtmlAnchor;
        temp.Attributes.Add("style", "border-color:#f40;background-color:#f40;color:white;");
    }

    /// <summary>
    /// 单击前所触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void a_front_ServerClick(object sender, EventArgs e)
    {
        int npge = int.Parse(nowpagenum.InnerText);
        int npgeindex = int.Parse(nowpageindex.InnerText);
        if (npge != 1 && npge != npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindTutorNode(npge);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindTutorNode(npge);
            npgeindex--;
            nowpageindex.InnerText = npgeindex.ToString();
            a_1.InnerText = (5 * npgeindex - 4).ToString();
            a_2.InnerText = (5 * npgeindex - 3).ToString();
            a_3.InnerText = (5 * npgeindex - 2).ToString();
            a_4.InnerText = (5 * npgeindex - 1).ToString();
            a_5.InnerText = (5 * npgeindex).ToString();
            a_1.Visible = true;
            a_2.Visible = true;
            a_3.Visible = true;
            a_4.Visible = true;
            a_5.Visible = true;
            a_6.Visible = true;
        }
        SetPageBT(npge);
    }

    private void BindPageIndex()
    {
        int num = all.GetALLNodeNum();
        int infact = (num + pagesize - 1) / pagesize;//总共的页数
        allpage.InnerText = infact.ToString();
        int npgeindex = int.Parse(nowpageindex.InnerText);
        int npnum = int.Parse(nowpagenum.InnerText);

        if (5 * npgeindex < infact)///5是显示的页数
        {
            for (int i = 0; i < 6; i++)// 初始化都出现
            {
                string aid = "a_";
                int real = i % 6 == 0 ? 6 : i % 6;
                paginate.FindControl(aid + real).Visible = true;
            }
        }
        else
        {
            int dif = 5 * npgeindex - infact;
            for (int i = 6 - dif; i <= 5; i++)
            {
                string aid = "a_";
                int real = i % 5 == 0 ? 5 : i % 5;
                paginate.FindControl(aid + real).Visible = false;
            }
            paginate.FindControl("a_6").Visible = false;
        }
    }

    private void initpage()
    {
        nowpageindex.InnerText = "1";
        nowpagenum.InnerText = "1";
        a_1.InnerText = (1).ToString();
        a_2.InnerText = (2).ToString();
        a_3.InnerText = (3).ToString();
        a_4.InnerText = (4).ToString();
        a_5.InnerText = (5).ToString();
        a_1.Visible = true;
        a_2.Visible = true;
        a_3.Visible = true;
        a_4.Visible = true;
        a_5.Visible = true;
        a_6.Visible = true;
        SetPageBT(1);
    }

    /// <summary>
    /// 点击查询所需要的情况
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_sure_Click(object sender, EventArgs e)
    {
        initpage();
        BindTutorNode(1);
        BindPageIndex();
    }


    protected void bt_pri_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor bt = sender as HtmlAnchor;
        SetPriBackGround(bt.ID);
        if (bt.Attributes["style"] == null || bt.Attributes["style"] == "color:#555;")
        {
            bt.Attributes["style"] = "color:orangered;";
            if (!bt.InnerText.Equals("50"))
                lb_price.Text = bt.InnerText.Split('~')[1];
            else
                lb_price.Text = bt.InnerText;
        }
        else
        {
            bt.Attributes["style"] = "color:#555;";
            lb_price.Text = "";
        }
    }




    protected void bt_sex_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor bt = sender as HtmlAnchor;
        SetSexBackGround(bt.ID);
        if (bt.Attributes["style"]==null||bt.Attributes["style"] == "color:#555;")
        {
            bt.Attributes["style"] = "color:orangered;";
            lb_sex.Text = bt.InnerText;
            
        }
        else
        {
            bt.Attributes["style"] = "color:#555;";
            lb_sex.Text = "";
        }
    }

    protected void bt_course_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor bt = sender as HtmlAnchor;
        if (bt.Attributes["style"] == null || bt.Attributes["style"] == "color:#555;")
            bt.Attributes["style"] = "color:orangered;";
        else
            bt.Attributes["style"] = "color:#555;";
        GetSelectCourse();
    }


    /// <summary>
    /// 得到选择的课程 写在lb_course 中
    /// </summary>
    private void GetSelectCourse()
    {
        lb_course.Text = "";
        for (int i = 0; i < find_course.Controls.Count; i++)
        {
            HtmlAnchor bt = find_course.FindControl("bt_course" + i) as HtmlAnchor;
            //HtmlAnchor a=bt.FindControl() HtmlAnchor
            if (bt != null && bt.Attributes["style"] == "color:orangered;")
            {
                lb_course.Text += bt.InnerText + ",";
            }
        }
    }


    private void SetPriBackGround(string id)
    {
        //string bt="bt_pri";
        for (int i = 0; i < find_price.Controls.Count; i++)
        {
            HtmlAnchor temp = find_price.Controls[i] as HtmlAnchor;
            if (temp != null && !temp.ID.Equals(id))
            {
                temp.Attributes["style"] = "color:#555;";
            }
        }

    }

    private void SetSexBackGround(string id)
    {

        for (int i = 0; i < find_sex.Controls.Count; i++)
        {
            HtmlAnchor temp = find_sex.Controls[i] as HtmlAnchor;
            if (temp != null && !temp.ID.Equals(id))
            {
                temp.Attributes["style"] = "color:#555;";
            }
        }
    }

    private void SetCourseBackGround()
    {
        for (int i = 0; i < find_course.Controls.Count; i++)
        {
            HtmlAnchor bt = find_course.FindControl("bt_course" + i) as HtmlAnchor;
            //HtmlAnchor a=bt.FindControl() HtmlAnchor
            if(bt!=null)
                bt.Attributes["style"] = "color:#555;";
        }
    }

    protected void sort_clear_Click(object sender, EventArgs e)
    {
        SetSexBackGround("");
        SetPriBackGround("");
        SetCourseBackGround();
        lb_price.Text = "";
        lb_sex.Text = "";
        lb_course.Text = "";
    }


 
    /// <summary>
    /// 点击搜索  所触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_serchname_Click(object sender, EventArgs e)
    {
        SetSexBackGround("");
        SetPriBackGround("");
        SetCourseBackGround();
        lb_price.Text = "";
        lb_sex.Text = "";
        lb_course.Text = "";
        string name = find_tutorname.Value;
        if (name.Trim().Equals(""))
        {
            Response.Write(Util.ShowMessage("请输入老师名字！"));
            return;
        }
        else
        {
            BindTutorByName(1, name);
            BindPageIndex();
        }
    }


}