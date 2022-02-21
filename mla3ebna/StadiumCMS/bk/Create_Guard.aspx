<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_Guard.aspx.cs" Inherits="StadiumCMS_Create_Guard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">Guard</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_Guard.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp;تعديل Guard </span></a>
                        </div>
                        <h6 class="element-header">Guard</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            الاسم الثلاثي 
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtGuardName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtGuardName" runat="server" CssClass="form-control" placeholder="الاسم الثلاثي"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            رقم الهاتف النقال   
                                           <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtMobile" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال رقم الهاتف النقال)"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control" placeholder="رقم الهاتف النقال"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label for="projectinput2">
                                            الرقم المدني 
                                      <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtCivilID" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(يرجى إدخال الرقم المدني)"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TxtCivilID" runat="server" CssClass="form-control" placeholder="الرقم المدني"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                              <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                          Note
                                           </label>
                                        <asp:TextBox ID="TxtNote" runat="server" CssClass="form-control" placeholder="Note"></asp:TextBox>
                                    </div>
                                </div>


                            </div>


                             <div class="row" runat="server" id="StatusDiv" visible="false">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                         
                                           </label>
                                        <asp:CheckBox ID="CHK_status" runat="server" Text="&nbsp;&nbsp;Change Status" />
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

