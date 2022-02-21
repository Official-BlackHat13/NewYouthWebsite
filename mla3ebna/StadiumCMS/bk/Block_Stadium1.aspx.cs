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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();

            fillGovernorate();
            fillTimeSlot();
        }
    }
    private void fillTimeSlot()
    {
        string cmd;
        DataTable dt;
        cmd = "select TimeSlotDetID,TimeSlot  from [MYA_Maleabna_TimeSlot_Det] ";
        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            ChkTimeSlot.DataSource = dt;
            ChkTimeSlot.DataTextField = "TimeSlot";
            ChkTimeSlot.DataValueField = "TimeSlotDetID";
            ChkTimeSlot.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "all";
            it_bo.Value = "*";          
            ChkTimeSlot.Items.Add(it_bo);
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
        lblerror.Text = "";

        string i = CheckGovernorate(DDLGovernorate.SelectedValue);
         if (i == "0")
         {
             fillArea(DDLGovernorate.SelectedValue);            
         }
         else
         {
             string[] Arrdate = i.Split(',');
             string from = Arrdate[0];
             string to = Arrdate[1];
             DivArea.Visible = false;
             lblerror.Text = "This Governorate is booked from " + from + "to" + to;
         }

         DivStadium.Visible = false;
         DivSchool.Visible = false;
         DivCourt.Visible = false;
    }
    private string CheckGovernorate(string strGovID)
    {
        string cmd;
        DataTable dt;

        cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where AreaID = 0 and GovernorateID= '" + strGovID + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
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



    private void fillArea(string StrGovernorateID)
    {
        string cmd;
        DataTable dt;
      //  cmd = "select a.AreaID,a.AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] a  where a.Status='" + true + "'and a.GovernorateID=" + StrGovernorateID + " and a.AreaID !=(ISNULL(( select  b.AreaID from [MYA_Maleabna].[dbo].[MYA_Maleabna_TimeSlot_Block] b where   SchoolID = 0 and GovernorateID= a.GovernorateID),0)) order by a.AreaName asc ";
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
            DivArea.Visible = true;
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
            DivArea.Visible = false;
           
        }
        
    }
    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        string i = CheckArea(DDLArea.SelectedValue);
        if (i == "0")
        {
            fillSchool(DDLArea.SelectedValue);
           
        }
        else
        {
            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];
            DivSchool.Visible = false;
            lblerror.Text = "This Area is booked from "+ from +"to"+to ;
        }
        DivStadium.Visible = false;
        DivCourt.Visible = false;

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



    private void fillSchool(string StrAreaID)
    {
        string cmd;
        DataTable dt;

       // cmd = "select a.SchoolID,a.SchoolName + ' - ' + a.SchoolNameEn AS SchoolName from [MYA_Maleabna_School] a where a.Status='" + true + "' and a.AreaID=" + StrAreaID + "and a.SchoolID != (ISNULL(( select  SchoolID  from [MYA_Maleabna].[dbo].[MYA_Maleabna_TimeSlot_Block]  where StadiumID=0 and SchoolID != '0' and AreaID=a.AreaID ),0))  order by a.SchoolName asc ";
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
            DivSchool.Visible = true;  
            
        }
        else
        {
            DDLSchool.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
            DivSchool.Visible = false;
           
        }
    }
    protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
         if (i == "0")
         {
             fillStadium(DDLSchool.SelectedValue);
         }
         else
         {
             string[] Arrdate = i.Split(',');
             string from = Arrdate[0];
             string to = Arrdate[1];
             DivStadium.Visible = false;
             lblerror.Text = "This School is booked from " + from + "to" + to;
         }
        DivCourt.Visible = false;       
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



    private void fillStadium(string StrSchoolID)
    {
        string cmd;
        DataTable dt;

        //cmd = "select a.StadiumID,a.StadiumName + ' - ' + a.StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium] a where a.Status='" + true + "' and a.SchoolID=" + StrSchoolID + "and a.StadiumID !=(ISNULL(( select  StadiumID  from [MYA_Maleabna].[dbo].[MYA_Maleabna_TimeSlot_Block]  where StadiumCourtId=0 and StadiumID != '0' and SchoolID=a.SchoolID),0)) order by StadiumName asc ";
        cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' and SchoolID=" + StrSchoolID +" order by StadiumName asc ";

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";
           
            DDLStadium.DataBind();

            ListItem it_bo = new ListItem();
           
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;

           
            DDLStadium.Items.Add(it_bo);
            DivStadium.Visible = true;
        }
        else
        {
            DDLStadium.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);

            DivStadium.Visible = false;
           
        }
    }
    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
          lblerror.Text = "";
        string i = CheckSchool(DDLSchool.SelectedValue);
        if (i == "0")
        {
            DivCourt.Visible = true;
            fillStadiumCourt(DDLStadium.SelectedValue);
        }
        else
        {
            string[] Arrdate = i.Split(',');
            string from = Arrdate[0];
            string to = Arrdate[1];
            DivCourt.Visible = false;

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
    




   

    
    private void fillStadiumCourt(string StrStadiumID)
    {
        string cmd;
        DataTable dt;

        cmd = "select StadiumDetId, StadiumType from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' and StadiumID=" + StrStadiumID + "  order by StadiumType asc ";

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStadiumCourt.DataSource = dt;
            DDLStadiumCourt.DataTextField = "StadiumType";
            DDLStadiumCourt.DataValueField = "StadiumDetId";
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
       
        //string i = CheckStadiumCourt(DDLStadiumCourt.SelectedValue);
        //if (i == "0")
        //{
        //    lblerror.Text = "";
        //}
        //else
        //{
        //    string[] Arrdate = i.Split(',');
        //    string from = Arrdate[0];
        //    string to = Arrdate[1];
            
        //    lblerror.Text = "This Court is booked from " + from + "to" + to;
        //}
       
    }
    private string CheckStadiumCourt(string strStadiumCourtId)
    {
        //string cmd;
        //DataTable dt;

        //cmd = "select  TimeSlotBlockId,DateFrm,dateto from [MYA_Maleabna_TimeSlot_Block] where  StadiumCourtId = '" + strStadiumCourtId + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        //dt = dbFunctions.GetData(cmd);
        //if (dt.Rows.Count != 0)
        //{
        //    string from = dt.Rows[0]["DateFrm"].ToString();
        //    string to = dt.Rows[0]["dateto"].ToString();
        //    return (from + "," + to);
        //}
        //else
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


                for (int i = 0; i < ChkTimeSlot.Items.Count; i++)
                {
                    if (ChkTimeSlot.Items[i].Selected)
                    {
                        if (ChkTimeSlot.Items[i].Value != "*")
                            timeslot = timeslot + ChkTimeSlot.Items[i].Value + ",";
                    }
                }



                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "insert into MYA_Maleabna_TimeSlot_Block(DateFrm,DateTo,GovernorateID,AreaID,SchoolID,StadiumID,StadiumCourtId,TimeSlotDetID,CreatedBy,status) values(@DateFrm,@DateTo,@GovernorateID,@AreaID,@SchoolID,@StadiumID,@StadiumCourtId,@TimeSlotDetID,@CreatedBy,'1')";

                sqlCommand.Parameters.AddWithValue("@DateFrm", TxtFromDate.Text);

                sqlCommand.Parameters.AddWithValue("@DateTo", TxtToDate.Text);

                sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@SchoolID", DDLSchool.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumID", DDLStadium.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@StadiumCourtId", DDLStadiumCourt.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@TimeSlotDetID", timeslot.TrimEnd(new Char[] { ',' }));

                sqlCommand.Parameters.AddWithValue("@CreatedBy", Session["MaleabnaCMSUserID"].ToString());

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
                }



                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stadium Has Been Blocked Successfully', 'success');", true);

                DDLGovernorate.SelectedValue = "0";
                DDLGovernorate_SelectedIndexChanged(null, null);
                DivArea.Visible = false;
                DivSchool.Visible = false;
                DivStadium.Visible = false;
                DivCourt.Visible = false;

                TxtFromDate.Text = "";
                TxtToDate.Text = "";
                ChkTimeSlot.ClearSelection();

            }
        }
        else
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
        if (DDLGovernorate.SelectedValue != "0")
            cmd = "select  TimeSlotBlockId,TimeSlotDetID from [MYA_Maleabna_TimeSlot_Block] where  StadiumCourtId = '" + strStadiumCourtId + "' and (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        else
            cmd = "select  TimeSlotBlockId,TimeSlotDetID,TimeSlotDetID from [MYA_Maleabna_TimeSlot_Block] where (( ('" + TxtFromDate.Text + "' between DateFrm and dateto )or ('" + TxtToDate.Text + "' between  DateFrm and dateto) or (( DateFrm between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "') or (dateto between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')) ))";
        
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
       

      hdtimeslot.Value = hdtimeslot.Value.TrimEnd(new char[] {','});
    }


    protected void DDLBlockType_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}