<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmAppraisal.aspx.vb" Inherits="frmAppraisal" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


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

          <div id="dvMainDvTitle" style ="padding-left :20px;"><h2><span id ="spCaption" runat ="server" >Employee APPRAISAL</span></h2></div>
          <div id="dvSubbodyMainDiv" class ="SubbodyMainDiv">
               
               <asp:Accordion ID="UserAccordion"  runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" AutoSize="None">
                
                <Panes>

                    <asp:AccordionPane ID="AppraiseeInformation"  runat="server">

                        <Header><a href="#" class="accordionhref">Appraisee Information </a></Header>
                        <Content>
                            <asp:Panel ID="UserReg" runat="server">
                                <div id="dvPersonalDetails" style="width :100%">

                                    <div id="dvPersonalfor" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                          <div id="dvAppraisalNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAppraisalNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
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

                                          <div id="dvEmployeeName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeName" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                          <div id="dvJobTitle" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Job Title :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtJobTitle" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                          <div id="dvAppraisalPeriod" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal Period :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAppraisalPeriod" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                          <div id="dvAppraisalHalf" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal Half :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAppraisalHalf" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div> 
                                         
                                          <div id="dvDepartmentt" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Department :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDepartment" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         

                                    </div>

                                    <div id="dvPersonalfor2" style="float :left ; width :45%; height: 270px;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                         <div id="dvQuerid" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Queried :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:CheckBox ID="chkQueried" runat="server" Checked="false" Enabled="false" />
                                               </div>
                                          </div>

                                         <div id="dvCurrentLevel" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Current Level :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCurrentLevel" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvCurrentLocation" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Current Location :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCurrentLocation" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:DropDownList ID="ddStatus" runat="server" Width="330px" CausesValidation="False" AutoPostBack="True" Enabled="false" ></asp:DropDownList>

                                                    
                                               </div>
                                          </div>

                                         <div id="dvAppraisalDate" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                    
                                                   <asp:TextBox ID="txtAppraisalDate" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvAgreed" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">I Agreed :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:CheckBox ID="chkAgreed" runat="server" Checked="false" />
                                               </div>
                                          </div>

                                         <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">R. Center :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:DropDownList ID="ddRC" runat="server" Width="330px" CausesValidation="False" AutoPostBack="True" ></asp:DropDownList>

                                                    
                                               </div>
                                          </div>

                                    </div>


                                </div>
                            </asp:Panel>
                        </Content>
                    </asp:AccordionPane>

                    <asp:AccordionPane ID="SelfEvaluation"  runat="server">

                        <Header><a href="#" class="accordionhref">Self Evaluation</a></Header>
                        <Content>
                            <asp:Panel ID="Panel1" runat="server">
                                <div id="dvSelfEvaluationAll" style="width :99%">
                                    <div id="dvSelf1" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvSelfAppraisalNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSelfAppraisalNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <%--<div id="dvSelfDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtSelfDescription" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>--%>

                                        <div id="dvSelfDescriptionDrop" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Evaluations:</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID="ddSelfEvaluationList" AutoPostBack="true" Width="300px" runat="server"></asp:DropDownList>
                                               </div>
                                          </div>

                                        <div id="dvSelfEvaluation" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Self Evaluation :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtSelfEvaluation" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnAdd" runat="server" Text="Add Self Evaluation" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   
                                              
                                               </div>
                                          </div>

                                    </div>
                                </div>

                                <div id="dvSelfEvaluationGrid" style="width :99%">

                                    <div id="dvSelf2" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridSelfEvaluation" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">




                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtLineNo" HeaderText="Line No" ItemStyle-Width="70"/>    
                                        <%--<asp:BoundField DataField="txtAppraisalNo" HeaderText="Appraisal No" ItemStyle-Width="70"/> --%>
                                        <%--<asp:BoundField DataField="txtAppraisalPeriod" HeaderText="Appraisal Period" ItemStyle-Width="80"/>--%>
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtSelf_Evaluation" HeaderText="Self Evaluation" ItemStyle-Width="200" />
                                        
                
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

                            </asp:Panel>

                        </Content>

                    </asp:AccordionPane>

                    <asp:AccordionPane ID="FunctionalAssessment"  runat="server">

                        <Header><a href="#" class="accordionhref">Functional Assessment</a></Header>
                        <Content>
                            <asp:Panel ID="Panel2" runat="server">
                                <div id="dvFunctionalAssessment" style="width :99%">
                                    <div id="dvFunctionalAssessment1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvFAtargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtFATargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFADescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFADescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <%--<div id="dvFATiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddFATiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="True" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>--%>
                                        
                                        

                                    </div>
                                    <div id="dvFunctionalAssessment2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">


                                        <div id="dvFAWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFAWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFAActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Result :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFAActualResult" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFAAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Agreed Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFAAgreedScore" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFADetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnFAAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   
                                              
                                               </div>
                                          </div>


                                    </div>


                                </div>

                                <div id="dvBehavouralGrid" style="width :99%">

                                    <div id="dvFunctionalAssessment3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridFunctionalAssessment" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <%--<asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtActualResult" HeaderText="Actual Result" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtAgreedScore" HeaderText="AgreedScore" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="OrganisationalCapability"  runat="server">

                        <Header><a href="#" class="accordionhref">Organisational Capability</a></Header>
                        <Content>
                            <asp:Panel ID="Panel3" runat="server">
                                <div id="dvOrganisationalCapability" style="width :99%">
                                    <div id="dvOrganisationalCapability1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvOCtargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtOCtargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvOCDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtOCDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <%--<div id="dvOCTiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddOCTiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="True" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>--%>
                                        
                                        

                                    </div>
                                    <div id="dvOrganisationalCapability2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">


                                        <div id="dvOCWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtOCWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvOCActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Result :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtOCActualResult" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvOCAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Agreed Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtOCAgreedScore" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvOCDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnOCAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   
                                              
                                               </div>
                                          </div>


                                    </div>


                                </div>

                                <div id="dvOrganisationalCapabilityGrid" style="width :99%">

                                    <div id="dvOrganisationalCapability3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridOrganisationalCapability" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <%--<asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtActualResult" HeaderText="Actual Result" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtAgreedScore" HeaderText="AgreedScore" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="ManagementCompetency"  runat="server" >

                        <Header><a href="#" class="accordionhref">Management Competency</a></Header>
                        <Content>
                            <asp:Panel ID="Panel5" runat="server">
                                <div id="dvManagementCompetency" style="width :99%">
                                    <div id="dvManagementCompetency1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvMCtargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtMCtargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvMCDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtMCDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <%--<div id="dvMCTiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddMCTiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="True" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>--%>
                                        
                                        

                                    </div>
                                    <div id="dvManagementCompetency2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">


                                        <div id="dvMCWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtMCWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvMCActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Actual Result :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtMCActualResult" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvMCAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Agreed Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtMCAgreedScore" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvMCDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnMCAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                                   
                                              
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                <div id="dvManagementCompetencyGrid" style="width :99%">

                                    <div id="dvManagementCompetency3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridManagementCompetency" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtActualResult" HeaderText="Actual Result" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtAgreedScore" HeaderText="AgreedScore" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="Financial"  runat="server">

                        <Header><a href="#" class="accordionhref">Financial - KPI</a></Header>
                        <Content>
                            <asp:Panel ID="Panel6" runat="server">
                                <div id="dvFKPI" style="width :99%">
                                    <div id="dvFKPI1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvFKPItargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtFKPItargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFKPIDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFKPIDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>


                                        <div id="dvFKPIWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFKPIWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>


                                        <div id="dvFKPITiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddFKPITiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       
                                                       
                                                       
                                                       
                                                       
                                                       
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>
                                        

                                    </div>
                                    <div id="dvFKPI2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvFKPIRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddFKPIRating" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >ABOVE</asp:ListItem>
                                                       <asp:ListItem >BELOW</asp:ListItem>
                                                       <asp:ListItem >NIL</asp:ListItem>
                                                       <asp:ListItem >ON TARGET</asp:ListItem>
                                                       <asp:ListItem >OUTSTANDING</asp:ListItem>
                                                       <asp:ListItem >THRESHOLD</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>

                                        <div id="dvFKPIScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFKPIScore" Width ="300px" runat="server" Enabled = "false" Text ="0"     ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFKPISupervisorScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtFKPISupervisorScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvFKPIDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnFKPIAdd" runat="server" Text="Add Assessment" ValidationGroup="FKPI" CssClass ="button" />
                                                    
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                <div id="dvFKPIGrid" style="width :99%">

                                    <div id="dvFKPI3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridFKPI" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtRating" HeaderText="Rating" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtScore" HeaderText="Score" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtSupervisorscore" HeaderText="Supervisor Score" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="Customer"  runat="server">

                        <Header><a href="#" class="accordionhref">Customer - KPI</a></Header>
                        <Content>
                            <asp:Panel ID="Panel7" runat="server">

                                <div id="dvCKPI" style="width :99%">
                                    <div id="dvCKPI1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvCKPItargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCKPItargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCKPIDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtCKPIDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCKPIWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtCKPIWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>
                                        
                                        <div id="dvCKPITiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                     
                                                   <asp:DropDownList ID="ddCKPITiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>

                                        
                                        

                                    </div>
                                    <div id="dvCKPI2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvCKPIRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddCKPIRating" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >ABOVE</asp:ListItem>
                                                       <asp:ListItem >BELOW</asp:ListItem>
                                                       <asp:ListItem >NIL</asp:ListItem>
                                                       <asp:ListItem >ON TARGET</asp:ListItem>
                                                       <asp:ListItem >OUTSTANDING</asp:ListItem>
                                                       <asp:ListItem >THRESHOLD</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>

                                        <div id="dvCKPIActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtCKPIScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCKPIAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtCKPISupervisorScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCKPIDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnCKPIAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                <div id="dvCKPIGrid" style="width :99%">

                                    <div id="dvCKPI3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridCKPI" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtRating" HeaderText="Rating" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtScore" HeaderText="Score" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtSupervisorscore" HeaderText="Supervisor Score" ItemStyle-Width="50" />                                       

                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="Internal"  runat="server">

                        <Header><a href="#" class="accordionhref">Internal - KPI</a></Header>
                        <Content>
                            <asp:Panel ID="Panel8" runat="server">
                                <div id="dvIKPI" style="width :99%">
                                    <div id="dvIKPI1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvIKPItargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtIKPItargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="true"  ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvIKPIDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtIKPIDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvIKPIWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtIKPIWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvIKPITiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddIKPITiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>
                                        

                                    </div>
                                    <div id="dvIKPI2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvIKPIRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddIKPIRating" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >ABOVE</asp:ListItem>
                                                       <asp:ListItem >BELOW</asp:ListItem>
                                                       <asp:ListItem >NIL</asp:ListItem>
                                                       <asp:ListItem >ON TARGET</asp:ListItem>
                                                       <asp:ListItem >OUTSTANDING</asp:ListItem>
                                                       <asp:ListItem >THRESHOLD</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>

                                        <div id="dvIKPIActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtIKPIScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvIKPIAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtIKPISupervisorScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvIKPIDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnIKPIAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                <div id="dvIKPIGrid" style="width :99%">

                                    <div id="dvIKPI3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridIKPI" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtRating" HeaderText="Rating" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtScore" HeaderText="Score" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtSupervisorscore" HeaderText="Supervisor Score" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="LearningGrowth"  runat="server">

                        <Header><a href="#" class="accordionhref">Learning and Growth - KPI</a></Header>
                        <Content>
                            <asp:Panel ID="Panel9" runat="server">
                                <div id="dvLCKPI" style="width :99%">
                                    <div id="dvLCKPI1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvLKPItargetObjective" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Target Objective :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLKPItargetObjective" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvLKPIDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtLKPIDescription" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvLKPIWeight" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Weight :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtLKPIWeight" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvLKPITiming" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Timing :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddLKPITiming" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >All_Year</asp:ListItem>
                                                       <asp:ListItem >Biannual</asp:ListItem>
                                                       <asp:ListItem >Daily</asp:ListItem>
                                                       <asp:ListItem >Hourly</asp:ListItem>
                                                       <asp:ListItem >Monthly</asp:ListItem>
                                                       <asp:ListItem >Quarterly</asp:ListItem>
                                                       <asp:ListItem >Weekly</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>
                                        
                                    </div>
                                    <div id="dvLKPI2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvLKPIRating" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Rating :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   
                                                   <asp:DropDownList ID="ddLKPIRating" runat="server" Width="310px" CausesValidation="False" AutoPostBack="false" >
                                                       
                                                       <asp:ListItem ></asp:ListItem>
                                                       <asp:ListItem >ABOVE</asp:ListItem>
                                                       <asp:ListItem >BELOW</asp:ListItem>
                                                       <asp:ListItem >NIL</asp:ListItem>
                                                       <asp:ListItem >ON TARGET</asp:ListItem>
                                                       <asp:ListItem >OUTSTANDING</asp:ListItem>
                                                       <asp:ListItem >THRESHOLD</asp:ListItem>
                                                       
                                                   </asp:DropDownList>

                                               </div>
                                          </div>

                                        <div id="dvLKPIActualResult" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtLKPIScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvLKPIAgreedScore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtLKPISupervisorScore" Width ="300px" runat="server" Enabled ="false" Text="0"    ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvLKPIDetailAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnLKPIAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                <div id="dvLKPIGrid" style="width :99%">

                                    <div id="dvLGKPI3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridLKPI" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtTargetObjective" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtDescription" HeaderText="Description" ItemStyle-Width="400"/>
                                        <asp:BoundField DataField="txtTiming" HeaderText="Timing" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtRating" HeaderText="Rating" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtWeight" HeaderText="Weight" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtScore" HeaderText="Score" ItemStyle-Width="50" />
                                        <asp:BoundField DataField="txtSupervisorscore" HeaderText="Supervisor Score" ItemStyle-Width="50" />                                       
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>

                    <asp:AccordionPane ID="CareerDevelopment"  runat="server">

                        <Header><a href="#" class="accordionhref">Career Development and Training Needs</a></Header>
                        <Content>
                            <asp:Panel ID="Panel10" runat="server">
                                <div id="dvCareerDev" style="width :99%">
                                    <div id="dvCareerDev1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvCareerDevQuestion" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Question :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCDQuestion" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false" Height="50px"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCareerDevAnswer" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Answer :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtCDAnswer" Width ="300px" runat="server" Enabled ="true" TextMode="MultiLine" Height="50px"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvCareerDevAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnCDAdd" runat="server" Text="Add Assessment" ValidationGroup="PVDetails" CssClass ="button" />
                                                    
                                               </div>
                                          </div>

                                    
                                        
                                    </div>
                                  

                                </div>

                                <div id="dvCDGrid" style="width :99%">

                                    <div id="dvCD3" style="float :left ; width :100%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <asp:GridView  Width="100%" ID="gridCareerDev" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridSelfEvaluation_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">

                                 <Columns>
                                    
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtQuestion" HeaderText="Target Objective" ItemStyle-Width="250"/> 
                                        <asp:BoundField DataField="txtAnswer" HeaderText="Description" ItemStyle-Width="400"/>
                
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


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>


                    <asp:AccordionPane ID="Comment"  runat="server">

                        <Header><a href="#" class="accordionhref">Comment</a></Header>
                        <Content>
                            <asp:Panel ID="Panel11" runat="server">
                                <div id="dvComment" style="width :99%">
                                    <div id="dvComment1" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        <div id="dvEmployeeComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee's Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeComment" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="true" Height="50px"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvSupervisorComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Supervisor Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtSupervisorComment" Width ="300px" runat="server" Enabled ="false" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                                    
                                               </div>
                                          </div>
                                        
                                    </div>
                                    <div id="dvComment2" style="float :left ; width :45%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                        
                                        <div id="dvHODComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">HOD Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtHODComment" Width ="300px" TextMode="MultiLine" runat="server" Enabled ="false" Height="50px"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                        <div id="dvMDComment" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">MD Comment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtMDComment" Width ="300px" runat="server" Enabled ="false" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                                    
                                               </div>
                                          </div>
                                        
                                        <div id="dvCommentAction" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">

                                                   <asp:Button ID="btnComment" runat="server" Text="Update Comment / Responsibility Center" ValidationGroup="PVDetails" CssClass ="button" />
                                                   <span id="spCommentError" runat="server" style="color : red;">.</span>
                                               </div>
                                          </div>


                                    </div>

                                </div>

                                


                            </asp:Panel>

                        </Content>


                    </asp:AccordionPane>


                    <asp:AccordionPane ID="SubmitApp"  runat="server">
                        
                        <Header><a href="#" class="accordionhref">Appraisal Actions</a></Header>
                        <Content>
                             <asp:Panel ID="Panel4" runat="server">
                                <div style="text-align:center">
                                 <asp:Button ID="btnSendToSupervisor" runat="server" Text="Send To Supervisor" ValidationGroup="personDetails" CssClass ="button" />

                                    
                                 <asp:Button ID="btnAppraisalScore" runat="server" Text="View Appraisal Score" ValidationGroup="personDetails" CssClass ="button" />
                                     </div>




                                  <div id="DivError" style ="width:360px; text-align :left ; padding-left :20px; padding-bottom :10px;" runat ="server" ><span id="lblogonMessage" runat ="server" ></span></div>
                                   <div class="dvBoxRowsFieldLabel" style="width :48%">

                                             <span id="Span2" style="color:red ;" runat="server" visible ="true" >.</span>

                                   </div>
                                          
                             </asp:Panel>
                        </Content>
                     </asp:AccordionPane>
                    
                </Panes>
            
               </asp:Accordion>

              
               
          </div>
          
     </div>

              
<asp:Button id="btnShowScorePopup" runat="server" style="display:none" />
       <asp:ModalPopupExtender ID="mpAppScore" runat="server" PopupControlID="pnlAppScore" TargetControlID="btnShowScorePopup" CancelControlID="btnAppScoreClose" BackgroundCssClass="modalBackground" ></asp:ModalPopupExtender>            
                 <asp:Panel ID="pnlAppScore" runat="server" CssClass="modalPopup" align="center" Height ="700px" style = "display:none" Width ="1000px">


    <div id="dvGeneral" style="width :100%">

                                    <div id="dvScoreHeaderLeft" style="float :left ; width :50%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                          <div id="dvScoreAppraisalNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreAppraisalNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                          <div id="dvScoreEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreEmployeeNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div> 

                                    </div>

                                    <div id="dvScoreHeaderRight" style="float :left ; width :45%; height: 75px; border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">

                                         <div id="dvScorePeriod" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Appraisal Period :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScorePeriod" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                               </div>
                                          </div>

                                    </div>

    </div>

                     
                     <div id="dvScoreDetails" style="width :100%">

                                    <div id="dvScoreDetailLeft" style="float :left ; width :48%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                         
                                        <div id="dvScoreDetailHeader1" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; font-weight:300; color:red;">FIRST HALF :</span>
                                               </div>       
                                        </div>

                                         <div id="dvScoreTotalFirst" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium;">Total First :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreTotalFirst" Width ="150px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvScoreDetailHeader2" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; ">BEHAVIOURAL :</span>
                                               </div>       
                                        </div>
                                        <br />
                                         <div id="dvScoreFA" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium;">Functional Assessment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreFA" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvScoreOC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Organisational Capability :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreOC" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreMC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Management Competence :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreMC" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreBA" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Behavioural Aggregate :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreBA" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreBA40" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Behavioural (40%) :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreBA40" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreDetailHeader3" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; ">KPI :</span>
                                               </div>       
                                        </div>

                                         <div id="dvScoreFIN" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Financial :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreFIN" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreCUS" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Customer :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreCUS" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreIP" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Internal Process :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreIP" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreLG" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Learning Growth :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreLG" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreAS" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Aggregate Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreAS" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreKPI60" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">KPI (60%) :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreKPI60" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>



                                    </div>

                                    <div id="dvScoreDetailRight" style="float :left ; width :48%;  border-style: solid; border-width: thin; border-radius: 25px; margin : 5px;">
                                         
                                        <div id="dvScoreDetailHeader2R" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; color:red;">SECOND HALF :</span>
                                               </div>       
                                        </div>

                                         <div id="dvScoreTotalFirstR" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium;">Total Second :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreTotalFirstR" Width ="150px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvScoreDetailHeader2R" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; ">BEHAVIOURAL :</span>
                                               </div>       
                                        </div>
                                        <br />
                                         <div id="dvScoreFAR" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium;">Functional Assessment :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreFAR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                          </div>

                                         <div id="dvScoreOCR" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Organisational Capability :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreOCR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreMCR" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Management Competence :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreMCR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreBA" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Behavioural Aggregate :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreBAR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreBA40" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Behavioural (40%) :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreBA40R" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreDetailHeader3R" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel" style="width:100%;text-align:left;">
                                                    <span style ="font-size : medium; ">KPI :</span>
                                               </div>       
                                        </div>

                                         <div id="dvScoreFINR" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Financial :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreFINR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreCUSR" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Customer :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreCUSR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreIPR" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Internal Process :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreIPR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreLGR" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Learning Growth :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreLGR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreASR" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">Aggregate Score :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreASR" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>

                                         <div id="dvScoreKPI60R" class ="dvBoxRows">
                                        
                                            <div class="dvBoxRowsFieldLabel" style="width:200px;">
                                                    <span style ="font-size : medium; ">KPI (60%) :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtScoreKPI60R" Width ="200px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    
                                               </div>
                                        </div>



                                    </div>


    </div>


    

        
        <br />

    <asp:Button ID="btnAppScoreClose" runat="server" Text="Close" CssClass ="button" />
    </asp:Panel>






    </ContentTemplate>

     </asp:UpdatePanel>

</asp:Content>

