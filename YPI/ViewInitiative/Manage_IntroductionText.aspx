<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Manage_IntroductionText.aspx.cs" Inherits="ViewInitiative_Manage_IntroductionText" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>الفئة  مبادراتنا </span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <%--<div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_AppUsers.aspx"><i class="os-icon os-icon-ui-22"></i><span>Add APP Users</span></a>
                        </div>--%>
                        <h6 class="element-header">تعديل الفئة مبادراتنا</h6>
                        <div class="element-box-tp">


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">Arabic</label>
                                          <ftb:FreeTextBox ID="TxtDescriptionAr" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                            SupportFolder="Scripts/FreeTextBox" Width="100%" Height="300px" TextDirection="RightToLeft">
                                        </ftb:FreeTextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">English</label>
                                          <ftb:FreeTextBox ID="TxtDescriptionEn" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                            SupportFolder="Scripts/FreeTextBox" Width="100%" Height="300px">
                                        </ftb:FreeTextBox>
                                    </div>
                                </div>

                            </div>

                             <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                               

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

