<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="ViewTimeSlot.aspx.cs" Inherits="ViewTimeSlot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

      <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <%--<script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=txtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                // minDate: '+1D',

            });
            $('#<%=txtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>--%>

   

    
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
                             <a class="btn btn-success btn-sm" href="Manage_TimeSlot.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;إضافة الملعب</span></a>

                          
                        </div>
                        <h6 class="element-header">Time Slots</h6>
                        <div class="element-box-tp">



                            <%--   <div class="row ">
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
                                        <label for="projectinput1">
                                           School
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                          Stadium
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadium" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                  <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                          Court
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadiumCourt" AutoPostBack="false" runat="server" >
                                        </asp:DropDownList>

                                    </div>
                                </div>


                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                          FromDate
                                        </label>
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                          ToDate
                                        </label>
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                 <div class="col-md-3" style="display:none;">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                          TimeSlot
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLTimeSlot" AutoPostBack="false" runat="server" >
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


                                        <asp:LinkButton ID="lnkSearch" OnClick="lnkSearch_Click" runat="server" CssClass="btn btn-round  btn-outline-success"><i class="ft-search"></i>&nbsp;بحث</asp:LinkButton>
                                        <asp:LinkButton ID="lnkClear" OnClick="lnkClear_Click" runat="server" CssClass="btn btn-round  btn-outline-danger"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>
                            </div>
                            <br />--%>


                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-md-4"></div>
                                <div class="col-md-4 text-left">

                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />





                            <div class="row" id="divblock" runat="server" visible="true">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="TimeSlotMasterID" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TimeSlotMasterID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DateFrm" HeaderText="Date From"></asp:BoundField>
                                                <asp:BoundField DataField="DateTo" HeaderText="Date To"></asp:BoundField>
                                                <asp:BoundField DataField="Type" HeaderText="Time Slot type"></asp:BoundField>


                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <a id="hyperview" href="View_TimeSlotDetails.aspx?TimeSlotMasterID=<%#DataBinder.Eval(Container.DataItem, "TimeSlotMasterID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a>

                                                        <a ID="hyperedit" style="visibility:visible;" href="Edit_ManageTimeSlot.aspx?TimeSlotMasterID=<%#DataBinder.Eval(Container.DataItem, "TimeSlotMasterID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-edit" aria-hidden="true"></i></a>                                                        
                                                      
                                                    </ItemTemplate>
                                                </asp:TemplateField>



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
</asp:Content>
