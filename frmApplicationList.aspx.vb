Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports AjaxControlToolkit
Partial Class frmApplicationList
     Inherits System.Web.UI.Page
     Dim ApprovalTypeCollection As New Hashtable

	Private Property dt As Object

	Protected Sub BtnViewInvestigationDetails_Click(sender As Object, e As EventArgs)

		Dim btnViewApplicationLog As New ImageButton, appCode As String
		btnViewApplicationLog = sender
		Dim i As GridViewRow
		i = btnViewApplicationLog.NamingContainer
		appCode = Me.gridProcessing.Rows(i.RowIndex).Cells(2).Text

		Dim typeID As Integer
		ApprovalTypeCollection = ViewState("ApprovalTypeCollection")
		'typeID = (CInt(ApprovalTypeCollection.Item(Me.gridProcessing.Rows(i.RowIndex).Cells(4).Text)))
		'typeID = (CInt(ApprovalTypeCollection.Item(Me.ddApprovalType.SelectedItem.Text)))

		If typeID = 5 Then
			Response.Redirect(String.Format("frmDBAInvestigation.aspx?ApplicationCode={0}&ApplicationTypeID={1}", Server.UrlEncode(appCode), Server.UrlEncode(typeID)))
		Else

		End If



		'  Response.Redirect(String.Format("frmApplicationConfirmation.aspx?ApplicationCode={0}&ReturnPage={1}", Server.UrlEncode(appDetail.ApplicationID), Server.UrlEncode("ApplicationDashBoard")))

	End Sub

	Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

          Dim btnViewApplicationLog As New ImageButton, appCode As String
          btnViewApplicationLog = sender
          Dim i As GridViewRow
          i = btnViewApplicationLog.NamingContainer
		appCode = Me.gridProcessing.Rows(i.RowIndex).Cells(2).Text
		Response.Redirect(String.Format("frmEditApplication.aspx?ApplicationCode={0}", Server.UrlEncode(appCode)))





	End Sub

	Protected Sub gridApprovalEntries_RowDataBound()

	End Sub
	Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs) Handles btnShowPopupApprovalEntries.Click

		Try

			Dim nav_win As New NAV_HR_WINDOW.Core, dtApprovalEntries As DataTable

			Dim btnViewApplicationLog As New ImageButton, appCode As String
			btnViewApplicationLog = sender
			Dim gridRow As GridViewRow
			gridRow = btnViewApplicationLog.NamingContainer
			appCode = Me.gridProcessing.Rows(gridRow.RowIndex).Cells(2).Text

			dtApprovalEntries = nav_win.getApprovalEntries(appCode)
			Me.gridApprovalEntries.DataSource = dtApprovalEntries
			gridApprovalEntries.DataBind()

			Me.mpApprovalEntries.Show()

		Catch ex As Exception

			Response.Redirect("Login.aspx")

		End Try




	End Sub



	Protected Sub getMyLeaveApplication()
		'NAV_HR_WINDOW.Core
		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeReLeavers, dtPostedEmployeeLeaves As New DataTable, result As DataRow()


		Try

			If IsNothing(Session("dtEmployeeLeaves")) = True Then
				Response.Redirect("Login.aspx")
			Else
				dtEmployeeLeaves = Session("dtEmployeeLeaves")
			End If


			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			''''''''''''''''''''''''''''''''''''''''''''''''''''''Retrieving RC''''''''''''''''''''''''''''''''''''''''''''''''''''''


			Dim RCCollection As New Hashtable
			If IsNothing(Session("RC")) = True Then

				Response.Redirect("Login.aspx")
			Else
				RCCollection = Session("RC")
			End If



			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			''''''''''''''''''''''''''''''''''''''''''''''Retrieving LeaveTypes''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			Dim dtLeaveTypes As New DataTable
			If IsNothing(Session("LeaveTypes")) = True Then

				Response.Redirect("Login.aspx")
			Else
				dtLeaveTypes = Session("LeaveTypes")
			End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			''''''''''''Retrieving Releavers''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			Dim dtReLeavers As New DataTable
			If IsNothing(Session("ReLeavers")) = True Then

				Response.Redirect("Login.aspx")
			Else
				dtReLeavers = Session("ReLeavers")
			End If
			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			loadGrid(dtEmployeeLeaves)


		Catch ex As Exception

			Response.Redirect("Login.aspx")

		End Try

	End Sub
	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

		Dim scriptManagerA As New ScriptManager, dtusers As New DataTable
		'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		'scriptManagerA.RegisterPostBackControl(Me.gridSubmittedDocuments)
		
		scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		scriptManagerA.RegisterPostBackControl(Me.gridProcessing)

          Try

			If IsPostBack = False Then

				'((Label)Master.FindControl("lblHeading")).Text = "your new text";
				'Dim a = DirectCast(Master.FindControl("lblWelComePerson"), Label)

				If IsNothing(Session("user")) = True Then

					Response.Redirect("login.aspx")

				ElseIf IsNothing(Session("user")) = False Then

					getMyLeaveApplication()

				Else
					getMyLeaveApplication()

				End If

			Else
				'getMyLeaveApplication()
			End If
			
		Catch ex As Exception

			Response.Redirect("Login.aspx")

		End Try

     End Sub


	Protected Sub gridLeaveApplication_RowDataBound(sender As Object, e As GridViewRowEventArgs)

		'If IsNothing(ViewState("ApplicationList")) = False Then

		'	Dim dt As DataTable = ViewState("ApplicationList")
		'	If e.Row.RowType = DataControlRowType.DataRow Then
		'		If dt.Rows(e.Row.RowIndex).Item("txtLockedBy").ToString <> "" And (dt.Rows(e.Row.RowIndex).Item("txtLockedBy").ToString = Session("user").ToString) = False Then
		'			e.Row.ForeColor = System.Drawing.Color.Blue
		'			e.Row.Enabled = False
		'			'isVerified
		'		Else

		'		End If

		'	End If

		'Else
		'End If

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

			Response.Redirect("Login.aspx")

		End Try
     End Sub


	Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

		Dim i As Integer, isPendingAppAvailable As Boolean = False

		Do While i < Me.gridProcessing.Rows.Count

			If gridProcessing.Rows(0).Cells(9).Text = "New" Or gridProcessing.Rows(0).Cells(9).Text = "Pending_Approval" Then
				'isPendingAppAvailable = True

				i = Me.gridProcessing.Rows.Count

			End If
			i = i + 1
		Loop

		If isPendingAppAvailable = True Then

		Else

			Response.Redirect("frmApplication.aspx")

		End If

		'Response.Redirect("frmApplication.aspx")
	End Sub

	Protected Sub gridProcessing_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridProcessing.PageIndexChanging


		Dim dtEmployeeLeaves As New DataTable

		dtEmployeeLeaves = Session("dtEmployeeLeaves")

		If IsNothing(dtEmployeeLeaves) = False Then

			Me.gridProcessing.PageIndex = e.NewPageIndex
			Me.loadGrid(dtEmployeeLeaves)

		Else

		End If

     End Sub


	Protected Sub gridProcessing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridProcessing.SelectedIndexChanged

		Dim selectedRowIndex As Integer
		selectedRowIndex = Me.gridProcessing.SelectedRow.RowIndex
		Dim row As GridViewRow = gridProcessing.Rows(selectedRowIndex)

		ViewState("ApplicationCode") = row.Cells(1).Text.ToString
		ViewState("EmployeeNumber") = row.Cells(2).Text.ToString



		

	End Sub

	Protected Sub gridApplicationSummary_RowDataBound()

	End Sub
	Protected Sub AddViewComment_Click()

	End Sub

	Protected Sub btnSendApprovalRequest_Click(sender As Object, e As EventArgs) Handles btnSendApprovalRequest.Click

		Dim NAV_Window As New NAV_HR_WINDOW.Core, result As String

		Dim cb As CheckBox, chk As Integer = 0

		Try

			If IsNothing(Session("user")) = True Then
				Response.Redirect("Login.aspx")
			Else
			End If

			For Each grow As GridViewRow In Me.gridProcessing.Rows

				Dim dt As New DataTable
				cb = grow.FindControl("chkProcessing")

				If cb.Checked = True Then

					If grow.Cells(10).Text = "New" Then

						result = NAV_Window.SendLeaveApproval(grow.Cells(2).Text)

					Else

					End If

				ElseIf cb.Checked = False Then

				End If

			Next

			Dim dtEmployeeLeaves As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
			dtEmployeeLeaves = NAV_Window.getLeaveApplicationList(dtEmployeeCard.Rows(0)("No").ToString)
			Session("dtEmployeeLeaves") = dtEmployeeLeaves
			Response.Redirect("frmApplicationList.aspx")

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)


		End Try







	End Sub

	Protected Sub datagrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

		'Try
		'	Dim dtEmployees As New DataTable
		'	Dim cacheKeyEmployees As String = "NAVEmployees"
		'	Dim cacheItemEmployees As Object = CType(Cache.Get(cacheKeyEmployees), DataTable)

		'	If IsNothing(cacheItemEmployees) = True Then
		'		getEmployeeList()

		'		'dtEmployees = NAV_Window.getEmployeeDetails
		'		'loadEmployeeGrid(dtEmployees)
		'		'cacheItemEmployees = dtEmployees
		'		'Cache.Insert(cacheKeyEmployees, cacheItemEmployees, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
		'	Else
		'		dtEmployees = Cache.Get(cacheKeyEmployees)
		'		Me.gridEmployeeList.PageIndex = e.NewPageIndex
		'		gridEmployeeList.DataBind()

		'	End If

		'Catch ex As Exception

		'End Try

	End Sub

	Private Sub gridProcessing_Load(sender As Object, e As EventArgs) Handles gridProcessing.Load

	End Sub
End Class
