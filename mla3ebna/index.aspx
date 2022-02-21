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
        .slides-container li img {
            top: 0 !important;
        }
    </style>
     <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            $("input[id$=txtDate]").datepicker({
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false               

            });

          

        });



    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div id="home">
        <div id="slides_wrapper" class="">
            <div id="slides">
                <ul class="slides-container">

                <%--    <li class="nav2">
                        <img src="Files/Banner/banner-1.jpeg" alt="" class="img" />

                    </li>

                    <li class="nav2">
                        <img src="Files/Banner/banner-3.jpeg" alt="" class="img" />

                    </li>--%>

                      <li class="nav2">
                        <img src="Files/Banner/testpng1.jpg" alt="" class="img" />

                    </li>

                     <li class="nav2">
                        <img src="Files/Banner/banner3.jpg" alt="" class="img" />

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

                                    <div class="col-sm-4 col-md-3"></div>

                                  <%--  <div class="col-sm-4 col-md-3" style="padding: 5px 0  15px -40px;">
                                        <div class="select1_wrapper">

                                          

                                            <div class="input1_inner" id="divid">
                                                <input type="text" id="datepicker" value="<%=Dateset %>" style="float: left;" autocomplete="off" />
                                                <asp:HiddenField ID="hiddenSearchDate" runat="server" ClientIDMode="Static" />

                                            </div>

                                        </div>--%>
                                    </div>
                               





                            </li>

                        </ul>


                    </div>



                    <div class="tabs_content tabs1_content">

                        <div id="tabs-1">
                            <div class="form1">
                                <div class="row">
                                    <div class="col-sm-4 col-md-2" style="padding: 5px 0  15px -40px;">
                                        <div class="select1_wrapper">

                                            <label>تاريخ الحجز</label>

                                            <div class="input1_inner" id="divid">
                                                <input type="text" id="datepicker" value="<%=Dateset %>" style="float: left;" autocomplete="off" />
                                                <asp:HiddenField ID="hiddenSearchDate" runat="server" ClientIDMode="Static" />

                                            </div>

                                        </div>
                                    </div>


                                    <asp:UpdatePanel ID="update1" runat="server">
                                        <ContentTemplate>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="select1_wrapper">
                                                    <label>الرياضة</label>


                                                    <asp:DropDownList ID="DDLSportType" AppendDataBoundItems="true" runat="server" CssClass="form-control"></asp:DropDownList>


                                                </div>
                                            </div>

                                            <div class="col-sm-4 col-md-2">
                                                <div class="select1_wrapper">
                                                    <label>المحافظة</label>

                                                    <asp:LinkButton ID="lnkFillGovernorate" ClientIDMode="Static" runat="server" CssClass="hidden" OnClick="lnkFillGovernorate_Click"></asp:LinkButton>
                                                    <asp:DropDownList ID="ddlGov" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged"></asp:DropDownList>

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

                                            <div class="col-sm-4 col-md-2" runat="server" visible="false">
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

            <h2 class="animated">نبذة عن ملاعبنا</h2>

            <div class="title1 animated">
                <div runat="server" id="pAbout"></div>

            </div>

            <br>
            <br>
        </div>
    </div>

    <div id="map" style="width: 100%; height: 440px; border: 1px solid #AAA;"></div>



    <div id="popular_cruises1">
        <div class="container">

            <h2 class="animated">  الملاعب الأكثر حجزا </h2>

            <!--<div class="title1 animated">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummملاعب ذات صلةy nibh
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
                                                                        <img src='<%#Eval("StadiumMainImage") %>' alt="image is not appearing" class="img-responsive">
                                                                        <div class="over">
                                                                            <label class="v1"><%#Eval("StadiumName") %> </label>

                                                                        </div>
                                                                    </figure>
                                                                    <div class="caption">
                                                                        <div class="txt1">
                                                                            <span><%#Eval("StadiumName") %> </span>
                                                                        </div>

                                                                        <div class="txt3 clearfix">

                                                                            <div class="left_side">
                                                                                <asp:LinkButton ID="lnkModelOpen" runat="server" ClientIDMode="Static" CssClass="btn btn-success btn-lg left_side" Text=" احجز الآن" CommandArgument='<%#Eval("StadiumID") %>' CommandName="OpenModel"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                                <%--<asp:LinkButton ID="lnkMapDate" runat="server" OnClick="lnkMapDate_Click" ClientIDMode="Static" CssClass="hidden" Text="ButtonForMap"></asp:LinkButton>--%>
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
    <div class="modal fade" id="ModalPopular" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">اختيار التاريخ </h5>

                </div>
                <div class="modal-body">
                    <div class="row">

                        <div class="col-md-3"></div>
                       
                        <div class="col-md-6" id="dividmodalPop">
                            
                            
                            <div id="datepickermodalPop" value="Dd/Mm/Yy" autocomplete="off" ></div>
                        

                            <asp:LinkButton ID="lnkGetStadiumData1" runat="server" CssClass="hidden" OnClick="lnkGetStadiumData_Click" ClientIDMode="Static" Text="GetStadiumData"></asp:LinkButton>
                            <asp:HiddenField ID="hiddenDate" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hiddenID" runat="server" ClientIDMode="Static" />
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">إغلاق </button>
                    <button type="button" class="btn btn-success" id="btnsearch">بحث </button>
                    <%--<asp:LinkButton ID="lnkModelDate" runat="server" CssClass="btn btn-success" Text="بحث" OnClick="lnkModelDate_Click"></asp:LinkButton>--%>
                    
                </div>
            </div>
        </div>
    </div>
    <%--<script src="js/jquery.js"></script>--%>
    
      <%--<script type="text/javascript">
          $(function () {
              $("#lnkModelDate").click(function (e) {
                  var selected = $("#hiddenDate").val();
                 // alert(selected);
                  if (selected === '') {
                      alert("Choose date!!!");
                      e.preventDefault();
                  }
              });
          });
        </script>--%>
    
    <script type="text/javascript">
        $(function () {
            $("#btnsearch").click(function (e) {

                var selected = $("#hiddenDate").val();
               // alert(selected);
                if (selected === '') {
                    alert("Choose date!!!");
                   // e.preventDefault();
                }
                else {
                    $.ajax({
                        type: 'post',
                        url: 'MYMA.asmx/fn_CheckWholeSiteBlock',
                        data: {
                            ld_data: selected
                        },
                        dataType: 'json',
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                        success: function (data, textStatus, jqXHR) {
                            // alert(data[0].Error);
                            if (data[0].Error == 'False') {

                                window.location = 'SiteBlock.aspx?msg=' + data[0].DisplayMsg;
                            }
                            else if (data[0].Error == 'True') {
                                var btn = document.getElementById('<%=lnkGetStadiumData1.ClientID%>');
                                btn.click();
                            }

                            $('#cover-spin').hide(0)
                        }, error: function (data, ajaxOptions, thrownError) {

                            console.log(data);
                            //scope.msg = data[0].message;
                            //scope.$apply();
                            //scope.MsgBox();
                            //$('#cover-spin').hide(0)
                        }
                    });
                }
            });
        });
       
    </script>

    <script>


        $(function () {
            $("#datepickermodalPop").datepicker({
                dateFormat: 'dd-mm-yy', minDate: 0, maxDate: "+7D",
                onSelect: function (datText) {
                    var selected = $(this).val();
                    $("#hiddenDate").val(selected);

                  //  alert($("#hiddenDate").val());




                }
            });

        });

        //$('#datepickermodalPop').on('show.bs.modal', function (e) {


        //});

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
                  $('#cover-spin').show(0)

                  //$.ajax({
                  //    type: 'post',
                  //    url: 'MYMA.asmx/fn_CheckWholeSiteBlock',
                  //    data: {
                  //        ld_data: selected
                  //    },
                  //    dataType: 'json',
                  //    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                  //    success: function (data, textStatus, jqXHR) {
                  //        //alert(data[0].Error);
                  //        if (data[0].Error == 'False') {

                  //            window.location = 'SiteBlock.aspx?msg=' + data[0].DisplayMsg;
                  //        }
                  //        else {
                  //            var btn = document.getElementById('<=lnkFillGovernorate.ClientID%>');
                  //            btn.click();
                            

                  //        }

                  //        $('#cover-spin').hide(0)
                  //    }, error: function (data, ajaxOptions, thrownError) {
                  //        // alert(data.d);
                  //        console.log(data);
                  //        scope.msg = data[0].message;
                  //        scope.$apply();
                  //        scope.MsgBox();
                  //        $('#cover-spin').hide(0)
                  //    }
                  //});
            

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
          
          }


          </script>

   <%-- <script type="text/javascript">
        $(function () {
            $("#lnkModelOpen").click(function (e) {
                var id = $(this).getAttribute("CommandArgument").val();
                alert(id);
                e.preventDefault();
            });
        });
    </script>--%>

    <script type='text/javascript' src='Scripts/maps/markers.js'></script>

</asp:Content>

