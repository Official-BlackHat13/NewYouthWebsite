<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_StadiumDetails.aspx.cs" Inherits="StadiumCMS_View_StadiumDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <style>
        table {
           border-collapse: collapse;
           width: 100%;
       }

        table, td, th {
            /*border: 1px solid black;*/
            border-bottom: 1px solid #ddd;
              padding: 8px;
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
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
                                <%=StrPrintbtn %>
                            </div>

                        </div>
                        <h6 class="element-header">الملعب</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="LabStadiumID" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="تفاصيل الملعب"></asp:Label>
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
                                    <span class="labdetails">المحافظة : </span>
                                    <asp:Label ID="LabGovernorate" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">المنطقة : </span>
                                    <asp:Label ID="LabArea" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">مدرسة : </span>
                                    <asp:Label ID="LabSchool" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">العنوان : </span>
                                    <asp:Label ID="LabAddress" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">

                                <div class="col-lg-12">
                                    <span class="labdetails">الرقم الآلي للعنوان (KuwaitFinder) : </span>
                                    <asp:Label ID="LabKuwaitfinderNumber" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">الموقع الجغرافي(Google) : </span>
                                    <asp:Label ID="LabGoogleMapLocation" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">وصف الملعب : </span>
                                    <asp:Label ID="LabDescription" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">ملاحظات : </span>
                                    <asp:Label ID="LabNote" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />


                        </div>
                    </div>
                </div>

                <div class="col-lg-4">

                    <%--<iframe width='100%' height='315' src='https://www.youtube.com/watch?v=P1QaM02mRTk' frameborder='1' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>--%>
                    
                    <div class="property-single">
                        <div class="property-info-w">
                            <div class="property-info-side">

                                <div class="side-section">
                                    <%-- <div class="side-section-header">
                                        Facts and Features
                                    </div>--%>
                                    <div class="side-section-content">
                                        <div class="property-side-features">
                                            <div class="feature">
                                                <asp:LinkButton ID="lnkEdit" CssClass="" runat="server" OnClick="lnkEdit_Click"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل &nbsp;</span></asp:LinkButton>

                                            </div>
                                            <div class="feature">
                                                <asp:LinkButton ID="lnkDelete" CssClass="" runat="server" OnClick="lnkDelete_Click"><i class="fa fa-trash"></i><span>&nbsp; حذف &nbsp;</span></asp:LinkButton>

                                            </div>

                                            <div class="feature">
                                                <a href='Assign_GaurdToStadium.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Assign Guard To Stadium">
                                                    <i class="os-icon os-icon-user-male-circle2"></i>&nbsp;&nbsp;Guard</a>
                                                <%--<a class="fancybox fancybox.iframe" href="Manage_Stadium.aspx"><i class="os-icon os-icon-user-male-circle2"></i><span>&nbsp;Gaurd &nbsp;</span></a>--%>
                                            </div>
                                            <div class="feature">
                                                <a href='Manage_StadiumGallery.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Manage Stadium Gallery">
                                                    <i class="os-icon os-icon-documents-07"></i>&nbsp;&nbsp;Gallery</a>

                                            </div>
                                            <div class="feature">
                                                <a href='Manage_StadiumVideos.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Manage Stadium Videos">
                                                    <i class="os-icon os-icon-others-29"></i>&nbsp;&nbsp;Videos</a>
                                                <%--<a class="fancybox fancybox.iframe" href="Manage_Stadium.aspx"><i class="os-icon os-icon-user-male-circle2"></i><span>&nbsp;Gaurd &nbsp;</span></a>--%>
                                            </div>
                                            <div class="feature">
                                                <a href='Manage_StadiumMaintenance.aspx?StadiumID=<%=Request.QueryString["StadiumID"] %>' class="fancybox fancybox.iframe" data-width="400" data-height="400" title="Manage Stadium Maintenance">
                                                    <i class="fa fa-cog"></i>&nbsp;&nbsp;Maintenance</a>

                                            </div>
                                            <div class="feature">
                                                <a class="" href="Manage_Stadium.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
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

           <%-- <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-box " style="">
                            <h6 class="element-header">

                                <asp:Label ID="Label2" runat="server" Text="Stadium Information"></asp:Label>
                            </h6>



                            <div class="row" dir="ltr">
                                <div class="col-lg-12 text-left">
                                    <span class="labdetails">Stadium Name : </span>
                                    <asp:Label ID="LabStadiumNameEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row" dir="ltr">
                                <div class="col-lg-6 text-left">
                                    <span class="labdetails">Governorate : </span>
                                    <asp:Label ID="LabGovernorateEn" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6 text-left">
                                    <span class="labdetails">Area : </span>
                                    <asp:Label ID="LabAreaEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row" dir="ltr">
                                <div class="col-lg-12 text-left">
                                    <span class="labdetails">School : </span>
                                    <asp:Label ID="LabSchoolEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row" dir="ltr">
                                <div class="col-lg-12 text-left">
                                    <span class="labdetails">Address : </span>
                                    <asp:Label ID="LabAddressEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row" dir="ltr">
                                <div class="col-lg-12 text-left">
                                    <span class="labdetails">Description : </span>
                                    <asp:Label ID="LabDescriptionEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row" dir="ltr">
                                <div class="col-lg-12 text-left">
                                    <span class="labdetails">Note : </span>
                                    <asp:Label ID="LabNoteEn" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>


                </div>
            </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                        <div class="element-wrapper">
                            <div class="element-box " style="">
                                <h6 class="element-header">

                                    <asp:Label ID="Label2" runat="server" Text="StadiumCourt Information"></asp:Label>
                                </h6>
                           
                                <table style="border:hidden; border-bottom:hidden;">
                                    <th> Stadium Type</th>
                                   <p> <%=StadiumCourtType %> </p>
                                </table>
                                
                       

                                 </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <div class="os-tabs-w">
                                <div class="os-tabs-controls">
                                    <ul class="nav nav-tabs bigger">
                                        <li class="nav-item">
                                            <a class="nav-link active show" data-toggle="tab" href="#tab_Gallery">Gallery</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" data-toggle="tab" href="#tab_Video">Video</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" data-toggle="tab" href="#tab_Gard">Gard Info</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" data-toggle="tab" href="#tab_Maintenance">Maintenance</a>
                                        </li>
                                    </ul>

                                </div>
                                <div class="tab-content">
                                    <div class="tab-pane active show" id="tab_Gallery">
                                        <div class="rentals-list-w">
                                            <div class="rentals-list">
                                                <div class="property-items as-grid">
                                                    
                                                    <p>

                                                        <%=StrGalleryDiv %>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_Video">
                                        <div class="row">
                                            <p>
                                                <%=StrVideoDiv %>
                                            </p>

                                        </div>

                                    </div>
                                    <div class="tab-pane" id="tab_Gard">
                                        <div class="row">
                                            <table>
                                                <p>
                                                <%=StrGuardDiv %>
                                            </p>
                                                
                                            </table>
                                            

                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_Maintenance" >
                                        <div class="row">
                                            <table >
                                                <tr runat="server" id="theader">
                                                    <th>MaintenanceType </th>
                                                    <th>MaintenanceDate </th>
                                                    <th>MaintenanceAmount </th>
                                                    <th>MaintenanceBill </th>
                                                </tr>
                                                <p>
                                                <%=StrMaintenanceDiv %>
                                            </p>
                                            </table>
                                            

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

