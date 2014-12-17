using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Web_Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1")) Response.Redirect("login.aspx");
        if (Request["ID"] == null)
        {
            tutorid = Session["ID"] == null ? "1" : Session["ID"].ToString();
        }
        else
        {
            tutorid = Request["ID"].ToString();
        }
        if (!IsPostBack)
        {
            initpage();
            BindCommentAveStar();
            BindCommentNode(1);
            BindPageIndex();
        }
    }

    private string tutorid="1";

    private int pagesize = 10;
    private int pageindex = 1;

    private CommentC cc = new CommentC();
    private TutorCommentDao tuc = new TutorCommentDao();
    public void BindCommentNode(int num)
    {
        string filepath=Server.MapPath("..//") + "Web\\Content.xml";
        string html = cc.GetComment(tutorid, filepath, pagesize,num);
        comment.InnerHtml = html;

    }
    /// <summary>
    /// 绑定平均分数
    /// </summary>
    public void BindCommentAveStar()
    {
        float re = tuc.GetAverageStar(tutorid);
        string temp = "    共{0}次打分";
        string num = tuc.GetAllComNum(tutorid);
        temp = string.Format(temp, num);
        avestar.InnerText = re.ToString("0.0");
        comnum.InnerText = temp;
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
        BindCommentNode(num );
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
            BindCommentNode(npge );
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
            BindCommentNode(npge );

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
            BindCommentNode(npge);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindCommentNode(npge );
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
        int num = cc.GetAllNodeNum();
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