using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Block_Stadium : System.Web.UI.Page
{
    string[] arr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          

           CMSCurrentUser.CheckLoggedIn();
          //  Session["MaleabnaCMSUserID"] = "109";
            fillGovernorate();
            fillArea();
            fillSchool();
            fillStadium();
            fillStadiumCourt();

            //fillTimeSlot();
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
        lblerror.Text = "";

        string i = CheckGovernorate(DDLGovernorate.SelectedValue);
         if (i == "0")
         {
             fillArea();
             fillTimeSlot();
         }
         else
         {
             DDLArea.Items.Clear();
             DDLSchool.Items.Clear();
             DDLStadium.Items.Clear();
             DDLStadiumCourt.Items.Clear();

             string[] Arrdate = i.Split(',');
             string from = Arrdate[0];
             string to = Arrdate[1];
            // DivArea.Visible = false;
             lblerror.Text = "This Governorate is booked from " + from + "to" + to;
         }

         DDLSchool.SelectedValue = "0";
         DDLStadium.SelectedValue = "0";
         DDLStadiumCourt.SelectedValue = "0";
    }
    private string CheckGovernorate(string strGovID)
    {
        string cmd;
        DataTable dt;

        cmd = "select TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where AreaID = 0 and GovernorateID= '" + strGovID + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count > 0)
        {
            string from = dt.Rows[0]["DateFrm"].ToString();
            string to = dt.Rows[0]["dateto"].ToString();
            return (from + "," + to);
        }
        else
            return "0";
    }



    private void fillArea()
    {
        DDLArea.Items.Clear();
        string cmd;
        DataTable dt;
        if (DDLGovernorate.SelectedValue != "0" || DDLGovernorate.SelectedValue != "")
            cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
        else
            cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' order by AreaName asc ";
       
        dt = dbFunctions.GetData(cmd);
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
        lblerror.Text = "";
        string i = CheckArea(DDLArea.SelectedValue);
        if (i == "0")
        {
            fillSchool();
            fillTimeSlot();
        }
        else
        {           
            DDLSchool.Items.Clear();
            DDLStadium.Items.Clear();
            DDLStadiumCourt.Items.Clear();

            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];
           // DivSchool.Visible = false;
            lblerror.Text = "This Area is booked from "+ from +"to"+to ;
        }

        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";

    }
    private string CheckArea(string StrAreaID)
    {
          string cmd;
        DataTable dt;

        cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where SchoolID= 0 and AreaID= '" + StrAreaID + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            string from = dt.Rows[0]["DateFrm"].ToString();
            string to = dt.Rows[0]["dateto"].ToString();
            return (from +","+to);
        }
        else
            return "0";
    }



    private void fillSchool()
    {
        string cmd;
        DataTable dt;

        if (DDLArea.SelectedValue != "0" || DDLArea.SelectedValue != "")
            cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' and AreaID=" + DDLArea.SelectedValue + "  order by SchoolName asc ";
        else
            cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' order by SchoolName asc ";
        dt = dbFunctions.GetData(cmd);
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
        lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
         if (i == "0")
         {
             fillStadium();
             fillTimeSlot();
         }
         else
         {
            // DDLSchool.Items.Clear();
             DDLStadium.Items.Clear();
             DDLStadiumCourt.Items.Clear();

             string[] Arrdate = i.Split(',');
             string from = Arrdate[0];
             string to = Arrdate[1];
             //DivStadium.Visible = false;
             lblerror.Text = "This School is booked from " + from + "to" + to;
         }
         DDLStadiumCourt.SelectedValue = "0";      
    }
    private string CheckSchool(string strSchoolId)
    {
        string cmd;
        DataTable dt;

        cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where  StadiumID= 0 and SchoolID= '" + strSchoolId + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            string from = dt.Rows[0]["DateFrm"].ToString();
            string to = dt.Rows[0]["dateto"].ToString();
            return (from + "," + to);
        }
        else
            return "0";
    }



    private void fillStadium()
    {
        string cmd;
        DataTable dt;

        if (DDLSchool.SelectedValue != "0" || DDLSchool.SelectedValue != "")
            cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' and SchoolID=" + DDLSchool.SelectedValue +" order by StadiumName asc ";
        else
            cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' order by StadiumName asc ";

        dt = dbFunctions.GetData(cmd);
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
          lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
        if (i == "0")
        {
           // DivCourt.Visible = true;
            fillStadiumCourt();
            fillTimeSlot();
        }
        else
        {

           // DDLStadium.Items.Clear();
            DDLStadiumCourt.Items.Clear();

            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];
           // DivCourt.Visible = false;

            lblerror.Text = "This Stadium is booked from " + from + "to" + to;
        }
    }
    private string CheckStadium(string strStadiumId)
    {
        string cmd;
        DataTable dt;

        cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where  StadiumCourtId= 0 and StadiumID = '" + strStadiumId + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            string from = dt.Rows[0]["DateFrm"].ToString();
            string to = dt.Rows[0]["dateto"].ToString();
            return (from + "," + to);
        }
        else
            return "0";
    }
    




   

    
    private void fillStadiumCourt()
    {
        string cmd;
        DataTable dt;

        if (DDLStadium.SelectedValue != "0" || DDLStadium.SelectedValue != "")
            cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' and StadiumID=" + DDLStadium.SelectedValue + "  order by StadiumType asc ";
        else
            cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' order by StadiumType asc ";

        dt = dbFunctions.GetData(cmd);
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
           

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadiumCourt.Items.Add(it_bo);

        }
    }
    protected void DDLStadiumCourt_SelectedIndexChanged(object sender, EventArgs e)
    {

        string i = CheckStadiumCourt(DDLStadiumCourt.SelectedValue);
        if (i == "0")
        {
            lblerror.Text = "";
            fillTimeSlot();
        }
        else
        {

            DDLStadiumCourt.Items.Clear();

            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];

            lblerror.Text = "This Court is booked from " + from + "to" + to;
        }
       
    }
    private string CheckStadiumCourt(string strStadiumCourtId)
    {
        string cmd;
        DataTable dt;

        cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where  StadiumCourtId = '" + strStadiumCourtId + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            string from = dt.Rows[0]["DateFrm"].ToString();
            string to = dt.Rows[0]["dateto"].ToString();
            return (from + "," + to);
        }
        else
            return "0";
    }



    protected void lnkCancel_Click(object sender, EventArgs e)
    {

    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
       
       CheckBlockAvailable(DDLStadiumCourt.SelectedValue);            

       if (ViewState["timeslot"].ToString() == "No" && lblerror.Text == "")
        {
            string cmd;
            DataTable dt = new DataTable();

            Validate("MainValidate");
            if (Page.IsValid)
            {
                string timeslot = string.Empty;

                if (ddlTimeSlotType.SelectedValue == "2")
                {
                    for (int i = 0; i < ChkTimeSlot.Items.Count; i++)
                    {
                        if (ChkTimeSlot.Items[i].Selected)
                        {
                            if (ChkTimeSlot.Items[i].Value != "*")
                                timeslot = timeslot + ChkTimeSlot.Items[i].Value + ",";
                        }
                    }
                }
                else if (ddlTimeSlotType.SelectedValue == "1")
                {
                    cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in (select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where Type = 'Default') group by timeslot";
                    dt = dbFunctions.GetData(cmd);

                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            timeslot = timeslot + dr["TimeSlotDetID"].ToString() + ",";
                        }
                    }
                }


                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "insert into MYA_Maleabna_TimeSlot_Block(DateFrm,DateTo,GovernorateID,AreaID,SchoolID,StadiumID,StadiumCourtId,TimeSlotDetID,CreatedBy,status,BlockBy,Reason,DisplayMsg,TimeSlotType)"+
                    "values(@DateFrm,@DateTo,@GovernorateID,@AreaID,@SchoolID,@StadiumID,@StadiumCourtId,@TimeSlotDetID,@CreatedBy,'1',@BlockBy,@Reason,@DisplayMsg,@TimeSlotType)";

                sqlCommand.Parameters.AddWithValue("@DateFrm", TxtFromDate.Text);

                sqlCommand.Parameters.AddWithValue("@DateTo", TxtToDate.Text);

                sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumID", DDLStadium.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumCourtId", DDLStadiumCourt.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@TimeSlotDetID", timeslot.TrimEnd(new Char[] { ',' }));

                sqlCommand.Parameters.AddWithValue("@CreatedBy", Session["MaleabnaCMSUserID"].ToString());

                sqlCommand.Parameters.AddWithValue("@BlockBy", DDLBlockType.SelectedItem.Text.Trim());

                sqlCommand.Parameters.AddWithValue("@Reason", txtReason.Text);

                sqlCommand.Parameters.AddWithValue("@DisplayMsg", txtMessage.Text);

                sqlCommand.Parameters.AddWithValue("@TimeSlotType", (DDLBlockType.SelectedItem.Text.Trim() == "WholeSite" ? "" : ddlTimeSlotType.SelectedItem.Text));

                try
                {
                    sqlConnection.Open();
                   sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
                }

                //code to send email about stadium Blocking information
                EmailSend();

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium Has Been Blocked Successfully', 'success');", true);

                
               

                DDLGovernorate.SelectedValue = "0";
                //DDLGovernorate_SelectedIndexChanged(null, null);
                DivArea.Visible = false;
                DivSchool.Visible = false;
                DivStadium.Visible = false;
                DivCourt.Visible = false;

                TxtFromDate.Text = "";
                TxtToDate.Text = "";
                ChkTimeSlot.ClearSelection();

            }
        }
        else if(ViewState["timeslot"].ToString() == "Booked")
        {            
                string[] Arrtime = hdtimeslot.Value.Split(',');
                hdtimeslot.Value = "";
                foreach (ListItem item in ChkTimeSlot.Items)
                {
                    for (int i = 0; i < Arrtime.Length; i++)
                    {
                        if (item.Value == Arrtime[i])
                            hdtimeslot.Value = hdtimeslot.Value + item.Text + ",";
                    }
                }

                lblerror.Text = "Can not Block."+ hdtimeslot.Value.TrimEnd(new char[] { ',' }) + "This Time Slots are Already Bloked";
            
        }
      
    }

    private void CheckBlockAvailable(string strStadiumCourtId)
    {
        hdtimeslot.Value = "";
        ViewState["timeslot"] = "No";
        string cmd,result=string.Empty;
        DataTable dt;

        string str = "";

        if (DDLBlockType.SelectedItem.Text.Trim() != "WholeSite")
        {

            if (DDLGovernorate.SelectedValue != "0" && DDLGovernorate.SelectedValue != "")
                str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

            if (DDLArea.SelectedValue != "0" && DDLArea.SelectedValue != "")
                str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


            if (DDLSchool.SelectedValue != "0" && DDLSchool.SelectedValue != "")
                str = str + ",SchoolID=" + DDLSchool.SelectedValue + " ";


            if (DDLStadium.SelectedValue != "0" && DDLStadium.SelectedValue != "")
                str = str + ",StadiumID=" + DDLStadium.SelectedValue + " ";


            if (DDLStadiumCourt.SelectedValue != "0" && DDLStadiumCourt.SelectedValue != "")
                str = str + ",StadiumCourtId=" + DDLStadiumCourt.SelectedValue + " ";

            string[] arr = str.Split(',');

            if (str != "")
            {
                str = " where ";
            }
            for (var i = 0; i < arr.Length; i++)
            {
                if (i > 1)
                {
                    str = str + " and ";
                }
                str = str + (arr[i]);

            }


            //if (DDLGovernorate.SelectedValue != "0")
            cmd = "select  TimeSlotBlockId,TimeSlotDetID from [MYA_Maleabna_TimeSlot_Block] " + str + "and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto)) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) )";
            //else
            //    cmd = "select  TimeSlotBlockId,TimeSlotDetID,TimeSlotDetID from [MYA_Maleabna_TimeSlot_Block] where (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";

            dt = dbFunctions.GetData(cmd);
            if (dt.Rows.Count != 0)
            {
                for (int t = 0; t < dt.Rows.Count; t++)
                {
                    string timeslot = dt.Rows[t]["TimeSlotDetID"].ToString();
                    result = result + timeslot + ",";


                }

                string[] data = result.Split(',');
                result = "";
                for (int i = 0; i < data.Length; i++)
                {
                    if (!hdtimeslot.Value.Contains(data[i]))
                    {
                        hdtimeslot.Value = hdtimeslot.Value + data[i] + ",";
                        result = result + data[i] + ",";
                    }

                }

                foreach (ListItem item in ChkTimeSlot.Items)
                {
                    if (item.Selected == true)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i].ToString() == item.Value)
                                ViewState["timeslot"] = "Booked";

                        }
                    }
                }
            }


            hdtimeslot.Value = hdtimeslot.Value.TrimEnd(new char[] { ',' });
        }
       
    }


    protected void DDLBlockType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLGovernorate.SelectedValue = "0";
        DDLArea.SelectedValue = "0";
        DDLSchool.SelectedValue = "0";
        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";
        DivMessage.Visible = false;
        txtMessage.Text = "";
        DivTimeSlot.Visible = true;

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
        else if (DDLBlockType.SelectedValue == "6")
        {
            DivGovernorate.Visible = true; 
            DivArea.Visible = true;
            DivSchool.Visible = true;
            DivStadium.Visible = true;
            DivCourt.Visible = true;
        }
        else if (DDLBlockType.SelectedValue == "7")
        {
            DivGovernorate.Visible = false;
            DivArea.Visible = false;
            DivSchool.Visible = false;
            DivStadium.Visible = false;
            DivCourt.Visible = false;
            DivTimeSlot.Visible = false;

            DivMessage.Visible = true;
        }
       // fillvalues();
    }

    //protected void fillvalues()
    //{
    //    if (DivGovernorate.Visible == true)
    //        fillGovernorate();
    //    if (DivArea.Visible == true)
    //        fillArea();
    //    if (DivSchool.Visible == true)
    //        fillSchool();
    //    if (DivStadium.Visible == true)
    //        fillStadium();
    //    if (DivStadium.Visible == true)
    //        fillStadiumCourt();
    //}
    protected void ddlTimeSlotType_SelectedIndexChanged(object sender, EventArgs e)
    {
        divSlot.Visible = false;
        lbltime.Text = "";
        ChkTimeSlot.Items.Clear();
        
        if (ddlTimeSlotType.SelectedValue == "2")
        {
            fillTimeSlot();
            
        }       

        
    }
    protected void fillTimeSlot()
    {
        ChkTimeSlot.Items.Clear();
        string cmd;
        DataTable dt;        

        cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where ((('" + TxtFromDate.Text + "'between DateFrm and DateTo) and ('" + TxtToDate.Text + "' between DateFrm and DateTo)) or (DateFrm ='1900-01-01' and DateTo = '1900-01-01')) and Type in ('Custom','Special','Default')) group by timeslot";

        
      
        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            ChkTimeSlot.DataSource = dt;
            ChkTimeSlot.DataTextField = "TimeSlot";
            ChkTimeSlot.DataValueField = "TimeSlotDetID";
            ChkTimeSlot.DataBind();

            if (ddlTimeSlotType.SelectedValue != "0" && ddlTimeSlotType.SelectedValue != "")
            {
                divSlot.Visible = true;
            }
        }

    }


    protected List<object> EmailList()   //string email, string[] list, string Text
    {
        string cmd;
        string str="";
        DataTable dt;
        string sid = "";

        List<object> EmailList = new List<object>();
       

        #region Getting Id's based on BlockBy

        if (DDLBlockType.SelectedValue != "7")
        {

            if (DDLBlockType.SelectedValue != "4" && DDLBlockType.SelectedValue != "5" && DDLBlockType.SelectedValue != "6")
            {
                #region GetStadiumIDBAsedOn(Governorate/Area/School)

                if (DDLBlockType.SelectedValue == "1")
                    str = "GovernorateID = " + DDLGovernorate.SelectedValue;
                else if (DDLBlockType.SelectedValue == "2")
                    str = " AreaID = " + DDLArea.SelectedValue;
                else if (DDLBlockType.SelectedValue == "3")
                    str = " SchoolID = " + DDLSchool.SelectedValue;


                arr = str.Split(',');

                if (str != "")
                {
                    str = " where ";
                }
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i > 1)
                    {
                        str = str + " and ";
                    }
                    str = str + (arr[i]);

                }

                cmd = "select StadiumID from [MYA_Maleabna_Stadium] " + str;

                dt = dbFunctions.GetData(cmd);  //get stadium ids
                str = "";

                foreach (DataRow dr in dt.Rows)
                {
                    sid = sid + dr["StadiumID"].ToString() + ",";
                }
                sid = sid.Trim(new char[] {','});
                #endregion
                

                str = "b.StadiumID in (" + sid +")";
            }
            else if (DDLBlockType.SelectedValue == "4")
                str = "b.StadiumID = " + DDLStadium.SelectedValue;
            else if (DDLBlockType.SelectedValue == "5")
                str = "b.StadiumDetId= " + DDLStadiumCourt.SelectedValue;

           
                #region TimeSlotWise
                string timeslot = string.Empty;

                if (ddlTimeSlotType.SelectedValue == "2")
                {
                    for (int i = 0; i < ChkTimeSlot.Items.Count; i++)
                    {
                        if (ChkTimeSlot.Items[i].Selected)
                        {
                            if (ChkTimeSlot.Items[i].Value != "*")
                                timeslot = timeslot + "'" + ChkTimeSlot.Items[i].Text + "' ,";
                        }
                    }
                }
                else if (ddlTimeSlotType.SelectedValue == "1")
                {
                    cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in (select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where Type = 'Default') group by timeslot";
                    dt = dbFunctions.GetData(cmd);

                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            timeslot = timeslot + "'"+dr["TimeSlot"].ToString() + "',";
                        }
                    }
                }

                timeslot = timeslot.Trim(new char[] { ',' });

                str = str + "?b.BookingTime in ("+ timeslot+")";
                #endregion
           


                arr = str.Split('?');

                str = "";
                for (var i = 0; i < arr.Length; i++)
                {          

                    str = str + " and " + (arr[i]);

                }

        }
#endregion

       
         
        

        cmd = "select distinct m.Email from MYA_Maleabna_Members m join MYA_Maleabna_Booking b on b.UserID = m.UserID " +
              " where b.BookingDate between  '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "'" + str ;

        /*date from and date to are must and should, so even they block by whole site also it will take all the stadium ids*/

        dt = dbFunctions.GetData(cmd);

        foreach (DataRow dr in dt.Rows)
        {
            EmailList.Add(dr["Email"]);
        }


        return EmailList;
    }


    protected void EmailSend()
    {
        List<object>  list = EmailList();
        string email;

        for (int i = 0; i < list.Count; i++)
        {
          
                email = list[i].ToString();

                int res = SendEmail.GeneralEmail(email, txtReason.Text);

           

        }
    }


    //protected string[] SEmail()
    //{
    //    string[] sid= new string[]{};
    //    string cmd;
    //    string str = "";
    //    if (DDLBlockType.SelectedValue == "1")
    //        str = "GovernorateID = " + DDLGovernorate.SelectedValue;
    //    else if (DDLBlockType.SelectedValue == "2")
    //        str = " AreaID = " + DDLArea.SelectedValue;
    //    else if (DDLBlockType.SelectedValue == "3")
    //        str = " SchoolID = " + DDLSchool.SelectedValue;
    //    else if (DDLBlockType.SelectedValue == "4")
    //        str = " StadiumID = " + DDLStadium.SelectedValue;


    //    arr = str.Split(',');

    //    if (str != "")
    //    {
    //        str = " where ";
    //    }
    //    for (var i = 0; i < arr.Length; i++)
    //    {
    //        if (i > 1)
    //        {
    //            str = str + " and ";
    //        }
    //        str = str + (arr[i]);

    //    }

    //    cmd = "select StadiumID from [MYA_Maleabna_Stadium] " + str ;

    //    DataTable dt = dbFunctions.GetData(cmd);

      
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        sid = dr.ItemArray.Cast<string>().ToArray();
    //    }

    //    return sid;
    //}

}