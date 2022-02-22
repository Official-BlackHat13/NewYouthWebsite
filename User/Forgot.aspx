<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="User_Forgot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            <h3>نسيت كلمة المرور </h3>

        </div>

        <hr />

            <div class="container bg-white">
                
                    <div class="row">
                 
                            <div class="col-lg-12 col-xs-12  col-sm-12 text-right">

                                <div class="heading-bg">
                                    <h1 class="form-style"></h1>
                                    <div class="line"></div>
                                </div>




                                <div class="clearfix"></div>

                                <br />
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlLogin">


                                            <div class="form-group">
                                                <div class="row" style="direction: rtl;">
                                                    <div class="col-sm-2">
                                                        <label class="control-label">البريد الالكتروني</label>
                                                    </div>

                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="note col-sm-8" style="float: right; margin-top: 10px;">
                                                    <asp:LinkButton runat="server" ID="lblEmail" OnClick="lblEmail_Click"> نسيت البريد الإلكتروني  ?</asp:LinkButton>

                                                </div>
                                                <div class="clear"></div>
                                                <div class="req">

                                                    <div class="col-sm-6">
                                                        <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                                            CssClass="red"
                                                            ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                            ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                            ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                                    </div>


                                                </div>


                                            </div>

                                            <br />


                                            <div class="form-group">

                                                <div class="col-sm-6">

                                                    <a href="Login.aspx" class="btn btn-danger">اغلاق</a>
                                                    <asp:Button ID="btnLogin" runat="server" class="btn btn-info" Text="ادخل" ValidationGroup="personalInfo" OnClick="btnLogin_Clicked" />
                                                </div>
                                            </div>

                                        </asp:Panel>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlReset" Visible="false">

                                            <div class="form-group">
                                                <div class="row" style="direction: rtl;">
                                                    <div class="col-sm-2">
                                                        <label class="control-label">الرقــم المـدني</label>
                                                    </div>

                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="txtCivil" runat="server" CssClass="form-control" MaxLength="12" ValidationGroup="personalInfo" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true"> </asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="clear"></div>
                                                <div class="req">

                                                    <div class="col-sm-6">
                                                        <asp:RequiredFieldValidator ID="rqdCivil" runat="server" ForeColor="#cc0000"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtCivil"
                                                            CssClass="red" Display="Dynamic"
                                                            ValidationGroup="personalInfo1" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator1" runat="server" ForeColor="#cc0000"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="personalInfo1"
                                                            ControlToValidate="txtCivil" Display="dynamic"
                                                            ValidationExpression="^[0-9,٠-٩]{12}$"
                                                            CssClass="red" SetFocusOnError="true" />
                                                        <asp:Label ID="lblCivil" runat="server" Visible="false" ForeColor="#cc0000" SetFocusOnError="true" Text="الرقم المدني غير صحيح" />

                                                        <asp:Label ID="lblGmail" runat="server" Visible="false" Style="font-size: 23px; color: #5f0303;" SetFocusOnError="true" Text="" />
                                                    </div>


                                                </div>
                                                <div class="note col-sm-8" style="float: right; margin-top: 10px;">
                                                    <asp:LinkButton runat="server" ID="lnkPassword" OnClick="lnkPassword_Click">هل نسيت كلمة المرور؟ </asp:LinkButton>
                                                </div>

                                            </div>
                                            <br />
                                            <div class="form-group">

                                                <div class="col-sm-6">

                                                    <a href="forgot.aspx" class="btn btn-danger">اغلاق</a>

                                                    <asp:Button ID="BtClick" runat="server"
                                                        ValidationGroup="personalInfo1" Text="ادخل" CssClass="btn btn-info"
                                                        OnClick="BtClick_Click" />

                                                </div>
                                            </div>

                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <hr />

                            </div>

                    </div>
               
            </div>
        </div>
    </div>


</asp:Content>



