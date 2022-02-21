<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_School.aspx.cs" Inherits="StadiumCMS_Create_School" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">مدرسة</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Manage"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Manage_School.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل مدرسة </span></a>
                        </div>
                        <h6 class="element-header">مدرسة</h6>
                        <div class="element-box">
                            <div class="row">
                              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="">
                                                    المحافظة  
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLGovernorate"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="">
                                                    المنطقة  
                                           <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLArea"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  المنطقة )" />
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="false" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                  <%--  </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DDLGovernorate" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            الاسم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtSchoolName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtSchoolName" runat="server" CssClass="form-control" placeholder="الاسم"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group txtEn">
                                        <label for="">
                                            Name
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtSchoolNameEn" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Please Provide School Name)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtSchoolNameEn" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>



                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            Address  
                                           
                                        </label>
                                        <asp:TextBox ID="TxtAddress" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group txtEn">
                                        <label for="projectinput2">
                                            Address En  
                                      
                                        </label>
                                        <asp:TextBox ID="TxtAddressEn" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="display:none;">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            CivilID Number
                                           
                                        </label>
                                        <asp:TextBox ID="TxtCivilIDNumber" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            TelephoneNo
                                           
                                        </label>
                                        <asp:TextBox ID="TxtTelephoneNo" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>

                            </div>
                            <div class="row" style="display:none;">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Fax
                                           
                                        </label>
                                        <asp:TextBox ID="TxtFax" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Contact Person Name
                                           
                                        </label>
                                        <asp:TextBox ID="TxtContactPersonName" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Contact Person Mobile
                                           
                                        </label>
                                        <asp:TextBox ID="TxtContactPersonMobile" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            ContactPersonEmail
                                           
                                        </label>
                                        <asp:TextBox ID="TxtContactPersonEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>


                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

