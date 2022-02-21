using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class contacts : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        divmodalmsg.InnerHtml = "";
        divmodalmsg.Visible = false;
        DataTable dt = fn_SendContact(txtName.Text.Trim(), txtEmail.Text.Trim(), txtMessage.Text.Trim());


        if (dt.Rows[0]["message"].ToString().Trim() == "Insert Sucessfully")
        {
            divmodalmsg.InnerHtml = "<div class='alert alert-info'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong>شكرا على الرسالة ، سوف يتم التواصل معك قريبا </strong> </div>";
            divmodalmsg.Visible = true;
        }

        txtName.Text = "";
        txtEmail.Text = "";
        txtMessage.Text = "";
                //if (data[0].message == 'Insert Sucessfully') {
                //    $('#divmodalmsg').html('<div class="alert alert-info"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>شكرا على الرسالة ، سوف يتم التواصل معك قريبا </strong> </div>');
                //    $('#divmodalmsg').show();
                //    $("#divspin1").hide();
                //}
    }

    public DataTable fn_SendContact(string ls_name, string ls_email, string ls_msg)
    {
        Object obj;
        string ls_body;
        DataInsertReturn dtr = new DataInsertReturn();
        DataTable dt = new DataTable();
        

        clsGeneral.ExecuteNonQuery("insert into MYA_Maleabna_ContactUs (Name,Email,Msg) values(N'" + ls_name + "','" + ls_email + "',N'" + ls_msg + "')", GstrDbKey);

        ls_body = PopulateBodyContactUS(ls_name, ls_email, ls_msg);
        dtr = SendEmail("web@youth.gov.kw", ls_body, "New Contact.");
        if (dtr.DataInsert == true)
        {
            dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
        }
        else
        {
            dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
        }

        return dt;
    }

    private string PopulateBodyContactUS(string ls_name, string ls_email, string ls_msg)
    {
        string body = string.Empty;
        StreamReader reader = new StreamReader(Server.MapPath("~/mla3ebna/emailContact.html"));
        body = reader.ReadToEnd();

        body = body.Replace("{Name}", ls_name);
        body = body.Replace("{Email}", ls_email);
        body = body.Replace("{Msg}", ls_msg);

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
            //smtpClient.Port = 25;
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

    protected void lnkGetStadiumData1_Click(object sender, EventArgs e)
    {
       HiddenField hiddenDate1 = (HiddenField)Page.Master.FindControl("hiddenDate1");   //hiddenDate1.Value.ToString();

        string date = hiddenDate1.Value.ToString();

        Session["std"] = date;
        Response.Redirect("SearchStadium.aspx", false);

    }
}