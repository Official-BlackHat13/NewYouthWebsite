<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_Booking_old.aspx.cs" Inherits="StadiumCMS_View_Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">


    <style>

        .modal-content-style{

 border: 2px solid #368148 !important;
 background-color: #eeefee !important;
}

        .element-box1{
background-color: #f9f9f9;
    border: 1px solid #b2d0af;
}

        .element-box1 input[type="radio"]
        {
            margin-right:15px !important;        }

        .element-box1 label
        {
            margin-right:5px !important;
        }

         .btnBig
        {
            font-size: 20px !important;
            vertical-align: top !important;
        }

    </style>

    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>

    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>

    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });


            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });



        });

    </script>


    <script type="text/javascript">
        function Confirm(ddl) {


            var index = ddl.selectedIndex;
            var ddltext = ddl.options[ddl.selectedIndex].innerText;

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (ddltext == 'Cancel' || ddltext == 'EnterToStadium') {
                if (confirm("Are you sure to Cancel Booking?")) {

                    confirm_value.value = "Yes";

                }
                else
                    confirm_value.value = "No";
            }


            document.forms[0].appendChild(confirm_value);

        }
    </script>


    <script type="text/javascript">
        function ShowPopup() {
            $("#exampleModal").modal("show");
        }
    </script>


    <script type="text/javascript">
        function radioemailchange() {

            var checked_radio = $("[id*=radioemail] input:checked");
            var value = checked_radio.val();
            var text = checked_radio.closest("td").find("label").html();

            if (value == 1) {
                document.getElementById('DivEmailText').style.display = 'block';
            }
            else
                document.getElementById('DivEmailText').style.display = 'none';
        }
    </script>


    <script type="text/javascript">

        function openWinPrint1() {

            window.open("Print_BookingReport.aspx" + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");

        }
       
    </script>


    <script type="text/javascript">

        

          function openWinPrint() {
                     
              
              
              var sdate = $("input[id*=TxtFromDate]").val();
             
             
              var edate = $("input[id*=TxtToDate]").val(); 

              

              var DDlStadium = document.getElementById("<%=DDlStadium.ClientID %>");
            
              var stadiumid = DDlStadium.options[DDlStadium.selectedIndex].value;
             

              var ddlbStatus = document.getElementById("<%=DDLbookingStatus.ClientID %>");
             
              var bstatus = ddlbStatus.options[ddlbStatus.selectedIndex].value;

              

              var str;
              
              
           
            if (sdate != "")
                str = str + "StartDate=" + sdate + "&";
            if (edate != "")
                str = str + "EndDate=" + edate + "&";
            if (stadiumid != 0)
                str = str + "StadiumID=" + stadiumid + "&";

            str = str + "BookingStatus=" + bstatus;

           
            str = str.replace("undefined", "");

            
            if (str != "")
                window.open("Print_BookingReport.aspx?" + str + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
            else
                window.open("Print_BookingReport.aspx" + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
        }

    </script>

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>Booking</span>
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
                        <h6 class="element-header">بحث Booking</h6>

                        <div class="element-box-tp">

                            <div class="row ">

                                <div class="col-md-3" style="display: none">
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
                                <div class="col-md-3" style="display: none;">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الاسم الثلاثي
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDlUser" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="TextUser" runat="server" AutoComplete="off" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>



                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            تاريخ من
                                        </label>
                                        <asp:TextBox ID="TxtFromDate" AutoComplete="off" CssClass="form-control " runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            تاريخ إلى
                                        </label>
                                        <asp:TextBox ID="TxtToDate" AutoComplete="off" CssClass="form-control " runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الملعب
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDlStadium" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            BookingStatus  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLbookingStatus" runat="server">
                                            <asp:ListItem Value="1" Text="Confirm"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Cancel"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="EnterToStadium"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
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

                                    <a class="btn btn-round  btn-outline-danger btnBig" href='javascript:void(0);' id="aprint" onclick="openWinPrint();" ><i class='fa fa-print'></i></a>

                                    <asp:LinkButton ID="lnkExcel" CssClass="btn btn-round  btn-outline-info btnBig" runat="server" OnClick="lnkExcel_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>

                                    <%-- &nbsp; | &nbsp;--%>
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
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookingID")%>'></asp:Label>
                                                        <asp:Label ID="LabelEmail" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BookingID" Visible="false" ReadOnly="True"></asp:BoundField>

                                                <asp:BoundField DataField="UserFullName" HeaderText="Name"></asp:BoundField>

                                                <asp:TemplateField HeaderText="BookingDate" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelDate" runat="server" Text='<%# Eval("BookingDate", "{0:dd/MM/yyyy}") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="BookingTime" HeaderText="BookingTime"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="StadiumName"></asp:BoundField>

                                                <asp:BoundField DataField="CreatedAt" HeaderText="DateofBooking"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Cancel" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DDLCancel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLCancel_SelectedIndexChanged" onchange="Confirm(this)">
                                                            <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Confirmed"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Cancel"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="EnterToStadium"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <a href="View_BookingDetails.aspx?BookingID=<%#DataBinder.Eval(Container.DataItem, "BookingID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>


                            <asp:HiddenField ID="hdmail" runat="server" />
                            <asp:HiddenField ID="hdDetails" runat="server" />
                            <asp:HiddenField ID="hdBookingID" runat="server" />
                            <asp:HiddenField ID="hdUserID" runat="server" />

                            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="padding: 100px 100px 100px 100px">

                                <div class="modal-dialog" role="document">

                                    <div class="modal-content modal-content-style">
                                        <div class="modal-header">
                                        </div>
                                        <div class="modal-body">

                                            <div class="content-i">
                                                <div class="content-box">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="element-wrapper">
                                                                <h6 class="element-header">Sendig Email</h6>
                                                                <div class="element-box element-box1">
                                                                    <section class="body-sign">

                                                                        <div class="row">
                                                                            <div class="col-lg-12 col-sm-12">
                                                                                <div class="form-group">
                                                                                    <label for="">
                                                                                        EmailType</label>

                                                                                    <asp:RadioButtonList ID="radioemail" runat="server" onchange="radioemailchange()" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem Value="1" Text="Custom"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Default"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                    <asp:RequiredFieldValidator ID="emailValidator3M" runat="server" SetFocusOnError="true" ForeColor="#cc0000"
                                                                                        ErrorMessage="*" ControlToValidate="radioemail" Display="Dynamic"
                                                                                        CssClass="red"
                                                                                        ValidationGroup="error"></asp:RequiredFieldValidator>

                                                                                </div>
                                                                            </div>


                                                                        </div>
                                                                        <br />
                                                                        <div class="row" id="DivEmailText" style="display: none;">
                                                                            <div class="col-lg-12 col-sm-12">
                                                                                <div class="form-group">
                                                                                    <label for="">
                                                                                        Write Email Text</label>

                                                                                    <asp:TextBox runat="server" ID="txtEmailText" CssClass="form-control " TextMode="MultiLine">
                                                                                    </asp:TextBox>

                                                                                </div>
                                                                            </div>


                                                                        </div>


                                                                    </section>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="modal-footer">
                                            <div class="ccol col-8">
                                                <label class="input">
                                                    <asp:LinkButton ID="lnkmail" runat="server" CssClass="btn btn-round  btn-outline-success" ValidationGroup="error" OnClick="lnkmail_Click" Text="Send"></asp:LinkButton>

                                                    &nbsp; &nbsp;  <a href="View_Booking.aspx" class="btn btn-round  btn-outline-danger cls">Close</a>
                                                </label>
                                            </div>
                                        </div>

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

