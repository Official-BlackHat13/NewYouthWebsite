using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public partial class YouthValley_OnlineCourseReg : System.Web.UI.Page
{
    fn_General fn = new fn_General();
    General gm = new General();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        fn.checkQueryString(Request.QueryString["id"].ToString());
       //
        if (!Page.IsPostBack)
        {
            //this.ActivityRegID = -1;
            FillLists();

        }
    }

    protected void ddlarea_Load(object sender, EventArgs e)
    {
        foreach (ListItem item in ddlArea.Items)
        {
            if ((item.Value == "A") || (item.Value == "B") || (item.Value == "C") || (item.Value == "D") || (item.Value == "E") || (item.Value == "F"))
            {
                item.Attributes.Add("style", "color: #6CACC5;font-weight:bolder;background-color:lightgrey;");
                item.Attributes.Add("disabled", "disabled");
            }
        }
    }


    private void FillLists()
    {
        try
        {
            int id;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {

                SqlConnection cnn = new SqlConnection();

                cnn.ConnectionString = gm.YPA();
                cnn.Open();

                //  SqlCommand cmd = new SqlCommand("exec sp_get_Activities", cnn);
                SqlCommand cmd = new SqlCommand("exec Sp_GetActivities @id=12", cnn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int activityid = Convert.ToInt32(dt.Rows[0]["ActivityID"].ToString());

                    if (activityid == 12)
                    {

                        this.ActivityID = 12;
                        //drpHobbies.Items[3].Enabled = false;
                        //drpHobbies.Items[1].Enabled = false;
                        //drpHobbies.Items[2].Enabled = false;

                    }



                    txtActivityType.Text = dt.Rows[0]["ActivityTypeAr"].ToString();

                    DateTime dateto = Convert.ToDateTime(dt.Rows[0]["DateTo"].ToString());
                    if (dateto < DateTime.Now)
                    {
                        Response.Redirect("~/ActivityDetails.aspx?id=" + activityid);
                    }
                }
                else
                    Response.Redirect("~/Index_AR.aspx", false);
            }


            else
            {
                Response.Redirect("~/Index_AR.aspx", false);
            }
       }
 
        catch (Exception ex)
        {
            //Globals.WriteLog(this, ex.Message);

            Console.WriteLine(ex);
        }
   // }

  }





    protected void btnSend_Click(object sender, EventArgs e)
    {
       // Divalert.Visible = false;
        //Page.Validate("ContactUs");
        //if (Page.IsValid)
        //{
            DateTime dob;
            bool isDate;
            isDate = DateTime.TryParse(txtDOB.Text, out dob);

            int age = ToAgeString(Convert.ToDateTime(txtDOB.Text));

            if ((age < 18) || (age > 35))
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

            if (ddlSex.SelectedValue == "" || ddlSex.SelectedValue=="-1")
            {
                pnlMessage.Visible = true;
                lblMessage.Text = "الرجاء اختيار الجنس";
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



            SqlConnection con = new SqlConnection();
            con.ConnectionString = gm.YPA();
            con.Open();

            //int yy = (DateTime.Now.Year);
            //int serialNo = 1;
            int mType = Convert.ToInt32(MaintenanceType.ActivitiesReg);

           
    
            //string query = "Select * From ActivitiesReg  where Activityid=12 and category='2' and (Email=N'" + txtEmail.Text + "' or Nationality = '" + txtNatNo.Text + "')";
            //SqlCommand cmd1 = new SqlCommand(query, con);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);

            //if (dt1.Rows.Count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Already Registered!!!!');", true);
            //    return;
            //}
           


            SqlCommand cmd = new SqlCommand("SP_Add_CourseReg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstNameAr",txtFirstName.Text);
            cmd.Parameters.Add("@FatherNameAr", txtFatherName.Text);
            cmd.Parameters.Add("@FamilyNameAr",  txtFamilyName.Text);

            cmd.Parameters.Add("@Year",DateTime.Now.Year);
            cmd.Parameters.Add("@Gender", ddlSex.SelectedValue);
            cmd.Parameters.Add("@Telephone",Convert.ToInt64(txtPhone.Text));
            cmd.Parameters.Add("@Email", txtEmail.Text);
            cmd.Parameters.Add("@BirthDate", dob);
            cmd.Parameters.Add("@Nationality", "KW");
            cmd.Parameters.Add("@NatID",Convert.ToInt64(txtNatNo.Text)); ;
            cmd.Parameters.Add("@CreatedDate", DateTime.Now);
            cmd.Parameters.Add("@Approval",  0);
            cmd.Parameters.Add("@ActivityType",  txtActivityType.Text);
            cmd.Parameters.Add("@ActivityID",  12);
            cmd.Parameters.Add("@Area",ddlArea.SelectedValue.ToString().Trim());
            cmd.Parameters.Add("@Address", drpHobbies.SelectedValue.ToString());
            cmd.Parameters.Add("@Hobby", txtHobbies.Text.ToString().Trim()); //
            //cmd.Parameters.Add("@Hobby", drpHobbies.SelectedItem.Text);
            cmd.Parameters.Add("@Category",  2);
            cmd.Parameters.Add("@mType", mType);            
            cmd.Parameters.Add("@res", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();


            string result = cmd.Parameters["@res"].Value.ToString();
            if (result == "01")
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('');", true);


                pnlMessage.Visible = true;
                lblMessage.Text = "Already Registered!!!!";
                Divalert1.Visible = true;
                Divalert.Visible = false;
            }
            else
            {

              
                 Divalert.Visible = true;
                 Divalert1.Visible = false;
                
               // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Registered Successfully!!!');", true);
            }

      //  }
    }
  

    protected void btnBackToHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index_AR.aspx", false);
    }

      private void Clear()
        {
            txtNatNo.Text = "";
            txtPhone.Text = "";
            txtActivityType.Text = "";
            txtEmail.Text = "";
            // txtAddress.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtFamilyName.Text = "";
            txtFatherName.Text = "";
            txtFirstName.Text = "";
            ddlArea.SelectedValue = "-1";
            // ddlNat.ClearSelection();
            ddlSex.ClearSelection();
            //ddlVBefore.ClearSelection();
            drpHobbies.ClearSelection();
            // pnlCat.Visible = false;

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

                    //if (year > DateTime.Now.Year) year += 2000;
                    //else if (year < 100) year += 1900;
                    try
                    {
                        foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                        //int dobyear = Convert.ToInt32(year1);// Convert.ToInt32(DateTime.Parse(dob1).Year);
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

                            if (diff > 18 && diff < 35)  /*(diff > 11 && diff < 19) */    //*(diff > 13 && diff < 35)*/

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
            if (!string.IsNullOrEmpty(dob.ToString()))
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

                //return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                //                     years, (years == 1) ? "" : "s",
                //                     months, (months == 1) ? "" : "s",
                //                     days, (days == 1) ? "" : "s");

                return years;
            }
            else
                return 0;


        }


     bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
        protected void txtNatNo_TextChanged(object sender, EventArgs e)
        {
         
           lblCivil.Visible = false;
        string civil_id = Server.HtmlEncode(txtNatNo.Text.Trim());

        bool num_result = IsDigitsOnly(civil_id);
        if ((num_result == true) && (civil_id.Length == 12))
        {

            string civil = civil_id;


            int c1 = int.Parse(civil.Substring(0, 1));
            int c2 = int.Parse(civil.Substring(1, 1));
            int c3 = int.Parse(civil.Substring(2, 1));
            int c4 = int.Parse(civil.Substring(3, 1));
            int c5 = int.Parse(civil.Substring(4, 1));
            int c6 = int.Parse(civil.Substring(5, 1));
            int c7 = int.Parse(civil.Substring(6, 1));
            int c8 = int.Parse(civil.Substring(7, 1));
            int c9 = int.Parse(civil.Substring(8, 1));
            int c10 = int.Parse(civil.Substring(9, 1));
            int c11 = int.Parse(civil.Substring(10, 1));
            int c12 = int.Parse(civil.Substring(11, 1));

            int vresult = ((c1 * 2) + (c2) + (c3 * 6) + (c4 * 3) + (c5 * 7) + (c6 * 9) + (c7 * 10) + (c8 * 5) + (c9 * 8) + (c10 * 4) + (c11 * 2));
            double vresult1 = (vresult / 11);
            double tvresult1 = Math.Floor(vresult1);
            double tvresult2 = (tvresult1 * 11);
            double totvresult = (vresult - tvresult2);
            double alltotvresult = (11 - totvresult);


            if (alltotvresult == c12)
            {
                txtNatNo.Text = civil;
                lblCivil.Visible = false;

            }
            else
            {
                // txtCivilID.Text = "";
                lblCivil.Visible = true;
            }



              
                 string dob = DobFromCivil(civil_id);

                string[] Arrdob = dob.Split('~');

             int  cnt = Convert.ToInt16(Arrdob[0]);
                int age= Convert.ToInt16(Arrdob[2]);
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
                    lblCivil.Text = "العمر يجب ان يكون 12-18";// for 2021 course
 
                     txtDOB.Text = "";

                }
                else
                {
                    lblCivil.Visible = false;
                    dob = Arrdob[1];
                    txtDOB.Text = dob;

                    if (age > 11 && age < 16)

                    {
                        drpHobbies.Items[2].Enabled = true;
                        drpHobbies.Items[1].Enabled = true;
                    }
                    else
                    {
                        drpHobbies.Items[2].Enabled = false;
                        drpHobbies.Items[1].Enabled = false;
                    }

                    if (age > 15 && age < 19)
                    {

                        drpHobbies.Items[3].Enabled = true;
                    }
                    else
                    { 
                        drpHobbies.Items[3].Enabled = false;
                    }

                }

            }
            else
            {
                lblCivil.Visible = true;
                txtDOB.Text = "";
            }
        }

    
        public int YPAEmail(string emailid, string civil, string Course)
        {

            String email = emailid;
            int i = 0;
            if (!email.Equals(""))
            {

                var message = new MailMessage();

                // Settings.  
                message.To.Add(new MailAddress(emailid));
                message.From = new MailAddress("youthvalley@ypa.gov.kw");
                message.Subject = "Online Course Registration_YPA";
                //message.Body = "Dear User" + "</br>" + "Your Contract" + " Name " + " Will be Expired in Next" + " remiderdays + days";
                // message.IsBodyHtml = true;



                //           message.Body = string.Format("<br/>  <span style='color:black'><b> {0}</b></span> <br /> <span style='color: #6CACC5'>{1}</span> <br/> <span style='color:black'><b> {2}</b></span> <br /><span style='color:black'><b> {3}</b></span><br /> <span style='color: #6CACC5'>{4}</span><br /><b> {5}</b> "
                //, "تم اكتمال بياناتك للتسجيل فى مجلس الشباب الكويتي برقم ",unique, "سوف تتلقى بريد الكتروني او رساله نصيه اذا كنت من المرشحين المؤهلين.", "للاستفسار او اضافه اي مرفقات او ملفات اضافيه يرجى تحديد رقم المرجع الخاص بك ,,,https://www.ypa.gov.kw/", unique, " info@ypa.gov.kw وارساله على ");


                // message.Body = string.Format("<br/> <span style='color:black'><b> {0}</b></span><br/> <span style='color: #6CACC5'>{1}</span> <br/><br/> <span style='color:black'><b>{2}</b></span><br/> <span style='color:#6CACC5'><b> {3}</b></span><br/><b /><span style='color:black'><b>{4}</b></span><br/> <span style='color:#6CACC5'><b>{5}</b></span><br/><br/><span style='color:black'><b>{6}</b></span><br/><span style='color:black'><b> {7}</b></span><br/><span style='color: #6CACC5'>{8}</span><br/><span style='color:black'>{9}</span><br/><span style='color: #6CACC5'><b>{10}</b></span><br/>",
                // "لقد تم تسجيلك في الدورة ", Course, "الرجاء الدخول على الرابط التالي", "http://www.dawrat.com/g/ypa", "ملاحظة:", "سيتم تفعيل حسابكم في موقع دورات.كوم خلال ٢٤ ساعة من تسجيلكم.", "للدخول على الدورات يرجى استخدام التالي", "Email: ", email, "Civil ID: ", civil);

                message.Body = string.Format("<br/> <span style='color:black'><b> {0}</b></span><span style='color: #6CACC5'>{1}</span> <br/><br/> <span style='color:black'><b>{2}</b></span><br/><br/> <span style='color:#6CACC5'><b> {3}</b></span><br/><b /><span style='color:#6CACC5'><b>{4}</b></span><br/> ",
                 "لقد تم تسجيلك في دورة ", Course, "يرجى الانتظار لحين التواصل معكم ، علماً بأن الاختيار حسب الأولويه .", "مع تحيات الهيئه العامه للشباب ", "@ypakw");

                message.IsBodyHtml = true;


                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("youthvalley@ypa.gov.kw", "youth@123");
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
       

        protected void drpHobbies_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(drpHobbies.SelectedValue);

            DataSet ds = GetDSYPI("exec SP_GetHobbies '@ActivityID=16,@Address=N'" + drpHobbies.SelectedValue + "'");

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    int cnt = Convert.ToInt32(dt.Rows[0]["totalcount"].ToString());

                    if (cnt >= 40)// 2021 course, category = 2                   
                    {
                        pnlMessage.Visible = true;
                        lblMessage.Text = "لقد اكتمل العدد في الدورة المختاره، يمكنكم التسجيل في دورة أخرى";
                        drpHobbies.Items[i].Enabled = false;
                    }

                }
            }

           
                

              //  SqlConnection cnn = new SqlConnection();
              //  cnn.ConnectionString = gm.YPA();
              //  cnn.Open();
              //  SqlCommand cmd = new SqlCommand("Select * From ActivitiesReg", cnn);
              //  SqlDataAdapter da = new SqlDataAdapter(cmd);
              // DataTable dt = new DataTable();
              //  da.Fill(dt);

              //cnn.Close();
              //if (dt.Rows.Count > 0)
              //{
                
              //    int pcount =Convert.ToInt32( dt.Rows[0]["ActivityID"].ToString());
              //    var add = dt.Rows[0]["Address"].ToString();
              //    if (pcount == 12 && add == drpHobbies.SelectedValue) 
              //    {

              //        pnlMessage.Visible = true;
              //        lblMessage.Text = "لقد اكتمل العدد في الدورة المختاره، يمكنكم التسجيل في دورة أخرى";
              //        drpHobbies.Items[i].Enabled = false;
              //    }

              //}
       
        

            }
        protected void lnksub_Click(object sender, System.EventArgs e)
        {
             Page.Validate("ContactUs");
             if (Page.IsValid)
             {

             }
        }
}
  