using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ViewInitiative_Manage_TermsConditionsText : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();


            fillData();

            /// labtitle1.Text = "تعديل ";


        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_TermsConditions]");
        if (dt.Rows.Count != 0)
        {

            if (!DBNull.Value.Equals(dt.Rows[0]["DescriptionEn"]))
                TxtDescriptionEn.Text = dt.Rows[0]["DescriptionEn"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["DescriptionAr"]))
                TxtDescriptionAr.Text = dt.Rows[0]["DescriptionAr"].ToString();


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }

    }
    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_TermsConditions(DescriptionAr,DescriptionEn) values(@DescriptionAr,@DescriptionEn)";

            sqlCommand.Parameters.AddWithValue("@DescriptionAr", TxtDescriptionAr.Text);

            sqlCommand.Parameters.AddWithValue("@DescriptionEn", TxtDescriptionEn.Text);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 id as NewID from [MYA_PI_TermsConditions] order by id desc";
                try
                {
                    dt = dbFunctions_YPI.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
                }

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "TermsConditions", "Add", DateTime.Now, "" + StrNewID + "", "TermsConditions", "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'TermsConditions Infomation Has Been Created Successfully', 'success');", true);

                fillData();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_PI_TermsConditions set DescriptionAr=@DescriptionAr,DescriptionEn=@DescriptionEn";


            sqlCommand.Parameters.AddWithValue("@DescriptionAr", TxtDescriptionAr.Text);

            sqlCommand.Parameters.AddWithValue("@DescriptionEn", TxtDescriptionEn.Text);

            try
            {


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "TermsConditions", "Modify", DateTime.Now, "1", "TermsConditions", "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'TermsConditions Infomation Has Been Updated Successfully', 'success');", true);

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
    }
}