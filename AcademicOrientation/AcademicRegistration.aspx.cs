using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

public partial class AcademicOrientation_AcademicRegistration : System.Web.UI.Page
{
    General gm = new General();
    general_fn gfn = new general_fn();
    fn_General fn = new fn_General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (CheckMaxCount())
            {
                
                FillGovernorate();
                FillArea();
              //  FillBookings();

                btnSubmit.Visible = true;
            }
            else
            {
                DivCountalert.Visible = true;
                btnSubmit.Visible = false;
            }
           
        }
    }

    protected bool CheckMaxCount()
    {
        DataTable dt = fn.GetDataTable("exec SP_CheckAcademicOrientationCount ");
        string res = dt.Rows[0]["todaycount"].ToString();

        if (res.Equals("0"))
            return false;
        else
            return true;

    }

    protected void FillGovernorate()
    {
        ddlGov.Items.Clear();
        int govid=0;
        DataTable dt = fn.GetDataTable("exec SP_Get_MYA_Youth_Governorate '" + govid+ "'");
        
        if (dt.Rows.Count > 0)
        {
            ddlGov.DataSource = dt;
            ddlGov.DataTextField = "GovernorateName";
            ddlGov.DataValueField = "GovernorateID";
            ddlGov.DataBind();
        }
        ddlGov.Items.Insert(0, new ListItem("--Select--", "0"));

    }


    protected void FillArea()
    {

        DataTable dt = fn.GetDataTable("exec SP_Get_MYA_Youth_Area ");
        if (dt.Rows.Count > 0)
        {
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaID";
            ddlArea.DataBind();
        }

        ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void FillBookings()
    {

        //DataTable dt = fn.GetDataTable("exec SP_Get_BookingTime ");
        //if (dt.Rows.Count > 0)
        //{
        //    ddlBookings.DataSource = dt;
        //    ddlBookings.DataTextField = "Time";
        //    ddlBookings.DataValueField = "ID";
        //    ddlBookings.DataBind();
        //}

        //ddlBookings.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblAchievements.Text = "";
        lblalert.Text = "";
        alertEmail.Visible = false;
        string val = radioAchievements.SelectedValue;
        Page.Validate("academic");
        if (Page.IsValid)
        {
            if (radioAchievements.SelectedValue == "0" || radioAchievements.SelectedValue == "1")
            {


                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();
                cnn.Open();
                string query = "SP_AcademicOrientationReg";
                SqlCommand cmd = new SqlCommand(query, cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cmd.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = txtfname.Text;
                    cmd.Parameters.AddWithValue("@mname", SqlDbType.NVarChar).Value = txtmname.Text;
                    cmd.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = txtlname.Text;
                    cmd.Parameters.AddWithValue("@gender", SqlDbType.NVarChar).Value = ddlGender.SelectedItem.Text.Trim();
                    cmd.Parameters.AddWithValue("@Dob", SqlDbType.NVarChar).Value = txtdob.Text;
                    cmd.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = txtcivil.Text;
                    cmd.Parameters.AddWithValue("@nationality", SqlDbType.NVarChar).Value = drpNationality.SelectedValue;
                    cmd.Parameters.AddWithValue("@telephone", SqlDbType.NVarChar).Value = txttelephone.Text;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtemail.Text;
                    cmd.Parameters.AddWithValue("@GovernorateID", SqlDbType.NVarChar).Value = ddlGov.SelectedValue;
                    cmd.Parameters.AddWithValue("@AreaID", SqlDbType.NVarChar).Value = ddlArea.SelectedValue;
                    //cmd.Parameters.AddWithValue("@BookingID", SqlDbType.NVarChar).Value = ddlBookings.SelectedValue;
                    cmd.Parameters.AddWithValue("@BookingDate", SqlDbType.NVarChar).Value = txtDate.Text.Trim();

                    cmd.Parameters.AddWithValue("@gpa", SqlDbType.NVarChar).Value = txtGPA.Text.Trim();
                    cmd.Parameters.AddWithValue("@anyachieve", SqlDbType.Bit).Value = radioAchievements.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@achieve", SqlDbType.NVarChar).Value = txtAchievements.Text.Trim();
                    cmd.Parameters.AddWithValue("@skills", SqlDbType.NVarChar).Value = txtSkills.Text.Trim();
                    cmd.Parameters.AddWithValue("@more", SqlDbType.NVarChar).Value = txtMore.Text.Trim();

                    cmd.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = ddlHighYear.SelectedItem.Text.Trim();
                    cmd.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtschool.Text.Trim());
                    cmd.Parameters.AddWithValue("@IELTS", SqlDbType.Bit).Value = rblIELTS.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@IELTSScore", SqlDbType.NVarChar).Value = txtscore.Text.Trim();

                    cmd.Parameters.Add("@result", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["@result"].Value.ToString();
                    if (result.Equals("0"))
                    {
                        sms(txttelephone.Text.Trim());

                        Response.Redirect("thankyou.aspx", false);
                    }
                    else
                    {
                        alertEmail.Visible = true;
                        if (result.Equals("1"))
                            lblalert.Text = "CivilId Already Exists";
                        else if (result.Equals("2"))
                            lblalert.Text = "Email Already Exists";
                        else
                            lblalert.Text = "Something Went Wrong.... Try Again!!!!";
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            else
                lblAchievements.Text = "مطلوب هذه الخانة";
        }
    }

    protected void txtcivil_TextChanged(object sender, EventArgs e)
    {
        alertEmail.Visible = false;
        lblalert.Text = "";


        txtdob.Text = null;
        if (!String.IsNullOrEmpty(txtcivil.Text))
        {
            if (txtcivil.Text.Length == 12)
            {

                string civil = string.Empty;

                civil = gfn.Civil_Check(txtcivil.Text.ToString());

                if (!string.IsNullOrEmpty(civil))
                {
                    string res = gfn.DobFromCivil(civil);
                    string[] arr = res.Split(new char[] { '~' });

                    if (arr[0] != "1")
                    {
                        txtdob.Text = arr[1];
                    }
                    else
                    {
                        txtdob.Text = null;
                        txtcivil.Text = null;
                        lblalert.Text = "Enter Valid CivilID";
                        alertEmail.Visible = true;
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Enter Valid CivilID!!!!!');</script>", false);
                    }
                    //string dob = gfn.DobFromCivil(txtcivil.Text);
                    //string[] Arrdob = dob.Split('~');
                    //string arrTxdob = Arrdob[1];
                    //string[] chgFrt = arrTxdob.Split('/');
                    //string TxtDob = chgFrt[1] + '/' + chgFrt[2] + '/' + chgFrt[0];
                    //txtdob.Text = TxtDob;

                }
                else
                {
                    txtcivil.Text = null;
                    lblalert.Text = "Enter Valid CivilID";
                    alertEmail.Visible = true;
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Enter Valid CivilId!!!!!');</script>", false);
                }
            }
        }


    }
    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        int govid = int.Parse(ddlGov.SelectedValue);
        DataTable dt = fn.GetDataTable("exec SP_Get_MYA_Youth_Governorate '" + govid +"'");

         

        if (dt.Rows.Count > 0)
        {
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaID";
            ddlArea.DataBind();
        }

        ddlArea.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    public void sms(string ph)
    {
        string mobile = ph;

        int i = mobile.Length;
        if (!mobile.Equals("") && mobile.Length == 8)
        {
            string senderusername = "Youthkuwait";
            string senderpassword = "you.1234";
            string sender_id = "57";
            mobile = "965" + mobile;

            string message = "تم تسجيلك في مركز الإرشاد الاكاديمي بنجاح ، سيتم التواصل معكم من قبل فريق التنسيق والمتابعة - الهيئة العامة للشباب ";
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



    protected void radioAchievements_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioAchievements.SelectedValue == "0")
        {
            //visible false
            DivAchievements.Visible = false;
            txtAchievements.Text = "";
        }
        else
        {
            DivAchievements.Visible = true;
            //visible true
        }        
    }


    protected void rblIELTS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblIELTS.SelectedValue == "0")
        {
            //visible false
            DivScore.Visible = false;
            txtscore.Text = "";
        }
        else
        {
            DivScore.Visible = true;
            //visible true
        }     
    }
}