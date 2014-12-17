using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Web_xuanke : System.Web.UI.Page
{
    BasicDao ba = new BasicDao();
    private  int tutorID = 1;//教师ID

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1") || Session["ID"] == null) Response.Redirect("PermissionsError.aspx");
        tutorID = int.Parse(Session["ID"].ToString());
        if (!IsPostBack)
        {
            bind();
            GridView1.Columns[3].Visible = false;
        }
    }

    private void bind()
    {
        string sql1 = "select * from CourseJoin where TutorID=@tutorID";
        SqlParameter[] pa1 = { new SqlParameter("@tutorID",tutorID) };

        DataSet myds1 = ba.GetDataSet(sql1, pa1);
        GridView1.DataSource = myds1;
        GridView1.DataKeyNames = new string[] { "JoinID","Grade", "CourseID", "Cost"};
        GridView1.DataBind();

        this.DropDownList3.Items.Clear();
        for (int i = 1; i <= this.GridView1.PageCount; i++)
        {
            this.DropDownList3.Items.Add(i.ToString());
        }
        if (this.GridView1.PageIndex != 0)
        {
            this.DropDownList3.SelectedIndex = this.GridView1.PageIndex;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.Label6.Text = string.Format("当前第{0}页/总共{1}页", this.GridView1.PageIndex + 1, this.GridView1.PageCount);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sql = "select CourseName from Course where CourseID=@courseID";
            SqlParameter[] pa = { new SqlParameter("@courseID", e.Row.Cells[1].Text) };
            DataSet ds = ba.GetDataSet(sql, pa);

            e.Row.Cells[1].Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string grade = DropDownList1.SelectedValue;
        string courseID = DropDownList2.SelectedValue;
        string cost = TextBox1.Text;
        int t;

        if (IsRepeat())
        {
            MessageForm.Show(this, "请勿添加重复的课程信息！");
            return;
        }

        if (!int.TryParse(cost, out t))
        {
            MessageForm.Show(this, "价格必须为整数！");
            return;
        }
        string sql = "insert into CourseJoin values(@tutorID,@courseID,null,@grade,@cost)";
        SqlParameter[] pa = { new SqlParameter("@tutorID", tutorID), new SqlParameter("@courseID", courseID), new SqlParameter("@grade", grade), new SqlParameter("@cost", cost) };
        ba.ExecNonQuery(sql, pa);
        bind();
        MessageForm.Show(this, "添加课程成功！");
    }

    private bool IsRepeat()
    {
        int thisIndex = this.GridView1.PageIndex;
        this.GridView1.PageIndex = 0;
        for (this.GridView1.PageIndex = 0; this.GridView1.PageIndex < this.GridView1.PageCount; this.GridView1.PageIndex++)
        {
            bind();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                if (this.GridView1.Rows[i].Cells[0].Text == DropDownList1.SelectedItem.Text)
                {
                    if (this.GridView1.Rows[i].Cells[1].Text == DropDownList2.SelectedItem.Text)
                    {
                        return true;
                    }
                }
            }
        }
        this.GridView1.PageIndex = thisIndex;
        bind();
        return false;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "delete from CourseJoin where JoinID=@joinID";
        SqlParameter[] pa = { new SqlParameter("@joinID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value)) };
        ba.ExecNonQuery(sql,pa);
        bind();
        GridView1.Columns[3].Visible = false;
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
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.DropDownList3.SelectedIndex;
        bind();
    }
}