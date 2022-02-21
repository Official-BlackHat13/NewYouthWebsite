using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_StadiumMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            // CMSCurrentUser.CheckLoggedIn();

            if (!string.IsNullOrEmpty(Request.QueryString["StadiumID"]))
            {
                fillStadiumMaintenanceData();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["MaintenanceID"]))
            {

                // labtitle1.Text = "تعديل ";

                fillStadiumMaintenanceDataToEdit();
            }
            else
            {
                img_pic.Visible = false;

                // labtitle1.Text = "إضافة ";
            }

            if (Session["MaleabnaCMSDeleteMenu"].ToString() == "True")
            {
                img_del.Visible = true;

                img_del.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            }
            else
            {
                img_del.Visible = false;

            }
        }
    }


    protected void fillStadiumMaintenanceData()
    {
        hdate.Value = "";
        string cmd = null;
        DataTable dt = default(DataTable);
       // cmd = "select MaintenanceID,format(MaintenanceDate,'MM/dd/yyyy') as MaintenanceDate,MaintenanceType,MaintenanceAmount,MaintenanceBill from [MYA_Maleabna_StadiumMaintenance] where StadiumId= " + Request.QueryString["StadiumID"];
        cmd = "select MaintenanceID,format(MaintenanceDate,'MM/dd/yyyy') as MaintenanceDate,MaintenanceType,MaintenanceAmount,MaintenanceBill from [MYA_Maleabna_StadiumMaintenance] where StadiumID = " + Request.QueryString["StadiumID"];
       
        dt = dbFunctions.GetData(cmd);
        dg.DataSource = dt;
        dg.DataBind();
        //setConfirm();
        //If dt.Rows.Count < 5 Then
        //    dg.PagerStyle.Visible = False
        //End If
        lblCount.Text = dt.Rows.Count + " record(s)";
    }
    protected void fillStadiumMaintenanceDataToEdit()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select format(MaintenanceDate,'MM/dd/yyyy') as MaintenanceDate,MaintenanceType,MaintenanceAmount,MaintenanceBill from [MYA_Maleabna_StadiumMaintenance] where MaintenanceID=" + Request.QueryString["MaintenanceID"]);

       
        
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MaintenanceDate"]))      // Here you can also check for DBNull or Empty string
            {
                string[] date = dt.Rows[0]["MaintenanceDate"].ToString().Split('/');
                string month = date[0].ToString();
                int mon = int.Parse(month);
                mon = mon - 1;
                hdate.Value = mon + "/" + date[1].ToString() + "/" + date[2].ToString();
                //TextMaintenanceDate.Text = dt.Rows[0]["MaintenanceDate"].ToString();
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["MaintenanceType"]))
                TxtMaintenanceType.Text = dt.Rows[0]["MaintenanceType"].ToString().Trim();

            if (!DBNull.Value.Equals(dt.Rows[0]["MaintenanceAmount"]))
                TxtAmount.Text = dt.Rows[0]["MaintenanceAmount"].ToString().Trim();

            if (!DBNull.Value.Equals(dt.Rows[0]["MaintenanceBill"]))
            {
                img_pic.Visible = true;
                img_pic.Src = System.Configuration.ConfigurationManager.AppSettings["StadiumMaintenance"] + dt.Rows[0]["MaintenanceBill"].ToString();
                labPhotoFile.Text = dt.Rows[0]["MaintenanceBill"].ToString();
                RequiredFieldValidator3.Visible = false;
            }
            else
            {
                img_pic.Visible = false;
                RequiredFieldValidator3.Visible = true;
            }
            btnAdd.Text = "Modify";
        }
        else
        {
            btnAdd.Text = "Add";
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

            file = uFile.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtMaintenanceType.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile.PostedFile.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["StadiumMaintenance"]) + file);

                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                #region GetSchoolID

                string SchoolID = "";
                dt = dbFunctions.GetData("select SchoolID from MYA_Maleabna_Stadium where StadiumID = " + Request.QueryString["StadiumID"]);
                if (dt.Rows.Count > 0)
                    SchoolID = dt.Rows[0]["SchoolID"].ToString().Trim();

                #endregion

                sqlCommand.CommandText = "insert into MYA_Maleabna_StadiumMaintenance(SchoolID,StadiumID,MaintenanceDate,MaintenanceType,MaintenanceAmount,MaintenanceBill) values(@SchoolID,@StadiumID,@MaintenanceDate,@MaintenanceType,@MaintenanceAmount,@MaintenanceBill)";

                sqlCommand.Parameters.AddWithValue("@SchoolID", SchoolID);

                sqlCommand.Parameters.AddWithValue("@StadiumID", Request.QueryString["StadiumID"]);

                sqlCommand.Parameters.AddWithValue("@MaintenanceDate", TextMaintenanceDate.Text);

                sqlCommand.Parameters.AddWithValue("@MaintenanceType", TxtMaintenanceType.Text);

                sqlCommand.Parameters.AddWithValue("@MaintenanceAmount", TxtAmount.Text);

                sqlCommand.Parameters.AddWithValue("@MaintenanceBill", file);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    fillStadiumMaintenanceData();



                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Stadium Maintenance Has Been Added Successfully');", true);
                    // fillStadiumGalleryData();
                    TxtMaintenanceType.Text = "";
                    TxtAmount.Text = "";
                    TextMaintenanceDate.Text = "";


                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Provide Image To Upload');", true);
            }
        }
        else
        {
            file = uFile.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtMaintenanceType.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile.PostedFile.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["StadiumMaintenance"]) + file);
            }
            else
            {
                file = labPhotoFile.Text;
            }

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_Maleabna_StadiumMaintenance set MaintenanceDate=@MaintenanceDate,MaintenanceType=@MaintenanceType,MaintenanceAmount=@MaintenanceAmount,MaintenanceBill=@MaintenanceBill where MaintenanceID=@MaintenanceID";


            sqlCommand.Parameters.AddWithValue("@MaintenanceDate", TextMaintenanceDate.Text);

            sqlCommand.Parameters.AddWithValue("@MaintenanceType", TxtMaintenanceType.Text);

            sqlCommand.Parameters.AddWithValue("@MaintenanceAmount", TxtAmount.Text);

            sqlCommand.Parameters.AddWithValue("@MaintenanceBill", file);


            sqlCommand.Parameters.AddWithValue("@MaintenanceID", Request.QueryString["MaintenanceID"]);



            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                //CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");
                fillStadiumMaintenanceData();
                btnAdd.Text = "Add";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Stadium Maintenance Has Been Modified Successfully');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }
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
                cmd = "delete from [MYA_Maleabna_StadiumMaintenance] where [MaintenanceID] = " + dg.Items[i].Cells[1].Text;
                dbFunctions.ExecuteQuery(cmd);
                // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
            }
        }
        fillStadiumMaintenanceData();
    }
}