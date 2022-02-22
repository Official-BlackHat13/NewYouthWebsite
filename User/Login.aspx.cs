using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                Response.Redirect("user_Profile.aspx");
            }
        }
    }


    protected void btnUserLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            if ((!txtEmail.Text.Equals("")) && (!txtPassowrd.Text.Equals("")))
            {
                General gm = new General();
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();

                cnn.Open();
                string EncID = string.Empty;
                SqlCommand comand = new SqlCommand("login", cnn);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text.Replace("'", ""));
                comand.Connection = cnn;
                comand.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter sda = new SqlDataAdapter(comand);
                DataTable result = new DataTable();
                sda.Fill(result);
                if (result.Rows.Count > 0)
                {
                    string UserLogin = string.Empty;
                    Boolean EmailType = false;
                    string emailInput = txtEmail.Text;

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(emailInput);
                    if (match.Success)
                    {

                        if (string.Equals(txtEmail.Text.Trim(), result.Rows[0]["email"].ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                        {

                            EmailType = true;

                        }
                        else
                        {

                            EmailType = false;
                        }

                    }

                    else
                    {

                        EmailType = true;
                    }

                    string page = Request.QueryString["page"];

                    bool flag = false;
                    string password = result.Rows[0]["pwd"].ToString().Trim();
                    general_fn gfn = new general_fn();
                    flag = gfn.VerifyHash(txtPassowrd.Text.Trim(), result.Rows[0]["email"].ToString().Trim(), "SHA512", password);
                    if (flag == false)
                    {

                        flag = gfn.VerifyHash(txtPassowrd.Text.Trim(), result.Rows[0]["civil"].ToString().Trim(), "SHA512", password);
                    }

                    if (EmailType)
                    {


                        if (flag == true)
                        {
                            string id = result.Rows[0]["id"].ToString().Trim();
                            string email = result.Rows[0]["email"].ToString().Trim();
                            //adding email with sessionid 
                            EncID = email + "&" + id;
                            Session["userid"] = gfn.SessionEncrypt(EncID, SHA512.Create().ToString());


                            if (Session["page"] == "urm")
                            {
                                Response.Redirect("~/Reward/reward.aspx", false);
                            }
                            else if (Session["page"] == "ini-Banner")
                            {
                                Response.Redirect("../ini_Form/initiativeForm_FromBanner.aspx", false);
                            }
                            else if (Session["moy_youth_agency"] == "youth_agency")
                            {
                                Response.Redirect("../zqvkghmqut/YouthAgency/thankyou.aspx", false);
                            }
                            else if (Session["page"] == "urmRD")
                            {
                                Response.Redirect("~/RewardReg.aspx", false);
                            }
                            else if (Session["page"] == "Training_page")
                            {
                                Response.Redirect("../Training/TrainingTerms.aspx", false);
                            }
                            else if (Session["page"] == "organization_page")
                            {
                                Response.Redirect("../ini_Form/Initiative_StudentOrganization.aspx", false);
                            }
                            else if (Session["page"] == "re_page")
                            {
                                Response.Redirect("../ini_Form/InitiativeAchievements.aspx", false);
                            }
                            else if (Session["page"] == "StudioPage")
                            {
                                Response.Redirect("../Studio/Register_AR.aspx", false);
                            }

                            else if (Session["page"] == "JobPage")
                            {
                                Response.Redirect("../JOB/Register.aspx", false);
                            }
                            else if (Session["page"] == "Law_Info")
                            {
                                Response.Redirect("../Lawyer/Registration.aspx", false);
                            }
                            else if (Session["page"] == "AWS_Info")
                            {
                                Response.Redirect("../AWS/Registration.aspx", false);
                            }
                            else if (Session["page"] == "iniProfile")
                            {
                                Response.Redirect("../ini_Form/Initiative_UserProfile.aspx", false);
                            }
                            else if (Session["page"] == "YPIProfile")
                            {
                                Response.Redirect("../YPI/Initiative_UserProfile.aspx", false);
                            }
                            else if (Session["page"] == "YPIFeedBack_page")
                            {
                                Response.Redirect("../YPI/YPIfeedback.aspx", false);
                            }
                            else if (Session["page"] == "ini_page")
                            {
                                Response.Redirect("../ini_Form/InitiativeTerms.aspx", false);
                            }
                            else if (Session["page"] == "YPI_page")
                            {
                                Response.Redirect("../YPI/InitiativeForm.aspx", false);
                            }
                            else if (Session["page"] == "confirm")
                            {
                                Response.Redirect("~/Reward/rewardConfirmation.aspx", false);
                            }
                            else if (Session["page"] == "V")
                            {
                                Response.Redirect("../Volunteer/thankyou.aspx", false);
                            }
                            else if (page == "I")
                            {
                                Response.Redirect("../initiative/Initiative_Form.aspx", false);
                            }
                            else if (Session["page"] == "T")
                            {
                                Response.Redirect("../Training/thankyou.aspx", false);
                            }
                            else if (page == "J")
                            {
                                Response.Redirect("../Volunteer/Join.aspx", false);
                            }
                            else if (Session["page"] == "YCL_Profile_page")
                            {
                                Response.Redirect("../YCL/user_Profile.aspx", false);
                            }
                            else if (Session["moy_initiative"] == "moy_ini")
                            {
                                Response.Redirect("../initiative/Initiative_Form.aspx", false);
                            }
                            else if (Session["page"] == "ini_editform")
                            {
                                Response.Redirect("../ini_Form/InitiativeEditForm.aspx", false);
                            }
                            else if (Session["page"] == "YCL_Profile_page")
                            {
                                Response.Redirect("../YCL/user_Profile.aspx", false);
                            }
                            else if (Session["page"] == "YCL_Training_page")
                            {
                                Response.Redirect("../YCL/TraineeForm.aspx", false);
                            }
                            else if (Session["page"] == "RAcademy_page")
                            {
                                Response.Redirect("../RAcademy/Register_AR.aspx", false);
                            }
                            else if (Session["page"] == "Eng-women")
                            {
                                Response.Redirect("../EngWomen/Registration.aspx", false);
                            }
                            else if (Session["page"] == "yc_Award")
                            {
                            }
                            else if (Session["page"] == "FMC_Info")
                            {
                                Response.Redirect("../FMC3/Registration.aspx", false);
                            }

                            else
                            {
                                Response.Redirect("user_Profile.aspx");
                            }


                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);
                    }



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Enter Email and password.');</script>", false);
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);

        }

    }
    protected void btnnewlogin_Click(object sender, EventArgs e)
    {
        general_fn gfn = new general_fn();
        try
        {
            if ((!txtEmail.Text.Equals("")) && (!txtPassowrd.Text.Equals("")))
            {
                General gm = new General();
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();

                cnn.Open();
                string EncID = string.Empty;
                SqlCommand comand = new SqlCommand("NewUserLogin", cnn);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text.Replace("'", ""));
                comand.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtPassowrd.Text.Trim());
                comand.Connection = cnn;
                comand.ExecuteNonQuery();
                cnn.Close();
                SqlDataAdapter sda = new SqlDataAdapter(comand);
                DataTable result = new DataTable();
                sda.Fill(result);
                if (result.Rows.Count > 0)
                {




                    string id = result.Rows[0]["id"].ToString().Trim();
                    string email = result.Rows[0]["email"].ToString().Trim();
                    //adding email with sessionid 
                    EncID = email + "&" + id;
                    Session["userid"] = gfn.SessionEncrypt(EncID, SHA512.Create().ToString());



                    Response.Redirect("user_Profile.aspx");




                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Enter Email /password is wrong....');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Enter Email and password.');</script>", false);
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);

        }
    }
}