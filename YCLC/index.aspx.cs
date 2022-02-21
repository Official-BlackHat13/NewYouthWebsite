using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YCLC_index : System.Web.UI.Page
{
    General gm = new General();
    SqlConnection con = new SqlConnection();
    SqlCommand command = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {       
       
        if (!Page.IsPostBack)
        {
           // LoadDropDown();
        }
    }

    protected void LoadDropDown()
    {
        con.ConnectionString = gm.ConnectionString();

        command.CommandText = "SP_YclcOrganization";
        command.Connection = con;
        command.CommandType = CommandType.StoredProcedure;
       
        SqlDataAdapter sda = new SqlDataAdapter(command);
        DataSet ds = new DataSet();
        
        try
        {
            con.Open();
            command.ExecuteNonQuery();
            sda.Fill(ds);
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }


        if (ds.Tables.Count > 0)
        {
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DDlOrganization.DataSource = ds.Tables[0];
            //    DDlOrganization.DataValueField = "ID";
            //    DDlOrganization.DataTextField = "OrganizationName";
            //    DDlOrganization.DataBind();

            //    DDlOrganization.Items.Insert(ds.Tables[0].Rows.Count, new ListItem("أخرى", "-1"));
            //    DDlOrganization.Items.Insert(0, new ListItem("--إسم الجهة--", "0"));
                
            //}
        }
    }
    
    protected void LnkSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate("personalInfo");
        if (Page.IsValid)
        {
            con.ConnectionString = gm.ConnectionString();

            command.CommandText = "SP_yclcAdminRegister";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = con;

            command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = TxtName.Text;
            command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
            command.Parameters.AddWithValue("@phone", SqlDbType.NVarChar).Value = TxtPhone.Text;
           // command.Parameters.AddWithValue("@orgid", SqlDbType.NVarChar).Value = DDlOrganization.SelectedValue;
            command.Parameters.AddWithValue("@orgname", SqlDbType.NVarChar).Value = txtOrganization.Text;
            command.Parameters.AddWithValue("@res_val", SqlDbType.Int).Direction = ParameterDirection.Output;
            //command.Parameters.AddWithValue("", SqlDbType.NVarChar).Value = TxtName.Text;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            int ret_val = (int.Parse)(command.Parameters["@res_val"].Value.ToString());
            
            
            TxtName.Text = "";
            txtEmail.Text = "";
            TxtPhone.Text = "";
            DDlOrganization.SelectedValue = "0";
            
            if (ret_val == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEmailExistsModel();", true);
            }
            else
            {               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }

        }
    }
    protected void linkIndividual_Click(object sender, EventArgs e)
    {
        //Session["OrganizationID"] = "1";
       // Response.Redirect("RegisterWeb.aspx", false);
    }
    protected void lnkJoinSubmit_Click(object sender, EventArgs e)
    {
        
        string jointype = ddlJoinType.SelectedValue.ToString();
        if (jointype.Equals("2") || jointype.Equals("1"))
        {


            Session["yclcJoinType"] = jointype;
            Response.Redirect("RegisterWeb.aspx", false);
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openJoinTypeModel();", true);
        }

    }
}