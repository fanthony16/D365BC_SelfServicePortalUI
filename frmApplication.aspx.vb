Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports AjaxControlToolkit
Imports System.Net

Partial Class frmApplication
	Inherits System.Web.UI.Page
	Dim DocumentCollection As New Hashtable
	Dim ApprovalTypeCollection As New Hashtable
	Dim InsurerTypeCollection As New Hashtable
	Dim LeaveTypeCollection As New Hashtable
	Dim RCCollection As New Hashtable
	Dim EmployerHistoryCollection As New Hashtable
	Dim RLVCollection As New Hashtable
	Dim lstRecievedDoc As New ArrayList
	Dim dtDocuments As New DataTable
	Dim dtColumn As New DataColumn
	Dim blnHardShip As Boolean = False
	Dim blnEnbloc As Boolean = False
	Dim blnLegacy As Boolean = False
	Dim blnAnnuity As Boolean = False
	Dim blnPW As Boolean = False
	Dim blnAVC As Boolean = False
	Dim blnDB As Boolean = False
	Dim blnNSITF As Boolean = False

	Private Sub DownLoadDocument(path As String)

		If Not File.Exists(path) = False Then

			'If CStr(ViewState("schedulePath")).ToString = "" Then
			'     ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Schedule Not Mapped", True)
			'Else
			'End If

			Dim schedulePath As String = path
			Try

				Dim str() As String = schedulePath.Split("|")
				Dim FI As FileInfo, fileExt As String, i As Integer = 0

				Do While i < str.Length

					FI = New FileInfo(str(i).Trim.ToString)
					fileExt = LCase(FI.Extension)
					'MsgBox("" & fileExt)
					Select Case fileExt

						Case Is = ".xls"
							' Process.Start("EXCEL", str(i).Trim.ToString)

							Response.ContentType = "application/EXCEL"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()

						Case Is = ".xlsx"
							' Process.Start("EXCEL", str(i).Trim.ToString)
							Response.ContentType = "application/EXCEL"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()
						Case Is = ".csv"
							'Process.Start("EXCEL", str(i).Trim.ToString)
							Response.ContentType = "application/EXCEL"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()
						Case Is = ".pdf"
							'Process.Start("ACRORD32", str(i).Trim.ToString)

							Response.ContentType = "application/pdf"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()


						Case Is = ".doc"
							' Process.Start("WINWORD", str(i).Trim.ToString)

							Response.ContentType = "application/WORD"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()

						Case Is = ".docx"

							'Process.Start("WINWORD", str(i).Trim.ToString)

							Response.ContentType = "application/WORD"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()

						Case Is = ".jpg"
							' Process.Start("EXPLORER", str(i).Trim.ToString)

							Response.ContentType = "application/EXPLORER"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()

						Case Is = ".png"
							' Process.Start("EXPLORER", str(i).Trim.ToString)

							Response.ContentType = "application/EXPLORER"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()
						Case Else
							Response.ContentType = "application/EXPLORER"
							Response.Clear()
							Response.AppendHeader("Content-Disposition", "attachment;Filename=" & str(i).Trim.ToString)
							Response.TransmitFile(str(i).Trim.ToString)
							Response.End()
					End Select
					i = i + 1
				Loop
			Catch ex As Exception
				'   MsgBox("" & ex.Message)
			End Try

		Else
			ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "File Not Found", True)
		End If


	End Sub

	Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)


		Dim btnDetails As New ImageButton
		btnDetails = sender
		Dim i As GridViewRow
		i = btnDetails.NamingContainer
		'	DownLoadDocument(Server.MapPath("~/FileUploads" + "/" + Session("user") + "/" + Me.gridRecievedDocument.Rows(i.RowIndex).Cells(3).Text))



		'Dim tmpPath As String = Server.MapPath("~/FileUploads" + "/" + Session("user") + "/" + Me.gridRecievedDocument.Rows(i.RowIndex).Cells(2).Text)


		'If File.Exists(tmpPath) = True Then

		'	DownLoadDocument(tmpPath)
		'	Exit Sub
		'End If





	End Sub

	Protected Sub AjaxFileDocumentUploadEvent(ByVal sender As Object, ByVal e As AjaxFileUploadEventArgs)

		Try


			'If Directory.Exists("~/FileUploads/" & Session("user")) = False Then
			'	Directory.CreateDirectory("~/FileUploads/" & Session("user") & "/")
			'Else
			'End If


			Dim filename As String = System.IO.Path.GetFileName(e.FileName)
			Dim fullPath As String = System.IO.Path.GetFullPath(e.FileName)


			Dim fileNewName As String = ""


			filename = filename.Replace(" | ", "_")
			filename = filename.Replace(" ", "_")
			filename = filename.Replace("|", "_")
			filename = filename.Replace(" ", "_")
			filename = filename.Replace("(", "_")
			filename = filename.Replace(")", "_")


			Dim strUploadPath As String


			strUploadPath = "~/FileUploads/" & Session("user") & "/" & CStr(Session("EmployeeNo")).Replace("/", "_") & "_" & filename ''& System.IO.Path.GetExtension(fullPath)


			Session("documentPath") = strUploadPath

			If e.FileSize > 2000000 Then
				Session("FileSizeExceeded") = True
				Session("Document") = Nothing
			Else
				Session("FileSizeExceeded") = False
				'Me.flReqDocUpload.SaveAs(Server.MapPath(strUploadPath))

				'flReqDocUpload.Dispose()
				Session("Document") = Nothing

			End If


		Catch ex As Exception

			MsgBox("" & ex.Message)

		End Try

	End Sub

	Protected Sub gridApprovalEntries_RowDataBound()

	End Sub

	Protected Sub calApplicationDate_SelectionChanged(sender As Object, e As EventArgs) Handles calApplicationDate.SelectionChanged

		Me.calApplicationDate_PopupControlExtender.Commit(Me.calApplicationDate.SelectedDate)

	End Sub


	'Private Sub MakeDirectoryIfExists(ByVal NewDirectory As String)

	'	Try
	'		' Check if directory exists
	'		If Not Directory.Exists(NewDirectory) Then
	'			' Create the directory.
	'			Directory.CreateDirectory(NewDirectory)
	'		ElseIf Directory.Exists(NewDirectory) Then
	'			DeleteDir(NewDirectory)
	'			Directory.CreateDirectory(NewDirectory)
	'		End If
	'	Catch _ex As IOException
	'		Response.Write(_ex.Message)
	'	End Try

	'End Sub

	Private Sub DeleteDir(ByVal DirPath As String)

		Try
			If Directory.Exists(DirPath) Then
				Directory.Delete("", True)
			Else
			End If
		Catch ex As Exception

		End Try

	End Sub


	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


		Dim scriptManagerA As New ScriptManager, scriptManagerB As New ScriptManager, dtusers As New DataTable

		scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		'scriptManagerA.RegisterPostBackControl(Me.gridRecievedDocument)

		'If flReqDocUpload.IsInFileUploadPostBack Then



		If IsPostBack = False Then

			'If IsNothing(Session("user")) = True Then
			'	Response.Redirect("Login.aspx")
			'ElseIf IsNothing(Session("user")) = False Then

			'dvUploadDocument.Visible = False

			getNavData2()

			'Dim strUploadPath As String = Server.MapPath("~/FileUploads/" & Session("user"))
			'MakeDirectoryIfExists(strUploadPath)

			'Else

			'End If

		Else



		End If




	End Sub
	Protected Sub getNavDataLeave(appCode As String)


		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Dim dtEmployees As New DataTable, dtEmployeeCard As New DataTable, dtHRSetup As New DataTable, dtRC As New DataTable, i As Integer, dtLeaveTypes As DataTable, dtReleaver As New DataTable, dtLeave As DataTable, empDeptCode As String = ""
		Dim result As DataRow()

		Dim user_ID As String = "PENSURE-NIGERIA\" & Session("user")

		dtEmployees = NAV_Window.getEmployeeDetails(user_ID)
		dtHRSetup = NAV_Window.getHRSetup
		dtRC = NAV_Window.getResponsibiltyCenters("")
		dtLeaveTypes = NAV_Window.getLeaveTypes
		dtLeave = NAV_Window.getLeaveApplicationForEdit(appCode)



		result = dtEmployees.Select("UserID = '" & user_ID & "'")

		For Each row As DataRow In result

			dtEmployeeCard = NAV_Window.getEmployee(row.Item(0))

		Next
		' Reading employee records
		If dtEmployeeCard.Rows.Count > 0 And dtLeave.Rows.Count > 0 Then

			Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
			Me.txtApplicantName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName").ToString
			Me.txtJobTitle.Text = dtEmployeeCard.Rows(0).Item("JobTitle").ToString
			Me.txtJobDescription.Text = dtEmployeeCard.Rows(0).Item("JobDescription").ToString
			Me.txtDepartment.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
			empDeptCode = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
			Me.txtSupervisor.Text = dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString
			Me.txtSupervisorName.Text = dtEmployeeCard.Rows(0).Item("SupervisorName").ToString
			Me.txtSupervisorEmail.Text = CStr(dtEmployeeCard.Rows(0).Item("SupervisorEmail").ToString).Split("\")(1) & "@leadway-pensure.com"
			Me.txtMaxLeaveDays.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveDays").ToString
			Me.txtLeaveBalance.Text = dtEmployeeCard.Rows(0).Item("LeaveBalance").ToString
			txtAnnualLeaveTaken.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveTaken").ToString

			Me.txtApplicationDatee.Text = dtLeave.Rows(0).Item("ApplicationDate").ToString
			Me.txtStartDate.Text = dtLeave.Rows(0).Item("StartDate").ToString
			Me.txtAppliedDays.Text = dtLeave.Rows(0).Item("DaysApplied").ToString



			'Reading the Current leave period
			If dtHRSetup.Rows.Count > 0 Then
				'Me.txtLeavePeriod.Text = dtHRSetup.Rows(0).Item("CurLeavePeriod")
				Me.ddLeavePeriod.Items.Add("")
				Me.ddLeavePeriod.Items.Add(dtHRSetup.Rows(0).Item("CurLeavePeriod"))
				Me.ddLeavePeriod.Items.Add(CInt(dtHRSetup.Rows(0).Item("CurLeavePeriod") - 1))

			Else
			End If

			Try
				ddLeavePeriod.SelectedItem.Text = dtLeave.Rows(0).Item("LeavePeriod")
			Catch ex As Exception

			End Try



		Else

		End If


		'Reading the responsibility centers
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



		i = 0


		Me.ddLeaveType.Items.Clear()

		Do While i < dtLeaveTypes.Rows.Count

			If Me.ddLeaveType.Items.Count = 0 Then

				Me.ddLeaveType.Items.Add("")
				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

			ElseIf Me.ddLeaveType.Items.Count > 0 Then

				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

			End If
			i = i + 1

		Loop

		'MsgBox("" & dtLeave.Rows(0).Item("LeaveType"))

		ddLeaveType.SelectedItem.Text = dtLeave.Rows(0).Item("LeaveType")






		' reading releavers

		dtReleaver = NAV_Window.getEmployeeReleaver(Me.txtDepartment.Text)
		gridReleaver.DataSource = dtReleaver
		gridReleaver.DataBind()
		pnlUploadDetail.Height = Nothing


		ViewState("RCCollection") = RCCollection
		ViewState("LeaveTypeCollection") = LeaveTypeCollection


	End Sub
	Protected Sub getNavData2()

		Dim dtEmployeeCard As New DataTable, empDeptCode As String = ""


		'dtEmployees = NAV_Window.getEmployeeDetails
		'dtHRSetup = NAV_Window.getHRSetup
		'dtRC = NAV_Window.getResponsibiltyCenters
		'dtLeaveTypes = NAV_Window.getLeaveTypes



		If IsNothing(Session("dtEmployeeCard")) = True Then
			Response.Redirect("Login.aspx")
		Else
			dtEmployeeCard = Session("dtEmployeeCard")
		End If


		' Reading employee records
		If dtEmployeeCard.Rows.Count > 0 Then
			Session("EmployeeNo") = dtEmployeeCard.Rows(0).Item("No").ToString
			Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
			Me.txtApplicantName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName").ToString
			Me.txtJobTitle.Text = dtEmployeeCard.Rows(0).Item("JobTitle").ToString
			Me.txtJobDescription.Text = dtEmployeeCard.Rows(0).Item("JobDescription").ToString
			Me.txtDepartment.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
			empDeptCode = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
			Me.txtSupervisor.Text = dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString
			Me.txtSupervisorName.Text = dtEmployeeCard.Rows(0).Item("SupervisorName").ToString
			If CStr(dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString).Split("\").Count > 1 Then
				Me.txtSupervisorEmail.Text = CStr(dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString).Split("\")(1) & "@leadway-pensure.com"
			Else

			End If

			Me.txtMaxLeaveDays.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveDays").ToString
			Me.txtLeaveBalance.Text = dtEmployeeCard.Rows(0).Item("LeaveBalance").ToString
			txtAnnualLeaveTaken.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveTaken").ToString
			Me.txtApplicationDatee.Text = Now.Date
			Me.txtStartDate.Text = Now.Date
			Me.txtAppliedDays.Text = 0

		Else

		End If

		'retrieving Leave Period Data
		getLeavePeriod()

		'retrieving Leave Type Data
		getLeaveType()

		'retrieving Responsibility Center Data
		getResponsibilityCenter()

		'retrieving leave releavers data 
		getReleavers()





	End Sub
	'retrieving leave period data from the session object
	Protected Sub getLeavePeriod()
		Dim dtHRSetup As New DataTable
		If IsNothing(Session("HRSetup")) = True Then
			Response.Redirect("Login.aspx")
		Else

			'Reading the leave period from the session object
			dtHRSetup = Session("HRSetup")
			ddLeavePeriod.Items.Clear()
			If dtHRSetup.Rows.Count > 0 Then

				Me.ddLeavePeriod.Items.Add("")
				Me.ddLeavePeriod.Items.Add(dtHRSetup.Rows(0).Item("CurLeavePeriod"))
				Me.ddLeavePeriod.Items.Add(CInt(dtHRSetup.Rows(0).Item("CurLeavePeriod") - 1))

			Else
			End If

		End If

	End Sub

	'retrieving leave releavers data from the session object
	Protected Sub getReleavers()

		Dim dtReLeavers As New DataTable

		If IsNothing(Session("ReLeavers")) = True Then

			Response.Redirect("Login.aspx")

		Else
			'Reading the leave period from the session object
			dtReLeavers = Session("ReLeavers")

		End If

		gridReleaver.DataSource = dtReLeavers
		gridReleaver.DataBind()
		pnlUploadDetail.Height = Nothing

	End Sub






	'retrieving responsibilty center and populating the control on the page
	Protected Sub getResponsibilityCenter()

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

			'If (rc = RCCollection.Item(RCCollection.Keys(i))) = True Then

			'	_rcc = (RCCollection.Keys(i).ToString())
			'Else
			'End If

			i += 1
		Loop

		'Me.ddRC.SelectedValue = _rcc.ToString()

	End Sub



	'retrieving leaveType data from the session object
	Protected Sub getLeaveType()

		Dim i As Integer
		Dim dtLeaveTypes As New DataTable
		'checking if the sesion object still has the leavetype data
		If IsNothing(Session("LeaveTypes")) = True Then

			Response.Redirect("Login.aspx")

		Else

			dtLeaveTypes = Session("LeaveTypes")

		End If

		i = 0

		Me.ddLeaveType.Items.Clear()

		Do While i < dtLeaveTypes.Rows.Count

			If Me.ddLeaveType.Items.Count = 0 Then

				Me.ddLeaveType.Items.Add("")
				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

			ElseIf Me.ddLeaveType.Items.Count > 0 Then

				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

			End If

			i += 1

		Loop

		ViewState("LeaveTypeCollection") = LeaveTypeCollection

	End Sub

	Protected Sub getEmployeeDetails()

		Dim empList As New EnployeeList.EmployeeList_Service

		empList.Credentials = New NetworkCredential("", "", "")
		empList.PreAuthenticate = True

		Dim empListFilterArray As New List(Of EnployeeList.EmployeeList_Filter)
		Dim empListFilter As New EnployeeList.EmployeeList_Filter

		empListFilter.Field = EnployeeList.EmployeeList_Fields.User_ID

		empListFilter.Criteria = "*"
		empListFilterArray.Add(empListFilter)
		Dim emp() As EnployeeList.EmployeeList
		emp = empList.ReadMultiple(empListFilterArray.ToArray, "", 500)













		MsgBox("" & emp.Length)


	End Sub


	Protected Sub getNAVData()


		Dim empCard As New EmployeeCard.EmployeeCard_Service
		Dim empList As New EnployeeList.EmployeeList_Service
		Dim LeaveC As New LeaveCard.LeaveApplication_Service
		Dim HRSetp As New HRSetup.HRSetup_Service
		Dim LeaveT As New LeaveTypes.LeaveTypes_Service
		Dim RC As New RCenter.ResponsibilityCenter_Service
		Dim LReleavers As New ReLeavers.Releavers_Service
		Dim NSeries As New NoSeries.NoSerialIntegration_Service


		Dim nc As New NetworkCredential
		nc.Domain = ConfigurationManager.AppSettings("DomainName")
		nc.UserName = ConfigurationManager.AppSettings("DomainUserName")
		nc.Password = ConfigurationManager.AppSettings("DomainPass")


		Dim prxy As New WebProxy("172.16.0.8:8080", True)
		prxy.Credentials = nc


		'empCard.UseDefaultCredentials = True


		empCard.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		empCard.PreAuthenticate = True


		'empList.UseDefaultCredentials = True


		empList.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		empList.PreAuthenticate = True


		'LeaveC.UseDefaultCredentials = True

		LeaveC.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		LeaveC.PreAuthenticate = True


		'HRSetp.UseDefaultCredentials = True

		HRSetp.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		HRSetp.PreAuthenticate = True

		'LeaveT.UseDefaultCredentials = True

		LeaveT.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		LeaveT.PreAuthenticate = True

		'RC.UseDefaultCredentials = True

		RC.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		RC.PreAuthenticate = True

		'LReleavers.UseDefaultCredentials = True

		LReleavers.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		LReleavers.PreAuthenticate = True


		'NSeries.UseDefaultCredentials = True

		NSeries.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
		NSeries.PreAuthenticate = True


		Dim empListFilterArray As New List(Of EnployeeList.EmployeeList_Filter)
		Dim empListFilter As New EnployeeList.EmployeeList_Filter

		Dim empCardFilterArray As New List(Of EmployeeCard.EmployeeCard_Filter)
		Dim empCardFilter As New EmployeeCard.EmployeeCard_Filter

		Dim LeaveCFilterArray As New List(Of LeaveCard.LeaveApplication_Filter)
		Dim LeaveCFilter As New LeaveCard.LeaveApplication_Filter

		Dim HRSetupFilterArray As New List(Of HRSetup.HRSetup_Filter)
		Dim HRSetupFilter As New HRSetup.HRSetup_Filter

		Dim LeaveTFilterArray As New List(Of LeaveTypes.LeaveTypes_Filter)
		Dim LeaveTFilter As New LeaveTypes.LeaveTypes_Filter

		Dim RCFilterArray As New List(Of RCenter.ResponsibilityCenter_Filter)
		Dim RCFilter As New RCenter.ResponsibilityCenter_Filter

		Dim ReleaverFilterArray As New List(Of ReLeavers.Releavers_Filter)
		Dim ReleaverFilter As New ReLeavers.Releavers_Filter

		Dim NSeriesFilterArray As New List(Of NoSeries.NoSerialIntegration_Filter)
		Dim NSeriesFilter As New NoSeries.NoSerialIntegration_Filter




		'''''''getting series code ''''''''''''''''''''''''''''''''''''''''

		NSeriesFilter.Field = NoSeries.NoSerialIntegration_Fields.Code
		NSeriesFilter.Criteria = "LVE"
		NSeriesFilterArray.Add(NSeriesFilter)
		Dim NCRs() As NoSeries.NoSerialIntegration
		NCRs = NSeries.ReadMultiple(NSeriesFilterArray.ToArray, "", 100)

		Dim i As Integer

		If NCRs.Length > 0 Then
			'Me.txtApplicationNo.Text = NCRs(0).LastNoUsed
		End If

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''








		'''''''getting responsibility Center''''''''''''''''''''''''''''''''''''''''
		RCFilter.Field = RCenter.ResponsibilityCenter_Fields.Code
		RCFilter.Criteria = "*"
		RCFilterArray.Add(RCFilter)
		Dim Rct() As RCenter.ResponsibilityCenter
		Rct = RC.ReadMultiple(RCFilterArray.ToArray, "", 100)

		i = 0
		ddRC.Items.Clear()

		Do While i < Rct.Length

			If Me.ddRC.Items.Count = 0 Then

				Me.ddRC.Items.Add("")
				Me.ddRC.Items.Add(Rct(i).Name)
				RCCollection.Add(Rct(i).Name, Rct(i).Code)

			ElseIf Me.ddRC.Items.Count > 0 Then

				Me.ddRC.Items.Add(Rct(i).Name)
				RCCollection.Add(Rct(i).Name, Rct(i).Code)

			End If
			i = i + 1

		Loop
		ViewState("RCCollection") = RCCollection

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





		'''''''getting leave types''''''''''''''''''''''''''''''''''''''''
		LeaveTFilter.Field = LeaveTypes.LeaveTypes_Fields.Code
		LeaveTFilter.Criteria = "*"
		LeaveTFilterArray.Add(LeaveTFilter)
		Dim LvType() As LeaveTypes.LeaveTypes
		LvType = LeaveT.ReadMultiple(LeaveTFilterArray.ToArray, "", 100)

		i = 0
		ddLeaveType.Items.Clear()
		Do While i < LvType.Length

			If Me.ddLeaveType.Items.Count = 0 Then

				Me.ddLeaveType.Items.Add("")
				Me.ddLeaveType.Items.Add(LvType(i).Description)
				LeaveTypeCollection.Add(LvType(i).Description, LvType(i).Code)

			ElseIf Me.ddLeaveType.Items.Count > 0 Then

				Me.ddLeaveType.Items.Add(LvType(i).Description)
				LeaveTypeCollection.Add(LvType(i).Description, LvType(i).Code)

			End If
			i = i + 1

		Loop
		ViewState("LeaveTypeCollection") = LeaveTypeCollection

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		HRSetupFilter.Field = HRSetup.HRSetup_Fields.Appraisal_Nos
		HRSetupFilter.Criteria = "*"
		HRSetupFilterArray.Add(HRSetupFilter)
		Dim HRSet() As HRSetup.HRSetup
		HRSet = HRSetp.ReadMultiple(HRSetupFilterArray.ToArray, "", 100)


		empListFilter.Field = EnployeeList.EmployeeList_Fields.User_ID
		'empListFilter.Criteria = "PENSURE-NIGERIA\" & CStr(Session("user")).ToString.ToUpper
		empListFilter.Criteria = "*"
		empListFilterArray.Add(empListFilter)
		Dim emp() As EnployeeList.EmployeeList
		emp = empList.ReadMultiple(empListFilterArray.ToArray, "", 100)

		'MsgBox("" & emp.Length)
		'Exit Sub
		If emp.Length > 0 Then


			''''rertrieving the employee details'''''''''''''''''''''''''''''''''''''''''''

			empCardFilter.Field = EmployeeCard.EmployeeCard_Fields.No
			empCardFilter.Criteria = emp(0).No
			empCardFilterArray.Add(empCardFilter)
			Dim empC() As EmployeeCard.EmployeeCard
			empC = empCard.ReadMultiple(empCardFilterArray.ToArray, "", 100)


			'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



			'''''''getting releavers''''''''''''''''''''''''''''''''''''''''
			ReleaverFilter.Field = ReLeavers.Releavers_Fields.Department_Code
			ReleaverFilter.Criteria = empC(0).Department_Code
			ReleaverFilterArray.Add(ReleaverFilter)

			'ReleaverFilter = New ReLeavers.Releavers_Filter



			Dim RLV() As ReLeavers.Releavers
			RLV = LReleavers.ReadMultiple(ReleaverFilterArray.ToArray, "", 100)

			gridReleaver.DataSource = Me.getdtReleaver(RLV)
			gridReleaver.DataBind()
			pnlUploadDetail.Height = Nothing
			'dvRLV.h()



			'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


			Me.txtEmployeeNo.Text = emp(0).No
			Me.txtApplicantName.Text = emp(0).Last_Name & " " & emp(0).Middle_Name & " " & emp(0).First_Name
			Me.txtJobTitle.Text = emp(0).Job_Title
			Me.txtJobDescription.Text = empC(0).Job_Description
			Me.txtDepartment.Text = empC(0).Department_Code
			Me.txtSupervisor.Text = empC(0).Supervisor_Manager
			Me.txtSupervisorName.Text = empC(0).SupervisorNames
			Me.txtSupervisorEmail.Text = empC(0).Supervisor_Manager.Split("\")(1) & "@leadway-pensure.com"

			'Me.txtLeavePeriod.Text = HRSet(0).Current_Leave_Period.ToString()

			Me.txtMaxLeaveDays.Text = empC(0).Total_Leave_Days
			Me.txtLeaveBalance.Text = empC(0).Leave_Balance
			txtAnnualLeaveTaken.Text = empC(0).Total_Leave_Taken
			Me.txtApplicationDatee.Text = Now.Date
			Me.txtStartDate.Text = Now.Date
			Me.txtAppliedDays.Text = 0
			'	Me.txtPayrollPeriod.Text = Now.Date

			'	txtReturnDate.Text = Now.Date

			'ddLeaveType.Items.Add("")

		End If
		'emp(0).

		'MsgBox("" & emp.Length)

	End Sub


	Private Function getdtReleaver(RLV() As ReLeavers.Releavers) As DataTable

		Dim i As Integer = 0, dtReLeaver As New DataTable

		If RLV.Length > 0 Then

			dtReLeaver = New DataTable

			dtColumn = New DataColumn("EmployeeNo")
			dtReLeaver.Columns.Add(dtColumn)

			dtColumn = New DataColumn("Firstname")
			dtReLeaver.Columns.Add(dtColumn)

			dtColumn = New DataColumn("MiddleName")
			dtReLeaver.Columns.Add(dtColumn)

			dtColumn = New DataColumn("LastName")
			dtReLeaver.Columns.Add(dtColumn)

			dtColumn = New DataColumn("LeaveStatus")
			dtReLeaver.Columns.Add(dtColumn)

			Do While i < RLV.Length

				Dim newCustomersRow As DataRow
				newCustomersRow = dtReLeaver.NewRow()

				newCustomersRow("EmployeeNo") = RLV(i).No
				newCustomersRow("Firstname") = RLV(i).First_Name
				newCustomersRow("MiddleName") = RLV(i).Middle_Name
				newCustomersRow("LastName") = RLV(i).Last_Name
				newCustomersRow("LeaveStatus") = RLV(i).Leave_Status

				dtReLeaver.Rows.Add(newCustomersRow)

				i = i + 1
			Loop

		End If
		Return dtReLeaver


	End Function
	Protected Sub txtAppliedDays_TextChanged(sender As Object, e As EventArgs) Handles txtAppliedDays.TextChanged

		'Me.txtReturnDate.Text = DateAdd(DateInterval.Day, CDbl(Me.txtAppliedDays.Text), Me.txtStartDate.Text)
	End Sub

	Protected Sub gridCustomerHistory_RowDataBound()

	End Sub
	Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

		Dim StartDate As DateTime
		Dim EndDate As DateTime
		Dim Difference As TimeSpan
		Dim dtHRSetup As New DataTable
		StartDate = Convert.ToDateTime(Me.txtStartDate.Text.ToString)
		EndDate = Convert.ToDateTime(Me.txtApplicationDatee.Text.ToString)
		Difference = StartDate.Subtract(EndDate)

		dtHRSetup = Session("HRSetup")

		If ddLeaveType.Text = "" Then

			Span2.InnerText = "Please Select Leave Type"
			Span2.Visible = True
			Exit Sub

		Else
		End If

		If ddRC.Text = "" Then

			Span2.InnerText = "Please Select Responsibility Center"
			Span2.Visible = True
			Exit Sub

		Else
		End If

		If ddLeavePeriod.Text = "" Then

			Span2.InnerText = "Please Select Responsibility Center"
			Span2.Visible = True
			Exit Sub

		Else
		End If

		If CInt(Me.txtAppliedDays.Text) = 0 Then

			Span2.InnerText = "Leave Days Must be Greater Than Zero"
			Span2.Visible = True
			Exit Sub

		Else
		End If

		If CInt(Convert.ToString(Difference.Days)) < CInt(dtHRSetup.Rows(0).Item("LeaveAppBefore")) Then

			Span2.InnerText = "Leave Start Date Must be two(2) days Greater than the Application Date"
			Span2.Visible = True
			Exit Sub

		Else
		End If

		Dim cb As CheckBox, chk As Integer = 0
		Dim LeaveApp As New LeaveCardd.LeaveApplication
		Dim leaveAppCls As New NAV_HR_WINDOW.LeaveApplication

		If Not IsNothing(ViewState("RCCollection")) = True Then

			RCCollection = ViewState("RCCollection")
			LeaveApp.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))
			leaveAppCls.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))

		Else

			Exit Sub

		End If

		For Each grow As GridViewRow In Me.gridReleaver.Rows

			cb = grow.FindControl("chkSelect")
			If cb.Checked = True Then

				LeaveApp.Reliever = grow.Cells(1).Text '& " " & grow.Cells(3).Text & " " & grow.Cells(4).Text
				leaveAppCls.Reliever = grow.Cells(1).Text '& " " & grow.Cells(3).Text & " " & grow.Cells(4).Text

				chk = chk + 1

			ElseIf cb.Checked = False Then

			End If

		Next


		If CInt(chk) = 0 Then

			Span2.InnerText = "Please Select Releaver Details"
			Span2.Visible = True
			Exit Sub

		Else
		End If


		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'''
		Dim result As DataRow()
		'result = dtEmployees.Select("UserID = '" & _userID & "'")

		Dim dtLeaveType As New DataTable
		If IsNothing(Session("LeaveTypes")) = False Then
			dtLeaveType = Session("LeaveTypes")
		Else
			Response.Redirect("Login.aspx")
		End If

		result = dtLeaveType.Select("Description = '" & Me.ddLeaveType.SelectedValue.ToString & "'")
		LeaveApp.Application_Date = CDate(Me.txtApplicationDatee.Text)
		leaveAppCls.Application_Date = CDate(Me.txtApplicationDatee.Text)
		LeaveApp.Employee_No = Me.txtEmployeeNo.Text
		leaveAppCls.Employee_No = Me.txtEmployeeNo.Text
		LeaveApp.Leave_Period = Me.ddLeavePeriod.SelectedItem.Text
		leaveAppCls.Leave_Period = Me.ddLeavePeriod.SelectedItem.Text
		LeaveApp.Leave_Type = Me.ddLeaveType.SelectedValue
		leaveAppCls.Leave_Type = Me.ddLeaveType.SelectedValue
		LeaveApp.Leave_Type = result(0).Item("Code").ToString
		leaveAppCls.Leave_Type = result(0).Item("Code").ToString
		leaveAppCls.UserName = Session("userID")
		leaveAppCls.Password = Session("password")


		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


		LeaveApp.Start_Date = CDate(Me.txtStartDate.Text)
		leaveAppCls.Start_Date = CDate(Me.txtStartDate.Text)

		LeaveApp.Start_DateSpecified = True

		LeaveApp.Days_Applied = CInt(Me.txtAppliedDays.Text)
		leaveAppCls.Days_Applied = CInt(Me.txtAppliedDays.Text)

		LeaveApp.Days_AppliedSpecified = True
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Dim NAV_WINDOW As New NAV_HR_WINDOW.Core, returnType As String = ""



		Try

		Catch ex As Exception

			lblogonMessage.InnerText = "" & ex.Message
			DivError.Attributes.Add("class", "logonError")
			Exit Sub

		End Try



		Dim us(1) As LeaveCardd.HR_Leave_Reliver_SubForm
		Dim lReleaver(1) As NAV_HR_WINDOW.LeaveCard_Service.HR_Leave_Reliver_SubForm

		For Each grow As GridViewRow In Me.gridReleaver.Rows
			Dim u As New LeaveCardd.HR_Leave_Reliver_SubForm
			Dim Releaver As New NAV_HR_WINDOW.LeaveCard_Service.HR_Leave_Reliver_SubForm
			cb = grow.FindControl("chkSelect")
			If cb.Checked = True Then

				u.Application_No = LeaveApp.Application_Code
				Releaver.Application_No = LeaveApp.Application_Code

				u.Reliver_No = grow.Cells(1).Text
				Releaver.Reliver_No = grow.Cells(1).Text

				u.Reliver_Name = grow.Cells(2).Text & " " & grow.Cells(3).Text & " " & grow.Cells(4).Text
				Releaver.Reliver_Name = grow.Cells(2).Text & " " & grow.Cells(3).Text & " " & grow.Cells(4).Text


				us(chk) = u
				lReleaver(chk) = Releaver

				chk = chk + 1

			ElseIf cb.Checked = False Then

			End If

		Next

		LeaveApp.HR_Leave_Reliver_SubForm = us
		leaveAppCls.ReLeaverForm = lReleaver

		Try

			returnType = NAV_WINDOW.CreateLeaveApplication(leaveAppCls).ToString()

			If returnType = "Success" Then

				Session("dtEmployeeLeaves") = Nothing
				Dim dtEmployeeCard As New DataTable
				dtEmployeeCard = Session("dtEmployeeCard")
				Session("dtEmployeeLeaves") = NAV_WINDOW.getLeaveApplicationList(dtEmployeeCard.Rows(0)("No"))
				Response.Redirect("frmApplicationList.aspx")

			Else

				Span2.InnerText = returnType
				Span2.Visible = True

			End If

			Exit Sub

		Catch ex As Exception

			lblogonMessage.InnerText = "" & ex.Message
			DivError.Attributes.Add("class", "logonError")
			Exit Sub

		End Try


		'Dim strUploadPath As String = Server.MapPath("~/FileUploads/" & Session("user"))
		'DeleteDir(strUploadPath)


		Session("dtEmployeeLeaves") = Nothing
		Response.Redirect("frmApplicationList.aspx")


	End Sub




	Protected Sub calStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles calStartDate.SelectionChanged

		Me.calStartDate_PopupControlExtender.Commit(Me.calStartDate.SelectedDate)

	End Sub

	Protected Sub txtStartDate_TextChanged(sender As Object, e As EventArgs) Handles txtStartDate.TextChanged



	End Sub

	Protected Sub ddLeaveType_TextChanged(sender As Object, e As EventArgs) Handles ddLeaveType.TextChanged

		If ddLeaveType.SelectedValue = "Exam" Then
			'dvUploadDocument.Visible = True
		ElseIf ddLeaveType.SelectedValue = "Sick" Then
			'dvUploadDocument.Visible = True
		Else
			'dvUploadDocument.Visible = False
		End If

	End Sub

	'Protected Sub btnAddDocument_Click(sender As Object, e As EventArgs) Handles btnAddDocument.Click

	'	Try

	'		Dim ary As IList(Of DataRow)

	'		If Not IsNothing(ViewState("RecievedDocument")) Then

	'			dtDocuments = ViewState("RecievedDocument")
	'			ary = dtDocuments.Select()

	'			Dim query = From n In ary
	'						Where n.Item("DocumentDesc") = Me.txtDocNarration.Text
	'			If query.Count > 0 Then
	'				Exit Sub
	'			Else

	'				dtDocuments = ViewState("RecievedDocument")

	'				'dtColumn = New DataColumn("DocumentDesc")
	'				'dtDocuments.Columns.Add(dtColumn)

	'				'dtColumn = New DataColumn("DocumentPath")
	'				'dtDocuments.Columns.Add(dtColumn)

	'			End If


	'		Else

	'			dtDocuments = New DataTable

	'			dtColumn = New DataColumn("DocumentDesc")
	'			dtDocuments.Columns.Add(dtColumn)

	'			dtColumn = New DataColumn("DocumentPath")
	'			dtDocuments.Columns.Add(dtColumn)



	'		End If

	'		'Dim typeID As Integer = CInt(ApprovalTypeCollection.Item(Me.ddApplicationType.SelectedItem.Text.ToString))

	'		Dim newCustomersRow As DataRow
	'		newCustomersRow = dtDocuments.NewRow()


	'		'''''getting the ID of the user selected application type

	'		'''''reviewing the collection of all the available application types from memory
	'		'If Not IsNothing(ViewState("ApprovalTypeCollection")) = True Then
	'		'	ApprovalTypeCollection = ViewState("ApprovalTypeCollection")
	'		'Else
	'		'End If
	'		'Dim typeID As Integer = CInt(ApprovalTypeCollection.Item(Me.ddApplicationType.SelectedItem.Text.ToString))

	'		If Not IsNothing(Session("documentPath")) = True Then

	'			'KeepTempAppDocument(Session("documentPath").ToString)
	'			Dim uName As String = Session("user")
	'			Dim sarrMyString As String() = Session("documentPath").ToString.Split(New String() {uName}, StringSplitOptions.None)


	'			newCustomersRow("DocumentDesc") = Me.txtDocNarration.Text
	'			newCustomersRow("DocumentPath") = sarrMyString(1).ToString.Replace("/", "")

	'			'If sarrMyString.Count = 1 Then
	'			'	sarrMyString = Session("documentPath").ToString.Split(New String() {"DBA"}, StringSplitOptions.None)
	'			'	newCustomersRow("DocumentPath") = "DBA" + sarrMyString(1).ToString
	'			'Else
	'			'	newCustomersRow("DocumentPath") = "PEN" + sarrMyString(1).ToString
	'			'	'saving the documents in a temp folder to allow auto-retrieval of document should the application was not submitted
	'			'	KeepTempAppDocument(Session("documentPath").ToString, "PEN" + sarrMyString(1).ToString, typeID, Me.ddRequiredDocuments.SelectedItem.Text.ToString)
	'			'End If

	'		Else

	'			newCustomersRow("DocumentPath") = ""

	'		End If

	'		dtDocuments.Rows.Add(newCustomersRow)

	'		ViewState("RecievedDocument") = dtDocuments
	'		Session("documentPath") = Nothing
	'		loadGrid(dtDocuments)

	'		'isVerified

	'	Catch ex As Exception

	'		Dim logerr As New Global.Logger.Logger
	'		logerr.FileSource = "NAV - Self Service Portal"
	'		logerr.FilePath = Server.MapPath("~/Logs")
	'		logerr.Logger(ex.Message)
	'		'Me.lblError.Text = "Error Adding Documents"

	'	End Try

	'End Sub


	'populating recieved document for benefit application
	Protected Sub loadGrid(dt As DataTable)
		Try

			If dt.Rows.Count > 5 Then

				'pnlUploadDetail.Height = Nothing
				'dvRecievedDocument.Style.Item("height") = Nothing

			End If

			'gridRecievedDocument.DataSource = dt
			'gridRecievedDocument.DataBind()

		Catch ex As Exception
			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)
		End Try
	End Sub


	'Protected Sub btnRemoveAllDocument_Click(sender As Object, e As EventArgs) Handles btnRemoveAllDocument.Click

	'	Dim chk As Integer = 0, cr As New Core

	'	Try

	'		If gridRecievedDocument.Rows.Count > 0 Then

	'			dvDocumentError.Visible = False
	'			For Each grow As GridViewRow In Me.gridRecievedDocument.Rows

	'				dtDocuments = ViewState("RecievedDocument")

	'				Dim filePath As String = (Server.MapPath("~/FileUploads" + "/" + Session("user") + "/" + dtDocuments.Rows(grow.RowIndex).Item("DocumentPath").ToString))

	'				ViewState("RecievedDocument") = dtDocuments
	'				Session("documentPath") = Nothing

	'				If File.Exists(filePath) = True Then
	'					File.Delete(filePath)
	'				Else

	'				End If

	'			Next
	'			'dtDocuments.Rows(0).Delete()
	'			dtDocuments.Rows.Clear()

	'			If Directory.Exists("c:\NPM_Doc_Temp\" & Session("user")) = True Then

	'				Directory.Delete("c:\NPM_Doc_Temp\" & Session("user"), True)

	'			Else

	'			End If

	'			loadGrid(dtDocuments)

	'		Else
	'		End If

	'	Catch ex As Exception

	'	End Try

	'End Sub

	'Protected Sub btnRemoveDocument_Click(sender As Object, e As EventArgs) Handles btnRemoveDocument.Click


	'	Dim cb As CheckBox, chk As Integer = 0, cr As New Core, aryIndex As New ArrayList

	'	For Each grow As GridViewRow In Me.gridRecievedDocument.Rows

	'		grow.FindControl("chkSelect")
	'		cb = grow.FindControl("chkSelect")

	'		If cb.Checked = True Then

	'			chk = chk + 1
	'			aryIndex.Add(grow.RowIndex)

	'		ElseIf cb.Checked = False Then

	'		End If

	'	Next



	'	If chk = 1 Then


	'		dvDocumentError.Visible = False
	'		For Each grow As GridViewRow In Me.gridRecievedDocument.Rows

	'			grow.FindControl("chkSelect")
	'			cb = grow.FindControl("chkSelect")

	'			If cb.Checked = True Then

	'				dtDocuments = ViewState("RecievedDocument")

	'				Dim filePath As String = (Server.MapPath("~/FileUploads" + "/" + Session("user") + "/" + dtDocuments.Rows(grow.RowIndex).Item("DocumentPath").ToString))

	'				dtDocuments.Rows(grow.RowIndex).Delete()
	'				ViewState("RecievedDocument") = dtDocuments

	'				If File.Exists(filePath) = True Then
	'					File.Delete(filePath)
	'				Else

	'				End If

	'				loadGrid(dtDocuments)

	'			ElseIf cb.Checked = False Then

	'			End If

	'		Next

	'	ElseIf chk > 1 Then





	'	Else

	'		dvDocumentError.Visible = False
	'		Exit Sub
	'	End If



	'End Sub
End Class

