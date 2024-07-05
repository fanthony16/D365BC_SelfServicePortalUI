
Imports System.Data

Partial Class frmStoreRequisitionList
    Inherits System.Web.UI.Page

    Protected Sub loadGrid(dt As DataTable)

        Try
            'MsgBox("" & dt.Rows.Count)
            Me.gridStoreRequisition.DataSource = dt
            gridStoreRequisition.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else

            End If

        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try

    End Sub
    Protected Sub getStoreRequisition()

        Dim dtStore As New DataTable

        If IsNothing(Session("StoreReq")) = True Then

            Response.Redirect("Login.aspx")

        Else

            dtStore = Session("StoreReq")

        End If

        loadGrid(dtStore)

    End Sub

    Private Sub frmStoreRequisitionList_Load(sender As Object, e As EventArgs) Handles Me.Load

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

                    getStoreRequisition()

                Else

                    getStoreRequisition()

                End If

            Else

                'getStoreRequisition()

            End If

        Catch ex As Exception

        End Try

    End Sub



    Protected Sub gridStoreRequisition_RowDataBound()

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub
    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core
        Dim btnViewApprovalLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApprovalLog = sender
        Dim i As GridViewRow
        i = btnViewApprovalLog.NamingContainer
        docNo = Me.gridStoreRequisition.Rows(i.RowIndex).Cells(2).Text
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


    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, docNo As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridStoreRequisition.Rows(i.RowIndex).Cells(2).Text
        Response.Redirect(String.Format("frmStoreRequisition.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub

    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub

    Protected Sub gridStoreRequisition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridStoreRequisition.SelectedIndexChanged
        MsgBox("here")
    End Sub


    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Response.Redirect("frmStoreRequisition.aspx")

    End Sub

    Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim NAV_Window As New NAV_HR_WINDOW.Core, result As String
        Dim cb As CheckBox, chk As Integer = 0

        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If


            For Each grow As GridViewRow In Me.gridStoreRequisition.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(6).Text = "Open" Then

                        result = NAV_Window.SendStoreReqApproval(grow.Cells(2).Text)

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next


            Dim dtStoreReq As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            dtStoreReq = NAV_Window.getStoreRequisitions(CStr(Session("userID")))
            Session("StoreReq") = dtStoreReq
            Response.Redirect("frmStoreRequisitionList.aspx")

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
