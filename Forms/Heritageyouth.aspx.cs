using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Heritageyouth : System.Web.UI.Page
{
    fn_General fn = new fn_General();

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
    protected void Page_Load(object sender, EventArgs e)
    {
        Divalert.Visible = false;
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

                //DataSet  dts = GetDSYPI("select ActivityID,DateTo,ActivityTypeAr from Activities where ActivityID=16");               
                DataSet dts = GetDSYPI("exec Sp_GetActivities @id=16");
                if (dts.Tables.Count > 0)
                {
                    DataTable dt = dts.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DateTime DateTo = Convert.ToDateTime(dt.Rows[0]["DateTo"].ToString());
                        int ActivityID = Convert.ToInt32(dt.Rows[0]["ActivityID"].ToString());
                        txtActivityType.Text = dt.Rows[0]["ActivityTypeAr"].ToString();
                        if (DateTo < DateTime.Now)
                        {
                            Response.Redirect("~/ActivityDetails.aspx?id=" + ActivityID);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Index_AR.aspx", false);
                    }
                }
              
            }
            else
            {
                Response.Redirect("~/Index_AR.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    public int YPAEmail(string emailid, string name, string Course, string Date)
    {

        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {

            var message = new MailMessage();
           
            message.To.Add(new MailAddress(emailid));
            message.From = new MailAddress("web@youth.gov.kw");
            message.Subject = "المركز الحرفي الشبابي التراثي";
           
            message.Body = string.Format("<br/> <span style='color:black'><b> {0}</b></span><span style='color: #6CACC5'>{1}</span> <br/><br/> <span style='color:black'><b>{2}</b></span><br/> <span style='color:#6CACC5'><b> {3}</b></span><br/><br/><b /><b>{4}</b><br/><span style='color:#6CACC5'><b>{5}</b></span><br/><br/>{6}<br/><br/>{7}<br/>{8}<br/><br/>{9}<br/>{10}<br/>{11}<br/> ",
             "تم تسجيل ", name, "الدورة", Course, "Starting Date", Date, "الوقت من ٥م إلى ٨م", "في المركز الحرفي الشبابي التراثي", "الكائن في منطقه القادسية قطعه ٨ شارع ٨٤", "للاستفسار", "هاتف: 97795513 ", "ايميل: ah.youthcenter@youth.gov.kw");


            message.IsBodyHtml = true;


            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
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
        Response.Redirect("~/Index_AR.aspx.aspx",false);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
         //   Divalert.Visible = false;

            DateTime dob;
            bool isDate;
            isDate = DateTime.TryParse(txtDOB.Text, out dob);

            int age = ToAgeString(Convert.ToDateTime(txtDOB.Text));

            if ((age < 17) || (age > 34))
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
            SqlConnection con = new SqlConnection();

            if (con.State == ConnectionState.Open)
                con.Close();
            con.ConnectionString = gm.YPA();



            con.ConnectionString = gm.YPA();
            con.Open();

            int mType = Convert.ToInt32(MaintenanceType.ActivitiesReg);

            SqlCommand cmd2 = new SqlCommand("SP_AddHeritageYouth", con);
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
            cmd2.Parameters.AddWithValue("@CreatedDate", SqlDbType.NVarChar).Value = DateTime.Now;
            cmd2.Parameters.AddWithValue("@Approval", SqlDbType.Int).Value = 0;
            cmd2.Parameters.AddWithValue("@ActivityType", SqlDbType.NVarChar).Value = txtActivityType.Text; ;
            cmd2.Parameters.AddWithValue("@ActivityID", SqlDbType.Int).Value = 16;
            cmd2.Parameters.AddWithValue("@Area", SqlDbType.Int).Value = DropDownList2.SelectedValue;

            cmd2.Parameters.AddWithValue("@Address", SqlDbType.Int).Value = drpHobbies.SelectedValue;
            cmd2.Parameters.AddWithValue("@Hobby", SqlDbType.NVarChar).Value = drpHobbies.SelectedItem.Text;
            cmd2.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = DropDownList2.SelectedItem.Text;
            cmd2.Parameters.AddWithValue("@ActivityRegID", SqlDbType.Int).Value = ActivityRegID;
            cmd2.Parameters.Add("@res", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            cmd2.ExecuteNonQuery();
            con.Close();
            string result = cmd2.Parameters["@res"].Value.ToString();
            if (!result.Equals("01"))
            {
               
                int Email = YPAEmail(txtEmail.Text, txtFirstName.Text, drpHobbies.SelectedItem.Text, DropDownList2.SelectedItem.Text);

                //if (Email == 0)
                //{
                    Clear();                 
                    Divalert.InnerHtml = "لقد تم ارسال طلبك بنجاح!";
                    Divalert.Attributes.Add("class", "alert alert-success");
                    Divalert.Visible = true;
                //}
                //else if (Email != 0)
                //{
                   
                //    Divalert.InnerHtml = "Email Error";
                //    Divalert.Attributes.Add("class", "alert alert-danger");
                //    Divalert.Visible = true;
                //}
            }
            else
            {               
                Divalert.InnerHtml = "عذراً، الرقم المدني مستخدم مسبقاً";
                Divalert.Attributes.Add("class", "alert alert-danger");
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

                        if (diff > 16 && diff < 35)    //*(diff > 13 && diff < 35)*/

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

        //return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
        //                     years, (years == 1) ? "" : "s",
        //                     months, (months == 1) ? "" : "s",
        //                     days, (days == 1) ? "" : "s");

        return years;


    }

    protected void drpHobbies_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = GetDSYPI("exec SP_GetHobbies '" + txtNatNo.Text.ToString() + "',16,'" + drpHobbies.SelectedValue + "','" + DropDownList2 .SelectedValue.ToString()+ "'");


        if (ds.Tables.Count > 0)
        {

            DataTable dt = new DataTable();

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                pnlMessage.Visible = true;
                lblMessage.Text = "Already Registered for this course";
                return;
            }
            else
            {
                pnlMessage.Visible = false;
            }

            dt = ds.Tables[1];
            int i = Convert.ToInt32(drpHobbies.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                int cnt = Convert.ToInt32(dt.Rows[0]["totalcount"].ToString());
                if (cnt >= 25)                
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "لقد اكتمل العدد في الدورة المختاره، يمكنكم التسجيل في دورة أخرى";
                    drpHobbies.Items[i].Enabled = false;
                }
                else { pnlMessage.Visible = false; }

            }
        }

        
    }

    protected void txtNatNo_TextChanged(object sender, EventArgs e)
    {
        cnt = 0;
        lblCivil.Visible = false;


        string civil_id = Server.HtmlEncode(txtNatNo.Text);

        if (civil_id != string.Empty && (civil_id.Length == 12))
        {
            //using (YPADBContext ctx = new YPADBContext())
            //{
            //    Double civil = Convert.ToInt64(txtNatNo.Text);
            //    //Double phone = Convert.ToInt64(txtPhone.Text);
            //    BusinessLayer.Data.ActivitiesReg result = ctx.ActivitiesRegs.FirstOrDefault(u => u.NatID == civil && u.ActivityID == 27);// || u.Telephone == phone);
            //    if (result != null)
            //    {
            //        if (result.NatID == civil)
            //        {

            //            txtNatNo.Text = "'" + civil + "'";
            //            txtNatNo.ForeColor = Color.Red;
            //            RegularExpressionValidator15.ErrorMessage = " عذراً، الرقم المدني مستخدم مسبقاً";



            //            RegularExpressionValidator15.Validate();


            //        }

            //    }
            //    else { txtNatNo.ForeColor = Color.Black; }
            //}

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
                lblCivil.Text = "العمر يجب ان يكون 17-34";// for 2021 course

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
        // txtAddress.Text = "";
        //  txtFamilyName.Text = "";
        // txtFatherName.Text = "";
        txtFirstName.Text = "";

        drpHobbies.ClearSelection();
        DropDownList2.ClearSelection();
        txtDOB.Text = "";



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


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //using (YPADBContext ctx = new YPADBContext())
        //{

        //    Double civil = Convert.ToInt64(txtNatNo.Text);
        //   var vol = ctx.ActivitiesRegs.FirstOrDefault((a => a.ActivityID.Value == 16 &&( a.Address == drpHobbies.SelectedValue || a.Area == DropDownList2.SelectedValue)));
        //    if (vol != null)
        //    {

        //        pnlMessage.Visible = true;
        //        lblMessage.Text = "عذراً، الرقم المدني مستخدم مسبقاً";
        //        return;

        //    }


        //    int i = Convert.ToInt32(DropDownList2.SelectedValue);
        //    var Pcount = ctx.ActivitiesRegs.Count(a => a.ActivityID.Value == 16 && a.Address == drpHobbies.SelectedValue && a.Area == DropDownList2.SelectedValue);
        //    cnt = Convert.ToInt32(Pcount);
        //    //if (cnt >= 50) 2020 course
        //    // if (cnt >= 40)// 2021 course, category = 2
        //    if (cnt >= 25)// 2021 course
        //    {
        //        pnlMessage.Visible = true;
        //        lblMessage.Text = "لقد اكتمل العدد في الدورة المختاره، يمكنكم التسجيل في دورة أخرى";
        //        drpHobbies.Items[i].Enabled = false;
        //    }
        //}
    }

}