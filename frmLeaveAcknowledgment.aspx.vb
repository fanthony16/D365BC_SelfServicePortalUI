Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports AjaxControlToolkit
Imports System.Net
Partial Class frmLeaveAcknowledgment
	Inherits System.Web.UI.Page
	Dim RCCollection As New Hashtable

	Protected Sub getNavData2()

		Dim NAV_Window As New NAV_HR_WINDOW.Core

		Dim dtEmployees As New DataTable, dtEmployeeCard As New DataTable, dtHRSetup As New DataTable, i As Integer, dtLeaveTypes As DataTable, dtReleaver As New DataTable, dtEmployeeLeaves, dtPostedEmployeeLeaves As New DataTable

		Dim result As DataRow()
		'Dim user_ID As String = "PENSURE-NIGERIA\o-taiwo"
		Dim user_ID As String = "PENSURE-NIGERIA\" & Session("user")

		'Reading the responsibility centers
		i = 0
		ddRC.Items.Clear()

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

		'Do While i < dtRC.Rows.Count
		'	If Me.ddRC.Items.Count = 0 Then
		'		If RCCollection.Contains(dtRC.Rows(i).Item("Name")) = False Then
		'			Me.ddRC.Items.Add("")
		'			Me.ddRC.Items.Add(dtRC.Rows(i).Item("Name").ToString)
		'			RCCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))
		'		Else
		'		End If
		'	ElseIf Me.ddRC.Items.Count > 0 Then
		'		If RCCollection.Contains(dtRC.Rows(i).Item("Name")) = False Then
		'			Me.ddRC.Items.Add(dtRC.Rows(i).Item("Name").ToString)
		'			RCCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))
		'		Else
		'		End If
		'	End If
		'	i = i + 1
		'Loop

		ViewState("RCCollection") = RCCollection

		i = 0

		If IsNothing(Session("dtEmployeeCard")) = False Then
			dtEmployeeCard = Session("dtEmployeeCard")
		Else
			Response.Redirect("Login.aspx")

		End If

		If IsNothing(Session("dtPostedEmployeeLeaves")) = False Then
			dtPostedEmployeeLeaves = Session("dtPostedEmployeeLeaves")
		Else
			Response.Redirect("Login.aspx")
		End If



		Dim empDeptCode As String = ""
		If dtEmployeeCard.Rows.Count > 0 Then

			Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No")
			Me.txtEmployeeName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName")
			empDeptCode = dtEmployeeCard.Rows(0).Item("DepartmentCode")

		End If

		i = 0
		Do While i < dtPostedEmployeeLeaves.Rows.Count

			If Me.ddLeaveNo.Items.Count = 0 Then

				Me.ddLeaveNo.Items.Add("")
				Me.ddLeaveNo.Items.Add(dtPostedEmployeeLeaves.Rows(i).Item("ApplicationNo").ToString)


			ElseIf Me.ddLeaveNo.Items.Count > 0 Then

				Me.ddLeaveNo.Items.Add(dtPostedEmployeeLeaves.Rows(i).Item("ApplicationNo").ToString)


			End If

			i = i + 1
		Loop



		i = 0
		ddRC.Items.Clear()

		Select Case empDeptCode

			Case Is = "ADMI"


				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("ADMINISTRATION") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("ADMINISTRATION")
						RCCollection.Add("ADMINISTRATION", "ADMI")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains(dtRC.Rows(i).Item("Name")) = False Then
						Me.ddRC.Items.Add("ADMINISTRATION")
						RCCollection.Add("ADMINISTRATION", "ADMI")
					Else
					End If

				End If



			Case Is = "ASM"


				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("ASSET MANAGENT") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("ASSET MANAGENT")
						RCCollection.Add("ASSET MANAGENT", "ASM")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("ASSET MANAGENT") = False Then
						Me.ddRC.Items.Add("ASSET MANAGENT")
						RCCollection.Add("ASSET MANAGENT", "ASM")
					Else
					End If

				End If



			Case Is = "BDM"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("BUSINESS DEVELOPMENT") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("BUSINESS DEVELOPMENT")
						RCCollection.Add("BUSINESS DEVELOPMENT", "BDM")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("BUSINESS DEVELOPMENT") = False Then
						Me.ddRC.Items.Add("BUSINESS DEVELOPMENT")
						RCCollection.Add("BUSINESS DEVELOPMENT", "BDM")
					Else
					End If

				End If

			Case Is = "BPU"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("BENEFIT PROCESSG UNIT") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("BENEFIT PROCESSG UNIT")
						RCCollection.Add("BENEFIT PROCESSG UNIT", "BPU")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("BENEFIT PROCESSG UNIT") = False Then
						Me.ddRC.Items.Add("BENEFIT PROCESSG UNIT")
						RCCollection.Add("BENEFIT PROCESSG UNIT", "BPU")
					Else
					End If

				End If

			Case Is = "COMP"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("COMPLIANCE") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("COMPLIANCE")
						RCCollection.Add("COMPLIANCE", "COMP")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("COMPLIANCE") = False Then
						Me.ddRC.Items.Add("COMPLIANCE")
						RCCollection.Add("COMPLIANCE", "COMP")
					Else
					End If

				End If

			Case Is = "CRMD"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("SALES") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("SALES")
						RCCollection.Add("SALES", "SLS")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("SALES") = False Then
						Me.ddRC.Items.Add("SALES")
						RCCollection.Add("SALES", "SLS")
					Else
					End If

				End If

			Case Is = "CSD"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("CUSTOMER SERVICE") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("CUSTOMER SERVICE")
						RCCollection.Add("CUSTOMER SERVICE", "CMS")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("CUSTOMER SERVICE") = False Then
						Me.ddRC.Items.Add("CUSTOMER SERVICE")
						RCCollection.Add("CUSTOMER SERVICE", "CMS")
					Else
					End If

				End If

			Case Is = "EXCO"

			Case Is = "FIN"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("FINANCE") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("FINANCE")
						RCCollection.Add("FINANCE", "FIN")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("FINANCE") = False Then
						Me.ddRC.Items.Add("FINANCE")
						RCCollection.Add("FINANCE", "FIN")
					Else
					End If

				End If

			Case Is = "HR"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("HUMAN RESOURCES") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("HUMAN RESOURCES")
						Me.ddRC.Items.Add("HUMAN RESURCES AND ADMINISTRATION")
						RCCollection.Add("HUMAN RESOURCES", "HR")
						RCCollection.Add("HUMAN RESURCES AND ADMINISTRATION", "HRAD")
					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("HUMAN RESOURCES") = False Then
						Me.ddRC.Items.Add("HUMAN RESOURCES")
						Me.ddRC.Items.Add("HUMAN RESURCES AND ADMINISTRATION")
						RCCollection.Add("HUMAN RESOURCES", "HR")
						RCCollection.Add("HUMAN RESURCES AND ADMINISTRATION", "HRAD")
					Else
					End If

				End If

			Case Is = "INFT"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("INFORMATION TECHNOLOGY") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("INFORMATION TECHNOLOGY")
						RCCollection.Add("INFORMATION TECHNOLOGY", "INFT")

					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("INFORMATION TECHNOLOGY") = False Then
						Me.ddRC.Items.Add("INFORMATION TECHNOLOGY")
						RCCollection.Add("INFORMATION TECHNOLOGY", "INFT")

					Else
					End If

				End If


			Case Is = "INT"


				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("INTERNAL CONTROL& RISK MGT") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("INTERNAL CONTROL& RISK MGT")
						RCCollection.Add("INTERNAL CONTROL& RISK MGT", "INT")

					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("INTERNAL CONTROL& RISK MGT") = False Then
						Me.ddRC.Items.Add("INTERNAL CONTROL& RISK MGT")
						RCCollection.Add("INTERNAL CONTROL& RISK MGT", "INT")

					Else
					End If

				End If


			Case Is = "LGL"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("LEGAL") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("LEGAL")
						RCCollection.Add("LEGAL", "LGL")

					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("LEGAL") = False Then
						Me.ddRC.Items.Add("LEGAL")
						RCCollection.Add("LEGAL", "LGL")

					Else
					End If

				End If

			Case Is = "OPS"



			Case Is = "RAS"

				If Me.ddRC.Items.Count = 0 Then

					If RCCollection.Contains("RISK AND STRATEGY") = False Then
						Me.ddRC.Items.Add("")
						Me.ddRC.Items.Add("RISK AND STRATEGY")
						RCCollection.Add("RISK AND STRATEGY", "RAS")

					Else
					End If

				ElseIf Me.ddRC.Items.Count > 0 Then

					If RCCollection.Contains("RISK AND STRATEGY") = False Then
						Me.ddRC.Items.Add("RISK AND STRATEGY")
						RCCollection.Add("RISK AND STRATEGY", "RAS")

					Else
					End If

				End If

			Case Else


		End Select





	End Sub

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

		If Page.IsPostBack = False Then
			'getNavData2()
		Else

		End If

	End Sub

	'If IsNothing(Session("dtEmployeeLeaves")) = True Then

	Protected Sub ddLeaveNo_TextChanged(sender As Object, e As EventArgs) Handles ddLeaveNo.TextChanged

		'MsgBox("" & Me.ddLeaveNo.SelectedItem.Text)
		Dim dtPostedEmployeeLeaves As New DataTable
		dtPostedEmployeeLeaves = Session("dtPostedEmployeeLeaves")
		Dim result() As DataRow

		result = dtPostedEmployeeLeaves.Select("ApplicationNo = '" & Me.ddLeaveNo.SelectedItem.Text & "'")
		'MsgBox("" & result.Length)

		If result.Length > 0 Then

			Me.txtLeaveType.Text = CStr(result(0).Item(3))
			Me.txtAppliedDays.Text = CStr(result(0).Item(4))
			Me.txtStateDate.Text = CDate(result(0).Item(5))
			Me.txtReturnDate.Text = CStr(result(0).Item(6))
			'	Me.txtDaySpent.Text = ""
			'	Me.txtActualReturnDay.Text = ""
			Me.txtComment.Text = ""
		End If

	End Sub

	Protected Sub calActualReturnDay_SelectionChanged(sender As Object, e As EventArgs) Handles calActualReturnDay.SelectionChanged
		Me.calActualReturnDay_PopupControlExtender.Commit(Me.calActualReturnDay.SelectedDate)
	End Sub

	Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

		Dim LeaveAck As New LeaveAcknowledgment.LeaveAcknowledgment
		Dim leaveAppCls As New NAV_HR_WINDOW.LeaveApplication
		If IsNothing(Session("user")) = False Then
			leaveAppCls.UserName = Session("user")
			leaveAppCls.Password = Session("password")
		Else
			Response.Redirect("login.aspx")
		End If
		

		If Not IsNothing(ViewState("RCCollection")) = True Then

			RCCollection = ViewState("RCCollection")
			LeaveAck.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))

		Else

			Exit Sub

		End If

		LeaveAck.Start_Date = CDate(Me.txtStateDate.Text)

		LeaveAck.Return_Date = CDate(Me.txtReturnDate.Text)


		LeaveAck.Days_Applied = CInt(Me.txtAppliedDays.Text)


		LeaveAck.Comment = Me.txtComment.Text
		'LeaveAck.Employee_No = Me.txtEmployeeNo.Text
		'LeaveAck.Employee_Name = Me.txtEmployeeName.Text
		LeaveAck.Leave_No = Me.ddLeaveNo.SelectedItem.Text
		'LeaveAck.Leave_Type = Me.txtLeaveType.Text

		Dim ii As New LeaveAcknowledgment.LeaveAcknowledgment_Service
		ii.Credentials = New NetworkCredential(leaveAppCls.UserName, leaveAppCls.Password, "pensure-nigeria.com")
		ii.PreAuthenticate = True

		Try
			ii.Create(LeaveAck)

			LeaveAck.Actual_Days_Spent = CInt(Me.txtDaySpent.Text)
			LeaveAck.Actual_Return_Day = CDate(Me.txtReturnDate.Text)

			ii.Update(LeaveAck)
			Response.Redirect("frmLeaveAcknowledgmentList.aspx")

		Catch ex As Exception

			lblogonMessage.InnerText = "" & ex.Message
			DivError.Attributes.Add("class", "logonError")
			Exit Sub

		End Try


	End Sub
End Class
