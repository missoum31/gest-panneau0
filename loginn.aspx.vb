Imports System.Drawing
Public Class login1
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub OnClick_DoConnect(sender As Object, e As EventArgs)

        If (FormsAuthentication.Authenticate(UserID.Text, Password.Text)) Then
            FormsAuthentication.RedirectFromLoginPage(UserID.Text, False)
        Else
            Message.Text = "Identification incorrecte"
            Message.ForeColor = Color.Red
        End If
    End Sub
End Class