Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class majbadd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            Dim mycon As SqlConnection
            mycon = CType(Session("mycon"), SqlConnection)
            bindGridview()
        End If

    End Sub

    Private Sub bindGridview()
        Dim mycon As SqlConnection


        mycon = CType(Session("mycon"), SqlConnection)

        Dim mycommand As SqlCommand
        Dim sql As String
        'sql = "select *from famillepanneau"

        mycommand = New SqlCommand()
        mycommand.CommandText = "select *from [famillepanneau]"
        'mycommand.Connection = mycon

        Dim data As SqlDataAdapter
        data = New SqlDataAdapter("mycommand", mycon)

        Dim ds As DataSet = New DataSet()


        data.Fill(ds)


        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim mycon As SqlConnection = CType(Session("mycon"), SqlConnection)
        Dim mycommande As SqlCommand
        Dim sqle As String

        Dim ds As DataSet = New DataSet()

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            mycon.Open()
            Dim dd As DropDownList
            dd = e.Row.FindControl("ddl")
            Dim ID_panneau As String
            ID_panneau = Convert.ToInt32(e.Row.Cells(0).Text)

            ' sqle = "select *from panneau where ID_famillepanneau=" + ID_panneau

            mycommande = New SqlCommand()
            mycommande.CommandText = "select *from panneau where ID_famillepanneau=" + ID_panneau
            Dim data As SqlDataAdapter = New SqlDataAdapter("mycommande", mycon)

            data.Fill(ds)
            dd.DataSource = ds
            dd.DataBind()



        End If
    End Sub
End Class