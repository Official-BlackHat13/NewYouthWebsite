using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    public string Dateset = string.Empty, myRate, rating;
    string GstrDbKey = "MalebnaDB";
    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["UserUID"] = "140222";
        
            if (!this.IsPostBack)
            {
                if (Session["stdresult"] != null)
                {
                    FillSportCategory();
                    FillGovernorate();
                    FillArea();
                    FillStadium();
                    FillTime();                   

                    FillData();
                 
                }
                else
                    Response.Redirect("index.aspx", false);
            }
       
    }




    private void FillSportCategory()
    {
        //SportType
        string cmd;
        DataTable dt;
        //cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = clsGeneral.GetDt("exec SP_GetSportCategory ");

        if (dt.Rows.Count != 0)
        {
            DDLSportType.DataSource = dt;
            DDLSportType.DataTextField = "Sport";
            DDLSportType.DataValueField = "ID";
            DDLSportType.DataBind();
        }
        else
        {
            DDLSportType.Items.Clear();


            //ListItem it_bo = new ListItem();
            //it_bo.Text = "<--أختار-->";
            //it_bo.Value = "0";
            //it_bo.Selected = true;
            //DDLSportType.Items.Add(it_bo);
        }

      //  DDLSportType.Items.Insert(0, new ListItem("--اختيار--", "0"));
    }

    protected void FillRating()
    {
        int userID = 0;

        if (Session["UserUID"] != null)
            userID = getUserid(Session["UserUID"].ToString());
        //else
        //    userID = "0";

        string[] arr = Session["stdresult"].ToString().Split(new char[] { ',' });

        string date = arr[0];
        string stadiumID = arr[1];

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium_Rating @li_userid=" + userID + ",@li_stadid=" + stadiumID);

        if (dt.Rows.Count > 0)
        {
            myRate = dt.Rows[0]["myrating"].ToString().Trim();
            rating = dt.Rows[0]["rating"].ToString();
            string fav = dt.Rows[0]["fav"].ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "StadiumRating(" + myRate + "," + rating + "," + fav+ ");", true);
        }
        else
        {
            myRate = "";
            rating = "";
        }
    }

    protected void FillImages()
    {
        //DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium_Gallery " + ddlStadium.SelectedValue);
        //if (dt.Rows.Count > 0)
        //{
        //    rpImages.DataSource = dt;
        //    rpImages.DataBind();
        //}
        //else
        //{
        //    rpImages.DataSource = "";
        //    rpImages.DataBind();
        //}
    }

    protected void FillVideos()
    {
        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium_Videos @li_stadid=" + ddlStadium.SelectedValue);

        if (dt.Rows.Count > 0)
        {
            rpVideos.DataSource = dt;
            rpVideos.DataBind();           
                   
        }
        else
        {
            rpVideos.DataSource = "";
            rpVideos.DataBind();
        }

    }

   

    protected void FillData()
    {
        string[] arr;

        arr = Session["stdresult"].ToString().Split(new char[] { ',' });
        string date = arr[0];
        string stadiumID = arr[1];
        hiddenSearchDate.Value = date;
        Dateset = date;
        DataSet ds = clsGeneral.GetDSY("exec SP_MYA_Maleabna_GetTimeSummary @st_id=" + stadiumID);

        AssignValues(ds.Tables[0]);

        LoadData(ds);  
        
    }

    protected void LoadData(DataSet ds)
    {
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            FullBlock.Visible = false;
           
            rpStadiumType.DataSource = dt;
            rpStadiumType.DataBind();
            DivStadium.Visible = true;
        }
        else
        {
            FullBlock.Visible = true;

            rpStadiumType.DataSource = "";
            rpStadiumType.DataBind();

            DivStadium.Visible = false;
        }

        dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
           // lblStadiumNameEn.Text = dt.Rows[0]["StadiumNameEn"].ToString();
            lblAddress.Text = dt.Rows[0]["Address"].ToString();
            lblDescription.Text = dt.Rows[0]["Description"].ToString();
            lblAreaName.Text = dt.Rows[0]["AreaName"].ToString();
            lblGovernorateName.Text = dt.Rows[0]["GovernorateName"].ToString();
            lblGender.Text = (dt.Rows[0]["Gender"].ToString().Trim() == "1" ? "ذكر" : "أنثى");
        }
        else
        {
            lblStadiumName.Text = "";
           // lblStadiumNameEn.Text = "";
            lblAddress.Text = "";
            lblDescription.Text = "";
            lblAreaName.Text = "";
            lblGovernorateName.Text = "";           
        }

        FillImages();
        FillVideos();
        GetMap();
        FillRating();
    }

    protected void GetMap()
    {
        string date = hiddenSearchDate.Value.ToString();
        string stadiumID = ddlStadium.SelectedValue.ToString();

        DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        date = temp.ToString("yyyy-MM-dd");

        string ls_param = "@ai_stadid=" + stadiumID + ",@ai_date='" + date+"'";
        DataTable dt = clsGeneral.GetDt("exec SP_MYA_Maleabna_Result " + ls_param);

        if (dt.Rows.Count > 0)
        {
            hiddenKuwaitFounderLocation.Value = dt.Rows[0]["KuwaitFinderLocation"].ToString();
            hiddenGoogleMapLocation.Value = dt.Rows[0]["GoogleMapLocation"].ToString();

            if (dt.Rows[0]["FullBlock"].ToString().Trim() == "No")
            {
                FullBlock.Visible = false;
                updatedata.Visible = true;
                
            }
            else
            {
                FullBlock.Visible = true;
                updatedata.Visible = false;                
            }
        }
    }

    protected void AssignValues(DataTable dt)
    {
        DDLSportType.ClearSelection();
       
       // ddlArea.ClearSelection();
       // ddlStadium.ClearSelection();

        string[] arr = Session["stdresult"].ToString().Split(new char[] { ',' });

        string date = arr[0];
        string stadiumID = arr[1];
        //Response.Write(stadiumID);
        if (dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["SportCategory"].ToString()))
            {
                DDLSportType.Items.FindByValue(dt.Rows[0]["SportCategory"].ToString()).Selected = true;
                DDLSportType_SelectedIndexChanged(null, null);
            }
            if (ddlGov.Items.FindByValue(dt.Rows[0]["GovernorateID"].ToString()) != null)
            {

                ddlGov.ClearSelection();
                ddlGov.Items.FindByValue(dt.Rows[0]["GovernorateID"].ToString()).Selected = true;
                ddlGov_SelectedIndexChanged(null, null);
            }

            if (ddlArea.Items.FindByValue(dt.Rows[0]["AreaID"].ToString()) != null)
            {
                ddlArea.ClearSelection();
                ddlArea.Items.FindByValue(dt.Rows[0]["AreaID"].ToString()).Selected = true;
                ddlArea_SelectedIndexChanged(null, null);
            }

           if (ddlStadium.Items.FindByValue(dt.Rows[0]["StadiumID"].ToString()) != null)
           {
               ddlStadium.ClearSelection();
               ddlStadium.Items.FindByValue(dt.Rows[0]["StadiumID"].ToString()).Selected = true;
               ddlStadium_SelectedIndexChanged(null, null);
           }
        }
        else
        {
            DDLSportType.SelectedValue = "0";
            ddlGov.SelectedValue = "0";
            ddlArea.SelectedValue = "0";
            ddlStadium.SelectedValue = "0";
        }
    }

    protected void FillGovernorate()
    {
        ddlGov.ClearSelection();
        ddlGov.Items.Clear();

        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("اليوم/الشهر/السنة"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = ",@ai_date='" + date + "'";
        }
        else
            ls_passvalue = ",@ai_date=''";

        string sportID = DDLSportType.SelectedValue.ToString();
        if (!String.IsNullOrEmpty(sportID.ToString()) && !sportID.Equals("0"))
        {
            ls_passvalue = ls_passvalue + ",@sportID='" + sportID + "'";

        }
        if (Session["UserGender"] != null)
        {
            ls_passvalue = ls_passvalue + ",@gender= '" + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
        }
        //if (Session["UserUID"] != null)
        //{
        //    int uid = getUserid(Session["UserUID"].ToString());
        //    ls_passvalue = ls_passvalue + ",@uid='" + uid + "'";
        //}
        ls_passvalue = ls_passvalue.Trim(new char[] { ',' });
       // DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Governorate @ls_passvalue=' '" + ls_passvalue);
        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForSearch " + ls_passvalue);

        ddlGov.Items.Insert(0, new ListItem("--اختيار--", "0"));

        if (dt.Rows.Count > 0)
        {
            ddlGov.DataSource = dt;
            ddlGov.DataTextField = "GovernorateName";
            ddlGov.DataValueField = "GovernorateID";
            ddlGov.DataBind();
        }

    }

    protected void FillArea()
    {

        
        ddlArea.Items.Clear();
        string ls = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls = "@ai_date='" + date + "'";
        }
        else
            ls = "@ai_date=''";

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue) )
            ls = ls + ",@ls_passvalue= 'and a.GovernorateID=" + ddlGov.SelectedValue + "'";
        else
            ls = ls + ",@ls_passvalue= ''";

        if (Session["UserGender"] != null)
        {
            ls = ls + ",@gender= '" + (Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1") + "'";
        }

        ls = ls.Trim(new char[] { ',' });

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_AreaForSearch " + ls);

        if (dt.Rows.Count > 0)
        {
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaID";
            ddlArea.DataBind();
        }
        ddlArea.ClearSelection();
        ddlArea.Items.Insert(0, new ListItem("--اختيار--", "0"));
        ddlArea_SelectedIndexChanged(null, null);
    }

    protected void FillStadium()
    {
        ddlStadium.ClearSelection();
        ddlStadium.Items.Clear();

        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = "@ai_date='" + date + "'";
        }
        else
            ls_passvalue = "@ai_date=''";

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue))
        {
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
            {
                ls_passvalue = ls_passvalue + " ,@ls_passvalue= 'and a.GovernorateID=" + ddlGov.SelectedValue + " and a.AreaID=" + ddlArea.SelectedValue + "'";
            }
            else
            {
                ls_passvalue = ls_passvalue + ",@ls_passvalue= 'and a.GovernorateID=" + ddlGov.SelectedValue + "'";
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                ls_passvalue = ls_passvalue + ",@ls_passvalue= ' and a.AreaID=" + ddlArea.SelectedValue + "'";
        }


        if ((string.IsNullOrEmpty(ddlGov.SelectedValue)) && (string.IsNullOrEmpty(ddlArea.SelectedValue)))
        {
            ls_passvalue = ls_passvalue + ",@ls_passvalue= ''";
        }

        if (Session["UserGender"] != null)
        {
            ls_passvalue = ls_passvalue + ",@gender= '" + (Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1") + "'";
        }

        ls_passvalue = ls_passvalue.Trim(new char[] { ',' });

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium " + ls_passvalue);

        if (dt.Rows.Count > 0)
        {
            ddlStadium.DataSource = dt;
            ddlStadium.DataTextField = "StadiumName";
            ddlStadium.DataValueField = "StadiumID";
            ddlStadium.DataBind();
        }
       // ddlStadium.ClearSelection();
        ddlStadium.Items.Insert(0, new ListItem("--اختيار--", "0"));
        ddlStadium_SelectedIndexChanged(null, null);
    }

    protected void FillTime()
    {

        ddlTime.ClearSelection();
        ddlTime.Items.Clear();

        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = "@ai_date='" + date + "'";
        }
        else
            ls_passvalue = "@ai_date=''";

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue) )
            ls_passvalue = ls_passvalue + ",@ai_govid=" + ddlGov.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_govid= 0";


        if (!string.IsNullOrEmpty(ddlArea.SelectedValue) )
            ls_passvalue = ls_passvalue + ",@ai_areaid=" + ddlArea.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_areaid = 0";

        if (!string.IsNullOrEmpty(ddlStadium.SelectedValue) )
            ls_passvalue = ls_passvalue + ",@ai_stadid=" + ddlStadium.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_stadid = 0";

        DataTable dt = clsGeneral.GetDt("exec SP_MYA_Maleabna_TimeSlot_Search " + ls_passvalue);

        if (dt.Rows.Count > 0)
        {
            ddlTime.DataSource = dt;
            ddlTime.DataTextField = "TimeSlot";
            ddlTime.DataValueField = "TimeID";
            ddlTime.DataBind();
        }

        ddlTime.Items.Insert(0, new ListItem("--اختيار--", "0"));
    } 

    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        FillArea();
    }

    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStadium();
    }

    protected void ddlStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTime();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value))
        {
            if (!string.IsNullOrEmpty(ddlStadium.SelectedValue) && !ddlStadium.SelectedValue.ToString().Equals("0"))
            {
                ReloadData();
            }
            else
            {
                string session = (hiddenSearchDate.Value) + "," + ((!string.IsNullOrEmpty(ddlGov.SelectedValue) && (!ddlGov.SelectedValue.Equals("0"))) ? ddlGov.SelectedValue : "") + "," + ((!string.IsNullOrEmpty(ddlArea.SelectedValue) && (!ddlArea.SelectedValue.Equals("0"))) ? ddlArea.SelectedValue : "") + "," + (((!string.IsNullOrEmpty(DDLSportType.SelectedValue.ToString()) && (!DDLSportType.SelectedValue.Equals("0"))) ? DDLSportType.SelectedValue : ""));
                Session["std"] = session;
                Response.Redirect("SearchStadium.aspx", false);
            }
        }
    }

    protected void ReloadData()
    {
        string stadiumID = ddlStadium.SelectedValue.ToString();
        Dateset = hiddenSearchDate.Value;
        DataSet ds = clsGeneral.GetDSY("exec SP_MYA_Maleabna_GetTimeSummary @st_id=" + stadiumID);
        LoadData(ds);
        

    }

    protected void rpStadiumType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int stDetID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "StadiumDetId"));
           
            Repeater rp = e.Item.FindControl("rptimeslots") as Repeater;

          //  Label lblNotavailble = e.Item.FindControl("lblNotavailble") as Label;

            Label lbltype = e.Item.FindControl("lbltype") as Label;
            string sttype =DataBinder.Eval(e.Item.DataItem, "StadiumType").ToString().Trim();

            if (sttype == "Sevens")
                lbltype.Text = "٧ لاعبين";
            else if (sttype == "Elevens")
                lbltype.Text = "١١ لاعب";

            HtmlGenericControl DivHeading = e.Item.FindControl("DivHeading") as HtmlGenericControl;


            string date = hiddenSearchDate.Value.ToString();
            string stadiumID = ddlStadium.SelectedValue.ToString();

            
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");

            string ls_param = "@ai_stadid=" + stadiumID + ",@ai_date='" + date + "',@StadiumDetId="+stDetID;

            DataTable dt = clsGeneral.GetDt("exec SP_MYA_Maleabna_Result " + ls_param);

           
            
             //if (data[0].FullBlock == 'No') {
             //            $scope.disFullBlock = false;
             //        } else if (data[0].FullBlock == 'Yes') {
             //            $scope.disFullBlock = true;
             //        }

            if (dt.Rows.Count > 0)
            {
                DivHeading.Visible = true;
              //  lblNotavailble.Visible = false;
                rp.DataSource = dt;
                rp.DataBind();
            }
            else
            {
                DivHeading.Visible = false;
               // lblNotavailble.Visible = true;
                rp.DataSource = "";
                rp.DataBind();
                //return;
            }
        }
    }

    protected void rptimeslots_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string timesta = DataBinder.Eval(e.Item.DataItem, "TimeSta").ToString();

            HtmlGenericControl lblAvailable = e.Item.FindControl("lblAvailable") as HtmlGenericControl;
            HtmlGenericControl lblNotAvailable = e.Item.FindControl("lblNotAvailable") as HtmlGenericControl;

            HtmlGenericControl li = e.Item.FindControl("liTimeSlot") as HtmlGenericControl;

            if (timesta == "Available")
            {
                lblAvailable.Visible = true;
                lblNotAvailable.Visible = false;
                li.Attributes.Add("class", "txt3 clearfix radio-arrange");
            }
            else if (timesta == "Booked" || timesta == "Blocked")
            {
                lblAvailable.Visible = false;
                lblNotAvailable.Visible = true;
                lblNotAvailable.Attributes.Add("title", timesta);
                li.Attributes.Add("class", "txt3 clearfix block-time");               
            }
        }
    }
  

    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }

    protected void lnkbooking_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hiddenTimeSlotID.Value))
        {
            string[] arr = hiddenTimeSlotID.Value.ToString().Split(new char[] { ',' });  // it contains StadiumDetId at 0 position,timeslotDetID at 1 position and timeslot at 2nd position values 
            // Session["stdbooking"] = ddlStadium.SelectedValue + "," + hiddenSearchDate.Value + "," + ddlTime.SelectedValue + "," + ddlTime.SelectedItem.Text+","+StadiumDetID; 
            Session["stdbooking"] = ddlStadium.SelectedValue + "," + hiddenSearchDate.Value + "," + arr[1] + "," + arr[2]+","+ arr[0];
            Session["WType"] = "Booking";
           
            Response.Redirect("Booking-Knet.aspx", false);
        }
        //else
        //{
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "chooseTime();", true);
        //}
    }
    protected void lnk_Click(object sender, EventArgs e)
    {
        if (Session["UserUID"] != null)
        {

            DataInsertReturn dtr = new DataInsertReturn();




            int li_userid = getUserid(Session["UserUID"].ToString());
            try
            {
                //li_userid = getUserid(ls_euid);  // uncomment whenever encrypted session is using
                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Favorite 'I',0," + ddlStadium.SelectedValue + "," + li_userid, GstrDbKey);
                string style = dv.Attributes["class"].ToString();

                if (style == "heart")
                    dv.Attributes.Add("class", "heart is-active");
                else if (style == "heart is-active")
                {
                    dv.Attributes.Remove("class");
                    dv.Attributes.Add("class", "heart");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        else
            Response.Redirect("Login.aspx", false);

    }
    protected void lnkMyrationgUpdate_Click(object sender, EventArgs e)
    {
        if (Session["UserUID"] != null)
        {

            string myrationg = hiddenMyrationSelect.Value;
            string ls_euid = Session["UserUID"].ToString();

            DataTable dt = new DataTable();
            int li_userid;

            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid;
           // int li_userid = 0;
            try
            {
                Object obj;
               // li_userid = getUserid(ls_euid); //  int.Parse(ls_euid); // getUserid(ls_euid);
                li_userid = getUserid(ls_euid);
                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Rating 'I',0," + ddlStadium.SelectedValue + "," + li_userid + "," + myrationg, GstrDbKey);

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {

            }
        }else
            Response.Redirect("Login.aspx",false);

    }

    //private int getUserid(string ls_eid)
    //{
    //    int li_userid;
    //    li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
    //    return li_userid;
    //}

    protected void FillGovernorate_FromSportType(string sportID)
    {
        ddlGov.ClearSelection();
        ddlGov.Items.Clear();
        
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = "@ai_date='" + date + "'";
        }
        else
            ls_passvalue = "@ai_date=''";


        if (!String.IsNullOrEmpty(sportID.ToString()) && !sportID.Equals("0"))
        {
            ls_passvalue = ls_passvalue + ",@sportID='" + sportID + "'";

        }
        if (Session["UserGender"] != null)
        {
            ls_passvalue = ls_passvalue + ",@gender= '" + (Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1") + "'";
        }
        //if (Session["UserUID"] != null)
        //{
        //    int uid = getUserid(Session["UserUID"].ToString());
        //    ls_passvalue = ls_passvalue + ",@uid='" + uid + "'";
        //}

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForSearch " + ls_passvalue);



        if (dt.Rows.Count > 0)
        {
            ddlGov.DataSource = dt;
            ddlGov.DataTextField = "GovernorateName";
            ddlGov.DataValueField = "GovernorateID";
            ddlGov.DataBind();
        }
        else
        {
            ddlGov.DataSource = "";
            ddlGov.DataBind();
        }
        //ddlGov.ClearSelection();
        ddlGov.Items.Insert(0, new ListItem("--اختيار--", "0"));
        ddlGov_SelectedIndexChanged(null, null);
    }



    protected void DDLSportType_SelectedIndexChanged(object sender, EventArgs e)
    {

        string SportID = DDLSportType.SelectedValue.ToString();
        FillGovernorate_FromSportType(SportID);        
    }
    protected void lnkFillGovernorate_Click(object sender, EventArgs e)
    {
        Dateset = hiddenSearchDate.Value.ToString();
        FillGovernorate();
    }

}