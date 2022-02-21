<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_ReceiptAndPaymentReport.aspx.cs" Inherits="View_MembersReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .text
        {
            float: left;
            font-family: 'Neo Sans Arabic';
            font-size: 18px;
            color: #787878;
            padding: 32px 0 0 30px;
        }

        .btnBig
        {
            font-size: 20px !important;
            vertical-align: top !important;
        }
        
        .footerStyle {

           background-color:#E2EDF2;
            direction:rtl;
           height:30px;
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
                onSelect: function (dateStr) {
                    $('#<%=TxtToDate.ClientID %>').datepicker("option", { minDate: new Date(dateStr) })
                    $('#<%=TxtToDate.ClientID %>').datepicker("setDate", new Date(dateStr));
                }

            });
            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>


    <script type="text/javascript">

        function openWinPrint() {
            window.open("Print_BookingReport.aspx", "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
        }

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Members</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <%-- <a class="btn btn-success btn-sm" href="Create_Stadium.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;إضافة الملعب</span></a>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h6 class="element-header">Booking Report

                                      

                                </h6>
                            </div>


                        </div>

                        <div class="element-box-tp">

                            <div class="row ">


                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            From Date
                                        </label>
                                        <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtFromDate_TextChanged" AutoComplete="off"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            To Date
                                        </label>
                                        <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtToDate_TextChanged" AutoComplete="off"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المحافظة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المنطقة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            Stadium  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadium" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                 


                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>



                                        <asp:LinkButton ID="lnkClear" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-round  btn-outline-danger"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>


                                <div class="col-md-3">
                                    <div class="form-group">

                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">

                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">

                                  <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>

                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton></div>
                                <div class="col-md-4 text-left">


                                   
                                        <div class="form-group pull-left">

                                            <label for="inputFirstName" class="control-label">
                                             
                                            </label>

                                            <%=StrPrintbtn %>

                                            <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-round  btn-outline-info btnBig" OnClick="btnExport_Click"><i class="fa fa-file-excel-o"></i><span></span> </asp:LinkButton>
                                        </div>
                                 


                                </div>
                            </div>


                         <div class="row">
                                 
                                <div class="col-md-4 text-left">


                                   
                                        <div class="form-group pull-left">

                                            <label for="inputFirstName" class="control-label">
                                             test
                                            </label>

                                           

                                           
                                        </div>
                                 


                                </div>
                            </div>

                         
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" ShowFooter="true">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>


                                            <Columns>
                                               
                                                 

                                               <%-- <asp:TemplateField HeaderText="Name" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    
                                                </asp:TemplateField>--%>

                                                <asp:BoundField DataField="Month" HeaderText="Month"></asp:BoundField>
                                                <%--<asp:BoundField DataField="Income" HeaderText="Income"></asp:BoundField>
                                                <asp:BoundField DataField="Expence" HeaderText="Expence"></asp:BoundField>--%>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="Income">
                                                    <ItemTemplate>
                                                        <span class="nf"><%# Eval("Income")%></span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="Expence">
                                                    <ItemTemplate>
                                                        <span class="nf"><%# Eval("Expence")%></span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:TemplateField>

                                                <%--<asp:BoundField DataField="BookingTime" HeaderText="BookingTime"></asp:BoundField>
                                                <asp:BoundField DataField="GovernorateName" HeaderText="GovernorateName"></asp:BoundField>
                                                <asp:BoundField DataField="AreaName" HeaderText="AreaName"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="StadiumName"></asp:BoundField>
                                                <asp:BoundField DataField="CreatedAt" HeaderText="RegisterDate"></asp:BoundField>--%>






                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>


