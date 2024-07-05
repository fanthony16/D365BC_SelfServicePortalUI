
Imports System.Data


Partial Class frmCanteenApplication
    Inherits System.Web.UI.Page


    Protected Sub RequestType()

        ddRequestType.Items.Clear()
        Me.ddRequestType.Items.Add("")
        Me.ddRequestType.Items.Add("Employee")
        Me.ddRequestType.Items.Add("Visitor")




    End Sub

    Protected Sub populatePayrollPeriod()
        Dim NAV_window As New NAV_HR_WINDOW.Core, dtPayrollPeriod As New DataTable, i As Integer = 0
        dtPayrollPeriod = NAV_window.getPayrollPeriods()
        ddPayrollPeriod.Items.Clear()
        Do While i < dtPayrollPeriod.Rows.Count
            If i = 0 Then
                Me.ddPayrollPeriod.Items.Add("")
            End If
            Me.ddPayrollPeriod.Items.Add(dtPayrollPeriod.Rows(i).Item(0))

            i = i + 1
        Loop





    End Sub

    Protected Sub populateStatus()

        ddStatus.Items.Clear()
        Me.ddStatus.Items.Add("")
        Me.ddStatus.Items.Add("Approved")
        Me.ddStatus.Items.Add("Rejected")
        Me.ddStatus.Items.Add("New")
        Me.ddStatus.Items.Add("Pending_Approval")



    End Sub

    Protected Sub calApplicationDate_SelectionChanged(sender As Object, e As EventArgs) Handles calApplicationDate.SelectionChanged

        Me.calApplicationDate_PopupControlExtender.Commit(Me.calApplicationDate.SelectedDate)

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim _canteenApp As New NAV_HR_WINDOW.CanteenApplication, _status As String = ""
        Dim RCCollection As New Hashtable
        RCCollection = ViewState("RCCollection")

        _canteenApp.Visitor_Name = Me.txtVisitorName.Text
        _canteenApp.Ticket_No = Me.txtDocumentNo.Text
        _canteenApp.Amount = CDbl(Me.txtAmount.Text.Replace("N", "").Replace(",", ""))
        _canteenApp.ApplicationDate = Me.txtApplicationDatee.Text
        _canteenApp.DepartmentCode = Me.txtDeptCode.Text
        _canteenApp.EmployeeNo = Me.txtEmployeeNo.Text
        _canteenApp.Responsibility_Center = RCCollection.Item(ddRC.Text)
        _canteenApp.RequestType = Me.ddRequestType.Text
        _canteenApp.SS_UserID = CStr(Session("userID"))
        _canteenApp.PayrollPeriod = CDate(Me.ddPayrollPeriod.Text)

        Dim NAV_window As New NAV_HR_WINDOW.Core

        If Me.txtDocumentNo.Text <> "" Then

            _status = NAV_window.CreateCanteenApplication(_canteenApp)
            Dim dtCanteenApps As New DataTable, userID As String = Session("userID")
            Dim dtEmployee As New DataTable
            dtEmployee = Session("dtEmployeeCard")
            dtCanteenApps = NAV_window.getCanteenApplications(dtEmployee.Rows(0).Item("No"))
            Session("Canteen") = dtCanteenApps
            Response.Redirect("frmCanteenApplicationList.aspx")

        Else

            _status = NAV_window.CreateCanteenApplication(_canteenApp)
            Dim dtCanteenApps As New DataTable, userID As String = Session("userID")
            Dim dtEmployee As New DataTable
            dtEmployee = Session("dtEmployeeCard")

            dtCanteenApps = NAV_window.getCanteenApplications(dtEmployee.Rows(0).Item("No"))
            Session("Canteen") = dtCanteenApps
            Response.Redirect("frmCanteenApplicationList.aspx")

        End If

    End Sub

    Protected Sub getNAVRC(rc As String)

        Dim dtRC As New DataTable
        Dim RCCollection As New Hashtable
        'checking if the sesion object still has the responsibilty center data
        If IsNothing(Session("RC")) = True Then

            Response.Redirect("Login.aspx")

        Else
            'retrieving the responsibility center from the session object
            RCCollection = Session("RC")
            ViewState("RCCollection") = RCCollection

        End If

        Dim i As Integer = 0

        ddRC.Items.Clear()
        Dim _rcc As String = ""

        Do While i < RCCollection.Keys.Count

            If ddRC.Items.Count = 0 Then
                Me.ddRC.Items.Add("")
                Me.ddRC.Items.Add(RCCollection.Keys(i).ToString)

            Else
                Me.ddRC.Items.Add(RCCollection.Keys(i).ToString)
            End If

            If (rc = RCCollection.Item(RCCollection.Keys(i))) = True Then

                _rcc = (RCCollection.Keys(i).ToString())
            Else
            End If

            i += 1
        Loop

        Me.ddRC.SelectedValue = _rcc.ToString()

    End Sub

    Private Sub frmCanteenApplication_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtusers As New DataTable

        Dim RequestNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core

        Try

            If IsPostBack = False And Not Context.Request.QueryString("DocumentNo") Is Nothing Then

                RequestNo = Context.Request.QueryString("DocumentNo") 'ApplicationTypeID
                ViewState("RequestNo") = RequestNo
                spCaption.InnerText = spCaption.InnerText & " Document Code : " & RequestNo

                Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeLeave, dtHRSetup As New DataTable

                'testing if cache is empty
                If IsNothing(Session("dtEmployeeCard")) = True Then

                    Response.Redirect("Login.aspx")

                Else
                    'populating the status control
                    populateStatus()
                    RequestType()
                    populatePayrollPeriod()
                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")
                    Dim _CanteenApplication As New NAV_HR_WINDOW.CanteenApplication
                    _CanteenApplication = NAV_Window.getCanteenApplication(RequestNo)

                    getNAVRC(_CanteenApplication.Responsibility_Center)
                    Me.txtVisitorName.Text = _CanteenApplication.Visitor_Name
                    Me.txtDocumentNo.Text = RequestNo
                    'Me.txtAmount.Text = _CanteenApplication.Amount.ToString("###,0##.00")

                    Dim num_ As Decimal
                    num_ = CDec(_CanteenApplication.Amount.ToString())
                    txtAmount.Text = num_.ToString("N###,0##.00")

                    Me.txtApplicationDatee.Text = _CanteenApplication.ApplicationDate
                    Me.txtDeptCode.Text = _CanteenApplication.DepartmentCode
                    Me.txtEmployeeNo.Text = _CanteenApplication.EmployeeNo
                    Me.ddRequestType.Text = _CanteenApplication.RequestType
                    Me.txtEmployeeName.Text = _CanteenApplication.EmployeeName
                    Me.ddStatus.Text = _CanteenApplication.Status
                    Me.ddPayrollPeriod.Text = _CanteenApplication.PayrollPeriod

                    If _CanteenApplication.RequestType <> "Employee" Then
                        Me.dvVisitorName.Visible = True
                    Else
                        Me.dvVisitorName.Visible = False
                    End If



                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("Login.aspx")

                Else

                    populateStatus()
                    Me.ddStatus.Text = "New"
                    RequestType()
                    populatePayrollPeriod()
                    getNAVRC("ADMI")

                    Dim dtEmployeeCard, dtHrSetup As New DataTable

                    dtEmployeeCard = Session("dtEmployeeCard")
                    dtHrSetup = Session("HRSetup")

                    txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
                    txtEmployeeName.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("MiddleName").ToString.ToUpper

                    Me.txtDeptCode.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
                    'Me.txtAmount.Text = dtHrSetup.Rows(0).Item("MealAmount").ToString("###,0##.00")


                    Dim num_ As Decimal
                    num_ = CDec(dtHrSetup.Rows(0).Item("MealAmount").ToString())
                    txtAmount.Text = num_.ToString("N###,0##.00")

                    Me.ddRequestType.Text = "Employee"

                End If
            Else

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try

    End Sub

    Protected Sub getNavData()

        Dim dtEmployeeCard As New DataTable, empDeptCode As String = ""

        If IsNothing(Session("dtEmployeeCard")) = True Then
            Response.Redirect("Login.aspx")
        Else
            dtEmployeeCard = Session("dtEmployeeCard")
        End If

        ' Reading employee records
        If dtEmployeeCard.Rows.Count > 0 Then
            Session("EmployeeNo") = dtEmployeeCard.Rows(0).Item("No")
            Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No")

            Me.txtDeptCode.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode")
            empDeptCode = dtEmployeeCard.Rows(0).Item("DepartmentCode")

            Me.txtApplicationDatee.Text = Now.Date

        Else

        End If

        'retrieving Responsibility Center Data
        getResponsibilityCenter()
        populatedRequestType()






    End Sub



    'retrieving responsibilty center and populating the control on the page
    Protected Sub getResponsibilityCenter()

        Dim dtRC As New DataTable
        Dim RCCollection As New Hashtable
        'checking if the sesion object still has the responsibilty center data
        If IsNothing(Session("RC")) = True Then

            Response.Redirect("Login.aspx")

        Else
            'retrieving the responsibility center from the session object
            RCCollection = Session("RC")
            ViewState("RCCollection") = RCCollection

        End If

        Dim i As Integer = 0

        ddRC.Items.Clear()
        Dim _rcc As String = ""

        Do While i < RCCollection.Keys.Count

            If ddRC.Items.Count = 0 Then
                Me.ddRC.Items.Add("")
                Me.ddRC.Items.Add(RCCollection.Keys(i).ToString)

            Else
                Me.ddRC.Items.Add(RCCollection.Keys(i).ToString)
            End If



            i += 1
        Loop



    End Sub

    Protected Sub populatedRequestType()

        ddRequestType.Items.Clear()
        Me.ddRequestType.Items.Add("")
        Me.ddRequestType.Items.Add("Employee")
        Me.ddRequestType.Items.Add("Visitor")

    End Sub

    Protected Sub txtDeptCode_TextChanged(sender As Object, e As EventArgs) Handles txtDeptCode.TextChanged

    End Sub

    Private Sub ddRC_TextChanged(sender As Object, e As EventArgs) Handles ddRC.TextChanged


    End Sub

    Protected Sub ddRequestType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddRequestType.SelectedIndexChanged
        If Me.ddRequestType.Text <> "Employee" Then
            Me.dvVisitorName.Visible = True
        Else
            Me.dvVisitorName.Visible = False
        End If
    End Sub

    Protected Sub txtApplicationDatee_TextChanged(sender As Object, e As EventArgs) Handles txtApplicationDatee.TextChanged

    End Sub
End Class
