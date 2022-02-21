<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_BookingDetails.aspx.cs" Inherits="StadiumCMS_View_BookingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">Booking</a>
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
                        <h6 class="element-header">Booking</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="LabBookingID" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="تفاصيل Booking"></asp:Label>
                            </h6>
                          
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">اسم الملعب : </span>
                                    <asp:Label ID="LabStadiumName" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">تاريخ الحجز : </span>
                                    <asp:Label ID="LabBookingDate" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">وقت الحجز : </span>
                                    <asp:Label ID="LabBookingTime" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">حالة الحجز : </span>
                                    <asp:Label ID="LabBookingStatus" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">Payment Status : </span>
                                    <asp:Label ID="LabPaymentStatus" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />


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
                                            window.open("Print_Booking.aspx?BookingID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
                                        }



                                    </script>
                                    <%-- <div class="side-section-header">
                                        Facts and Features
                                    </div>--%>
                                    <div class="side-section-content">
                                        <div class="property-side-features">

                                            <div class="feature"><%=StrPrintbtn %></div>
                                            <div class="feature">
                                                <a class="" href="View_Booking.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="element-wrapper  pt-2" id="Div1" runat="server">
                        <div class="element-box" style="">
                            <h6 class="element-header">تفاصيل User
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
                                     <span class="labdetails">الرقم المدني : </span>
                                    <asp:Label ID="LabCivilID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                              <div class="row">
                                <div class="col-lg-12">
                                   <span class="labdetails">البريد الإلكتروني : </span>
                                    <asp:Label ID="LabEmail" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                              <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">رقم الهاتف النقال : </span>
                                    <asp:Label ID="LabPhone" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>


                </div>
                <div class="col-lg-6">
                    <div class="element-wrapper  pt-2" id="PanPaymentDetails" runat="server">
                        <div class="element-box" style="">
                            <h6 class="element-header">تفاصيل Payment
                            </h6>
                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">Payment ID : </span>
                                    <asp:Label ID="LabPaymentID" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">Tran ID : </span>
                                    <asp:Label ID="LabTranID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">Ref : </span>
                                    <asp:Label ID="LabRef" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">Auth : </span>
                                    <asp:Label ID="LabAuth" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">TrackID : </span>
                                    <asp:Label ID="LabTrackID" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">Payment Date : </span>
                                    <asp:Label ID="LabPaymentDate" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>


