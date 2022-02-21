using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            FillSportCategory();

            FillGovernorate();
            FillArea();
            FillStadium();
            FillTime();

            FillAbout();
            FillData();
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
    }

    protected void FillGovernorate()
    {
        string ls_passvalue = string.Empty;
        if (!string.IsNullOrEmpty(hiddenSearchDate.Value.ToString()) && !hiddenSearchDate.Value.Equals("Dd/Mm/Yy"))
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


        ls_passvalue = ls_passvalue.Trim(new char[]{','});

       // DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Governorate @ls_passvalue=' '" + ls_passvalue);

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_GovernorateForSearch " + ls_passvalue);

        ddlGov.Items.Insert(0, new ListItem("--Select--","0"));

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

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue) && !ddlGov.SelectedValue.Equals("0"))
            ls = ls + ",@ls_passvalue= 'and a.GovernorateID=" + ddlGov.SelectedValue+"'";
        else
            ls = ls + ",@ls_passvalue= ''";

        if (!string.IsNullOrEmpty(DDLSportType.SelectedValue) && !DDLSportType.SelectedValue.Equals("0"))
            ls = ls + ",@SportID='" + DDLSportType.SelectedValue.ToString() + "'";

        if (Session["UserGender"] != null)
        {
            ls = ls + ",@gender= '" + ((Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1")) + "'";
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

        ddlArea.Items.Insert(0, new ListItem("--Select--","0"));
    }

    protected void FillStadium()
    {
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

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue) && !ddlGov.SelectedValue.Equals("0"))
        {
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue) && !ddlArea.SelectedValue.Equals("0"))
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
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue) && !ddlArea.SelectedValue.Equals("0"))
                ls_passvalue = ls_passvalue + ",@ls_passvalue= ' and a.AreaID=" + ddlArea.SelectedValue + "'";
        }
       

        if ((string.IsNullOrEmpty(ddlGov.SelectedValue) || ddlGov.SelectedValue.Equals("0")) && (string.IsNullOrEmpty(ddlArea.SelectedValue) || ddlArea.SelectedValue.Equals("0")))
        {
            ls_passvalue = ls_passvalue + ",@ls_passvalue= ''";
        }

        ls_passvalue = ls_passvalue.Trim(new char[] { ',' });

        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_Stadium " + ls_passvalue );

        if (dt.Rows.Count > 0)
        {
            ddlStadium.DataSource = dt;
            ddlStadium.DataTextField = "StadiumName";
            ddlStadium.DataValueField = "StadiumID";
            ddlStadium.DataBind();
        }

        ddlStadium.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void FillTime()
    {
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

        if (!string.IsNullOrEmpty(ddlGov.SelectedValue) && !ddlGov.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@ai_govid=" + ddlGov.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_govid= 0";


        if (!string.IsNullOrEmpty(ddlArea.SelectedValue) && !ddlArea.SelectedValue.Equals("0"))
            ls_passvalue = ls_passvalue + ",@ai_areaid=" + ddlArea.SelectedValue;
        else
            ls_passvalue = ls_passvalue + ",@ai_areaid = 0";

        if (!string.IsNullOrEmpty(ddlStadium.SelectedValue) && !ddlStadium.SelectedValue.Equals("0"))
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

        ddlTime.Items.Insert(0, new ListItem("--Select--", "0"));
    } 

    protected void FillAbout()
    {
        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_PageContent @ls_type='About'");

        if (dt.Rows.Count > 0)
            lblAbout.Text = dt.Rows[0]["PageContent"].ToString();
        else
            lblAbout.Text = "";
    }

    protected void FillData()
    {
        lblError.Text = "";
        DataTable dt = clsGeneral.GetDt("exec SP_Get_MYA_Maleabna_PopularStadiums ");
        if (dt.Rows.Count > 0)
        {
            DataColumnCollection columns = dt.Columns;
            if (!columns.Contains("Error"))
            {

                rpPopularStadiums.DataSource = dt;
                rpPopularStadiums.DataBind();
            }
            else
            {
                rpPopularStadiums.DataSource = "";
                rpPopularStadiums.DataBind();
                lblError.Text = dt.Rows[0]["Error"].ToString(); ;
            }
        }
        else
        {
            rpPopularStadiums.DataSource = "";
            rpPopularStadiums.DataBind();
            lblError.Text = "No Data Found" ;
        }
    }

    protected void rpPopularStadiums_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string command = e.CommandName.ToString();

        switch (command)
        {
            case "OpenModel":
                hiddenID.Value = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "modeOpen();", true);
                break;

        }
      
    }
    
    protected void lnkGetStadiumData_Click(object sender, EventArgs e)
    {
        string date = hiddenDate.Value.ToString();
        string ID = hiddenID.Value.ToString();

        if (!string.IsNullOrEmpty(ID))
        {

            Session["stdresult"] = date + "," + ID;

            Response.Redirect("SearchStadiumResult.aspx", false);
        }
        else
        {
            Session["std"] = date;
            Response.Redirect("SearchStadium.aspx", false);
        }

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
            if (!ddlStadium.SelectedValue.Equals("0") && !string.IsNullOrEmpty(ddlStadium.SelectedValue))
            {
                string session = (hiddenSearchDate.Value) + "," + ((!string.IsNullOrEmpty(ddlStadium.SelectedValue)) ? ddlStadium.SelectedValue : "0");
                Session["stdresult"] = session;
                Response.Redirect("SearchStadiumResult.aspx", false);
            }
            else
            {
                string sp = DDLSportType.SelectedValue;
                string session = (hiddenSearchDate.Value) + "," + ((!string.IsNullOrEmpty(ddlGov.SelectedValue) && (!ddlGov.SelectedValue.Equals("0"))) ? ddlGov.SelectedValue : "") + "," + ((!string.IsNullOrEmpty(ddlArea.SelectedValue) && (!ddlArea.SelectedValue.Equals("0"))) ? ddlArea.SelectedValue : "")+","+(((!string.IsNullOrEmpty(DDLSportType.SelectedValue.ToString()) && (!DDLSportType.SelectedValue.Equals("0"))) ? DDLSportType.SelectedValue : ""));
                Session["std"] = session;
                Response.Redirect("SearchStadium.aspx", false);
            }
        }
    }


    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public static List<Dictionary<string, object>> GetData1()
    {
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;

        DS = GetDS1("exec SP_Get_MapData", "", "Table", true);

        dt = DS.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    DateTime dtt = DateTime.Parse(dr[col].ToString());
                    row.Add(col.ColumnName, dtt.ToString("dd-MM-yyyy hh:mm:ss"));
                }
                else
                    row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }

        return rows;
    }


    public static DataSet GetDS1(string strSQL, string strConnectionStringKey, string strTableName, bool blnIsSrno)
    {
        DataTable dt = new DataTable();
        //General gm = new General();

        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MalebnaDB"].ConnectionString);
        string[] a = new string[1];
        DataRow dr;
        DataTable dtDataTable;
        if (conGlobal.State == ConnectionState.Closed)
            conGlobal.Open();
        var SDA = new SqlDataAdapter(strSQL, conGlobal);
        DataSet DS = new DataSet();
        try
        {
            dtDataTable = new DataTable(strTableName);
            DataColumn dcolSrNo;
            if ((blnIsSrno == true))
            {
                dcolSrNo = new DataColumn("SlNo");
                dcolSrNo.AutoIncrement = true;
                dcolSrNo.AutoIncrementSeed = 1;
                dcolSrNo.AutoIncrementStep = 1;
                dtDataTable.Columns.Add(dcolSrNo);
            }
            DS.Tables.Add(dtDataTable);
            SDA.Fill(DS, strTableName);
            SDA.Dispose();
            return DS;
        }
        catch (Exception ex)
        {
            dt.Columns.Clear();
            dt.Columns.Add("Error");
            dr = dt.NewRow();
            dr["Error"] = ex.Message.Trim();
            dt.Rows.Add(dr);
            DS.Tables.Add(dt);
            conGlobal.Close();
            return DS;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }


    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public static string SearchMap(string stadiumID, string currentDate)
    {

        try
        {


            if (!string.IsNullOrEmpty(stadiumID))
            {


                string session = currentDate + "," + stadiumID;
                HttpContext.Current.Session["stdresult"] = session;
              //  Response.Redirect("SearchStadiumResult.aspx", false);
                return "SearchStadiumResult.aspx";
                
          
            }      


               return "0";
         
        }
        catch (Exception ex)
        {

            throw ex.InnerException;
        }

    }

    protected void lnkMapDate_Click(object sender, EventArgs e)
    {

    }
}