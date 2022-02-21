using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Create_Banner : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();


            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "Modify ";

                fillData();
            }
            else
            {

                img_pic.Visible = false;
                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "Create ";
            }
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select * from [MYA_Maleabna_Banner] where BannerID=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Title"]))      // Here you can also check for DBNull or Empty string
                TxtName.Text = dt.Rows[0]["Title"].ToString();


          
            if (!DBNull.Value.Equals(dt.Rows[0]["BannerImage"]))
            {
                img_pic.Src = "../" + System.Configuration.ConfigurationManager.AppSettings["Banner"] + dt.Rows[0]["BannerImage"].ToString();
                labPhotoFile.Text = dt.Rows[0]["BannerImage"].ToString();
            }



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
            Response.Redirect("Manage_Banner.aspx");
        else
            Response.Redirect("Create_Banner.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        string file;
        string ext;


        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {

            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile1.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Banner"]) + file);
            }

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_Banner(Title,BannerImage) values(@Title,@BannerImage)";

            sqlCommand.Parameters.AddWithValue("@Title", TxtName.Text);

         
            sqlCommand.Parameters.AddWithValue("@BannerImage", file);

         
            try
            {
                // dbFunctions.ExecuteQuery(cmd);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 BannerID as NewID from [MYA_Maleabna_Banner] order by BannerID desc";
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


                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Banner", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");


                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Banner Infomation Has Been Created Successfully', 'success');", true);

                TxtName.Text = "";

              

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else
        {

            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile1.PostedFile.SaveAs(Server.MapPath("../" + System.Configuration.ConfigurationManager.AppSettings["Banner"]) + file);
            }
            else
            {
                file = labPhotoFile.Text;
            }

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_Maleabna_Banner set Title=@Title,BannerImage=@BannerImage where BannerID=@BannerID";


            sqlCommand.Parameters.AddWithValue("@Title", TxtName.Text);


            sqlCommand.Parameters.AddWithValue("@BannerImage", file);


            sqlCommand.Parameters.AddWithValue("@BannerID", Request.QueryString["ID"]);

          

            try
            {
                // dbFunctions.ExecuteQuery(cmd);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

               
                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Banner", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Banner Infomation Has Been Modified Successfully', 'success');", true);
             
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
    }
}