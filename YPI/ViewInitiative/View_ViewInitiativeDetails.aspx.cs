using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_View_ViewInitiativeDetails : System.Web.UI.Page
{
    public string StrInitiativeActivityDiv;
    public string StrPrintbtn;
    public string StrInstitutionID, StrBusinessNurseryID, StrUserGroupID, StrMYAAllStage, StrMYAStage1, StrMYAStage2, StrMYAStage3, StrMYAStage4, StrMYAStage5, StrMYAStage6, StrMYAStage7, StrBNAllStage, StrBNStage1, StrBNStage2, StrBNStage3, StrBNStage4;
    public string StrURewiewApprove, StrUEdit, StrUPrint, StrUDelete, StrUDownload, StrUFollowUp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewInitiativeAppCurrentUser.CheckLoggedIn();
            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            //PanPrint.Visible = false;
            lnkEdit.Visible = false;
            PANMYAReviewApprove.Visible = false;
            PanFileAgriculture.Visible = false;
            lnkDelete.Visible = false;

            panIncubatorToChoose.Visible = false;

            panIncubatorFileUploadWhenSelected.Visible = false;

            fillBusinessNursery();

            StrURewiewApprove = Session["MYAPIVIAppRewiewApprove"].ToString();

            StrUEdit = Session["MYAPIVIAppEdit"].ToString();

            StrUPrint = Session["MYAPIVIAppPrint"].ToString();

            StrUDelete = Session["MYAPIVIAppDelete"].ToString();

            StrUDownload = Session["MYAPIVIAppDownload"].ToString();

            StrUFollowUp = Session["MYAPIVIAppFollowUp"].ToString();



            StrUserGroupID = Session["MYAPIVIAppUserGroupID"].ToString();

            StrInstitutionID = Session["MYAPIVIAppInstitution"].ToString();

            StrBusinessNurseryID = Session["MYAPIVIAppBusinessNurseryID"].ToString();




            StrMYAAllStage = Session["MYAPIVIAppMYAAllStage"].ToString();

            StrMYAStage1 = Session["MYAPIVIAppMYAStage1"].ToString();

            StrMYAStage2 = Session["MYAPIVIAppMYAStage2"].ToString();

            StrMYAStage3 = Session["MYAPIVIAppMYAStage3"].ToString();

            StrMYAStage4 = Session["MYAPIVIAppMYAStage4"].ToString();

            StrMYAStage5 = Session["MYAPIVIAppMYAStage5"].ToString();

            StrMYAStage6 = Session["MYAPIVIAppMYAStage6"].ToString();

            StrMYAStage7 = Session["MYAPIVIAppMYAStage7"].ToString();


            StrBNAllStage = Session["MYAPIVIAppBNAllStage"].ToString();

            StrBNStage1 = Session["MYAPIVIAppBNStage1"].ToString();

            StrBNStage2 = Session["MYAPIVIAppBNStage2"].ToString();

            StrBNStage3 = Session["MYAPIVIAppBNStage3"].ToString();

            StrBNStage4 = Session["MYAPIVIAppBNStage4"].ToString();



            if (!string.IsNullOrEmpty(Request.QueryString["InitiativeID"]))
            {

                fillStatus();
                fillData();
                // fillLeadsFollowUpData();

                panUpdateStatus.Visible = false;

                if (StrUPrint == "True")
                {
                    StrPrintbtn = " <a class='btn btn-primary btn-sm' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["InitiativeID"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";

                }

                if (StrUEdit == "True")
                {
                    lnkEdit.Visible = true;
                }

                if (StrUDelete == "True")
                {
                    lnkDelete.Visible = true;
                }

                if (StrURewiewApprove == "True")
                {
                    PANMYAReviewApprove.Visible = true;
                }

                fillInitiativeActivityLogData();
                fillInitiativeFollowUpData();

                if (StrInstitutionID == "2")
                { PANMYAReviewApprove.Visible = false; PANInitiativeActivity.Visible = false; }
            }
        }
    }
    private void fillInitiativeActivityLogData()
    {
        DataTable dt = new DataTable();

        DataTable dtAllInitiative = new DataTable();

        dtAllInitiative = dbFunctions_YPI.GetData("select * from [V_AllInitiative] where ID=" + Request.QueryString["InitiativeID"]);
        if (dtAllInitiative.Rows.Count != 0)
        {
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-box-w'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-time'>";

            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-box'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <div class='activity-avatar'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <img src='img/photo.jpg'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + " </div>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-info'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-role'>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "" + dtAllInitiative.Rows[0]["SubmitedAt"] + "";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <strong class='activity-title'>Initiative Created</strong>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + " </div>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
            StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
        }

        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_InitiativeActivityLog] where ActivityItemID=" + Request.QueryString["InitiativeID"]);
        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-box-w'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-time'>";

                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-box'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <div class='activity-avatar'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <img src='img/photo.jpg'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + " </div>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-info'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "<div class='activity-role'>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "" + dt.Rows[i1]["UserFullName"] + "<br>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "" + dt.Rows[i1]["ActivityDate"] + "";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
                if (dt.Rows[i1]["Stage"].ToString() == "0")
                {
                    StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <strong class='activity-title'>" + dt.Rows[i1]["Activity"] + "</strong>";
                }
                else
                {
                    StrInitiativeActivityDiv = StrInitiativeActivityDiv + " <strong class='activity-title'>" + dt.Rows[i1]["Activity"] + " <br> " + GetStageText(dt.Rows[i1]["Stage"].ToString()) + " <br> " + dt.Rows[i1]["StageStatusText"] + "</strong>";
                }
               
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + " </div>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
                StrInitiativeActivityDiv = StrInitiativeActivityDiv + "</div>";
            }
        }
    }

    public string GetStageText(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Stage] where id=" + s + " order by id desc";
        //Response.Write(cmd);
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }

    private void fillInitiativeFollowUpData()
    {
        DataTable dt = new DataTable();
        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_Initiative_FollowUp] where InitiativeID=" + Request.QueryString["InitiativeID"]);
        if (dt.Rows.Count != 0)
        {
            GVFollowUpData.DataSource = dt;
            GVFollowUpData.DataBind();
        }
    }

    protected void GVFollowUpData_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVFollowUpData.PageIndex = e.NewPageIndex;
        this.fillInitiativeFollowUpData();
    }

    public string GetCategoryName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Category]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }


        return strresult;
    }

    private void fillData()
    {

        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions_YPI.GetData("select * from [V_AllInitiative] where ID=" + Request.QueryString["InitiativeID"]);
        //Try


        if (dt.Rows.Count != 0)
        {

            if (!DBNull.Value.Equals(dt.Rows[0]["CategoryID"]))
                labcategory.Text = GetCategoryName(dt.Rows[0]["CategoryID"].ToString());

            LabInstitutionID.Text = dt.Rows[0]["InstitutionID"].ToString();

            LabStatus1.Text = dt.Rows[0]["Status"].ToString();

            labStage.Text = dt.Rows[0]["Stage"].ToString();

            labStageStatus.Text = dt.Rows[0]["StageStatus"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["HowKnwAbtUs"]))
            {
                lblHowtoKnow.Text = dt.Rows[0]["HowKnwAbtUs"].ToString();
                HowtoKnow.Visible = true;
            }
            else
                HowtoKnow.Visible = false;

            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "1")
            {
                labStageText.Text = GetStageLabelText("1", "2");
                fillMYAStage2Status();
                DDLStageStatus.SelectedValue = dt.Rows[0]["StageStatus"].ToString();
                PANMYAReviewApprove.Visible = true;
            }


            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "2")
            {
                labStageText.Text = GetStageLabelText("1", "2");
                fillMYAStage2Status();
                DDLStageStatus.SelectedValue = dt.Rows[0]["StageStatus"].ToString();
                PANMYAReviewApprove.Visible = true;
            }

            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "3")
            {
                labStageText.Text = GetStageLabelText("1", "3");
                fillMYAStage3Status();
                //labStageText.Text = GetStageLabelText("2", "4");
                //fillMYAStage4Status();
                PANMYAReviewApprove.Visible = true;
            }

            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "4")
            {
                labStageText.Text = GetStageLabelText("1", "4");
                fillMYAStage4Status();
                PANMYAReviewApprove.Visible = true;
            }

            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "5")
            {
                panIncubatorToChoose.Visible = true;
                labStageText.Text = GetStageLabelText("1", "5");
                fillMYAStage5Status();
                PANMYAReviewApprove.Visible = true;
            }


            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "6")
            {
                //panIncubatorToChoose.Visible = true;
                panIncubatorFileUploadWhenSelected.Visible = true;
                labStageText.Text = GetStageLabelText("1", "6");
                fillMYAStage6Status();
                PANMYAReviewApprove.Visible = true;
            }

            if (dt.Rows[0]["InstitutionID"].ToString() == "1" && dt.Rows[0]["Stage"].ToString() == "7")
            {
               
                labStageText.Text = GetStageLabelText("1", "7");
                fillMYAStage7Status();
                PANMYAReviewApprove.Visible = true;
            }

            if (dt.Rows[0]["Status"].ToString() == "8")
            {

                PANMYAReviewApprove.Visible = false;
            }


            if (dt.Rows[0]["Status"].ToString() == "9")
            {

                PANMYAReviewApprove.Visible = false;
            }

           



            if (!DBNull.Value.Equals(dt.Rows[0]["EducationQualificationNameAr"]))
                labEducationQualification.Text = dt.Rows[0]["EducationQualificationNameAr"].ToString();


            if (dt.Rows[0]["CategoryID"].ToString() == "3")
            {
                PanFileAgriculture.Visible = true;
                if (!DBNull.Value.Equals(dt.Rows[0]["FileAgriculture"]))
                {
                    labFileAgriculture.Text = "<a target='_blank' href='../" + dt.Rows[0]["FileAgriculture"].ToString() + "'>عرض</a>";
                }
            }
            else
            { PanFileAgriculture.Visible = false; }



            if (!DBNull.Value.Equals(dt.Rows[0]["TypeNameAr"]))
                LabType.Text = dt.Rows[0]["TypeNameAr"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["TypeID"]))
            {

                if (dt.Rows[0]["TypeID"].ToString() == "1")
                {
                    PanExperience.Visible = false;
                }
                else
                {
                    PanExperience.Visible = true;


                    if (dt.Rows[0]["SimilarProject"].ToString() == "True")
                    {
                        PanSimilarProjectYes.Visible = true;
                        labSimilarProject.Text = "نعم";

                        if (dt.Rows[0]["ExperienceTypeID"].ToString() == "0")
                        {
                            labExperienceType.Text = "مشروع عائلي";
                        }
                        else if (dt.Rows[0]["ExperienceTypeID"].ToString() == "1")
                        {
                            labExperienceType.Text = "مشروع سابق";
                        }

                        if (!DBNull.Value.Equals(dt.Rows[0]["OldDesc"]))
                            labOldDesc.Text = dt.Rows[0]["OldDesc"].ToString();


                        if (dt.Rows[0]["Success"].ToString() == "True")
                        {
                            labWastheproject.Text = "ناجح";
                            labdesc.InnerText = "اذكر مقومات النجاح : ";
                            lablabWastheprojectdesc.Text = dt.Rows[0]["SuccessDec"].ToString();
                        }
                        else
                        {
                            labWastheproject.Text = "واجهتك معوقات";
                            labdesc.InnerText = "اذكر معوقات المشروع : ";
                            lablabWastheprojectdesc.Text = dt.Rows[0]["SuccessDec"].ToString();
                        }
                    }
                    else
                    {
                        labSimilarProject.Text = "لا";
                        PanSimilarProjectYes.Visible = false;
                    }


                }


            }


            if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNurseryID"]))
                DDLIncubator.SelectedValue = dt.Rows[0]["BusinessNurseryID"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeName"]))      // Here you can also check for DBNull or Empty string
                labInitiativeName.Text = dt.Rows[0]["InitiativeName"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeDesc"]))
                labInitiativeDesc.Text = dt.Rows[0]["InitiativeDesc"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeObjectives"]))
                labInitiativeObjectives.Text = dt.Rows[0]["InitiativeObjectives"].ToString();

            //if (!DBNull.Value.Equals(dt.Rows[0]["FileCriminalAutorization"]))
            //    labFileCriminalAutorization.Text = "<a target='_blank' href='../" + dt.Rows[0]["FileCriminalAutorization"].ToString() + "'>عرض</a>"; //dt.Rows[0]["FileCriminalAutorization"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["FileAcademicQualification"]))
                labFileAcademicQualification.Text = "<a target='_blank' href='../" + dt.Rows[0]["FileAcademicQualification"].ToString() + "'>عرض</a>";






            if (dt.Rows[0]["Status"].ToString() == "1")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "2")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "3")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "4")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "5")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "6")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "7")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-primary'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "9")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-danger'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }
            else if (dt.Rows[0]["Status"].ToString() == "8")
            {

                labStatus.Text = "<div class='value badge badge-pill badge-success'>" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</div>";
            }

            DDLStatus.SelectedValue = dt.Rows[0]["Status"].ToString();


            //if (!DBNull.Value.Equals(dt.Rows[0]["CivilIDCopy"]))
            //{
            //    labCivilIDCopy.Text = "<a target='_blank' href='../Files/App/Quotation/" + dt.Rows[0]["CivilIDCopy"].ToString() + "'>View CivilID Copy</a>";// "../" + System.Configuration.ConfigurationManager.AppSettings["CustomerLogo"] + dt.Rows[0]["QuotationFile"].ToString();

            //}




            //if (!DBNull.Value.Equals(dt.Rows[0]["UID"]))
            //    Response.Write(dt.Rows[0]["UID"].ToString());


            Userdt = globalFunctions.GetUserDetails(dt.Rows[0]["UID"].ToString());

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Name"]))
                labName.Text = Userdt.Rows[0]["Name"].ToString() + " " + Userdt.Rows[0]["Mname"].ToString() + " " + Userdt.Rows[0]["TName"].ToString() + " " + Userdt.Rows[0]["Lname"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Email"]))
                labEmail.Text = Userdt.Rows[0]["Email"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Mobile"]))
                labMobile.Text = Userdt.Rows[0]["Mobile"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["civil"]))
                labCivilID.Text = Userdt.Rows[0]["civil"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["image_name"]))
            {
                labCivilIDCopy.Text = "<a target='_blank' href='../../User/" + Userdt.Rows[0]["image_name"].ToString() + "'>View CivilID Copy</a>";// "../" + System.Configuration.ConfigurationManager.AppSettings["CustomerLogo"] + dt.Rows[0]["QuotationFile"].ToString();

            }

        }



    }

    private void fillMYAStage2Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Send Reminder", "1"); 
        StageStatus.Rows.Add("Approve", "2");
        StageStatus.Rows.Add("Reject", "3");


        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage3Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Interview Done", "1");
        StageStatus.Rows.Add("Reject", "2");
       


        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage4Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Approve", "1");
        StageStatus.Rows.Add("Reject", "2");



        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage5Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        //StageStatus.Rows.Add("Reject", "1");

        StageStatus.Rows.Add("Send To Incubator", "2");


        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage6Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Approved", "1");
        StageStatus.Rows.Add("Reject", "2");


        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage7Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Completed", "1");
       
        StageStatus.Rows.Add("Discontinued", "2");


        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillMYAStage8Status()
    {
        DataTable StageStatus = new DataTable();

        //Add Columns to Table
        StageStatus.Columns.Add(new DataColumn("StageStatusText"));
        StageStatus.Columns.Add(new DataColumn("StageStatusValue"));

        //Now Add Values
        StageStatus.Rows.Add("<--أختار-->", "0");
        StageStatus.Rows.Add("Payment Done", "1");
        //StageStatus.Rows.Add("Pending", "2");



        //At Last Bind datatable to dropdown.
        DDLStageStatus.DataSource = StageStatus;
        DDLStageStatus.DataTextField = StageStatus.Columns["StageStatusText"].ToString();
        DDLStageStatus.DataValueField = StageStatus.Columns["StageStatusValue"].ToString();
        DDLStageStatus.DataBind();
    }

    private void fillStatus()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Status] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStatus.DataSource = dt;
            DDLStatus.DataTextField = "Name";
            DDLStatus.DataValueField = "id";
            DDLStatus.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStatus.Items.Add(it_bo);
        }
        else
        {
            DDLStatus.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStatus.Items.Add(it_bo);
        }
    }

    public string GetStageLabelText(string StrInstitutionID, String StrID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Stage]  where InstitutionID=" + StrInstitutionID + " and id=" + StrID + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }

    public string GetStatusName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Status]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }


        return strresult;
    }

    public string GetTypeName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Type]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }


        return strresult;
    }

    protected void lnkUpdateStatus_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();
        cmd = "update [MYA_PI_Initiative] set  [status]='" + globalFunctions.checkText(DDLStatus.SelectedValue) + "' where id=" + Request.QueryString["InitiativeID"];

        try
        {
            dbFunctions_YPI.ExecuteQuery(cmd);
            fillData();
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Initiative Status Has Been Modified Successfully');", true);

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
    }

    protected void lnkReviewApprove_Click(object sender, EventArgs e)
    {
        string cmd = "";
        DataTable dt = new DataTable();

        String StrBusinessNurseryID = "0";

        String StrBusinessNurseryText = "0";

        String StrStatus = "0";

        String StrInstitutionID = "0";

        String StrStage = "0";

        String StrStage_1 = "0";

        String StageStatus = "0";


        if (LabInstitutionID.Text == "1" && LabStatus1.Text == "1" && labStage.Text == "1")
        {
            StrInstitutionID = "1";

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "2";
                StrStage = "2";
                StrStage_1 = "2";
                StageStatus = DDLStageStatus.SelectedValue;
            }
            else if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "3";
                StrStage = "3";
                StrStage_1 = "2";
                StageStatus = "0";
               
            }
            else if (DDLStageStatus.SelectedValue == "3")
            {
                StrStatus = "9";
                StrStage = "9";
                StrStage_1 = "2";
                StageStatus = DDLStageStatus.SelectedValue;
            }



            //  cmd = "update [MYA_PI_Initiative] set  [status]='" + StrStatus + "',InstitutionID='" + StrInstitutionID + "',Stage='" + StrStage + "',StageStatus=" + StageStatus + " where id=" + Request.QueryString["InitiativeID"];
        }
        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "2" && labStage.Text == "2")
        {
            StrInstitutionID = "1";

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "2";
                StrStage = "2";
                StrStage_1 = "2";
                StageStatus = DDLStageStatus.SelectedValue;
            }
            else if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "3";
                StrStage = "3";
                StrStage_1 = "2";
                StageStatus = "0";

            }
            else if (DDLStageStatus.SelectedValue == "3")
            {
                StrStatus = "9";
                StrStage = "9";
                StrStage_1 = "2";
                StageStatus = DDLStageStatus.SelectedValue;
              
            }
        }

        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "3" && labStage.Text == "3")
        {
            StrInstitutionID = "1";

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "4";
                StrStage = "4";
                StrStage_1 = "3";
                StageStatus = "0";
            }
            else if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "9";
                StrStage = "9";
                StrStage_1 = "3";
                StageStatus = DDLStageStatus.SelectedValue;
            }

        }
        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "4" && labStage.Text == "4")
        {
            StrInstitutionID = "1";

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "5";
                StrStage = "5";
                StrStage_1 = "4";
                StageStatus = "0";
            }
            else if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "9";
                StrStage = "9";
                StrStage_1 = "4";
                StageStatus = DDLStageStatus.SelectedValue;
            }
        }

        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "5" && labStage.Text == "5")
        {
            StrInstitutionID = "1";
            StrBusinessNurseryID = DDLIncubator.SelectedValue;
            StrBusinessNurseryText= DDLIncubator.SelectedItem.Text;

            if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "6";
                StrStage = "6";
                StrStage_1 = "5";
                StageStatus = "0";
            }
           
        }
        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "6" && labStage.Text == "6")
        {
            StrInstitutionID = "1";
            StrBusinessNurseryID = DDLIncubator.SelectedValue;
            StrBusinessNurseryText = DDLIncubator.SelectedItem.Text;

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "7";
                StrStage = "7";
                StrStage_1 = "6";
                StageStatus = "0";
            }
            else if (DDLStageStatus.SelectedValue == "2")
            {
                StrStatus = "9";
                StrStage = "9";
                StrStage_1 = "6";
                StageStatus = DDLStageStatus.SelectedValue;
            }
        }

        else if (LabInstitutionID.Text == "1" && LabStatus1.Text == "7" && labStage.Text == "7")
        {
            StrInstitutionID = "2";
            StrBusinessNurseryID = DDLIncubator.SelectedValue;
            StrBusinessNurseryText = DDLIncubator.SelectedItem.Text;

            if (DDLStageStatus.SelectedValue == "1")
            {
                StrStatus = "8";
                StrStage = "8";
                StrStage_1 = "7";
                StageStatus = "0";
            }
           
        }

       



        if (labStage.Text == "6")
        {

            string File_Stage;

            string ext_Stage;

            File_Stage = "";

            File_Stage = uFileStage.PostedFile.FileName;

            if (File_Stage == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Please Attach Incubator Selected Contract Copy To Proceed', 'error');", true);
                return;
            }
            else
            {
                File_Stage = Path.GetFileName(File_Stage);
                ext_Stage = Path.GetExtension(File_Stage);
                File_Stage = Request.QueryString["InitiativeID"] + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext_Stage;
                uFileStage.PostedFile.SaveAs(Server.MapPath("../YPIFiles/StageFile/") + File_Stage);
            }


               
        }

        if (labStage.Text == "5" && DDLIncubator.SelectedValue == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Please Choose Incubator To Proceed', 'error');", true);
            return;
        }


        cmd = "update [MYA_PI_Initiative] set  [status]='" + StrStatus + "',InstitutionID='" + StrInstitutionID + "',Stage='" + StrStage + "',StageStatus=" + StageStatus + ",BusinessNurseryID=" + StrBusinessNurseryID + ",ChooseIncubator=N'" + StrBusinessNurseryText + "' where id=" + Request.QueryString["InitiativeID"];

        try
        {
            dbFunctions_YPI.ExecuteQuery(cmd);

            cmd = "insert into [MYA_PI_Initiative_Stages] ([InitiativeID],[InstitutionID],[Stage],[StageStatusText],[StageStatus],[Note]) values('" + globalFunctions.checkText(Request.QueryString["InitiativeID"]) + "','" + StrInstitutionID + "','" + StrStage + "','" + DDLStageStatus.SelectedItem.Text + "','" + DDLStageStatus.SelectedValue + "','" + globalFunctions.checkText(TxtComment.Text) + "')";
            //Response.Write(cmd);
            dbFunctions_YPI.ExecuteQuery(cmd);
            
            ViewInitiativeAppInitiativeActivityLog.CreateInitiativeActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Update Stage", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + labInitiativeName.Text + "", "" + globalFunctions.checkText(TxtComment.Text) + "", "" + StrInstitutionID + "", "" + StrStage_1 + "", "" + DDLStageStatus.SelectedValue + "", "" + DDLStageStatus.SelectedItem.Text + "");
            fillData();
            fillInitiativeActivityLogData();
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Initiative Status Has Been Modified Successfully');", true);
            fillData();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit_Initiative.aspx?InitiativeID=" + Request.QueryString["InitiativeID"] + "");
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        cmd = "delete from [MYA_PI_Initiative] where [ID] = " + Request.QueryString["InitiativeID"];
        dbFunctions_YPI.ExecuteQuery(cmd);
        ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Delete", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + labInitiativeName.Text + "", "");
        ViewInitiativeAppInitiativeActivityLog.CreateInitiativeActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Delete", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + labInitiativeName.Text + "", "", "", "", "", "");
    }

    protected void lnkFollowUpSubmit_Click(object sender, EventArgs e)
    {
        string cmd, StrUsertype;
        DataTable dt = new DataTable();


        string File_FollowUp;

        string ext_FollowUp;

        File_FollowUp = "";

        File_FollowUp = uFileFollowUp.PostedFile.FileName;

        if (File_FollowUp != "")
        {
            File_FollowUp = Path.GetFileName(File_FollowUp);
            ext_FollowUp = Path.GetExtension(File_FollowUp);
            File_FollowUp = Request.QueryString["InitiativeID"] + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext_FollowUp;
            uFileFollowUp.PostedFile.SaveAs(Server.MapPath("../YPIFiles/FollowUp/") + File_FollowUp);
        }

        if (LabInstitutionID.Text == "1")
        {
            StrUsertype = "MYA";
        }
        else
        { StrUsertype = "BS"; }

        SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "insert into MYA_PI_Initiative_FollowUp(InitiativeID,UserType,UserID,UserFullName,Subject,Note,AttFile) values(@InitiativeID,@UserType,@UserID,@UserFullName,@Subject,@Note,@AttFile)";

        sqlCommand.Parameters.AddWithValue("@InitiativeID", Request.QueryString["InitiativeID"]);

        sqlCommand.Parameters.AddWithValue("@UserType", StrUsertype);
        sqlCommand.Parameters.AddWithValue("@UserID", ViewInitiativeAppCurrentUser.MYAPIVIAppUserID);
        sqlCommand.Parameters.AddWithValue("@UserFullName", ViewInitiativeAppCurrentUser.MYAPIVIAppName);
        sqlCommand.Parameters.AddWithValue("@Subject", TxtSubject.Text);
        sqlCommand.Parameters.AddWithValue("@Note", TxtNote.Text);
        sqlCommand.Parameters.AddWithValue("@AttFile", File_FollowUp);

        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "FollowUp - Add", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + labInitiativeName.Text + "", "");
            ViewInitiativeAppInitiativeActivityLog.CreateInitiativeActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "FollowUp - Add", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + labInitiativeName.Text + "", "", "", "", "", "");
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Initiative Follow Up Infomation Has Been Created Successfully');", true);
            fillInitiativeActivityLogData();
            fillInitiativeFollowUpData();

            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Initiative Follow Up Has Been Submitted Successfully');", true);
            TxtSubject.Text = "";
            TxtNote.Text = "";

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
    }

    public string GetFollowAttachment(object s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";
        cmd = "select * from [MYA_PI_Initiative_FollowUp] where id=" + s + " order by id desc";
       
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["AttFile"]))
            {
                strresult = "<div class='badge badge-primary'><i class='fa fa-paperclip' aria-hidden='true'></i>&nbsp;   <a class='txtWhite' target='_blank' href='../YPIFiles/FollowUp/" + dt.Rows[0]["AttFile"].ToString() + "'>عرض</a></div>";
            }
            else
            {
                strresult = "";
            }
        }

            return strresult;
    }


    private void fillBusinessNursery()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_BusinessNursery] where Status='" + true + "' order by nameAr asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLIncubator.DataSource = dt;
            DDLIncubator.DataTextField = "NameAr";
            DDLIncubator.DataValueField = "id";
            DDLIncubator.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLIncubator.Items.Add(it_bo);
        }
        else
        {
            DDLIncubator.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLIncubator.Items.Add(it_bo);
        }
    }
   
   
}