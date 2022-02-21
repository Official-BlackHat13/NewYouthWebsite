<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Manage_Institutions.aspx.cs" Inherits="ViewInitiative_Manage_Institutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Institutions </span>
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
                        <h6 class="element-header">تعديل Institutions</h6>
                        <div class="element-box-tp">

                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="os-icon os-icon-ui-15"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-5 text-left">
                                    <asp:LinkButton ID="lnkSort" runat="server" OnClick="lnkSort_Click" CssClass="btn btn-round btn-sm btn-secondary"><i class="os-icon os-icon-bar-chart-up"></i>&nbsp;Update Sort</asp:LinkButton>
                                    &nbsp; | &nbsp;<asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:DataGrid ID="dg" runat="server" Width="100%" CssClass="table table-padded"
                                            GridLines="Horizontal" AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="3" CellSpacing="8" PageSize="50" AllowPaging="True" OnPageIndexChanged="dg_PageIndexChanged" OnItemCommand="dg_ItemCommand">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                                            <AlternatingItemStyle CssClass="alternate-row" />
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="id" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="NameAr" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="Institutions"></asp:BoundColumn>
                                                <asp:EditCommandColumn HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    ButtonType="LinkButton" UpdateText="Update" HeaderText="تعديل" CancelText="Cancel"
                                                    EditText="تعديل">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" CssClass="z"></ItemStyle>
                                                </asp:EditCommandColumn>
                                                <asp:TemplateColumn HeaderText="Sort" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox Width="30" ID="txtsort" runat="server" CssClass="txt" Text='<%#DataBinder.Eval(Container.DataItem, "sort")%>'>
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="الحالة" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle NextPageText="Next" PrevPageText="Prevoius" HorizontalAlign="Center"
                                                PageButtonCount="200" CssClass="dgPager" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid>
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

