using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MessageForm 的摘要说明
/// </summary>
public class MessageForm
{
	public MessageForm()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void Show(System.Web.UI.Page page, string msg)
    {//消息提示

        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");

    }
}