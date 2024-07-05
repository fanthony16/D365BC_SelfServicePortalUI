
Imports System.Data

Partial Class frmAppraisalList
    Inherits System.Web.UI.Page

    Private Sub frmAppraisalList_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim scriptManagerA As New ScriptManager, dtusers As New DataTable

        scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        scriptManagerA.RegisterPostBackControl(Me.gridAppraisals)

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getMyAppraisals()

                Else

                    getMyAppraisals()

                End If

            Else
                'getMyLeaveApplication()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub getMyAppraisals()
        Dim NAV_Window As New NAV_HR_WINDOW.Core
        Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeReLeavers, dtPostedEmployeeLeaves As New DataTable, result As DataRow(), lstAppraisalRequest As New List(Of NAV_HR_WINDOW.AppraisalRequest)

        Try

            If IsNothing(Session("AppraisalRequest")) = True Then
                Response.Redirect("Login.aspx")
            Else
                lstAppraisalRequest = Session("AppraisalRequest")
                loadGrid(lstAppraisalRequest)
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub

    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, appCode As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        appCode = Me.gridAppraisals.Rows(i.RowIndex).Cells(2).Text
        Response.Redirect(String.Format("frmAppraisal.aspx?AppraisalNo={0}", Server.UrlEncode(appCode)))

    End Sub

    Protected Sub BtnViewApprovalEntries_Click()

    End Sub

    Protected Sub gridAppraisal_RowDataBound()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub loadGrid(lstAppraisalRequest As List(Of NAV_HR_WINDOW.AppraisalRequest))
        Try
            Dim dt As New DataTable, i As Integer

            dt.Columns.Add("Appraisal_No", GetType(String))
            dt.Columns.Add("Employee_No", GetType(String))
            dt.Columns.Add("EmployeeName", GetType(String))
            dt.Columns.Add("Appraisal_Period", GetType(String))
            dt.Columns.Add("Appraisal_Type", GetType(String))
            dt.Columns.Add("Appraisal_Date", GetType(Date))
            dt.Columns.Add("Status", GetType(String))

            Do While i < lstAppraisalRequest.Count

                Dim row As DataRow = dt.NewRow()
                row("Appraisal_No") = lstAppraisalRequest(i).Appraisal_No
                row("Employee_No") = lstAppraisalRequest(i).EmployeeNo
                row("EmployeeName") = lstAppraisalRequest(i).EmployeeName
                row("Appraisal_Period") = lstAppraisalRequest(i).Appraisal_Period
                row("Appraisal_Type") = lstAppraisalRequest(i).Appraisal_Half.ToString()
                row("Appraisal_Date") = lstAppraisalRequest(i).Appraisal_Date
                row("Status") = lstAppraisalRequest(i).Status

                dt.Rows.Add(row)
                i = i + 1
            Loop

            Me.gridAppraisals.DataSource = dt
            gridAppraisals.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else
            End If

        Catch ex As Exception
            '   MsgBox("" & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Dim appraisalRequest As New NAV_HR_WINDOW.AppraisalRequest
        Dim nav_window As New NAV_HR_WINDOW.Core
        Dim dtEmployeeCard As New DataTable

        dtEmployeeCard = Session("dtEmployeeCard")

        appraisalRequest = nav_window.CreateAppraisal(Session("userID"), dtEmployeeCard.Rows(0)("No"))

        If appraisalRequest.Appraisal_No <> "" Then

            Session("AppraisalRequest") = Nothing

            'dtEmployeeCard = Session("dtEmployeeCard")
            Session("AppraisalRequest") = nav_window.getStaffAppraisal("", dtEmployeeCard.Rows(0)("No"))
            Response.Redirect("frmAppraisalList.aspx")

        Else

            spNewAppraisal.InnerText = appraisalRequest.ExceptionMessage
            spNewAppraisal.Visible = True

        End If

        ' Response.Redirect("frmAppraisal.aspx")

    End Sub

    Private Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim NAV_Window As New NAV_HR_WINDOW.Core, result As String

        Dim cb As CheckBox, chk As Integer = 0

        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If

            For Each grow As GridViewRow In Me.gridAppraisals.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(8).Text = "Open" Then

                        result = NAV_Window.SendAppraisalForApproval(grow.Cells(2).Text)

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next

            Dim lstAppraisalRequest As New List(Of NAV_HR_WINDOW.AppraisalRequest), dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            lstAppraisalRequest = NAV_Window.getStaffAppraisal("", dtEmployeeCard.Rows(0)("No"))
            Session("AppraisalRequest") = lstAppraisalRequest
            Response.Redirect("frmAppraisalList.aspx")

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)


        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
