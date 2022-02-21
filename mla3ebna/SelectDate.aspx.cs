using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mla3ebna_SelectDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkGetStadiumData_Click(object sender, EventArgs e)
    {
       
        string date = hiddenDate1.Value.ToString();

      
           Session["std"] = date ;
           Response.Redirect("SearchStadium.aspx", false);

    
    }
}