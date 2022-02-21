using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YCLC_cp_YCLC_RegisterdAdmin : System.Web.UI.Page
{
    General gm = new General();
    general_fn gfn = new general_fn();
    protected SqlCommand cmd;
    protected SqlConnection cnn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
            loadOrganization();
            DataTable dt = LoadValues("rgall");
            FillData(dt);
        }
    }

    protected void loadOrganization()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_YclcOrganization";
        cmd.Parameters.Clear();


        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        cnn.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDlOrganization.DataSource = ds.Tables[0];
            DDlOrganization.DataValueField = "ID";
            DDlOrganization.DataTextField = "OrganizationName";
            DDlOrganization.DataBind();
            DDlOrganization.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
    }


    protected DataTable LoadValues(string type)
    {      
        cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();



        SqlCommand command = new SqlCommand("SP_YCLCadmin", cnn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
        command.Parameters.AddWithValue("@orgID", SqlDbType.NVarChar).Value = (!DDlOrganization.SelectedValue.Equals("0") ? DDlOrganization.SelectedValue : null);

        command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = (!drpstatus.SelectedValue.Equals("0") ? drpstatus.SelectedItem.Text : null);

      
        command.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = (txtmbl.Text == "" ? null : txtmbl.Text);
       

        command.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(command);
        sda.Fill(dt);
        cnn.Close();

        return dt;
    }

    protected void FillData(DataTable dt)
    {
        competetionGrid.DataSource = dt;
        competetionGrid.DataBind();
    }



    protected void lnlprint_Click(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void DDlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }

    protected void DDLGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }
    protected void txtmbl_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }

    protected void TextEmail_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }

    protected void drpstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }


    protected void btClear_Click(object sender, EventArgs e)
    {

        DDlOrganization.SelectedValue = "0";
     
        txtmbl.Text = "";
        TextEmail.Text = "";
        drpstatus.SelectedValue = "0";


        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }

    
    protected void competetionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            Session["yclc_rid"] = e.CommandArgument.ToString();
            Response.Redirect("YCLC_AddAdmin.aspx", false);
        }
    }
    protected void competetionGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        competetionGrid.PageIndex = e.NewPageIndex;

       
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }
    protected void competetionGrid_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = competetionGrid.BottomPagerRow;
        if (gvr == null)
        {
            return;
        }
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(competetionGrid.PageIndex + 1);
        int[] page = new int[7];
        page[0] = competetionGrid.PageIndex - 2;
        page[1] = competetionGrid.PageIndex - 1;
        page[2] = competetionGrid.PageIndex;
        page[3] = competetionGrid.PageIndex + 1;
        page[4] = competetionGrid.PageIndex + 2;
        page[5] = competetionGrid.PageIndex + 3;
        page[6] = competetionGrid.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > competetionGrid.PageCount)
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Visible = false;
                }
                else
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Text = Convert.ToString(page[i]);
                    lb.CommandName = "PageNo";
                    lb.CommandArgument = lb.Text;
                }
            }
        }
        if (competetionGrid.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (competetionGrid.PageIndex == competetionGrid.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (competetionGrid.PageIndex > competetionGrid.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (competetionGrid.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }

    void lb_Command(object sender, CommandEventArgs e)
    {
        competetionGrid.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        DataTable dt = LoadValues("rgall");
        FillData(dt);
    }

    protected void competetionGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewRow gvr = e.Row;
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p1");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p2");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p4");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p5");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p6");
            lb.Command += new CommandEventHandler(lb_Command);


        }
    }

    protected void competetionGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status"));
        string emailstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmailStatus")); 


        DropDownList ddl = (DropDownList)(e.Row.FindControl("DDLStatus"));         
        LinkButton lnk = (LinkButton)(e.Row.FindControl("lnkadd"));


        if (emailstatus.Equals("1"))
        {
            ddl.Items.Insert(3, new ListItem("Credentials Sent", "3"));
            ddl.Items.FindByText("Credentials Sent").Selected = true;
            ddl.BackColor = System.Drawing.Color.FromArgb(0, 128, 0);
            ddl.Enabled = false;
            lnk.Visible = false;
        }
        else
        {
            if (!string.IsNullOrEmpty(status))
            {
                ddl.Items.FindByText(status).Selected = true;


                if (ddl.SelectedItem.Text == "Active")
                {
                    lnk.Visible = true;
                    ddl.BackColor = System.Drawing.Color.FromArgb(0, 128, 0);
                }
                else if (ddl.SelectedItem.Text == "Pending")
                {
                    lnk.Visible = false;
                    ddl.BackColor = System.Drawing.Color.FromArgb(255, 193, 204);  //System.Drawing.Color.FromArgb(173, 38, 92);
                    ddl.ForeColor = System.Drawing.Color.Black;
                }
                else if (ddl.SelectedItem.Text == "Inactive")
                {
                    lnk.Visible = false;
                    ddl.BackColor = System.Drawing.Color.FromArgb(87, 87, 87);
                }
            }
        }
    }


    
protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
{
    DropDownList chk = (DropDownList)sender;

    GridViewRow gvr = (GridViewRow)chk.NamingContainer;

    LinkButton lnk = ((LinkButton)competetionGrid.Rows[gvr.RowIndex].Cells[0].FindControl("lnkadd"));
    DropDownList ddl = (DropDownList)competetionGrid.Rows[gvr.RowIndex].Cells[0].FindControl("DDLStatus");
    string dstatus = ddl.SelectedItem.Text.ToString();
    int ItemId = Convert.ToInt32(((Label)competetionGrid.Rows[gvr.RowIndex].Cells[0].FindControl("labelID")).Text);

    changeStatus(ItemId, dstatus);

    if (dstatus == "Active")
    {       
        lnk.Visible = true;
        ddl.BackColor = System.Drawing.Color.FromArgb(0, 128, 0);
    }

    else if(dstatus == "Pending")
    {       
        lnk.Visible = false;
        ddl.BackColor = System.Drawing.Color.FromArgb(255, 193, 204); //System.Drawing.Color.FromArgb(173, 38, 92);
        ddl.ForeColor = System.Drawing.Color.Black;
    }

    else if (dstatus == "Inactive")
    {       
        lnk.Visible = false;
        ddl.BackColor = System.Drawing.Color.FromArgb(87, 87, 87);    
    }


    DataTable dt = LoadValues("rgall");
    FillData(dt);


}

protected void changeStatus(int id, string status)
{

    cnn = new SqlConnection();
    cnn.ConnectionString = gm.ConnectionString();

    SqlCommand command = new SqlCommand("SP_YCLCadmin", cnn);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "update";
    command.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = id;
    command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = status;

    try
    {
        cnn.Open();
        command.ExecuteNonQuery();
        cnn.Close();
    }
    catch (Exception ex)
    {
        Response.Write(ex);
    }
}

}