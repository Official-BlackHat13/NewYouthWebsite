using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class YCLC_cp_YCLC_UserDetails : System.Web.UI.Page
{
    General gm = new General();  

    general_fn gfn = new general_fn();
    General Obj_Gen = new General();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public string OrganizationID,Type;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Session["userid_Yclid"] != null)
            {

                OrganizationID = Session["OrganizationID"].ToString();
                Type = Session["Type"].ToString();

                if (!Type.Equals("1"))
                {

                    lnkdelete.Visible = false;

                }
                else
                {
                    lnkdelete.Visible = true;                   
                }


                loaddetails();
            }
            else
                Response.Redirect("YCLC_ViewUsers.aspx", false);
        }
    }


    protected void loaddetails()
    {

        DataTable dt = new DataTable();
        dt = FetchData("View");



        if (dt.Rows.Count > 0)
        {
            comptetionrepeater.DataSource = dt;

            comptetionrepeater.DataBind();

        }
        foreach (RepeaterItem item in comptetionrepeater.Items)
        {
            HtmlTableRow tr = (HtmlTableRow)item.FindControl("trsubgroup");
            Label lblsubgroup = (Label)item.FindControl("lblsubgroup");
            if (string.IsNullOrEmpty(lblsubgroup.Text))
            {
                tr.Visible = false;
            }

        }


    }

    protected DataTable FetchData(string type)
    {
        int id = (int.Parse)(Session["yclc_userid"].ToString());
        SqlConnection cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();

        using (cnn)
        {
            SqlCommand viewcommand = new SqlCommand("SP_YCLCompetition", cnn);
            viewcommand.CommandType = CommandType.StoredProcedure;

            viewcommand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "View";
            viewcommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            viewcommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(viewcommand);
            sda.Fill(dt);


            return dt;

        }
    }

    protected void lnkcivil_Command(object sender, CommandEventArgs e)
    {
        download_File(e.CommandArgument.ToString());
    }
    public void download_File(string fName)
    {

        string mypath = Path.Combine("C:/inetpub/wwwroot/Youth.gov.kw/YCLC/Civil/", fName);
        FileInfo fi = new FileInfo(mypath);
        if (fi.Exists)
        {
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = Path.GetExtension(fName);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(mypath)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(mypath);
            Response.End();
        }
    }
    protected void lnlprint_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = FetchData("view");
        RemoveReOrderColumns(dt);
        Session.Add("printDt", dt);
        Response.Redirect("ListPrintGeneral.aspx", false);
    }

    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("صورة البطاقة المدنية");



    }

    protected void lnkChange_Command(object sender, CommandEventArgs e)
    {
        pnl.Visible = true;
        pnlGov.Visible = false;
        BtSave.Focus();
        DataTable dt = GetData("YCLgetGovAndArea", 0, "102");
        if (dt.Rows.Count > 0)
        {
            DDLCatagory.DataSource = dt;
            DDLCatagory.DataTextField = "Category";
            DDLCatagory.DataValueField = "CategoryId";
            DDLCatagory.DataBind();
            DDLCatagory.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        foreach (RepeaterItem item in comptetionrepeater.Items)
        {
            Label lblcategory = (Label)item.FindControl("lblcategory");
            string category = lblcategory.Text;           
           
            DDLCatagory.ClearSelection();
            DDLCatagory.SelectedIndex = DDLCatagory.Items.IndexOf(DDLCatagory.Items.FindByText(category));
           
            DDLCatagory_SelectedIndexChanged(null, null);
        }
    }
    public DataTable GetData(string Command, int Parameter, string TransId)
    {


        con.ConnectionString = Obj_Gen.ConnectionString();
        con.Open();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = Command;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@transid", TransId);
        if (Parameter != 0)
        {
            cmd.Parameters.AddWithValue("@govid", Parameter);
        }
        else { DDLArea.Items.Insert(0, new ListItem("--اختر--", "0")); };
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;

    }
    private void LoadAreaByGovID()
    {
        int govid = Convert.ToInt32(DDlGovernarate.SelectedItem.Value);
        DataTable dt = GetData("YCLgetGovAndArea", govid, "100");
        if (dt.Rows.Count > 0)
        {
            DDLArea.Enabled = true;
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "id";
            DDLArea.DataBind();
        }
        else
        {
            DDLArea.ClearSelection();
            DDLArea.Items.Clear();
            DDLArea.Enabled = false;
        }
        DDLArea.Items.Insert(0, new ListItem("--اختر--", "0"));
    }
    protected void DDlGovernarate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLArea.Enabled = true;   

        pnlAREA.Visible = true;
        if (DDlGovernarate.SelectedItem.Value != "0")
        {
            LoadAreaByGovID();
        }
        else
        {
            DDLArea.ClearSelection();
            DDLArea.Items.Clear();
            DDLArea.Items.Insert(0, new ListItem("--اختر--", "0"));
            DDLArea.Enabled = false;
        }
    }

    protected int age(string civil)
    {
        string dob = gfn.DobFromCivil(civil);
        string[] Arrdob = dob.Split('~');
        String DOB = Arrdob[1];

        int year = Convert.ToInt32(DateTime.Now.Year);

        int years = DateTime.Now.Year - DateTime.Parse(DOB).Year;

        int month = DateTime.Parse(DOB).Month;
        int day = DateTime.Parse(DOB).Day;

        if ((DateTime.Parse(DOB).Month > DateTime.Now.Month) || (DateTime.Parse(DOB).Month == DateTime.Now.Month && DateTime.Parse(DOB).Day > DateTime.Now.Day))
            years--;

        int age = years;

        return age;
    }
    protected void DDLCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSub.Visible = false;
        DDlSubGroup.ClearSelection();
        if (DDLCatagory.SelectedItem.Value.Equals("5"))
        {
            pnlSub.Visible = true;
            DDlSubGroup.ClearSelection();
            DDlSubGroup.Items.Clear();
            DDlSubGroup.Items.Insert(0, new ListItem("", "0"));
            DDlSubGroup.Items.Insert(1, new ListItem("الرسم", "1"));
            DDlSubGroup.Items.Insert(2, new ListItem("الخزف", "2"));

            Label lblcivil = new Label();
            foreach (RepeaterItem item in comptetionrepeater.Items)
            {
                lblcivil = (Label)item.FindControl("lblcivil");                 
                
            }


            int ageval = age(lblcivil.Text.Trim());

            if (ageval >= 7 && ageval <= 10)
            {

                DDlSubGroup.Items.FindByValue("1").Selected = true;

            }
            else if (ageval >= 11 && ageval <= 14)
            {

                DDlSubGroup.Items.FindByValue("1").Selected = true;


            }
            else if (ageval >= 15 && ageval <= 18)
            {

                DDlSubGroup.Items.FindByValue("2").Selected = true;

            }


        }

    }
    protected void BtSave_Click(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] != null)
        {
            foreach (RepeaterItem item in comptetionrepeater.Items)
            {

                HiddenField hdid = (HiddenField)item.FindControl("hdid");


                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();
                cnn.Open();
                SqlCommand viewcommand = new SqlCommand("SP_YCLCompetitionUpdation", cnn);
                viewcommand.CommandType = CommandType.StoredProcedure;

                viewcommand.Parameters.AddWithValue("@type", SqlDbType.Int).Value = "category";
                viewcommand.Parameters.AddWithValue("@category", SqlDbType.NVarChar).Value = DDLCatagory.SelectedValue;
                viewcommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = hdid.Value;
                viewcommand.Parameters.AddWithValue("@subcategory", SqlDbType.NVarChar).Value = (DDLCatagory.SelectedValue == "5" ? DDlSubGroup.SelectedItem.Text : "");
                viewcommand.Parameters.AddWithValue("@adminid", SqlDbType.Int).Value = Session["userid_Yclid"].ToString();
                viewcommand.ExecuteNonQuery();
                cnn.Close();
            }
            loaddetails();
            pnl.Visible = false;
            successAdmin.Visible = true;
        }
        else
        {
            Response.Redirect("YCLC_ViewUsers.aspx", false);
        }
    }
    protected void lnkdelete_Command(object sender, CommandEventArgs e)
    {

    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] != null)
        {
            foreach (RepeaterItem item in comptetionrepeater.Items)
            {

                HiddenField hdid = (HiddenField)item.FindControl("hdid");
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();
                cnn.Open();
                SqlCommand viewcommand = new SqlCommand("SP_YCLCompetitionUpdation", cnn);
                viewcommand.CommandType = CommandType.StoredProcedure;

                viewcommand.Parameters.AddWithValue("@type", SqlDbType.Int).Value = "delete";
                viewcommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = hdid.Value;

                viewcommand.ExecuteNonQuery();
                cnn.Close();
            }
        }
        else
        {
            Response.Redirect("YCLC_ViewUsers.aspx", false);
        }
    }
    protected void lnkGov_Command(object sender, CommandEventArgs e)
    {
        pnl.Visible = false;
        pnlGov.Visible = true;
        Btgov.Focus();
        DataTable dt = GetData("YCLgetGovAndArea", 0, "100");
        if (dt.Rows.Count > 0)
        {
            DDlGovernarate.DataSource = dt;
            DDlGovernarate.DataTextField = "GovName";
            DDlGovernarate.DataValueField = "Id";
            DDlGovernarate.DataBind();
            DDlGovernarate.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
        foreach (RepeaterItem item in comptetionrepeater.Items)
        {
            Label lblcategory = (Label)item.FindControl("lblgove");
            string category = lblcategory.Text;

            DDlGovernarate.ClearSelection();
            DDlGovernarate.SelectedIndex = DDlGovernarate.Items.IndexOf(DDlGovernarate.Items.FindByText(category));

          //  DDlGovernarate_SelectedIndexChanged(null, null);
        }

    }
    protected void Btgov_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in comptetionrepeater.Items)
        {

            HiddenField hdid = (HiddenField)item.FindControl("hdid");


            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            SqlCommand viewcommand = new SqlCommand("SP_YCLCompetitionUpdation", cnn);
            viewcommand.CommandType = CommandType.StoredProcedure;

            viewcommand.Parameters.AddWithValue("@type", SqlDbType.Int).Value = "Gov";
            viewcommand.Parameters.AddWithValue("@gov", SqlDbType.NVarChar).Value = DDlGovernarate.SelectedValue;
            viewcommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = hdid.Value;
            viewcommand.Parameters.AddWithValue("@area", SqlDbType.NVarChar).Value = DDLArea.SelectedValue;
            viewcommand.ExecuteNonQuery();
            cnn.Close();
        }
        loaddetails();
        pnlGov.Visible = false;
        successAdmin.Visible = true;
    }

    protected void comptetionrepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlTableRow trChanges = e.Item.FindControl("trChanges") as HtmlTableRow;
            LinkButton lnkChange = e.Item.FindControl("lnkChange") as LinkButton;
            LinkButton lnkGov = e.Item.FindControl("lnkGov") as LinkButton;

            //if (Session["OrganizationID"].ToString() == "1")
            if (Session["Type"].ToString() == "1")
            {
                trChanges.Visible = true;
                lnkChange.Visible = true;
                lnkGov.Visible = true;
            }
            else
            {
                trChanges.Visible = false;
                lnkChange.Visible = false;
                lnkGov.Visible = false;
            }
        }
    }
}