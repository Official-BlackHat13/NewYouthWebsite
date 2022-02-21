using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_ContactUs : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();
           


           // lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";

            fillData();
        }
    }
    private void fillData()
    {
        string cmd;
        DataTable dt;


        str = "";

       
        if (TxtDate.Text != "")
        {
            str = str + "cast(CreatedAt as date) = '"+ TxtDate.Text +"'";
        }

        if (Txtemail.Text != "")
        {
            str = str + ",Email like N'%" + Txtemail.Text + "%' ";
        }

        arr = str.Split(',');

        if (str != "")
        {
            str = " where ";
        }
        for (var i = 0; i < arr.Length; i++)
        {
            if (i > 1)
            {
                str = str + " and ";
            }
            str = str + (arr[i]);

        }


        cmd = "select * from MYA_Maleabna_ContactUs" + str + " order by ContactId desc";

        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            GVData.DataSource = dt;
            GVData.DataBind();
            lnkDelete.Visible = false;
            GVData.Visible = true;
        }
        else
        {
            lnkDelete.Visible = false;
            GVData.Visible = false;
        }


        lblCount.Text = dt.Rows.Count + " record(s)";
    }


    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }



    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }
    public void lnkSearch_Click(object sender, EventArgs e)
    {
       // GVData.PageIndex = 0;
        fillData();
    }

    protected void lnkClear_Click(object sender, EventArgs e)
    {
        TxtDate.Text = "";
        Txtemail.Text = "";
        //GVData.PageIndex = 0;
        fillData();
    }
   
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {  

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView dr = (DataRowView)e.Row.DataItem;
            string status = dr["Status"].ToString();

            

            HtmlAnchor aRef = (HtmlAnchor)e.Row.FindControl("aRef");
            if (status == "1")
            {
                string email = dr["Email"].ToString();
                string contactId = dr["ContactId"].ToString();
                aRef.Title="Sending Reply";
                aRef.HRef = "ContactUs_Reply.aspx?ContactId=" + contactId + "&UserEmail=" + email;
                aRef.Attributes.Add("class", "mr-2 mb-2 btn btn-outline-success btn-sm fancybox fancybox.iframe");
            }
            else if (status == "0")
            {
                aRef.HRef = " ";
                aRef.Title = "Already Sent Reply";
                aRef.Attributes.Add("class", "mr-2 mb-2 btn btn-outline-info btn-sm");
            }

        }


    }
}