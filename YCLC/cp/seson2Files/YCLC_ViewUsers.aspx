<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="YCLC_ViewUsers.aspx.cs" Inherits="YCLC_cp_YCLC_ViewUsers"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        .pull-left {
            float: left!important;
        }

        select {
            width: 100%;
            margin-left: 0px;
        }

        @media screen and (max-width: 700px) {
            input[type="text"] {
                width: 66%;
                margin-bottom: 7px;
            }

            select {
                margin-bottom: 7px;
            }
        }
         .drpColor {
            background-color: #05436d;
            width: 250px;
            color: #fff;
        }
         input[type="text"], input[type="textarea"], input[type="password"]
         {
             width: 100%;
         }
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
     <h4 class="widgettitle"> View List Of User 

           <div class="pull-left pd">
              <asp:LinkButton ID="btnExport1" runat="server" ToolTip="Export to Excel" Text="Export to Excel" OnClick="btnExport1_Click"
                  Style="font-size: 21px;">   <i class="fa fa-file-excel-o"></i>  </asp:LinkButton>
              <asp:LinkButton ID="lnlprint" runat="server" OnClick="lnlprint_Click" ToolTip="Print"><span class="fa fa-print" style="font-size: 21px; font-weight: 500; text-shadow: none;"></span>
              </asp:LinkButton> &nbsp; &nbsp;
               <a href="Statistics.aspx"  class="pull-left"  title="Catagory Wise View"><i class="fa fa-bar-chart" style="font-size: 21px; font-weight: 500; text-shadow: none;margin-right: 10px;"></i></a>
               &nbsp; &nbsp;

                 <a href="StatisticsLevel.aspx"  class="pull-left"  title="Catagory and Level Wise View"><i class="fa fa-tasks" style="font-size: 21px; font-weight: 500; text-shadow: none;margin-right: 10px;"></i></a>
          </div>
    </h4>

    <div class="mediamgr_head">
        <ul class="mediamgr_menu">

           
             <li class="col-md-12 col-sm-4 col-xs-12 pd">
                <div class="col-md-2 col-sm-2 pull-right ad_input">
                    <div class="form-group">
                        <label>Catagory</label>

                     
                        <asp:DropDownList ID="DDLCatagory" runat="server" OnSelectedIndexChanged="DDLCatagory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-2 pull-right ad_input">
                    <div class="form-group">
                        <label>Level</label>

                        <asp:DropDownList ID="DDLlevel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLlevel_SelectedIndexChanged">
                            <asp:ListItem Text="--اختر---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="المبتدئ" Value="1"></asp:ListItem>
                            <asp:ListItem Text="المتوسط" Value="2"></asp:ListItem>
                            <asp:ListItem Text="المتقدم" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-1 pull-right ad_input">
                    <div class="form-group">
                        <label>Governarate</label>
                        <asp:DropDownList ID="DDlGovernarate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlGovernarate_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-1 col-sm-2 pull-right ad_input">
                    <div class="form-group">
                        <label>Area</label>
                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="--اختر---" ></asp:ListItem>
                            <asp:ListItem Text="Area 1 (الأحمدي,حولي,العاصمة,مبارك الكبير " Value="1"></asp:ListItem>
                            <asp:ListItem Text="Area 2 (الجهراء,الفروانية) " Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                   <div class="col-sm-1 pull-right ad_input">
                    <div class="form-group">
                        <label>Mobile</label>
                       <asp:TextBox ID="txtmbl" runat="server" AutoPostBack="true" OnTextChanged="txtmbl_TextChanged"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-2 pull-right ad_input">
                    <div class="form-group">
                        <label>Civil Id</label>
                        <asp:TextBox ID="txtcivil" runat="server" AutoPostBack="true" OnTextChanged="txtcivil_TextChanged"></asp:TextBox>
                    </div>
                </div>
             


                <div class="col-md-1 col-sm-2 pull-right ad_input">
                    <div class="form-group">
                        <label>Gender</label>
                        <asp:DropDownList ID="DDLGender" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLGender_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="--اختر---" ></asp:ListItem>
                            <asp:ListItem Text="ذكر " Value="ذكر"></asp:ListItem>
                            <asp:ListItem Text=" أنثى " Value="أنثى"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-2 col-sm-2 pull-right ad_input">
                    <div class="form-group">

                        <asp:Button runat="server" ID="btClear" CssClass="btn btn-danger" Text="Clear Selection" OnClick="btClear_Click" />
                    </div>
                </div>

            </li>



        </ul>
        <div class="clearall"></div>
    </div>
    <asp:HiddenField ID="hdConfirmation" runat="server" />
    <asp:HiddenField ID="hdType" runat="server" />
    <asp:GridView ID="competetionGrid" runat="server" CssClass="table table-bordered" EmptyDataText="No Records Found" AllowSorting="true" AutoGenerateColumns="false"  OnRowCommand="competetionGrid_RowCommand" AllowPaging="true"
        OnPageIndexChanging="competetionGrid_PageIndexChanging" OnDataBound="competetionGrid_DataBound" CellPadding="4" PageSize="20" Style="direction: rtl" OnRowCreated="competetionGrid_RowCreated" OnRowDataBound="competetionGrid_RowDataBound">

        <alternatingrowstyle backcolor="White" />
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم">
                <ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
            </asp:TemplateField>
            
            

            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderText="اسم المشارك">
               <ItemTemplate>
                   <asp:LinkButton ID="lnkusername" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="View" Text='<%# Eval("اسم المشارك") %>'></asp:LinkButton>
                  
               </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="اسم ولي الأمر">
                <ItemTemplate>
                    <%# Eval("اسم ولي الأمر") %>
                </ItemTemplate>
            </asp:TemplateField>

            
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم المدني">
                <ItemTemplate>
                    <%# Eval("الرقم المدني") %> 

                    <asp:HiddenField ID="hiddencivil" runat="server" Value='<%# Eval("الرقم المدني") %>' />
                   
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الهاتف">
                <ItemTemplate>
                   <%# Eval("الهاتف")  == "" ? Eval("هاتف ولي الأمر") : Eval("الهاتف")%>
                    
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="البريد الالكتروني">
                <ItemTemplate>
                    <%# Eval("البريد الالكتروني") == "" ? Eval("البريد الالكتروني لولي الأمر"): Eval("البريد الالكتروني") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="صورة البطاقة المدنية">
                <ItemTemplate>
                   <%--<a id="acivilid" runat="server" target="_blank" >Download</a>--%>
                    <asp:LinkButton ID="lnkcivil" runat="server" CommandArgument='<%# Eval("صورة البطاقة المدنية") %>' CommandName="civil" Text="View" ></asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Badge">
                <ItemTemplate>
                    <a  href='<%# "https://www.youth.gov.kw/YCLC/QRenerator.aspx?rid=" + Eval("QRCODE") %>' runat="server" id="aQR" target="_blank">Get QR</a>
                   
                 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <pagerstyle cssclass="dataTables_info" />
            <pagertemplate>
        <div class="pagination">
          <ul>
            <li>
              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
            </li>
            <li>
              <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
            </li>
            <li>
              <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">>></asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p0" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p1" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p2" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
            </li>
            <li>
              <asp:LinkButton ID="p4" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p5" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p6" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next"><<</asp:LinkButton>
            </li>
            <li>
              <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
            </li>
            <li>
              <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
            </li>
          </ul>
        </div>
      </pagertemplate>
    </asp:GridView>
             <div>

     </div>
</asp:Content>

