using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Create_Guard : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();



            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {

                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }
    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select * from [MYA_Maleabna_Guard] where GuardID=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["GuardName"]))      // Here you can also check for DBNull or Empty string
                TxtGuardName.Text = dt.Rows[0]["GuardName"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["Mobile"]))
                TxtMobile.Text = dt.Rows[0]["Mobile"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["CivilID"]))
                TxtCivilID.Text = dt.Rows[0]["CivilID"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Note"]))
                TxtNote.Text = dt.Rows[0]["Note"].ToString();

            StatusDiv.Visible = true;
            CHK_status.Checked = bool.Parse(dt.Rows[0]["Status"].ToString());

           

            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }

    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
            Response.Redirect("Manage_Guard.aspx");
        else
            Response.Redirect("Create_Guard.aspx.aspx");
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

            sqlCommand.CommandText = "insert into MYA_Maleabna_Guard(GuardName,Mobile,CivilID,Note) values(@GuardName,@Mobile,@CivilID,@Note)";

            sqlCommand.Parameters.AddWithValue("@GuardName", TxtGuardName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Note", TxtNote.Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 GuardID as NewID from [MYA_Maleabna_Guard] order by GuardID desc";
                try
                {
                    dt = dbFunctions.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Guard", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtGuardName.Text + "", "");

                
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Guard Infomation Has Been Created Successfully', 'success');", true);
                TxtGuardName.Text = "";
                TxtMobile.Text = "";
                TxtCivilID.Text = "";
                TxtNote.Text = "";
               
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


            sqlCommand.CommandText = "update MYA_Maleabna_Guard set GuardName=@GuardName,Mobile=@Mobile,CivilID=@CivilID,Note=@Note, Status=@Status where GuardID=@GuardID";


            sqlCommand.Parameters.AddWithValue("@GuardName", TxtGuardName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Note", TxtNote.Text);

            sqlCommand.Parameters.AddWithValue("@Status", CHK_status.Checked);

            sqlCommand.Parameters.AddWithValue("@GuardID", Request.QueryString["id"].ToString());


            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Guard", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtGuardName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Guard Infomation Has Been Modified Successfully', 'success');", true);
                fillData();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }
    }
}