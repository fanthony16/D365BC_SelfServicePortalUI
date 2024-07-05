Imports NAV_HR_WINDOW
Imports System.Data
Imports System.IO

Partial Class frmStaffAdvance
    Inherits System.Web.UI.Page
    Dim LinesKeys As New List(Of String)
    Dim RCCollection As New Hashtable
    Dim dtAttachment As New DataTable

    Protected Sub gridAdvanceRequest_RowDataBound()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub LoadGridAdvReqLines(dt As DataTable)

        ViewState("AdvReqLines") = dt
        Me.gridAdvanceRequest.DataSource = dt
        gridAdvanceRequest.DataBind()

    End Sub

    Protected Sub populateLineType()
        Dim dtAdvanceTypes As New DataTable, i As Integer

        ' Session("AdvanceType") = dtAdvanceTypes

        dtAdvanceTypes = Session("AdvanceType")


        Do While i < dtAdvanceTypes.Rows.Count

            If Me.ddLine_Type.Items.Count = 0 Then

                ddLine_Type.Items.Add("")
                ddLine_Type.Items.Add(dtAdvanceTypes.Rows(i).Item("AdvanceType"))

            Else

                ddLine_Type.Items.Add(dtAdvanceTypes.Rows(i).Item("AdvanceType"))

            End If

            i = i + 1
        Loop

    End Sub

    Protected Sub populateLocation()

        Dim dtLocation As New DataTable, i As Integer

        dtLocation = Session("NAVLocation")

        Do While i < dtLocation.Rows.Count

            If Me.ddLocation.Items.Count = 0 Then

                ddLocation.Items.Add("")
                ddLocation.Items.Add(dtLocation.Rows(i).Item("Name").ToString())

            Else

                ddLocation.Items.Add(dtLocation.Rows(i).Item("Name").ToString())

            End If

            i += 1
        Loop

    End Sub

    Protected Sub populateBusinessUnit()

        Dim dtBusinessUnit As New DataTable, i As Integer

        dtBusinessUnit = Session("NAVBusinessUnit")

        Do While i < dtBusinessUnit.Rows.Count

            If Me.ddBusinessUnit.Items.Count = 0 Then

                ddBusinessUnit.Items.Add("")
                ddBusinessUnit.Items.Add(dtBusinessUnit.Rows(i).Item("Name").ToString())

            Else

                ddBusinessUnit.Items.Add(dtBusinessUnit.Rows(i).Item("Name").ToString())

            End If

            i += 1
        Loop

    End Sub

    Protected Sub populateStatus()

        ddStatus.Items.Clear()
        Me.ddStatus.Items.Add("")
        Me.ddStatus.Items.Add("Approved")
        Me.ddStatus.Items.Add("Cancelled")
        Me.ddStatus.Items.Add("Checking")
        Me.ddStatus.Items.Add("Cheque_Printing")
        Me.ddStatus.Items.Add("Pending")
        Me.ddStatus.Items.Add("Pending_Approval")
        Me.ddStatus.Items.Add("Posted")
        Me.ddStatus.Items.Add("Rejected")

    End Sub


    'Protected Sub populatePaymentMode()

    '    ddPay_Mode.Items.Clear()
    '    Me.ddPay_Mode.Items.Add("")
    '    Me.ddPay_Mode.Items.Add("Cash")
    '    Me.ddPay_Mode.Items.Add("Cheque")
    '    Me.ddPay_Mode.Items.Add("_blank_")

    'End Sub

    'Protected Sub populateChequeType()

    '    ddCheque_Type.Items.Clear()
    '    Me.ddCheque_Type.Items.Add("")
    '    Me.ddCheque_Type.Items.Add("Computer_Check")
    '    Me.ddCheque_Type.Items.Add("Manual_Check")
    '    Me.ddCheque_Type.Items.Add("_blank_")

    'End Sub

    Private Sub frmStaffAdvance_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtusers As New DataTable
        Dim RequestNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core

        ScriptManager.GetCurrent(Me).RegisterPostBackControl(Me.btnAddDocument)

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
                    'populatePaymentMode()
                    'populateChequeType()
                    populateLineType()
                    populateLocation()
                    populateBusinessUnit()
                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")

                    Dim _CashAdvanceRequest As New NAV_HR_WINDOW.CashAdvanceRequest
                    _CashAdvanceRequest = NAV_Window.getStaffAdvance(RequestNo)
                    getNAVRC(_CashAdvanceRequest.Responsibility_Center)
                    Me.txtdocumentID_attachment.Text = _CashAdvanceRequest.DocumentNo
                    Me.txtDocumentNo.Text = _CashAdvanceRequest.DocumentNo
                    Me.txtCashier.Text = _CashAdvanceRequest.Cashier
                    '  Me.txtCheque_No.Text = _CashAdvanceRequest.Cheque_No
                    ' Me.ddCheque_Type.Text = _CashAdvanceRequest.Cheque_Type
                    Me.ddStatus.Text = _CashAdvanceRequest.Status
                    ' Me.ddPay_Mode.Text = _CashAdvanceRequest.Pay_Mode.ToString
                    Me.txtPayee.Text = _CashAdvanceRequest.Payee
                    Me.txtPayee_Account_Number.Text = _CashAdvanceRequest.Payee_Account_Number
                    ' Me.txtPaying_Bank_Account.Text = _CashAdvanceRequest.Paying_Bank_Account
                    'Me.txtPayment_Narration.Text = _CashAdvanceRequest.Payment_Narration

                    Dim dtBusinessUnit As New DataTable
                    dtBusinessUnit = Session("NAVBusinessUnit")

                    Me.ddBusinessUnit.Text = dtBusinessUnit.Select("Code = '" & _CashAdvanceRequest.BusinessUnit & "'")(0).Item("Name")

                    Me.ddLocation.Text = _CashAdvanceRequest.LocationCode

                    Me.ddRC.Text = _CashAdvanceRequest.Responsibility_Center
                    Me.txtRequestdate.Text = _CashAdvanceRequest.RequestDate
                    'Me.txtPayment_Release_Date.Text = _CashAdvanceRequest.Payment_Release_Date
                    Me.txtNetAmount.Text = _CashAdvanceRequest.Total_Payment_Amount



                    '_StoreRequisition.StoreRequisitionLines(0).Unit_of_Measure

                    Dim dt As New DataTable, i As Integer

                    dt.Columns.Add(New DataColumn("LineNo", GetType(String)))
                    dt.Columns.Add(New DataColumn("Account_No", GetType(String)))
                    dt.Columns.Add(New DataColumn("Account_Name", GetType(String)))
                    dt.Columns.Add(New DataColumn("Advance_Type", GetType(String)))
                    dt.Columns.Add(New DataColumn("Advance_Narration", GetType(String)))
                    dt.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("Date_Issued", GetType(DateTime)))
                    dt.Columns.Add(New DataColumn("Due_Date", GetType(DateTime)))
                    dt.Columns.Add(New DataColumn("txtKey", GetType(String)))

                    Do While i < _CashAdvanceRequest.CashAdvanceRequestLines.Length

                        dt.Rows.Add(_CashAdvanceRequest.CashAdvanceRequestLines(i).No, _CashAdvanceRequest.CashAdvanceRequestLines(i).Account_No, _CashAdvanceRequest.CashAdvanceRequestLines(i).Account_Name, _CashAdvanceRequest.CashAdvanceRequestLines(i).Advance_Type, _CashAdvanceRequest.CashAdvanceRequestLines(i).Advance_Narration, _CashAdvanceRequest.CashAdvanceRequestLines(i).Amount, _CashAdvanceRequest.CashAdvanceRequestLines(i).Date_Issued, _CashAdvanceRequest.CashAdvanceRequestLines(i).Due_Date, _CashAdvanceRequest.CashAdvanceRequestLines(i).Key)

                        LinesKeys.Add(_CashAdvanceRequest.CashAdvanceRequestLines(i).Key)

                        i += 1

                    Loop

                    ViewState("LinesKey") = LinesKeys
                    LoadGridAdvReqLines(dt)

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then






                If IsNothing(Session("user")) = True Then

                    Response.Redirect("Login.aspx")

                Else

                    populateStatus()
                    '  populatePaymentMode()
                    ' populateChequeType()
                    populateLineType()
                    getNAVRC("")
                    populateLocation()
                    populateBusinessUnit()
                    Dim dtEmployeeCard As New DataTable
                    Me.txtCashier.Text = CStr(Session("userID")).ToUpper

                    dtEmployeeCard = Session("dtEmployeeCard")

                    Me.txtPayee_Account_Number.Text = dtEmployeeCard.Rows(0).Item(0).ToString

                    txtCashier.Text = dtEmployeeCard.Rows(0).Item("UserID").ToString

                    txtPayee.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("MiddleName").ToString.ToUpper

                    'tblEmployee.Columns.Add(New DataColumn("UserID", TypeOf (String)));
                    'tblEmployee.Columns.Add(New DataColumn("FirstName", TypeOf (String)));
                    'tblEmployee.Columns.Add(New DataColumn("MiddleName", TypeOf (String)));
                    'tblEmployee.Columns.Add(New DataColumn("LastName", TypeOf (String)));


                End If
            Else


            End If


        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub
    Protected Sub gridDocumentAttachment_RowDataBound()

    End Sub
    Protected Sub LoadGridDocumentLines(dt As DataTable)

        ViewState("dtAttachment") = dt
        Me.gridFileAttachment.DataSource = dt
        gridFileAttachment.DataBind()

    End Sub
    Protected Sub RemoveFile()
        Dim dtAttachment As New DataTable
        Try

            If IsNothing(ViewState("selectedFileRowIndex")) = False Then

                dtAttachment = ViewState("dtAttachment")
                dtAttachment.Rows(CInt(ViewState("selectedFileRowIndex"))).Delete()
                LoadGridDocumentLines(dtAttachment)

            Else

            End If

        Catch ex As Exception

        End Try


    End Sub
    Protected Sub UploadFile()

        mpDocumentAttachment.Show()

    End Sub

    'retrieving responsibilty center and populating the control on the page
    Protected Sub getNAVRC(rc As String)

        Dim dtRC As New DataTable
        ' Dim RCCollection As New Hashtable
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
            '    _rcc = (RCCollection.Keys(i).ToString())
            'Else
            'End If

            i += 1
        Loop

        ' Me.ddRC.SelectedValue = _rcc.ToString()

        Dim strRCKey As ICollection
        strRCKey = RCCollection.Keys

        Dim j As Integer = 0

        Do While j < strRCKey.Count

            If (RCCollection.Item(strRCKey(j)).ToString = rc) = True Then
                Me.ddRC.Text = strRCKey(j)
            Else
            End If
            j = j + 1
        Loop


    End Sub


    Protected Sub gridAdvanceRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridAdvanceRequest.SelectedIndexChanged

        Dim selectedRowIndex As Integer, dtAdvanceTypes As New DataTable, result As DataRow()
        selectedRowIndex = Me.gridAdvanceRequest.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex
        Dim row As GridViewRow = gridAdvanceRequest.Rows(selectedRowIndex)

        Try

            Me.ddLine_Type.Text = row.Cells(4).Text.ToString()

        Catch ex As Exception

        End Try

        ' Me.txtPayment_Narration_Line.Text = row.Cells(5).Text.ToString()
        Me.txtAmount.Text = row.Cells(5).Text.ToString()

        dtAdvanceTypes = Session("AdvanceType")

        Try

            result = dtAdvanceTypes.Select("AdvanceType = '" & row.Cells(4).Text.ToString() & "'")
            Me.txtAccountType.Text = result(0).Item("AccountType").ToString
            Me.txtAccount_No.Text = result(0).Item("AccountNo").ToString
            Me.txtAccountName.Text = result(0).Item("AccountName").ToString

        Catch ex As Exception
            'MsgBox("" & ex.Message())
        End Try



    End Sub

    Private Sub ddLine_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddLine_Type.SelectedIndexChanged

        Dim result As DataRow(), dtClaimTypes As New DataTable
        dtClaimTypes = Session("AdvanceType")

        result = dtClaimTypes.Select("AdvanceType = '" & ddLine_Type.Text & "'")
        Me.txtAccountType.Text = result(0).Item("AccountType").ToString
        Me.txtAccount_No.Text = result(0).Item("AccountNo").ToString
        Me.txtAccountName.Text = result(0).Item("AccountName").ToString

    End Sub

    Protected Sub ClearLine()

        ' Me.txtInvoiceNo.Text = ""
        Me.ddLine_Type.Text = ""
        Me.txtAccountType.Text = ""
        Me.txtAccount_No.Text = ""
        Me.txtAccountName.Text = ""
        'Me.txtPayment_Narration_Line.Text = ""
        'Me.txtDueDate.Text = ""
        Me.txtAmount.Text = "0"
        ViewState("selectedRowIndex") = Nothing


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try

            Dim _DataRow As DataRow

            If IsNothing(ViewState("selectedRowIndex")) = True Then

                Dim dtPVLines As New DataTable

                If IsNothing(ViewState("AdvReqLines")) = True Then

                    dtPVLines.Columns.Add(New DataColumn("LineNo", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Account_No", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Account_Name", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Advance_Type", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Advance_Narration", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
                    dtPVLines.Columns.Add(New DataColumn("Date_Issued", GetType(DateTime)))
                    dtPVLines.Columns.Add(New DataColumn("Due_Date", GetType(DateTime)))
                    dtPVLines.Columns.Add(New DataColumn("txtKey", GetType(String)))

                Else

                    dtPVLines = ViewState("AdvReqLines")

                End If

                Try
                    _DataRow = dtPVLines.NewRow
                    _DataRow("LineNo") = Me.txtDocumentNo.Text
                    _DataRow("Account_No") = Me.txtAccount_No.Text
                    _DataRow("Account_Name") = Me.txtAccountName.Text
                    _DataRow("Advance_Type") = Me.ddLine_Type.Text
                    _DataRow("Advance_Narration") = ""
                    _DataRow("Amount") = Me.txtAmount.Text
                    _DataRow("Date_Issued") = Now.Date
                    _DataRow("Due_Date") = Now.Date
                    _DataRow("txtKey") = ""

                    dtPVLines.Rows.Add(_DataRow)
                    LoadGridAdvReqLines(dtPVLines)

                    ClearLine()

                Catch ex As Exception

                    Dim logerr As New Global.Logger.Logger
                    logerr.FileSource = "NAV - Self Service Portal"
                    logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
                    logerr.Logger(ex.Message)

                End Try


            Else

                Dim selectedRowIndex As Integer, dtPVLines As New DataTable
                If IsNothing(ViewState("selectedRowIndex")) = False Then
                    selectedRowIndex = ViewState("selectedRowIndex")
                Else
                End If

                dtPVLines = ViewState("AdvReqLines")
                _DataRow = dtPVLines.Rows(selectedRowIndex)
                _DataRow("LineNo") = Me.txtDocumentNo.Text
                _DataRow("Account_No") = Me.txtAccount_No.Text
                _DataRow("Account_Name") = Me.txtAccountName.Text
                _DataRow("Advance_Type") = Me.ddLine_Type.Text
                _DataRow("Advance_Narration") = ""
                _DataRow("Amount") = Me.txtAmount.Text
                _DataRow("Date_Issued") = Now.Date
                _DataRow("Due_Date") = Now.Date
                '_DataRow("txtKey") = Me.txtAmount.Text

                LoadGridAdvReqLines(dtPVLines)
                ClearLine()



            End If


        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        Try

            If IsNothing(ViewState("selectedRowIndex")) = True Then

            Else

                Dim selectedRowIndex As Integer, dtPVLines As New DataTable
                If IsNothing(ViewState("selectedRowIndex")) = False Then
                    selectedRowIndex = ViewState("selectedRowIndex")
                Else
                End If

                dtPVLines = ViewState("AdvReqLines")
                dtPVLines.Rows(selectedRowIndex).Delete()
                LoadGridAdvReqLines(dtPVLines)
                ClearLine()

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            Dim dtLocation As DataTable = Session("NAVLocation")
            Dim dtBusinessUnit As DataTable = Session("NAVBusinessUnit")
            Dim NAV_window As New NAV_HR_WINDOW.Core
            Dim lineCount As Integer = 0

            Dim StaffAdvlines_() As StaffAdvanceRequest_Service.Staff_Advance_Lines
            ReDim StaffAdvlines_(Me.gridAdvanceRequest.Rows.Count - 1)

            If IsNothing(ViewState("LinesKey")) = False Then
                LinesKeys = ViewState("LinesKey")
            Else
            End If

            If Not IsNothing(ViewState("RCCollection")) = True Then

                RCCollection = ViewState("RCCollection")
            Else
                Response.Redirect("login.aspx")
            End If

            Do While lineCount < Me.gridAdvanceRequest.Rows.Count

                Dim StaffAdvline As StaffAdvanceRequest_Service.Staff_Advance_Lines = New StaffAdvanceRequest_Service.Staff_Advance_Lines

                'StaffAdvline.Account_No = gridAdvanceRequest.Rows(lineCount).Cells(2).Text.ToString
                StaffAdvline.Account_Name = gridAdvanceRequest.Rows(lineCount).Cells(3).Text.ToString
                StaffAdvline.Advance_Type = gridAdvanceRequest.Rows(lineCount).Cells(4).Text.ToString
                ' StaffAdvline.Advance_Narration = gridAdvanceRequest.Rows(lineCount).Cells(5).Text.ToString
                StaffAdvline.Amount = gridAdvanceRequest.Rows(lineCount).Cells(5).Text.ToString
                StaffAdvline.AmountSpecified = True

                If gridAdvanceRequest.Rows(lineCount).Cells(6).Text = "&nbsp;" Then

                    StaffAdvlines_(lineCount) = StaffAdvline

                Else

                    If LinesKeys.Contains(gridAdvanceRequest.Rows(lineCount).Cells(6).Text) = True Then

                        NAV_window.DeleteAdvanceRequestLine(gridAdvanceRequest.Rows(lineCount).Cells(6).Text)
                        StaffAdvlines_(lineCount) = StaffAdvline
                        LinesKeys.RemoveAt(LinesKeys.IndexOf(gridAdvanceRequest.Rows(lineCount).Cells(6).Text))

                    End If

                End If

                lineCount += 1

            Loop

            Dim i As Integer = 0

            Do While i < LinesKeys.Count
                'deleting sraff claim lines removed by the user
                NAV_window.DeletePaymentRequestLine(LinesKeys.Item(i))
                i += 1
            Loop

            Dim _cashAdvanceRequest As CashAdvanceRequest = New CashAdvanceRequest With {
             .Bank_Name = "",
             .Budget_Center_Name = "",
             .Cashier = Me.txtCashier.Text,
             .Cheque_No = "",
             .DocumentNo = Me.txtDocumentNo.Text,
             .Function_Name = "",
             .On_Behalf_Of = "",
             .Payee = Me.txtPayee.Text,
             .Payee_Account_Number = Me.txtPayee_Account_Number.Text,
             .Paying_Bank_Account = "",
             .Payment_Narration = "",
             .RequestDate = Me.txtRequestdate.Text,
             .Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text)),
             .Status = Me.ddStatus.Text,
             .Total_Payment_Amount = 0,
             .Total_Payment_Amount_LCY = 0,
            .Total_Retention_Amount = 0,
            .Total_VAT_Amount = 0,
            .Total_Witholding_Tax_Amount = 0,
            .Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = 0,
             .CashAdvanceRequestLines = StaffAdvlines_,
             .LocationCode = dtLocation.Select("Name = '" & Me.ddLocation.Text & "'")(0).Item(0).ToString,
             .BusinessUnit = dtBusinessUnit.Select("Name = '" & Me.ddBusinessUnit.Text & "'")(0).Item(0).ToString,
             .UserID = CStr(Session("userID"))
            }

            'result = dtEmployees.Select("UserID = '" & _userID & "'")

            If Me.txtDocumentNo.Text <> "" Then

                Dim _status As String = NAV_window.UpdateAdvanceRequest(_cashAdvanceRequest)
                Dim dtAdvanceRequest As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
                dtAdvanceRequest = NAV_window.getStaffAdvanceList(CStr(Session("userID")))
                Session("StaffAdv") = dtAdvanceRequest
                Response.Redirect("frmStaffAdvanceList.aspx")

            Else

                Dim _status As String = NAV_window.CreateAdvanceRequest(_cashAdvanceRequest)


                Dim dtAdvanceRequest As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
                dtAdvanceRequest = NAV_window.getStaffAdvanceList(CStr(Session("userID")))
                Session("StaffAdv") = dtAdvanceRequest
                Response.Redirect("frmStaffAdvanceList.aspx")

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Protected Sub calRequestdate_SelectionChanged(sender As Object, e As EventArgs) Handles calRequestdate.SelectionChanged

        Me.calRequestdate_PopupControlExtender.Commit(Me.calRequestdate.SelectedDate)


    End Sub

    Private Sub btnAddDocument_Click(sender As Object, e As EventArgs) Handles btnAddDocument.Click

        dtAttachment = ViewState("dtAttachment")
        Dim _fileName, _fileExt As String, fileCount As Integer
        fileCount = Me.gridFileAttachment.Rows.Count

        If FileUpload1.HasFile = True Then

            _fileName = Me.txtdocumentID_attachment.Text.Replace("-", "_") & "_" & (fileCount + 1).ToString()

            _fileExt = FileUpload1.PostedFile.FileName.ToString().Split(".")(1)

        Else

            Exit Sub

        End If

        Try

            Dim _DataRow As DataRow

            If IsNothing(ViewState("selectedFileRowIndex")) = True Then

                Dim dtDocumentLines As New DataTable

                If IsNothing(ViewState("dtAttachment")) = True Then

                    ' dtDocumentLines.Columns.Add(New DataColumn("DocumentNo", GetType(String)))
                    dtDocumentLines.Columns.Add(New DataColumn("FileName", GetType(String)))
                    dtDocumentLines.Columns.Add(New DataColumn("FileType", GetType(String)))
                    dtDocumentLines.Columns.Add(New DataColumn("txtBase64String", GetType(String)))

                Else

                    dtDocumentLines = ViewState("dtAttachment")

                End If

                Try

                    _DataRow = dtDocumentLines.NewRow
                    '_DataRow("DocumentNo") = ""
                    _DataRow("FileName") = _fileName
                    _DataRow("FileType") = _fileExt
                    _DataRow("txtBase64String") = Me.getBase64String(_fileName & "." & _fileExt)


                    dtDocumentLines.Rows.Add(_DataRow)
                    LoadGridDocumentLines(dtDocumentLines)
                    '  ClearLine()

                Catch ex As Exception

                    Dim logerr As New Global.Logger.Logger
                    logerr.FileSource = "NAV - Self Service Portal"
                    logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
                    logerr.Logger(ex.Message)

                End Try
            Else

                Dim selectedFileRowIndex As Integer, dtPVLines As New DataTable
                If IsNothing(ViewState("selectedFileRowIndex")) = False Then
                    selectedFileRowIndex = ViewState("selectedFileRowIndex")
                Else
                End If

                dtAttachment = ViewState("dtAttachment")
                'dtPVLines.Rows(selectedRowIndex).Delete()
                _DataRow = dtAttachment.Rows(selectedFileRowIndex)

                ' _DataRow("DocumentNo") = ""
                _DataRow("FileName") = _fileName
                _DataRow("FileType") = _fileExt
                _DataRow("txtBase64String") = Me.getBase64String(_fileName & "." & _fileExt)

                LoadGridDocumentLines(dtAttachment)
                ClearLine()

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Protected Function getBase64String(fileName As String) As String

        Try

            If FileUpload1.HasFile = True Then

                Dim fs As System.IO.Stream = FileUpload1.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                fs.Close()
                br.Close()

                Dim docPath As String = ConfigurationManager.AppSettings("DocumentPath")
                File.WriteAllBytes(docPath + fileName, Convert.FromBase64String(base64String))
                Return base64String

            Else

                Return ""

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Function

End Class
