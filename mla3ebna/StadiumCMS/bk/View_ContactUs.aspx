<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_ContactUs.aspx.cs" Inherits="View_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                // minDate: '+1D',

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
            <span>ContactUs</span>
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
                        <h6 class="element-header">بحث Members</h6>
                        <div class="element-box-tp">
                            
                            <div class="row ">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            Date  
                                          
                                        </label>
                                       <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                           Email
                                        </label>
                                        <asp:TextBox ID="Txtemail" runat="server" CssClass="form-control"></asp:TextBox>

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

                                    <%-- &nbsp; | &nbsp;--%><asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8" OnRowDataBound="GVData_RowDataBound"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="ContactId" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                                            

                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ContactId")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="StadiumID" Visible="false" ReadOnly="True"></asp:BoundField>--%>
                                                <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                                <asp:BoundField DataField="Msg" HeaderText="Message"></asp:BoundField>


                                                <asp:TemplateField HeaderText="Reply" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <a runat="server" id="aRef" data-width='400' data-height='400' ><i class="fa fa-reply" aria-hidden="true"></i></a>

                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Record(s) Available!!!
                                            </EmptyDataTemplate>
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



