Imports System.Data
Partial Class frmPaymentRequestList
    Inherits System.Web.UI.Page

    Protected Sub gridPaymentRequest_RowDataBound()

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub gridApprovalEntries_RowDataBound()

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

    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core

        Dim btnViewApplicationLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridPaymentRequests.Rows(i.RowIndex).Cells(1).Text
        dtApprovalEntries = Nav_Window.getApprovalEntries(docNo)
        loadApprovalGrid(dtApprovalEntries)
        mpApprovalEntries.Show()

    End Sub
    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

        Dim btnViewApplicationLog As New ImageButton, docNo As String
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridPaymentRequests.Rows(i.RowIndex).Cells(1).Text
        Response.Redirect(String.Format("frmPaymentRequest.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub
    Private Sub FrmPaymentRequestList_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getPaymentRequest()

                Else

                    getPaymentRequest()

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

    Protected Sub getPaymentRequest()

        Dim dtStore As New DataTable

        If IsNothing(Session("PmtReq")) = True Then

            Response.Redirect("Login.aspx")

        Else

            dtStore = Session("PmtReq")

        End If

        loadGrid(dtStore)

    End Sub

    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridPaymentRequests.DataSource = dt
            gridPaymentRequests.DataBind()

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


    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Session("entry") = Nothing
        Response.Redirect("frmPaymentRequest.aspx")

    End Sub

    Protected Sub gridPaymentRequests_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridPaymentRequests.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim NAV_Window As New NAV_HR_WINDOW.Core, result As String

        Dim cb As CheckBox, chk As Integer = 0

        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If


            For Each grow As GridViewRow In Me.gridPaymentRequests.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(4).Text = "Pending" Then
                        result = NAV_Window.SendPaymentApproval(grow.Cells(1).Text)

                        If result.ToUpper <> "SUCCESS" Then
                            dvError.Visible = True
                            lblError.Text = "An Error Occur Sending Document For Approval on NAV : " & result
                            Exit Sub
                        Else
                            dvError.Visible = False
                            lblError.Text = ""
                        End If

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next

            Dim dtPaymentRequest As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            dtPaymentRequest = NAV_Window.getPaymentVoucherList(CStr(Session("userID")))
            Session("PmtReq") = dtPaymentRequest
            Response.Redirect("FrmPaymentRequestList.aspx")

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub
End Class
