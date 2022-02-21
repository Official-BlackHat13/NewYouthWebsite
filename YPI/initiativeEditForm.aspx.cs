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
            if (!this.IsPostBack)
            {
                loadData();
                checkName();
                checkApplied(Session["userid"].ToString());
            }
            

        }
        else
        {
            Session["page"] = "YPI_page";
            Response.Redirect("../User/Login.aspx", true);
        }
    }
    private void checkApplied(string userID) {
        try
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
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdinitiativeId.Value = ds.Tables[0].Rows[0]["id"].ToString();
                    string typeid = ds.Tables[0].Rows[0]["TypeID"].ToString();
                    RBIntiativeType.ClearSelection();
                    RBIntiativeType.SelectedIndex = RBIntiativeType.Items.IndexOf(RBIntiativeType.Items.FindByValue(typeid));
                    RBIntiativeType_SelectedIndexChanged(null, null);

                    if (ExperiencePanel.Visible == true)
                    {
                        string simproj = (ds.Tables[0].Rows[0]["SimilarProject"].ToString() == "False" ? "0" : "1");
                        ExperienceRadioList.ClearSelection();
                        ExperienceRadioList.SelectedIndex = ExperienceRadioList.Items.IndexOf(ExperienceRadioList.Items.FindByValue(simproj));
                        ExperienceRadioList_SelectedIndexChanged(null, null);
                    }

                    if (TypeofExperienceDivision.Visible == true)
                    {

                        string exp = ds.Tables[0].Rows[0]["ExperienceTypeID"].ToString();
                        RBTypeofExperience.ClearSelection();
                        RBTypeofExperience.SelectedIndex = RBTypeofExperience.Items.IndexOf(RBTypeofExperience.Items.FindByValue(exp));
                        RBTypeofExperience_SelectedIndexChanged(null, null);

                        TxTExperienceProjectDescription.Text = ds.Tables[0].Rows[0]["OldDesc"].ToString();

                        string success = (ds.Tables[0].Rows[0]["Success"].ToString() =="True"? "1" : "0");
                        RBExperienceProjectStatus.ClearSelection();
                        RBExperienceProjectStatus.SelectedIndex = RBExperienceProjectStatus.Items.IndexOf(RBExperienceProjectStatus.Items.FindByValue(success));
                        

                        if (RBExperienceProjectStatus.SelectedValue == "1")
                        {
                            SucessDivision.Visible = true;
                            FailureDivision.Visible = false;
                            TxtSucess.Text = ds.Tables[0].Rows[0]["SuccessDec"].ToString();

                        }
                        else if (RBExperienceProjectStatus.SelectedValue == "0")
                        {
                            SucessDivision.Visible = false;
                            FailureDivision.Visible = true;
                            txtfailure.Text = ds.Tables[0].Rows[0]["ProblemDesc"].ToString();
                        }
                    }                    


                   

                    txtProjectName.Text = ds.Tables[0].Rows[0]["InitiativeName"].ToString();

                    string cate = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    RBProjectCategory.ClearSelection();
                    RBProjectCategory.SelectedIndex = RBProjectCategory.Items.IndexOf(RBProjectCategory.Items.FindByValue(cate));

                    string edu = ds.Tables[0].Rows[0]["EducationQualificationID"].ToString();
                    drpEduQulification.ClearSelection();
                    drpEduQulification.SelectedIndex = drpEduQulification.Items.IndexOf(drpEduQulification.Items.FindByValue(edu));
                    drpEduQulification_SelectedIndexChanged(null, null);


                    TxTProjectDescription.Text = ds.Tables[0].Rows[0]["InitiativeDesc"].ToString();

                    TxtProjectGoal.Text = ds.Tables[0].Rows[0]["InitiativeObjectives"].ToString();

                    string que = ds.Tables[0].Rows[0]["HowKnwAbtUs"].ToString();
                    DrpFromWhere.ClearSelection();
                    DrpFromWhere.SelectedIndex = DrpFromWhere.Items.IndexOf(DrpFromWhere.Items.FindByText(que));
                    //ChooseIncubator
                    string ChooseIncubator = ds.Tables[0].Rows[0]["ChooseIncubator"].ToString();
                    DropChooseIncubator.ClearSelection();
                    DropChooseIncubator.SelectedIndex = DropChooseIncubator.Items.IndexOf(DropChooseIncubator.Items.FindByText(ChooseIncubator));

                    if (DrpFromWhere.SelectedIndex == 0)
                    {
                        DrpFromWhere.ClearSelection();
                        DrpFromWhere.Items.FindByValue("5").Selected = true;                      
                        DrpFromWhere_SelectedIndexChanged(null, null);

                        txtOtherWhere.Text = ds.Tables[0].Rows[0]["HowKnwAbtUs"].ToString();
                    }
                    else if (DrpFromWhere.SelectedIndex == 4)
                    {
                        DrpFromWhere_SelectedIndexChanged(null, null);
                        string incu = ds.Tables[0].Rows[0]["Incublator"].ToString();
                        DrpBusinessNursy.ClearSelection();
                        DrpBusinessNursy.SelectedIndex = DrpBusinessNursy.Items.IndexOf(DrpBusinessNursy.Items.FindByText(incu));
                    }

                    #region files
                   
                    string fileacademic = ds.Tables[0].Rows[0]["FileAcademicQualification"].ToString();
                    if (!string.IsNullOrEmpty(fileacademic))
                    {
                        hdacademic.Value = fileacademic;
                        FileAcademicQualification_a.HRef = fileacademic;
                        FileAcademicQualification_a.Visible = true;
                        RequiredFieldValidator6.Visible = false;
                    }

                    string fileagri = ds.Tables[0].Rows[0]["FileAgriculture"].ToString();
                    if (!string.IsNullOrEmpty(fileagri))
                    {
                        div_fp_agriculture.Visible = true;
                        hdagriculture.Value = fileagri;
                        FileAgriculture_a.HRef = fileagri;
                        FileAgriculture_a.Visible = true;
                        RequiredFieldValidator7.Visible = false;
                    }
                    #endregion

                }

            }
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
            Response.Write(ex);
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

    //private int checkAge()
    //{

    //    general_fn gfn = new general_fn();
    //    string id = userid();
    //    int age = 25; //gfn.checkYPIAge(id.ToString());
    //    return age;
    //}

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
            string query = "ProfessionalInitiativeInfoUpdate";
            SqlCommand BIDCommand = new SqlCommand(query);
            BIDCommand.CommandType = CommandType.StoredProcedure;

            BIDCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = hdinitiativeId.Value;

            BIDCommand.Parameters.AddWithValue("@TypeID", SqlDbType.Int).Value = RBIntiativeType.SelectedValue;
            if (RBIntiativeType.SelectedValue != "1")
            {
                BIDCommand.Parameters.AddWithValue("@SimilarProject", SqlDbType.Int).Value = (RBIntiativeType.SelectedValue != "1" ? ExperienceRadioList.SelectedValue : "");
                BIDCommand.Parameters.AddWithValue("@ExperienceTypeID", SqlDbType.Int).Value = (ExperienceRadioList.SelectedValue == "1" ? RBTypeofExperience.SelectedValue : "");
                BIDCommand.Parameters.AddWithValue("@OldDesc", SqlDbType.NVarChar).Value = TxTExperienceProjectDescription.Text.Trim();
                BIDCommand.Parameters.AddWithValue("@Success", SqlDbType.Int).Value = RBExperienceProjectStatus.SelectedValue;
                BIDCommand.Parameters.AddWithValue("@SuccessDec", SqlDbType.NVarChar).Value = (RBExperienceProjectStatus.SelectedValue == "1" ? TxtSucess.Text : "");
                BIDCommand.Parameters.AddWithValue("@ProblemDesc", SqlDbType.NVarChar).Value = (RBExperienceProjectStatus.SelectedValue == "0" ? txtfailure.Text : "");

            }
            else
            {
                BIDCommand.Parameters.AddWithValue("@SimilarProject", SqlDbType.Int).Value = "";
                BIDCommand.Parameters.AddWithValue("@ExperienceTypeID", SqlDbType.Int).Value = "";
                BIDCommand.Parameters.AddWithValue("@OldDesc", SqlDbType.NVarChar).Value = "";
                BIDCommand.Parameters.AddWithValue("@Success", SqlDbType.Int).Value = "";
                BIDCommand.Parameters.AddWithValue("@SuccessDec", SqlDbType.NVarChar).Value = "";
                BIDCommand.Parameters.AddWithValue("@ProblemDesc", SqlDbType.NVarChar).Value = "";
            }


            BIDCommand.Parameters.AddWithValue("@CategoryID", SqlDbType.Int).Value = RBProjectCategory.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@EducationQualificationID", SqlDbType.Int).Value = drpEduQulification.SelectedValue;
            BIDCommand.Parameters.AddWithValue("@EducationQualificationOther", SqlDbType.NVarChar).Value = TxtEduQuliOther.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@InitiativeName", SqlDbType.NVarChar).Value = txtProjectName.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@InitiativeDesc", SqlDbType.NVarChar).Value = TxTProjectDescription.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@InitiativeObjectives", SqlDbType.NVarChar).Value = TxtProjectGoal.Text.Trim();
            BIDCommand.Parameters.AddWithValue("@HowKnwAbtUs", SqlDbType.NVarChar).Value = (OtherPanel.Visible == true ? txtOtherWhere.Text : DrpFromWhere.SelectedItem.Text);
            BIDCommand.Parameters.AddWithValue("@incubator", SqlDbType.NVarChar).Value = (pnlBusinessNursy.Visible == true ? DrpBusinessNursy.SelectedItem.Text : null);
            BIDCommand.Parameters.AddWithValue("@ChooseIncubator", SqlDbType.NVarChar).Value = DropChooseIncubator.SelectedItem.Text;


            //if (FileCriminalAutorization.HasFile)
            //{
            //    if (FileCriminalAutorization_a.Visible == false)
            //    {
            //        FileCriminalAutorizationPath = @"YPIFiles\" + hiddenID.Value + "-" + "AutorizationFile-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileCriminalAutorization.PostedFile.FileName.ToString());
            //    }
            //    else
            //    {
            //        FileCriminalAutorizationPath = hdcriminal.Value;
            //    }
            //    FileCriminalAutorization.PostedFile.SaveAs(Server.MapPath(FileCriminalAutorizationPath));
            //}
            //else
            //{
            //    FileCriminalAutorizationPath = hdcriminal.Value;
            //}

            //BIDCommand.Parameters.AddWithValue("@FileCriminalAutorization", SqlDbType.NVarChar).Value = FileCriminalAutorizationPath;

            if (FileAcademicQualification.HasFile)
            {
                if (FileAcademicQualification_a.Visible == false)
                {
                    FileAcademicQualificationPath = @"YPIFiles\" + hiddenID.Value + "-" + "AcademicQualification-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileAcademicQualification.PostedFile.FileName.ToString());
                }
                else
                {
                    FileAcademicQualificationPath = hdacademic.Value;
                }
                FileAcademicQualification.PostedFile.SaveAs(Server.MapPath(FileAcademicQualificationPath));
            }
            else
            {
                FileAcademicQualificationPath = hdacademic.Value;
            }
            
            BIDCommand.Parameters.AddWithValue("@FileAcademicQualification", SqlDbType.NVarChar).Value = FileAcademicQualificationPath;


            if (div_fp_agriculture.Visible == true)
            {
                if (FileAgriculture.HasFile)
                {
                    if (FileAgriculture_a.Visible == false)
                    {
                        FileAgriculturePath = @"YPIFiles\" + hiddenID.Value + "-" + "Agriculture-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileAgriculture.PostedFile.FileName.ToString());
                    }
                    else
                    {
                        FileAgriculturePath = hdagriculture.Value;
                    }
                    FileAgriculture.PostedFile.SaveAs(Server.MapPath(FileAgriculturePath));
                }
                else
                {
                    FileAgriculturePath = hdagriculture.Value;
                }
                
            }
            BIDCommand.Parameters.AddWithValue("@FileAgriculture", SqlDbType.NVarChar).Value =  FileAgriculturePath;


            BIDCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            BIDCommand.Connection = cnn;
            try
            {
                BIDCommand.ExecuteNonQuery();
                string MemberBID = BIDCommand.Parameters["@Message"].Value.ToString();
                if (!MemberBID.Equals("01"))
                {
                    cnn.Close();

                  
                    Response.Redirect("thankEdit.aspx", false);
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