<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Manage_BusinessNursery.aspx.cs" Inherits="ViewInitiative_Manage_BusinessNursery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">حاضنة الأعمال</a>
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
                        <h6 class="element-header">بحث حاضنة الأعمال</h6>
                        <div class="element-box-tp">

                            <div class="row ">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            اسم 
                                        </label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الهاتف
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control"></asp:TextBox>

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
                                            runat="server" BorderColor="Silver" BorderWidth="0px" CellPadding="3" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="id" ShowFooter="false">
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
                                                <asp:BoundField DataField="Name" HeaderText="اسم"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="البريد الالكتروني"></asp:BoundField>
                                                <asp:BoundField DataField="ContactNumber" HeaderText="الهاتف"></asp:BoundField>
                                                <asp:BoundField DataField="Website" HeaderText="Website"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Image" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton Width="75" Style="cursor: hand" BorderWidth="0" ID="imgtest"
                                                            runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "Logo", "../YPIFiles/BusinessNursery/{0}")%>'
                                                            Visible='<%# chkImg(DataBinder.Eval(Container.DataItem, "Logo"))%>'></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="تعديل" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="Create_BusinessNursery.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" class="btn btn-info btn-sm"><i class="os-icon os-icon-ui-49"></i></a>



                                                        <asp:Label ID="lbl_id" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'></asp:Label>
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

