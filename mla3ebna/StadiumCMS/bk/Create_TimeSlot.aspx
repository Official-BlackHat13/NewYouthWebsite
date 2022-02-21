<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_TimeSlot.aspx.cs" Inherits="StadiumCMS_Create_TimeSlot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="Scripts/Calendar/css/jquery-ui.css">

    <script src="Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });


            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });



        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">Time Slot</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_TimeSlot.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل Time Slot </span></a>
                        </div>
                        <h6 class="element-header">Time Slot</h6>
                        <div class="element-box">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            Type  
                                            <asp:CustomValidator runat="server" ID="CustomValidator2" CssClass="require" ControlToValidate="DDLType"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLType_SelectedIndexChanged" ID="DDLType" AutoPostBack="true" runat="server">
                                            <asp:ListItem Value="0"><--أختار--></asp:ListItem>
                                            <asp:ListItem Value="1">Default</asp:ListItem>
                                            <asp:ListItem Value="2">Special</asp:ListItem>
                                            <asp:ListItem Value="3">StadiumWise</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="display: none">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            المحافظة  
                                            <asp:CustomValidator runat="server" ID="CustomValidator4" CssClass="require" ControlToValidate="DDLGovernorate"
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
                                           <asp:CustomValidator runat="server" ID="CustomValidator5" CssClass="require" ControlToValidate="DDLArea"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  المنطقة )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                               
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="">
                                            From Hr
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLFromHr"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال From Hr )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLFromHr" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="01">01</asp:ListItem>
                                            <asp:ListItem Value="02">02</asp:ListItem>
                                            <asp:ListItem Value="03">03</asp:ListItem>
                                            <asp:ListItem Value="04">04</asp:ListItem>
                                            <asp:ListItem Value="05">05</asp:ListItem>
                                            <asp:ListItem Value="06">06</asp:ListItem>
                                            <asp:ListItem Value="07">07</asp:ListItem>
                                            <asp:ListItem Value="08">08</asp:ListItem>
                                            <asp:ListItem Value="09">09</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="">
                                            From Min
                                           
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLFromMin" AutoPostBack="false" runat="server">
                                             <asp:ListItem Value="00">00</asp:ListItem>
                                             <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                             <asp:ListItem Value="45">45</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="">
                                            AM/PM  
                                           <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLFromAMPM"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  AM/PM)" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLFromAMPM" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="AM">AM</asp:ListItem>
                                            <asp:ListItem Value="PM">PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                              
                            </div>
                             <div class="row">
                               
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="">
                                            To Hr
                                            <asp:CustomValidator runat="server" ID="CustomValidator6" CssClass="require" ControlToValidate="DDLToHr"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال   To Hr )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLToHr" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="01">01</asp:ListItem>
                                            <asp:ListItem Value="02">02</asp:ListItem>
                                            <asp:ListItem Value="03">03</asp:ListItem>
                                            <asp:ListItem Value="04">04</asp:ListItem>
                                            <asp:ListItem Value="05">05</asp:ListItem>
                                            <asp:ListItem Value="06">06</asp:ListItem>
                                            <asp:ListItem Value="07">07</asp:ListItem>
                                            <asp:ListItem Value="08">08</asp:ListItem>
                                            <asp:ListItem Value="09">09</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="">
                                            To Min
                                           
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLToMin" AutoPostBack="false" runat="server">
                                             <asp:ListItem Value="00">00</asp:ListItem>
                                             <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                             <asp:ListItem Value="45">45</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="">
                                            AM/PM  
                                           <asp:CustomValidator runat="server" ID="CustomValidator8" CssClass="require" ControlToValidate="DDLToAMPM"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                               ErrorMessage="(يرجى إدخال  AM/PM )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLToAMPM" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="AM">AM</asp:ListItem>
                                            <asp:ListItem Value="PM">PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                              
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            تاريخ من
                                        </label>
                                        <asp:TextBox ID="TxtFromDate" AutoComplete="off" CssClass="form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            تاريخ إلى
                                        </label>
                                        <asp:TextBox ID="TxtToDate" AutoComplete="off" CssClass="form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>



                            </div>
                             <div class="row"> <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            الملعب  
                                            
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl"  ID="DDLStadium"  runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div> </div>
                            
                           


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

