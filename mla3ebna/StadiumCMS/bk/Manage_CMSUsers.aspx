<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_CMSUsers.aspx.cs" Inherits="StadiumCMS_Manage_CMSUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">فريق العمل</a>
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
                            <a class="btn btn-success btn-sm" href="Create_CMSUsers.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp; إضافة فريق العمل </span></a>
                        </div>
                        <h6 class="element-header">فريق العمل</h6>
                        <div class="element-box-tp">

                            <div class="row">
                                <div class="col-lg-4">
                                    <asp:LinkButton ID="lk_del" runat="server" CssClass="btn btn-round btn-sm btn-danger" OnClick="lk_del_Click"><i class="os-icon os-icon-ui-15"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4 text-left">
                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                           <asp:DataGrid ID="dg" runat="server" Width="100%" CssClass="table table-padded"
                                            GridLines="Horizontal" AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="3" CellSpacing="8" PageSize="50" AllowPaging="True">
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
                                                <asp:BoundColumn Visible="False" DataField="UserID" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Name" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="الاسم"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="UserName" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="اسم المستخدم "></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="تعديل" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="Create_CMSUsers.aspx?id=<%#DataBinder.Eval(Container.DataItem, "UserID")%>" class="btn btn-info btn-sm"><i class="os-icon os-icon-ui-49"></i></a>
                                                       
                                                       
                                                        <asp:LinkButton ID="lk_del" Visible="false" CommandName="Del" runat="server" CssClass="btn btn-danger btn-sm"><i class="ft-delete"></i></asp:LinkButton>
                                                        <asp:Label ID="lbl_id" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="الحالة" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="ShowStatus" runat="server" AutoPostBack="true"
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

