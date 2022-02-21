<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>

      
        .tabs_tabs ul {
            margin-bottom: 0px;
            margin-right: -40px;
        }

            .tabs_tabs ul li {
                font-weight: bold;
                list-style-type: none;
            }

        .flights {
            /*list-style-type: none;*/
            display: block;
            width: 181px;
            padding: 12px 16px 15px 10px;
            background: #fff url(/images/flights_hover.png) 15% 43% no-repeat;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div id="home">
        <div id="slides_wrapper" class="">
            <div id="slides">
                <ul class="slides-container">

                    <li class="nav2">
                        <img src="Files/Banner/banner-1.jpeg" alt="" class="img" />                      

                    </li>

                    <li class="nav2">
                        <img src="Files/Banner/banner-3.jpeg" alt="" class="img" />

                    </li>


                </ul>
            </div>
        </div>
    </div>



    <div id="front_tabs">
        <div class="container">
            <div class="tabs_wrapper tabs1_wrapper">
                <div class="tabs">
                    <div class="tabs_tabs tabs1_tabs">

                        <ul>
                            <li class="active ">

                                <%--<a class="flights" href="#tabs-1">  البحث عن ملاعب</a>--%>
                                <div class="row">
                                    <div class="col-sm-4 col-md-6">
                                        <a class="flights" href="#tabs-1" role="tab">البحث عن ملاعب</a>
                                    </div>

                                    <div class="col-sm-4 col-md-4"></div>

                                    <div class="col-sm-4 col-md-2" style="padding:5px 0  15px -40px;">
                                        <div class="select1_wrapper">

                                            <%--<label>تاريخ الحجز</label>--%>

                                            <div class="input1_inner" id="divid">
                                                <input type="text" id="datepicker" value="Dd/Mm/Yy" style="float: left;" autocomplete="off" />
                                                <asp:HiddenField ID="hiddenSearchDate" runat="server" ClientIDMode="Static" />
                                            </div>

                                        </div>
                                    </div>
                                </div>

                               

                                
                               
                            </li>

                        </ul>


                    </div>



                    <div class="tabs_content tabs1_content">

                        <div id="tabs-1">
                            <div class="form1">
                                <div class="row">

                                    <asp:UpdatePanel ID="update1" runat="server">
                                        <ContentTemplate>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="select1_wrapper">
                                                    <label>Sports</label>


                                                    <asp:DropDownList ID="DDLSportType" AppendDataBoundItems="true" runat="server" CssClass="form-control"></asp:DropDownList>


                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="select1_wrapper">
                                                    <label>المحافظة</label>
                                                    <%-- <div class="select1_inner">--%>

                                                    <asp:DropDownList ID="ddlGov" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged"></asp:DropDownList>

                                                    <%-- </div>--%>
                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="input1_wrapper">
                                                    <label>منطقة</label>
                                                    <div class="">

                                                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"></asp:DropDownList>


                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="input1_wrapper">
                                                    <label>الملعب</label>
                                                    <div class="">
                                                        <asp:DropDownList ID="ddlStadium" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStadium_SelectedIndexChanged"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="select1_wrapper">
                                                    <label>وقت الحجز (اختياري)</label>
                                                    <div class="">

                                                        <asp:DropDownList ID="ddlTime" runat="server" CssClass="form-control"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="button1_wrapper">
                                                    <%--<button type="submit" class="btn-default btn-form1-submit"> old البحث </button>--%>
                                                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-default btn-form1-submit" OnClientClick="return checkdate();" OnClick="lnkSearch_Click" Text="البحث"></asp:LinkButton>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" style="display: none; margin: 10px" id="divmodalmsg"></div>
                        <div style="display: none" class="spinner" id="divmodalspin"></div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="why1">
        <div class="container">

            <h2 class="animated">نبذة عن ملعبنا</h2>

            <div class="title1 animated">
                <p>
                    <asp:Label ID="lblAbout" runat="server"></asp:Label>
                </p>

            </div>

            <br>
            <br>
        </div>
    </div>

    <div id="map" style="width: 100%; height: 440px; border: 1px solid #AAA;"></div>



    <div id="popular_cruises1">
        <div class="container">

            <h2 class="animated">ملاعب ذات صلة</h2>

            <!--<div class="title1 animated">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                euismod <br>tincidunt ut laoreet dolore magna aliquam erat volutpat.
            </div>-->

            <br>
            <br>

            <div id="popular_wrapper" class="animated" data-animation="fadeIn" data-animation-delay="300">
                <div id="popular_inner">
                    <div class="">
                        <div id="popular">
                            <div class="">
                                <div class="carousel-box">
                                    <div class="inner">
                                        <div class="carousel main">
                                            <ul>
                                                <asp:Label ID="lblError" CssClass="text-red" runat="server"></asp:Label>
                                                <asp:Repeater ID="rpPopularStadiums" runat="server" OnItemCommand="rpPopularStadiums_ItemCommand">
                                                    <ItemTemplate>
                                                        <li>
                                                            <div class="popular">
                                                                <div class="popular_inner">
                                                                    <figure>
                                                                        <img src='<%#Eval("StadiumMainImage") %>' alt="" class="img-responsive">
                                                                        <div class="over">
                                                                            <div class="v1"><%#Eval("StadiumName") %> </div>

                                                                        </div>
                                                                    </figure>
                                                                    <div class="caption">
                                                                        <div class="txt1">
                                                                            <span><%#Eval("StadiumName") %> </span>
                                                                        </div>

                                                                        <div class="txt3 clearfix">

                                                                            <div class="left_side">
                                                                                <asp:LinkButton ID="lnkModelOpen" runat="server" CssClass="btn btn-success btn-lg left_side" Text="المزيد" CommandArgument='<%#Eval("StadiumID") %>' CommandName="OpenModel"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                                <asp:LinkButton ID="lnkMapDate" runat="server" OnClick="lnkMapDate_Click" ClientIDMode="Static" CssClass="hidden" Text="ButtonForMap"></asp:LinkButton>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="popular_pagination"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <!-- Modal -->
    <div class="modal fade" id="ModalPopular" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" ng-controller="HomeCtrl">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">اختيار التاريخ </h5>

                </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <div class="col-md-3"></div>
                        <div class="col-md-6" id="dividmodalPop">
                            <div id="datepickermodalPop" value="Dd/Mm/Yy" autocomplete="off" data-dismiss="modal"></div>

                            <asp:LinkButton ID="lnkGetStadiumData" runat="server" CssClass="hidden" OnClick="lnkGetStadiumData_Click" ClientIDMode="Static" Text="GetStadiumData"></asp:LinkButton>
                            <asp:HiddenField ID="hiddenDate" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hiddenID" runat="server" ClientIDMode="Static" />
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">إغلاق </button>
                    <!-- <button type="button" class="btn btn-primary">Save changes</button>-->
                </div>
            </div>
        </div>
    </div>

    <script type='text/javascript' src='Scripts/maps/markers.js'></script>
    <%-- <script type='text/javascript' src='Scripts/maps/leaf-demo.js'></script>--%>

    <script>


        $(function () {
            $("#datepickermodalPop").datepicker({
                dateFormat: 'dd-mm-yy', minDate: 0, maxDate: "+7D",
                onSelect: function (dateText) {
                    var selected = $(this).val();
                    $("#hiddenDate").val(selected);

                    var btn = document.getElementById('<%=lnkGetStadiumData.ClientID%>');
                    btn.click();

                }
            });

        });

        $('#datepickermodalPop').on('show.bs.modal', function (e) {


        });

    </script>

    <script src="js/script.js" type="application/javascript"></script>

    <script type="application/javascript">
        $('.dropdown-menu').find('input').click(function (e) {
            e.stopPropagation();
        });

    </script>


    <script type="application/javascript">


        $(document).ready(function () {
            $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', minDate: 0, maxDate: "+7D" });
            $("#datepicker").on("change", function () {
                var selected = $(this).val();

                $("#hiddenSearchDate").val(selected);
                //angular.element("#divid").scope().test(selected);

            });
        });



        $(function () {

            $("#datepicker").click(function () {

                $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', minDate: 0, maxDate: "+7D" });
            });
        });

        function checkdate() {
            var date = $("#hiddenSearchDate").val();

            if (date === '' || typof(date) === 'undefined' || date === 0) {
                $('#divmodalmsg').html('<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء اختيار التاريخ </strong> </div>');
                $('#divmodalmsg').show();
                return false;
            }
            else {
                $('#divmodalmsg').hide();
                return true;
            }
        }

    </script>


    <script type="text/javascript">
        function modeOpen() {
            $("#ModalPopular").modal('toggle');
        }
    </script>


    <script>

        var map = L.map('map', {
            attributionControl: false,
            center: [29.2816, 47.9603],
            minZoom: 7,
            zoom: 11
        })

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
            subdomains: ['a', 'b', 'c']
        }).addTo(map)

        //  var myURL = jQuery('script[src$="leaf-demo.js"]').attr('src').replace('leaf-demo.js', '')
        var myURL = 'Scripts/maps/';
        var myIcon = L.icon({
            iconUrl: myURL + 'images/pin24.png',
            iconRetinaUrl: myURL + 'images/pin48.png',
            iconSize: [29, 24],
            iconAnchor: [9, 21],
            popupAnchor: [0, -14]
        })


        $.ajax({
            type: "POST",
            url: 'index.aspx/GetData1',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {


                var fullDate = new Date()

                //Thu May 19 2011 17:25:38 GMT+1000 {}

                //convert month to 2 digits
                var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);

                var currentDate = fullDate.getDate() + "-" + twoDigitMonth + "-" + fullDate.getFullYear();


                //  console.log(currentDate);

                //  console.log(data.d[0]);

                for (var i = 0; i < data.d.length; ++i) {

                    //  console.log(data.d[0]);
                    //  L.marker([data.d[i].lat, data.d[i].lng], { icon: myIcon })
                    //.bindPopup('<a href="' + data.d[i].url + currentDate + '" target="_blank">' + data.d[i].name + '</a>')
                    //.addTo(map);

                    var contentId = data.d[i].name

                    L.marker([data.d[i].lat, data.d[i].lng], { icon: myIcon })
                  .bindPopup('<a href=javascript:void(0) onclick="SearchResult(\'' + data.d[i].stadiumID + '\')">  ' + data.d[i].name + '</a>')
                  //'<a onclick="showDiv("' + data.d[i].url + currentDate + '")">' + data.d[i].name + '</a>')
                  .addTo(map);
                }
            },

            failure: function (data, err) {
                alert("error:" + err.data);
            },
            error: function (data) {
                alert("Error");
            }




        });

        function SearchResult(stadiumID) {

            var fullDate = new Date()
            var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);

            var currentDate = fullDate.getDate() + "-" + twoDigitMonth + "-" + fullDate.getFullYear();
            // alert(stadiumID);
            $.ajax({
                type: "POST",
                url: "/index.aspx/SearchMap",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ "stadiumID": stadiumID, "currentDate": currentDate }),
                success: function (msg) {
                    window.location = msg.d;
                }
            });



        }
        function getValue(a) {
            console.log("here");




            //  var text = a.innerHTML;

            //var id = text.find(".hidden").text();
            // alert(id);
            //   var btn = document.getElementById('<%=lnkMapDate.ClientID%>');
               //   btn.click();
           }


    </script>

</asp:Content>

