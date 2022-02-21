<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ViewInitiative_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>تغير كلمة السر</span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <h6 class="element-header">تغير كلمة السر</h6>
                        <div class="element-box">

                            <h5 class="form-header">تغير كلمة السر
          </h5>
                            <div class="form-desc">
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">اسم المستخدم</label><asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="User Name" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            كلمة السر القديمة
                                            <asp:RequiredFieldValidator ValidationGroup="ChangePassword" CssClass="require" ControlToValidate="txtoldpasswrd" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(مطلوب هذه الخانة)"></asp:RequiredFieldValidator></label><asp:TextBox ID="txtoldpasswrd" runat="server" CssClass="form-control" placeholder="Current Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            كلمة السر الجديدة
                                            <asp:RequiredFieldValidator ValidationGroup="ChangePassword" CssClass="require" ControlToValidate="txtnewpassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(مطلوب هذه الخانة)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="txtnewpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            أعد كتابة كلمة السر
                                            <asp:RequiredFieldValidator ValidationGroup="ChangePassword" CssClass="require" ControlToValidate="txtrepassword" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(مطلوب هذه الخانة)"></asp:RequiredFieldValidator></label><asp:TextBox ID="txtrepassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" ValidationGroup="ChangePassword" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-49"></i>&nbsp; تحديث</asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp; الغاء</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

