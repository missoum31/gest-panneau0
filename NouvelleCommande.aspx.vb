Imports System.Data.SqlClient
Imports System.Data

Public Class NouvelleCommande
    Inherits System.Web.UI.Page



    Dim myConnection As SqlConnection
    Dim myAdapter As SqlDataAdapter
    Dim myDataSet As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'Dim connStr As String = ConfigurationSettings.AppSettings("ConnectionString")
        'myConnection = new SqlConnection(connStr)
        myConnection = CType(Session("myConnection"), SqlConnection)
        If (Not IsPostBack) Then
            
            Calendrier.SelectedDate = DateTime.Now.AddDays(7)
            ChargerListeFournisseurs()
            '-------------------

        End If

    End Sub

    Protected Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        AddRowsToGrid()
    End Sub


    Private Sub AddRowsToGrid()
        Dim noofRows As List(Of Integer) = New List(Of Integer)

        '-----------------------------------


        '-----------------------------------


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
            panel2.Visible = True

        Else
            panel2.Visible = False
        End If


    End Sub

    Sub ChargerListeFournisseurs()

        ' Chargement de la liste des fournisseurs

        Dim myCommand As SqlCommand
        Dim Sql As String
        Sql = "SELECT * FROM direction"
        If (userName = "anepWest") Then
            Sql = "SELECT * FROM direction WHERE NomDirection = 'Direction Ouest' "
        End If
        If (userName = "DirectionEst") Then
            Sql = "SELECT * FROM direction WHERE NomDirection = 'Direction Est' "
        End If
        If (userName = "DirectionCentre") Then
            Sql = "SELECT * FROM direction WHERE NomDirection = 'Direction Centre' "
        End If

        myCommand = New SqlCommand(Sql, myConnection)

        Dim myDataReader As SqlDataReader

        ' myConnection.Open()
        myDataReader = myCommand.ExecuteReader()

        direction.DataSource = myDataReader
        direction.DataTextField = "NomDirection"
        direction.DataValueField = "ID_Direction"
        direction.DataBind()

        myDataReader.Close()
        '  myConnection.Close()

        ' Chargement de la liste des références pour le fournisseur actif
        ' AfficherListeReferences()    '----------------------------


        Dim myCommande As SqlCommand
        Dim Sqle As String
        Sqle = "SELECT * FROM Client"


        myCommande = New SqlCommand(Sqle, myConnection)

        Dim myDataReadere As SqlDataReader

        ' myConnection.Open()
        myDataReadere = myCommande.ExecuteReader()

        clients.DataSource = myDataReadere
        clients.DataTextField = "Client"
        clients.DataValueField = "idClient"
        clients.DataBind()

        myDataReadere.Close()



    End Sub
 
    Protected Sub gvContacts_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvContacts.RowDataBound
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataAdapter
        Dim SQL As String
        myConnection = CType(Session("myConnection"), SqlConnection)



        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim ddl As DropDownList
            Dim cal As calendar
            ddl = e.Row.FindControl("fpanneau")

            'traitement de button--------------------------------
            '   Dim botona As ImageButton
            '  botona = e.Row.FindControl("Button1")



            '----------------------------------------------------

            'traitement du calendrier-----------------------------
            '     cal = e.Row.FindControl("calendar1")
            '    cal.Visible = False
            '------------------------------------------------------
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

    'Sub ChargerListCliente()
    '    Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
    '    Dim myredaer As SqlDataReader
    '    Dim mycommand As SqlCommand
    '    Dim sql As String = "select *from client where idClient<>1"

    '    mycommand = New SqlCommand(sql, myConnection)
    '    ' mycommand.CommandText = "select *from client"
    '    myredaer = mycommand.ExecuteReader()

    '    clients.DataSource = myredaer
    '    clients.DataValueField = "idClient"
    '    clients.DataTextField = "Client"

    '    clients.DataBind()

    '    clients.Items.Insert(0, New ListItem("--select--", "0"))
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

            sql = "select codePanneau, panneau.id_panneau as ID_Panneau, panneau.ID_Famillepanneau as ID_Famille from panneau inner join MouvementStock on panneau.ID_panneau=MouvementStock.ID_panneau where  panneau.ID_Famillepanneau = " + nameFamille
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
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim myconnection As SqlConnection
        myconnection = CType(Session("myconnection"), SqlConnection)
        Dim myset As DataSet = New DataSet()
        '--------------------------------------------------------------
        Dim myApater As SqlDataAdapter
        Dim sql As String = "select *from commande where id_commande=0"
        myApater = New SqlDataAdapter(sql, myconnection)
        myApater.Fill(myset, "commande")
        '--------------------------------------------------------------
        Dim mycommand As SqlCommand = New SqlCommand("ajouterCommande", myconnection)
        mycommand.CommandType = CommandType.StoredProcedure
        Dim prm As SqlParameterCollection
        prm = mycommand.Parameters

        prm.Add("@id_client", SqlDbType.Int, 4, "ID_client")     ' on veux passer les paramettre svt commande : client/direction/dateintervention/quantite 
        prm.Add("@direction", SqlDbType.Int, 4, "id_direction")
        prm.Add("@date_Intervention", SqlDbType.DateTime, 8, "date_intervention")

        prm.Add("@qtt", SqlDbType.Int, 4, "Quantite")
        prm.Add("@Intervention", SqlDbType.Bit, 1, "Intervention")
        prm.Add("@type", SqlDbType.Char, 4, "TypeMission")
        '-----------------------------------------------------------
        Dim sortie As SqlParameter
        sortie = New SqlParameter("@id_commande", SqlDbType.Int, 4)
        sortie.Direction = ParameterDirection.Output
        '------------------------------------------------
        prm.Add(sortie)
        '-----------------------------------------------

        myApater.InsertCommand = mycommand




        '-----------------------------------------------
        Dim myrow As DataRow
        myrow = myset.Tables("commande").NewRow()
        '--------------------------------------------------
        myrow("ID_client") = clients.SelectedValue
        myrow("id_direction") = direction.SelectedValue

        myrow("date_intervention") = Calendrier.SelectedDate
        myrow("Quantite") = txtNoOfRecord.Text
        myrow("intervention") = "False"
        myrow("TypeMission") = type.Text
        myset.Tables("commande").Rows.Add(myrow)
        myApater.Update(myset, "commande")
        '-----------------------------------------------
        Dim linAdap As SqlDataAdapter



        Dim i As Integer
        Dim sqq As String = "select *from LigneCommande where id_lignecommande=0"
        linAdap = New SqlDataAdapter(sqq, myconnection)
        linAdap.Fill(myset, "LigneCommande")
        Dim build As SqlCommandBuilder = New SqlCommandBuilder(linAdap)
        Dim newR As Int32 = sortie.Value

        For i = 0 To (gvContacts.Rows.Count - 1)

            myrow = myset.Tables("LigneCommande").NewRow()

            myrow("id_commande") = newR
            myrow("id_panneau") = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text
            myrow("nbr_face") = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text
            myset.Tables("lignecommande").Rows.Add(myrow)
        Next

        linAdap.Update(myset, "lignecommande")



        Response.Redirect("production.aspx")




    End Sub







    ' Protected Sub Button1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click


    'If (Calendrier.Visible = True) Then
    '   Calendrier.Visible = False
    'Else
    '   Calendrier.Visible = True
    'End If
    ' End Sub

    
    Sub OnAnnulerClicked(sender As Object, e As EventArgs)

        Response.Redirect("production.aspx")


    End Sub

   





    


   

End Class
