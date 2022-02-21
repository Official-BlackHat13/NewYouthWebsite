<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="StadiumCMS_Default" %>

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

        .bg-info1 {
            background-color: #5F9EA0 !important;
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

        .calenderStyle {
            position: absolute;
            margin-top: -31px;
            margin-right: 8px;
            font-size: 23px;
            color: #5f9ea0;
        }

        .text-bg1 {
            background-color: #eff5f7 !important;
            border: 1px solid #516b86 !important;
            padding-right: 34px !important;
        }

        .btnBig {
            font-size: 20px !important;
        }
    </style>
    <%--  <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Month', 'Total'],
                ['Jan', 1000],
                ['Feb', 1170],
                ['Mar', 660],
                ['Apr', 1000],
                ['May', 1170],
                ['Jun', 660],
                ['Jul', 1000],
                ['Aug', 1170],
                ['Sep', 660],
                ['Oct', 660],
                ['Nov', 660],
                ['Dec', 1030]
            ]);

            var options = {
                chart: {
                    // title: 'Month Wise Booking',
                    legend: { position: 'none' }
                }
            };

            var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

            chart.draw(data, google.charts.Bar.convertOptions(options));
        }
    </script>--%>

    <script>
        window.onload = function () {
            var ctxGovernorate = document.getElementById("barChartByGovernorate").getContext('2d');

            $.ajax({
                type: 'POST',
                url: 'Default.aspx/GetGovernorateData',
                data: '{}',
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {

                    var govname = new Array();
                    var govBookingCount = new Array();
                    var govBookingCancelCount = new Array();

                    var data = data.d;
                    $.each(data, function (key, value) {
                        if (key != 0) {
                            govname.push(value[0]);
                            govBookingCount.push(value[1]);
                            govBookingCancelCount.push(value[2]);
                        }

                    }
                    )

                    var barChartByGovernorate = new Chart(ctxGovernorate, {
                        type: 'bar',

                        data: {
                            //  labels: ["مبارك الكبير", "الأحمدي", "الجهراء", "الفروانية", "حولي", "العاصمة"],                    
                            labels: govname,
                            datasets: [
                                {
                                    label: "تأكيد",/*Confirm*/
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#4ecc48",
                                    data: govBookingCount //[408, 547, 675, 734, 500, 400]
                                },
                                {
                                    label: "إلغاء",/*Cancel*/
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#f37070",
                                    data: govBookingCancelCount //[133, 221, 783, 800, 300, 300]
                                }

                            ]
                        },
                        options: {
                            title: {
                                display: true,
                                fontFamily: 'Droid Arabic Kufi',
                                fontSize: '11',
                                text: 'الشهر'

                            }, responsive: true,
                            scales: {
                                xAxes: [{
                                    // display: false,
                                    stacked: true,
                                    ticks: {
                                        fontFamily: 'Droid Arabic Kufi',
                                        fontSize: '11',
                                        fontColor: '#969da5'
                                    },
                                    //gridLines: {
                                    //  color: 'rgba(0,0,0,0.05)',
                                    //  zeroLineColor: 'rgba(0,0,0,0.05)'
                                    // }
                                }],
                                yAxes: [{
                                    stacked: true,
                                    position: 'right',
                                    ticks: {
                                        beginAtZero: true
                                    },
                                    // gridLines: {
                                    //   color: 'rgba(0,0,0,0.05)',
                                    //   zeroLineColor: '#6896f9'
                                    // }
                                }]
                            },
                        }
                    });

                },
                failure: function (data) {
                    alert(data.d);
                },
                error: function (data) {
                    alert(data.d);
                }

            });


            var ctxArea = document.getElementById("barChartByArea").getContext('2d');


            $.ajax({
                type: 'POST',
                url: 'Default.aspx/GetRegionData',
                data: '{}',
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {

                    var year = new Array();
                    var yearBookingcount = new Array();
                    var yearCancelCount = new Array();

                    var data = data.d;
                    $.each(data, function (key, value) {
                        if (key != 0) {
                            year.push(value[0]);
                            yearBookingcount.push(value[1]);
                            yearCancelCount.push(value[2]);

                        }

                    }
                    )
                    var barChartByArea = new Chart(ctxArea, {
                        type: 'bar',

                        data: {
                            labels: year,//["1900", "1950", "1999", "2050"],
                            datasets: [
                                {
                                    label: "تأكيد",/*Confirm*/
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#4ecc48",
                                    data: yearBookingcount//[408, 547, 675, 734]
                                },
                                {
                                    label: "إلغاء",/*Cancel*/
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#f37070",
                                    data: yearCancelCount //[133, 221, 783, 2478]
                                }

                            ]
                        },
                        options: {
                            title: {
                                display: true,
                                fontFamily: 'Droid Arabic Kufi',
                                fontSize: '11',
                                text: 'الشهر'

                            }, responsive: true,
                            scales: {
                                xAxes: [{
                                    // display: false,
                                    stacked: true,
                                    ticks: {
                                        fontFamily: 'Droid Arabic Kufi',
                                        fontSize: '11',
                                        fontColor: '#969da5'
                                    },
                                    //gridLines: {
                                    //  color: 'rgba(0,0,0,0.05)',
                                    //  zeroLineColor: 'rgba(0,0,0,0.05)'
                                    // }
                                }],
                                yAxes: [{
                                    stacked: true,
                                    position: 'right',
                                    ticks: {
                                        beginAtZero: true
                                    },
                                    // gridLines: {
                                    //   color: 'rgba(0,0,0,0.05)',
                                    //   zeroLineColor: '#6896f9'
                                    // }
                                }]
                            },
                        }
                    });
                },
                failure: function (data) {
                    alert(data.d);
                },
                error: function (data) {
                    alert(data.d);
                }

            });


            var ctxTop5Stadium = document.getElementById("barChartByTop5Stadium").getContext('2d');


            $.ajax({
                type: 'POST',
                url: 'Default.aspx/GetStadiumData',
                data: '{}',
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {

                    var stadiumname = new Array();
                    var stadiumCount = new Array();

                    var data = data.d;
                    $.each(data, function (key, value) {
                        if (key != 0) {
                            stadiumname.push(value[0]);
                            stadiumCount.push(value[1]);
                        }

                    }
                    )



                    var barChartByTop5Stadium = new Chart(ctxTop5Stadium, {
                        type: 'bar',

                        data: {
                            //  labels: ["Stadium 1", "Stadium 2", "Stadium 3", "Stadium 4", "Stadium 5"],
                            labels: stadiumname,
                            datasets: [
                                {
                                    label: "Count",
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#4ecc48",
                                    data: stadiumCount //[408, 547, 675, 734, 800]
                                }

                            ]
                        },
                        options: {
                            title: {
                                display: true,
                                fontFamily: 'Droid Arabic Kufi',
                                fontSize: '11',
                                text: 'الشهر'

                            }, responsive: true,
                            scales: {
                                xAxes: [{
                                    // display: false,
                                    stacked: true,
                                    ticks: {
                                        fontFamily: 'Droid Arabic Kufi',
                                        fontSize: '11',
                                        fontColor: '#969da5'
                                    },
                                    //gridLines: {
                                    //  color: 'rgba(0,0,0,0.05)',
                                    //  zeroLineColor: 'rgba(0,0,0,0.05)'
                                    // }
                                }],
                                yAxes: [{
                                    stacked: true,
                                    position: 'right',
                                    ticks: {
                                        beginAtZero: true
                                    },
                                    // gridLines: {
                                    //   color: 'rgba(0,0,0,0.05)',
                                    //   zeroLineColor: '#6896f9'
                                    // }
                                }]
                            },
                        }
                    });
                },
                failure: function (data) {
                    alert(data.d);
                },
                error: function (data) {
                    alert(data.d);
                }

            });

            var ctxTop5Members = document.getElementById("barChartByTop5Members").getContext('2d');


            $.ajax({
                type: 'POST',
                url: 'Default.aspx/GetMembersData',
                data: '{}',
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {

                    var name = new Array();
                    var Count = new Array();

                    var data = data.d;
                    $.each(data, function (key, value) {
                        if (key != 0) {
                            name.push(value[0]);
                            Count.push(value[1]);
                        }

                    }
                    )

                    var barChartByTop5Members = new Chart(ctxTop5Members, {
                        type: 'bar',

                        data: {
                            labels: name, //["Member 1", "Member 2", "Member 3", "Member 4", "Member 5"],
                            datasets: [
                                {
                                    label: "Count",
                                    fontFamily: 'Droid Arabic Kufi',
                                    backgroundColor: "#4ecc48",
                                    data: Count //[200, 350, 100, 400, 600]
                                }

                            ]
                        },
                        options: {
                            title: {
                                display: true,
                                fontFamily: 'Droid Arabic Kufi',
                                fontSize: '11',
                                text: 'الشهر'

                            }, responsive: true,
                            scales: {
                                xAxes: [{
                                    // display: false,
                                    stacked: true,
                                    ticks: {
                                        fontFamily: 'Droid Arabic Kufi',
                                        fontSize: '11',
                                        fontColor: '#969da5'
                                    },
                                    //gridLines: {
                                    //  color: 'rgba(0,0,0,0.05)',
                                    //  zeroLineColor: 'rgba(0,0,0,0.05)'
                                    // }
                                }],
                                yAxes: [{
                                    stacked: true,
                                    position: 'right',
                                    ticks: {
                                        beginAtZero: true
                                    },
                                    // gridLines: {
                                    //   color: 'rgba(0,0,0,0.05)',
                                    //   zeroLineColor: '#6896f9'
                                    // }
                                }]
                            },
                        }
                    });
                },
                failure: function (data) {
                    alert(data.d);
                },
                error: function (data) {
                    alert(data.d);
                }

            });


        }
    </script>



    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=txtdate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true

            });

        });
    </script>


    <script type="text/javascript">

        function openWinPrint() {

            var date = document.getElementById("<%=txtdate.ClientID%>").value;

            if (date != "")
                window.open("Print_BookingReport.aspx?BookingDate=" + date + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
            else
                window.open("Print_BookingReport.aspx" + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");

        }



    </script>
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
            <span>ملعبنا</span>
        </li>
    </ul>
    <!--------------------
          END - Breadcrumbs
          -------------------->
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-sm-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                        </div>
                        <h6 class="element-header">ملعبنا Dashboard
                        </h6>
                        <div class="element-content">


                           

                                    <div class="row" id="PanSiteStatistics" >

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dGov">
                                            <a class="element-box el-tablo bg-primary" href="Manage_Governorate.aspx">
                                                <div class="label_w">
                                                    المحافظة <%--المبادر المحترف--%>
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalGovernorate" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">
                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>


                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3"  runat="server" id="dArea">
                                            <a class="element-box el-tablo bg-secondary" href="Manage_Area.aspx">
                                                <div class="label_w">
                                                    المنطقة 
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalArea" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">
                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>


                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dSchool">
                                            <a class="element-box el-tablo bg-success" href="Manage_School.aspx">
                                                <div class="label_w">
                                                    School
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalSchool" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">
                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dStadium" >
                                            <a class="element-box el-tablo bg-danger" href="Manage_Stadium.aspx">
                                                <div class="label_w">
                                                    الملعب 
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalStadium" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">

                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dGaurd">
                                            <a class="element-box el-tablo bg-info" href="Manage_Guard.aspx">
                                                <div class="label_w">
                                                    Guard 
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalGuard" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">

                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dMembers">
                                            <a class="element-box el-tablo bg-warning1" href="View_Members.aspx">
                                                <div class="label_w">
                                                    Members 
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labTotalMembers" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">

                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dBooking">
                                            <a class="element-box el-tablo bg-primary1" href="View_Booking.aspx">
                                                <div class="label text-center">
                                                    Booking 
                           
                                                </div>
                                                <div class="value">
                                                    <asp:Label ID="labTotalBooking" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite1">

                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-sm-3 col-xxxl-3" runat="server" id="dBookingCancel">
                                            <a class="element-box el-tablo bg-info1" href="View_Booking.aspx">
                                                <div class="label_w">
                                                    CancelBooking 
                           
                                                </div>
                                                <div class="value_w">
                                                    <asp:Label ID="labBookingCancel" runat="server" Text="0"></asp:Label>

                                                </div>
                                                <div class="trending txtColorWhite">

                                                    <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                                </div>
                                            </a>
                                        </div>
                                    </div>

                                

                            <div class="row pt-4" style="display:none;">
                                <div class="col-md-12">
                                    <div class="element-wrapper">
                                          <div class="element-actions">
                                            <div class="form-inline justify-content-sm-end">
                                                <asp:DropDownList ID="DDLStatisticsFilter" CssClass="form-control form-control-sm rounded" AutoPostBack="true" runat="server">
                                                    <asp:ListItem Value="0">بحث في</asp:ListItem>
                                                   
                                                    <asp:ListItem Value="3">الشهر</asp:ListItem>
                                                   
                                                    <asp:ListItem Value="4">السنه</asp:ListItem>
                                                    
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <h6 class="element-header">احصائيات</h6>


                                       <div class="row " >
                                            <div class="col-md-6">
                                                <div class="projects-list">
                                                    <div class="project-box">
                                                        <div class="project-head">
                                                            <div class="project-title">
                                                                <h5>المحافظة
                                                                </h5>
                                                            </div>

                                                        </div>
                                                        <div class="project-info">
                                                            <canvas height="280" id="barChartByGovernorate" width="300"></canvas>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="projects-list">
                                                    <div class="project-box">
                                                        <div class="project-head">
                                                            <div class="project-title">
                                                                <h5>المنطقة
                                                                </h5>
                                                            </div>

                                                        </div>
                                                        <div class="project-info">
                                                            <canvas height="280" id="barChartByArea" width="300"></canvas>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row ">
                                            <div class="col-md-6">
                                                <div class="projects-list">
                                                    <div class="project-box">
                                                        <div class="project-head">
                                                            <div class="project-title">
                                                                <h5>Top 5 Stadium
                                                                </h5>
                                                            </div>

                                                        </div>
                                                        <div class="project-info">
                                                            <canvas height="280" id="barChartByTop5Stadium" width="300"></canvas>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="projects-list">
                                                    <div class="project-box">
                                                        <div class="project-head">
                                                            <div class="project-title">
                                                                <h5>Top 5 Members
                                                                </h5>
                                                            </div>

                                                        </div>
                                                        <div class="project-info">
                                                            <canvas height="280" id="barChartByTop5Members" width="300"></canvas>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row ">
                                            <div class="col-md-12">
                                                <link rel="stylesheet" href="https://unpkg.com/leaflet@1.5.1/dist/leaflet.css"
                                                    integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
                                                    crossorigin="" />

                                                <script src="https://unpkg.com/jquery@3.4.1/dist/jquery.min.js"
                                                    integrity="sha384-vk5WoKIaW/vJyUAd9n/wmopsmNhiy+L2Z+SBxGYnUkunIxVxAv/UtMOhba/xskxh"
                                                    crossorigin=""></script>
                                                <script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js"
                                                    integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og=="
                                                    crossorigin=""></script>

                                                <%--<div id="map" style="width: 100%; height: 440px; border: 1px solid #AAA;"></div>--%>
                                                <script type='text/javascript' src='Design/Scripts/maps/markers.js'></script>
                                                <script type='text/javascript' src='Design/Scripts/maps/leaf-demo.js'></script>


                                                <%--   <link rel="shortcut icon"
    type="image/x-icon"
    href="docs/images/favicon.ico">

  <link rel="stylesheet"
    href="https://unpkg.com/leaflet@1.2.0/dist/leaflet.css"
    integrity="sha512-M2wvCLH6DSRazYeZRIm1JnYyh22purTM+FDB5CsyxtQJYeKq83arPe5wgbNmcFXGqiSH2XR8dT/fJISVA1r/zQ=="
    crossorigin>

  <script src="https://unpkg.com/leaflet@1.2.0/dist/leaflet.js"
    integrity="sha512-lInM/apFSqyy1o6s89K4iQUKg6ppXEgsVxT35HbzUupEVRh2Eu9Wdl4tHj7dZO0s1uvplcYGmt3498TtHq+log=="
    crossorigin />


  <style>
    #map {
      width: 600px;
      height: 400px;
    }
  </style>

  <style>
    #map {
      width: 800px;
      height: 500px;
    }
    .info {
      padding: 6px 8px;
      font: 14px/16px Arial, Helvetica, sans-serif;
      background: white;
      background: rgba(255, 255, 255, 0.8);
      box-shadow: 0 0 15px rgba(0, 0, 0, 0.2);
      border-radius: 5px;
    }
    .info h4 {
      margin: 0 0 5px;
      color: #777;
    }
    .legend {
      text-align: left;
      line-height: 18px;
      color: #555;
    }
    .legend i {
      width: 18px;
      height: 18px;
      float: left;
      margin-right: 8px;
      opacity: 0.7;
    }
  </style>
                                                <div id="map" />

  <script type="text/javascript"
    src="us-states.js" />


  <script type="text/javascript">
      var map = L.map("map").setView([29.3117, 47.4818], 4);

      L.tileLayer(
          "https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1Ijoicm9qaXJhamFuIiwiYSI6ImNrYjBseTZzZzA5YTgyeXM5a2ZhNXhwbnQifQ.E1cMLMjAKWv6hELwocAOTw",
          {
              maxZoom: 18,
              attribution:
              'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
              '<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
              'Imagery © <a href="http://mapbox.com">Mapbox</a>',
              id: "mapbox.light"
          }
      ).addTo(map);

      // control that shows state info on hover
      var info = L.control();

      info.onAdd = function (map) {
          this._div = L.DomUtil.create("div", "info");
          this.update();
          return this._div;
      };

      info.update = function (props) {
          this._div.innerHTML =
              "<h4>US Population Density</h4>" +
              (props
                  ? "<b>" +
                  props.name +
                  "</b><br />" +
                  props.density +
                  " people / mi<sup>2</sup>"
                  : "Hover over a state");
      };

      info.addTo(map);

      // get color depending on population density value
      function getColor(d) {
          return d > 1000
              ? "#800026"
              : d > 500
                  ? "#BD0026"
                  : d > 200
                      ? "#E31A1C"
                      : d > 100
                          ? "#FC4E2A"
                          : d > 50
                              ? "#FD8D3C"
                              : d > 20 ? "#FEB24C" : d > 10 ? "#FED976" : "#FFEDA0";
      }

      function style(feature) {
          return {
              weight: 2,
              opacity: 1,
              color: "white",
              dashArray: "3",
              fillOpacity: 0.7,
              fillColor: getColor(feature.properties.density)
          };
      }

      function highlightFeature(e) {
          var layer = e.target;

          layer.setStyle({
              weight: 5,
              color: "#666",
              dashArray: "",
              fillOpacity: 0.7
          });

          if (!L.Browser.ie && !L.Browser.opera && !L.Browser.edge) {
              layer.bringToFront();
          }

          info.update(layer.feature.properties);
      }

      var geojson;

      function resetHighlight(e) {
          geojson.resetStyle(e.target);
          info.update();
      }

      function zoomToFeature(e) {
          map.fitBounds(e.target.getBounds());
      }

      function onEachFeature(feature, layer) {
          layer.on({
              mouseover: highlightFeature,
              mouseout: resetHighlight,
              click: zoomToFeature
          });
      }

      geojson = L.geoJson(statesData, {
          style: style,
          onEachFeature: onEachFeature
      }).addTo(map);

      map.attributionControl.addAttribution(
          'Population data &copy; <a href="http://census.gov/">US Census Bureau</a>'
      );

      var legend = L.control({ position: "bottomright" });

      legend.onAdd = function (map) {
          var div = L.DomUtil.create("div", "info legend"),
              grades = [0, 10, 20, 50, 100, 200, 500, 1000],
              labels = [],
              from,
              to;

          for (var i = 0; i < grades.length; i++) {
              from = grades[i];
              to = grades[i + 1];

              labels.push(
                  '<i style="background:' +
                  getColor(from + 1) +
                  '"></i> ' +
                  from +
                  (to ? "&ndash;" + to : "+")
              );
          }

          div.innerHTML = labels.join("<br>");
          return div;
      };

      legend.addTo(map);

  </script>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>


                            <div class="row pt-4">
                                <div class="col-sm-9 col-xxl-8">
                                    <!--START - Customers with most tickets-->
                                    <div class="element-wrapper">
                                        <div class="element-actions">
                                        </div>
                                        <h6 class="element-header">أخر حجوز
                                        </h6>


                                        <div class="element-box" style="min-height: 450px;">
                                            <div class="col-md-3 pull-left">
                                                <div class="form-group">
                                                    <label for="projectinput1">
                                                        Search By Date
                                                    </label>
                                                    <asp:TextBox ID="txtdate" AutoComplete="off" CssClass="form-control text-bg1" runat="server" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                                                    <i class="fa fa-calendar form-control-feedback calenderStyle"></i>

                                                </div>
                                            </div>


                                            <div class="table-responsive">
                                                <table class="table table-lightborder">
                                                    <thead>
                                                        <tr>
                                                            <th>الاسم الثلاثي
                                                            </th>
                                                            <th class="text-center">تاريخ الحجز
                                                            </th>
                                                            <th class="text-center">وقت الحجز
                                                            </th>
                                                            <th class="text-center">اسم الملعب
                                                            </th>
                                                            <th class="text-center">ReservedDate
                                                            </th>
                                                            <th class="text-center">حالة
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <%=StrLatestBookingtr %>
                                                    </tbody>
                                                </table>
                                            </div>


                                        </div>


                                        <div class="element-box text-left">

                                            <a class="btn btn-round  btn-outline-danger btnBig" href='javascript:void(0);' onclick="openWinPrint()"><i class='fa fa-print'></i></a>
                                            <%--<asp:LinkButton ID="lnkprint" runat="server" CssClass="btn btn-round  btn-outline-success" OnClick="lnkprint_Click"><span class="fa fa-print"></span> </asp:LinkButton>--%>
                                            <asp:LinkButton ID="LinkExcel" runat="server" CssClass="btn btn-round  btn-outline-info btnBig" OnClick="LinkExcel_Click"><span class="fa fa-file-excel-o"></span> </asp:LinkButton>
                                        </div>

                                    </div>
                                    <!--END - Customers with most tickets-->
                                </div>
                                <div class="col-sm-3 col-xxl-4" runat="server" id="divLatestMembers">
                                    <!--START - Questions per Product-->
                                    <div class="element-wrapper">
                                        <div class="element-actions">
                                        </div>

                                      
                                        <h6 class="element-header">Latest Members
                                        </h6>
                                        <div class="element-box-tp">
                                            <%=StrLatestMemberstr %>
                                        </div>
                                        
                                    </div>
                                    <!--END - Questions per product-->
                                </div>
                            </div>

                            <%--     <div class="row">
                                <div class="col-lg-12">
                                </div>
                            </div>--%>

                            <%-- <div class="row ">


                                <div class="col-sm-8">
                                    <div class="element-wrapper">
                                        <h6 class="element-header">Month Wise Booking</h6>
                                        <div class="element-box" dir="ltr">
                                            <div id="columnchart_material" style="width: 100%; height: 300px;"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-sm-4">
                                    <div class="element-wrapper">
                                        <div class="element-actions">
                                            <div class="form-inline justify-content-sm-end">
                                                <asp:DropDownList ID="DDLTop5Stadium" CssClass="form-control form-control-sm rounded" runat="server">
                                                    <asp:ListItem Value="1">Today</asp:ListItem>
                                                    <asp:ListItem Value="2">This Week</asp:ListItem>
                                                    <asp:ListItem Value="3">This Month</asp:ListItem>
                                                    <asp:ListItem Value="4">This Tear</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                        <h6 class="element-header">Top 5 Stadium</h6>

                                        <div class="element-box" style="min-height:345px;">
                                            <div class="os-progress-bar success">
                                                <div class="bar-labels">
                                                    <div class="bar-label-left">
                                                        <span class="bigger">مدرسة عبداللطيف النصف المتوسطة</span>
                                                    </div>
                                                  
                                                </div>
                                                <div class="bar-level-1" style="width: 100%">

                                                    <div class="bar-level-3" style="width: 40%"></div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
    </div>
</asp:Content>

