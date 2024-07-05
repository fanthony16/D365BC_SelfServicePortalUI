
Imports System.Data

Partial Class frmCashAdvRetirements
    Inherits System.Web.UI.Page

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
    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core

        Dim btnViewApplicationLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridWorkRetirement.Rows(i.RowIndex).Cells(2).Text
        dtApprovalEntries = Nav_Window.getApprovalEntries(docNo)
        loadApprovalGrid(dtApprovalEntries)
        mpApprovalEntries.Show()


    End Sub

    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, docNo As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridWorkRetirement.Rows(i.RowIndex).Cells(2).Text
        Response.Redirect(String.Format("frmCashAdvRetirement.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub

    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

    End Sub
    Protected Sub gridWorkRetirement_RowDataBound()

    End Sub

    Protected Sub getWorkRetirements()

        Dim dtStore As New DataTable

        If IsNothing(Session("NAVStaffRetirement")) = True Then

            Response.Redirect("Login.aspx")

        Else

            dtStore = Session("NAVStaffRetirement")

        End If

        loadGrid(dtStore)

    End Sub

    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridWorkRetirement.DataSource = dt
            gridWorkRetirement.DataBind()

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

    Private Sub frmCashAdvRetirements_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getWorkRetirements()

                Else

                    getWorkRetirements()

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

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("frmCashAdvRetirement.aspx")
    End Sub

    Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim result As String
        Dim cb As CheckBox, chk As Integer = 0
        Dim nav_window As New NAV_HR_WINDOW.Core
        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If


            For Each grow As GridViewRow In Me.gridWorkRetirement.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(7).Text = "Pending" Then

                        result = nav_window.SendCashRetirementApproval(grow.Cells(2).Text)

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next

            Dim dtAdvanceRetirement As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            dtAdvanceRetirement = nav_window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)

            Session("NAVStaffRetirement") = dtAdvanceRetirement
            Response.Redirect("frmCashAdvRetirements.aspx")

        Catch ex As Exception

        End Try


    End Sub
End Class
