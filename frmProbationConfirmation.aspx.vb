Imports System.Data
Imports NAV_HR_WINDOW
Partial Class frmProbationConfirmation
    Inherits System.Web.UI.Page
    Dim LinesKeys As New List(Of String)
    Protected Sub populateStatus()

        ddStatus.Items.Clear()
        Me.ddStatus.Items.Add("")
        Me.ddStatus.Items.Add("Approved")
        Me.ddStatus.Items.Add("HR")
        Me.ddStatus.Items.Add("New")
        Me.ddStatus.Items.Add("Pending_Approval")

    End Sub

    Protected Sub populateAppraisalType()

        ddAppraisalType.Items.Clear()
        Me.ddAppraisalType.Items.Add("")
        Me.ddAppraisalType.Items.Add("Probation")
        Me.ddAppraisalType.Items.Add("_Confirmation")

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

    Private Sub frmProbationConfirmation_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtusers As New DataTable

        Dim RequestNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core

        Try

            If IsPostBack = False And Not Context.Request.QueryString("DocumentNo") Is Nothing Then

                RequestNo = Context.Request.QueryString("DocumentNo") 'ApplicationTypeID
                ViewState("RequestNo") = RequestNo
                spCaption.InnerText = spCaption.InnerText & " Document Code : " & Context.Request.QueryString("DocumentNo")

                Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeLeave, dtHRSetup As New DataTable

                'testing if cache is empty
                If IsNothing(Session("dtEmployeeCard")) = True Then

                    Response.Redirect("Login.aspx")

                Else
                    'populating the status control
                    populateStatus()
                    populateAppraisalType()

                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")
                    Dim _ProbationConfirmation As New NAV_HR_WINDOW.ConfirmationProbation
                    _ProbationConfirmation = NAV_Window.getProbationConfirmation(RequestNo)

                    getNAVRC(_ProbationConfirmation.Responsibility_Center)


                    'ViewState("AccountNumber") = staffClaim.AccountNo

                    Me.txtApplicationNo.Text = _ProbationConfirmation.ApplicationNo
                    Me.txtEmployeeNo.Text = _ProbationConfirmation.EmployeeNo
                    Me.txtEmployeeName.Text = _ProbationConfirmation.EmployeeName
                    Me.txtComment.Text = _ProbationConfirmation.Comment
                    Me.txtDepartment.Text = _ProbationConfirmation.Department
                    Me.txtDevelopmentArea.Text = _ProbationConfirmation.DevelopmentAreas
                    Me.txtEmployeeComment.Text = _ProbationConfirmation.EmployeeComment
                    Me.txtEmploymentdate.Text = _ProbationConfirmation.EmploymentDate
                    Me.txtEndDate.Text = _ProbationConfirmation.EndDate
                    Me.txtStartDate.Text = _ProbationConfirmation.StartDate
                    Me.txtSupervisor.Text = _ProbationConfirmation.Supervisor
                    Me.txtSupervisor2.Text = _ProbationConfirmation.Second_Line_Supervisor
                    Me.txtSupervisor2Comment.Text = _ProbationConfirmation.Second_Line_Supervisor_Comment
                    Me.txtTrainingIdeas.Text = _ProbationConfirmation.Training_Ideas
                    Me.ddAppraisalType.Text = _ProbationConfirmation.AppraisalType.ToString
                    Me.ddStatus.Text = _ProbationConfirmation.Status.ToString
                    Me.txtReviewDate.Text = _ProbationConfirmation.ReviewDate
                    Me.txtLevel.Text = _ProbationConfirmation.Level

                    Dim dt As New DataTable, i As Integer

                    dt.Columns.Add(New DataColumn("txtSN", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtResponsibilities", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtAvailableRating", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtSupervisorRating", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtEmployeeRating", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtKey", GetType(String)))


                    Do While i < _ProbationConfirmation.HR_Confirmation_Lines.Length

                        dt.Rows.Add(_ProbationConfirmation.HR_Confirmation_Lines(i).Entry_No, _ProbationConfirmation.HR_Confirmation_Lines(i).Responbilities, _ProbationConfirmation.HR_Confirmation_Lines(i).Available_Rating, _ProbationConfirmation.HR_Confirmation_Lines(i).Supervisor_Rating, _ProbationConfirmation.HR_Confirmation_Lines(i).Employee_Rating, _ProbationConfirmation.HR_Confirmation_Lines(i).Key)
                        LinesKeys.Add(_ProbationConfirmation.HR_Confirmation_Lines(i).Key)

                        i += 1

                    Loop

                    ViewState("LinesKey") = LinesKeys
                    LoadGridPaymentReqLines(dt)

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("Login.aspx")

                Else

                    populateStatus()
                    getNAVRC("")
                    populateAppraisalType()


                    Dim dtEmployeeCard As New DataTable
                    dtEmployeeCard = Session("dtEmployeeCard")

                    txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
                    txtEmployeeName.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("MiddleName").ToString.ToUpper

                    Me.txtSupervisor.Text = dtEmployeeCard.Rows(0).Item("SupervisorName").ToString
                    Me.txtEmploymentdate.Text = dtEmployeeCard.Rows(0).Item("EmploymentDate").ToString
                    Me.txtDepartment.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
                    Me.txtSupervisor2.Text = dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString


                End If
            Else


            End If


        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub

    Protected Sub LoadGridPaymentReqLines(dt As DataTable)

        ViewState("ProbationConfirmationLines") = dt
        Me.gridPaymentRequest.DataSource = dt
        gridPaymentRequest.DataBind()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

    End Sub
    Protected Sub gridPaymentRequest_RowDataBound()

    End Sub

    Private Sub gridPaymentRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridPaymentRequest.SelectedIndexChanged

        Dim selectedRowIndex As Integer, dtClaimTypes As New DataTable, i As Integer
        selectedRowIndex = Me.gridPaymentRequest.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridPaymentRequest.Rows(selectedRowIndex)



        Me.txtSN.Text = row.Cells(1).Text.ToString()
        Me.txtResponsibilities.Text = row.Cells(2).Text.ToString()
        Me.txtAvailableRating.Text = row.Cells(3).Text.ToString()
        Me.txtSupervisorRating.Text = row.Cells(4).Text.ToString()
        Me.txtEmployeeRating.Text = row.Cells(5).Text.ToString()


    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        Try

            If IsNothing(ViewState("selectedRowIndex")) = True Then

            Else

                ' dtPVLines = ViewState("PmtReqLines")

                Dim selectedRowIndex As Integer, dtProbationLines As New DataTable
                If IsNothing(ViewState("selectedRowIndex")) = False Then
                    selectedRowIndex = ViewState("selectedRowIndex")
                Else
                End If

                dtProbationLines = ViewState("ProbationConfirmationLines")
                dtProbationLines.Rows(selectedRowIndex).Delete()
                LoadGridPaymentReqLines(dtProbationLines)
                ClearLine()

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try

            Dim _DataRow As DataRow

            If IsNothing(ViewState("selectedRowIndex")) = True Then
                Dim dtProbationLines As New DataTable

                If IsNothing(ViewState("ProbationConfirmationLines")) = True Then

                    dtProbationLines.Columns.Add(New DataColumn("txtSN", GetType(String)))
                    dtProbationLines.Columns.Add(New DataColumn("txtResponsibilities", GetType(String)))
                    dtProbationLines.Columns.Add(New DataColumn("txtAvailableRating", GetType(String)))
                    dtProbationLines.Columns.Add(New DataColumn("txtSupervisorRating", GetType(String)))
                    dtProbationLines.Columns.Add(New DataColumn("txtEmployeeRating", GetType(String)))
                    dtProbationLines.Columns.Add(New DataColumn("txtKey", GetType(String)))

                Else

                    dtProbationLines = ViewState("ProbationConfirmationLines")

                End If

                Try

                    _DataRow = dtProbationLines.NewRow
                    _DataRow("txtSN") = Me.txtSN.Text
                    _DataRow("txtResponsibilities") = Me.txtResponsibilities.Text
                    _DataRow("txtAvailableRating") = Me.txtAvailableRating.Text
                    _DataRow("txtSupervisorRating") = Me.txtSupervisorRating.Text
                    _DataRow("txtEmployeeRating") = Me.txtEmployeeRating.Text
                    _DataRow("txtKey") = ""

                    dtProbationLines.Rows.Add(_DataRow)
                    LoadGridPaymentReqLines(dtProbationLines)
                    ClearLine()

                Catch ex As Exception

                    Dim logerr As New Global.Logger.Logger
                    logerr.FileSource = "NAV - Self Service Portal"
                    logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
                    logerr.Logger(ex.Message)

                End Try
            Else

                Dim selectedRowIndex As Integer, dtProbationLines As New DataTable
                If IsNothing(ViewState("selectedRowIndex")) = False Then
                    selectedRowIndex = ViewState("selectedRowIndex")
                Else
                End If

                dtProbationLines = ViewState("ProbationConfirmationLines")
                'dtPVLines.Rows(selectedRowIndex).Delete()
                _DataRow = dtProbationLines.Rows(selectedRowIndex)
                _DataRow("txtSN") = Me.txtSN.Text
                _DataRow("txtResponsibilities") = Me.txtResponsibilities.Text
                _DataRow("txtAvailableRating") = Me.txtAvailableRating.Text
                _DataRow("txtSupervisorRating") = Me.txtSupervisorRating.Text
                _DataRow("txtEmployeeRating") = Me.txtEmployeeRating.Text

                LoadGridPaymentReqLines(dtProbationLines)
                ClearLine()

            End If


        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub
    Protected Sub ClearLine()

        ' Me.txtInvoiceNo.Text = ""
        Me.txtSN.Text = ""
        Me.txtResponsibilities.Text = ""
        Me.txtAvailableRating.Text = ""
        Me.txtSupervisorRating.Text = ""
        Me.txtEmployeeRating.Text = ""
        ViewState("selectedRowIndex") = Nothing


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        Try

            Dim NAV_window As New NAV_HR_WINDOW.Core
            Dim lineCount As Integer = 0

            Dim ProbationConfirmationLines_() As ProbationConfirmationCard_Service.HR_Confirmation_Lines
            ReDim ProbationConfirmationLines_(Me.gridPaymentRequest.Rows.Count - 1)

            If IsNothing(ViewState("LinesKey")) = False Then
                LinesKeys = ViewState("LinesKey")
            Else
            End If



            Do While lineCount < Me.gridPaymentRequest.Rows.Count


                Dim ProbationConfirmationLine As ProbationConfirmationCard_Service.HR_Confirmation_Lines = New ProbationConfirmationCard_Service.HR_Confirmation_Lines

                ProbationConfirmationLine.Responbilities = gridPaymentRequest.Rows(lineCount).Cells(2).Text.ToString
                ProbationConfirmationLine.Available_Rating = gridPaymentRequest.Rows(lineCount).Cells(3).Text.ToString

                ProbationConfirmationLine.Available_RatingSpecified = True
                ProbationConfirmationLine.Supervisor_Rating = gridPaymentRequest.Rows(lineCount).Cells(4).Text.ToString

                ProbationConfirmationLine.Supervisor_RatingSpecified = True

                ProbationConfirmationLine.Employee_Rating = gridPaymentRequest.Rows(lineCount).Cells(5).Text.ToString
                ProbationConfirmationLine.Employee_RatingSpecified = True

                If gridPaymentRequest.Rows(lineCount).Cells(6).Text = "&nbsp;" Then

                    ProbationConfirmationLines_(lineCount) = ProbationConfirmationLine
                Else

                    If LinesKeys.Contains(gridPaymentRequest.Rows(lineCount).Cells(6).Text) = True Then

                        'NAV_window.DeletePaymentRequestLine(gridPaymentRequest.Rows(lineCount).Cells(7).Text)
                        ProbationConfirmationLines_(lineCount) = ProbationConfirmationLine
                        LinesKeys.RemoveAt(LinesKeys.IndexOf(gridPaymentRequest.Rows(lineCount).Cells(6).Text))

                    End If
                End If

                lineCount += 1

            Loop

            Dim i As Integer = 0

            'Do While i < LinesKeys.Count
            '    'deleting sraff claim lines removed by the user
            '    NAV_window.DeletePaymentRequestLine(LinesKeys.Item(i))
            '    i += 1
            'Loop

            Dim _confirmationProbation As ConfirmationProbation = New ConfirmationProbation With {
             .ApplicationNo = Me.txtApplicationNo.Text,
             .AppraisalType = ddAppraisalType.Text,
             .Comment = Me.txtComment.Text,
             .Department = Me.txtDepartment.Text,
             .DevelopmentAreas = Me.txtDevelopmentArea.Text,
             .EmployeeComment = Me.txtEmployeeComment.Text,
             .EmployeeName = Me.txtEmployeeName.Text,
             .EmployeeNo = Me.txtEmployeeNo.Text,
             .EmploymentDate = Me.txtEmploymentdate.Text,
             .EndDate = Me.txtEndDate.Text,
             .KPI_Score = Me.lblKPIScore.Text,
             .Score = Me.lblScore.Text,
             .Level = Me.txtLevel.Text,
             .ReviewDate = txtReviewDate.Text,
             .StartDate = Me.txtStartDate.Text,
             .Responsibility_Center = "SLS",
             .Status = Me.ddStatus.Text,
             .Supervisor = Me.txtSupervisor.Text,
             .Second_Line_Supervisor = Me.txtSupervisor2.Text,
            .Second_Line_Supervisor_Comment = Me.txtSupervisor2Comment.Text,
            .Training_Ideas = Me.txtTrainingIdeas.Text,
            .HR_Confirmation_Lines = ProbationConfirmationLines_
            }


            If Me.txtApplicationNo.Text <> "" Then

                MsgBox("" & NAV_window.UpdateProbationConfirmation(_confirmationProbation))
                Dim dtProbationConfirmation As New DataTable, userID As String = Session("userID")
                dtProbationConfirmation = NAV_window.getProbationConfirmationList()
                Session("ProbationConfirmation") = dtProbationConfirmation
                Response.Redirect("frmProbationConfirmations.aspx")
            Else

                MsgBox("" & NAV_window.CreateProbationConfirmation(_confirmationProbation))
                Dim dtProbationConfirmation As New DataTable, userID As String = Session("userID")
                dtProbationConfirmation = NAV_window.getProbationConfirmationList()
                Session("ProbationConfirmation") = dtProbationConfirmation
                Response.Redirect("frmProbationConfirmations.aspx")

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try



    End Sub
End Class
