using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backstage_PubArticle : System.Web.UI.Page
{
    private NewsDao nd = new NewsDao();
    private ImageHelper img = new ImageHelper();
    private string ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] == null || Session["Uid"] == null || Session["usertype"] == null || !Session["usertype"].ToString().Equals("2")) Response.Redirect("../Web/PermissionsError.aspx");
        ID = Session["ID"].ToString();
        if (!IsPostBack)
        {
            BindFooter();
            BindBackstageHead();
            bindcheckboxlist();
        }
    }

    private string TitlePic = "";

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
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Title = TextBox1.Text;
        string Body = TextBox3.Text;
        string Author = "推广部";
        string Date = DateTime.Now.ToString("yyyy-MM-dd");
        string ifadmin = "1";
        string ifpass = "1";

        if (TextBox1.Text != "" && TextBox3.Text != "")
        {
          
                if (FileUpload1.HasFile) TitlePic = UPimage(570, 385);
                else TitlePic = "default.jpg"; // 默认图片
                nd.OpenSqlTransaction();
                try
                {
                    nd.insertNews(Title, Body, Author, Date, ID, TitlePic, ifadmin, ifpass);
                    DataSet ds = nd.GetLastNews();
                    string NewsID = ds.Tables[0].Rows[0]["NewsID"].ToString();
                    getcheck(CheckBoxList1, NewsID);
                    if (diytag.Value != "")
                    {
                        nd.insertTags(diytag.Value);
                        DataSet sd = nd.GetLastTags();
                        nd.insertNewsTag(NewsID, sd.Tables[0].Rows[0]["TagID"].ToString());
                    }
                    nd.Commit();
                }
                catch
                {
                    nd.RollBack();
                    Response.Write(Util.ShowMessage("文章提交失败！"));
                }
                TextBox1.Text = "";
                TextBox3.Text = "";
                Image1.ImageUrl = "../images/" + TitlePic;
                Response.Write(Util.ShowMessage("你的文章已经提交，请耐心等待管理员审核！"));
            
        }
        else Response.Write("<script language=\"JavaScript\">alert(\"信息不完全!\")</script>");
    }

    private string UPimage(int weight, int height)
    {
        string re = "";
        //TitlePic = FileUpload1.FileName;
        //string type = TitlePic.Substring(TitlePic.LastIndexOf(".") + 1);
        //获取网站根目录路径
        string path = HttpContext.Current.Request.MapPath("~/");
        //存储文件到磁盘
        //FileUpload1.SaveAs(path + "images/" + FileUpload1.FileName);
        //文件大小
        int size = FileUpload1.PostedFile.ContentLength;
        //文件类型
        string type = FileUpload1.PostedFile.ContentType;
        if ((!type.Equals("image/jpeg")) && (!type.Equals("images/png")))
        {
            Response.Write("<script language=\"JavaScript\">alert(\"导入文件只支持jpg/png文件且小于4M，请导入正确的jpg/png文件！\")</script>");
        }
        else
        {
            HttpFileCollection HFC = Request.Files;

            for (int i = 0; i < HFC.Count; i++)
            {

                HttpPostedFile HPF = HFC[i];

                if (HPF.ContentLength >= 4000000)
                {
                    Response.Write(Util.ShowMessage("导入图片只支持4M一下的图片！"));
                    return null;
                }
                if (HPF.ContentLength > 0 && HPF.ContentLength < 4000000)
                {
                    string fullname = path + "images/" + FileUpload1.FileName;
                    try
                    {
                        HPF.SaveAs(fullname);
                        re = img.Image(fullname, weight, height);
                        DeleteFile(fullname);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

        }
        return re;
    }

    private void DeleteFile(string filename)
    {
        if (System.IO.File.Exists(filename))
        {
            System.IO.File.Delete(filename);
        }

    }

    private void bindcheckboxlist()
    {
        DataSet ds = nd.GetAllTags();
        CheckBoxList1.DataSource = ds.Tables[0];
        CheckBoxList1.DataTextField = "TagName";
        CheckBoxList1.DataValueField = "TagID";
        CheckBoxList1.DataBind();
    }

    private void getcheck(CheckBoxList checkList, string NewsID)
    {
        for (int i = 0; i < checkList.Items.Count; i++)
        {
            if (checkList.Items[i].Selected)
            {
                nd.insertNewsTag(NewsID, (i + 1).ToString());
            }
        }
    }

}