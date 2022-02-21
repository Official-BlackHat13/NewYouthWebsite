<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SearchStadium.aspx.cs" Inherits="SearchStadium" %>
<%@ MasterType VirtualPath="MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .bottom-right {
            position: absolute;
            bottom: 8px;
            right: 16px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

    <asp:Panel ID="pnl" runat="server">
        <div class="page_banner"></div>

        <div class="breadcrumbs1_wrapper">
            <div class="container">
                <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span> الملاعب الأكثر جحزا</div>
            </div>
        </div>


        <div id="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-3 col-xs-12">
                        <div class="sidebar-block">
                            <div class="form-group col-xs-12" style="display: none; margin: 10px" id="divmodalmsg"></div>
                            <div style="display: none" class="spinner col-xs-12" id="divmodalspin"></div>

                            <form action="javascript:void(0);">

                                <div class="col-sm-12 no-padding margin-top">
                                    <div class="input1_wrapper">
                                        <label>تاريخ الحجز</label>

                                        <div class="input1_inner">
                                            <input type="text" id="datepicker" value="<%=Dateset %>" autocomplete="off" title="اليوم/الشهر/السنة" />
                                            <asp:HiddenField ID="hiddenSearchDate" runat="server" ClientIDMode="Static" />

                                        </div>
                                    </div>
                                </div>

                                <div class="clearfix"></div>

                                <asp:UpdatePanel ID="update" runat="server">
                                    <ContentTemplate>


                                        <div class="col-sm-12 no-padding margin-top">

                                            <label for="Button2">الرياضة </label>
                                            <div class="select1_inner">
                                                 <asp:LinkButton ID="lnkFillGovernorate" ClientIDMode="Static" runat="server" CssClass="hidden" OnClick="lnkFillGovernorate_Click"></asp:LinkButton>
                                                <asp:DropDownList ID="DDLSportType" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLSportType_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>



                                        </div>

                                        <div class="clearfix"></div>

                                        <div class="clearfix"></div>


                                        <div class="col-sm-12 no-padding margin-top">

                                            <label for="Button2">المحافظة</label>
                                            <div class="select1_inner">

                                                <asp:DropDownList ID="DDLGov" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLGov_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>



                                        </div>

                                        <div class="clearfix"></div>

                                        <div class="clearfix"></div>
                                        <div class="col-sm-12 no-padding margin-top">


                                            <label for="inputEmail">منطقة</label>

                                            <div class="select1_inner">

                                                <asp:DropDownList ID="DDLArea" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>





                                        </div>

                                        <div class="clearfix"></div>
                                        <div class="col-sm-12 no-padding margin-top">

                                            <label for="inputEmail">الملعب</label>


                                            <div class="select1_inner">

                                                <asp:DropDownList ID="DDLStadium" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>



                                        </div>

                                        <div class="clearfix"></div>

                                        <div class="col-sm-12 no-padding margin-top" runat="server" visible="false">


                                            <label for="inputEmail">وقت الحجز (اختياري)</label>

                                            <div class="select1_inner">

                                                <asp:DropDownList ID="DDLTimeSlot" runat="server" CssClass="btn btn-default dropdown-toggle">
                                                </asp:DropDownList>


                                            </div>


                                        </div>

                                        <div class="clearfix"></div>

                                        <label class="col-md-6" style="padding-left: 0; padding-top: 12px;"></label>


                                        <div class="no-padding margin-top col-md-6 text-right" style="margin-top: 30px;">
                                            <%-- <button class="btn btn-default btn-cf-submit" style="width:100%;"  ng-click="OnClickSearch();">بحث</button>--%>
                                            <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-default btn-cf-submit" Style="width: 100%;" Text="بحث" OnClientClick="return lnkSearch();" OnClick="lnkSearch_Click"></asp:LinkButton>
                                        </div>
                                        <div class="clearfix"></div>

                                    </ContentTemplate>
                                    <Triggers>
                                       
                                    </Triggers>
                                </asp:UpdatePanel>

                            </form>

                        </div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>


                    </div>
                    <div class="col-sm-9 col-md-9 col-xs-12">

                        <!-- <div dir-paginate="drrpt in dtReport|itemsPerPage:9"> -->

                        <asp:UpdatePanel ID="updateData" runat="server">
                            <ContentTemplate>
                                <asp:Repeater ID="rpStadiums" runat="server" OnItemCommand="rpStadiums_ItemCommand" OnItemDataBound="rpStadiums_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-sm-4 col-xs-12">
                                                <div id="Div1" class="thumb5 " runat="server" visible='<%#Eval("Sta1") != DBNull.Value?true:false %>'>
                                                    <div class="thumbnail clearfix">
                                                        <figure>
                                                            <img src='<%#Eval("StadiumMainImage1") %>' alt="" class="img-responsive">

                                                            <div class="bottom-right">
                                                            </div>

                                                        </figure>
                                                        <div class="row">
                                                            <div class="caption col-sm-12 col-xs-12">
                                                                <label class="txt1"><%#Eval("StadiumName1") %>  </label>
                                                                <div class="txt3 clearfix">
                                                                    <fieldset class="ratingonly">
                                                                        <asp:RadioButton runat="server" ID="radio15_0" GroupName="ratingonly" ClientIDMode="Static" /><label class="full" for="Radio6" title="Awesome - 5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio14_5" GroupName="ratingonly" ClientIDMode="Static" /><label class="half" for="Radio7" title="Pretty good - 4.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio14_0" GroupName="ratingonly" ClientIDMode="Static" /><label class="full" for="Radio8" title="Pretty good - 4 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio13_5" GroupName="ratingonly" ClientIDMode="Static" /><label class="half" for="Radio9" title="Meh - 3.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio13_0" GroupName="ratingonly" ClientIDMode="Static" /><label class="full" for="Radio10" title="Meh - 3 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio12_5" GroupName="ratingonly" ClientIDMode="Static" /><label class="half" for="Radio11" title="Kinda bad - 2.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio12_0" GroupName="ratingonly" ClientIDMode="Static" /><label class="full" for="Radio12" title="Kinda bad - 2 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio11_5" GroupName="ratingonly" ClientIDMode="Static" /><label class="half" for="Radio13" title="Meh - 1.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio11_0" GroupName="ratingonly" ClientIDMode="Static" /><label class="full" for="Radio14" title="Sucks big time - 1 star"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio10_5" GroupName="ratingonly" ClientIDMode="Static" /><label class="half" for="Radio15" title="Sucks big time - 0.5 stars"></label>

                                                                    </fieldset>

                                                                </div>



                                                                <div class="txt3 clearfix col-sm-12 col-xs-12">
                                                                    <div id="Div2" class="right_side" runat="server" visible='<%#Eval("Sta1")=="Booked"?true:false%>'><a href="" class="btn-default btn4"><%#Eval("Sta1")%> </a></div>
                                                                    <div id="Div3" class="right_side" runat="server" visible='<%#Eval("Sta1")=="Booked"?false:true%>'>
                                                                        <asp:LinkButton ID="lnkAvailble" runat="server" CommandArgument='<%#Eval("StadiumID1") %>' CommandName="stadiumResult" OnClientClick="return lnkSearch();" CssClass="btn-default btn1" Text="التفاصيل"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-4 col-xs-12">
                                                <div id="Div4" class="thumb5" runat="server" visible='<%#Eval("Sta2") != DBNull.Value ?true:false %>'>
                                                    <div class="thumbnail clearfix">
                                                        <figure>
                                                            <img src='<%#Eval("StadiumMainImage2") %>' alt="" class="img-responsive">
                                                        </figure>
                                                        <div class="row">
                                                            <div class="caption col-sm-12 col-xs-12">
                                                                <label class="txt1"><%#Eval("StadiumName2") %> <%-- {{drrpt.StadiumName2}}--%> </label>
                                                                <div class="txt3 clearfix">
                                                                    <fieldset class="ratingonlytwo">

                                                                        <asp:RadioButton runat="server" ID="Radio25_0" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="full" for="Radio6" title="Awesome - 5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio24_5" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="half" for="Radio7" title="Pretty good - 4.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio24_0" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="full" for="Radio8" title="Pretty good - 4 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio23_5" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="half" for="Radio9" title="Meh - 3.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio23_0" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="full" for="Radio10" title="Meh - 3 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio22_5" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="half" for="Radio11" title="Kinda bad - 2.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio22_0" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="full" for="Radio12" title="Kinda bad - 2 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio21_5" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="half" for="Radio13" title="Meh - 1.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio21_0" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="full" for="Radio14" title="Sucks big time - 1 star"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio20_5" GroupName="ratingonlytwo" ClientIDMode="Static" /><label class="half" for="Radio15" title="Sucks big time - 0.5 stars"></label>

                                                                    </fieldset>

                                                                </div>
                                                                <div class="txt3 clearfix col-sm-12 col-xs-12">

                                                                    <div id="Div5" class="right_side" runat="server" visible='<%#Eval("Sta2")=="Booked"?true:false%>'><a href="" class="btn-default btn4"><%#Eval("Sta2") %></a></div>
                                                                    <div id="Div6" class="right_side" runat="server" visible='<%#Eval("Sta1")=="Booked"?false:true%>'>
                                                                        <asp:LinkButton ID="lnkAvailable2" runat="server" CssClass="btn-default btn1" Text="التفاصيل" CommandArgument='<%#Eval("StadiumID2") %>' CommandName="stadiumResult" OnClientClick="return lnkSearch();"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-4 col-xs-12">
                                                <div id="Div7" class="thumb5" runat="server" visible='<%#Eval("Sta3") != DBNull.Value?true:false %>'>
                                                    <div class="thumbnail clearfix">
                                                        <figure>
                                                            <img src='<%#Eval("StadiumMainImage3") %>' alt="" class="img-responsive">
                                                        </figure>
                                                        <div class="row">
                                                            <div class="caption col-sm-12 col-xs-12">
                                                                <label class="txt1"><%#Eval("StadiumName3") %> <%--{{drrpt.StadiumName3}}--%> </label>
                                                                <div class="txt3 clearfix">
                                                                    <fieldset class="ratingonlythree">
                                                                        <asp:RadioButton runat="server" ID="Radio35_0" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="full" for="Radio6" title="Awesome - 5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio34_5" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="half" for="Radio7" title="Pretty good - 4.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio34_0" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="full" for="Radio8" title="Pretty good - 4 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio33_5" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="half" for="Radio9" title="Meh - 3.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio33_0" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="full" for="Radio10" title="Meh - 3 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio32_5" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="half" for="Radio11" title="Kinda bad - 2.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio32_0" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="full" for="Radio12" title="Kinda bad - 2 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio31_5" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="half" for="Radio13" title="Meh - 1.5 stars"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio31_0" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="full" for="Radio14" title="Sucks big time - 1 star"></label>
                                                                        <asp:RadioButton runat="server" ID="Radio30_5" GroupName="ratingonlythree" ClientIDMode="Static" /><label class="half" for="Radio15" title="Sucks big time - 0.5 stars"></label>

                                                                    </fieldset>


                                                                </div>
                                                                <div class="txt3 clearfix col-sm-12 col-xs-12">

                                                                    <div id="Div8" class="right_side" runat="server" visible='<%#Eval("Sta3")=="Booked"?true:false%>'><a href="" class="btn-default btn4"><%#Eval("Sta3") %><%-- {{drrpt.Sta3 }}--%></a></div>
                                                                    <div id="Div9" class="right_side" runat="server" visible='<%#Eval("Sta3")=="Booked"?false:true%>'>
                                                                        <asp:LinkButton ID="lnkAvilable3" runat="server" CssClass="btn-default btn1" Text="التفاصيل" CommandArgument='<%#Eval("StadiumID3") %>' CommandName="stadiumResult" OnClientClick="return lnkSearch();"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </ContentTemplate>
                        </asp:UpdatePanel>





                        <%--</div>--%>


                        <dir-pagination-controls
                            max-size="5"
                            direction-links="true"
                            boundary-links="true">
                        </dir-pagination-controls>


                    </div>
                </div>


            </div>
        </div>



        <script>
            $('.dropdown-menu').find('input').click(function (e) {
                e.stopPropagation();
            });


        </script>
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
            });

            $('.ratingonly').css({ pointerEvents: "none" })
            $('.ratingonlythree').css({ pointerEvents: "none" })
            $('.ratingonlytwo').css({ pointerEvents: "none" })



        </script>

        <script>
            $(function () {
                $(".heart").on("click", function () {
                    $(this).toggleClass("is-active");
                });
            });
        </script>

        <script>
            function lnkSearch() {

                if ($.trim($('#datepicker').val()).length == 0) {
                    $('#divmodalmsg').html('<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء اختيار التاريخ </strong> </div>');
                    $('#divmodalmsg').show();
                    return false;
                }
                return true;
            }
        </script>

    </asp:Panel>

</asp:Content>

