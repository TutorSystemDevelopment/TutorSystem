using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class Web_readArticle : System.Web.UI.Page
{
    private NewsDao nd = new NewsDao();
    private PagedDataSource pgSource = new PagedDataSource();
    private string TutorID = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1") || Session["ID"] == null) Response.Redirect("PermissionsError.aspx");
        TutorID = Session["ID"].ToString();
        if (!IsPostBack)
        {
            BindDateList();
            Paging();
        }
    }

    private void BindDateList()
    {
        DataSet ds = nd.GetNewsByTutorID(TutorID);

        pgSource.DataSource = ds.Tables[0].DefaultView;
        pgSource.AllowPaging = true;
        pgSource.PageSize = 5;

        //pgSource.CurrentPageIndex = i;
        DataList1.DataSource = pgSource;
        DataList1.DataKeyField = "NewsID";
        DataList1.DataBind();
    }

    private void Paging()
    {
        int CurPage;
        string pagecount = pgSource.PageCount.ToString();

        if (Request.QueryString["Page"] != null)
            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurPage = 1;

        pgSource.CurrentPageIndex = CurPage - 1;
        Label3.Text = "第" + CurPage.ToString() + "页";

        if (!pgSource.IsFirstPage)
            HyperLink2.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);

        if (!pgSource.IsLastPage)
            HyperLink3.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);

        if (!pgSource.IsFirstPage)
        {
            HyperLink4.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
        }
        if (!pgSource.IsLastPage)
        {
            HyperLink5.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + pagecount;
        }

        DataList1.DataSource = pgSource;
        DataList1.DataBind();
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string id = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        string url = "articlePub.aspx?NewsID=" + id;
        switch (e.CommandName)
        {
            case "edit":
                Response.Redirect(url);
                break;
            case "delete":
                nd.deleteNewsByNewsID(id);
                BindDateList();
                break;
        }
    }
}