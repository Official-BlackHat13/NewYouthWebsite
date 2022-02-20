using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Youngleaders : System.Web.UI.Page
{
    private int ActivityRegID
    {
        get
        {
            return (int)Session["ActivityRegID"];
        }
        set
        {
            Session["ActivityRegID"] = value;
        }
    }

    private int ActivityID
    {
        get
        {
            return Convert.ToInt32(ViewState["ActivityID"]);
        }
        set
        {
            ViewState["ActivityID"] = value;
        }
    }
    public static int cnt = 0;
     General gm = new General();
    fn_General fn = new fn_General();

    protected void Page_Load(object sender, EventArgs e)
    {

        fn.checkQueryString(Request.QueryString["id"].ToString());

        if (!Page.IsPostBack)
        {
            this.ActivityRegID = -1;
            FillLists();


        }
    }
    private void FillLists()
    {
        try
        {
            int id;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {

                DataSet dts = GetDSYPI("exec Sp_GetActivities @id=17");

                if (dts.Tables.Count > 0)
                {
                    DataTable dt = dts.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DateTime DateTo = Convert.ToDateTime(dt.Rows[0]["DateTo"].ToString());
                        int ActivityID = Convert.ToInt32(dt.Rows[0]["ActivityID"].ToString());
                        txtActivityType.Text = dt.Rows[0]["ActivityTypeAr"].ToString(); //activity.ActivityTypeAr;
                        if (DateTo < DateTime.Now)
                        {
                            Response.Redirect("~/ActivityDetails.aspx?id=" + ActivityID);
                        }

                        if (id != 17)
                        {
                            Response.Redirect("~/index_AR.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/index_AR.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/index_AR.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    public DataSet GetDSYPI(string SQLstring)
    {

        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.YPA();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataSet DS = new DataSet();

            SDA.Fill(DS);
            SDA.Dispose();
            return DS;

        }
    }

    public int YPAEmail(string emailid, string name)
    {

        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {

            var message = new MailMessage();

            // Settings.  
            message.To.Add(new MailAddress(emailid));
            message.From = new MailAddress("ah.youthcenter@youth.gov.kw");
            message.Subject = "المركز الحرفي الشبابي التراثي";
           
            message.Body = string.Format("<br/> <span style='color:black'><b> {0}</b></span><span style='color: #6CACC5'>{1}</span> <br/><br/> <span style='color:black'><b>{2}</b></span><br/> ",
             "تم تسجيل ", name, "ايميل: ah.youthcenter@youth.gov.kw");


            message.IsBodyHtml = true;


            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ah.youthcenter@youth.gov.kw", "Ahyc2021");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(message);
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                //  lblMessage.Text = ex.Message;
                i = 1;
            }
        }
        return i;
    }

    protected void btnBackToHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index_AR.aspx");
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {


            try
            {

                DateTime dob;
                bool isDate;
                isDate = DateTime.TryParse(txtDOB.Text, out dob);

                int age = ToAgeString(Convert.ToDateTime(txtDOB.Text));

                if ((age < 20) || (age > 34))
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "العمر غير مطابق لشروط";
                    // lblMessage.ForeColor=Red;
                    return;
                }



                if (!isDate)
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "الرجاء اختيار تاريخ ميلاد صحيح";
                    return;
                }

                if (txtNatNo.Text.Length < 12)
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "الرقم المدني يجب ان يكون 12 رقم";
                    return;
                }

                if (txtPhone.Text.Length < 8)
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "رقم الهاتف يجب ان يكون 8 رقم";
                    return;
                }

                Double civil = Convert.ToInt64(txtNatNo.Text);
                General gm = new General();
               
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.YPA();
                cnn.Open();
                int mType = Convert.ToInt32(MaintenanceType.ActivitiesReg);
                string query = "SP_Add_YoungLeaderReg";
                SqlCommand cmd2 = new SqlCommand(query, cnn);

                cmd2.CommandType = CommandType.StoredProcedure;                             
             
                cmd2.Parameters.AddWithValue("@FirstNameAr", SqlDbType.NVarChar).Value = txtFirstName.Text;
                cmd2.Parameters.AddWithValue("@FatherNameAr", SqlDbType.NVarChar).Value = string.Empty;
                cmd2.Parameters.AddWithValue("@FamilyNameAr", SqlDbType.NVarChar).Value = string.Empty;
                cmd2.Parameters.AddWithValue("@mType", SqlDbType.Int).Value = mType;
                cmd2.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = DateTime.Now.Year;
                cmd2.Parameters.AddWithValue("@NatID", SqlDbType.NVarChar).Value = Convert.ToInt64(txtNatNo.Text);
                cmd2.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = true;
                cmd2.Parameters.AddWithValue("@Telephone", SqlDbType.BigInt).Value = txtPhone.Text;
                cmd2.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd2.Parameters.AddWithValue("@BirthDate", SqlDbType.NVarChar).Value = dob;
                cmd2.Parameters.AddWithValue("@Nationality", SqlDbType.NVarChar).Value = "KW";
                cmd2.Parameters.AddWithValue("@hobby", SqlDbType.NVarChar).Value = txtcertificate.Text;
                cmd2.Parameters.AddWithValue("@CreatedDate", SqlDbType.NVarChar).Value = DateTime.Now;
                cmd2.Parameters.AddWithValue("@Approval", SqlDbType.Int).Value = 0;
                cmd2.Parameters.AddWithValue("@ActivityType", SqlDbType.NVarChar).Value = txtActivityType.Text; ;
                cmd2.Parameters.AddWithValue("@ActivityID", SqlDbType.Int).Value = 17;
                cmd2.Parameters.AddWithValue("@ActivityRegID", SqlDbType.Int).Value = ActivityRegID;
                cmd2.Parameters.Add("@res", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd2.ExecuteNonQuery();
                cnn.Close();
                string result = cmd2.Parameters["@res"].Value.ToString();
                if (!result.Equals("01"))
                {

                    int Email = YPAEmail(txtEmail.Text, txtFirstName.Text);
                    
                    Clear();
                    Divalert.InnerHtml = "لقد تم ارسال طلبك بنجاح!";
                    Divalert.Attributes.Add("class", "alert alert-success");
                    Divalert.Visible = true;
                    Response.Redirect("thankyou.aspx", false);
                   
                }
                else
                {
                    
                   // Divalert.InnerHtml = "عذراً، الرقم المدني مستخدم مسبقاً";
                  //  Divalert.Attributes.Add("class", "alert alert-danger");
                 //  Divalert.Visible = true;
                    alertCivilID.Visible = true;
                   // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('already applied ..!!');</script>", false);
                 
                  //  ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:ShowDivInnerHTML(); ", true);
                   // Page.ClientScript.RegisterStartupScript(this.GetType(), "MyKey", "getMyOutput();");
                    lblalert.Text = "CivilId Already Exists";
                    Divalert.InnerHtml = "لقد تم ارسال طلبك بنجاح!";
                    Divalert.Attributes.Add("class", "alert alert-success");
                    Divalert.Visible = true;

                }
                

            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);

                pnlMessage.Visible = true;
                lblMessage.Text = "حدث حطأ";
            }
           
    }
       

    public string DobFromCivil(string civil_id)
    {
        int year;
        int cnt = 0;
        string returndob = null;

        //if input is arabic numberes.
        string enddate1 = civil_id;

        string first_digit = enddate1.Substring(0, 1);
        string sub = enddate1.Substring(1, 6);
        string year1 = sub.Substring(0, 2);
        string month = sub.Substring(2, 2);
        string date = sub.Substring(4, 2);
        int diff = 0;
        string dob = date + "/" + month + "/" + year1;



        DateTime foundDate;
        Match matchResult = Regex.Match(dob,
            "^(?<day>[0-3]?[0-9])/(?<month>[0-3]?[0-9])/(?<year>(?:[0-9]{2})?[0-9]{2})$");
        if (matchResult.Success)
        {
            year = int.Parse(matchResult.Groups["year"].Value);

            if ((first_digit == "3") || (first_digit == "2"))
            {
                if (first_digit == "3") year += 2000;
                else if (first_digit == "2") year += 1900;

                try
                {
                    foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                     int years = Convert.ToInt32(DateTime.Now.Year);
                    diff = (years - year);
                    string dateformate = year + "/" + month + "/" + date;
                    if (diff < 1)
                    {
                        cnt = 1;

                    }
                    else
                    {
                        if ((DateTime.Parse(dateformate).Month > DateTime.Now.Month) || (DateTime.Parse(dateformate).Month == DateTime.Now.Month && DateTime.Parse(dateformate).Day > DateTime.Now.Day))

                            diff = diff - 1;

                    
                        if (diff > 20 && diff < 34)    

                            returndob = year + "/" + month + "/" + date;

                        else

                            cnt = 2;

                    }
                }
                catch (Exception ex)
                {
                    cnt = 1;

                }
            }
            else
            {
                cnt = 1;

            }
        }
        else
        {
            cnt = 1;

        }
        string a = cnt + "~" + returndob + "~" + diff;
        return a;

    }
    public static int ToAgeString(DateTime dob)
    {
        DateTime today = DateTime.Today;

        int months = today.Month - dob.Month;
        int years = today.Year - dob.Year;

        if (today.Day < dob.Day)
        {
            months--;
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        int days = (today - dob.AddMonths((years * 12) + months)).Days;

     

        return years;


    }

    protected void txtNatNo_TextChanged(object sender, EventArgs e)
    {
        cnt = 0;
        lblCivil.Visible = false;


        string civil_id = Server.HtmlEncode(txtNatNo.Text);

        if (civil_id != string.Empty && (civil_id.Length == 12))
        {           

            string dob = DobFromCivil(civil_id);

            string[] Arrdob = dob.Split('~');

            cnt = Convert.ToInt16(Arrdob[0]);
            int age = Convert.ToInt16(Arrdob[2]);
            if (cnt == 1)
            {
                lblCivil.Visible = true;
                lblCivil.Text = "الرقم المدني غير صحيح";
                txtDOB.Text = "";

            }
            else if (cnt == 2)
            {
                lblCivil.Visible = true;
                // lblCivil.Text = "العمر يجب ان يكون 14-34"; for 2020 course
               // lblCivil.Text = "العمر يجب ان يكون 17-34";// for 2021 course
                lblCivil.Text = "العمر يجب ان يكون 20-34";// for 2022course

                txtDOB.Text = "";

            }
            else
            {
                dob = Arrdob[1];
                txtDOB.Text = dob;



            }

        }
        else
        {
            lblCivil.Visible = true;
            txtDOB.Text = "";
        }
    }


    private void Clear()
    {

        txtNatNo.Text = "";
        txtPhone.Text = "";
        txtActivityType.Text = "";
        txtEmail.Text = "";
        txtFirstName.Text = "";
        txtDOB.Text = "";



    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


}