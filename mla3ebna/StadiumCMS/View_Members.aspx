<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_Members.aspx.cs" Inherits="StadiumCMS_View_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
          .btnBig
        {
            font-size: 20px !important;
            vertical-align: top !important;
        }
    </style>


    <script type="text/javascript">
        function ConfirmChange(ddl) {


            var index = ddl.selectedIndex;
            var parent = ddl.parentNode.parentNode;
            var textvalue = ddl.options[ddl.selectedIndex].innerText;

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";


            if (confirm("Are you sure to " + textvalue + " the User?")) {

                confirm_value.value = "Yes";

            }
            else
                confirm_value.value = "No";


            document.forms[0].appendChild(confirm_value);
        }
    </script>
<%--    <script type="text/javascript">
        function openWinPrint1() {
               
                window.open("Print_MemberList.aspx" + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
        }
    </script>--%>
    <script type="text/javascript">

        function openWinPrint() {           
           

            var ddlGov = document.getElementById("<%=DDLGovernorate.ClientID %>");           
            var gov = ddlGov.options[ddlGov.selectedIndex].value;
           

            

            var name = document.getElementById("<%=TxtName.ClientID %>").value;
           
            var phn = document.getElementById("<%=TxtMobile.ClientID %>").value;
            

            var ddlStatus = document.getElementById("<%=DDLMemberStatus.ClientID %>");
            var status = ddlStatus.options[ddlStatus.selectedIndex].value;
           
           
            var str;

            if (gov != 0)
                str = str +"GovernorateID=" + gov +"&";
            if (name != "")
                str = str + "Name=" + name + "&";
            if (phn != "")
                str = str + "Phone=" + phn + "&";
            
            str = str + "Status=" + status;

            str = str.replace("undefined","");
           

            if (str != "")
                 window.open("Print_MemberList.aspx?"+str + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
            else
                window.open("Print_MemberList.aspx" +'', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
        }

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Members</span>
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
                                            المحافظة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3" style="display: none;">
                                    <div class="form-group">
                                        <label for="">
                                            المنطقة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Search الاسم الثلاثي Here
                                        </label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtName_TextChanged"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            رقم الهاتف النقال
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Status
                                        </label>
                                        <asp:DropDownList ID="DDLMemberStatus" runat="server" CssClass="chzn-select chzn-rtl">
                                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="Cancel"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>


                                        <asp:LinkButton ID="lnkSearch" OnClick="lnkSerach_Click" runat="server" CssClass="btn btn-round  btn-outline-success"><i class="ft-search"></i>&nbsp;بحث</asp:LinkButton>
                                        <asp:LinkButton ID="lnkClear" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-round  btn-outline-danger"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row ">


                                <div class="col-md-4">
                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>


                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>
                                </div>

                                <div class="col-md-4 text-left">
                                    <a class="btn btn-round  btn-outline-danger btnBig" href='javascript:void(0);' onclick="openWinPrint();"><i class='fa fa-print'></i></a>
                                    <asp:LinkButton ID="lnkExcel" runat="server" CssClass="btn btn-round  btn-outline-info btnBig" OnClick="lnkExcel_Click"> <i class="fa fa-file-excel-o"></i> </asp:LinkButton>
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
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="UserID" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StadiumID" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="الاسم الثلاثي"></asp:BoundField>
                                                <asp:BoundField DataField="CivilID" HeaderText="الرقم المدني"></asp:BoundField>
                                                <asp:BoundField DataField="Phone" HeaderText="رقم الهاتف النقال"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="البريد الإلكتروني"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DDLStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLStatus_SelectedIndexChanged" onchange="ConfirmChange(this)">
                                                            <asp:ListItem Value="*" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Block"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Delete"></asp:ListItem>
                                                        </asp:DropDownList>

                                                        <%--<asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <a href="View_MemberDetails.aspx?UserID=<%#DataBinder.Eval(Container.DataItem, "UserID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
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
     <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
</asp:Content>

