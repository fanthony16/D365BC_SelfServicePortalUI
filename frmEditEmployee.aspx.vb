Imports System
Imports System.Data
Imports NAV_HR_WINDOW

Partial Class frmEditEmployee
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim scriptManagerA As New ScriptManager, scriptManagerB As New ScriptManager, dtusers As New DataTable
        'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        'scriptManagerA.RegisterPostBackControl(Me.ddStatus)


        Dim employeeNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core
        Try


            If IsPostBack = False And Not Context.Request.QueryString("xytamcvrofqg") Is Nothing Then

                employeeNo = Context.Request.QueryString("xytamcvrofqg")
                ViewState("employeeNo") = employeeNo


                Dim dtEmployeeCard As New DataTable

                If IsNothing(Session("dtEmployeeCard")) = True Then

                    Response.Redirect("Login.aspx")

                Else

                    dtEmployeeCard = Session("dtEmployeeCard")

                    If dtEmployeeCard.Rows(0).Item("No").ToString = employeeNo Then

                        Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
                        Me.txtFirstName.Text = dtEmployeeCard.Rows(0).Item("FirstName").ToString
                        Me.txtMiddleName.Text = dtEmployeeCard.Rows(0).Item("MiddleName").ToString
                        Me.txtLastName.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString
                        Me.txtJobTitle.Text = dtEmployeeCard.Rows(0).Item("JobTitle").ToString
                        Me.txtContractType.Text = dtEmployeeCard.Rows(0).Item("ContractType").ToString
                        Me.txtCompanyEmail.Text = dtEmployeeCard.Rows(0).Item("CompanyEmail").ToString
                        Me.txtStatus.Text = dtEmployeeCard.Rows(0).Item("Status").ToString

                    Else

                        Response.Redirect("Login.aspx")

                    End If

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("xytamcvrofqg") Is Nothing Then

                If IsNothing(Session("Employee")) = True Then

                    Response.Redirect("Login.aspx")

                Else
                End If
            Else


            End If


        Catch ex As Exception

            '  MsgBox("" & ex.Message)

        End Try


    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        'If Page.IsValid = True Then

        '    Dim _emp As New Employee
        '    _emp.FirstName = Me.txtFirstName.Text
        '    _emp.LastName = Me.txtLastName.Text
        '    _emp.MiddleName = Me.txtMiddleName.Text
        '    _emp.CompanyEmail = Me.txtCompanyEmail.Text
        '    Dim _core As New NAV_HR_WINDOW.Core
        '    MsgBox("" & _core.updateEmployeeDetails(_emp))
        'Else

        'End If

    End Sub

    Protected Sub txtEmployeeNo_TextChanged(sender As Object, e As EventArgs) Handles txtEmployeeNo.TextChanged

    End Sub

    Private Sub txtEmployeeNo_Load(sender As Object, e As EventArgs) Handles txtEmployeeNo.Load

    End Sub
End Class
