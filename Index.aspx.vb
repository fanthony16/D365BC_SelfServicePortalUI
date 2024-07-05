Imports System.Data
Partial Class index
	Inherits System.Web.UI.Page

	Protected Sub gridApplicationSummary_RowDataBound()

	End Sub

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Dim dtusers As New DataTable, dtAppPreference As New DataTable
		Try

			If Page.IsPostBack = False Then



				Me.lblWelcomePerson.InnerText = Me.lblWelcomePerson.InnerText & " " & CStr(Session("user")).ToString

			Else

			End If
		Catch ex As Exception

			Response.Redirect("Login.aspx")

		End Try


	End Sub





End Class
