Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class reserver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            Dim myconnection As SqlConnection
            myconnection = CType(Session("myconnection"), SqlConnection)
            '    populateData()
            ' ChargerListCliente()
            'Calendrier.SelectedDate = DateTime.Now.AddDays(7)
            '    BindData()
            Dim rad As SqlDataReader
            Dim comm As SqlCommand

            comm = New SqlCommand("reserver", myconnection)
            comm.CommandType = CommandType.StoredProcedure
            rad = comm.ExecuteReader()
            rad.Close()
        End If
    End Sub

    'Private Sub populateData()
    '    Dim myconnection As SqlConnection
    '    myconnection = CType(Session("myconnection"), SqlConnection)
    '    Dim mycommand As SqlCommand
    '    mycommand = New SqlCommand("select *from panneau", myconnection)

    '    Dim dt As DataTable
    '    dt = New DataTable()
    '    Dim red As SqlDataReader
    '    red = mycommand.ExecuteReader()
    '    While (red.Read())
    '        GridView1.DataSource = dt
    '        GridView1.DataBind()
    '    End While


    '    ' red.Close()


    'End Sub

    'Private Sub BindData()

    '    Dim strQuery As String = "select id,client,datedebut,datefin, codepanneau from reservation"
    '    Dim cmd As New SqlCommand(strQuery)
    '    GridView1.DataSource = GetData(cmd) ' je passe le cmd qui pointe sur la pile a la fct GetData
    '    GridView1.DataBind()
    'End Sub

    Private Function GetData(cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()    'nvelle table dans la memoir
        Dim myConnection As New SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim sda As New SqlDataAdapter()    'nvelle sqldataadapter pour lier la base de  a la teble de memoire
        cmd.CommandType = CommandType.Text
        cmd.Connection = myConnection

        sda.SelectCommand = cmd      'select a record in datasource
        sda.Fill(dt)   'remplir la table
        Return dt
    End Function


    Protected Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        AddRowsToGrid()
    End Sub

    Private Sub AddRowsToGrid()

        Dim Nroof = New List(Of Integer)
        Dim rows As Integer
        Integer.TryParse(txtNoOfRecord.Text.Trim, rows)
        Dim i As Integer
        For i = 1 To rows
            Nroof.Add(i)

        Next
        gvContacts.DataSource = Nroof
        gvContacts.DataBind()

        If (gvContacts.Rows.Count() > 0) Then
            panel1.Visible = True
        Else
            panel1.Visible = False
        End If
    End Sub



    
    Protected Sub gvContacts_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvContacts.RowDataBound
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataAdapter
        Dim SQL As String
        myConnection = CType(Session("myConnection"), SqlConnection)

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim ddl As DropDownList
            ddl = e.Row.FindControl("fpanneau")



            myCommand = New SqlCommand("select *from Famillepanneau", myConnection)

            'myReader = New SqlDataAdapter(myCommand)
            '   Dim ds As DataSet
            '    ds = New DataSet()

            '  myReader.Fill(ds)


            Dim myre As SqlDataReader
            myre = myCommand.ExecuteReader()

            ddl.DataSource = myre
            ddl.DataTextField = "NomFamille"
            ddl.DataValueField = "ID_Famillepanneau"

            ddl.DataBind()
            ddl.Items.Insert(0, New ListItem("--select--", "0"))
            myre.Close()

        End If

    End Sub
    '---------------------------------------------------------------------deleeeeeeeeeeeeeeeeeeet

    Sub ChargerListCliente()
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim myredaer As SqlDataReader
        Dim mycommand As SqlCommand
        Dim sql As String = "select *from client where idClient<>1"

        mycommand = New SqlCommand(sql, myConnection)
        ' mycommand.CommandText = "select *from client"
        myredaer = mycommand.ExecuteReader()



        client.DataSource = myredaer
        client.DataValueField = "idClient"
        client.DataTextField = "Client"

        client.DataBind()

        client.Items.Insert(0, New ListItem("--select--", "0"))

        myredaer.Close()

    End Sub
    Sub fpanneau_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim myConnection As SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        ' Dim ddm, ddl As DropDownList
        'ddm = TryCast(gvContacts.HeaderRow.FindControl("panneau"), DropDownList)
        'ddm = gvContacts.FindControl("panneau")
        Dim ddlCurrentDropDownList As DropDownList = sender
        Dim grdrDropDownRow As GridViewRow = (ddlCurrentDropDownList.Parent.Parent)
        Dim ddm As DropDownList = grdrDropDownRow.FindControl("panneau")


        '    Dim grdrDropDownRow As GridViewRow = (ddlCurrentDropDownList.Parent.Parent)
        Dim lblCurrentStatus As DropDownList = grdrDropDownRow.FindControl("fpanneau")
        Dim nameFamille As String = lblCurrentStatus.SelectedValue
        If (lblCurrentStatus IsNot Nothing) Then

            lblCurrentStatus.Text = ddlCurrentDropDownList.SelectedItem.Value
            'MsgBox(lblCurrentStatus.Text)
            Dim sql As String
            Dim mycommande As SqlCommand
            ' Dim myReadere As SqlDataAdapter
            '  ddm.Items.Insert(0, New ListItem("--select--", "0"))
            ' MsgBox(nameFamille)

            sql = "select codePanneau, panneau.id_panneau as ID_Panneau, panneau.ID_Famillepanneau as ID_Famille, SUM(nombreFace) from panneau inner join MouvementStock on panneau.ID_panneau=MouvementStock.ID_panneau Group by codePanneau,panneau.ID_panneau, panneau.ID_Famillepanneau having SUM(nombreFace) > 0 And panneau.ID_Famillepanneau = " + nameFamille
            mycommande = New SqlCommand(sql, myConnection)

            '  myReadere = New SqlDataAdapter(mycommande)
            ' Dim dse As DataSet
            'dse = New DataSet()
            ' myReadere.Fill(dse)
            Dim myreder As SqlDataReader
            myreder = mycommande.ExecuteReader()

            'ddm.DataSource = dse
            ddm.DataSource = myreder
            ddm.DataTextField = "codePanneau"
            ddm.DataValueField = "ID_panneau"
            ddm.DataBind()
            ddm.Items.Insert(0, New ListItem("--select--", "0"))
            myreder.Close()

        End If
    End Sub


End Class