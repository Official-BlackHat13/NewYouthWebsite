using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_BlockStadiumDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
            fillTimeSlot();
            fillData();
           
            StrPrintbtn = " <a class='' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["TimeSlotBlockId"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";
        }
    }
    private void fillTimeSlot()
    {
        string cmd;
        DataTable dt;
      //  cmd = "select TimeSlotDetID,TimeSlot  from [MYA_Maleabna_TimeSlot_Det] ";
        cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot  from [MYA_Maleabna_TimeSlot_Det] group by timeslot";
        dt = dbFunctions.GetData(cmd);
      //  ViewState["TimeSlotCount"] = dt.Rows.Count.ToString();

        if (dt.Rows.Count != 0)
        {
            ChkTimeSlot.DataSource = dt;
            ChkTimeSlot.DataTextField = "TimeSlot";
            ChkTimeSlot.DataValueField = "TimeSlotDetID";

            //ChkTimeSlot.SelectedValue = null;
            ChkTimeSlot.DataBind();

        }
    }
    private void fillData()
    {
        string cmd;

        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        cmd = "select b.TimeSlotBlockId, format(b.DateFrm,'dd/MM/yyyy') as DateFrm , format(b.DateTo,'dd/MM/yyyy') as DateTo,b.TimeSlotDetID,b.CreatedBy,b.BlockBy,b.Status,b.Reason,b.DisplayMsg," +
           "CASE when b.GovernorateID = 0 then '-' when b.GovernorateID != 0 then (select g.GovernorateName from  MYA_Maleabna_Governorate g where b.GovernorateID = g.GovernorateID ) End as GovernorateName,"+
            "CASE when b.AreaID = 0 then '-' when b.AreaID != 0 then (select a.AreaName from  MYA_Maleabna_Area a where b.AreaID = a.AreaID ) End as AreaName," +
           "CASE when b.SchoolID = 0 then '-' when b.schoolID != 0 then (select s.SchoolName from MYA_Maleabna_School s where b.SchoolID = s.SchoolID) End as SchoolName," +
           "CASE when b.StadiumID = 0 then '-' when b.StadiumID != 0 then (select st.StadiumName from MYA_Maleabna_Stadium st where b.StadiumID = st.StadiumID) End as StadiumName," +
           "CASE when b.StadiumCourtId = 0 then '-' when b.StadiumCourtId != 0 then (select sd.StadiumType from MYA_Maleabna_Stadium_Detail sd where b.StadiumCourtId = sd.StadiumDetId) End as StadiumType " +
           //str +
           "From MYA_Maleabna_TimeSlot_Block b where b.TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"];


        //dt = dbFunctions.GetData("select [TimeSlotBlockId],format([DateFrm],'dd/MM/yyyy') as DateFrm,format([DateTo],'dd/MM/yyyy') as DateTo,[GovernorateID],[AreaID],[SchoolID],[StadiumID],[StadiumCourtId],[TimeSlotDetID],[BlockBy],CreatedBy from [MYA_Maleabna_TimeSlot_Block] where TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"]);
        dt = dbFunctions.GetData(cmd);


        if (dt.Rows.Count != 0)
        {
            //LabUserID.Text = dt.Rows[0]["CreatedBy"].ToString();
            lbldetefrom.Text = dt.Rows[0]["DateFrm"].ToString();

            lbldateto.Text = dt.Rows[0]["DateTo"].ToString();

            Labblockby.Text = dt.Rows[0]["BlockBy"].ToString();

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

            if (Labblockby.Text.Trim() == "WholeSite")
            {
                divdetails.Visible = false;
                divtimeslot.Visible = false;
                divmessage.Visible = true;
            }
            else
            {
                divdetails.Visible = true;
                divtimeslot.Visible = true;
                divmessage.Visible = false;
            }

            LabArea.Text = dt.Rows[0]["AreaName"].ToString();

            LabSchool.Text = dt.Rows[0]["SchoolName"].ToString();

            LabStadium.Text = dt.Rows[0]["StadiumName"].ToString();

            LabCourt.Text = dt.Rows[0]["StadiumType"].ToString();

            lblmsg.Text = dt.Rows[0]["DisplayMsg"].ToString();

            lblcomment.Text = dt.Rows[0]["Reason"].ToString();

            string time = dt.Rows[0]["TimeSlotDetID"].ToString();
            string[] timearray = time.Split(',');

            for (int i = 0; i < timearray.Length; i++)
            {
                for (int k = 0; k < ChkTimeSlot.Items.Count; k++)
                {
                    if (timearray[i] == ChkTimeSlot.Items[k].Value)
                        ChkTimeSlot.Items[k].Selected = true;

                }

            }

            //if (ViewState["TimeSlotCount"].ToString() == timearray.Length.ToString())
            //{
            //    for (int j = 0; j < ChkTimeSlot.Items.Count; j++)
            //    {
            //        ChkTimeSlot.Items[j].Selected = true;
            //    }
            //}
            //else
            //{

            //    if (dt.Rows.Count > 0)
            //    {
                   
            //    }
            //}
            ChkTimeSlot.Enabled = false;


        }
    }
  
    
    
   

}