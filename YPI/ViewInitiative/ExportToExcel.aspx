<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="ExportToExcel.aspx.cs" Inherits="YPI_ViewInitiative_ExportToExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">المبادر المحترف</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Excel"></asp:Label></span>
        </li>
    </ul>

     <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">

                         <div class="element-actions">
                           
                         </div>
                        <h6 class="element-header">المبادر المحترف</h6>

                          <div class="element-box">
                               <div class="row">
                                   <div class="col-md-3">
                                       <asp:LinkButton ID="lnkExcelFullReportByAge" runat="server" OnClick="lnkExcelFullReportByAge_Click" CssClass="btn btn-round btn-sm btn-success"><i class="fa fa-file-excel-o"></i>&nbsp;Excel Full Report By Age</asp:LinkButton>
                                   </div>
                                    <div class="col-md-3">
                                        <asp:LinkButton ID="lnkExcelIncubatorSelected" runat="server" OnClick="lnkExcelIncubatorSelected_Click" CssClass="btn btn-round btn-sm btn-success"><i class="fa fa-file-excel-o"></i>&nbsp;Excel Incubator Selected</asp:LinkButton>
                                   </div>
                                    <div class="col-md-3">
                                        <asp:LinkButton ID="lnkExcelAll" runat="server" OnClick="lnkExcelAll_Click" CssClass="btn btn-round btn-sm btn-success"><i class="fa fa-file-excel-o"></i>&nbsp;Excel All</asp:LinkButton>
                                   </div>
                                  

                               </div>

                        <div class="row ">
                                <div class="col-md-4">
                                  
                                </div>
                            
                                <div class="col-md-8 text-left">
                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>

                               <br />
                            
                          </div>


                     </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

