Imports System.Data
Partial Class frmStaffAdvanceList
    Inherits System.Web.UI.Page

    Protected Sub gridPaymentRequest_RowDataBound()

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub
    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core

        Dim btnViewApplicationLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridStaffAdvances.Rows(i.RowIndex).Cells(2).Text
        dtApprovalEntries = Nav_Window.getApprovalEntries(docNo)
        loadApprovalGrid(dtApprovalEntries)
        mpApprovalEntries.Show()

    End Sub
    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, docNo As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridStaffAdvances.Rows(i.RowIndex).Cells(2).Text

        Response.Redirect(String.Format("frmStaffAdvance.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub

    Protected Sub loadApprovalGrid(dt As DataTable)

        Try

            Me.gridApprovalEntries.DataSource = dt
            gridApprovalEntries.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else

            End If

        Catch ex As Exception
            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)
        End Try

    End Sub

    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridStaffAdvances.DataSource = dt
            gridStaffAdvances.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else

            End If

        Catch ex As Exception
            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)
        End Try

    End Sub

    Protected Sub getStaffAdvance()

        Dim dtStore As New DataTable

        If IsNothing(Session("StaffAdv")) = True Then

            Response.Redirect("Login.aspx")

        Else

            dtStore = Session("StaffAdv")

        End If

        loadGrid(dtStore)

    End Sub

    Private Sub frmStaffAdvanceList_Load(sender As Object, e As EventArgs) Handles Me.Load




        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getStaffAdvance()

                Else

                    getStaffAdvance()

                End If

            Else

                'getStoreRequisition()

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Response.Redirect("frmStaffAdvance.aspx")

    End Sub

    Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim NAV_Window As New NAV_HR_WINDOW.Core, result As String

        Dim cb As CheckBox, chk As Integer = 0

        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If


            For Each grow As GridViewRow In Me.gridStaffAdvances.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(6).Text = "Pending" Then

                        result = NAV_Window.SendCashAdvanceApproval(grow.Cells(2).Text)
                        'result = NAV_Window.send(grow.Cells(2).Text)

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next

            Dim dtAdvanceRequest As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            dtAdvanceRequest = NAV_Window.getStaffAdvanceList(CStr(Session("userID")))
            Session("StaffAdv") = dtAdvanceRequest
            Response.Redirect("frmStaffAdvanceList.aspx")

        Catch ex As Exception

        End Try


    End Sub
End Class
