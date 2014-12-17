using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Backstage_NewsMenege : System.Web.UI.Page
{

    private PagedDataSource pgSource = new PagedDataSource();
    private NewsDao ne = new NewsDao();
    private UserDao us = new UserDao();
    private int pagesize = 10;
    private int newspageindex = 1;
    private int type = 2;
    private string uid = "21";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null || Session["usertype"] == null || !Session["usertype"].ToString().Equals("2")) Response.Redirect("../Web/PermissionsError.aspx");
        uid = Session["Uid"].ToString();
        newspageindex = Session["newspageindex"] == null ? 1 : int.Parse(Session["newspageindex"].ToString());
        pgSource = Session["NewspgSource"] == null ? null : Session["NewspgSource"] as PagedDataSource;
        type = Session["newsfindboxtype"] == null ? 2 : int.Parse(Session["newsfindboxtype"].ToString());
        if (!IsPostBack)
        {
            BindPGSourse(2);
            BindFooter();
            BindBackstageHead();
            BindDataList(0);
            BindPageIndex(2);
            SetPageBT(1);
        }
    }



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

    private void BindPGSourse(int type)
    {

        DataSet ds = ne.GetNewsByifpass(type);
        pgSource = new PagedDataSource();
        pgSource.DataSource = ds.Tables[0].DefaultView;
        pgSource.AllowPaging = true;
        pgSource.PageSize = pagesize;
        pgSource.CurrentPageIndex = 0;
        Session["NewspgSource"] = pgSource;
    }


    private void BindDataList(int num)
    {
        if (pgSource == null)
            BindPGSourse(2);
        pgSource.CurrentPageIndex = num;
        this.DataList1.DataSource = pgSource;
        this.DataList1.DataKeyField ="NewsID";
        this.DataList1.DataBind();
    }


    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string newid = DataList1.DataKeys[e.Item.ItemIndex].ToString();

            Label ifpass = e.Item.FindControl("lb_state") as Label;
            Label content = e.Item.FindControl("lb_content") as Label;
            Label istop = e.Item.FindControl("lb_top") as Label;
            if (istop.Text.Trim().Equals("1"))
            {
                istop.Text = "已上首页";
            }
            else
            {
                istop.Text = "未上首页";
            }

            string con = content.Text;
            
             if (content.Text.IndexOf('<')>0&& content.Text.IndexOf('<') < 250)
            {
                con = con.Substring(0, content.Text.IndexOf('<'));
                con += "......";
                content.Text = con;
            }
             else if (content.Text.Length > 250 )
             {
                 con = con.Substring(0, 250);
                 con += "......";
                 content.Text = con;
             }

            if (ifpass.Text.Equals("0"))
            {
                ifpass.Text = "正在处理";
                ifpass.ForeColor = Color.Red;
                //Label phone = e.Item.FindControl("lb_phone") as Label;
                //phone.Text = "暂未获取";
                //LinkButton send = e.Item.FindControl("bt_send") as LinkButton;
                //send.Visible = false;
                Button bt_delete = e.Item.FindControl("bt_delete") as Button;
                bt_delete.Visible = false;
                Button bt_top = e.Item.FindControl("bt_top") as Button;
                bt_top.Visible = false;
            }
            else if (ifpass.Text.Equals("1"))
            {
                ifpass.Text = "审核通过";
                ifpass.ForeColor = Color.Green;
                Button bt_pass = e.Item.FindControl("bt_pass") as Button;
                bt_pass.Visible = false;
                Button send = e.Item.FindControl("bt_send") as Button;
                send.Visible = false;
                
            }
        }
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
        BindDataList(num - 1);
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
            BindDataList(npge - 1);
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
            BindDataList(npge - 1);

            BindPageIndex(type);
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
            BindDataList(npge - 1);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindDataList(npge - 1);
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

    private void BindPageIndex(int type)
    {
        int num = ne.GetNewsNumByType(type);
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




    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lb_newsid = e.Item.FindControl("lb_newid") as Label;
        Label lb_tutorid = e.Item.FindControl("lb_tutorid") as Label;
        
        Boolean b;
        switch (e.CommandName)
        {
            case "pass":
                //sponse.Redirect(url);
                b = PassNews(lb_newsid.Text);
                if (!b)
                {
                    Response.Write(Util.ShowMessage("修改失败！"));
                }
                break;
            case "send":
                b = SendMessege(lb_tutorid.Text,uid);
                if (!b)
                {
                    Response.Write(Util.ShowMessage("发送消息失败！"));
                }
                else
                {
                    Response.Write(Util.ShowMessage("发送消息成功！"));
                }
                break;
            case "top":
                b = ne.ChangeTopStateNews(lb_newsid.Text, 1);
                  if (!b)
                {
                    Response.Write(Util.ShowMessage("修改失败！"));
                }
                break;
            case "delete":
                 b = ne.ChangeTopStateNews(lb_newsid.Text, 0);
                  if (!b)
                {
                    Response.Write(Util.ShowMessage("修改失败！"));
                }
                break;
        }
        try
        {
            BindPGSourse(type);
            
            //int now = int.Parse(nowpagenum.InnerText);
            BindDataList(int.Parse(nowpagenum.InnerText) - 1);
            BindPageIndex(type);
        }
        catch
        {
            BindDataList(0);
        }
    }




    public Boolean SendMessege(string tutorid,string uid)
    {
        string title="文章未通过审核！";
        string content="请检查你的文章是否有不良信息或者格式不正确，须知详情请联系管理员！";
        string uuid = us.GetUUIDByIDAndType(tutorid, "1");
        Boolean b = us.InsertChat(uuid, uid, title, content);
        return b;
    }
  

    private Boolean PassNews(string id)
    {
        Boolean b = ne.ChangeStateNews(id, 1);
        return b;

    }



    protected void bt_all_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_all.Attributes.Add("style", "color:#f40;");
        BindPGSourse(2);
        BindDataList(0);
        BindPageIndex(2);
        Session["newsfindboxtype"] = 2;
    }
    protected void bt_pass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_pass.Attributes.Add("style", "color:#f40;");
        BindPGSourse(1);
        BindDataList(0);
        BindPageIndex(1);
        Session["newsfindboxtype"] = 1;
    }

    protected void bt_notpass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_notpass.Attributes.Add("style", "color:#f40;");
        BindPGSourse(0);
        BindDataList(0);
        BindPageIndex(0);
        Session["newsfindboxtype"] = 0;
    }

    private void MoveBTStyle()
    {
        abt_all.Attributes.Remove("style");
        abt_pass.Attributes.Remove("style");
        abt_notpass.Attributes.Remove("style");
    }

    
}