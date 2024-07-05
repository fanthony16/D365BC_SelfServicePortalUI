
Imports System.Data

Partial Class frmStaffClaimList
    Inherits System.Web.UI.Page


    Protected Sub gridStaffClaim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridStaffClaim.SelectedIndexChanged

    End Sub

    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, appCode As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        appCode = Me.gridStaffClaim.Rows(i.RowIndex).Cells(1).Text
        Response.Redirect(String.Format("frmStaffClaim.aspx?DocumentNo={0}", Server.UrlEncode(appCode)))


    End Sub
    Protected Sub BtnViewApprovalEntries_Click()

    End Sub

    Private Sub frmStaffClaimList_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim scriptManagerA As New ScriptManager, dtusers As New DataTable

        'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        'scriptManagerA.RegisterPostBackControl(Me.gridSubmittedDocuments)

        'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        'scriptManagerA.RegisterPostBackControl(Me.gridStaffClaim)

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getStaffClaim()

                Else

                    getStaffClaim()

                End If

            Else

                getStaffClaim()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gridClaim_RowDataBound()

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub
    Protected Sub getStaffClaim()

        Dim dtClaim As New DataTable

        If IsNothing(Session("Claim")) = True Then

            Response.Redirect("Login.aspx")
        Else
            dtClaim = Session("Claim")
        End If

        loadGrid(dtClaim)

    End Sub

    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridStaffClaim.DataSource = dt
            gridStaffClaim.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else

            End If

        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try

    End Sub

    Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("frmStaffClaim.aspx")
    End Sub
End Class
