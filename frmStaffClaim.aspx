<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmStaffClaim.aspx.vb" Inherits="frmStaffClaim" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%--<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="tel" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true" ></asp:ToolkitScriptManager> --%>
    <%--<asp:ScriptManager ID ="scriptManager_" runat="server"   ></asp:ScriptManager>--%>
   <%-- <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="updFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
   </asp:UpdateProgress>--%>


            <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Staff Claim </span></h2></div>
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
                                                   
                                               </div>
                                          </div>
                                          <div id="dvPayee" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Payee :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPaye" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>
                                          <div id="dvNetTotal" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Net Total :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtNetTotal" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqNetTotal" runat ="server" ErrorMessage="*" ControlToValidate="txtNetTotal" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                          <div id="dvApplicationDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtApplicationDate" Width ="300px" runat="server" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqApplicationDatee" runat ="server" ErrorMessage="*" controlToValidate="txtApplicationDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calApplicationDate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlApplicationDate" Position="Bottom" TargetControlID="txtApplicationDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlApplicationDate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calApplicationDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calApplicationDate" runat="server" BackColor="White" 
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
                                         
                                         <div id="dvPurpose" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Purpose :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPurpose" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>

                                         <div id="dvFunctionName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Function Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtfunctionName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>

                                         <div id="dvBudgetCentreName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Budget Center :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtBudgetCenter" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>


                                         <div id="dvBusinessUnit" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Business Unit :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtBusinessUnit" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>


                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddStatus" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqStatus" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">RC. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddRC" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     </div>

                                </div>

            </div>

    
            

        <asp:UpdatePanel ID="updFormPanel" runat ="server"    >
        
        <ContentTemplate>


            <div class ="bodyMainDiv" style="margin-top: 30px;">
                <div id="dvMainDvTitlee" style ="padding :20px;"><h2><span>Claim Details  </span></h2></div>
                <div id="dvPersonalDetailss" style="width :100%">
                                     <div id="dvClaimDetail1" style="float :left ; width :50%; ">    
                                                                                                          
                                          <div id="dvClaimLineNumber" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Line No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtClaimLineNumber" Width ="300px" runat="server" Enabled ="false" ReadOnly="true"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                          <div id="dvAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAmount" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvLinePurpose" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Purpose :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLinePurpose" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="reqtxtMiddleName" runat ="server" ErrorMessage="*" ControlToValidate="txtMiddleName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                          <div id="dvRecieptNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Reciept No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtRecieptNo" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtRecieptNo" runat ="server" ErrorMessage="*" ControlToValidate="txtRecieptNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvNarration" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtNarration" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtNarration" runat ="server" ErrorMessage="*" ControlToValidate="txtNarration" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     
                                     </div>

                                     <div id="dvClaimDetail2" style="float :left ; width :50%; "> 

                                         <div id="dvAdvanceType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Advance Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:DropDownList ID ="ddAdvanceType" Width ="310px" runat ="server" AutoPostBack="true" ValidationGroup="PVDetails" ></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqtxtAdvanceType" runat ="server" ErrorMessage="*" ControlToValidate="ddAdvanceType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvAccountType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Account Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccountType" Width ="300px" runat="server"  Enabled ="false" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccountType" runat ="server" ErrorMessage="*" ControlToValidate="txtAccountType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvAccountNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Account No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccountNumber" Width ="300px" runat="server" Enabled ="false"  ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccountNumber" runat ="server" ErrorMessage="*" ControlToValidate="txtAccountNumber" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvAccountName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Account Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAccountName" Width ="300px" runat="server"  Enabled ="false"  ValidationGroup="PVDetails"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAccountName" runat ="server" ErrorMessage="*" ControlToValidate="txtAccountName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvDateSpent" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date Spent :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDateSpent" Width ="300px" runat="server" Enabled="true" ValidationGroup="PVDetails"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtDateSpent" runat ="server" ErrorMessage="*" controlToValidate="txtDateSpent" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="CalDateSpent_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlDateSpent" Position="Bottom" TargetControlID="txtDateSpent"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlDateSpent" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="CalDateSpent" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="CalDateSpent" runat="server" BackColor="White" 
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


                                     <div id="dvDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnAdd" runat="server" Text="Add Claim Detail" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   <asp:Button ID="btnRemove" runat="server" Text="Remove Claim Detail" ValidationGroup="PVDetails" CssClass ="RemoveButton" />
                                              
                                                   
                                                   
                                               </div>
                                          </div>



                                </div>

            </div>


            <div class ="bodyMainDiv" style="margin-top: 20px;">
                
                <div id="dvGrid" style="width :100%">

                                     <div id="dvActionButton" style="float :left ; width :100%; ">    
                                                                                                          
                                        <asp:GridView  Width="100%" ID="gridClaimLine" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridClaimLine_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">




                                 <Columns>

                                        <%--<asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtClaimLineNumber" HeaderText="Line No" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtAmount" HeaderText="Amount" ItemStyle-Width="100"/> 
                                        <asp:BoundField DataField="txtLinePurpose" HeaderText="Purpose" ItemStyle-Width="300"/>
                                        <asp:BoundField DataField="txtRecieptNo" HeaderText="Reciept No" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtNarration" HeaderText="Narration" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtAdvanceType" HeaderText="Advance Type" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtAccountType" HeaderText="Account Type" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtAccountNumber" HeaderText="Account No" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtAccountName" HeaderText="Account Name" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtDateSpent" HeaderText="Date Spent" ItemStyle-Width="60" DataFormatString="{0:d}" />
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
                                                    
                                                     <asp:Button ID="btnSave" runat="server" Text="Save Claim" CssClass ="button" />
                                                    
                                                 
                                               </div>
                                          </div>


        </div>

</asp:Content>

