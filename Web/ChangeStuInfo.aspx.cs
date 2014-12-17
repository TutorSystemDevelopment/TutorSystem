using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Web_ChangeStuInfo : System.Web.UI.Page
{
    int stuID = 1;
    string name;
    string address;
    string qq;
    string guardianName;
    string guardianPhone;

    Regex rx = new Regex("^1[0-9]{10}$");
    BasicDao ba = new BasicDao();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("0") || Session["ID"] == null)
            Response.Redirect("PermissionsError.aspx");
        stuID = int.Parse(Session["ID"].ToString());
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        string sql1 = "select * from Student where StuID=@stuID";
        SqlParameter[] pa1 = { new SqlParameter("@StuID", stuID) };
        DataSet ds = ba.GetDataSet(sql1, pa1);
        TextBox1.Text = ds.Tables[0].Rows[0][1].ToString();
        TextBox2.Text = ds.Tables[0].Rows[0][3].ToString();
        TextBox3.Text = ds.Tables[0].Rows[0][4].ToString();
        TextBox4.Text = ds.Tables[0].Rows[0][5].ToString();
        TextBox5.Text = ds.Tables[0].Rows[0][6].ToString();
    }


    private bool IsLegal()
    {
        if (TextBox1.Text != null && TextBox2.Text != null && TextBox3.Text != null && TextBox4.Text != null && TextBox5.Text != null)
        {
            int t;
            if (!int.TryParse(TextBox3 .Text, out t))
            {
                MessageForm.Show(this, "QQ号必须为数字！");
                return false;
            }
            else if (!rx.IsMatch(TextBox5.Text.Trim())) //号码格式不匹配
            {
                MessageForm.Show(this, "请输入正确的手机号！");
                return false;
            }
            else if (TextBox2.Text.Trim().Length > 50)
            {
                MessageForm.Show(this, "输入的地址过长！");
                return false;
            }
            return true;
        }
        else
        {
            MessageForm.Show(this, "信息不能为空！");
            return false;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsLegal())
        {
            name = TextBox1.Text.Trim();
            address = TextBox2.Text.Trim();
            qq = TextBox3.Text.Trim();
            guardianName = TextBox4.Text.Trim();
            guardianPhone = TextBox5.Text.Trim();
            string sql = "update Student set Name=@name,Address=@address,QQ=@qq,GuardianName=@guardianName,GuardianPhone=@guardianPhone where StuID = @stuID";
            SqlParameter[] pa = { new SqlParameter("@name", name), new SqlParameter("@address", address), new SqlParameter("@qq", qq), new SqlParameter("@guardianName", guardianName), new SqlParameter("@guardianPhone", guardianPhone), new SqlParameter("@stuID", stuID) };
            ba.ExecNonQuery(sql, pa);
            MessageForm.Show(this, "修改成功！");
        }
    }
}