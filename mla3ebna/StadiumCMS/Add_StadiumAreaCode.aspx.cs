using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class mla3ebna_StadiumCMS_Add_StadiumAreaCode : System.Web.UI.Page
{

    General gm = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSCurrentUser.CheckLoggedIn();
        if (!this.IsPostBack)
        {

            FillGovernorate();
            
        }

    }

    protected void FillGovernorate()
    {
            
       
        SqlConnection cnn = new SqlConnection(dbFunctions.ConnectionString);
        DataTable dt;
        dt = dbFunctions.GetData("exec SP_get_StadiumAreacode @type='selgov'");

         if (dt.Rows.Count > 0)
        {
            DDLGov.DataSource = dt;
            DDLGov.DataTextField = "GovernorateName";
            DDLGov.DataValueField = "GovernorateID";
            DDLGov.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLGov.Items.Insert(0, new ListItem("--Select--", "0"));
                DDLGov.Enabled = true;
            }

            else
            {
                DDLGov.Enabled = false;
            }

        }


    }



    protected void DDLGov_SelectedIndexChanged(object sender, EventArgs e)
    {

               
            SqlConnection cnn = new SqlConnection(dbFunctions.ConnectionString);
            DataTable dt;
            dt = dbFunctions.GetData("exec SP_get_StadiumAreacode @type='selArea', @Govid='"+ (DDLGov.SelectedValue == "0" ? "" : DDLGov.SelectedValue) +"'");
        
            if (dt.Rows.Count > 0)
            {
                DDLArea.DataSource = dt;
                DDLArea.DataTextField = "AreaName";
                DDLArea.DataValueField = "AreaID";
                DDLArea.DataBind();

                if (dt.Rows.Count > 1)
                {
                    DDLArea.Items.Insert(0, new ListItem("--Select--", "0"));
                    DDLArea.Enabled = true;
                }

                else
                {
                    DDLArea.Enabled = false;
                }

            }
        
    }


    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SqlConnection cnn = new SqlConnection(dbFunctions.ConnectionString);
        DataTable dt;
        dt = dbFunctions.GetData("exec SP_get_StadiumAreacode @type='selstadium',@Aid ='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "'");
     
        if (dt.Rows.Count > 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";
            DDLStadium.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLStadium.Items.Insert(0, new ListItem("--Select--", "0"));
                DDLStadium.Enabled = true;
            }

            else
            {
                DDLStadium.Enabled = false;
            }

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        Page.Validate("report1");
        {
            SqlConnection cnn = new SqlConnection(dbFunctions.ConnectionString);
            cnn.Open();
            string query = "SP_Add_StadimCode";
            SqlCommand cmd = new SqlCommand(query, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Govid", SqlDbType.Int).Value = DDLGov.SelectedValue;
                cmd.Parameters.AddWithValue("@Areaid ", SqlDbType.Int).Value = DDLArea.SelectedValue;
                cmd.Parameters.AddWithValue("@Stadium", SqlDbType.Int).Value = DDLStadium.SelectedValue;
                //cmd.Parameters.AddWithValue("@Jamiya", SqlDbType.Int).Value = txtjamiya.Text;
               // cmd.Parameters.AddWithValue("@IBAN ", SqlDbType.Int).Value = txtIBANno.Text;
                cmd.Parameters.AddWithValue("@Acode ", SqlDbType.NVarChar).Value = txtAreacode.Text;
                cmd.Parameters.AddWithValue("@stcode ", SqlDbType.NVarChar).Value = txtStadiumcode.Text;
               // cmd.Parameters.AddWithValue("@StadiumName ", SqlDbType.NVarChar).Value = DDLStadium.SelectedItem.Text;
               // cmd.Parameters.AddWithValue("@date ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.ExecuteNonQuery();
                cnn.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Successfully added !!!');</script>", false);
                
                //DDLGov.Items.Clear();
                //DDLArea.Items.Clear();
                //DDLStadium.Items.Clear();
                ////txtjamiya.Text = "";
                ////txtIBANno.Text = "";
                //txtAreacode.Text = "";
                //txtStadiumcode.Text = "";
            }


            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }

    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(dbFunctions.ConnectionString);
        DataTable dt;
        dt = dbFunctions.GetData("exec SP_get_StadiumAreacode @type='get',@stadiumID ='" + DDLStadium.SelectedValue + "'");

        if (dt.Rows.Count > 0)
        {
            txtAreacode.Text = dt.Rows[0]["AreaCode"].ToString();
            txtStadiumcode.Text = dt.Rows[0]["StadiumCode"].ToString();

        }
        else
        {
            txtAreacode.Text = "";
            txtStadiumcode.Text = "";
        }
    }
}
