<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmCanteenApplication.aspx.vb" Inherits="frmCanteenApplication" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     
   
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="updFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>


    <asp:UpdatePanel ID="updFormPanel" runat ="server" >

        <ContentTemplate>

            <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Canteen Application </span></h2></div>
                <div id="dvPersonalDetails" style="width :100%">
                                     <div id="dvPersonalfor" style="float :left ; width :70%; ">    

                                          <div id="dvDocumentNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Document No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDocumentNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>


                                                                                                          
                                       
                                          <div id="dvRequestType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Request Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddRequestType" runat="server" Width="300px" CausesValidation="False" AutoPostBack="true" Enabled="False"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqRequestType" runat ="server" ErrorMessage="*" ControlToValidate="ddRequestType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvVisitorName" class ="dvBoxRows" runat="server" visible="false">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Visitor's Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtVisitorName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>


                                          <div id="dvRC" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">RC. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddRC" Enabled="false" runat="server" Width="300px" CausesValidation="False" AutoPostBack="true"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqRC" runat ="server" ErrorMessage="*" ControlToValidate="ddRC" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status. :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddStatus" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled="false"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqStatus" runat ="server" ErrorMessage="*" ControlToValidate="ddStatus" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>


                                          <div id="dvEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <div id="dvEmployeeName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Staff Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeName" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <div id="dvDeptCode" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Department :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtDeptCode" Width ="300px" runat="server" readonly="" Enabled="False"   ></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="reqtxtMiddleName" runat ="server" ErrorMessage="*" ControlToValidate="txtMiddleName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <div id="dvAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAmount" Width ="300px" runat="server" Enabled ="False"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvPayrollPeriod" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Payroll Period :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                   <asp:DropDownList ID="ddPayrollPeriod" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled="true"></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqPayrollPeriod" runat ="server" ErrorMessage="*" ControlToValidate="ddPayrollPeriod" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                        

                                         <div id="dvApplicationDate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtApplicationDatee" Width ="300px" runat="server" Enabled="true"></asp:TextBox>
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



                                        

                                         <div id="dvUpdate" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:Button ID="btnUpdate" runat="server" Text="Create Canteen Application" ValidationGroup="personDetails" CssClass ="button" />

                                                    
                                               </div>
                                          </div>

                                     </div>

                                </div>

            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>

