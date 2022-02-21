using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Manage_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EvalCurrentUser.CheckLoggedIn();
        fillData();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }

    private void fillData()
    {


        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "SP_MYA_Maleabna_Evaluate_Stadium";

        sqlCommand.CommandType = CommandType.StoredProcedure;



        if (HttpContext.Current.Session["MaleabnaEvalUserType"].ToString() == "User")
        {
            string s = Session["MaleabnaEvalUserID"].ToString();
            sqlCommand.Parameters.AddWithValue("@flag", "SS");
            sqlCommand.Parameters.AddWithValue("@StaEvalID", Session["MaleabnaEvalUserID"]);

        }
        else  if (HttpContext.Current.Session["MaleabnaEvalUserType"].ToString() == "Admin")
        {        
            sqlCommand.Parameters.AddWithValue("@flag", "SL");
        }

        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();

        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            adapter.Fill(dt);

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
        finally
        {
            sqlConnection.Close();
        }


        GVData.DataSource = dt;
        GVData.DataBind();
        // setConfirm();

        lblCount.Text = dt.Rows.Count + " record(s)";
    }
    protected void GVData_DataBound(object sender, EventArgs e)
    {

    }
}