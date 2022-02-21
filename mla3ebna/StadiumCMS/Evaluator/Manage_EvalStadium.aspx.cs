using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Manage_EvalStadium : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EvalCurrentUser.CheckLoggedIn();
            fillData();
        }

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

        sqlCommand.Parameters.AddWithValue("@flag", "SL");

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

    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }
    public void Status_selected(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow gvr = (GridViewRow)chk.NamingContainer;
        int RowIndex = gvr.RowIndex;

        // bool val = chk.Checked; // this also will work

        bool isSelected = ((CheckBox)GVData.Rows[RowIndex].Cells[0].FindControl("ch_Status")).Checked;
        int ItemId = Convert.ToInt32(((Label)GVData.Rows[RowIndex].Cells[0].FindControl("labItemID")).Text);


        StatusChange(ItemId, isSelected);

    }

    protected void StatusChange(int EvalID, bool status)
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "SP_MYA_Maleabna_Evaluate_Stadium";        

        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@flag", "Update");
        sqlCommand.Parameters.AddWithValue("@StaEvalID", EvalID);
        sqlCommand.Parameters.AddWithValue("@Status", status);
        sqlCommand.Parameters.AddWithValue("@ModifiedBy", Session["MaleabnaEvalUserID"]);

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

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', ' Status is Changed!!!!', 'success');", true);
    }
}