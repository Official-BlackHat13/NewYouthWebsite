using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
public partial class StadiumCMS_Create_Stadium : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();

            fillGovernorate();

            fillArea(DDLGovernorate.SelectedValue);

            fillSchool(DDLArea.SelectedValue);

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {
                img_pic.Visible = false;
                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }

    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
        else
        {
            DDLGovernorate.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
    }

    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillArea(DDLGovernorate.SelectedValue);
    }

    private void fillArea(string StrGovernorateID)
    {
        string cmd;
        DataTable dt;
        cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + StrGovernorateID + "  order by AreaName asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }

    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSchool(DDLArea.SelectedValue);
    }
    private void fillSchool(string StrAreaID)
    {
        string cmd;
        DataTable dt;
      
            cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' and AreaID=" + StrAreaID + "  order by SchoolName asc ";
       
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLSchool.DataSource = dt;
            DDLSchool.DataTextField = "SchoolName";
            DDLSchool.DataValueField = "SchoolID";
            DDLSchool.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
        }
        else
        {
            DDLSchool.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();

        

       dt = dbFunctions.GetData("select * from [MYA_Maleabna_Stadium] where StadiumID=" + Request.QueryString["id"]);
       
        if (dt.Rows.Count != 0)
        {

            if (!DBNull.Value.Equals(dt.Rows[0]["GovernorateID"]))
                DDLGovernorate.SelectedValue = dt.Rows[0]["GovernorateID"].ToString();

            fillArea(DDLGovernorate.SelectedValue);


            if (!DBNull.Value.Equals(dt.Rows[0]["AreaID"]))
                DDLArea.SelectedValue = dt.Rows[0]["AreaID"].ToString();

            fillSchool(DDLArea.SelectedValue);

            if (!DBNull.Value.Equals(dt.Rows[0]["SchoolID"]))
                DDLSchool.SelectedValue = dt.Rows[0]["SchoolID"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["StadiumName"]))      // Here you can also check for DBNull or Empty string
                TxtStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["StadiumNameEn"]))
                TxtStadiumNameEn.Text = dt.Rows[0]["StadiumNameEn"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["Address"]))
                TxtAddress.Text = dt.Rows[0]["Address"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["AddressEn"]))
                TxtAddressEn.Text = dt.Rows[0]["AddressEn"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["KuwaitfinderNumber"]))
                TxtKuwaitfinderNumber.Text = dt.Rows[0]["KuwaitfinderNumber"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["KuwaitfinderLocation"]))
                TxtKuwaitfinderLocation.Text = dt.Rows[0]["KuwaitfinderLocation"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["GoogleMapLocation"]))
                TxtGoogleMapLocation.Text = dt.Rows[0]["GoogleMapLocation"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["Description"]))
                TxtDescription.Text = dt.Rows[0]["Description"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["DescriptionEn"]))
                TxtDescriptionEn.Text = dt.Rows[0]["DescriptionEn"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["Note"]))
                TxtNote.Text = dt.Rows[0]["Note"].ToString();

            DDLType.ClearSelection();
            if (!DBNull.Value.Equals(dt.Rows[0]["Noofplayers"]))
               DDLType.Items.FindByText(dt.Rows[0]["Noofplayers"].ToString().Trim()).Selected = true;

            if (DDLType.SelectedValue == "1")
            {
                DivTerms.Visible = false;
            }

            else if (DDLType.SelectedValue == "2")
            {
                DivTerms.Visible = true;
            }




            if (!DBNull.Value.Equals(dt.Rows[0]["StadiumMainImage"]))
            {
                img_pic.Visible = true;
                img_pic.Src = "~/" + System.Configuration.ConfigurationManager.AppSettings["StadiumMainImage"] + dt.Rows[0]["StadiumMainImage"].ToString();
                labPhotoFile.Text = dt.Rows[0]["StadiumMainImage"].ToString();
            }
            else { img_pic.Visible = false; }


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";


        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }


        #region CheckBoxCheckeOrNot
               
            dt = dbFunctions.GetData("select * from [MYA_Maleabna_Stadium_Detail] where StadiumID=" + Request.QueryString["id"]);
            if (dt.Rows.Count != 0)
            {

                if (dt.Rows.Count == 1)
                {
                    chkmembers.Checked = false;
                    if (dt.Rows[0]["StadiumType"].ToString().Trim() == "Sevens")
                        ViewState["StadiumType"] = "7";
                    if (dt.Rows[0]["StadiumType"].ToString().Trim() == "Elevens")
                        ViewState["StadiumType"] = "11";
                }
                else if (dt.Rows.Count == 3 && DDLType.SelectedValue == "2")
                {
                    ViewState["StadiumType"] = "1";
                    chkmembers.Checked = true;
                }

            }

            else
            {
                ViewState["StadiumType"] = "0";
                chkmembers.Checked = false;
                chkmembers.AutoPostBack = false;
            }
       
        #endregion

    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
            Response.Redirect("Manage_Stadium.aspx");
        else
            Response.Redirect("Create_Stadium.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();


        string file;
        string ext;


        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {
            #region Insert
            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtStadiumName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

                string te = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["StadiumMainImage"]) + file;

                uFile1.PostedFile.SaveAs(Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["StadiumMainImage"]) + file);
            }

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_Stadium(GovernorateID,AreaID,SchoolID,StadiumName,StadiumNameEn,Address,AddressEn,KuwaitfinderNumber,KuwaitfinderLocation,GoogleMapLocation,Description,DescriptionEn,Note,StadiumMainImage,Noofplayers,Gender) values(@GovernorateID,@AreaID,@SchoolID,@StadiumName,@StadiumNameEn,@Address,@AddressEn,@KuwaitFinderNumber,@KuwaitFinderLocation,@GoogleMapLocation,@Description,@DescriptionEn,@Note,@StadiumMainImage,@Noofplayers,@Gender)";

            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@StadiumName", TxtStadiumName.Text);

            sqlCommand.Parameters.AddWithValue("@StadiumNameEn", TxtStadiumNameEn.Text);

            sqlCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);

            sqlCommand.Parameters.AddWithValue("@AddressEn", TxtAddressEn.Text);

            sqlCommand.Parameters.AddWithValue("@KuwaitFinderNumber", TxtKuwaitfinderNumber.Text);

            sqlCommand.Parameters.AddWithValue("@KuwaitFinderLocation", TxtKuwaitfinderLocation.Text);

            sqlCommand.Parameters.AddWithValue("@GoogleMapLocation", TxtGoogleMapLocation.Text);

            sqlCommand.Parameters.AddWithValue("@Description", TxtDescription.Text);

            sqlCommand.Parameters.AddWithValue("@DescriptionEn", TxtDescriptionEn.Text);

            sqlCommand.Parameters.AddWithValue("@Note", TxtNote.Text);

            sqlCommand.Parameters.AddWithValue("@Noofplayers", DDLType.SelectedItem.Text.Trim());

            sqlCommand.Parameters.AddWithValue("@StadiumMainImage", file);

            sqlCommand.Parameters.AddWithValue("@Gender", DDLgender.SelectedItem.Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 StadiumID as NewID from [MYA_Maleabna_Stadium] order by StadiumID desc";
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

                if(DDLType.SelectedValue == "1")
                    addStadiumDetails(StrNewID, "Sevens", 2);
                else if (DDLType.SelectedValue == "2")
                {
                    if (chkmembers.Checked)
                    {
                        addStadiumDetails(StrNewID, "Sevens", 2);
                        addStadiumDetails(StrNewID, "Sevens", 2);
                    }

                    addStadiumDetails(StrNewID, "Elevens", 4);
                }


               

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Stadium", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtStadiumName.Text + "", "");
               
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium Infomation Has Been Created Successfully', 'success');", true);

                DDLGovernorate.SelectedValue = "0";
                DDLArea.SelectedValue = "0";
                DDLSchool.SelectedValue = "0";

                TxtStadiumName.Text = "";
                TxtStadiumNameEn.Text = "";
                TxtAddress.Text = "";
                TxtAddressEn.Text = "";
                TxtKuwaitfinderNumber.Text = "";
                TxtKuwaitfinderLocation.Text = "";
                TxtGoogleMapLocation.Text = "";
                TxtDescription.Text = "";
                TxtDescriptionEn.Text = "";
               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
            #endregion
        }
        else
        {
            #region Update
            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtStadiumName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile1.PostedFile.SaveAs(Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["StadiumMainImage"]) + file);
            }
            else
            {
                file = labPhotoFile.Text;
            }



            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_Maleabna_Stadium set GovernorateID=@GovernorateID,AreaID=@AreaID,SchoolID=@SchoolID,StadiumName=@StadiumName,StadiumNameEn=@StadiumNameEn,Address=@Address,AddressEn=@AddressEn,Description=@Description,DescriptionEn=@DescriptionEn,GoogleMapLocation=@GoogleMapLocation,KuwaitFinderNumber=@KuwaitFinderNumber,KuwaitFinderLocation=@KuwaitFinderLocation,Note=@Note,StadiumMainImage=@StadiumMainImage,Noofplayers=@Noofplayers,Gender=@Gender where StadiumID=@StadiumID";

            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@StadiumName", TxtStadiumName.Text);

            sqlCommand.Parameters.AddWithValue("@StadiumNameEn", TxtStadiumNameEn.Text);

            sqlCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);

            sqlCommand.Parameters.AddWithValue("@AddressEn", TxtAddressEn.Text);

            sqlCommand.Parameters.AddWithValue("@Description", TxtDescription.Text);

            sqlCommand.Parameters.AddWithValue("@DescriptionEn", TxtDescriptionEn.Text);

            sqlCommand.Parameters.AddWithValue("@GoogleMapLocation", TxtGoogleMapLocation.Text);

            sqlCommand.Parameters.AddWithValue("@KuwaitFinderNumber", TxtKuwaitfinderNumber.Text);

            sqlCommand.Parameters.AddWithValue("@KuwaitFinderLocation", TxtKuwaitfinderLocation.Text);

            sqlCommand.Parameters.AddWithValue("@Note", TxtNote.Text);

            sqlCommand.Parameters.AddWithValue("Noofplayers", DDLType.SelectedItem.Text.Trim());

            sqlCommand.Parameters.AddWithValue("@StadiumMainImage", file);

            sqlCommand.Parameters.AddWithValue("@StadiumID", Request.QueryString["id"].ToString());

            sqlCommand.Parameters.AddWithValue("@Gender", DDLgender.SelectedItem.Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                Stadium();

                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Stadium", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtStadiumName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium Infomation Has Been Modified Successfully', 'success');", true);
                fillData();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
            #endregion
        }
    }

    private void Stadium()
    {
        if (ViewState["StadiumType"].ToString() == "0")
        {
            if (DDLType.SelectedValue == "1")
                addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
            else if (DDLType.SelectedValue == "2")
            {
                if (chkmembers.Checked)
                {
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                }

                addStadiumDetails(Request.QueryString["id"].ToString(), "Elevens", 4);
            }
        }


        if (ViewState["StadiumType"].ToString() == "7")
        {
            if (DDLType.SelectedValue == "2")
            {
                UpdateStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", "Elevens", 4);
                if (chkmembers.Checked)
                {
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                }


            }
        }

        else if (ViewState["StadiumType"].ToString() == "11")
        {
            if (DDLType.SelectedValue == "1")
            {
                UpdateStadiumDetails(Request.QueryString["id"].ToString(), "Elevens", "Sevens", 2);
            }
            else if (DDLType.SelectedValue == "2")
            {
                if (chkmembers.Checked)
                {
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                    addStadiumDetails(Request.QueryString["id"].ToString(), "Sevens", 2);
                }
            }
        }
        else if (ViewState["StadiumType"].ToString() == "1")
        {
            if (DDLType.SelectedValue == "1")
            {
                DeleteStadiumDetails(Request.QueryString["id"].ToString(), "Elevens");
                DeleteStadiumDetails(Request.QueryString["id"].ToString(), "Sevens");
            }
            
        }
    }
    private void UpdateStadiumDetails(string id, string oldStadiumType, string newStadiumType, int newRate)
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "Update MYA_Maleabna_Stadium_Detail set StadiumType='" + newStadiumType + "',Rate = " + newRate + " where StadiumType='" + oldStadiumType + "'and StadiumID =" + id;
        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
        }
    }
    private void DeleteStadiumDetails(string id, string StadiumType)
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Delete top(1) FROM  MYA_Maleabna_Stadium_Detail  where StadiumType='"+StadiumType+"' and StadiumID =" + id ;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }  
    }
    private void addStadiumDetails(string id, string StadiumType,int rate)
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_Stadium_Detail(StadiumID,GovernorateID,AreaID,SchoolID,StadiumType,Rate,Status) values(@StadiumID,@GovernorateID,@AreaID,@SchoolID,@StadiumType,@Rate,@Status)";
            sqlCommand.Parameters.AddWithValue("@StadiumID", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@StadiumType", StadiumType);
            sqlCommand.Parameters.AddWithValue("@Rate", rate);
            sqlCommand.Parameters.AddWithValue("@Status", 1);       

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }           
    }

   
    protected void chkmembers_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkmembers.Checked)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (ViewState["StadiumType"].ToString() == "1")
                {
                    //compare with booking table
                    DataTable dt = new DataTable();
                    string cmd = " select BookingID  FROM [dbo].[MYA_Maleabna_Booking] B join MYA_Maleabna_Stadium_Detail D on B.StadiumDetId = D.StadiumDetId where D.StadiumType='Sevens' and D.StadiumID =" + Request.QueryString["id"];
                    try
                    {
                        dt = dbFunctions.GetData(cmd);
                        if (dt.Rows.Count != 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium is booked. Can not Change', 'Success');", true);

                            chkmembers.Checked = true;
                        }
                        else
                        {
                            cmd = " Delete FROM  MYA_Maleabna_Stadium_Detail  where StadiumType='Sevens' and StadiumID =" + Request.QueryString["id"];
                            dbFunctions.ExecuteQuery(cmd);

                        }

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                    }
                }               
            }
        }
    }
    protected void DDLType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLType.SelectedValue != "0")
        {
            if (DDLType.SelectedValue == "2")
            {
                DivTerms.Visible = true;
                //chkmembers_CheckedChanged(null, null);
            }
            else if(DDLType.SelectedValue == "1")
            {
                DivTerms.Visible = false;
               // chkmembers_CheckedChanged(null, null);
            }

            
        }
    }
}