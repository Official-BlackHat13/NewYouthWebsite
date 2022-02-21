<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ViewInitiative_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .el-tablo .trending {
            padding: 3px 10px;
            border-radius: 30px;
            display: inline-block;
            font-size: 1.91rem !important;
            vertical-align: middle;
            margin-left: 10px;
            float: left;
        }

        .el-tablo .label {
            display: block;
            font-size: 0.93rem !important;
            text-transform: uppercase;
            color: rgba(0, 0, 0, 0.4);
            letter-spacing: 0px;
        }

        .el-tablo .label_w {
            display: block;
            font-size: 0.89rem !important;
            text-transform: uppercase;
            color: rgba(255, 255, 255, 1);
            letter-spacing: 0px;
            text-align: center;
            font-weight: 500;
        }

        .el-tablo .trending .os-icon {
            margin-left: 0px;
            vertical-align: middle;
            font-size: 35px;
        }

        .el-tablo .value_w {
            font-size: 2.43rem;
            font-weight: 500;
            font-family: "Avenir Next W01", "Proxima Nova W01", "Rubik", -apple-system, system-ui, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
            letter-spacing: 1px;
            line-height: 1.2;
            display: inline-block;
            vertical-align: middle;
            color: rgba(255, 255, 255, 1);
        }

        .el-tablo .trending .os-icon_w {
            margin-left: 0px;
            vertical-align: middle;
            font-size: 35px;
            color: rgba(255, 255, 255, 1);
        }

        .bg-warning1 {
            background-color: #ff6a00 !important;
        }

        .txtColorWhite {
            color: rgba(255, 255, 255, 1) !important;
        }

        .Ddanger {
            color: #b71b1b !important;
        }

        .DTotal {
            color: #000 !important;
        }

        .Dpending {
            color: #f8bc34 !important;
        }

        .DApproved {
            color: #71c21a !important;
        }

        .DSubmitted {
            color: #047bf8 !important;
        }
        .txtnosize {  font-size: 18px !important; font-weight:600 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--------------------
          START - Breadcrumbs
          -------------------->
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>المبادر المحترف</span>
        </li>
    </ul>
    <!--------------------
          END - Breadcrumbs
          -------------------->
    <div class="content-panel-toggler">
        <i class="os-icon os-icon-grid-squares-22"></i><span>Sidebar</span>
    </div>


    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-sm-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <%-- <form class="form-inline justify-content-sm-end">
                                <select class="form-control form-control-sm rounded">
                                    <option value="Pending">Today
                          </option>
                                    <option value="Active">Last Week 
                          </option>
                                    <option value="Cancelled">Last 30 Days
                          </option>
                                </select>
                            </form>--%>
                        </div>
                        <h6 class="element-header">المبادر المحترف Dashboard
                    </h6>
                        <div class="element-content">
                            <div class="row" id="PanMainDashboard" runat="server">
                                <div class="col-sm-3 col-xxxl-3">
                                    <a class="element-box el-tablo bg-primary" href="Search_Initiative.aspx?Status=0">
                                        <div class="label_w">
                                            مجموع <%--المبادر المحترف--%>
                                        </div>
                                        <div class="value_w">
                                            <asp:Label ID="labTotalInitiative" runat="server" Text="0"></asp:Label>

                                        </div>
                                        <div class="trending txtColorWhite">
                                            <i class="fa fa-bar-chart" aria-hidden="true"></i>


                                        </div>
                                    </a>
                                </div>

                                <div class="col-sm-3 col-xxxl-3">
                                    <a class="element-box el-tablo bg-primary" href="Search_Initiative.aspx?Status=1">
                                        <div class="label_w">
                                            Active 
                           
                                        </div>
                                        <div class="value_w">
                                            <asp:Label ID="labTotalInitiativeActive" runat="server" Text="0"></asp:Label>

                                        </div>
                                        <div class="trending txtColorWhite">
                                            <i class="fa fa-bar-chart" aria-hidden="true"></i>


                                        </div>
                                    </a>
                                </div>

                                <div class="col-sm-3 col-xxxl-3">
                                    <a class="element-box el-tablo bg-success" href="Search_Initiative.aspx?Status=8">
                                        <div class="label_w">
                                            Completed
                           
                                        </div>
                                        <div class="value_w">
                                            <asp:Label ID="labTotalInitiativeCompleted" runat="server" Text="0"></asp:Label>

                                        </div>
                                        <div class="trending txtColorWhite">
                                            <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-sm-3 col-xxxl-3">
                                    <a class="element-box el-tablo bg-danger" href="Search_Initiative.aspx?Status=9">
                                        <div class="label_w">
                                            Rejected 
                           
                                        </div>
                                        <div class="value_w">
                                            <asp:Label ID="labTotalInitiativeCancelled" runat="server" Text="0"></asp:Label>

                                        </div>
                                        <div class="trending txtColorWhite">

                                            <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12" id="PanMYAInitiativeStatistics" runat="server">
                    <div class="element-wrapper">

                        <div class="element-box">
                            <div class="element-info">
                                <div class="row align-items-center">
                                    <div class="col-sm-12">
                                        <div class="element-info-with-icon">
                                            <div class="element-info-icon">
                                                <div class="fa fa-bar-chart"></div>
                                            </div>
                                            <div class="element-info-text">
                                                <h5 class="element-inner-header">Phase Wise Statistics
                                                </h5>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-xl-12">
                                    <div class="row">
                                        <div class="col-sm-4 b-l b-b" id="PanMYAStage1" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage1" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">1</span> - Application Received
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 b-l b-b" id="PanMYAStage2" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage2" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">2</span> - Reviewing
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 b-b" id="PanMYAStage3" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage3" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">3</span> - Call For Interview 
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 b-l" id="PanMYAStage4" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage4" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">4</span> - Final  Reviewing
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 b-l" id="PanMYAStage5" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage5" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">5</span> - Wating For Incubator Selection
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 b-l" id="PanMYAStage6" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage6" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                   <span class="text-primary txtnosize">6</span> - Incubator Evaluation
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 b-l" id="PanMYAStage7" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage7" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                  <span class="text-primary txtnosize">7</span> -	Incubator Selected
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 b-l" id="PanMYAStage8" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage8" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                 <span class="text-success txtnosize">8</span> -	Completed
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 b-l" id="PanMYAStage9" runat="server">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labMYAStatisticsInitiativeStage9" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                     <span class="text-danger txtnosize">9</span> -	Rejected
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12" id="PanBusinessNurseryInitiativeStatistics" runat="server">
                    <div class="element-wrapper">

                        <div class="element-box">
                            <div class="element-info">
                                <div class="row align-items-center">
                                    <div class="col-sm-12">
                                        <div class="element-info-with-icon">
                                            <div class="element-info-icon">
                                                <div class="fa fa-bar-chart"></div>
                                            </div>
                                            <div class="element-info-text">
                                                <h5 class="element-inner-header">حاضنة الأعمال
                                                </h5>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-xl-12">
                                    <div class="row">
                                        <div class="col-sm-3 b-l ">
                                            <div class="el-tablo centered padded">
                                                <div class="value">
                                                    <asp:Label ID="labOtherStatisticsInitiativeAssigned" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                    تم استلام المستندات من المكتب 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 b-l">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labOtherStatisticsInitiativeCompleted" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                    يحول للإدارة المختصة للدراسة 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 b-l">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labOtherStatisticsInitiativeActive" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                    الموافقة واخطار المبادر بالدفع
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 ">
                                            <div class="el-tablo centered padded">
                                                <div class="value ">
                                                    <asp:Label ID="labOtherStatisticsInitiativePending" runat="server" Text="0"></asp:Label>
                                                </div>
                                                <div class="label DTotal">
                                                    تم الدفع 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-sm-12">
                    <div class="element-wrapper">
                        <h6 class="element-header">أخر المبادر المحترف
                    </h6>
                        <div class="element-box-tp">


                            <div class="table-responsive">
                                <table class="table table-bordered table-lg table-v2 table-striped">
                                    <thead class="">
                                        <tr class="">

                                            <th>#</th>
                                            <th>اسم المشروع</th>
                                            <th>اسم مقدم الطلب</th>
                                            <%-- <th>الهاتف</th>--%>
                                            <th>الحالة</th>
                                            <th>Phase</th>
                                            <th>عرض</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%=StrInitiativetr %>
                                    </tbody>
                                </table>
                                 <script type="text/javascript">

                                            function openWinPrint(id) {
                                                window.open("Print_Initiative.aspx?InitiativeID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
                                            }



                                        </script>
                            </div>


                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

