<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Create_BusinessNursery.aspx.cs" Inherits="ViewInitiative_Create_BusinessNursery" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">حاضنة الأعمال</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_AppUsers.aspx"><i class="os-icon os-icon-ui-49"></i><span>تعديل حاضنة الأعمال</span></a>
                        </div>
                        <h6 class="element-header">فريق العمل</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            الاسم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtNameAr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtNameAr" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            Name
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
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
                                        <label for="projectinput2">
                                            Website  
                                      
                                        </label>
                                        <asp:TextBox ID="TxtWebsite" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            Logo  
                                      
                                        </label>
                                       <input class="txt" id="uFile1" style="width: 100%" type="file" name="uFile1" runat="server">
                                        <br />
                                        <img id="img_pic" width="100" height="100" runat="server">
                                        <asp:Label ID="labPhotoFile" Visible="false" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">Profile Arabic</label>
                                        <ftb:freetextbox id="TxtDescriptionAr" runat="server" buttonset="Office2000" toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            toolbarimageslocation="ExternalFile" buttonimageslocation="ExternalFile" javascriptlocation="ExternalFile"
                                            supportfolder="Scripts/FreeTextBox" width="100%" height="300px" textdirection="RightToLeft">
                                        </ftb:freetextbox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">Profile English</label>
                                        <ftb:freetextbox id="TxtDescriptionEn" runat="server" buttonset="Office2000" toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            toolbarimageslocation="ExternalFile" buttonimageslocation="ExternalFile" javascriptlocation="ExternalFile"
                                            supportfolder="Scripts/FreeTextBox" width="100%" height="300px">
                                        </ftb:freetextbox>
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

