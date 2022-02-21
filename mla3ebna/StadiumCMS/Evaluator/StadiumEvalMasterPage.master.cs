using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_StadiumEvalMasterPage : System.Web.UI.MasterPage
{
    public string strMenu, strMobileMenu;
    protected void Page_Load(object sender, EventArgs e)
    {
        EvalCurrentUser.CheckLoggedIn();


        lblMobileMessage.Text = Session["MaleabnaEvalUserName"].ToString();
        lblTopMessage.Text = "Welcome " + Session["MaleabnaEvalUserName"].ToString();

        labUserFullNameLeft.Text = Session["MaleabnaEvalUserName"].ToString();

        labUserFullNameLeftPopup.Text = Session["MaleabnaEvalUserName"].ToString();

        fillMobileMenu();

        fillMenu();
    }

    private void fillMobileMenu()
    {

        //strMobileMenu = strMobileMenu + "<li class=''><a href='Eval_Stadium.aspx'><div class='icon-w'><div class='fa fa-home'></div></div><span>الرئيسية</span></a></li>";

        //if (Session["MaleabnaCMSUsersMenu"].ToString() == "True")
        //{
        //    strMobileMenu = strMobileMenu + "<li class='has-sub-menu'> <a href='Manage_AppUsers'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div></div>";
        //    strMobileMenu = strMobileMenu + " <span>فريق العمل</span></a>";
        //    strMobileMenu = strMobileMenu + " <ul class='sub-menu'>";

        //    strMobileMenu = strMobileMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
        //    strMobileMenu = strMobileMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";
        //}

        //strMobileMenu = strMobileMenu + " </ul>";
        //strMobileMenu = strMobileMenu + " </li>";
      

      
    }

    private void fillMenu()
    {

        #region AdminMenu
        if (HttpContext.Current.Session["MaleabnaEvalUserType"].ToString() == "Admin")
        {
            if (Request.Url.ToString().IndexOf("Manage_EvalStadium.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_EvalStadium.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_EvalStadium.aspx'><div class='icon-w'><div class='fa fa-futbol-o'></div> </div><span> View Stadium</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_EvalStadium.aspx'><div class='icon-w'><div class='fa fa-futbol-o'></div> </div><span> View Stadium</span></a> </li>";
            }




            if (Request.Url.ToString().IndexOf("Manage_EvalUsers.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_EvalUsers.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_EvalUsers.aspx'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div> </div><span> View Users</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_EvalUsers.aspx'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div> </div><span> View Users</span></a> </li>";
            }



            if (Request.Url.ToString().IndexOf("Manage_Print.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Print.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_Print.aspx'><div class='icon-w'><div class='fa fa-print'></div> </div><span> Print Evaluation </span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_Print.aspx'><div class='icon-w'><div class='fa fa-print'></div> </div><span> print Evaluation  </span></a> </li>";
            }

        }

        

        #endregion



        #region UserMenu

        if (HttpContext.Current.Session["MaleabnaEvalUserType"].ToString() == "User")
        {
            if (Request.Url.ToString().IndexOf("Eval_Stadium.aspx") != -1 | Request.Url.ToString().IndexOf("Eval_Stadium.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Eval_Stadium.aspx'><div class='icon-w'><div class='fa fa-futbol-o'></div> </div><span> Evaluate Stadium </span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Eval_Stadium.aspx'><div class='icon-w'><div class='fa fa-futbol-o'></div> </div><span>  Evaluate Stadium </span></a> </li>";
            }


            if (Request.Url.ToString().IndexOf("Manage_Print.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Print.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_Print.aspx'><div class='icon-w'><div class='fa fa-print'></div> </div><span> Print Evaluation </span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_Print.aspx'><div class='icon-w'><div class='fa fa-print'></div> </div><span> print Evaluation  </span></a> </li>";
            }

            //if (!string.IsNullOrEmpty(Session["StadiumEvalID"].ToString()))
            //{
            //    string StadiumEvalID = Session["StadiumEvalID"].ToString();
            //    if (Request.Url.ToString().IndexOf("Manage_EvalStadium.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_EvalStadium.aspx") != -1)
            //    {
            //        strMenu = strMenu + " <li class='selected'><a href='Print_EvalStadium.aspx?StadiumEvalID=" + StadiumEvalID + "'><div class='icon-w'><div class='fa fa-print'></div> </div><span> Print Evaluation </span></a> </li>";

            //    }
            //    else
            //    {
            //        strMenu = strMenu + " <li class='selected'><a href='Print_EvalStadium.aspx?StadiumEvalID=" + StadiumEvalID + "'><div class='icon-w'><div class='fa fa-print'></div> </div><span> Print Evaluation </span></a> </li>";

            //    }
            //}

        }

        #endregion



       
    }
}
