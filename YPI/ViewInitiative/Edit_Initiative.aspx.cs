using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ViewInitiative_Edit_Initiative : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();
           
            if (!string.IsNullOrEmpty(Request.QueryString["InitiativeID"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {
               

                labtitle1.Text = "إضافة ";
            }
        }
    }
    private void fillData()
    {
        DataTable dt = new DataTable();

        DataSet ds = GetDs("exec ProfessionalInitiativeGetInfo @id='" + Request.QueryString["InitiativeID"]  + "'");
       // dt = dbFunctions_YPI.GetData("select * from [V_AllInitiative] where ID=" + Request.QueryString["InitiativeID"]);

        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "NameAr";
            ddlCategory.DataValueField = "id";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem ("--Category--", "0",true));
        }


        dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            ddlType.DataSource = dt;
            ddlType.DataTextField = "NameAr";
            ddlType.DataValueField = "id";
            ddlType.DataBind();

            ddlType.Items.Insert(0, new ListItem("--مقدم الطلب--", "0", true));
        }


        dt = ds.Tables[2];
        if (dt.Rows.Count != 0)
        {
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue(dt.Rows[0]["CategoryID"].ToString()).Selected = true;

            ddlType.ClearSelection();
            ddlType.Items.FindByValue(dt.Rows[0]["TypeID"].ToString()).Selected = true;

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeName"]))
                TxtInitiativeName.Text = dt.Rows[0]["InitiativeName"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeDesc"]))
                TxtInitiativeDesc.Text = dt.Rows[0]["InitiativeDesc"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["InitiativeObjectives"]))
                TxtInitiativeObjectives.Text = dt.Rows[0]["InitiativeObjectives"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["FileCriminalAutorization"]))
            { 
                labFileCriminalAutorization.Text = "<a target='_blank' href='" + dt.Rows[0]["FileCriminalAutorization"].ToString() + "'>عرض</a>"; //dt.Rows[0]["FileCriminalAutorization"].ToString();
                labFileCriminalAutorization1.Text = dt.Rows[0]["FileCriminalAutorization"].ToString();
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["FileAcademicQualification"]))
            {
                labFileAcademicQualification.Text = "<a target='_blank' href='" + dt.Rows[0]["FileAcademicQualification"].ToString() + "'>عرض</a>";
                labFileAcademicQualification1.Text = dt.Rows[0]["FileAcademicQualification"].ToString();
            }

            labCat.Text = dt.Rows[0]["CategoryID"].ToString();
            if (dt.Rows[0]["CategoryID"].ToString() == "3")
            {

                PanFileAgriculture.Visible = true;
                if (!DBNull.Value.Equals(dt.Rows[0]["FileAgriculture"]))
                {
                    labFileAgriculture.Text = "<a target='_blank' href='" + dt.Rows[0]["FileAgriculture"].ToString() + "'>عرض</a>";
                    labFileAgriculture1.Text = dt.Rows[0]["FileAgriculture"].ToString();
                }
            }
            else
            {
                PanFileAgriculture.Visible = false;
            }

            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }
    }
    public static DataSet GetDs(string qry)
    {
        General gm = new General();
        SqlConnection CN = new SqlConnection();
        CN.ConnectionString = gm.ConnectionStringMYAPI();
        SqlDataAdapter adpt = new SqlDataAdapter(qry, CN);
        DataSet ds = new DataSet();
        CN.Open();
        adpt.Fill(ds);
        CN.Close();
        return ds;

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
       

        string File_CriminalAutorization, File_AcademicQualification, File_Agriculture;

        string ext_CriminalAutorization, ext_AcademicQualification, ext_Agriculture;

        File_CriminalAutorization = "";
        File_AcademicQualification = "";
        File_Agriculture = "";

        File_CriminalAutorization = uFileCriminalAutorization.PostedFile.FileName;

        if (File_CriminalAutorization != "")
        {
            File_CriminalAutorization = Path.GetFileName(File_CriminalAutorization);
            ext_CriminalAutorization = Path.GetExtension(File_CriminalAutorization);
            File_CriminalAutorization = Request.QueryString["InitiativeID"] + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext_CriminalAutorization;
            uFileCriminalAutorization.PostedFile.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["CriminalAutorization"]) + File_CriminalAutorization);
        }
        else
        {
            File_CriminalAutorization = labFileCriminalAutorization1.Text;
        }


        File_AcademicQualification = uFileAcademicQualification.PostedFile.FileName;

        if (File_AcademicQualification != "")
        {
            File_AcademicQualification = Path.GetFileName(File_AcademicQualification);
            ext_AcademicQualification = Path.GetExtension(File_AcademicQualification);
            File_AcademicQualification = Request.QueryString["InitiativeID"] + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext_AcademicQualification;
            uFileAcademicQualification.PostedFile.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["AcademicQualification"]) + File_AcademicQualification);
        }
        else
        {
            File_AcademicQualification = labFileAcademicQualification1.Text;
        }

        if (labCat.Text == "3")
        {
            File_Agriculture = uFileAgriculture.PostedFile.FileName;

            if (File_Agriculture != "")
            {
                File_Agriculture = Path.GetFileName(File_Agriculture);
                ext_Agriculture = Path.GetExtension(File_Agriculture);
                File_Agriculture = Request.QueryString["InitiativeID"] + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext_Agriculture;
                uFileAgriculture.PostedFile.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Agriculture"]) + File_Agriculture);
            }
            else
            {
                File_Agriculture = labFileAgriculture1.Text;
            }

        }




        DataTable dt = new DataTable();

        SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();

        sqlCommand.Connection = sqlConnection;


        sqlCommand.CommandText = "ProfessionalInitiativeSaveChanges";
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);

        sqlCommand.Parameters.AddWithValue("@type", ddlType.SelectedValue);

        sqlCommand.Parameters.AddWithValue("@InitiativeName", TxtInitiativeName.Text);

        sqlCommand.Parameters.AddWithValue("@InitiativeDesc", TxtInitiativeDesc.Text);

        sqlCommand.Parameters.AddWithValue("@InitiativeObjectives", TxtInitiativeObjectives.Text);

        sqlCommand.Parameters.AddWithValue("@FileCriminalAutorization", File_CriminalAutorization);

        sqlCommand.Parameters.AddWithValue("@FileAcademicQualification", File_AcademicQualification);

        sqlCommand.Parameters.AddWithValue("@FileAgriculture", File_Agriculture);

        sqlCommand.Parameters.AddWithValue("@ID", Request.QueryString["InitiativeID"].ToString());



        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Initiative Modified", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + TxtInitiativeName.Text + "", "");
            ViewInitiativeAppInitiativeActivityLog.CreateInitiativeActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Initiative Modified", DateTime.Now, "" + Request.QueryString["InitiativeID"] + "", "" + TxtInitiativeName.Text + "", "", "", "", "", "");
            
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Initiative Information Has Been Modified Successfully');", true);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["InitiativeID"] != "")
            Response.Redirect("View_ViewInitiativeDetails.aspx?InitiativeID=" + Request.QueryString["InitiativeID"] + "");
    }
}