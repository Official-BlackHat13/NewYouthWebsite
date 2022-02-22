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
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;

public partial class ini_Form_InitiativeEditForm : System.Web.UI.Page
{
    DataTable myTable = new DataTable();
    DataTable MediaTable = new DataTable();
    DataTable BudgetTable = new DataTable();
    DataTable SponserTable = new DataTable();
    DataTable ExcutiveTable = new DataTable();

    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    SqlConnection con = new SqlConnection();
    general_fn gfn = new general_fn();

   // public static string PID = string.Empty;
   // public static string BID = string.Empty;
   // public static string AID = string.Empty;

    int appy_type = 0;
    int total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["userid"] = "3680"; //"6063";
        if (Server.HtmlEncode((Request.QueryString["rid"])) != null)
        {
            Session["unique"] = Server.HtmlEncode(Request.QueryString["rid"]);
        }
        if (Session["userid"] != null)
        {


            myTable.Columns.Add("txtDate");
            myTable.Columns.Add("txtStartTime");
            myTable.Columns.Add("txtEndTime");
            myTable.Columns.Add("txtCv");
            myTable.Columns.Add("txtNameofSpeaker");
            myTable.Columns.Add("txtAddress");
            myTable.Columns.Add("txtAxces");
            myTable.Columns.Add("txtNumberofattendence");
            myTable.Columns.Add("id");



            MediaTable.Columns.Add("txtPlace");
            MediaTable.Columns.Add("txtNumberAdd");
            MediaTable.Columns.Add("txtAddDetails");
            MediaTable.Columns.Add("txtCostDetails");
            MediaTable.Columns.Add("id");


            BudgetTable.Columns.Add("txtItem");
            BudgetTable.Columns.Add("txtNumber");
            BudgetTable.Columns.Add("txtCost");
            BudgetTable.Columns.Add("txtTotalcost");
            BudgetTable.Columns.Add("id");


            SponserTable.Columns.Add("txtSponserName");
            SponserTable.Columns.Add("txtTypeCare");
            SponserTable.Columns.Add("txtCareDetails");
            SponserTable.Columns.Add("id");


            ExcutiveTable.Columns.Add("txtActivityDate");
            ExcutiveTable.Columns.Add("txtActivity");
            ExcutiveTable.Columns.Add("id");



            if (!this.IsPostBack)
            {
                for (int i = 0; i < 1; i++) // LOAD THREE TEXTBOX FOR EXAMPLE
                {
                    myTable.Rows.Add(myTable.NewRow());
                    Bind();

                    MediaTable.Rows.Add(MediaTable.NewRow());
                    BindMedia();


                    BudgetTable.Rows.Add(BudgetTable.NewRow());
                    BindBudget();

                    SponserTable.Rows.Add(SponserTable.NewRow());
                    SponserBudget();

                    ExcutiveTable.Rows.Add(ExcutiveTable.NewRow());
                    BindExcutive();
                }

                if (Session["unique"] != null)
                {

                    checkPageInfo(); 
                   // loadValue("6189", "3216");
                  

                }
                else
                {

                    Response.Redirect("Ini_Edit_final.aspx", true);
                }


            }
        }
        else
        {

            Session["page"] = "ini_editform";
            Response.Redirect("../User/login.aspx", true);

        }
        
    }


    public void checkPageInfo()
    {

        string id = userid();
        SQLConnection2();
        string query = "checkIniEditUserPermission";
        SqlCommand cmd = new SqlCommand(query, cnn);
        string unique = Session["unique"].ToString();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@uniqueid", SqlDbType.NVarChar).Value = unique;
        cmd.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = id;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable result = new DataTable();
        da.Fill(result);
        cnn.Close();
        if (result.Rows.Count > 0)
        {

            hBid.Value = result.Rows[0]["BID"].ToString().Trim();
            hPid.Value = result.Rows[0]["PID"].ToString().Trim();
            hAid.Value = result.Rows[0]["adminID"].ToString().Trim();
            if (result.Rows[0]["TypeofIntiative"].ToString().Equals("10"))
            {

                Response.Redirect("Initiative_EditStudentOrganization.aspx", true);

            }
            else
                loadValue(hBid.Value, hPid.Value);
        }
        else
        {
            Response.Redirect("Ini_Edit_final.aspx", true);
        }

    }




    private void loadValue(string BuID, string UsID)
    {
        SQLConnection2();

        string query = "loadIntiativeValue";
        SqlCommand cmd = new SqlCommand(query, cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //DataTable dt = new DataTable();
        cmd.Parameters.AddWithValue("@PID", SqlDbType.NVarChar).Value = UsID;
        cmd.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = BuID;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            loadPersonel(ds.Tables[0]);
            loadiniData(ds.Tables[1]);
            loadActivity(ds.Tables[2]);
            loadBudget(ds.Tables[3]);
            loadExecutive(ds.Tables[4]);
            loadFile(ds.Tables[5]);
            loadMedia(ds.Tables[6]);
            loadSponser(ds.Tables[7]);
            cnn.Close();
        }

    }
    private void loadPersonel(DataTable dt)
    {
        txtFname.Text = dt.Rows[0]["Name"].ToString();
        txtMname.Text = dt.Rows[0]["Mname"].ToString();
        txtThirdName.Text = dt.Rows[0]["TName"].ToString();
        txtsurname.Text = dt.Rows[0]["Lname"].ToString();

        string image = dt.Rows[0]["image_name"].ToString();

        hdUserCivilPath.Value = image;
        hdUserCivilID.Value = dt.Rows[0]["civil"].ToString();

        if (!string.IsNullOrEmpty(image))
        {
            filecivil_a.HRef = "../User/" + image;
            filecivil_a.Visible = true;
            RequiredFieldValidator44.Visible= false;
        }
        else
        {
            filecivil_a.Visible = false;
            RequiredFieldValidator44.Visible = true;
        }


    }
    private void loadiniData(DataTable dt)
    {
        string d;
        string[] datesplit;
      
        if (RBIntiativeCatagory.Items.FindByText(dt.Rows[0]["Intiative_CatagoryType"].ToString()) != null)
        {
            RBIntiativeCatagory.Items.FindByText(dt.Rows[0]["Intiative_CatagoryType"].ToString()).Selected = true;
            RBIntiativeCatagory_SelectedIndexChanged(null, null);
        }
        
        if (dt.Rows[0]["Initiative_Type"].ToString().Equals("5"))
        {
            RBindivitual.Checked = true;
           // drpType.Items.Clear();
            //lblNumberofBenficiries.Text = "عدد المستفيدين من المشروع";
            //lblproject.Text = "بيان الأثر الإيجابي للمشروع الشبابي";
            //drpType.Items.Insert(0, new ListItem("--اختر--", "0"));
            //drpType.Items.Insert(1, new ListItem("محاضرة", "1"));
            //drpType.Items.Insert(2, new ListItem("دورة تدريبية", "2"));
            //drpType.Items.Insert(3, new ListItem("ورشة عمل", "3"));
            //drpType.Items.Insert(4, new ListItem("أخرى", "4"));
            RBindivitual_CheckedChanged(null, null);
        }
        else
        {
            RBForum.Checked = true;
            RBForum_CheckedChanged(null, null);
            //lblproject.Text = "بيان الأثر الإيجابي للفعالية";
            //lblNumberofBenficiries.Text = "عدد المستفيدين من الفعالية";
            //drpType.Items.Clear();
            //drpType.Items.Insert(0, new ListItem("--اختر--", "0"));
            //drpType.Items.Insert(1, new ListItem("مؤتمر", "1"));
            //drpType.Items.Insert(2, new ListItem("ملتقى", "2"));
            //drpType.Items.Insert(3, new ListItem("أخرى", "3"));
        }

        
        if (RBindivitual.Checked)
        {
            divEvent.Visible = false;
            divProjectname.Visible = true;
            txtProjectName.Text = dt.Rows[0]["Initiative_ProjcetName"].ToString();
            RBindivitual_CheckedChanged(null, null);
        }
        else if (RBForum.Checked)
        {
            divEvent.Visible = true;
            divProjectname.Visible = false;
            txtEventName.Text = dt.Rows[0]["Initiative_ProjcetName"].ToString();
            RBForum_CheckedChanged(null, null);
        }
        drpEduQulification.SelectedIndex = drpEduQulification.Items.IndexOf(drpEduQulification.Items.FindByText(dt.Rows[0]["Initiative_EducationalQulification"].ToString()));
        txtNameofInstitution.Text = dt.Rows[0]["Initiative_NameofInstituion"].ToString();
        dpGovernarate.SelectedIndex = dpGovernarate.Items.IndexOf(dpGovernarate.Items.FindByText(dt.Rows[0]["Initiative_Governarate"].ToString()));
        dpArea.SelectedIndex = dpArea.Items.IndexOf(dpArea.Items.FindByText(dt.Rows[0]["Initiative_Area"].ToString()));      




        d = dt.Rows[0]["Initiative_StratDate"].ToString().Trim();

        if (!string.IsNullOrEmpty(d))
        {
            datesplit = d.Split(' ');
            string[] strS = new string[4]; 
            if (d.Contains("/"))
            {
               strS = datesplit[0].Split('/');
            }
            else
                strS = datesplit[0].Split('-');
            datepicker.Text = strS[2] + "-" + strS[1] + "-" + strS[0];

        }
        d = dt.Rows[0]["Initiative_EndDate"].ToString().Trim();
        if (!string.IsNullOrEmpty(d))
        {
            datesplit = d.Split(' ');

            string[] strS= new string[4]; 
            if (d.Contains("/"))
            {
                strS = datesplit[0].Split('/');
            }
            else
                strS = datesplit[0].Split('-');          

            txtend.Text = strS[2] + "-" + strS[1] + "-" + strS[0];
        }
        if (!string.IsNullOrEmpty(txtend.Text))
        {
            RequiredFieldValidator33.Visible =false;
            txtend.CausesValidation = false;
            
        }



        txtPlaceofResidence.Text = dt.Rows[0]["Initiative_PlaceofResidence"].ToString();
        txtEventVenue.Text = dt.Rows[0]["Initiative_PlaceofResidence"].ToString();//same as above


        txtProjectDetail.Text = dt.Rows[0]["Initiative_ProjectDetail"].ToString();
        txtObjective.Text = dt.Rows[0]["Initiative_Objective"].ToString();
        txtImpctofproject.Text = dt.Rows[0]["Initiative_Impctofproject"].ToString();

        dpTargetSegment.SelectedIndex = dpTargetSegment.Items.IndexOf(dpTargetSegment.Items.FindByText(dt.Rows[0]["Initiative_Target"].ToString()));
        if (dpTargetSegment.SelectedIndex == 1)
        {
            lblCatagory.Text = "الفئة العمرية (من 14 إلى 35 سنة)";
        }
        else if (dpTargetSegment.SelectedIndex == 2)
        {
            lblCatagory.Text = "الفئة العمرية";
        }

        txtNumberofBenficiries.Text = dt.Rows[0]["Initiative_NumberofBenficiries"].ToString();

        string age = dt.Rows[0]["Initiative_CatogoryandAge"].ToString();
        if (age.Contains('-'))
        {

            txtAgeFrom.Text = age.Substring(0, age.IndexOf("-"));
            txtAgeTo.Text = age.Substring(age.IndexOf("-") + 1);
        }
        else
            txtAgeFrom.Text = age;



        txtRoleofApplicant.Text = dt.Rows[0]["Initiative_RoleofApplicant"].ToString();

        dpProjectCategory.SelectedIndex = dpProjectCategory.Items.IndexOf(dpProjectCategory.Items.FindByText(dt.Rows[0]["Initiative_ProjectCategory"].ToString()));

        RBVolounteer.SelectedIndex = RBVolounteer.Items.IndexOf(RBVolounteer.Items.FindByText(dt.Rows[0]["Initiative_volounteerInterest"].ToString()));

        if (RBVolounteer.Items.FindByValue(dt.Rows[0]["Initiative_volounteerInterest"].ToString()) != null)
        {
            RBVolounteer.Items.FindByValue(dt.Rows[0]["Initiative_volounteerInterest"].ToString()).Selected = true;
        }

        if (txtNameofInstitution.Text == "")
        {
            divname_of_institution.Visible = false;
        }

        drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByText(dt.Rows[0]["Initiative_typeofActivity"].ToString()));
        drpType_SelectedIndexChanged(null, null);

        
        
    }
    private void loadActivity(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            rpDetails.DataSource = dt;
            rpDetails.DataBind();

            rpDetails.Visible = true;
            foreach (RepeaterItem item in rpDetails.Items)
            {
                HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");
                TextBox txtCv = (TextBox)item.FindControl("txtCv");
                RequiredFieldValidator rbtext = (RequiredFieldValidator)item.FindControl("RequiredFieldValidator4");
                if (string.IsNullOrEmpty(txtCv.Text))
                {
                    anchor.Visible = false;
                    rbtext.Enabled = true;
                }
                else
                {
                    rbtext.Enabled = false;
                }

            }


            if (rpDetails.Items.Count > 1)
            {
                lnkDetailCancel.Visible = true;

            }
        }
    }
    private void loadBudget(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            RPBudget.DataSource = dt;
            RPBudget.DataBind();
            RPBudget.Visible = true;
            calculateBudget();
            if (RPBudget.Items.Count > 1)
            {
                lnkBugetCancel.Visible = true;
            }
        }
    }
    private void loadExecutive(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            RpExctuiveplan.DataSource = dt;
            RpExctuiveplan.DataBind();
            RpExctuiveplan.Visible = true;

            if (RpExctuiveplan.Items.Count > 1)
            {
                lnkExcutiveCanecl.Visible = true;
            }
        }
    }
    private void loadFile(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {

            if (!string.IsNullOrEmpty(dt.Rows[0]["Initiative_CivilID"].ToString()))
            {
                fpCivilID_a.HRef = dt.Rows[0]["Initiative_CivilID"].ToString();
                rfvCivilId.Visible = false;
                fpCivilID_a.Visible = true;
            }
          

            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_Autorization"].ToString()))
            {
                fpAutorization_a.HRef = dt.Rows[0]["Intiative_Autorization"].ToString();
                RequiredFieldValidator8.Visible = false;
                fpAutorization_a.Visible = true;
            }
            else
            {
                fpAutorization_a.Visible = false;
                div_authorization.Visible = false;

            }


            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_civilpubicauthority"].ToString()))
            {
                fpcivilpubicauthority_a.HRef = dt.Rows[0]["Intiative_civilpubicauthority"].ToString();
                RequiredFieldValidator9.Visible = false;
                fpcivilpubicauthority_a.Visible = true;
            }
            else
            {
                fpcivilpubicauthority_a.Visible = false;
                div_civilid_publi_authority.Visible = false;
            }


            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_civilidpublicpapper"].ToString()))
            {
                fpcivilidpublicpapper_a.HRef = dt.Rows[0]["Intiative_civilidpublicpapper"].ToString();
                RequiredFieldValidator10.Visible = false;
                fpcivilidpublicpapper_a.Visible = true;
            }
            else
            {
                fpcivilidpublicpapper_a.Visible = false;
                div_civilid_public_papper.Visible = false;
            }


            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_BookApproval"].ToString()))
            {
                txtBookApproval_a.HRef = dt.Rows[0]["Intiative_BookApproval"].ToString();
                rvBookApproval.Visible = false;
                txtBookApproval_a.Visible = true;
            }
            else
                txtBookApproval_a.Visible = false;



            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_conferencewrkingpapper"].ToString()))
            {
                fpconferencewrkingpapper_a.HRef = dt.Rows[0]["Intiative_conferencewrkingpapper"].ToString();
                RequiredFieldValidator39.Visible = false;
                fpconferencewrkingpapper_a.Visible = true;
            }
            else
                fpconferencewrkingpapper_a.Visible = false;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_Cvofapplicant"].ToString()))
            {
                txtCvofapplicant_a.HRef = dt.Rows[0]["Intiative_Cvofapplicant"].ToString();
                RequiredFieldValidator43.Visible = false;
                txtCvofapplicant_a.Visible = true;
            }
            else
                txtCvofapplicant_a.Visible = false;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Intiative_executiveplan"].ToString()))
            {
                fpexecutiveplan_a.HRef = dt.Rows[0]["Intiative_executiveplan"].ToString();
                fpexecutiveplan_a.Visible = true;

            }
            else
            {
                fpexecutiveplan_a.Visible = false;
            }

        }

        
    }
    private void loadMedia(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            RpMedia.DataSource = dt;
            RpMedia.DataBind();
            RpMedia.Visible = true;

            foreach (RepeaterItem item in RpMedia.Items)
            {
                TextBox txtCostDetails = (TextBox)item.FindControl("txtCostMedia");
                MediaTotal(txtCostDetails.Text);

            }

            BudgetTable.Rows.Add(BudgetTable.NewRow());

            if (RpMedia.Items.Count > 1)
            {
                lnkMediaCancel.Visible = true;
            }
        }
    }
    private void loadSponser(DataTable dt)
    {

        if (dt.Rows.Count > 0)
        {
            rpSponser.DataSource = dt;
            if (rpSponser.Items.Count > 0)
            {
                rpSponser.DataBind();
            }
            rpSponser.Visible = true;
            if (rpSponser.Items.Count > 1)
            {
                lnkSponserCanel.Visible = true;
            }
        }
    }

    public string userid()
    {
        general_fn gfn = new general_fn();
        string strUserid = Session["userid"].ToString();
        strUserid = gfn.SessionDecrypt(strUserid, SHA512.Create().ToString());
        strUserid = strUserid.Substring(strUserid.IndexOf("&") + 1);
        return strUserid;
    }
    protected void rpDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulateDataTable();
        myTable.Rows[e.Item.ItemIndex].Delete();
        Bind();
        Repeater gvRow = (Repeater)((Control)e.CommandSource).NamingContainer;
        TextBox HdEmail = ((TextBox)gvRow.FindControl("txtCv"));
        RequiredFieldValidator hdre = ((RequiredFieldValidator)gvRow.FindControl("RequiredFieldValidator4"));
        if (HdEmail.Text.Equals(""))
        {
            hdre.Enabled = true;
        }
        else
            hdre.Enabled = false;
        
    }
    protected void RpExctuiveplan_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulateExecutiveDataTable();
        myTable.Rows[e.Item.ItemIndex].Delete();
        BindExcutive();
    }
    protected void RpMedia_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulateMediaDataTable();
        MediaTable.Rows[e.Item.ItemIndex].Delete();
        BindMedia();
    }

    protected void RPBudget_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulateBudgetDataTable();
        BudgetTable.Rows[e.Item.ItemIndex].Delete();
        BindBudget();
    }

    protected void rpSponser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulateSponserDataTable();
        SponserTable.Rows[e.Item.ItemIndex].Delete();
        SponserBudget();
    }
    protected void SponserBudget()
    {
        rpSponser.DataSource = SponserTable;
        rpSponser.DataBind();

    }
    protected void BindBudget()
    {
        RPBudget.DataSource = BudgetTable;
        RPBudget.DataBind();

    }
    protected void BindMedia()
    {
        RpMedia.DataSource = MediaTable;
        RpMedia.DataBind();

    }
    protected void Bind()
    {
        rpDetails.DataSource = myTable;
        rpDetails.DataBind();

        foreach (RepeaterItem item in rpDetails.Items)
        {
            HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");
            TextBox txtCv = (TextBox)item.FindControl("txtCv");
            RequiredFieldValidator rq = (RequiredFieldValidator)item.FindControl("RequiredFieldValidator4");
            if (string.IsNullOrEmpty(txtCv.Text))
            {
                anchor.Visible = false;
                rq.Enabled = true;
            }
            else
            {
                rq.Enabled = false;
            }

        }

    }
    protected void BindExcutive()
    {
        RpExctuiveplan.DataSource = ExcutiveTable;
        RpExctuiveplan.DataBind();

    }
    protected void PopulateDataTable()
    {
        foreach (RepeaterItem item in rpDetails.Items)
        {
            TextBox txtDate = (TextBox)item.FindControl("txtDate");

            TextBox txtStartTime = (TextBox)item.FindControl("txtStartTime");
            TextBox txtEndTime = (TextBox)item.FindControl("txtEndTime");
            TextBox txtCv = (TextBox)item.FindControl("txtCv");
            TextBox txtNameofSpeaker = (TextBox)item.FindControl("txtNameofSpeaker");
            TextBox txtAddress = (TextBox)item.FindControl("txtAddress");
            TextBox txtAxces = (TextBox)item.FindControl("txtAxces");
            TextBox txtNumberofattendence = (TextBox)item.FindControl("txtNumberofattendence");
            HiddenField id = (HiddenField)item.FindControl("hddetailsID");

            


            DataRow row = myTable.NewRow();

            row["txtDate"] = txtDate.Text;
            row["txtStartTime"] = txtStartTime.Text;
            row["txtEndTime"] = txtEndTime.Text;
            row["txtCv"] = txtCv.Text;
            row["txtNameofSpeaker"] = txtNameofSpeaker.Text;
            row["txtAddress"] = txtAddress.Text;
            row["txtAxces"] = txtAxces.Text;
            row["txtNumberofattendence"] = txtNumberofattendence.Text;
            row["id"] = id.Value;
            


            myTable.Rows.Add(row);
            

        }

    }

    protected void PopulateExecutiveDataTable()
    {
        foreach (RepeaterItem item in RpExctuiveplan.Items)
        {
            TextBox txtActivityDate = (TextBox)item.FindControl("txtActivityDate");

            TextBox txtActivity = (TextBox)item.FindControl("txtActivity");
            HiddenField id = (HiddenField)item.FindControl("hdExecutiveID");


            DataRow row = ExcutiveTable.NewRow();

            row["txtActivityDate"] = txtActivityDate.Text;
            row["txtActivity"] = txtActivity.Text;
            row["id"] = id.Value;  

            ExcutiveTable.Rows.Add(row);

        }
    }

    protected void MediaTotal(string totalCost)
    {       
       
            string value = string.Empty;

            int i = 0;
            if (totalCost != "")
            {
                i = int.Parse(totalCost) + i;
                value = i.ToString();
                total = total + i;
                txtToalCostMedia.Text = "الإجمالي :" + total;
            }
        

    }

    protected void PopulateMediaDataTable()
    {
        //int total = 0;
        foreach (RepeaterItem item in RpMedia.Items)
        {
            TextBox txtPlace = (TextBox)item.FindControl("txtPlace");

            TextBox txtNumberAdd = (TextBox)item.FindControl("txtNumberAdd");
            TextBox txtAddDetails = (TextBox)item.FindControl("txtAddDetails");
            TextBox txtCostDetails = (TextBox)item.FindControl("txtCostMedia");
            HiddenField id = (HiddenField)item.FindControl("hdMediaID");
            MediaTotal(txtCostDetails.Text);

            //string value = string.Empty;
            //int i = 0;

            //if (!txtCostDetails.Text.Equals(""))
            //{
            //    i = int.Parse(txtCostDetails.Text) + i;
            //    value = i.ToString();
            //    total = total + i;
            //    txtToalCostMedia.Text = "الإجمالي :" + total;
            //}

            DataRow row = MediaTable.NewRow();

            row["txtPlace"] = txtPlace.Text;
            row["txtNumberAdd"] = txtNumberAdd.Text;
            row["txtAddDetails"] = txtAddDetails.Text;
            row["txtCostDetails"] = txtCostDetails.Text;
            row["id"] = id.Value;  

            MediaTable.Rows.Add(row);

        }
    }

    protected void PopulateBudgetDataTable()
    {
        int total = 0;
        foreach (RepeaterItem item in RPBudget.Items)
        {
            TextBox txtItem = (TextBox)item.FindControl("txtItem");

            TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
            TextBox txtCost = (TextBox)item.FindControl("txtCostBudget");
            TextBox txtTotalcost = (TextBox)item.FindControl("txtTotalcost");
            HiddenField id = (HiddenField)item.FindControl("hdBudgetID");

            string value = string.Empty;
            int i = 0;
            if (!txtNumber.Text.Equals("") && !txtCost.Text.Equals(""))
            {
                i = int.Parse(txtNumber.Text) * int.Parse(txtCost.Text);
                value = i.ToString();
                total = total + i;
                txtTotalFinalcost.Text = "الإجمالي :" + total.ToString();
            }
            DataRow row = BudgetTable.NewRow();
            row["txtItem"] = txtItem.Text;
            row["txtNumber"] = txtNumber.Text;
            row["txtCost"] = txtCost.Text;
            row["txtTotalcost"] = value;
            row["id"] = id.Value;


            BudgetTable.Rows.Add(row);

        }
    }
    protected void PopulateSponserDataTable()
    {
        foreach (RepeaterItem item in rpSponser.Items)
        {
            TextBox txtSponserName = (TextBox)item.FindControl("txtSponserName");

            TextBox txtTypeCare = (TextBox)item.FindControl("txtTypeCare");
            TextBox txtCareDetails = (TextBox)item.FindControl("txtCareDetails");
            HiddenField id = (HiddenField)item.FindControl("hdSponsorID");



            DataRow row = SponserTable.NewRow();

            row["txtSponserName"] = txtSponserName.Text;
            row["txtTypeCare"] = txtTypeCare.Text;
            row["txtCareDetails"] = txtCareDetails.Text;
            row["id"] = id.Value;

            SponserTable.Rows.Add(row);

        }
    }
    protected void RBIntiativeCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlType.Visible = true;

        if (RBIntiativeCatagory.SelectedIndex == 4)
        {

         //   RBindivitual.Visible = false;
           // toolindi.Visible = false;

        }
        else if (RBIntiativeCatagory.SelectedIndex > 1 && RBIntiativeCatagory.SelectedIndex <= 3)
        {
          //  RBindivitual.Visible = true;
          //  toolindi.Visible = true;
        }

        else
        {
          //  RBindivitual.Visible = true;
           // toolindi.Visible = true;
        }

      //  RBindivitual.Checked = false;
       // RBForum.Checked = false;
       // pnlOthr.Visible = false;
       // pnlbutton.Visible = false;

    }


    protected void RBindivitual_CheckedChanged(object sender, EventArgs e)
    {
        rvBookApproval.Enabled = false;
        pnlOthr.Visible = true;
        pnlbutton.Visible = true;
        dpprojcetcatagory.Visible = true;
        drpType.Items.Clear();
        lblNumberofBenficiries.Text = "عدد المستفيدين من المشروع";       
        
        
        lblproject.Text = "بيان الأثر الإيجابي للمشروع الشبابي";
        drpType.Items.Insert(0, new ListItem("--اختر--", "0"));
        drpType.Items.Insert(1, new ListItem("محاضرة", "1"));
        drpType.Items.Insert(2, new ListItem("دورة تدريبية", "2"));
        drpType.Items.Insert(3, new ListItem("ورشة عمل", "3"));
        drpType.Items.Insert(4, new ListItem("أخرى", "4"));
        if (RBIntiativeCatagory.SelectedIndex == 0)
        {
            divEvent.Visible = false;
            div_eventVenue.Visible = false;


            divProjectname.Visible = true;
            div_projectVenue.Visible = true;

            divCivilID.Visible = false;
            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;


        }
        else if (RBIntiativeCatagory.SelectedIndex == 1)
        {


            divEvent.Visible = false;
            div_eventVenue.Visible = false;

            divProjectname.Visible = true;
            div_projectVenue.Visible = true;
            divCivilID.Visible = true;
            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;
            div_eventVenue.Visible = false;



        }
        else if (RBIntiativeCatagory.SelectedIndex == 2)
        {
            divCivilID.Visible = false;

            divEvent.Visible = false;
            div_eventVenue.Visible = false;

            divProjectname.Visible = true;
            div_projectVenue.Visible = true;

            divname_of_institution.Visible = true;
            div_authorization.Visible = true;
            div_civilid_publi_authority.Visible = true;
            div_civilid_public_papper.Visible = false;
            div_eventVenue.Visible = false;

        }
        else if (RBIntiativeCatagory.SelectedIndex == 3)
        {
            divCivilID.Visible = false;

            divEvent.Visible = false;
            div_eventVenue.Visible = false;

            divProjectname.Visible = true;
            div_projectVenue.Visible = true;

            divname_of_institution.Visible = true;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = true;
            div_civilid_public_papper.Visible = true;
            div_eventVenue.Visible = false;

        }
        else if (RBIntiativeCatagory.SelectedIndex == 4)
        {
            divCivilID.Visible = false;

            divEvent.Visible = false;
            div_eventVenue.Visible = false;

            divProjectname.Visible = true;
            div_projectVenue.Visible = true;

            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;
            div_eventVenue.Visible = false;

        }
    }
    protected void RBForum_CheckedChanged(object sender, EventArgs e)
    {
        pnlOthr.Visible = true;
        pnlbutton.Visible = true;
        dpprojcetcatagory.Visible = false;
        rvBookApproval.Enabled = true;       


        lblproject.Text = "بيان الأثر الإيجابي للفعالية";
        lblNumberofBenficiries.Text = "عدد المستفيدين من الفعالية";
        drpType.Items.Clear();
        drpType.Items.Insert(0, new ListItem("--اختر--", "0"));
        drpType.Items.Insert(1, new ListItem("مؤتمر", "1"));
        drpType.Items.Insert(2, new ListItem("ملتقى", "2"));
        drpType.Items.Insert(3, new ListItem("معرض", "3"));
        if (RBIntiativeCatagory.SelectedIndex == 0)
        {
            divProjectname.Visible = false;
            div_projectVenue.Visible = false;
            divEvent.Visible = true;
            div_eventVenue.Visible = true;
            divCivilID.Visible = false;
            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;


        }
        else if (RBIntiativeCatagory.SelectedIndex == 1)
        {
            divProjectname.Visible = false;
            div_projectVenue.Visible = false;
            divCivilID.Visible = true;
            divEvent.Visible = true;
            div_eventVenue.Visible = true;
            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;



        }
        else if (RBIntiativeCatagory.SelectedIndex == 2)
        {
            divProjectname.Visible = false;
            div_projectVenue.Visible = false;
            divCivilID.Visible = false;
            divEvent.Visible = true;
            div_eventVenue.Visible = true;
            divname_of_institution.Visible = true;
            div_authorization.Visible = true;
            div_civilid_publi_authority.Visible = true;
            div_civilid_public_papper.Visible = false;




        }
        else if (RBIntiativeCatagory.SelectedIndex == 3)
        {
            divProjectname.Visible = false;
            div_projectVenue.Visible = false;
            divCivilID.Visible = false;
            divEvent.Visible = true;
            div_eventVenue.Visible = true;
            divname_of_institution.Visible = true;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = true;
            div_civilid_public_papper.Visible = true;




        }
        else if (RBIntiativeCatagory.SelectedIndex == 4)
        {
            divProjectname.Visible = false;
            div_projectVenue.Visible = false;
            divCivilID.Visible = false;
            divEvent.Visible = true;
            div_eventVenue.Visible = true;
            divname_of_institution.Visible = false;
            div_authorization.Visible = false;
            div_civilid_publi_authority.Visible = false;
            div_civilid_public_papper.Visible = false;



        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        PopulateDataTable();
        myTable.Rows.Add(myTable.NewRow());
        Bind();
        lnkDetailCancel.Visible = true;
    }
    protected void lnk_MediaPlan_Click(object sender, EventArgs e)
    {
        PopulateMediaDataTable();
        MediaTable.Rows.Add(MediaTable.NewRow());
        BindMedia();
        lnkMediaCancel.Visible = true;
    }
    protected void lnkBudget_Click(object sender, EventArgs e)
    {
        PopulateBudgetDataTable();
        BudgetTable.Rows.Add(BudgetTable.NewRow());
        BindBudget();
        lnkBugetCancel.Visible = true;
    }
    protected void lnksponser_Click(object sender, EventArgs e)
    {
        PopulateSponserDataTable();
        SponserTable.Rows.Add(SponserTable.NewRow());
        SponserBudget();
        lnkSponserCanel.Visible = true;
    }
    protected void lnk_Excutive_Click(object sender, EventArgs e)
    {
        PopulateExecutiveDataTable();
        ExcutiveTable.Rows.Add(ExcutiveTable.NewRow());
        BindExcutive();
        lnkExcutiveCanecl.Visible = true;
    }

    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = drpType.SelectedItem.Text;

        if (value.Equals("مؤتمر"))
        {
            pnlDetails.Visible = true;
            pnlFile.Visible = true;
        }

        else if (value.Equals("أخرى") || value.Equals("--اختر--") || value.Equals("معرض"))
        {
            pnlDetails.Visible = false;
            pnlFile.Visible = false;
        }
        else
        {
            pnlDetails.Visible = true;
            pnlFile.Visible = false;
        }
        if (value.Equals("محاضرة"))
        {
            lblAddress.Text = "عنوان المحاضرة";
        }
        else if (value.Equals("دورة تدريبية"))
        {
            lblAddress.Text = "عنوان الدورة التدريبية";
        }
        else if (value.Equals("ورشة عمل"))
        {
            lblAddress.Text = "عنوان ورشة العمل";
        }
        else if (value.Equals("مؤتمر"))
        {
            lblAddress.Text = "عنوان المؤتمر";
        }
        else if (value.Equals("ملتقى"))
        {
            lblAddress.Text = "عنوان الملتقى";
        }

    }

   


    public void SQLConnection2()
    {

        cnn.ConnectionString = gm.ConnectionString2();
        cnn.Open();
    }
    public void SQLConnection()
    {

        con.ConnectionString = gm.ConnectionString();
        con.Open();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       Validate("submitionform");
       if (Page.IsValid)
       {
           SQLConnection2();

           string startdate = string.Empty;

           string enddate = string.Empty;
           string dob = string.Empty;

           if (!datepicker.Text.Equals(""))
           {
               startdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(3, 2) + "/" + datepicker.Text.Substring(0, 2);

           }
           if (!txtend.Text.Equals(""))
           {
               enddate = txtend.Text.Substring(6, 4) + "/" + txtend.Text.Substring(3, 2) + "/" + txtend.Text.Substring(0, 2);
           }

           if (RBVolounteer.SelectedItem.Value.Equals("1"))
           {

               Session["ayadina_checked"] = "1";

           }

           try
           {
               string civilpath = string.Empty;


               string query = "InitiativeInfo_Update";
               SqlCommand BIDCommand = new SqlCommand(query);
               BIDCommand.CommandType = CommandType.StoredProcedure;

               
              
               string civil = hdUserCivilID.Value;               
               if (filecivil.HasFile && filecivil_a.Visible == false)
               {
                   civilpath = @"Civil\" + civil + "-" + "Civil-ID" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(filecivil.PostedFile.FileName.ToString());
                   filecivil.PostedFile.SaveAs(Server.MapPath("../User/" + civilpath));
               }
               else if (filecivil.HasFile && filecivil_a.Visible == true)
               {
                   civilpath = hdUserCivilPath.Value;
                   filecivil.PostedFile.SaveAs(Server.MapPath("../User/" + civilpath));
               }
               else
               {
                   civilpath = hdUserCivilPath.Value;
               }


               if (!txtProjectName.Text.Equals(""))
               {
                   BIDCommand.Parameters.AddWithValue("@initiative_name", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtProjectName.Text);
               }
               else
                   BIDCommand.Parameters.AddWithValue("@initiative_name", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEventName.Text);



               BIDCommand.Parameters.AddWithValue("@Initiative_Type", SqlDbType.NVarChar).Value = Server.HtmlEncode(dpArea.SelectedItem.Text);

               BIDCommand.Parameters.AddWithValue("@Initiative_Info", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtProjectDetail.Text);
               BIDCommand.Parameters.AddWithValue("@Objectives", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtObjective.Text);


               if (!txtPlaceofResidence.Text.Equals(""))
               {
                   BIDCommand.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtPlaceofResidence.Text);
               }
               else
               {
                   BIDCommand.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEventVenue.Text);
               }



               BIDCommand.Parameters.AddWithValue("@Target_Group", SqlDbType.NVarChar).Value = Server.HtmlEncode(dpTargetSegment.SelectedItem.Text);

               BIDCommand.Parameters.AddWithValue("@Establishment_Time", SqlDbType.NVarChar).Value = Server.HtmlEncode(startdate);
               BIDCommand.Parameters.AddWithValue("@Time_Period", SqlDbType.NVarChar).Value = Server.HtmlEncode(enddate);
               BIDCommand.Parameters.AddWithValue("@Expected_Members", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumberofBenficiries.Text);




               BIDCommand.Parameters.AddWithValue("@Initiative_ProjectCategory", SqlDbType.NVarChar).Value = Server.HtmlEncode(dpProjectCategory.SelectedItem.Text);


               BIDCommand.Parameters.AddWithValue("@Initiative_Impctofproject", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtImpctofproject.Text);


               BIDCommand.Parameters.AddWithValue("@Initiative_RoleofApplicant", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtRoleofApplicant.Text);


               BIDCommand.Parameters.AddWithValue("@Initiative_CatogoryandAge", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAgeFrom.Text + "-" + txtAgeTo.Text);




               BIDCommand.Parameters.AddWithValue("@Initiative_typeofActivity", SqlDbType.NVarChar).Value = Server.HtmlEncode(drpType.SelectedItem.Text);


               BIDCommand.Parameters.AddWithValue("@Initiative_volounteerInterest", SqlDbType.Int).Value = Server.HtmlEncode(RBVolounteer.SelectedItem.Value);

               BIDCommand.Parameters.AddWithValue("@fName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtFname.Text);
               BIDCommand.Parameters.AddWithValue("@mName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtMname.Text);
               BIDCommand.Parameters.AddWithValue("@tName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtThirdName.Text);
               BIDCommand.Parameters.AddWithValue("@lName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtsurname.Text);
               BIDCommand.Parameters.AddWithValue("@civilUser", SqlDbType.NVarChar).Value = civilpath;

               //BIDCommand.Parameters.AddWithValue("@applyType", SqlDbType.Int).Value = appy_type;


               BIDCommand.Parameters.AddWithValue("type", SqlDbType.NVarChar).Value = "Business";

               BIDCommand.Parameters.AddWithValue("@IID", SqlDbType.Int).Value = hBid.Value;



               //string userid = string.Empty;
               //if (Session["userid"] != null)
               //{
               //    userid = Session["userid"].ToString();
               //    userid = gfn.SessionDecrypt(userid, SHA512.Create().ToString());
               //    userid = userid.Substring(userid.IndexOf("&") + 1);

               //}
               //int id = int.Parse(userid);


               BIDCommand.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = hPid.Value;


               BIDCommand.Connection = cnn;


                DataSet ds = new DataSet();

               try
               {
                  

                   string query1 = "loadIntiativeValue";
                   SqlCommand cmd = new SqlCommand(query1, cnn);
                   cmd.CommandType = CommandType.StoredProcedure;

                   //DataTable dt = new DataTable();
                   cmd.Parameters.AddWithValue("@PID", SqlDbType.NVarChar).Value = hPid.Value;
                   cmd.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = hBid.Value;
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   cmd.ExecuteNonQuery();                  
                   da.Fill(ds);


                   BIDCommand.ExecuteNonQuery();
               }
               catch (Exception ex)
               {
                   Response.Write(ex.Message);

               }

               if (!hBid.Value.Equals("0"))
               {
                   cnn.Close();
                   AddAgency(hBid.Value);
                   insertGrid(hBid.Value);
                   insertMedia(hBid.Value);
                   insertBudget(hBid.Value);
                   insertSponser(hBid.Value);
                   insertExcutive(hBid.Value);

                   insertFile(hBid.Value);
                   insertFollowup(hBid.Value);

                   insertFieldsUpdated(hBid.Value, hPid.Value, ds);

                   Session["ini_admin"] = hAid.Value;
                   Session["ini_BID"] = hBid.Value;
                   Response.Redirect("ini_tahnkyou.aspx", true);
               }
               else
               {

                   alertEmail.Visible = true;
               }
           }
           catch (Exception ex)
           {
               Response.Write(ex.Message);
           }
       }
    }

    private void insertFieldsUpdated(string bid, string uid,DataSet ds)
    {

        if (ds.Tables.Count > 0)
        {
            SQLConnection2();

            SqlCommand cmdUpdate = new SqlCommand("sp_InitiativeFieldsUpdated_Highlight", cnn);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@UID", SqlDbType.NVarChar).Value = uid;
            cmdUpdate.Parameters.AddWithValue("@BID", SqlDbType.NVarChar).Value = bid;

            #region User and Initiative info, Files Uploaded Parameters

            //loadPersonel(ds.Tables[0]);
            if (ds.Tables[0].Rows.Count > 0)  //checking user information
            {
                string s = ds.Tables[0].Rows[0]["Name"].ToString();
                if (txtFname.Text != ds.Tables[0].Rows[0]["Name"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@FName", SqlDbType.Int).Value = 1;
                }
                if (txtMname.Text != ds.Tables[0].Rows[0]["Mname"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@MName", SqlDbType.Int).Value = 1;
                }
                if (txtThirdName.Text != ds.Tables[0].Rows[0]["TName"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@TName", SqlDbType.Int).Value = 1;
                }
                if (txtsurname.Text != ds.Tables[0].Rows[0]["Lname"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@LName", SqlDbType.Int).Value = 1;
                }
            }

            //******************************* Initiative information*********************************************

            //loadiniData(ds.Tables[1]);
            if (ds.Tables[1].Rows.Count > 0)  //checking Initiative information
            {
                string startdate = string.Empty;

                string enddate = string.Empty;
                string dob = string.Empty;

                if (!datepicker.Text.Equals(""))
                {
                    startdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(3, 2) + "/" + datepicker.Text.Substring(0, 2);

                }
                if (!txtend.Text.Equals(""))
                {
                    enddate = txtend.Text.Substring(6, 4) + "/" + txtend.Text.Substring(3, 2) + "/" + txtend.Text.Substring(0, 2);
                }

                if (!txtProjectName.Text.Equals(""))
                {
                    if (txtProjectName.Text != ds.Tables[1].Rows[0]["Initiative_ProjcetName"].ToString())
                    {
                        cmdUpdate.Parameters.AddWithValue("@initiative_name", SqlDbType.NVarChar).Value = 1;
                    }
                }
                else
                {
                    if (txtEventName.Text != ds.Tables[1].Rows[0]["Initiative_ProjcetName"].ToString())
                    {
                        cmdUpdate.Parameters.AddWithValue("@initiative_name", SqlDbType.NVarChar).Value = 1;
                    }
                }

                if (dpArea.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_Area"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_Type", SqlDbType.NVarChar).Value = 1;
                }
                if (txtProjectDetail.Text != ds.Tables[1].Rows[0]["Initiative_ProjectDetail"].ToString())
                {

                    cmdUpdate.Parameters.AddWithValue("@Initiative_Info", SqlDbType.NVarChar).Value = 1;
                }
                if (txtObjective.Text != ds.Tables[1].Rows[0]["Initiative_Objective"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Objectives", SqlDbType.NVarChar).Value = 1;
                }

                if (!txtPlaceofResidence.Text.Equals(""))
                {
                    if (txtPlaceofResidence.Text != ds.Tables[1].Rows[0]["Initiative_PlaceofResidence"].ToString())
                    {
                        cmdUpdate.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = 1;
                    }
                }
                else
                {
                    if (txtPlaceofResidence.Text != ds.Tables[1].Rows[0]["Initiative_PlaceofResidence"].ToString())
                    {
                        cmdUpdate.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = 1;
                    }
                }

                if (dpTargetSegment.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_Target"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Target_Group", SqlDbType.NVarChar).Value = 1;
                }
                if (startdate != ds.Tables[1].Rows[0]["Initiative_StratDate"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Establishment_Time", SqlDbType.NVarChar).Value = 1;
                }
                if (enddate != ds.Tables[1].Rows[0]["Initiative_EndDate"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Time_Period", SqlDbType.NVarChar).Value = 1;
                }
                if (txtNumberofBenficiries.Text != ds.Tables[1].Rows[0]["Initiative_NumberofBenficiries"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Expected_Members", SqlDbType.NVarChar).Value = 1;
                }
                if (dpProjectCategory.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_ProjectCategory"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_ProjectCategory", SqlDbType.NVarChar).Value = 1;
                }
                if (txtImpctofproject.Text != ds.Tables[1].Rows[0]["Initiative_Impctofproject"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_Impctofproject", SqlDbType.NVarChar).Value = 1;
                }
                if (txtRoleofApplicant.Text != ds.Tables[1].Rows[0]["Initiative_RoleofApplicant"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_RoleofApplicant", SqlDbType.NVarChar).Value = 1;
                }
                if ((txtAgeFrom.Text + "-" + txtAgeTo.Text) != ds.Tables[1].Rows[0]["Initiative_CatogoryandAge"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_CatogoryandAge", SqlDbType.NVarChar).Value = 1;
                }
                if (drpType.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_typeofActivity"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_typeofActivity", SqlDbType.NVarChar).Value = 1;
                }
                if (RBVolounteer.SelectedItem.Value != ds.Tables[1].Rows[0]["Initiative_volounteerInterest"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_volounteerInterest", SqlDbType.Int).Value = 1;
                }


                //******************************* Agency*********************************************

                int typeOfApply = 0;
                if (RBindivitual.Checked)
                    typeOfApply = 5;
                else if (RBForum.Checked)
                    typeOfApply = 1;

                if (RBIntiativeCatagory.SelectedItem.Text != ds.Tables[1].Rows[0]["Intiative_CatagoryType"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@Org_Type", SqlDbType.NVarChar).Value = 1;
                }
                if (typeOfApply.ToString() != ds.Tables[1].Rows[0]["Initiative_Type"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@TypeOfApply", SqlDbType.Int).Value = 1;
                }
                if (drpEduQulification.SelectedItem.Text != "--اختر--")
                {
                    if (drpEduQulification.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_EducationalQulification"].ToString())
                    {
                        cmdUpdate.Parameters.AddWithValue("@qualification", SqlDbType.NVarChar).Value = 1;
                    }
                }
                if (dpGovernarate.SelectedItem.Text != ds.Tables[1].Rows[0]["Initiative_Governarate"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = 1;
                }
                if (txtNameofInstitution.Text != ds.Tables[1].Rows[0]["Initiative_NameofInstituion"].ToString())
                {
                    cmdUpdate.Parameters.AddWithValue("@agency_name", SqlDbType.NVarChar).Value = 1;
                }


                //***************************************File*******************************************//


                if (fpCivilID.HasFile && divCivilID.Visible == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@Initiative_CivilID", SqlDbType.NVarChar).Value = 1;
                }

                if (fpAutorization.HasFile && div_authorization.Visible == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_Autorization", SqlDbType.NVarChar).Value = 1;
                }

                if (fpcivilpubicauthority.HasFile && div_civilid_publi_authority.Visible == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_civilpubicauthority", SqlDbType.NVarChar).Value = 1;
                }

                if (fpcivilidpublicpapper.HasFile && div_civilid_public_papper.Visible == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_civilidpublicpapper", SqlDbType.NVarChar).Value = 1;
                }
                if (txtBookApproval.HasFile)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_BookApproval", SqlDbType.NVarChar).Value = 1;
                }
                if (fpconferencewrkingpapper.HasFile && pnlFile.Visible == true)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_conferencewrkingpapper", SqlDbType.NVarChar).Value = 1;
                }
                if (txtCvofapplicant.HasFile)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_Cvofapplicant", SqlDbType.NVarChar).Value = 1;
                }
                if (fpexecutiveplan.HasFile)
                {
                    cmdUpdate.Parameters.AddWithValue("@Intiative_executiveplan", SqlDbType.NVarChar).Value = 1;
                }
            }

            #endregion

            cmdUpdate.Connection = cnn;
            cmdUpdate.ExecuteNonQuery();
            cnn.Close();


            #region Activity

            //loadActivity(ds.Tables[2]);
            if (ds.Tables[2].Rows.Count > 0)  //checking Activity
            {
                int i = 0;
                foreach (RepeaterItem item in rpDetails.Items)
                {
                    SQLConnection2();

                    HiddenField id = (HiddenField)item.FindControl("hddetailsID");
                    TextBox txtDate = (TextBox)item.FindControl("txtDate");
                    TextBox txtStartTime = (TextBox)item.FindControl("txtStartTime");
                    TextBox txtEndTime = (TextBox)item.FindControl("txtEndTime");
                    System.Web.UI.WebControls.FileUpload txtCv = (System.Web.UI.WebControls.FileUpload)item.FindControl("fbCv");
                    TextBox txtNameofSpeaker = (TextBox)item.FindControl("txtNameofSpeaker");
                    TextBox txtAddress = (TextBox)item.FindControl("txtAddress");
                    TextBox txtAxces = (TextBox)item.FindControl("txtAxces");
                    TextBox txtNumberofattendence = (TextBox)item.FindControl("txtNumberofattendence");
                    HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");

                    string filename = string.Empty;

                    if ((txtCv.PostedFile.ContentLength > 0) && (anchor.Visible == false))
                    {
                        filename = @"InitiativeFiles\" + bid.ToString() + "-" + "Civil-" + i + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtCv.PostedFile.FileName.ToString());
                        txtCv.PostedFile.SaveAs(Server.MapPath(filename));
                    }
                    else
                    {
                        filename = anchor.HRef;
                    }

                    string startdate = string.Empty;

                    if (!txtDate.Text.Equals(""))
                    {
                        startdate = txtDate.Text.ToString().Replace("-", "/");
                    }

                    if (txtDate.Text != "" || txtStartTime.Text != "")
                    {
                        int chkUpdate = 0;
                        SqlCommand cmdActivity = new SqlCommand("sp_InitiativeRepeaterFieldsUpdated_Highlight");
                        cmdActivity.CommandType = CommandType.StoredProcedure;

                        cmdActivity.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = Server.HtmlEncode(bid);
                        cmdActivity.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = uid;
                        cmdActivity.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = "tbl_IntiativeActivity";
                        cmdActivity.Parameters.AddWithValue("@RecordID", SqlDbType.Int).Value = Server.HtmlEncode(id.Value.TrimEnd('N'));

                        cmdActivity.Parameters.AddWithValue("@Field1Name", SqlDbType.NVarChar).Value = "Intiative_Date";
                        cmdActivity.Parameters.AddWithValue("@Field2Name", SqlDbType.NVarChar).Value = "Initiative_StartTime";
                        cmdActivity.Parameters.AddWithValue("@Field3Name", SqlDbType.NVarChar).Value = "Initiative_EndTime";
                        cmdActivity.Parameters.AddWithValue("@Field4Name", SqlDbType.NVarChar).Value = "Intiative_CV";
                        cmdActivity.Parameters.AddWithValue("@Field5Name", SqlDbType.NVarChar).Value = "Intiative_NameofSpeaker";
                        cmdActivity.Parameters.AddWithValue("@Field6Name", SqlDbType.NVarChar).Value = "Intiative_Address";
                        cmdActivity.Parameters.AddWithValue("@Field7Name", SqlDbType.NVarChar).Value = "Intiative_Acess";
                        cmdActivity.Parameters.AddWithValue("@Field8Name", SqlDbType.NVarChar).Value = "Intiative_NoAttendence";

                        if (!id.Value.Contains('N'))
                        {
                            string[] sd = ds.Tables[2].Rows[i]["txtDate"].ToString().Split(' ');
                            if (startdate != sd[0].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtStartTime.Text != ds.Tables[2].Rows[i]["txtStartTime"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtEndTime.Text != ds.Tables[2].Rows[i]["txtEndTime"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            //if (filename != ds.Tables[2].Rows[i]["txtCv"].ToString())
                             if (txtCv.HasFile)
                            {
                                cmdActivity.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtNameofSpeaker.Text != ds.Tables[2].Rows[i]["txtNameofSpeaker"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field5", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtAddress.Text != ds.Tables[2].Rows[i]["txtAddress"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field6", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtAxces.Text != ds.Tables[2].Rows[i]["txtAxces"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field7", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtNumberofattendence.Text != ds.Tables[2].Rows[i]["txtNumberofattendence"].ToString())
                            {
                                cmdActivity.Parameters.AddWithValue("@Field8", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                        }
                        else
                        {
                            cmdActivity.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field5", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field6", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field7", SqlDbType.Int).Value = 1;
                            cmdActivity.Parameters.AddWithValue("@Field8", SqlDbType.Int).Value = 1;
                            chkUpdate++;

                        }

                        if (chkUpdate > 0)
                        {
                            cmdActivity.Connection = cnn;
                            cmdActivity.ExecuteNonQuery();
                        }
                    }
                    cnn.Close();
                    i++;
                }
            }

            #endregion

            #region Budget
            //loadBudget(ds.Tables[3]);
            if (ds.Tables[3].Rows.Count > 0)  //checking Budget
            {
                int i = 0;
                foreach (RepeaterItem item in RPBudget.Items)
                {
                    SQLConnection2();


                    TextBox txtItem = (TextBox)item.FindControl("txtItem");
                    TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
                    TextBox txtCost = (TextBox)item.FindControl("txtCostBudget");
                    TextBox txtTotalcost = (TextBox)item.FindControl("txtTotalcost");
                    HiddenField id = (HiddenField)item.FindControl("hdBudgetID");

                    if (txtItem.Text != "" || txtNumber.Text != "")
                    {
                        int chkUpdate = 0;

                        SqlCommand MemberCommand = new SqlCommand("sp_InitiativeRepeaterFieldsUpdated_Highlight");
                        MemberCommand.CommandType = CommandType.StoredProcedure;

                        MemberCommand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = Server.HtmlEncode(bid);
                        MemberCommand.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = uid;
                        MemberCommand.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = "tbl_IntiativeBudget";
                        MemberCommand.Parameters.AddWithValue("@RecordID", SqlDbType.Int).Value = Server.HtmlEncode(id.Value.TrimEnd('N'));

                        MemberCommand.Parameters.AddWithValue("@Field1Name", SqlDbType.NVarChar).Value = "Initiative_Item";
                        MemberCommand.Parameters.AddWithValue("@Field2Name", SqlDbType.NVarChar).Value = "Intiative_Number";
                        MemberCommand.Parameters.AddWithValue("@Field3Name", SqlDbType.NVarChar).Value = "Intiative_Cost";
                        MemberCommand.Parameters.AddWithValue("@Field4Name", SqlDbType.NVarChar).Value = "Intiative_Totalcost";

                        if (!id.Value.Contains('N'))
                        {
                            if (txtItem.Text != ds.Tables[3].Rows[i]["txtItem"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtNumber.Text != ds.Tables[3].Rows[i]["txtNumber"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtCost.Text != ds.Tables[3].Rows[i]["txtCost"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtTotalcost.Text != ds.Tables[3].Rows[i]["txtTotalcost"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                        }
                        else
                        {
                            MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                            chkUpdate++;

                        }

                        if (chkUpdate > 0)
                        {
                            MemberCommand.Connection = cnn;
                            MemberCommand.ExecuteNonQuery();
                        }
                    }
                    cnn.Close();
                    i++;
                }
            }

            #endregion

            #region Executive

            //loadExecutive(ds.Tables[4]);
            if (ds.Tables[4].Rows.Count > 0)  //checking Executive
            {
                int i = 0;
                foreach (RepeaterItem item in RpExctuiveplan.Items)
                {
                    SQLConnection2();

                    TextBox txtActivityDate = (TextBox)item.FindControl("txtActivityDate");
                    TextBox txtActivity = (TextBox)item.FindControl("txtActivity");
                    HiddenField id = (HiddenField)item.FindControl("hdExecutiveID");

                    string ActivityDate = string.Empty;

                    if (!txtActivityDate.Text.Equals(""))
                    {
                        ActivityDate = txtActivityDate.Text.Substring(6, 4) + "/" + txtActivityDate.Text.Substring(3, 2) + "/" + txtActivityDate.Text.Substring(0, 2); 
                    }
                    if (txtActivityDate.Text != "" || txtActivity.Text != "")
                    {
                        int chkUpdate = 0;

                        SqlCommand MemberCommand = new SqlCommand("sp_InitiativeRepeaterFieldsUpdated_Highlight");
                        MemberCommand.CommandType = CommandType.StoredProcedure;

                        MemberCommand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = Server.HtmlEncode(bid);
                        MemberCommand.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = uid;
                        MemberCommand.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = "tbl_IntiativeExcutive";
                        MemberCommand.Parameters.AddWithValue("@RecordID", SqlDbType.Int).Value = Server.HtmlEncode(id.Value.TrimEnd('N'));

                        MemberCommand.Parameters.AddWithValue("@Field1Name", SqlDbType.NVarChar).Value = "Initiative_ActivityDate";
                        MemberCommand.Parameters.AddWithValue("@Field2Name", SqlDbType.NVarChar).Value = "Intiative_Activity";

                        if (!id.Value.Contains('N'))
                        {
                            string d = ds.Tables[4].Rows[i]["txtActivityDate"].ToString();
                            if (ActivityDate != ds.Tables[4].Rows[i]["txtActivityDate"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtActivity.Text != ds.Tables[4].Rows[i]["txtActivity"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                        }
                        else
                        {
                            MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                            chkUpdate++;
                        }
                        if (chkUpdate > 0)
                        {
                            MemberCommand.Connection = cnn;
                            MemberCommand.ExecuteNonQuery();
                        }
                    }
                    cnn.Close();
                    i++;
                }
            }

            #endregion

            #region Media
            //loadMedia(ds.Tables[6]);
            if (ds.Tables[6].Rows.Count > 0)  //checking Media
            {
                int i = 0;
                foreach (RepeaterItem item in RpMedia.Items)
                {
                    SQLConnection2();

                    TextBox txtPlace = (TextBox)item.FindControl("txtPlace");
                    TextBox txtNumberAdd = (TextBox)item.FindControl("txtNumberAdd");
                    TextBox txtAddDetails = (TextBox)item.FindControl("txtAddDetails");
                    TextBox txtCostDetails = (TextBox)item.FindControl("txtCostMedia");
                    HiddenField id = (HiddenField)item.FindControl("hdMediaID");

                    if (txtPlace.Text != "" || txtNumberAdd.Text != "")
                    {
                        int chkUpdate = 0;
                        SqlCommand MemberCommand = new SqlCommand("sp_InitiativeRepeaterFieldsUpdated_Highlight");
                        MemberCommand.CommandType = CommandType.StoredProcedure;

                        MemberCommand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = Server.HtmlEncode(bid);
                        MemberCommand.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = uid;
                        MemberCommand.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = "tbl_IntiativeMedia";
                        MemberCommand.Parameters.AddWithValue("@RecordID", SqlDbType.Int).Value = Server.HtmlEncode(id.Value.TrimEnd('N'));

                        MemberCommand.Parameters.AddWithValue("@Field1Name", SqlDbType.NVarChar).Value = "Initiative_Place";
                        MemberCommand.Parameters.AddWithValue("@Field2Name", SqlDbType.NVarChar).Value = "Intiative_NumberAdd";
                        MemberCommand.Parameters.AddWithValue("@Field3Name", SqlDbType.NVarChar).Value = "Intiative_AddDetails";
                        MemberCommand.Parameters.AddWithValue("@Field4Name", SqlDbType.NVarChar).Value = "Intiative_CostDetails";

                        if (!id.Value.Contains('N'))
                        {
                            if (txtPlace.Text != ds.Tables[6].Rows[i]["txtPlace"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtNumberAdd.Text != ds.Tables[6].Rows[i]["txtNumberAdd"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtAddDetails.Text != ds.Tables[6].Rows[i]["txtAddDetails"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtCostDetails.Text != ds.Tables[6].Rows[i]["txtCostDetails"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }

                        }
                        else
                        {
                            MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field4", SqlDbType.Int).Value = 1;
                            chkUpdate++;
                        }
                        if (chkUpdate > 0)
                        {
                            MemberCommand.Connection = cnn;
                            MemberCommand.ExecuteNonQuery();
                        }
                    }
                    cnn.Close();
                    i++;
                }
            }

            #endregion

            #region Sponser

            //loadSponser(ds.Tables[7]);
            if (ds.Tables[7].Rows.Count > 0)  //checking Sponser
            {
                int i = 0;
                foreach (RepeaterItem item in rpSponser.Items)
                {
                    SQLConnection2();

                    TextBox txtSponserName = (TextBox)item.FindControl("txtSponserName");
                    TextBox txtTypeCare = (TextBox)item.FindControl("txtTypeCare");
                    TextBox txtCareDetails = (TextBox)item.FindControl("txtCareDetails");
                    HiddenField id = (HiddenField)item.FindControl("hdSponsorID");

                    if (txtSponserName.Text != "" || txtTypeCare.Text != "")
                    {
                        int chkUpdate = 0;
                        SqlCommand MemberCommand = new SqlCommand("sp_InitiativeRepeaterFieldsUpdated_Highlight");
                        MemberCommand.CommandType = CommandType.StoredProcedure;

                        MemberCommand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = Server.HtmlEncode(bid);
                        MemberCommand.Parameters.AddWithValue("@UID", SqlDbType.Int).Value = uid;
                        MemberCommand.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = "tbl_IntiativeSponser";
                        MemberCommand.Parameters.AddWithValue("@RecordID", SqlDbType.Int).Value = Server.HtmlEncode(id.Value.TrimEnd('N'));

                        MemberCommand.Parameters.AddWithValue("@Field1Name", SqlDbType.NVarChar).Value = "Initiative_SponserName";
                        MemberCommand.Parameters.AddWithValue("@Field2Name", SqlDbType.NVarChar).Value = "Intiative_TypeCare";
                        MemberCommand.Parameters.AddWithValue("@Field3Name", SqlDbType.NVarChar).Value = "Intiative_CareDetails";

                        if (!id.Value.Contains('N'))
                        {
                            if (txtSponserName.Text != ds.Tables[7].Rows[i]["txtSponserName"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtTypeCare.Text != ds.Tables[7].Rows[i]["txtTypeCare"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                            if (txtCareDetails.Text != ds.Tables[7].Rows[i]["txtCareDetails"].ToString())
                            {
                                MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                                chkUpdate++;
                            }
                        }
                        else
                        {
                            MemberCommand.Parameters.AddWithValue("@Field1", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field2", SqlDbType.Int).Value = 1;
                            MemberCommand.Parameters.AddWithValue("@Field3", SqlDbType.Int).Value = 1;
                            chkUpdate++;
                        }

                        if (chkUpdate > 0)
                        {
                            MemberCommand.Connection = cnn;
                            MemberCommand.ExecuteNonQuery();
                        }
                    }
                    cnn.Close();
                    i++;
                }
            }

            #endregion

        }
    }


    private void insertFollowup(string bid)
    {
        string message = "تم التعديل على البيانات من قبل مقدم الطلب";
        SqlCommand comand = new SqlCommand("InitiativeFollowUpComments");
        SQLConnection2();
        comand.CommandType = CommandType.StoredProcedure;
        comand.Parameters.AddWithValue("@u_id", SqlDbType.Int).Value = hAid.Value; // Session["userid"];
        comand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = bid;
        comand.Parameters.AddWithValue("@message", SqlDbType.NVarChar).Value = message;
        comand.Parameters.AddWithValue("@postdate", SqlDbType.DateTime).Value = DateTime.Now;
        comand.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Active";
        comand.Connection = cnn;
        comand.ExecuteNonQuery();
        cnn.Close();

    }
    private void AddAgency(string bid)
    {
        cnn.Open();

        int typeOfApply = 0;
        if (RBindivitual.Checked)
            typeOfApply = 5;
        else if (RBForum.Checked)
            typeOfApply = 1;

        string qualifcn = "";
        if (drpEduQulification.SelectedItem.Text != "--اختر--")
        {
            qualifcn = drpEduQulification.SelectedItem.Text;
        }
        SqlCommand FileCommand = new SqlCommand("InitiativeInfo_Update", cnn);
        FileCommand.CommandType = CommandType.StoredProcedure;


        FileCommand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "Agency";
        if (string.IsNullOrEmpty(bid))
            FileCommand.Parameters.AddWithValue("@IID", DBNull.Value).Value = "";
        else
            FileCommand.Parameters.AddWithValue("IID", SqlDbType.Int).Value = bid;
        FileCommand.Parameters.AddWithValue("@org", SqlDbType.NVarChar).Value = Server.HtmlEncode(RBIntiativeCatagory.SelectedItem.Text);
        FileCommand.Parameters.AddWithValue("@TypeOfApply", SqlDbType.Int).Value = typeOfApply;
        if (drpEduQulification.SelectedItem.Text != "--اختر--")
        {
            qualifcn = drpEduQulification.SelectedItem.Text;
        }
        FileCommand.Parameters.AddWithValue("@qualification", SqlDbType.NVarChar).Value = Server.HtmlEncode(qualifcn);
        FileCommand.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = Server.HtmlEncode(dpGovernarate.SelectedItem.Text);
        if (string.IsNullOrEmpty(txtNameofInstitution.Text))
            FileCommand.Parameters.AddWithValue("@agency", DBNull.Value).Value = "";
        else
            FileCommand.Parameters.AddWithValue("@agency", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNameofInstitution.Text);
        // user table 
        FileCommand.Parameters.AddWithValue("@fName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtFname.Text);
        FileCommand.Parameters.AddWithValue("@mName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtMname.Text);
        FileCommand.Parameters.AddWithValue("@tName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtThirdName.Text);
        FileCommand.Parameters.AddWithValue("@lName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtsurname.Text);
      

       
        FileCommand.ExecuteNonQuery();

        
        cnn.Close();
    }
    private void insertFile(string memberID)
    {
        SQLConnection2();
        string CivilID = null;
        string Autorization = null;
        string civilpubicauthority = null;
        string civilidpublicpapper = null;
        string BookApproval = null;
        string conferencewrkingpapper = null;
        string Cvofapplicant = null;
        string executiveplan = null;



        if (divCivilID.Visible)
        {
            if (fpCivilID.HasFile && fpCivilID_a.Visible == false)
            {
                CivilID = @"InitiativeFiles\" + memberID.ToString() + "-" + "Civil-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpCivilID.PostedFile.FileName.ToString());

            }
            else
                CivilID = fpCivilID_a.HRef;
        }
        else
            CivilID = "";

        if (div_authorization.Visible)
        {
            if (fpAutorization.HasFile && fpAutorization_a.Visible == false)
            {
                Autorization = @"InitiativeFiles\" + memberID.ToString() + "-" + "Autorization-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpAutorization.PostedFile.FileName.ToString());
            }
            else
                Autorization = fpAutorization_a.HRef;
        }
        else
            Autorization = "";



        if (div_civilid_publi_authority.Visible)
        {
            if (fpcivilpubicauthority.HasFile && fpcivilpubicauthority_a.Visible == false)
            {
                civilpubicauthority = @"InitiativeFiles\" + memberID.ToString() + "-" + "pubicauthority-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpcivilpubicauthority.PostedFile.FileName.ToString());
            }
            else
                civilpubicauthority = fpcivilpubicauthority_a.HRef;
        }
        else
            civilpubicauthority = "";



        if (div_civilid_public_papper.Visible)
        {
            if (fpcivilidpublicpapper.HasFile && fpcivilidpublicpapper_a.Visible == false)
            {
                civilidpublicpapper = @"InitiativeFiles\" + memberID.ToString() + "-" + "civilidpublicpapper-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpcivilidpublicpapper.PostedFile.FileName.ToString());

            }
            else
                civilidpublicpapper = fpcivilidpublicpapper_a.HRef;
        }
        else
            civilidpublicpapper = "";


        if (txtBookApproval.HasFile && txtBookApproval_a.Visible == false)
        {
            BookApproval = @"InitiativeFiles\" + memberID.ToString() + "-" + "BookApproval-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtBookApproval.PostedFile.FileName.ToString());
        }
        else
            BookApproval = txtBookApproval_a.HRef;



        if (pnlFile.Visible)
        {
            if (fpconferencewrkingpapper.HasFile && fpconferencewrkingpapper_a.Visible == false)
            {

                conferencewrkingpapper = @"InitiativeFiles\" + memberID.ToString() + "-" + "conferencewrkingpapper-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpconferencewrkingpapper.PostedFile.FileName.ToString());
            }
            else
                conferencewrkingpapper = fpconferencewrkingpapper_a.HRef;
        }
        else
            conferencewrkingpapper = "";


        if (txtCvofapplicant.HasFile && txtCvofapplicant_a.Visible == false)
        {
            Cvofapplicant = @"InitiativeFiles\" + memberID.ToString() + "-" + "Cvofapplicant-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtCvofapplicant.PostedFile.FileName.ToString());

        }
        else
            Cvofapplicant = txtCvofapplicant_a.HRef;



        if (fpexecutiveplan.HasFile && fpexecutiveplan_a.Visible == false)
        {

            executiveplan = @"InitiativeFiles\" + memberID.ToString() + "-" + "ExecutivePlan-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpexecutiveplan.PostedFile.FileName.ToString());
        }
        else
            executiveplan = fpexecutiveplan_a.HRef;
       



        SqlCommand FileCommand = new SqlCommand("sp_InitiativeFileUpdate", cnn);
        FileCommand.CommandType = CommandType.StoredProcedure;
        FileCommand.Parameters.AddWithValue("@IID", SqlDbType.Int).Value = memberID;
        FileCommand.Parameters.AddWithValue("@Initiative_CivilID", SqlDbType.NVarChar).Value = CivilID;
        FileCommand.Parameters.AddWithValue("@Intiative_Autorization", SqlDbType.NVarChar).Value = Autorization;
        FileCommand.Parameters.AddWithValue("@Intiative_civilpubicauthority", SqlDbType.NVarChar).Value = civilpubicauthority;
        FileCommand.Parameters.AddWithValue("@Intiative_civilidpublicpapper", SqlDbType.NVarChar).Value = civilidpublicpapper;
        FileCommand.Parameters.AddWithValue("@Intiative_BookApproval", SqlDbType.NVarChar).Value = BookApproval;
        FileCommand.Parameters.AddWithValue("@Intiative_conferencewrkingpapper", SqlDbType.NVarChar).Value = conferencewrkingpapper;
        FileCommand.Parameters.AddWithValue("@Intiative_Cvofapplicant", SqlDbType.NVarChar).Value = Cvofapplicant;
        FileCommand.Parameters.AddWithValue("@Intiative_executiveplan", SqlDbType.NVarChar).Value = executiveplan;

        var returnParameter = FileCommand.Parameters.Add("@retVal", SqlDbType.NVarChar);
        returnParameter.Direction = ParameterDirection.Output;

        returnParameter.Size = 100;
        FileCommand.ExecuteNonQuery();

        string message = (string)FileCommand.Parameters["@retVal"].Value;
        if (message == "1")        
        {

            if (fpCivilID.HasFile && divCivilID.Visible == true) //1
            {

                fpCivilID.PostedFile.SaveAs(Server.MapPath(CivilID));
                //fileUploadSucessInfo(fpCivilID, "civil", oprCivilIdPath);

            }
            //else
            //    filedel(fpCivilID_a.HRef);


            if (fpAutorization.HasFile && div_authorization.Visible == true) //2
            {

                fpAutorization.PostedFile.SaveAs(Server.MapPath(Autorization));
                // fileUploadSucessInfo(updOther, "civil", oprDocfilePath);

            }
            //else
            //    filedel(fpAutorization_a.HRef);


            if (fpcivilpubicauthority.HasFile && div_civilid_publi_authority.Visible == true) //3
            {

                fpcivilpubicauthority.PostedFile.SaveAs(Server.MapPath(civilpubicauthority));
                //fileUploadSucessInfo(updCourse1, "pdf", Upload_CoursePath1);

            }
            //else
            //    filedel(fpcivilpubicauthority_a.HRef);


            if (fpcivilidpublicpapper.HasFile && div_civilid_public_papper.Visible == true) //4
            {


                fpcivilidpublicpapper.PostedFile.SaveAs(Server.MapPath(civilidpublicpapper));
                //  fileUploadSucessInfo(updReward1, "pdf", Upload_RewardPath1);

            }
            //else
            //    filedel(fpcivilidpublicpapper_a.HRef);


            if (txtBookApproval.HasFile) //5
            {
                

                txtBookApproval.PostedFile.SaveAs(Server.MapPath(BookApproval));
                //fileUploadSucessInfo(updReward2, "pdf", Upload_RewardPath2);

            }
            if (fpconferencewrkingpapper.HasFile && pnlFile.Visible == true) //6
            {
                fpconferencewrkingpapper.PostedFile.SaveAs(Server.MapPath(conferencewrkingpapper));
                //fileUploadSucessInfo(updReward2, "pdf", Upload_RewardPath2);

            }
            //else
            //    filedel(fpconferencewrkingpapper_a.HRef);


            if (txtCvofapplicant.HasFile)
            {
                
                txtCvofapplicant.PostedFile.SaveAs(Server.MapPath(Cvofapplicant));
                //fileUploadSucessInfo(updReward2, "pdf", Upload_RewardPath2);

            }
            if (fpexecutiveplan.HasFile)
            {
                fpexecutiveplan.PostedFile.SaveAs(Server.MapPath(executiveplan));
            }

        }

        cnn.Close();


    }

    private void filedel(string file)
    {
        string fileName = Server.MapPath(file);

        if (System.IO.File.Exists(fileName))
        {
            try
            {
                System.IO.File.Delete(fileName);
            }


            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }


   
  
    private void insertGrid(string memberID)
    {
        if (drpType.SelectedItem.Text.Equals("أخرى"))
        {
            int id = int.Parse(memberID);
            DeleteRow(id, "updatestatus");
        }
        else
        {
            int i = 0;
            foreach (RepeaterItem item in rpDetails.Items)
            {
                SQLConnection2();
                HiddenField id = (HiddenField)item.FindControl("hddetailsID");
                TextBox txtDate = (TextBox)item.FindControl("txtDate");
                TextBox txtStartTime = (TextBox)item.FindControl("txtStartTime");
                TextBox txtEndTime = (TextBox)item.FindControl("txtEndTime");
                System.Web.UI.WebControls.FileUpload txtCv = (System.Web.UI.WebControls.FileUpload)item.FindControl("fbCv");
                TextBox txtNameofSpeaker = (TextBox)item.FindControl("txtNameofSpeaker");
                TextBox txtAddress = (TextBox)item.FindControl("txtAddress");
                TextBox txtAxces = (TextBox)item.FindControl("txtAxces");
                TextBox txtNumberofattendence = (TextBox)item.FindControl("txtNumberofattendence");

                HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");


                string filename = string.Empty;

                if ((txtCv.PostedFile.ContentLength > 0) && (anchor.Visible == false))
                {
                    filename = @"InitiativeFiles\" + memberID.ToString() + "-" + "Civil-" + i + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtCv.PostedFile.FileName.ToString());

                    txtCv.PostedFile.SaveAs(Server.MapPath(filename));
                    i++;
                }
                else
                {

                    filename = anchor.HRef;
                    i++;
                }

                string startdate = string.Empty;

                if (!txtDate.Text.Equals(""))
                {
                    startdate = txtDate.Text.Substring(6, 4) + "/" + txtDate.Text.Substring(3, 2) + "/" + txtDate.Text.Substring(0, 2);

                }

                if (txtDate.Text != "" || txtStartTime.Text != "")
                {
                    SqlCommand MemberCommand = new SqlCommand("sp_InitiativeActivityEdit");
                    MemberCommand.CommandType = CommandType.StoredProcedure;
                    MemberCommand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "Activity";
                    MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                    MemberCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Server.HtmlEncode(id.Value);
                    MemberCommand.Parameters.AddWithValue("@Intiative_Date", SqlDbType.Date).Value = Server.HtmlEncode(startdate);
                    MemberCommand.Parameters.AddWithValue("@Initiative_StartTime", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtStartTime.Text);
                    MemberCommand.Parameters.AddWithValue("@Initiative_EndTime", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEndTime.Text);
                    MemberCommand.Parameters.AddWithValue("@Intiative_CV", SqlDbType.NVarChar).Value = Server.HtmlEncode(filename);
                    MemberCommand.Parameters.AddWithValue("@Intiative_NameofSpeaker", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNameofSpeaker.Text);
                    MemberCommand.Parameters.AddWithValue("@Intiative_Address", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAddress.Text);
                    MemberCommand.Parameters.AddWithValue("@Intiative_Acess", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAxces.Text);
                    MemberCommand.Parameters.AddWithValue("@Intiative_NoAttendence", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumberofattendence.Text);


                    MemberCommand.Parameters.Add("@insertID", SqlDbType.Int, 0, "id");
                    MemberCommand.Parameters["@insertID"].Direction = ParameterDirection.Output;

                    MemberCommand.Connection = cnn;
                    MemberCommand.ExecuteNonQuery().ToString();

                    string MemberBID = MemberCommand.Parameters["@insertID"].Value.ToString();
                    if (MemberBID != "")
                        id.Value = MemberBID + "N";


                }
                cnn.Close();

            }
        }
    }

    private void insertMedia(string memberID)
    {

        foreach (RepeaterItem item in RpMedia.Items)
        {
            SQLConnection2();
            TextBox txtPlace = (TextBox)item.FindControl("txtPlace");

            TextBox txtNumberAdd = (TextBox)item.FindControl("txtNumberAdd");
            TextBox txtAddDetails = (TextBox)item.FindControl("txtAddDetails");
            TextBox txtCostDetails = (TextBox)item.FindControl("txtCostMedia");
            HiddenField id = (HiddenField)item.FindControl("hdMediaID");



            if (txtPlace.Text != "" || txtNumberAdd.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeMediaEdit");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Server.HtmlEncode(id.Value);
                MemberCommand.Parameters.AddWithValue("@Initiative_Place", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtPlace.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_NumberAdd", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumberAdd.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_AddDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAddDetails.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_CostDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCostDetails.Text);


                MemberCommand.Parameters.Add("@insertID", SqlDbType.Int, 0, "id");
                MemberCommand.Parameters["@insertID"].Direction = ParameterDirection.Output;

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery().ToString();

                string MemberBID = MemberCommand.Parameters["@insertID"].Value.ToString();
                if (MemberBID != "")
                    id.Value = MemberBID + "N";
            }
            cnn.Close();

        }
    }
    private void insertExcutive(string memberID)
    {
        //Excutive plan

        foreach (RepeaterItem item in RpExctuiveplan.Items)
        {
            SQLConnection2();
            TextBox txtActivityDate = (TextBox)item.FindControl("txtActivityDate");
            TextBox txtActivity = (TextBox)item.FindControl("txtActivity");
            HiddenField id = (HiddenField)item.FindControl("hdExecutiveID");

            string ActivityDate = string.Empty;

            if (!txtActivityDate.Text.Equals(""))
            {
                ActivityDate = txtActivityDate.Text.Substring(6, 4) + "/" + txtActivityDate.Text.Substring(3, 2) + "/" + txtActivityDate.Text.Substring(0, 2); 
            }
            if (txtActivityDate.Text != "" || txtActivity.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeExcutiveEdit");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Server.HtmlEncode(id.Value);
                MemberCommand.Parameters.AddWithValue("@Initiative_ActivityDate", SqlDbType.Date).Value = Server.HtmlEncode(ActivityDate);
                MemberCommand.Parameters.AddWithValue("@Intiative_Activity", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtActivity.Text);

                MemberCommand.Parameters.Add("@insertID", SqlDbType.Int, 0, "id");
                MemberCommand.Parameters["@insertID"].Direction = ParameterDirection.Output;

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery().ToString();

                string MemberBID = MemberCommand.Parameters["@insertID"].Value.ToString();
                if (MemberBID != "")
                    id.Value = MemberBID + "N";
            }
            cnn.Close();

        }
    }
    private void insertBudget(string memberID)
    {

        foreach (RepeaterItem item in RPBudget.Items)
        {
            SQLConnection2();

            TextBox txtItem = (TextBox)item.FindControl("txtItem");
            TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
            TextBox txtCost = (TextBox)item.FindControl("txtCostBudget");
            TextBox txtTotalcost = (TextBox)item.FindControl("txtTotalcost");
            HiddenField id = (HiddenField)item.FindControl("hdBudgetID");



            if (txtItem.Text != "" || txtNumber.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeBudgetEdit");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Server.HtmlEncode(id.Value);
                MemberCommand.Parameters.AddWithValue("@Initiative_Item", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtItem.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Number", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumber.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Cost", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCost.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Totalcost", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTotalcost.Text);


                MemberCommand.Parameters.Add("@insertID", SqlDbType.Int, 0, "id");
                MemberCommand.Parameters["@insertID"].Direction = ParameterDirection.Output;

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery().ToString();

                string MemberBID = MemberCommand.Parameters["@insertID"].Value.ToString();
                if (MemberBID != "")
                    id.Value = MemberBID + "N";
            }
            cnn.Close();

        }
    }



    private void insertSponser(string memberID)
    {

        foreach (RepeaterItem item in rpSponser.Items)
        {
            SQLConnection2();

            TextBox txtSponserName = (TextBox)item.FindControl("txtSponserName");

            TextBox txtTypeCare = (TextBox)item.FindControl("txtTypeCare");
            TextBox txtCareDetails = (TextBox)item.FindControl("txtCareDetails");
            HiddenField id = (HiddenField)item.FindControl("hdSponsorID");


            if (txtSponserName.Text != "" || txtTypeCare.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeSponserEdit");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Server.HtmlEncode(id.Value);
                MemberCommand.Parameters.AddWithValue("@Initiative_SponserName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtSponserName.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_TypeCare", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTypeCare.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_CareDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCareDetails.Text);

                MemberCommand.Parameters.Add("@insertID", SqlDbType.Int, 0, "id");
                MemberCommand.Parameters["@insertID"].Direction = ParameterDirection.Output;

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery().ToString();

                string MemberBID = MemberCommand.Parameters["@insertID"].Value.ToString();
                if (MemberBID != "")
                    id.Value = MemberBID + "N";
            }
            cnn.Close();

        }
    }

    protected void datepicker_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(datepicker.Text) && Regex.IsMatch(datepicker.Text, @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$") == true)
        {
            lblage.Visible = false;
            string dob = datepicker.Text;
            string startdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(3, 2) + "/" + datepicker.Text.Substring(0, 2);
            DateTime dteThen = DateTime.Parse(startdate);
            TimeSpan difference = dteThen - DateTime.Now;
            var days = difference.TotalDays;
            if (days < 45)
            {
                lblage.Visible = true;
                datepicker.Text = "";
            }
        }
        else
        {
            lblage.Visible = false;
            RegularExpressionValidator9.ValidationExpression = @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$";
            RegularExpressionValidator9.Validate();
        }
    }
    protected void dpTargetSegment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dpTargetSegment.SelectedIndex == 1)
        {
            lblCatagory.Text = "الفئة العمرية (من 14 إلى 35 سنة)";
        }
        else if (dpTargetSegment.SelectedIndex == 2)
        {
            lblCatagory.Text = "الفئة العمرية";
        }
    }

    protected void txtActivityDate_TextChanged(object sender, EventArgs e)
    {

        string ini_startdate = string.Empty;
        String ini_excu_plan = string.Empty;


        DateTime startDate = DateTime.Now;

        DateTime ini_excu_plan_date = DateTime.Now;

        TextBox tb1 = ((TextBox)(sender));
        RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
        TextBox tb2 = (TextBox)rp1.FindControl("txtActivityDate");

        Label vald = (Label)rp1.FindControl("lblMessage");

        if (!String.IsNullOrEmpty(datepicker.Text) && Regex.IsMatch(datepicker.Text, @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$") == true)
        {
            ini_startdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(3, 2) + "/" + datepicker.Text.Substring(0, 2);
            startDate = DateTime.Parse(ini_startdate);
        }

        if (!String.IsNullOrEmpty(tb2.Text) && Regex.IsMatch(tb2.Text, @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$") == true)
        {
            ini_excu_plan = tb2.Text.Substring(6, 4) + "/" + tb2.Text.Substring(3, 2) + "/" + tb2.Text.Substring(0, 2);
            ini_excu_plan_date = DateTime.Parse(ini_excu_plan);
        }

        if (!tb2.Text.Equals(""))
        {
            DateTime exc_date = DateTime.Parse(ini_excu_plan);
            TimeSpan difference = exc_date - startDate;
            var days = difference.TotalDays;
            if (days < 0)
            {

                vald.Visible = true;
                tb2.Text = "";
            }
            else
            {
                vald.Visible = false;
            }

        }


    }

    int val = 0;
    protected void txtCostBudget_TextChanged(object sender, EventArgs e)
    {

        TextBox tb1 = ((TextBox)(sender));
        RepeaterItem rpBudget = ((RepeaterItem)(tb1.NamingContainer));
        TextBox txtBudgetNumber = (TextBox)rpBudget.FindControl("txtNumber");
        TextBox txtBudgetCost = (TextBox)rpBudget.FindControl("txtCostBudget");
        TextBox txtBudgetTotalCost = (TextBox)rpBudget.FindControl("txtTotalcost");

        if (!String.IsNullOrEmpty(txtBudgetNumber.Text) && Regex.IsMatch(txtBudgetNumber.Text, @"^\d+?$") == true)
        {
            if (!String.IsNullOrEmpty(txtBudgetCost.Text) && Regex.IsMatch(txtBudgetCost.Text, @"^\d+?$") == true)
            {

                calculateBudget();
            }
            else
            {

                txtBudgetTotalCost.Text = "";
                txtBudgetTotalCost.Text = "";
            }

        }
        else
        {
            txtBudgetNumber.Text = "";
        }

    }
    public void calculateBudget()
    {

        int total = 0;

        foreach (RepeaterItem item in RPBudget.Items)
        {
            TextBox txtNumber = (TextBox)item.FindControl("txtNumber");
            TextBox txtCost = (TextBox)item.FindControl("txtCostBudget");
            TextBox txtTotalcost = (TextBox)item.FindControl("txtTotalcost");

            RequiredFieldValidator RequiredFieldValidator26 = (RequiredFieldValidator)item.FindControl("RequiredFieldValidator26");
            RequiredFieldValidator RequiredFieldValidator27 = (RequiredFieldValidator)item.FindControl("RequiredFieldValidator8");

            string value = string.Empty;
            int i = 0;
            if (!String.IsNullOrEmpty(txtNumber.Text) && Regex.IsMatch(txtNumber.Text, @"^\d+?$") == true)
            {
                if (!String.IsNullOrEmpty(txtCost.Text) && Regex.IsMatch(txtCost.Text, @"^\d+?$") == true)
                {

                    i = int.Parse(txtNumber.Text) * int.Parse(txtCost.Text);
                    value = i.ToString();
                    total = total + i;
                    txtTotalFinalcost.Text = "الإجمالي :" + total.ToString();
                    txtTotalcost.Text = value;
                }
                else
                {
                    txtCost.Text = "";
                    RequiredFieldValidator27.Enabled = true;
                }
            }
            else
            {
                txtNumber.Text = "";
                RequiredFieldValidator26.Enabled = true;
            }
        }
    }

    int value = 0;
    protected void txtCostMedia_TextChanged(object sender, EventArgs e)
    {
        TextBox tb1 = ((TextBox)(sender));
        RepeaterItem rpMedia = ((RepeaterItem)(tb1.NamingContainer));
        TextBox txtMediaCost = (TextBox)rpMedia.FindControl("txtCostMedia");

        if (!String.IsNullOrEmpty(txtMediaCost.Text) && Regex.IsMatch(txtMediaCost.Text, @"^\d+?$") == true)
        {

            value = int.Parse(txtMediaCost.Text);
            if (!txtToalCostMedia.Text.Equals(""))
            {
                int index = txtToalCostMedia.Text.IndexOf(":") + 1;
                string piece = txtToalCostMedia.Text.Substring(index);
                int count = int.Parse(piece) + val;
                txtToalCostMedia.Text = "الإجمالي:" + count.ToString();
            }
            else
                txtToalCostMedia.Text = "الإجمالي:" + value.ToString();

        }
        else
        {
            txtMediaCost.Text = "";

        }



    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        string ini_startdate = string.Empty;
        String ini_excu_plan = string.Empty;


        DateTime startDate = DateTime.Now;

        DateTime ini_excu_plan_date = DateTime.Now;

        TextBox tb1 = ((TextBox)(sender));
        RepeaterItem rp1 = ((RepeaterItem)(tb1.NamingContainer));
        TextBox tb2 = (TextBox)rp1.FindControl("txtDate");

        Label vald = (Label)rp1.FindControl("lblDetailsMessage");

        if (!String.IsNullOrEmpty(datepicker.Text) && Regex.IsMatch(datepicker.Text, @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$") == true)
        {
            ini_startdate = datepicker.Text.Substring(6, 4) + "/" + datepicker.Text.Substring(3, 2) + "/" + datepicker.Text.Substring(0, 2);
            startDate = DateTime.Parse(ini_startdate);
        }

        if (!String.IsNullOrEmpty(tb2.Text) && Regex.IsMatch(tb2.Text, @"^[0-3]?[0-9](/|-)[0-1]?[0-9](/|-)[1-2][0-9][0-9][0-9]$") == true)
        {
            ini_excu_plan = tb2.Text.Substring(6, 4) + "/" + tb2.Text.Substring(3, 2) + "/" + tb2.Text.Substring(0, 2);
            ini_excu_plan_date = DateTime.Parse(ini_excu_plan);
        }

        if (!tb2.Text.Equals(""))
        {
            DateTime exc_date = DateTime.Parse(ini_excu_plan);
            TimeSpan difference = exc_date - startDate;
            var days = difference.TotalDays;
            if (days < 0)
            {

                vald.Visible = true;
                tb2.Text = "";
            }
            else
            {
                vald.Visible = false;
            }



        }
    }

    public void DeleteRow(int id,string type)
    {
        SQLConnection2();
        string query= "sp_InitiativeDelete";
        SqlCommand cmd = new SqlCommand(query, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IID", SqlDbType.Int).Value = hBid.Value;
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
        cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
        cmd.ExecuteNonQuery();
        cnn.Close();
            
    }


    protected void lnkExcutiveCanecl_Click(object sender, EventArgs e)
    {
        PopulateExecutiveDataTable();

        if (ExcutiveTable.Rows.Count > 1)
        {
            string id1 = ExcutiveTable.Rows[ExcutiveTable.Rows.Count - 1]["id"].ToString();
            string confirmValue = hdConfirmation.Value;
            if (confirmValue == "Yes")
            {
                if (id1 != "")
                {
                    int id = int.Parse(id1);
                    DeleteRow(id, "Excutive");
                }
                ExcutiveTable.Rows[ExcutiveTable.Rows.Count - 1].Delete();
            }
        }

        if (ExcutiveTable.Rows.Count == 1)
        {
            lnkExcutiveCanecl.Visible = false;
        }

        BindExcutive();



    }
    protected void lnkDetailCancel_Click(object sender, EventArgs e)
    {

        PopulateDataTable();

        if (myTable.Rows.Count > 1)
        {
            string id1 = myTable.Rows[myTable.Rows.Count - 1]["id"].ToString();

            string confirmValue = hdConfirmation.Value;
            if (confirmValue == "Yes")
            {
                if (id1 != "")
                {
                    foreach (RepeaterItem item in rpDetails.Items)
                    {
                        HiddenField hd = (HiddenField)item.FindControl("hddetailsID");
                        HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");
                        if (id1 == hd.Value)
                        {
                            filedel(anchor.HRef);
                        }
                    }

                    int id = int.Parse(id1);
                    DeleteRow(id, "Activity");
                }

                myTable.Rows[myTable.Rows.Count - 1].Delete();
            }

        }

        if (myTable.Rows.Count == 1)
        {
            lnkDetailCancel.Visible = false;
        }




        Bind();
    }
    protected void lnkMediaCancel_Click(object sender, EventArgs e)
    {
        PopulateMediaDataTable();

        if (MediaTable.Rows.Count > 1)
        {
            string id1 = MediaTable.Rows[MediaTable.Rows.Count - 1]["id"].ToString();
            string confirmValue = hdConfirmation.Value;
            if (confirmValue == "Yes")
            {
                if (id1 != "")
                {
                    int id = int.Parse(id1);
                    DeleteRow(id, "Media");
                }
                MediaTable.Rows[MediaTable.Rows.Count - 1].Delete();
            }
        }

        if (MediaTable.Rows.Count == 1)
        {
            lnkMediaCancel.Visible = false;
        }

        BindMedia();
    }
    protected void lnkBugetCancel_Click(object sender, EventArgs e)
    {

        PopulateBudgetDataTable();
        if (BudgetTable.Rows.Count > 1)
        {
            string id1 = BudgetTable.Rows[BudgetTable.Rows.Count - 1]["id"].ToString();
            string confirmValue = hdConfirmation.Value;
            if (confirmValue == "Yes")
            {
                if (id1 != "")
                {
                    int id = int.Parse(id1);
                    DeleteRow(id, "Budget");
                }
                BudgetTable.Rows[BudgetTable.Rows.Count - 1].Delete();
            }

        }

        if (BudgetTable.Rows.Count == 1)
        {
            lnkBugetCancel.Visible = false;
        }

        BindBudget();
        calculateBudget();
    }
    protected void lnkSponserCanel_Click(object sender, EventArgs e)
    {
        PopulateSponserDataTable();


        if (SponserTable.Rows.Count > 1)
        {
            string id1 = SponserTable.Rows[SponserTable.Rows.Count - 1]["id"].ToString();
            string confirmValue = hdConfirmation.Value;
            if (confirmValue == "Yes")
            {
                if (id1 != "")
                {
                    int id = int.Parse(id1);
                    DeleteRow(id, "Sponsor");
                }
                SponserTable.Rows[SponserTable.Rows.Count - 1].Delete();
            }
        }

        if (SponserTable.Rows.Count == 1)
        {
            lnkSponserCanel.Visible = false;
        }

        SponserBudget();
    }

    protected void txtProjectDetail_TextChanged(object sender, EventArgs e)
    {
        txtProjectDetail.Text = fnRemoveStyle(txtProjectDetail.Text);
    }

    protected void txtImpctofproject_TextChanged(object sender, EventArgs e)
    {
        txtImpctofproject.Text = fnRemoveStyle(txtImpctofproject.Text);
    }

    protected void txtRoleofApplicant_TextChanged(object sender, EventArgs e)
    {
        txtRoleofApplicant.Text = fnRemoveStyle(txtRoleofApplicant.Text);
    }

    private string fnRemoveStyle(string txt)
    {
        //remove bullets from text
        txt = txt.Replace("•", "");
        txt = txt.Replace("o", "");

        //for Special Case( or ?)
        txt = Regex.Replace(txt, "\uF0FC", "");
        txt = Regex.Replace(txt, "\uF0D8", "");
        txt = Regex.Replace(txt, "\uF076", "");
        txt = Regex.Replace(txt, "\uF0A7", "");

        // remove more space and new lines from text
        txt = Regex.Replace(txt, " {2,}", " ");
        txt = txt.Replace("\n\n", "");
        txt = txt.Replace("\t", "");

        return txt;
    }
    public string dateFormat(String DateIn)
    {
        string d = string.Empty;
        string[] datesplit;
        if (!DateIn.Equals(""))
        {
            d = DateIn;
            datesplit = d.Split(' ');
            string[] strS = datesplit[0].Split('/');
            if (strS.Count() > 1)
            {

                d = strS[2] + "-" + strS[1] + "-" + strS[0];
            }
            else
            {
                strS = datesplit[0].Split('-');
                d = strS[0] + "-" + strS[1] + "-" + strS[2];
            }
        }
        return d;
    }

    //public void download_File(string fName)
    //{

    //    //string mypath = Path.Combine("C:/inetpub/wwwroot/Youth.gov.kw/ini_Form/", fName); 
    //    string mypath = Path.Combine("C:/inetpub/wwwroot/YouthNew/ini_Form/", fName);        
    //    FileInfo fi = new FileInfo(mypath);
    //    long sz = fi.Length;
    //    Response.ClearContent();
    //    Response.ContentType = Path.GetExtension(fName);
    //    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(mypath)));
    //    Response.AddHeader("Content-Length", sz.ToString("F0"));
    //    Response.TransmitFile(mypath);
    //    Response.End();
    //}



    //protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //     foreach (RepeaterItem item in rpDetails.Items)
    //    {
    //        FileUpload fbCv = (FileUpload)item.FindControl("fbCv");
    //        CustomValidator custom1 = (CustomValidator)item.FindControl("CustomValidator1");

    //        HtmlAnchor anchor = (HtmlAnchor)item.FindControl("anchor");
    //        TextBox txtCv = (TextBox)item.FindControl("txtCv");         
            

    //        if (string.IsNullOrEmpty(txtCv.Text))
    //        {
    //            anchor.Visible = false;            
                
    //        }
    //        if (anchor.Visible == false)
    //        {
    //            if (fbCv.HasFile)
    //            {
    //                args.IsValid = true;
    //                custom1.Enabled = false;
    //            }
    //            else
    //            {
    //                args.IsValid = false;
    //                break;
    //            }
    //        }
    //        else
    //        {
    //            args.IsValid = true;
    //            custom1.Enabled = false;
    //        }
    //    }
    
    //}
}