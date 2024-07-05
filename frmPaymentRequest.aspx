<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmPaymentRequest.aspx.vb" Inherits="frmPaymentRequest" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Payment Request </span></h2></div>
                <div id="dvPersonalDetails" style="width :100%">
                                     <div id="dvPersonalfor" style="float :left ; width :50%; ">    
                                                                                                         
                                       
                                          <div id="dvDocumentNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Document No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtDocumentNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>

                                          <div id="dvCashier" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Cashier :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCashier" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtCashier" runat ="server" ErrorMessage="*" ControlToValidate="txtCashier" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                          
                                          <div id="dvPayee" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Payee :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPayee" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqPayee" runat ="server" ErrorMessage="*" ControlToValidate="txtPayee" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvPayee_Account_Number" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Account No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPayee_Account_Number" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayee_Account_Number" runat ="server" ErrorMessage="*" ControlToValidate="txtPayee_Account_Number" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <%--<div id="dvPaying_Bank_Account" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Paying AccountNo :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPaying_Bank_Account" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPaying_Bank_Account" runat ="server" ErrorMessage="*" ControlToValidate="txtPaying_Bank_Account" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                          <%--<div id="dvPayment_Narration" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPayment_Narration" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                          <div id="dvRequestdate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtRequestdate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtRequestdate" runat ="server" ErrorMessage="*" controlToValidate="txtRequestdate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calRequestdate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlRequestdate" Position="Bottom" TargetControlID="txtRequestdate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlRequestdate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calRequestdate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calRequestdate" runat="server" BackColor="White" 
                                                                           BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                                                           DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                                                           ForeColor="#003399" Height="200px" Width="220px">
                                                                           <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                                           <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                                           <OtherMonthDayStyle ForeColor="#999999" />
                                                                           <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                           <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                                           <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                                                               Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                                           <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                                           <WeekendDayStyle BackColor="#CCCCFF" />
                                                                      </asp:Calendar>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                    </asp:Panel>




                                               </div>
                                          </div>
                                          <div id="dvRelease_Date" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Release Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtPayment_Release_Date" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Release_Date" runat ="server" ErrorMessage="*" controlToValidate="txtPayment_Release_Date" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_Releasedate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlReleasedate" Position="Bottom" TargetControlID="txtPayment_Release_Date"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlReleasedate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calReleasedate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calReleasedate" runat="server" BackColor="White" 
                                                                           BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                                                           DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                                                           ForeColor="#003399" Height="200px" Width="220px">
                                                                           <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                                           <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                                           <OtherMonthDayStyle ForeColor="#999999" />
                                                                           <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                           <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                                           <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                                                               Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                                           <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                                           <WeekendDayStyle BackColor="#CCCCFF" />
                                                                      </asp:Calendar>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                    </asp:Panel>




                                               </div>
                                          </div>

                              
                                     </div>


                                     <div id="dvPersonalforr" style="float :left ; width :50%; ">  
                                         
                                         
                                         <%--<div id="dvPay_Mode" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Pay Mode :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddPay_Mode" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddPay_Mode" runat ="server" ErrorMessage="*" ControlToValidate="ddPay_Mode" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                         <%--<div id="Cheque_Type" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Cheque Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddCheque_Type" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddCheque_Type" runat ="server" ErrorMessage="*" ControlToValidate="ddCheque_Type" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                         <%--<div id="dvCheque_No" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Cheque_No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCheque_No" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtCheque_No" runat ="server" ErrorMessage="*" ControlToValidate="txtCheque_No" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                         <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">RC. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddRC" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddStatus" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddStatus" runat ="server" ErrorMessage="*" ControlToValidate="ddStatus" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                         
                                         <%--<div id="dvPaymentAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Total Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPaymentAmount" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtPaymentAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtPaymentAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>--%>
                                        <%-- <div id="dvVATAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">VAT Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtVatAmount" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtVatAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtVatAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>
                                         <div id="dvRetentionAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Retention Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtRetentionAmount" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtRetentionAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtRetentionAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>
                                         <div id="dvWHTAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">WHT Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtWHTAmount" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtWHTAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtWHTAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>--%>


                                         <div id="dvLocation" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Location. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddLocation" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled ="true" ></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddLocation" runat ="server" ErrorMessage="*" ControlToValidate="ddLocation" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvBusinessUnit" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Biz. Unit :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddBusinessUnit" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled ="true" ></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddBusinessUnit" runat ="server" ErrorMessage="*" ControlToValidate="ddBusinessUnit" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>




                                         <div id="dvTotalAll" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Net Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtNetAmount" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtNetAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtNetAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>


                                     </div>

                                </div>

            </div>

       <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="updFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>

       <asp:UpdatePanel ID="updFormPanel" runat ="server">
        
       <ContentTemplate>


            <div class ="bodyMainDiv" style="margin-top: 30px;">
                <div id="dvMainDvTitlee" style ="padding :20px;"><h2><span>Payment Request Details  </span></h2></div>
                <div id="dvPersonalDetailss" style="width :100%">

                                     <div id="dvClaimDetail1" style="float :left ; width :50%; ">    
                                                                                                          
                                          <%--<div id="dvRequisitionLineNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Invoice No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtInvoiceNo" Width ="300px" runat="server" Enabled ="false" ReadOnly="true"   ></asp:TextBox>
                                                 
                                               </div>
                                          </div>--%>                                      

                                          <div id="dvLineType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Line Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID ="ddLine_Type" Width ="310px" runat ="server" AutoPostBack="true" ValidationGroup="PVDetails" ></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqddLine_Type" runat ="server" ErrorMessage="*" ControlToValidate="ddLine_Type" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>


                                         <div id="dvAccount_Type" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Account Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccountType" Width ="300px" runat="server" Enabled ="false"    ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccountType" runat ="server" ErrorMessage="*" ControlToValidate="txtAccountType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvAccount_No" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Acoount No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccount_No" Width ="300px" runat="server" Enabled="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccount_No" runat ="server" ErrorMessage="*" ControlToValidate="txtAccount_No" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvAccountName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Acoount Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccountName" Width ="300px" runat="server" Enabled="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccountName" runat ="server" ErrorMessage="*" ControlToValidate="txtAccountName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     
                                     </div>

                                     <div id="dvClaimDetail2" style="float :left ; width :50%; "> 

                                         <div id="dvPayment_NarrationLine" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtPayment_Narration_Line" TextMode="MultiLine" Height="60px" Width ="300px" runat="server" Enabled ="true"  ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration_Line" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration_Line" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtAmount" Width ="300px" runat="server"  Enabled ="true" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>

                                         <div id="dvVehicleCode" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Vehicle Code :</span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:DropDownList ID="ddVehicleCode" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled ="False" ></asp:DropDownList>
                                                   <%--<asp:RequiredFieldValidator ID="reqVehicleCode" runat ="server" ErrorMessage="*" ControlToValidate="ddVehicleCode" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>


                                               </div>
                                         </div>


                                         <div id="dvAdvertCode" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Advert Code :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:DropDownList ID="ddAdvertCode" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled ="false" ></asp:DropDownList>
                                                   <%--<asp:RequiredFieldValidator ID="reqAdvertCode" runat ="server" ErrorMessage="*" ControlToValidate="ddAdvertCode" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>

                                               </div>
                                         </div>

                                         <%--<div id="dvNetAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Net Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLineNetAmount" Width ="300px" runat="server"  Enabled ="true"  ValidationGroup="PVDetails"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtLineNetAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtLineNetAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                    <%--     <div id="dvDueDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Due Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDueDate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtDueDate" runat ="server" ErrorMessage="*" controlToValidate="txtDueDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_dueDate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlDuedate" Position="Bottom" TargetControlID="txtDueDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlDuedate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calDuedate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calDuedate" runat="server" BackColor="White" 
                                                                           BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                                                           DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                                                           ForeColor="#003399" Height="200px" Width="220px">
                                                                           <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                                           <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                                           <OtherMonthDayStyle ForeColor="#999999" />
                                                                           <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                           <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                                           <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                                                               Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                                           <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                                           <WeekendDayStyle BackColor="#CCCCFF" />
                                                                      </asp:Calendar>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                    </asp:Panel>




                                               </div>
                                          </div>--%>

                                     </div>   

                                     <div id="dvDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnAdd" runat="server" Text="Add Requisition Detail" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   <asp:Button ID="btnRemove" runat="server" Text="Remove Requisition Detail" ValidationGroup="PVDetails" CssClass ="RemoveButton" />
                                              
                                               </div>
                                          </div>



                                </div>

            </div>


            <div class ="bodyMainDiv" style="margin-top: 20px;">
                
                <div id="dvGrid" style="width :100%">

                                     <div id="dvActionButton" style="float :left ; width :100%; ">    
                                                                                                          
                                        <asp:GridView  Width="100%" ID="gridPaymentRequest" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridPaymentRequest_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">




                                 <Columns>

                                       <%-- <asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <%--<asp:BoundField DataField="txtInvoice_No" HeaderText="Line No" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="txtType" HeaderText="Type" ItemStyle-Width="100"/> 
                                        <asp:BoundField DataField="txtAccount_Type" HeaderText="Account Type" ItemStyle-Width="300"/>
                                        <asp:BoundField DataField="txtAccount_No" HeaderText="Account No" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtAccount_Name" HeaderText="Account Name" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="Payment_Narration" HeaderText="Narration" ItemStyle-Width="500" />
                                        <%--<asp:BoundField DataField="Due_Date" HeaderText="Due Date" ItemStyle-Width="60" DataFormatString="{0:d}" />--%>
                                       <%-- <asp:BoundField DataField="numAmount" HeaderText="Amount" ItemStyle-Width="200" />--%>
                                        <asp:BoundField DataField="numNet_Amount" HeaderText="Amount" ItemStyle-Width="200" />
                                        
                                        <asp:BoundField DataField="txtVehicleCode" HeaderText="Vehicle Code" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtAdvertCode" HeaderText="Advert Code" ItemStyle-Width="200" />

                                        <%--<asp:BoundField DataField="txtKey" HeaderText="" ItemStyle-Width="1" Visible="true" />--%>
                                        <asp:BoundField DataField="txtLineNo" HeaderText="Line No" ItemStyle-Width="1" Visible="true" />

                
                                 </Columns>
                    
                                        <pagersettings mode="NextPreviousFirstLast"
                                        firstpagetext="First"
                                        lastpagetext="Last"
                                        nextpagetext="Next"
                                        previouspagetext="Prev"   
                                        position="Bottom"/> 
                              </asp:GridView>
                                   

                                     </div>

                                </div>

            </div>

     <asp:Button id="btnShowDocumentAttachment" runat="server" style="display:none" />    
     <asp:ModalPopupExtender ID="mpDocumentAttachment" runat="server" PopupControlID="pnlDocumentAttachment" TargetControlID="btnShowDocumentAttachment" CancelControlID="btnCloseDocumentAttachment" BackgroundCssClass="modalBackground" ></asp:ModalPopupExtender>
     <asp:Panel ID="pnlDocumentAttachment" runat="server" CssClass="modalPopup" align="center" Height ="600px" style = "display:none" Width ="600px">

    <div id="Div8" class ="dvSideBox" style="width :98%"> 
        
        <div id="Div9" style="border-color:#3a4f63; border :2px solid ; width :100%;">

            <div id="dvDocumentAttachment" style ="padding-left :20px;"><h2><span>Document Attachment...</span></h2></div>

            <div id="dvFileDetails" class="dvBoxbody">

                                         <div id="dvFileDocumentNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Document No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtdocumentID_attachment" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>


                                        <div id="dvDocumentFileName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">File Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtDocumentFileName" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                        </div>



                                        <div id="dvFileName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Select File :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 <asp:FileUpload ID="FileUpload1" runat="server"   />
                                              <%--     <asp:TextBox ID="TextBox2" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>--%>
                                                   
                                               </div>
                                          </div>

                                        <div id="dvFileAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                
                                                 <asp:Button ID="btnAddDocument" Text="Upload" runat="server" OnClick="UploadFile" CssClass ="button" />
                                                 <asp:Button ID="btnRemoveDocument" Text="Remove" runat="server" OnClick="RemoveFile" CssClass ="RemoveButton" />
                                              
                                                   
                                               </div>
                                          </div>


            </div>

            <div id="dvFilesGrid" class="dvBoxbody">
                           

                        <asp:Panel ID="Panel5" Width ="98%" runat ="server" BorderStyle="Solid" Height ="300px" BorderWidth ="2px">
                                                    <asp:GridView Width="100%" ID="gridFileAttachment" runat="server" Visible="true" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" OnRowDataBound ="gridDocumentAttachment_RowDataBound" ShowHeaderWhenEmpty="True" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                                                         <Columns>

                                                              <%--<asp:BoundField DataField="DocumentNo" HeaderText="Doc No" />--%>
                                                             <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                                              <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                              <asp:BoundField DataField="FileType" HeaderText="File Type" />
                                                              
                                                         </Columns>

                                                    </asp:GridView>
                                               </asp:Panel>

                                 
            </div>
    
    </div>
    
    </div>
        
        <br />

    <asp:Button ID="btnCloseDocumentAttachment" runat="server" Text="Close" ValidationGroup ="AppSummary" />
    </asp:Panel>

            <div class="bodyMainDiv">


         <div id="dvSubmit" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> </span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                     <asp:Button ID="btnSave" runat="server" Text="Submit Payment Request" CssClass ="button" />

                                                   
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                   <asp:ImageButton ID="imgDocumentAttactment" runat="server" OnClick="UploadFile" AlternateText="Document Attactment" ImageUrl="~/images/attach-2-64.ico" ToolTip="Document Attachment"/>
                                                    
                                                 
                                               </div>

                                               
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <div id="dvErr" runat="server" style="text-align : left;" visible="false">
                                                   <asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
                                               </div>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               <br></br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>
                                               </br>




                                          </div>


        </div>

        </ContentTemplate>

            <Triggers>

                <asp:PostBackTrigger ControlID="btnAddDocument" />
                        
            </Triggers>

       </asp:UpdatePanel>


</asp:Content>

