
Imports System.Data

Partial Class frmProbationConfirmations
    Inherits System.Web.UI.Page
    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, docNo As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridProbationConfirmation.Rows(i.RowIndex).Cells(2).Text
        Response.Redirect(String.Format("frmProbationConfirmation.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub


    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core
        Dim btnViewApplicationLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridProbationConfirmation.Rows(i.RowIndex).Cells(2).Text
        dtApprovalEntries = Nav_Window.getApprovalEntries(docNo)
        loadApprovalGrid(dtApprovalEntries)
        mpApprovalEntries.Show()

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

    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

    End Sub
    Protected Sub gridProbationConfirmation_RowDataBound()

    End Sub

    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridProbationConfirmation.DataSource = dt
            gridProbationConfirmation.DataBind()

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

    Protected Sub getProbationConfirmation()

        Dim dtProbationConfirmation As New DataTable

        If IsNothing(Session("ProbationConfirmation")) = True Then

            Response.Redirect("Login.aspx")

        Else

            dtProbationConfirmation = Session("ProbationConfirmation")

        End If

        loadGrid(dtProbationConfirmation)

    End Sub

    Private Sub frmProbationConfirmations_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getProbationConfirmation()

                Else

                    getProbationConfirmation()

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

End Class
