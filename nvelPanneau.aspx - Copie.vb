Imports System.Data.SqlClient
Imports System.Data
Public Class nvelPanneau
    Inherits System.Web.UI.Page



    Dim myConnection As SqlConnection
    Dim myAdapter As SqlDataAdapter
    Dim myDataSet As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then

            populateData()
            ChargerListCliente()
            Calendrier.SelectedDate = DateTime.Now.AddDays(7)

        End If

    End Sub


    Private Sub populateData()
        Dim myconnection As SqlConnection
        myconnection = CType(Session("myconnection"), SqlConnection)
        Dim mycommand As SqlCommand
        mycommand = New SqlCommand("select *from panneau", myconnection)

        Dim dt As DataTable
        dt = New DataTable()
        Dim red As SqlDataReader
        red = mycommand.ExecuteReader()
        GridView1.DataSource = dt
        GridView1.DataBind()
        red.Close()




    End Sub



    Protected Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        AddRowsToGrid()
    End Sub

    Private Sub AddRowsToGrid()
        Dim noofRows As List(Of Integer) = New List(Of Integer)



        ' nnn = New DataListCommandEventArgs()

        Dim rows As Integer = 0
        Integer.TryParse(txtNoOfRecord.Text.Trim(), rows)
        Dim i As Integer = 0
        For i = 1 To rows
            noofRows.Add(i)

        Next
        gvContacts.DataSource = noofRows


        gvContacts.DataBind()

        If (gvContacts.Rows.Count > 0) Then
            panel1.Visible = True
        Else
            panel1.Visible = False
        End If


    End Sub

    





   
   

    '---------------------------------------------------------------------deleeeeeeeeeeeeeeeeeeet
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

            myReader = New SqlDataAdapter(myCommand)
            Dim ds As DataSet
            ds = New DataSet()

            myReader.Fill(ds)

            ddl.DataSource = ds
            ddl.DataTextField = "NomFamille"
            ddl.DataValueField = "ID_Famillepanneau"

            ddl.DataBind()
            ddl.Items.Insert(0, New ListItem("--select--", "0"))


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

 

   

    Protected Sub fpanneau_SelectedIndexChanged(sender As Object, e As EventArgs)

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
        Dim nameFamille As String = lblCurrentStatus.SelectedIndex
        If (lblCurrentStatus IsNot Nothing) Then

            lblCurrentStatus.Text = ddlCurrentDropDownList.SelectedItem.Value
            'MsgBox(lblCurrentStatus.Text)
            Dim sql As String
            Dim mycommande As SqlCommand
            ' Dim myReadere As SqlDataAdapter
            '  ddm.Items.Insert(0, New ListItem("--select--", "0"))
            MsgBox(nameFamille)

            sql = "select *from panneau where ID_Famillepanneau= " + nameFamille
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
            myreder.Close()

        End If
    End Sub

    Protected Function panneau_SelectedIndexChanged1(sender As Object, e As EventArgs)
        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")
        If (ddp IsNot Nothing) Then

            Dim nbr As String = ddp.SelectedValue




            Dim sql As String = "select SUM(nombreFace) AS dispo from Mouvement where ID_panneau=" + nbr
            ' MsgBox(sql)

            Dim myCom As SqlCommand
            myCom = New SqlCommand(sql, myConnection)
            'myCom.CommandType = CommandType.Text
            ' Dim myread As SqlDataReader

            chifre.Text = myCom.ExecuteScalar()


            'chifre.Text = myCom.ExecuteScalar()
            If (chifre.Text < 1) Then
                MsgBox("y'a plus d' espace a louer")
                btnsave.Enabled = False
                nbrface.Enabled = False
            Else
                nbrface.Enabled = True

            End If
        End If
        Return chifre.Text

    End Function





    

    Protected Sub gvContacts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContacts.SelectedIndexChanged

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbr As String = ddp.SelectedValue
        Dim sql As Integer = "select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau= + nbr  "
        Dim myCom As SqlCommand
        myCom = New SqlCommand(sql, myConnection)
        myCom.CommandType = CommandType.Text

        chifre.Text = myCom.ExecuteScalar()

        MsgBox(sql)




    End Sub

   
    Protected Sub nbrface_SelectedIndexChanged(sender As Object, e As EventArgs)
       
        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")
        


        Dim nbr As String = ddp.SelectedValue.ToString

        MsgBox(gvContacts.Rows.Count)

        If (nbr.Equals("0") Or nbr.Equals("")) Then

            '         nbrface.Enabled = False
            '        btnsave.Enabled = False
            '       MsgBox(nbr)
           
        Else
            
            '      nbrface.Enabled = True
            '     nbrface.Enabled = True
            '    MsgBox("btnActivé")
        End If
    End Sub

  








   

End Class
