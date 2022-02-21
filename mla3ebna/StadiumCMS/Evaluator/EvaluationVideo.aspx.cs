using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_EvaluationVideo : System.Web.UI.Page
{
    dbFunctions dbfunctions = new dbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EvalCurrentUser.CheckLoggedIn();

          //  HDStadiumID.Value = Session["MaleabnaEvalStadiumID"].ToString();
          

        }
    }
    protected void videoSubmit_Click(object sender, EventArgs e)
    {
        string video = string.Empty;
        string AdminID = Session["MaleabnaEvalUserID"].ToString();
        if (fpuploadvideo.FileContent.Length > 0)
        {
            string ext = Path.GetExtension(fpuploadvideo.PostedFile.FileName);
            video = AdminID + "_Videos_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;

            fpuploadvideo.PostedFile.SaveAs(Server.MapPath("../Evaluator/Video/" + video));

            //
            int i = dbFunctions.GetSingleRecord("exec SP_MYA_Maleabna_Evaluate_EvaluateVideo @userid = " + AdminID + ",@fpvideo='" + video + "'");

            if (!i.Equals(0) || !i.Equals(999))
            {
                Session["MaleabnaEvalVideoID"] = i;

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Uploaded Successfully!!!');", true);

            }

        }
    }

      
}