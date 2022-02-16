using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ActivityDetails : System.Web.UI.Page
{
    fn_General fn = new fn_General();
    protected void Page_Load(object sender, EventArgs e)
    {
        fn.checkQueryString(Request.QueryString["ati"].ToString());

        if (Request.QueryString["id"] != null)
            FillNewsDetails();
        else
        {
            Response.Redirect("Index_AR.aspx", false);
        }


       
    }
    protected void FillNewsDetails()
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //string ls = "@id='" + Session["ID"] + "'";
            string ls = "@id='" + id + "'";
            DataSet ds = GetDataDS("exec Sp_GetActivities " + ls);

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    title.InnerText = dt.Rows[0]["ActivityTitleAr"].ToString();
                    Span2.InnerText = dt.Rows[0]["ActivitySummaryAr"].ToString();

                    int ActivitiesRegsCount = Convert.ToInt32(dt.Rows[0]["ActivitiesRegsCount"].ToString());
                    DateTime DateFrom = Convert.ToDateTime(dt.Rows[0]["DateFrom"].ToString());
                    DateTime DateTo = Convert.ToDateTime(dt.Rows[0]["DateTo"].ToString());
                    int ActivityID = Convert.ToInt32(dt.Rows[0]["ActivityID"].ToString());

                    //lblText.Text = dt.Rows[0]["ActivityTextAr"].ToString();
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["ActivityImage"]);
                    newsImage.Src = imageUrl;

                    #region Rcode13
                    if (id != 13)
                    {

                        lbl.Text = dt.Rows[0]["ActivityTextAr"].ToString();
                        winnerpnl.Visible = false;
                    }
                    else if (id == 13)
                    {
                        lbl.Visible = false;
                        regLink.Visible = false;
                        string[] lines = dt.Rows[0]["ActivityTextAr"].ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        A.Text = lines[0];
                        A1.Text = lines[1];
                        A2.Text = lines[2];
                        A3.Text = lines[3];
                        B.Text = lines[4];
                        B1.Text = lines[5];
                        B2.Text = lines[6];
                        B3.Text = lines[7];
                        C.Text = lines[8];
                        C1.Text = lines[9];
                        C2.Text = lines[10];
                        C3.Text = lines[11];
                    }

                    #endregion
                    //date.InnerText = activity.DateFrom.Value.ToString("dd/MM/yyyy");


                   
                    int cnt = 0;
                    if (id == 5)
                    {

                        cnt = Convert.ToInt32(ActivitiesRegsCount);
                    }


                    if ((DateTo < DateTime.Now) || (cnt > 50))
                    {
                        regLink.Attributes.Add("href", "#");
                        regLink.Attributes.Add("class", "btn btn-default");
                        regLink.Disabled = true;
                    }

                    if (id == 6)
                    {
                        regLink.Attributes.Add("href", "Forms/ActivityRegister?ati=" + ActivityID);
                    }
                    else if (id == 7)
                    {
                        regLink.Attributes.Add("href", "academy/index.html");
                    }

                    else if (id == 8)
                    {
                        LoginLink.Visible = true;
                        regLink.Attributes.Add("href", "Forms/ResearchRegister?ati=" + ActivityID);
                        LoginLink.Attributes.Add("href", "Forms/ResearchDetails?ati=" + ActivityID);
                    }
                    else if (id == 9)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 20)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/RegisterYouthValley?ati=" + ActivityID);
                    }

                    else if (id == 10)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 8)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/RegisterYouthValley?ati=" + ActivityID);
                    }


                    else if (id == 11)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 30)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/RegisterYouthValley?ati=" + ActivityID);
                    }

                    else if (id == 12)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 45)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/OnlineCourseReg.aspx?ati=" + ActivityID);
                    }

                    else if (id == 27)
                    {
                        //var Pcount = ctx.ActivitiesRegs.Count(a => a.ActivityID.Value == 12);
                        //cnt = Convert.ToInt32(Pcount);
                        //if (cnt >= 750)
                        //{
                        //    regLink.Attributes.Add("href", "#");
                        //    regLink.Attributes.Add("class", "btn btn-default");
                        //    regLink.Disabled = true;
                        //}
                        //else
                        //LoginLink.Visible = true;

                        //LoginLink.Attributes.Add("onclick", "lnkDownloadDetailas_Click");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date expired...!!!')", true);
                        lnkDownloadDetailas.Visible = true;
                        //regLink.Attributes.Add("onclick", "ActivityDetails.aspx?ati=" + activity.ActivityID);
                        regLink.Attributes.Add("runat", "server");
                        regLink.ServerClick += new EventHandler(this.regLink_Click);



                    }
                    else if (id == 14)
                    {
                        regLink.Attributes.Add("href", "#");
                        regLink.Attributes.Add("class", "btn btn-default");
                        regLink.Disabled = true;
                        LoginLink.Visible = true;
                    }

                    else if (id == 15)
                    {
                        regLink.Visible = false;
                        LoginLink.Visible = false;
                        regSurvey.Visible = true;
                        regSurvey.Attributes.Add("href", "https://docs.google.com/forms/d/e/1FAIpQLScmzV0uaj_HxXzuCnoJ6yhMmneTTSDtW2dGOAR1heyhaL74hA/viewform?usp=sf_link");



                        // Response.Redirect("https://docs.google.com/forms/d/e/1FAIpQLScmzV0uaj_HxXzuCnoJ6yhMmneTTSDtW2dGOAR1heyhaL74hA/viewform?usp=sf_link", false);
                    }
                    else if (id == 16)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 700)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/Heritageyouth.aspx?ati=" + ActivityID);

                    }
                    else if (id == 17)
                    {
                        var Pcount = ActivitiesRegsCount;
                        cnt = Convert.ToInt32(Pcount);
                        if (cnt >= 75)
                        {
                            regLink.Attributes.Add("href", "#");
                            regLink.Attributes.Add("class", "btn btn-default");
                            regLink.Disabled = true;
                        }
                        else
                            regLink.Attributes.Add("href", "Forms/Youngleaders.aspx?ati=" + ActivityID);
                    }

                    else
                    {
                        regLink.Attributes.Add("href", "Forms/Youngleaders.aspx?ati=" + ActivityID);
                    }



                }
                dt = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {

                    pnlPhotoGallery.Visible = dt.Rows.Count > 0;
                    rptNewsPhotoGallery.DataSource = dt;
                    rptNewsPhotoGallery.DataBind();
                    
                }
                else
                {
                    pnlPhotoGallery.Visible = false;
                  //  Response.Redirect("Index_AR.aspx", false);
                }

            }
            else
                Response.Redirect("Index_AR.aspx", false);
            
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    private void regLink_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date Expired')", true);
    }

    public DataSet GetDataDS(string SQLstring)
    {

        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.YPA();
            cnn.Open();

            // SqlCommand cmd = new SqlCommand(SQLstring, cnn);
            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataSet DS = new DataSet();

            SDA.Fill(DS);
            SDA.Dispose();
            return DS;

        }
    }

    protected void Downloadfile(string fname)
    {
        if (fname != string.Empty)
        {
            try
            {
                HttpContext.Current.Response.ContentType = "application/file";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fname);
                Response.Buffer = true;
                HttpContext.Current.Response.TransmitFile(Server.MapPath("~/Winners_YouthValley/" + fname));
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                Response.Flush();
                Response.Clear();
            }
            catch (Exception e)
            {
            }
        }

    }



    protected void lnkA1_Click(object sender, EventArgs e)
    {
        Downloadfile("A1.pdf");
    }


    protected void lnkA2_Click(object sender, EventArgs e)
    {
        Downloadfile("A2.pdf");
    }

    protected void lnkA3_Click(object sender, EventArgs e)
    {
        Downloadfile("A3.pdf");
    }

    protected void lnkB1_Click(object sender, EventArgs e)
    {
        Downloadfile("B1.pdf");
    }

    protected void lnkB2_Click(object sender, EventArgs e)
    {
        Downloadfile("B2.pdf");
    }

    protected void lnkB3_Click(object sender, EventArgs e)
    {
        Downloadfile("B3.pdf");
    }

    protected void lnkC1_Click(object sender, EventArgs e)
    {
        Downloadfile("C1.pdf");
    }

    protected void lnkC2_Click(object sender, EventArgs e)
    {
        Downloadfile("C2.pdf");
    }

    protected void lnkC3_Click(object sender, EventArgs e)
    {
        Downloadfile("C3.pdf");
    }

    protected void lnkDownloadDetailas_Click(object sender, EventArgs e)
    {

        Downloadfile("Huawei_Courses.pdf");

        //string fname = "Huawei_Courses.docx";

        //string filePath = Server.MapPath("~/OnlineCourse/" + fname); // Specify the location of the file
        //using (FileStream fileStream = File.OpenRead(filePath))
        //{
        //    MemoryStream memStream = new MemoryStream();
        //    memStream.SetLength(fileStream.Length);
        //    fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

        //    Response.Clear();
        //    Response.ContentType = "application/vnd.ms-word";
        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + fname);
        //    Response.BinaryWrite(memStream.ToArray());
        //    Response.Flush();
        //    Response.Close();
        //    Response.End();
        //}
    }
}