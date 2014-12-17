using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Web_teacherRecommend : System.Web.UI.Page
{
    private ImageHelper img = new ImageHelper();
    private Boolean has;
    private string pagenum = "";
    private string backpage = "teacherManagement.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null || Session["usertype"] == null || !Session["usertype"].ToString().Equals("2")) Response.Redirect("../Web/PermissionsError.aspx");
        pagenum = Request["pagenum"] == null ? "1" : Request["pagenum"].ToString();
        //backpage = Request["backpage"] == null ? "index.aspx" : Request["backpage"].ToString();
        tutorid = Request["tutorid"] == null ? "" : Request["tutorid"].ToString();
        if(!tutorid.Equals(""))
            has = tu.HasTopTutor(tutorid);
        if (!IsPostBack)
        {
            if (has)
            {
                BindContent();
            }
        }
    }

    private TutorDao tu = new TutorDao();

    private string tutorid = "57";
    private string lastpic = "-1";

    private void BindContent()
    {
        DataSet ds=tu.GetTopTutorByID(tutorid);
        txtContent.Text=ds.Tables[0].Rows[0]["Advice"].ToString();
        iftop.Checked=ds.Tables[0].Rows[0]["iftop"].ToString().Equals("1")?true:false;
        lb_filename.Text=lastpic = ds.Tables[0].Rows[0]["IndexPic"].ToString();
        preview.Src = "../images/" + lastpic;
    }
    protected void bt_sure_Click(object sender, EventArgs e)
    {
        string content = txtContent.Text;
        int top = iftop.Checked ? 1 : 0;
        if (content.Trim().Equals(""))
        {
            Response.Write(Util.ShowMessage("内容不能为空！"));
            return;
        }
        try
        {
            string pic = UPPicture(220, 220);
            if (pic == null) return;
            if (!has)
            {
                tu.InsertintoTopTutor(pic, content, tutorid, top);
            }
            else
            {
                tu.UpTopTutor(pic, content, tutorid, top);
            }
            Response.Write(Util.ShowMessage("插入成功！"));
        }
        catch (Exception a)
        {
            Response.Write(Util.ShowMessage("插入失败!"));
            throw a;
        }

    }

    /// <summary>
    /// 上传图片
    /// </summary>
    private string UPPicture(int weight, int height)
    {
        string re = lb_filename.Text;
        string filename = info_photo.FileName;
        if (filename.Equals(lb_filename.Text))
            return lb_filename.Text;
        string type = filename.Substring(filename.LastIndexOf(".") + 1);
        //string time=DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //string pic = info_photo.Value + time;
        if (!has)
        {
            if (filename.Trim().Equals(""))
            {
                Response.Write(Util.ShowMessage("路径不能为空！"));
                return null;
            }
        }
        if (!type.Equals("jpg") && !type.Equals("png") && !filename.Equals(""))
        {
            Response.Write(Util.ShowMessage("导入文件只支持jpg和png文件，请导入正确的图片文件！"));
            return null;
        }
        else 
        {
            string FilePath = Server.MapPath("..//") + "images";
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

                    string strFileName = re = HPF.FileName.Substring(0, filename.LastIndexOf(".")) +
                                            DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "." + type;
                    string fullname = FilePath + "\\" + strFileName;
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


    protected void bt_back_Click(object sender, EventArgs e)
    {
        string url = backpage + "?pagenum=" + pagenum;
        Response.Redirect(url);
    }
}