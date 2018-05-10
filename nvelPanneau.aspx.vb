Imports System.Data.SqlClient
Imports System.Data


Public Class nvelPanneau
    Inherits System.Web.UI.Page



    Dim myConnection As SqlConnection
    Dim myAdapter As SqlDataAdapter
    Dim myDataSet As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        If (Not IsPostBack) Then
            Dim myconnection As SqlConnection
            myconnection = CType(Session("myconnection"), SqlConnection)
          


            Calendrier.SelectedDate = DateTime.Now.AddDays(7)


            TextBox3.Text = DateTime.Now.AddDays(7).ToShortDateString
            nomCompagne.Text = DateTime.Now.AddDays(7).ToShortDateString


            populateData()
            ChargerListCliente()
           
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
            Dim cal As Calendar
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
    'fonction se declanche en changeon ddl panneau
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
                MsgBox("y'a plus d' espace a louer")

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

        '  MsgBox(sql)




    End Sub


    Protected Sub nbrface_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")



        Dim nbr As String = ddp.SelectedValue.ToString

        '  MsgBox(gvContacts.Rows.Count)

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




        Dim mycommand As SqlCommand

        mycommand = New SqlCommand("ajouterCompagne", myConnection)
        mycommand.CommandType = CommandType.StoredProcedure
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        'les parametres de la command mycommand serons passé au variable param
        Dim param As SqlParameterCollection = mycommand.Parameters
        param.Add("@nomCompagne", SqlDbType.Char, 4, "NomCompagne")
        param.Add("@idClient", SqlDbType.Int, 4, "id_Client")
        param.Add("@datePrevu", SqlDbType.DateTime, 8, "datePrevu")
        param.Add("@nbrPanneau", SqlDbType.Int, 4, "nbrPanneau")
        param.Add("@Montant", SqlDbType.Int, 4, "Montant")
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
        '--------------------------------------------------------------------------------------------
        Dim myrow As DataRow = myset.Tables("Compagne").NewRow()
        myrow("nbrPanneau") = System.Convert.ToInt32(txtNoOfRecord.Text)
        myrow("id_Client") = client.SelectedItem.Value
        myrow("datePrevu") = Calendrier.SelectedDate.ToString()
        myrow("NomCompagne") = nomCompagne.Text
        myrow("Montant") = System.Convert.ToDecimal(Montant.Text)

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
            ' Dim myObjet As Object


            '  CType(GridView1.Rows(e.RowIndex).FindControl("ddPeriods"), DropDownList)



            ' myObjet = gvContacts.Rows(i).Cells(3).FindControl("duree")

            Dim nub As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text
            myrow = myset.Tables("Mouvementstock").NewRow()
            Dim s As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text
            myrow("ID_panneau") = s
            myrow("nombreFace") = -nub
            ' myrow("Duree") = CType(gvContacts.Rows(i).FindControl("duree"), TextBox).Text
            myrow("DateMouvement") = CType(gvContacts.Rows(i).FindControl("datefin"), TextBox).Text
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

            MsgBox("Left nombre de panneau choisie")
            MsgBox(Convert.ToInt32(nub))

            MsgBox("le resultat de la somme est:")
            MsgBox(myval)

            'comparer le nbre de face panneau avec le nombre validés





            '   Dim ss As Int32 = CInt(somme)
            Dim ss As Int32 = myval


            If (nub > System.Convert.ToInt32(txtNoOfRecord.Text)) Then
                MsgBox(ss)
                MsgBox("Erreure de saisie")
                Dim Sqlo As String
                Sqlo = "delete from compagne where idCompagne=" + newMvt.ToString
                Dim mycom As SqlCommand
                mycom = New SqlCommand(Sqlo, myConnection)

                Dim rider As SqlDataReader
                rider = mycom.ExecuteReader()
                rider.Close()


                Response.Redirect("nvelPanneau.aspx")

            End If

            myset.Tables("MouvementStock").Rows.Add(myrow)
        Next

        lineAdapter.Update(myset, "Mouvementstock")



        Response.Redirect("FinCommande.aspx?id=" + newMvt.ToString())

    End Sub

   

    Protected Sub Calendrier_SelectionChanged(sender As Object, e As EventArgs) Handles Calendrier.SelectionChanged
        TextBox3.Text = Calendrier.SelectedDate.ToShortDateString()
    End Sub
End Class
