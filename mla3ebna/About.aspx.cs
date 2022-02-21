using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class About : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadAbout();
    }

    public void LoadAbout()
    {
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
      
        try
        {           
            //DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=1", GstrDbKey, "Table", true);
           
            //if (DS.Tables[0].Rows.Count == 0)
            //    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            //else
            //{
            //    dt = DS.Tables[0];
            //}
            //DataColumnCollection columns = dt.Columns;
            //if (columns.Contains("PageContent"))
            //{
            //    pAbout.InnerHtml = dt.Rows[0]["PageContent"].ToString();
            //}
            //else
            //{
               
            //}


            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=1", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
            }

            DataColumnCollection columns = dt.Columns;
            if (columns.Contains("PageContent"))
            {


                string str = dt.Rows[0]["PageContent"].ToString().Trim().Replace("\r\n", "</br>");
                str = str.Replace("•", "\u2022 ");
                pAbout.InnerHtml = str;
            }
            else
            {

            }
            
        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);

            pAbout.InnerHtml = dt.Rows[0]["message"].ToString();
        }
        finally
        {

        }

        

    }

    //public void LoadPageContent(string ls_type)
    //{

    //    DataTable dt = new DataTable();
    //    DataSet DS = new DataSet();
        
    //    DataInsertReturn dtr = new DataInsertReturn();

    //    try
    //    {
    //        if (ls_type.Equals("About"))
    //        {
    //            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=1", GstrDbKey, "Table", true);
    //        }
    //        else if (ls_type.Equals("Policy"))
    //        {
    //            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=2", GstrDbKey, "Table", true);
    //        }
    //        else if (ls_type.Equals("Reservation"))
    //        {
    //            DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=3", GstrDbKey, "Table", true);
    //        }
    //        if (DS.Tables[0].Rows.Count == 0)
    //            dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
    //        else
    //        {
    //            dt = DS.Tables[0];
    //        }

    //        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
    //    }
    //    catch (Exception ex)
    //    {
    //        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
    //    }
    //    finally
    //    {

    //    }

    //}
}