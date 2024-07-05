<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmStoreRequisition.aspx.vb" Inherits="frmStoreRequisition" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


             <div class ="bodyMainDiv">
                <div id="dvMainDvTitle" style ="padding :20px;"><h2><span id="spCaption" runat="server">Store Requisition </span></h2></div>
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


                                         <%-- <div id="dvIssuingStore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Issuing Store :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtIssuingtore" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtIssuingtore" runat ="server" ErrorMessage="*" ControlToValidate="txtIssuingtore" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                          <div id="dvRequestdate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtRequestdate" Width ="300px" runat="server" Enabled="false"></asp:TextBox>
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

                              
                                     </div>


                                     <div id="dvPersonalforr" style="float :left ; width :50%; ">  
                                         
                                         <div id="dvRequiredate" class ="dvBoxRows" >
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Date :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtRequiredate" Width ="300px" runat="server" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtRequiredate" runat ="server" ErrorMessage="*" controlToValidate="txtRequiredate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>


                                                    <asp:PopupControlExtender ID="calRequiredate_PopupControlExtender" runat="server" Enabled="True" ExtenderControlID="" PopupControlID="pnlRequiredate" Position="Bottom" TargetControlID="txtRequiredate"></asp:PopupControlExtender>
                                                    <asp:Panel ID="pnlRequiredate" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                                                                 <Triggers>

                                                                      <asp:AsyncPostBackTrigger ControlID="calRequestdate" />

                                                                 </Triggers>
                                                                 <ContentTemplate>
                                                                      <asp:Calendar ID="calRequiredate" runat="server" BackColor="White" 
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


                                         

                                         <div id="dvIssueingStore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Issueing. Store :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:DropDownList ID="ddIssueingStore" runat="server" Width="300px" CausesValidation="False" AutoPostBack="false" Enabled ="true" ></asp:DropDownList>
                                                   <asp:RequiredFieldValidator ID="reqddIssueingStore" runat ="server" ErrorMessage="*" ControlToValidate="ddIssueingStore" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>




                                       <%--  <div id="dvDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                 
                                                   <asp:TextBox ID="txtRequestDescription" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtRequestDescription" runat ="server" ErrorMessage="*" ControlToValidate="txtRequestDescription" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                     </div>

                                </div>

            </div>

    
            

        <asp:UpdatePanel ID="updFormPanel" runat ="server">
        
        <ContentTemplate>


            <div class ="bodyMainDiv" style="margin-top: 30px;">
                <div id="dvMainDvTitlee" style ="padding :20px;"><h2><span>Store Requisition Details  </span></h2></div>
                <div id="dvPersonalDetailss" style="width :100%">
                                     <div id="dvClaimDetail1" style="float :left ; width :50%; ">    
                                                                                                          
                                          <div id="dvRequisitionLineNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Item No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtRequisitionLineNo" Width ="300px" runat="server" Enabled ="false" ReadOnly="true"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <%--<div id="dvBinCode" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Bin Code :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtBinCode" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                   
                                               </div>
                                          </div>--%>

                                          <%--<div id="dvAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtAmount" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>--%>

                                          <%--<div id="dvLineDescription" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Description :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLineDescription" Width ="300px" runat="server"   ></asp:TextBox>
                                                   
                                               </div>
                                          </div>--%>

                                          <div id="dvType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Item :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:DropDownList ID ="ddType" Width ="310px" runat ="server" AutoPostBack="true" ValidationGroup="PVDetails" ></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqddType" runat ="server" ErrorMessage="*" ControlToValidate="ddType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvQuantity" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Quantity :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtQuantity" Width ="300px" runat="server"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtQuantity" runat ="server" ErrorMessage="*" ControlToValidate="txtQuantity" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                     
                                     </div>

                                     <div id="dvClaimDetail2" style="float :left ; width :50%; "> 

                                         <div id="dvUnitMeasure" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Unit Of Measure :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtUnitMeasure" Width ="300px" runat="server" Enabled ="false"  ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtUnitMeasure" runat ="server" ErrorMessage="*" ControlToValidate="txtUnitMeasure" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>
                                         
                                         <div id="dvUnitCost" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Unit Cost :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    
                                                   <asp:TextBox ID="txtUnitCost" Width ="300px" runat="server"  Enabled ="false" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                   <asp:RequiredFieldValidator ID="reqtxtUnitCost" runat ="server" ErrorMessage="*" ControlToValidate="txtUnitCost" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>

                                               </div>
                                          </div>

                                         <div id="dvQtyInStore" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Quantity In Store :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtQtyInStore" Width ="300px" runat="server" text="0" Enabled ="false" ValidationGroup="PVDetails"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqtxtQtyInStore" runat ="server" ErrorMessage="*" ControlToValidate="txtQtyInStore" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvLineAmount" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Amount :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLineAmount" Width ="300px" runat="server"  Enabled ="false"  ValidationGroup="PVDetails"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqLinetxtAmount" runat ="server" ErrorMessage="*" ControlToValidate="txtLineAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="PVDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

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
                                                                                                          
                                        <asp:GridView  Width="100%" ID="gridStoreRequisition" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridStoreRequisition_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging" EnableSortingAndPagingCallbacks="false">




                                 <Columns>

                                        <%--<asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                        <asp:ButtonField CommandName="Select" Text="Select" ItemStyle-Width ="50"/>
                                        <asp:BoundField DataField="txtReqLineNumber" HeaderText="Line No" ItemStyle-Width="100" />
                                        <%--<asp:BoundField DataField="txtBin_Code" HeaderText="Bin Code" ItemStyle-Width="100"/> --%>
                                        <asp:BoundField DataField="txtDescription" HeaderText="Item Type" ItemStyle-Width="300"/>
                                        <%--<asp:BoundField DataField="txtIssuingStore" HeaderText="Issuing Store" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="txtType" HeaderText="Type" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtQtyinstore" HeaderText="Qty In Store" ItemStyle-Width="200" />
                                       <%-- <asp:BoundField DataField="txtQuantity" HeaderText="Qty" ItemStyle-Width="200" />--%>
                                        <asp:BoundField DataField="txtQuantityRequested" HeaderText="Qty Request" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtUnitCost" HeaderText="Unit Cost" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtUnitofMeasure" HeaderText="Unit of Measure" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtLintAmount" HeaderText="Amount" ItemStyle-Width="200" />
                                        <asp:BoundField DataField="txtKey" HeaderText="" ItemStyle-Width="1" Visible="true" />

                                     
                                        <%--<asp:BoundField DataField="txtDateSpent" HeaderText="Date Spent" ItemStyle-Width="60" DataFormatString="{0:d}" />--%>
                             
                  
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
                                                    
                                                     <asp:Button ID="btnSave" runat="server" Text="Submit Store Requisition" CssClass ="button" />
                                                    
                                                 
                                               </div>
                                          </div>


        </div>


</asp:Content>

