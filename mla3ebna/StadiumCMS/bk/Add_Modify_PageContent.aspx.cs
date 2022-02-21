using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Add_Modify_PageContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();

            if (!string.IsNullOrEmpty(Request.QueryString["PID"]))
            {
                if (Request.QueryString["PID"].ToString() == "1")
                {
                    labbreadcrumbTitle.Text = "عن ملعبنا";
                    labPageTitle.Text = "عن ملعبنا";
                }
                else if (Request.QueryString["PID"].ToString() == "2")
                {
                    labbreadcrumbTitle.Text = "سياسة الخصوصية";
                    labPageTitle.Text = "سياسة الخصوصية";
                }
                else if (Request.QueryString["PID"].ToString() == "3")
                {
                    labbreadcrumbTitle.Text = "سياسة الحجز";
                    labPageTitle.Text = "سياسة الحجز";
                }
                else if (Request.QueryString["PID"].ToString() == "4")
                {
                    labbreadcrumbTitle.Text = "الإتصال بنا";
                    labPageTitle.Text = "الإتصال بنا";
                }
                else if (Request.QueryString["PID"].ToString() == "5")
                {
                    labbreadcrumbTitle.Text = "Introduction";
                    labPageTitle.Text = "Introduction";
                }

            }

                fillData();

            /// labtitle1.Text = "تعديل ";


        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select * from [MYA_Maleabna_PageContent] where PID=" + Request.QueryString["PID"] + "");
        if (dt.Rows.Count != 0)
        {

            if (!DBNull.Value.Equals(dt.Rows[0]["PageContent"]))
                TxtDescription.Text = dt.Rows[0]["PageContent"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["PageContentEn"]))
                TxtDescriptionEn.Text = dt.Rows[0]["PageContentEn"].ToString();


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
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_PageContent(PID,PageContent,PageContentEn) values(@PID,@PageContent,@PageContentEn)";

            sqlCommand.Parameters.AddWithValue("@PID", Request.QueryString["PID"]);

            sqlCommand.Parameters.AddWithValue("@PageContent", TxtDescription.Text);

            sqlCommand.Parameters.AddWithValue("@PageContentEn", TxtDescriptionEn.Text);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 id as NewID from [MYA_Maleabna_PageContent] order by id desc";
                try
                {
                    dt = dbFunctions.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
                }

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, labPageTitle.Text, "Add", DateTime.Now, "" + StrNewID + "", labPageTitle.Text, "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', '" + labPageTitle.Text + " Infomation Has Been Created Successfully', 'success');", true);

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
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_Maleabna_PageContent set PageContent=@PageContent,PageContentEn=@PageContentEn where PID=@PID";


            sqlCommand.Parameters.AddWithValue("@PageContent", TxtDescription.Text);

            sqlCommand.Parameters.AddWithValue("@PageContentEn", TxtDescriptionEn.Text);

            sqlCommand.Parameters.AddWithValue("@PID", Request.QueryString["PID"]);


            try
            {


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, labPageTitle.Text, "Modify", DateTime.Now, Request.QueryString["PID"], labPageTitle.Text, "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', '" + labPageTitle.Text + " Infomation Has Been Updated Successfully', 'success');", true);

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
    }
}