using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Print_EvalStdium : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  EvalCurrentUser.CheckLoggedIn();

            FillData();
        }
    }

    protected void FillData()
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

        if (dt.Rows.Count != 0)
        {
            lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
            lblGovernorateName.Text = dt.Rows[0]["GovernorateName"].ToString();
            LblName.Text = dt.Rows[0]["Name"].ToString();
            lblDate.Text = dt.Rows[0]["CreatedAt"].ToString();

            TxtHonour.Text = dt.Rows[0]["Honour"].ToString();
            TextAdmin.Text = dt.Rows[0]["DistrictAdministrator"].ToString();
            TextTeamLeader.Text = dt.Rows[0]["TeamLeader"].ToString();

            TextNote.InnerText = dt.Rows[0]["Note"].ToString();



            if (!string.IsNullOrEmpty(dt.Rows[0]["TopLeftImage"].ToString()))
                StrTopLeftFile.Attributes["src"] = "../Files/Evaluate/" + dt.Rows[0]["TopLeftImage"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["TopRightImage"].ToString()))
                StrTopRightFile.Attributes["src"] = "../Files/Evaluate/" + dt.Rows[0]["TopRightImage"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["BotomnLeftImage"].ToString()))
                StrBotomnLeftFile.Attributes["src"] = "../Files/Evaluate/" + dt.Rows[0]["BotomnLeftImage"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["BotomnRightImage"].ToString()))
                StrBotomnRightFile.Attributes["src"] = "../Files/Evaluate/" + dt.Rows[0]["BotomnRightImage"].ToString();           

            if (!string.IsNullOrEmpty(dt.Rows[0]["StadiumEntrance"].ToString()))
                radioEntrance.Items.FindByText(dt.Rows[0]["StadiumEntrance"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["PlayingField"].ToString()))
                RadioPlayField.Items.FindByText(dt.Rows[0]["PlayingField"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Pitch"].ToString()))
                RadioPitch.Items.FindByText(dt.Rows[0]["Pitch"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Goal"].ToString()))
                RadioGoal.Items.FindByText(dt.Rows[0]["Goal"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["GoalKick"].ToString()))
                RadioGoalKick.Items.FindByText(dt.Rows[0]["GoalKick"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Water"].ToString()))
                RadioWater.Items.FindByText(dt.Rows[0]["Water"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["HeadlampLighting"].ToString()))
                RadioHeadLamp.Items.FindByText(dt.Rows[0]["HeadlampLighting"].ToString()).Selected = true;

            if (!string.IsNullOrEmpty(dt.Rows[0]["Rooms"].ToString()))
                RadioWashooms.Items.FindByText(dt.Rows[0]["Rooms"].ToString()).Selected = true;       

           
           
        }
    }

    
}