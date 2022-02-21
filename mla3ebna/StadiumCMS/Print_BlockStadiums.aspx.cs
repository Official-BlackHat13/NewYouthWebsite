using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_BlockStadiums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillData();
        }
    }
    private void fillData()
    {

        string cmd = "";
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();


        cmd = "select b.TimeSlotBlockId,format(b.DateFrm,'dd/MM/yyyy') as DateFrm, format(b.DateTo,'dd/MM/yyyy') as DateTo,b.TimeSlotDetID,b.CreatedBy,b.BlockBy,b.Status,b.Reason,b.DisplayMsg," +
           "CASE when b.GovernorateID = 0 then '-' when b.GovernorateID != 0 then (select g.GovernorateName from  MYA_Maleabna_Governorate g where b.GovernorateID = g.GovernorateID ) End as GovernorateName,"+
            "CASE when b.AreaID = 0 then '-' when b.AreaID != 0 then (select a.AreaName from  MYA_Maleabna_Area a where b.AreaID = a.AreaID ) End as AreaName," +
           "CASE when b.SchoolID = 0 then '-' when b.schoolID != 0 then (select s.SchoolName from MYA_Maleabna_School s where b.SchoolID = s.SchoolID) End as SchoolName," +
           "CASE when b.StadiumID = 0 then '-' when b.StadiumID != 0 then (select st.StadiumName from MYA_Maleabna_Stadium st where b.StadiumID = st.StadiumID) End as StadiumName," +
           "CASE when b.StadiumCourtId = 0 then '-' when b.StadiumCourtId != 0 then (select sd.StadiumType from MYA_Maleabna_Stadium_Detail sd where b.StadiumCourtId = sd.StadiumDetId) End as StadiumType " +          
           "From MYA_Maleabna_TimeSlot_Block b where b.TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"];


        dt = dbFunctions.GetData(cmd);


       // dt = dbFunctions.GetData("select [TimeSlotBlockId],format([DateFrm],'dd/MM/yyyy') as DateFrm,format([DateTo],'dd/MM/yyyy') as DateTo,[GovernorateID],[AreaID],[SchoolID],[StadiumID],[StadiumCourtId],[TimeSlotDetID],[BlockBy],CreatedBy from [MYA_Maleabna_TimeSlot_Block] where TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"]);
        //Try


        if (dt.Rows.Count != 0)
        {
           
            lblstadiumblockby.Text = dt.Rows[0]["CreatedBy"].ToString();

            lbldetefrom.Text = dt.Rows[0]["DateFrm"].ToString();

            lbldateto.Text = dt.Rows[0]["DateTo"].ToString();

            Labblockby.Text = dt.Rows[0]["BlockBy"].ToString();

            lblcomment.Text = dt.Rows[0]["Reason"].ToString();

            // Labtimeslot.Text = dt.Rows[0]["TimeSlotDetID"].ToString();
            

            if (Labblockby.Text.Trim() == "WholeSite")
            {
                trgov.Visible = false;
                trschool.Visible = false;
                trtimeslot.Visible = false;
                trmsg.Visible = true;

                lblmsg.Text = dt.Rows[0]["DisplayMsg"].ToString();
            }
            else
            {
                trgov.Visible = true;
                trschool.Visible = true;
                trtimeslot.Visible = true;
                trmsg.Visible = false;


                LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

                LabArea.Text = dt.Rows[0]["AreaName"].ToString();

                LabSchool.Text = dt.Rows[0]["SchoolName"].ToString();

                LabStadium.Text = dt.Rows[0]["StadiumName"].ToString();

                LabCourt.Text = dt.Rows[0]["StadiumType"].ToString();

                string time = dt.Rows[0]["TimeSlotDetID"].ToString();

                             

                string syn = "select TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotDetID in (" + time + ")";
                dt = dbFunctions.GetData(syn);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Labtimeslot.Text = Labtimeslot.Text + dt.Rows[i]["TimeSlot"].ToString() + ',';
                    }
                }

                Labtimeslot.Text = Labtimeslot.Text.TrimEnd(new char[] { ',' });
            }
        }
    }

    
}