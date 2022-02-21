<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SearchStadiumResult.aspx.cs" Inherits="Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .radio-arrange {
            display: inline-block;
        }

        .switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input { 
  opacity: 0;
  width: 0;
  height: 0;
}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}


        .block-time {
            margin: 17px 0 36px 0;
            display: inline-block;
        }

        .caption label span {
            display: block !important;
        }


        @media (max-width: 765px) {

            .block-time {
                margin:0 !important;
            }
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div id="main">
        <div class="page_banner"></div>
        <div class="breadcrumbs1_wrapper">
            <div class="container">
                <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span>عن ملعبنا</div>
            </div>
        </div>
        <div id="content">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3">
                        <div class="sidebar-block">
                             <%-- <form action="javascript:void(0);">--%>
                            <div>
                                <div class="col-sm-12 no-padding margin-top">
                                    <div class="input1_wrapper">
                                        <label>تاريخ الحجز</label>
                                        <div class="input1_inner">
                                            <input type="text" id="datepicker" value="<%=Dateset %>" title="Date Format (اليوم/الشهر/السنة)" />
                                            <asp:HiddenField ID="hiddenSearchDate" runat="server" ClientIDMode="Static" />
                                             <asp:HiddenField ID="hiddenTimeSlotID" runat="server" ClientIDMode="Static" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>

                                <asp:UpdatePanel ID="update1" runat="server">
                                    <ContentTemplate>


                                         <div class="col-sm-12 no-padding margin-top">

                                            <label for="Button2">الرياضة </label>
                                             <asp:LinkButton ID="lnkFillGovernorate" ClientIDMode="Static" runat="server" CssClass="hidden" OnClick="lnkFillGovernorate_Click"></asp:LinkButton>
                                            <div class="select1_inner">
                                                 
                                                <asp:DropDownList ID="DDLSportType" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLSportType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                         </div>


                                        <div class="col-sm-12 no-padding margin-top">
                                            <label for="Button2">المحافظة</label>

                                            <asp:DropDownList ID="ddlGov" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged"></asp:DropDownList>


                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="clearfix"></div>
                                        <div class="col-sm-12 no-padding margin-top">
                                            <label for="inputEmail">منطقة</label>
                                            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-sm-12 no-padding margin-top">
                                            <label for="inputEmail">الملعب</label>
                                            <asp:DropDownList ID="ddlStadium" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStadium_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-sm-12 no-padding margin-top" runat="server" visible="false">
                                            <label for="inputEmail">وقت الحجز (اختياري)</label>
                                            <asp:DropDownList ID="ddlTime" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                        </div>



                                    </ContentTemplate>
                                    <Triggers>
                                      
                                        <%--<asp:PostBackTrigger ControlID="ddlStadium" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>


                                <div class="clearfix"></div>
                                <label class="col-md-6" style="padding-left: 0; padding-top: 12px;"></label>
                                <div id="divid" class="no-padding margin-top col-md-6 text-right" style="margin-top: 5px;">

                                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-default btn-cf-submit" OnClick="lnkSearch_Click" Text="بحث" ClientIDMode="Static"></asp:LinkButton>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>

                    </div>

                     
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="col-sm-12 col-xs-12">
                                <div class="thumb5">
                                    <div class="thumbnail clearfix" runat="server" id="DivStadium" visible="true">

                                        <asp:UpdatePanel ID="updatedata" runat="server">
                                            <ContentTemplate>


                                                <div class="caption">



                                                    <asp:Repeater ID="rpStadiumType" runat="server" OnItemDataBound="rpStadiumType_ItemDataBound">
                                                        <ItemTemplate>
                                                            <div class="txt1" runat="server" id="DivHeading"> ( <asp:Label ID="lbltype" runat="server"></asp:Label> <%--<%#Eval("StadiumType")%>--%> )   الأوقات المتوفرة   </div>
                                                            <br />
                                                             <ul>
                                                                 
                                                                <asp:Repeater ID="rptimeslots" runat="server" OnItemDataBound="rptimeslots_ItemDataBound">
                                                                    <ItemTemplate>

                                                                        <li class="txt3 clearfix radio-arrange" runat="server" id="liTimeSlot">
                                                                            <div class="right_side">
                                                                           <asp:Label ID="lblNotavailble" runat="server" CssClass="text-danger" Text="Not Available" Visible="false"></asp:Label>     
 
                                                                     <div class="switch-div" runat="server" id="lblAvailable" >
                                                                         <label class="switch">
                                                                                <input type="radio" name="timeradio" id='<%# String.Format("{0},{1}", Eval("StadiumDetId"), Eval("TimeSlotDetid"))%>' value="<%#Eval("TimeSlot")%>" > 
                                                                            
                                                                                    <span class="slider round"></span>
                                                                             
                                                                              <div class="right_side-1">
                                                                                        <%#Eval("TimeSlot")%>                                                                                  
                                                                                    </div>

                                                                             
                                                                          </label>
                                                                      </div>                                                                                                                                                       <label class="switch">

                                                                                <div class="switch-div" id="lblNotAvailable" runat="server" >
                                                                                  
                                                                                    <img src="images/ban-icon.png" alt="">
                                                                                    <span style="color: red;" >
                                                                                        <div class="right_side-1" style="margin: 5px -45px 0 0;">
                                                                                            <%#Eval("TimeSlot")%>
                                                                                        </div>
                                                                                    </span>
                                                                                       
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>

                                                            </ul>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="form-group" style="display: none; margin: 10px" id="divmodalmsg"></div>
                                                        <div style="display: none" class="spinner" id="divmodalspin"></div>
                                                        <div class="no-padding margin-top col-md-3 col-xs-12 text-right" style="margin-top: 5px;">
                                                            <asp:LinkButton ID="lnkbooking" runat="server" Text="إرسال" CssClass="btn btn-default btn-cf-submit" OnClick="lnkbooking_Click" OnClientClick="return Gettime();"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <div class="row" >
                                        <div class="txt1 col-sm-12 col-xs-12" id="FullBlock" runat="server" visible="false">
                                            <h3>لاتوجد فترات زمنية متوفرة حاليا FullBlock </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="hl1"></div>
                        <div class="clearfix"></div>
                        <div class="row">
                            <div class="col-sm-12 col-xs-12">
                                <div class="thumb5">
                                    <div class="thumbnail clearfix">
                                      
                                        <div class="caption col-sm-12 col-xs-12">
                                            <div class="">
                                                <div class="txt1">
                                                    <asp:Label ID="lblStadiumName" runat="server">  </asp:Label>
                                                   <%-- -
                                                    <asp:Label ID="lblStadiumNameEn" runat="server"></asp:Label>--%>
                                                </div>
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a href="">العنوان :</a>
                                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a href="">وصف الملعب :</a>
                                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                             <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a href="">Gender :</a>
                                                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a href="">منطقة :</a> 
                                                        <asp:Label ID="lblAreaName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a href="">المحافظة :</a>
                                                        <asp:Label ID="lblGovernorateName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a>الموقع</a>
                                                        <img onclick="MapRedirect(1)"  src="images/kuwait-map.png" width="70"  style="cursor: pointer;"  /> 
                                                        <asp:HiddenField ID="hiddenKuwaitFounderLocation" runat="server" ClientIDMode="Static" />
                                                        <img  onclick="MapRedirect(2)"  src="images/google-map.png" width="50" height="50" style="cursor: pointer;" />  
                                                        <asp:HiddenField ID="hiddenGoogleMapLocation" runat="server" ClientIDMode="Static"/>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="txt3 clearfix">
                                                        <div class="right_side">
                                                            <a> التقييم العام:</a>

                                                    
                                                            <fieldset class="ratingonlydet" >
                                                                <input type="radio" id="Radio1"  name="ratingonlydet" value="5" /><label class="full" for="Radio1" title="Awesome - 5 stars"></label>
                                                                <input type="radio" id="Radio2" name="ratingonlydet"  value="4.5" /><label class="half" for="Radio2" title="Pretty good - 4.5 stars"></label>
                                                                <input type="radio" id="Radio3" name="ratingonlydet"  value="4" /><label class="full" for="Radio3" title="Pretty good - 4 stars"></label>
                                                                <input type="radio" id="Radio4" name="ratingonlydet" value="3.5" /><label class="half" for="Radio4" title="Meh - 3.5 stars"></label>
                                                                <input type="radio" id="Radio5" name="ratingonlydet" value="3" /><label class="full" for="Radio5" title="Meh - 3 stars"></label>
                                                                <input type="radio" id="Radio6" name="ratingonlydet"  value="2.5" /><label class="half" for="Radio6" title="Kinda bad - 2.5 stars"></label>
                                                                <input type="radio" id="Radio7" name="ratingonlydet"  value="2" /><label class="full" for="Radio7" title="Kinda bad - 2 stars"></label>
                                                                <input type="radio" id="Radio8" name="ratingonlydet"  value="1.5" /><label class="half" for="Radio8" title="Meh - 1.5 stars"></label>
                                                                <input type="radio" id="Radio9" name="ratingonlydet"  value="1" /><label class="full" for="Radio9" title="Sucks big time - 1 star"></label>
                                                                <input type="radio" id="Radio10" name="ratingonlydet"  value=".5" /><label class="half" for="Radio10" title="Sucks big time - 0.5 stars"></label>
                                                            </fieldset>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                        <a>تقييمك :</a>
                                                        <fieldset class="rating" >
                                                            <input type="radio" id="star5" name="rating"  value="5" /><label class="full" for="star5" title=""></label>
                                                            <input type="radio" id="star4half" name="rating"  value="4.5"  /><label class="half" for="star4half" title=""></label>
                                                            <input type="radio" id="star4" name="rating"  value="4"  /><label class="full" for="star4" title=""></label>
                                                            <input type="radio" id="star3half" name="rating" value="3.5" /><label class="half" for="star3half" title=""></label>
                                                            <input type="radio" id="star3" name="rating"  value="3" /><label class="full" for="star3" title=""></label>
                                                            <input type="radio" id="star2half" name="rating"  value="2.5"  /><label class="half" for="star2half" title=""></label>
                                                            <input type="radio" id="star2" name="rating" value="2" /><label class="full" for="star2" title=""></label>
                                                            <input type="radio" id="star1half" name="rating"  value="1.5"  /><label class="half" for="star1half" title=""></label>
                                                            <input type="radio" id="star1" name="rating"  value="1" " /><label class="full" for="star1" title=""></label>
                                                            <input type="radio" id="starhalf" name="rating" value=".5"  /><label class="half" for="starhalf" title=""></label>
                                                        </fieldset>
                                                        <asp:UpdatePanel ID="upmyrating" runat="server">
                                                            <ContentTemplate>
                                                                <asp:HiddenField ID="hiddenMyrationSelect" runat="server" ClientIDMode="Static"/>
                                                        <asp:LinkButton ID="lnkMyrationgUpdate" runat="server" ClientIDMode="Static" OnClick="lnkMyrationgUpdate_Click" CssClass="hidden"></asp:LinkButton>                                                    </div>
                                               
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                     </div>
                                            </div>
                                          
                                                <div class="txt3 clearfix">
                                                    <div class="right_side">
                                                <a> أضف إلى المفضلة </a>
                                                <div class="txt3 clearfix" style="direction: rtl">
                                                    <div class="right_side">
                                                        <div class="heart" onclick="ClickFavorite();" runat="server" id="dv"></div>
                                                        <asp:UpdatePanel ID="up" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="lnk" runat="server" CssClass="hidden" ClientIDMode="Static" OnClick="lnk_Click"></asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group" style="display: none; margin: 10px" id="divmodalmsg2"></div>
                                                <div style="display: none" class="spinner" id="divmodalspin2"></div>
                                            </div>
                                            
                                        </div>
                                                </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                                           <div class="tab_container">

                            <input id="tab3" type="radio" name="tabs" checked="checked">
                            <label for="tab3"><span>صورة</span></label>

                            <input id="tab4" type="radio" name="tabs">
                            <label for="tab4"><span>فيديو</span></label>



                    <section id="content3" class="tab-content">
                                <div class="tabs3_content">


                                    <div id="tabs3-1">

                                        <div id="" class="clearfix">
                                            <asp:Repeater ID="rpImages" runat="server">
                                                <ItemTemplate>


                                                    <div class="row">
                                                        <div class="col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo1") != null?true:false %>'>

                                                            <a href='<%#Eval("photo1")%>' target="_blank" class="img-responsive" rel="prettyPhoto[mix]" title="Big Photo">

                                                                <img src='<%#Eval("photo1")%>' class="img-responsive col-xs-12" alt="" title="Thumbnail">
                                                            </a>

                                                        </div>
                                                        <div class=" col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo2") != null?true:false %>'>

                                                            <a href='<%#Eval("photo2")%>' target="_blank" class="img-responsive" rel="prettyPhoto[mix]" title="Big Photo">

                                                                <img src='<%#Eval("photo2")%>' class="img-responsive col-xs-12" alt="" title="Thumbnail">
                                                            </a>

                                                        </div>
                                                        <div class="col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo3") != null?true:false %>'>

                                                            <a href='<%#Eval("photo3")%>' target="_blank" class="img-responsive" rel="prettyPhoto[mix]" title="Big Photo">

                                                                <img src='<%#Eval("photo3")%>' class="img-responsive col-xs-12" alt="" title="Thumbnail">
                                                            </a>

                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </div>

                                    </div>
                                </div>
                            </section>  

                               <section id="content4" class="tab-content">
                                <div id="tabs3-2">
                                    <div class="isotope-box">
                                        <asp:Repeater ID="rpVideos" runat="server">
                                            <ItemTemplate>
                                                <div id="Div1" class="clearfix">

                                                    <ul class="thumbnails clearfix" id="Ul1">
                                                        <div class="grid-sizer col-sm-4 col-xs-12"></div>
                                                        <div class="gutter-sizer"></div>
                                                        <li id="Li4" class="element col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo1") != null ? true:false%>'>
                                                            <div class="thumb-isotope">
                                                                <div class="thumbnail clearfix">
                                                                    <iframe width="100%" height="100%"
                                                                        allowfullscreen="allowfullscreen"
                                                                        mozallowfullscreen="mozallowfullscreen"
                                                                        msallowfullscreen="msallowfullscreen"
                                                                        oallowfullscreen="oallowfullscreen"
                                                                        webkitallowfullscreen="webkitallowfullscreen" src="photo1"></iframe>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li id="Li5" class="element col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo2") != null ? true:false%>'>
                                                            <div class="thumb-isotope">
                                                                <div class="thumbnail clearfix">
                                                                    <iframe width="100%" height="100%"
                                                                        allowfullscreen="allowfullscreen"
                                                                        mozallowfullscreen="mozallowfullscreen"
                                                                        msallowfullscreen="msallowfullscreen"
                                                                        oallowfullscreen="oallowfullscreen"
                                                                        webkitallowfullscreen="webkitallowfullscreen" src="photo2"></iframe>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li id="Li6" class="element col-sm-4 col-xs-12" runat="server" visible='<%#Eval("photo3") != null ? true:false%>'>
                                                            <div class="thumb-isotope">
                                                                <div class="thumbnail clearfix">
                                                                    <iframe width="100%" height="100%"
                                                                        allowfullscreen="allowfullscreen"
                                                                        mozallowfullscreen="mozallowfullscreen"
                                                                        msallowfullscreen="msallowfullscreen"
                                                                        oallowfullscreen="oallowfullscreen"
                                                                        webkitallowfullscreen="webkitallowfullscreen"
                                                                        src="photo3"></iframe>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                </div>
                            </section>


                        </div>

                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        </div>
    <script src="js/script.js"></script>


    <script>
        $(function () {

            $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', minDate: 0, maxDate: "+7D" });



            $("#datepicker").on("change", function () {
                var selected = $(this).val();

                $("#hiddenSearchDate").val(selected);
                $.ajax({
                    type: 'post',
                    url: 'MYMA.asmx/fn_CheckWholeSiteBlock',
                    data: {
                        ld_data: selected
                    },
                    dataType: 'json',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    success: function (data, textStatus, jqXHR) {
                        //alert(data[0].Error);
                        if (data[0].Error == 'False') {

                            window.location = 'SiteBlock.aspx?msg=' + data[0].DisplayMsg;
                        }
                        else {
                            var btn = document.getElementById('<%=lnkFillGovernorate.ClientID%>');
                            btn.click();


                        }

                        $('#cover-spin').hide(0)
                    }, error: function (data, ajaxOptions, thrownError) {
                        // alert(data.d);
                        console.log(data);
                        scope.msg = data[0].message;
                        scope.$apply();
                        scope.MsgBox();
                        $('#cover-spin').hide(0)
                    }
                });

            });




            $("#lnkSearch").click(function () {
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
            });
        });

        $('.ratingonlydet').css({ pointerEvents: "none" })


    </script>

    <script>
        $(document).ready(function () {
            $("input[name='rating']").change(function () {
                $("#hiddenMyrationSelect").val($(this).val());
                document.getElementById("<%=lnkMyrationgUpdate.ClientID%>").click();
            });

            
        });

      
       

        function MapRedirect(val) {            
            if (val === 1) {
                window.open($("#hiddenKuwaitFounderLocation").val(), '_blank');
            }
            else if (val === 2) {                
                window.open('https://www.google.com.sa/maps/search/' + $("#hiddenGoogleMapLocation").val(), '_blank');
            }
        }


        function StadiumRating(myrate,rate,fav) {          
            
            $('input[name=rating][value="' + myrate + '"]').prop('checked', true);
            $('input[name=ratingonlydet][value="' + rate + '"]').prop('checked', true);
            
            if (fav === 1)             
                $('.heart').addClass('is-active');
            else if (fav === 0)
                $('.heart').removeClass('is-active');
        }


    </script>

        <script>
            $("input[name='timeradio']").change(function () {
               // alert($(this).val());
                timeSlotID = $("input[name='timeradio']:checked").attr('id');
                var timeslot = $(this).val();            

                $('#hiddenTimeSlotID').val(timeSlotID + ',' + timeslot);
                
               // alert($('#hiddenTimeSlotID').val());
            });
        </script>


   <script type="text/javascript">
      
           function ClickFavorite() {
               document.getElementById("<%=lnk.ClientID %>").click();               
            }
      
      
       function Gettime() {
          
           if ($('input[name=timeradio]:checked').length > 0) {
               

               timeSlotID = $("input[name='timeradio']:checked").attr('id');
               var timeslot = $(this).val();

               $('#hiddenTimeSlotID').val(timeSlotID + ',' + timeslot );
               return true;
           }
           else {
               alert("Choose Time!!!");
               return false;
           }
       }
    </script>



</asp:Content>

