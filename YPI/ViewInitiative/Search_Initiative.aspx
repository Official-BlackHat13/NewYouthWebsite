<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Search_Initiative.aspx.cs" Inherits="ViewInitiative_Search_Initiative" %>

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
            <a href="#">المبادر المحترف</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="بحث"></asp:Label>
            </span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <%--  <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_Quotation.aspx"><i class="os-icon os-icon-ui-22"></i><span>Create مبادراتنا</span></a>
                        </div>--%>
                        <h6 class="element-header">بحث المبادر المحترف</h6>
                        <div class="element-box-tp">

                            <div class="row ">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            مقدم الطلب
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLType" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            المجال
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLCategory" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-3" style="display:none;">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Stage
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStage" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-3" style="display:none;">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الحالة
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStatus" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="0"><--أختار--></asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>

                                            <asp:ListItem Value="8">Completed</asp:ListItem>
                                            <asp:ListItem Value="9">Rejected</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <%-- <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                              الرقم المدني
                                        </label>
                                        <asp:TextBox ID="TxtCivilID" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>--%>
                                <%--  <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الهاتف
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>--%>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            تاريخ من
                                        </label>
                                        <asp:TextBox ID="TxtFromDate" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            تاريخ إلى
                                        </label>
                                        <asp:TextBox ID="TxtToDate" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            اسم المشروع
                                        </label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>  
                                
                                
                                  <div class="col-md-3" >
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Search
                                        </label>
                                        <asp:DropDownList ID="ddlSerachByMultiple" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSerachByMultiple_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="CivilID"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Email"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Name"></asp:ListItem> 
                                            <asp:ListItem Value="4" Text="YPINo."></asp:ListItem>                                                                                       
                                        </asp:DropDownList>

                                       

                                    </div>
                                </div>    
                                
                                   <div class="col-md-3" runat="server" id="DivSearch" visible="false">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            
                                        </label>                                        

                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Type Here" autocomplete="off"></asp:TextBox>

                                    </div>
                                </div>                       

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>


                                        <asp:LinkButton ID="lnkSearch" OnClick="lnkSerach_Click" runat="server" CssClass="btn btn-round btn-sm btn-dark"><i class="ft-search"></i>&nbsp;Search</asp:LinkButton>
                                        <asp:LinkButton ID="lnkClear" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-round btn-sm btn-light"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                               <%-- <div class="col-md-4"></div>--%>
                                <div class="col-md-8 text-left">
                                     <asp:LinkButton ID="lnkExcel" runat="server" OnClick="lnkExcel_Click" CssClass="btn btn-round btn-sm btn-success"><i class="fa fa-file-excel-o"></i>&nbsp;Excel By Search</asp:LinkButton>
                                      
                                    &nbsp; | &nbsp;  
                                    <%-- &nbsp; | &nbsp;--%><asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px" CellPadding="3" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="id" ShowFooter="true">
                                            <%--<HeaderStyle CssClass="dgHeader_1" />--%>
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>

                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="InitiativeNo" HeaderText="Initiative No."></asp:BoundField>
                                                <asp:BoundField DataField="CategoryNameAr" HeaderText="مجالات المشروع"></asp:BoundField>
                                                <asp:BoundField DataField="InitiativeName" HeaderText="اسم المشروع"></asp:BoundField>
                                                <asp:TemplateField HeaderText="اسم مقدم الطلب" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <%# GetUserInfo(Eval("UID"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Phase" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <%# GetPhaseDetails(Eval("id"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-Width="15%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <%# GetQuotationStatus(Eval("id"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" ItemStyle-Width="15%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <%-- <a href="Create_Quotation.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" class="mr-2 mb-2 btn btn-outline-primary btn-sm"><i class="os-icon os-icon-ui-49"></i></a>--%>
                                                        <a href="View_ViewInitiativeDetails.aspx?InitiativeID=<%#DataBinder.Eval(Container.DataItem, "id")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                                        <a href="javascript:void(0);" onclick="openWinPrint(<%#DataBinder.Eval(Container.DataItem, "id")%>)" class="mr-2 mb-2 btn btn-outline-primary btn-sm"><i class="fa fa-print" aria-hidden="true"></i></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                        <script type="text/javascript">

                                            function openWinPrint(id) {
                                                window.open("Print_Initiative.aspx?InitiativeID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
                                            }



                                        </script>
                                        <div></div>
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

