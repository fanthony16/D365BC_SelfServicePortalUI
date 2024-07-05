
Imports AjaxControlToolkit

Partial Class frmLeaveApp
    Inherits System.Web.UI.Page

    Protected Sub BtnViewDetails_Click(sender As Object, e As EventArgs)

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
                Me.flReqDocUpload.SaveAs(Server.MapPath(strUploadPath))

                flReqDocUpload.Dispose()
                Session("Document") = Nothing

            End If


        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try

    End Sub

End Class
