Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class reservation
    Inherits System.Web.UI.Page



    Dim myConnection As SqlConnection
    Dim myAdapter As SqlDataAdapter
    Dim myDataSet As DataSet

 



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then

            Button2.Visible = False
            annule.Visible = False
            view.ActiveViewIndex = 0
            btnsave.Visible = False
            Dim myconnection As SqlConnection
            myconnection = CType(Session("myconnection"), SqlConnection)
            ' populateData()
            ' ChargerListCliente()
            ' directionPopulate()
            'Calendrier.SelectedDate = DateTime.Now.AddDays(7)
            '-------------------------------
            Dim populate = New share(direction, client, myconnection)

            populate.directionPopulate()
            populate.ChargerListCliente()
            '-------------------------------

            BindData()
            Dim rad As SqlDataReader
            Dim comm As SqlCommand

            comm = New SqlCommand("reserver", myconnection)
            comm.CommandType = CommandType.StoredProcedure
            rad = comm.ExecuteReader()
            rad.Close()





        End If

    End Sub
    Private Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Dim myConnection As New SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = myConnection

        sda.SelectCommand = cmd
        sda.Fill(dt)
        Return dt
    End Function
    Private Sub BindData()
        Dim strQuery As String = "select id,client,datedebut,datefin, codepanneau from reservation"
        Dim cmd As New SqlCommand(strQuery)
        GridView2.DataSource = GetData(cmd)
        GridView2.DataBind()
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

    '    GridView1.DataSource = dt
    '    GridView1.DataBind()


    '    red.Close()




    'End Sub
  
    'Sub directionPopulate()
    '    Dim myconnection As SqlConnection
    '    myconnection = CType(Session("myconnection"), SqlConnection)
    '    Dim myread As SqlDataReader
    '    Dim mycomad As SqlCommand
    '    Dim sql As String = "select *from direction"
    '    mycomad = New SqlCommand(sql, myconnection)
    '    myread = mycomad.ExecuteReader()
    '    direction.DataSource = myread
    '    direction.DataValueField = "id"
    '    direction.DataTextField = "NomDirection"
    '    direction.DataBind()
    '    direction.Items.Insert(0, New ListItem("--select Direction--", "0"))
    '    myread.Close()

    'End Sub
    Protected Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        AddRowsToGrid()
    End Sub

    Private Sub AddRowsToGrid()
        Dim noofRows As List(Of Integer) = New List(Of Integer)



        ' nnn = New DataListCommandEventArgs()

        Dim rows As Integer = 0    'declare ligne comme entier
        Integer.TryParse(txtNoOfRecord.Text.Trim(), rows)  'Convertir la representation d'un chiffre en string  en int32 et retrourne un boolen

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

    'Sub ChargerListCliente()
    '    Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
    '    Dim myredaer As SqlDataReader
    '    Dim mycommand As SqlCommand
    '    Dim sql As String = "select *from client where idClient<>1"

    '    mycommand = New SqlCommand(sql, myConnection)
    '    ' mycommand.CommandText = "select *from client"
    '    myredaer = mycommand.ExecuteReader()



    '    client.DataSource = myredaer
    '    client.DataValueField = "idClient"
    '    client.DataTextField = "Client"

    '    client.DataBind()

    '    client.Items.Insert(0, New ListItem("--select--", "0"))

    '    myredaer.Close()

    'End Sub





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

    Protected Function panneau_SelectedIndexChanged1(sender As Object, e As EventArgs)
        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")
        If (ddp IsNot Nothing) Then

            Dim nbr As String = ddp.SelectedValue




            Dim sql As String = "select SUM(nombreFace) AS dispo from Mouvementstock where ID_panneau=" + nbr
            ' MsgBox(sql)

            Dim myCom As SqlCommand
            myCom = New SqlCommand(sql, myConnection)
            'myCom.CommandType = CommandType.Text
            ' Dim myread As SqlDataReader

            chifre.Text = myCom.ExecuteScalar()
            'MsgBox(chifre.Text)


            'chifre.Text = myCom.ExecuteScalar()
            If (chifre.Text < 1) Then
                '  MsgBox("y'a plus d' espace a louer")

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
        Dim sql As Integer = "select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + nbr
        Dim myCom As SqlCommand
        myCom = New SqlCommand(sql, myConnection)
        myCom.CommandType = CommandType.Text

        chifre.Text = myCom.ExecuteScalar()

        '  MsgBox(sql)




    End Sub


    Protected Sub nbrface_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")



        Dim nbr As Int32 = Convert.ToInt32(nbrface.SelectedItem.Value.ToString)

        '  MsgBox(gvContacts.Rows.Count)
        Dim cc As Int32 = Convert.ToInt32(chifre.Text)
        If (cc < nbr) Then

            '  MsgBox("erreur de la saisie")
            Response.Redirect("reservation.aspx")

        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click


        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim myAdapter As SqlDataAdapter
        Dim myset As DataSet = New DataSet()
        Dim myConnection As SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim sql As String
        sql = "select *from Compagne where idCompagne=0"
        myAdapter = New SqlDataAdapter(sql, myConnection)
        myAdapter.Fill(myset, "Compagne")

        Dim nbrSouver(20) As String


        Dim mycommand As SqlCommand

        mycommand = New SqlCommand("ajouterCompagne", myConnection)
        mycommand.CommandType = CommandType.StoredProcedure
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        'les parametres de la command mycommand serons passé au variable param
        Dim param As SqlParameterCollection = mycommand.Parameters
        param.Add("@NomCompagne", SqlDbType.VarChar, 16, "NomCompagne")
        param.Add("@idClient", SqlDbType.Int, 4, "id_Client")
        param.Add("@datePrevu", SqlDbType.DateTime, 8, "datePrevu")
        param.Add("@nbrPanneau", SqlDbType.Int, 4, "nbrPanneau")
        param.Add("@Montant", SqlDbType.Int, 4, "Montant")
        param.Add("@id_region", SqlDbType.Int, 4, "id_region")
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        'faut retourné la clé etrangéres idCompagne donc faut créer une autre variable de type sqlparameters
        Dim bara As SqlParameter = New SqlParameter("@idCompagne", SqlDbType.Int, 4)
        bara.Direction = ParameterDirection.Output
        param.Add(bara)

        myAdapter.InsertCommand = mycommand
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------

        Dim lineAdapter As SqlDataAdapter
        sql = "select *from mouvementstock where Id_Mouvementstock=0"
        lineAdapter = New SqlDataAdapter(sql, myConnection)

        lineAdapter.Fill(myset, "Mouvementstock")

        Dim myBuild As SqlCommandBuilder = New SqlCommandBuilder(lineAdapter)
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim ismZaboun As String = "select client from client where idclient=" + client.SelectedItem.Value
        ' Dim mycamand As SqlCommand

        '   mycamand = New SqlCommand(ismZaboun, myConnection)
        '    Dim myrod As IDataReader = mycamand.ExecuteReader()


        '--------------------------------------------------------------------------------------------
        Dim myrow As DataRow = myset.Tables("Compagne").NewRow()
        myrow("nbrPanneau") = System.Convert.ToInt32(txtNoOfRecord.Text)
        myrow("id_Client") = client.SelectedItem.Value
        myrow("NomCompagne") = "reservation" '+ myrod.ToString
        myrow("Montant") = "0"
        myrow("datePrevu") = Date.Now
        myrow("Id_Region") = direction.SelectedItem.Value
        ' myrod.Close()

        myset.Tables("Compagne").Rows.Add(myrow)
        myAdapter.Update(myset, "compagne")




        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim newMvt As Int32 = bara.Value
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim i As Integer
        For i = 0 To (gvContacts.Rows.Count - 1)
           

            Dim nub As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text
            myrow = myset.Tables("Mouvementstock").NewRow()
            Dim s As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text
            myrow("ID_panneau") = s
            myrow("nombreFace") = -nub
            myrow("DateMouvement") = Date.Now.AddDays(7)

            ' myrow("nbrPanneau") = nbrf
            'myrow = myset.Tables("Mouvementstock").NewRow()
            myrow("id_compagne") = newMvt
            '   myrow("nombreFace") = nbrface.SelectedItem.Value
            '   myrow("Duree") = mouda.SelectedItem.Value
            '    myrow("ID_panneau") = ddp.SelectedItem.Value
            '   myDataSet.Tables("Mouvementstock").Rows.Add(myrow)

            'recuperer le nombre de face panneau 

            Dim mycome As SqlCommand = New SqlCommand()

            '   Dim riders As SqlCommand
            'mycome = New SqlCommand(somme, myConnection)
            '    mycome.CommandType = CommandType.Text
            mycome = New SqlCommand("select SUM(nombreFace) from mouvementstock where id_panneau=" + s, myConnection)

            mycome.CommandType = CommandType.Text

            Dim myval As Int32 = Convert.ToInt32(mycome.ExecuteScalar())
            ' riders = mycome.ExecuteScalar()

            '  MsgBox("Left nombre de panneau choisie")
            'MsgBox(Convert.ToInt32(nub))

            '  MsgBox("le resultat de la somme est:")
            '  MsgBox(myval)
            '
            'comparer le nbre de face panneau avec le nombre validés





            '   Dim ss As Int32 = CInt(somme)
            Dim ss As Int32 = myval
            nbrSouver(i) = myval
            'le dernier test avant la validation
            If (CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text > nbrSouver(i)) Then

                '   MsgBox("Erreure de saisie")
                Dim Sqlo As String
                Sqlo = "delete from compagne where idCompagne=" + newMvt.ToString
                Dim mycom As SqlCommand
                mycom = New SqlCommand(Sqlo, myConnection)

                Dim rider As SqlDataReader
                rider = mycom.ExecuteReader()
                rider.Close()


                Response.Redirect("reservation.aspx")

            End If

            myset.Tables("MouvementStock").Rows.Add(myrow)
        Next

        lineAdapter.Update(myset, "Mouvementstock")
        Dim comm As SqlCommand
        Dim rad As SqlDataReader
        comm = New SqlCommand("reserver", myConnection)
        comm.CommandType = CommandType.StoredProcedure
        rad = comm.ExecuteReader()
        rad.Close()

        view.ActiveViewIndex = 2
        '  Response.Redirect("FinCommande.aspx?id=" + newMvt.ToString())

    End Sub


    Protected Sub GridView2_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub






    Protected Sub GridView2_RowDeleting(sender As Object, e As EventArgs) ' GridViewDeletedEventArgs)
        Dim rr As GridViewRow
        Dim i As Integer
        Dim myConnection As SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim linkRemove As LinkButton = DirectCast(sender, LinkButton)

        Dim cmd As SqlCommand = New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from reservation where " & "id=@id;" & "select id,client,datedebut,datefin, codepanneau from reservation"
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = linkRemove.CommandArgument


        GridView2.DataSource = GetData(cmd)
        GridView2.DataBind()




    End Sub

    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        view.ActiveViewIndex = 1
    End Sub



    Protected Sub check_Click(sender As Object, e As EventArgs) Handles check.Click

        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)

        Dim nomb As Integer = 0
        Dim nombre As Integer = 0
        Dim resultat As Object = New Object()
        Dim mycome As SqlCommand = New SqlCommand()

        Dim flag As Boolean = True
        Dim i As Integer

        Dim sze As String
        Dim sz As String

        Dim ddp As String = 0
        Dim disponible As String



        For i = 0 To (gvContacts.Rows.Count - 1)
            sze = CType(gvContacts.Rows(i).FindControl("fpanneau"), DropDownList).Text
            sz = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text





            mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + sz, myConnection)
            ' If (IsNothing(mycome)) Then
            If (sz = "") Then
                mycome.CommandType = CommandType.Text

            Else
                mycome.CommandType = CommandType.Text
                resultat = mycome.ExecuteScalar()



            End If
            Dim ddpr As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text

            Dim ddnbr As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text


            If (i > 0) Then
                '   ddp = CType(gvContacts.Rows(i - 1).FindControl("panneau"), DropDownList).Text

                Dim count As Integer

                For count = 0 To (i - 1)

                    ddp = CType(gvContacts.Rows(count).FindControl("panneau"), DropDownList).Text


                    If ddp = ddpr Then
                        nombre = nombre + 1

                    End If

                Next


            End If

            ' If ddp = ddpr Then
            'nombre = nombre + 1

            '   End If







            If (ddpr = "") Or (ddpr = "0") Then

                nomb = nomb + 1

            End If






            If (ddnbr.ToString > resultat.ToString) Then
                flag = False
            End If







            '    CType(gvContacts.Rows(i).FindControl("dispo"), Label).Text = resultat.ToString


        Next



        If (nomb <> 0) Or (nombre > 0) Or (flag = False) Then
            Button2.Visible = False
            txtt.Text = "Modifier Votre Commande SVP"
        Else
            check.Visible = False
            Button2.Visible = True
            gvContacts.Enabled = False
            annule.Visible = True
            btnsave.Visible = True
            txtt.Text = ""
        End If

    End Sub

    Protected Sub annule_Click(sender As Object, e As EventArgs) Handles annule.Click
        Button2.Visible = False
        check.Visible = True
        annule.Visible = False
        gvContacts.Enabled = True
        btnsave.Visible = False
    End Sub



    Protected Sub prec1_Click(sender As Object, e As EventArgs) Handles prec1.Click
        view.ActiveViewIndex = 0
    End Sub
End Class


