<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_StadiumMaintenance.aspx.cs" Inherits="Manage_StadiumMaintenance" %>

<%--<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Design/css/main.css" rel="stylesheet" />


    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TextMaintenanceDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                
            });

            
            if ($("#<%=hdate.ClientID%>").val() != "") {

                dtString = $("#<%=hdate.ClientID%>").val();
                dtString = dtString.split('/');
                var defaultDate = new Date(dtString[2], dtString[0], dtString[1]); //yyyy/MM/dd
                $('#<%=TextMaintenanceDate.ClientID %>').datepicker("setDate", defaultDate);
            }
           
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

       <div class="content-i">
            <div class="content-box">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="element-wrapper">
                            <h6 class="element-header">Stadium Maintenance</h6>
                            <div class="element-box">

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                               Maintenance Type</label>

                                           <asp:TextBox ID="TxtMaintenanceType" runat="server" CssClass="form-control " ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqguard" runat="server" SetFocusOnError="true" 
                                                ErrorMessage="*" ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtMaintenanceType"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                              Maintenance Date</label>
                                            <asp:HiddenField ID="hdate" runat="server" />
                                           <asp:TextBox ID="TextMaintenanceDate" runat="server" CssClass="form-control " AutoComplete="off" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" 
                                                ErrorMessage="*" ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextMaintenanceDate"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                               money For Maintenance (in KWD)</label>

                                           <asp:TextBox ID="TxtAmount" runat="server" CssClass="form-control " ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" 
                                                ErrorMessage="*" ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtAmount"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                                Bill</label>
                                            <input class="form-control" id="uFile" style="width: 250px" type="file" name="uFile" runat="server" />
                                            <img id="img_pic" width="100" height="100" runat="server" visible="false" />
                                            <asp:Label ID="labPhotoFile" Visible="false" runat="server" Text=""></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" 
                                                ErrorMessage="*" ValidationGroup="MainValidate" CssClass="require" ControlToValidate="uFile"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>


                                </div>

                                <div class="form-buttons-w">
                                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="btn" Text="Add" ValidationGroup="MainValidate" />
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

                            <h6 class="element-header">تعديل Maintenance</h6>
                            <div class="element-box-tp">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:ImageButton ID="img_del" ImageUrl="Design/img/trash.png" OnClick="img_del_Click" runat="server" /><asp:LinkButton
                                            Visible="false" ID="lk_del" runat="server" CssClass="z">Delete</asp:LinkButton>
                                    </div>
                                    <div class="col-md-6 text-left" dir="ltr">
                                        <%--<asp:LinkButton ID="lnkSort" runat="server" OnClick="lnkSort_Click" CssClass="btn btn-round btn-sm btn-secondary"><i class="os-icon os-icon-bar-chart-up"></i>&nbsp;Update Sort</asp:LinkButton>
                                        &nbsp; | &nbsp;--%>
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

                                                    <asp:BoundColumn Visible="False" DataField="MaintenanceID" ReadOnly="True"></asp:BoundColumn>

                                                    <asp:BoundColumn DataField="MaintenanceType" HeaderText="Type"></asp:BoundColumn>

                                                    <asp:BoundColumn DataField="MaintenanceDate" HeaderText="Date"></asp:BoundColumn>

                                                    <asp:BoundColumn DataField="MaintenanceAmount" HeaderText="Amount" ></asp:BoundColumn>

                                                    <asp:TemplateColumn HeaderText="Image" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton Width="75" Style="cursor: hand" BorderWidth="0" ID="imgtest"
                                                                runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "MaintenanceBill", "Files/Stadium/Maintenance/{0}")%>'
                                                                Visible='<%# chkImg(DataBinder.Eval(Container.DataItem, "MaintenanceBill"))%>'></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                   
                                                    <asp:TemplateColumn HeaderText="تعديل" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href='Manage_StadiumMaintenance.aspx?MaintenanceID=<%#DataBinder.Eval(Container.DataItem, "MaintenanceID")%>&StadiumID=<%=Request.QueryString["StadiumID"] %>'
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

    </form>
</body>
</html>

