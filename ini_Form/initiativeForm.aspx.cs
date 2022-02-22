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

public partial class initiativeForm : System.Web.UI.Page
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

    int appy_type = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
           
            checkAge();


            myTable.Columns.Add("txtDate");
            myTable.Columns.Add("txtStartTime");
            myTable.Columns.Add("txtEndTime");
            myTable.Columns.Add("txtCv");
            myTable.Columns.Add("txtNameofSpeaker");
            myTable.Columns.Add("txtAddress");
            myTable.Columns.Add("txtAxces");
            myTable.Columns.Add("txtNumberofattendence");


            MediaTable.Columns.Add("txtPlace");
            MediaTable.Columns.Add("txtNumberAdd");
            MediaTable.Columns.Add("txtAddDetails");
            MediaTable.Columns.Add("txtCostDetails");


            BudgetTable.Columns.Add("txtItem");
            BudgetTable.Columns.Add("txtNumber");
            BudgetTable.Columns.Add("txtCost");
            BudgetTable.Columns.Add("txtTotalcost");


            SponserTable.Columns.Add("txtSponserName");
            SponserTable.Columns.Add("txtTypeCare");
            SponserTable.Columns.Add("txtCareDetails");


            ExcutiveTable.Columns.Add("txtActivityDate");
            ExcutiveTable.Columns.Add("txtActivity");



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
                checkName();
            }
        }
        else
        {
            Response.Redirect("index.aspx", true);
        }
    }
    private void checkAge()
    {

        general_fn gfn = new general_fn();
        string id = userid();
        int age = gfn.checkAge(id.ToString());
        if (age == 1)
        {
            lblAgeMessage.Visible = false;
        }
        else
        {
            lblAgeMessage.Visible = true;
            foreach (ListItem item in this.RBIntiativeCatagory.Items)
            {
                if (item.Value.Equals("أفراد") || item.Value.Equals("مجموعات شبابية"))
                {
                    item.Enabled = false;
                }

            }

        }
    }
    private void checkName()
    {
        SQLConnection();
        string id = userid();

        string query = "ViewUserDetails";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.StoredProcedure;

        DataTable dt = new DataTable();
        cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        sda.Fill(dt);
        txtFname.Text = dt.Rows[0]["Name"].ToString();
        txtMname.Text = dt.Rows[0]["Mname"].ToString();
        txtThirdName.Text = dt.Rows[0]["TName"].ToString();
        txtsurname.Text = dt.Rows[0]["Lname"].ToString();
        string image = dt.Rows[0]["image_name"].ToString();
        hdUserCivilPath.Value = image;
        hdUserCivilID.Value = dt.Rows[0]["civil"].ToString();
        if (string.IsNullOrEmpty(image))
        {
            Panelcivil.Visible = true;
        }

        //if (!string.IsNullOrEmpty(txtFname.Text))
        //{
        //    txtFname.Enabled = false;
        //}
        //if(!string.IsNullOrEmpty(txtMname.Text))
        //{
        //    txtMname.Enabled = false;
        //}
        //if (!string.IsNullOrEmpty(txtThirdName.Text))
        //{
        //    txtThirdName.Enabled = false;
        //}
        //if (!string.IsNullOrEmpty(txtsurname.Text))
        //{
        //    txtsurname.Enabled = false;
        //}
        con.Close();
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


            DataRow row = myTable.NewRow();

            row["txtDate"] = txtDate.Text;
            row["txtStartTime"] = txtStartTime.Text;
            row["txtEndTime"] = txtEndTime.Text;
            row["txtCv"] = txtCv.Text;
            row["txtNameofSpeaker"] = txtNameofSpeaker.Text;
            row["txtAddress"] = txtAddress.Text;
            row["txtAxces"] = txtAxces.Text;
            row["txtNumberofattendence"] = txtNumberofattendence.Text;

            myTable.Rows.Add(row);

        }
    }

    protected void PopulateExecutiveDataTable()
    {
        foreach (RepeaterItem item in RpExctuiveplan.Items)
        {
            TextBox txtActivityDate = (TextBox)item.FindControl("txtActivityDate");

            TextBox txtActivity = (TextBox)item.FindControl("txtActivity");


            DataRow row = ExcutiveTable.NewRow();

            row["txtActivityDate"] = txtActivityDate.Text;
            row["txtActivity"] = txtActivity.Text;


            ExcutiveTable.Rows.Add(row);

        }
    }
    protected void PopulateMediaDataTable()
    {
        int total = 0;
        foreach (RepeaterItem item in RpMedia.Items)
        {
            TextBox txtPlace = (TextBox)item.FindControl("txtPlace");

            TextBox txtNumberAdd = (TextBox)item.FindControl("txtNumberAdd");
            TextBox txtAddDetails = (TextBox)item.FindControl("txtAddDetails");
            TextBox txtCostDetails = (TextBox)item.FindControl("txtCostMedia");

            string value = string.Empty;



            int i = 0;

            if (!txtCostDetails.Text.Equals(""))
            {
                i = int.Parse(txtCostDetails.Text) + i;
                value = i.ToString();
                total = total + i;
                txtToalCostMedia.Text = "الإجمالي :" + total;
            }

            DataRow row = MediaTable.NewRow();

            row["txtPlace"] = txtPlace.Text;
            row["txtNumberAdd"] = txtNumberAdd.Text;
            row["txtAddDetails"] = txtAddDetails.Text;
            row["txtCostDetails"] = txtCostDetails.Text;
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




            DataRow row = SponserTable.NewRow();

            row["txtSponserName"] = txtSponserName.Text;
            row["txtTypeCare"] = txtTypeCare.Text;
            row["txtCareDetails"] = txtCareDetails.Text;

            SponserTable.Rows.Add(row);

        }
    }
    protected void RBIntiativeCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlType.Visible = true;

        if (RBIntiativeCatagory.SelectedIndex == 4)
        {

            RBindivitual.Visible = false;
            toolindi.Visible = false;
            lblExperience.Visible = true;

        }
        else if (RBIntiativeCatagory.SelectedIndex > 1 && RBIntiativeCatagory.SelectedIndex <= 3)
        {
            RBindivitual.Visible = true;
            toolindi.Visible = true;
            lblExperience.Visible = false;
        }

        else
        {
            RBindivitual.Visible = true;
            toolindi.Visible = true;
            lblExperience.Visible = false;
        }

        RBindivitual.Checked = false;
        RBForum.Checked = false;
        pnlOthr.Visible = false;
        pnlbutton.Visible = false;

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
        SQLConnection2();

        string startdate = string.Empty;
        //string pid = HiddenID.Value;
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
            string query = "InitiativeInfoInsert";
            SqlCommand BIDCommand = new SqlCommand(query);
            BIDCommand.CommandType = CommandType.StoredProcedure;
            string civil = hdUserCivilID.Value;
            // project or event name same coloum 
            if (filecivil.HasFile)
            {
                civilpath = @"Civil\" + civil + "-" + "Civil-ID" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(filecivil.PostedFile.FileName.ToString());
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

            // this event and project is one in the same 
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



            // need to add in sp and table 



            BIDCommand.Parameters.AddWithValue("@Initiative_ProjectCategory", SqlDbType.NVarChar).Value = Server.HtmlEncode(dpProjectCategory.SelectedItem.Text);


            BIDCommand.Parameters.AddWithValue("@Initiative_Impctofproject", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtImpctofproject.Text);


            BIDCommand.Parameters.AddWithValue("@Initiative_RoleofApplicant", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtRoleofApplicant.Text);


            BIDCommand.Parameters.AddWithValue("@Initiative_CatogoryandAge", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAgeFrom.Text + "-" + txtAgeTo.Text);




            BIDCommand.Parameters.AddWithValue("@Initiative_typeofActivity", SqlDbType.NVarChar).Value = Server.HtmlEncode(drpType.SelectedItem.Text);


            BIDCommand.Parameters.AddWithValue("@Initiative_volounteerInterest", SqlDbType.Int).Value = Server.HtmlEncode(RBVolounteer.SelectedItem.Value);
            // BIDCommand.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = pid;
            BIDCommand.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtFname.Text);
            BIDCommand.Parameters.AddWithValue("@mName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtMname.Text);
            BIDCommand.Parameters.AddWithValue("@tname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtThirdName.Text);
            BIDCommand.Parameters.AddWithValue("@lName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtsurname.Text);
            BIDCommand.Parameters.AddWithValue("@civilUser", SqlDbType.NVarChar).Value = civilpath;

            BIDCommand.Parameters.AddWithValue("@applyType", SqlDbType.Int).Value = appy_type;


            BIDCommand.Parameters.Add("@insertBID", SqlDbType.Int, 0, "id");
            string userid = string.Empty;
            if (Session["userid"] != null)
            {
                userid = Session["userid"].ToString();
                userid = gfn.SessionDecrypt(userid, SHA512.Create().ToString());
                userid = userid.Substring(userid.IndexOf("&") + 1);

            }
            int id = int.Parse(userid);

            BIDCommand.Parameters.AddWithValue("@id", id);
            BIDCommand.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = id;
            BIDCommand.Parameters["@insertBID"].Direction = ParameterDirection.Output;
            var returnParameter = BIDCommand.Parameters.Add("@ERROR", SqlDbType.NVarChar);
            returnParameter.Direction = ParameterDirection.Output;

            returnParameter.Size = 100;
            BIDCommand.Connection = cnn;

            //  bool val= checkFile();

            try
            {
                BIDCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
            string MemberBID = BIDCommand.Parameters["@insertBID"].Value.ToString();
            if (!MemberBID.Equals("0"))
            {
                cnn.Close();

                AddAgency(MemberBID);
               
                insertMedia(MemberBID);
                insertBudget(MemberBID);
                insertSponser(MemberBID);
                insertExcutive(MemberBID);
                insertFile(MemberBID);
 		insertGrid(MemberBID);
                Session["ini_bid"] = MemberBID;
                Response.Redirect("thankyou.aspx", true);
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
        SqlCommand FileCommand = new SqlCommand("InitiativeAgencyInfoInsert", cnn);
        FileCommand.CommandType = CommandType.StoredProcedure;
        if (string.IsNullOrEmpty(bid))
            FileCommand.Parameters.AddWithValue("@BID", DBNull.Value).Value = "";
        else
            FileCommand.Parameters.AddWithValue("@BID", SqlDbType.Int).Value = bid;
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
        FileCommand.Parameters.AddWithValue("@surname", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtsurname.Text);
        var returnParameter = FileCommand.Parameters.Add("@retVal", SqlDbType.NVarChar);
        returnParameter.Direction = ParameterDirection.Output;

        returnParameter.Size = 100;
        FileCommand.ExecuteNonQuery();

        string message = (string)FileCommand.Parameters["@retVal"].Value;
        if (message == "1")
        {

        }
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

        if (fpCivilID.HasFile)
        {
            CivilID = @"InitiativeFiles\" + memberID.ToString() + "-" + "Civil-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpCivilID.PostedFile.FileName.ToString());
        }
        if (fpAutorization.HasFile)
        {
            Autorization = @"InitiativeFiles\" + memberID.ToString() + "-" + "Autorization-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpAutorization.PostedFile.FileName.ToString());

        }
        if (fpcivilpubicauthority.HasFile)
        {
            civilpubicauthority = @"InitiativeFiles\" + memberID.ToString() + "-" + "pubicauthority-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpcivilpubicauthority.PostedFile.FileName.ToString());

        }
        if (fpcivilidpublicpapper.HasFile)
        {
            civilidpublicpapper = @"InitiativeFiles\" + memberID.ToString() + "-" + "civilidpublicpapper-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpcivilidpublicpapper.PostedFile.FileName.ToString());
        }
        if (txtBookApproval.HasFile)
        {
            BookApproval = @"InitiativeFiles\" + memberID.ToString() + "-" + "BookApproval-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtBookApproval.PostedFile.FileName.ToString());

        }
        if (fpconferencewrkingpapper.HasFile)
        {
            conferencewrkingpapper = @"InitiativeFiles\" + memberID.ToString() + "-" + "conferencewrkingpapper-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpconferencewrkingpapper.PostedFile.FileName.ToString());
        }
        if (txtCvofapplicant.HasFile)
        {
            Cvofapplicant = @"InitiativeFiles\" + memberID.ToString() + "-" + "Cvofapplicant-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(txtCvofapplicant.PostedFile.FileName.ToString());
        }
        if (fpexecutiveplan.HasFile)
        {
            executiveplan = @"InitiativeFiles\" + memberID.ToString() + "-" + "ExecutivePlan-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fpexecutiveplan.PostedFile.FileName.ToString());
        }

        SqlCommand FileCommand = new SqlCommand("sp_InitiativeFileInsert", cnn);
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


            if (fpCivilID.HasFile)
            {


                fpCivilID.PostedFile.SaveAs(Server.MapPath(CivilID));
                //fileUploadSucessInfo(fpCivilID, "civil", oprCivilIdPath);

            }
            if (fpAutorization.HasFile)
            {


                fpAutorization.PostedFile.SaveAs(Server.MapPath(Autorization));
                // fileUploadSucessInfo(updOther, "civil", oprDocfilePath);

            }
            if (fpcivilpubicauthority.HasFile)
            {

                fpcivilpubicauthority.PostedFile.SaveAs(Server.MapPath(civilpubicauthority));
                //fileUploadSucessInfo(updCourse1, "pdf", Upload_CoursePath1);

            }
            if (fpcivilidpublicpapper.HasFile)
            {

                fpcivilidpublicpapper.PostedFile.SaveAs(Server.MapPath(civilidpublicpapper));
                //  fileUploadSucessInfo(updReward1, "pdf", Upload_RewardPath1);

            }
            if (txtBookApproval.HasFile)
            {

                txtBookApproval.PostedFile.SaveAs(Server.MapPath(BookApproval));
                //fileUploadSucessInfo(updReward2, "pdf", Upload_RewardPath2);

            }
            if (fpconferencewrkingpapper.HasFile)
            {

                fpconferencewrkingpapper.PostedFile.SaveAs(Server.MapPath(conferencewrkingpapper));
                //fileUploadSucessInfo(updReward2, "pdf", Upload_RewardPath2);

            }
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


    private void insertGrid(string memberID)
    {
        int i = 0;
        foreach (RepeaterItem item in rpDetails.Items)
        {
            SQLConnection2();
            TextBox txtDate = (TextBox)item.FindControl("txtDate");
            TextBox txtStartTime = (TextBox)item.FindControl("txtStartTime");
            TextBox txtEndTime = (TextBox)item.FindControl("txtEndTime");
            System.Web.UI.WebControls.FileUpload  fileCv = (System.Web.UI.WebControls.FileUpload)item.FindControl("fbCv");
            TextBox txtNameofSpeaker = (TextBox)item.FindControl("txtNameofSpeaker");
            TextBox txtAddress = (TextBox)item.FindControl("txtAddress");
            TextBox txtAxces = (TextBox)item.FindControl("txtAxces");
            TextBox txtNumberofattendence = (TextBox)item.FindControl("txtNumberofattendence");
            string filename = string.Empty;


           // dynamic fileUploadControl = fileCv;

            if (pnlDetails.Visible == true)
            {

                if (fileCv.PostedFile.ContentLength > 0)
                {
                    filename = @"InitiativeFiles\" + memberID.ToString() + "-" + "Civil-" + i + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fileCv.PostedFile.FileName.ToString());
                    fileCv.PostedFile.SaveAs(Server.MapPath(filename));
                    i++;
                }
            }
            string startdate = string.Empty;

            if (!txtDate.Text.Equals(""))
            {
                startdate = txtDate.Text.Substring(6, 4) + "/" + txtDate.Text.Substring(3, 2) + "/" + txtDate.Text.Substring(0, 2);



            }

            if (txtDate.Text != "" || txtStartTime.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeActivity");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@Intiative_Date", SqlDbType.Date).Value = Server.HtmlEncode(startdate);
                MemberCommand.Parameters.AddWithValue("@Initiative_StartTime", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtStartTime.Text);
                MemberCommand.Parameters.AddWithValue("@Initiative_EndTime", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEndTime.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_CV", SqlDbType.NVarChar).Value = Server.HtmlEncode(filename);
                MemberCommand.Parameters.AddWithValue("@Intiative_NameofSpeaker", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNameofSpeaker.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Address", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAddress.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Acess", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAxces.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_NoAttendence", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumberofattendence.Text);

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery();
            }
            cnn.Close();

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



            if (txtPlace.Text != "" || txtNumberAdd.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeMedia");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@Initiative_Place", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtPlace.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_NumberAdd", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumberAdd.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_AddDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtAddDetails.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_CostDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCostDetails.Text);


                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery();
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
            string ActivityDate = string.Empty;

            if (!txtActivityDate.Text.Equals(""))
            {
                ActivityDate = txtActivityDate.Text.Substring(6, 4) + "/" + txtActivityDate.Text.Substring(3, 2) + "/" + txtActivityDate.Text.Substring(0, 2);
            }
            if (txtActivityDate.Text != "" || txtActivity.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeExcutive");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@Initiative_ActivityDate", SqlDbType.Date).Value = Server.HtmlEncode(ActivityDate);
                MemberCommand.Parameters.AddWithValue("@Intiative_Activity", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtActivity.Text);

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery();
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



            if (txtItem.Text != "" || txtNumber.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeBudget");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@Initiative_Item", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtItem.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Number", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtNumber.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Cost", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCost.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_Totalcost", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTotalcost.Text);


                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery();
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


            if (txtSponserName.Text != "" || txtTypeCare.Text != "")
            {
                SqlCommand MemberCommand = new SqlCommand("sp_InitiativeSponser");
                MemberCommand.CommandType = CommandType.StoredProcedure;
                MemberCommand.Parameters.AddWithValue("@IID", SqlDbType.NVarChar).Value = Server.HtmlEncode(memberID);
                MemberCommand.Parameters.AddWithValue("@Initiative_SponserName", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtSponserName.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_TypeCare", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtTypeCare.Text);
                MemberCommand.Parameters.AddWithValue("@Intiative_CareDetails", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCareDetails.Text);

                MemberCommand.Connection = cnn;
                MemberCommand.ExecuteNonQuery();
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
                }
            }
            else
                txtNumber.Text = "";
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

    protected void lnkExcutiveCanecl_Click(object sender, EventArgs e)
    {
        PopulateExecutiveDataTable();

        if (ExcutiveTable.Rows.Count > 1)
        {
            ExcutiveTable.Rows[ExcutiveTable.Rows.Count - 1].Delete();
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
            myTable.Rows[myTable.Rows.Count - 1].Delete();
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
            MediaTable.Rows[MediaTable.Rows.Count - 1].Delete();
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
            BudgetTable.Rows[BudgetTable.Rows.Count - 1].Delete();

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
            SponserTable.Rows[SponserTable.Rows.Count - 1].Delete();
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
}