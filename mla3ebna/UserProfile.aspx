<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Profile1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">



  <style>
      /*.breadcrumbs1_wrapper {
          margin-top: 220px;
      }*/
      #content {
          background-color:none !important;
      }

      breadcrumbs1_wrapper

      .fa-circle:before {
          display:none;
      }
      #content {
          padding-top:0px;
      }

      .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus {

          background-color: #4cb050;
      }

      /*.tab-content-left {
          width: 75%;
          left: 0;
          position: absolute;
      }*/



       /*.nav-tabs-dropdown {
            display: none;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

            .nav-tabs-dropdown:before {
                content: "\e114";
                font-family: 'Glyphicons Halflings';
                position: absolute;
                right: 30px;
            }

        @media screen and (min-width: 769px) {
            #nav-tabs-wrapper {
                display: block!important;
            }
        }

        @media screen and (max-width: 768px) {
            .nav-tabs-dropdown {
                display: block;
            }

            #nav-tabs-wrapper {
                display: none;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
                text-align: center;
            }

            .nav-tabs-horizontal {
                min-height: 20px;
                padding: 19px;
                margin-bottom: 20px;
                background-color: #f5f5f5;
                border: 1px solid #e3e3e3;
                border-radius: 4px;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
            }

                .nav-tabs-horizontal > li {
                    float: none;
                }

                    .nav-tabs-horizontal > li + li {
                        margin-left: 2px;
                    }

                    .nav-tabs-horizontal > li,
                    .nav-tabs-horizontal > li > a {
                        background: transparent;
                        width: 100%;
                    }

                        .nav-tabs-horizontal > li > a {
                            border-radius: 4px;
                        }

                        .nav-tabs-horizontal > li.active > a,
                        .nav-tabs-horizontal > li.active > a:hover,
                        .nav-tabs-horizontal > li.active > a:focus {
                            color: #ffffff;
                            background-color: #428bca;
                        }
        }*/

  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div class="not-front">


       
        <div class="page_banner"></div>

            <div id="content" style="direction:rtl;">

                <div class="breadcrumbs1_wrapper">
            <div class="container">
                <div class="breadcrumbs1">
                    <a href="index.aspx">الرئيسية</a>
                    <span>/</span>حسابي
                </div>
            </div>
        </div>

            <div class="container">

             <div class="row">
                 <div class="col-md-12">
                        <h3>حسابي</h3>
                        <hr />
                 </div>
                </div>

                   

                            <div class="row">
                                <div class="col-sm-3">
                                
                                    <ul id="nav-tabs-wrapper" class="nav nav-tabs tabs-left nav-pills nav-stacked well">
                                        <li class="active show"><a href="#vtab1" data-toggle="tab">تحديث الملف </a></li>
                                        <li><a href="#vtab2" data-toggle="tab">حجوزاتي  </a></li>
                                        <li><a href="#vtab3" data-toggle="tab">الحجز السابق </a></li>
                                        <li><a href="#vtab4" data-toggle="tab">إلغاء </a></li>
                                        <li><a href="#vtab5" data-toggle="tab">المحفظة </a></li>
                                        <li><a href="#vtab6" data-toggle="tab">الملاعب المفضلة </a></li>
                                        <li><a href="#vtab7" data-toggle="tab">تغيير كلمة السر </a></li>
                                        <li style="display:none;"><a href="#vtab8" data-toggle="tab">إضافة صديق </a></li>
                                        <li>
                                            <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Text="خروج">  </asp:LinkButton>
                                          

                                        </li>


                                    </ul>
                                </div>


                                <div class="col-sm-9 tab-content-left">

                                    <div class="tab-content">

                                        <div role="tabpanel" class="tab-pane active in" id="vtab1">
                                            <asp:HiddenField ID="hdGov" runat="server" />
                                            <asp:HiddenField ID="hdArea" runat="server" />
                                            <asp:HiddenField ID="hdGender" runat="server" />

                                            <h3 class="line">تفاصيل الحجز</h3>

                                            <div class="control-group col-md-12 col-xs-12" dir="rtl">
                                                <div style="text-align: right; float: right; margin-right: 10px; color: #6dacc2; padding-top: 20px;" dir="rtl">
                                                    <label>اللإسم</label>
                                                </div>

                                                <div class="col-md-6 col-xs-6" style="text-align: center; padding-right: 0; padding-left: 0; padding-top: 20px;" dir="rtl">
                                                    <span class="red">
                                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                                        <%--{{dtProfile[0].Name}}--%> </span>
                                                </div>
                                            </div>


                                            <div class="control-group col-md-12 col-xs-12" dir="rtl">
                                                <div style="text-align: right; float: right; margin-right: 10px; color: #6dacc2; padding-top: 20px;" dir="rtl">
                                                    <label>الهاتف النقال</label>
                                                </div>

                                                <div class="col-md-6 col-xs-6" style="text-align: center; padding-right: 0; padding-left: 0; padding-top: 20px;" dir="rtl">
                                                    <span class="red">
                                                        <asp:Label ID="lblphone" runat="server"></asp:Label>
                                                        <%--<%#Eval("Phone") %>--%> <%--{{dtProfile[0].Phone}}--%> </span>
                                                </div>
                                            </div>

                                            <div class="control-group col-md-12 col-xs-12" dir="rtl">
                                                <div style="text-align: right; float: right; margin-right: 10px; color: #6dacc2; padding-top: 20px;" dir="rtl">
                                                    <label>البريد الالكتروني</label>
                                                </div>

                                                <div class="col-md-6 col-xs-6" style="text-align: center; padding-right: 0; padding-left: 0; padding-top: 20px;" dir="rtl">
                                                    <span class="red">
                                                        <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                        <%--{{dtProfile[0].Email}}--%> </span>
                                                </div>
                                            </div>


                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab2">
                                            <%--    <div class="col-md-3" /> --%>
                                            <%-- <div class="clearfix" />--%>
                                            <h3 class="line">حجوزاتي</h3>
                                            <p>
                                                <table class="table table-striped table-bordered table-responsive" style="direction: rtl">
                                                    <thead>
                                                        <tr>
                                                            <th style="display: none">stdid</th>
                                                            <th style="display: none">bookid</th>
                                                            <th>#</th>
                                                            <th>التاريخ</th>
                                                            <th>التوقيت </th>
                                                            <th>الملعب </th>
                                                            <th>النوع </th>
                                                            <th>توقيت تاريخ الحجز </th>
                                                            <th>إلغاء</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>



                                                        <asp:Repeater ID="rpReservation" runat="server" OnItemCommand="rpReservation_ItemCommand" OnItemDataBound="rpReservation_ItemDataBound">
                                                            <ItemTemplate>
                                                                <tr>

                                                                    <td style="display: none;"><%#Eval("StadiumID") %> </td>
                                                                    <td style="display: none;"><%#Eval("BookingID") %> </td>
                                                                    <td><%#Eval("SlNo") %> </td>
                                                                    <td><%#Eval("bookingdate","{0:d}") %> </td>
                                                                    <td><%#Eval("bookingtime") %> </td>
                                                                    <td><%#Eval("StadiumName") %> </td>
                                                                    <td><%#Eval("StadiumType") %> </td>
                                                                    <td><%#Eval("BookDT") %>  </td>

                                                                    <td>
                                                                        
                                                                        <asp:LinkButton ID="lnkCancekBooking" runat="server" CssClass="btn btn-default btn-cf-submit"
                                                                            CommandArgument='<%# String.Format("{0}:{1}", Eval("StadiumID"), Eval("BookingID")) %>' CommandName="bCancel" Text="Cancel"></asp:LinkButton>
                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>                                                
                                            </p>
                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab3">
                                            <h3 class="line">الحجز السابق</h3>
                                            <table class="table table-striped table-bordered table-responsive" style="direction: rtl">
                                                <thead>
                                                    <tr>
                                                       <%-- <th style="display: none">stdid</th>
                                                        <th style="display: none">bookid</th>--%>
                                                        <th>#</th>
                                                        <th>التاريخ</th>
                                                        <th>التوقيت </th>
                                                        <th>الملعب </th>
                                                        <th>النوع </th>
                                                        <th>توقيت تاريخ الحجز </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rpPastReservation" runat="server">
                                                        <ItemTemplate>
                                                            <tr>

                                                                <%--<td style="display: none"><%#Eval("StadiumID") %> </td>
                                                                <td style="display: none"><%#Eval("BookingID") %> </td>--%>
                                                                <td><%--{{drPast.SlNo}}--%>  <%#Eval("SlNo") %>  </td>
                                                                <td><%--{{drPast.bookingdate}} --%> <%#Eval("bookingdate") %>  </td>
                                                                <td><%--{{drPast.bookingtime}}--%>   <%#Eval("bookingtime") %>   </td>
                                                                <td><%--{{drPast.StadiumName}} --%>  <%#Eval("StadiumName") %>   </td>
                                                                <td><%--{{drPast.StadiumType}}--%>  <%#Eval("StadiumType") %>  </td>
                                                                <td><%--{{drPast.BookDT}}--%>  <%#Eval("BookDT") %>  </td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </tbody>
                                            </table>
                                            

                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab4">
                                            <h3 class="line">إلغاء</h3>

                                            <table class="table table-striped table-bordered table-responsive" style="direction: rtl">
                                                <thead>
                                                    <tr>
                                                        <th style="display: none">stdid</th>
                                                        <th style="display: none">bookid</th>
                                                        <th>#</th>
                                                        <th>تاريخ الحجز</th>
                                                        <th>التوقيت </th>
                                                        <th>تاريخ الإلغاء</th>
                                                        <th>المبلغ الإلغاء</th>
                                                        <th>الملعب </th>
                                                        <th>النوع </th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rpBookingCancellation" runat="server">
                                                        <ItemTemplate>

                                                            <tr>
                                                                <td style="display: none"><%--{{drReCan.StadiumID}}--%>  <%#Eval("StadiumID") %> </td>
                                                                <td style="display: none"><%--{{drReCan.BookingID}}--%>  <%#Eval("BookingID") %></td>
                                                                <td><%--{{drReCan.SlNo}}--%>  <%#Eval("SlNo") %> </td>
                                                                <td><%--{{drReCan.bookingdate}}--%>  <%#Eval("bookingdate") %> </td>
                                                                <td><%--{{drReCan.bookingtime}}--%>  <%#Eval("bookingtime") %> </td>
                                                                <td><%--{{drReCan.canceldate}}--%>  <%#Eval("canceldate") %> </td>
                                                                <td><%--{{drReCan.amount}}--%>  <%#Eval("amount") %> </td>
                                                                <td><%--{{drReCan.StadiumName}} --%>  <%#Eval("StadiumName") %> </td>
                                                                <td><%--{{drReCan.StadiumType}}--%>   <%#Eval("StadiumType") %></td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>

                                                </tbody>
                                            </table>
                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab5">
                                            <h3 class="line">المحفظة</h3>
                                            <table class="table table-striped table-bordered table-responsive" style="direction: rtl">
                                                <thead>
                                                    <tr>
                                                        <th style="display: none">stdid</th>
                                                        <th style="display: none">bookid</th>
                                                        <th>#</th>
                                                        <th>نوع المحفظة </th>
                                                        <th>تاريخ المحفظة </th>
                                                        <th>مبلغ المحفظة </th>
                                                        <th>الملعب </th>
                                                        <th>النوع </th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rpWallet" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="display: none"><%--{{drWallet.StadiumID}}--%> <%#Eval("StadiumID") %> </td>
                                                                <td style="display: none"><%--{{drWallet.BookingID}}--%> <%#Eval("BookingID") %> </td>
                                                                <td><%--{{drWallet.SlNo}}--%> <%#Eval("SlNo") %> </td>
                                                                <td><%--{{drWallet.typeofcredit}}--%> <%#Eval("typeofcredit") %> </td>
                                                                <td><%--{{drWallet.paymentdate}}--%> <%#Eval("paymentdate") %> </td>
                                                                <td><%--{{drWallet.amount}}--%>  <%#Eval("amount") %></td>
                                                                <td><%--{{drWallet.StadiumName}}--%> <%#Eval("StadiumName") %> </td>
                                                                <td><%--{{drWallet.StadiumType}}--%> <%#Eval("StadiumType") %> </td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </tbody>
                                            </table>
                                            <h3>مبلغ المحفظة  : <asp:Label ID="lblwalletAmt" runat="server" Visible="true"></asp:Label> <%--{{walletAmt}}--%></h3>
                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab6">
                                            <h3 class="line">الملاعب المفضلة</h3>
                                            <table class="table table-striped table-bordered table-responsive" style="direction: rtl">
                                                <thead>
                                                    <tr>
                                                        <th style="display: none">stdid</th>
                                                        <th style="width: 10%">#</th>
                                                        <th style="width: 90%">الملعب </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rpFavourate" runat="server" OnItemCommand="rpFavourate_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="display: none"><%#Eval("StadiumId") %>  <%--{{drFav.StadiumId}}--%> </td>
                                                                <td><%#Eval("SlNo") %>  <%--{{drFav.SlNo}}--%> </td>
                                                                <td>
                                                                    <%--<a href="" ng-click="OnClickFavorite(drFav.StadiumId);">{{drFav.StadiumName}}</a>--%>
                                                                    <asp:LinkButton ID="lnkFavorateStadium" runat="server" CommandArgument='<%#Eval("StadiumID") %>' CommandName="redirect" Text='<%#Eval("StadiumName") %>'></asp:LinkButton>

                                                                </td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </tbody>
                                            </table>
                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab7">
                                            <h3 class="line">تغيير كلمة السر </h3>
                                            <div id="fields">
                                                <form id="ajax-contact-form" class="form-horizontal">
                                                    <div class="login-box">
                                                        <div class="form-group" style="margin: 10px" id="divmodalmsgpwd" runat="server" visible="false"></div>
                                                        <div style="display: none" class="text-center" id="divmodalspinpwd" runat="server"><i class="ace-icon fa fa-spinner fa-spin orange bigger-300"></i></div>
                                                        <div class="form-group">
                                                            <label for="txtoldpwd">كلمة المرور السابقة </label>
                                                            <%--<input type="password" class="form-control" ng-model="oldPassword" id="txtoldpwd" placeholder="كلمة المرور السابقة "   autocomplete="off"/>--%>
                                                            <asp:TextBox ID="txtoldpwd" runat="server" TextMode="Password" CssClass="form-control" placeholder=" كلمة المرور السابقة " autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="req1" runat="server" ValidationGroup="pwd" ControlToValidate="txtoldpwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtnewpwd">New Password</label>
                                                            <%--<input type="password" class="form-control" ng-model="newPassword" id="txtnewpwd" placeholder="كلمة المرور الجديدة"   autocomplete="off"/>--%>
                                                            <asp:TextBox ID="txtnewpwd" runat="server" TextMode="Password" CssClass="form-control" placeholder=" كلمة المرور الجديدة " autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="pwd" runat="server" ControlToValidate="txtnewpwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="txtrepwd">Confirm your Password</label>
                                                            <%--<input type="password" class="form-control" ng-model="rePassword" id="txtrepwd" placeholder="تأكيد كلمة المرور "  autocomplete="off"/>--%>
                                                            <asp:TextBox ID="txtrepwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="تأكيد كلمة المرور" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="pwd" runat="server" ControlToValidate="txtrepwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="comp1" runat="server" ValidationGroup="pwd" ControlToValidate="txtrepwd" ControlToCompare="txtnewpwd"
                                                                SetFocusOnError="true" CssClass="text-danger" ErrorMessage="Password Should match"></asp:CompareValidator>
                                                        </div>


                                                        <%--<button type="submit" class="btn-default btn-cf-submit" ng-click="btnSubmit();">إرسال </button>--%>
                                                        <asp:LinkButton ID="lnkChangePwd" runat="server" ValidationGroup="pwd" OnClientClick="showspin();" CssClass="btn-default btn-cf-submit" Text="إرسال" OnClick="lnkChangePwd_Click"></asp:LinkButton>
                                                        <%-- <span class="text-danger" style="color:red">{{ erroMessage }}</span>--%>
                                                    </div>


                                                </form>
                                            </div>
                                        </div>

                                        <div role="tabpanel" class="tab-pane fade" id="vtab8">
                                            <h3>تسجيل الدخول </h3>
                                            <div id="Div1">
                                                <div id="ajax-contact-form3" class="form-horizontal">
                                                    <div class="login-box">

                                                        <div style="" class="spinner" id="divmodalspin" runat="server" visible="false"></div>
                                                        <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>


                                                       <%-- <p>Refer Your Friends. One of them are must be in your own area.</p>--%>
                                                        <p> قم بإضافة اصدقائك ، على الاقل صديق واحد ينتمي لنفس المنطقة السكنية </p>

                                                        <asp:UpdatePanel ID="update1" runat="server">
                                                            <ContentTemplate>




                                                                <div class="form-group row" style="height: 0px; margin-bottom: 0px;">
                                                                    <div class="col-sm-4"></div>
                                                                    <div class="col-sm-6" style="height: 2px; margin-bottom: 10px;">
                                                                        <div class="form-group" style="color: red; font-size: x-small;" id="divmsgc1" runat="server"></div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group row" style="margin-bottom: 10px;">
                                                                    <label for="colFormLabelLg" class="col-sm-3">البطاقة المدنية (1)</label>
                                                                    <div class="col-sm-1">
                                                                        <%--<button id="btnpl1" type="button" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',1)">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>--%>
                                                                        <asp:LinkButton ID="lnkFirstPlus" ClientIDMode="Static" runat="server" CssClass="btn btn-success btn-number" OnClick="lnkFirstPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                                                        </asp:LinkButton>

                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                        <div class="form-group" style="display: none; color: red; font-size: xx-small;" id="div2"></div>
                                                                        <%--<input type="text" class="form-control" ng-model="reg.civilID1" id="txtcivil1"   maxlength="12" value="الرقم المدني" >--%>
                                                                        <asp:TextBox ID="txtFirstCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="الرقم المدني"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFirstCivilID"
                                                                            SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator
                                                                            EnableClientScript="true"
                                                                            ID="RegularExpressionValidator5" runat="server"
                                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                            ValidationGroup="profileupdate"
                                                                            ControlToValidate="txtFirstCivilID" Display="dynamic"
                                                                            ValidationExpression="^[0-9]{12}$"
                                                                            CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                    <div class="col-sm-2">
                                                                        <img src="images\cross.jpg" alt="Right" style="width: 40px; height: 40px;" id="c1err" runat="server" visible="false" />
                                                                        <img src="images\tick.jpg" alt="Right" style="width: 40px; height: 40px;" id="c1suc" runat="server" visible="false" />
                                                                        <button type="button" data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" id="c1inv" runat="server" visible="false">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                                                    </div>


                                                                </div>

                                                                <div id="divciv2" runat="server" visible="false">
                                                                    <div class="form-group row" style="height: 0px; margin-bottom: 0px;">
                                                                        <div class="col-sm-4"></div>
                                                                        <div class="col-sm-6" style="height: 2px; margin-bottom: 10px;">
                                                                            <div class="form-group" style="color: red; font-size: x-small;" id="divmsgc2" runat="server" visible="false"></div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group row" style="margin-bottom: 10px;">
                                                                        <label for="colFormLabelLg" class="col-sm-3">البطاقة المدنية (2)</label>

                                                                        <div class="col-sm-1">
                                                                            <%--  <button type="button" id="btnpl2" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',2)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>

                                                                            <asp:LinkButton ID="lnkSecondPlus" ClientIDMode="Static" runat="server" CssClass="btn btn-success btn-number" OnClick="lnkSecondPlus_Click">
                                                   <span class="glyphicon glyphicon-plus"></span>
                                                                            </asp:LinkButton>
                                                                        </div>

                                                                        <div class="col-sm-5">

                                                                            <asp:TextBox ID="txtSecondCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="12" autocomplete="false" placeholder="الرقم المدني"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtSecondCivilID"
                                                                                SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator4" runat="server"
                                                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                                ValidationGroup="profileupdate"
                                                                                ControlToValidate="txtSecondCivilID" Display="dynamic"
                                                                                ValidationExpression="^[0-9]{12}$"
                                                                                CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',2)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>

                                                                            <asp:LinkButton ID="lnkSecondMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkSecondMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <img src="images\cross.jpg" alt="Right" style="width: 40px; height: 40px;" id="c2err" runat="server" visible="false" />
                                                                            <img src="images\tick.jpg" alt="Right" style="width: 40px; height: 40px;" id="c2suc" runat="server" visible="false" />
                                                                            <button type="button" data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c2inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                                <div id="divciv3" runat="server" visible="false">
                                                                    <div class="form-group row" style="height: 0px; margin-bottom: 0px;">
                                                                        <div class="col-sm-4"></div>
                                                                        <div class="col-sm-6" style="height: 2px; margin-bottom: 10px;">
                                                                            <div class="form-group" style="color: red; font-size: x-small;" id="divmsgc3" runat="server" visible="false"></div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group row" style="margin-bottom: 10px;" id="">
                                                                        <label for="colFormLabelLg" class="col-sm-3"> البطاقة المدنية (3)</label>
                                                                        <div class="col-sm-1">
                                                                            <%-- <button type="button" id="btnpl3"  class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',3)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>
                                                                            <asp:LinkButton ID="lnkThirdPlus" runat="server" ClientIDMode="Static" CssClass="btn btn-success btn-number" OnClick="lnkThirdPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                                                            </asp:LinkButton>

                                                                        </div>
                                                                        <div class="col-sm-5">
                                                                            <%--<input type="text" class="form-control" ng-model="reg.civilID3" id="txtcivil3"  maxlength="12" value="الرقم المدني" >--%>
                                                                            <asp:TextBox ID="txtThirdCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="الرقم المدني"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtThirdCivilID"
                                                                                SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator3" runat="server"
                                                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                                ValidationGroup="profileupdate"
                                                                                ControlToValidate="txtThirdCivilID" Display="dynamic"
                                                                                ValidationExpression="^[0-9]{12}$"
                                                                                CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',3)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>
                                                                            <asp:LinkButton ID="lnkThirdMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkThirdMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                                            </asp:LinkButton>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <img src="images\cross.jpg" alt="Right" style="width: 40px; height: 40px;" id="c3err" runat="server" visible="false" />
                                                                            <img src="images\tick.jpg" alt="Right" style="width: 40px; height: 40px;" id="c3suc" runat="server" visible="false" />
                                                                            <button type="button" data-toggle="modal" data-target="#modalEmail" class="btn btn-success" runat="server" visible="false" id="c3inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                                <div id="divciv4" runat="server" visible="false">
                                                                    <div class="form-group row" style="height: 0px; margin-bottom: 0px;">
                                                                        <div class="col-sm-4"></div>
                                                                        <div class="col-sm-6" style="height: 2px; margin-bottom: 10px;">
                                                                            <div class="form-group" style="color: red; font-size: x-small;" id="divmsgc4" runat="server" visible="false"></div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group row" style="margin-bottom: 10px;" id="Div3">
                                                                        <label for="colFormLabelLg" class="col-sm-3"> البطاقة المدنية (4)</label>
                                                                        <div class="col-sm-1">
                                                                            <%-- <button type="button" id="btnpl4" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',4)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>
                                                                            <asp:LinkButton ID="lnkFourthPlus" runat="server" ClientIDMode="Static" CssClass="btn btn-success btn-number" OnClick="lnkFourthPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-sm-5">
                                                                            <%--<input type="text" class="form-control" ng-model="reg.civilID4" id="txtcivil4"   maxlength="12" value="الرقم المدني"  >--%>
                                                                            <asp:TextBox ID="txtFourthCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="الرقم المدني"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFourthCivilID"
                                                                                SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator2" runat="server"
                                                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                                ValidationGroup="profileupdate"
                                                                                ControlToValidate="txtFourthCivilID" Display="dynamic"
                                                                                ValidationExpression="^[0-9]{12}$"
                                                                                CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <%--   <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',4)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>

                                                                            <asp:LinkButton ID="lnkFourthMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkFourthMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <img src="images\cross.jpg" alt="Right" style="width: 40px; height: 40px;" id="c4err" runat="server" visible="false" />
                                                                            <img src="images\tick.jpg" alt="Right" style="width: 40px; height: 40px;" id="c4suc" runat="server" visible="false" />
                                                                            <button type="button" data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c4inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div id="divciv5" runat="server" visible="false">
                                                                    <div class="form-group row" style="height: 0px; margin-bottom: 0px;">
                                                                        <div class="col-sm-4"></div>
                                                                        <div class="col-sm-6" style="height: 2px; margin-bottom: 10px;">
                                                                            <div class="form-group" style="color: red; font-size: x-small;" id="divmsgc5" runat="server" visible="false"></div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group row" style="margin-bottom: 10px;" id="Div4">

                                                                        <label for="colFormLabelLg" class="col-sm-3"> البطاقة المدنية (5)</label>
                                                                        <div class="col-sm-1">
                                                                            <!-- <button type="button" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>-->
                                                                            <%-- <asp:LinkButton ID="lnkFifthPlus" runat="server" CssClass="btn btn-success btn-number">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>--%>
                                                                        </div>
                                                                        <div class="col-sm-5">
                                                                            <%--<input type="text" class="form-control" ng-model="reg.civilID5" id="txtcivil5" maxlength="12" value="الرقم المدني" >--%>
                                                                            <asp:TextBox ID="txtFifthCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="الرقم المدني"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rer5" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFifthCivilID"
                                                                                SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator1" runat="server"
                                                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                                ValidationGroup="profileupdate"
                                                                                ControlToValidate="txtFifthCivilID" Display="dynamic"
                                                                                ValidationExpression="^[0-9]{12}$"
                                                                                CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="col-sm-1">
                                                                            <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',5)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>
                                                                            <asp:LinkButton ID="lnlFifthMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnlFifthMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <img src="images\cross.jpg" alt="Right" style="width: 40px; height: 40px;" id="c5err" runat="server" visible="false" />
                                                                            <img src="images\tick.jpg" alt="Right" style="width: 40px; height: 40px;" id="c5suc" runat="server" visible="false" />
                                                                            <button type="button" data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c5inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <%--<button type="submit" class="btn-default btn-cf-submit" ng-click="btnSubmit('Profile');">Update Your Profile</button>--%>
                                                                <asp:LinkButton ID="lnkUpdate" runat="server" ClientIDMode="Static" ValidationGroup="profileupdate" CssClass="btn-default btn-cf-submit" Text="تحديث الحساب" OnClick="lnkUpdate_Click"></asp:LinkButton>
                                                            </ContentTemplate>
                                                            <Triggers>                                                          
                                                               
                                                                 <asp:AsyncPostBackTrigger ControlID="lnkFirstPlus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnkSecondPlus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnkThirdPlus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnkFourthPlus" />

                                                                <asp:AsyncPostBackTrigger ControlID="lnkSecondMinus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnkThirdMinus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnkFourthMinus" />
                                                                <asp:AsyncPostBackTrigger ControlID="lnlFifthMinus" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                          
                                </div>

                    </div>



            </div>
        </div>


        <!--<script src="js/bootstrap.min.js"></script>-->


    <!-- Modal -->
    <div class="modal fade" id="modalEmail" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">اختيار التاريخ </h5>

                </div>
                <div style="display: none;" class="spinner" id="divmodalspinmodal" runat="server"></div>
                <asp:UpdatePanel ID="up" runat="server">
                    <ContentTemplate>
                        <div class="form-group" style="margin: 10px" id="divmodalmsgmodal" runat="server" visible="false"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-body" style="direction: ltr;">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <label for="colFormLabelLg" class="col-sm-12">Your Friend Email</label>
                        </div>

                        <div class="col-md-6" id="dividmodal">
                            <%--<input type="text" name="txtemail" ng-model="friendemail" value=""/>--%>
                            <asp:TextBox ID="txtfriendEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="email" SetFocusOnError="true" Display="Dynamic"
                                ControlToValidate="txtfriendEmail" CssClass="text-danger" ErrorMessage="required"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                ControlToValidate="txtfriendEmail" CssClass="text-danger" Display="dynamic"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                            <%-- <input type="text" style="display:none;" name="bookId" value=""/>--%>
                        </div>
                    </div>
                </div>

                <br />
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-success" ng-click="SendEmail();">Send Email<i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>--%>
                    <asp:UpdatePanel ID="sendmail" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkSendmail" runat="server" CssClass="btn btn-success" ValidationGroup="email" OnClientClick="showspin();" ClientIDMode="Static" OnClick="lnkSendmail_Click">Send Email<i class="fa fa-paper-plane-o" aria-hidden="true"></i></asp:LinkButton>
                        </ContentTemplate>
                        <%-- <Triggers>
                  <asp:PostBackTrigger ControlID="lnkSendmail" />
              </Triggers>--%>
                    </asp:UpdatePanel>

                    <button type="button" class="btn btn-secondary" data-dismiss="modal">إغلاق </button>

                    <!-- <button type="button" class="btn btn-primary">Save changes</button>-->
                </div>
            </div>
        </div>
    </div>




    <script type="text/javascript">
        function showspin() {
            document.getElementById("divmodalspinpwd").style.display = "block";
        }

      



    
    </script>



</asp:Content>

