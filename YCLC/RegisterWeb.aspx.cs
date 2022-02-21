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


public partial class YCLC_RegisterWeb : System.Web.UI.Page
{
    general_fn gfn = new general_fn();
    General Obj_Gen = new General();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public static int cnt = 0;
    string imagetime = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      
//Response.Redirect("Index.aspx",true);
       
        if (!IsPostBack)
        {
            LoadGovernorate();
            LoadCategory();

            if (Session["yclcJoinType"] != null)
            {
                hiddenJoinType.Value = Session["yclcJoinType"].ToString();
            }

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
            // DDLCatagory.Items.Insert(0, new ListItem("--اختر--", "0"));
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
            DDLCatagory.Enabled = true;
            DDLCatagory.ClearSelection();
            // HideCategory("q");
            //DDLCatagory.Items[5].Attributes.Add("class", "hiddenR");

            int ageval = int.Parse(HdAge.Value);
            lblLevelIssue.Visible = false;
            DDLlevl.Visible = true;
            DDLlevl.ClearSelection();

            if (ageval >= 7 && ageval <= 10)
            {
                DDLlevl.Items.FindByValue("1").Selected = true;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);

                //  HideCategory("R");
                HideCategoryByCount(DDLlevl.SelectedItem.Text.Trim(), ageval);

            }
            else if (ageval >= 11 && ageval <= 14)
            {

                DDLlevl.Items.FindByValue("2").Selected = true;

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'inline';", true);
                // HideCategory("R");
                HideCategoryByCount(DDLlevl.SelectedItem.Text.Trim(), ageval);
            }
            else if (ageval >= 15 && ageval <= 18)
            {

                DDLlevl.Items.FindByValue("3").Selected = true;
                HideCategoryByCount(DDLlevl.SelectedItem.Text.Trim(), ageval);

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


    protected void HideCategory(string s)
    {

        if (s.Equals("R"))
            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "hiddenR");
        else if (s.Equals("q"))
            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "hiddenR");


    }


    protected DataSet GetDebateCount(string level)
    {
        //
        if (con.State == ConnectionState.Open)
            con.Close();

        con.ConnectionString = Obj_Gen.ConnectionString();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetYCLCompetitionCountOfDebate", con);
        cmd.CommandType = CommandType.StoredProcedure;       
        cmd.Parameters.AddWithValue("@level", SqlDbType.NVarChar).Value = level;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cmd.ExecuteNonQuery();
        sda.Fill(ds);
        con.Close();


        return ds;
        
    }



    protected void HideCategoryByCount(string level,int age)
    {

        foreach (ListItem item in DDLCatagory.Items)
        {
            // if (item.Text == "الروبوت" || item.Text == "البرمجة")
            //  {
            if (item.Text != "المناظرات الشبابية")
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.ConnectionString = Obj_Gen.ConnectionString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetYCLCompetitionCountByLevel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@category", SqlDbType.NVarChar).Value = item.Text;
                cmd.Parameters.AddWithValue("@level", SqlDbType.NVarChar).Value = level;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.ExecuteNonQuery();
                sda.Fill(dt);
                con.Close();
                int count = 0;
                if (dt.Rows.Count > 0)
                {
                    count = Convert.ToInt32(dt.Rows[0]["count"].ToString());

                }

                if (item.Text == "الروبوت") //1 
                {
                    #region Robotics
                    if (DDLlevl.SelectedItem.Text == "المبتدئ") //level1,robot
                    {
                       // DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "hiddenR");
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "");
                    }
                    else if (DDLlevl.SelectedItem.Text == "المتوسط") //level1,robot
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "");
                    }
                    else if (level == "المتقدم")   //level3,robotics
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الروبوت").Attributes.Add("class", "");
                    }
                    #endregion

                }
                else if (item.Text == "البرمجة") //2
                {
                    #region Maths
                    if (level == "المبتدئ") //level1,coding(program)
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "");
                    }
                    else if (level == "المتوسط") //level2,coding
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "");
                    }
                    else if (level == "المتقدم")  //level3,coding
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("البرمجة").Attributes.Add("class", "");
                    }
                    #endregion
                }
                else if (item.Text == "الرياضيات") //3
                {
                    #region Maths
                    if (level == "المبتدئ") //level1,maths
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "");
                    }
                    else if (level == "المتوسط") //level2,maths
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "");

                    }
                    else if (level == "المتقدم")  //level3,maths
                    {
                        if (count >= 42)
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الرياضيات").Attributes.Add("class", "");
                    }
                    #endregion
                }
                else if (item.Text == "الثقافة والآداب") //6
                {
                    #region Culture
                    if (level == "المبتدئ") //level1,Culture 
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "");
                    }
                    if (level == "المتوسط") //level2,Culture 
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "");
                    }
                    else if (level == "المتقدم")  //level3,Culture 
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الثقافة والآداب").Attributes.Add("class", "");
                    }
                    #endregion
                }
                else if (item.Text == "القرآن الكريم")  //4
                {
                    #region quran

                    if (level == "المبتدئ") //level1,Quran
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "");
                    }
                    if (level == "المتوسط") //level2,Quran
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "");
                    }
                    else if (level == "المتقدم")  //level3,Quran
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("القرآن الكريم").Attributes.Add("class", "");
                    }
                    #endregion
                }
                else if (item.Text == "الفنون") //5
                {
                    #region paint
                    if (level == "المبتدئ") //level1,painting
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "");
                    }
                    else if (level == "المتوسط") //level2,painting
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "");
                    }
                    else if (level == "المتقدم")  //level3,painting
                    {
                        if (count >= 60)
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "hiddenR");
                        else
                            DDLCatagory.Items.FindByText("الفنون").Attributes.Add("class", "");
                    }
                    #endregion
                }
            }
            else if (item.Text == "المناظرات الشبابية") //7 
            {
                #region Debate

                DataSet ds = GetDebateCount(level);

                int ArabicCount = 0;
                int EngCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArabicCount = int.Parse(ds.Tables[0].Rows[0]["total"].ToString());
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    EngCount = int.Parse(ds.Tables[1].Rows[0]["total"].ToString());
                }

                radioLangauge.Enabled = true;
                if (age > 12) // age above 12 years only are eligible for english Debate
                {
                   
                   
                    if (level == "المبتدئ") //level1,debate
                    {
                        radioLangauge.Items.Clear();
                        if (ArabicCount >= 60)
                        {
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");                               
                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");                               
                                radioLangauge.Items.Insert(0, new ListItem("English", "1"));
                            }
                        }
                        else
                        {
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));                               

                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));
                                radioLangauge.Items.Insert(1, new ListItem("English", "1"));
                            }
                        }

                    }
                    if (level == "المتوسط") //level2,debate
                    {
                        radioLangauge.Items.Clear();
                        if (ArabicCount >= 60)
                        {
                            radioLangauge.Items.Clear();
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");
                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("English", "1"));
                            }
                        }
                        else
                        {
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));

                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));
                                radioLangauge.Items.Insert(1, new ListItem("English", "1"));
                            }
                        }

                    }
                    else if (level == "المتقدم")  //level3,debate
                    {

                        radioLangauge.Items.Clear();
                        if (ArabicCount >= 60)
                        {
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");
                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("English", "1"));
                            }
                        }
                        else
                        {
                            if (EngCount >= 60)
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));

                            }
                            else
                            {
                                DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");
                                radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));
                                radioLangauge.Items.Insert(1, new ListItem("English", "1"));
                            }
                        }

                    }
                }
                else  // unser 12 years
                {
                    radioLangauge.Items.Clear();                    
                    radioLangauge.Items.Insert(0, new ListItem("Arabic", "0"));

                    if (level == "المبتدئ") //level1,debate
                    {

                        if (ArabicCount >= 60)
                        {
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");                           
                        }
                        else
                        {                          
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");                            
                           
                        }

                    }
                    if (level == "المتوسط") //level2,debate
                    {

                        if (ArabicCount >= 60)
                        {
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");
                        }
                        else
                        {
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");

                        }

                    }
                    else if (level == "المتقدم")  //level3,debate
                    {

                        if (ArabicCount >= 60)
                        {
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "hiddenR");
                        }
                        else
                        {
                            DDLCatagory.Items.FindByText("المناظرات الشبابية").Attributes.Add("class", "");

                        }

                    }

                }

                #endregion
            }
           
        }

        // }



    }

    protected bool CheckData()
    {
        if (DDLCatagory.SelectedItem.Text.ToString().Trim() == "المناظرات الشبابية")
        {
            if (!string.IsNullOrEmpty(radioLangauge.SelectedValue.ToString()))
                return true;
            else
                return false;
        }
        else 
            return true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {      

            Validate("personalInfo");
            if (Page.IsValid)
            {
                if (CheckData())
                {

                    IEnumerable<int> category = (from item in DDLCatagory.Items.Cast<ListItem>()
                                                 where item.Selected
                                                 select int.Parse(item.Value));


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
                    //   string Lang = (!string.IsNullOrEmpty(radioLangauge.SelectedItem.Text.ToString().Trim()) ? radioLangauge.SelectedItem.Text.ToString().Trim() : "");

                    HttpFileCollection hfc = Request.Files;
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0 || !string.IsNullOrEmpty(fphidd.Value.ToString()))
                        {
                            lblfileerror.Visible = false;
                            hdfile.Value = civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());

                             if (hpf.ContentLength > 0)
                            {


                            filepath = civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());
                            savePath = @"Civil\" + civil + "-" + "Civil-ID" + imagetime + Path.GetExtension(fbCiviID.PostedFile.FileName.ToString());
                            fbCiviID.PostedFile.SaveAs(Server.MapPath(savePath));
                            }
                             else
                             {
                                 filepath = fphidd.Value.ToString();
                             }

                            general_fn gfn = new general_fn();
                            hdpwd.Value = gfn.ComputeHash(Server.HtmlEncode(txtPassword.Text.Trim()), Server.HtmlEncode(txtEmail.Text), "SHA512", null);
                            string time = date.ToString("yyyyMMddHHmmss");


                            string lang = string.Empty;
                            if (DDLCatagory.SelectedItem.Text.ToString().Trim() == "المناظرات الشبابية")
                            {
                                lang = radioLangauge.SelectedItem.Text.Trim();
                            }
                            else
                            {
                                lang = "";
                            }
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

                            //Command.Parameters.AddWithValue("@Parentname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentFirstname.Text);
                            //Command.Parameters.AddWithValue("@ParentMname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentSecondname.Text);
                            //Command.Parameters.AddWithValue("@ParentTname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentThirdname.Text);
                            //Command.Parameters.AddWithValue("@ParentLname", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentLastname.Text);
                            //Command.Parameters.AddWithValue("@Parentemail", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentEmail.Text);
                            //Command.Parameters.AddWithValue("@Parentmobile", SqlDbType.NVarChar).Value = Server.HtmlEncode(TxtParentMobileNo.Text);

                            //other info
                            Command.Parameters.AddWithValue("@Governarate", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDlGovernarate.SelectedValue);
                            Command.Parameters.AddWithValue("@Area", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDLArea.SelectedValue);
                            Command.Parameters.AddWithValue("@Catagory", SqlDbType.NVarChar).Value = category.First();
                            Command.Parameters.AddWithValue("@SubCatagory", SqlDbType.NVarChar).Value = (pnlSub.Visible == true ? Server.HtmlEncode(DDlSubGroup.SelectedItem.Text) : "");
                            Command.Parameters.AddWithValue("@UserLevel", SqlDbType.NVarChar).Value = Server.HtmlEncode(DDLlevl.SelectedItem.Text);
                            Command.Parameters.AddWithValue("@Organization", SqlDbType.Int).Value = "1"; // int.Parse(Session["OrganizationID"].ToString());
                            Command.Parameters.AddWithValue("@Catagory2", SqlDbType.NVarChar).Value = (category.Count() == 1 ? 0 : category.Last());
                            Command.Parameters.AddWithValue("@lang", SqlDbType.NVarChar).Value = lang;
                            Command.Parameters.AddWithValue("@jointype", SqlDbType.NVarChar).Value = hiddenJoinType.Value.ToString();

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

                                    //string code = "دوري الابداع الشبابي" + Environment.NewLine + "الموسم الاول ٢٠٢٠" + Environment.NewLine + " Name:" + txtName.Text + " " + txtMname.Text + " " + txtTname.Text + " " + txtLname.Text + Environment.NewLine + "civil:" + txtCivil.Text + Environment.NewLine + "Competition Name:" + DDLCatagory.SelectedItem.Text + Environment.NewLine + "Level" + DDLlevl.SelectedItem.Text;

                                    //var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", code, 150, 150);
                                    //WebResponse response = default(WebResponse);
                                    //Stream remoteStream = default(Stream);
                                    //StreamReader readStream = default(StreamReader);
                                    //WebRequest request = WebRequest.Create(url);
                                    //response = request.GetResponse();
                                    //remoteStream = response.GetResponseStream();
                                    //readStream = new StreamReader(remoteStream);
                                    //System.Drawing.Image img = System.Drawing.Image.FromStream(remoteStream);
                                    //img.Save("C:/inetpub/wwwroot/Youth.gov.kw/YCLC/imgQR/" + message + ".png");
                                    //// img.Save("C:/inetpub/wwwroot/YouthMinistry/YCLC/imgQR/" + message + ".png");
                                    ////  img.Save(Server.MapPath("imgQR/" )+ message + ".png");
                                    //response.Close();
                                    //remoteStream.Close();
                                    //readStream.Close();
                                    string ID = message;
                                    Session["yclC_userid"] = ID;
                                    con.Close();
                                    gfn.YCLCompetition(txtEmail.Text, "", ID);
                                    con.Close();

                                    Session["yclC_category"] = hiddenJoinType.Value.ToString();//DDLCatagory.SelectedValue.ToString();
                                    Response.Redirect("Thankyou.aspx", false);

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
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Choose Debate Langauge for المناظرات الشبابية ');", true);

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
                    datepicker.Text = dob;
                    //bool val = checkcivil();



                    LoadLevel();
                    Filldata();
                    //if (val)
                    //{
                    //    datepicker.Text = dob;
                    //    // DDLCatagory_SelectedIndexChanged(null, null);

                    //}
                    //else
                    //{
                    //    lblCivil.Visible = true;
                    //}


                }

            }
            else
            {
                txtCivil.Text = "";
                lblCivil.Visible = true;
                lblCivil.Text = "الرقم المدني غير صحيح";
                DDLCatagory.Enabled = false;
            }



        }
        else
        {
            DDLCatagory.Enabled = false;
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



    protected void Filldata()
    {
        con.ConnectionString = Obj_Gen.ConnectionString();
        con.Open();
        SqlCommand cmd1 = new SqlCommand("SP_GetCivildetails", con);
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.AddWithValue("@CivilID", SqlDbType.NVarChar).Value = txtCivil.Text;
        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        cmd1.ExecuteNonQuery();
        sda1.Fill(dt1);
        con.Close();
        if (dt1.Rows.Count > 0)
        {

            txtName.Text = dt1.Rows[0]["UserName"].ToString();
            txtMname.Text = dt1.Rows[0]["UserMname"].ToString();
            txtTname.Text = dt1.Rows[0]["UserTName"].ToString();
            txtLname.Text = dt1.Rows[0]["UserLname"].ToString();
            txtEnglishName.Text = dt1.Rows[0]["NameInEnglish"].ToString();


            txtContactNo.Text = dt1.Rows[0]["Usermobile"].ToString();
            txtCivil.Text = dt1.Rows[0]["Usercivil"].ToString();
            txtEmail.Text = dt1.Rows[0]["Useremail"].ToString();
            TxtEmailCompare.Text = dt1.Rows[0]["Useremail"].ToString();
            DDlGovernarate.SelectedValue = dt1.Rows[0]["Governarate"].ToString();
            DDlGovernarate_SelectedIndexChanged(null, null);
            DDLArea.SelectedValue = dt1.Rows[0]["Area"].ToString();
            //txtPassword.Text = dt1.Rows[0]["pwd"].ToString();
            //txtConfirmPwd.Text = dt1.Rows[0]["pwd"].ToString();

            DDLCatagory.Items.FindByValue(dt1.Rows[0]["Catagory"].ToString()).Attributes.Add("class", "");
            DDLCatagory.Items.FindByValue(dt1.Rows[0]["Catagory"].ToString()).Selected = true;
            gender.Items.FindByValue(dt1.Rows[0]["Usergender"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt1.Rows[0]["image_name"].ToString()))
            {
                afilecivil.HRef = "../YCLC/Civil/" + dt1.Rows[0]["image_name"].ToString();
                afilecivil.Visible = true;
                RequiredFieldValidator2.Visible = false;
                fphidd.Value = dt1.Rows[0]["image_name"].ToString();
            }
            else
            {
                afilecivil.HRef = "#";
                afilecivil.Visible = false;
                RequiredFieldValidator2.Visible = true;
                fphidd.Value = null;
            }
            if (!string.IsNullOrEmpty(dt1.Rows[0]["DebateLangaguge"].ToString()))
            {
                radioLangauge.Items.FindByText(dt1.Rows[0]["DebateLangaguge"].ToString().Trim()).Selected = true;
                radioLangauge.Visible = true;

            }

        }
    }





    private bool checkcivil()
    {
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
        con.Close();
        if (msg.Equals("1"))
        {
            Filldata();
            //lblCivil.Text = "Already Applied ";
            val = false;
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "visible", " $get('" + btnSubmit.ClientID + "').style.display = 'none';", true);
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
        //   DDLCatagory.SelectedIndex = 0;
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

        LoadLevel();
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
        //   int ic = Convert.ToInt32(DDLCatagory.SelectedValue.ToString());
        string gov = DDlGovernarate.SelectedValue;

        int area1 = 0;
        int count = 0;

        bool chek = false;

        foreach (ListItem item in DDLCatagory.Items)
        {
            if (item.Selected == true)
            {
                chek = true;
                break;
            }
        }

        if (chek)
        {

            if ((gov.Equals("1")) || (gov.Equals("3")) || (gov.Equals("4")) || (gov.Equals("6")))
            {
                count = 1000;
                area1 = int.Parse(GetQueryValue("select count(*) from YCLCompetition where Catagory=" + DDLCatagory.SelectedItem.Value + " and UserLevel=N'" + DDLlevl.SelectedItem.Text + "' and Governarate in(1,3,4,6)").ToString());

            }
            else if ((gov.Equals("2")) || (gov.Equals("5")))
            {
                count = 1000;
                area1 = int.Parse(GetQueryValue("select count(*) from YCLCompetition where Catagory=" + DDLCatagory.SelectedItem.Value + " and UserLevel=N'" + DDLlevl.SelectedItem.Text + "' and Governarate in(2,5)").ToString());

            }

            #region newModifications

            //    bool chek5 = false;
            //    foreach (ListItem item in DDLCatagory.Items)
            //    {
            //        if (item.Selected == true && item.Value == "5")
            //        {
            //            chek5 = true;
            //            break;
            //        }
            //    }
            //    if (chek5 == false)
            //    {
            //        pnlSub.Visible = false;
            //        DDlSubGroup.ClearSelection();
            //        DDlSubGroup.Items.Clear();
            //    }
            //    else if (chek5 == true)
            //    {
            //        pnlSub.Visible = true;
            //        DDlSubGroup.ClearSelection();
            //        DDlSubGroup.Items.Clear();
            //        DDlSubGroup.Items.Insert(0, new ListItem("--اختر--", "0"));
            //        DDlSubGroup.Items.Insert(1, new ListItem("الرسم", "1"));
            //        DDlSubGroup.Items.Insert(2, new ListItem("الخزف", "2"));
            //        int ageval = int.Parse(HdAge.Value);

            //        if (ageval >= 7 && ageval <= 10)
            //        {

            //            DDlSubGroup.Items.FindByValue("1").Selected = true;

            //        }
            //        else if (ageval >= 11 && ageval <= 14)
            //        {

            //            DDlSubGroup.Items.FindByValue("1").Selected = true;


            //        }
            //        else if (ageval >= 15 && ageval <= 18)
            //        {
            //            if ((gov.Equals("2")) || (gov.Equals("5")))
            //            {
            //                pnlSub.Visible = false;
            //                DDlSubGroup.ClearSelection();
            //                DDlSubGroup.Items.Clear();
            //                pnlMessage.Visible = true;
            //                DDLCatagory.SelectedIndex = 0;
            //            }
            //            else
            //            {
            //                DDlSubGroup.Items.FindByValue("2").Selected = true;
            //            }

            //        }
            //    }

            //    #region oldCode

            //    //if (DDLCatagory.SelectedItem.Value.Equals("5"))
            //    //{

            //    //    pnlSub.Visible = true;
            //    //    DDlSubGroup.ClearSelection();
            //    //    DDlSubGroup.Items.Clear();
            //    //    DDlSubGroup.Items.Insert(0, new ListItem("--اختر--", "0"));
            //    //    DDlSubGroup.Items.Insert(1, new ListItem("الرسم", "1"));
            //    //    DDlSubGroup.Items.Insert(2, new ListItem("الخزف", "2"));
            //    //    int ageval = int.Parse(HdAge.Value);

            //    //    if (ageval >= 7 && ageval <= 10)
            //    //    {

            //    //        DDlSubGroup.Items.FindByValue("1").Selected = true;

            //    //    }
            //    //    else if (ageval >= 11 && ageval <= 14)
            //    //    {

            //    //        DDlSubGroup.Items.FindByValue("1").Selected = true;


            //    //    }
            //    //    else if (ageval >= 15 && ageval <= 18)
            //    //    {
            //    //        if ((gov.Equals("2")) || (gov.Equals("5")))
            //    //        {
            //    //            pnlSub.Visible = false;
            //    //            DDlSubGroup.ClearSelection();
            //    //            DDlSubGroup.Items.Clear();
            //    //            pnlMessage.Visible = true;
            //    //            DDLCatagory.SelectedIndex = 0;
            //    //        }
            //    //        else
            //    //        {
            //    //            DDlSubGroup.Items.FindByValue("2").Selected = true;
            //    //        }

            //    //    }

            //    //}
            //    //else
            //    //{
            //    //    pnlSub.Visible = false;
            //    //    DDlSubGroup.ClearSelection();
            //    //    DDlSubGroup.Items.Clear();

            //    //}

            //    #endregion
            //}
            //else
            //{
            //    DDlSubGroup.ClearSelection();
            //    pnlSub.Visible = false;
            //    pnlSub.Visible = false;
            //}

            #endregion

            if (area1 <= count)
            {
                pnlMessage.Visible = false;

            }

            else
            {
                pnlMessage.Visible = true;
                //DDLCatagory.SelectedIndex = 0;
                //  pnlSub.Visible = false;
                // DDlSubGroup.ClearSelection();
                // DDlSubGroup.Items.Clear();
            }


        }
        else
            pnlMessage.Visible = false;


    }



    protected void DDLCatagory_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DDLCatagory.SelectedItem.Text.Trim() == "المناظرات الشبابية")
        {
            if (int.Parse(HdAge.Value.ToString()) > 12)
            {               
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "openModal();", true);               
            }
            else
            {
                radioLangauge.Items.FindByValue("0").Selected = true;
            }
           
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "closeModal();", true);
        }
    }
}