Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports AjaxControlToolkit
Partial Class frmLeaveAcknowledgmentList
	Inherits System.Web.UI.Page

	Protected Sub gridLeaveApplication_RowDataBound()

	End Sub

	Protected Sub BtnViewDetails_Click()

	End Sub
	Protected Sub gridApprovalEntries_RowDataBound()

	End Sub
	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Dim scriptManagerA As New ScriptManager, dtusers As New DataTable
		scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		scriptManagerA.RegisterPostBackControl(Me.gridProcessing)

		Session("user") = "O-TAIWO"

		Try


			If IsPostBack = False Then

				If IsNothing(Session("user")) = True Then

					Response.Redirect("login.aspx")

				ElseIf IsNothing(Session("user")) = False Then

					getMyLeaveApplication()

				Else
					getMyLeaveApplication()

				End If

			Else
				getMyLeaveApplication()
			End If

		Catch ex As Exception

		End Try

	End Sub

	Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs) Handles btnShowPopupApprovalEntries.Click

		Dim nav_win As New NAV_HR_WINDOW.Core, dtApprovalEntries As DataTable
		Dim btnViewApplicationLog As New ImageButton, appCode As String
		btnViewApplicationLog = sender
		Dim gridRow As GridViewRow
		gridRow = btnViewApplicationLog.NamingContainer
		appCode = Me.gridProcessing.Rows(gridRow.RowIndex).Cells(1).Text

		dtApprovalEntries = nav_win.getLeaveApprovalEntries(appCode)
		Me.gridApprovalEntries.DataSource = dtApprovalEntries
		gridApprovalEntries.DataBind()

		Me.mpApprovalEntries.Show()

	End Sub


	Protected Sub getMyLeaveApplication()
		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Dim user_ID As String = "PENSURE-NIGERIA\" & Session("user")
		Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves As New DataTable, result As DataRow()


		Try

			Dim cacheKeyEmployees As String = "NAVEmployees"
			Dim cacheItemEmployees As Object = CType(Cache.Get(cacheKeyEmployees), DataTable)

			If IsNothing(Session("dtEmployeeCard")) = False Then
				dtEmployeeCard = Session("dtEmployeeCard")
			Else
				Response.Redirect("Login.aspx")
			End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			'Session("EmployeeNo") = dtEmployeeCard.Rows(0).Item("No")

			If IsNothing(Session("dtEmployeeLeaves")) = True Then

				dtEmployeeLeaves = NAV_Window.getLeaveApplicationList(CStr(dtEmployeeCard.Rows(0).Item("No")))
				Session("dtEmployeeLeaves") = dtEmployeeLeaves

			Else
				dtEmployeeLeaves = Session("dtEmployeeLeaves")

			End If

			'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




			''''''''''''''''''''''''''''''''''''''''''''''''''''''Retrieving RC''''''''''''''''''''''''''''''''''''''''''''''''''''''
			Dim dtRC As New DataTable
			Dim cacheKeyRC As String = "NAVRC"
			Dim cacheItemRC As Object = CType(Cache.Get(cacheKeyRC), DataTable)

			'testing if cache is empty
			If IsNothing(cacheItemRC) = True Then
				'fetching leave records from NAV
				dtRC = NAV_Window.getResponsibiltyCenters("")
				cacheItemRC = dtRC
				'putting retrieved records into cache for subsequent read
				Cache.Insert(cacheKeyRC, cacheItemRC, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)

			Else
				'retrieving employee leave record from cache
				dtRC = Cache.Get(cacheKeyRC)

			End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			''''''''''''''''''''''''''''''''Retrieving Employee Leave Acknowledgments''''''''''''''''''''''''

			Dim dtLeaveAck As New DataTable

			'Dim cacheKeyLeaveAck As String = "NAVLeaveAck"
			'Dim cacheItemLeaveAck As Object = CType(Cache.Get(cacheKeyLeaveAck), DataTable)

			''testing if cache is empty
			'If IsNothing(cacheItemLeaveAck) = True Then
			'	'fetching leave acknowledgment records from NAV
			'	dtLeaveAck = NAV_Window.getLeaveAcknowledgmentList(user_ID)
			'	cacheItemLeaveAck = dtLeaveAck
			'	'putting retrieved records into cache for subsequent read
			'	Cache.Insert(cacheKeyLeaveAck, cacheItemLeaveAck, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)

			'Else
			'	'retrieving employee leave record from cache
			'	dtLeaveAck = Cache.Get(cacheKeyLeaveAck)

			'End If



			If IsNothing(Session("dtLeaveAck")) = True Then

				'user_ID = "PENSURE-NIGERIA\CORETEC"

				dtLeaveAck = NAV_Window.getLeaveAcknowledgmentList(user_ID)

				'MsgBox("" & user_ID & "  :  " & dtLeaveAck.Rows.Count)

				Session("dtLeaveAck") = dtLeaveAck

			Else
				dtLeaveAck = Session("dtLeaveAck")

			End If

			'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


			loadGrid(dtLeaveAck)

		Catch ex As Exception
			MsgBox("" & ex.Message)

		End Try

	End Sub


	'loading datagrid on the page
	Protected Sub loadGrid(dt As DataTable)
		Try

			Me.gridProcessing.DataSource = dt
			gridProcessing.DataBind()

			If dt.Rows.Count > 5 Then
				pnlGrid.Height = Nothing
			Else

			End If

		Catch ex As Exception
			MsgBox("" & ex.Message)
		End Try
	End Sub

	Protected Sub btnNew_Click(sender As Object, e As ImageClickEventArgs) Handles btnNew.Click

		Dim i As Integer, isPendingAppAvailable As Boolean = False

		Do While i < Me.gridProcessing.Rows.Count
			If gridProcessing.Rows(0).Cells(4).Text = "New" Or gridProcessing.Rows(0).Cells(4).Text = "Pending_Approval" Then
				isPendingAppAvailable = False
			End If
			i = i + 1
		Loop

		If isPendingAppAvailable = True Then

		Else
			Response.Redirect("frmLeaveAcknowledgment.aspx")
		End If

	End Sub

	Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

		If IsNothing(ViewState("ApplicationCode")) = False And IsNothing(Session("EmployeeNo")) = False Then

			Dim ss As New NAV_HR_WINDOW.Core, result As String

			result = ss.UpdateEmployeeLastAckLeaveNo(CStr(Session("EmployeeNo")), CStr(ViewState("ApplicationCode")))

			Dim cacheKeyEmployeeLeaves As String = "NAVEmployeeLeavce"
			Cache.Remove(cacheKeyEmployeeLeaves)
			Session("dtEmployeeLeaves") = Nothing
			Session("dtLeaveAck") = Nothing
			Response.Redirect("frmLeaveAcknowledgmentList.aspx")

		Else

		End If

	End Sub

	Protected Sub gridProcessing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridProcessing.SelectedIndexChanged


		Dim selectedRowIndex As Integer
		selectedRowIndex = Me.gridProcessing.SelectedRow.RowIndex
		Dim row As GridViewRow = gridProcessing.Rows(selectedRowIndex)

		ViewState("ApplicationCode") = row.Cells(1).Text.ToString



	End Sub
End Class
