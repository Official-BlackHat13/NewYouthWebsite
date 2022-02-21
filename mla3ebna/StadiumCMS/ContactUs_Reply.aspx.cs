using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs_Reply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();

            if (!string.IsNullOrEmpty(Request.QueryString["UserEmail"]))
            {
                fillData();
            }
        }
    }

    private void fillData()
    {
        TxtToEmail.Text = Request.QueryString["UserEmail"].ToString();
        TxtToEmail.Enabled = false;
    }
  
   
    protected void btnSend_Click(object sender, EventArgs e)
    {

        int i = GeneralEmail(TxtToEmail.Text, TxtReplyMessage.Text);

        if (i == 0)
        {
            string cmd;
            cmd = "update MYA_Maleabna_ContactUs set Reply ='" + TxtReplyMessage.Text + "',ReplyBy = " + Session["MaleabnaCMSUserID"].ToString() + ", Status = '0' where ContactId = " + Request.QueryString["ContactId"];
            dbFunctions.ExecuteQuery(cmd);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Message Sent Successfully');", true);

            TxtReplyMessage.Text = "";
            TxtToEmail.Text = "";
        }

        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Try Again');", true);
        }


        
    }

    public int GeneralEmail(string emailid, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message1 = new MailMessage();
           // message1.From = new MailAddress("web@youth.gov.kw", "Registration Sucess");
            message1.From = new MailAddress("web@youth.gov.kw");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-reply";

            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Body = EmailBodyGeneral(unique);
            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(message1);
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }
        }
        return i;
    }


    public string EmailBodyGeneral(string unique)
    {
        string body = string.Empty;
        string text = "";

        text = unique ;


        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }
}