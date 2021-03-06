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
using System.Net;

public partial class RegisterForm : System.Web.UI.Page
{
    general_fn gfn = new general_fn();
    General Obj_Gen = new General();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public static int cnt = 0;
    string imagetime = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {      

        if (!IsPostBack)
        {
            LoadGovernorate();
            LoadCategory();


        }
       

    }
    private void LoadGovernorate()
    {
        DataTable dt = GetData("YCLgetGovAndArea", 0, "100");
        if (dt.Rows.Count > 0)
        {
            DDlGovernarate.DataSource = dt;
            DDlGovernarate.DataTextField = "GovName";
            DDlGovernarate.DataValueField = "Id";
            DDlGovernarate.DataBind();
            DDlGovernarate.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
    }
    private void LoadCategory()
    {
        DataTable dt = GetData("YCLgetGovAndArea", 0, "101");
        if (dt.Rows.Count > 0)
        {
            DDLCatagory.DataSource = dt;
            DDLCatagory.DataTextField = "Category";
            DDLCatagory.DataValueField = "CategoryId";
            DDLCatagory.DataBind();
            DDLCatagory.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
    }
    private void LoadAreaByGovID()
    {
        int govid = Convert.ToInt32(DDlGovernarate.SelectedItem.Value);
        DataTable dt = GetData("YCLgetGovAndArea", govid, "100");
        if (dt.Rows.Count > 0)
        {
            DDLArea.Enabled = true;
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "id";
            DDLArea.DataBind();
        }
        else
        {
            DDLArea.ClearSelection();
            DDLArea.Items.Clear();
            DDLArea.Enabled = false;
        }
        DDLArea.Items.Insert(0, new ListItem("--اختر--", "0"));
    }
    public DataTable GetData(string Command, int Parameter, string TransId)
    {
     
        con.ConnectionString = Obj_Gen.ConnectionString();
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = Command;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@transid", TransId);
        if (Parameter != 0)
        {
            cmd.Parameters.AddWithValue("@govid", Parameter);
        }
        else { DDLArea.Items.Insert(0, new ListItem("--اختر--", "0")); };
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;

    }
    private void LoadLevel()
    {

        if (!HdAge.Value.Equals(""))
        {
            rqdContactnumber.Enabled = false;
            rqdEmail.Enabled = false;
            int ageval = int.Parse(HdAge.Value);
            lblLevelIssue.Visible = false;
            DDLlevl.Visible = true;
            DDLlevl.ClearSelection();           
            if (ageval >= 7 && ageval <= 10)
            {
                rqdContactnumber.Enabled = true;
                rqdEmail.Enabled = true;
                DDLlevl.Items.FindByValue("1").Selected = true;
                DDLCatagory.Items.Remove(DDLCatagory.Items.FindByValue("1"));
                DDLCatagory.Items.Remove(DDLCatagory.Items.FindByValue("2"));

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
            }
            else if (ageval >= 11 && ageval <= 14)
            {
                rqdContactnumber.Enabled = true;
                rqdEmail.Enabled = true;
                DDLlevl.Items.FindByValue("2").Selected = true;
             
             
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
            }
            else if (ageval >= 15 && ageval < 18)
            {
               
                DDLlevl.Items.FindByValue("3").Selected = true;
               // DDLCatagory.Items.Remove(DDLCatagory.Items.FindByValue("5"));

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
            }
            else
            {
                DDLlevl.Visible = false;
                lblLevelIssue.Visible = true;
                lblCivil.Text = "";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'none';", true);
                

            }
        }
    }

    protected void model()
    {
        QuestionModel.Style.Add("display", "block");
        FormFade.Style.Add("display", "block");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        Validate("personalInfo");
        if (Page.IsValid)
        {


            con.ConnectionString = Obj_Gen.ConnectionString();
            
            con.Open();


            SqlCommand Command = new SqlCommand("YCLCRegister", con);
            Command.CommandType = CommandType.StoredProcedure;

            string dob = datepicker.Text;

            DateTime date = DateTime.Now;
            string phone = toEnglishNumber(txtContactNo.Text);
            string civil = toEnglishNumber(txtCivil.Text);
            string savePath = string.Empty;
            string filepath = string.Empty;
            imagetime = DateTime.Now.ToString("yyyyMMddHHmmss");

           HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    lblfileerror.Visible = false;
                    hdfile.Value = civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());

                    filepath = civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());
                    savePath = @"Civil\" + civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());
                    fbCiviID.PostedFile.SaveAs(Server.MapPath(savePath));


                    general_fn gfn = new general_fn();
                    hdpwd.Value = gfn.ComputeHash(Server.HtmlEncode(txtPassword.Text.Trim()), Server.HtmlEncode(txtEmail.Text), "SHA512", null);
                    string time = date.ToString("yyyyMMddHHmmss");

                    //User Data

                    Command.Parameters.AddWithValue("@Username", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtName.Text);
                    Command.Parameters.AddWithValue("@UserMname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtMname.Text);
                    Command.Parameters.AddWithValue("@UserTname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTname.Text);
                    Command.Parameters.AddWithValue("@UserLname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtLname.Text);

                    Command.Parameters.AddWithValue("@NameInEnglish", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEnglishName.Text);

                    Command.Parameters.AddWithValue("@Usercivil", SqlDbType.NVarChar).Value = Server.HtmlEncode(civil);
                    Command.Parameters.AddWithValue("@Useremail", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text);
                    Command.Parameters.AddWithValue("@Usermobile", SqlDbType.NVarChar).Value = Server.HtmlEncode(phone);
                    Command.Parameters.AddWithValue("@Userdob", SqlDbType.Date).Value = dob;
                    Command.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = hdpwd.Value;
                    Command.Parameters.AddWithValue("@image_name", SqlDbType.NVarChar).Value = filepath;
                    Command.Parameters.AddWithValue("@Usergender", SqlDbType.NVarChar).Value = gender.SelectedValue;

                    //Parent Data

                    Command.Parameters.AddWithValue("@Parentname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentFirstname.Text);
                    Command.Parameters.AddWithValue("@ParentMname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentSecondname.Text);
                    Command.Parameters.AddWithValue("@ParentTname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentThirdname.Text);
                    Command.Parameters.AddWithValue("@ParentLname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentLastname.Text);
                    Command.Parameters.AddWithValue("@Parentemail", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentEmail.Text);
                    Command.Parameters.AddWithValue("@Parentmobile", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentMobileNo.Text);


                    //other info
                    Command.Parameters.AddWithValue("@Governarate", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDlGovernarate.SelectedValue);
                    Command.Parameters.AddWithValue("@Area", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDLArea.SelectedValue);
                    Command.Parameters.AddWithValue("@Catagory", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDLCatagory.SelectedValue);
                    Command.Parameters.AddWithValue("@SubCatagory", SqlDbType.NVarChar).Value = (pnlSub.Visible == true ? Server.HtmlEncode(DDlSubGroup.SelectedItem.Text) : "");
                    Command.Parameters.AddWithValue("@UserLevel", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDLlevl.SelectedItem.Text);



                    var returnParameter = Command.Parameters.Add("@ERROR", SqlDbType.NVarChar);
                    returnParameter.Direction = ParameterDirection.Output;
                    returnParameter.Size = 100;

                    if (cnt != 1)
                    {
                        Command.ExecuteNonQuery();

                        string message = (string)Command.Parameters["@ERROR"].Value;

                        if (message.Equals("02"))
                        {
                            alertCivil.Visible = true;
                            alertEmail.Visible = false;

                        }

                        else
                        {

                            string code = "دوري الابداع الشبابي" + Environment.NewLine + "الموسم الاول ٢٠٢٠" + Environment.NewLine + " Name:" + txtName.Text + " " + txtMname.Text + " " + txtTname.Text + " " + txtLname.Text + Environment.NewLine + "civil:" + txtCivil.Text + Environment.NewLine + "Competition Name:" + DDLCatagory.SelectedItem.Text + Environment.NewLine + "Level" + DDLlevl.SelectedItem.Text;

                            var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", code, 150, 150);
                            WebResponse response = default(WebResponse);
                            Stream remoteStream = default(Stream);
                            StreamReader readStream = default(StreamReader);
                            WebRequest request = WebRequest.Create(url);
                            response = request.GetResponse();
                            remoteStream = response.GetResponseStream();
                            readStream = new StreamReader(remoteStream);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(remoteStream);
                            img.Save("C:/inetpub/wwwroot/Youth.gov.kw/YCLC/imgQR/" + message + ".png");
                          // img.Save("C:/inetpub/wwwroot/YouthMinistry/YCLC/imgQR/" + message + ".png");
                            response.Close();
                            remoteStream.Close();
                            readStream.Close();



                            string ID = message;
                            Session["yclC_userid"] = ID;
                            con.Close();
                            string userEmail = string.Empty;
                            string parentEmail = string.Empty;
                            if (txtEmail.Text.Equals(""))
                            {
                                userEmail = TxtParentEmail.Text;
                                parentEmail = "";
                            }
                            else
                            {
                                userEmail = txtEmail.Text;
                                parentEmail = TxtParentEmail.Text;
                            }

                            gfn.YCLCompetition(userEmail, parentEmail, ID);
                            sendMailToAdmin();
                            model();

                            con.Close();




                            // Response.Redirect("Thankyou.aspx", false);

                        }
                    }
                    else
                    {
                        datepicker.Text = string.Empty;
                        cnt = 0;

                    }


                }
                else
                {
                    lblfileerror.Visible = true;
                    fbCiviID.Focus();
                                      
                }
            }     
           
            

        }

    }

    protected void txtCivil_TextChanged(object sender, EventArgs e)
    {
        DDlGovernarate.Enabled = true;
        cnt = 0;
        lblCivil.Visible = false;
        string civil_id = Server.HtmlEncode(txtCivil.Text.Trim());

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
                    HdAge.Value = Arrdob[2];
                    bool val = checkcivil();
                    LoadLevel();
                    if (val)
                    {
                        datepicker.Text = dob;
                        DDLCatagory_SelectedIndexChanged(null, null);
                       
                    }
                    else
                    {
                        lblCivil.Visible = true;
                    }
                 
                   
                }

            }
            else
            {
                txtCivil.Text = "";
                lblCivil.Visible = true;
                lblCivil.Text="الرقم المدني غير صحيح";
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
    private bool checkcivil()
    {

        //Boolean val = false;
        //con.ConnectionString = Obj_Gen.ConnectionString();
        //con.Open();
        //SqlCommand cmd = new SqlCommand("YCLCivilIDCheck", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CivilID", SqlDbType.NVarChar).Value = txtCivil.Text;

        //var returnparameter = cmd.Parameters.Add("@ERROR", SqlDbType.NVarChar);
        //returnparameter.Direction = ParameterDirection.Output;
        //returnparameter.Size = 100;
        //cmd.ExecuteNonQuery();
        //string msg = cmd.Parameters["@ERROR"].Value.ToString();

        //if (!msg.Equals("0"))
        //{
        //    lblCivil.Text = "Already Applied ";
        //    Session["yclcUserID"] = msg;
        //    Response.Redirect("Confirmation.aspx");
        //    val = false;
        //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'none';", true);
        //}

        //else
        //{
        //    //  ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
        //    val = true;
        //}
        //return val;

        Boolean val = false;
        con.ConnectionString = Obj_Gen.ConnectionString();
        con.Open();
        SqlCommand cmd = new SqlCommand("YCLCivilIDCheck", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CivilID", SqlDbType.NVarChar).Value = txtCivil.Text;

        var returnparameter = cmd.Parameters.Add("@ERROR", SqlDbType.NVarChar);
        returnparameter.Direction = ParameterDirection.Output;
        returnparameter.Size = 100;
        cmd.ExecuteNonQuery();
        string msg = cmd.Parameters["@ERROR"].Value.ToString();

        if (msg.Equals("1"))
        {
            lblCivil.Text = "Already Applied ";
            val = false;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'none';", true);
        }

        else
        {
            //  ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
            val = true;
        }
        return val;

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
    protected void DDlGovernarate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLArea.Enabled = true;
        DDLCatagory.Enabled = true;
        DDLCatagory.SelectedIndex = 0;
        pnlMessage.Visible = false;
        if (DDlGovernarate.SelectedItem.Value != "0")
        {
            LoadAreaByGovID();
        }
        else
        {
            DDLArea.ClearSelection();
            DDLArea.Items.Clear();
            DDLArea.Items.Insert(0, new ListItem("--اختر--", "0"));
            DDLArea.Enabled = false;
        }
    }

    public string GetQueryValue(string strSQL)
    {
        SqlConnection conGlobal = new SqlConnection();
        conGlobal.ConnectionString = Obj_Gen.ConnectionString();
        conGlobal.Open();         
        DataTable dt = new DataTable();
        string[] a = new string[1];
        string ls_return = "";
        try
        {
            if (conGlobal.State == ConnectionState.Closed)
                conGlobal.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conGlobal);
            SqlDataReader DA = cmd.ExecuteReader();
            while (DA.Read())
                ls_return = DA.GetValue(0).ToString();
            return ls_return;
        }
        catch (Exception ex)
        {
            return ex.Message.Trim();
            conGlobal.Close();
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }

    protected void DDLCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
       // string gov = DDlGovernarate.SelectedValue;
       // int area1 = 0;
      
       // int count = 0;
       // if((gov.Equals("1")) || (gov.Equals("3") )|| (gov.Equals("4")) || (gov.Equals("6")))
       // {
       //     count=20;
       //     area1 = int.Parse(GetQueryValue("select count(*) from YCLCompetition where Catagory=" + DDLCatagory.SelectedItem.Value + " and UserLevel=N'" + DDLlevl.SelectedItem.Text + "' and Governarate in(1,3,4,6)").ToString());
        
       // }
       // else if ((gov.Equals("2")) || (gov.Equals("5")))
       // {
       //     count = 10;
       //     area1 = int.Parse(GetQueryValue("select count(*) from YCLCompetition where Catagory=" + DDLCatagory.SelectedItem.Value + " and UserLevel=N'" + DDLlevl.SelectedItem.Text + "' and Governarate in(2,5)").ToString());
        
       // }
       //// int count =int.Parse( GetQueryValue("select count(*) from YCLCompetition where Catagory=" + DDLCatagory.SelectedItem.Value + " and UserLevel=N'" + DDLlevl.SelectedItem.Text + "'").ToString());


       // if (area1 <= count)
       // {
            //pnlMessage.Visible = false;
            if (DDLCatagory.SelectedItem.Value.Equals("5"))
            {
                pnlSub.Visible = true;
                DDlSubGroup.ClearSelection();
                DDlSubGroup.Items.Clear();
                DDlSubGroup.Items.Insert(0, new ListItem("--اختر--", "0"));
                DDlSubGroup.Items.Insert(1, new ListItem("الرسم", "1"));
                DDlSubGroup.Items.Insert(2, new ListItem("الخزف", "2"));
                int ageval = int.Parse(HdAge.Value);

                if (ageval >= 7 && ageval <= 10)
                {

                    DDlSubGroup.Items.FindByValue("1").Selected = true;

                }
                else if (ageval >= 11 && ageval <= 14)
                {

                    DDlSubGroup.Items.FindByValue("1").Selected = true;


                }
                else if (ageval >= 15 && ageval <= 18)
                {
                    //if ((gov.Equals("2")) || (gov.Equals("5")))
                    //{
                    //    pnlSub.Visible = false;
                    //    DDlSubGroup.ClearSelection();
                    //    DDlSubGroup.Items.Clear();
                    //    pnlMessage.Visible = true;
                    //    DDLCatagory.SelectedIndex = 0;
                    //}
                    //else
                    //{
                        DDlSubGroup.Items.FindByValue("2").Selected = true;
                    //}

                }


            }

            else
            {
                pnlSub.Visible = false;
                DDlSubGroup.ClearSelection();
                DDlSubGroup.Items.Clear();



            }
        //}
        //else
        //{
        //    pnlMessage.Visible = true;
        //    DDLCatagory.SelectedIndex =0;
        //    pnlSub.Visible = false;
        //    DDlSubGroup.ClearSelection();
        //    DDlSubGroup.Items.Clear();
        //}
       
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "نعم")
        {          
            div1.Style.Add("display", "none");
            div2.Style.Add("display", "block");
        }
        else
        {
            Response.Redirect("Thankyou.aspx", false);
        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string usertype = string.Empty;
        if (RadioButtonList2.SelectedItem.Text == "ولي الأمر")
            usertype = "Parent";        
        else
            usertype = "User";

        General gm = new General();
        general_fn gfn = new general_fn();      
        
        

        SqlConnection cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        SqlCommand usercommand = new SqlCommand("competitionUserinfo", cnn);
        usercommand.CommandType = CommandType.StoredProcedure;
    
        usercommand.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = txtName.Text;
        usercommand.Parameters.AddWithValue("@mname", SqlDbType.NVarChar).Value = txtMname.Text;
        usercommand.Parameters.AddWithValue("@tname", SqlDbType.NVarChar).Value = txtTname.Text;
        usercommand.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = txtLname.Text;

        usercommand.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = txtCivil.Text;
        usercommand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = (txtEmail.Text=="" ?TxtParentEmail.Text:txtEmail.Text);
        usercommand.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = txtContactNo.Text;
        usercommand.Parameters.AddWithValue("@gender", SqlDbType.NVarChar).Value = gender.SelectedItem.Text;
        usercommand.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = hdpwd.Value;
        usercommand.Parameters.AddWithValue("@dob", SqlDbType.NVarChar).Value = datepicker.Text;
        usercommand.Parameters.AddWithValue("@image", SqlDbType.NVarChar).Value = @"Civil\" + hdfile.Value;        
        usercommand.Parameters.AddWithValue("@usertype", SqlDbType.NVarChar).Value = usertype;

        var returnParameter = usercommand.Parameters.Add("@ERROR", SqlDbType.NVarChar);
        returnParameter.Direction = ParameterDirection.Output;
        returnParameter.Size = 100;

        cnn.Open();

        usercommand.ExecuteNonQuery();
        string message = (string)usercommand.Parameters["@ERROR"].Value;
        

        string ID = message;
        string email = txtEmail.Text.Trim();
        string EncID = email + "&" + ID;
        HttpContext.Current.Session["userid"] = gfn.SessionEncrypt(EncID, SHA512.Create().ToString());
        cnn.Close();
        cnn.Dispose();     
            

        Response.Redirect("Thankyou.aspx", false);
        
        
    }
    private void sendMailToAdmin()
    {

        MailMessage message = new MailMessage();
        message.From = new MailAddress("web@youth.gov.kw", "دوري الاإبداع الشبابي ");
        message.Bcc.Add(new MailAddress("web@youth.gov.kw"));
        message.To.Add(new MailAddress("admin@youth.gov.kw"));

        message.Subject = "YCLC competition User Info";
        message.CC.Add(new MailAddress("selva@youth.gov.kw"));
        message.CC.Add(new MailAddress("a.bennoune@youth.gov.kw"));
        message.CC.Add(new MailAddress("sijila.p@gmail.com"));
        string text = "<table><tr><td>" + "Basic Information" + "</td></tr>" + "<br><tr><td>" + "Name :" + txtEnglishName.Text + "</td></tr><br><tr><td>" + "CivilId:" + txtCivil.Text + "</td></tr><br><tr><td>" + "Level :" + DDLlevl.SelectedItem.Text + "</td></tr><br><tr><td>" + "Catagory: " + DDLCatagory.SelectedItem.Text + "</td></tr><br><tr><td>" + "Phone :" + txtContactNo.Text + "</td></tr><br><tr><td>" + "Email :" + txtEmail.Text + "</td></tr><br><tr><td>" + "Father Name :" + TxtParentFirstname.Text + "  " + TxtParentLastname.Text + "</td></tr></table>";
        message.Body = text;
        message.IsBodyHtml = true;
        SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

        try
        {
            smtpClient.Send(message);
            smtpClient = null;
            message.Dispose();

        }
        catch (Exception ex)
        {

        }


    }
}