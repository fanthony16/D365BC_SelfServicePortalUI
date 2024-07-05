Imports System.Data
Partial Class ErrorPage
    Inherits System.Web.UI.Page

     Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
          Dim dtusers As New DataTable
          If Page.IsPostBack = False Then

               If IsNothing(Session("user")) = True Then

                    Response.Redirect("Login.aspx")

               ElseIf IsNothing(Session("user")) = False And IsNothing(Session("userDetails")) = False Then

                'getUserAccessMenu(Session("user"))

            Else
               End If

          End If

     End Sub


End Class
