using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TutorRegisterControl 的摘要说明
/// </summary>
public class TutorRegisterControl
{
	public TutorRegisterControl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private TutorDao tu = new TutorDao();
    private UserDao us = new UserDao();


    public string InsertTutorInfo(string mail,string psd,string qq,string sex,string name,string uni,string phone,string backtime
        ,string leavetime,string course,string senir,string intro,string photo)
    {
         return tu.InsertTutorInfo(mail, psd, qq, sex, name, uni, phone, backtime, leavetime, course, senir, intro, photo);
    }

    public Boolean CheckUser(string mail)
    {
        return us.CheckUser(mail);
    }

    public Boolean CheckPhone(string phone)
    {
        return tu.CheckPhone(phone);

    }

    public string GetUid(string type, string id)
    {
        return us.GetUid(type, id);
    }



}