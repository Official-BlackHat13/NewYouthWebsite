<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Create_AppUsers.aspx.cs" Inherits="ViewInitiative_Create_AppUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">فريق العمل</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_AppUsers.aspx"><i class="os-icon os-icon-ui-49"></i><span>تعديل فريق العمل</span></a>
                        </div>
                        <h6 class="element-header">فريق العمل</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            الاسم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            اسم المستخدم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtUserName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال اسم المستخدم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-6 ">
                                    <div class="form-group">
                                        <label for="">
                                            الرقم السري
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtPassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(يرجى إدخال الرقم السري)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            الهاتف  
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="txtreq" ControlToValidate="txtMobile"
                                                ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only"
                                                runat="server" />
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            البريد الالكتروني  
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email"
                                                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </label>
                                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الرقــم المـدني
                                          <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtCivilID" ID="RequiredFieldValidator4" runat="server" ErrorMessage="(يرجى إدخال الرقــم المـدني)"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TxtCivilID" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                
                            </div>
                            <div class="row">
                                  <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            Institution
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLInstitution"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  Institution )" />
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLInstitution" OnSelectedIndexChanged="DDLInstitution_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                   <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            حاضنة الأعمال    
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLBusinessNursery" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            Group
                                            <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLUserGroups"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال )" />
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLUserGroups"  AutoPostBack="false" runat="server">
                                           
                                        </asp:DropDownList>
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

