<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_Area.aspx.cs" Inherits="StadiumCMS_Manage_Area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>المنطقة</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">

            <asp:UpdatePanel ID="updatearea" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="element-wrapper">
                                <h6 class="element-header">المنطقة</h6>
                                <div class="element-box">

                                    <h5 class="form-header">إضافة المنطقة</h5>




                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="">
                                                    المحافظة  
                                            <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLGovernorate"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="">
                                                    المنطقة
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال المنطقة)"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control "></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group txtEn">
                                                <label for="">
                                                    Area
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtNameEn" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Please Provide Area)"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="TxtNameEn" runat="server" CssClass="form-control txtEn"></asp:TextBox>
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
                                <h6 class="element-header">تعديل المنطقة</h6>
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
                                                        <asp:BoundColumn Visible="False" DataField="AreaID" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="AreaName" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                            HeaderText="المنطقة"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="AreaNameEn" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                            HeaderText="Area"></asp:BoundColumn>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
    <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

