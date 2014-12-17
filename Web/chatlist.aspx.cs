using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class Web_chatlist : System.Web.UI.Page
{
    BasicDao ba = new BasicDao();
    string RID = "25";//收信人UUID
    string CID = "";//所查看信件来自的UUID
    string RName = "";//回复的接收方的姓名
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usertype"] == null || Session["Uid"] == null) Response.Redirect("permissionserror.aspx");
        RID = Session["Uid"].ToString();
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        GridView1.Columns[5].Visible = true;
        GridView2.Columns[5].Visible = true;
        GridView1.Columns[7].Visible = true;
        GridView2.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = true;
        GridView2.Columns[8].Visible = true;

        string date = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        string sql1 = "select * from Chat where RecieveUID=@id and Time>@date";
        string sql2 = "select * from Chat where RecieveUID=@id and Time<=@date";
        SqlParameter[] pa1 = { new SqlParameter("@id", RID), new SqlParameter("@date", date) };
        SqlParameter[] pa2 = { new SqlParameter("@id", RID), new SqlParameter("@date", date) };

        DataSet myds1 = ba.GetDataSet(sql1, pa1);
        GridView1.DataSource = myds1;
        GridView1.DataKeyNames = new string[] {  "Title", "ChatContent", "Time", "IsRead", "ChatID", "SendUID" };
        GridView1.DataBind();

        DataSet myds2 = ba.GetDataSet(sql2, pa2);
        GridView2.DataSource = myds2;
        GridView2.DataKeyNames = new string[] { "Title", "ChatContent", "Time", "IsRead","ChatID", "SendUID" };
        GridView2.DataBind();

        GridView1.Columns[5].Visible = false;
        GridView2.Columns[5].Visible = false;
        GridView1.Columns[7].Visible = false;
        GridView2.Columns[7].Visible = false;
        GridView1.Columns[8].Visible = false;
        GridView2.Columns[8].Visible = false;

        this.DropDownList1.Items.Clear();
        this.DropDownList2.Items.Clear();
        for (int i = 1; i <= this.GridView1.PageCount; i++)
        {
            this.DropDownList1.Items.Add(i.ToString());
        }
        if (GridView1.Rows.Count >0)
        {
            this.DropDownList1.SelectedIndex = this.GridView1.PageIndex;
        }

        for (int i = 1; i <= this.GridView2.PageCount; i++)
        {
            this.DropDownList2.Items.Add(i.ToString());
        }
        if (GridView2.Rows.Count >0)
        {
            this.DropDownList2.SelectedIndex = this.GridView2.PageIndex;
        }
    }

    private string getNameByUID(string uid)
    {
        string re = "";
        string sql = "";
        if (getTypeByUID(uid) == "0")
        {
            sql = "select Name from Student where StuID=@SID";
            SqlParameter[] pa={ new SqlParameter("@SID",getIDByUID(uid))};
            re = ba.ReString(sql, pa, 0);
            return re;
        }
        else if (getTypeByUID(uid) == "1")
        {
            sql = "select Name from Tutor where TutorID=@TID";
            SqlParameter[] pa={ new SqlParameter("@TID",getIDByUID(uid))};
            re = ba.ReString(sql, pa, 0);
            return re;
        }
        else if (getTypeByUID(uid) == "2")
        {
            return "管理员";
        }
        else return "错误！";
    }

    private string getTypeByUID(string uid)
    {
        string re = "";
        string sql = "select Type from tb_User where UUID=@uid";

        SqlParameter[] pa = { new SqlParameter("@uid", uid) };
        re = ba.ReString(sql, pa, 0);
        return re;
    }

    private string getIDByUID(string uid)
    {
        string re = "";
        string sql = "select ID from tb_User where UUID=@uid";

        SqlParameter[] pa = { new SqlParameter("@uid", uid) };
        re = ba.ReString(sql, pa, 0);
        return re;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.Label3.Text = string.Format("当前第{0}页/总共{1}页", this.GridView1.PageIndex + 1, this.GridView1.PageCount);

        int t;
        if (int.TryParse(e.Row.Cells[1].Text, out t))
        {//ID换成用户名
            e.Row.Cells[8].Text = e.Row.Cells[1].Text;
            e.Row.Cells[1].Text = getNameByUID(e.Row.Cells[1].Text);
        }

        LinkButton l = (LinkButton)e.Row.FindControl("查看");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image pic = (Image)e.Row.FindControl("Image1");
            if (e.Row.Cells[5].Text == "0")
            {
                pic.ImageUrl = "~/images/log/unread.png";
            }
            else if (e.Row.Cells[5].Text == "1")
            {
                pic.ImageUrl = "~/images/log/read.png";
            }

            e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;
            if (e.Row.Cells[2].Text.Length > 15)
            {
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 15) + "...";
            }
            e.Row.Cells[3].ToolTip = e.Row.Cells[3].Text;
            if (e.Row.Cells[3].Text.Length > 15)
            {
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 15) + "...";
            }
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.Label4.Text = string.Format("当前第{0}页/总共{1}页", this.GridView2.PageIndex + 1, this.GridView2.PageCount);

        int t;
        if (int.TryParse(e.Row.Cells[1].Text, out t))
        {
            e.Row.Cells[8].Text = e.Row.Cells[1].Text;
            e.Row.Cells[1].Text = getNameByUID(e.Row.Cells[1].Text);
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image pic = (Image)e.Row.FindControl("Image2");
            if (e.Row.Cells[5].Text == "0")
            {
                pic.ImageUrl = "~/images/log/unread.png";
            }
            else if (e.Row.Cells[5].Text == "1")
            {
                pic.ImageUrl = "~/images/log/read.png";
            }


            if (e.Row.Cells[2].Text.Length > 15)
            {
                e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 15) + "...";
            }
            if (e.Row.Cells[3].Text.Length > 15)
            {
                e.Row.Cells[3].ToolTip = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 15) + "...";
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        bind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex > 0)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex - 1;
            bind();
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex < this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
            bind();
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.GridView1.PageCount;
        bind();
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        this.GridView2.PageIndex = 0;
        bind();
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        if (this.GridView2.PageIndex > 0)
        {
            this.GridView2.PageIndex = this.GridView2.PageIndex - 1;
            bind();
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        if (this.GridView2.PageIndex < this.GridView2.PageCount)
        {
            this.GridView2.PageIndex = this.GridView2.PageIndex + 1;
            bind();
        }
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        this.GridView2.PageIndex = this.GridView2.PageCount;
        bind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.DropDownList1.SelectedIndex;
        bind();
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView2.PageIndex = this.DropDownList2.SelectedIndex;
        bind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.DropDownList1.SelectedIndex;
        bind();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView2.PageIndex = this.DropDownList2.SelectedIndex;
        bind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument.ToString()) - (this.GridView1.PageIndex * this.GridView1.PageSize);
        GridView1.Columns[8].Visible = true;
        lb_cid.Text = CID = this.GridView1.Rows[rowIndex].Cells[8].Text;
        lb_Rname.Text= RName = getNameByUID(CID);
        GridView1.Columns[8].Visible = false;

        dialog.Attributes.Add("style", "display:block");
        background.Attributes.Add("style", "display:block");
        chatDetails.InnerText = GridView1.Rows[rowIndex].Cells[3].ToolTip;

        string sql = "update Chat set IsRead = 1 where ChatID = " + GridView1.Rows[rowIndex].Cells[7].Text;
        ba.ExecNonQuery(sql, null);
        bind();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument.ToString()) - (this.GridView2.PageIndex * this.GridView2.PageSize);
        GridView2.Columns[8].Visible = true;
        lb_cid.Text = CID = GridView2.Rows[rowIndex].Cells[8].Text;
        lb_Rname.Text = RName = getNameByUID(CID);
        GridView2.Columns[8].Visible = false;

        dialog.Attributes.Add("style", "display:block");
        background.Attributes.Add("style", "display:block");
        chatDetails.InnerText = GridView2.Rows[rowIndex].Cells[3].ToolTip;

        string sql = "update Chat set IsRead = 1 where ChatID = " + GridView2.Rows[rowIndex].Cells[7].Text;
        ba.ExecNonQuery(sql, null);
        bind();
    }

    protected void check_ServerClick(object sender, EventArgs e)
    {
        //dialog.Attributes.Add("style", "display:block");
        //background.Attributes.Add("style", "display:block");
        //chatDetails.InnerText = GridView1.
    }
    protected void cancel_btn_ServerClick(object sender, EventArgs e)
    {
        dialog.Attributes.Add("style", "display:none");
        background.Attributes.Add("style", "display:none");
    }
    protected void confirm_btn_ServerClick(object sender, EventArgs e)
    {
        //string a = RID;
        //string b = CID;
        //string rnam = RName;
        Response.Redirect("../Backstage/SendMessege.aspx?Uid=" +RID + "&recid=" + lb_cid.Text+"&Name="+lb_Rname.Text);
    }
    
}