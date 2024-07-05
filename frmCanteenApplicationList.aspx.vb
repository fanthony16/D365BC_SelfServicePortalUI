
Imports System.Data

Partial Class frmCanteenApplicationList
    Inherits System.Web.UI.Page

    Dim NAV_Window As New NAV_HR_WINDOW.Core
    Protected Sub gridApprovalEntries_RowDataBound()

    End Sub

    Protected Sub gridCanteenApp_RowDataBound()

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Response.Redirect("frmCanteenApplication.aspx")

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub
    Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs)

        Dim Nav_Window As New NAV_HR_WINDOW.Core
        Dim btnViewApplicationLog As New ImageButton, docNo As String, dtApprovalEntries As New DataTable
        btnViewApplicationLog = sender
        Dim i As GridViewRow
        i = btnViewApplicationLog.NamingContainer
        docNo = Me.gridCanteenApp.Rows(i.RowIndex).Cells(2).Text
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
        docNo = Me.gridCanteenApp.Rows(i.RowIndex).Cells(2).Text
        Response.Redirect(String.Format("frmCanteenApplication.aspx?DocumentNo={0}", Server.UrlEncode(docNo)))

    End Sub


    Protected Sub gridCanteenApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridCanteenApp.SelectedIndexChanged

    End Sub

    Private Sub frmCanteenApplicationList_Load(sender As Object, e As EventArgs) Handles Me.Load



        Dim dtusers As New DataTable
        'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        'scriptManagerA.RegisterPostBackControl(Me.gridSubmittedDocuments)

        'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
        'scriptManagerA.RegisterPostBackControl(Me.gridCanteenApp)

        Try

            If IsPostBack = False Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("login.aspx")

                ElseIf IsNothing(Session("user")) = False Then

                    getMyCanteenApplication()

                Else
                    getMyCanteenApplication()

                End If

            Else
                '  getMyCanteenApplication()
            End If

        Catch ex As Exception

        End Try


    End Sub
    Protected Sub getMyCanteenApplication()

        Dim dtCanteen As New DataTable

        If IsNothing(Session("Canteen")) = True Then

            Response.Redirect("Login.aspx")
        Else
            dtCanteen = Session("Canteen")
        End If

        loadGrid(dtCanteen)

    End Sub
    Protected Sub loadGrid(dt As DataTable)

        Try

            Me.gridCanteenApp.DataSource = dt
            gridCanteenApp.DataBind()

            If dt.Rows.Count > 5 Then
                pnlGrid.Height = Nothing
            Else

            End If

        Catch ex As Exception
            MsgBox("" & ex.Message)
        End Try

    End Sub

    Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

        Dim result As String

        Dim cb As CheckBox, chk As Integer = 0

        Try

            If IsNothing(Session("user")) = True Then
                Response.Redirect("Login.aspx")
            Else
            End If


            For Each grow As GridViewRow In Me.gridCanteenApp.Rows

                Dim dt As New DataTable
                cb = grow.FindControl("chkProcessing")

                If cb.Checked = True Then

                    If grow.Cells(9).Text = "New" Then

                        result = NAV_Window.SendCanteenApp(grow.Cells(2).Text)

                    Else

                    End If

                ElseIf cb.Checked = False Then

                End If

            Next

            Dim dtCanteen As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
            dtCanteen = NAV_Window.getCanteenApplications(dtEmployeeCard.Rows(0)("No").ToString)
            Session("Canteen") = dtCanteen
            Response.Redirect("frmCanteenApplicationList.aspx")

        Catch ex As Exception

        End Try



    End Sub
End Class
