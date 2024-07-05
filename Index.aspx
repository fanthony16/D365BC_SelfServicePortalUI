<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" Theme="Blue"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true" ></asp:ToolkitScriptManager>--%>

 
        <div id="dvUploadDocument" class ="dvBoxRows">

        <table style="width:100%; border-collapse:collapse; font:14px Arial,sans-serif;">
        <tr>
            <td colspan="3" style="padding:10px 20px; background-color:#acb3b9;">
                <%--<h1 style="font-size:24px;">Welcome  Mr . </h1>--%>
                <span id="lblWelcomePerson" runat ="server" style="font-size:24px;" >Welcome. </span>
            </td>
        </tr>
        <tr style="height:170px;">
            <td style="width:20%; padding:20px; background-color:#d4d7dc; vertical-align: top;">
                <p>
                    A self service solution that enable you do more in a very cost effective way, 
while also increasing business process efficiencies. 

                   

                </p>
                <%--<ul style="list-style:none; padding:0px; line-height:24px;">
                    <li><a href="#" style="color:#333;">Home</a></li>
                    <li><a href="#" style="color:#333;">About</a></li>
                    <li><a href="#" style="color:#333;">Contact</a></li>
                </ul>--%>
            </td>
            <td style="padding:20px; background-color:#f2f2f2; vertical-align:top;">
                <h2>Leave</h2>
                <p>
                    <a href="frmApplicationList.aspx">Leave Application</a><br />
				<a href="#">Leave Acknowledgment</a><br />
				<a href="#">Leave Approval</a></p>
            </td>

             <td style="padding:20px; background-color:#f2f2f2; vertical-align:top;">
                <h2>Payment</h2>
                <p>
                   
                   <a href="#">Branch Imprest Request</a><br />
                   <a href="#">Branch Imprest Retirement</a><br />
                   <a href="frmStaffAdvanceList.aspx">Cash Advance Request</a><br />
				   <a href="frmCashAdvRetirements.aspx">Cash Advance Retirement</a><br />
				   <a href="frmPaymentRequestList.aspx">Payment Request</a><br />
                   

				</p>
            </td>

        </tr>
            <tr style="height:170px;">
            <td style="width:20%; padding:20px; background-color:#d4d7dc; vertical-align: top;">
                
                <p><br /><br />
                     Contact Details:<br />
                    Email : info@reeltechsolutions.com<br />
                    Phone : +234-8011-222-333
                </p></td>
            <td style="padding:20px; background-color:#f2f2f2; vertical-align:top;">
                <h2>Staff Need</h2>
                <p>
                                                        <a href="frmEmployeeList.aspx">Employee Management</a><br />
														<a href="frmCanteenApplicationList.aspx">Canteen Application</a><br />
														<a href="frmStaffClaimList.aspx">Staff Claim</a> <br />
														<a href="frmStoreRequisitionList.aspx">Store Requisition</a>

													</p>
            </td>

             <td style="padding:20px; background-color:#f2f2f2; vertical-align:top;">
                <h2>Performance</h2>
                <p>
				<a href="frmAppraisalList.aspx">Appraisal/Performance Management</a><br />
				<a href="frmProbationConfirmations.aspx">Probation/Confirmation</a><br />
				<a href="#">Training Application Request</a>
				</p>
            </td>

        </tr>
        <tr>
            <td colspan="3" style="padding:5px; background-color:#acb3b9; text-align:center;">
                <p>copyright &copy; reeltechsolutions.com</p>
            </td>
        </tr>
    </table>

    </div>

</asp:Content>

