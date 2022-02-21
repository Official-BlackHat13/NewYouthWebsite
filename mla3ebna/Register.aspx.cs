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

public partial class Register : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGovernorate();
            LoadTerms();
        }
    }

    public void LoadTerms()
    {
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();

        try
        {
            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=3", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
            }

            DataColumnCollection columns = dt.Columns;
            if (columns.Contains("PageContent"))
            {
                DivBooking.InnerText = dt.Rows[0]["PageContent"].ToString();
            }
            else
            {

            }


            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=2", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
            }

            DataColumnCollection columns1 = dt.Columns;
            if (columns1.Contains("PageContent"))
            {
                DivPolicy.InnerText = dt.Rows[0]["PageContent"].ToString().Trim();
            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);

            DivBooking.InnerText = dt.Rows[0]["message"].ToString();
        }
        finally
        {

        }



    }

    protected void FillGovernorate()
    {    




        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForReg " );

        

        if (dt.Rows.Count > 0)
        {
            DDLGov.DataSource = dt;
            DDLGov.DataTextField = "GovernorateName";
            DDLGov.DataValueField = "GovernorateID";
            DDLGov.DataBind();
        }

        DDLGov.Items.Insert(0, new ListItem("--اختيار--", "0"));

    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate("register");
        if (Page.IsValid)
        {
            divmodalmsg.Visible = false;
            divmodalmsg.InnerHtml = "";

            DataTable dt = Registration(txtUserName.Text, txtName.Text, txtCivilID.Text, txtEmail.Text, txtmobile.Text, int.Parse(DDLGov.SelectedValue.ToString()), txtPwd.Text, cmbGender.Value.ToString(),txtMname.Text.ToString().Trim(),txtTname.Text.ToString().Trim(),txtLname.Text.ToString().Trim());

            divmodalmsg.Visible = true;
            divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> " + dt.Rows[0]["message"].ToString() + " </strong>  </div>";  

            if (dt.Rows[0]["message"].ToString().Trim() == "Insert Sucessfully")
            {

                Session["rEmail"] = txtEmail.Text;
                Session["rmob"] = txtmobile.Text;
                Session["rsmscount"] = 1;
                Response.Redirect("UserVerification.aspx", false);

            }

        }
    }

    public DataTable Registration(string ls_name, string ls_fullname, string ls_civil, string ls_email, string ls_phone, int ls_govID, string ls_pwd, string ls_gender,string mname,string tname,string lname)
    {

        DataTable dt = new DataTable();
        DataInsertReturn dtr = new DataInsertReturn();
       
        fnReturnCivilId dtrCivil = new fnReturnCivilId();

        try
        {
            dtrCivil = clsGeneral.CheckCivilId(ls_civil);

            if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where username='" + ls_name + "'", GstrDbKey).Equals("0"))
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("اسم المستخدم مسجل معنا سابقا "), 0);
                return dt;
            }
            if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil + "'", GstrDbKey).Equals("0"))
            {
                dt= clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("البطاقة المدنية مسجلة معنا سابقا."), 0);
                return dt;
            }

            if (dtrCivil.ValidCivil == false)
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 0);
                return dt;
            }
            if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey).Equals("0"))
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("البريد الالكتروني مسجل معنا سابقا "), 0);
                return dt;
            }
            if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where phone='" + ls_phone + "'", GstrDbKey).Equals("0"))
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("رقم الموبايل مسجل معنا سابقا "), 0);
                return dt;
            }


            string ls_otp = clsGeneral.GenerateOTP();

            Object obj;
            string ls_body;
            string ls_encrpwd;


            string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(ls_pwd.Trim()), Server.HtmlEncode(ls_civil), "SHA512", null);

            String ls_dob = clsGeneral.DobFromCivil2(ls_civil);

            dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_Register N'" + ls_name + "',N'" + ls_fullname + "',N'" + ls_civil + "','" + ls_email + "',N'" + ls_phone + "','" + ls_govID + "',N'" + ePass + "','" + ls_otp + "',N'" + ls_gender + "','" + ls_dob + "',N'"+mname+"',N'"+tname+"',N'"+lname+"'", GstrDbKey);
           
            if (dtr.DataInsert == true)
            {
                sms(ls_phone, ls_otp);
                ls_body = PopulateBodyRegister(ls_name, ls_otp);
                DataInsertReturn dtr1 = new DataInsertReturn();
                dtr1 = SendEmail(ls_email, ls_body, "مرحبا بك في مباراتنا .");
                //if (dtr.DataInsert == true)
                //{
                //    dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
                //}
                //else
                //{
                //    dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
                //}
                dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
                return dt;
            }
            else
            {
                dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
                return dt;
            }
            //if (DS.Tables[0].Rows.Count == 0)
            //    dt = msgResponse("", "True", "NO ITEMS FOUND", 0);
            //else
            //    dt = DS.Tables[0];
            //Context.Response.Write(js.Serialize(GetJSon(dt)));

        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
            return dt;
        }
        finally
        {

        }

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

          
            catch (Exception ex)
            {
                dtr.DataInsert = false;
                dtr.ErrorMsg = ex.Message;
                return dtr;
            }

        }
        return dtr;
    }

 
    protected void DDLGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = DDLGov.SelectedValue.ToString();

        if (!DDLGov.SelectedValue.ToString().Equals("0") && !string.IsNullOrEmpty(DDLGov.SelectedValue.ToString()))
        {
            DataTable dt = new DataTable();
            string GovID = DDLGov.SelectedValue.ToString();
            dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_AreaForReg '" + GovID + "'");
            if (dt.Rows.Count > 0)
            {
                DDLArea.DataSource = dt;
                DDLArea.DataTextField = "AreaName";
                DDLArea.DataValueField = "AreaID";
                DDLArea.DataBind();
            }
          //  DDLArea.Items.Insert(0, new ListItem("--اختيار--", "0"));
        }
        else
        {
            DDLArea.ClearSelection();
            DDLArea.Items.Clear();
        }
    }
}