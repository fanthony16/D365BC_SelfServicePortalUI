<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table align="center" class="style1" style="border: thin solid #008080">
            <tr>
                <td class="style2" colspan="3" 
                    style="font-weight: 700; text-align: center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #008080;">
                    Validation Summary Control in ASP.Net</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Name :</td>
                <td>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtname" ErrorMessage="Enter Name !!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    City :</td>
                <td>
                    <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtcity" ErrorMessage="Enter City !!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile :</td>
                <td>
                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtmobile" ErrorMessage="Invalid Mobile no !!" 
                        MaximumValue="9999999999" MinimumValue="1000000000" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email :</td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtemail" ErrorMessage="Invalid Email Address !!" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="SAVE" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        DisplayMode="List" ShowMessageBox="True" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

</asp:Content>

