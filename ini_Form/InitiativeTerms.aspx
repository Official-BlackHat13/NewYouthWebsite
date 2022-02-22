<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="InitiativeTerms.aspx.cs" Inherits="ini_Form_InitiativeTerms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function validateTerms(source, arguments) {
            var $c = $('#<%= ChckTerm.ClientID %>');
            if ($c.prop("checked")) {
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
    </script>
    <style>
        input[type=checkbox]
        {          
            margin-right: -200px !important;
        }

        
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

      <div class="main-content">
        <!-- Breadcrumbs Section Start -->
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

    </div>



    <section>
        <div class="container-fluid ">
            <div class="container">

                 <div class="text-center mt-50">
                    <h3> شروط التقديم </h3>

                </div>

                <hr />


                <div class="bg-white">
                   
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-lg-12 text-right">                           
                               
                                    <asp:Panel runat="server" ID="pnlError">

                                        <div id="alertAge" class="alert alert-danger" runat="server" visible="false">يجب ان لا يتجاوز عمر مقدم الطلب  35 عاما </div>
                                        <div id="alertApplied" class="alert alert-danger" runat="server" visible="false">أنت مسجل بالفعل</div>

                                    </asp:Panel>


                                    <div class="col-lg-12 sp col-xs-12 pull-right">

                                        <asp:Panel runat="server" ID="pnlTerms">

                                                <ul class="lh">

                                                    <li><i class="fa fa-chevron-left"></i>&nbsp;
                                                        <a href="projects1.aspx" class="blue" target="_blank">لائحة تنظيم دعم المشاريع والفعاليات الشبابية والمكافآت والجوائز </a></li>
                                                    <li><i class="fa fa-chevron-left"></i>&nbsp;
                                                        <a href="conditions3.aspx" class="blue" target="_blank">الضوابط التنظيمية لتنظيم دعم المشاريع والفعاليات الشبابية
والمكافآت والجوائز

وفق المواد <span style="font-family: Tahoma;">(7-6-5)</span>
                                                    </a></li>

                                                  
                                                </ul>
                                           
                                                                                      
                                            <div class="form-group mt-30 mr-10">
                                                <div class="col-xs-12">
                                                  
                                                       
                                                        <asp:CheckBox ID="ChckTerm"  runat="server" Text="أوافق على الأحكام والشروط" TextAlign="left" />
                                                       <br />
                                                         <asp:CustomValidator ID="vTerms"
                                                            ClientValidationFunction="validateTerms"
                                                            ErrorMessage="*" Style="font-size: 22px"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            EnableClientScript="true"
                                                            ValidationGroup="vg"
                                                            runat="server" />

                                                   
                                                </div>
                                              
                                            </div>


                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <asp:Button ID="btnterm" runat="server" Text="موافق" Style="padding: 10px 40px;margin-right:15px;" OnClick="btnterm_Click" ValidationGroup="vg" CssClass="btn btn-info" />
                                                </div>
                                                <div class="clear"></div>
                                            </div>


                                            <div class="text-center">
                                                <h5 class="text">للاستفسار عن المبادرات</h5>
                                            </div>
                                            <div class="text-center">
                                                <h6 class="text-link"><a href="mailto:mubadarat@youth.gov.kw">mubadarat@youth.gov.kw</a> </h6>

                                               <h6> 134</h6>
                                               
                                            </div>



                                        </asp:Panel>
                                    </div>

                               
                            </div>
                        </div>
                   
                </div>
            </div>
        </div>
    </section>
   
</asp:Content>

