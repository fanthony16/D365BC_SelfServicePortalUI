
Imports System.Data

Partial Class frmAppraisal
    Inherits System.Web.UI.Page

    Dim SelfEvalCollection, SelfFACollection, SelfOCCollection, SelfMCCollection, FKPICollection, CKPICollection, IKPICollection, LKPICollection, CareerQuesCollection, RCCollection As New Hashtable

    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub gridSelfEvaluation_RowDataBound()

    End Sub

    Private Sub frmAppraisal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Dim nav_window As New NAV_HR_WINDOW.Core, appraisalno As String
            Dim appraisalRequest As New List(Of NAV_HR_WINDOW.AppraisalRequest), dtEmployeeCard As New DataTable, lstManagement As New List(Of String), jobLevel As String
            'If IsPostBack = False And Not Context.Request.QueryString("ApplicationCode") Is Nothing Then

            lstManagement.Add("MD")
            lstManagement.Add("ED")
            lstManagement.Add("GM")
            lstManagement.Add("DGM")
            lstManagement.Add("PM")
            lstManagement.Add("AGM")

            dtEmployeeCard = Session("dtEmployeeCard")
            jobLevel = dtEmployeeCard.Rows(0).Item("JobLevel").ToString()
            If Not IsPostBack = True And Not Context.Request.QueryString("AppraisalNo") Is Nothing Then



                populateStatus()


                If lstManagement.Contains(dtEmployeeCard.Rows(0).Item("JobLevel").ToString()) = True Then
                    ManagementCompetency.Visible = True
                Else
                    ManagementCompetency.Visible = False
                End If

                appraisalno = Context.Request.QueryString("AppraisalNo")
                appraisalRequest = nav_window.getStaffAppraisal(appraisalno, "")
                ViewState("AppraisalKey") = appraisalRequest(0).Key
                Me.txtJobTitle.Text = appraisalRequest(0).JobTitle
                Me.txtAppraisalNo.Text = appraisalRequest(0).Appraisal_No
                    Me.txtAppraisalPeriod.Text = appraisalRequest(0).Appraisal_Period
                    Me.txtAppraisalHalf.Text = appraisalRequest(0).Appraisal_Half
                    Me.txtDepartment.Text = appraisalRequest(0).DepartmentName
                    Me.txtEmployeeName.Text = appraisalRequest(0).EmployeeName
                    Me.txtEmployeeNo.Text = appraisalRequest(0).EmployeeNo
                    Me.ddStatus.Text = appraisalRequest(0).Status
                Me.ddRC.Text = appraisalRequest(0).Responsibility_Center
                getResponsibilityCenter(appraisalRequest(0).Responsibility_Center)
                Me.txtCurrentLocation.Text = appraisalRequest(0).Responsibility_Center
                    Me.txtAppraisalDate.Text = CDate(appraisalRequest(0).Appraisal_Date)
                Dim dtSelfEval, dtSelfFA, dtSelfOC, dtSelfMC, dtFKPI, dtCareerDevQues As New DataTable
                ddRC.Text = appraisalRequest(0).Responsibility_Center
                ddStatus.Text = appraisalRequest(0).Status

                Me.txtEmployeeComment.Text = appraisalRequest(0).EmployeeComment
                Me.txtSupervisorComment.Text = appraisalRequest(0).SupervisorComment
                Me.txtHODComment.Text = appraisalRequest(0).HODComment
                Me.txtMDComment.Text = appraisalRequest(0).MDComment


                Me.txtSelfAppraisalNo.Text = Me.txtAppraisalNo.Text
                    populateSelfEvaluationQuestion(appraisalRequest(0).SelfEvaluations)
                    getSelfEvaluationResponses(appraisalRequest(0).Appraisal_No)

                dtSelfFA = getdtBehavouralList(nav_window.getAppraisalBehavoural("FUNCTIONAL ASSESSMENT", appraisalRequest(0).Appraisal_No), "FA")

                dtSelfOC = getdtBehavouralList(nav_window.getAppraisalBehavoural("ORGANISATIONAL CAPABILITY", appraisalRequest(0).Appraisal_No), "OC")

                dtSelfMC = getdtBehavouralList(nav_window.getAppraisalBehavoural("MANAGEMENT COMPETENCIES", appraisalRequest(0).Appraisal_No), "MC")


                dtCareerDevQues = getdtCareerDevelopmentList(nav_window.GetCareerDevelopments(appraisalRequest(0).Appraisal_No))

                'dtFKPI = getdtKPIList(nav_window.getKPIFinancial(appraisalRequest(0).Appraisal_No), "FI")
                getKPIList((appraisalRequest(0).Appraisal_No), "FI")
                getKPIList((appraisalRequest(0).Appraisal_No), "CU")
                getKPIList((appraisalRequest(0).Appraisal_No), "IP")
                getKPIList((appraisalRequest(0).Appraisal_No), "LG")

                'MsgBox("" & dtSelfMC.Rows.Count)
                'ORGANISATIONAL CAPABILITY
                'FUNCTIONAL ASSESSMENT
                '                populateSelfEvaluation(dtSelfEval)

                populateFunctionalAssessment(dtSelfFA)
                populateOrganisationalCapability(dtSelfOC)
                populateManagementCompetencies(dtSelfMC)
                populateCareerDevelopmentQuestions(dtCareerDevQues)

                'ViewState("SelfEval") = dtSelfEval
                ViewState("SelfFA") = dtSelfFA
                ViewState("SelfOC") = dtSelfOC
                ViewState("SelfMC") = dtSelfMC



            Else

                End If

        Catch ex As Exception

            '  MsgBox("" & ex.Message)

        End Try

    End Sub

    Protected Sub getKPIList(appraisalno As String, KPIType As String)
        Dim nav_window As New NAV_HR_WINDOW.Core, dtFKPI, dtCKPI, dtIKPI, dtLKPI As New DataTable
        If KPIType = "FI" Then

            dtFKPI = getdtKPIList(nav_window.getKPIFinancial(appraisalno), KPIType)
            populateFinancialKPI(dtFKPI)
            ViewState("FKPI") = dtFKPI

        ElseIf KPIType = "CU" Then

            dtCKPI = getdtKPIList(nav_window.getKPICustomer(appraisalno), KPIType)
            populateCustomerKPI(dtCKPI)
            ViewState("CKPI") = dtCKPI

        ElseIf KPIType = "IP" Then

            dtIKPI = getdtKPIList(nav_window.getKPIInternal(appraisalno), KPIType)
            populateInternalKPI(dtIKPI)
            ViewState("IKPI") = dtIKPI

        ElseIf KPIType = "LG" Then

            dtLKPI = getdtKPIList(nav_window.getKPILearning(appraisalno), KPIType)
            populateLearningKPI(dtLKPI)
            ViewState("LKPI") = dtLKPI

        End If

    End Sub

    Protected Sub getSelfquestionresponses(description As String)
        Dim dtSelfEvalAll, dtSelfEvalSel As New DataTable, dtColumn As New DataColumn, result As DataRow()

        dtSelfEvalAll = ViewState("SelfEval")

        result = dtSelfEvalAll.Select("txtDescription = '" & description & "'")


        dtSelfEvalSel = New DataTable

        dtColumn = New DataColumn("txtLineNo")
        dtSelfEvalSel.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtDescription")
        dtSelfEvalSel.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtSelf_Evaluation")
        dtSelfEvalSel.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtKey")
        dtSelfEvalSel.Columns.Add(dtColumn)

        For Each row As DataRow In result
            'dtEmployeeCard = NAV_Window.getEmployee(row.Item(0))

            Dim newSelfEvalRow As DataRow
            newSelfEvalRow = dtSelfEvalSel.NewRow()

            newSelfEvalRow("txtLineNo") = row.Item(0)
            newSelfEvalRow("txtDescription") = row.Item(1)
            newSelfEvalRow("txtSelf_Evaluation") = row.Item(2).ToString
            newSelfEvalRow("txtKey") = row.Item(3).ToString

            dtSelfEvalSel.Rows.Add(newSelfEvalRow)

        Next

        populateSelfEvaluation(dtSelfEvalSel)

        'Return dtSelfEval

    End Sub

    Protected Sub populateStatus()

        Me.ddStatus.Items.Add("")
        Me.ddStatus.Items.Add("Approved")
        Me.ddStatus.Items.Add("Closed")
        Me.ddStatus.Items.Add("HR")
        Me.ddStatus.Items.Add("Open")
        Me.ddStatus.Items.Add("Pending_Approval")
        Me.ddStatus.Items.Add("Review")

    End Sub

    Protected Sub getResponsibilityCenter(rc As String)

        Dim dtRC As New DataTable
        Dim RCCollection As New Hashtable
        'checking if the sesion object still has the responsibilty center data
        If IsNothing(Session("RCAppraisal")) = True Then

            Response.Redirect("Login.aspx")

        Else
            'retrieving the responsibility center from the session object
            RCCollection = Session("RCAppraisal")
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



    'retrieving Responsibility Center Data




    Private Sub populateSelfEvaluation(dt As DataTable)
        Try


            Me.gridSelfEvaluation.DataSource = dt
            gridSelfEvaluation.DataBind()
            ViewState("SelfEvaluationData") = dt
            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub


    Private Sub populateFunctionalAssessment(dt As DataTable)
        Try


            Me.gridFunctionalAssessment.DataSource = dt
            gridFunctionalAssessment.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateOrganisationalCapability(dt As DataTable)
        Try


            Me.gridOrganisationalCapability.DataSource = dt
            gridOrganisationalCapability.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateCareerDevelopmentQuestions(dt As DataTable)
        Try


            Me.gridCareerDev.DataSource = dt
            gridCareerDev.DataBind()

            ' pnlUploadDetail.Height = Nothing
            ViewState("CareerDevQues") = dt

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateManagementCompetencies(dt As DataTable)
        Try


            Me.gridManagementCompetency.DataSource = dt
            gridManagementCompetency.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateFinancialKPI(dt As DataTable)
        Try


            Me.gridFKPI.DataSource = dt
            gridFKPI.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateCustomerKPI(dt As DataTable)
        Try


            Me.gridCKPI.DataSource = dt
            gridCKPI.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub populateInternalKPI(dt As DataTable)
        Try


            Me.gridIKPI.DataSource = dt
            gridIKPI.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub


    Private Sub populateLearningKPI(dt As DataTable)
        Try


            Me.gridLKPI.DataSource = dt
            gridLKPI.DataBind()

            ' pnlUploadDetail.Height = Nothing

        Catch ex As Exception

        End Try
    End Sub


    Private Sub gridSelfEvaluation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridSelfEvaluation.SelectedIndexChanged

        Dim selectedRowIndex As Integer, dtClaimTypes As New DataTable, i As Integer
        selectedRowIndex = Me.gridSelfEvaluation.SelectedRow.RowIndex
        ViewState("SelfEvalSelectedRowIndex") = selectedRowIndex

        'LineNo - Index 1

        Dim row As GridViewRow = gridSelfEvaluation.Rows(selectedRowIndex)

        'Me.txtSelfAppraisalNo.Text = row.Cells(1).Text.ToString()
        Me.ddSelfEvaluationList.Text = row.Cells(2).Text.ToString()
        Me.txtSelfEvaluation.Text = row.Cells(3).Text.ToString()

        If Me.txtSelfEvaluation.Text = "&nbsp;" Then
            Me.txtSelfEvaluation.Text = ""
        Else

        End If




    End Sub

    Private Sub clearEntryFKPI()

        Me.txtFKPItargetObjective.Text = ""
        Me.txtFKPIDescription.Text = ""
        Me.ddFKPITiming.Text = ""
        Me.txtFKPIWeight.Text = ""
        Me.txtFKPIScore.Text = "0"
        Me.txtFKPISupervisorScore.Text = "0"
        Me.ddFKPIRating.Text = ""

    End Sub

    Private Sub clearEntryCKPI()

        Me.txtCKPItargetObjective.Text = ""
        Me.txtCKPIDescription.Text = ""
        Me.ddCKPITiming.Text = ""
        Me.txtCKPIWeight.Text = ""
        Me.txtCKPIScore.Text = "0"
        Me.txtCKPISupervisorScore.Text = "0"
        Me.ddCKPIRating.Text = ""

    End Sub

    Private Sub clearEntryLKPI()

        Me.txtLKPItargetObjective.Text = ""
        Me.txtLKPIDescription.Text = ""
        Me.ddLKPITiming.Text = ""
        Me.txtLKPIWeight.Text = ""
        Me.txtLKPIScore.Text = "0"
        Me.txtLKPISupervisorScore.Text = "0"
        Me.ddLKPIRating.Text = ""

    End Sub

    Private Sub clearEntryIKPI()

        Me.txtIKPItargetObjective.Text = ""
        Me.txtIKPIDescription.Text = ""
        Me.ddIKPITiming.Text = ""
        Me.txtIKPIWeight.Text = ""
        Me.txtIKPIScore.Text = "0"
        Me.txtIKPISupervisorScore.Text = "0"
        Me.ddIKPIRating.Text = ""

    End Sub


    Private Sub clearEntryMC()

        Me.txtMCActualResult.Text = ""
        Me.txtMCAgreedScore.Text = ""
        Me.txtMCDescription.Text = ""
        Me.txtMCDescription.Text = ""
        Me.txtMCWeight.Text = ""
        'Me.ddMCTiming.Text = ""
        Me.txtMCtargetObjective.Text = ""

    End Sub

    Private Sub clearEntryOC()

        Me.txtOCActualResult.Text = ""
        Me.txtOCAgreedScore.Text = ""
        Me.txtOCDescription.Text = ""
        Me.txtOCDescription.Text = ""
        Me.txtOCWeight.Text = ""
        'Me.ddOCTiming.Text = ""
        Me.txtOCtargetObjective.Text = ""

    End Sub

    Private Sub clearEntryFA()

        Me.txtFAActualResult.Text = ""
        Me.txtFAAgreedScore.Text = ""
        Me.txtFADescription.Text = ""
        Me.txtFADescription.Text = ""
        Me.txtFAWeight.Text = ""
        'Me.ddFATiming.Text = ""
        Me.txtFATargetObjective.Text = ""

    End Sub

    Private Sub clearEntry()
        txtSelfAppraisalNo.Text = ""
        'txtSelfDescription.Text = ""
        txtSelfEvaluation.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _selfEval, _selfEvalRes As New NAV_HR_WINDOW.SelfEvaluation
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtSelfEval As New DataTable, dt As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            'ViewState("SelfEvalSelectedRowIndex") = selectedRowIndex

            dt = ViewState("SelfEvaluationData")

            If Not IsNothing(ViewState("SelfEvalSelectedRowIndex")) = True And Me.txtSelfEvaluation.Text <> "" Then

                selectedRowIndex = CInt(ViewState("SelfEvalSelectedRowIndex"))
                _selfEval.LineNo = Me.gridSelfEvaluation.Rows(selectedRowIndex).Cells(1).Text
                _selfEval.Appraisal_No = Me.txtSelfAppraisalNo.Text
                _selfEval.Self_Evaluation = Me.txtSelfEvaluation.Text
                _selfEval.Key = dt.Rows(selectedRowIndex).Item(3).ToString

                _res = nav_window.UpdateAppraisalSelfEvaluation(_selfEval)
                Me.txtSelfEvaluation.Text = ""
                ViewState("SelfEvalSelectedRowIndex") = Nothing
                getSelfEvaluationResponses(Me.txtSelfAppraisalNo.Text)
                getSelfquestionresponses(Me.ddSelfEvaluationList.Text)

            ElseIf Not IsNothing(ViewState("SelfEvalSelectedRowIndex")) = False And Me.txtSelfEvaluation.Text <> "" Then

                _selfEval.Appraisal_No = Me.txtSelfAppraisalNo.Text
                _selfEval.Self_Evaluation = Me.txtSelfEvaluation.Text
                _selfEval.Description = ddSelfEvaluationList.Text
                _selfEvalRes = nav_window.CreateAppraisalSelfEvaluation(_selfEval)
                Me.txtSelfEvaluation.Text = ""
                ViewState("SelfEvalSelectedRowIndex") = Nothing
                getSelfEvaluationResponses(Me.txtSelfAppraisalNo.Text)
                getSelfquestionresponses(Me.ddSelfEvaluationList.Text)

            Else

                Exit Sub

            End If


            'selectedRowIndex = CInt(ViewState("selectedRowIndex"))
            '_selfEval.Appraisal_No = Me.txtSelfAppraisalNo.Text
            ''_selfEval.Description = Me.txtSelfDescription.Text
            '_selfEval.Self_Evaluation = Me.txtSelfEvaluation.Text

            'If Not IsNothing(ViewState("SelfEvalCollection")) = True Then

            '    SelfEvalCollection = ViewState("SelfEvalCollection")

            '    _selfEval.Key = SelfEvalCollection.Item(selectedRowIndex).ToString().Trim
            '    _res = nav_window.UpdateAppraisalSelfEvaluation(_selfEval)
            '    dtSelfEval = ViewState("SelfEval")
            '    row = dtSelfEval.Rows(selectedRowIndex)
            '    row("txtSelf_Evaluation") = Me.txtSelfEvaluation.Text
            '    ViewState("SelfEval") = dtSelfEval
            '    populateSelfEvaluation(dtSelfEval)
            '    clearEntry()

            'Else

            'End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try


    End Sub

    Private Sub gridFunctionalAssessment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridFunctionalAssessment.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        selectedRowIndex = Me.gridFunctionalAssessment.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridFunctionalAssessment.Rows(selectedRowIndex)

        Me.txtFATargetObjective.Text = row.Cells(1).Text.ToString()
        Me.txtFADescription.Text = row.Cells(2).Text.ToString()
        'Me.ddFATiming.Text = row.Cells(3).Text.ToString()

        Me.txtFAWeight.Text = row.Cells(3).Text.ToString()
        Me.txtFAActualResult.Text = row.Cells(4).Text.ToString()
        Me.txtFAAgreedScore.Text = row.Cells(5).Text.ToString()

    End Sub

    Private Sub gridOrganisationalCapability_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridOrganisationalCapability.SelectedIndexChanged


        Dim selectedRowIndex As Integer
        selectedRowIndex = Me.gridOrganisationalCapability.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridOrganisationalCapability.Rows(selectedRowIndex)

        Me.txtOCtargetObjective.Text = row.Cells(1).Text.ToString()
        Me.txtOCDescription.Text = row.Cells(2).Text.ToString()
        'Me.ddOCTiming.Text = row.Cells(3).Text.ToString()

        Me.txtOCWeight.Text = row.Cells(3).Text.ToString()
        Me.txtOCActualResult.Text = row.Cells(4).Text.ToString()
        Me.txtOCAgreedScore.Text = row.Cells(5).Text.ToString()

    End Sub

    Private Sub btnFAAdd_Click(sender As Object, e As EventArgs) Handles btnFAAdd.Click

        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtSelfFA As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            selectedRowIndex = CInt(ViewState("selectedRowIndex"))

            If Not IsNothing(ViewState("SelfFACollection")) = True Then

                SelfFACollection = ViewState("SelfFACollection")

                _selfBehavioural.ActualResult = Me.txtFAActualResult.Text
                _selfBehavioural.Key = SelfFACollection.Item(selectedRowIndex)
                _selfBehavioural.Appraisal_No = txtAppraisalNo.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                _res = nav_window.UpdateAppraisalBehavoural(_selfBehavioural)

                dtSelfFA = ViewState("SelfFA")
                row = dtSelfFA.Rows(selectedRowIndex)
                row("txtActualResult") = Me.txtFAActualResult.Text
                ViewState("SelfFA") = dtSelfFA
                populateFunctionalAssessment(dtSelfFA)
                clearEntryFA()

            Else

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try

    End Sub

    Private Sub btnOCAdd_Click(sender As Object, e As EventArgs) Handles btnOCAdd.Click


        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtSelfOC As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            selectedRowIndex = CInt(ViewState("selectedRowIndex"))

            If Not IsNothing(ViewState("SelfOCCollection")) = True Then

                SelfOCCollection = ViewState("SelfOCCollection")
                _selfBehavioural.ActualResult = Me.txtOCActualResult.Text
                _selfBehavioural.Key = SelfOCCollection.Item(selectedRowIndex)
                _selfBehavioural.Employee_No = txtEmployeeNo.Text
                _res = nav_window.UpdateAppraisalBehavoural(_selfBehavioural)

                dtSelfOC = ViewState("SelfOC")
                row = dtSelfOC.Rows(selectedRowIndex)
                row("txtActualResult") = Me.txtOCActualResult.Text
                ViewState("SelfOC") = dtSelfOC
                'populateFunctionalAssessment(dtSelfOC)
                populateOrganisationalCapability(dtSelfOC)
                clearEntryOC()

            Else

            End If

        Catch ex As Exception

            ' MsgBox("" & ex.Message)

        End Try


    End Sub
    'get appraisal self evaluation list

    'populating self evaluation questions on the page
    Private Sub populateSelfEvaluationQuestion(SelfEval As List(Of NAV_HR_WINDOW.SelfEvaluationList))
        Dim i As Integer = 0
        Try
            ddSelfEvaluationList.Items.Clear()
            ddSelfEvaluationList.Items.Add("")
            Do While i < SelfEval.Count

                ddSelfEvaluationList.Items.Add(SelfEval(i).Description)
                i += 1

            Loop

        Catch ex As Exception

        End Try
    End Sub

    ' retrieving self evaluation answers for the appraisal document

    Private Sub getSelfEvaluationResponses(appraisalNo As String)

        Dim dtSelfEval As New DataTable, dtColumn As New DataColumn, i As Integer
        Dim _selfEvals As New List(Of NAV_HR_WINDOW.SelfEvaluation), nav_window As New NAV_HR_WINDOW.Core

        dtSelfEval = New DataTable

        dtColumn = New DataColumn("txtLineNo")
        dtSelfEval.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtDescription")
        dtSelfEval.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtSelf_Evaluation")
        dtSelfEval.Columns.Add(dtColumn)

        dtColumn = New DataColumn("txtKey")
        dtSelfEval.Columns.Add(dtColumn)

        Try

            _selfEvals = nav_window.getSelfEvaluationResponse(appraisalNo)

            i = 0

            Do While i < _selfEvals.Count

                Dim newSelfEvalRow As DataRow
                newSelfEvalRow = dtSelfEval.NewRow()
                newSelfEvalRow("txtLineNo") = _selfEvals.Item(i).LineNo
                newSelfEvalRow("txtDescription") = _selfEvals.Item(i).Description
                newSelfEvalRow("txtSelf_Evaluation") = _selfEvals.Item(i).Self_Evaluation
                newSelfEvalRow("txtKey") = _selfEvals.Item(i).Key

                dtSelfEval.Rows.Add(newSelfEvalRow)

                i += 1

            Loop

        Catch ex As Exception

        End Try

        ViewState("SelfEval") = dtSelfEval



    End Sub

    Private Function getdtCareerDevelopmentList(CareerDevQues As List(Of NAV_HR_WINDOW.CareerDevelopmentQuestion)) As DataTable

        Dim i As Integer = 0, dtCareerDevQues As New DataTable, dtColumn As New DataColumn

        CareerQuesCollection.Clear()

        If CareerDevQues.Count > 0 Then

            dtCareerDevQues = New DataTable

            dtColumn = New DataColumn("txtAppraisalNo")
            dtCareerDevQues.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtQuestion")
            dtCareerDevQues.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtAnswer")
            dtCareerDevQues.Columns.Add(dtColumn)

            Do While i < CareerDevQues.Count

                Dim newSelfBHRow As DataRow
                newSelfBHRow = dtCareerDevQues.NewRow()

                newSelfBHRow("txtAppraisalNo") = CareerDevQues(i).AppraisalNo
                newSelfBHRow("txtQuestion") = CareerDevQues(i).Question
                newSelfBHRow("txtAnswer") = CareerDevQues(i).Answer

                dtCareerDevQues.Rows.Add(newSelfBHRow)

                CareerQuesCollection.Add(i, CareerDevQues(i).Key)

                i += 1

            Loop

        End If

        ViewState("CareerQuesCollection") = CareerQuesCollection

        Return dtCareerDevQues


    End Function

    Private Function getdtBehavouralList(SelfBH As List(Of NAV_HR_WINDOW.Behavoural), recType As String) As DataTable

        Dim i As Integer = 0, dtSelfBH As New DataTable, dtColumn As New DataColumn

        If SelfBH.Count > 0 Then

            dtSelfBH = New DataTable

            dtColumn = New DataColumn("txtAppraisalNo")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtTargetObjective")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtDescription")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtTiming")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtWeight")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtActualResult")
            dtSelfBH.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtAgreedScore")
            dtSelfBH.Columns.Add(dtColumn)


            Do While i < SelfBH.Count

                Dim newSelfBHRow As DataRow
                newSelfBHRow = dtSelfBH.NewRow()

                newSelfBHRow("txtAppraisalNo") = SelfBH(i).Appraisal_No
                newSelfBHRow("txtTargetObjective") = SelfBH(i).TargetObjective
                newSelfBHRow("txtDescription") = SelfBH(i).Description
                newSelfBHRow("txtTiming") = SelfBH(i).Timing
                newSelfBHRow("txtWeight") = SelfBH(i).Weight
                newSelfBHRow("txtActualResult") = SelfBH(i).ActualResult
                newSelfBHRow("txtAgreedScore") = SelfBH(i).AgreedScore

                dtSelfBH.Rows.Add(newSelfBHRow)
                If recType = "FA" Then
                    SelfFACollection.Add(i, SelfBH(i).Key)
                ElseIf recType = "OC" Then
                    SelfOCCollection.Add(i, SelfBH(i).Key)
                ElseIf recType = "MC" Then
                    SelfMCCollection.Add(i, SelfBH(i).Key)
                End If

                i += 1

            Loop

        End If

        ViewState("SelfFACollection") = SelfFACollection
        ViewState("SelfOCCollection") = SelfOCCollection
        ViewState("SelfMCCollection") = SelfMCCollection

        Return dtSelfBH


    End Function


    Private Function getdtKPIList(KPI As List(Of NAV_HR_WINDOW.Behavoural), recType As String) As DataTable

        Dim i As Integer = 0, dtKPI As New DataTable, dtColumn As New DataColumn

        FKPICollection.Clear()
        CKPICollection.Clear()
        IKPICollection.Clear()
        LKPICollection.Clear()


        If KPI.Count > 0 Then

            dtKPI = New DataTable

            dtColumn = New DataColumn("txtAppraisalNo")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtTargetObjective")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtDescription")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtTiming")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtRating")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtWeight")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtScore")
            dtKPI.Columns.Add(dtColumn)

            dtColumn = New DataColumn("txtSupervisorscore")
            dtKPI.Columns.Add(dtColumn)

            Do While i < KPI.Count

                Dim newSelfBHRow As DataRow
                newSelfBHRow = dtKPI.NewRow()

                newSelfBHRow("txtAppraisalNo") = KPI(i).Appraisal_No
                newSelfBHRow("txtTargetObjective") = KPI(i).TargetObjective
                newSelfBHRow("txtDescription") = KPI(i).Description
                newSelfBHRow("txtTiming") = KPI(i).Timing
                newSelfBHRow("txtRating") = KPI(i).Ratings
                newSelfBHRow("txtWeight") = KPI(i).Weight
                newSelfBHRow("txtScore") = KPI(i).Score
                newSelfBHRow("txtSupervisorscore") = KPI(i).Supervisor_Score

                dtKPI.Rows.Add(newSelfBHRow)

                If recType = "FI" Then

                    FKPICollection.Add(i, KPI(i).Key)

                ElseIf recType = "CU" Then
                    CKPICollection.Add(i, KPI(i).Key)
                ElseIf recType = "IP" Then
                    IKPICollection.Add(i, KPI(i).Key)
                ElseIf recType = "LG" Then
                    LKPICollection.Add(i, KPI(i).Key)
                End If

                i += 1

            Loop

        End If

        ViewState("FKPICollection") = FKPICollection
        ViewState("CKPICollection") = CKPICollection
        ViewState("IKPICollection") = IKPICollection
        ViewState("LKPICollection") = LKPICollection

        Return dtKPI


    End Function

    Private Sub btnSendToSupervisor_Click(sender As Object, e As EventArgs) Handles btnSendToSupervisor.Click
        Dim nav_window As New NAV_HR_WINDOW.Core, _status As String, lstAppraisalRequest As New List(Of NAV_HR_WINDOW.AppraisalRequest), dtEmployeeCard As New DataTable

        Try
            Span2.InnerText = ""
            _status = nav_window.SendAppraisalToSupervisor(Me.txtAppraisalNo.Text)
            If _status = "Success" Then
                Span2.InnerText = "Appraisal Sent to Supervisor Successfully"

                dtEmployeeCard = Session("dtEmployeeCard")
                lstAppraisalRequest = nav_window.getStaffAppraisal("", dtEmployeeCard.Rows(0)("No"))
                Session("AppraisalRequest") = lstAppraisalRequest
                Response.Redirect("frmAppraisalList.aspx")

            Else
                Span2.InnerText = _status
            End If


        Catch ex As Exception

            Span2.InnerText = ex.Message

        End Try

    End Sub

    Private Sub ddSelfEvaluationList_TextChanged(sender As Object, e As EventArgs) Handles ddSelfEvaluationList.TextChanged


        Me.txtSelfEvaluation.Text = ""
        getSelectedSelfQuestionResponses(ddSelfEvaluationList.Text)

    End Sub

    Private Sub getSelectedSelfQuestionResponses(question As String)
        getSelfquestionresponses(question)
    End Sub

    Private Sub btnMCAdd_Click(sender As Object, e As EventArgs) Handles btnMCAdd.Click


        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtSelfMC As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            selectedRowIndex = CInt(ViewState("selectedRowIndex"))

            If Not IsNothing(ViewState("SelfMCCollection")) = True Then

                SelfMCCollection = ViewState("SelfMCCollection")
                _selfBehavioural.ActualResult = Me.txtMCActualResult.Text
                _selfBehavioural.Key = SelfMCCollection.Item(selectedRowIndex)
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                _res = nav_window.UpdateAppraisalBehavoural(_selfBehavioural)

                dtSelfMC = ViewState("SelfMC")
                row = dtSelfMC.Rows(selectedRowIndex)
                row("txtActualResult") = Me.txtMCActualResult.Text

                ViewState("SelfMC") = dtSelfMC

                populateManagementCompetencies(dtSelfMC)
                clearEntryMC()

            Else

            End If

        Catch ex As Exception

            ' MsgBox("" & ex.Message)

        End Try

    End Sub

    Private Sub gridManagementCompetency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridManagementCompetency.SelectedIndexChanged


        Dim selectedRowIndex As Integer
        selectedRowIndex = Me.gridManagementCompetency.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridManagementCompetency.Rows(selectedRowIndex)

        Me.txtMCtargetObjective.Text = row.Cells(1).Text.ToString()
        Me.txtMCDescription.Text = row.Cells(2).Text.ToString()
        'Me.ddMCTiming.Text = row.Cells(3).Text.ToString()

        Me.txtMCWeight.Text = row.Cells(3).Text.ToString()
        Me.txtMCActualResult.Text = row.Cells(4).Text.ToString()
        Me.txtMCAgreedScore.Text = row.Cells(5).Text.ToString()

    End Sub

    Private Sub btnFKPIAdd_Click(sender As Object, e As EventArgs) Handles btnFKPIAdd.Click

        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtFKPI As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            If Not IsNothing(ViewState("FKPICollection")) = True And Not IsNothing(ViewState("selectedRowIndexFKPI")) = True Then

                FKPICollection = ViewState("FKPICollection")
                selectedRowIndex = CInt(ViewState("selectedRowIndexFKPI"))

                _selfBehavioural.Key = FKPICollection.Item(selectedRowIndex)
                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtFKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtFKPIDescription.Text
                _selfBehavioural.Weight = Me.txtFKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddFKPIRating.Text
                _selfBehavioural.Score = Me.txtFKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtFKPISupervisorScore.Text
                _selfBehavioural.Timing = ddFKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text

                _res = nav_window.createKPIFinancial(_selfBehavioural)


                getKPIList((Me.txtAppraisalNo.Text), "FI")




                'ViewState("FKPI") = dtFKPI

                'populateFinancialKPI(dtFKPI)
                clearEntryFKPI()
                ViewState("selectedRowIndexFKPI") = Nothing

            Else

                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtFKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtFKPIDescription.Text
                _selfBehavioural.Weight = Me.txtFKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddFKPIRating.Text
                _selfBehavioural.Score = Me.txtFKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtFKPISupervisorScore.Text

                _selfBehavioural.AppraisalPeriod = Me.txtAppraisalPeriod.Text
                _selfBehavioural.AppraisalHalf = CInt(Me.txtAppraisalHalf.Text)
                _selfBehavioural.Key = ""
                _selfBehavioural.Timing = Me.ddFKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                'Me.txtAppraisalPeriod.Text = appraisalRequest(0).Appraisal_Period
                'Me.txtAppraisalHalf.Text = appraisalRequest(0).Appraisal_Half


                _res = nav_window.createKPIFinancial(_selfBehavioural)
                clearEntryFKPI()
                getKPIList(Me.txtAppraisalNo.Text, "FI")

            End If

        Catch ex As Exception

            ' MsgBox("" & ex.Message)

        End Try




    End Sub

    Private Sub gridFKPI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridFKPI.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        Try

            selectedRowIndex = Me.gridFKPI.SelectedRow.RowIndex


            Dim row As GridViewRow = gridFKPI.Rows(selectedRowIndex)

            Me.txtFKPItargetObjective.Text = row.Cells(1).Text.ToString()
            Me.txtFKPIDescription.Text = row.Cells(2).Text.ToString()
            Me.ddFKPITiming.Text = row.Cells(3).Text.ToString()
            Me.ddFKPIRating.Text = row.Cells(4).Text.ToString()
            Me.txtFKPIWeight.Text = row.Cells(5).Text.ToString()
            Me.txtFKPIScore.Text = row.Cells(6).Text.ToString()
            Me.txtFKPISupervisorScore.Text = row.Cells(7).Text.ToString()

            ViewState("selectedRowIndexFKPI") = selectedRowIndex

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try


    End Sub

    Private Sub btnCKPIAdd_Click(sender As Object, e As EventArgs) Handles btnCKPIAdd.Click

        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtFKPI As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            If Not IsNothing(ViewState("CKPICollection")) = True And Not IsNothing(ViewState("selectedRowIndexCKPI")) = True Then

                CKPICollection = ViewState("CKPICollection")
                selectedRowIndex = CInt(ViewState("selectedRowIndexCKPI"))

                _selfBehavioural.Key = CKPICollection.Item(selectedRowIndex)
                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtCKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtCKPIDescription.Text
                _selfBehavioural.Weight = Me.txtCKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddCKPIRating.Text
                _selfBehavioural.Score = Me.txtCKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtCKPISupervisorScore.Text
                _selfBehavioural.Timing = ddCKPITiming.Text

                _res = nav_window.createKPICustomer(_selfBehavioural)
                Span2.InnerText = _res

                getKPIList((Me.txtAppraisalNo.Text), "CU")

                clearEntryCKPI()
                ViewState("selectedRowIndexCKPI") = Nothing

            Else

                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtCKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtCKPIDescription.Text
                _selfBehavioural.Weight = Me.txtCKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddCKPIRating.Text
                _selfBehavioural.Score = Me.txtCKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtCKPISupervisorScore.Text

                _selfBehavioural.AppraisalPeriod = Me.txtAppraisalPeriod.Text
                _selfBehavioural.AppraisalHalf = CInt(Me.txtAppraisalHalf.Text)
                _selfBehavioural.Key = ""
                _selfBehavioural.Timing = Me.ddCKPITiming.Text

                _res = nav_window.createKPICustomer(_selfBehavioural)
                Span2.InnerText = _res
                getKPIList(Me.txtAppraisalNo.Text, "CU")

                clearEntryCKPI()

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try


    End Sub

    Private Sub frmAppraisal_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    Private Sub gridCKPI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridCKPI.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        Try

            selectedRowIndex = Me.gridCKPI.SelectedRow.RowIndex

            Dim row As GridViewRow = gridCKPI.Rows(selectedRowIndex)

            Me.txtCKPItargetObjective.Text = row.Cells(1).Text.ToString()
            Me.txtCKPIDescription.Text = row.Cells(2).Text.ToString()
            Me.ddCKPITiming.Text = row.Cells(3).Text.ToString()
            Me.ddCKPIRating.Text = row.Cells(4).Text.ToString()
            Me.txtCKPIWeight.Text = row.Cells(5).Text.ToString()
            Me.txtCKPIScore.Text = row.Cells(6).Text.ToString()
            Me.txtCKPISupervisorScore.Text = row.Cells(7).Text.ToString()

            ViewState("selectedRowIndexCKPI") = selectedRowIndex

        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub



    Private Sub gridIKPI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridIKPI.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        Try

            selectedRowIndex = Me.gridIKPI.SelectedRow.RowIndex

            Dim row As GridViewRow = gridIKPI.Rows(selectedRowIndex)

            Me.txtIKPItargetObjective.Text = row.Cells(1).Text.ToString()
            Me.txtIKPIDescription.Text = row.Cells(2).Text.ToString()
            Me.ddIKPITiming.Text = row.Cells(3).Text.ToString()
            Me.ddIKPIRating.Text = row.Cells(4).Text.ToString()
            Me.txtIKPIWeight.Text = row.Cells(5).Text.ToString()
            Me.txtIKPIScore.Text = row.Cells(6).Text.ToString()
            Me.txtIKPISupervisorScore.Text = row.Cells(7).Text.ToString()

            ViewState("selectedRowIndexIKPI") = selectedRowIndex

        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub

    Private Sub btnIKPIAdd_Click(sender As Object, e As EventArgs) Handles btnIKPIAdd.Click


        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtIKPI As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            If Not IsNothing(ViewState("IKPICollection")) = True And Not IsNothing(ViewState("selectedRowIndexIKPI")) = True Then

                IKPICollection = ViewState("IKPICollection")
                selectedRowIndex = CInt(ViewState("selectedRowIndexIKPI"))

                _selfBehavioural.Key = IKPICollection.Item(selectedRowIndex)
                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtIKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtIKPIDescription.Text
                _selfBehavioural.Weight = Me.txtIKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddIKPIRating.Text
                _selfBehavioural.Score = Me.txtIKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtIKPISupervisorScore.Text
                _selfBehavioural.Timing = ddIKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                _res = nav_window.createKPIInternal(_selfBehavioural)
                Span2.InnerText = _res

                getKPIList((Me.txtAppraisalNo.Text), "IP")

                clearEntryIKPI()
                ViewState("selectedRowIndexIKPI") = Nothing

            Else

                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtIKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtIKPIDescription.Text
                _selfBehavioural.Weight = Me.txtIKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddIKPIRating.Text
                _selfBehavioural.Score = Me.txtIKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtIKPISupervisorScore.Text

                _selfBehavioural.AppraisalPeriod = Me.txtAppraisalPeriod.Text
                _selfBehavioural.AppraisalHalf = CInt(Me.txtAppraisalHalf.Text)
                _selfBehavioural.Key = ""
                _selfBehavioural.Timing = Me.ddIKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text

                _res = nav_window.createKPIInternal(_selfBehavioural)
                Span2.InnerText = _res
                getKPIList(Me.txtAppraisalNo.Text, "IP")

                clearEntryIKPI()

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try

    End Sub



    Private Sub gridLKPI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridLKPI.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        Try

            selectedRowIndex = Me.gridLKPI.SelectedRow.RowIndex

            Dim row As GridViewRow = gridLKPI.Rows(selectedRowIndex)

            Me.txtLKPItargetObjective.Text = row.Cells(1).Text.ToString()
            Me.txtLKPIDescription.Text = row.Cells(2).Text.ToString()
            Me.ddLKPITiming.Text = row.Cells(3).Text.ToString()
            Me.ddLKPIRating.Text = row.Cells(4).Text.ToString()
            Me.txtLKPIWeight.Text = row.Cells(5).Text.ToString()
            Me.txtLKPIScore.Text = row.Cells(6).Text.ToString()
            Me.txtLKPISupervisorScore.Text = row.Cells(7).Text.ToString()

            ViewState("selectedRowIndexLKPI") = selectedRowIndex

        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub

    Private Sub btnLKPIAdd_Click(sender As Object, e As EventArgs) Handles btnLKPIAdd.Click

        Dim _selfBehavioural As New NAV_HR_WINDOW.Behavoural
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtLKPI As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            If Not IsNothing(ViewState("LKPICollection")) = True And Not IsNothing(ViewState("selectedRowIndexLKPI")) = True Then

                LKPICollection = ViewState("LKPICollection")
                selectedRowIndex = CInt(ViewState("selectedRowIndexLKPI"))

                _selfBehavioural.Key = LKPICollection.Item(selectedRowIndex)
                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtLKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtLKPIDescription.Text
                _selfBehavioural.Weight = Me.txtLKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddLKPIRating.Text
                _selfBehavioural.Score = Me.txtLKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtLKPISupervisorScore.Text
                _selfBehavioural.Timing = ddLKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                _res = nav_window.createKPILearning(_selfBehavioural)
                Span2.InnerText = _res

                getKPIList((Me.txtAppraisalNo.Text), "LG")

                clearEntryLKPI()
                ViewState("selectedRowIndexLKPI") = Nothing

            Else

                _selfBehavioural.Appraisal_No = Me.txtAppraisalNo.Text
                _selfBehavioural.TargetObjective = Me.txtLKPItargetObjective.Text
                _selfBehavioural.Description = Me.txtLKPIDescription.Text
                _selfBehavioural.Weight = Me.txtLKPIWeight.Text
                _selfBehavioural.Ratings = Me.ddLKPIRating.Text
                _selfBehavioural.Score = Me.txtLKPIScore.Text
                _selfBehavioural.Supervisor_Score = Me.txtLKPISupervisorScore.Text

                _selfBehavioural.AppraisalPeriod = Me.txtAppraisalPeriod.Text
                _selfBehavioural.AppraisalHalf = CInt(Me.txtAppraisalHalf.Text)
                _selfBehavioural.Key = ""
                _selfBehavioural.Timing = Me.ddLKPITiming.Text
                _selfBehavioural.Employee_No = Me.txtEmployeeNo.Text
                _res = nav_window.createKPILearning(_selfBehavioural)
                Span2.InnerText = _res
                getKPIList(Me.txtAppraisalNo.Text, "LG")

                clearEntryLKPI()

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try


    End Sub

    Private Sub gridCareerDev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridCareerDev.SelectedIndexChanged

        Dim selectedRowIndex As Integer
        Try

            selectedRowIndex = Me.gridCareerDev.SelectedRow.RowIndex

            Dim row As GridViewRow = gridCareerDev.Rows(selectedRowIndex)
            Dim _question As String = row.Cells(1).Text.ToString()
            Me.txtCDQuestion.Text = _question.Replace("&#39;", "'")
            Me.txtCDAnswer.Text = row.Cells(2).Text.ToString()

            If Me.txtCDAnswer.Text = "&nbsp;" Then
                Me.txtCDAnswer.Text = ""
            Else
            End If

            ViewState("selectedRowIndexCD") = selectedRowIndex

        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try


    End Sub

    Private Sub btnCDAdd_Click(sender As Object, e As EventArgs) Handles btnCDAdd.Click

        Dim _careerdev As New NAV_HR_WINDOW.CareerDevelopmentQuestion
        Dim nav_window As New NAV_HR_WINDOW.Core, _res As String
        Dim dtCareerDevQues As New DataTable, row As DataRow
        Dim selectedRowIndex As Integer

        Try

            'ViewState("CareerQuesCollection") = CareerQuesCollection

            If Not IsNothing(ViewState("CareerQuesCollection")) = True And Not IsNothing(ViewState("selectedRowIndexCD")) = True Then

                CareerQuesCollection = ViewState("CareerQuesCollection")
                selectedRowIndex = CInt(ViewState("selectedRowIndexCD"))

                _careerdev.Key = CareerQuesCollection.Item(selectedRowIndex)
                _careerdev.AppraisalNo = Me.txtAppraisalNo.Text
                _careerdev.Question = Me.txtCDQuestion.Text
                _careerdev.Answer = Me.txtCDAnswer.Text

                _res = nav_window.UpdateCareerDevelopments(_careerdev)
                Span2.InnerText = _res

                dtCareerDevQues = getdtCareerDevelopmentList(nav_window.GetCareerDevelopments(txtAppraisalNo.Text))
                Me.populateCareerDevelopmentQuestions(dtCareerDevQues)

                Me.txtCDQuestion.Text = ""
                Me.txtCDAnswer.Text = ""

                ViewState("selectedRowIndexCD") = Nothing

            Else

            End If

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try

    End Sub

    Private Sub btnComment_Click(sender As Object, e As EventArgs) Handles btnComment.Click
        Dim nav_window As New NAV_HR_WINDOW.Core, appraisalRequest As New NAV_HR_WINDOW.AppraisalRequest, res As String, rc As String
        Try

            spCommentError.InnerText = ""
            If Not IsNothing(ViewState("RCCollection")) = True Then

                RCCollection = ViewState("RCCollection")
                rc = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))

                If Not IsNothing(ViewState("AppraisalKey")) = True And ddRC.Text <> "" Then

                    appraisalRequest.Appraisal_No = Me.txtAppraisalNo.Text
                    appraisalRequest.EmployeeComment = Me.txtEmployeeComment.Text
                    appraisalRequest.SupervisorComment = Me.txtSupervisorComment.Text
                    appraisalRequest.HODComment = Me.txtHODComment.Text
                    appraisalRequest.MDComment = Me.txtMDComment.Text
                    appraisalRequest.Key = CStr(ViewState("AppraisalKey"))
                    appraisalRequest.Responsibility_Center = rc

                    res = nav_window.updateAppraisalComment(appraisalRequest)
                    If (res = "Updated Successfully") = True Then
                        txtEmployeeComment.Enabled = False
                        spCommentError.InnerText = ""
                    Else
                        txtEmployeeComment.Enabled = True
                        Span2.InnerText = res
                    End If


                Else
                    spCommentError.InnerText = "Select Responsibility Center"
                End If



            Else

                Response.Redirect("login.aspx")

            End If




        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnAppraisalScore_Click(sender As Object, e As EventArgs) Handles btnAppraisalScore.Click
        Dim nav_window As New NAV_HR_WINDOW.Core
        Dim appraisalScore As New NAV_HR_WINDOW.ScoreCard

        Me.txtScoreAppraisalNo.Text = Me.txtAppraisalNo.Text
        Me.txtScoreEmployeeNo.Text = Me.txtEmployeeNo.Text
        Me.txtScorePeriod.Text = Me.txtAppraisalPeriod.Text
        appraisalScore = nav_window.getAppraisalScore(Me.txtAppraisalNo.Text, Me.txtAppraisalPeriod.Text)

        Me.txtScoreTotalFirst.Text = appraisalScore.TotalFirst
        Me.txtScoreTotalFirstR.Text = appraisalScore.TotalSecond

        Me.txtScoreFA.Text = appraisalScore.Functional_Ass_First_Half
        Me.txtScoreFAR.Text = appraisalScore.Functional_Ass_Second_Half

        Me.txtScoreBA.Text = appraisalScore.Behavioural_First_Half_Score
        Me.txtScoreBAR.Text = appraisalScore.Behavioural_Second_Half_Score

        Me.txtScoreBA40.Text = appraisalScore.BehavFirst
        Me.txtScoreBA40R.Text = appraisalScore.BehavSecond

        Me.txtScoreFIN.Text = appraisalScore.Financial_First_Half
        Me.txtScoreFINR.Text = appraisalScore.Financial_Second_Half

        Me.txtScoreOC.Text = appraisalScore.Org_Capability_First_Half
        Me.txtScoreOCR.Text = appraisalScore.Org_Capability_Second_Half

        Me.txtScoreMC.Text = appraisalScore.Mgt_Competencies_First_Half
        Me.txtScoreMCR.Text = appraisalScore.Mgt_Competencies_Second_Half

        Me.txtScoreCUS.Text = appraisalScore.Customer_First_Half
        Me.txtScoreCUSR.Text = appraisalScore.Customer_Second_Half

        Me.txtScoreIP.Text = appraisalScore.Internal_Process_First_Half
        Me.txtScoreIPR.Text = appraisalScore.Internal_Process_Second_Half

        Me.txtScoreLG.Text = appraisalScore.Learning_Growth_First_Half
        Me.txtScoreLGR.Text = appraisalScore.Learning_Growth_Second_Half

        Me.txtScoreAS.Text = appraisalScore.KPI_First_Half_Aggregate
        Me.txtScoreASR.Text = appraisalScore.KPI_Second_Half_Aggregate

        Me.txtScoreKPI60.Text = appraisalScore.KPIFirst
        Me.txtScoreKPI60R.Text = appraisalScore.KPISecond

        'Me.txtScoreK.Text = appraisalScore.KPI_First_Half_Aggregate
        'Me.txtScoreKPI60R.Text = appraisalScore.KPI_Second_Half_Aggregate


        mpAppScore.Show()
    End Sub


End Class

