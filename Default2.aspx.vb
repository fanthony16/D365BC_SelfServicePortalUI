
Imports System.Net

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Dim ii As New LPPFACommon.pfagetbalance
            ii.Credentials = New NetworkCredential("", "", "")
            ii.PreAuthenticate = True
            MsgBox("" & ii.SendApprovalRequest("LAN-7209"))

        Catch ex As Exception

            MsgBox("" & ex.Message)

        End Try



    End Sub
End Class
