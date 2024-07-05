Imports NAV_HR_WINDOW
Imports System.Data

Partial Class frmStaffClaim
    Inherits System.Web.UI.Page
	Dim LinesKeys As New List(Of String)
	Dim RCCollection As New Hashtable
	Protected Sub LoadGridPVLine(dt As DataTable)

		ViewState("PVLines") = dt
		Me.gridClaimLine.DataSource = dt
		gridClaimLine.DataBind()

	End Sub
	Protected Sub frmStaffClaim_Load(sender As Object, e As EventArgs) Handles Me.Load


		Dim dtusers As New DataTable


		Dim claimNo As String
		Dim NAV_Window As New NAV_HR_WINDOW.Core

		Try


			If IsPostBack = False And Not Context.Request.QueryString("DocumentNo") Is Nothing Then


				claimNo = Context.Request.QueryString("DocumentNo") 'ApplicationTypeID
				ViewState("ClaimNumber") = claimNo
				spCaption.InnerText = spCaption.InnerText & " Document Code : " & Context.Request.QueryString("DocumentNo") & " IN EDIT MODE"

				Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeLeave, dtHRSetup As New DataTable



				'testing if cache is empty
				If IsNothing(Session("dtEmployeeCard")) = True Then

					Response.Redirect("Login.aspx")

				Else
					'populating the status control
					populateStatus()
					'retrieving employee detail from session object
					dtEmployeeCard = Session("dtEmployeeCard")
					Dim staffClaim As New NAV_HR_WINDOW.StaffClaim
					staffClaim = NAV_Window.getStaffClaim(claimNo)
					ViewState("AccountNumber") = staffClaim.AccountNo
					Me.txtDocumentNo.Text = staffClaim.DocumentNo
					Me.txtCashier.Text = staffClaim.Cashier
					Me.txtPaye.Text = staffClaim.Paye
					Me.txtNetTotal.Text = staffClaim.TotalNetAmount
					Me.txtApplicationDate.Text = staffClaim.ClaimDate
					Me.txtPurpose.Text = staffClaim.Purpose
					Me.txtfunctionName.Text = staffClaim.FunctionName
					Me.txtBudgetCenter.Text = staffClaim.BudgetCenterName
					Me.txtBusinessUnit.Text = staffClaim.BusinessUnit
					Me.ddStatus.Text = staffClaim.Status

					getNAVRC(staffClaim.Responsibility_Center)

					Dim dt As New DataTable, i As Integer
					dt.Columns.Add(New DataColumn("txtClaimLineNumber", GetType(String)))
					dt.Columns.Add(New DataColumn("txtAmount", GetType(Decimal)))
					dt.Columns.Add(New DataColumn("txtLinePurpose", GetType(String)))
					dt.Columns.Add(New DataColumn("txtRecieptNo", GetType(String)))
					dt.Columns.Add(New DataColumn("txtNarration", GetType(String)))
					dt.Columns.Add(New DataColumn("txtAdvanceType", GetType(String)))
					dt.Columns.Add(New DataColumn("txtAccountType", GetType(String)))
					dt.Columns.Add(New DataColumn("txtAccountNumber", GetType(String)))
					dt.Columns.Add(New DataColumn("txtAccountName", GetType(String)))
					dt.Columns.Add(New DataColumn("txtDateSpent", GetType(Date)))
					dt.Columns.Add(New DataColumn("txtKey", GetType(String)))


					Do While i < staffClaim.PVLines.Length

						dt.Rows.Add(staffClaim.PVLines(i).No, staffClaim.PVLines(i).Amount, staffClaim.PVLines(i).Purpose, staffClaim.PVLines(i).Claim_Receipt_No, staffClaim.PVLines(i).Claim_Narration, staffClaim.PVLines(i).Advance_Type, staffClaim.PVLines(i).Account_type, staffClaim.PVLines(i).Account_No, staffClaim.PVLines(i).Account_Name, staffClaim.PVLines(i).Expenditure_Date, staffClaim.PVLines(i).Key)

						LinesKeys.Add(staffClaim.PVLines(i).Key)

						i += 1
					Loop

					ViewState("LinesKey") = LinesKeys

					LoadGridPVLine(dt)

				End If

			ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then

				getNAVRC("")
				populateLineType()
				populateStatus()
				Me.txtApplicationDate.Text = Now.Date

				'Session("user") = "test"
				'Dim dt As New DataTable, i As Integer
				'dt.Columns.Add(New DataColumn("txtClaimLineNumber", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtAmount", GetType(Decimal)))
				'dt.Columns.Add(New DataColumn("txtLinePurpose", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtRecieptNo", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtNarration", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtAdvanceType", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtAccountType", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtAccountNumber", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtAccountName", GetType(String)))
				'dt.Columns.Add(New DataColumn("txtDateSpent", GetType(Date)))


				'dt.Rows.Add(1, 3000, "Test", "20980", "Purchase of card", "Side1", "GL", "0000", "petty", Now.Date)
				'Me.gridClaimLine.DataSource = dt
				'gridClaimLine.DataBind()





				If IsNothing(Session("user")) = True Then

					Response.Redirect("Login.aspx")

				Else
				End If
			Else


			End If


		Catch ex As Exception

			'MsgBox("" & ex.Message)

		End Try

	End Sub

	Protected Sub populateLineType()
		Dim dtAdvanceTypes As New DataTable, i As Integer

		' Session("AdvanceType") = dtAdvanceTypes

		dtAdvanceTypes = Session("AdvanceType")

		Do While i < dtAdvanceTypes.Rows.Count

			If Me.ddAdvanceType.Items.Count = 0 Then

				ddAdvanceType.Items.Add("")
				ddAdvanceType.Items.Add(dtAdvanceTypes.Rows(i).Item("AdvanceType"))

			Else

				ddAdvanceType.Items.Add(dtAdvanceTypes.Rows(i).Item("AdvanceType"))

			End If

			i = i + 1

		Loop

	End Sub

	'retrieving responsibilty center and populating the control on the page
	Protected Sub getNAVRC(rc As String)

		Dim dtRC As New DataTable
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

	Protected Sub populateStatus()

		ddStatus.Items.Clear()
		Me.ddStatus.Items.Add("")
		Me.ddStatus.Items.Add("Approved")
		Me.ddStatus.Items.Add("Cancelled")
		Me.ddStatus.Items.Add("Checking")
		Me.ddStatus.Items.Add("Cheque_Printing")
		Me.ddStatus.Items.Add("Pending")
		'Pending

		Me.ddStatus.Items.Add("Pending_Approval")
		Me.ddStatus.Items.Add("Posted")

	End Sub
	Protected Sub gridClaimLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridClaimLine.SelectedIndexChanged


		Dim selectedRowIndex As Integer, dtClaimTypes As New DataTable, i As Integer
		selectedRowIndex = Me.gridClaimLine.SelectedRow.RowIndex
		ViewState("selectedRowIndex") = selectedRowIndex

		Dim row As GridViewRow = gridClaimLine.Rows(selectedRowIndex)

		dtClaimTypes = Session("ClaimType")

		Do While i < dtClaimTypes.Rows.Count

			If Me.ddAdvanceType.Items.Count = 0 Then

				ddAdvanceType.Items.Add("")
				ddAdvanceType.Items.Add(dtClaimTypes.Rows(i).Item("AdvanceType"))

			Else

				ddAdvanceType.Items.Add(dtClaimTypes.Rows(i).Item("AdvanceType"))

			End If

			i = i + 1
		Loop

		Me.txtClaimLineNumber.Text = row.Cells(1).Text.ToString()
		Me.txtAmount.Text = row.Cells(2).Text.ToString()
		Me.txtLinePurpose.Text = row.Cells(3).Text.ToString()
		Me.txtRecieptNo.Text = row.Cells(4).Text.ToString()
		Me.txtNarration.Text = row.Cells(5).Text.ToString()
		Me.ddAdvanceType.Text = row.Cells(6).Text.ToString()
		Me.txtAccountType.Text = row.Cells(7).Text.ToString()
		Me.txtAccountNumber.Text = row.Cells(8).Text.ToString()
		Me.txtAccountName.Text = row.Cells(9).Text.ToString()
		Me.txtDateSpent.Text = row.Cells(10).Text.ToString()

	End Sub

	Protected Sub datagrid_PageIndexChanging()

    End Sub

	Protected Sub gridClaimLine_RowDataBound()

	End Sub

	Protected Sub txtClaimLineNumber_TextChanged(sender As Object, e As EventArgs) Handles txtClaimLineNumber.TextChanged

	End Sub

	Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

		Dim NAV_window As New NAV_HR_WINDOW.Core
		Dim lineCount As Integer = 0

		Dim Claimlines_() As StaffClaim_Service.Staff_Claim_Lines
		ReDim Claimlines_(Me.gridClaimLine.Rows.Count - 1)

		If IsNothing(ViewState("LinesKey")) = False Then
			LinesKeys = ViewState("LinesKey")
		Else
		End If

		Do While lineCount < Me.gridClaimLine.Rows.Count

			Dim Claimline As StaffClaim_Service.Staff_Claim_Lines = New StaffClaim_Service.Staff_Claim_Lines With {
			.No = gridClaimLine.Rows(lineCount).Cells(1).Text,
			.Amount = gridClaimLine.Rows(lineCount).Cells(2).Text,
			.Purpose = gridClaimLine.Rows(lineCount).Cells(3).Text,
			.Claim_Receipt_No = gridClaimLine.Rows(lineCount).Cells(4).Text,
			.Claim_Narration = gridClaimLine.Rows(lineCount).Cells(5).Text,
			.Advance_Type = gridClaimLine.Rows(lineCount).Cells(6).Text,
			.Account_type = 0,
			.Account_No = gridClaimLine.Rows(lineCount).Cells(8).Text,
			.Account_Name = gridClaimLine.Rows(lineCount).Cells(9).Text,
			.Expenditure_Date = gridClaimLine.Rows(lineCount).Cells(10).Text
			}


			If gridClaimLine.Rows(lineCount).Cells(11).Text = "&nbsp;" Then

				Claimlines_(lineCount) = Claimline

			Else

				If LinesKeys.Contains(gridClaimLine.Rows(lineCount).Cells(11).Text) = True Then

					NAV_window.DeleteStaffClaimLine(gridClaimLine.Rows(lineCount).Cells(11).Text)
					Claimlines_(lineCount) = Claimline
					LinesKeys.RemoveAt(LinesKeys.IndexOf(gridClaimLine.Rows(lineCount).Cells(11).Text))


				End If
			End If

			lineCount += 1

		Loop

		Dim i As Integer = 0

		Do While i < LinesKeys.Count
			'deleting sraff claim lines removed by the user
			NAV_window.DeleteStaffClaimLine(LinesKeys.Item(i))
			i += 1
		Loop



		Dim _staffClaim As StaffClaim = New StaffClaim With {
		.DocumentNo = Me.txtDocumentNo.Text,
		.Cashier = Me.txtCashier.Text,
		.BudgetCenterName = Me.txtBudgetCenter.Text,
		.FunctionName = Me.txtfunctionName.Text,
		.Paye = Me.txtPaye.Text,
		.Purpose = Me.txtPurpose.Text,
		.ClaimDate = Me.txtApplicationDate.Text,
		.TotalNetAmount = "8000",
		.Status = Me.ddStatus.Text,
		.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text)),
		.AccountNo = CStr(ViewState("AccountNumber")),
		.BusinessUnit = CStr(Me.txtBusinessUnit.Text),
		.PVLines = Claimlines_
		 }


		'Dim NAV_window As New NAV_HR_WINDOW.Core

		If Me.txtDocumentNo.Text <> "" Then

			Dim _status As String = NAV_window.UpdateStaffClaim(_staffClaim)
			Dim dtClaim As New DataTable
			dtClaim = NAV_window.getStaffClaimList("LP/06/0027")
			Session("Claim") = dtClaim

		Else

			Dim _status As String = NAV_window.CreateStaffClaim(_staffClaim)
			Dim dtClaim As New DataTable
			dtClaim = NAV_window.getStaffClaimList("LP/06/0027")
			Session("Claim") = dtClaim


		End If



	End Sub

	Private Sub ddAdvanceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddAdvanceType.SelectedIndexChanged

		Try
			Dim result As DataRow(), dtClaimTypes As New DataTable
			dtClaimTypes = Session("ClaimType")
			result = dtClaimTypes.Select("AdvanceType = '" & ddAdvanceType.Text & "'")
			Me.txtAccountType.Text = result(0).Item("AccountType").ToString
			Me.txtAccountNumber.Text = result(0).Item("AccountNo").ToString
			Me.txtAccountName.Text = result(0).Item("AccountName").ToString
		Catch ex As Exception
			clearLine()
		End Try



	End Sub

	Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

		Dim _DataRow As DataRow, dtPVLines As New DataTable

		If Me.txtClaimLineNumber.Text = "" Then

			dtPVLines.Columns.Add(New DataColumn("txtClaimLineNumber", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtAmount", GetType(Decimal)))
			dtPVLines.Columns.Add(New DataColumn("txtLinePurpose", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtRecieptNo", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtNarration", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtAdvanceType", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtAccountType", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtAccountNumber", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtAccountName", GetType(String)))
			dtPVLines.Columns.Add(New DataColumn("txtDateSpent", GetType(DateTime)))
			dtPVLines.Columns.Add(New DataColumn("txtKey", GetType(String)))

			_DataRow = dtPVLines.NewRow
			_DataRow("txtClaimLineNumber") = Me.txtClaimLineNumber.Text
			_DataRow("txtAmount") = Me.txtAmount.Text
			_DataRow("txtLinePurpose") = Me.txtLinePurpose.Text
			_DataRow("txtRecieptNo") = Me.txtRecieptNo.Text
			_DataRow("txtNarration") = Me.txtNarration.Text
			_DataRow("txtAdvanceType") = Me.ddAdvanceType.Text
			_DataRow("txtAccountType") = Me.txtAccountType.Text
			_DataRow("txtAccountNumber") = Me.txtAccountNumber.Text
			_DataRow("txtAccountName") = Me.txtAccountName.Text
			_DataRow("txtDateSpent") = Me.txtDateSpent.Text
			_DataRow("txtKey") = ""

			dtPVLines.Rows.Add(_DataRow)

			LoadGridPVLine(dtPVLines)
			clearLine()

		Else

			Dim selectedRowIndex As Integer
			If IsNothing(ViewState("selectedRowIndex")) = False Then
				selectedRowIndex = ViewState("selectedRowIndex")
			Else
			End If

			dtPVLines = ViewState("PVLines")
			'dtPVLines.Rows(selectedRowIndex).Delete()
			_DataRow = dtPVLines.Rows(selectedRowIndex)
			_DataRow("txtAmount") = Me.txtAmount.Text
			_DataRow("txtLinePurpose") = Me.txtLinePurpose.Text
			_DataRow("txtRecieptNo") = Me.txtRecieptNo.Text
			_DataRow("txtNarration") = Me.txtNarration.Text
			_DataRow("txtAdvanceType") = Me.ddAdvanceType.Text
			_DataRow("txtAccountType") = Me.txtAccountType.Text
			_DataRow("txtAccountNumber") = Me.txtAccountNumber.Text
			_DataRow("txtAccountName") = Me.txtAccountName.Text
			_DataRow("txtDateSpent") = Me.txtDateSpent.Text

			LoadGridPVLine(dtPVLines)
			clearLine()
		End If


	End Sub
	Protected Sub clearLine()

		Me.txtClaimLineNumber.Text = ""
		txtAmount.Text = ""
		txtLinePurpose.Text = ""
		txtRecieptNo.Text = ""
		txtNarration.Text = ""
		ddAdvanceType.Text = ""
		txtAccountType.Text = ""
		txtAccountNumber.Text = ""
		txtAccountName.Text = ""
		txtDateSpent.Text = ""



	End Sub

	Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

		If Me.txtClaimLineNumber.Text = "" Then

		Else

			Dim selectedRowIndex As Integer, dtPVLines As New DataTable
			If IsNothing(ViewState("selectedRowIndex")) = False Then
				selectedRowIndex = ViewState("selectedRowIndex")
			Else
			End If

			dtPVLines = ViewState("PVLines")
			dtPVLines.Rows(selectedRowIndex).Delete()
			LoadGridPVLine(dtPVLines)
			clearLine()
		End If



	End Sub

	Protected Sub calApplicationDate_SelectionChanged(sender As Object, e As EventArgs) Handles calApplicationDate.SelectionChanged

		calApplicationDate_PopupControlExtender.Commit(Me.calApplicationDate.SelectedDate)

	End Sub

	Private Sub CalDateSpent_SelectionChanged(sender As Object, e As EventArgs) Handles CalDateSpent.SelectionChanged


		Me.CalDateSpent_PopupControlExtender.Commit(Me.CalDateSpent.SelectedDate)


	End Sub
End Class
