Imports NAV_HR_WINDOW
Imports System.Data
Imports System.IO

Partial Class frmPaymentRequest
    Inherits System.Web.UI.Page
    Dim LinesKeys As New List(Of String)
    Dim dtAttachment As New DataTable
    Dim RCCollection As New Hashtable
    Dim PLCollection As New Hashtable

    'retrieving responsibilty center and populating the control on the page

    Protected Sub gridDocumentAttachment_RowDataBound()

    End Sub
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



    Protected Sub populatePaymentMode()

        'ddPay_Mode.Items.Clear()
        'Me.ddPay_Mode.Items.Add("")
        'Me.ddPay_Mode.Items.Add("Cash")
        'Me.ddPay_Mode.Items.Add("Cheque")
        'Me.ddPay_Mode.Items.Add("_blank_")

    End Sub

    Protected Sub populateChequeType()

        'ddCheque_Type.Items.Clear()
        'Me.ddCheque_Type.Items.Add("")
        'Me.ddCheque_Type.Items.Add("Computer_Check")
        'Me.ddCheque_Type.Items.Add("Manual_Check")
        'Me.ddCheque_Type.Items.Add("_blank_")



    End Sub

    Protected Sub populateLineType()
        Dim dtPaymentTypes As New DataTable, i As Integer

        dtPaymentTypes = Session("PaymentType")

        Do While i < dtPaymentTypes.Rows.Count

            If Me.ddLine_Type.Items.Count = 0 Then

                ddLine_Type.Items.Add("")
                ddLine_Type.Items.Add(dtPaymentTypes.Rows(i).Item("AdvanceType"))

            Else

                ddLine_Type.Items.Add(dtPaymentTypes.Rows(i).Item("AdvanceType"))

            End If

            i = i + 1
        Loop


        'ddAccount_Type.Items.Clear()
        'Me.dd.Items.Add("")
        'Me.ddAccount_Type.Items.Add("Bank_Account")
        'Me.ddAccount_Type.Items.Add("Customer")
        'Me.ddAccount_Type.Items.Add("Fixed_Asset")
        'Me.ddAccount_Type.Items.Add("G_L_Account")
        'Me.ddAccount_Type.Items.Add("IC_Partner")
        'Me.ddAccount_Type.Items.Add("Vendor")




    End Sub

    Protected Sub gridPaymentRequest_RowDataBound()

    End Sub

    Protected Sub datagrid_PageIndexChanging()

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
    Protected Sub UploadFile()

        mpDocumentAttachment.Show()

    End Sub
    Private Sub frmPaymentRequest_Load(sender As Object, e As EventArgs) Handles Me.Load

        '    Exit Sub

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
                    populatePaymentMode()
                    populateLocation()

                    populateVehicleCode()
                    populateAdvertCode()

                    populateBusinessUnit()
                    populateChequeType()
                    populateLineType()
                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")
                    Dim _PaymentRequest As New NAV_HR_WINDOW.PaymentRequest
                    _PaymentRequest = NAV_Window.getPaymentRequest(RequestNo)
                    ' ViewState("PaymentRequest") = _PaymentRequest
                    getNAVRC(_PaymentRequest.Responsibility_Center)
                    'ViewState("AccountNumber") = staffClaim.AccountNo
                    Me.txtDocumentNo.Text = _PaymentRequest.DocumentNo
                    Me.txtdocumentID_attachment.Text = _PaymentRequest.DocumentNo
                    Me.txtCashier.Text = _PaymentRequest.Cashier

                    Dim dtBusinessUnit As New DataTable
                    dtBusinessUnit = Session("NAVBusinessUnit")

                    Me.ddBusinessUnit.Text = dtBusinessUnit.Select("Code = '" & _PaymentRequest.Bussiness_Unit & "'")(0).Item("Name")

                    Me.ddLocation.Text = _PaymentRequest.Location


                    Me.ddStatus.Text = _PaymentRequest.Status
                    ' Me.ddPay_Mode.Text = _PaymentRequest.Pay_Mode
                    Me.txtPayee.Text = _PaymentRequest.Payee
                    Me.txtPayee_Account_Number.Text = _PaymentRequest.Payee_Account_Number
                    Me.ddRC.Text = _PaymentRequest.Responsibility_Center
                    Me.txtRequestdate.Text = _PaymentRequest.RequestDate
                    Me.txtPayment_Release_Date.Text = _PaymentRequest.Payment_Release_Date
                    Me.txtNetAmount.Text = _PaymentRequest.Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount

                    'Me.ddPay_Mode.Text = _PaymentRequest.Pay_Mode.ToString()

                    '_StoreRequisition.StoreRequisitionLines(0).Unit_of_Measure

                    Dim dt As New DataTable, i As Integer

                    dt.Columns.Add(New DataColumn("txtInvoice_No", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtType", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtAccount_Type", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtAccount_No", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtAccount_Name", GetType(String)))
                    dt.Columns.Add(New DataColumn("Payment_Narration", GetType(String)))
                    dt.Columns.Add(New DataColumn("Due_Date", GetType(DateTime)))
                    ''''dt.Columns.Add(New DataColumn("numAmount", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("numNet_Amount", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("txtVehicleCode", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtAdvertCode", GetType(String)))

                    'dt.Columns.Add(New DataColumn("txtKey", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtLineNo", GetType(String)))

                    Do While i < _PaymentRequest.PaymentRequisitionLines.Length

                        dt.Rows.Add(_PaymentRequest.PaymentRequisitionLines(i).Invoice_No, _PaymentRequest.PaymentRequisitionLines(i).Type, _PaymentRequest.PaymentRequisitionLines(i).Account_Type, _PaymentRequest.PaymentRequisitionLines(i).Account_No, _PaymentRequest.PaymentRequisitionLines(i).Account_Name, _PaymentRequest.PaymentRequisitionLines(i).Payment_Narration, _PaymentRequest.PaymentRequisitionLines(i).Due_Date, _PaymentRequest.PaymentRequisitionLines(i).Amount, _PaymentRequest.PaymentRequisitionLines(i).Shortcut_Dimension_4_Code, _PaymentRequest.PaymentRequisitionLines(i).Shortcut_Dimension_6_Code, _PaymentRequest.PaymentRequisitionLines(i).Line_No)
                        '_PaymentRequest.PaymentRequisitionLines(i).Key,
                        LinesKeys.Add(_PaymentRequest.PaymentRequisitionLines(i).Key)
                        PLCollection.Add(_PaymentRequest.PaymentRequisitionLines(i).Line_No, _PaymentRequest.PaymentRequisitionLines(i).Key)
                        i += 1

                    Loop
                    ViewState("PLCollection") = PLCollection
                    ViewState("LinesKey") = LinesKeys
                    LoadGridPaymentReqLines(dt)

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then
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

                    populateStatus()
                    populatePaymentMode()
                    populateLocation()
                    populateVehicleCode()
                    populateAdvertCode()
                    populateBusinessUnit()
                    populateChequeType()
                    populateLineType()
                    getNAVRC("")

                    Me.txtCashier.Text = CStr(Session("userID")).ToUpper
                    Dim dtEmployeeCard As New DataTable
                    dtEmployeeCard = Session("dtEmployeeCard")

                    Me.txtPayee_Account_Number.Text = dtEmployeeCard.Rows(0).Item(0).ToString
                    txtCashier.Text = dtEmployeeCard.Rows(0).Item("UserID").ToString
                    txtPayee.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("MiddleName").ToString.ToUpper


                End If
            Else


            End If


        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Protected Sub LoadGridDocumentLines(dt As DataTable)

        ViewState("dtAttachment") = dt
        Me.gridFileAttachment.DataSource = dt
        gridFileAttachment.DataBind()

    End Sub

    Protected Sub LoadGridPaymentReqLines(dt As DataTable)

        ViewState("PmtReqLines") = dt
        Me.gridPaymentRequest.DataSource = dt
        gridPaymentRequest.DataBind()

    End Sub

    Private Sub ddLine_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddLine_Type.SelectedIndexChanged

        Dim result As DataRow(), dtClaimTypes As New DataTable
        dtClaimTypes = Session("PaymentType")
        result = dtClaimTypes.Select("AdvanceType = '" & ddLine_Type.Text & "'")
        Me.txtAccountType.Text = result(0).Item("AccountType").ToString
        Me.txtAccount_No.Text = result(0).Item("AccountNo").ToString
        Me.txtAccountName.Text = result(0).Item("AccountName").ToString

        If Me.ddLine_Type.Text = "FUELING" Or Me.ddLine_Type.Text = "VEHICLE REPAIRS" Then
            Me.ddVehicleCode.Enabled = True
            Me.ddAdvertCode.Enabled = False
        ElseIf Me.ddLine_Type.Text = "ADVERT" Then
            Me.ddAdvertCode.Enabled = True
            Me.ddVehicleCode.Enabled = False
        End If

    End Sub

    'Protected Sub calDuedate_SelectionChanged(sender As Object, e As EventArgs) Handles calDuedate.SelectionChanged

    '    PopupControlExtender_dueDate.Commit(calDuedate.SelectedDate)

    'End Sub

    Private Sub gridPaymentRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridPaymentRequest.SelectedIndexChanged


        Dim selectedRowIndex As Integer, dtClaimTypes As New DataTable, i As Integer
        selectedRowIndex = Me.gridPaymentRequest.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridPaymentRequest.Rows(selectedRowIndex)
        dtClaimTypes = Session("ClaimType")

        'Do While i < dtClaimTypes.Rows.Count
        '    If Me.ddAdvanceType.Items.Count = 0 Then
        '        ddAdvanceType.Items.Add("")
        '        ddAdvanceType.Items.Add(dtClaimTypes.Rows(i).Item("AdvanceType"))
        '    Else
        '        ddAdvanceType.Items.Add(dtClaimTypes.Rows(i).Item("AdvanceType"))
        '    End If
        '    i = i + 1
        'Loop

        'If row.Cells(1).Text.ToString() = "" Or row.Cells(1).Text.ToString() = "&nbsp;" Then
        '    Me.txtInvoiceNo.Text = ""
        'Else
        '    Me.txtInvoiceNo.Text = row.Cells(1).Text.ToString()
        'End If

        Me.ddLine_Type.Text = row.Cells(1).Text.ToString()
        Me.txtAccountType.Text = row.Cells(2).Text.ToString()
        Me.txtAccount_No.Text = row.Cells(3).Text.ToString()
        Me.txtAccountName.Text = row.Cells(4).Text.ToString()
        Me.txtPayment_Narration_Line.Text = row.Cells(5).Text.ToString()
        Me.txtAmount.Text = row.Cells(6).Text.ToString()

        Me.ddVehicleCode.Text = row.Cells(7).Text.ToString()
        Me.ddAdvertCode.Text = row.Cells(8).Text.ToString()

        'If Me.txtdocumentID_attachment.Text.Split("_").Count > 1 = True Then

        '    If (Me.txtdocumentID_attachment.Text.Split("_")(1) = row.Cells(8).Text.ToString()) = False Then

        '        Me.txtdocumentID_attachment.Text = Me.txtdocumentID_attachment.Text & "_" & row.Cells(8).Text.ToString()

        '    End If

        'Else

        '    Me.txtdocumentID_attachment.Text = Me.txtdocumentID_attachment.Text & "_" & row.Cells(8).Text.ToString()

        'End If



        '''''Load Files here'''''''''''''''''''''''''''''''''''''
        'Dim _PaymentRequest As New NAV_HR_WINDOW.PaymentRequest
        '_PaymentRequest = ViewState("PaymentRequest")
        'Me.txtdocumentID_attachment.Text = CStr(_PaymentRequest.DocumentNo) & "_" & _PaymentRequest.PaymentRequisitionLines(0).Line_No

        'ViewState("PaymentRequest") = _PaymentRequest

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''






    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try

            Dim _DataRow As DataRow

            If IsNothing(ViewState("selectedRowIndex")) = True Then
                Dim dtPVLines As New DataTable

                If IsNothing(ViewState("PmtReqLines")) = True Then

                    dtPVLines.Columns.Add(New DataColumn("txtInvoice_No", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtType", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtAccount_Type", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtAccount_No", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtAccount_Name", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Payment_Narration", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Due_Date", GetType(DateTime)))
                    dtPVLines.Columns.Add(New DataColumn("numNet_Amount", GetType(Decimal)))
                    dtPVLines.Columns.Add(New DataColumn("txtVehicleCode", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtAdvertCode", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("txtLineNo", GetType(String)))

                Else

                    dtPVLines = ViewState("PmtReqLines")

                End If

                Try

                    _DataRow = dtPVLines.NewRow
                    _DataRow("txtInvoice_No") = ""
                    _DataRow("txtType") = Me.ddLine_Type.Text
                    _DataRow("txtAccount_Type") = Me.txtAccountType.Text
                    _DataRow("txtAccount_No") = Me.txtAccount_No.Text
                    _DataRow("txtAccount_Name") = Me.txtAccountName.Text
                    _DataRow("Payment_Narration") = Me.txtPayment_Narration_Line.Text
                    _DataRow("Due_Date") = Now.Date
                    _DataRow("numNet_Amount") = Me.txtAmount.Text
                    _DataRow("txtVehicleCode") = Me.ddVehicleCode.Text
                    _DataRow("txtAdvertCode") = Me.ddAdvertCode.Text
                    _DataRow("txtLineNo") = ""

                    dtPVLines.Rows.Add(_DataRow)
                    LoadGridPaymentReqLines(dtPVLines)
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

                dtPVLines = ViewState("PmtReqLines")
                'dtPVLines.Rows(selectedRowIndex).Delete()
                _DataRow = dtPVLines.Rows(selectedRowIndex)
                _DataRow("txtInvoice_No") = ""
                _DataRow("txtType") = Me.ddLine_Type.Text
                _DataRow("txtAccount_Type") = Me.txtAccountType.Text
                _DataRow("txtAccount_No") = Me.txtAccount_No.Text
                _DataRow("txtAccount_Name") = Me.txtAccountName.Text
                _DataRow("Payment_Narration") = Me.txtPayment_Narration_Line.Text
                _DataRow("Due_Date") = Now.Date
                _DataRow("numNet_Amount") = Me.txtAmount.Text
                _DataRow("txtVehicleCode") = Me.ddVehicleCode.Text
                _DataRow("txtAdvertCode") = Me.ddAdvertCode.Text
                LoadGridPaymentReqLines(dtPVLines)
                ClearLine()



            End If


        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub
    Protected Sub ClearLine()

        ' Me.txtInvoiceNo.Text = ""
        Me.ddLine_Type.Text = ""
        Me.txtAccountType.Text = ""
        Me.txtAccount_No.Text = ""
        Me.txtAccountName.Text = ""
        Me.txtPayment_Narration_Line.Text = ""
        'Me.txtDueDate.Text = ""
        Me.txtAmount.Text = "0"
        Me.ddVehicleCode.Text = ""
        Me.ddAdvertCode.Text = "0"

        ViewState("selectedRowIndex") = Nothing


    End Sub
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try

            If IsNothing(ViewState("selectedRowIndex")) = True Then

            Else

                ' dtPVLines = ViewState("PmtReqLines")

                Dim selectedRowIndex As Integer, dtPVLines As New DataTable
                If IsNothing(ViewState("selectedRowIndex")) = False Then

                    selectedRowIndex = ViewState("selectedRowIndex")

                Else
                End If

                dtPVLines = ViewState("PmtReqLines")
                dtPVLines.Rows(selectedRowIndex).Delete()
                LoadGridPaymentReqLines(dtPVLines)
                ClearLine()
                ViewState("selectedFileRowIndex") = Nothing

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try


    End Sub

    Protected Sub calReleasedate_SelectionChanged(sender As Object, e As EventArgs) Handles calReleasedate.SelectionChanged
        PopupControlExtender_Releasedate.Commit(calReleasedate.SelectedDate)
    End Sub

    Protected Sub calRequestdate_SelectionChanged(sender As Object, e As EventArgs) Handles calRequestdate.SelectionChanged
        calRequestdate_PopupControlExtender.Commit(calRequestdate.SelectedDate)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim dtLocation As DataTable = Session("NAVLocation")
        Dim dtBusinessUnit As DataTable = Session("NAVBusinessUnit")

        Me.btnSave.Enabled = False
        Dim clicks_ As Integer = 0

        If IsNothing(ViewState("click")) = True Then

            clicks_ = 1
            ViewState("click") = clicks_

        Else

            clicks_ = CInt(ViewState("click"))
            clicks_ += 1

        End If

        Try

            If Not IsNothing(ViewState("RCCollection")) = True Then

                RCCollection = ViewState("RCCollection")
            Else
                Response.Redirect("login.aspx")
            End If

            Dim NAV_window As New NAV_HR_WINDOW.Core
            Dim lineCount As Integer = 0

            Dim Paymentlines_() As PaymentRequest_Service.Payment_Request_Lines
            ReDim Paymentlines_(Me.gridPaymentRequest.Rows.Count - 1)

            If IsNothing(ViewState("LinesKey")) = False Then
                LinesKeys = ViewState("LinesKey")
                PLCollection = ViewState("PLCollection")
            Else
            End If

            Dim totalLineAmount As Double = 0
            Do While lineCount < Me.gridPaymentRequest.Rows.Count

                    Dim PaymentLine As PaymentRequest_Service.Payment_Request_Lines = New PaymentRequest_Service.Payment_Request_Lines

                    PaymentLine.Type = gridPaymentRequest.Rows(lineCount).Cells(1).Text.ToString

                    Select Case gridPaymentRequest.Rows(lineCount).Cells(2).Text.ToString

                        Case = "Bank_Account"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.Bank_Account
                        Case = "Customer"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.Customer
                        Case = "Fixed_Asset"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.Fixed_Asset
                        Case = "G_L_Account"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.G_L_Account
                        Case = "IC_Partner"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.IC_Partner
                        Case = "Vendor"
                            PaymentLine.Account_Type = PaymentRequest_Service.Account_Type.Vendor
                        Case Else

                    End Select


                    PaymentLine.Account_No = gridPaymentRequest.Rows(lineCount).Cells(3).Text.ToString
                    PaymentLine.Account_Name = gridPaymentRequest.Rows(lineCount).Cells(4).Text.ToString
                PaymentLine.Payment_Narration = gridPaymentRequest.Rows(lineCount).Cells(5).Text.ToString
                PaymentLine.Amount = gridPaymentRequest.Rows(lineCount).Cells(6).Text.ToString
                PaymentLine.Shortcut_Dimension_4_Code = gridPaymentRequest.Rows(lineCount).Cells(7).Text.ToString
                PaymentLine.Shortcut_Dimension_6_Code = gridPaymentRequest.Rows(lineCount).Cells(8).Text.ToString
                totalLineAmount += PaymentLine.Amount
                PaymentLine.AmountSpecified = True

                If gridPaymentRequest.Rows(lineCount).Cells(9).Text = "&nbsp;" Then

                    Paymentlines_(lineCount) = PaymentLine

                Else

                    ' MsgBox(CStr(PLCollection.Item(CInt(gridPaymentRequest.Rows(lineCount).Cells(7).Text))) & " | " & gridPaymentRequest.Rows(lineCount).Cells(7).Text)

                    If LinesKeys.Contains(PLCollection.Item(CInt(gridPaymentRequest.Rows(lineCount).Cells(9).Text))) = True Then
                        NAV_window.DeletePaymentRequestLine(PLCollection.Item(CInt(gridPaymentRequest.Rows(lineCount).Cells(9).Text)))

                        Paymentlines_(lineCount) = PaymentLine
                        LinesKeys.RemoveAt(LinesKeys.IndexOf(PLCollection.Item(CInt(gridPaymentRequest.Rows(lineCount).Cells(9).Text))))

                        'LinesKeys.RemoveAt(lineCount)
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

            Dim _paymentRequest As PaymentRequest = New PaymentRequest With {
                 .SS_UserID = CStr(Session("userID")),
                 .Bank_Name = "",
                 .Budget_Center_Name = "",
                 .Cashier = Me.txtCashier.Text,
                 .Cheque_No = "",
                 .Cheque_Type = "",
                 .DocumentNo = Me.txtDocumentNo.Text,
                 .Function_Name = "",
                 .On_Behalf_Of = "",
                 .Payee = Me.txtPayee.Text,
                 .Payee_Account_Number = Me.txtPayee_Account_Number.Text,
                 .Paying_Bank_Account = "",
                 .Payment_Narration = "",
                 .Payment_Release_Date = Me.txtPayment_Release_Date.Text,
                 .Pay_Mode = "",
                 .RequestDate = Me.txtRequestdate.Text,
                 .Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text)),
                 .Status = Me.ddStatus.Text,
                 .Location = dtLocation.Select("Name = '" & Me.ddLocation.Text & "'")(0).Item(0).ToString,
                 .Bussiness_Unit = dtBusinessUnit.Select("Name = '" & Me.ddBusinessUnit.Text & "'")(0).Item(0).ToString,
                 .Total_Payment_Amount = 0,
                 .Total_Payment_Amount_LCY = 0,
                .Total_Retention_Amount = 0,
                .Total_VAT_Amount = 0,
                .Total_Witholding_Tax_Amount = 0,
                .Total_Payment_Amount_Total_Witholding_Tax_Amount__Total_VAT_Amount__Total_Retention_Amount = 0,
                 .PaymentRequisitionLines = Paymentlines_
                }

            If Me.txtDocumentNo.Text <> "" Then

                    NAV_window.UpdatePaymentRequest(_paymentRequest)
                Dim dtPaymentRequest As New DataTable, userID As String = Session("userID")
                dtPaymentRequest = NAV_window.getPaymentVoucherList(userID)
                    Session("PmtReq") = dtPaymentRequest
                Response.Redirect("frmPaymentRequestList.aspx")

            Else
                Dim entry As New ArrayList

                If IsNothing(Session("entry")) = True Then
                    Dim _message As String = ""
                    _message = NAV_window.CreatePaymentRequest(_paymentRequest)


                    If _message.ToUpper <> "SUCCESS" Then
                        dvErr.Visible = True
                        lblError.Text = "An Error Occur while creating document : " & _message
                        Exit Sub

                    Else
                        lblError.Text = ""
                        dvErr.Visible = False
                    End If


                    entry.Add(_paymentRequest.Cashier.ToString() & " : " & _paymentRequest.RequestDate.ToString() & " : " & _paymentRequest.Status & " : " & totalLineAmount)
                    Session("entry") = entry
                Else
                End If

                Dim dtPaymentRequest As New DataTable, userID As String = Session("userID")

                dtPaymentRequest = NAV_window.getPaymentVoucherList(userID)
                    Session("PmtReq") = dtPaymentRequest
                    Response.Redirect("frmPaymentRequestList.aspx")

                End If

            Catch ex As Exception

                Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try


    End Sub

    Protected Sub populateVehicleCode()

        Dim dtVehiclePayment As New DataTable, i As Integer

        dtVehiclePayment = Session("NAVVehicle")

        Do While i < dtVehiclePayment.Rows.Count

            If Me.ddVehicleCode.Items.Count = 0 Then

                ddVehicleCode.Items.Add("")
                ddVehicleCode.Items.Add(dtVehiclePayment.Rows(i).Item("Name").ToString())

            Else

                ddVehicleCode.Items.Add(dtVehiclePayment.Rows(i).Item("Name").ToString())

            End If

            i += 1
        Loop

    End Sub

    Protected Sub populateAdvertCode()

        Dim dtAdvert As New DataTable, i As Integer

        dtAdvert = Session("NAVAdvert")

        Do While i < dtAdvert.Rows.Count

            If Me.ddAdvertCode.Items.Count = 0 Then

                ddAdvertCode.Items.Add("")
                ddAdvertCode.Items.Add(dtAdvert.Rows(i).Item("Name").ToString())

            Else

                ddAdvertCode.Items.Add(dtAdvert.Rows(i).Item("Name").ToString())

            End If

            i += 1
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

    Private Sub btnAddDocument_Click(sender As Object, e As EventArgs) Handles btnAddDocument.Click

        dtAttachment = ViewState("dtAttachment")
        Dim _fileName, _fileExt As String, fileCount As Integer
        fileCount = Me.gridFileAttachment.Rows.Count

        If FileUpload1.HasFile = True Then

            '_fileName = FileUpload1.PostedFile.FileName.ToString().Split(".")(0) & Me.txtdocumentID_attachment.Text.Replace("-", "_") & "_" & (fileCount + 1).ToString()

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


        'StatusLabel.Text = "Upload status: File uploaded!"

        'Dim hh As System.IO.StreamReader = New System.IO.StreamReader(FileUpload1.PostedFile.InputStream)



    End Sub

    Protected Sub DeleteFile(filePath As String)

        Dim docPath As String = ConfigurationManager.AppSettings("DocumentPath")
        Try

            If File.Exists(docPath + filePath) = True Then
                File.Delete(docPath + filePath)
            Else
            End If

        Catch ex As Exception

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

    Private Sub frmPaymentRequest_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        Me.Page.Form.Enctype = "multipart/form-data"

    End Sub

    Private Sub gridFileAttachment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridFileAttachment.SelectedIndexChanged

        Dim selectedFileRowIndex As Integer, dtAttachment As New DataTable, i As Integer
        selectedFileRowIndex = Me.gridFileAttachment.SelectedRow.RowIndex
        ViewState("selectedFileRowIndex") = selectedFileRowIndex

        Dim row As GridViewRow = gridFileAttachment.Rows(selectedFileRowIndex)
        ' dtPaymentTypes = Session("ClaimType")

        Me.txtDocumentFileName.Text = row.Cells(1).Text.ToString() & "." & row.Cells(2).Text.ToString()

        mpDocumentAttachment.Show()

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

    Private Sub btnRemoveDocument_Click(sender As Object, e As EventArgs) Handles btnRemoveDocument.Click

        Try

            If IsNothing(ViewState("selectedFileRowIndex")) = True Then

            Else

                Dim selectedRowIndex As Integer, dtPVLines As New DataTable

                If IsNothing(ViewState("selectedFileRowIndex")) = False Then
                    selectedRowIndex = ViewState("selectedFileRowIndex")
                    dtAttachment = ViewState("dtAttachment")
                    Dim row As GridViewRow = gridFileAttachment.Rows(selectedRowIndex)
                    dtAttachment.Rows(selectedRowIndex).Delete()
                    DeleteFile(row.Cells(1).Text & "." & row.Cells(2).Text)
                    ViewState("selectedFileRowIndex") = Nothing
                    LoadGridDocumentLines(dtAttachment)

                Else
                End If

                Me.txtDocumentFileName.Text = ""

                If dtAttachment.Rows.Count = 0 Then
                    dtAttachment = Nothing
                Else
                End If

                'ClearLine()

                Me.mpDocumentAttachment.Show()
                'DeleteFile
                'Dim row As GridViewRow = gridFileAttachment.Rows(selectedRowIndex)
                'dtAttachment = ViewState("dtAttachment")
                'dtAttachment.Rows(selectedRowIndex).Delete()

                'mpDocumentAttachment.Show()

            End If

        Catch ex As Exception

            Dim logerr As New Global.Logger.Logger
            logerr.FileSource = "NAV - Self Service Portal"
            logerr.FilePath = AppDomain.CurrentDomain.BaseDirectory & "\Logs"
            logerr.Logger(ex.Message)

        End Try

    End Sub

    Private Sub imgDocumentAttactment_Click(sender As Object, e As ImageClickEventArgs) Handles imgDocumentAttactment.Click

    End Sub

    Private Sub btnShowDocumentAttachment_Click(sender As Object, e As EventArgs) Handles btnShowDocumentAttachment.Click

    End Sub

    Private Sub ddLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddLocation.SelectedIndexChanged

    End Sub


End Class
