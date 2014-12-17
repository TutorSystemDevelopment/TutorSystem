using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Web_teacherManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null || Session["usertype"] == null || !Session["usertype"].ToString().Equals("2")) Response.Redirect("../Web/PermissionsError.aspx");
        nowpage = Request["pagenum"] == null ? 1 : int.Parse(Request["pagenum"].ToString());
        if (!IsPostBack)
        {
            BindBackstageHead();
            BindFooter();
            BindTutorNode(nowpage);
            BindPageIndex();
            SetPageBT(1);
        }
    }

    private int pagesize = 10;
    private int pageindex = 1;
    private int nowpage = 1;
    private TutorMMC mmc = new TutorMMC();

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }

    private void BindBackstageHead()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        head.InnerHtml = Util.ReadInfoFromXML(FilePath, "backstage_head");
    }

    private void BindTutorNode(int index)
    {
        string path = Server.MapPath("..//") + "Web\\Content.xml";
        tutornode.InnerHtml = mmc.GetTutorNode(path, index, pagesize,int.Parse(flag.InnerText.ToString()));
    }


    private void BindPageIndex()
    {
        int num = mmc.GetALLNodeNum();
        int infact = (num + pagesize - 1) / pagesize;//总共的页数
        allpage.InnerText = infact.ToString();
        int npgeindex = int.Parse(nowpageindex.InnerText);
        int npnum = int.Parse(nowpagenum.InnerText);
        if (5*npgeindex < infact)///5是显示的页数
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
            for (int i = 6-dif; i <= 5 ; i++)
            {
                string aid = "a_";
                int real = i % 5 == 0 ? 5 : i % 5;
                paginate.FindControl(aid + real).Visible = false;
            }
            paginate.FindControl("a_6").Visible = false;
        }
        
    }

    


    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor a = sender as HtmlAnchor;
        int num =nowpage= int.Parse(a.InnerText);
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

        ////int num = int.Parse(a_5.InnerText);
        //
        //if (num < actualallpage)
        //{
        //    pageindex++;
        //    Session["pageindex"] = pageindex;
        //    a_1.InnerText = (5 * pageindex - 4).ToString();
        //    a_2.InnerText = (5 * pageindex - 3).ToString();
        //    a_3.InnerText = (5 * pageindex - 2).ToString();
        //    a_4.InnerText = (5 * pageindex - 1).ToString();
        //    a_5.InnerText = (5 * pageindex).ToString();
        //    BindPageIndex();
        //}

    }

    private void SetPageBT(int num)
    {
        string fre="a_";
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
        if (npge != 1 && npge != npgeindex*5-4)
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

        //if (num > 1)
        //{
        //    pageindex--;
        //    Session["pageindex"] = pageindex;
        //    a_1.InnerText = (5 * pageindex - 4).ToString();
        //    a_2.InnerText = (5 * pageindex - 3).ToString();
        //    a_3.InnerText = (5 * pageindex - 2).ToString();
        //    a_4.InnerText = (5 * pageindex - 1).ToString();
        //    a_5.InnerText = (5 * pageindex).ToString();
        //    a_1.Visible = true;
        //    a_2.Visible = true;
        //    a_3.Visible = true;
        //    a_4.Visible = true;
        //    a_5.Visible = true;

        //    BindPageIndex();
        //}
    }
    /// <summary>
    /// 初始化 分页按钮
    /// </summary>
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



    protected void bt_all_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_all.Attributes.Add("style", "color:#f40;");
        flag.InnerText = "0";
        BindTutorNode(1);
        BindPageIndex();
    }


    protected void bt_pass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_pass.Attributes.Add("style", "color:#f40;");
        flag.InnerText = "1";
        BindTutorNode(1);
        BindPageIndex();
    }


    protected void bt_notpass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_notpass.Attributes.Add("style", "color:#f40;");
        flag.InnerText = "2";
        BindTutorNode(1);
        BindPageIndex();
    }


    protected void bt_recommand_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_recommand.Attributes.Add("style", "color:#f40;");
        flag.InnerText = "3";
        BindTutorNode(1);
        BindPageIndex();
    }

    protected void bt_index_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_index.Attributes.Add("style", "color:#f40;");
        flag.InnerText = "4";
        BindTutorNode(1);
        BindPageIndex();
    }


    private void MoveBTStyle()
    {
        abt_all.Attributes.Remove("style");
        abt_pass.Attributes.Remove("style");
        abt_notpass.Attributes.Remove("style");
        abt_index.Attributes.Remove("style");
        abt_recommand.Attributes.Remove("style");
    }
    
}