<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_TimeSlotDetails.aspx.cs" Inherits="View_TimeSlotDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">TimeSlot</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="TimeSlotDetails"></asp:Label>
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
                        <h6 class="element-header">TimeSlot</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                
                                 <asp:Label ID="Label1" Visible="true" runat="server" Text="TimeSlot Details " CssClass="labdetails"></asp:Label>
                                <asp:Label ID="LabUserID" Visible="true" runat="server" Text=""></asp:Label>

                                
                            </h6>

                             <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblTimeslottype" runat="server" Text=""></asp:Label>
                                    <span class="labdetails"> TimeSlotType : </span>
                                    
                                </div>
                                
                            </div>
                            <div class="row" runat="server" id="divDate">
                                <div class="col-lg-6">
                                    <asp:Label ID="lbldetefrom" runat="server" Text=""></asp:Label>
                                    <span class="labdetails">Date From : </span>
                                    
                                </div>
                                <div class="col-lg-6">
                                    
                                    <asp:Label ID="lbldateto" runat="server" Text=""></asp:Label>
                                    <span class="labdetails">Date To : </span>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div id="divcustom" runat="server">

                                <div class="row">
                                    <div class="col-lg-12">

                                        <asp:Label ID="Labblockby" runat="server" Text=""></asp:Label>
                                        <span class="labdetails">Custom Type : </span>
                                    </div>
                                </div>

                                <div id="divdetails" runat="server">
                                    <div class="row">
                                        <div class="col-lg-6">

                                            <asp:Label ID="LabGovernorate" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">Governorate : </span>
                                        </div>


                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-6">

                                            <asp:Label ID="LabArea" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">Area : </span>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:Label ID="LabSchool" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">School : </span>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-lg-6">

                                            <asp:Label ID="LabStadium" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">Stadium : </span>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:Label ID="LabCourt" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">Stadium Type : </span>
                                        </div>
                                    </div>
                                    <br />
                                </div>                                
                                <br />

                            </div>

                            <div class="row">
                                      
                                        <div class="col-lg-12">

                                            <asp:Label ID="lblTimeSlot" runat="server" Text=""></asp:Label>
                                            <span class="labdetails">Time Slots : </span>
                                        </div>
                                    </div>
                                    <br />
                                </div>

                            
                            <%--<div class="row" id="divtimeslot" runat="server">

                                <div class="col-lg-12">
                                    
                                   
                                    <asp:CheckBoxList ID="ChkTimeSlot" CssClass="form-control" runat="server" RepeatDirection="Horizontal" AppendDataBoundItems="true" RepeatColumns="5" ValidationGroup="MainValidate"></asp:CheckBoxList>
                                                <asp:HiddenField ID="hdtimeslot" runat="server" />
                                    <span class="labdetails"> Time Slot : </span>
                                </div>

                                <div class="col-lg-6">
                                  
                                </div>
                            </div>--%>
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
                                            window.open("Print_TimeSlot.aspx?TimeSlotMasterID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
                                        }



                                    </script>
                                    
                                    <div class="side-section-content">
                                        <div class="property-side-features">
                                           
                                            <div class="feature"><%=StrPrintbtn %></div>
                                            <div class="feature">
                                                <a class="" href="ViewTimeSlot.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
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
    </div>
</asp:Content>