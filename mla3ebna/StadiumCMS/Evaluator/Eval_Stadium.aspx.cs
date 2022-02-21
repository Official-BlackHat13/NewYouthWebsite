using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Eval_Stadium : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  string str = Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Evaluate"]) ;
        if (!IsPostBack)
        {
            EvalCurrentUser.CheckLoggedIn();

            HDStadiumID.Value = Session["MaleabnaEvalStadiumID"].ToString();


            if (HttpContext.Current.Session["MaleabnaEvalUserType"].ToString() == "Admin")
                manageEvaluation.Visible = true;
            else
                manageEvaluation.Visible = false;

            TextHonour.Text = HttpContext.Current.Session["MaleabnaEvalName"].ToString();
            TextHonour.Enabled = false;

            FillStadium();

        }
    }

    protected void FillStadium()
    {
        //Session["MaleabnaEvalUserID"]

        DataTable dt = dbFunctions.GetData("exec SP_MYA_Maleabna_Evaluate_GetStadiumByID @userid=" + Session["MaleabnaEvalUserID"]);
        if (dt.Rows.Count > 0)
        {
            chkStadium.DataSource = dt;
            chkStadium.DataTextField = "StadiumName";
            chkStadium.DataValueField = "StadiumID";
            chkStadium.DataBind();
        }
    }
  

    protected void LinkSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate("required");
        if (Page.IsValid)
        {
            string topRimage = "";
            string topLimage = "";
            string botomnRimage = "";
            string botomnLimage = "";
            string ext = "";

            if (fpTopRightImg.FileContent.Length > 0)
            {
                ext = Path.GetExtension(fpTopRightImg.PostedFile.FileName);
                topRimage = HDStadiumID.Value + "_TopRightImage_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

            }

            if (fpTopLeftImg.FileContent.Length > 0)
            {
                ext = Path.GetExtension(fpTopLeftImg.PostedFile.FileName);
                topLimage = HDStadiumID.Value + "_TopLeftImage_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

            }


            if (fpBotomnRightImg.FileContent.Length > 0)
            {
                ext = Path.GetExtension(fpBotomnRightImg.PostedFile.FileName);
                botomnRimage = HDStadiumID.Value + "_BotomnRightImage_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

            }


            if (fpBotomnLeftImg.FileContent.Length > 0)
            {
                ext = Path.GetExtension(fpBotomnLeftImg.PostedFile.FileName);
                botomnLimage = HDStadiumID.Value + "_BotomnLeftImage_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

            }


            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = dbFunctions.ConnectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SP_MYA_Maleabna_Evaluate_StadiumUpdation";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = sqlconnection;

            command.Parameters.AddWithValue("@StadiumID", chkStadium.SelectedValue);   //HDStadiumID.Value
            command.Parameters.AddWithValue("@EvaluationBy", Session["MaleabnaEvalUserID"]);
            command.Parameters.AddWithValue("@StadiumEntrance", (radioEntrance.SelectedValue == "" ? "" : radioEntrance.SelectedItem.Text));
            command.Parameters.AddWithValue("@PlayingField", (RadioPlayField.SelectedValue == "" ? "" : RadioPlayField.SelectedItem.Text));
            command.Parameters.AddWithValue("@Pitch", (RadioPitch.SelectedValue == "" ? "" : RadioPitch.SelectedItem.Text));
            command.Parameters.AddWithValue("@Goal", (RadioGoal.SelectedValue == "" ? "" : RadioGoal.SelectedItem.Text));
            command.Parameters.AddWithValue("@GoalKick", (RadioGoalKick.SelectedValue == "" ? "" : RadioGoalKick.SelectedItem.Text));
            command.Parameters.AddWithValue("@Water", (RadioWater.SelectedValue == "" ? "" : RadioWater.SelectedItem.Text));
            command.Parameters.AddWithValue("@HeadlampLighting", (RadioHeadLamp.SelectedValue == "" ? "" : RadioHeadLamp.SelectedItem.Text));
            command.Parameters.AddWithValue("@Rooms", (RadioWashooms.SelectedValue == "" ? "" : RadioWashooms.SelectedItem.Text));
            command.Parameters.AddWithValue("@Note", TextNote.InnerText.Trim());
            command.Parameters.AddWithValue("@Honour", TextHonour.Text.Trim());
            command.Parameters.AddWithValue("@DistrictAdministrator", TextDistributor.Text.Trim());
            command.Parameters.AddWithValue("@TeamLeader", TextTeamLeader.Text.Trim());

            command.Parameters.AddWithValue("@TopLeftImage", topLimage);
            command.Parameters.AddWithValue("@TopRightImage", topRimage);
            command.Parameters.AddWithValue("@BotomnLeftImage", botomnLimage);
            command.Parameters.AddWithValue("@BotomnRightImage", botomnRimage);

            command.Parameters.AddWithValue("@VideoID", (Session["MaleabnaEvalVideoID"] == null?0:Session["MaleabnaEvalVideoID"]));

            command.Parameters.Add("@ret_val", SqlDbType.Int, 100).Direction = ParameterDirection.Output;


            try
            {
                sqlconnection.Open();
                command.ExecuteNonQuery();

                int ret_val = int.Parse(command.Parameters["@ret_val"].Value.ToString());
                string str = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Evaluate"]);
                if (!ret_val.Equals(0))
                {                   
                    if (fpTopRightImg.FileContent.Length > 0)
                        fpTopRightImg.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Evaluate"]) + topRimage);
                    if (fpTopLeftImg.FileContent.Length > 0)
                        fpTopLeftImg.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Evaluate"]) + topLimage);
                    if (fpBotomnRightImg.FileContent.Length > 0)
                        fpBotomnRightImg.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Evaluate"]) + botomnRimage);
                    if (fpBotomnLeftImg.FileContent.Length > 0)
                        fpBotomnLeftImg.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Evaluate"]) + botomnLimage);

                    if (Session["StadiumEvalID"].ToString() == "")
                    {
                        Session["StadiumEvalID"] = ret_val;
                    }


                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Infomation Added Successfully', 'success');", true);
                    //Response.Redirect("Manage_EvalStadium.aspx", false);
                }


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }

            finally
            {
                sqlconnection.Close();
            }
        }

    }
}