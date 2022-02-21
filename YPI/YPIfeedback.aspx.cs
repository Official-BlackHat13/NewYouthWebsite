using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class YPI_YPIfeedback : System.Web.UI.Page
{
    fn_General fn = new fn_General();

    protected void Page_Load(object sender, EventArgs e)
    {
      

        if (Session["userid"] != null)
        {
            if (!this.IsPostBack)
            {
                FillData();
            }
        }
        else
        {
            Session["page"] = "YPIFeedBack_page";
            Response.Redirect("../User/Login.aspx", true);
        }
    }

    protected void FillData(int id = 1)
    {
        string userID = userid();

        DataTable dt = fn.GetDataTableYPI(" exec SP_PI_feedback @userID='" + userID + "',@id=" + id );

        DivFeedback.Visible = true;
        alert.Visible = false;



        if (dt.Rows.Count > 0)
        {
            if (int.Parse(dt.Rows[0]["ID"].ToString()).Equals(0))
            {
                DivFeedback.Visible = false;
                alert.Visible = true;
                lbl1.Text = "لقد قمت بتعبئة الاستبيان من قبل ، شكرا";

            }
            else
            {
                DivFeedback.Visible = true;
                alert.Visible = false;


                rpCategory.DataSource = dt;
                rpCategory.DataBind();

            }


        }
        else
        {
            DivFeedback.Visible = false;
            alert.Visible = true;
            lbl1.Text = "نأسف ، لايمكنك المشاركة في هذا الإستبيان لأنك لم تشارك في الدورة ، وشكرا";

            rpCategory.DataSource = "";
            rpCategory.DataBind();
        }

        

    }

    protected void rpCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            
            
             
            LinkButton lnkSubmit = e.Item.FindControl("lnkSubmit") as LinkButton;
          
            string ID = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ID").ToString());
           
      
            if (ID == "4")
                lnkSubmit.Text = "ارسال";  //submit
            else
                lnkSubmit.Text = "التالي"; //next

            Repeater rp= e.Item.FindControl("rpQuestions") as Repeater;

            DataTable dt = fn.GetDataTableYPI(" exec SP_PI_feedback @category='" + ID + "'");

            if (dt.Rows.Count > 0)
                rp.DataSource = dt;
            else
                rp.DataSource = "";

            rp.DataBind();                

        }
    }

    public string userid()
    {
        general_fn gfn = new general_fn();
        string strUserid = Session["userid"].ToString();
        strUserid = gfn.SessionDecrypt(strUserid, SHA512.Create().ToString());
        strUserid = strUserid.Substring(strUserid.IndexOf("&") + 1);
        return strUserid;
    }  
  
    protected void rpCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "submit")
        {
            if (Session["userid"] != null)
            {
                string userID = userid();
                HiddenField hiddenCategoryID = e.Item.FindControl("hiddenID") as HiddenField;
                TextBox txtComment = e.Item.FindControl("txtComment") as TextBox;

                Repeater rpQuestions = e.Item.FindControl("rpQuestions") as Repeater;

                Submit(rpQuestions, userID, hiddenCategoryID.Value, txtComment.Text);


               
                    if (!string.IsNullOrEmpty(txtComment.Text))
                    {
                        string ls = "@category='" + hiddenCategoryID.Value + "',@userID='" + userID + "'";
                        ls = ls + ",@suggestion = N'" + txtComment.Text + "'";

                        int r = fn.ExecuteDataYPI("exec SP_InsertFeedback " + ls);
                    }



                    int CurrenttblNo = int.Parse(hiddenCategoryID.Value);

                    int nxttblNo = int.Parse(hiddenCategoryID.Value) + 1;

                
                if(!hiddenCategoryID.Value.ToString().Equals("4"))
                    FillData(nxttblNo);
                else
                    Response.Redirect("thankEdit.aspx", false);
            }
        }
    }

    protected void Submit(Repeater rp, string userID, string category, string suggestions)
    {
        if (Session["userid"] != null)
        {
            foreach (RepeaterItem item in rp.Items)
            {
                TextBox txtMark = item.FindControl("txtMark") as TextBox;
                HiddenField hiddenQuestionID = item.FindControl("hiddenQuestionID") as HiddenField;


                string categoryID = category;

                if (!string.IsNullOrEmpty(txtMark.Text))
                {

                    string ls = "@category='" + categoryID + "',@userID='" + userID + "',@questionID='" + hiddenQuestionID.Value + "',@option='" + txtMark.Text + "',@table='" + category + "'";

                    int i = fn.ExecuteDataYPI("exec SP_InsertFeedback " + ls);

                }


            }
        }
        else
            Response.Redirect("../User/Login.aspx", false);


    }

}