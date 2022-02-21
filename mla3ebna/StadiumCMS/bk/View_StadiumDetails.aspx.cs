using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_StadiumDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv, StrGuardDiv, StrMaintenanceDiv, StadiumCourtType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           CMSCurrentUser.CheckLoggedIn();
            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();
            fillCourtData();

            fillStadiumGalleryData();
            fillStadiumVideosData();
            fillStadiumGuardData();
            fillStadiumMaintenanceData();
            
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_StadiumInfo] where StadiumID=" + Request.QueryString["StadiumID"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            LabStadiumID.Text = dt.Rows[0]["StadiumID"].ToString();

            LabStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();       

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

            LabArea.Text = dt.Rows[0]["AreaName"].ToString();  

            LabSchool.Text = dt.Rows[0]["SchoolName"].ToString();       

            LabAddress.Text = dt.Rows[0]["Address"].ToString();         

            LabKuwaitfinderNumber.Text = "<a href='" + dt.Rows[0]["KuwaitFinderLocation"].ToString() + "' target='_blank'>" + dt.Rows[0]["KuwaitFinderNumber"].ToString() + "</a>";

            LabGoogleMapLocation.Text = "<a href='https://maps.google.com/?q=" + dt.Rows[0]["GoogleMapLocation"].ToString() + "' target='_blank'>View Location</a>";

            LabDescription.Text = dt.Rows[0]["Description"].ToString();          

            LabNote.Text = dt.Rows[0]["Note"].ToString();



            //LabStadiumNameEn.Text = dt.Rows[0]["StadiumNameEn"].ToString();

            //LabGovernorateEn.Text = dt.Rows[0]["GovernorateNameEn"].ToString();

            //LabAreaEn.Text = dt.Rows[0]["AreaNameEn"].ToString();

            //LabSchoolEn.Text = dt.Rows[0]["SchoolNameEn"].ToString();

            //LabAddressEn.Text = dt.Rows[0]["AddressEn"].ToString();

            //LabDescriptionEn.Text = dt.Rows[0]["DescriptionEn"].ToString();

            //LabNoteEn.Text = dt.Rows[0]["Note"].ToString();
        }
    }

    private void fillCourtData()
    {
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select StadiumType,StadiumName from MYA_Maleabna_Stadium join MYA_Maleabna_Stadium_Detail on MYA_Maleabna_Stadium.StadiumID = MYA_Maleabna_Stadium_Detail.StadiumID where MYA_Maleabna_Stadium.StadiumID=" + Request.QueryString["StadiumID"];
        dt = dbFunctions.GetData(cmd);
        //CourtGrid.DataSource = dt;
        //CourtGrid.DataBind();
        //CourtGrid.PagerStyle.Visible = false;

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                StadiumCourtType = StadiumCourtType + "";
                StadiumCourtType = StadiumCourtType + "<tr> <td>";
                StadiumCourtType = StadiumCourtType + row["StadiumType"];
                StadiumCourtType = StadiumCourtType + "</td></tr>";
            }
        }
        
    }

    private void fillStadiumGalleryData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [MYA_Maleabna_Stadium_Gallery] where StadiumID=" + Request.QueryString["StadiumID"]);


        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrGalleryDiv = StrGalleryDiv + "";
                StrGalleryDiv = StrGalleryDiv + "<div class='property-item'>";
                StrGalleryDiv = StrGalleryDiv + "<a class='item-media-w' href='#'>";
                StrGalleryDiv = StrGalleryDiv + "<div class='item-media' style='background-image: url(Files/Stadium/Gallery/" + dt.Rows[i1]["Photo"] + ");background-size: cover;'></div>";
                StrGalleryDiv = StrGalleryDiv + "</a>";
                StrGalleryDiv = StrGalleryDiv + "<div class='item-info'>";

                StrGalleryDiv = StrGalleryDiv + " <h3 class='item-title'>" + dt.Rows[i1]["Title"] + "";
                StrGalleryDiv = StrGalleryDiv + "</h3>";

                StrGalleryDiv = StrGalleryDiv + " </div>";
                StrGalleryDiv = StrGalleryDiv + "</div>";
            }
        }
    }

    private void fillStadiumVideosData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [MYA_Maleabna_Stadium_Videos] where StadiumID=" + Request.QueryString["StadiumID"]);


        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                string video = "";
                if (dt.Rows[i1]["VideoUrl"].ToString().Contains("watch?v="))
                {
                    video = dt.Rows[i1]["VideoUrl"].ToString().Replace("watch?v=", "embed/");
                }
                else
                    video = dt.Rows[i1]["VideoUrl"].ToString();
                
                StrVideoDiv = StrVideoDiv + "<div class='col-lg-4'>  <div class='iframe-container'>"+
                                            "<iframe width='100%' height='315' src='" + video + "' frameborder='1' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" +
                                            "</div> </div>";
                //"<video  width='100%' height='315' loop src=''></video>" +  

                StrVideoDiv = StrVideoDiv + "<div class='property-item'>";
                StrVideoDiv = StrVideoDiv + "<a class='item-media-w' href='#'>";
                StrVideoDiv = StrVideoDiv + "<div class='item-media' style='background-image: url()'></div>";
                StrVideoDiv = StrVideoDiv + "</a>";
                StrVideoDiv = StrVideoDiv + "<div class='item-info'>";

                StrVideoDiv = StrVideoDiv + " <h3 class='item-title'>" + dt.Rows[i1]["Title"] + "";
                StrVideoDiv = StrVideoDiv + "</h3>";

                StrVideoDiv = StrVideoDiv + " </div>";
                StrVideoDiv = StrVideoDiv + "</div>";
            }
        }
    }

    private void fillStadiumGuardData()
    {
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from MYA_Maleabna_Stadium_Guard join MYA_Maleabna_Guard on MYA_Maleabna_Guard.GuardID = MYA_Maleabna_Stadium_Guard.GuardID where MYA_Maleabna_Stadium_Guard.StadiumID=" + Request.QueryString["StadiumID"];
        dt = dbFunctions.GetData(cmd);


        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrGuardDiv = StrGuardDiv + "";
                StrGuardDiv = StrGuardDiv + "<div class='property-item'>";
                //StrGuardDiv = StrGuardDiv + "<a class='item-media-w' href='#'>";
                //StrGuardDiv = StrGuardDiv + "<div class='item-media' style='background-image: url(../Files/Stadium/Gallery/" + dt.Rows[i1]["Photo"] + ")'></div>";
                //StrGuardDiv = StrGuardDiv + "</a>";
                StrGuardDiv = StrGuardDiv + "<div class='item-info'>";

                StrGuardDiv = StrGuardDiv + "<tr> <td> Name: </td> ";
                StrGuardDiv = StrGuardDiv + " <td><h3 class='item-title'> " + dt.Rows[i1]["GuardName"] + "";
                StrGuardDiv = StrGuardDiv + "</h3></td> </tr>";

                StrGuardDiv = StrGuardDiv + "<tr> <td> Mobile: </td> ";
                StrGuardDiv = StrGuardDiv + " <td><h3 class='item-title'> " + dt.Rows[i1]["Mobile"] + "";
                StrGuardDiv = StrGuardDiv + "</h3> </td></tr>";

                StrGuardDiv = StrGuardDiv + "<tr> <td> CivilID: </td> ";
                StrGuardDiv = StrGuardDiv + " <td><h3 class='item-title'>" + dt.Rows[i1]["CivilID"] + "";
                StrGuardDiv = StrGuardDiv + "</h3></td></tr>";

               
                StrGuardDiv = StrGuardDiv + " </div>";
                StrGuardDiv = StrGuardDiv + "</div>";
            }
        }
    }

    private void fillStadiumMaintenanceData()
    {
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select MaintenanceID,format(MaintenanceDate,'MM/dd/yyyy') as MaintenanceDate,MaintenanceType,MaintenanceAmount,MaintenanceBill from [MYA_Maleabna_StadiumMaintenance] where StadiumId= " + Request.QueryString["StadiumID"];
        dt = dbFunctions.GetData(cmd);


        if (dt.Rows.Count != 0)
        {
            theader.Visible = true;
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrMaintenanceDiv = StrMaintenanceDiv + "";
                StrMaintenanceDiv = StrMaintenanceDiv + "<div class='property-item'>";

                StrMaintenanceDiv = StrMaintenanceDiv + "<div class='item-info'>";



                StrMaintenanceDiv = StrMaintenanceDiv + "<tr>";

                StrMaintenanceDiv = StrMaintenanceDiv + " <td><h3 class='item-title'> " + dt.Rows[i1]["MaintenanceType"] + "";
                StrMaintenanceDiv = StrMaintenanceDiv + "</h3> </td>";


                StrMaintenanceDiv = StrMaintenanceDiv + "<td> <h3 class='item-title'> " + dt.Rows[i1]["MaintenanceDate"] + "";
                StrMaintenanceDiv = StrMaintenanceDiv + "</h3></td>";


                StrMaintenanceDiv = StrMaintenanceDiv + "<td> <h3 class='item-title'>" + dt.Rows[i1]["MaintenanceAmount"] + "";
                StrMaintenanceDiv = StrMaintenanceDiv + "</h3></td>";



                StrMaintenanceDiv = StrMaintenanceDiv + "<td><a class='item-media-w' href='#'>";
                StrMaintenanceDiv = StrMaintenanceDiv + "<div class='item-media' style='background-image: url(Files/Stadium/Maintenance/" + dt.Rows[i1]["MaintenanceBill"] + ");width:200px; height:200px;background-size: cover;'></div>";
                StrMaintenanceDiv = StrMaintenanceDiv + "</a></td>";

                StrMaintenanceDiv = StrMaintenanceDiv + "</tr>";

                StrMaintenanceDiv = StrMaintenanceDiv + " </div>";
                StrMaintenanceDiv = StrMaintenanceDiv + "</div>";
            }

        }
        else
        {
            theader.Visible = false;
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_Stadium.aspx?ID=" + Request.QueryString["StadiumID"] + "");
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        cmd = "delete from [MYA_Maleabna_Stadium] where [StadiumID] = " + Request.QueryString["StadiumID"];
        dbFunctions.ExecuteQuery(cmd);
        CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Stadium", "Delete", DateTime.Now, "" + Request.QueryString["StadiumID"] + "", "" + LabStadiumName.Text + "", "");
        Response.Redirect("Manage_Stadium.aspx", false);
       
    }


}