using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class Web_Default2 : System.Web.UI.Page
{
    private TutorDao td = new TutorDao();

    private string TutorID = "59";
    private int Time;
    private string Title;
    private string Year;
    private string Month;
    private string Items;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1") || Session["ID"] == null) Response.Redirect("PermissionsError.aspx");

        TutorID = Session["ID"].ToString();
        if (!IsPostBack)
        {
            Label1.Text = "0"; // LineID，为0则为添加，否则为编辑
            bindgridview();
            UpdateTime();
        }
    }

    private void bindgridview()
    {
        DataSet ds = td.GetTutorTimeLineByOrder(TutorID);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataKeyNames = new string[] { "LineID" }; 
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        td.DeleteTutorTimeLine(id);
        bindgridview();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TitleText.Text != "" && TextArea1.Text != "" && !equalsTime())
        {
            Year = DropDownList1.Text;
            Month = DropDownList2.Text;
            Title = TitleText.Text;
            Items = TextArea1.Text;
            td.InsertTutorTimeLine(Year, Month, Title, Items, TutorID);
            bindgridview();
            TitleText.Text = "";
            TextArea1.Text = "";
            Response.Write("<script language=\"JavaScript\">alert(\"添加成功!\")</script>");
        }
        else Response.Write("<script language=\"JavaScript\">alert(\"添加失败!\")</script>");
    }

    private void UpdateTime()
    {
        int i;
        Time = Int32.Parse(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4));
        for (i = 0; i < 5; i++ )
        {
            DropDownList1.Items.Add(new ListItem((Time - i).ToString(), (Time - i).ToString()));
        }
        // DropDownList1.Items.Add(new ListItem((Time - i + 1).ToString() + "之前", (Time - i + 1).ToString() + "之前"));
    }

    private Boolean equalsTime()
    {
        DataSet ds = td.GetTutorTimeLineByOrder(TutorID);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["Year"].ToString().Equals(DropDownList1.Text) && ds.Tables[0].Rows[i]["Month"].ToString().Equals(DropDownList2.Text))
            {
                Response.Write("<script language=\"JavaScript\">alert(\"插入日期不能相同!\")</script>");
                return true;
            }
        }
        return false;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    Label1.Text = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
    //    DataSet ds = td.GetTutorTimeLineByLineID(Label1.Text);



    //    DropDownList1.Text = ds.Tables[0].Rows[0]["Year"].ToString();
    //    DropDownList2.Text = ds.Tables[0].Rows[0]["Month"].ToString();
    //    TitleText.Text = ds.Tables[0].Rows[0]["Title"].ToString();
    //    TextArea1.Text = ds.Tables[0].Rows[0]["Items"].ToString();

    //    bindgridview();
    //}

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Label1.Text = GridView1.Value.ToString();
        //DataSet ds = td.GetTutorTimeLineByLineID(Label1.Text);

        GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值
        string id = GridView1.DataKeys[drv.RowIndex].Value.ToString(); //此获取的值为GridView中绑定数据库中的主键值

        switch (e.CommandName)
        {
            case "editor":
                DataSet ds = td.GetTutorTimeLineByLineID(id);

                DropDownList1.Text = ds.Tables[0].Rows[0]["Year"].ToString();
                DropDownList2.Text = ds.Tables[0].Rows[0]["Month"].ToString();
                TitleText.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                TextArea1.Text = ds.Tables[0].Rows[0]["Items"].ToString();
                break;
            case "deleteor":
                td.DeleteTutorTimeLine(id);
                bindgridview();
                break;
        }
    }
}