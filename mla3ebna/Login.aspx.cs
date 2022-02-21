using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserUID"] != null && Session["UserGender"] != null)
            {
                Response.Redirect("UserProfile.aspx");
            }
        }
    }
    public void Get_User_Login(string username, string password)
    {
        string GstrDbKey = "MalebnaDB";
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        JavaScriptSerializer js = new JavaScriptSerializer();
        MGeneral clsGeneral = new MGeneral();
        string ls_civilid = "";
        string ls_Epwd = "";
        string ls_email = "";
        divmodalmsg.Visible = false;
        divmodalmsg.InnerHtml = "";
        try
        {
            if (clsGeneral.GetQueryValue("select UserType from MYA_Maleabna_Members where username='" + username + "' and pwd=''", GstrDbKey).Equals("Old"))
            {
                dt = clsGeneral.msgResponse("", "True", "Old User", 0);

                divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> Kindly, Reset your Password!!! </strong>  </div>"; 
                divmodalmsg.Visible = true;
            }
            else
            {

                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where username=N'" + username + "'", GstrDbKey).Equals("0"))
                {

                    ls_email = clsGeneral.GetQueryValue("select email from MYA_Maleabna_Members where  username=N'" + username + "'", GstrDbKey);
                    ls_civilid = clsGeneral.GetQueryValue("select civilid from MYA_Maleabna_Members where  username=N'" + username + "'", GstrDbKey);
                    ls_Epwd = clsGeneral.GetQueryValue("select pwd from MYA_Maleabna_Members where  username=N'" + username + "'", GstrDbKey);
                    bool flag = false;
                    flag = clsGeneral.VerifyHash(password.Trim(), ls_civilid, "SHA512", ls_Epwd);
                    if (flag == false)
                    {
                        flag = clsGeneral.VerifyHash(password.Trim(), ls_email, "SHA512", ls_Epwd);
                    }

                    if (flag == true)
                    {
                        DS = clsGeneral.GetDS("EXEC	SP_Get_User_Login N'" + username + "',N'" + ls_Epwd + "'", GstrDbKey, "Table", true);

                        if (DS.Tables[0].Rows.Count == 0)
                        {
                           //lblError.Text = "Login Failed";
                            divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> UserName not Exists, Kindly Register!!! </strong>  </div>";
                            divmodalmsg.Visible = true;
                        }

                        else
                        {
                            string ls_smsstats = "";
                            string ls_profilestatus = "";
                            ls_smsstats = clsGeneral.GetQueryValue("select cast(smsstatus as char(1)) as smsstatus from MYA_Maleabna_Members where username=N'" + username + "'", GstrDbKey);
                            ls_profilestatus = clsGeneral.GetQueryValue("select ProfileStatus from MYA_Maleabna_Members where username=N'" + username + "'", GstrDbKey);
                            if (ls_smsstats.Equals("False"))
                            {
                                lblError.Text = "SMS Not Validated";

                            }
                            else
                            {
                                Session["UserUID"] = DS.Tables[0].Rows[0]["UserUID"].ToString();
                                Session["UserGender"] = DS.Tables[0].Rows[0]["gender"].ToString().Trim();
                                Session["UserName"] = DS.Tables[0].Rows[0]["UserName"].ToString().Trim();
                                if (Session["page"] == "booking")
                                    Response.Redirect("Booking-Knet.aspx", false);
                                else
                                    Response.Redirect("UserProfile.aspx", false);
                            }
                            //else if (ls_profilestatus.Equals("False"))
                            //{
                            //   // dt = clsGeneral.msgResponse("", DS.Tables[0].Rows[0]["UserUID"].ToString(), "Profile Not Updated", 0);
                            //    Session["UserUID"] = DS.Tables[0].Rows[0]["UserUID"].ToString();
                            //    Session["UserGender"] = DS.Tables[0].Rows[0]["gender"].ToString();
                            //    Response.Redirect("ProfileUpdate.aspx", true);
                            //}
                            //else
                            //{
                            //    Session["UserUID"] = DS.Tables[0].Rows[0]["UserUID"].ToString();
                            //    Session["UserGender"] = DS.Tables[0].Rows[0]["gender"].ToString().Trim();
                            //    if (Session["page"] == "booking")
                            //        Response.Redirect("SearchStadiumResult.aspx", false);
                            //    else
                            //        Response.Redirect("UserProfile.aspx", false);
                            //}
                        }

                    }
                    else
                    {
                       // lblError.Text = "Login Failed";
                        divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> Password is Wrong!!! </strong>  </div>";
                        divmodalmsg.Visible = true;
                      
                    }
                }
                else
                {
                   // lblError.Text = "Login Failed";
                    divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> UserName not Exists, Kindly Register!!! </strong>  </div>";
                    divmodalmsg.Visible = true;
                   
                }
            }

          //  Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
        }
        catch (Exception ex)
        {
          //  Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
        }
        finally
        {

        }

    }


    protected void btnUserLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            if ((!txtusername.Text.Equals("")) && (!txtpwd.Text.Equals("")))
            {

                Get_User_Login(txtusername.Text, txtpwd.Text);
            }
                     
        }
        catch (IndexOutOfRangeException ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);

        }

    }
}