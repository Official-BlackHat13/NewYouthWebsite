<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_Stadium.aspx.cs" Inherits="StadiumCMS_Create_Stadium" %>

<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_Stadium.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل الملعب </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            المحافظة  
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLGovernorate"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            المنطقة  
                                           <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLArea"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  المنطقة )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged" ID="DDLArea" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            مدرسة  
                                           <asp:CustomValidator runat="server" ID="CustomValidator2" CssClass="require" ControlToValidate="DDLSchool"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  مدرسة)" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                  <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Image
                                        </label>
                                        <input class="txt" id="uFile1" style="width: 100%" type="file" name="uFile1" runat="server">
                                        <br />
                                        <img id="img_pic" width="100" height="100" runat="server">
                                        <asp:Label ID="labPhotoFile" Visible="false" runat="server" Text=""></asp:Label>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            اسم الملعب
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtStadiumName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال اسم الملعب)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtStadiumName" runat="server" CssClass="form-control" placeholder="اسم الملعب"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group txtEn">
                                        <label for="">
                                            Stadium Name
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtStadiumNameEn" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Please Provide Stadium Name)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtStadiumNameEn" runat="server" CssClass="form-control" placeholder="Stadium Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            العنوان  
                                           
                                        </label>
                                        <asp:TextBox ID="TxtAddress" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group txtEn">
                                        <label for="projectinput2">
                                            Address  
                                      
                                        </label>
                                        <asp:TextBox ID="TxtAddressEn" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الرقم الآلي للعنوان (KuwaitFinder)
                                           
                                        </label>
                                        <asp:TextBox ID="TxtKuwaitfinderNumber" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الآلي الموقع (KuwaitFinder)
                                           
                                        </label>
                                        <asp:TextBox ID="TxtKuwaitfinderLocation" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الموقع الجغرافي(Google)
                                           
                                        </label>
                                        <asp:TextBox ID="TxtGoogleMapLocation" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Players Type
                                           
                                            <asp:CustomValidator runat="server" ID="CustomValidator3" CssClass="require" ControlToValidate="DDLType"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(Please Select)" />
                                        </label>
                                        <asp:DropDownList ID="DDLType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLType_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Sevens"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Elevens"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="row">
                                <div class="col-md-6"  runat="server" id="DivTerms" visible="false">
                                    <div class="form-group">                                       
                                        <asp:CheckBox ID="chkmembers" runat="server" Text="Do You Want To Split" AutoPostBack="true" OnCheckedChanged="chkmembers_CheckedChanged"/>
                                    </div>
                                </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                             <label for="">
                                            Gender 
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" InitialValue="0" ControlToValidate="DDLgender" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(Please select Gender)"></asp:RequiredFieldValidator></label>
                                            <asp:DropDownList ID="DDLgender" runat="server"  CssClass="chzn-select chzn-rtl">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="ذكر"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="أنثى"></asp:ListItem>
                                            </asp:DropDownList> 
                                        </div>

                                    </div>


                            </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="">وصف الملعب</label>
                                        <ftb:FreeTextBox ID="TxtDescription" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                            SupportFolder="Design/Scripts/FreeTextBox" Width="100%" Height="300px" TextDirection="RightToLeft">
                                        </ftb:FreeTextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group txtEn">
                                        <label for="">Description</label>
                                        <ftb:FreeTextBox ID="TxtDescriptionEn" runat="server" ButtonSet="Office2000" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontBackColorsMenu,Cut,Copy,Paste,Delete;Undo,Redo;BulletedList,NumberedList|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;CreateLink,Unlink|InsertRule,InsertDate,InsertTime|SelectAll|InsertImageFromGallery"
                                            ToolbarImagesLocation="ExternalFile" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                            SupportFolder="Design/Scripts/FreeTextBox" Width="100%" Height="300px" TextDirection="LeftToRight">
                                        </ftb:FreeTextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            ملاحظات
                                        </label>
                                        <asp:TextBox ID="TxtNote" runat="server" CssClass="form-control" placeholder="Note"></asp:TextBox>
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

