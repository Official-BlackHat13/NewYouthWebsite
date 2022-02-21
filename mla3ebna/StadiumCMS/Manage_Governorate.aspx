<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_Governorate.aspx.cs" Inherits="StadiumCMS_Manage_Governorate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>المحافظة</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <h6 class="element-header">المحافظة</h6>
                        <div class="element-box">

                            <h5 class="form-header">إضافة المحافظة</h5>

                            <div class="row">
                               
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="">
                                          المحافظة
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال المحافظة)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtName" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="col-sm-6">
                                    <div class="form-group txtEn">
                                        <label for="">
                                          Governorate 
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtNameEn" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Please Provide Governorate)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtNameEn" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-sm-6">
                                    <label for="" class="btnpaddingtop">&nbsp;</label>
                                    <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="element-wrapper">
                        <%--<div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_AppUsers.aspx"><i class="os-icon os-icon-ui-22"></i><span>Add APP Users</span></a>
                        </div>--%>
                        <h6 class="element-header">تعديل الأنشطة الموقوفة</h6>
                        <div class="element-box-tp">

                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="os-icon os-icon-ui-15"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-5 text-left">
                                    <asp:LinkButton ID="lnkSort" Visible="false" runat="server" OnClick="lnkSort_Click" CssClass="btn btn-round btn-sm btn-secondary"><i class="os-icon os-icon-bar-chart-up"></i>&nbsp;Update Sort</asp:LinkButton>
                                    &nbsp; | &nbsp;<asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:DataGrid ID="dg" runat="server" Width="100%" CssClass="table table-padded"
                                            GridLines="Horizontal" AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="3" CellSpacing="8" PageSize="50" AllowPaging="True" OnPageIndexChanged="dg_PageIndexChanged" OnItemCommand="dg_ItemCommand" OnUpdateCommand="dg_UpdateCommand" OnCancelCommand="dg_CancelCommand">
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
                                                <asp:BoundColumn Visible="False" DataField="GovernorateID" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="GovernorateName" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="المحافظة"></asp:BoundColumn>
                                                 <asp:BoundColumn DataField="GovernorateNameEn" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    HeaderText="Governorate "></asp:BoundColumn>
                                                <asp:EditCommandColumn HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                    ButtonType="LinkButton" UpdateText="Update" HeaderText="تعديل" CancelText="Cancel"
                                                    EditText="تعديل">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" CssClass="z"></ItemStyle>
                                                </asp:EditCommandColumn>
                                                <asp:TemplateColumn HeaderText="Sort" Visible="false" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
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
    <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

