<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_MemberDetails.aspx.cs" Inherits="StadiumCMS_View_MemberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        
        .btnBig
        {
            font-size: 20px !important;
            vertical-align: top !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">Members</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="عرض"></asp:Label>
            </span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <div class="element-actions">
                            </div>

                        </div>
                        <h6 class="element-header">Members</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="LabUserID" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="الملف الشخصي"></asp:Label>
                            </h6>
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">الاسم الثلاثي : </span>
                                    <asp:Label ID="LabFullName" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">اسم المستخدم : </span>
                                    <asp:Label ID="LabUsername" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">الرقم المدني : </span>
                                    <asp:Label ID="LabCivilID" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">المحافظة : </span>
                                    <asp:Label ID="LabGovernorate" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">البريد الإلكتروني : </span>
                                    <asp:Label ID="LabEmail" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">رقم الهاتف النقال : </span>
                                    <asp:Label ID="LabPhone" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <%--  <div class="row">
                              
                            </div>
                            <br />--%>
                            <div class="row">

                                <div class="col-lg-6">
                                    <span class="labdetails">حالة الحساب : </span>
                                    <asp:Label ID="LabStatus" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">حالة الحظر : </span>
                                    <asp:Label ID="LabBanStatus" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <%--   <div class="row">
                               
                            </div>
                            <br />--%>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4">

                    <div class="property-single">
                        <div class="property-info-w">
                            <div class="property-info-side">

                                <div class="side-section">
                                    <script type="text/javascript">

                                        function openWinPrint(id) {
                                           
                                            window.open("Print_Members.aspx?UserID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");                                           
                                        
                                        }


                                        function openWinBookingPrint(id) {

                                            window.open("Print_MemberBookings.aspx?UserID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");                                   
                                        }


                                    </script>
                                    <%-- <div class="side-section-header">
                                        Facts and Features
                                    </div>--%>
                                    <div class="side-section-content">
                                        <div class="property-side-features">
                                            <%-- <div class="feature">
                                                <asp:LinkButton ID="lnkEdit" CssClass="" runat="server" OnClick="lnkEdit_Click"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل &nbsp;</span></asp:LinkButton>

                                            </div>--%>
                                            <div class="feature" runat="server" id="DivlnkDelete">
                                                <asp:LinkButton ID="lnkDelete"  runat="server" OnClick="lnkDelete_Click"><i class="fa fa-trash"></i><span>&nbsp; حذف &nbsp;</span></asp:LinkButton>

                                            </div>

                                            <%--   <div class="feature">
                                                <a href='Assign_GaurdToStadium.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Assign Gaurd To Stadium">
                                                    <i class="os-icon os-icon-user-male-circle2"></i>&nbsp;&nbsp;Gaurd</a>
                                               
                                            </div>
                                            <div class="feature">
                                                <a href='Manage_StadiumGallery.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Manage Stadium Gallery">
                                                    <i class="os-icon os-icon-documents-07"></i>&nbsp;&nbsp;Gallery</a>

                                            </div>
                                            <div class="feature">
                                                <a href='Manage_StadiumVideos.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Manage Stadium Videos">
                                                    <i class="os-icon os-icon-others-29"></i>&nbsp;&nbsp;Videos</a>
                                              
                                            </div>--%>
                                            <div class="feature"><%=StrPrintbtn %></div>
                                            <div class="feature">
                                                <a class="" href="View_Members.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
                                            </div>
                                            <%-- <div class="feature">
                                                <i class="os-icon os-icon-home-10"></i><span>Washer and Dryer</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="element-wrapper  pt-2" id="PanFollowUpView" runat="server">
                <div class="element-actions d-none d-sm-block">                    
                    <%=StrBookPrintbtn %>
                    <asp:LinkButton ID="lnkexcel" runat="server" CssClass="btn btn-round  btn-outline-info btnBig" OnClick="lnkexcel_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    
                </div>
                <h6 class="element-header">View Booking

                    
                </h6>
                <div class="element-box-tp">
                    <asp:GridView Width="100%" ID="GVBooking" OnPageIndexChanging="GVBooking_OnPageIndexChanging"
                        AutoGenerateColumns="false" CssClass="table table-padded"
                        runat="server" BorderColor="Silver" BorderWidth="0px" CellPadding="5" CellSpacing="8"
                        PageSize="20" GridLines="None" AllowPaging="true" DataKeyNames="BookingID" ShowHeader="true" ShowFooter="true">

                        <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                        <Columns>
                            <asp:BoundField DataField="StadiumName" HeaderText="اسم الملعب"></asp:BoundField>
                            <asp:TemplateField HeaderText="تاريخ الحجز" Visible="true" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%# Eval("BookingDate", "{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="BookingTime" HeaderText="وقت الحجز" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center"></asp:BoundField>

                            <asp:TemplateField HeaderText="Payment Status" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%# GetPaymentStatus(Eval("PaymentStatus"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حالة الحجز" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%# GetBookingStatus(Eval("BookingStatus"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عرض" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <a href="View_BookingDetails.aspx?BookingID=<%#DataBinder.Eval(Container.DataItem, "BookingID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>



                </div>
            </div>
            <%-- <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="Label1" runat="server" Text="View Booking"></asp:Label>
                            </h6>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

