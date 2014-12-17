using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Web_StuReservation : System.Web.UI.Page
{
    private PagedDataSource pgSource = new PagedDataSource();
    private ReservationDao res = new ReservationDao();
    private UserDao us = new UserDao();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("0") || Session["ID"] == null)
            Response.Redirect("PermissionsError.aspx");
        pageindex = Session["pageindex"] == null ? 1 : int.Parse(Session["pageindex"].ToString());
        stuid = Session["ID"].ToString();
        if (!IsPostBack)
        {
            initpage();
            BindDateList(0);
            BindPageIndex();
        }
    }


    private string stuid = "1";

    private int pagesize = 10;
    private int pageindex = 1;

    private void BindDateList(int i)
    {
        //if (i < 0 || pgSource.DataSource == null) return; 
        DataSet ds = res.GetTutorAndStuBYStuid(stuid);
        pgSource.DataSource = ds.Tables[0].DefaultView;
        pgSource.AllowPaging = true;
        pgSource.PageSize = pagesize;
        //pgSource.CurrentPageIndex = 0;

        pgSource.CurrentPageIndex = i;
        this.DataList1.DataSource = pgSource;
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
                Label phone = e.Item.FindControl("lb_phone") as Label;
                phone.Text = "暂未获取";
                LinkButton send = e.Item.FindControl("bt_send") as LinkButton;
                send.Visible = false;
                LinkButton comment = e.Item.FindControl("bt_comment") as LinkButton;
                comment.Visible = false;

            }
            else if (ifpass.Text.Equals("1"))
            {
                ifpass.Text = "审核通过";
                ifpass.ForeColor = Color.Green;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
            }
            else if (ifpass.Text.Equals("2"))
            {
                ifpass.Text = "授课结束";
                ifpass.ForeColor = Color.Blue;
                //LinkButton send = e.Item.FindControl("bt_send") as LinkButton;
                //send.Visible = false;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
            }
            else if (ifpass.Text.Equals("-1"))
            {
                ifpass.Text = "取消";
                ifpass.ForeColor = Color.DarkGray;
                LinkButton send = e.Item.FindControl("bt_send") as LinkButton;
                send.Visible = false;
                LinkButton delete = e.Item.FindControl("lb_delete") as LinkButton;
                delete.Visible = false;
                LinkButton comment = e.Item.FindControl("bt_comment") as LinkButton;
                comment.Visible = false;
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
        BindDateList(num - 1);
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
            BindDateList(npge - 1);
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
            BindDateList(npge - 1);

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
            BindDateList(npge - 1);
        }
        else if (npge != 1 && npge == npgeindex * 5 - 4)
        {
            npge--;
            nowpagenum.InnerText = npge.ToString();
            BindDateList(npge - 1);
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
        int num = res.GetAllNumResStuBYStuID(stuid);
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
        Label lb_tutorid = e.Item.FindControl("lb_tutorid") as Label;
        Label lb_name = e.Item.FindControl("lb_name") as Label;
        Label lb_resid=e.Item.FindControl("lb_resid") as Label;
        string tutorid = lb_tutorid.Text;
        string url = "";
        switch (e.CommandName)
        {
            case "send":
                //url = "../Backstage/SendMessege.aspx?Uid=" + tutorid + "&&backpage=../Web/TutorOrder.aspx&&Name=" + lb_name.Text;
                string tuid = us.GetUUIDByIDAndType(tutorid, "1");
                url = "../Backstage/SendMessege.aspx?recid=" + tuid + "&&Name=" + lb_name.Text;
                Session["backpage"] = "../Web/StuReservation.aspx";
                Response.Redirect(url);
                break;
            case "delete":
                DeleteReservation(lb_resid.Text);
                BindDateList(int.Parse(nowpagenum.InnerText) - 1);
                break;
            case "check":
                 url = "teacherDetails.aspx?tutorid=" + tutorid;
                 Response.Write("<script>window.parent.location.href='"+url+"';</script>");
                 //Response.Redirect(url);
                 break;
            case "comment":
                 url = "AddressComment.aspx?resid=" + lb_resid.Text + "&&tutorid=" + lb_tutorid.Text + "&&stuid=" + stuid;
                 Response.Redirect(url);
                 break;
        }
    }


    private void DeleteReservation(string resid)
    {
       Boolean b =res.ChangeStateReservation(resid, -1);
       if (b)
       {
           Response.Write(Util.ShowMessage("删除成功！"));
       }
       else
       {
           Response.Write(Util.ShowMessage("删除失败！"));
       }
    }


   
}