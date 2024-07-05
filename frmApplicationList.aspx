<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmApplicationList.aspx.vb" Inherits="frmApplicationList"  EnableEventValidation="false"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     


      <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="updFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>

      <asp:UpdatePanel ID="updFormPanel" runat="server">

          <ContentTemplate>
               
               <div class ="bodyMainDiv" >
          <div id="dvMainDvTitle" style ="padding-left :20px;"><h2><span>My Leave Application List...</span></h2></div>
          <div id="dvSubbodyMainDiv" class ="SubbodyMainDiv" style="text-align:center ; float :left ;">
               
               <div class="dvMiddleBox" style="border-radius :25px 25px 0px 0px; border :2px solid; margin-top :10px; padding  :5px 10px 0px 10px; width:95%" >

                    <asp:Panel ID="pnlGrid" runat ="server"   >
                            <%--<asp:GridView Width="100%" ID="gridProcessing" runat="server" Visible="true" PageSize="5" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridLeaveApplication_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging">--%>


                                <asp:GridView  Width="100%" ID="gridProcessing" runat="server" Visible="true" PageSize="50" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="true" OnRowDataBound ="gridLeaveApplication_RowDataBound" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" OnPageIndexChanging="datagrid_PageIndexChanging">




                                 <Columns>

                                        <asp:TemplateField HeaderText="">
                                             <ItemTemplate>
                                                  <asp:CheckBox ID="chkProcessing" runat="server" Enabled="true"  AutoPostBack="true"/>
                                             </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:ButtonField CommandName="Select" Text="Select"/>
                                        <asp:BoundField DataField="ApplicationNo" HeaderText="Leave Code" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="EmployeeNo" HeaderText="Employee No" ItemStyle-Width="100"/> 
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Full Name" ItemStyle-Width="300"/>
                                        <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="DaysApplied" HeaderText="No Of Days" ItemStyle-Width="70" />
                                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" ItemStyle-Width="60" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="EndDate" HeaderText="End Date" ItemStyle-Width="60" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="Releaver" HeaderText="Reliever" ItemStyle-Width="300" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="50" />


                                       <asp:TemplateField HeaderText="">
                                              <ItemTemplate>
                                    
                                                  <asp:ImageButton OnClick="BtnViewApprovalEntries_Click" ID="btnViewApprovalEntries" runat ="server" ImageUrl="~/images/viewapproval.png" ToolTip="View Approval Entries" ItemStyle-Width ="10px" />
                                        
                                              </ItemTemplate>
                                       </asp:TemplateField>



                                       <asp:TemplateField HeaderText="">
                                              <ItemTemplate>
                                    
                                                  <asp:ImageButton OnClick="BtnViewDetails_Click"  ID="btnViewApplicationLog" runat ="server" ImageUrl="~/images/edit.JPG" ToolTip="View Application" ItemStyle-Width ="10px" />
                                        
                                              </ItemTemplate>
                                       </asp:TemplateField>


                                     


                                     



                                        
                  
                                 </Columns>
                    
                                        <pagersettings mode="NextPreviousFirstLast"
                                        firstpagetext="First"
                                        lastpagetext="Last"
                                        nextpagetext="Next"
                                        previouspagetext="Prev"   
                                        position="Bottom"/> 
                              </asp:GridView>
                        </asp:Panel>
       
       
        <div><hr /></div>

        


        <div id="dvTag" style ="width :100%; padding : 5px; text-align :right ; height :20px; ">
             <div style="float:left ; ">
                <%-- <asp:ImageButton ID="btnNew" runat ="server" ImageUrl="~/images/add.png" ToolTip="Add New Application" Visible="true"/>--%>

                 <asp:Button ID="btnNew" runat="server" Text="Create Leave Application" CssClass ="button"  />

             </div>
             <div style="float:left ;padding-left :30px; ">
                 
                 <%--<asp:ImageButton ID="btnEdit" runat ="server" ImageUrl="~/images/edit (1).png" ToolTip="Edit Application"/> --%>

             </div>
             <%--<div style="float:left ;padding-left :30px; "><asp:ImageButton ID="btnCancel" runat ="server" ImageUrl="~/images/remove.png" ToolTip="Cancel Application" Visible="False"/>

             </div>--%>
             
             <div id="dvErrorMessage" style="float:left; color :red ; padding-left :0px; width : 120px;" runat ="server" visible ="false"  ><span>Multiple Selection Not Allowed !!! </span></div>

             <div style="float:left ; padding-left :350px; ">
                  <%--<asp:Button ID="btnTagAll" runat="server" Text="Tag All" />--%>
                  <%--<asp:ImageButton ID="btnTagAll" runat ="server" ImageUrl="~/images/success.png" ToolTip="Tag All"/>--%>
             </div>
             <div style="float:left; padding-left :100px;">
                  <%--<asp:Button ID="btnUnTagAll" runat="server" Text="Un-Tag All" />--%>
                  <%--<asp:ImageButton ID="btnUnTagAll" runat ="server" ImageUrl="~/images/error.png" ToolTip="Un-Tag All"/>--%>
             </div>
             <div style="float:left;padding-left :50px;">
                 
                 <asp:Button ID="btnSendApprovalRequest" runat="server" Text="Send Approval Request" CssClass ="button"  />

                 

             </div>
        </div>


    </div>
              
          </div>
     </div>



       <asp:Button id="btnShowCommentPopup" runat="server" style="display:none" />
       <asp:ModalPopupExtender ID="mpAppComments" runat="server" PopupControlID="pnlAppComments" TargetControlID="btnShowCommentPopup" CancelControlID="btnMPAppComments" BackgroundCssClass="modalBackground" ></asp:ModalPopupExtender>            
                  <asp:Panel ID="pnlAppComments" runat="server" CssClass="modalPopup" align="center" Height ="600px" style = "display:none" Width ="600px">

    <div id="Div2" class ="dvSideBox" style="width :98%"> 
        
        <div id="Div3" style="border-color:#3a4f63; border :2px solid ; width :100%;">

            <div id="Div4" class ="dvBoxHeader"><span style ="color :#dde4ec;"><strong>Benefit Application Comment</strong></span></div>
            <div id="Div5" class="dvBoxbody">
               
               <div class="dvBoxRows" style =" width :300px;">
                   
               <div style="padding-top :5px; margin-bottom  :15px;">
                    <div style ="float :left "><span>Application ID :</span></div>
                    <div style ="float :left "><asp:TextBox ID="txtApplicationID" runat="server" Width ="150px" Enabled="false"></asp:TextBox></div>
               </div>
                   
                </div>
                
               <div class="dvBoxRows" style =" width :300px; padding-top :10px; ">
                    
                     <asp:TextBox id="txtApplicationComment" runat ="server" TextMode ="MultiLine" ValidationGroup  ="ApplicationComment" Height="80px" Width="100%" MaxLength="70"></asp:TextBox><asp:RequiredFieldValidator ID="reqApplicationComment" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtApplicationComment" ValidationGroup="ApplicationComment"></asp:RequiredFieldValidator>
                </div>

               <div class="dvBoxRows" style =" width :300px; padding-top :10px; ">
                    <div style ="float :left "><span>Error Type :</span></div>
                    <asp:DropDownList ID="cbErrorCheckList"  runat ="server" Width ="220px" ></asp:DropDownList>
                    
                </div>


                 <div id="Div6"  class="dvBoxRows" style =" width :300px; float :left  ;text-align :right ; padding :10px;">
                   <asp:ImageButton ID="btnAppCommentAdd" runat ="server" ImageUrl="~/images/add.png" ToolTip="Add To Comment" CausesValidation="true" ValidationGroup  ="ApplicationComment"  />
                     
                    
                </div>


                  <div class="dvBoxRows" style =" width :570px; padding-top :10px; ">
                    
                       <asp:ListBox ID="lstComments" runat="server" Width ="100%" Height ="300px"></asp:ListBox>
                </div>

                 <div id="Div7"  class="dvBoxRows" style =" width :560px; float :left  ;text-align :right ; padding :10px;">
                   <asp:ImageButton ID="btnAppCommentRemove" runat ="server" ImageUrl="~/images/cancel.png" ToolTip="Remove Comment" CausesValidation="true" ValidationGroup  ="AppComment"  />
                     
                    
                </div>
                 
            </div>
    
    </div>
    
    </div>
        
        <br />

    <asp:Button ID="btnMPAppComments" runat="server" Text="Close" />
    </asp:Panel>




               <asp:Button id="btnShowPopupApprovalEntries" runat="server" style="display:none" />    
     <asp:ModalPopupExtender ID="mpApprovalEntries" runat="server" PopupControlID="pnlApprovalEntry" TargetControlID="btnShowPopupApprovalEntries" CancelControlID="btnCloseApprovalEntries" BackgroundCssClass="modalBackground" ></asp:ModalPopupExtender>
                       <asp:Panel ID="pnlApprovalEntry" runat="server" CssClass="modalPopup" align="center" Height ="700px" style = "display:none" Width ="600px">

    <div id="Div8" class ="dvSideBox" style="width :98%"> 
        
        <div id="Div9" style="border-color:#3a4f63; border :2px solid ; width :100%;">

            <div id="dvApprovalEntries" style ="padding-left :20px;"><h2><span>Approval Entries...</span></h2></div>
            <div id="Div11" class="dvBoxbody">
                           

                        <asp:Panel ID="Panel5" Width ="98%" runat ="server" BorderStyle="Solid" Height ="600px" BorderWidth ="2px">
                                                    <asp:GridView Width="100%" ID="gridApprovalEntries" runat="server" Visible="true" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" OnRowDataBound ="gridApprovalEntries_RowDataBound">
                                                         <Columns>

                                                              <asp:BoundField DataField="DocumentNo" HeaderText="Leave No" />
                                                              <asp:BoundField DataField="ApprovalID" HeaderText="Approval ID" />
                                                              <asp:BoundField DataField="Status" HeaderText="Status" />
                                                              
                                                         </Columns>

                                                    </asp:GridView>
                                               </asp:Panel>

                                 
            </div>
    
    </div>
    
    </div>
        
        <br />

    <asp:Button ID="btnCloseApprovalEntries" runat="server" Text="Close" ValidationGroup ="AppSummary" CssClass ="button" />
    </asp:Panel>


               
        </ContentTemplate>
     </asp:UpdatePanel>


</asp:Content>

