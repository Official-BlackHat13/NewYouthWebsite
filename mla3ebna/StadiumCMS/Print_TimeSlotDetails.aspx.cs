using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mla3ebna_StadiumCMS_Print_TimeSlotDetails : System.Web.UI.Page
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
        DateTime strdate;

        DataSet ds = new DataSet();

        DataTable dt;


        ds = dbFunctions.GetDS("exec SP_GetTimeSlotDetails @TimeSlotMasterID=" + Request.QueryString["TimeSlotMasterID"]);
        dt = ds.Tables[0];

        
        if (dt.Rows.Count > 0)
          
          {
              rpdetails.DataSource = dt;
          }
            else
          {
              rpdetails.DataSource = "";
          }


        rpdetails.DataBind();
            LabBookingStatus.Text = dt.Rows[0]["Type"].ToString();

            //strdate = DateTime.Parse(dt.Rows[0]["BookingDate"].ToString());

            //LabBookingStatus.Text = dt.Rows[0]["Type"].ToString();

            //LabPaymentStatus.Text = dt.Rows[0]["TimeSlot"].ToString();

           
        }
        
         
    }

   
    
