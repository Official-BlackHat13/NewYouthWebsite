using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_View_EvalStadium : System.Web.UI.Page
{
    public string StrPrintbtn, StrTopRightFile, StrTopLeftFile, StrBotomnRightFile, StrBotomnLeftFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        EvalCurrentUser.CheckLoggedIn();
        lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
        fillData();

        StrPrintbtn = " <a class='' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["StadiumEvalID"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";
           
    }

    private void fillData()
    {
        DataTable dt = new DataTable();

        SqlConnection sqlconnection = new SqlConnection();
        sqlconnection.ConnectionString = dbFunctions.ConnectionString;

        SqlCommand command = new SqlCommand("SP_MYA_Maleabna_Evaluate_Stadium");      
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = sqlconnection;

        SqlDataAdapter DataAdapter = new SqlDataAdapter(command);


        command.Parameters.AddWithValue("@StaEvalID", Request.QueryString["StadiumEvalID"]);
        command.Parameters.AddWithValue("@flag", "Details");

        try
        {
            sqlconnection.Open();
            command.ExecuteNonQuery();
            DataAdapter.Fill(dt);

        }
        catch (Exception ex)
        {
        }
        finally
        {
            sqlconnection.Close();
        }


        //dt = dbFunctions.GetData("select * from [V_Members] where UserID=" + Request.QueryString["UserID"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            repeater.DataSource = dt;
            repeater.DataBind();

            if (!string.IsNullOrEmpty(dt.Rows[0]["TopRightImage"].ToString()))
            {
                StrTopRightFile = StrTopRightFile + "<div class='item-media' style='background-image: url(../Files/Evaluate/" + dt.Rows[0]["TopRightImage"] + ");width:200px; height:200px;background-size: cover;'></div>";
                DivTRI.Visible = true;
            }
            else
                DivTRI.Visible = false;



            if (!string.IsNullOrEmpty(dt.Rows[0]["TopLeftImage"].ToString()))
            {
                StrTopLeftFile = StrTopLeftFile + "<div class='item-media' style='background-image: url(../Files/Evaluate/" + dt.Rows[0]["TopLeftImage"] + ");width:200px; height:200px;background-size: cover;'></div>";
                DivTLI.Visible = true;
            }
            else
                DivTLI.Visible = false;



            if (!string.IsNullOrEmpty(dt.Rows[0]["BotomnRightImage"].ToString()))
            {
                StrBotomnRightFile = StrBotomnRightFile + "<div class='item-media' style='background-image: url(../Files/Evaluate/" + dt.Rows[0]["BotomnRightImage"] + ");width:200px; height:200px;background-size: cover;'></div>";
                DivBRI.Visible = true;
            }
            else
                DivBRI.Visible = false;



            if (!string.IsNullOrEmpty(dt.Rows[0]["BotomnLeftImage"].ToString()))
            {
                StrBotomnLeftFile = StrBotomnLeftFile + "<div class='item-media' style='background-image: url(../Files/Evaluate/" + dt.Rows[0]["BotomnLeftImage"] + ");width:200px; height:200px;background-size: cover;'></div>";
                DivBLI.Visible = true;
            }
            else
                DivBLI.Visible = false;




            
           
           

        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        Delete(int.Parse(Request.QueryString["StadiumEvalID"]));
         Response.Redirect("Manage_EvalStadium.aspx", false);
    }

    protected void Delete(int EvalID)
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "SP_MYA_Maleabna_Evaluate_Stadium";

        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@flag", "Delete");
        sqlCommand.Parameters.AddWithValue("@StaEvalID", EvalID);
       
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

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', ' Deleted', 'success');", true);
    }

}