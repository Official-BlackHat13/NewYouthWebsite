using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit_BlockStadiumDetails : System.Web.UI.Page
{
    string FromDate;
    string ToDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();
           // Session["MaleabnaCMSUserID"] = "109";

            fillGovernorate();           
            fillBlockStadium();
        }
    }


    private void fillBlockStadium()
    {
        string cmd;
        DataTable dt;
        cmd = "select [TimeSlotBlockId], format(DateFrm,'MM/dd/yyyy') as DateFrm,format(DateTo,'MM/dd/yyyy') as DateTo,[GovernorateID],[AreaID],[SchoolID],[StadiumID],[StadiumCourtId],[TimeSlotDetID],[BlockBy],CreatedBy,DisplayMsg,Reason,TimeSlotType from [MYA_Maleabna_TimeSlot_Block] where TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"];
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            //TxtFromDate.Text = dt.Rows[0]["DateFrm"].ToString();
            // TxtToDate.Text = dt.Rows[0]["DateTo"].ToString();
            
            FromDate = dt.Rows[0]["DateFrm"].ToString();  //MM/dd/yyyy         
            ToDate = dt.Rows[0]["DateTo"].ToString(); //MM/dd/yyyy

            string[] fromdate = FromDate.ToString().Split('/'); 
            string month = fromdate[0].ToString();
            int mon = int.Parse(month);
            mon = mon - 1;
            hiddendatefrom.Value = mon + "/" + fromdate[1].ToString() + "/" + fromdate[2].ToString();


            string[] todate = ToDate.ToString().Split('/'); 
            month = todate[0].ToString();
            mon = int.Parse(month);
            mon = mon - 1;
            hiddendateto.Value = mon + "/" + todate[1].ToString() + "/" + todate[2].ToString();
            
            /***** assigning hidden field value to the jquery datepicker as the mindate, while assigning date to the jquery datepicker method 'Option("setDate")', 
             * in a place of month, jQuery method is assigning to the next month Because in jQuery method month index starts from '0', so month is deducting by "1" 
             * Other wise if we set textbox value directly to the datepicker, then while submitting it is consider as a string, but not as a date*****/
          
                    
            
            
            DDLBlockType.ClearSelection();
            string b = dt.Rows[0]["BlockBy"].ToString();
            DDLBlockType.Items.FindByText(dt.Rows[0]["BlockBy"].ToString().Trim()).Selected = true;
            DDLBlockType_SelectedIndexChanged(null, null);


            DDLGovernorate.ClearSelection();
            string g = dt.Rows[0]["GovernorateID"].ToString().Trim();
            DDLGovernorate.Items.FindByValue(g).Selected = true;
          // DDLGovernorate_SelectedIndexChanged(null, null);
            fillArea();

           

            DDLArea.ClearSelection();
            string a = dt.Rows[0]["AreaID"].ToString().Trim();
            DDLArea.Items.FindByValue(dt.Rows[0]["AreaID"].ToString().Trim()).Selected = true;
           // DDLArea_SelectedIndexChanged(null, null);
            fillSchool();

            DDLSchool.ClearSelection();
            DDLSchool.Items.FindByValue(dt.Rows[0]["SchoolID"].ToString().Trim()).Selected = true;
            //DDLSchool_SelectedIndexChanged(null, null); 
            fillStadium();

            DDLStadium.ClearSelection();
            string t = dt.Rows[0]["StadiumID"].ToString().Trim();
            for (int i = 0; i < DDLStadium.Items.Count; i++)
            {
                string o = DDLStadium.Items[i].Value.ToString();
            }
            DDLStadium.Items.FindByValue(dt.Rows[0]["StadiumID"].ToString().Trim()).Selected = true;
            //DDLStadium_SelectedIndexChanged(null, null); 
            fillStadiumCourt();

            DDLStadiumCourt.ClearSelection();
            DDLStadiumCourt.Items.FindByValue(dt.Rows[0]["StadiumCourtId"].ToString().Trim()).Selected = true;

            txtMessage.Text = dt.Rows[0]["DisplayMsg"].ToString().Trim();
            txtReason.Text = dt.Rows[0]["Reason"].ToString().Trim();

            ddlTimeSlotType.ClearSelection();
            if (!String.IsNullOrEmpty(dt.Rows[0]["TimeSlotType"].ToString().Trim()))
            {
                ddlTimeSlotType.Items.FindByText(dt.Rows[0]["TimeSlotType"].ToString().Trim()).Selected = true;
            }

            if (dt.Rows[0]["TimeSlotType"].ToString().Trim() == "All")
            {
                divSlot.Visible = false;
            }
            else if (dt.Rows[0]["TimeSlotType"].ToString().Trim() == "Specific")
            {
              
                fillSlot();

                string time = dt.Rows[0]["TimeSlotDetID"].ToString().Trim();
                string[] timearray = time.Split(',');

                for (int i = 0; i < timearray.Length; i++)
                {
                    string p = timearray[i].ToString().Trim();
                    for (int j = 0; j < ChkTimeSlot.Items.Count; j++)
                    {
                        string r = ChkTimeSlot.Items[j].Value.ToString();
                        if (timearray[i].ToString() == ChkTimeSlot.Items[j].Value)
                            ChkTimeSlot.Items[j].Selected = true;
                    }
                }
            }
           
            
        }
    }


    private void fillSlot()
    {
        string cmd;
        DataTable dt;

        // cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where (('" + FromDate + "'between DateFrm and DateTo) and('" + ToDate + "' between DateFrm and DateTo)) and Type in ('Custom','Special')) group by timeslot";

        cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where ((('" + FromDate + "'between DateFrm and DateTo) and ('" + ToDate + "' between DateFrm and DateTo)) or (DateFrm ='1900-01-01' and DateTo = '1900-01-01')) and Type in ('Custom','Special','Default')) group by timeslot";


        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            ChkTimeSlot.DataSource = dt;
            ChkTimeSlot.DataTextField = "TimeSlot";
            ChkTimeSlot.DataValueField = "TimeSlotDetID";
            ChkTimeSlot.DataBind();


            divSlot.Visible = true;

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
           
            lblerror.Text = "This Governorate is booked from " + from + "to" + to;
        }

        DDLSchool.SelectedValue = "0";
        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue="0";
        
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
      
        int i = DDLArea.Items.Count;
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

            DDLSchool.ClearSelection();
            DDLStadium.ClearSelection();
            DDLStadiumCourt.ClearSelection();
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
        i = DDLArea.Items.Count;
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
            
            lblerror.Text = "This Area is booked from " + from + "to" + to;
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
        DDLSchool.Items.Clear();
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
           
            //DDLStadium.ClearSelection();
          //  DDLStadiumCourt.ClearSelection();

            
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
        lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
         if (i == "0")
         {
            
                 fillStadium();
                 fillTimeSlot();
             
         }
         else
         {
             DDLStadiumCourt.Items.Clear();

             string[] Arrdate = i.Split(',');
             string from = Arrdate[0];
             string to = Arrdate[1];
            
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
        DDLStadium.Items.Clear();
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

            
            DDLStadiumCourt.ClearSelection();
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
          lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
        if (i == "0")
        {
           
               fillStadiumCourt();
               fillTimeSlot();
           
        }
        else
        {
            DDLStadiumCourt.Items.Clear();

            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];
          
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
        DDLStadiumCourt.Items.Clear();
        string cmd;
        DataTable dt;

        if (DDLStadium.SelectedValue != "0" || DDLStadium.SelectedValue != "")
            cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' and StadiumID=" + DDLStadium.SelectedValue + "  order by StadiumType asc";
        else
            cmd = "select max(StadiumDetId) as StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' group by StadiumType ";

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

        string i = CheckStadiumCourt(DDLStadiumCourt.SelectedValue);
        if (i == "0")
        {
           
                lblerror.Text = "";
            
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
       if (ViewState["timeslot"].ToString() == "No")
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

                sqlCommand.CommandText = " update MYA_Maleabna_TimeSlot_Block set DateFrm=@DateFrm,DateTo =@DateTo,GovernorateID =@GovernorateID,AreaID=@AreaID,SchoolID = @SchoolID,StadiumID=@StadiumID," +
                                         "StadiumCourtId=@StadiumCourtId,TimeSlotDetID=@TimeSlotDetID,BlockBy = @BlockBy,Reason=@Reason,DisplayMsg = @DisplayMsg,TimeSlotType=@TimeSlotType where TimeSlotBlockId =@TimeSlotBlockId";

                sqlCommand.Parameters.AddWithValue("@DateFrm", TxtFromDate.Text);

                sqlCommand.Parameters.AddWithValue("@DateTo", TxtToDate.Text);

                sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumID", DDLStadium.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumCourtId", DDLStadiumCourt.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@TimeSlotDetID", timeslot.TrimEnd(new Char[] { ',' }));

                sqlCommand.Parameters.AddWithValue("@CreatedBy", Session["MaleabnaCMSUserID"].ToString());

                sqlCommand.Parameters.AddWithValue("@BlockBy", DDLBlockType.SelectedItem.Text);

                sqlCommand.Parameters.AddWithValue("@TimeSlotBlockId", Request.QueryString["TimeSlotBlockId"].ToString());

                sqlCommand.Parameters.AddWithValue("@Reason", txtReason.Text);

                sqlCommand.Parameters.AddWithValue("@DisplayMsg", txtMessage.Text);

                sqlCommand.Parameters.AddWithValue("@TimeSlotType", ddlTimeSlotType.SelectedItem.Text.ToString());

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
                }



                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium Details Has Been Updated Successfully', 'success');", true);


                if (DDLBlockType.SelectedItem.Text.Trim() == "WholeSite")
                {
                    //code to send email, the reason of blocking complete site
                }

                DDLGovernorate.SelectedValue = "0";
               
                DivArea.Visible = false;
                DivSchool.Visible = false;
                DivStadium.Visible = false;
                DivCourt.Visible = false;

                TxtFromDate.Text = "";
                TxtToDate.Text = "";
                ChkTimeSlot.ClearSelection();

            }
        }
       else if (ViewState["timeslot"].ToString() == "Booked")
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

            if (DDLGovernorate.SelectedValue != "0")
                str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

            if (DDLArea.SelectedValue != "0")
                str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


            if (DDLSchool.SelectedValue != "0")
                str = str + ",SchoolID=" + DDLSchool.SelectedValue + " ";


            if (DDLStadium.SelectedValue != "0")
                str = str + ",StadiumID=" + DDLStadium.SelectedValue + " ";


            if (DDLStadiumCourt.SelectedValue != "0")
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


            
            cmd = "select  TimeSlotBlockId,TimeSlotDetID from [MYA_Maleabna_TimeSlot_Block] " + str + "and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto)) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) )";
            
            dt = dbFunctions.GetData(cmd);
            if (dt.Rows.Count != 0)
            {
                for (int t = 0; t < dt.Rows.Count; t++)
                {
                    string timeslot = dt.Rows[t]["TimeSlotDetID"].ToString();

                    if (dt.Rows[t]["TimeSlotBlockId"].ToString() != Request.QueryString["TimeSlotBlockId"].ToString())
                    {
                        result = result + timeslot + ",";
                    }


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


    protected void ddlTimeSlotType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        divSlot.Visible = false;
        lbltime.Text = "";
        ChkTimeSlot.Items.Clear();

        if (ddlTimeSlotType.SelectedValue == "2")
        {
            fillTimeSlot();

        }   
    }

    private void fillTimeSlot()
    {
        //string cmd;
        //DataTable dt;

        // cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where ((('" + TxtFromDate.Text + "'between DateFrm and DateTo) and ('" + TxtToDate.Text + "' between DateFrm and DateTo)) or (DateFrm ='1900-01-01' and DateTo = '1900-01-01')) and Type in ('Custom','Special','Default')) group by timeslot";
        //dt = dbFunctions.GetData(cmd);

        //if (dt.Rows.Count != 0)
        //{
        //    ChkTimeSlot.DataSource = dt;
        //    ChkTimeSlot.DataTextField = "TimeSlot";
        //    ChkTimeSlot.DataValueField = "TimeSlotDetID";
        //    ChkTimeSlot.DataBind();

        //    divSlot.Visible = true;
        //}
        //else
        //{
        //    lbltime.Text = "No Time Slots are available";
        //}

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
}