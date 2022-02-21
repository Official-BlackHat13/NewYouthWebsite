<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_TimeSlot.aspx.cs" Inherits="Manage_TimeSlot" %>

<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="radio"], input[type="checkbox"] {
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            padding: 0px;
            margin: 15px 15px 5px 5px !Important;
        }
    </style>
    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                minDate: '+1D',
                onSelect: function (dateStr) {
                    $('#<%=TxtToDate.ClientID %>').datepicker("option", { minDate: new Date(dateStr) })
                }
            });
            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>





    <script src="js/jquery-1.12.4.js"></script>









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
                <asp:Label ID="labtitle1" runat="server" Text="TimeSlot"></asp:Label></span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="ViewTimeSlot.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل الملعب </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>
                        <div class="element-box">



                            <div class="row" id="DivGovernorate" runat="server">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                            Select By  
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLsite"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLsite" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLsite_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Default"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Special"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Custom"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>


                            <div id="divtime" runat="server" visible="false">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="">
                                                Date From  
                                           <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtFromDate" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Enter date)"></asp:RequiredFieldValidator>

                                            </label>
                                            <asp:TextBox ID="TxtFromDate" runat="server" AutoComplete="off" CssClass="form-control "></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="">
                                                Date To  
                                          <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtToDate" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Enter date)"></asp:RequiredFieldValidator>
                                            </label>
                                            <asp:TextBox ID="TxtToDate" runat="server" AutoComplete="off" CssClass="form-control "></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>



                            <asp:UpdatePanel ID="updaterepeater" runat="server">
                                <ContentTemplate>



                                    <div class="row">
                                        <div class="col-sm-5">
                                            <div class="form-group">
                                                <label for="">From</label>

                                            </div>
                                        </div>
                                        <div class="col-sm-2">  </div>
                                        <div class="col-sm-5">
                                            <div class="form-group">
                                                <label for="">To </label>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:Repeater ID="rptTime" runat="server" OnItemCommand="rptTime_ItemCommand">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-sm-5">
                                                      <div class="row">
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="reqFromHour" runat="server" SetFocusOnError="true" ErrorMessage="Choose Hour" CssClass="require" ControlToValidate="ddlFromHour"
                                                                ValidationGroup="MainValidate" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlFromHour" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--Hour--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                                                <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" ErrorMessage="Choose Minuits" CssClass="require" ControlToValidate="ddlFromMin"
                                                                ValidationGroup="MainValidate" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlFromMin" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--Min--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="00"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="15"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="30"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="45"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true" ErrorMessage="Choose AM/PM" CssClass="require" ControlToValidate="ddlFromMeridian"
                                                                ValidationGroup="MainValidate" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlFromMeridian" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--AM/PM--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="AM"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div> </div>
                                                    <%-- <asp:TextBox ID="txtFromTime" runat="server" type="time" Text='<%# Eval("txtFromTime").ToString() %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="txtFromTime" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(Choose Time)"></asp:RequiredFieldValidator>
                                                    --%>
                                                </div>

                                                 <div class="col-sm-2">  </div>
                                                <div class="col-sm-5">

                                                      <div class="row">
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" ErrorMessage="Choose Hour" CssClass="require"
                                                                ControlToValidate="ddlToHour" InitialValue="0" ValidationGroup="MainValidate"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlToHour" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--Hour--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                                                <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" ErrorMessage="Choose Minuits" CssClass="require"
                                                                ControlToValidate="ddlToMin" ValidationGroup="MainValidate" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlToMin" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--Min--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="00"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="15"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="30"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="45"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true" ErrorMessage="Choose AM/PM" CssClass="require"
                                                                ControlToValidate="ddlToMeridian" ValidationGroup="MainValidate" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlToMeridian" runat="server" CssClass="chzn-select chzn-rtl">
                                                                <asp:ListItem Value="0" Text="--AM/PM--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="AM"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div></div>


                                                    <%--<asp:TextBox ID="txtToTime" runat="server" type="time" Text='<%# Eval("txtToTime").ToString() %>'></asp:TextBox>--%>
                                                    <%--<asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="txtToTime" ID="RequiredFieldValidator4" runat="server" ErrorMessage="(Choose Time)"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="row">

                                <div class="col-sm-5">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lnkadd" runat="server" Text="+" OnClick="lnkadd_Click" CssClass="btn btn-primary"></asp:LinkButton>

                                    </div>
                                </div>
                                <div class="col-sm-2">  </div>
                                <div class="col-sm-5">
                                    <div class="form-group">
                                        <asp:LinkButton ID="lnkcancel" runat="server" Text="-" OnClick="lnkcancel_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                    </div>
                                </div>

                            </div>







                            <div id="divCustom" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="">
                                                TimeSlot By  
                                          <asp:CustomValidator runat="server" ID="custBlockType" CssClass="require" ControlToValidate="DDLBlockType"
                                              SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                              ErrorMessage="(يرجى إدخال  المحافظة )" />

                                            </label>
                                            <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLBlockType_SelectedIndexChanged" ID="DDLBlockType" AutoPostBack="true" runat="server">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Governorate Wise"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Area Wise"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="School Wise"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Stadium Wise"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Court Wise"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>


                                <asp:UpdatePanel ID="updatearea" runat="server">
                                    <ContentTemplate>


                                        <div class="row" id="Div4" runat="server">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label for="">
                                                        المحافظة  
                                            <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLGovernorate"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                                    </label>
                                                    <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>
                                                    <%--<asp:CheckBoxList ID="chkGovernorate" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"></asp:CheckBoxList>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6" runat="server" id="DivArea" visible="false">
                                                <div class="form-group">
                                                    <label for="">
                                                        المنطقة  
                                                     <asp:CustomValidator runat="server" ID="CustomValidator2" CssClass="require" ControlToValidate="DDLArea"
                                                         SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                         ErrorMessage="(يرجى إدخال  المحافظة )" />
                                                    </label>
                                                    <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged" AppendDataBoundItems="true" ID="DDLArea" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6" runat="server" id="DivSchool" visible="false">
                                                <div class="form-group">
                                                    <label for="">
                                                        مدرسة  
                                                      <asp:CustomValidator runat="server" ID="CustomValidator3" CssClass="require" ControlToValidate="DDLSchool"
                                                          SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                          ErrorMessage="(يرجى إدخال  المحافظة )" />

                                                    </label>
                                                    <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-6" runat="server" visible="false" id="DivStadium">
                                                <div class="form-group">
                                                    <label for="">
                                                        Stadium
                                                     <asp:CustomValidator runat="server" ID="CustomValidator4" CssClass="require" ControlToValidate="DDLStadium"
                                                         SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                         ErrorMessage="(يرجى إدخال  المحافظة )" />
                                                    </label>
                                                    <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadium" AutoPostBack="true" AppendDataBoundItems="true" runat="server" ClientValidationFunction="CheckDropDownValueZero" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6" runat="server" visible="false" id="DivCourt">
                                                <div class="form-group">
                                                    <label for="">
                                                        Court Type
                                                    <asp:CustomValidator runat="server" ID="CustomValidator5" CssClass="require" ControlToValidate="DDLStadiumCourt"
                                                        SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                        ErrorMessage="(يرجى إدخال  المحافظة )" />

                                                    </label>
                                                    <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadiumCourt" AppendDataBoundItems="true" AutoPostBack="false" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6" runat="server" id="Div5">
                                                <div class="form-group">
                                                    <label for="">
                                                        &nbsp;
                                          
                                                    </label>

                                                </div>
                                            </div>
                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>








                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAddTime" OnClick="lnkAddTime_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                                <asp:LinkButton ID="lnkCanceltime" PostBackUrl="~/ViewTimeSlot.aspx" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>
