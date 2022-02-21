using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Create_CMSUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        CMSCurrentUser.CheckLoggedIn();

        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {          
            

            fillData();
        }
       
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
            



           


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";


        }
        else
        {
           // lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }
        #endregion

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


        Response.Redirect("Manage_CMSUsers.aspx", true);
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }

    protected void DDLUserType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}