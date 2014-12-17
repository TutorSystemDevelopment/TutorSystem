using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail; 

/// <summary>
/// SendMail 的摘要说明
/// </summary>
public class Mail
{

    private string smtpserver="smtp.qq.com";
    private string sendmail="756407280@qq.com";
    private string mailpsd = "DKZYK07397237699";
	public Mail()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        //string reciever,string title,string content
	}


    public void SetMailInfo(string smtpserver, string sendusername, string sendpsd)
    {
        this.smtpserver = smtpserver;
        sendmail = sendusername;
        mailpsd = sendpsd;
    }


    public void SendMail(string recmail,string title,string content)
    {
        System.Net.Mail.SmtpClient client = new SmtpClient();
        client.Host = smtpserver;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(sendmail, mailpsd);
        //星号改成自己邮箱的密码
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        System.Net.Mail.MailMessage message = new MailMessage(sendmail, recmail);
        message.Subject = title;
        message.Body = content;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.IsBodyHtml = true;
        //添加附件
        //Attachment data = new Attachment(@"附件地址如：e:\a.jpg", System.Net.Mime.MediaTypeNames.Application.Octet);
        //message.Attachments.Add(data);
        try
        {
            client.Send(message);
            //MessageBox.Show("Email successfully send.");
        }
        catch (Exception ex)
        {
            throw ex;
            //MessageBox.Show("Send Email Failed." + ex.ToString());
        }

    }

}