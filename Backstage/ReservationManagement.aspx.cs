using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Backstage_ReservationManagement : System.Web.UI.Page
{

    private PagedDataSource respgSource = new PagedDataSource();
    private ReservationDao res = new ReservationDao();
    private Mail mail = new Mail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null || Session["usertype"] == null || !Session["usertype"].ToString().Equals("2")) Response.Redirect("../Web/PermissionsError.aspx");
        respageindex = Session["respageindex"] == null ? 1 : int.Parse(Session["respageindex"].ToString());
        respgSource = Session["respgSource"] == null ? null : Session["respgSource"] as PagedDataSource;
        type = Session["resfindboxtype"] == null ? 3 : int.Parse(Session["resfindboxtype"].ToString());
        if (!IsPostBack)
        {
            BindPGSourse(3);
            BindFooter();
            BindBackstageHead();
            BindDatalist(0);
            BindPageIndex(3);
            SetPageBT(1);
        }
    }


    private int pagesize = 10;
    private int respageindex = 1;
    private int type = 2;

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
      
        DataSet ds = res.GetAllTutorAndStu(type);
        respgSource = new PagedDataSource();
        respgSource.DataSource = ds.Tables[0].DefaultView;
        respgSource.AllowPaging = true;
        respgSource.PageSize = pagesize;
        respgSource.CurrentPageIndex = 0;
        Session["respgSource"] = respgSource;
    }

    private void BindDatalist(int i)
    {
        //respgSource.CurrentPageIndex = 0;
        if (respgSource == null)
            BindPGSourse(3);
        respgSource.CurrentPageIndex = i;
        this.DataList1.DataSource = respgSource;
        this.DataList1.DataKeyField = "ReservationID";
        this.DataList1.DataBind();


    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string resid = DataList1.DataKeys[e.Item.ItemIndex].ToString();

            DataSet dscour = res.GetRecCourse(resid);
            string course = "";
            for (int i = 0; i < dscour.Tables[0].Rows.Count; i++)
            {
                course += dscour.Tables[0].Rows[i]["CourseName"].ToString() + ",";
            }
            course = course.Substring(0, course.LastIndexOf(','));
            Label cour = e.Item.FindControl("lb_course") as Label;
            cour.Text = course;


            Label ifpass = e.Item.FindControl("lb_state") as Label;

            if (ifpass.Text.Equals("0"))
            {
                ifpass.Text = "正在处理";
                ifpass.ForeColor = Color.Red;
                //Label phone = e.Item.FindControl("lb_phone") as Label;
                //phone.Text = "暂未获取";
                //LinkButton send = e.Item.FindControl("bt_send") as LinkButton;
                //send.Visible = false;
                LinkButton finish = e.Item.FindControl("bt_finish") as LinkButton;
                finish.Visible = false;
            }
            else if (ifpass.Text.Equals("1"))
            {
                ifpass.Text = "审核通过";
                ifpass.ForeColor = Color.Green;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
                LinkButton check = e.Item.FindControl("bt_check") as LinkButton;
                check.Visible = false;
            }
            else if (ifpass.Text.Equals("2"))
            {
                ifpass.Text = "授课结束";
                ifpass.ForeColor = Color.Green;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
                LinkButton check = e.Item.FindControl("bt_check") as LinkButton;
                check.Visible = false;
                LinkButton finish = e.Item.FindControl("bt_finish") as LinkButton;
                finish.Visible = false;
            }
            else if (ifpass.Text.Equals("-1"))
            {
                ifpass.Text = "取消";
                ifpass.ForeColor = Color.DarkGray;
                LinkButton check = e.Item.FindControl("bt_check") as LinkButton;
                check.Visible = false;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
                LinkButton finish = e.Item.FindControl("bt_finish") as LinkButton;
                finish.Visible = false;
            }


        }
    }







    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor a = sender as HtmlAnchor;
        int num = int.Parse(a.InnerText);
        nowpagenum.InnerText = num.ToString();
        SetPageBT(num);
        BindDatalist(num-1);
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
            BindDatalist(npge-1);
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
            BindDatalist(npge-1);

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
            BindDatalist(npge-1);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindDatalist(npge-1);
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
        int num = res.GetAllNumTutorAndStu(type);
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

    private void  initpage()
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
        Label lb_tutorid = e.Item.FindControl("lb_tuid") as Label;
        Label lb_name = e.Item.FindControl("lb_name") as Label;
        Label lb_stu=e.Item.FindControl("lb_stuid") as Label;
        Label lb_resid = e.Item.FindControl("lb_resid") as Label;
        string tutorid = lb_tutorid.Text;
        string stuid = lb_stu.Text;

        string stumail = (e.Item.FindControl("lb_stumail") as Label).Text;
        string tutormail = (e.Item.FindControl("lb_tutormail") as Label).Text;

        //ring url = "";
        Boolean b;
        switch (e.CommandName)
        {
            case "pass":
                
                //sponse.Redirect(url);
                b= PassReservation(lb_resid.Text);
                if (!b)
                {
                    Response.Write(Util.ShowMessage("修改失败！"));
                }
                else
                {
                    try
                    {
                        mail.SendMail(stumail, "预约通过", "你的预约通过啦你的预约通过啦你的预约通过啦");
                    }
                    catch
                    {
                        Response.Write(Util.ShowMessage("学生邮件发送失败,邮箱号可能出错！"));
                    }
                    try
                    {
                        mail.SendMail(tutormail, "预约通过", "你的预约通过啦你的预约通过啦你的预约通过啦");
                    }
                    catch
                    {
                        Response.Write(Util.ShowMessage("教师邮件发送失败,邮箱号可能出错！"));
                    }
                }
                break;
            case "delete":
                b = deleteReservation(lb_resid.Text);
                if (!b)
                {
                    Response.Write(Util.ShowMessage("修改失败！"));

                }
                else
                {
                    try
                    {
                        mail.SendMail(stumail, "预约取消", "你的预约被管理员取消");
                    }
                    catch
                    {
                        Response.Write(Util.ShowMessage("学生邮件发送失败,邮箱号可能出错！"));
                    }
                    try
                    {
                        mail.SendMail(tutormail, "预约取消", "你的预约被管理员取消");
                    }
                    catch
                    {
                        Response.Write(Util.ShowMessage("教师邮件发送失败,邮箱号可能出错！"));
                    }
                }
                break;
            case "finish":
                 b =FinishReservation(lb_resid.Text);
                 if (!b)
                 {
                     Response.Write(Util.ShowMessage("修改失败！"));
                 }
                 else
                 {
                     try
                     {
                         mail.SendMail(stumail, "授课完成", "记得给你家教评分哦！");
                         //mail.SendMail(tutormail, "预约取消", "你的预约被管理员取消");
                         Response.Write(Util.ShowMessage("已发送邮件通知学生!"));
                     }
                     catch
                     {
                         Response.Write(Util.ShowMessage("邮件发送失败,邮箱号可能出错！"));
                     }
                 }

                break;

        }
        try
        {
            BindPGSourse(type);
            BindDatalist(int.Parse(nowpagenum.InnerText) - 1);
            BindPageIndex(type);
        }
        catch
        {
            BindDatalist(0);
        }
    }

    private Boolean FinishReservation(string resid)
    {
        Boolean b = res.ChangeStateReservation(resid, 2);
        return b;
    }

    private Boolean deleteReservation(string resid)
    {
        Boolean b = res.ChangeStateReservation(resid, -1);
        return b;
    }

    private Boolean PassReservation(string resid)
    {
        Boolean b = res.ChangeStateReservation(resid,1);
        return b;

    }



    protected void bt_all_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_all.Attributes.Add("style", "color:#f40;");
        BindPGSourse(3);
        BindDatalist(0);
        BindPageIndex(3);
        Session["resfindboxtype"] = 3;
        
    }
    protected void bt_pass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_pass.Attributes.Add("style", "color:#f40;");
        BindPGSourse(1);
        BindDatalist(0);
        BindPageIndex(1);
        Session["resfindboxtype"] = 1;
        
    }

    protected void bt_notpass_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_notpass.Attributes.Add("style", "color:#f40;");
        BindPGSourse(0);
        BindDatalist(0);
        BindPageIndex(0);
        Session["resfindboxtype"] = 0;
        
    }
    protected void bt_cancel_Click(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_cancel.Attributes.Add("style", "color:#f40;");
        BindPGSourse(-1);
        BindDatalist(0);
        BindPageIndex(-1);
        Session["resfindboxtype"] = -1;
        
    }

    protected void abt_finish_ServerClick(object sender, EventArgs e)
    {
        initpage();
        MoveBTStyle();
        abt_finish.Attributes.Add("style", "color:#f40;");
        BindPGSourse(2);
        BindDatalist(0);
        BindPageIndex(2);
        Session["resfindboxtype"] = 2;
        
    }

    private void MoveBTStyle()
    {
        abt_all.Attributes.Remove("style");
        abt_pass.Attributes.Remove("style");
        abt_notpass.Attributes.Remove("style");
        abt_cancel.Attributes.Remove("style");
    }
    
}