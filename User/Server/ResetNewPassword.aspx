<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="ResetNewPassword.aspx.cs" Inherits="User_ResetNewPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        @media (max-width:768px) {
            .user-forgot-pass {
                display: block !important;
                text-align: right !important;
            }
        }
    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <div class="container">

        <div class="py-5 mt-110 inside-page">
            <div class="bg-white">
                <div class="new-services login-page">

                    <div class=" text-right form-bg1">



                        <div class="heading-bg">
                            <h1 class="form-style">تسجيل الدخول       </h1>
                            <div class="line"></div>
                        </div>


                        <div class="clearfix"></div>

                        <br />


                        <div class="form-group">

                            <div class="row">
                                <div class="col-md-8 col-sm-12">
                                    <div class="alert alert-danger">
                                        <p>عزيزي المستخدم ، الرجاء القيام بتغيير كلمة المرور الخاصة بك لأسباب أمنية وذلك حرصا منا على تقديم الأفضل لكم . </p>
                                    </div>
                                </div>
                            </div>

                            <div class="row" style="direction: rtl;">
                                <div class="col-xs-12 col-sm-2">
                                    <label class="control-label">اسم المستخدم / البريد الالكتروني</label>
                                </div>

                                <div class="col-xs-12 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                        CssClass="text-danger"
                                        ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                        ErrorMessage="يرجى كتابة عنوان الإيميل"
                                        ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="clear"></div>


                        </div>

                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-xs-12 col-sm-2">
                                    <label class="control-label">كلمة المرور</label>
                                </div>

                                <div class="col-xs-12 col-sm-6">
                                    <asp:TextBox ID="txtPassowrd" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassowrd" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regular" runat="server"
                                        ControlToValidate="txtPassowrd" ErrorMessage="Password must be atleast 6 characters long and only English alphanumeric allowed " Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z0-9@#$%&*+\-_(),+':;?.,!\[\]\s\\/]{6,}$" CssClass="text-danger " SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="clear"></div>


                        </div>

                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-xs-12 col-sm-2">
                                    <label class="control-label">Confirm Password</label>
                                </div>

                                <div class="col-xs-12 col-sm-6">
                                    <asp:TextBox ID="txtconfirmpassword" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtconfirmpassword" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"
                                        ControlToCompare="txtPassowrd"
                                        ControlToValidate="txtconfirmpassword"
                                        ErrorMessage=" كلمة المرور لم تطابق" CssClass="text-danger" ValidationGroup="personalInfo"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-xs-12 col-sm-2">
                                    <label class="control-label">OTP (Sent To Email) </label>
                                </div>

                                <div class="col-xs-12 col-sm-6">
                                    <asp:TextBox ID="txtOTP" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtOTP" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="clear"></div>


                        </div>

                        <div class="form-group">
                            <div class="row" style="direction: rtl; margin-top: 18px;">

                                <div class="col-xs-12 col-sm-3 col-12">

                                    <span class="user-forgot-pass mt-2" style="position: absolute; left: 0;">
                                        <a href="Register_AR.aspx" class="modal-opener ">تسجيل جديد </a>
                                    </span>

                                </div>



                            </div>
                        </div>

                        <hr />

                        <div class="form-group">

                            <div class="text-center">
                                <asp:Button ID="btnUserLogin" runat="server" class="btn btn-info" Text="الدخول" ValidationGroup="personalInfo" OnClick="btnUserLogin_Clicked" />
                            </div>
                        </div>



                    </div>

                </div>

            </div>
        </div>


    </div>
</asp:Content>


