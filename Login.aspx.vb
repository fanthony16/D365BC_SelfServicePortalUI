Imports System.DirectoryServices.AccountManagement
Imports System.Data

Public Class Login
	Inherits System.Web.UI.Page

	Dim cacheKeyEmployees As String = "NAVEmployees"
	Dim cacheItemEmployees As Object
	Dim cacheKeyEmployee As String = "NAVEmployee"
	Dim cacheItemEmployee As Object
	Dim cacheKeyHRSetup As String = "NAVHRSetup"
	Dim cacheItemHRSetup As Object
	Dim cacheKeyLeaveTypes As String = "NAVLeaveTypes"
	Dim cacheItemLeaveTypes As Object
	Dim cacheItemEmployeeReleavers As Object
	Dim cacheKeyEmployeeReleavers As String = "NAVReLeavers"
	Dim cacheItemEmployeeCanteen As Object
	Dim cacheKeyEmployeeCanteen As String = "NAVCanteen"
	Dim cacheItemEmployeeClaim As Object
	Dim cacheKeyEmployeeClaim As String = "NAVClaim"

	Dim cacheItemEmployeeClaimType As Object
	Dim cacheKeyEmployeeClaimType As String = "NAVClaimType"

	Dim cacheItemPaymentType As Object
	Dim cacheKeyPaymentType As String = "NAVPaymentType"

	Dim cacheItemStoreItemType As Object
	Dim cacheKeyStoreItemType As String = "NAVStoreItemType"

	Dim cacheItemEmployeeStoreReq As Object
	Dim cacheKeyEmployeeStoreReq As String = "NAVStoreReq"

	Dim cacheItemEmployeePmtReq As Object
	Dim cacheKeyEmployeePmtReq As String = "NAVPmtReq"

	Dim cacheItemEmployeeLeaves As Object
	Dim cacheKeyEmployeeLeaves As String = "NAVEmpLeaves"

	Dim cacheItemEmployeeAppraisals As Object
	Dim cacheKeyEmployeeAppraisals As String = "NAVAppraisals"

	Dim cacheItemStaffAdv As Object
	Dim cacheKeyStaffAdv As String = "NAVStaffAdv"

	Dim cacheItemStaffAdvRetirement As Object
	Dim cacheKeyStaffAdvRetirement As String = "NAVStaffRetirement"

	Dim cacheItemProbationConfirmation As Object
	Dim cacheKeyProbationConfirmation As String = "NAVProbationConfirmation"

	Dim cacheItemIssueingStore As Object
	Dim cacheKeyIssueingStore As String = "NAVIssueingStore"

	Dim cacheItemLocation As Object
	Dim cacheKeyLocation As String = "NAVLocation"

	Dim cacheItemBusinessUnit As Object
	Dim cacheKeyBusinessUnit As String = "NAVBusinessUnit"

	Dim cacheItemAdvanceType As Object
	Dim cacheKeyAdvanceType As String = "NAVAdvanceType"

	Dim cacheItemVehicle As Object
	Dim cacheKeyVehicle As String = "NAVVehicle"

	Dim cacheItemAdvert As Object
	Dim cacheKeyAdvert As String = "NAVAdvert"




	Dim RCCollection, RCAppraisalCollection As New Hashtable


	Protected Sub openPage()

		'Session("user") = LTrim(RTrim(txtUserName.Text))
		'Session("password") = LTrim(RTrim(Me.txtPassword.Text))
		'Response.Redirect("frmApplicationList.aspx")

	End Sub
	Protected Sub btnlogon_Click(sender As Object, e As ImageClickEventArgs) Handles btnlogon.Click

		Dim dtEmployees, dtEmployee As New DataTable, result As DataRow()

		If Page.IsValid = True Then

			'Dim cr As New Core

			If Me.txtUserName.Text = "Admin" And Me.txtPassword.Text = "System.,@" Then
				Response.Redirect("frmUserManagement.aspx")
			Else

				Try

					Dim UFullName As String, pc As PrincipalContext, dtUser As New DataTable

					'pc = New PrincipalContext(ContextType.Domain, "PENSURE-NIGERIA.COM", RTrim(LTrim(Me.txtUserName.Text)), RTrim(LTrim(Me.txtPassword.Text)))
					'Dim uPrincipal As UserPrincipal
					'uPrincipal = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, RTrim(LTrim(Me.txtUserName.Text)))
					'UFullName = uPrincipal.DisplayName
					'If IsNothing(pc) = False Then

					If 0 = 0 Then

						Session("user") = LTrim(RTrim(txtUserName.Text))
						Session("password") = LTrim(RTrim(Me.txtPassword.Text))

						Dim user_ID As String = "PENSURE-NIGERIA\" & Session("user")
						Session("userID") = user_ID

						getNavData(user_ID)

						Try

							If IsNothing(Session("dtEmployeeCard")) = True Then

								Response.Redirect("Login.aspx")

							Else

								dtEmployee = Session("dtEmployeeCard")

							End If

							'filtering the logged on user from the list of employees
							'result = dtEmployees.Select("UserID = '" & user_ID & "'")

							If dtEmployee.Rows.Count = 0 Then

								lblogonMessage.InnerText = "Employee Not Found on NAV"
								Divlogon.Attributes.Add("class", "logonError")

							Else



								Session("user") = dtEmployee.Rows(0).Item("Title") & ". " & dtEmployee.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployee.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployee.Rows(0).Item("MiddleName").ToString.ToUpper

								Session("EmployeeNo") = CStr(dtEmployee.Rows(0).Item("No"))
								Response.Redirect("Index.aspx")

							End If

						Catch ex As Exception

							lblogonMessage.InnerText = ex.Message
							Divlogon.Attributes.Add("class", "logonError")

						End Try




						'Response.Redirect("frmApplicationList.aspx")

					Else

						lblogonMessage.InnerText = " Logon Failure...Username or Password is In-Correct!!!"
						Divlogon.Attributes.Add("class", "logonError")
						Exit Sub

					End If


				Catch ex As Exception

					lblogonMessage.InnerText = ex.Message
					Divlogon.Attributes.Add("class", "logonError")

				End Try

			End If


		End If

	End Sub

	Public Sub EmptyCacheObjects()

		cacheItemEmployees = Nothing
		cacheItemEmployee = Nothing
		cacheItemHRSetup = Nothing
		cacheItemLeaveTypes = Nothing
		cacheItemEmployeeReleavers = Nothing
		cacheItemEmployeeCanteen = Nothing
		cacheItemEmployeeClaim = Nothing
		cacheItemEmployeeLeaves = Nothing

	End Sub

	Public Sub getNavData(_userID As String)

		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtPostedEmployeeLeaves As New DataTable, result As DataRow()
		Dim dtHRSetup As New DataTable, dtRC As New DataTable, i As Integer, dtLeaveTypes As DataTable, dtReleaver As New DataTable, empDeptCode As String = "", dtCanteen As New DataTable, dtClaim As New DataTable, dtClaimTypes As New DataTable, dtStoreReq As New DataTable, dtStoreItemList As New DataTable, dtPaymentRequest As New DataTable, dtPaymentTypes As New DataTable, dtStaffAdvance As New DataTable, dtAdvanceRetirement As New DataTable, dtLocation As New DataTable, dtIssueingStore As New DataTable, dtBusinessUnit As New DataTable, dtAdvanceTypes As New DataTable, dtProbationConfirmation As New DataTable, lstAppraisalRequest As New List(Of NAV_HR_WINDOW.AppraisalRequest), userID_ As String = "", dtVehiclePayment As New DataTable, dtAdvertPayment As New DataTable

		'Try
		'	If IsNothing(cacheItemUser) = True Then
		'		cacheItemUser = _userID
		'		Cache.Insert(cacheKeyUser, cacheItemUser, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
		'	Else
		'		dtEmployees = NAV_Window.getEmployeeDetails(_userID)
		'		userID_ = Cache.Get(cacheKeyUser)
		'	End If

		'Catch ex As Exception

		'End Try

		'retrieving all employees from NAV
		Try


			'cacheItemEmployees = CType(Cache.Get(cacheKeyEmployees), DataTable)
			'If IsNothing(cacheItemEmployees) = True Then
			'	dtEmployees = NAV_Window.getEmployeeDetails(_userID)
			'	cacheItemEmployees = dtEmployees
			'	Cache.Insert(cacheKeyEmployees, cacheItemEmployees, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
			'Else
			'	dtEmployees = NAV_Window.getEmployeeDetails(_userID)
			'End If
			Session("dtEmployees") = Nothing
			If IsNothing(Session("dtEmployees")) = True Then

				dtEmployees = NAV_Window.getEmployeeDetails(_userID)

				'Dim status As Boolean
				'status = NAV_Window.getEmployeeDetail(_userID)


				Session("dtEmployees") = dtEmployees
				'Cache.Insert(cacheKeyEmployees, cacheItemEmployees, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
			Else
				dtEmployees = Session("dtEmployees")
				'dtEmployees = NAV_Window.getEmployeeDetails(_userID)
			End If


		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'creating a session object to hold the logon employee information
		'MsgBox("" & dtEmployees.Rows(0).Item("UserID").ToString())

		result = dtEmployees.Select("UserID = '" & _userID & "'")

		For Each row As DataRow In result
			dtEmployeeCard = NAV_Window.getEmployee(row.Item(0))
		Next
		Session("dtEmployeeCard") = dtEmployeeCard

		'retrieving all employees Leaves from NAV

		Try

			'cacheItemEmployeeLeaves = CType(Cache.Get(cacheKeyEmployeeLeaves), DataTable)
			'If (IsNothing(cacheItemEmployeeLeaves) = True) Then
			'	dtEmployeeLeaves = NAV_Window.getLeaveApplicationList(dtEmployeeCard.Rows(0)("No"))
			'	cacheItemEmployeeLeaves = dtEmployeeLeaves
			'	'inserting the all employee Leaves in the cache object
			'	Cache.Insert(cacheKeyEmployeeLeaves, cacheItemEmployeeLeaves, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
			'	Session("dtEmployeeLeaves") = dtEmployeeLeaves
			'Else
			'	'retrieving all employee Leaves from the cache object
			'	dtEmployeeLeaves = Cache.Get(cacheKeyEmployeeLeaves)
			'	Session("dtEmployeeLeaves") = dtEmployeeLeaves
			'End If

			Session("dtEmployeeLeaves") = Nothing

			If IsNothing(Session("dtEmployeeLeaves")) = True Then
				dtEmployeeLeaves = NAV_Window.getLeaveApplicationList(dtEmployeeCard.Rows(0)("No"))
				Session("dtEmployeeLeaves") = dtEmployeeLeaves
			Else
				dtEmployeeLeaves = Session("dtEmployeeLeaves")
			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try


		'retrieving all employees Appraisals from NAV
		Try

			'creating a cache object to hold all employee appraisals

			Dim empNo As String = dtEmployeeCard.Rows(0)("No")

			cacheItemEmployeeAppraisals = CType(Cache.Get(cacheKeyEmployeeAppraisals), DataTable)

			If IsNothing(cacheItemEmployeeAppraisals) = True Then
				lstAppraisalRequest = NAV_Window.getStaffAppraisal("", dtEmployeeCard.Rows(0)("No"))

				cacheItemEmployeeAppraisals = lstAppraisalRequest
				'inserting all employee appraisals in the cache object
				Cache.Insert(cacheKeyEmployeeAppraisals, cacheItemEmployeeAppraisals, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("AppraisalRequest") = lstAppraisalRequest
			Else
				'retrieving all employee appraisals from the cache object
				lstAppraisalRequest = Cache.Get(cacheKeyEmployeeAppraisals)
				Session("AppraisalRequest") = lstAppraisalRequest

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving HRSetup Information from NAV

		Try

			'creating a cache object to hold HRSetup Information
			cacheItemHRSetup = CType(Cache.Get(cacheKeyHRSetup), DataTable)

			If IsNothing(cacheItemHRSetup) = True Then
				dtHRSetup = NAV_Window.getHRSetup

				cacheItemHRSetup = dtHRSetup
				'inserting HRSetup Information in the cache object
				Cache.Insert(cacheKeyHRSetup, cacheItemHRSetup, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("HRSetup") = dtHRSetup
			Else
				'retrieving HRSetup Information from the cache object
				dtHRSetup = Cache.Get(cacheKeyHRSetup)
				Session("HRSetup") = dtHRSetup
			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try


		'retrieving LeaveTypes Information from NAV
		Try

			'creating a cache object to hold LeaveTypes Information
			cacheItemLeaveTypes = CType(Cache.Get(cacheKeyLeaveTypes), DataTable)

			If IsNothing(cacheItemLeaveTypes) = True Then

				dtLeaveTypes = NAV_Window.getLeaveTypes
				cacheItemLeaveTypes = dtLeaveTypes
				'inserting LeaveTypes Information in the cache object
				Cache.Insert(cacheKeyLeaveTypes, cacheItemLeaveTypes, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("LeaveTypes") = dtLeaveTypes
			Else
				'retrieving LeaveTypes Information from the cache object
				dtLeaveTypes = Cache.Get(cacheKeyLeaveTypes)
				Session("LeaveTypes") = dtLeaveTypes
			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		Try
			'Dim _str As String
			dtRC = NAV_Window.getResponsibiltyCenters("")
			'_str = NAV_Window.getResponsibiltyCenterss("")
			i = 0
			Do While i < dtRC.Rows.Count

				If Not RCCollection.ContainsKey(dtRC.Rows(i).Item("Name")) Then
					RCCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))
				Else
				End If

				i += 1
			Loop

		Catch ex As Exception

			lblogonMessage.InnerText = ex.Message
			Divlogon.Attributes.Add("class", "logonError")
			Exit Sub

		End Try
		' inserting the Responsibility center in a session object
		Session("RC") = RCCollection



		Try
			dtRC = New DataTable
			dtRC = NAV_Window.getResponsibiltyCenters("Appraisal")
			i = 0
			Do While i < dtRC.Rows.Count
				If Not RCAppraisalCollection.ContainsKey(dtRC.Rows(i).Item("Name")) Then
					RCAppraisalCollection.Add(dtRC.Rows(i).Item("Name"), dtRC.Rows(i).Item("Code"))
				Else
				End If

				i += 1
			Loop

		Catch ex As Exception

			lblogonMessage.InnerText = ex.Message
			Divlogon.Attributes.Add("class", "logonError")
			Exit Sub

		End Try
		' inserting the Responsibility center for appraisal in a session object
		Session("RCAppraisal") = RCAppraisalCollection






		'Try


		'	'Creating object for responsibility centers for the employee's department 
		'	Select Case dtEmployeeCard.Rows(0)("DepartmentCode").ToString

		'		Case Is = "ADMI"

		'			If RCCollection.Contains("ADMINISTRATION") = False Then
		'				'Me.ddRC.Items.Add("")
		'				'Me.ddRC.Items.Add("ADMINISTRATION")
		'				RCCollection.Add("ADMINISTRATION", "ADMI")
		'			Else
		'			End If

		'		Case Is = "ASM"

		'			If RCCollection.Contains("ASSET MANAGENT") = False Then

		'				RCCollection.Add("ASSET MANAGENT", "ASM")
		'			Else
		'			End If

		'		Case Is = "BDM"

		'			If RCCollection.Contains("BUSINESS DEVELOPMENT") = False Then

		'				RCCollection.Add("BUSINESS DEVELOPMENT", "BDM")

		'			Else
		'			End If

		'		Case Is = "BPU"

		'			If RCCollection.Contains("BENEFIT PROCESSG UNIT") = False Then

		'				RCCollection.Add("BENEFIT PROCESSG UNIT", "BPU")
		'			Else
		'			End If

		'		Case Is = "COMP"

		'			If RCCollection.Contains("COMPLIANCE") = False Then

		'				RCCollection.Add("COMPLIANCE", "COMP")
		'			Else
		'			End If

		'		Case Is = "CRMD"

		'			If RCCollection.Contains("SALES") = False Then

		'				RCCollection.Add("SALES", "SLS")
		'			Else
		'			End If

		'		Case Is = "CSD"

		'			If RCCollection.Contains("CUSTOMER SERVICE") = False Then

		'				RCCollection.Add("CUSTOMER SERVICE", "CMS")

		'			Else
		'			End If

		'		Case Is = "EXCO"

		'		Case Is = "FIN"

		'			If RCCollection.Contains("FINANCE") = False Then

		'				RCCollection.Add("FINANCE", "FIN")
		'			Else
		'			End If

		'		Case Is = "HR"

		'			If RCCollection.Contains("HUMAN RESOURCES") = False Then

		'				RCCollection.Add("HUMAN RESOURCES", "HR")
		'				RCCollection.Add("HUMAN RESURCES AND ADMINISTRATION", "HRAD")

		'			Else
		'			End If

		'		Case Is = "INFT"

		'			If RCCollection.Contains("INFORMATION TECHNOLOGY") = False Then

		'				RCCollection.Add("INFORMATION TECHNOLOGY", "INFT")

		'			Else
		'			End If

		'		Case Is = "INT"

		'			If RCCollection.Contains("INTERNAL CONTROL& RISK MGT") = False Then

		'				RCCollection.Add("INTERNAL CONTROL& RISK MGT", "INT")

		'			Else
		'			End If

		'		Case Is = "LGL"

		'			If RCCollection.Contains("LEGAL") = False Then

		'				RCCollection.Add("LEGAL", "LGL")

		'			Else
		'			End If

		'		Case Is = "OPS"

		'		Case Is = "RAS"

		'			If RCCollection.Contains("RISK AND STRATEGY") = False Then

		'				RCCollection.Add("RISK AND STRATEGY", "RAS")

		'			Else
		'			End If

		'		Case Else

		'	End Select
		'	' inserting the Responsibility center in a session object
		'	Session("RC") = RCCollection
		'Catch ex As Exception
		'	lblogonMessage.InnerText = "Employee Not Found on NAV"
		'	Divlogon.Attributes.Add("class", "logonError")
		'	Exit Sub
		'End Try


		'retrieving all releavers in the employee department from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemEmployeeReleavers = CType(Cache.Get(cacheKeyEmployeeReleavers), DataTable)

			If IsNothing(cacheItemEmployeeReleavers) = True Then
				dtReleaver = NAV_Window.getEmployeeReleaver(dtEmployeeCard.Rows(0)("DepartmentCode").ToString)

				cacheItemEmployeeReleavers = dtReleaver
				'inserting the all employee releavers in the cache object
				Cache.Insert(cacheKeyEmployeeReleavers, cacheItemEmployeeReleavers, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("ReLeavers") = dtReleaver

			Else
				'retrieving all employee releavers from the cache object
				dtReleaver = Cache.Get(cacheKeyEmployeeReleavers)
				Session("ReLeavers") = dtReleaver

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)


		End Try

		'retrieving employee canteen application from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemEmployeeCanteen = CType(Cache.Get(cacheKeyEmployeeCanteen), DataTable)

			'	Dim cacheItemEmployeeCanteen As Object
			'	Dim cacheKeyEmployeeCanteen As String = "NAVCanteen"

			If IsNothing(cacheItemEmployeeCanteen) = True Then
				'dtReleaver = NAV_Window.getCanteenApplication("")
				'LP/13/0196
				'MsgBox("" & dtEmployeeCard.Rows(0)("No").ToString)
				dtCanteen = NAV_Window.getCanteenApplications(dtEmployeeCard.Rows(0)("No").ToString)
				'dtCanteen = NAV_Window.getCanteenApplications("LP/13/0196")

				cacheItemEmployeeCanteen = dtCanteen
				'inserting the all employee releavers in the cache object
				Cache.Insert(cacheKeyEmployeeCanteen, cacheItemEmployeeCanteen, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("Canteen") = dtCanteen

			Else
				'retrieving all employee releavers from the cache object
				'	MsgBox("" & dtEmployeeCard.Rows(0)("No").ToString)
				dtCanteen = NAV_Window.getCanteenApplications(dtEmployeeCard.Rows(0)("No").ToString)
				'dtCanteen = Cache.Get(cacheKeyEmployeeCanteen)
				Session("Canteen") = dtCanteen

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)


		End Try


		'retrieving employee staff NAV Probation Confirmation from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemProbationConfirmation = CType(Cache.Get(cacheKeyProbationConfirmation), DataTable)

			If IsNothing(cacheItemProbationConfirmation) = True Then

				'dtCanteen = NAV_Window.getStaffClaim(dtEmployeeCard.Rows(0)("No").ToString)
				'dtClaim = NAV_Window.getStaffClaim("LP/06/0027")

				dtProbationConfirmation = NAV_Window.getProbationConfirmationList()

				cacheItemProbationConfirmation = dtClaim
				'inserting the all employee claim in the cache object
				Cache.Insert(cacheKeyProbationConfirmation, cacheItemProbationConfirmation, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("ProbationConfirmation") = dtProbationConfirmation

			Else
				'retrieving all employee claim from the cache object
				dtProbationConfirmation = Cache.Get(cacheKeyProbationConfirmation)
				Session("ProbationConfirmation") = dtProbationConfirmation

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try


		'retrieving employee staff claim application from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemEmployeeClaim = CType(Cache.Get(cacheKeyEmployeeClaim), DataTable)

			If IsNothing(cacheItemEmployeeClaim) = True Then

				'dtCanteen = NAV_Window.getStaffClaim(dtEmployeeCard.Rows(0)("No").ToString)
				'dtClaim = NAV_Window.getStaffClaim("LP/06/0027")

				dtClaim = NAV_Window.getStaffClaimList("LP/06/0027")

				cacheItemEmployeeClaim = dtClaim
				'inserting the all employee claim in the cache object
				Cache.Insert(cacheKeyEmployeeClaim, cacheItemEmployeeClaim, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("Claim") = dtClaim

			Else
				'retrieving all employee claim from the cache object
				dtClaim = Cache.Get(cacheKeyEmployeeClaim)
				Session("Claim") = dtClaim

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving employee staff claim type from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemEmployeeClaimType = CType(Cache.Get(cacheKeyEmployeeClaimType), DataTable)

			If IsNothing(cacheItemEmployeeClaimType) = True Then

				dtClaimTypes = NAV_Window.getRecieptPaymentTypeList("Claim")
				cacheItemEmployeeClaimType = dtClaimTypes
				'inserting the all employee claim type in the cache object
				Cache.Insert(cacheKeyEmployeeClaimType, cacheItemEmployeeClaimType, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("ClaimType") = dtClaimTypes
				dtClaimTypes.Select("")
			Else
				'retrieving all employee claim from the cache object
				dtClaimTypes = Cache.Get(cacheKeyEmployeeClaimType)
				Session("ClaimType") = dtClaimTypes

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving payment  type from NAV
		Try

			'creating a cache object to hold all payment types
			cacheItemPaymentType = CType(Cache.Get(cacheKeyPaymentType), DataTable)

			If IsNothing(cacheItemPaymentType) = True Then

				dtPaymentTypes = NAV_Window.getRecieptPaymentTypeList("Payment")
				cacheItemPaymentType = dtPaymentTypes
				'inserting the all payment type in the cache object
				Cache.Insert(cacheKeyPaymentType, cacheItemPaymentType, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("PaymentType") = dtPaymentTypes

			Else
				'retrieving all payment types from the cache object
				dtPaymentTypes = Cache.Get(cacheKeyPaymentType)
				Session("PaymentType") = dtPaymentTypes

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving advance  type from NAV
		Try

			'Dim cacheItemAdvanceType As Object
			'Dim cacheKeyAdvanceType As String = "NAVAdvanceType"


			'creating a cache object to hold all payment types
			cacheItemAdvanceType = CType(Cache.Get(cacheKeyAdvanceType), DataTable)

			If IsNothing(cacheItemAdvanceType) = True Then

				dtAdvanceTypes = NAV_Window.getRecieptPaymentTypeList("Advance")
				cacheItemAdvanceType = dtAdvanceTypes
				'inserting the all payment type in the cache object
				Cache.Insert(cacheKeyAdvanceType, cacheItemAdvanceType, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("AdvanceType") = dtAdvanceTypes

			Else
				'retrieving all payment types from the cache object
				dtAdvanceTypes = Cache.Get(cacheKeyAdvanceType)
				Session("AdvanceType") = dtAdvanceTypes

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving store item type from NAV
		Try

			'creating a cache object to hold all store item type
			cacheItemStoreItemType = CType(Cache.Get(cacheKeyStoreItemType), DataTable)

			If IsNothing(cacheItemStoreItemType) = True Then
				' put message here
				dtStoreItemList = NAV_Window.getItemList("Inventory")
				cacheItemStoreItemType = dtStoreItemList
				'inserting the all store item type in the cache object
				Cache.Insert(cacheKeyStoreItemType, cacheItemStoreItemType, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("StoreItemType") = dtStoreItemList

			Else
				'retrieving all employee claim from the cache object
				dtStoreItemList = Cache.Get(cacheItemStoreItemType)
				Session("StoreItemType") = dtStoreItemList

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving employee store requisition from NAV
		Try

			'creating a cache object to hold all employee releavers
			cacheItemEmployeeStoreReq = CType(Cache.Get(cacheKeyEmployeeStoreReq), DataTable)
			'cacheItemEmployeeStoreReq = Nothing
			If IsNothing(cacheItemEmployeeStoreReq) = True Then


				dtStoreReq = NAV_Window.getStoreRequisitions(CStr(Session("userID")))
				cacheItemEmployeeStoreReq = dtStoreReq

				'MsgBox("" & dtStoreReq.Rows.Count)
				'inserting the all employee store requisition in the cache object
				Cache.Insert(cacheKeyEmployeeStoreReq, cacheItemEmployeeStoreReq, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("StoreReq") = dtStoreReq


			Else
				'retrieving all employee store requisition from the cache object
				dtStoreReq = Cache.Get(cacheKeyEmployeeStoreReq)
				Session("StoreReq") = dtStoreReq

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving employee payment requisition from NAV
		Try

			'creating a cache object to hold all employee payment request
			cacheItemEmployeePmtReq = CType(Cache.Get(cacheKeyEmployeePmtReq), DataTable)
			'cacheItemEmployeeStoreReq = Nothing
			_userID = _userID.ToUpper

			If IsNothing(cacheItemEmployeePmtReq) = True Then

				'dtPaymentRequest = NAV_Window.getPaymentRequestList(_userID)
				dtPaymentRequest = NAV_Window.getPaymentVoucherList(_userID)

				cacheItemEmployeePmtReq = dtPaymentRequest



				Cache.Insert(cacheKeyEmployeePmtReq, cacheItemEmployeePmtReq, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("PmtReq") = dtPaymentRequest

			Else
				'retrieving all employee payment request from the cache object

				'dtPaymentRequest = Cache.Get(cacheKeyEmployeePmtReq)

				'dtPaymentRequest = NAV_Window.getPaymentRequestList(_userID)
				dtPaymentRequest = NAV_Window.getPaymentVoucherList(_userID)

				Session("PmtReq") = dtPaymentRequest

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving  staff advance requisition from NAV
		Try

			'creating a cache object to hold all staff advances request

			cacheItemStaffAdv = CType(Cache.Get(cacheKeyStaffAdv), DataTable)

			If IsNothing(cacheItemStaffAdv) = True Then

				'dtStaffAdvance = NAV_Window.getStaffAdvanceList(dtEmployeeCard.Rows(0)("No").ToString)
				dtStaffAdvance = NAV_Window.getStaffAdvanceList(CStr(Session("userID")))


				cacheItemStaffAdv = dtStaffAdvance

				Cache.Insert(cacheKeyStaffAdv, cacheItemStaffAdv, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("StaffAdv") = dtStaffAdvance
				'MsgBox("" & dtStaffAdvance.Rows.Count)

			Else

				'retrieving all employee payment request from the cache object

				dtStaffAdvance = Cache.Get(cacheKeyStaffAdv)

				''''remove this after testing 
				'dtStaffAdvance = NAV_Window.getStaffAdvanceList(dtEmployeeCard.Rows(0)("No").ToString)
				dtStaffAdvance = NAV_Window.getStaffAdvanceList(CStr(Session("userID")))
				''''''''''''
				Session("StaffAdv") = dtStaffAdvance
				'MsgBox("" & dtStaffAdvance.Rows.Count)


			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try


		'retrieving  staff advance retirement from NAV
		Try

			'creating a cache object to hold all staff advances request

			'Dim cacheItemStaffAdvRetirement As Object
			'Dim cacheKeyStaffAdvRetirement As String = "NAVStaffRetirement"

			cacheItemStaffAdvRetirement = CType(Cache.Get(cacheKeyStaffAdvRetirement), DataTable)

			If IsNothing(cacheItemStaffAdvRetirement) = True Then

				dtAdvanceRetirement = NAV_Window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)
				cacheItemStaffAdvRetirement = dtAdvanceRetirement

				Cache.Insert(cacheKeyStaffAdvRetirement, cacheItemStaffAdvRetirement, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVStaffRetirement") = dtAdvanceRetirement
				'MsgBox("" & dtStaffAdvance.Rows.Count)

			Else

				'retrieving all employee payment request from the cache object

				dtAdvanceRetirement = Cache.Get(cacheKeyStaffAdvRetirement)

				''''remove this after testing 
				dtAdvanceRetirement = NAV_Window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)
				''''''''''''
				Session("NAVStaffRetirement") = dtAdvanceRetirement
				'MsgBox("" & dtStaffAdvance.Rows.Count)


			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try


		'retrieving  IssueingStore from NAV
		Try

			cacheItemIssueingStore = CType(Cache.Get(cacheKeyIssueingStore), DataTable)

			If IsNothing(cacheItemIssueingStore) = True Then

				dtIssueingStore = NAV_Window.getIssueingStore()
				cacheItemIssueingStore = dtIssueingStore

				Cache.Insert(cacheKeyIssueingStore, cacheItemIssueingStore, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVIssueingStore") = dtIssueingStore

			Else

				'retrieving all issueing store from the cache object
				dtIssueingStore = Cache.Get(cacheKeyIssueingStore)
				Session("NAVIssueingStore") = dtIssueingStore


			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving  locations from NAV
		Try

			'Dim cacheItemLocation As Object
			'Dim cacheKeyLocation As String = "NAVLocation"

			cacheItemLocation = CType(Cache.Get(cacheKeyLocation), DataTable)

			If IsNothing(cacheItemLocation) = True Then

				dtLocation = NAV_Window.getLocationCode("1")
				dtVehiclePayment = NAV_Window.getLocationCode("4")
				dtAdvertPayment = NAV_Window.getLocationCode("6")

				cacheItemLocation = dtLocation
				cacheItemVehicle = dtVehiclePayment
				cacheItemAdvert = dtAdvertPayment

				Cache.Insert(cacheKeyLocation, cacheItemLocation, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVLocation") = dtLocation

				Cache.Insert(cacheKeyVehicle, cacheItemVehicle, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVVehicle") = dtVehiclePayment

				Cache.Insert(cacheKeyAdvert, cacheItemAdvert, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVAdvert") = dtAdvertPayment


			Else

				'retrieving all location from the cache object

				dtLocation = Cache.Get(cacheKeyLocation)

				dtVehiclePayment = Cache.Get(cacheKeyVehicle)

				dtAdvertPayment = Cache.Get(cacheKeyAdvert)

				''''remove this after testing 
				'dtLocation = NAV_Window.getLocationCode("1")
				''''''''''''
				Session("NAVLocation") = dtLocation

				Session("NAVVehicle") = dtVehiclePayment

				Session("NAVAdvert") = dtAdvertPayment
				'MsgBox("" & dtStaffAdvance.Rows.Count)


			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving  Business Unit from NAV
		Try

			cacheItemBusinessUnit = CType(Cache.Get(cacheKeyBusinessUnit), DataTable)

			If IsNothing(cacheItemBusinessUnit) = True Then

				dtBusinessUnit = NAV_Window.getLocationCode("2")
				cacheItemBusinessUnit = dtBusinessUnit

				Cache.Insert(cacheKeyBusinessUnit, cacheItemBusinessUnit, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVBusinessUnit") = dtBusinessUnit

			Else

				'retrieving all location from the cache object

				dtBusinessUnit = Cache.Get(cacheKeyBusinessUnit)

				''''remove this after testing 
				dtBusinessUnit = NAV_Window.getLocationCode("2")
				''''''''''''
				Session("NAVBusinessUnit") = dtBusinessUnit



			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving  Vehicle Class payment category from NAV
		Try

			cacheItemVehicle = CType(Cache.Get(cacheKeyVehicle), DataTable)

			If IsNothing(cacheItemVehicle) = True Then

				dtVehiclePayment = NAV_Window.getPaymentCodes("VEHICLE")
				cacheItemVehicle = dtVehiclePayment

				Cache.Insert(cacheKeyVehicle, cacheItemVehicle, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVVehiclePayment") = dtVehiclePayment

			Else

				'retrieving all location from the cache object

				dtVehiclePayment = Cache.Get(cacheKeyVehicle)

				''''remove this after testing 
				dtVehiclePayment = NAV_Window.getPaymentCodes("VEHICLE")
				''''''''''''
				Session("NAVVehiclePayment") = dtVehiclePayment

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try

		'retrieving  Advert Class payment category from NAV
		Try

			cacheItemAdvert = CType(Cache.Get(cacheKeyAdvert), DataTable)

			If IsNothing(cacheItemAdvert) = True Then

				dtAdvertPayment = NAV_Window.getPaymentCodes("ADVERTS")
				cacheItemAdvert = dtAdvertPayment

				Cache.Insert(cacheKeyAdvert, cacheItemAdvert, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
				Session("NAVAdvertPayment") = dtAdvertPayment

			Else

				'retrieving all location from the cache object

				dtAdvertPayment = Cache.Get(cacheKeyAdvert)

				''''remove this after testing 
				dtAdvertPayment = NAV_Window.getPaymentCodes("ADVERTS")
				''''''''''''
				Session("NAVAdvertPayment") = dtAdvertPayment

			End If

		Catch ex As Exception

			Dim logerr As New Global.Logger.Logger
			logerr.FileSource = "NAV - Self Service Portal"
			logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
			logerr.Logger(ex.Message)

		End Try



	End Sub

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

		Dim scriptManagerA As New ScriptManager, dtusers As New DataTable


		'Dim num_ As Decimal
		'num_ = "19800.00"
		'MsgBox(" " & num_.ToString("N###,0##.00"))
		'Exit Sub

		'txtAmount.Text = dtHrSetup.Rows(0).Item("MealAmount").ToString("N###,0##.00")

		scriptManagerA = ScriptManager.GetCurrent(Me.Page)


		Try

			If IsPostBack = False Then


			Else

			End If

		Catch ex As Exception

		End Try

	End Sub

	Protected Sub getEmployeeList()
		'NAV_HR_WINDOW.Core
		Dim NAV_Window As New NAV_HR_WINDOW.Core
		Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtPostedEmployeeLeaves As New DataTable, result As DataRow()

		Try

			cacheItemEmployees = CType(Cache.Get(cacheKeyEmployees), DataTable)

			If IsNothing(cacheItemEmployees) = True Then
				dtEmployees = NAV_Window.getEmployeeDetails("")

				cacheItemEmployees = dtEmployees
				Cache.Insert(cacheKeyEmployees, cacheItemEmployees, Nothing, DateTime.Now.AddSeconds(300), TimeSpan.Zero)
			Else
				dtEmployees = Cache.Get(cacheKeyEmployees)

			End If

		Catch ex As Exception

			'MsgBox("" & ex.Message)

		End Try



	End Sub

End Class
