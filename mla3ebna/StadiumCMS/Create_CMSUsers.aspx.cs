using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Create_CMSUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        CMSCurrentUser.CheckLoggedIn();


      //  string test = hidTest.Value;
       // Response.Write(test);
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {

            if (!IsPostBack) {

                fillData();
            }
           
           
        }


       // fillGovernorate();
    }


    private void fillData()
    {

        SqlConnection SqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand command = new SqlCommand("SP_AddEdit_MYA_MaleabnaCMSUsers", SqlConnection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@UserID", Request.QueryString["id"]);
        command.Parameters.AddWithValue("@flag", "S");

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        try
        {
            SqlConnection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            SqlConnection.Close();
        }

        #region FillTableValues
        if (dt.Rows.Count != 0)
        {

            if (!DBNull.Value.Equals(dt.Rows[0]["Username"]))
                TxtUserName.Text = dt.Rows[0]["Username"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Password"]))
                TxtPassword.Text = dt.Rows[0]["Password"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))
                TxtName.Text = dt.Rows[0]["Name"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Email"]))
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["Mobile"]))
                TxtEmail.Text = dt.Rows[0]["Mobile"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["CivilID"]))
                TxtCivilID.Text = dt.Rows[0]["CivilID"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["UserType"]))
                DDLUserType.Items.FindByValue(dt.Rows[0]["UserType"].ToString()).Selected = true;
           // DDLUserType_SelectedIndexChanged(null, null);
                

            if (!DBNull.Value.Equals(dt.Rows[0]["Users"]))
                CH_Users.Checked = bool.Parse(dt.Rows[0]["Users"].ToString());


            if (!DBNull.Value.Equals(dt.Rows[0]["Settings"]))
                CH_Settings.Checked = bool.Parse(dt.Rows[0]["Settings"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Stadium"]))
                CH_Stadium.Checked = bool.Parse(dt.Rows[0]["Stadium"].ToString());


            if (!DBNull.Value.Equals(dt.Rows[0]["Members"]))
                CH_Members.Checked = bool.Parse(dt.Rows[0]["Members"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Pages"]))
                CH_Pages.Checked = bool.Parse(dt.Rows[0]["Pages"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Banner"]))
                CH_Banner.Checked = bool.Parse(dt.Rows[0]["Banner"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["DropDowns"]))
                CH_DropDowns.Checked = bool.Parse(dt.Rows[0]["DropDowns"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Reports"]))
                CH_Report.Checked = bool.Parse(dt.Rows[0]["Reports"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Booking"]))
                CH_Booking.Checked = bool.Parse(dt.Rows[0]["Booking"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["BlockStadium"]))
                CH_Block.Checked = bool.Parse(dt.Rows[0]["BlockStadium"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Contact"]))
                CH_Contact.Checked = bool.Parse(dt.Rows[0]["Contact"].ToString());

            if (!DBNull.Value.Equals(dt.Rows[0]["Delete"]))
                CH_Delete.Checked = bool.Parse(dt.Rows[0]["Delete"].ToString());

            if (DDLUserType.SelectedValue == "2")
            {
                pnlLocation.Visible = true;

                fillGovernorate();
                //fillArea();
                //fillSchool();
                //fillStadium();
             

                string id = string.Empty;
                if (!DBNull.Value.Equals(dt.Rows[0]["GovernorateID"]))
                    id = dt.Rows[0]["GovernorateID"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "GovernorateSelect();", "GovernorateSelect('" + id + "');", true);
                fillArea(id);

                id = string.Empty;
                if (!DBNull.Value.Equals(dt.Rows[0]["AreaID"]))
                    id = dt.Rows[0]["AreaID"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AreaSelect();", "AreaSelect('" + id + "');", true);
                fillSchool(id);

                id = string.Empty;
                if (!DBNull.Value.Equals(dt.Rows[0]["SchoolID"]))
                    id = dt.Rows[0]["SchoolID"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SchoolSelect();", "SchoolSelect('" + id + "');", true);
                fillStadium(id);

                id = string.Empty;
                if (!DBNull.Value.Equals(dt.Rows[0]["StadiumID"]))
                    id = dt.Rows[0]["StadiumID"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "StadiumSelect();", "StadiumSelect('" + id + "');", true);

            }
            else if (DDLUserType.SelectedValue == "1")
            {
                pnlLocation.Visible = false;
            }
           


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";


        }
        else
        {
           // lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }
        #endregion

    }

    protected void FillStadium()
    {

    }
   

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        String SuccessMessgae = "";
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand("SP_AddEdit_MYA_MaleabnaCMSUsers");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType= CommandType.StoredProcedure;

       

        
        sqlCommand.Parameters.AddWithValue("@Username", TxtUserName.Text );
        sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text );
        sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);
        sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);
        sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);
        sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);
        sqlCommand.Parameters.AddWithValue("@UserType", DDLUserType.SelectedValue);
        sqlCommand.Parameters.AddWithValue("@Users", CH_Users.Checked );
        sqlCommand.Parameters.AddWithValue("@Settings", CH_Settings.Checked );
        sqlCommand.Parameters.AddWithValue("@Stadium", CH_Stadium.Checked);
        sqlCommand.Parameters.AddWithValue("@Members", CH_Members.Checked);
        sqlCommand.Parameters.AddWithValue("@Pages", CH_Pages.Checked ); 
        sqlCommand.Parameters.AddWithValue("@Banner", CH_Banner.Checked );
        sqlCommand.Parameters.AddWithValue("@DropDowns", CH_DropDowns.Checked );
        sqlCommand.Parameters.AddWithValue("@Reports", CH_Report.Checked);
        sqlCommand.Parameters.AddWithValue("@Booking", CH_Booking.Checked);
        sqlCommand.Parameters.AddWithValue("@BlockStadium", CH_Block.Checked);
        sqlCommand.Parameters.AddWithValue("@Contact", CH_Contact.Checked);
        sqlCommand.Parameters.AddWithValue("@del", CH_Delete.Checked);


        if (DDLUserType.SelectedValue == "2")
        {
            sqlCommand.Parameters.AddWithValue("@govid", hGov.Value);
            sqlCommand.Parameters.AddWithValue("@areaid", hArea.Value);
            sqlCommand.Parameters.AddWithValue("@schoolid", hSchool.Value);
            sqlCommand.Parameters.AddWithValue("@stadiumid", hStadium.Value);
        }


        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {

            sqlCommand.Parameters.AddWithValue("@flag", "I");
            SuccessMessgae = "Added Successfully";
        }       
        else
        {
            sqlCommand.Parameters.AddWithValue("@flag", "U");
            sqlCommand.Parameters.AddWithValue("@UserID", Request.QueryString["id"]);
            SuccessMessgae = "Updated Successfully";
        }

        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
        finally
        {
            sqlConnection.Close();
        }

               
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('','"+SuccessMessgae+" ', 'success');", true);
    }

  
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }

    protected void DDLUserType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DDLUserType.SelectedValue.Equals("2"))
        {

            pnlLocation.Visible = true;

            fillGovernorate();

        }
        else
        {
            pnlLocation.Visible = false;

        
        }
    
    }
  
    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        cmd = "select GovernorateID,GovernorateName GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

          
        }
        else
        {
            DDLGovernorate.Items.Clear();


        }
    }

    private void fillArea(string id)
    {
        string cmd;
        DataTable dt;
        //cmd = "select AreaID,AreaName  AreaName from [MYA_Maleabna_Area] where Status='" + true + "'  order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStaiums @id='" + id + "',@type='area'");
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "Name";
            DDLArea.DataValueField = "ID";
            DDLArea.DataBind();          
        }
        else
        {
            DDLArea.Items.Clear();
        }
    }
    private void fillSchool(string id)
    {
        DDLStadium.Items.Clear();

        string cmd;
        DataTable dt;
       
        //    cmd = "select SchoolID,SchoolName AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' order by SchoolName asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStaiums @id='" + id + "',@type='school'");
        if (dt.Rows.Count != 0)
        {
            DDLSchool.DataSource = dt;
            DDLSchool.DataTextField = "Name";
            DDLSchool.DataValueField = "ID";
            DDLSchool.DataBind();
        }
        else
        {
            DDLSchool.Items.Clear();
        }
    }

    private void fillStadium(string id)
    {


        string cmd;
        DataTable dt;

      
      //cmd = "select StadiumID,StadiumName  AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' order by StadiumName asc ";

      //  dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStaiums @id='" + id + "',@type='stadium'");
        if (dt.Rows.Count != 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "Name";
            DDLStadium.DataValueField = "ID";          
            DDLStadium.DataBind();          
        }
        else
        {
            ListItem it_bo = new ListItem();           
        }
    }
    
  

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<ListItem> GetstadiumData(string id, string type)
    {
        List<ListItem> Details = new List<ListItem>();
        //Area.Add(new object[]
        //{
        //"AreaID", "AreaName"
        //});     

        string query = "exec SP_GetAdminStaiums @id='" + id + "',@type='" + type + "'";


        using (DataTable dt = dbFunctions.GetData(query))
        {
            foreach (DataRow dr in dt.Rows)
            {

                Details.Add(new ListItem
                {
                    Value = dr["ID"].ToString(),
                    Text = dr["Name"].ToString()
                });
            }

        }


        return Details;
    }


   

   
}