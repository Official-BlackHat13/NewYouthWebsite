using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Manage_StadiumVideos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            // CMSCurrentUser.CheckLoggedIn();

            if (!string.IsNullOrEmpty(Request.QueryString["StadiumID"]))
            {
                fillStadiumData();
                fillStadiumGalleryData();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {

                // labtitle1.Text = "تعديل ";

                fillStadiumGalleryDataToEdit();
            }
            else
            {


                // labtitle1.Text = "إضافة ";
            }
        }
    }
    private void fillStadiumGalleryDataToEdit()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select * from [MYA_Maleabna_Stadium_Videos] where id=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Title"]))      // Here you can also check for DBNull or Empty string
                TxtName.Text = dt.Rows[0]["Title"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["VideoUrl"]))      // Here you can also check for DBNull or Empty string
                TxtVideoUrl.Text = dt.Rows[0]["VideoUrl"].ToString();

            btnAdd.Text = "Modify";
        }
        else
        {
            btnAdd.Text = "Add";
        }
    }

    private void fillStadiumData()
    {

    }
    private void fillStadiumGalleryData()
    {


        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from [MYA_Maleabna_Stadium_Videos] where StadiumID = " + Request.QueryString["StadiumID"] + " order by [Sort] asc ";
        dt = dbFunctions.GetData(cmd);
        dg.DataSource = dt;
        dg.DataBind();
        //setConfirm();
        //If dt.Rows.Count < 5 Then
        //    dg.PagerStyle.Visible = False
        //End If
        lblCount.Text = dt.Rows.Count + " record(s)";
    }

    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        string file;
        string ext;

        if (btnAdd.Text != "Modify")
        {

           

                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "insert into MYA_Maleabna_Stadium_Videos(StadiumID,Title,VideoUrl) values(@StadiumID,@Title,@VideoUrl)";

                sqlCommand.Parameters.AddWithValue("@StadiumID", Request.QueryString["StadiumID"]);

                sqlCommand.Parameters.AddWithValue("@Title", TxtName.Text);

                sqlCommand.Parameters.AddWithValue("@VideoUrl", TxtVideoUrl.Text);

                try
                {
                    // dbFunctions.ExecuteQuery(cmd);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();




                    // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Stadium Gallery Photo Has Been Uploaded Successfully');", true);
                    fillStadiumGalleryData();
                    TxtName.Text = "";
                TxtVideoUrl.Text = "";




            }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }

            
        }
        else
        {
           

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_Maleabna_Stadium_Videos set Title=@Title,Photo=@Photo where id=@id";


            sqlCommand.Parameters.AddWithValue("@Title", TxtName.Text);


            sqlCommand.Parameters.AddWithValue("@VideoUrl", TxtVideoUrl.Text);


            sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["ID"]);



            try
            {
                // dbFunctions.ExecuteQuery(cmd);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                //CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");
                fillStadiumGalleryData();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Stadium Gallery Photo Has Been Modified Successfully');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }







    }

    public Boolean chkImg(object str)
    {
        try
        {



            if (Convert.ToString(str).IndexOf(".") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void img_del_Click(object sender, ImageClickEventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            if (((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_Maleabna_Stadium_Videos] where [id] = " + dg.Items[i].Cells[1].Text;
                dbFunctions.ExecuteQuery(cmd);
                // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
            }
        }
        fillStadiumGalleryData();
    }

    public void lnkSort_Click(object sender, EventArgs e)
    {
        int i;
        string cmd;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_Maleabna_Stadium_Videos set sort=@sort where id=@id";

            sqlCommand.Parameters.AddWithValue("@sort", ((TextBox)dg.Items[i].Cells[4].FindControl("txtsort")).Text);

            sqlCommand.Parameters.AddWithValue("@id", dg.Items[i].Cells[1].Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }


        }
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Governorate Sort Has Been Updated Successfully', 'success');", true);

        fillStadiumGalleryData();
    }
}