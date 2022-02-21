using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_Initiative : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {




            if (!string.IsNullOrEmpty(Request.QueryString["InitiativeID"]))
            {


                fillData();



            }
        }
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

            if (!DBNull.Value.Equals(dt.Rows[0]["EducationQualificationID"]))
                labEducationQualification.Text = GetEducationQualificationName(dt.Rows[0]["EducationQualificationID"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["SubmitedAt"]))
                labPostDate.Text = dt.Rows[0]["SubmitedAt"].ToString();

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

            lblLabelRef.Text = dt.Rows[0]["InitiativeNo"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeName"]))      // Here you can also check for DBNull or Empty string
                labInitiativeName.Text = dt.Rows[0]["InitiativeName"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeDesc"]))
                labInitiativeDesc.Text = dt.Rows[0]["InitiativeDesc"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeObjectives"]))
                labInitiativeObjectives.Text = dt.Rows[0]["InitiativeObjectives"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["HowKnwAbtUs"]))
                lblHowtoKnow.Text = dt.Rows[0]["HowKnwAbtUs"].ToString();
            if (!DBNull.Value.Equals(dt.Rows[0]["Incublator"]))
                lblIncubator.Text = dt.Rows[0]["Incublator"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ChooseIncubator"]))
            {
                tdIncu.Visible = true;
                lblChoosenIncubator.Text = dt.Rows[0]["ChooseIncubator"].ToString();
            }

            

            Userdt = globalFunctions.GetUserDetails(dt.Rows[0]["UID"].ToString());

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Name"]))
                labName.Text = Userdt.Rows[0]["Name"].ToString() + " " + Userdt.Rows[0]["Mname"].ToString() + " " + Userdt.Rows[0]["TName"].ToString() + " " + Userdt.Rows[0]["LName"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Email"]))
                labEmail.Text = Userdt.Rows[0]["Email"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["Mobile"]))
                labMobile.Text = Userdt.Rows[0]["Mobile"].ToString();

            if (!DBNull.Value.Equals(Userdt.Rows[0]["civil"]))
                labCivilID.Text = Userdt.Rows[0]["civil"].ToString();



        }


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

    public string GetEducationQualificationName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_EducationQualification]  where id=" + s + " order by id desc";
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
}