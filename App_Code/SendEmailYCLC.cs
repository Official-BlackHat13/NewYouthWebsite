using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

/// <summary>
/// Summary description for SendEmail
/// </summary>
public class SendEmailYCLC
{
    public string GeneralYCLEmail(string emailid, DataTable dt)
    {
        string rtString;
        rtString = "";
        String email = emailid;        
        if (!email.Equals(""))
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("web@youth.gov.kw", "Registration Sucess");
            message.To.Add(new MailAddress(email));
            message.Subject = "User Info";
            message.CC.Add(new MailAddress("web@youth.gov.kw"));
            message.IsBodyHtml = true;


            string FilePath = "C:\\inetpub\\wwwroot\\Youth.gov.kw\\YCLC\\TPFEmailTemplate.html";
           // string FilePath = "C:\\inetpub\\wwwroot\\youthMinistry\\YCLC\\TPFEmailTemplate.html";
            StreamReader str = new StreamReader(FilePath);

            

            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("{NameoftheParticipant}", dt.Rows[0]["اسم المشارك"].ToString());
            MailText = MailText.Replace("{gender}", dt.Rows[0]["الجنس"].ToString());
            MailText = MailText.Replace("{UserPhone}", dt.Rows[0]["الهاتف"].ToString());
            MailText = MailText.Replace("{Civil}", dt.Rows[0]["الرقم المدني"].ToString());          
            MailText = MailText.Replace("{catagory}", dt.Rows[0]["اختر مسابقة واحدة فقط"].ToString());

            MailText = MailText.Replace("{UserEmail}", dt.Rows[0]["البريد الالكتروني"].ToString());
            MailText = MailText.Replace("{DOB}", dt.Rows[0]["ChildDOB"].ToString());

            MailText = MailText.Replace("{Governarate}", dt.Rows[0]["المحافظة"].ToString());
            MailText = MailText.Replace("{Area}", dt.Rows[0]["منطقة السكن"].ToString());
            MailText = MailText.Replace("{level}", dt.Rows[0]["تم تسجيلك في المستوى"].ToString());

            MailText = MailText.Replace("{GuardianName}", dt.Rows[0]["اسم ولي الأمر"].ToString());
            MailText = MailText.Replace("{GuardianEmail}", dt.Rows[0]["البريد الالكتروني لولي الأمر"].ToString());
            MailText = MailText.Replace("{GuardianPhone}", dt.Rows[0]["هاتف ولي الأمر"].ToString());
            MailText = MailText.Replace("{DateofApply}", Convert.ToDateTime(dt.Rows[0]["DateOfApply"].ToString()).Date.ToString("dd/MM/yyyy"));


            StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\Youth.gov.kw\\YCL\\TPFEmailTemplate2.html");
           // StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\youthMinistry\\YCLC\\TPFEmailTemplate2.html");
            writer.Write(MailText);
            writer.Dispose();



            message.Body = "شكرا لك على التسجيل ،يمكنك الضغط على الصورة أدناه لتحميل تفاصيل الحجز  ";         

            Attachment attachment;
            attachment = new Attachment("C:\\inetpub\\wwwroot\\Youth.gov.kw\\YCLC\\TPFEmailTemplate2.html");
            //attachment = new Attachment("C:\\inetpub\\wwwroot\\youthMinistry\\YCLC\\TPFEmailTemplate2.html");
            attachment.ContentDisposition.FileName = dt.Rows[0]["اسم المشارك"].ToString() + ".html";


            Attachment civilcopy;
            civilcopy = new Attachment("C:\\inetpub\\wwwroot\\Youth.gov.kw\\YCLC\\Civil\\" + dt.Rows[0]["صورة البطاقة المدنية"].ToString());
           // civilcopy = new Attachment("C:\\inetpub\\wwwroot\\youthMinistry\\YCLC\\Civil\\" + dt.Rows[0]["صورة البطاقة المدنية"].ToString());
            civilcopy.ContentDisposition.FileName = dt.Rows[0]["صورة البطاقة المدنية"].ToString();

            message.Attachments.Add(attachment);
            message.Attachments.Add(civilcopy);

            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");


            try
            {
                smtpClient.Send(message);
                smtpClient = null;
                message.Dispose();
                rtString = "Email Send Successfully.";
            }
            catch (Exception ex)
            {
                rtString= ex.Message;
                //Response.Write(ex.Message);
            }
        }
        return rtString;
        
    }
}