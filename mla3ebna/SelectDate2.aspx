<%@ Page Title="" Language="C#" MasterPageFile="~/mla3ebna/MasterPage.master" AutoEventWireup="true" CodeFile="SelectDate2.aspx.cs" Inherits="mla3ebna_SelectDate2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
                <div class="col-md-3"></div>
                    <div class="col-md-6" id="dividmodal">   
                        
                        <p> Testing </p>   
                                     
        <div id="datepickermodalPop" value="Dd/Mm/Yy" autocomplete="off" ></div>


                         <asp:LinkButton ID="lnkGetStadiumData" runat="server" CssClass="hidden" OnClick="lnkGetStadiumData_Click" ClientIDMode="Static" Text="GetStadiumData"></asp:LinkButton>
                            <asp:HiddenField ID="hiddenDate1" runat="server" ClientIDMode="Static" />
                </div>
            </div>
</asp:Content>

