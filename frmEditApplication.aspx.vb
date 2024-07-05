Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Diagnostics
Imports AjaxControlToolkit
Imports System.Net

Partial Class frmEditApplication
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





	Protected Sub calApplicationDate_SelectionChanged(sender As Object, e As EventArgs) Handles calApplicationDate.SelectionChanged

		Me.calApplicationDate_PopupControlExtender.Commit(Me.calApplicationDate.SelectedDate)

	End Sub

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

		Dim scriptManagerA As New ScriptManager, scriptManagerB As New ScriptManager, dtusers As New DataTable
		scriptManagerA = ScriptManager.GetCurrent(Me.Page)
		'scriptManagerA.RegisterPostBackControl(Me.gridRecievedDocument)


		Dim appcode As String
		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Try
			'If flReqDocUpload.IsInFileUploadPostBack Then

			If IsPostBack = False And Not Context.Request.QueryString("ApplicationCode") Is Nothing Then

				'dvUploadDocument.Visible = False
				appcode = Context.Request.QueryString("ApplicationCode") 'ApplicationTypeID
				ViewState("LeaveNumber") = appcode
				spCaption.InnerText = spCaption.InnerText & " Code : " & Context.Request.QueryString("ApplicationCode") & " IN EDIT MODE"

				Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeLeave, dtHRSetup As New DataTable

				If IsNothing(Session("dtEmployeeCard")) = True Then

					Response.Redirect("Login.aspx")

				Else
					'retrieving employee detail from session object
					dtEmployeeCard = Session("dtEmployeeCard")

					Me.txtApplicantName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName").ToString
					Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No").ToString
					Me.txtApplicantName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName").ToString
					Me.txtJobTitle.Text = dtEmployeeCard.Rows(0).Item("JobTitle").ToString
					Me.txtJobDescription.Text = dtEmployeeCard.Rows(0).Item("JobDescription").ToString
					Me.txtDepartment.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode").ToString
					Me.txtSupervisor.Text = dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString
					Me.txtSupervisorName.Text = dtEmployeeCard.Rows(0).Item("SupervisorName").ToString

					If CStr(dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString).Split("\").Count > 1 Then
						Me.txtSupervisorEmail.Text = CStr(dtEmployeeCard.Rows(0).Item("SupervisorManager").ToString).Split("\")(1) & "@leadway-pensure.com"
					Else

					End If



					Me.txtMaxLeaveDays.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveDays")
					Me.txtLeaveBalance.Text = dtEmployeeCard.Rows(0).Item("LeaveBalance")
					txtAnnualLeaveTaken.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveTaken")


				End If

				dtEmployeeLeave = NAV_Window.getLeaveApplicationForEdit(appcode)

				Me.txtApplicationDatee.Text = CDate(dtEmployeeLeave.Rows(0).Item("ApplicationDate"))
				Me.txtStartDate.Text = CDate(dtEmployeeLeave.Rows(0).Item("StartDate"))
				Me.txtAppliedDays.Text = dtEmployeeLeave.Rows(0).Item("DaysApplied")

				'dtHRSetup = NAV_Window.getHRSetup

				If IsNothing(Session("HRSetup")) = True Then
					Response.Redirect("Login.aspx")
				Else

					'Reading the Current leave period
					dtHRSetup = Session("HRSetup")
					ddLeavePeriod.Items.Clear()
					If dtHRSetup.Rows.Count > 0 Then
						'Me.txtLeavePeriod.Text = dtHRSetup.Rows(0).Item("CurLeavePeriod")
						Me.ddLeavePeriod.Items.Add("")
						Me.ddLeavePeriod.Items.Add(dtHRSetup.Rows(0).Item("CurLeavePeriod"))
						Me.ddLeavePeriod.Items.Add(CInt(dtHRSetup.Rows(0).Item("CurLeavePeriod") - 1))

					Else
					End If

				End If


				Try
					ddLeavePeriod.Text = dtEmployeeLeave.Rows(0).Item("LeavePeriod")
				Catch ex As Exception
				End Try

				Try
					'populating leaveTypes control and setting its value 
					getNAVLeaveType(dtEmployeeLeave.Rows(0).Item("LeaveType"))

				Catch ex As Exception

				End Try


				Try
					'populating employee responsibility center control and setting its value 
					getNAVRC(dtEmployeeLeave.Rows(0).Item("Responsibility_Center"))
				Catch ex As Exception
					getNAVRC("")
				End Try

				ViewState("LeaveReleaver") = dtEmployeeLeave.Rows(0).Item("Releaver")



				getReleavers(dtEmployeeCard.Rows(0).Item("DepartmentCode"))

			ElseIf IsPostBack = False And Context.Request.QueryString("ApplicationCode") Is Nothing Then

				If IsNothing(Session("user")) = True Then

					Response.Redirect("Login.aspx")

				Else
				End If
			Else


			End If


		Catch ex As Exception

			MsgBox("" & ex.Message)

		End Try




	End Sub


	Protected Sub AjaxFileDocumentUploadEvent(ByVal sender As Object, ByVal e As AjaxFileUploadEventArgs)

		Try


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


			strUploadPath = "~/FileUploads/" & Session("user") & "/" & Me.txtEmployeeNo.Text.Replace("/", "_") & "_" & filename ''& System.IO.Path.GetExtension(fullPath)


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

			'MsgBox("" & ex.Message)

		End Try

	End Sub
	'retrieving responsibilty center and populating the control on the page
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
	'populating the leaveType dropdown and setting the value from the leave object
	Protected Sub getNAVLeaveType(leaveType As String)

		Dim _leaveType As String = ""
		Dim dtLeaveTypes As New DataTable
		If IsNothing(Session("LeaveTypes")) = True Then

			Response.Redirect("Login.aspx")

		Else

			dtLeaveTypes = Session("LeaveTypes")

		End If


		Dim i As Integer = 0
		Me.ddLeaveType.Items.Clear()

		Do While i < dtLeaveTypes.Rows.Count

			If Me.ddLeaveType.Items.Count = 0 Then

				Me.ddLeaveType.Items.Add("")
				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

				If leaveType.ToUpper = dtLeaveTypes.Rows(i).Item("Code").ToString.ToUpper Then
					_leaveType = dtLeaveTypes.Rows(i).Item("Description")
				Else
				End If

			ElseIf Me.ddLeaveType.Items.Count > 0 Then

				Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
				LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

				If leaveType.ToUpper = dtLeaveTypes.Rows(i).Item("Code").ToString.ToUpper Then
					_leaveType = dtLeaveTypes.Rows(i).Item("Description")
				Else
				End If

			End If
			i = i + 1

		Loop


		Me.ddLeaveType.SelectedValue = _leaveType

	End Sub

	Protected Sub getReleavers(deptCode As String)


		Dim dtReLeavers As New DataTable

		If IsNothing(Session("ReLeavers")) = True Then

			Response.Redirect("Login.aspx")

		Else

			dtReLeavers = Session("ReLeavers")

		End If

		gridReleaver.DataSource = dtReLeavers
		gridReleaver.DataBind()
		pnlUploadDetail.Height = Nothing


	End Sub

	Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)


		'Dim btnViewDocument As New ImageButton
		'btnViewDocument = sender
		'Dim i As GridViewRow
		'i = btnViewDocument.NamingContainer

		'''''dms integration addition'''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		'Dim dtDocs As New DataTable, dmsDocumentID As String, dmsDocumentExt As String

		'Try

		'	dmsDocumentID = Me.gridRecievedDocument.Rows(i.RowIndex).Cells(2).Text
		'	'dmsDocumentExt = "JPG"
		'	dmsDocumentExt = ""

		'	Dim dms As New PaymentModuleDMSWindow.CEEntry, DMSDocumentPath As String
		'	Dim uName As String, uPWD As String, uRI As String

		'	uName = ConfigurationManager.AppSettings("DomainUserName")
		'	uPWD = ConfigurationManager.AppSettings("DomainPass")
		'	uRI = ConfigurationManager.AppSettings("FileNetURI")

		'	dms.getConnection(uName, uPWD, uRI)
		'	DMSDocumentPath = dms.GetDocument(Server.MapPath("~/FileDownLoads"), dmsDocumentID, "NAV_DOCS", "." & dmsDocumentExt)
		'	DownLoadDocument(DMSDocumentPath)


		'Catch ex As Exception

		'	'MsgBox("" & ex.Message)

		'End Try


	End Sub

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

	Protected Sub getApplicationDocuments(appCode As String)

		Dim navDoc As New NavDocs.NAV_Doc_Interface_Service
		Dim nav As New NavDocs.NAV_Doc_Interface
		Dim l As Integer = 0

		navDoc.Credentials = New NetworkCredential("coretec", "Ibukun@lag", "pensure-nigeria.com")
		navDoc.PreAuthenticate = True

		Dim navDocFilterArray As New List(Of NavDocs.NAV_Doc_Interface_Filter)
		Dim navDocFilter As New NavDocs.NAV_Doc_Interface_Filter

		navDocFilter.Field = NavDocs.NAV_Doc_Interface_Fields.Application_No
		navDocFilter.Criteria = appCode
		navDocFilterArray.Add(navDocFilter)
		Dim appDocs() As NavDocs.NAV_Doc_Interface
		appDocs = navDoc.ReadMultiple(navDocFilterArray.ToArray, "", 100)

		Dim i As Integer

		Dim dtDocuments As DataTable = New DataTable

		dtColumn = New DataColumn("DocumentDesc")
		dtDocuments.Columns.Add(dtColumn)

		dtColumn = New DataColumn("DocumentPath")
		dtDocuments.Columns.Add(dtColumn)


		Do While i < appDocs.Length

			Dim newCustomersRow As DataRow
			newCustomersRow = dtDocuments.NewRow()

			newCustomersRow("DocumentDesc") = appDocs(i).Document_Description
			newCustomersRow("DocumentPath") = appDocs(i).DocId

			dtDocuments.Rows.Add(newCustomersRow)

			i = i + 1
		Loop

		ViewState("RecievedDocument") = dtDocuments
		Session("documentPath") = Nothing
		loadGrid(dtDocuments)




	End Sub
	Protected Sub gridReleaver_RowDataBound(sender As Object, e As GridViewRowEventArgs)

		If IsNothing(Session("ReLeavers")) = False Then


			Dim dt As DataTable = Session("ReLeavers")

			If e.Row.RowType = DataControlRowType.DataRow Then

				Dim btn As New CheckBox
				btn = e.Row.FindControl("chkSelect")

				Dim str() As String = ViewState("LeaveReleaver").ToString.Split(" ")
				Array.Reverse(str)

				If dt.Rows(e.Row.RowIndex).Item("LastName").ToString = str(0) Then

					btn.Checked = True

				Else

					'e.Row.ForeColor = System.Drawing.Color.Green
					'e.Row.Enabled = False

				End If

			End If
		Else
		End If

	End Sub

	'Protected Sub getNavData2()

	'	Dim NAV_Window As New NAV_HR_WINDOW.Core
	'	Dim dtEmployees As New DataTable, dtEmployeeCard As New DataTable, dtHRSetup As New DataTable, dtRC As New DataTable, i As Integer, dtLeaveTypes As DataTable, dtReleaver As New DataTable
	'	Dim result As DataRow()
	'	'Dim user_ID As String = "PENSURE-NIGERIA\o-taiwo"
	'	Dim user_ID As String = "PENSURE-NIGERIA\" & Session("user")


	'	dtEmployees = NAV_Window.getEmployeeDetails

	'	dtHRSetup = NAV_Window.getHRSetup
	'	dtRC = NAV_Window.getResponsibiltyCenters
	'	dtLeaveTypes = NAV_Window.getLeaveTypes



	'	'result = dtEmployees.Select("UserID = 'PENSURE-NIGERIA\o-taiwo'")
	'	result = dtEmployees.Select("UserID = '" & user_ID & "'")

	'	For Each row As DataRow In result

	'		dtEmployeeCard = NAV_Window.getEmployee(row.Item(0))

	'	Next
	'	' Reading employee records
	'	If dtEmployeeCard.Rows.Count > 0 Then

	'		Me.txtEmployeeNo.Text = dtEmployeeCard.Rows(0).Item("No")
	'		Me.txtApplicantName.Text = dtEmployeeCard.Rows(0).Item("ApplicantName")
	'		Me.txtJobTitle.Text = dtEmployeeCard.Rows(0).Item("JobTitle")
	'		Me.txtJobDescription.Text = dtEmployeeCard.Rows(0).Item("JobDescription")
	'		Me.txtDepartment.Text = dtEmployeeCard.Rows(0).Item("DepartmentCode")
	'		Me.txtSupervisor.Text = dtEmployeeCard.Rows(0).Item("SupervisorManager")
	'		Me.txtSupervisorName.Text = dtEmployeeCard.Rows(0).Item("SupervisorName")
	'		Me.txtSupervisorEmail.Text = CStr(dtEmployeeCard.Rows(0).Item("SupervisorEmail")).Split("\")(1) & "@leadway-pensure.com"

	'		Me.txtMaxLeaveDays.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveDays")
	'		Me.txtLeaveBalance.Text = dtEmployeeCard.Rows(0).Item("LeaveBalance")
	'		txtAnnualLeaveTaken.Text = dtEmployeeCard.Rows(0).Item("TotalLeaveTaken")
	'		Me.txtApplicationDatee.Text = Now.Date
	'		Me.txtStartDate.Text = Now.Date
	'		Me.txtAppliedDays.Text = 0
	'		'Me.txtPayrollPeriod.Text = Now.Date
	'		'txtReturnDate.Text = Now.Date

	'	Else

	'	End If

	'	'Reading the Current leave period
	'	If dtHRSetup.Rows.Count > 0 Then
	'		Me.ddLeavePeriod.SelectedItem.Text = dtHRSetup.Rows(0).Item("CurLeavePeriod")
	'	Else

	'	End If


	'	'Reading the responsibility centers
	'	i = 0
	'	ddRC.Items.Clear()

	'	Do While i < dtRC.Rows.Count

	'		If Me.ddRC.Items.Count = 0 Then

	'			Me.ddRC.Items.Add("")
	'			Me.ddRC.Items.Add(dtRC.Rows(i).Item("Name"))
	'			RCCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))

	'		ElseIf Me.ddRC.Items.Count > 0 Then

	'			Me.ddRC.Items.Add(dtRC.Rows(i).Item("Name"))
	'			RCCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))

	'		End If
	'		i = i + 1

	'	Loop

	'	i = 0
	'	Me.ddLeaveType.Items.Clear()

	'	Do While i < dtLeaveTypes.Rows.Count

	'		If Me.ddLeaveType.Items.Count = 0 Then

	'			Me.ddLeaveType.Items.Add("")
	'			Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
	'			LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

	'		ElseIf Me.ddLeaveType.Items.Count > 0 Then

	'			Me.ddLeaveType.Items.Add(dtLeaveTypes.Rows(i).Item("Description"))
	'			LeaveTypeCollection.Add(dtLeaveTypes.Rows(i).Item("Description"), dtLeaveTypes.Rows(i).Item("Code"))

	'		End If
	'		i = i + 1

	'	Loop


	'	' reading releavers
	'	dtReleaver = NAV_Window.getEmployeeReleaver(Me.txtDepartment.Text)
	'	gridReleaver.DataSource = dtReleaver
	'	gridReleaver.DataBind()
	'	pnlUploadDetail.Height = Nothing



	'	ViewState("RCCollection") = RCCollection
	'	ViewState("LeaveTypeCollection") = LeaveTypeCollection


	'End Sub

	'Protected Sub getNAVData()


	'	Dim empCard As New EmployeeCard.EmployeeCard_Service
	'	Dim empList As New EnployeeList.EmployeeList_Service
	'	Dim LeaveC As New LeaveCard.LeaveApplication_Service
	'	Dim HRSetp As New HRSetup.HRSetup_Service
	'	Dim LeaveT As New LeaveTypes.LeaveTypes_Service
	'	Dim RC As New RCenter.ResponsibilityCenter_Service
	'	Dim LReleavers As New ReLeavers.Releavers_Service
	'	Dim NSeries As New NoSeries.NoSerialIntegration_Service


	'	Dim nc As New NetworkCredential
	'	nc.Domain = ConfigurationManager.AppSettings("DomainName")
	'	nc.UserName = ConfigurationManager.AppSettings("DomainUserName")
	'	nc.Password = ConfigurationManager.AppSettings("DomainPass")


	'	Dim prxy As New WebProxy("172.16.0.8:8080", True)
	'	prxy.Credentials = nc


	'	'empCard.UseDefaultCredentials = True


	'	empCard.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	empCard.PreAuthenticate = True


	'	'empList.UseDefaultCredentials = True


	'	empList.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	empList.PreAuthenticate = True


	'	'LeaveC.UseDefaultCredentials = True

	'	LeaveC.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	LeaveC.PreAuthenticate = True


	'	'HRSetp.UseDefaultCredentials = True

	'	HRSetp.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	HRSetp.PreAuthenticate = True

	'	'LeaveT.UseDefaultCredentials = True

	'	LeaveT.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	LeaveT.PreAuthenticate = True

	'	'RC.UseDefaultCredentials = True

	'	RC.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	RC.PreAuthenticate = True

	'	'LReleavers.UseDefaultCredentials = True

	'	LReleavers.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	LReleavers.PreAuthenticate = True


	'	'NSeries.UseDefaultCredentials = True

	'	NSeries.Credentials = New NetworkCredential(CStr(Session("user")), CStr(Session("password")), "pensure-nigeria.com")
	'	NSeries.PreAuthenticate = True


	'	Dim empListFilterArray As New List(Of EnployeeList.EmployeeList_Filter)
	'	Dim empListFilter As New EnployeeList.EmployeeList_Filter

	'	Dim empCardFilterArray As New List(Of EmployeeCard.EmployeeCard_Filter)
	'	Dim empCardFilter As New EmployeeCard.EmployeeCard_Filter

	'	Dim LeaveCFilterArray As New List(Of LeaveCard.LeaveApplication_Filter)
	'	Dim LeaveCFilter As New LeaveCard.LeaveApplication_Filter

	'	Dim HRSetupFilterArray As New List(Of HRSetup.HRSetup_Filter)
	'	Dim HRSetupFilter As New HRSetup.HRSetup_Filter

	'	Dim LeaveTFilterArray As New List(Of LeaveTypes.LeaveTypes_Filter)
	'	Dim LeaveTFilter As New LeaveTypes.LeaveTypes_Filter

	'	Dim RCFilterArray As New List(Of RCenter.ResponsibilityCenter_Filter)
	'	Dim RCFilter As New RCenter.ResponsibilityCenter_Filter

	'	Dim ReleaverFilterArray As New List(Of ReLeavers.Releavers_Filter)
	'	Dim ReleaverFilter As New ReLeavers.Releavers_Filter

	'	Dim NSeriesFilterArray As New List(Of NoSeries.NoSerialIntegration_Filter)
	'	Dim NSeriesFilter As New NoSeries.NoSerialIntegration_Filter




	'	'''''''getting series code ''''''''''''''''''''''''''''''''''''''''

	'	NSeriesFilter.Field = NoSeries.NoSerialIntegration_Fields.Code
	'	NSeriesFilter.Criteria = "LVE"
	'	NSeriesFilterArray.Add(NSeriesFilter)
	'	Dim NCRs() As NoSeries.NoSerialIntegration
	'	NCRs = NSeries.ReadMultiple(NSeriesFilterArray.ToArray, "", 100)

	'	Dim i As Integer

	'	If NCRs.Length > 0 Then
	'		'Me.txtApplicationNo.Text = NCRs(0).LastNoUsed
	'	End If

	'	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''








	'	'''''''getting responsibility Center''''''''''''''''''''''''''''''''''''''''
	'	RCFilter.Field = RCenter.ResponsibilityCenter_Fields.Code
	'	RCFilter.Criteria = "*"
	'	RCFilterArray.Add(RCFilter)
	'	Dim Rct() As RCenter.ResponsibilityCenter
	'	Rct = RC.ReadMultiple(RCFilterArray.ToArray, "", 100)

	'	i = 0
	'	ddRC.Items.Clear()

	'	Do While i < Rct.Length

	'		If Me.ddRC.Items.Count = 0 Then

	'			Me.ddRC.Items.Add("")
	'			Me.ddRC.Items.Add(Rct(i).Name)
	'			RCCollection.Add(Rct(i).Name, Rct(i).Code)

	'		ElseIf Me.ddRC.Items.Count > 0 Then

	'			Me.ddRC.Items.Add(Rct(i).Name)
	'			RCCollection.Add(Rct(i).Name, Rct(i).Code)

	'		End If
	'		i = i + 1

	'	Loop
	'	ViewState("RCCollection") = RCCollection

	'	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''





	'	'''''''getting leave types''''''''''''''''''''''''''''''''''''''''
	'	LeaveTFilter.Field = LeaveTypes.LeaveTypes_Fields.Code
	'	LeaveTFilter.Criteria = "*"
	'	LeaveTFilterArray.Add(LeaveTFilter)
	'	Dim LvType() As LeaveTypes.LeaveTypes
	'	LvType = LeaveT.ReadMultiple(LeaveTFilterArray.ToArray, "", 100)

	'	i = 0
	'	ddLeaveType.Items.Clear()
	'	Do While i < LvType.Length

	'		If Me.ddLeaveType.Items.Count = 0 Then

	'			Me.ddLeaveType.Items.Add("")
	'			Me.ddLeaveType.Items.Add(LvType(i).Description)
	'			LeaveTypeCollection.Add(LvType(i).Description, LvType(i).Code)

	'		ElseIf Me.ddLeaveType.Items.Count > 0 Then

	'			Me.ddLeaveType.Items.Add(LvType(i).Description)
	'			LeaveTypeCollection.Add(LvType(i).Description, LvType(i).Code)

	'		End If
	'		i = i + 1

	'	Loop
	'	ViewState("LeaveTypeCollection") = LeaveTypeCollection

	'	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	'	HRSetupFilter.Field = HRSetup.HRSetup_Fields.Appraisal_Nos
	'	HRSetupFilter.Criteria = "*"
	'	HRSetupFilterArray.Add(HRSetupFilter)
	'	Dim HRSet() As HRSetup.HRSetup
	'	HRSet = HRSetp.ReadMultiple(HRSetupFilterArray.ToArray, "", 100)


	'	empListFilter.Field = EnployeeList.EmployeeList_Fields.User_ID
	'	'empListFilter.Criteria = "PENSURE-NIGERIA\" & CStr(Session("user")).ToString.ToUpper
	'	empListFilter.Criteria = "*"
	'	empListFilterArray.Add(empListFilter)
	'	Dim emp() As EnployeeList.EmployeeList
	'	emp = empList.ReadMultiple(empListFilterArray.ToArray, "", 100)

	'	'MsgBox("" & emp.Length)
	'	'Exit Sub
	'	If emp.Length > 0 Then


	'		''''rertrieving the employee details'''''''''''''''''''''''''''''''''''''''''''

	'		empCardFilter.Field = EmployeeCard.EmployeeCard_Fields.No
	'		empCardFilter.Criteria = emp(0).No
	'		empCardFilterArray.Add(empCardFilter)
	'		Dim empC() As EmployeeCard.EmployeeCard
	'		empC = empCard.ReadMultiple(empCardFilterArray.ToArray, "", 100)


	'		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



	'		'''''''getting releavers''''''''''''''''''''''''''''''''''''''''
	'		ReleaverFilter.Field = ReLeavers.Releavers_Fields.Department_Code
	'		ReleaverFilter.Criteria = empC(0).Department_Code
	'		ReleaverFilterArray.Add(ReleaverFilter)

	'		'ReleaverFilter = New ReLeavers.Releavers_Filter



	'		Dim RLV() As ReLeavers.Releavers
	'		RLV = LReleavers.ReadMultiple(ReleaverFilterArray.ToArray, "", 100)

	'		gridReleaver.DataSource = Me.getdtReleaver(RLV)
	'		gridReleaver.DataBind()
	'		pnlUploadDetail.Height = Nothing
	'		'dvRLV.h()



	'		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


	'		Me.txtEmployeeNo.Text = emp(0).No
	'		Me.txtApplicantName.Text = emp(0).Last_Name & " " & emp(0).Middle_Name & " " & emp(0).First_Name
	'		Me.txtJobTitle.Text = emp(0).Job_Title
	'		Me.txtJobDescription.Text = empC(0).Job_Description
	'		Me.txtDepartment.Text = empC(0).Department_Code
	'		Me.txtSupervisor.Text = empC(0).Supervisor_Manager
	'		Me.txtSupervisorName.Text = empC(0).SupervisorNames
	'		Me.txtSupervisorEmail.Text = empC(0).Supervisor_Manager.Split("\")(1) & "@leadway-pensure.com"

	'		Me.ddLeavePeriod.SelectedItem.Text = HRSet(0).Current_Leave_Period.ToString()

	'		Me.txtMaxLeaveDays.Text = empC(0).Total_Leave_Days
	'		Me.txtLeaveBalance.Text = empC(0).Leave_Balance
	'		txtAnnualLeaveTaken.Text = empC(0).Total_Leave_Taken
	'		Me.txtApplicationDatee.Text = Now.Date
	'		Me.txtStartDate.Text = Now.Date
	'		Me.txtAppliedDays.Text = 0
	'		'	Me.txtPayrollPeriod.Text = Now.Date

	'		'	txtReturnDate.Text = Now.Date

	'		'ddLeaveType.Items.Add("")

	'	End If
	'	'emp(0).

	'	'MsgBox("" & emp.Length)

	'End Sub


	'Private Function getdtReleaver(RLV() As ReLeavers.Releavers) As DataTable

	'	Dim cr As New Core, i As Integer = 0, dtReLeaver As New DataTable

	'	If RLV.Length > 0 Then

	'		dtReLeaver = New DataTable

	'		dtColumn = New DataColumn("EmployeeNo")
	'		dtReLeaver.Columns.Add(dtColumn)

	'		dtColumn = New DataColumn("Firstname")
	'		dtReLeaver.Columns.Add(dtColumn)

	'		dtColumn = New DataColumn("MiddleName")
	'		dtReLeaver.Columns.Add(dtColumn)

	'		dtColumn = New DataColumn("LastName")
	'		dtReLeaver.Columns.Add(dtColumn)

	'		dtColumn = New DataColumn("LeaveStatus")
	'		dtReLeaver.Columns.Add(dtColumn)

	'		Do While i < RLV.Length

	'			Dim newCustomersRow As DataRow
	'			newCustomersRow = dtReLeaver.NewRow()

	'			newCustomersRow("EmployeeNo") = RLV(i).No
	'			newCustomersRow("Firstname") = RLV(i).First_Name
	'			newCustomersRow("MiddleName") = RLV(i).Middle_Name
	'			newCustomersRow("LastName") = RLV(i).Last_Name
	'			newCustomersRow("LeaveStatus") = RLV(i).Leave_Status

	'			dtReLeaver.Rows.Add(newCustomersRow)

	'			i = i + 1
	'		Loop

	'	End If
	'	Return dtReLeaver


	'End Function
	Protected Sub txtAppliedDays_TextChanged(sender As Object, e As EventArgs) Handles txtAppliedDays.TextChanged

		'Me.txtReturnDate.Text = DateAdd(DateInterval.Day, CDbl(Me.txtAppliedDays.Text), Me.txtStartDate.Text)
	End Sub

	Protected Sub gridCustomerHistory_RowDataBound()

	End Sub
	Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

		Dim cb As CheckBox, chk As Integer = 0
		Dim LeaveApp As New NAV_HR_WINDOW.LeaveCard_Service.LeaveApplication
		Dim leaveAppCls As New NAV_HR_WINDOW.LeaveApplication

		If Not IsNothing(ViewState("RCCollection")) = True Then

			RCCollection = ViewState("RCCollection")
			leaveAppCls.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))

		Else

			Exit Sub

		End If

		'Dim u As New LeaveCardd.HR_Leave_Reliver_SubForm

		For Each grow As GridViewRow In Me.gridReleaver.Rows

			cb = grow.FindControl("chkSelect")

			If cb.Checked = True Then

				leaveAppCls.Reliever = grow.Cells(1).Text

				chk += 1

			ElseIf cb.Checked = False Then

			End If
		Next

		Dim us(1) As LeaveCardd.HR_Leave_Reliver_SubForm
		'Dim us(1) As NAV_HR_WINDOW.LeaveCard_Service.HR_Leave_Reliver_SubForm

		'Dim us(1) As LeaveApp.
		'us = DirectCast(us, LeaveCard.HR_Leave_Reliver_SubForm())

		For Each grow As GridViewRow In Me.gridReleaver.Rows
			Dim u As New LeaveCardd.HR_Leave_Reliver_SubForm
			'Dim u As New NAV_HR_WINDOW.LeaveCard_Service.HR_Leave_Reliver_SubForm
			cb = grow.FindControl("chkSelect")
			If cb.Checked = True Then

				u.Application_No = LeaveApp.Application_Code
				u.Reliver_No = grow.Cells(1).Text
				u.Reliver_Name = grow.Cells(2).Text & " " & grow.Cells(3).Text & " " & grow.Cells(4).Text
				us(chk) = u
				chk += 1

			ElseIf cb.Checked = False Then

			End If

		Next

		'LeaveApp.HR_Leave_Reliver_SubForm = us
		'leaveAppCls.ReLeaverForm = us
		leaveAppCls.LeaveNumber = CStr(ViewState("LeaveNumber"))
		leaveAppCls.Application_Date = CDate(Me.txtApplicationDatee.Text)
		leaveAppCls.Employee_No = Me.txtEmployeeNo.Text
		leaveAppCls.Leave_Period = Me.ddLeavePeriod.SelectedItem.Text
		leaveAppCls.Leave_Type = Me.ddLeaveType.SelectedValue
		leaveAppCls.UserName = Session("user")
		leaveAppCls.Password = Session("password")
		leaveAppCls.Start_Date = CDate(Me.txtStartDate.Text)
		leaveAppCls.Days_Applied = CInt(Me.txtAppliedDays.Text)
		Dim NAV_WINDOW As New NAV_HR_WINDOW.Core, returnType As String



		'Dim lvAppService As LeaveCardd.LeaveApplication_Service = New LeaveCardd.LeaveApplication_Service()
		'lvAppService.Credentials = New NetworkCredential("fundadmin2", "Sunshine@123", "pensure-nigeria")
		'lvAppService.PreAuthenticate = True
		'Dim LeaveCardFilterArray As List(Of LeaveCardd.LeaveApplication_Filter) = New List(Of LeaveCardd.LeaveApplication_Filter)
		'Dim LeaveCardFilter As LeaveCardd.LeaveApplication_Filter = New LeaveCardd.LeaveApplication_Filter()
		'LeaveCardFilter.Field = LeaveCardd.LeaveApplication_Fields.Application_Code
		'LeaveCardFilter.Criteria = leaveAppCls.LeaveNumber
		'LeaveCardFilterArray.Add(LeaveCardFilter)
		'Dim results() As LeaveCardd.LeaveApplication = lvAppService.ReadMultiple(LeaveCardFilterArray.ToArray(), "", 5)

		'results(0).Application_Date = leaveAppCls.Application_Date
		'results(0).Reliever = leaveAppCls.Reliever
		'results(0).Employee_No = leaveAppCls.Employee_No
		'results(0).Leave_Period = leaveAppCls.Leave_Period
		'results(0).Leave_Type = leaveAppCls.Leave_Type
		'results(0).Responsibility_Center = leaveAppCls.Responsibility_Center
		'results(0).Start_DateSpecified = True
		'results(0).Days_AppliedSpecified = True
		'results(0).Start_Date = leaveAppCls.Start_Date
		'results(0).Days_Applied = leaveAppCls.Days_Applied
		''results(0).Status = LeaveCardd.Status.Pending_Approval
		'results(0).HR_Leave_Reliver_SubForm = us

		'Try
		'	lvAppService.Update(results(0))
		'Catch ex As Exception
		'	MsgBox("" & ex.Message)
		'	Exit Sub
		'End Try

		returnType = NAV_WINDOW.updateLeaveApplication(leaveAppCls)

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



		'mm.getNavData("")
		'	MsgBox("" & returnType)
		'Dim cacheKeyEmployeeLeaves As String = "NAVEmployeeLeavce"
		'Cache.Remove(cacheKeyEmployeeLeaves)





	End Sub




	Protected Sub calStartDate_SelectionChanged(sender As Object, e As EventArgs) Handles calStartDate.SelectionChanged

		Me.calStartDate_PopupControlExtender.Commit(Me.calStartDate.SelectedDate)

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
	'			''Where n.Item("DocumentDesc") = Me.txtDocNarration.Text
	'			Dim query = From n In ary
	'						Where n.Item("DocumentDesc") = ""
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


	'			'newCustomersRow("DocumentDesc") = Me.txtDocNarration.Text
	'			newCustomersRow("DocumentDesc") = ""
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
	'		logerr.Logger(ex.Message & "Error Attaching Document")
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


	Protected Sub ddRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddRC.SelectedIndexChanged

	End Sub

	Private Sub btnSubmit_Load(sender As Object, e As EventArgs) Handles btnSubmit.Load

	End Sub
End Class

