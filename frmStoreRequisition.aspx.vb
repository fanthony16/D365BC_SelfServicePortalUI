Imports NAV_HR_WINDOW
Imports System.Data
Imports System.Net

Partial Class frmStoreRequisition
    Inherits System.Web.UI.Page
    Dim LinesKeys As New List(Of String)
    Dim RCCollection As New Hashtable

    Protected Sub populateStatus()

        ddStatus.Items.Clear()

        Me.ddStatus.Items.Add("")
        Me.ddStatus.Items.Add("Open")
        Me.ddStatus.Items.Add("Pending_Approval")
        Me.ddStatus.Items.Add("Pending_Prepayment")
        Me.ddStatus.Items.Add("Posted")
        Me.ddStatus.Items.Add("Released")
        Me.ddStatus.Items.Add("Cancelled")
        Me.ddStatus.Items.Add("Released")
        'Pending

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
    Protected Sub gridStoreRequisition_RowDataBound()

    End Sub
    Protected Sub datagrid_PageIndexChanging()


    End Sub

    Protected Sub populateIssueingStore()

        Dim dtIssueingStore As New DataTable, i As Integer

        dtIssueingStore = Session("NAVIssueingStore")

        Do While i < dtIssueingStore.Rows.Count

            If Me.ddIssueingStore.Items.Count = 0 Then

                ddIssueingStore.Items.Add("")
                ddIssueingStore.Items.Add(dtIssueingStore.Rows(i).Item("Name").ToString())

            Else

                ddIssueingStore.Items.Add(dtIssueingStore.Rows(i).Item("Name").ToString())

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
    Protected Sub populateItemType()
        Try

            Dim dtStoreItemTypes As New DataTable, i As Integer = 0

            dtStoreItemTypes = Session("StoreItemType")

            Do While i < dtStoreItemTypes.Rows.Count

                If Me.ddType.Items.Count = 0 Then

                    ddType.Items.Add("")
                    ddType.Items.Add(dtStoreItemTypes.Rows(i).Item("Description").ToString())

                Else

                    ddType.Items.Add(dtStoreItemTypes.Rows(i).Item("Description").ToString())

                End If

                i = i + 1

            Loop

        Catch ex As Exception
            ' MsgBox("" & ex.Message)
        End Try

    End Sub

    Private Sub frmStoreRequisition_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtusers As New DataTable

        Dim RequisitionNo As String
        Dim NAV_Window As New NAV_HR_WINDOW.Core

        Try

            If IsPostBack = False And Not Context.Request.QueryString("DocumentNo") Is Nothing Then

                RequisitionNo = Context.Request.QueryString("DocumentNo") 'ApplicationTypeID
                ViewState("RequisitionNumber") = RequisitionNo
                spCaption.InnerText = spCaption.InnerText & " Document Code : " & Context.Request.QueryString("DocumentNo") & " IN EDIT MODE"

                Dim dtEmployees, dtEmployeeCard, dtEmployeeLeaves, dtEmployeeLeave, dtHRSetup As New DataTable

                'testing if cache is empty
                If IsNothing(Session("dtEmployeeCard")) = True Then

                    Response.Redirect("Login.aspx")

                Else
                    'populating the status control
                    populateStatus()
                    'retrieving employee detail from session object
                    dtEmployeeCard = Session("dtEmployeeCard")
                    Dim _StoreRequisition As New NAV_HR_WINDOW.StoreRequisition
                    _StoreRequisition = NAV_Window.getStoreRequisition(RequisitionNo)
                    'ViewState("AccountNumber") = staffClaim.AccountNo
                    Me.txtDocumentNo.Text = _StoreRequisition.DocumentNo
                    'Me.txtBudgetCenter.Text = _StoreRequisition.BudgetCenterName
                    'Me.txtFunctionName.Text = _StoreRequisition.FunctionName
                    ' Me.txtIssuingtore.Text = _StoreRequisition.Issuing_Store
                    Me.txtRequestdate.Text = _StoreRequisition.Request_Date
                    Me.txtRequiredate.Text = _StoreRequisition.Require_Date
                    Me.ddStatus.Text = _StoreRequisition.Status

                    ' Me.txtRequestDescription.Text = _StoreRequisition.RequestDescription

                    getNAVRC(_StoreRequisition.Responsibility_Center)
                    populateItemType()
                    populateLocation()
                    populateBusinessUnit()
                    populateIssueingStore()

                    Me.ddLocation.Text = _StoreRequisition.Location
                    Me.ddBusinessUnit.Text = _StoreRequisition.BusinessUnit
                    Me.ddIssueingStore.Text = _StoreRequisition.IssueingStore

                    '_StoreRequisition.StoreRequisitionLines(0).Unit_of_Measure

                    Dim dt As New DataTable, i As Integer

                    dt.Columns.Add(New DataColumn("txtReqLineNumber", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtDescription", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtIssuingStore", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtType", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtQtyinstore", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtQuantity", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtQuantityRequested", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtUnitCost", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtUnitofMeasure", GetType(String)))
                    dt.Columns.Add(New DataColumn("txtLintAmount", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("txtKey", GetType(String)))

                    'dt.Columns.Add(New DataColumn("txtBin_Code", GetType(String)))
                    ' ReDim LinesKeys(_StoreRequisition.StoreRequisitionLines.Length - 1)

                    Do While i < _StoreRequisition.StoreRequisitionLines.Length

                        dt.Rows.Add(_StoreRequisition.StoreRequisitionLines(i).No, _StoreRequisition.StoreRequisitionLines(i).Description, _StoreRequisition.StoreRequisitionLines(i).Issuing_Store, _StoreRequisition.StoreRequisitionLines(i).Type, _StoreRequisition.StoreRequisitionLines(i).Qty_in_store, _StoreRequisition.StoreRequisitionLines(i).Quantity, _StoreRequisition.StoreRequisitionLines(i).Quantity_Requested, _StoreRequisition.StoreRequisitionLines(i).Unit_Cost, _StoreRequisition.StoreRequisitionLines(i).Unit_of_Measure, _StoreRequisition.StoreRequisitionLines(i).Line_Amount, _StoreRequisition.StoreRequisitionLines(i).Key)
                        ' LinesKeys(i) = _StoreRequisition.StoreRequisitionLines(i).Key
                        LinesKeys.Add(_StoreRequisition.StoreRequisitionLines(i).Key)
                        i += 1
                    Loop



                    ViewState("LinesKey") = LinesKeys

                    LoadGridStoreReqLines(dt)

                End If

            ElseIf IsPostBack = False And Context.Request.QueryString("DocumentNo") Is Nothing Then

                populateStatus()
                populateItemType()
                populateLocation()
                populateBusinessUnit()
                populateIssueingStore()
                getNAVRC("")
                Me.txtRequestdate.Text = Now.Date
                Me.txtRequiredate.Text = Now.Date




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
                End If
            Else


            End If


        Catch ex As Exception

            ' MsgBox("" & ex.Message)

        End Try

    End Sub
    Protected Sub LoadGridStoreReqLines(dt As DataTable)

        ViewState("StoreReqLines") = dt
        Me.gridStoreRequisition.DataSource = dt
        gridStoreRequisition.DataBind()

    End Sub

    Private Sub ddType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddType.SelectedIndexChanged

        Dim result As DataRow(), dtStoreItemTypes As New DataTable
        dtStoreItemTypes = Session("StoreItemType")
        result = dtStoreItemTypes.Select("Description = '" & ddType.Text & "'")
        Me.txtUnitCost.Text = result(0).Item("Unit_Cost").ToString
        Me.txtUnitMeasure.Text = result(0).Item("UnitOfMeasure").ToString
        Me.txtRequisitionLineNo.Text = result(0).Item("No").ToString
        Me.txtLineAmount.Text = 0

        Me.txtUnitMeasure.Text = result(0).Item("Location").ToString

        Dim NAV_Window As New NAV_HR_WINDOW.Core
        txtQtyInStore.Text = NAV_Window.getItemQuantityInStore(result(0).Item("No").ToString)
        'txtQtyInStore.Text = NAV_Window.getItemQuantityInStore("CR0025")



    End Sub

    Private Sub txtLineAmount_TextChanged(sender As Object, e As EventArgs) Handles txtLineAmount.TextChanged

        Me.txtLineAmount.Text = CInt(txtQuantity.Text) * CDbl(txtUnitCost.Text)

    End Sub

    Private Sub gridStoreRequisition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridStoreRequisition.SelectedIndexChanged


        Dim selectedRowIndex As Integer, dtStoreItemTypes As New DataTable, i As Integer
        selectedRowIndex = Me.gridStoreRequisition.SelectedRow.RowIndex
        ViewState("selectedRowIndex") = selectedRowIndex
        Dim row As GridViewRow = gridStoreRequisition.Rows(selectedRowIndex)


        Dim result As DataRow()
        dtStoreItemTypes = Session("StoreItemType")
        result = dtStoreItemTypes.Select("Description = '" & row.Cells(2).Text.ToString() & "'")
        Me.txtUnitCost.Text = result(0).Item("Unit_Cost").ToString
        Me.txtUnitMeasure.Text = result(0).Item("UnitOfMeasure").ToString
        Me.ddType.Text = result(0).Item("Description").ToString

        Dim NAV_Window As New NAV_HR_WINDOW.Core
        txtQtyInStore.Text = NAV_Window.getItemQuantityInStore(row.Cells(1).Text)
        Me.txtQuantity.Text = row.Cells(5).Text
        Me.txtRequisitionLineNo.Text = row.Cells(1).Text


        Me.txtLineAmount.Text = row.Cells(8).Text




    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _DataRow As DataRow

        If IsNothing(ViewState("selectedRowIndex")) = True Then

            Dim dtStoreReqLines As New DataTable
            If IsNothing(ViewState("StoreReqLines")) = True Then

                dtStoreReqLines.Columns.Add(New DataColumn("txtReqLineNumber", GetType(String)))
                'dtStoreReqLines.Columns.Add(New DataColumn("txtBin_Code", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtDescription", GetType(String)))
                'dtStoreReqLines.Columns.Add(New DataColumn("txtIssuingStore", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtType", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtQtyinstore", GetType(String)))
                ' dtStoreReqLines.Columns.Add(New DataColumn("txtQuantity", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtQuantityRequested", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtUnitCost", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtUnitofMeasure", GetType(String)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtLintAmount", GetType(Decimal)))
                dtStoreReqLines.Columns.Add(New DataColumn("txtKey", GetType(String)))


            Else
                dtStoreReqLines = ViewState("StoreReqLines")
            End If

            Try
                _DataRow = dtStoreReqLines.NewRow
                _DataRow("txtReqLineNumber") = Me.txtRequisitionLineNo.Text
                '_DataRow("txtBin_Code") = Me.txtBinCode.Text
                _DataRow("txtDescription") = Me.ddType.Text
                '_DataRow("txtIssuingStore") = Me.txtIssuingtore.Text
                _DataRow("txtType") = "Item"
                _DataRow("txtQtyinstore") = Me.txtQtyInStore.Text
                ' _DataRow("txtQuantity") = "0"
                _DataRow("txtQuantityRequested") = Me.txtQuantity.Text
                _DataRow("txtUnitCost") = Me.txtUnitCost.Text
                _DataRow("txtUnitofMeasure") = Me.txtUnitMeasure.Text
                _DataRow("txtLintAmount") = CDbl(Me.txtUnitCost.Text) * CDbl(Me.txtQuantity.Text)
                dtStoreReqLines.Rows.Add(_DataRow)
                LoadGridStoreReqLines(dtStoreReqLines)
                clearLine()

            Catch ex As Exception
                ' MsgBox("" & ex.Message)
            End Try


        Else

            Dim selectedRowIndex As Integer, dtStoreReqLines As New DataTable

            If IsNothing(ViewState("selectedRowIndex")) = False Then
                selectedRowIndex = ViewState("selectedRowIndex")

            Else
            End If

            dtStoreReqLines = ViewState("StoreReqLines")
            'dtPVLines.Rows(selectedRowIndex).Delete()
            _DataRow = dtStoreReqLines.Rows(selectedRowIndex)
            _DataRow("txtReqLineNumber") = Me.txtRequisitionLineNo.Text
            '   _DataRow("txtBin_Code") = Me.txtBinCode.Text
            _DataRow("txtDescription") = Me.ddType.Text
            '_DataRow("txtIssuingStore") = Me.txtIssuingtore.Text
            _DataRow("txtType") = "Item"
            _DataRow("txtQtyinstore") = Me.txtQtyInStore.Text
            _DataRow("txtQuantity") = "0"
            _DataRow("txtQuantityRequested") = Me.txtQuantity.Text
            _DataRow("txtUnitCost") = Me.txtUnitCost.Text
            _DataRow("txtUnitofMeasure") = Me.txtUnitMeasure.Text
            _DataRow("txtLintAmount") = CDbl(Me.txtUnitCost.Text) * CDbl(Me.txtQuantity.Text)


            LoadGridStoreReqLines(dtStoreReqLines)
            clearLine()
        End If

        ViewState("selectedRowIndex") = Nothing


    End Sub
    Protected Sub clearLine()

        'Me.txtBinCode.Text = ""
        Me.ddType.Text = ""
        'Me.txtIssuingtore.Text = ""
        Me.txtQtyInStore.Text = "0"
        Me.txtQuantity.Text = "0"
        Me.txtUnitCost.Text = "0"
        Me.txtUnitMeasure.Text = ""
        Me.txtLineAmount.Text = "0"
        Me.txtRequisitionLineNo.Text = ""

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim NAV_window As New NAV_HR_WINDOW.Core
        Dim lineCount As Integer = 0
        Dim s As StoreRequisition_Service.StoreRequisitionHeder
        Dim Requisitionlines() As StoreRequisition_Service.Store_Requisition_Line
        ReDim Requisitionlines(Me.gridStoreRequisition.Rows.Count - 1)
        Dim dtLocation As DataTable = Session("NAVLocation")
        Dim dtBusinessUnit As DataTable = Session("NAVBusinessUnit")
        Dim dtIssueingStore As DataTable = Session("NAVIssueingStore")

        If Not IsNothing(ViewState("RCCollection")) = True Then

            RCCollection = ViewState("RCCollection")

        Else

            Response.Redirect("login.aspx")

        End If

        If IsNothing(ViewState("LinesKey")) = False Then
            LinesKeys = ViewState("LinesKey")
        Else
        End If


        Do While lineCount < Me.gridStoreRequisition.Rows.Count

            Dim Requisitionline As StoreRequisition_Service.Store_Requisition_Line = New StoreRequisition_Service.Store_Requisition_Line With {
             .No = gridStoreRequisition.Rows(lineCount).Cells(1).Text,
             .Bin_Code = "",
             .Description = gridStoreRequisition.Rows(lineCount).Cells(2).Text,
             .Issuing_Store = "",
             .Type = StoreRequisition_Service.Type.Item,
             .Qty_in_store = gridStoreRequisition.Rows(lineCount).Cells(4).Text,
             .Quantity_Requested = CDbl(gridStoreRequisition.Rows(lineCount).Cells(5).Text),
             .Quantity_RequestedSpecified = True,
             .Unit_of_Measure = gridStoreRequisition.Rows(lineCount).Cells(7).Text
            }


            If gridStoreRequisition.Rows(lineCount).Cells(9).Text = "&nbsp;" Then

                Requisitionlines(lineCount) = Requisitionline

            Else

                If LinesKeys.Contains(gridStoreRequisition.Rows(lineCount).Cells(9).Text) = True Then



                    NAV_window.DeleteStoreRequisitionLine(gridStoreRequisition.Rows(lineCount).Cells(9).Text)
                    Requisitionlines(lineCount) = Requisitionline
                    LinesKeys.RemoveAt(LinesKeys.IndexOf(gridStoreRequisition.Rows(lineCount).Cells(9).Text))


                End If
            End If
            lineCount += 1

        Loop

        Dim _storeRequisition As NAV_HR_WINDOW.StoreRequisition = New NAV_HR_WINDOW.StoreRequisition With {
        .DocumentNo = txtDocumentNo.Text,
        .Request_Date = Me.txtRequestdate.Text,
        .Require_Date = Me.txtRequiredate.Text,
        .StoreRequisitionLines = Requisitionlines,
        .Status = Me.ddStatus.Text,
        .Responsibility_Center = CStr(RCCollection.Item(Me.ddRC.SelectedItem.Text)),
        .UserID = CStr(Session("userID")),
        .Location = dtLocation.Select("Name = '" & Me.ddLocation.Text & "'")(0).Item(0).ToString,
        .BusinessUnit = dtBusinessUnit.Select("Name = '" & Me.ddBusinessUnit.Text & "'")(0).Item(0).ToString,
        .IssueingStore = dtIssueingStore.Select("Name = '" & Me.ddIssueingStore.Text & "'")(0).Item(0).ToString
         }

        Try

            If Me.txtDocumentNo.Text <> "" Then

                Dim _status As String = NAV_window.UpdateStoreRequisition(_storeRequisition)

                Dim dtStoreReq As New DataTable
                dtStoreReq = NAV_window.getStoreRequisitions(CStr(Session("userID")))
                Session("StoreReq") = dtStoreReq
                Response.Redirect("frmStoreRequisitionList.aspx")

            Else

                Dim _status As String = NAV_window.CreateStoreRequisition(_storeRequisition)
                Dim dtStoreReq As New DataTable
                dtStoreReq = NAV_window.getStoreRequisitions(CStr(Session("userID")))
                Session("StoreReq") = dtStoreReq
                Response.Redirect("frmStoreRequisitionList.aspx")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If Me.txtRequisitionLineNo.Text = "" Then

        Else

            Dim selectedRowIndex As Integer, dtStoreReqLines As New DataTable
            If IsNothing(ViewState("selectedRowIndex")) = False Then
                selectedRowIndex = ViewState("selectedRowIndex")
            Else
            End If

            dtStoreReqLines = ViewState("StoreReqLines")
            dtStoreReqLines.Rows(selectedRowIndex).Delete()

            LoadGridStoreReqLines(dtStoreReqLines)


            clearLine()
        End If

    End Sub
End Class
