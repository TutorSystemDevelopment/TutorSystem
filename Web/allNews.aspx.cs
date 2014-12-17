using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Web_allNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pageindex = Session["pageindex"] == null ? 1 : int.Parse(Session["pageindex"].ToString());
        if (!IsPostBack)
        {
            BindHead();
            BindFooter();
            BindNewsNode(1, pagesize);
            BindPageIndex();
            BindRollNews();
            BindTopNews();
            BindTutor();
        }
    }

    private int pagesize = 10;
    private int pageindex = 1;

    private AllNewsC all = new AllNewsC();
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

    private void BindTutor()
    {
        string html = all.GetTeacherAdsHtml(4);
        teacherAds.InnerHtml = html;
    }

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }


    private void BindNewsNode(int pageindex,int pagesize)
    {
        string html = all.GetAllNewsNode(pageindex, pagesize);
        new_node.InnerHtml = html;
    }


    private void BindRollNews()
    {
        string html = all.GetNewsRoll();
        new_roll.InnerHtml = html;
    }

    private void BindTopNews()
    {
        string html = all.GetTopNews(10);
        new_top.InnerHtml = html;
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
        BindNewsNode(num, pagesize);
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
            BindNewsNode(npge, pagesize);
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
            BindNewsNode(npge, pagesize);

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
            BindNewsNode(npge, pagesize);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindNewsNode(npge, pagesize);
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
        int num = all.GetAllNewsNum();
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




}