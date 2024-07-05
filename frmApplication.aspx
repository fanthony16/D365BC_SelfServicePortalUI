<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmApplication.aspx.vb" Inherits="frmApplication"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     
     
     <%--<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="upFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>--%>

     <asp:UpdatePanel ID="upFormPanel" runat ="server" >
          <ContentTemplate>

     <div class ="bodyMainDiv">

          <div id="dvMainDvTitle" style ="padding-left :20px;"><h2><span id ="spCaption" runat ="server" >Employee Leave Application</span></h2></div>
          <div id="dvSubbodyMainDiv" class ="SubbodyMainDiv">
               
               <asp:Accordion ID="UserAccordion"  runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None">
                
                <Panes>

                    <asp:AccordionPane ID="PersonalDetails"  runat="server">
                        <Header><a href="#" class="accordionhref">Personal Details</a></Header>
                        <Content>
                            <asp:Panel ID="UserReg" runat="server">
                                <div id="dvPersonalDetails" style="width :100%">
                                     <div id="dvPersonalfor" style="float :left ; width :70%; ">    
                                                                                                          

                                          <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">R. Center :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:DropDownList ID="ddRC" runat="server" Width="330px" CausesValidation="False" AutoPostBack="True" ></asp:DropDownList>

                                                    <%--<asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                          <div id="dvEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeNo" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvApplicantName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Applicant Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtApplicantName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqApplicantName" runat ="server" ErrorMessage="*" ControlToValidate="txtApplicantName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvJobTitle" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Job Title :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtJobTitle" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqJobTitle" runat ="server" ErrorMessage="*" ControlToValidate="txtJobTitle" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvJobdescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Job Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtJobDescription" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqJobDescription" runat ="server" ErrorMessage="*" ControlToValidate="txtJobDescription" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvDepartmentt" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Department :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDepartment" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqDepartmentt" runat ="server" ErrorMessage="*" ControlToValidate="txtDepartment" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
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

                                          <div id="dvSupervisorName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor's Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSupervisorName" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqSupervisorName" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisorName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvSupervisorEmail" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor's Email :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSupervisorEmail" Width ="300px" runat="server" Enabled ="false"    ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqSupervisorEmail" runat ="server" ErrorMessage="*" ControlToValidate="txtSupervisorEmail" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     </div>

                                 

                                </div>
                            </asp:Panel>
                        </Content>
                    </asp:AccordionPane>

                    <asp:AccordionPane ID="ContactAddress"  runat="server">
                        <Header><a href="#" class="accordionhref">Leave Details</a></Header>
                        <Content>
                            <asp:Panel ID="Panel1" runat="server">

                               
                                
                                
                                
                                
                                <%--<div id="dvUploadDocument" class ="dvBoxRows" style ="margin-top : 1px;" runat ="server" visible ="true" >

                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Upload Document :</span>
                                               </div>

                                               <div style ="text-align :right ; padding-right :25px;">
                                                    <asp:AjaxFileUpload ID="flReqDocUpload" runat="server" OnUploadComplete="AjaxFileDocumentUploadEvent" ValidationGroup ="valScheduless" EnableViewState="True" Font-Bold="False" />
                                                    
                                               </div>

                                       <div class="dvBoxRowsFieldLabel">
                                          <span style ="font-size : medium;">Doc. Narration :</span>
                                     </div>
                                     <div style ="text-align :left ;">
                                          <asp:TextBox ID="txtDocNarration" Width ="300px" runat="server" Height ="50px" MaxLength ="50"></asp:TextBox>
                                     </div>


                                      <div class="dvBoxRowsFieldLabel">
                                          <span style ="font-size : medium;">.</span>
                                     </div>

                                     <div style ="text-align :left ;">
                                          <asp:Button ID="btnAddDocument" runat="server" Text="Add Document" />
                                     </div>

                                                    
                                          </div>   --%>
                                



                                <div  style="float :left ; width :35%; height :260px; border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                     <div style="width :100%; border-radius :25px 25px 0px 0px; border-style: solid; border-width: thin;height : 30px;  background-color :#fec84c; text-align:center; padding-top : 3px; font-size: 16px;">
                                     
                                          <span style="color:black ;">Leave Details</span>

                                <div id="dvLeavePeriod" class ="dvBoxRows" style="margin-top : 17px;">
                                     <div class="dvBoxRowsFieldLabel">
                                          <span style ="font-size : medium;">Leave Period :</span>
                                     </div>
                                     <div style ="text-align :left ;">
                                          
                                          <asp:DropDownList ID="ddLeavePeriod" runat="server" Width="150px" CausesValidation="False" AutoPostBack="True"></asp:DropDownList>
                                         
                                          <%--<asp:RequiredFieldValidator ID="reqLeavePeriod" runat ="server" ErrorMessage="*" controlToValidate="ddLeavePeriod" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                     </div>
                                </div>                            

                                <div id="dvLeaveType" class ="dvBoxRows">
                                     <div class="dvBoxRowsFieldLabel">
                                          <span style ="font-size : medium;">Leave Type :</span>
                                     </div>
                                     <div style ="text-align :left ;">
                                          
                                          <asp:DropDownList ID="ddLeaveType" runat="server" Width="150px" CausesValidation="False" AutoPostBack="True"></asp:DropDownList>                         
                                          <%--<asp:RequiredFieldValidator ID="reqLeaveType" runat ="server" ErrorMessage="*" controlToValidate="ddLeaveType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>

                                     </div>
                                </div>                            

                                <div id="dvRequestAllowance" class ="dvBoxRows">
                                     <div class="dvBoxRowsFieldLabel">
                                          <span style ="font-size : medium;">Request Allow. :</span>
                                     </div>
                                     <div style ="text-align :left ;">
                                          
                                          <asp:CheckBox ID="chkLeaveAllowance" runat="server" Checked ="false"  />

                                     </div>
                                </div>    








                                          <%--<asp:Panel ID="Panel4" Width ="98%" runat ="server" BorderStyle="Solid" Height ="230px" BorderWidth ="2px">
                                                    <asp:GridView Width="100%" ID="gridRecievedDocument" runat="server" Visible="true" AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
                                                         <Columns>
                                                              <asp:TemplateField HeaderText="">
                                                                 <ItemTemplate>

                                                                      <asp:CheckBox ID="chkSelect" runat="server" Enabled="true" Width ="10" />
                                                                 </ItemTemplate>
                                                              </asp:TemplateField>
                                                              
                                                              <asp:BoundField DataField="DocumentDesc" HeaderText="Desciption" />
                                                              <asp:BoundField DataField="DocumentPath" HeaderText="" HeaderStyle-Width="0" Visible ="true"  />
                                                              <asp:TemplateField HeaderText="">
                                                                  <ItemTemplate>
                                    
                                                                      <asp:ImageButton OnClick="BtnViewDetails_Click" ID="btnViewDocument" runat ="server" ImageUrl="~/images/K view.png" ToolTip="View Document" OnClientClick="BtnViewDetails_Click" ItemStyle-Width ="10px" />
                                        
                                                                  </ItemTemplate>
                                                                   
                                                               </asp:TemplateField>
                                                              
                                                              

                                                         </Columns>

                                                    </asp:GridView>

                                               </asp:Panel>
                                               <div id="Div1" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel" style="width :48%">
                                                    <span id="dvDocumentError" style="color:red ;" runat="server" visible ="false" > Multiple Selection Not allowed!</span>
                                               </div>

                                               <div style ="padding-right :8px; float :left ;"> 

                                                    <asp:Button ID="btnRemoveDocument" runat="server" Text="Delete From Recived Documents" ValidationGroup="RemoveDocument" />
                                               </div>

                                               <div style ="padding-right :8px; float :right  ;"> 

                                                    <asp:Button ID="btnRemoveAllDocument" runat="server" Text="Delete All Recieved Documents" ValidationGroup="RemoveDocument" Visible ="false"  />
                                               </div>

                                              </div>--%>



                                     </div>
                                </div> 




                                <div id="dvAddress2" style="float :left ; width :30%; height :260px; border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                     <div style="width :100%; border-radius :25px 25px 0px 0px; border-style: solid; border-width: thin;height : 30px; background-color :#fec84c; text-align:center; padding-top : 3px; font-size: 16px;">
                                          <span style="color:black;">Leave Details</span>

                                <%--          <div id="dvExamLeaveBalance" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Exam Leave Balance :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtExamLeaveBalance" Width ="300px" runat="server" Enabled="false" Text="0"></asp:TextBox>
                                                    
                                               </div>
                                          </div>--%>

                                          <div id="dvMaxLeaveDays" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Max. Leave Days :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtMaxLeaveDays" Width ="100px" runat="server" Enabled="false" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqMaxLeaveDays" runat ="server" ErrorMessage="*" controlToValidate="txtMaxLeaveDays" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvApplicationDate" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">App. Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtApplicationDatee" Width ="100px" runat="server" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqApplicationDatee" runat ="server" ErrorMessage="*" controlToValidate="txtApplicationDatee" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calApplicationDate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlApplicationDate" Position="Bottom" TargetControlID="txtApplicationDatee"></asp:PopupControlExtender>
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

                                          <div id="dvStartDate" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Start Date</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtStartDate" Width ="100px" runat="server" Enabled="true" ></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="reqtxtStartDate" runat ="server" ErrorMessage="*" controlToValidate="txtStartDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calStartDate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlStartDate" Position="Bottom" TargetControlID="txtStartDate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlStartDate" runat="server">

                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calStartDate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calStartDate" runat="server" BackColor="White" 
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

                                               <div id="Divlogon" style ="width:360px; text-align :left ; padding-left :20px; padding-bottom :10px;" runat ="server" ><span id="spDateError" runat ="server" visible ="false"  > Enter Your Login Details</span></div>


                                          </div>



                                   <%--       <div id="dvRequestLeaveAllow" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Request Leave Allowance :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                   
                                                    <asp:CheckBox ID="chkRequestLeaveAllow" runat="server" />           
                                          </div>


                                          

                                     </div>--%>


                                </div> 

                                </div>

                                <div id="dvAddress3" style="float :left ; width :30%; height :260px; border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                     <div style="width :100%; border-radius :25px 25px 0px 0px; border-style: solid; border-width: thin;height : 30px;background-color :#fec84c; text-align:center; padding-top : 3px; font-size: 16px;">
                                          <span style=" color:black ;">Leave Details</span>
                    

                                          <div id="dvAnnualLeaveTaken" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Leave Taken :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAnnualLeaveTaken" Width ="100px" runat="server" Enabled="false" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqAnnualLeaveTaken" runat ="server" ErrorMessage="*" controlToValidate="txtAnnualLeaveTaken" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvLeaveBalance" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Leave Balance :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLeaveBalance" Width ="100px" runat="server" Enabled="false" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqLeaveBalance" runat ="server" ErrorMessage="*" controlToValidate="txtLeaveBalance" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                          
                                          <div id="dvAppliedDays" class ="dvBoxRows" style="margin-top : 15px;">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Days Applied :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAppliedDays" Width ="100px" runat="server" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqLGA" runat ="server" ErrorMessage="OL" controlToValidate="txtAppliedDays" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     </div>
                                </div> 
          
                            </asp:Panel>
                        </Content>
                    </asp:AccordionPane>     
                                                     
                    <asp:AccordionPane ID="AppInfo"  runat="server">
                        <Header><a href="#" class="accordionhref">Reliever Details</a></Header>
                        <Content>

                            <asp:Panel ID="Panel2" runat="server">

                                <div id="dvReleavers" runat="server"  style="float :left ; width :100%; height :380px;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                     <div id="dvRLV" style="width :100%; border-radius :25px 25px 0px 0px; border-style: solid; border-width: thin;height : 30px; background-color :#fec84c; text-align:center; padding-top : 3px; font-size: 16px;" runat ="server" >
                                          <span style="color:black ;">Reliever Details</span>
                                                                             
                                          <div id="dvReleaver" class ="dvBoxRows" style="margin-top : 15px; margin-left :7px;">
                                               <asp:Panel ID="pnlUploadDetail" Width ="98%" runat ="server" BorderStyle="Solid" Height ="290px" BorderWidth ="2px">
                                                    <asp:GridView Width="100%" ID="gridReleaver" runat="server" Visible="true"  AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" >
                                                         <Columns>

                                                              <asp:TemplateField HeaderText="">
                                                                 <ItemTemplate>

                                                                      <asp:CheckBox ID="chkSelect" runat="server" Enabled="true" Width ="10" />
                                                                 </ItemTemplate>
                                                              </asp:TemplateField>

                                                              <asp:BoundField DataField="No" HeaderText="Employee No" />
                                                              <asp:BoundField DataField="LastName" HeaderText="Last Name"  />
                                                              <asp:BoundField DataField="Firstname" HeaderText="First Name"  />
                                                              <asp:BoundField DataField="MiddleName" HeaderText="Middle Name"  />
                                                              <%--<asp:BoundField DataField="LeaveStatus" HeaderText="Leave Status" />--%>
                                                             
                                                         </Columns>

                                                    </asp:GridView>
                                               </asp:Panel>
                                               
                                         

                                          </div>
                                          

                                     </div>
                                </div> 

                            </asp:Panel>
                        </Content>
                    </asp:AccordionPane>

                    <asp:AccordionPane ID="SubmitApp"  runat="server">
                          <Header><a href="#" class="accordionhref">Submit Leave Application</a></Header>
                        <Content>
                             <asp:Panel ID="Panel3" runat="server">
                                <div style="text-align:center">
                                 <asp:Button ID="btnSubmit" runat="server" Text="Create Leave Application" ValidationGroup="personDetails" />
                                     </div>
                                  <div id="DivError" style ="width:360px; text-align :left ; padding-left :20px; padding-bottom :10px;" runat ="server" ><span id="lblogonMessage" runat ="server" ></span></div>
                                   <div class="dvBoxRowsFieldLabel" style="width :48%">

                                                    <span id="Span2" style="color:red ;" runat="server" visible ="false" > Multiple Selection Not allowed!</span>
                                   </div>
                                          
                                <%--  <div id="dvValSummary">
                    <asp:ValidationSummary id="valSum" 
                             DisplayMode="BulletList"
                             HeaderText="You must enter a value in the following fields:"
                             runat="server" ShowMessageBox="true" ShowSummary="false" />
               </div>--%>


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

