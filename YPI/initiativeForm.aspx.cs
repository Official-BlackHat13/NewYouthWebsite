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


    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    SqlConnection con = new SqlConnection();
    general_fn gfn = new general_fn();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            checkApplied(Session["userid"].ToString());

            int val = checkAge();

            if (val == 1)
            {
                if (!this.IsPostBack)
                {

                    checkName();
                    loadData();
                }
            }
            else
            {

                divFormPanel.Visible = false;
                alertAge.Visible = true;

            }
        }
        else
        {
            Session["page"] = "YPI_page";
            Response.Redirect("../User/Login.aspx", true);
        }
    }

    private int checkAge()
    {

        general_fn gfn = new general_fn();
        string id = userid();
        int age = gfn.checkYPIAge(id.ToString());
        return age;
      
    }
    private void checkApplied(string userID)
    {

        con.ConnectionString = gm.ConnectionStringMYAPI();
        con.Open();
        string id = userid();
        hiddenID.Value = id;
        string query = "getUserYPI";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        con.Close();
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("initiativeEditForm.aspx");
            }
        }
        

    }
    private void loadData()
    {
        cnn.ConnectionString = gm.ConnectionStringMYAPI();
        cnn.Open();
        SqlCommand command = new SqlCommand("PIItemsLoad", cnn);
        command.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        command.ExecuteNonQuery();
        da.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                RBIntiativeType.DataSource = ds.Tables[0];
                RBIntiativeType.DataTextField = "NameAr";
                RBIntiativeType.DataValueField = "id";
                RBIntiativeType.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {

                RBProjectCategory.DataSource = ds.Tables[1];
                RBProjectCategory.DataTextField = "NameAr";
                RBProjectCategory.DataValueField = "id";
                RBProjectCategory.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {

                drpEduQulification.Items.Insert(0, new ListItem("--Select--", "0"));
                drpEduQulification.DataSource = ds.Tables[2];
                drpEduQulification.DataTextField = "NameAr";
                drpEduQulification.DataValueField = "id";
                drpEduQulification.DataBind();
                drpEduQulification.Items.Insert(drpEduQulification.Items.Count, new ListItem("أخرى", "-1"));
            }
            if (ds.Tables[3].Rows.Count > 0)
            {

                DropChooseIncubator.Items.Insert(0, new ListItem("--Select--", "0"));
                DropChooseIncubator.DataSource = ds.Tables[3];
                DropChooseIncubator.DataTextField = "NameAr";
                DropChooseIncubator.DataValueField = "id";
                DropChooseIncubator.DataBind();
               
            }
        }
        cnn.Close();

    }

   
    private void checkName()
    {
        con.ConnectionString = gm.ConnectionString();
        con.Open();
        string id = userid();
        hiddenID.Value = id;
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


    protected void RBIntiativeType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (RBIntiativeType.SelectedValue == "1")
        {
            ExperiencePanel.Visible = false;
            FailureDivision.Visible = false;
            SucessDivision.Visible = false;
            TypeofExperienceDivision.Visible = false;
            ExperienceInformationDivision.Visible = false;
            ExperienceRadioList.ClearSelection();
            RBExperienceProjectStatus.ClearSelection();
            RBTypeofExperience.ClearSelection();
            TxtSucess.Text = "";
            txtfailure.Text = "";

        }
        else
        {
            ExperiencePanel.Visible = true;
        }

    }
    protected void ExperienceRadioList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ExperienceRadioList.SelectedValue == "0")
        {
            TypeofExperienceDivision.Visible = false;
            ExperienceInformationDivision.Visible = false;
            FailureDivision.Visible = false;
            SucessDivision.Visible = false;
            RBExperienceProjectStatus.ClearSelection();
            RBTypeofExperience.ClearSelection();
            TxtSucess.Text = "";
            txtfailure.Text = "";
        }
        else if (ExperienceRadioList.SelectedValue == "1")
        {
            TypeofExperienceDivision.Visible = true;
        }

    }

    protected void RBExperienceProjectStatus_CheckedChanged(object sender, EventArgs e)
    {
        if (RBExperienceProjectStatus.SelectedValue == "0")
        {
            FailureDivision.Visible = true;
            SucessDivision.Visible = false;
        }
        else if (RBExperienceProjectStatus.SelectedValue == "1")
        {
            FailureDivision.Visible = false;
            SucessDivision.Visible = true;
        }
    }

    protected void RBTypeofExperience_SelectedIndexChanged(object sender, EventArgs e)
    {

        ExperienceInformationDivision.Visible = true;

    }
    protected void RBProjectCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBProjectCategory.SelectedValue == "3")
        {
            div_fp_agriculture.Visible = true;
        }
        else
        {
            div_fp_agriculture.Visible = false;
        }
    }
    protected void drpEduQulification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpEduQulification.SelectedValue.Equals("-1"))
        {
            divEduQuliOther.Visible = true;

        }
        else
        {

            divEduQuliOther.Visible = false;
            TxtEduQuliOther.Text = string.Empty;
            LblError.Text = "";
        }
    }
    protected void TxtEduQuliOther_TextChanged(object sender, EventArgs e)
    {
        if (!TxtEduQuliOther.Text.Equals(""))
        {
            cnn.ConnectionString = gm.ConnectionStringMYAPI();
            cnn.Open();
            string query = "PIQulificationIsert";
            SqlCommand Command = new SqlCommand(query);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@QuliName", SqlDbType.NVarChar).Value = TxtEduQuliOther.Text.Trim();
            Command.Parameters.Add("@Message", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            Command.Connection = cnn;
            try
            {
                Command.ExecuteNonQuery();
                string MemberBID = Command.Parameters["@Message"].Value.ToString();
                if (MemberBID.Equals("01"))
                {

                    LblError.Text = "Already exists !!!";
                }
                else
                    LblError.Text = "";

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string FileCriminalAutorizationPath, FileAcademicQualificationPath, FileAgriculturePath = string.Empty;

            cnn.ConnectionString = gm.ConnectionStringMYAPI();
            cnn.Open();
            string query = "ProfessionalInitiativeInfo";
            SqlCommand BIDCommand = new SqlCommand(query);
            BIDCommand.CommandType = CommandType.StoredProcedure;


            BIDCommand.Parameters.AddWithValue("@TypeID", SqlDbType.Int).Value = RBIntiativeType.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@SimilarProject", SqlDbType.Int).Value = ExperienceRadioList.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@ExperienceTypeID", SqlDbType.Int).Value = RBTypeofExperience.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@OldDesc", SqlDbType.NVarChar).Value = TxTExperienceProjectDescription.Text.Trim();



            BIDCommand.Parameters.AddWithValue("@Success", SqlDbType.Int).Value = RBExperienceProjectStatus.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@SuccessDec", SqlDbType.NVarChar).Value = TxtSucess.Text;
            //BIDCommand.Parameters.AddWithValue("@Problem", SqlDbType.Int).Value = RBExperienceProjectStatus.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@ProblemDesc", SqlDbType.NVarChar).Value = txtfailure.Text;


            BIDCommand.Parameters.AddWithValue("@CategoryID", SqlDbType.Int).Value = RBProjectCategory.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@UID", SqlDbType.NVarChar).Value = hiddenID.Value;
            BIDCommand.Parameters.AddWithValue("@EducationQualificationID", SqlDbType.Int).Value = drpEduQulification.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@EducationQualificationOther", SqlDbType.NVarChar).Value = TxtEduQuliOther.Text.Trim();
            //BIDCommand.Parameters.AddWithValue("@EducationQualificationID", SqlDbType.Int).Value = (divEduQuliOther.Visible == true ? HdQuliID.Value : drpEduQulification.SelectedValue);
            BIDCommand.Parameters.AddWithValue("@InitiativeName", SqlDbType.NVarChar).Value = txtProjectName.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@InitiativeDesc", SqlDbType.NVarChar).Value = TxTProjectDescription.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@InitiativeObjectives", SqlDbType.NVarChar).Value = TxtProjectGoal.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@HowKnwAbtUs", SqlDbType.NVarChar).Value = (OtherPanel.Visible == true ? txtOtherWhere.Text : DrpFromWhere.SelectedItem.Text);
            BIDCommand.Parameters.AddWithValue("@incubator", SqlDbType.NVarChar).Value = (pnlBusinessNursy.Visible == true ? DrpBusinessNursy.SelectedItem.Text : null);
            BIDCommand.Parameters.AddWithValue("@ChooseIncubator", SqlDbType.NVarChar).Value = DropChooseIncubator.SelectedItem.Text;


            if (FileCriminalAutorization.HasFile)
            {
                FileCriminalAutorizationPath = @"YPIFiles\" + hiddenID.Value + "-" + "AutorizationFile-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileCriminalAutorization.PostedFile.FileName.ToString());
                FileCriminalAutorization.PostedFile.SaveAs(Server.MapPath(FileCriminalAutorizationPath));
                BIDCommand.Parameters.AddWithValue("@FileCriminalAutorization", SqlDbType.NVarChar).Value = FileCriminalAutorizationPath;
            }
            if (FileAcademicQualification.HasFile)
            {
                FileAcademicQualificationPath = @"YPIFiles\" + hiddenID.Value + "-" + "AcademicQualification-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileAcademicQualification.PostedFile.FileName.ToString());
                FileAcademicQualification.PostedFile.SaveAs(Server.MapPath(FileAcademicQualificationPath));
                BIDCommand.Parameters.AddWithValue("@FileAcademicQualification", SqlDbType.NVarChar).Value = FileAcademicQualificationPath;
            }
            if (FileAgriculture.HasFile)
            {
                FileAgriculturePath = @"YPIFiles\" + hiddenID.Value + "-" + "Agriculture-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileAgriculture.PostedFile.FileName.ToString());
                FileAgriculture.PostedFile.SaveAs(Server.MapPath(FileAgriculturePath));
                BIDCommand.Parameters.AddWithValue("@FileAgriculture", SqlDbType.NVarChar).Value = FileAgriculturePath;
            }

            BIDCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            BIDCommand.Connection = cnn;
            try
            {
                BIDCommand.ExecuteNonQuery();
                string MemberBID = BIDCommand.Parameters["@Message"].Value.ToString();
                if (!MemberBID.Equals("01"))
                {
                    cnn.Close();

                    Session["ini_YPIbid"] = MemberBID;
                    Response.Redirect("thankyou.aspx", false);
                }
                else
                {

                    alert.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            cnn.Close();
        }
    }


    protected void DrpFromWhere_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpFromWhere.SelectedValue.Equals("5"))
        {

            OtherPanel.Visible = true;
            pnlBusinessNursy.Visible = false;
        }
        else if (DrpFromWhere.SelectedValue.Equals("4"))
        {

            OtherPanel.Visible = false;
            pnlBusinessNursy.Visible = true;
            DrpBusinessNursy.Items.Clear();
            cnn.ConnectionString = gm.ConnectionStringMYAPI();
            cnn.Open();
            SqlCommand command = new SqlCommand("PIBusinessNurseryLoad", cnn);
            command.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            command.ExecuteNonQuery();
            da.Fill(ds);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DrpBusinessNursy.Items.Insert(0, new ListItem("--Select--", "0"));
                    DrpBusinessNursy.DataSource = ds.Tables[0];
                    DrpBusinessNursy.DataTextField = "NameAr";
                    DrpBusinessNursy.DataValueField = "id";
                    DrpBusinessNursy.DataBind();

                }

            }
        }
        else
        {

            OtherPanel.Visible = false;
            pnlBusinessNursy.Visible = false;
            DrpBusinessNursy.Items.Clear();
        }
    }

    protected void DrpBusinessNursy_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}