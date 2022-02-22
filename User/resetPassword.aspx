<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="resetPassword.aspx.cs" Inherits="User_resetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

     <div class="main-content">
        <!-- Breadcrumbs Section Start -->
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

    </div>

    <div class="container-fluid">
        <div class="container">

            
             <div class="text-center mt-50">
            <h3>إعادة تعيين كلمة المرور </h3>

        </div>

        <hr />

            <div class="bg-white">
            
                    <div class="row">
                        
                            <div class="col-lg-12 col-xs-12 col-sm-12 text-right">
                                
                                <div class="form-horizontal">
                                    <div id="alert" class="notification msgalert" runat="server" visible="false">
                                        <p>
                                            !!
                                            لقد استخدمت هذا الرابط مسبقا
                                        </p>
                                    </div>
                                </div>
                                <div class="clearfix"></div>

                                <div runat="server" id="resetform">

                                    <div class="form-group">
                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-4">
                                                <label class="control-label">كلمة مرور جديدة</label>
                                            </div>

                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="" OnClick="this.value=''" ValidationGroup="personalInfo" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassword" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regular" runat="server"
                                                    ControlToValidate="txtPassword" ErrorMessage="Password must be atleast 6 characters long and only English alphanumeric allowed " Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z0-9@#$%&*+\-_(),+':;?.,!\[\]\s\\/]{6,}$" CssClass="red nf" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                            </div>
                                            <%--{6,}$--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-4">
                                                <label class="control-label">التأكد من كلمة المرور</label>
                                            </div>



                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtConfirmPassowrd" runat="server" CssClass="form-control" ValidationGroup="personalInfo" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtConfirmPassowrd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>


                                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"
                                                    ControlToCompare="txtPassword"
                                                    ControlToValidate="txtConfirmPassowrd"
                                                    ErrorMessage=" كلمة المرور لم تطابق" CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                            </div>
                                        </div>
                                    </div>
                                  
                                    <div class="form-group">

                                        <div class="col-sm-6">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="تسجيل" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                    <hr />

                                </div>

                            </div>



                        
                    </div>
               
            </div>
        </div>
    </div>


</asp:Content>
