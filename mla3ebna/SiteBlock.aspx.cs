using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mubaratna2021_SiteBlock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string message = Request.QueryString["msg"];

    
       DisplayMessage(message);
    }

    protected void DisplayMessage(string msg)
    {
        DivStadium1.InnerHtml = msg;
    }
}