using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchStadium : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    public string Dateset, myRate, rating;
    string GstrDbKey = "MalebnaDB";
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Session["userid"] = "140222";
        
            if (!this.IsPostBack)
            {
                if (Session["std"] != null)
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

            //ListItem it_bo = new ListItem();
            //it_bo.Text = "<--أختار-->";
            //it_bo.Value = "0";
            //it_bo.Selected = true;
            //DDLSportType.Items.Add(it_bo);
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
    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }
    protected void FillGovernorate()
    {
        DDLGov.ClearSelection();
        DDLGov.Items.Clear();
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("اليوم/الشهر/السنة") && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
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


        //DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Governorate @ls_passvalue=' '" + ls_passvalue);
        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForSearch " + ls_passvalue);


        DDLGov.Items.Insert(0, new ListItem("--اختيار--", "0"));

        if (dt.Rows.Count > 0)
        {
            DDLGov.DataSource = dt;
            DDLGov.DataTextField = "GovernorateName";
            DDLGov.DataValueField = "GovernorateID";
            DDLGov.DataBind();
        }

    }

    protected void FillArea()
    {
        DDLArea.Items.Clear();
        string ls = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy") && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls = "@ai_date='" + date + "'";
        }
        else
            ls = "@ai_date=''";

        if (!string.IsNullOrEmpty(DDLGov.SelectedValue))
            ls = ls + ",@ls_passvalue= 'and a.GovernorateID=" + DDLGov.SelectedValue + "'";
        else
            ls = ls + ",@ls_passvalue= ''";

        if (!string.IsNullOrEmpty(DDLSportType.SelectedValue) && !DDLSportType.SelectedValue.Equals("0"))
            ls = ls + ",@SportID='"+DDLSportType.SelectedValue.ToString()+"'";

        if (Session["UserGender"] != null)
        {
            ls = ls + ",@gender= '" + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
        }

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_AreaForSearch " + ls);

        if (dt.Rows.Count > 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();
        }

        DDLArea.Items.Insert(0, new ListItem("--اختيار--", "0"));
        DDLArea_SelectedIndexChanged(null, null);
    }

    protected void FillStadium()
    {
        DDLStadium.Items.Clear();
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy") && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = "@ai_date='" + date + "'";
        }
        else
            ls_passvalue = "@ai_date=''";

        if (!string.IsNullOrEmpty(DDLSportType.SelectedValue) && !DDLSportType.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@SportID='" + DDLSportType.SelectedValue.ToString() + "'";

        if (Session["UserGender"] != null)
        {
            ls_passvalue = ls_passvalue + ",@gender=' " + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
        }


        if (!string.IsNullOrEmpty(DDLGov.SelectedValue) )
        {
            if (!string.IsNullOrEmpty(DDLArea.SelectedValue))
            {
                ls_passvalue = ls_passvalue + " ,@ls_passvalue= 'and a.GovernorateID=" + DDLGov.SelectedValue + " and a.AreaID=" + DDLArea.SelectedValue + "'";
            }
            else
            {
                ls_passvalue = ls_passvalue + ",@ls_passvalue= 'and a.GovernorateID=" + DDLGov.SelectedValue + "'";
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(DDLArea.SelectedValue) && !DDLArea.SelectedValue.Equals("0"))
                ls_passvalue = ls_passvalue + ",@ls_passvalue= ' and a.AreaID=" + DDLArea.SelectedValue + "'";
        }


        if ((string.IsNullOrEmpty(DDLGov.SelectedValue) || DDLGov.SelectedValue.Equals("0")) && (string.IsNullOrEmpty(DDLArea.SelectedValue) || DDLArea.SelectedValue.Equals("0")))
        {
            ls_passvalue = ls_passvalue + ",@ls_passvalue= ''";
        }

        

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium " + ls_passvalue);

        if (dt.Rows.Count > 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";
            DDLStadium.DataBind();
        }

        DDLStadium.Items.Insert(0, new ListItem("--اختيار--", "0"));
        DDLStadium_SelectedIndexChanged(null, null);
    }

    protected void FillTime()
    {
        DDLTimeSlot.Items.Clear();
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy") && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
        {
            string date = hiddenSearchDate.Value;
            DateTime temp = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            date = temp.ToString("yyyy-MM-dd");
            ls_passvalue = "@ai_date='" + date + "'";
        }
        else
            ls_passvalue = "@ai_date=''";

        if (!string.IsNullOrEmpty(DDLGov.SelectedValue) && !DDLGov.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@ai_govid=" + DDLGov.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_govid= 0";


        if (!string.IsNullOrEmpty(DDLArea.SelectedValue) && !DDLArea.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@ai_areaid=" + DDLArea.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_areaid = 0";

        if (!string.IsNullOrEmpty(DDLStadium.SelectedValue) && !DDLStadium.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@ai_stadid=" + DDLStadium.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_stadid = 0";

        DataTable dt = clsGeneral.GetDt("exec SP_MYA_Maleabna_TimeSlot_Search " + ls_passvalue);

        if (dt.Rows.Count > 0)
        {
            DDLTimeSlot.DataSource = dt;
            DDLTimeSlot.DataTextField = "TimeSlot";
            DDLTimeSlot.DataValueField = "TimeID";
            DDLTimeSlot.DataBind();
        }

        DDLTimeSlot.Items.Insert(0, new ListItem("--اختيار--", "0"));
    }


    protected void FillData()
    {
        string[] arr;       

        string ls = string.Empty;

        arr = Session["std"].ToString().Split(new char[] { ',' });
        string date = arr[0];
        if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]) )
            ls = "and a.GovernorateID="+arr[1];
        if (arr.Length > 2 && !string.IsNullOrEmpty(arr[2]))
            ls = ls + " and a.AreaID=" + arr[2];       
        if (arr.Length > 3 && !string.IsNullOrEmpty(arr[3]))
            ls = ls + " and a.SportCategory=" + arr[3];
        

        /******* Assign Date to public variable(to assign to the datepicker textbox) and hidden field (to use the value from code behind)*/
        hiddenSearchDate.Value = date;
        Dateset = date;


        string str = "";
        if (hiddenSearchDate.Value != "" && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
        {
            DateTime temp = DateTime.ParseExact(hiddenSearchDate.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            str = temp.ToString("yyyy-MM-dd");
        }

        string time = string.Empty;

        time = ((DDLTimeSlot.SelectedValue != "0" && !string.IsNullOrEmpty(DDLTimeSlot.SelectedValue)) ? DDLTimeSlot.SelectedValue : "");

        string list = string.Empty;
        int userid = 0;
        if (Session["UserGender"] != null)
        {
            list = list + "@gender='" + (Session["UserGender"].ToString().Trim() == "أنثى"?"0":"1") + "'";
        }

        //if (Session["UserUID"] != null)
        //{
        //    userid = getUserid(Session["UserUID"].ToString());
           
        //}
        ls = ls.Trim(new char[] { ',' });

       
        //if (!userid.Equals(0))
        //{
        //    if (!string.IsNullOrEmpty(list))
        //    {
        //        list = list + ",@uid ='" + userid + "'";
        //    }
        //    else
        //    {
        //        list = list + "@uid ='" + userid + "'";
        //    }
        //}

        string strGender = (!string.IsNullOrEmpty(list) ? "," + list : null);
        

        DataSet ds = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Search '" + ls + "','" + str + "','" + time +"'"+ strGender, GstrDbKey, "Table", true);


        AssignValues(arr);

        LoadData(ds);

    }

    //public DataTable Get_MYA_Maleabna_Search(string ls_passvalue, string ls_date, string ls_time)
    //{

    //    DataTable dt = new DataTable();
    //    DataSet DS = new DataSet();
       

    //    try
    //    {
    //        string str = "";
    //        if (ls_date != "")
    //        {
    //            DateTime temp = DateTime.ParseExact(ls_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    //            str = temp.ToString("yyyy-MM-dd");
    //        }
    //        DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Search '" + ls_passvalue + "','" + str + "','" + ls_time + "'", GstrDbKey, "Table", true);

    //        if (DS.Tables[0].Rows.Count == 0)
    //            dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
    //        else
    //            dt = DS.Tables[0];
    //        //Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
    //    }
    //    catch (Exception ex)
    //    {
    //       dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
    //    }
    //    finally
    //    {

    //    }

    //    return dt;

    //}

    protected void LoadData(DataSet ds)
    {
        DataTable dt = ds.Tables[0];
        int count = dt.Rows.Count;
        if (dt.Rows.Count > 0)
        {
            rpStadiums.DataSource = dt;
            rpStadiums.DataBind();
        }
        else
        {
            rpStadiums.DataSource = "";
            rpStadiums.DataBind();
        }

       

       
    }

   

    protected void AssignValues(string[] arr)
    {

        DDLGov.ClearSelection();
        DDLArea.ClearSelection();     
        DDLSportType.ClearSelection();
        string GovID = string.Empty;
        string AreaID = string.Empty;
        string SportID = string.Empty;


        if (arr.Length > 3 && !string.IsNullOrEmpty(arr[3]))  // first sports data has to be bind
        {
            SportID = arr[3];
            DDLSportType.ClearSelection();
            DDLSportType.Items.FindByValue(SportID).Selected = true;
            DDLSportType_SelectedIndexChanged(null, null);
        }   
        if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1]) )
        {
            GovID = arr[1];
            if (DDLGov.Items.FindByValue(GovID) != null)
            {
                DDLGov.ClearSelection();                
                DDLGov.Items.FindByValue(GovID).Selected = true;
                DDLGov_SelectedIndexChanged(null, null);
            }
        }
        if (arr.Length > 2 && !string.IsNullOrEmpty(arr[2]))
        {
            AreaID = arr[2];
            if (DDLArea.Items.FindByValue(AreaID) != null)
            {
                DDLArea.ClearSelection();
                DDLArea.Items.FindByValue(AreaID).Selected = true;
                DDLArea_SelectedIndexChanged(null, null);
            }
        }
            
       
    }
    protected void DDLGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillArea();
    }
    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStadium();
    }
    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTime();
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {      
        if (!DDLStadium.SelectedValue.Equals("0") && !string.IsNullOrEmpty(DDLStadium.SelectedValue))
        {
            string session = (hiddenSearchDate.Value) + "," + ((!string.IsNullOrEmpty(DDLStadium.SelectedValue)) ? DDLStadium.SelectedValue : "0");
            Session["stdresult"] = session;
            Response.Redirect("SearchStadiumResult.aspx", false);
           
        }
        else
        {
            string ls = string.Empty;

            if (!DDLGov.SelectedValue.Equals("0") && !string.IsNullOrEmpty(DDLGov.SelectedValue))
                ls = "and a.GovernorateID=" + DDLGov.SelectedValue;
            if (!DDLArea.SelectedValue.Equals("0") && !string.IsNullOrEmpty(DDLArea.SelectedValue))
                ls = ls + " and a.AreaID=" + DDLArea.SelectedValue;
            if (!DDLSportType.SelectedValue.Equals("0") && !string.IsNullOrEmpty(DDLSportType.SelectedValue.ToString()))
                ls = ls + " and a.SportCategory= " + DDLSportType.SelectedValue.ToString();
            //if (Session["UserGender"] != null)
            //{
            //    ls = ls + " and a.Gender='" + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
            //}

            string str = "";
            if (hiddenSearchDate.Value != "" && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
            {
                DateTime temp = DateTime.ParseExact(hiddenSearchDate.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                str = temp.ToString("yyyy-MM-dd");
            }

            string time = string.Empty;

            time = ((DDLTimeSlot.SelectedValue != "0" && !string.IsNullOrEmpty(DDLTimeSlot.SelectedValue)) ? DDLTimeSlot.SelectedValue : "");



            string list = string.Empty;
            if (Session["UserGender"] != null)
            {
                list = list + "@gender='" + (Session["UserGender"].ToString().Trim() == "أنثى" ? "0" : "1") + "'";
            }

            string strGender = (!string.IsNullOrEmpty(list) ? "," + list : null);

            DataSet ds = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Search '" + ls + "','" + str + "','" + time + "'" + strGender, GstrDbKey, "Table", true);


          //  DataSet ds = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Search '" + ls + "','" + str + "','" + time + "'", GstrDbKey, "Table", true);

            LoadData(ds);
        }
    }
    protected void rpStadiums_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string search = e.CommandName.ToString();
        switch(search){
            case "stadiumResult":
                if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
                {
                    string session = (hiddenSearchDate.Value) + "," + e.CommandArgument.ToString();
                    Session["stdresult"] = session;
                    Response.Redirect("SearchStadiumResult.aspx", false);
                }
                break;
        }
    }

    protected void rpStadiums_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
           // DataRowView usrCurrent = e.Item.DataItem as DataRowView;

            string rating1 = (DataBinder.Eval(e.Item.DataItem, "Rating1")).ToString();
            string rating2 = (DataBinder.Eval(e.Item.DataItem, "Rating2")).ToString();
            string rating3 = (DataBinder.Eval(e.Item.DataItem, "Rating3")).ToString();

            if (!string.IsNullOrEmpty(rating1) && !rating1.Equals("0.0"))
            {
                
                string r1 = ("Radio1" + rating1).Replace('.', '_');
                RadioButton rb1 = e.Item.FindControl(r1) as RadioButton;
                rb1.Checked = true;

               // ContentPlaceHolder1_rpStadiums_Radio11_5_0
            }


            if (!string.IsNullOrEmpty(rating2) && !rating2.Equals("0.0"))
            {
                string r2 = ("Radio2" + rating2).Replace('.', '_');
                RadioButton rb2 = e.Item.FindControl(r2) as RadioButton;
                rb2.Checked = true;
            }

            if (!string.IsNullOrEmpty(rating3) && !rating3.Equals("0.0"))
            {
                string r3 = ("Radio3" + rating3).Replace('.', '_');
                RadioButton rb3 = e.Item.FindControl(r3) as RadioButton;
                rb3.Checked = true;
            }

        }
    }



    protected void FillGovernorate_FromSportType(string sportID)
    {
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("NaN-NaN-NaN"))
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
            ls_passvalue = ls_passvalue + ",@gender= '" + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
        }
        //if (Session["UserUID"] != null)
        //{
        //    int uid = getUserid(Session["UserUID"].ToString());
        //    ls_passvalue = ls_passvalue + ",@uid='" + uid + "'";
        //}

        ls_passvalue = ls_passvalue.Trim(new char[]{','});

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForSearch " + ls_passvalue);

       // DDLGov.Items.Insert(0, new ListItem("--اختيار--", "0"));

        if (dt.Rows.Count > 0)
        {
            DDLGov.DataSource = dt;
            DDLGov.DataTextField = "GovernorateName";
            DDLGov.DataValueField = "GovernorateID";
            DDLGov.DataBind();
        }
        else
        {
            DDLGov.DataSource = "";
            DDLGov.DataBind();
        }
        DDLGov.Items.Insert(0, new ListItem("--اختيار--", "0"));
    }



    protected void DDLSportType_SelectedIndexChanged(object sender, EventArgs e)
    {

        string SportID = DDLSportType.SelectedValue.ToString();
        FillGovernorate_FromSportType(SportID);
        DDLGov_SelectedIndexChanged(null, null);
    }


    protected void lnkFillGovernorate_Click(object sender, EventArgs e)
    {
        Dateset = hiddenSearchDate.Value.ToString();
        FillGovernorate();
    }
}