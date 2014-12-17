using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_BasicInfo : System.Web.UI.Page
{
    private TutorDao td = new TutorDao();
    private ImageHelper img = new ImageHelper();

    private string tutorid = "64";
    private string QQ;
    private string Phone;
    private string University;
    private string Intro;
    private string Photo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertype"] == null || !Session["usertype"].ToString().Equals("1") || Session["ID"] == null) Response.Redirect("PermissionsError.aspx");
        tutorid = Session["ID"].ToString();
        if (!IsPostBack)
        {
            BindInfo();
        }
    }


    private void BindInfo()
    {
        DataSet ds = td.GetTutorByID(tutorid);

        info_qq.Value = ds.Tables[0].Rows[0][3].ToString();
        info_phone.Value = ds.Tables[0].Rows[0][5].ToString();
        info_university.Value = ds.Tables[0].Rows[0][4].ToString();
        info_intro.Value = ds.Tables[0].Rows[0]["Intro"].ToString();
        Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
        photoname.InnerText = Photo;
        preview.Src = "../images/" + Photo;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string pic = null;
            Photo = photoname.InnerText;
            //存储文件到磁盘
            if (Photo.Equals(info_photo.FileName.ToString()) || info_photo.FileName == "")
            {
                pic = Photo;
            }
            else
            {
                pic = UPPicture(570, 385);
            }
            ////文件大小
            //int size = info_photo.PostedFile.ContentLength;
            ////文件类型
            //string type = info_photo.PostedFile.ContentType;

            QQ = info_qq.Value.ToString();
            Phone = info_phone.Value.ToString();
            University = info_university.Value.ToString();
            Intro = info_intro.Value.ToString();
            if (pic != null)
            {
                td.UpdateTutor(tutorid, QQ, Phone, University, Intro, pic);
            }
            else
            {
                td.UpdateTutor(tutorid, QQ, Phone, University, Intro, Photo);
                Util.ShowMessage("您未上传照片或上传的照片格式不正确，照片修改失败！");
            }
        }
        catch
        {
            Response.Write("<script>alert('信息修改出错，请重试！')</script>");
            return;
        }
        Response.Write("<script>alert('修改信息成功！')</script>");
        BindInfo();
    }

    private string UPPicture(int weight, int height)
    {

        string re = "";
        string filename = info_photo.FileName;
        string type = filename.Substring(filename.LastIndexOf(".") + 1);
        //string time=DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //string pic = info_photo.Value + time;
        if (!type.Equals("jpg"))
        {
            Response.Write(Util.ShowMessage("导入文件只支持jpg文件且小于4M，请导入正确的jpg文件！"));
            return null;
        }
        else
        {
            string FilePath = Server.MapPath("..//") + "images";
            HttpFileCollection HFC = Request.Files;

            for (int i = 0; i < HFC.Count; i++)
            {
                HttpPostedFile HPF = HFC[i];

                if (HPF.ContentLength > 0)
                {
                    string strFileName = re = HPF.FileName.Substring(0, filename.LastIndexOf(".")) +
                                            DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "." + type;
                    string fullname = FilePath + "\\" + strFileName;
                    try
                    {
                        HPF.SaveAs(fullname);
                        re = img.Image(fullname, weight, height);

                        DeleteFile(Photo);
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
}