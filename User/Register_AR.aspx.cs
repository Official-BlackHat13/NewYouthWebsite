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
using System.Security.Cryptography;

public partial class User_Register_AR : System.Web.UI.Page
{
    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    string a_id = string.Empty;
    string page = string.Empty;
    string t_id = string.Empty;
    public static int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        a_id = Request.QueryString["a_id"];
        page = Request.QueryString["page"];
        t_id = Request.QueryString["ID"];

        if (Session["userid"] != null)
        {
            Response.Redirect("user_Profile.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Validate("personalInfo");
        if (Page.IsValid)
        {

         
            cnn.ConnectionString = gm.ConnectionString();
            string civilpath = string.Empty;
            cnn.Open();
           

            SqlCommand Command = new SqlCommand("uesrRegister", cnn);
            Command.CommandType = CommandType.StoredProcedure;

            string dob = datepicker.Text;

            DateTime date = DateTime.Now;
            string phone = toEnglishNumber(txtContactNo.Text);
            string civil = toEnglishNumber(txtCivil.Text);

            if (fbCiviID.HasFile)
            {
                civilpath = @"Civil\" + civil + "-" + "Civil-ID" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());
            }
            general_fn gfn = new general_fn();
            string ePass = gfn.ComputeHash(Server.HtmlEncode(txtPassword.Text.Trim()), Server.HtmlEncode(txtEmail.Text), "SHA512", null);
            string time = date.ToString("yyyyMMddHHmmss");
            Command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtName.Text);
            Command.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = Server.HtmlEncode(civil);
            Command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text);
            Command.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = Server.HtmlEncode(phone);
            Command.Parameters.AddWithValue("@dob", SqlDbType.Date).Value = dob;
            Command.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = ePass;
            Command.Parameters.AddWithValue("@image_name", SqlDbType.NVarChar).Value = civilpath;  
            Command.Parameters.AddWithValue("@gender", SqlDbType.NVarChar).Value = gender.SelectedValue;
            Command.Parameters.AddWithValue("@imgQR", SqlDbType.NVarChar).Value = "qr" + time + ".jpeg";


            Command.Parameters.Add("@Mname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtMname.Text);
            Command.Parameters.AddWithValue("@Tname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTname.Text);
            Command.Parameters.Add("@Lname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtLname.Text);

            var returnParameter = Command.Parameters.Add("@ERROR", SqlDbType.NVarChar);
            returnParameter.Direction = ParameterDirection.Output;
            returnParameter.Size = 100;

            if (cnt != 1)
            {
                Command.ExecuteNonQuery();

                string message = (string)Command.Parameters["@ERROR"].Value;
                if (message.Equals("1"))
                {
                    alertEmail.Visible = true;
                    alertCivil.Visible = true;
                }
                else if (message.Equals("2"))
                {
                    alertCivil.Visible = true;
                    alertEmail.Visible = false;

                }
                else if (message.Equals("3"))
                {
                    alertEmail.Visible = true;
                    alertCivil.Visible = false;
                }
                else
                {
                    if (fbCiviID.HasFile)
                    {
                        fbCiviID.PostedFile.SaveAs(Server.MapPath(civilpath));
                    }
                    string code = "civil:" + civil + "email:" + Server.HtmlEncode(txtEmail.Text) + "phone:" + phone;
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:imgQR/png;base64," + Convert.ToBase64String(byteImage);/// ----for displaying
                        }


                        bitMap.Save(Server.MapPath("~/User/imgQR/") + @"\qr" + time + ".jpeg");
                    }
                    string ID = message;
                    string email = txtEmail.Text.Trim();
                    string EncID = email + "&" + ID;
                    Session["userid"] = gfn.SessionEncrypt(EncID, SHA512.Create().ToString());
                    cnn.Close();

                    if (page == "V")
                    {
                        Response.Redirect("../Volunteer/thankyou.aspx", false);


                    }
                    else if (Session["page"] == "AWS_Info")
                    {
                        Response.Redirect("../AWS/Registration.aspx", false);
                    }
                    else if (Session["page"] == "organization_page")
                    {
                        Response.Redirect("../ini_Form/Initiative_StudentOrganization.aspx", false);
                    }
                    else if (Session["page"] == "ini-Banner")
                    {
                        Response.Redirect("../ini_Form/initiativeForm_FromBanner.aspx", false);
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
                           
                    else if (Session["page"] == "re_page")
                            {
                                Response.Redirect("../ini_Form/InitiativeAchievements.aspx", false);
                            }
                    else if (Session["moy_initiative"] == "moy_ini")
                    {
                        Response.Redirect("../initiative/Initiative_Form.aspx", false);
                    }
                    else if (Session["page"] == "RAcademy_page")
                    {
                        Response.Redirect("../RAcademy/Register_AR.aspx", false);
                    }
                    else if (Session["page"] == "ini_page")
                    {
                        Response.Redirect("../ini_Form/InitiativeTerms.aspx", false);
                    }
                    else if (Session["moy_youth_agency"] == "youth_agency")
                    {
                        Response.Redirect("../zqvkghmqut/YouthAgency/thankyou.aspx", false);
                    }
                    else if (Session["page"] == "YPI_page")
                    {
                        Response.Redirect("../YPI/InitiativeForm.aspx", false);
                    }
                    else if (Session["page"] == "urm")
                    {
                        Response.Redirect("~/Reward/user_Profile_More.aspx", false);
                    }
                    else if (Session["page"] == "urmRD")
                    {
                        Response.Redirect("../RewardReg.aspx", false);
                    }
                    else if (Session["page"] == "ini_page")
                    {
                        Response.Redirect("../ini_Form/initiativeForm.aspx", false);
                    }
                    else if (Session["page"] == "Training_page")
                    {
                        Response.Redirect("../Training/TrainingTerms.aspx", false);
                    }
                    else if (Session["page"] == "yc_Award")
                    {
                        Response.Redirect("../YCA/Award_AR.aspx", false);
                    }
                    else if (Session["page"] == "FMC_Info")
                    {
                        Response.Redirect("../FMC3/Registration.aspx", false);
                    }
                    else if (Session["page"] == "Eng-women")
                    {
                        Response.Redirect("../EngWomen/Registration.aspx", false);
                    }        
                    else if (page == "T")
                    {

                        var url = String.Format("../Training/Training_Registration.aspx?id={0}", t_id);
                        Response.Redirect(url, false);
                    }
                     else if (page == "I")
                            {
                                Response.Redirect("../initiative/Initiative_Form.aspx", false);
                            }
                    else if (page == "J")
                    {

                        Response.Redirect("../Volunteer/Join.aspx", false);
                    }
                    else
                    {

                        Response.Redirect("user_Profile.aspx", false);
                    }
                }
            }
            else
            {
                datepicker.Text = string.Empty;
                cnt = 0;

            }

        }

    }

    protected void txtCivil_TextChanged(object sender, EventArgs e)
    {
        
        cnt = 0;
        lblCivil.Visible = false;


        string civil_id = Server.HtmlEncode(txtCivil.Text);

        if (civil_id != string.Empty && (civil_id.Length == 12))
        {

            string civil = txtCivil.Text.ToString();


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
                txtCivil.Text = civil;
                general_fn gfn = new general_fn();
                string dob = gfn.DobFromCivil(civil_id);
                string[] Arrdob = dob.Split('~');

                cnt = Convert.ToInt16(Arrdob[0]);
                if (cnt == 1)
                {
                    lblCivil.Visible = true;

                }
                else
                {
                    dob = Arrdob[1];
                    datepicker.Text = dob;

                }

            }
            else
            {
                txtCivil.Text = "";
                lblCivil.Visible = true;
            }

            

        }
        else
        {

            RegularExpressionValidator1.Validate();

        }

    }


    private string toEnglishNumber(string input)
    {
        string EnglishNumbers = "";


        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                EnglishNumbers += char.GetNumericValue(input, i);

            }
            else
            {
                EnglishNumbers += input[i].ToString();
            }

        }
        return EnglishNumbers;
    }
  
}