<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmProbationConfirmation.aspx.vb" Inherits="frmProbationConfirmation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Probation Confirmation </span></h2></div>
                <div id="dvPersonalDetails" style="width :100%">
                                     <div id="dvPersonalfor" style="float :left ; width :50%; ">    
                                                                                                         
                                       
                                          <div id="dvApplicationNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Application No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtApplicationNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>
                                          <div id="dvEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtEmployeeNo" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>
                                          <div id="dvEmployeeName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtEmployeeName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>

                                          <div id="dvEmploymentdate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employment Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmploymentdate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtEmploymentdate" runat ="server" ErrorMessage="*" controlToValidate="txtEmploymentdate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calEmploymentdate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlEmploymentdate" Position="Bottom" TargetControlID="txtEmploymentdate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlEmploymentdate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calEmploymentdate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calEmploymentdate" runat="server" BackColor="White" 
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

                                          <div id="dvDepartment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Department :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDepartment" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtDepartment" runat ="server" ErrorMessage="*" ControlToValidate="txtDepartment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                          
                                          <div id="dvSupervisor" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtSupervisor" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqSupervisor" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisor" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvSupervisor2" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">2nd Line Supervisor :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtSupervisor2" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtSupervisor2" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisor2" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvLevel" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Level :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtLevel" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtLevel" runat ="server" ErrorMessage="*" ControlToValidate="txtLevel" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvApprisalType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddAppraisalType" Width ="300px" runat="server" Enabled ="true"></asp:DropDownList>
                                                  
                                                    <asp:RequiredFieldValidator ID="reqAppraisalType" runat ="server" ErrorMessage="*" ControlToValidate="ddAppraisalType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddStatus" Width ="300px" runat="server" Enabled ="true"></asp:DropDownList>
                                                  
                                                    <asp:RequiredFieldValidator ID="reqStatus" runat ="server" ErrorMessage="*" ControlToValidate="ddStatus" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>



                                          <%--<div id="dvPayment_Narration" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtPayment_Narration" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>
                                         

                                        <div id="dvReviewDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Review Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtReviewDate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtReviewDate" runat ="server" ErrorMessage="*" controlToValidate="txtReviewDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_ReviewDate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlReviewDate" Position="Bottom" TargetControlID="txtReviewDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlReviewDate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="CalReviewDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="CalReviewDate" runat="server" BackColor="White" 
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

                                        <div id="dvStartDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Start Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtStartDate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqStartDate" runat ="server" ErrorMessage="*" controlToValidate="txtStartDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_StartDate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlStartDate" Position="Bottom" TargetControlID="txtStartDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlStartDate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="CalStateDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="CalStateDate" runat="server" BackColor="White" 
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

                                         <div id="dvEndDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">End Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEndDate" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtEndDate" runat ="server" ErrorMessage="*" controlToValidate="txtEndDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="PopupControlExtender_EndDate" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlEndDate" Position="Bottom" TargetControlID="txtEndDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlEndDate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="CalEndDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="CalEndDate" runat="server" BackColor="White" 
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
                                         
                                         
                                         <div id="dvScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                   <asp:Label id ="lblScore" runat="server" Enabled="false" Font-Bold="True" ForeColor="Black" Width="300px" Text="0.00"></asp:Label>
                                                   
                                               </div>
                                          </div>

                                         <div id="dvKPIScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">KPI Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                   <asp:Label id ="lblKPIScore" runat="server" Enabled="false" Font-Bold="True" ForeColor="Black" Width="300px" Text="0.00"></asp:Label>
                                                   
                                               </div>
                                          </div>

                                         <div id="dvComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtComment" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="70px"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtComment" runat ="server" ErrorMessage="*" ControlToValidate="txtComment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvSupervisor2Comment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor2 Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSupervisor2Comment" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="70px"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqSupervisor2Comment" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisor2Comment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvDevelopmentArea" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Development Area :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDevelopmentArea" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="70px"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqDevelopmentArea" runat ="server" ErrorMessage="*" ControlToValidate="txtDevelopmentArea" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvTrainingIdeas" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Training Ideas :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtTrainingIdeas" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="70px"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqTrainingIdeas" runat ="server" ErrorMessage="*" ControlToValidate="txtTrainingIdeas" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvEmployeeComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeComment" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="70px"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeComment" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeComment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
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

        <asp:UpdatePanel ID="updFormPanel" runat ="server">
        
        <ContentTemplate>


            <div class ="bodyMainDiv" style="margin-top: 30px;">
                <div id="dvMainDvTitlee" style ="padding :20px;"><h2><span>HR Confirmation Line  </span></h2></div>
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

                                          

                                          

                                          

                                         


                                         <div id="dvSN" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">S/N :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSN" Width ="300px" runat="server" Enabled ="false"    ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtSN" runat ="server" ErrorMessage="*" ControlToValidate="txtSN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvResponsibilities" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Responsibility:</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtResponsibilities" Width ="300px" runat="server" Enabled="true" TextMode="MultiLine" Height="70px"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqResponsibilities" runat ="server" ErrorMessage="*" ControlToValidate="txtResponsibilities" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                        

                                     
                                     </div>

                                     <div id="dvClaimDetail2" style="float :left ; width :50%; "> 

                                          <div id="dvAvailableRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Available Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAvailableRating" Width ="300px" runat="server" Enabled="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqAvailableRating" runat ="server" ErrorMessage="*" ControlToValidate="txtAvailableRating" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvSupervisorRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSupervisorRating" Width ="300px" runat="server" Enabled="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqSupervisorRating" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisorRating" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvEmployeeRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeRating" Width ="300px" runat="server" Enabled="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeRating" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeRating" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                        <%-- <div id="dvPayment_NarrationLine" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Narration :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtPayment_Narration_Line" TextMode="MultiLine" Height="60px" Width ="300px" runat="server" Enabled ="true"  ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtPayment_Narration_Line" runat ="server" ErrorMessage="*" ControlToValidate="txtPayment_Narration_Line" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
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

                                        <%--<asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        
                                        <asp:BoundField DataField="txtSN" HeaderText="Entry No" ItemStyle-Width="100"/> 
                                        <asp:BoundField DataField="txtResponsibilities" HeaderText="Responsibilities" ItemStyle-Width="300"/>
                                        <asp:BoundField DataField="txtAvailableRating" HeaderText="Available Rating" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtSupervisorRating" HeaderText="Supervisor Rating" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtEmployeeRating" HeaderText="Employee Rating" ItemStyle-Width="500" />
                                       
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

