using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_TimeSlot : System.Web.UI.Page
{

    DataTable timeTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        timeTable.Columns.Add("txtFromHour", Type.GetType("System.String"));
        timeTable.Columns.Add("txtFromMin", Type.GetType("System.String"));
        timeTable.Columns.Add("txtFromMeridian", Type.GetType("System.String"));


        timeTable.Columns.Add("txtToHour", Type.GetType("System.String"));
        timeTable.Columns.Add("txtToMin", Type.GetType("System.String"));
        timeTable.Columns.Add("txtToMeridian", Type.GetType("System.String"));

       
        if (!Page.IsPostBack)
        {

              CMSCurrentUser.CheckLoggedIn();
           // Session["MaleabnaCMSUserID"] = "109";



            for (int i = 0; i < 1; i++) // LOAD THREE TEXTBOX FOR EXAMPLE
            {
                timeTable.Rows.Add(timeTable.NewRow());
                Bind();
            }

        }
    }


    protected void Bind()
    {
        rptTime.DataSource = timeTable;
        rptTime.DataBind();
        reBind();


    }
    protected void reBind()
    {
        int i = 0;
        foreach (RepeaterItem item in rptTime.Items)
        {
            DropDownList ddlfromhour = (DropDownList)item.FindControl("ddlFromHour");
            DropDownList ddlfromMin = (DropDownList)item.FindControl("ddlFromMin");
            DropDownList ddlfromMeridian = (DropDownList)item.FindControl("ddlFromMeridian");

            DropDownList ddltohour = (DropDownList)item.FindControl("ddlToHour");
            DropDownList ddltoMin = (DropDownList)item.FindControl("ddlToMin");
            DropDownList ddltoMeridian = (DropDownList)item.FindControl("ddlToMeridian");


            string fromhour = timeTable.Rows[i]["txtFromHour"].ToString() == "" ? "--Hour--" : timeTable.Rows[i]["txtFromHour"].ToString();
            string frommin = timeTable.Rows[i]["txtFromMin"].ToString() == "" ? "--Min--" : timeTable.Rows[i]["txtFromMin"].ToString();
            string frommeridian = timeTable.Rows[i]["txtFromMeridian"].ToString() == "" ? "--AM/PM--" : timeTable.Rows[i]["txtFromMeridian"].ToString();

            string tohour = timeTable.Rows[i]["txtToHour"].ToString() == "" ? "--Hour--" : timeTable.Rows[i]["txtToHour"].ToString();
            string tomin = timeTable.Rows[i]["txtToMin"].ToString() == "" ? "--Min--" : timeTable.Rows[i]["txtToMin"].ToString();
            string tomeridian = timeTable.Rows[i]["txtToMeridian"].ToString() == "" ? "--AM/PM--" : timeTable.Rows[i]["txtToMeridian"].ToString();
            

            
            ddlfromhour.Items.FindByText(fromhour).Selected = true;
            ddlfromMin.Items.FindByText(frommin).Selected = true;
            ddlfromMeridian.Items.FindByText(frommeridian).Selected = true;

            ddltohour.Items.FindByText(tohour).Selected = true;
            ddltoMin.Items.FindByText(tomin).Selected = true;
            ddltoMeridian.Items.FindByText(tomeridian).Selected = true;

          


            i++;
            
        }
    }

    protected void PopulatetimeTable()
    {
        foreach (RepeaterItem item in rptTime.Items)
        {
            DropDownList ddlfromhour = (DropDownList)item.FindControl("ddlFromHour");
            DropDownList ddlfromMin = (DropDownList)item.FindControl("ddlFromMin");
            DropDownList ddlfromMeridian = (DropDownList)item.FindControl("ddlFromMeridian");

            DropDownList ddltohour = (DropDownList)item.FindControl("ddlToHour");
            DropDownList ddltoMin = (DropDownList)item.FindControl("ddlToMin");
            DropDownList ddltoMeridian = (DropDownList)item.FindControl("ddlToMeridian");

            
            DataRow row = timeTable.NewRow();

            row["txtFromHour"] = ddlfromhour.SelectedItem.Text;
            row["txtFromMin"] = ddlfromMin.SelectedItem.Text;
            row["txtFromMeridian"] = ddlfromMeridian.SelectedItem.Text;


            row["txtToHour"] = ddltohour.SelectedItem.Text;
            row["txtToMin"] = ddltoMin.SelectedItem.Text;
            row["txtToMeridian"] = ddltoMeridian.SelectedItem.Text;

          
            timeTable.Rows.Add(row);
        }
    }
    protected void DDLsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLsite.SelectedValue == "1")
        {
            divtime.Visible = false;
            divCustom.Visible = false;
        }
        else if (DDLsite.SelectedValue == "2")
        {
            divtime.Visible = true;
            divCustom.Visible = false;
        }
        else if (DDLsite.SelectedValue == "3")
        {
            divtime.Visible = true;
            divCustom.Visible = true;
        }

    }
    protected void lnkadd_Click(object sender, EventArgs e)
    {
        PopulatetimeTable();
        timeTable.Rows.Add(timeTable.NewRow());
        Bind();
        lnkcancel.Visible = true;
    }
    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        PopulatetimeTable();

        if (timeTable.Rows.Count > 1)
        {
            timeTable.Rows[timeTable.Rows.Count - 1].Delete();
        }

        if (timeTable.Rows.Count == 1)
        {
            lnkcancel.Visible = false;
        }

        Bind();
    }
    protected void rptTime_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PopulatetimeTable();
        timeTable.Rows[e.Item.ItemIndex].Delete();
        Bind();
    }



    protected void DDLBlockType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLGovernorate.SelectedValue = "0";
        DDLArea.SelectedValue = "0";
        DDLSchool.SelectedValue = "0";
        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";

        if (DDLBlockType.SelectedValue == "1")
        {
            DivGovernorate.Visible = true;


            DivArea.Visible = false;
            DivSchool.Visible = false;
            DivStadium.Visible = false;
            DivCourt.Visible = false;
        }
        else if (DDLBlockType.SelectedValue == "2")
        {
            DivGovernorate.Visible = true;
            DivArea.Visible = true;


            DivSchool.Visible = false;
            DivStadium.Visible = false;
            DivCourt.Visible = false;
        }
        else if (DDLBlockType.SelectedValue == "3")
        {
            DivGovernorate.Visible = true;
            DivArea.Visible = true;
            DivSchool.Visible = true;


            DivStadium.Visible = false;
            DivCourt.Visible = false;
        }
        else if (DDLBlockType.SelectedValue == "4")
        {
            DivGovernorate.Visible = true;
            DivArea.Visible = true;
            DivSchool.Visible = true;
            DivStadium.Visible = true;


            DivCourt.Visible = false;
        }
        else if (DDLBlockType.SelectedValue == "5")
        {
            DivGovernorate.Visible = true;
            DivArea.Visible = true;
            DivSchool.Visible = true;
            DivStadium.Visible = true;
            DivCourt.Visible = true;

        }
       

         fillvalues();
    }
    protected void fillvalues()
    {
        if (DivGovernorate.Visible == true)
            fillGovernorate();
        if (DivArea.Visible == true)
            fillArea();
        if (DivSchool.Visible == true)
            fillSchool();
        if (DivStadium.Visible == true)
            fillStadium();
        if (DivStadium.Visible == true)
            fillStadiumCourt();
    }



    private void fillGovernorate()
    {

        string cmd;
        DataTable dt;
        //cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='gov',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.Items.Clear();
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";

            DDLGovernorate.SelectedValue = null;


            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;

            DDLGovernorate.Items.Add(it_bo);
            //  DDLGovernorate.DataBind();

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

        DDLArea.SelectedValue = "0";

    }
    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {

        fillArea();

        DDLSchool.SelectedValue = "0";
        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";
        
    }
    

    private void fillArea()
    {
        DDLArea.Items.Clear();
        string cmd;
        DataTable dt;
        //if (DDLGovernorate.SelectedValue != "0" || DDLGovernorate.SelectedValue != "")
        //    cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
        //else
        //    cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);


        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);


        
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";

            DDLArea.SelectedValue = null;
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;

            DDLArea.Items.Add(it_bo);
            // DivArea.Visible = true;
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
            // DivArea.Visible = false;

        }
        DDLArea.SelectedValue = "0";
        DDLSchool.SelectedValue = "0";

    }
    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSchool();

        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";
        //DivStadium.Visible = false;
        //DivCourt.Visible = false;

    }
    

    private void fillSchool()
    {
        DDLSchool.Items.Clear();
        string cmd;
        DataTable dt;

        //if (DDLArea.SelectedValue != "0" || DDLArea.SelectedValue != "")
        //    cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' and AreaID=" + DDLArea.SelectedValue + "  order by SchoolName asc ";
        //else
        //    cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' order by SchoolName asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='school',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            DDLSchool.DataSource = dt;
            DDLSchool.DataTextField = "SchoolName";
            DDLSchool.DataValueField = "SchoolID";

            DDLSchool.SelectedValue = null;
            DDLSchool.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
            //  DivSchool.Visible = true;  

        }
        else
        {
            DDLSchool.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
            //  DivSchool.Visible = false;

        }
    }
    protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStadium();
        
        DDLStadiumCourt.SelectedValue = "0";
        // DivCourt.Visible = false;       
    }
    


    private void fillStadium()
    {
        DDLStadium.Items.Clear();
        string cmd;
        DataTable dt;

        //if (DDLSchool.SelectedValue != "0" || DDLSchool.SelectedValue != "")
        //    cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' and SchoolID=" + DDLSchool.SelectedValue + " order by StadiumName asc ";
        //else
        //    cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' order by StadiumName asc ";

        //dt = dbFunctions.GetData(cmd);


         dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='stadium',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@schoolid='" + (DDLSchool.SelectedValue == "0" ? "" : DDLSchool.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";

            DDLStadium.SelectedValue = null;
            DDLStadium.DataBind();

            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;


            DDLStadium.Items.Add(it_bo);
            // DivStadium.Visible = true;
        }
        else
        {
            DDLStadium.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);

            // DivStadium.Visible = false;

        }
    }
    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStadiumCourt();
    }
    



    private void fillStadiumCourt()
    {
        DDLStadiumCourt.Items.Clear();
        string cmd;
        DataTable dt;

        //if (DDLStadium.SelectedValue != "0" || DDLStadium.SelectedValue != "")
        //    cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' and StadiumID=" + DDLStadium.SelectedValue + "  order by StadiumType asc ";
        //else
        //    cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' order by StadiumType asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='court',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@schoolid='" + (DDLSchool.SelectedValue == "0" ? "" : DDLSchool.SelectedValue) + "',@stadiumid='" + (DDLStadium.SelectedValue == "0" ? "" : DDLStadium.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);


        
        if (dt.Rows.Count != 0)
        {
            DDLStadiumCourt.DataSource = dt;
            DDLStadiumCourt.DataTextField = "StadiumType";
            DDLStadiumCourt.DataValueField = "StadiumDetId";

            DDLStadiumCourt.SelectedValue = null;
            DDLStadiumCourt.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadiumCourt.Items.Add(it_bo);


        }
        else
        {
            DDLStadiumCourt.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadiumCourt.Items.Add(it_bo);

        }
    }
    protected void DDLStadiumCourt_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }
   


    protected void lnkAddTime_Click(object sender, EventArgs e)
    {
        string cmd;
            DataTable dt = new DataTable();

            Validate("MainValidate");
            if (Page.IsValid)
            {

                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "insert into MYA_Maleabna_TimeSlot_Master(DateFrm,DateTo,GovernorateID,AreaID,SchoolID,StadiumID,StadiumDetId,status,Type,CustomType) values(@DateFrm,@DateTo,@GovernorateID,@AreaID,@SchoolID,@StadiumID,@StadiumDetId,'1',@Type,@CustomType)";

                sqlCommand.Parameters.AddWithValue("@DateFrm", (DDLsite.SelectedValue != "1"? TxtFromDate.Text: ""));

                sqlCommand.Parameters.AddWithValue("@DateTo", (DDLsite.SelectedValue != "1"? TxtToDate.Text:""));

                sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumID", DDLStadium.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumDetId", DDLStadiumCourt.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@Type", DDLsite.SelectedItem.Text);

                sqlCommand.Parameters.AddWithValue("@CustomType", (divCustom.Visible == true ? DDLBlockType.SelectedItem.Text : "0"));

               
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrMasterID;

                StrMasterID = "";


               // cmd = " select top 1 TimeSlotMasterID as MasterID from [MYA_Maleabna_TimeSlot_Master] order by StadiumID desc";
                cmd = "select max(TimeSlotMasterID) as MasterID FROM [MYA_Maleabna].[dbo].[MYA_Maleabna_TimeSlot_Master]";
                try
                {
                    dt = dbFunctions.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrMasterID = dt.Rows[0]["MasterID"].ToString();

                    InsertTimeSlot(StrMasterID);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }
            }
    }

    protected void InsertTimeSlot(string masterid)
    {
        foreach (RepeaterItem item in rptTime.Items)
        {
           // TextBox txtFromTime = (TextBox)item.FindControl("txtFromTime");
           // TextBox txtToTime = (TextBox)item.FindControl("txtToTime");


            DropDownList ddlfromhour = (DropDownList)item.FindControl("ddlFromHour");
            DropDownList ddlfromMin = (DropDownList)item.FindControl("ddlFromMin");
            DropDownList ddlfromMeridian = (DropDownList)item.FindControl("ddlFromMeridian");

            DropDownList ddltohour = (DropDownList)item.FindControl("ddlToHour");
            DropDownList ddltoMin = (DropDownList)item.FindControl("ddlToMin");
            DropDownList ddltoMeridian = (DropDownList)item.FindControl("ddlToMeridian");


            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into [MYA_Maleabna_TimeSlot_Det](TimeSlotMasterID,TimeFrom,FromAP,TimeTo,ToAp,TimeSlot) values (@TimeSlotMasterID,@TimeFrom,@FromAP,@TimeTo,@ToAp,@TimeSlot)";


            sqlCommand.Parameters.AddWithValue("@TimeSlotMasterID", masterid);

         

            sqlCommand.Parameters.AddWithValue("@TimeFrom", ddlfromhour.SelectedItem.Text + ":" + ddlfromMin.SelectedItem.Text);

            sqlCommand.Parameters.AddWithValue("@FromAP", ddlfromMeridian.SelectedItem.Text);

            sqlCommand.Parameters.AddWithValue("@TimeTo", ddltohour.SelectedItem.Text + ":" + ddltoMin.SelectedItem.Text);

            sqlCommand.Parameters.AddWithValue("@ToAp", ddltoMeridian.SelectedItem.Text);

            sqlCommand.Parameters.AddWithValue("@TimeSlot", ddlfromhour.SelectedItem.Text + ":" + ddlfromMin.SelectedItem.Text + "" + ddlfromMeridian.SelectedItem.Text + " - " + ddltohour.SelectedItem.Text + ":" + ddltoMin.SelectedItem.Text + "" + ddltoMeridian.SelectedItem.Text);

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

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Time Period Added Successfully!', 'success');", true);


        DDLsite.SelectedValue = "0";
        divtime.Visible = false;
        divCustom.Visible = false;
        rptTime.DataSource = "";
        rptTime.DataBind();
        PopulatetimeTable();
    }

    protected string timesplit(string FromTime, string ToTime)
    {
        string result = string.Empty;
        string[] ftime = FromTime.Split(':');
        string[] tTime = ToTime.Split(':');

        int hour = int.Parse(ftime[0]);
        string meridian = string.Empty;
        if (hour > 12)
        {
            hour = hour - 12;
            ftime[0] = hour.ToString();
            meridian = "PM";
        }
        else
            meridian = "AM";

        result = result + "," + hour + ":" + ftime[1] + "," + meridian;

        hour = int.Parse(tTime[0]);       
        if (hour > 12)
        {
            hour = hour - 12;
            tTime[0] = hour.ToString();
            meridian = "PM";
        }
        else
            meridian = "AM";

        result = result + "," + hour + ":" + tTime[1] + "," + meridian;

        result = result.Trim(new char[] { ',' });


        return result;

    }
}