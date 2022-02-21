using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;

using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

public partial class MYA2_Edit_Announcement : System.Web.UI.Page
{

    SqlConnection cnn = new SqlConnection();
    General gm = new General();
    general_fn gfn = new general_fn();

    static string prevPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                // actvity.homepage(Session["userid_Adminid"].ToString(), Session["name"].ToString(), Session["sessionid"].ToString(), "Announcement");

                if (Request.UrlReferrer != null)
                    prevPage = Request.UrlReferrer.ToString();
                contents();
            }
        }

    }
    public string GetRadioValue(ControlCollection controls, string groupName)
    {
        // using Language Intergrated Query (LINQ) in order to find the radio button that is selected in the groupName.
        var selectedRadioButton = controls.OfType<RadioButton>().FirstOrDefault(rb => rb.GroupName == groupName && rb.Checked);
        return selectedRadioButton == null ? string.Empty : selectedRadioButton.Text;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {  
       
        SQLConnection();


        string id = Session["ycl_Event_ID"].ToString();

        string eventdate = string.Empty;
        string publishdate = string.Empty;
        string publishenddate = string.Empty;
        string eventenddate = string.Empty;
        string file = string.Empty;


        string trtime = GetRadioValue(Div1.Controls, "Time");
        string age = GetRadioValue(Div1.Controls, "Age");
        string gender = GetRadioValue(Div1.Controls, "Gender");
        string startage = string.Empty;
        string endage = string.Empty;

        if (gender == "بنات")
            gender = "0";
        else if (gender == "بنين")
            gender = "1";
        else
            gender = "2";

        if (age.Equals("اخرى"))
        {
            age = txtage.Text + "-" + txtageto.Text;
            age = "(" + age + ")سنوات";
            startage = txtage.Text;
            endage = txtageto.Text;
        }
        else if (age.Equals("( 7- 9 )سنوات"))
        {
            startage = "7";
            endage = "9";
        }
        else if (age.Equals("( 10- 16 )سنوات"))
        {
            startage = "10";
            endage = "16";
        }

       
        if (trtime.Equals("أخرى"))
        {
            trtime = texttime.Text + '-' +textendtime.Text;
        }



        if (!datepicker.Text.Equals(""))
        {
            eventdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(0, 2) + "/" + datepicker.Text.Substring(3, 2);
        }
        if (!datepicker3.Text.Equals(""))
        {
            eventenddate = datepicker3.Text.Substring(6, 4) + "/" + datepicker3.Text.Substring(0, 2) + "/" + datepicker3.Text.Substring(3, 2);
        }  


        if (!datepicker1.Text.Equals(""))
        {
            publishdate = datepicker1.Text.Substring(6, 4) + "/" + datepicker1.Text.Substring(0, 2) + "/" + datepicker1.Text.Substring(3, 2);
        }
        if (!datepicker2.Text.Equals(""))
        {
            publishenddate = datepicker2.Text.Substring(6, 4) + "/" + datepicker2.Text.Substring(0, 2) + "/" + datepicker2.Text.Substring(3, 2);
        }
             
             

                try
                {
               

                    SqlCommand com = new SqlCommand();
                    com.Connection = cnn;
                    com.CommandType = CommandType.StoredProcedure;                  
                    com.CommandText = "ycl_announcement_update";


                    com.Parameters.AddWithValue("@EventName", SqlDbType.NVarChar).Value = dropdownevnt.SelectedItem.Text;
                    com.Parameters.AddWithValue("@EventDate", SqlDbType.Date).Value = eventdate;
                    com.Parameters.AddWithValue("@Time_period", SqlDbType.NChar).Value = trtime;  // radiotime.SelectedItem.Text;
                    com.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = gender;
                    com.Parameters.AddWithValue("@Age_Group", SqlDbType.NVarChar).Value = age ;
                    com.Parameters.AddWithValue("@trash", SqlDbType.NVarChar).Value = DDLStatus.SelectedValue.ToString();
                    com.Parameters.AddWithValue("@count", SqlDbType.NVarChar).Value = dropcount.SelectedItem.Text;
                    com.Parameters.AddWithValue("@PublishEndDate", SqlDbType.DateTime).Value = publishenddate;
                    com.Parameters.AddWithValue("@PublishStartDate", SqlDbType.DateTime).Value = publishdate;
                    com.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = txtcourseloc.Text;
                    com.Parameters.AddWithValue("@EventLocation", SqlDbType.DateTime).Value = txtloc.Text;
                    com.Parameters.AddWithValue("@description", SqlDbType.DateTime).Value = txtdescription.Text;
                    com.Parameters.AddWithValue("@Endescription", SqlDbType.DateTime).Value = txtENdescription.Text;
                    com.Parameters.AddWithValue("@EventEndDate", SqlDbType.DateTime).Value = (eventenddate == "" ? eventdate : eventenddate);
                    com.Parameters.AddWithValue("@startage", SqlDbType.NVarChar).Value = startage;
                    com.Parameters.AddWithValue("@endage", SqlDbType.NVarChar).Value = endage;
                    

                    if (imageUpload_a.Visible == true)
                    {
                        if (imageUpload.HasFile)
                        {

                            DateTime date1 = DateTime.Now;
                            string time = date1.ToString("yyyyMMddHHmmss");
                            string currentdate = DateTime.Now.ToString();
                            string strfilepath = Path.GetFileName(imageUpload.PostedFile.FileName.ToString());
                            string extn = Path.GetExtension(imageUpload.PostedFile.FileName.ToString());
                            string mypath = Server.MapPath(@"../webImage/" + time + extn);
                            string filenameToSave = time + extn;

                            string filename = Path.GetFileNameWithoutExtension(imageUpload.PostedFile.FileName.ToString());
                            try
                            {
                                com.Parameters.AddWithValue("@ImageName", SqlDbType.NVarChar).Value = "webImage/" + time + extn;
                                imageUpload.PostedFile.SaveAs(mypath);

                                string thumb = Path.Combine(@"C:\inetpub\wwwroot\YouthMinistry\YCL\webImage\thumbimages\");

                                System.Drawing.Image myimg = System.Drawing.Image.FromFile(mypath);

                                myimg = myimg.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                                myimg.Save(thumb + time + extn, myimg.RawFormat);

                            }
                            catch (SqlException sqlex)
                            {
                                Response.Write(sqlex);

                            }

                        }
                        else
                        {
                           com.Parameters.AddWithValue("@ImageName", SqlDbType.NVarChar).Value = hdfile.Value;
                        }
                    }
                    else
                    {

                        if (imageUpload.HasFile)
                        {

                            DateTime date1 = DateTime.Now;
                            string time = date1.ToString("yyyyMMddHHmmss");
                            string currentdate = DateTime.Now.ToString();
                            string strfilepath = Path.GetFileName(imageUpload.PostedFile.FileName.ToString());
                            string extn = Path.GetExtension(imageUpload.PostedFile.FileName.ToString());
                            string mypath = Server.MapPath(@"../webImage/" + time + extn);
                            string filenameToSave = time + extn;

                            string filename = Path.GetFileNameWithoutExtension(imageUpload.PostedFile.FileName.ToString());
                            try
                            {
                                com.Parameters.AddWithValue("@ImageName", SqlDbType.NVarChar).Value = "webImage/" + time + extn;
                                imageUpload.PostedFile.SaveAs(mypath);                              

                            }
                            catch (SqlException sqlex)
                            {
                                Response.Write(sqlex);

                            }

                        }
                        else
                        {
                            com.Parameters.AddWithValue("@ImageName", SqlDbType.NVarChar).Value = "";
                          
                        }
                    }

                   com.Parameters.AddWithValue("@id", id);


                   
                    var returnParameter = com.Parameters.Add("@ERROR", SqlDbType.NVarChar);
                    returnParameter.Direction = ParameterDirection.Output;
                    returnParameter.Size = 100;
                    com.ExecuteNonQuery();

                    string message = (string)com.Parameters["@ERROR"].Value;
                   
                    if ( !string.IsNullOrEmpty(message))
                    {
                        cnn.Close();
                        string[] items = new string[8];
                        items[0] = dropdownevnt.SelectedItem.Text;
                        items[1] = eventdate;
                        items[2] = eventenddate;
                        items[3] = txtdescription.Text;                      
                        if (DDLStatus.SelectedItem.Text == "Publish")
                        {
                        //  SendEmail(items);


                        }

                        successAdmin.Visible = true;                        
                        

                        cnn.Close();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    cnn.Close();
                }
        

            cnn.Close();
            contents();
     

    }

    public void SQLConnection()
    {

        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
    }

    
    
    protected DataTable loaddata()
    {
        SQLConnection();
        string id = Session["ycl_Event_ID"].ToString();
        string query2 = "YCL_announcement_status_update";
        SqlCommand com2 = new SqlCommand(query2, cnn);  
        com2.CommandType = CommandType.StoredProcedure; 
        com2.Parameters.AddWithValue("@id", id);        
        com2.Parameters.AddWithValue("@ActionField", "select");
        com2.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(com2);
        DataTable dt = new DataTable();
        da.Fill(dt);
        cnn.Close();
        return dt;
    }
    
    public void contents()
    {

        string age = string.Empty;
        string gender = string.Empty;
        string category = string.Empty;
        DataTable ds = new DataTable();
        //da.Fill(ds);
        ds = loaddata();
        cnn.Close();
        if (ds != null && ds.Rows.Count > 0)
        {
            string status = ds.Rows[0]["trash"].ToString().Trim();

            if (!string.IsNullOrEmpty(status))
            {
                DDLStatus.Items.FindByValue(status).Selected = true;
            }


            string time = ds.Rows[0]["Time_period"].ToString().Trim();
            if (time == "4:30 PM - 6:30 PM")
            {
                radiotime1.Checked = true;
            }
            else if (time.Equals("7:00 PM - 9:30 PM"))
            {
                radiotime2.Checked = true;
            }
            else
            {
                radiotime3.Checked = true;
                paneltime.Visible = true;
                string time1 = time.Substring(0, time.IndexOf('-'));
                string time2 = time.Substring(time.IndexOf('-') + 1);

                texttime.Text = time1;
                textendtime.Text = time2;
            }

            

           
            
            age = ds.Rows[0]["Age_Group"].ToString().Trim();            
            if (age == "( 7- 9 )سنوات")           
                radioage1.Checked = true;
            else if (age == "(10 - 16 )سنوات")
                radioage2.Checked = true;
            else
                radioage3.Checked = true;

            if (radioage3.Checked == true)
            {                
                panelage.Visible = true;

                txtage.Text = ds.Rows[0]["StartAge"].ToString().Trim();
                txtage.Enabled = true;
                txtageto.Text = ds.Rows[0]["EndAge"].ToString().Trim();
                txtageto.Enabled = true;
            }




            gender = ds.Rows[0]["Gender"].ToString().Trim();
            if (gender == "False")
            {
                radgender1.Checked = true;
            }
            else if (gender == "True")
                radgender2.Checked = true;
            else if(gender == "2")
                radgender3.Checked = true;


      
          // dropdownevnt.SelectedItem.Text = ds.Rows[0]["EventName"].ToString();
            dropdownevnt.ClearSelection();
           string name = ds.Rows[0]["EventName"].ToString();
            dropdownevnt.Items.FindByText(ds.Rows[0]["EventName"].ToString().Trim()).Selected = true;
         
           

            string sdate = ds.Rows[0]["EventDate"].ToString().Trim();
            if (!sdate.Equals(""))
            {
                DateTime d2 = Convert.ToDateTime(sdate);
                datepicker.Text = (d2.Date).ToString("MM/dd/yyyy");
            }
            else
                datepicker.Text = "";

            string eventenddate = ds.Rows[0]["EventEndDate"].ToString().Trim();
            if (!eventenddate.Equals(""))
            {
                DateTime d2 = Convert.ToDateTime(sdate);
                if (eventenddate.Equals(sdate))
                    datepicker3.Text = "";
                else
                    datepicker3.Text = (d2.Date).ToString("MM/dd/yyyy");
            }
            else
                datepicker3.Text = "";


            string startdate = ds.Rows[0]["PublishStartDate"].ToString().Trim();
            if (!startdate.Equals(""))
            {
                DateTime d2 = Convert.ToDateTime(startdate);
                datepicker1.Text = (d2.Date).ToString("MM/dd/yyyy");
            }
            else
                datepicker1.Text = "";



            string enddate = ds.Rows[0]["PublishEndDate"].ToString().Trim();
            if (!enddate.Equals(""))
            {
                DateTime d2 = Convert.ToDateTime(enddate);
                datepicker2.Text = (d2.Date).ToString("MM/dd/yyyy");
            }
            else
                datepicker2.Text = "";


            string c = ds.Rows[0]["count_ToRegister"].ToString();
            dropcount.Items.FindByText(ds.Rows[0]["count_ToRegister"].ToString()).Selected =true;

            string description = ds.Rows[0]["CourseDescription"].ToString().Trim();
            txtdescription.Text = description;
            txtENdescription.Text = ds.Rows[0]["EnCourseDescription"].ToString().Trim();
            txtloc.Text = ds.Rows[0]["EventLocation"].ToString().Trim();
           
            hdfile.Value = ds.Rows[0]["ImageName"].ToString().Trim();
            if (!string.IsNullOrEmpty(hdfile.Value))
            {
                imageUpload_a.Visible = true;

                imageUpload_a.HRef = "../webImage/" + hdfile.Value;
            }
            txtcourseloc.Text = ds.Rows[0]["Location"].ToString().Trim();         

        }
        
    }

  
    
    protected void lnkprint_Click(object sender, EventArgs e)
    {
        DataTable dt = loaddata();
        if (dt.Rows.Count > 0)
        {
            RemoveReOrderColumns(dt);
            Session["printDt"] = dt;
            Response.Redirect("ListPrintGeneral.aspx", false);
        }
        
    }
    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("ID");
        dt.Columns.Remove("Event_Id");
        dt.Columns.Remove("trash");
        dt.Columns.Remove("status");
        dt.Columns.Remove("type");
        dt.Columns.Remove("Updated_Date");
        dt.Columns.Remove("count_ToRegister");

        dt.Columns.Remove("PublishStartDate");
        dt.Columns.Remove("PublishEndDate");


        dt.Columns.Remove("Longitude");
        dt.Columns.Remove("Latitude");
        dt.Columns.Remove("ImageName");
        dt.Columns.Remove("StartAge");
        dt.Columns.Remove("EndAge");
      


        
      

    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        if (prevPage != null)
            Response.Redirect(prevPage);
    }



    protected void radioage3_CheckedChanged(object sender, EventArgs e)
    {
        if (radioage3.Checked == true)
        {
            panelage.Visible = true;
           
            txtage.Enabled = true;
            txtageto.Enabled = true;
        }
        else
        {
            panelage.Visible = false;
            txtage.Enabled = false;
            txtageto.Enabled = false;
            
            txtage.Text = string.Empty;
            txtageto.Text = string.Empty;
        }
    }

    protected void radiotime3_CheckedChanged(object sender, EventArgs e)
    {
        if (radiotime3.Checked)
        {
            paneltime.Visible = true;
        }
        else
        {
            paneltime.Visible = false;
            texttime.Text = "";
            textendtime.Text = "";

        }
    }
    protected void SendEmail(string[] EmailBody)
    {


        //if (ddl_Type.SelectedIndex == 1)
        //{

        //    AnnouncementGeneral(EmailBody);

        //}
        //else if (ddl_Type.SelectedIndex == 2)
        //{
        //    AnnouncementByCategory(EmailBody);

        //}
    }



    
    //public void AnnouncementByCategory(string[] EmailBody)
    //{
    //    string Categorylist = ViewState["CategoryList"].ToString();
    //    string[] Type = Regex.Split(Categorylist, ",");
    //    foreach (string Category in Type)
    //    {

    //        cnn.ConnectionString = gm.ConnectionString();
    //        cnn.Open();
    //        cmd.Connection = cnn;
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "Jazha_add_Announcement";
    //        cmd.Parameters.Clear();
    //        cmd.Parameters.AddWithValue("@TransID", SqlDbType.NVarChar).Value = "102";
    //        cmd.Parameters.AddWithValue("@type", Category);
    //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        sda.Fill(dt);
    //        cnn.Close();
    //        string Body = PopulateBody(EmailBody);
    //        foreach (DataRow dr in dt.Rows)
    //        {

    //            string email = dr["email"].ToString();
    //            if (!email.Equals("") && IsValidEmailId(email))
    //                Obj_GenMethods.GeneralEmail(email, Body);

    //        }
    //        cnn.Close();
    //    }
    //}
    //protected void AnnouncementGeneral(string[] EmailBody)
    //{
    //    cnn.ConnectionString = Obj_Gen.ConnectionString();
    //    cnn.Open();
    //    cmd.Connection = cnn;
    //    cmd.Parameters.Clear();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "Jahaz_add_Announcement";
    //    cmd.Parameters.AddWithValue("@TransID", SqlDbType.NVarChar).Value = "101";
    //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    sda.Fill(dt);
    //    string Body = PopulateBody(EmailBody);
    //    cnn.Close();
    //    GridView DummyGridview = new GridView();
    //    DummyGridview.DataSource = dt;
    //    DummyGridview.DataBind();
    //    List<GridViewRow> list = new List<GridViewRow>();
    //    foreach (GridViewRow row in DummyGridview.Rows)
    //    {
    //        list.Add(row);

    //    }

    //    Parallel.ForEach(list, row =>
    //    {

    //        String email = row.Cells[0].Text.Trim();

    //        if (!email.Equals("") && IsValidEmailId(email))
    //        {
    //            Obj_GenMethods.GeneralEmail(email, Body);

    //        }
    //    });
    //    cnn.Close();
    //}

    //public static bool IsValidEmailId(string InputEmail)
    //{
    //    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    //    Match match = regex.Match(InputEmail);
    //    if (match.Success)
    //        return true;
    //    else
    //        return false;
    //}



    //private string PopulateBody(string[] item)
    //{
    //    string body = string.Empty;
    //    string p1 = "", p2 = "", p3 = "";
    //    using (StreamReader reader = new StreamReader(Server.MapPath("emailGeneral.html")))
    //    {
    //        body = reader.ReadToEnd();
    //    }
    //    p1 = "<table border='0' cellspacing='10' cellpadding='10' width='100%'>" +
    //    " <tr><td colspan='2'><center> <strong>تعلن إدارة العمل التطوعي عن الفرصة التطوعية </center></strong></td></tr>" +
    //    " <tr><td colspan='2'><center> <strong>" + item[0] + "</strong></center></td></tr>" +
    //      "<tr><td><b>نص الاعلان</b> </td><td>: <strong>" + item[6] + "</strong></td></tr>" +
    //        "<tr><td><b>الوقت</b> </td><td style='direction:rtl'>: <strong>" + item[7] + "</strong></td></tr>" +
    //    "<tr><td><b>تاريخ بدء الفعالية</b> </td><td>: <strong>" + item[1] + "</strong></td></tr>" +
    //    "<tr><td><b>تاريخ نهاية الفعالية</b> </td><td> :<strong>" + item[2] + "</strong></td></tr>" +
    //    "<tr><td><b>المكان</b>   </td><td>: <strong>" + item[3] + "</strong></td></tr>";
    //    if (item[4] != "")
    //    {
    //        p2 = "<tr><td><b>الشروط</b> </td><td> :<strong> " + item[4] + "</strong></td></tr> ";
    //    }
    //    p3 = "<tr><td colspan='2'>  <center> <strong>" + "<a href=" + item[5] + ">" + "<b>للتسجيل يرجى الدخول على الرابط التالي</b> </a>" + "</center></td></tr>" +
    //    " </table>";
    //    string textBody = p1 + p2 + p3;
    //    body = body.Replace("{work}", textBody);
    //    return body;


    //}
}
