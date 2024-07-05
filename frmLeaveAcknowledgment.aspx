<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmLeaveAcknowledgment.aspx.vb" Inherits="frmLeaveAcknowledgment" Theme ="Blue"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true" ></asp:ToolkitScriptManager>    


     <asp:UpdatePanel ID="upFormPanel" runat ="server" >
          <ContentTemplate>
               <div class ="bodyMainDiv">
                    <div id="dvMainDvTitle" style ="padding-left :20px;"><h2><span id ="spCaption" runat ="server" >Employee Leave Acknowledgment </span></h2></div>

                    <div id="dvSubbodyMainDiv" class ="SubbodyMainDiv">

                         <asp:Accordion ID="UserAccordion"  runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None">
                              <Panes>

                                   <asp:AccordionPane ID="PersonalDetails"  runat="server">
                        <Header><a href="#" class="accordionhref">Personal Details</a></Header>
                        <Content>
                            
                                                                                                          

                                          <asp:Panel ID="UserReg" runat="server" >
                                <div id="dvPersonalDetails" style="width :100%; border-bottom-width :thin ;">
                                     <div id="dvPersonalfor" style="float :left ; width :50%; ">    
                                                                                                          
                                          <div id="dvEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeNo" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeNo" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvApplicantName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeName" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeName" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>


                                          <div id="dvLeaveNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Leave No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                    <asp:DropDownList ID="ddLeaveNo" runat="server" Width="300px" CausesValidation="False" AutoPostBack="True"></asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="reqddLeaveNo" runat ="server" ErrorMessage="*" ControlToValidate="ddLeaveNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                     </div>




                                          <div id="dvJobTitle" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Leave Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLeaveType" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqLeaveType" runat ="server" ErrorMessage="*" ControlToValidate="txtLeaveType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvAppliedDays" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Days Applied :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAppliedDays" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAppliedDays" runat ="server" ErrorMessage="*" ControlToValidate="txtAppliedDays" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvStartDate" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Start Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtStateDate" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqStateDate" runat ="server" ErrorMessage="*" ControlToValidate="txtStateDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     </div>

                                     <div id="dvPersonalPassport" style="float :left ; width :50%;  ">
                                               <div id="Return Date" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Return Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtReturnDate" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    
                                               </div>
                                          </div>
                                     </div>

                                     <div id="dvDaySpent" style="float :left ; width :50%;  ">
                                               <div id="dvSpentDays" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Days Spent :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDaySpent" Width ="300px" runat="server" Enabled ="true"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtDaySpent" runat ="server" ErrorMessage="*" ControlToValidate="txtDaySpent" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                     </div>

                                     <div id="dvActualReturnDay" style="float :left ; width :50%;  ">
                                               <div id="Div2" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Return Day :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtActualReturnDay" Width ="300px" runat="server" Enabled ="true"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqActualReturnDay" runat ="server" ErrorMessage="*" ControlToValidate="txtActualReturnDay" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>



                                                    <asp:PopupControlExtender ID="calActualReturnDay_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlActualReturnDay" Position="Bottom" TargetControlID="txtActualReturnDay"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlActualReturnDay" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calActualReturnDay" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calActualReturnDay" runat="server" BackColor="White" 
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

                                     <div id="dvComment" style="float :left ; width :50%;  ">
                                               <div id="Div3" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtComment" Width ="300px" runat="server" Enabled ="true"  TextMode="MultiLine" Height="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqComment" runat ="server" ErrorMessage="*" ControlToValidate="txtComment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                     </div>

                                     <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">R. Center :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:DropDownList ID="ddRC" runat="server" Width="300px" CausesValidation="False" AutoPostBack="True"></asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                     </div>

                                     <div id="dvSubmit" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <%--<span style ="font-size : medium;">R. Center :</span>--%>
                                               </div>
                                               <div style ="text-align :center;">
                                                    
                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" />

                                                    <div id="DivError" style ="width:360px; text-align :left ; padding-left :20px; padding-bottom :10px;" runat ="server" ><span id="lblogonMessage" runat ="server" ></span></div>

                                                    
                                               </div>
                                     </div>




                                </div>
                            </asp:Panel>

                                          

                        </Content>
                    </asp:AccordionPane>

                              </Panes> 
                         
                         </asp:Accordion> 


                    </div>

               </div>
          </ContentTemplate> 
     </asp:UpdatePanel> 

             

</asp:Content>

