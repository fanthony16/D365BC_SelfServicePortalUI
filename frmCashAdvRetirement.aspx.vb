
Imports NAV_HR_WINDOW
Imports System.Data

Partial Class frmCashAdvRetirement
    Inherits System.Web.UI.Page
    Dim LinesKeys As New List(Of String)
    Dim RCCollection As New Hashtable

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

    'retrieving responsibilty center and populating the control on the page
    Protected Sub getNAVRC(rc As String)

        Dim dtRC As New DataTable
        'Dim RCCollection As New Hashtable
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

            RCCollection.ContainsValue("")

            If ddRC.Items.Count = 0 Then
                Me.ddRC.Items.Add("")

                ' MsgBox("Value - " & RCCollection.Item(RCCollection.Keys(i).ToString))

                ' MsgBox("Key - " & RCCollection.Keys(i).ToString)

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

        'Me.ddRC.SelectedValue = _rcc.ToString()

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

    Private Sub frmCashAdvRetirement_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtusers As New DataTable
        Dim RequestNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core

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

                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")

                    getPageData(RequestNo)

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then

                If IsNothing(Session("user")) = True Then

                    Response.Redirect("Login.aspx")

                Else

                    populateStatus()
                    ' populatePaymentMode()
                    ' populateChequeType()
                    populateLineType()
                    getNAVRC("")

                    Me.txtCashier.Text = CStr(Session("userID")).ToUpper
                    Me.txtChequedate.Text = Now.Date
                    txtSurrender_Date.Text = Now.Date

                End If
            Else


            End If


        Catch ex As Exception

            'MsgBox("" & ex.Message)

        End Try

    End Sub
    Protected Sub getPageData(docNo As String)

        Dim NAV_Window As New NAV_HR_WINDOW.Core
        Dim _WorkRetirement As New NAV_HR_WINDOW.WorkRetirement
        _WorkRetirement = NAV_Window.getWorkRetirement(docNo)
        getNAVRC(_WorkRetirement.Responsibility_Center)


        Me.txtDocumentNo.Text = _WorkRetirement.DocumentNo
        Me.txtCashier.Text = _WorkRetirement.Cashier
        'Me.txtCheque_No.Text = _WorkRetirement.Cheque_No
        'Me.txtBankCode.Text = _WorkRetirement.Bank_Code
        Me.ddStatus.Text = _WorkRetirement.Status

        'If IsNothing(_WorkRetirement.Pay_Mode) = True Then
        '    Me.ddPay_Mode.Text = ""
        'Else
        '    Me.ddPay_Mode.Text = CStr(_WorkRetirement.Pay_Mode).ToString
        'End If

        'If IsNothing(_WorkRetirement.Description2) = True Then
        '    Me.txtDescription2.Text = ""
        'Else
        '    Me.txtDescription2.Text = CStr(_WorkRetirement.Description2).ToString
        'End If


        RCCollection = ViewState("RCCollection")
        Dim j As Integer

        Do While j < RCCollection.Count
            'MsgBox(RCCollection.Values(j).ToString() & " - " & _WorkRetirement.Responsibility_Center)
            If (RCCollection.Values(j).ToString() = _WorkRetirement.Responsibility_Center) = True And Not IsNothing(_WorkRetirement.Responsibility_Center) = True Then

                ddRC.Text = RCCollection.Keys(j).ToString()

            Else
                Me.ddRC.Text = ""
            End If

            j = j + 1

        Loop

        'If IsNothing(_WorkRetirement.Responsibility_Center) = True Then
        '    Me.ddRC.Text = ""
        'Else
        '    Me.ddRC.Text = CStr(_WorkRetirement.Responsibility_Center).ToString
        'End If

        If IsNothing(_WorkRetirement.ChequeDate) = True Then
            Me.txtChequedate.Text = ""
        Else
            Me.txtChequedate.Text = _WorkRetirement.ChequeDate
        End If



        If IsNothing(_WorkRetirement.Imprest_Issue_Date) = True Then
            Me.txtIssued_Date.Text = ""
        Else
            Me.txtIssued_Date.Text = _WorkRetirement.Imprest_Issue_Date
        End If


        If IsNothing(_WorkRetirement.Surrender_Date) = True Then
            Me.txtSurrender_Date.Text = ""
        Else
            Me.txtSurrender_Date.Text = _WorkRetirement.Surrender_Date
        End If

        If IsNothing(_WorkRetirement.Imprest_Issue_Doc_No) = True Then

        Else
            Me.txtImprest_Issue_Doc_No.Text = _WorkRetirement.Imprest_Issue_Doc_No.ToString
        End If

        Dim dtEmployeeCard As New DataTable
        dtEmployeeCard = Session("dtEmployeeCard")

        txtPayee.Text = dtEmployeeCard.Rows(0).Item("LastName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("FirstName").ToString.ToUpper & " " & dtEmployeeCard.Rows(0).Item("MiddleName").ToString.ToUpper

        'Me.ddRC.Text = _WorkRetirement.Responsibility_Center.ToString
        'Me.txtChequedate.Text = CStr(_WorkRetirement.ChequeDate)
        'Me.txtIssued_Date.Text = CStr(_WorkRetirement.Imprest_Issue_Date)
        'Me.txtSurrender_Date.Text = CStr(_WorkRetirement.Surrender_Date)



        Dim dt As New DataTable, i As Integer

        dt.Columns.Add(New DataColumn("LineNo", GetType(String)))
        dt.Columns.Add(New DataColumn("Account_No", GetType(String)))
        dt.Columns.Add(New DataColumn("Account_Name", GetType(String)))
        dt.Columns.Add(New DataColumn("Imprest_Type", GetType(String)))
        dt.Columns.Add(New DataColumn("ActualSpent", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("RecieptNo", GetType(String)))
        dt.Columns.Add(New DataColumn("RecieptAmount", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("txtKey", GetType(String)))

        Dim dtAdvanceTypes As DataTable = Session("PaymentType")


        Do While i < _WorkRetirement.WorkAdvanceLines.Length

            Dim _accountName As String = dtAdvanceTypes.Select("AdvanceType = '" & _WorkRetirement.WorkAdvanceLines(i).Imprest_Type & "'")(0).Item("AccountName").ToString


            dt.Rows.Add(_WorkRetirement.WorkAdvanceLines(i).Line_No, _WorkRetirement.WorkAdvanceLines(i).Account_No, _accountName, _WorkRetirement.WorkAdvanceLines(i).Imprest_Type, _WorkRetirement.WorkAdvanceLines(i).Actual_Spent, _WorkRetirement.WorkAdvanceLines(i).Amount, _WorkRetirement.WorkAdvanceLines(i).Cash_Receipt_No, _WorkRetirement.WorkAdvanceLines(i).Cash_Receipt_Amount, _WorkRetirement.WorkAdvanceLines(i).Key)

            LinesKeys.Add(_WorkRetirement.WorkAdvanceLines(i).Key)

            i += 1

        Loop

        ViewState("LinesKey") = LinesKeys
        LoadGridAdvReqLines(dt)

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

    End Sub

    Protected Sub LoadGridAdvReqLines(dt As DataTable)

        ViewState("CashRetirementLines") = dt
        Me.gridAdvanceRequest.DataSource = dt
        gridAdvanceRequest.DataBind()

    End Sub
    Protected Sub datagrid_PageIndexChanging()

    End Sub

    Protected Sub gridAdvanceRequest_RowDataBound()

    End Sub

    Private Sub ddLine_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddLine_Type.SelectedIndexChanged

        Dim result As DataRow(), dtClaimTypes As New DataTable
        dtClaimTypes = Session("PaymentType")
        result = dtClaimTypes.Select("AdvanceType = '" & ddLine_Type.Text & "'")
        Me.txtAccountType.Text = result(0).Item("AccountType").ToString
        Me.txtAccount_No.Text = result(0).Item("AccountNo").ToString
        Me.txtAccountName.Text = result(0).Item("AccountName").ToString

    End Sub

    Private Sub gridAdvanceRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridAdvanceRequest.SelectedIndexChanged

        Dim selectedRowIndex As Integer, dtAdvanceTypes As New DataTable, result As DataRow()
        selectedRowIndex = Me.gridAdvanceRequest.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex

        Dim row As GridViewRow = gridAdvanceRequest.Rows(selectedRowIndex)

        Try

            Me.ddLine_Type.Text = row.Cells(4).Text.ToString()

        Catch ex As Exception

        End Try

        ViewState("lineNo") = row.Cells(1).Text.ToString()
        Me.txtActualSpent.Text = row.Cells(5).Text.ToString()
        Me.txtAmount.Text = row.Cells(6).Text.ToString()

        'Me.txtRecieptNo.Text = row.Cells(7).Text.ToString()
        'Me.txtRecieptAmount.Text = row.Cells(8).Text.ToString()

        dtAdvanceTypes = Session("PaymentType")

        Try

            result = dtAdvanceTypes.Select("AdvanceType = '" & row.Cells(4).Text.ToString() & "'")
            Me.txtAccountType.Text = result(0).Item("AccountType").ToString
            Me.txtAccount_No.Text = result(0).Item("AccountNo").ToString
            Me.txtAccountName.Text = result(0).Item("AccountName").ToString

        Catch ex As Exception
            'MsgBox("" & ex.Message())
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try

            Dim _DataRow As DataRow

            If IsNothing(ViewState("selectedRowIndex")) = True Then

                Dim dtPVLines As New DataTable

                If IsNothing(ViewState("CashRetirementLines")) = True Then

                    dtPVLines.Columns.Add(New DataColumn("LineNo", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Account_No", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Account_Name", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("Imprest_Type", GetType(String)))
                    dtPVLines.Columns.Add(New DataColumn("ActualSpent", GetType(Decimal)))
                    dtPVLines.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
                    dtPVLines.Columns.Add(New DataColumn("txtKey", GetType(String)))

                Else

                    dtPVLines = ViewState("CashRetirementLines")

                End If

                Try

                    _DataRow = dtPVLines.NewRow
                    _DataRow("LineNo") = ViewState("lineNo")
                    _DataRow("Account_No") = Me.txtAccount_No.Text
                    _DataRow("Account_Name") = Me.txtAccountName.Text
                    _DataRow("Imprest_Type") = Me.ddLine_Type.Text
                    _DataRow("ActualSpent") = Me.txtActualSpent.Text
                    _DataRow("Amount") = Me.txtAmount.Text
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

                dtPVLines = ViewState("CashRetirementLines")
                _DataRow = dtPVLines.Rows(selectedRowIndex)

                _DataRow("LineNo") = ViewState("lineNo")
                _DataRow("Account_No") = Me.txtAccount_No.Text
                _DataRow("Account_Name") = Me.txtAccountName.Text
                _DataRow("Imprest_Type") = Me.ddLine_Type.Text
                _DataRow("ActualSpent") = Me.txtActualSpent.Text
                _DataRow("Amount") = Me.txtAmount.Text
                _DataRow("RecieptNo") = ""
                _DataRow("RecieptAmount") = "0"


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
    Protected Sub ClearLine()

        Me.txtActualSpent.Text = 0
        'Me.txtRecieptNo.Text = ""
        'Me.txtRecieptAmount.Text = 0
        Me.ddLine_Type.Text = ""
        Me.txtAccountType.Text = ""
        Me.txtAccount_No.Text = ""
        Me.txtAccountName.Text = ""

        'Me.txtDueDate.Text = ""
        Me.txtAmount.Text = "0"
        ViewState("selectedRowIndex") = Nothing

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            Dim NAV_window As New NAV_HR_WINDOW.Core
            Dim lineCount As Integer = 0
            Dim _response As String = ""
            Dim _WorkRetirement As New NAV_HR_WINDOW.WorkRetirement
            Dim StaffRetirementlines_() As WorkRetirement_Service.Staff_Advanc_Surrender_Details
            ReDim StaffRetirementlines_(Me.gridAdvanceRequest.Rows.Count - 1)


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If IsNothing(ViewState("LinesKey")) = False Then
                LinesKeys = ViewState("LinesKey")
            Else
            End If

            Do While lineCount < Me.gridAdvanceRequest.Rows.Count

                Dim StaffRetirementline As WorkRetirement_Service.Staff_Advanc_Surrender_Details = New WorkRetirement_Service.Staff_Advanc_Surrender_Details

                StaffRetirementline.Account_No = gridAdvanceRequest.Rows(lineCount).Cells(2).Text.ToString
                StaffRetirementline.Account_Name = gridAdvanceRequest.Rows(lineCount).Cells(3).Text.ToString
                StaffRetirementline.Imprest_Type = gridAdvanceRequest.Rows(lineCount).Cells(4).Text.ToString
                StaffRetirementline.Actual_Spent = gridAdvanceRequest.Rows(lineCount).Cells(5).Text.ToString

                If gridAdvanceRequest.Rows(lineCount).Cells(7).Text = "&nbsp;" Then

                    StaffRetirementlines_(lineCount) = StaffRetirementline

                Else

                    If LinesKeys.Contains(gridAdvanceRequest.Rows(lineCount).Cells(7).Text) = True Then

                        Dim staffRetirement_ As New RetirementLine

                        staffRetirement_.LineNo = gridAdvanceRequest.Rows(lineCount).Cells(1).Text
                        staffRetirement_.AmountSpent = gridAdvanceRequest.Rows(lineCount).Cells(5).Text
                        staffRetirement_.SurrenderDocNo = Me.txtDocumentNo.Text
                        _response = NAV_window.UpdateRetirementRequestLine(staffRetirement_)

                        ' MsgBox("" & NAV_window.DeleteRetirementRequestLine(gridAdvanceRequest.Rows(lineCount).Cells(9).Text))

                        StaffRetirementlines_(lineCount) = StaffRetirementline
                        LinesKeys.RemoveAt(LinesKeys.IndexOf(gridAdvanceRequest.Rows(lineCount).Cells(7).Text))

                    End If
                End If

                lineCount += 1

            Loop
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''remove the un-required retirement lines'''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lno As Integer = 0
            Do While lno < LinesKeys.Count
                NAV_window.DeleteRetirementRequestLine(LinesKeys(lno))
                lno += 1
            Loop



            Dim i As Integer = 0

            RCCollection = ViewState("RCCollection")

            Dim _cashRetirementRequest As WorkRetirement = New WorkRetirement With {
             .ChequeDate = Me.txtChequedate.Text,
             .Surrender_Date = Me.txtSurrender_Date.Text,
             .Imprest_Issue_Doc_No = Me.txtImprest_Issue_Doc_No.Text,
             .Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text)),
             .DocumentNo = Me.txtDocumentNo.Text,
             .UserID = CStr(Session("userID")),
             .WorkAdvanceLines = StaffRetirementlines_
            }

            Dim _return As String = ""

            If Me.txtDocumentNo.Text <> "" Then

                _return = NAV_window.UpdateRetirementRequest(_cashRetirementRequest)

                If _return <> "Success" Then
                    ' MsgBox("" & _return)
                Else

                    Dim dtAdvanceRetirement As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
                    dtAdvanceRetirement = NAV_window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)
                    Session("NAVStaffRetirement") = dtAdvanceRetirement
                    Response.Redirect("frmCashAdvRetirements.aspx")

                End If


            Else

                _return = NAV_window.CreateRetirementRequest(_cashRetirementRequest)

                If _response <> "Success" Then

                    Dim dtAdvanceRetirement As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
                    dtAdvanceRetirement = NAV_window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)
                    Session("NAVStaffRetirement") = dtAdvanceRetirement
                    Response.Redirect("frmCashAdvRetirements.aspx")

                Else

                End If


                'Dim _return As String = NAV_window.CreateRetirementRequest(_cashRetirementRequest)
                ''MsgBox("" & NAV_window.UpdateRetirementRequest(_cashRetirementRequest))
                'If _return <> "Success" Then
                '    MsgBox("" & _return)
                'Else

                '    Dim dtAdvanceRetirement As New DataTable, dtEmployeeCard As DataTable = Session("dtEmployeeCard")
                '    dtAdvanceRetirement = NAV_window.getWorkRetirementList(dtEmployeeCard.Rows(0)("No").ToString)
                '    Session("NAVStaffRetirement") = dtAdvanceRetirement
                '    Response.Redirect("frmCashAdvRetirement.aspx")

                'End If

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

                dtPVLines = ViewState("CashRetirementLines")
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

    Protected Sub txtImprest_Issue_Doc_No_TextChanged(sender As Object, e As EventArgs) Handles txtImprest_Issue_Doc_No.TextChanged

        Dim NAV_window As New NAV_HR_WINDOW.Core
        Dim _CashAdvanceRequest As New NAV_HR_WINDOW.CashAdvanceRequest
        Dim _WorkRetirement As New NAV_HR_WINDOW.WorkRetirement
        Dim _return As String

        _CashAdvanceRequest = NAV_window.getStaffAdvance(txtImprest_Issue_Doc_No.Text)
        _WorkRetirement.Imprest_Issue_Doc_No = Me.txtImprest_Issue_Doc_No.Text

        If Not IsNothing(ViewState("RCCollection")) = True Then

            RCCollection = ViewState("RCCollection")
            _WorkRetirement.Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text))
            _return = NAV_window.CreateRetirementRequest(_WorkRetirement)
            Me.txtDocumentNo.Text = CStr(_return.Split("|")(1))

        Else

            Response.Redirect("login.aspx")

        End If

        getPageData(txtDocumentNo.Text)


        Exit Sub

        'Dim dt As New DataTable, i As Integer
        'dt.Columns.Add(New DataColumn("LineNo", GetType(String)))
        'dt.Columns.Add(New DataColumn("Account_No", GetType(String)))
        'dt.Columns.Add(New DataColumn("Account_Name", GetType(String)))
        'dt.Columns.Add(New DataColumn("Imprest_Type", GetType(String)))
        'dt.Columns.Add(New DataColumn("ActualSpent", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("Amount", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("RecieptNo", GetType(String)))
        'dt.Columns.Add(New DataColumn("RecieptAmount", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("txtKey", GetType(String)))

        'Do While i < _CashAdvanceRequest.CashAdvanceRequestLines.Length

        '    dt.Rows.Add(_CashAdvanceRequest.CashAdvanceRequestLines(i).No, _CashAdvanceRequest.CashAdvanceRequestLines(i).Account_No, _CashAdvanceRequest.CashAdvanceRequestLines(i).Account_Name, _CashAdvanceRequest.CashAdvanceRequestLines(i).Advance_Type, 0, _CashAdvanceRequest.CashAdvanceRequestLines(i).Amount, "", 0, "")

        '    i += 1

        'Loop

        ''i = 0
        'Dim lineCount As Integer = 0
        'Dim StaffRetirementlines_() As WorkRetirement_Service.Staff_Advanc_Surrender_Details
        'ReDim StaffRetirementlines_(dt.Rows.Count - 1)

        'Do While lineCount < dt.Rows.Count


        '    Dim StaffRetirementline As WorkRetirement_Service.Staff_Advanc_Surrender_Details = New WorkRetirement_Service.Staff_Advanc_Surrender_Details

        '    StaffRetirementline.Account_No = dt.Rows(lineCount).Item("Account_No").ToString
        '    StaffRetirementline.Account_Name = dt.Rows(lineCount).Item("Account_Name").ToString
        '    StaffRetirementline.Imprest_Type = dt.Rows(lineCount).Item("Imprest_Type").ToString
        '    StaffRetirementline.Amount = dt.Rows(lineCount).Item("Amount").ToString
        '    StaffRetirementlines_(lineCount) = StaffRetirementline

        '    lineCount += 1

        'Loop

        'LoadGridAdvReqLines(dt)
        'Exit Sub

        'Dim _cashRetirementRequest As WorkRetirement = New WorkRetirement With {
        '                  .Imprest_Issue_Doc_No = Me.txtImprest_Issue_Doc_No.Text,
        '                  .WorkAdvanceLines = StaffRetirementlines_
        '    }


        'If Me.txtDocumentNo.Text = "" Then

        '    _return = NAV_window.CreateRetirementRequest(_cashRetirementRequest)
        '    MsgBox("" & _return)

        '    If _return.Split("|").Length > 0 Then
        '        getPageData(_return.Split("|")(1).ToString.Trim)
        '    Else
        '    End If

        'Else

        '    getPageData(txtDocumentNo.Text)

        'End If

    End Sub

    Private Sub txtChequedate_TextChanged(sender As Object, e As EventArgs) Handles txtChequedate.TextChanged

    End Sub

    Protected Sub calChequedate_SelectionChanged(sender As Object, e As EventArgs) Handles calChequedate.SelectionChanged

        Me.calChequedate_PopupControlExtender.Commit(Me.calChequedate.SelectedDate)

    End Sub

    Protected Sub calSurrenderDate_SelectionChanged(sender As Object, e As EventArgs) Handles calSurrenderDate.SelectionChanged
        Me.calSurrenderDate_PopupControlExtender.Commit(Me.calSurrenderDate.SelectedDate)
    End Sub

    Private Sub ddRC_TextChanged(sender As Object, e As EventArgs) Handles ddRC.TextChanged

        If ddRC.Text <> "" Then
            txtImprest_Issue_Doc_No.Enabled = True
        Else

        End If

    End Sub
End Class
