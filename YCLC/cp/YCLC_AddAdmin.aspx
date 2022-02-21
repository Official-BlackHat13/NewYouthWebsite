<%@ Page Title="" Language="C#" MasterPageFile="~/YCLC/cp/cpanl.master" AutoEventWireup="true" CodeFile="YCLC_AddAdmin.aspx.cs" Inherits="YCLC_cp_YCLC_AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .GenderRadio input[type=radio] {
            margin-right: 24px;
        }


        .inut-four input {
        }

        .stdform input {
            width: 100%;
        }

        .stdform select {
            width: 102%;
        }

        .red {
            color: red;
        }

        .GenderRadio input[type=radio] {
            margin-right: 24px;
            width: auto !important;
            float: right;
            margin-left: 10px;
        }

        #mainContent_ChckTerm {
            width: auto !important;
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">

    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ScriptManager>


    <div class="widgetcontent bordered shadowed stdform">

        <div class="row">

            <div class="col-md-8 col-md-offset-2 text-center ">
                <asp:Panel ID="pnlReg" runat="server">


                    <asp:Panel ID="panelform" runat="server" Style="margin-right: 15px;">
                        <h4 class="widgettitle">Add Admin</h4>
                         <br />
                        <div id="alertEmail" class="alert alert-danger" runat="server" visible="false">
                            <p>الايميل مسجل لدينا مسبقاً</p>
                        </div>

                        <div id="success" class="alert alert-success" runat="server" visible="false">
                            <p>Added Successfully</p>
                        </div>

                        <div class="form-group">

                            <div class="row inut-four" style="direction: rtl; padding-top: 20px;">
                                <div class="col-sm-3 col-xs-12 pull-right">
                                    <label class="control-label">Name in Arabic </label>
                                </div>

                                <div class="col-sm-8 col-xs-12">
                                    <asp:TextBox ID="txtName" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأول"></asp:TextBox>

                                </div>

                                <div class="clearfix"></div>

                            </div>

                            <div class="req">
                                <div class="col-sm-8">
                                    <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtName"
                                        CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtName" CssClass="red"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                      
                         <div class="clearfix"></div>

                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-sm-3">
                                    <label class="control-label">الهاتف</label>
                                </div>

                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtContactNo" MaxLength="8" ClientIDMode="Static" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="req">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">

                                    <asp:RequiredFieldValidator ID="rqdContactnumber1" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtContactNo"
                                        CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                        EnableClientScript="true"
                                        ID="RegularExpressionValidator2" runat="server"
                                        ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                        ValidationGroup="personalInfo" SetFocusOnError="true"
                                        ControlToValidate="txtContactNo" Display="dynamic"
                                        ValidationExpression="^[0-9,٠-٩]{8}$"
                                        CssClass="red" />
                                </div>
                            </div>

                        </div>


                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-sm-3">
                                    <label class="control-label">البريد الالكتروني</label>
                                </div>

                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo" ClientIDMode="Static" ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="req">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">


                                    <asp:RequiredFieldValidator ID="rqdEmail1" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                        CssClass="red"
                                        ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                        ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                        ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                       


                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-sm-3">
                                    <label class="control-label">كلمة المرور</label>
                                </div>

                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="req">

                                <div class="col-sm-12">
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
                                <div class="col-sm-3">
                                    <label class="control-label">تأكيد كلمة المرور</label>
                                </div>

                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="form-control" ValidationGroup="personalInfo" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="req">

                                <div class="col-sm-12">
                                    <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtConfirmPwd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>


                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" SetFocusOnError="true"
                                        ControlToCompare="txtPassword"
                                        ControlToValidate="txtConfirmPwd"
                                        ErrorMessage=" كلمة المرور لم تطابق" CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="row" style="direction: rtl;">
                                <div class="col-sm-3">
                                    <label class="control-label">Organization</label>
                                </div>

                                <div class="col-sm-8">
                                    <asp:DropDownList ID="DDlOrganization" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="req">

                                <div class="col-sm-8">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="ddlOrganization" InitialValue="0"
                                        CssClass="red"
                                        ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>


                                </div>
                            </div>
                        </div>





                        <hr />
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-8">
                                    <div style="display: block; margin: 0 auto; text-align: center;">                                        
                                         <asp:Button ID="Button1" runat="server" class="btn btn-danger" Text="Cancel" PostBackUrl="~/YCLC/cp/YCLC_RegisterdAdmin.aspx" Style="width: 150px;" />
                                         
                                         <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="تسجيل" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" Style="width: 150px;" />

                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdfile" runat="server" />
                        <asp:HiddenField ID="hdpwd" runat="server" />

                    </asp:Panel>




                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

