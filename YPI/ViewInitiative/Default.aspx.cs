using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_Default : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    public string StrInitiativetr, StrInstitutionID, StrBusinessNurseryID, StrUserGroupID, StrMYAAllStage, StrMYAStage1, StrMYAStage2, StrMYAStage3, StrMYAStage4, StrMYAStage5, StrMYAStage6, StrMYAStage7, StrBNAllStage, StrBNStage1, StrBNStage2, StrBNStage3, StrBNStage4;
    protected void Page_Load(object sender, EventArgs e)
    {

             

        ViewInitiativeAppCurrentUser.CheckLoggedIn();

      

        PanMainDashboard.Visible = false;

        PanMYAInitiativeStatistics.Visible = false;

        PanBusinessNurseryInitiativeStatistics.Visible = false;

        PanMYAStage1.Visible = false;

        PanMYAStage2.Visible = false;

        PanMYAStage3.Visible = false;

        PanMYAStage4.Visible = false;

        PanMYAStage5.Visible = false;

        PanMYAStage6.Visible = false;

        PanMYAStage7.Visible = false;


        StrUserGroupID = Session["MYAPIVIAppUserGroupID"].ToString();    

        StrInstitutionID = Session["MYAPIVIAppInstitution"].ToString();   

        StrBusinessNurseryID = Session["MYAPIVIAppBusinessNurseryID"].ToString();




        StrMYAAllStage= Session["MYAPIVIAppMYAAllStage"].ToString();

        StrMYAStage1 = Session["MYAPIVIAppMYAStage1"].ToString();

        StrMYAStage2 = Session["MYAPIVIAppMYAStage2"].ToString();

        StrMYAStage3 = Session["MYAPIVIAppMYAStage3"].ToString();

        StrMYAStage4 = Session["MYAPIVIAppMYAStage4"].ToString();

        StrMYAStage5 = Session["MYAPIVIAppMYAStage5"].ToString();

        StrMYAStage6 = Session["MYAPIVIAppMYAStage6"].ToString();

        StrMYAStage7 = Session["MYAPIVIAppMYAStage7"].ToString();


        StrBNAllStage = Session["MYAPIVIAppBNAllStage"].ToString();

        StrBNStage1 = Session["MYAPIVIAppBNStage1"].ToString();

        StrBNStage2 = Session["MYAPIVIAppBNStage2"].ToString();

        StrBNStage3 = Session["MYAPIVIAppBNStage3"].ToString();

        StrBNStage4 = Session["MYAPIVIAppBNStage4"].ToString();

        //Response.Write(StrInstitutionID + "-" + StrMYAAllStage + "-" + StrMYAStage1 + "-" + StrMYAStage2 + "-" + StrMYAStage3 + "-" + StrBNAllStage + "-" + StrBNStage1 + "-" + StrBNStage2 + "-" + StrBNStage3 + "-" + StrBNStage4 + "-");

        if (StrUserGroupID == "1")
        {
            PanMainDashboard.Visible = true;

            PanMYAInitiativeStatistics.Visible = true;

            PanMYAStage1.Visible = true;

            PanMYAStage2.Visible = true;

            PanMYAStage3.Visible = true;

            PanMYAStage4.Visible = true;

            PanMYAStage5.Visible = true;

            PanMYAStage6.Visible = true;

            PanMYAStage7.Visible = true;

        }
        else
        {
            if (StrInstitutionID == "1" && StrMYAAllStage == "True")
            {
                PanMainDashboard.Visible = true;
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage1.Visible = true;

                PanMYAStage2.Visible = true;

                PanMYAStage3.Visible = true;

                PanMYAStage4.Visible = true;

                PanMYAStage5.Visible = true;

                PanMYAStage6.Visible = true;

                PanMYAStage7.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage1 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage1.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage2 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage2.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage3 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage3.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage4 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage4.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage5 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage5.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage6 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage6.Visible = true;
            }

            if (StrInstitutionID == "1" && StrMYAStage7 == "True")
            {
                PanMYAInitiativeStatistics.Visible = true;
                PanMYAStage7.Visible = true;
            }

            if (StrInstitutionID == "2" )
            {
                PanBusinessNurseryInitiativeStatistics.Visible = false;
            }
        }




       
        

        FillInitiativeByStatus();

        FillInitiativeByStatusOfMYA();

        FillLatestInitiative();
        //PanOtherInitiativeStatistics.Visible = false;
    }

    private void FillInitiativeByStatus()
    {
        string cmd;
        DataTable dt;

        cmd = "select count(id) as TotalInitiative from MYA_PI_Initiative";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["TotalInitiative"]))
                labTotalInitiative.Text = dt.Rows[0]["TotalInitiative"].ToString();

        }

        

        cmd = "select count(id) as TotalInitiativeActive from MYA_PI_Initiative where Status Not IN(8,9)";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["TotalInitiativeActive"]))
                labTotalInitiativeActive.Text = dt.Rows[0]["TotalInitiativeActive"].ToString();

        }


        


        cmd = "select count(id) as TotalInitiativeCompleted from MYA_PI_Initiative where Status=8";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["TotalInitiativeCompleted"]))
                labTotalInitiativeCompleted.Text = dt.Rows[0]["TotalInitiativeCompleted"].ToString();

        }


        cmd = "select count(id) as TotalInitiativeCancelled from MYA_PI_Initiative where Status=9";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["TotalInitiativeCancelled"]))
                labTotalInitiativeCancelled.Text = dt.Rows[0]["TotalInitiativeCancelled"].ToString();

        }
    }

    private void FillInitiativeByStatusOfMYA()
    {

        string cmd;
        DataTable dt;


        cmd = "select count(id) as MYAStatisticsInitiativeStage1 from MYA_PI_Initiative where InstitutionID=1 and Stage=1 and Status!=4";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage1"]))
                labMYAStatisticsInitiativeStage1.Text = dt.Rows[0]["MYAStatisticsInitiativeStage1"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage2 from MYA_PI_Initiative where InstitutionID=1 and Stage=2 and Status!=4";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage2"]))
                labMYAStatisticsInitiativeStage2.Text = dt.Rows[0]["MYAStatisticsInitiativeStage2"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage3 from MYA_PI_Initiative where InstitutionID=1 and Stage=3 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage3"]))
                labMYAStatisticsInitiativeStage3.Text = dt.Rows[0]["MYAStatisticsInitiativeStage3"].ToString();

        }


        cmd = "select count(id) as MYAStatisticsInitiativeStage4 from MYA_PI_Initiative where InstitutionID=1 and Stage=4 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage4"]))
                labMYAStatisticsInitiativeStage4.Text = dt.Rows[0]["MYAStatisticsInitiativeStage4"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage5 from MYA_PI_Initiative where  Stage=5 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage5"]))
                labMYAStatisticsInitiativeStage5.Text = dt.Rows[0]["MYAStatisticsInitiativeStage5"].ToString();

        }


        cmd = "select count(id) as MYAStatisticsInitiativeStage6 from MYA_PI_Initiative where Stage=6 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage6"]))
                labMYAStatisticsInitiativeStage6.Text = dt.Rows[0]["MYAStatisticsInitiativeStage6"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage7 from MYA_PI_Initiative where  Stage=7 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage7"]))
                labMYAStatisticsInitiativeStage7.Text = dt.Rows[0]["MYAStatisticsInitiativeStage7"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage8 from MYA_PI_Initiative where  Stage=8 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage8"]))
                labMYAStatisticsInitiativeStage8.Text = dt.Rows[0]["MYAStatisticsInitiativeStage8"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeStage9 from MYA_PI_Initiative where  Stage=9 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeStage9"]))
                labMYAStatisticsInitiativeStage9.Text = dt.Rows[0]["MYAStatisticsInitiativeStage9"].ToString();

        }

       

    }

    private void FillInitiativeByStatusOfOther()
    {

        string cmd;
        DataTable dt;


        cmd = "select count(id) as MYAStatisticsInitiativeAssigned from MYA_PI_Initiative where InstitutionID=2 ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeAssigned"]))
                labOtherStatisticsInitiativeAssigned.Text = dt.Rows[0]["MYAStatisticsInitiativeAssigned"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeCompleted from MYA_PI_Initiative where InstitutionID=2 and Status=5";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeCompleted"]))
                labOtherStatisticsInitiativeCompleted.Text = dt.Rows[0]["MYAStatisticsInitiativeCompleted"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativeActive from MYA_PI_Initiative where InstitutionID=2 and Status=2";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeActive"]))
                labOtherStatisticsInitiativeActive.Text = dt.Rows[0]["MYAStatisticsInitiativeActive"].ToString();

        }

        cmd = "select count(id) as MYAStatisticsInitiativePending from MYA_PI_Initiative where InstitutionID=2 and Status=3";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativePending"]))
                labOtherStatisticsInitiativePending.Text = dt.Rows[0]["MYAStatisticsInitiativePending"].ToString();

        }


        cmd = "select count(id) as MYAStatisticsInitiativeCancelled from MYA_PI_Initiative where InstitutionID=2 and Status=4";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            //if (!DBNull.Value.Equals(dt.Rows[0]["MYAStatisticsInitiativeCancelled"]))
               // labOtherStatisticsInitiativeCancelled.Text = dt.Rows[0]["MYAStatisticsInitiativeCancelled"].ToString();

        }

    }

    private void FillLatestInitiative()
    {
        string cmd = "";
        DataTable dt;

        String StrStageIDOr = "";

        int stagecounter=0;

        bool StageStart = false;

        str = "";

        //if (StrInstitutionID == "1")
        //{
        //    str = str + ",InstitutionID=" + StrInstitutionID + " ";
        //}

        if (StrInstitutionID == "2")
        {
            str = str + "|InstitutionID=" + StrInstitutionID + " or Status=5 ";

            
        }


            if (StrMYAAllStage == "False" && StrBNAllStage == "False")
        {

            if (StrInstitutionID == "1")
            {
                str = str + "|InstitutionID in (0,1) ";
            }
            else { str = str + "|InstitutionID=" + StrInstitutionID + " "; }

           // str = str + ",InstitutionID=" + StrInstitutionID + " ";

            if (StrMYAStage1 == "True")
            {
                StageStart = true;
                //stagecounter = stagecounter + 1;
                StrStageIDOr = StrStageIDOr + "Stage=0 or Stage=1";
            }

            if (StrMYAStage2 == "True")
            {
                if (StageStart = true)
                {
                    StrStageIDOr = StrStageIDOr + "or Stage=2 ";
                }
                else
                {
                    StageStart = true;
                    StrStageIDOr = StrStageIDOr + "Stage=2 ";
                }

               // stagecounter = stagecounter + 1;
               
            }
            if (StrMYAStage3 == "True")
            {
                if (StageStart = true)
                {
                    StrStageIDOr = StrStageIDOr + "or Stage=3 ";
                }
                else
                {
                    StageStart = true;
                    StrStageIDOr = StrStageIDOr + "Stage=3 ";
                }

            }
            //Response.Write(stagecounter);



            //if (StrBNStage1 == "True")
            //{
            //    if (StageStart = true)
            //    {
            //        StrStageIDOr = StrStageIDOr + "or Stage=4 ";
            //    }
            //    else
            //    {
            //        StageStart = true;
            //        StrStageIDOr = StrStageIDOr + "Stage=4 ";
            //    }
            //}

            //if (StrBNStage2 == "True")
            //{
            //    if (StageStart = true)
            //    {
            //        StrStageIDOr = StrStageIDOr + "or Stage=5 ";
            //    }
            //    else
            //    {
            //        StageStart = true;
            //        StrStageIDOr = StrStageIDOr + "Stage=5 ";
            //    }
            //}

            //if (StrBNStage3 == "True")
            //{
            //    if (StageStart = true)
            //    {
            //        StrStageIDOr = StrStageIDOr + "or Stage=6 ";
            //    }
            //    else
            //    {
            //        StageStart = true;
            //        StrStageIDOr = StrStageIDOr + "Stage=6 ";
            //    }
            //}

            //if (StrBNStage4 == "True")
            //{
            //    if (StageStart = true)
            //    {
            //        StrStageIDOr = StrStageIDOr + "or Stage=7 ";
            //    }
            //    else
            //    {
            //        StageStart = true;
            //        StrStageIDOr = StrStageIDOr + "Stage=7 ";
            //    }
            //}


            str = str + "|" + StrStageIDOr + " ";
        }


        arr = str.Split('|');

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


        cmd = "select top 10 * from [V_AllInitiative]" + str + " order by id desc";


       

        //Response.Write(cmd);
        //// cmd = "select top 10 * from V_AllInitiative order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrInitiativetr = StrInitiativetr + "<tr>";
                StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + dt.Rows[i1]["InitiativeNo"] + "</td>";
                StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + dt.Rows[i1]["InitiativeName"] + "</td>";
                StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + GetUserInfo(dt.Rows[i1]["UID"].ToString()) + "</td>";
                //StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + dt.Rows[i]["Mobile"] + "</td>";

                StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + GetStatusName(dt.Rows[i1]["Status"].ToString()) + "</td>";
                StrInitiativetr = StrInitiativetr + "<td class='text-center'>" + GetPhaseDetails(dt.Rows[i1]["id"].ToString()) + "</td>";
                StrInitiativetr = StrInitiativetr + "<td class='text-center'><a href='View_ViewInitiativeDetails.aspx?InitiativeID=" + dt.Rows[i1]["id"] + "' class='mr-2 mb-2 btn btn-outline-success btn-sm'><i class='fa fa-eye' aria-hidden='true'></i></a><br><a href='javascript:void(0);' onclick='openWinPrint(" + dt.Rows[i1]["id"] + ")' class='mr-2 mb-2 btn btn-outline-primary btn-sm'><i class='fa fa-print' aria-hidden='true'></i></a></td>";
                StrInitiativetr = StrInitiativetr + "</tr>";
            }
        }

    }

    public string GetPhaseDetails(string s)
    {
        string cmd, strresult, strInstitution,StrStage;
        DataTable dt;

        strresult = "";
        strInstitution = "";
        StrStage = "";

        cmd = "select * from [V_AllInitiative]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["InstitutionID"]))
            {
                if (dt.Rows[0]["InstitutionID"].ToString() == "1")
                {
                    strInstitution = "<b> مكتب وزير الدولة لشئون الشباب </b>";
                }
                else if (dt.Rows[0]["InstitutionID"].ToString() == "2")
                {
                    if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNurseryID"]))
                    {
                        if (dt.Rows[0]["BusinessNurseryID"].ToString() == "0")
                        {
                            strInstitution = "حاضنة الأعمال";
                        }
                        else
                        {
                            strInstitution = "حاضنة الأعمال ( " + GetBusinessNurseryText(dt.Rows[0]["BusinessNurseryID"].ToString()) + " )";
                        }
                    }
                }
                else { strInstitution = "-"; }

            }

            if (!DBNull.Value.Equals(dt.Rows[0]["Stage"]))
            {
                //if (dt.Rows[0]["InstitutionID"].ToString() == "1")
                //{
                //    StrStage = "";
                //}
                //else
                //{
                    StrStage = dt.Rows[0]["Stage"].ToString() + " - " + GetStageText(dt.Rows[0]["Stage"].ToString());
                //}
                    
            }
        }


        strresult = strInstitution + "<br><br>" + StrStage;



            return strresult;
    }
    public string GetBusinessNurseryText(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_BusinessNursery] where id=" + s + " order by id desc";
        //Response.Write(cmd);
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }

    public string GetStageText(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Stage] where id=" + s + " order by id desc";
        //Response.Write(cmd);
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }


    public string GetStatusName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Status]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))
            {

                if (s == "1")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "2")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "3")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "4")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "5")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "6")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "7")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-primary'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }

                else if (s == "8")
                {
                    strresult = "<span class='status-pill smaller green'></span><span class='text-success'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }
                else if (s == "9")
                {
                    strresult = "<span class='status-pill smaller red'></span><span class='text-danger'>&nbsp;" + dt.Rows[0]["NameAr"].ToString() + "</span>";
                }


            }

        }


        return strresult;
    }

    public string GetUserInfo(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [User_Basic_Info]  where id=" + s + "";

        dt = dbFunctions_YPI.GetDataMYAMain(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))
            {
                strresult = dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Mname"].ToString() + " " + dt.Rows[0]["TName"].ToString() + " " + dt.Rows[0]["Lname"].ToString() + "<br>" + dt.Rows[0]["mobile"].ToString();
            }
        }


        return strresult;
    }

}