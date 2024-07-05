<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmCashAdvRetirement.aspx.vb" Inherits="frmCashAdvRetirement" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Cash Advance Retirement </span></h2></div>
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

                                          <div id="dvImprest_Issue_Doc_No" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Imprest Issue Doc No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtImprest_Issue_Doc_No" Width ="300px" runat="server" Enabled ="false" AutoPostBack ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtImprest_Issue_Doc_No" runat ="server" ErrorMessage="*" ControlToValidate="txtImprest_Issue_Doc_No" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>

                                       <%--   <div id="dvDescription2" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description2 :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtDescription2" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtDescription2" runat ="server" ErrorMessage="*" ControlToValidate="txtDescription2" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                       <%--          <div id="dvPayment_Narration" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPayment_Narration" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                          <div id="dvChequedate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Cheque Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtChequedate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtChequedate" runat ="server" ErrorMessage="*" controlToValidate="txtChequedate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calChequedate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlChequedate" Position="Bottom" TargetControlID="txtChequedate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlChequedate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calChequedate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calChequedate" runat="server" BackColor="White" 
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


                                          <%--<div id="dvChequeDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Cheque Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtChequedate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtChequedate" runat ="server" ErrorMessage="*" controlToValidate="txtChequedate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                                    <asp:PopupControlExtender ID="calChequedate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlChequedate" Position="Bottom" TargetControlID="txtChequedate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlChequetdate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calChequedate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calChequedate" runat="server" BackColor="White" 
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



                                          <div id="dvIssued_Date" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Issued Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtIssued_Date" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtIssued_Date" runat ="server" ErrorMessage="*" controlToValidate="txtIssued_Date" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_Issuedate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlIssuedate" Position="Bottom" TargetControlID="txtIssued_Date"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlIssuedate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calIssuedate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calIssuedate" runat="server" BackColor="White" 
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


                                         <div id="dvSurrender_Date" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Surrender Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSurrender_Date" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtSurrender_Date" runat ="server" ErrorMessage="*" controlToValidate="txtSurrender_Date" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                                   <asp:PopupControlExtender ID="PopupControlExtender_Surrender_Date" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlSurrender_Date" Position="Bottom" TargetControlID="txtSurrender_Date"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlSurrender_Date" runat="server">
                                                         
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calSurrender_Date" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calSurrender_Date" runat="server" BackColor="White" 
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

                                        <%-- <div id="Bank_Code" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Bank Code :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtBankCode" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtBankCode" runat ="server" ErrorMessage="*" ControlToValidate="txtBankCode" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                        <%-- <div id="dvCheque_No" class ="dvBoxRows">
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
                                                 
                                                   <asp:DropDownList ID="ddRC" runat="server" Width="300px" CausesValidation="False" AutoPostBack="true"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddStatus" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled="false" ></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddStatus" runat ="server" ErrorMessage="*" ControlToValidate="ddStatus" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <%--<div id="dvTotalAll" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Net Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtNetAmount" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtNetAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtNetAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>--%>

                                         <div id="dvIssueddate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Issued Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtIssued_Date" Width ="300px" runat="server" Enabled="False"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtIssued_Date" runat ="server" ErrorMessage="*" controlToValidate="txtIssued_Date" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                                    <asp:PopupControlExtender ID="calIssuedDate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlIssuedDate" Position="Bottom" TargetControlID="txtIssued_Date"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlIssuedDate" runat="server">

                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calIssuedDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calIssuedDate" runat="server" BackColor="White" 
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


                                         <div id="dvSurrender_Date" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Surrender Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                    <asp:TextBox ID="txtSurrender_Date" Width ="300px" runat="server" Enabled="False"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtSurrender_Date" runat ="server" ErrorMessage="*" controlToValidate="txtSurrender_Date" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                                    <asp:PopupControlExtender ID="calSurrenderDate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlSurrender_Date" Position="Bottom" TargetControlID="txtSurrender_Date"></asp:PopupControlExtender>
                                                    
                                                    <asp:Panel ID="pnlSurrender_Date" runat="server">

                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calSurrenderDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calSurrenderDate" runat="server" BackColor="White" 
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

                                         


                                     </div>

                                </div>

            </div>

    
        <asp:UpdatePanel ID="updFormPanel" runat ="server">
        
        <ContentTemplate>


            <div class ="bodyMainDiv" style="margin-top: 30px;">
                <div id="dvMainDvTitlee" style ="padding :20px;"><h2><span>Cash Advance Request Details  </span></h2></div>
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
                                                    <span style ="font-size : medium;">Imprest Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID ="ddLine_Type" Width ="310px" runat ="server" AutoPostBack="true" ValidationGroup="PVDetails" Enabled="false" ></asp:DropDownList>
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

                                         <%--<div id="dvPayment_NarrationLine" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtPayment_Narration_Line" TextMode="MultiLine" Height="60px" Width ="300px" runat="server" Enabled ="true"  ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration_Line" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration_Line" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                         
                                         <div id="dvAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtAmount" Width ="300px" runat="server"  Enabled ="false" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>

                                          <div id="dvActualSpent" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Spent :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtActualSpent" Width ="300px" runat="server"  Enabled ="true" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtActualSpent" runat ="server" ErrorMessage="*" ControlToValidate="txtActualSpent" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>

                                 <%--         <div id="dvRecieptNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Reciept No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtRecieptNo" Width ="300px" runat="server"  Enabled ="true" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtRecieptNo" runat ="server" ErrorMessage="*" ControlToValidate="txtRecieptNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>--%>

                                 <%--         <div id="dvRecieptAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Reciept Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtRecieptAmount" Width ="300px" runat="server"  Enabled ="true" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqRecieptAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtRecieptAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>--%>

                                         <%--<div id="dvNetAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Net Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLineNetAmount" Width ="300px" runat="server"  Enabled ="true"  ValidationGroup="PVDetails"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtLineNetAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtLineNetAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
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
                                                                                                          
                                        <asp:GridView  Width="100%" ID="gridAdvanceRequest" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridAdvanceRequest_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">




                                 <Columns>

                                        <%--<asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="LineNo" HeaderText="No" ItemStyle-Width="100"/> 
                                        <asp:BoundField DataField="Account_No" HeaderText="Account No" ItemStyle-Width="300"/>
                                        <asp:BoundField DataField="Account_Name" HeaderText="Account Name" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="Imprest_Type" HeaderText="Imprest Type" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="ActualSpent" HeaderText="Actual Spent" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Width="500" />
                                        
                                       <%-- <asp:BoundField DataField="Date_Issued" HeaderText="Issue Date" ItemStyle-Width="60" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Due_Date" HeaderText="Due Date" ItemStyle-Width="60" DataFormatString="{0:d}" />--%>
                                        <asp:BoundField DataField="txtKey" HeaderText="" ItemStyle-Width="1" Visible="true" />

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

        </ContentTemplate>

       

    </asp:UpdatePanel>


     <div class="bodyMainDiv">


         <div id="dvSubmit" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> </span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                     <asp:Button ID="btnSave" runat="server" Text="Submit Payment Request" CssClass ="button" />
                                                    
                                                 
                                               </div>
                                          </div>


        </div>

</asp:Content>

