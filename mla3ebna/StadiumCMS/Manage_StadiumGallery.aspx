<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_StadiumGallery.aspx.cs" Inherits="StadiumCMS_Manage_StadiumGallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="content-i">
            <div class="content-box">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="element-wrapper">
                            <h6 class="element-header">إضافة Gallery</h6>
                            <div class="element-box">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                                الاسم</label>
                                            <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                                Image</label>
                                            <input class="form-control" id="uFile" style="width: 250px" type="file" name="uFile" runat="server">
                                            <img id="img_pic" width="100" height="100" runat="server">
                                            <asp:Label ID="labPhotoFile" Visible="false" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>


                                </div>
                                <div class="form-buttons-w">
                                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="btn" Text="Add" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="content-i">
            <div class="content-box">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="element-wrapper">

                            <h6 class="element-header">تعديل Gallery</h6>
                            <div class="element-box-tp">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:ImageButton ID="img_del" ImageUrl="Design/img/trash.png" OnClick="img_del_Click" runat="server" /><asp:LinkButton
                                            Visible="false" ID="lk_del" runat="server" CssClass="z">Delete</asp:LinkButton>
                                    </div>
                                    <div class="col-md-6 text-left" dir="ltr">
                                        <asp:LinkButton ID="lnkSort" runat="server" OnClick="lnkSort_Click" CssClass="btn btn-round btn-sm btn-secondary"><i class="os-icon os-icon-bar-chart-up"></i>&nbsp;Update Sort</asp:LinkButton>
                                        &nbsp; | &nbsp;
                                                <asp:Label ID="lblCount" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:DataGrid ID="dg" runat="server" Width="100%" CssClass="table table-padded btxt" GridLines="Horizontal"
                                                AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="0px" CellPadding="3" CellSpacing="8" PageSize="20" AllowPaging="True">
                                                <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn>
                                                        <HeaderStyle Width="2%"></HeaderStyle>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn Visible="False" DataField="id" ReadOnly="True"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Title"
                                                        HeaderText="Title"></asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Image" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton Width="75" Style="cursor: hand" BorderWidth="0" ID="imgtest"
                                                                runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "Photo", "Files/Stadium/Gallery/{0}")%>'
                                                                Visible='<%# chkImg(DataBinder.Eval(Container.DataItem, "Photo"))%>'></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Sort"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox Width="30" ID="txtsort" runat="server" CssClass="txt" Text='<%#DataBinder.Eval(Container.DataItem, "sort")%>'>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="تعديل" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href='Manage_StadiumGallery.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&StadiumID=<%=Request.QueryString["StadiumID"] %>'
                                                                class="mr-2 mb-2 btn btn-outline-secondary btn-sm">&nbsp;<i class="os-icon os-icon-ui-49"></i>&nbsp;
                                                            تعديل &nbsp;</a>
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
    </form>
</body>
</html>
