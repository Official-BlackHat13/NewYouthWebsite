using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class ForegetPassword : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        divmodalmsg.InnerHtml = "";
        divmodalmsg.Visible=false;

        Validate("forget");
        if (Page.IsValid)
        {
            DataTable dt = fn_Reset_Password(txtEmail.Text.Trim());

            divmodalmsg.InnerHtml = dt.Rows[0]["message"].ToString();
            divmodalmsg.Visible=true;
              //$('#divmodalmsg').html(data[0].message);
              //  $('#divmodalmsg').show();
              //  $("#divmodalspin").hide();
        }
    }

    public DataTable fn_Reset_Password(string ls_email)
    {

        DataTable dt = new DataTable();
        DataInsertReturn dtr = new DataInsertReturn();
        
        fnReturnCivilId dtrCivil = new fnReturnCivilId();
        string ls_body;
        string ls_username;
        string ls_euid;
        object obj;
        try
        {

            if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey).Equals("0"))
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("لم يتم العثور على بريدك الإلكتروني "), 0);
                return dt;
            }

            ls_username = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
            ls_euid = clsGeneral.GetQueryValue("select useruid from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);

            ls_body = PopulateBodyResetPWD(ls_username, "https://www.youth.gov.kw/mla3ebna/ResetPassword.aspx?uid=" + ls_euid);
            // ls_body = PopulateBodyResetPWD(ls_username, "http://localhost:12815/mla3ebna/ResetPassword.aspx?uid=" + ls_euid);


           // ls_body = PopulateBodyResetPWD(ls_username, "https://mubaratna.com/ResetPassword/" + ls_euid);
            //ls_body = PopulateBodyResetPWD(ls_username, "http://localhost:94/ResetPassword/" + ls_euid);
            dtr = SendEmail(ls_email, ls_body, "Mubaratna Reset Password.");

            if (dtr.DataInsert == true)
            {
                dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم ارسال رابط تغيير كلمة الرور لبريدك الإلكتروني بنجاح "), 0);
            }
            else
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag(dtr.ErrorMsg.Trim()), 0);
            }

            return dt;
        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }

        return dt;
    }


    private string PopulateBodyResetPWD(string ls_username, string ls_link)
    {
        string body = string.Empty;
        StreamReader reader = new StreamReader(Server.MapPath("~/mla3ebna/emailForgetPWD.html"));
        body = reader.ReadToEnd();

        body = body.Replace("{User}", ls_username);
        body = body.Replace("{link}", ls_link);

        return body;
    }

    public DataInsertReturn SendEmail(string emailid, string ls_body, string ls_Subject)
        {
            string rtString;
            rtString = "";
            string email = emailid;
            DataInsertReturn dtr = new DataInsertReturn();
            dtr.DataInsert = true;
            if (!email.Equals(""))
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new MailAddress("web@youth.gov.kw", "Mubaratna");
                message.To.Add(new MailAddress(email));
                message.Subject = ls_Subject;
                message.CC.Add(new MailAddress("web@youth.gov.kw"));
                message.IsBodyHtml = true;

                message.Body = ls_body;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.office365.com";
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                try
                {
                    smtpClient.Send(message);
                    //smtpClient = null/* TODO Change to default(_) if this is not a reference type */;

                    dtr.ErrorMsg = "Insert Sucessfully";

                    return dtr;
                }

                // rtString = "Email Send Successfully."
                catch (Exception ex)
                {
                    dtr.DataInsert = false;
                    dtr.ErrorMsg = ex.Message;
                    return dtr;
                }

            }
            return dtr;
        }
}