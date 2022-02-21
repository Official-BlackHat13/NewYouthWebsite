using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserVerification : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkresend_Click(object sender, EventArgs e)
    {
        if (Session["rEmail"] != null)
        {
            DataTable dt = fn_ReSendOTP(Session["rEmail"].ToString());

            txtopt1.Focus();
            divmodalmsg.InnerHtml = dt.Rows[0]["message"].ToString();
            divmodalmsg.Visible = true;            
        }
    }
    public DataTable fn_ReSendOTP(string ls_email)
    {
        DataTable dt = new DataTable();
        DataInsertReturn dtr = new DataInsertReturn();      
        
       
        string ls_body;
        string ls_name;
        string ls_phone;
        int ls_smscnt;

        ls_phone = clsGeneral.GetQueryValue("select phone from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
        ls_name = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
        ls_smscnt = int.Parse(clsGeneral.GetQueryValue("select smscount from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey));
        

        string ls_otp = clsGeneral.GenerateOTP();
        if (ls_smscnt < 3)
        {
            sms(ls_phone, ls_otp);
            clsGeneral.ExecuteNonQuery("update MYA_Maleabna_Members set smscount=smscount+1 where  email='" + ls_email + "'", GstrDbKey);
        }

        ls_body = PopulateBodyRegister(ls_name, ls_otp);
        dtr = SendEmail(ls_email, ls_body, "مرحبا بك في مباراتنا ");
        if (dtr.DataInsert == true)
        {
            clsGeneral.ExecuteNonQuery("update MYA_Maleabna_Members set otp='" + ls_otp + "' where  email='" + ls_email + "'", GstrDbKey);
            dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم ارسال الرمز بنجاح "), 0);
        }
        else
        {
            dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
        }
        return dt;
    }
    public void sms(string ph, string aaNme)
    {
        string mobile = ph;

        int i = mobile.Length;
        if (!mobile.Equals("") && mobile.Length == 8)
        {
            string senderusername = "Youthkuwait";
            string senderpassword = "you.1234";
            string sender_id = "57";
            mobile = "965" + mobile;

            string message = "رمزك لمرة واحدة فقط هو " + aaNme;
            string sURL;


            StreamReader objReader;

            sURL = "https://kuwait.uigtc.com/capi/sms/send_sms?api_key=194.DC5E858062D052AC61C74CC176E91CC6BFD2B055CBF471&sender_id=" + sender_id + "&send_type=1&sms_content=" + message + "&numbers=" + mobile + "&unique=1";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }

    private string PopulateBodyRegister(string ls_username, string ls_otp)
    {
        string body = string.Empty;
        StreamReader reader = new StreamReader(Server.MapPath("~/mla3ebna/emailRegister.html"));
        body = reader.ReadToEnd();

        body = body.Replace("{User}", ls_username);
        body = body.Replace("{otp}", ls_otp);

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





    protected void lnkVerify_Click(object sender, EventArgs e)
    {
      //  Session["rEmail"] = "sijila.p@gmail.com";
       
        if (Session["rEmail"] != null)
        {
            string email = Session["rEmail"].ToString();
            divmodalmsg.InnerHtml = "";
            string ls_otp = txtopt1.Text.ToString() + txtopt2.Text.ToString() + txtopt3.Text.ToString() + txtopt4.Text.ToString() +  txtopt5.Text.ToString() + txtopt6.Text.ToString();
            DataTable dt = Get_VerifyInfo(Session["rEmail"].ToString(), ls_otp);
            if (dt.Rows[0]["message"].ToString().Trim() == "NO ITEMS FOUND")
            {
                txtopt1.Focus();
                divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='fa fa-times'></i></button><strong>الرمز غير صحيح ، حاول مرة اخرى</strong> </div>";
                divmodalmsg.Visible = true;
            }
            else if (dt.Rows[0]["message"].ToString().Trim() == "Verified")
            {
                Response.Redirect("ContinuePage.aspx", false);                
            }
        }
           
        
    }
    public DataTable Get_VerifyInfo(string email, string otp)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
       
        DataInsertReturn dtr = new DataInsertReturn();

        try
        {
            DS = clsGeneral.GetDS("select * from MYA_Maleabna_Members where email='" + email + "' and otp='" + otp + "'", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set smsstatus=1,emailStatus=1 where email='" + email + "'", GstrDbKey);
                dt = clsGeneral.msgResponse("", "True", "Verified", 0);
            }

            
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
}