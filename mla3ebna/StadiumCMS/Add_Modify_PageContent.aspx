<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Add_Modify_PageContent.aspx.cs" Inherits="StadiumCMS_Add_Modify_PageContent" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labbreadcrumbTitle" runat="server" Text=""></asp:Label> </span>
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
                        <h6 class="element-header"><asp:Label ID="labPageTitle" runat="server" Text=""></asp:Label></h6>
                        <div class="element-box-tp">


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">Arabic</label>
                                          <ftb:FreeTextBox ID="TxtDescription" ClientIDMode="Static" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile" 
                                            SupportFolder="Design/Scripts/FreeTextBox" Width="100%" Height="300px" TextDirection="RightToLeft">
                                        </ftb:FreeTextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtDescription" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Enter Text)"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">English</label>
                                          <ftb:FreeTextBox ID="TxtDescriptionEn" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                            SupportFolder="Design/Scripts/FreeTextBox" Width="100%" Height="300px">
                                        </ftb:FreeTextBox>
                                        <asp:HiddenField ID="hiddenAr" runat="server" ClientIDMode="Static" />
                                        <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtDescriptionEn" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Enter Text)"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>

                             <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" ClientIDMode="Static"  OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                               

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

