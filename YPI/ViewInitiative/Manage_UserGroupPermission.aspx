<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Manage_UserGroupPermission.aspx.cs" Inherits="ViewInitiative_Manage_UserGroupPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>User Group Permissions</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <%--<a class="btn btn-success btn-sm" href="Manage_AppUsers.aspx"><i class="os-icon os-icon-ui-49"></i><span>تعديل فريق العمل</span></a>--%>
                        </div>
                        <h6 class="element-header">فريق العمل</h6>
                        <div class="element-box">



                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            Group
                                            <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLUserGroups"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال )" />
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLUserGroups" OnSelectedIndexChanged="DDLUserGroups_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                              
                             


                            </div>
                            <br />
                            <legend><span>Stage Access&nbsp;</span></legend>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAAll" Text="&nbsp; مكتب وزير الدولة لشئون الشباب" OnCheckedChanged="MYAAllCheckALL" AutoPostBack="true" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage1" Text="&nbsp; Reviewing" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage2" Text="&nbsp; Call For Interview" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage3" Text="&nbsp; Final  Reviewing " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                      <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage4" Text="&nbsp; Wating For Incubator Selection " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                      <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage5" Text="&nbsp; Incubator Evaluation " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                      <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage6" Text="&nbsp; Incubator Selected " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_MYAStage7" Text="&nbsp; Completed " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" id="PanBN" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_BNAll" Text="&nbsp;  حاضنة الأعمال" OnCheckedChanged="BNAllCheckALL" AutoPostBack="true" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                  <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_BNStage1" Text="&nbsp;  تم استلام المستندات من المكتب " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_BNStage2" Text="&nbsp;  يحول للإدارة المختصة للدراسة " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_BNStage3" Text="&nbsp;  الموافقة واخطار المبادر بالدفع" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:CheckBox ID="CH_BNStage4" Text="&nbsp;  تم الدفع " CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <legend><span>Menu Access&nbsp;</span></legend>
                            <div class="row">

                                <%--     <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Settings" Text="&nbsp; Settings" CssClass="form-control" runat="server" />
                                    </div>
                                </div>--%>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Users" Text="&nbsp; فريق العمل" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Settings" Enabled="false" Text="&nbsp; الاعدادات" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_BusinessNursery" Text="&nbsp; حاضنة الأعمال" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Initiative" Text="&nbsp; برنامج المبادر المحترف" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                            </div>
                            <legend><span>Button Access&nbsp;</span></legend>
                            <div class="row">
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_RewiewApprove" Text="&nbsp; Rewiew & Approve" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Edit" Text="&nbsp; Edit" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Print" Text="&nbsp; Print" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Delete" Text="&nbsp; Delete" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Download" Text="&nbsp; Download" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <%--  <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Report" Text="&nbsp; Report" CssClass="form-control" runat="server" />
                                    </div>
                                </div>--%>
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

