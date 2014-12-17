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

    private string TutorID = "1";
    private string Time;
    private string Title;
    private string Year;
    private string Month;
    private string Items;
    private Mail mail = new Mail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bindgridview();
        }
    }

    //private void bindgridview()
    //{
    //    DataSet ds = td.GetTutorTimeLineByOrder(TutorID);
        
    //    GridView1.DataSource = ds.Tables[0];
    //    GridView1.DataKeyNames = new string[] { "LineID" }; 
    //    GridView1.DataBind(); 
    //}
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
    //    td.DeleteTutorTimeLine(id);
    //    bindgridview();
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (TitleText.Text != null && TextArea1.InnerText != null && Time != null)
    //    {
    //        Time = date.Value;
    //        Year = Time.Substring(0, 4);
    //        Month = Time.Substring(5, 2);
    //        Title = TitleText.Text;
    //        Items = TextArea1.InnerText;
    //        td.InsertTutorTimeLine(Year, Month, Title, Items, TutorID);
    //        bindgridview();
    //    }
    //    else Response.Write("<script language=\"JavaScript\">alert(\"信息不完全!\")</script>");
    //}
    protected void Button1_Click1(object sender, EventArgs e)
    {
        mail.SendMail("275083584@qq.com","我长的帅不帅","你真逗额啥卡束带结发爱上加工费阿斯顿规范撒谎就撒旦蜂皇浆撒旦法干啥都贵发给 哈斯的规范 阿斯顿合肥高 挥洒的规范哈吉斯 ");
    }
}