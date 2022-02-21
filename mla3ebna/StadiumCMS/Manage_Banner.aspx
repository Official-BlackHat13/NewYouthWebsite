<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_Banner.aspx.cs" Inherits="StadiumCMS_Manage_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Banner</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_Banner.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;إضافة Banner</span></a>
                        </div>
                        <h6 class="element-header">بحث Banner</h6>
                        <div class="element-box-tp">

                        <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-md-4"></div>
                                <div class="col-md-4 text-left">
                                       <asp:LinkButton ID="lnkSort" runat="server" CssClass="btn btn-round btn-sm btn-primary" OnClick="lnkSort_Click"><i class="os-icon os-icon-ui-49"></i>&nbsp;Update Sort</asp:LinkButton>
                                    |
                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
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
                                                <asp:BoundColumn Visible="False" DataField="BannerID" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Title" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="Title"></asp:BoundColumn>
                                              
                                                <asp:TemplateColumn HeaderText="Image" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton Width="200" Style="cursor: hand" BorderWidth="0" ID="imgtest"
                                                            runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "BannerImage", "Files/Banner/{0}")%>'
                                                            Visible='<%# chkImg(DataBinder.Eval(Container.DataItem, "BannerImage"))%>'></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderText="Action" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="Create_Banner.aspx?id=<%#DataBinder.Eval(Container.DataItem, "BannerID")%>" class="btn btn-primary btn-sm"><i class="os-icon os-icon-ui-49"></i></a>


                                                        <asp:LinkButton ID="lk_del" Visible="false" CommandName="Del" runat="server" CssClass="btn btn-danger btn-sm"><i class="ft-delete"></i></asp:LinkButton>
                                                        <asp:Label ID="lbl_id" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BannerID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Status" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="ShowStatus" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Sort" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox Width="30" ID="Txtsort" runat="server" CssClass="txt" Text='<%#DataBinder.Eval(Container.DataItem, "sort")%>'>
                                                        </asp:TextBox>
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
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

