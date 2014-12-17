using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;

public partial class Web_teacherRegister : System.Web.UI.Page
{
    private CourseDAO co = new CourseDAO();
    private ImageHelper img = new ImageHelper();
    

    private TutorRegisterControl tu = new TutorRegisterControl();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
            BindHead();
            BindCourse();
            BindFooter();
        }    
    }

    private void BindHead()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        string html = Util.ReadInfoFromXML(FilePath, "head");
        string usertype = Session["usertype"] == null ? "-1" : Session["usertype"].ToString();
        string ty = "";
        string name = "";
        if (usertype.Equals("-1"))
        {
            A_ModifyInfo.HRef = "login.aspx";
            ty = "游客  ";
            name = "请登录>>>";
        }
        else if (usertype.Equals("0"))
        {
            A_ModifyInfo.HRef = "StuInfoMenegement.aspx";
            ty = "学生  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("1"))
        {
            A_ModifyInfo.HRef = "infoManagement.aspx";
            ty = "老师  ";
            name = Session["Name"] == null ? "" : Session["Name"].ToString();
        }
        else if (usertype.Equals("2"))
        {
            A_ModifyInfo.HRef = "../Backstage/teacherManagement.aspx";
            ty = "管理员  ";
            name = "";
        }
        navbar.InnerHtml = string.Format(html, ty, name);
    }

    private void BindFooter()
    {
        string FilePath = Server.MapPath("..//") + "Web\\Content.xml";
        footer.InnerHtml = Util.ReadInfoFromXML(FilePath, "footer");
    }

    private void BindCourse()
    {
        courseBox.DataSource = co.GetAllCourses();
        courseBox.DataTextField = "CourseName";
        courseBox.DataValueField = "CourseID";
        courseBox.DataBind();
    }

    /// <summary>
    /// 点击报名所触发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void registerButton_ServerClick(object sender, EventArgs e)
    {
        int count = 0;
        string mail = info_mail.Value;
        string psd = info_password.Value;
        string qq = info_qq.Value;
        string name = info_name.Value;
        string sex = info_male.Checked ? info_male.Value : info_female.Value;
        if (sex.Equals("1"))
            sex = "男";
        else
            sex = "女";
        string uni = info_university.Value;
        string phone = info_phone.Value;
        string leve = info_leavetime.Value;
        string back = info_backtime.Value;
        string intro = info_intro.Value;

        //return;
        if (!mail.Trim().Equals("")&&tu.CheckUser(mail))
        {
            Response.Write(Util.ShowMessage("输入的用户名（邮箱已经存在）!"));
            return;
        }
        if (tu.CheckPhone(phone))
        {
            Response.Write(Util.ShowMessage("手机号码已存在!"));
            return;
        }


        string temp = intro.Replace("\r\n", "<br/>");

        StringBuilder cou = new StringBuilder();
        foreach(ListItem li in courseBox.Items)
        {
            if (li.Selected)
            {
                count++;
                cou.Append(li.Value + ",");
            }
        }
        if (count == 0)
        {
            Response.Write(Util.ShowMessage("至少应选择一门授课科目，请返回重新选择！"));
            return;
        }
        string course = cou.ToString();
        course = course.Remove(course.LastIndexOf(','));

        count = 0;
        string se = "";
        if (primaryBox.Checked)
        { 
            se+="小学,";
            count++;
        }
        if (middleBox.Checked)
        { 
            se += "中学,";
            count++;
        }
        if (seniorBox.Checked)
        { 
            se += "高中,";
            count++;
        }
        if (count == 0)
        {
            Response.Write(Util.ShowMessage("请至少选择一个授课年级！"));
            return;
        }
        se = se.Remove(se.LastIndexOf(','));

        


        try
        {

            psd = FormsAuthentication.HashPasswordForStoringInConfigFile(psd, "MD5").ToLower().Substring(8, 16);
            string pic =UPPicture(570,385);
            if (pic != null)
            { 
                string id=tu.InsertTutorInfo(mail, psd, qq, sex, name, uni, phone, back, leve, course, se, intro, pic);
                string uid = tu.GetUid("1",id);
                Session["ID"] = id;
                Session["usertype"] = "1";
                Session["Uid"] = uid;
                Session["Name"] = name;
                Response.Write(Util.ShowMessage("报名成功！","index.aspx"));
            }
        }
        catch
        {
            Response.Write(Util.ShowMessage("报名失败，请检查信息是否有误或者与管理员联系!"));
        }
       
    }

    /// <summary>
    /// 上传图片
    /// </summary>
    private string  UPPicture(int weight ,int height)
    {

        string re = "";
        string filename = info_photo.FileName;
        string type = filename.Substring(filename.LastIndexOf(".") + 1);
        //string time=DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //string pic = info_photo.Value + time;
        if (!type.Equals("jpg")&&!type.Equals("png"))
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
                if (HPF.ContentLength > 0&&HPF.ContentLength<4000000)
                {
                    
                    string strFileName =re= HPF.FileName.Substring(0, filename.LastIndexOf(".")) +
                                            DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "." + type;
                    string fullname = FilePath + "\\" + strFileName;
                    try
                    {
                        HPF.SaveAs(fullname);
                        re=img.Image(fullname, weight, height);

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


}