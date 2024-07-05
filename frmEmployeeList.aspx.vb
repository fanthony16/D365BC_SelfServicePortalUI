
Imports System.Data

Partial Class frmEmployeeList
    Inherits System.Web.UI.Page


	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Dim scriptManagerA As New ScriptManager, dtusers As New DataTable
		'scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		'scriptManagerA.RegisterPostBackControl(Me.gridSubmittedDocuments)

		scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		scriptManagerA.RegisterPostBackControl(Me.gridEmployeeList)

		Try

			If IsPostBack = False Then

				'If IsNothing(Session("user")) = True Then

				'	Response.Redirect("login.aspx")

				'ElseIf IsNothing(Session("user")) = False Then

				'	getEmployeeList()

				'Else
				'	getEmployeeList()

				'End If
				getEmployeeList()
			Else

			End If

		Catch ex As Exception

		End Try
	End Sub


	Protected Sub gridApprovalEntries_RowDataBound()

	End Sub
	Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

		Dim btnViewApplicationLog As New ImageButton, appCode As String
		btnViewApplicationLog = sender
		Dim i As GridViewRow
		i = btnViewApplicationLog.NamingContainer

		appCode = Me.gridEmployeeList.Rows(i.RowIndex).Cells(1).Text
		Response.Redirect(String.Format("frmEditEmployee.aspx?xytamcvrofqg={0}", Server.UrlEncode(appCode)))


		'MsgBox("I am here")
		'Exit Sub
	End Sub
	Protected Sub gridEmployeeList_RowDataBound(sender As Object, e As GridViewRowEventArgs)

	End Sub

	Protected Sub BtnViewApprovalEntries_Click(sender As Object, e As EventArgs) Handles btnShowPopupApprovalEntries.Click

	End Sub
	Protected Sub getEmployeeList()

		Dim NAV_Window As New NAV_HR_WINDOW.Core


		Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtPostedEmployeeLeaves As New DataTable, result As DataRow()


		Try

			Dim cacheKeyEmployees As String = "NAVEmployees"
			Dim cacheItemEmployees As Object = CType(Cache.Get(cacheKeyEmployees), DataTable)



			'retrieving the list of employees  from the cache object
			If IsNothing(cacheItemEmployees) = True Then

				Response.Redirect("Login.aspx")
			Else
				dtEmployees = Cache.Get(cacheKeyEmployees)

			End If

			Dim dtEmployee As New DataTable, i As Integer
			dtEmployee.Columns.Add(New DataColumn("No", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("UserID", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("FirstName", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("MiddleName", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("LastName", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("JobTitle", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("ContractType", GetType(String)))
			dtEmployee.Columns.Add(New DataColumn("CompanyEmail", GetType(String)))
			'dtEmployee.Columns.Add(New DataColumn("Status", GetType(String)))

			'filtering the logged on user from the list of employees

			'MsgBox("" & Session("EmployeeNo").ToString)

			result = dtEmployees.Select("No = '" & CStr(Session("EmployeeNo")) & "'")
			dtEmployee.Rows.Add(result(0).Item(0), result(0).Item(1), result(0).Item(2), result(0).Item(3), result(0).Item(4), result(0).Item(5), result(0).Item(6), result(0).Item(7))

			'	Session("Employee") = dtEmployee
			loadEmployeeGrid(dtEmployee)



			'dtEmployeeCard = NAV_Window.getEmployee(CStr(result(0).Item(0)))
			'Session("dtEmployeeCard") = dtEmployeeCard
			'Session("EmployeeNo") = dtEmployeeCard.Rows(0).Item("No")
			'ViewState("EmployeeDepartmentCode") = dtEmployeeCard.Rows(0).Item("DepartmentCode")


			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


			'If IsNothing(Session("dtEmployeeLeaves")) = True Then

			'	dtEmployeeLeaves = NAV_Window.getLeaveApplicationList(CStr(Session("EmployeeNo")))
			'	Session("dtEmployeeLeaves") = dtEmployeeLeaves

			'Else
			'	dtEmployeeLeaves = Session("dtEmployeeLeaves")

			'End If


			'If IsNothing(Session("dtPostedEmployeeLeaves")) = True Then

			'	dtPostedEmployeeLeaves = NAV_Window.getPostedLeaveApplicationList(CStr(Session("EmployeeNo")))
			'	Session("dtPostedEmployeeLeaves") = dtPostedEmployeeLeaves

			'Else
			'	dtPostedEmployeeLeaves = Session("dtPostedEmployeeLeaves")

			'End If
			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




			''''''''''''''''''''''''''''''''''''''''''''''''''''''Retrieving RC''''''''''''''''''''''''''''''''''''''''''''''''''''''
			'Dim dtRC As New DataTable
			'Dim cacheKeyRC As String = "NAVRC"
			'Dim cacheItemRC As Object = CType(Cache.Get(cacheKeyRC), DataTable)

			''testing if cache is empty
			'If IsNothing(cacheItemRC) = True Then
			'	'fetching leave records from NAV
			'	dtRC = NAV_Window.getResponsibiltyCenters
			'	cacheItemRC = dtRC
			'	'putting retrieved records into cache for subsequent read
			'	Cache.Insert(cacheKeyRC, cacheItemRC, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)

			'Else
			'	'retrieving employee leave record from cache
			'	dtRC = Cache.Get(cacheKeyRC)

			'End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			'''''''''''''''Retrieving LeaveTypes''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			'Dim dtLeaveType As New DataTable
			'Dim cacheKeyLeaveType As String = "NAVLeaveType"
			'Dim cacheItemLeaveType As Object = CType(Cache.Get(cacheKeyLeaveType), DataTable)

			''testing if cache is empty
			'If IsNothing(cacheItemLeaveType) = True Then
			'	'fetching leave records from NAV
			'	dtLeaveType = NAV_Window.getLeaveTypes
			'	cacheItemLeaveType = dtLeaveType
			'	'putting retrieved records into cache for subsequent read
			'	Cache.Insert(cacheKeyLeaveType, cacheItemLeaveType, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)

			'Else
			'	'retrieving employee leave record from cache
			'	dtLeaveType = Cache.Get(cacheKeyLeaveType)

			'End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			''''''''''''Retrieving Releavers''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			'Dim dtReLeavers As New DataTable
			'If IsNothing(Session("dtReLeavers")) = True Then

			'	dtReLeavers = NAV_Window.getEmployeeReleaver(ViewState("EmployeeDepartmentCode"))
			'	Session("dtReLeavers") = dtReLeavers

			'Else

			'	dtReLeavers = Session("dtReLeavers")

			'End If

			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			'	loadEmployeeGrid(dtEmployeeLeaves)






		Catch ex As Exception
			MsgBox("" & ex.Message)

		End Try



	End Sub


	Protected Sub loadEmployeeGrid(dt As DataTable)
		Try

			Me.gridEmployeeList.DataSource = dt
			gridEmployeeList.DataBind()

			'If dt.Rows.Count > 5 Then
			pnlGrid.Height = Nothing
			'Else

			'End If

		Catch ex As Exception
			MsgBox("" & ex.Message)
		End Try
	End Sub

	Protected Sub datagrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

		Try
			Dim dtEmployees As New DataTable
			Dim cacheKeyEmployees As String = "NAVEmployees"
			Dim cacheItemEmployees As Object = CType(Cache.Get(cacheKeyEmployees), DataTable)

			If IsNothing(cacheItemEmployees) = True Then
				getEmployeeList()

				'dtEmployees = NAV_Window.getEmployeeDetails
				'loadEmployeeGrid(dtEmployees)
				'cacheItemEmployees = dtEmployees
				'Cache.Insert(cacheKeyEmployees, cacheItemEmployees, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
			Else
				dtEmployees = Cache.Get(cacheKeyEmployees)
				Me.gridEmployeeList.PageIndex = e.NewPageIndex
				gridEmployeeList.DataBind()

			End If

		Catch ex As Exception

		End Try

	End Sub


	Protected Sub gridEmployeeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridEmployeeList.SelectedIndexChanged

	End Sub
End Class
