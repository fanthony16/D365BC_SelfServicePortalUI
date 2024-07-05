<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmEditEmployee.aspx.vb" Inherits="frmEditEmployee" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true" ></asp:ToolkitScriptManager> --%>
   
    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="updFormPanel" runat="server">
            <ProgressTemplate>           
            <img alt="progress" src="images/loading.png"/>
               Processing...           
            </ProgressTemplate>
        </asp:UpdateProgress>


    <asp:UpdatePanel ID="updFormPanel" runat ="server" >

        <ContentTemplate>

            <div class ="bodyMainDiv">

                <div id="dvPersonalDetails" style="width :100%">
                                     <div id="dvPersonalfor" style="float :left ; width :70%; ">    
                                                                                                          
                                       
                                          <div id="dvEmployeeNo" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Employee No :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtEmployeeNo" Width ="300px" runat="server" Enabled ="false"   ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmployeeNo" runat ="server" ErrorMessage="*" ControlToValidate="txtEmployeeNo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                          <div id="dvFirstName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">First Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtFirstName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="reqFirstName" runat ="server" ErrorMessage="*" ControlToValidate="txtFirstName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <div id="dvMiddleName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Middle Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtMiddleName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="reqtxtMiddleName" runat ="server" ErrorMessage="*" ControlToValidate="txtMiddleName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
                                               </div>
                                          </div>

                                         <div id="dvLastName" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Last Name :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtLastName" Width ="300px" runat="server" Enabled ="true"   ></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="reqtxtLastName" runat ="server" ErrorMessage="*" ControlToValidate="txtLastName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>--%>
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

                                         <div id="dvContractType" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Contract Type :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtContractType" Width ="300px" runat="server" Enabled ="false"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqContractType" runat ="server" ErrorMessage="*" ControlToValidate="txtContractType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvCompanyEmail" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Company's Email :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    <asp:TextBox ID="txtCompanyEmail" Width ="300px" runat="server" Enabled ="true"    ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqCompanyEmail" runat ="server" ErrorMessage="*" ControlToValidate="txtCompanyEmail" Display="Dynamic" SetFocusOnError="True" ValidationGroup="personDetails" Font-Bold="True" ForeColor="Red" ></asp:RequiredFieldValidator>
                                               </div>
                                          </div>

                                         <div id="dvStatus" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;">Status :</span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:TextBox ID="txtStatus" Width ="300px" runat="server" Enabled ="false" ReadOnly ="true"    ></asp:TextBox>

                                                    
                                               </div>
                                          </div>

                                         <div id="dvUpdate" class ="dvBoxRows">
                                               <div class="dvBoxRowsFieldLabel">
                                                    <span style ="font-size : medium;"> &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                               </div>
                                               <div style ="text-align :left ;">
                                                    

                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update Employee Record" ValidationGroup="personDetails" CssClass ="button" />

                                                    
                                               </div>
                                          </div>

                                     </div>

                                </div>

            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>

