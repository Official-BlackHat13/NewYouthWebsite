<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="View_BookingReport.aspx.cs" Inherits="View_MembersReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .text {
            float: left;
            font-family: 'Neo Sans Arabic';
            font-size: 18px;
            color: #787878;
            padding: 32px 0 0 30px;
        }

        .btnBig {
            font-size: 20px !important;
            vertical-align: top !important;
        }
    </style>

    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                onSelect: function (dateStr) {
                    $('#<%=TxtToDate.ClientID %>').datepicker("option", { minDate: new Date(dateStr) })
                    $('#<%=TxtToDate.ClientID %>').datepicker("setDate", new Date(dateStr));
                }

            });
            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>


    <script type="text/javascript">

        function openWinPrint() {


            var sdate = $("input[id*=TxtFromDate]").val();
          

            var edate = $("input[id*=TxtToDate]").val();
             
            var gov = $("[id*=DDLGovernorate]").find("option:selected").val();   //$('input[id*=DDLGovernorate],select').val();
          
           
            var area = $("[id*=DDLArea]").find("option:selected").val();  // $('input[id*=DDLArea],select').val();


            
            var school = $("[id*=DDLSchool]").find("option:selected").val();  //$('input[id*=DDLSchool],select').val();

           
            var stadiumid = $("[id*=DDLStadium]").find("option:selected").val();   //$('input[id*=DDLStadium],select').val();



           
            var time = $("[id*=DDLTimeSlot]").find("option:selected").val();   //$('input[id*=DDLTimeSlot],select').val();
            var timetext = $("[id*=DDLTimeSlot]").find("option:selected").text(); //$('input[id*=DDLTimeSlot],select').text();
            
            
           

            var other = $("[id*=DDLOther]").find("option:selected").val();// $('input[id*=DDLOther],select').val();
            var OtherTxt = $("[id*=DDLOther]").find("option:selected").text();
            var TextBoxValue = $("input[id*=TxtOther]").val();
          


            
            var day  =  $("[id*=DDLday]").find("option:selected").val();   //$('input[id*=DDLday],select').val();
            var dayText = $("[id*=DDLday]").find("option:selected").text(); 

           

            var str;
           

            if (sdate != "")
                str = str + "StartDate=" + sdate + "&";
            if (edate != "")
                str = str + "EndDate=" + edate + "&";
            if (gov > 0) {
                
                str = str + "GovernorateID=" + gov + "&";
            }
            if (area > 0)
                str = str + "AreaID=" + area + "&";
            if (school > 0)
                str = str + "schoolID=" + school + "&";
            if (stadiumid > 0)
                str = str + "StadiumID=" + stadiumid + "&";
            if (time > 0)
                str = str + "BookingTime=" + timetext + "&";

            if (other > 0) {
                str = str + OtherTxt + "=" + TextBoxValue + "&";
              }

              if (day != 0)
                  str = str + "Day=" + dayText + "&";


              str = str + "BookingStatus=1" ;

              var str_pos = str.indexOf("undefined");
             

              if (str_pos > -1) {                 
                  str = str.replace("undefined", "");   // to remove last '&' symbol
              }

             
             // alert(str);

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
                        <div class="row">

                            <div class="col-md-12">
                                <h6 class="element-header">Booking Report

                                      

                                </h6>                               
                            </div>

                        </div>

                        <div class="element-box-tp">

                            <div class="row ">


                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            From Date
                                        </label>
                                        <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtFromDate_TextChanged" AutoComplete="off"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            To Date
                                        </label>
                                        <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtToDate_TextChanged" AutoComplete="off"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المحافظة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المنطقة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            School  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            Stadium  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadium" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            TimeSlot  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLTimeSlot" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLTimeSlot_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>







                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            Other  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLOther" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLOther_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="CivilID"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Phone"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Email"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="col-md-3" id="DivOther" runat="server" visible="false">
                                    <div class="form-group">
                                        <asp:Label ID="LblOther" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtOther" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtOther_TextChanged"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-md-3" id="Div1" runat="server">
                                    <label for="">
                                        Day
                                    </label>
                                    <div class="form-group">
                                        <asp:Label ID="Day" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DDLday" runat="server" CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLday_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Sunday"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Monday"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Tuesday"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Wednesday"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Thursday"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Friday"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Saturday"></asp:ListItem>
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

                                        <%--<asp:LinkButton ID="lnksearch" OnClick="lnkSerach_Click" runat="server" CssClass="btn btn-round  btn-outline-success"><i class="ft-refresh-cw"></i>&nbsp;search</asp:LinkButton>--%>

                                        <asp:LinkButton ID="lnkSearch" OnClick="lnkSerach_Click" runat="server" CssClass="btn btn-round  btn-outline-success"><i class="ft-search"></i>&nbsp;بحث</asp:LinkButton>
                                        <asp:LinkButton ID="lnkClear" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-round  btn-outline-danger"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>


                                <div class="col-md-3">
                                    <div class="form-group">

                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">

                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">

                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>

                                </div>
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>

                                </div>
                                <div class="col-md-4 text-left">



                                    <div class="form-group pull-left">

                                       

                                        <%--  <%=StrPrintbtn %>--%>

                                        <a class='btn btn-round  btn-outline-danger btnBig' href='javascript:void(0);' onclick='openWinPrint()'><i class='fa fa-print'></i><span></span></a>

                                        <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-round  btn-outline-info btnBig" OnClick="btnExport_Click"><i class="fa fa-file-excel-o"></i><span></span> </asp:LinkButton>
                                    </div>



                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8"
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
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BookingID" Visible="false" ReadOnly="True"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Name" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <a href="View_MemberDetails.aspx?UserID=<%#DataBinder.Eval(Container.DataItem, "UserID")%>" class="mr-2 mb-2 btn-sm"><%#DataBinder.Eval(Container.DataItem, "Name")%></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Email" HeaderText="البريد الإلكتروني"></asp:BoundField>
                                                <asp:BoundField DataField="Phone" HeaderText="رقم الهاتف النقال"></asp:BoundField>
                                                <asp:BoundField DataField="BookingDate" HeaderText="BookingDate"></asp:BoundField>
                                                <asp:BoundField DataField="BookingTime" HeaderText="BookingTime"></asp:BoundField>
                                                <asp:BoundField DataField="GovernorateName" HeaderText="GovernorateName"></asp:BoundField>
                                                <asp:BoundField DataField="AreaName" HeaderText="AreaName"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="StadiumName"></asp:BoundField>
                                                <asp:BoundField DataField="CreatedAt" HeaderText="RegisterDate"></asp:BoundField>






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


