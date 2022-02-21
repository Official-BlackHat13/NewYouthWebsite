using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    string dt = hiddenDate1.Value.ToString();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserUID"] == null)
        {
            lnkLogin.Text = "تسجيل الدخول";
            lnkReg.Text = "إنشاء حساب";
            lblName.Text = "";
        }
        else
        {
            lnkLogin.Text = "تسجيل الخروج";
            lnkReg.Text = "مرحبا بكم  ";
            if (Session["UserName"] != null)
            {
                lblName.Text = Session["UserName"].ToString();
            }


        }
    }

   
    protected void lnkReg_Click(object sender, EventArgs e)
    {
        if (Session["UserUID"] == null)
        {
            Response.Redirect("Register.aspx", false);
        }
        else
        {
            Response.Redirect("UserProfile.aspx", false);
        }
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        if (Session["UserUID"] == null)
        {
            Response.Redirect("Login.aspx", false);
        }
        else
        {
            Session.Abandon();
            Response.Redirect("index.aspx", false);
        }
    }

    protected void lnkGetStadiumData1_Click(object sender, EventArgs e)
    {
        //string date = hiddenDate1.Value.ToString();

      
        //   Session["std"] = date ;
        //   Response.Redirect("SearchStadium.aspx", false);

    }

    protected void lnkModelDate_Click(object sender, EventArgs e)
    {
        //DataTable dt = fn_CheckWholeSiteBlock(hiddenDate1.Value.ToString());
        //DataColumnCollection columns = dt.Columns;


        //if (dt.Rows[0]["Error"].ToString() == "False")
        //{
        //    Response.Redirect("SiteBlock.aspx?msg=" + dt.Rows[0]["DisplayMsg"].ToString(), false);
        //}
        //else
        //{
        //    string date = hiddenDate1.Value.ToString();


        //    Session["std"] = date;

        //    Response.Redirect("SearchStadium.aspx", false);
        //}


    }


    public DataTable fn_CheckWholeSiteBlock(string ld_data)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        
        DataInsertReturn dtr = new DataInsertReturn();

        try
        {
            string str_date = "";
            if (ld_data != "")
            {
                DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                str_date = temp.ToString("yyyy-MM-dd");
            }

            DS = clsGeneral.GetDS("select  DisplayMsg,convert(varchar,DateFrm, 106) as  DateFrm,  convert(varchar,DateTo, 106) as DateTo,'False' as Error from MYA_Maleabna_TimeSlot_Block where BlockBy='WholeSite' and '" + str_date + "' between DateFrm and DateTo and status=1", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
            }

            return dt;
        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }
        return dt;

    }
}
