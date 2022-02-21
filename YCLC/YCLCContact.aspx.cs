using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;
using QRCoder;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;

public partial class YCLCContact : System.Web.UI.Page
{
    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    general_fn Obj_GenMethods = new general_fn();
    public static int cnt = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        success.Visible = false;
        alert.Visible = false;
        alert2.Visible = false;

        string txt = txtSuggestions.Text;

        if (!IsPostBack)
        {


            FillCapctha();
        }
    }
    
    void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["randomStr"] = captcha.ToString();
            imgCaptcha.ImageUrl = "~/Turing.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }
    
    protected void txtcivil_TextChanged(object sender, EventArgs e)
    {
        cnt = 0;
        lbl_civil.Visible = false;
        int year;
        string civil_id = txtcivil.Text;
        bool num_result = IsDigitsOnly(civil_id);
        int civilcnt = 0;
        civilcnt = civil_id.Length;

        if ((num_result == true) && (civil_id != string.Empty) && (civilcnt==12))
        {
            string first_digit = civil_id.Substring(0, 1);
            string sub = civil_id.Substring(1, 6);
            string year1 = sub.Substring(0, 2);
            string month = sub.Substring(2, 2);
            string date = sub.Substring(4, 2);

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
                        int diff = (years - year);
                        if (diff < 1)
                        {
                            cnt = 1;
                            lbl_civil.Visible = true;
                            //  lbl_civil.Text = "Civil ID is not Correct";
                            // datepicker.Text = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            // datepicker.Text = date + "/" + month + "/" + year;
                        }

                    }
                    catch (Exception ex)
                    {
                        cnt = 1;
                        lbl_civil.Visible = true;
                        // lbl_civil.Text = "Civil ID is not Correct";
                    }
                }
                else
                {
                    cnt = 1;
                    lbl_civil.Visible = true;
                    // lbl_civil.Text = "Civil ID is not Correct";

                }
            }
            else
            {
                cnt = 1;
                lbl_civil.Visible = true;
                // lbl_civil.Text = "Civil ID is not Correct";
            }
        }
        else
        {
            RegularExpressionValidator1.Validate();

        }
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

    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        DateTime date = DateTime.Now;
        string dt = string.Format("{0:M/d/yyyy}", date);

        if (Session["randomStr"] != null)
        {
             if (Page.IsValid && (txtTuring.Text.ToString() == Session["randomStr"].ToString()))
              {

                  try
                  {
                      string encoded = Server.HtmlEncode(txtSuggestions.Text.ToString().Trim());
                      
                     

                      cnn.ConnectionString = gm.ConnectionString();
                      cnn.Open();
                      SqlCommand PIDCommand = new SqlCommand("YCLC_contact", cnn);
                      PIDCommand.CommandType = CommandType.StoredProcedure;

                      PIDCommand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "insert";
                      PIDCommand.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = txtName.Text;
                      PIDCommand.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = txtNumber.Text;
                      PIDCommand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                      PIDCommand.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = txtcivil.Text;
                      PIDCommand.Parameters.AddWithValue("@message", SqlDbType.NVarChar).Value = encoded;                     
                    
                     
                   
                      var returnParameter = PIDCommand.Parameters.Add("@ERROR", SqlDbType.NVarChar);
                      returnParameter.Direction = ParameterDirection.Output;
                      returnParameter.Size = 100;
                      PIDCommand.ExecuteNonQuery();

                      string message =PIDCommand.Parameters["@ERROR"].Value.ToString();
                     
                      if(!string.IsNullOrEmpty(message))
                      {
                          string[] items = new string[8];
                          items[0] = txtName.Text;
                          items[1] = txtNumber.Text;
                          items[2] = txtEmail.Text;
                          items[3] = txtcivil.Text;
                          items[4] = encoded;
                          items[5] = DateTime.Now.ToString();
                                                  
                          AnnouncementGeneral(items);                          
                        
                          success.Visible = true;
                          alert.Visible = false;
                          alert2.Visible = false;

                          txtName.Text = "";
                          txtEmail.Text = "";
                          txtNumber.Text = "";
                          txtSuggestions.Text = "";
                          txtTuring.Text = "";
                          txtcivil.Text = "";
                          pnlData.Visible = false;
                      }
                      
                  }

                  catch (SmtpException ex)
                  {
                      success.Visible = false;
                      alert.Visible = false;
                      alert2.Visible = true;
                  }               

            }
            else
            {
                //Response.Redirect("ErrorCaptcha_AR.aspx");
                success.Visible = false;
                alert.Visible = true;
                alert2.Visible = false;
            }
        }

    
    }
   
   
    protected void AnnouncementGeneral(string[] EmailBody)
    {
       
        string Body = PopulateBody(EmailBody);

        general_fn gfn = new general_fn();


        gfn.GeneralYCLCEmail(Body);

    }

    private string PopulateBody(string[] item)
    {
        string body = string.Empty;
        string p1 = "", p2 = "", p3 = "";
        using (StreamReader reader = new StreamReader(Server.MapPath("../emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        p1 = "<table border='0' cellspacing='10' cellpadding='10' width='100%'>" +
        " <tr><td colspan='2'><center> <strong> Contact Inforamtion</center></strong></td></tr>" +
         "<tr><td><b>Name</b> </td><td>: <strong>" + item[0] + "</strong></td></tr>" +
         "<tr><td><b>Contact No.</b>   </td><td>: <strong>" + item[1] + "</strong></td></tr>"+
        "<tr><td><b>Email</b> </td><td> :<strong>" + item[2] + "</strong></td></tr>" +
            "<tr><td><b>CivilId</b> </td><td> :<strong>" + item[3] + "</strong></td></tr>" +
          "<tr><td><b>Message</b> </td><td>: <strong>" + item[4] + "</strong></td></tr>" +
           "<tr><td><b>Time</b> </td><td>: <strong>" + item[5] + "</strong></td></tr></table>";
                       
      
        string textBody = p1;
        body = body.Replace("{work}", textBody);
        return body;


    }
    
   
}