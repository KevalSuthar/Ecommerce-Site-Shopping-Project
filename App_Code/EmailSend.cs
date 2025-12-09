using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for EmailSend
/// </summary>
public class EmailSend
{
	public EmailSend()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public static bool SendMail(string to, string subject,string otp)
    //{
    //    try
    //    {
    //        string gMailAccount = "kksuthar3222@gmail.com";
    //        string password = "ikvwdwbrwuilsjmq";
    //        NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
    //        MailMessage msg = new MailMessage();
    //        msg.From = new MailAddress(gMailAccount, "Ecommerce Project by Otp Send");
    //        msg.To.Add(new MailAddress(to));
    //        msg.Subject = subject;
    //        msg.Body = otp;
    //        msg.IsBodyHtml = true;
    //        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
    //        client.EnableSsl = true;
    //        client.UseDefaultCredentials = false;
    //        client.Credentials = new NetworkCredential(gMailAccount, password);
    //        client.Send(msg);

    //        return true;
    //    }
    //    catch (Exception Ex)
    //    {
    //        return false;
    //    }

    //}
    public static bool SendMail(string name, string toEmail, int otp, string messageBody)
{
    try
    {
        string gMailAccount = "kksuthar3222@gmail.com";
        string password = "ikvwdwbrwuilsjmq";
        NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(gMailAccount, "Ecommerce Project");
        msg.To.Add(new MailAddress(toEmail));
        msg.Subject = "otp verification in e-commerce project by conformation";
        msg.Body = messageBody;
        msg.IsBodyHtml = true;

        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = loginInfo;
        client.Send(msg);

        return true;
    }
    catch (Exception)
    {
        return false;
    }
}

    public static bool SendMailWithAttachement(string gMailAccount, string password, string to, string message, string path)
    {
        try
        {
            NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(gMailAccount);
            msg.To.Add(new MailAddress(to));
            msg.Body = message;
            msg.IsBodyHtml = true;
            msg.Attachments.Add(new Attachment(path));
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(msg);

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
}