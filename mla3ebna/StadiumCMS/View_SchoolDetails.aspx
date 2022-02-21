<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_SchoolDetails.aspx.cs" Inherits="StadiumCMS_View_SchoolDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">School</a>
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
                        <h6 class="element-header">School</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="LabSchoolID" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="تفاصيل School"></asp:Label>
                            </h6>
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">اسم: </span>
                                    <asp:Label ID="LabSchoolName" runat="server" Text=""></asp:Label>
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
                                <div class="col-lg-12">
                                    <span class="labdetails">العنوان : </span>
                                    <asp:Label ID="LabAddress" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">

                                <div class="col-lg-6">
                                    <span class="labdetails">TelephoneNo : </span>
                                    <asp:Label ID="LabTelephoneNo" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">Contact Person Name : </span>
                                    <asp:Label ID="LabContactPersonName" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-lg-6">
                                    <span class="labdetails">Contact Person Mobile : </span>
                                    <asp:Label ID="LabContactPersonMobile" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <span class="labdetails">ContactPersonEmail : </span>
                                    <asp:Label ID="LabContactPersonEmail" runat="server" Text=""></asp:Label>
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
                                    <%-- <div class="side-section-header">
                                        Facts and Features
                                    </div>--%>
                                    <div class="side-section-content">
                                        <div class="property-side-features">
                                            <div class="feature">
                                                <asp:LinkButton ID="lnkEdit" CssClass="" runat="server" OnClick="lnkEdit_Click"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل &nbsp;</span></asp:LinkButton>

                                            </div>
                                            <div class="feature" runat="server" id="DivlnkDelete">
                                                <asp:LinkButton ID="lnkDelete" CssClass="" runat="server" OnClick="lnkDelete_Click"><i class="fa fa-trash"></i><span>&nbsp; حذف &nbsp;</span></asp:LinkButton>

                                            </div>

                                            <div class="feature">
                                                <a class="" href="Manage_School.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
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

            <div class="element-wrapper  pt-2" id="PanStadiumView" runat="server">
                <div class="element-actions d-none d-sm-block">
                </div>
                <h6 class="element-header">الملعب عرض 
                </h6>
                <div class="element-box-tp">
                    <asp:GridView Width="100%" ID="GVStadium" OnPageIndexChanging="GVStadium_OnPageIndexChanging"
                        AutoGenerateColumns="false" CssClass="table table-padded"
                        runat="server" BorderColor="Silver" BorderWidth="0px" CellPadding="5" CellSpacing="8"
                        PageSize="20" GridLines="None" AllowPaging="true" DataKeyNames="StadiumID" ShowHeader="true" ShowFooter="true">

                        <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                        <Columns>
                            <asp:BoundField DataField="StadiumID" Visible="false" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="StadiumName" HeaderText="اسم الملعب"></asp:BoundField>
                            <asp:TemplateField HeaderText="عرض" ItemStyle-CssClass="text-center"
                                HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <a href="View_StadiumDetails.aspx?StadiumID=<%#DataBinder.Eval(Container.DataItem, "StadiumID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>



                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

