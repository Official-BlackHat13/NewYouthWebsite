<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_StadiumVideos.aspx.cs" Inherits="StadiumCMS_Manage_StadiumVideos" %>

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
                            <h6 class="element-header">إضافة Videos</h6>
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
                                                VideoUrl</label>
                                            <asp:TextBox ID="TxtVideoUrl" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span style="color:#0000FF" > (Ex:https://www.youtube.com/embed/P1QaM02mRTk)</span><br />
                                            <asp:RegularExpressionValidator ID="regularvideo" runat="server" CssClass="require" ControlToValidate="TxtVideoUrl" Display="Dynamic"
                                                ErrorMessage="Url Formate is Wrong" ValidationExpression="['\'].*youtube\.com\/embed\/(.*)['\'] ?" ></asp:RegularExpressionValidator>
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

                            <h6 class="element-header">تعديل Videos</h6>
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
                                            <asp:DataGrid ID="dg" runat="server" Width="100%" CssClass="btxt" GridLines="Horizontal"
                                                AutoGenerateColumns="False" BorderColor="Silver" BorderWidth="1px" CellPadding="5"
                                                CellSpacing="0" PageSize="20" AllowPaging="True">
                                                <HeaderStyle CssClass="dgHeader"></HeaderStyle>
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
                                                    <asp:BoundColumn DataField="Title" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                        HeaderText="Title"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="VideoUrl" HeaderStyle-CssClass="TxtBlueColor" HeaderStyle-Font-Bold="true"
                                                        HeaderText="VideoUrl"></asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Sort" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox Width="30" ID="txtsort" runat="server" CssClass="txt" Text='<%#DataBinder.Eval(Container.DataItem, "sort")%>'>
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <a href='Manage_StadiumVideos.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&StadiumID=<%=Request.QueryString["StadiumID"] %>'
                                                                class="z">
                                                                <img src="Design/img/user_edit.png" border="0" /></a>
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
