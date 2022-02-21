<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_BlockStadium.aspx.cs" Inherits="View_BlockStadium" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

      <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
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
    </script>

    <script type="text/javascript">
        function clientfun(num) {

          
            var grd = document.getElementById("<%=GVData.ClientID%>");           
           
            if (grd.rows.length > 0) {
                for (var i = 1; i < grd.rows.length; i++) {
                   
                    document.getElementById("hyperall").style.visibility = "hidden";
                    document.getElementById("hyperedit").style.visibility = "visible";
                   
                  //  var hyperall = grd.rows[i].getElementById("hyperall");
                   // var hyperedit = grd.rows[i].getElementById("hyperedit");              

                    
                }
            }
            
        }
    </script>

    <script>
        function clientfun1() {
           
            var grd = document.getElementById("<%=GVData.ClientID%>"); 
            if (grd.rows.length > 0) {
                for (var i = 1; i < grd.rows.length; i++) {


                    document.getElementById("hyperall").style.visibility = "visible";
                    document.getElementById("hyperedit").style.visibility = "hidden";

                    //var hyperall = grd.rows[i].getElementById("hyperall");
                    //var hyperedit = grd.rows[i].getElementById("hyperedit");

                    //hyperall.style.display = "block";
                    //hyperedit.style.display = "none";
                }
            }
           
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Block</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                             <a class="btn btn-success btn-sm" href="Block_Stadium.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;إضافة الملعب</span></a>

                            <asp:LinkButton ID="lnkanchor" runat="server" Visible="true" CssClass="btn btn-success btn-sm" OnClick="lnkanchor_Click"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;Stadiums BlockBy Admin</span></asp:LinkButton>
                            
                            <asp:LinkButton ID="lnkall" runat="server" Visible="false" CssClass="btn btn-success btn-sm" OnClick="lnkall_Click"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;All</span></asp:LinkButton>
                            
                        </div>
                        <h6 class="element-header">Block Stadium</h6>
                        <div class="element-box-tp">

                              <%--<asp:UpdatePanel ID="updatelist" runat="server">
                                <ContentTemplate>--%>

                            <div class="row ">
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

                                  <div class="col-md-3" >
                                    <div class="form-group">
                                        <label for="projectinput1">
                                         Block By
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="ddlBlockBy" AutoPostBack="false" runat="server" >
                                             <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="WholeSite"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Governorate Wise"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Area Wise"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="School Wise"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Stadium Wise"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Court Wise"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="TimeSlot Wise"></asp:ListItem>
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
                            <br />
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
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="TimeSlotBlockId" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TimeSlotBlockId")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TimeSlotBlockId" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="BlockBy" HeaderText="BlockBy"></asp:BoundField>
                                                <asp:BoundField DataField="GovernorateName" HeaderText="Governorate"></asp:BoundField>
                                                <asp:BoundField DataField="AreaName" HeaderText="Area"></asp:BoundField>
                                                <asp:BoundField DataField="SchoolName" HeaderText="School"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="Stadium"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumType" HeaderText="StadiumType" />
                                                <asp:BoundField DataField="DateFrm" HeaderText="DateFrm"></asp:BoundField>
                                                <asp:BoundField DataField="DateTo" HeaderText="DateTo" />
                                                <%--<asp:BoundField DataField="TimeSlotDetID" HeaderText="TimeSlot"></asp:BoundField>--%>
                                                
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
                                                        <a ID="hyperall"  href="View_BlockStadiumDetails.aspx?TimeSlotBlockId=<%#DataBinder.Eval(Container.DataItem, "TimeSlotBlockId")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                                         
                                                        <a ID="hyperedit" style="visibility:visible;" href="Edit_BlockStadiumDetails.aspx?TimeSlotBlockId=<%#DataBinder.Eval(Container.DataItem, "TimeSlotBlockId")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-edit" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>                                                        
                                                      
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>

                                   <%-- <div class="row" runat="server" id="divAdminBlock" visible="false">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GridViewAdmin" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="TimeSlotBlockId" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TimeSlotBlockId")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TimeSlotBlockId" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="GovernorateID" HeaderText="Governorate"></asp:BoundField>
                                                <asp:BoundField DataField="AreaID" HeaderText="Area"></asp:BoundField>
                                                <asp:BoundField DataField="SchoolID" HeaderText="SchoolID"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumID" HeaderText="StadiumID"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumCourtId" HeaderText="StadiumCourtId" />
                                                <asp:BoundField DataField="DateFrm" HeaderText="DateFrm"></asp:BoundField>
                                                <asp:BoundField DataField="DateTo" HeaderText="DateTo" />
                                                <asp:BoundField DataField="TimeSlotDetID" HeaderText="TimeSlotDetID"></asp:BoundField>
                                                
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
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>--%>


                                 <%--   </ContentTemplate>
                            </asp:UpdatePanel>--%>
                           

                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
