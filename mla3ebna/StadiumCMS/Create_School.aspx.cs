using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Create_School : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();


            fillGovernorate();

            fillArea(DDLGovernorate.SelectedValue);

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {

                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }
    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        //cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='gov',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
        else
        {
            DDLGovernorate.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
    }

    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillArea(DDLGovernorate.SelectedValue);
    }

    private void fillArea(string StrGovernorateID)
    {
        string cmd;
        DataTable dt;
        //cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + StrGovernorateID + "  order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }
    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select * from [MYA_Maleabna_School] where SchoolID=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["SchoolName"]))      // Here you can also check for DBNull or Empty string
                TxtSchoolName.Text = dt.Rows[0]["SchoolName"].ToString();

            DDLGovernorate.ClearSelection();
            if (!DBNull.Value.Equals(dt.Rows[0]["GovernorateID"]))
                DDLGovernorate.SelectedValue = dt.Rows[0]["GovernorateID"].ToString();

            fillArea(DDLGovernorate.SelectedValue);


            DDLArea.ClearSelection();
            if (!DBNull.Value.Equals(dt.Rows[0]["AreaID"]))
                DDLArea.SelectedValue = dt.Rows[0]["AreaID"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["SchoolNameEn"]))
                TxtSchoolNameEn.Text = dt.Rows[0]["SchoolNameEn"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["Address"]))
                TxtAddress.Text = dt.Rows[0]["Address"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["AddressEn"]))
                TxtAddressEn.Text = dt.Rows[0]["AddressEn"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["CivilIDNumber"]))
                TxtCivilIDNumber.Text = dt.Rows[0]["CivilIDNumber"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["TelephoneNo"]))
                TxtTelephoneNo.Text = dt.Rows[0]["TelephoneNo"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Fax"]))
                TxtFax.Text = dt.Rows[0]["Fax"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ContactPersonName"]))
                TxtContactPersonName.Text = dt.Rows[0]["ContactPersonName"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ContactPersonMobile"]))
                TxtContactPersonMobile.Text = dt.Rows[0]["ContactPersonMobile"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ContactPersonEmail"]))
                TxtContactPersonEmail.Text = dt.Rows[0]["ContactPersonEmail"].ToString();




            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }

    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
            Response.Redirect("Manage_School.aspx");
        else
            Response.Redirect("Create_School.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();





        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_School(GovernorateID,AreaID,SchoolName,SchoolNameEn,Address,AddressEn,CivilIDNumber,TelephoneNo,Fax,ContactPersonName,ContactPersonMobile,ContactPersonEmail) values(@GovernorateID,@AreaID,@SchoolName,@SchoolNameEn,@Address,@AddressEn,@CivilIDNumber,@TelephoneNo,@Fax,@ContactPersonName,@ContactPersonMobile,@ContactPersonEmail)";

            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@SchoolName", TxtSchoolName.Text);

            sqlCommand.Parameters.AddWithValue("@SchoolNameEn", TxtSchoolNameEn.Text);

            sqlCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);

            sqlCommand.Parameters.AddWithValue("@AddressEn", TxtAddressEn.Text);

            sqlCommand.Parameters.AddWithValue("@CivilIDNumber", TxtCivilIDNumber.Text);

            sqlCommand.Parameters.AddWithValue("@TelephoneNo", TxtTelephoneNo.Text);

            sqlCommand.Parameters.AddWithValue("@Fax", TxtFax.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonName", TxtContactPersonName.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonMobile", TxtContactPersonMobile.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonEmail", TxtContactPersonEmail.Text);

         

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 SchoolID as NewID from [MYA_Maleabna_School] order by SchoolID desc";
                try
                {
                    dt = dbFunctions.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtSchoolName.Text + "", "");

                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('School Infomation Has Been Created Successfully');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'School Infomation Has Been Created Successfully', 'success');", true);
                DDLGovernorate.SelectedValue = "0";
                DDLArea.SelectedValue = "0";
                TxtSchoolName.Text = "";
                TxtSchoolNameEn.Text = "";
                TxtAddress.Text = "";
                TxtAddressEn.Text = "";
                TxtCivilIDNumber.Text = "";
                TxtTelephoneNo.Text = "";
                TxtFax.Text = "";
                TxtContactPersonName.Text = "";
                TxtContactPersonMobile.Text = "";
                TxtContactPersonEmail.Text = "";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_Maleabna_School set GovernorateID=@GovernorateID,AreaID=@AreaID,SchoolName=@SchoolName,SchoolNameEn=@SchoolNameEn,Address=@Address,AddressEn=@AddressEn,CivilIDNumber=@CivilIDNumber,TelephoneNo=@TelephoneNo,Fax=@Fax,ContactPersonName=@ContactPersonName,ContactPersonMobile=@ContactPersonMobile,ContactPersonEmail=@ContactPersonEmail where SchoolID=@SchoolID";

            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@SchoolName", TxtSchoolName.Text);

            sqlCommand.Parameters.AddWithValue("@SchoolNameEn", TxtSchoolNameEn.Text);

            sqlCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);

            sqlCommand.Parameters.AddWithValue("@AddressEn", TxtAddressEn.Text);

            sqlCommand.Parameters.AddWithValue("@CivilIDNumber", TxtCivilIDNumber.Text);

            sqlCommand.Parameters.AddWithValue("@TelephoneNo", TxtTelephoneNo.Text);

            sqlCommand.Parameters.AddWithValue("@Fax", TxtFax.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonName", TxtContactPersonName.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonMobile", TxtContactPersonMobile.Text);

            sqlCommand.Parameters.AddWithValue("@ContactPersonEmail", TxtContactPersonEmail.Text);

            sqlCommand.Parameters.AddWithValue("@SchoolID", Request.QueryString["id"].ToString());


            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtSchoolName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'School Infomation Has Been Modified Successfully', 'success');", true);
                fillData();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }
    }
}