using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_ChangePassword : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            EvalCurrentUser.CheckLoggedIn();
            txtUsername.Text = Session["MaleabnaEvalUserName"].ToString();
            txtpwdFromDB.Text = GetPwd();
        }
    }


    public void lnkUpdate_Click(object sender, EventArgs e)
    {
        Page.Validate("ChangePassword");
        if (Page.IsValid)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = dbFunctions.ConnectionString;

            SqlCommand command = new SqlCommand("SP_MYA_Maleabna_Evaluate_Users");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = sqlconnection;


            command.Parameters.AddWithValue("@flag", "PU");
            command.Parameters.AddWithValue("@UserID", Session["MaleabnaEvalUserName"]);
            command.Parameters.AddWithValue("@Password", txtnewpassword.Text.Trim());

            try
            {
                sqlconnection.Open();
                command.ExecuteNonQuery();
                sqlconnection.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Account Information Updated Successfilly!');", true);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid  Password!');", true);
        }

    }


    protected string GetPwd()
    {
        string Result = "";

        SqlConnection sqlconnection = new SqlConnection();
        sqlconnection.ConnectionString = dbFunctions.ConnectionString;

        SqlCommand command = new SqlCommand("SP_MYA_Maleabna_Evaluate_Users");
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = sqlconnection;


        command.Parameters.AddWithValue("@flag", "PS");
        command.Parameters.AddWithValue("@Username", Session["MaleabnaEvalUserName"]);
        SqlDataAdapter da = new SqlDataAdapter(command);
        DataTable dt = new DataTable();

        try
        {
            sqlconnection.Open();
            command.ExecuteNonQuery();
            da.Fill(dt);
            sqlconnection.Close();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
        }

        if (dt.Rows.Count > 0)
        {
            Result = dt.Rows[0]["Password"].ToString();
        }
        else
            Result = "";

        return Result;

    }
    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Eval_Stadium.aspx",false);
    }
}