Imports System.Data.SqlClient
Imports System.Data
Imports GestPanneau.share

Public Class WebForm4
    Inherits System.Web.UI.Page

    Dim val(6) As String
    Dim i As Integer = 1

    Dim myConnection As SqlConnection
    Dim myAdapter As SqlDataAdapter
    Dim myDataSet As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If (Not IsPostBack) Then

            view.ActiveViewIndex = 0

            Dim populate As share
            Dim myconnection As SqlConnection
            myconnection = CType(Session("myconnection"), SqlConnection)
            '   populateData()
            'ChargerListCliente()
            Calendrier.SelectedDate = DateTime.Now.AddDays(7)
            ' directionPopulate()
            '------------------------------------------------------
            populate = New share(direction, client, myconnection)

            populate.directionPopulate()
            populate.ChargerListCliente()
            '-----------------------------------------------------

            Button2.Visible = False
            annule.Visible = False
            Montant.Attributes.Add("onclick", "mimicPlaceholder()")
            Montant.Attributes.Add("onblur", "mimicPlaceholder()")

            NomCompagne.Attributes.Add("onclick", "cplaceholder()")
            NomCompagne.Attributes.Add("onblur", "cplaceholder()")


        End If

    End Sub

 






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

    'Private Sub populateData()
    '    Dim myconnection As SqlConnection
    '    myconnection = CType(Session("myconnection"), SqlConnection)
    '    Dim mycommand As SqlCommand
    '    mycommand = New SqlCommand("select *from MouvementStock", myconnection)

    '    Dim dt As DataTable
    '    dt = New DataTable()
    '    Dim red As SqlDataReader
    '    red = mycommand.ExecuteReader()
    '    GridView1.DataSource = dt
    '    GridView1.DataBind()
    '    red.Close()




    'End Sub



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

    '    client.Items.Insert(0, New ListItem("--select Client--", "0"))
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
        Dim i As Integer
        Dim myPanneau(10) As String
        myPanneau(i) = 1
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

            sql = "select codePanneau, panneau.id_panneau as ID_Panneau, panneau.ID_Famillepanneau as ID_Famille, SUM(nombreFace) from panneau inner join MouvementStock on panneau.ID_panneau=MouvementStock.ID_panneau Group by codePanneau,panneau.ID_panneau, panneau.ID_Famillepanneau having SUM(nombreFace) > 0  And panneau.ID_Famillepanneau = " + nameFamille
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
            myPanneau(i) = ddm.Text

        End If
    End Sub
    'fonction se declanche en changeon ddl panneau
    Protected Sub panneau_SelectedIndexChanged1(sender As Object, e As EventArgs)
        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim nombr As Integer = 0
        Dim nombre As Integer = 0
        Dim ddp As DropDownList = grid.FindControl("panneau")





        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)

        Dim nbrface As DropDownList = grid.FindControl("nbrface")
        Dim nomb As Integer = 0

        Dim resultat As New Object()
        Dim mycome As SqlCommand = New SqlCommand()
        Dim nub As String
        '   Dim riders As SqlCommand
        'mycome = New SqlCommand(somme, myConnection)
        '    mycome.CommandType = CommandType.Text
        Dim flag As Boolean = True
        Dim i As Integer
        For i = 0 To (gvContacts.Rows.Count - 1)
            Dim ddpr As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text
            Dim sz As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text




            nub = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text

            mycome = New SqlCommand("select SUM(nombreFace) from mouvementstock where id_panneau=" + sz, myConnection)



            mycome.CommandType = CommandType.Text
            resultat = mycome.ExecuteScalar()

          



            If ddp.Text = ddpr Then
                nombre = nombre + 1

            End If
            If (ddpr = "") Or (ddpr = "0") Then

                nomb = nomb + 1

            End If
           
            If (nub > resultat.ToString) Then
                flag = False
            End If
        Next


        If (nomb <> 0) Or (nombre > 1) Or (flag = False) Then
            Button2.Visible = False
        Else
            Button2.Visible = True
        End If



    End Sub







    Protected Sub gvContacts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvContacts.SelectedIndexChanged

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim obj As New Object()
        Dim nbr As String = ddp.SelectedValue
        Dim sql As String = "select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + nbr
        Dim myCom As SqlCommand
        myCom = New SqlCommand(sql, myConnection)
        myCom.CommandType = CommandType.Text

        obj = myCom.ExecuteScalar()

        '  MsgBox(obj)




    End Sub



    
































    Protected Function validerForm(sender As Object, e As EventArgs) As Boolean

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")

        Dim disp As Label = grid.FindControl("chifre")
        Dim nomb As Integer = 0
        Dim nombre As Integer = 0
        Dim resultat As Object = New Object()
        Dim mycome As SqlCommand = New SqlCommand()
        Dim nub As String = ddp.SelectedValue
        '   Dim riders As SqlCommand
        'mycome = New SqlCommand(somme, myConnection)
        '    mycome.CommandType = CommandType.Text
        Dim flag As Boolean = True
        Dim i As Integer

        Dim sze As String
        Dim sz As String

        '--------------------remplir label disponible-----------------------------------
        mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + nub, myConnection)

        ' If (IsNothing(mycome)) Then

        mycome.CommandType = CommandType.Text
        resultat = mycome.ExecuteScalar()


        disp.Text = resultat.ToString
        '--------------------------------------------------------------------------------




        For i = 0 To (gvContacts.Rows.Count - 1)
            sze = CType(gvContacts.Rows(i).FindControl("fpanneau"), DropDownList).Text
            sz = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text



            sz = CType(gvContacts.Rows(0).FindControl("panneau"), DropDownList).Text

            mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + sz, myConnection)
            ' If (IsNothing(mycome)) Then
            If (IsNothing(mycome)) Then
                '
                MsgBox("dommmage" + i)
            Else
                mycome.CommandType = CommandType.Text
                resultat = mycome.ExecuteScalar()


            End If
            Dim ddpr As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text

            Dim ddnbr As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text


            If ddp.Text = ddpr Then
                nombre = nombre + 1

            End If
            If (ddpr = "") Or (ddpr = "0") Then

                nomb = nomb + 1

            End If



            If (ddnbr.ToString > resultat.ToString) Then
                flag = False
            End If
            disp.Text = resultat.ToString

        Next
    




        If (nomb <> 0) Or (nombre > 1) Or (flag = False) Then
            Return False
        Else
            Return True
        End If







    End Function

 




















    Protected Sub nbrface_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim curenrDrop As DropDownList = sender
        Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        Dim ddp As DropDownList = grid.FindControl("panneau")
        Dim nbrface As DropDownList = grid.FindControl("nbrface")
        Dim disp As Label = grid.FindControl("chifre")
        Dim nomb As Integer = 0
        Dim nombre As Integer = 0
        Dim resultat As Object = New Object()
        Dim mycome As SqlCommand = New SqlCommand()
        Dim nub As String = ddp.SelectedValue
        '   Dim riders As SqlCommand
        'mycome = New SqlCommand(somme, myConnection)
        '    mycome.CommandType = CommandType.Text
        Dim flag As Boolean = True
        Dim i As Integer

        Dim sze As String
        Dim sz As String






        For i = 0 To (gvContacts.Rows.Count - 1)
            sze = CType(gvContacts.Rows(i).FindControl("fpanneau"), DropDownList).Text
            sz = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text





            mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + sz, myConnection)
            ' If (IsNothing(mycome)) Then
            If (sz = "") Then
                mycome.CommandType = CommandType.Text
                ' MsgBox("111errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr")
            Else
                mycome.CommandType = CommandType.Text
                resultat = mycome.ExecuteScalar()

                '   MsgBox("2emmmmmmmmmmmmmmmmme")

            End If
            Dim ddpr As String = CType(gvContacts.Rows(i).FindControl("panneau"), DropDownList).Text

            Dim ddnbr As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text
          

            If ddp.Text = ddpr Then
                nombre = nombre + 1

            End If
            If (ddpr = "") Or (ddpr = "0") Then

                nomb = nomb + 1

            End If



            If (ddnbr.ToString > resultat.ToString) Then
                flag = False
            End If
            disp.Text = resultat.ToString


            '   MsgBox("nbr choisie  " + ddnbr)
            '   MsgBox("le disponible " + resultat.ToString)
        Next
        mycome = New SqlCommand("select SUM(nombreFace) AS dispo from MouvementStock where ID_panneau=" + nub, myConnection)

        ' If (IsNothing(mycome)) Then

        mycome.CommandType = CommandType.Text
        resultat = mycome.ExecuteScalar()
        

        disp.Text = resultat.ToString




        If (nomb <> 0) Or (nombre > 1) Or (flag = False) Then
            Button2.Visible = False
            check.Visible = True
        Else
            Button2.Visible = True
            check.Visible = False
        End If







    End Sub
    Sub valider(e As GridViewRow)
        Dim mycome As SqlCommand = New SqlCommand()

        Dim aze As String = e.RowIndex


        '   Dim ss As Int32 = CInt(somme)

        mycome = New SqlCommand("select SUM(nombreFace) from mouvementstock where id_panneau=" + aze, myConnection)

        mycome.CommandType = CommandType.Text

        '   Dim myval As Int32 = Convert.ToInt32(mycome.ExecuteScalar())
        ' riders = mycome.ExecuteScalar()
        '  Dim ss As Int32 = myval

        Dim myval As Int32 = Convert.ToInt32(mycome.ExecuteScalar())

        '  MsgBox(myval)

    End Sub



    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click


        '  Dim row As GridViewRow = gvContacts.Rows(e.AffectedRows)





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


        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim myrow As DataRow = myset.Tables("Compagne").NewRow()
        myrow("nbrPanneau") = System.Convert.ToInt32(txtNoOfRecord.Text)
        myrow("id_Client") = client.SelectedItem.Value
        myrow("datePrevu") = Calendrier.SelectedDate
        myrow("NomCompagne") = NomCompagne.Text
        myrow("Montant") = System.Convert.ToDecimal(Montant.Text)
        myrow("id_region") = direction.SelectedItem.Value
        myset.Tables("Compagne").Rows.Add(myrow)
        myAdapter.Update(myset, "compagne")




        '--------------------------------------------------------------------------------------------
        Dim lineAdapter As SqlDataAdapter
        sql = "select *from mouvementstock where Id_Mouvementstock=0"
        lineAdapter = New SqlDataAdapter(sql, myConnection)

        lineAdapter.Fill(myset, "Mouvementstock")

        Dim myBuild As SqlCommandBuilder = New SqlCommandBuilder(lineAdapter)
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim newMvt As Int32 = bara.Value
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        Dim nbrSouver(20) As String

        '--------------------------------------------------------------------------------------------
        Dim i As Integer
        For i = 0 To (gvContacts.Rows.Count - 1)
            ' Dim myObjet As Object
            myrow = myset.Tables("Mouvementstock").NewRow()

            '  CType(GridView1.Rows(e.RowIndex).FindControl("ddPeriods"), DropDownList)



            ' myObjet = gvContacts.Rows(i).Cells(3).FindControl("duree")

            Dim nub As String = CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text

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

            nbrSouver(i) = myval

            'comparer le nbre de face panneau avec le nombre validés





            '   Dim ss As Int32 = CInt(somme)
            Dim ss As Int32 = myval

            If (CType(gvContacts.Rows(i).FindControl("datefin"), TextBox).Text <= Calendrier.SelectedDate) Then

            End If


            If (CType(gvContacts.Rows(i).FindControl("nbrface"), DropDownList).Text > nbrSouver(i)) Then

                '   MsgBox("Erreure de saisie")
                Dim Sqlo As String
                Sqlo = "delete from compagne where idCompagne=" + newMvt.ToString
                Dim mycom As SqlCommand
                mycom = New SqlCommand(Sqlo, myConnection)

                Dim rider As SqlDataReader
                rider = mycom.ExecuteReader()
                rider.Close()


                Response.Redirect("webform4.aspx")

            End If

            myset.Tables("MouvementStock").Rows.Add(myrow)
        Next
        Dim mycam As SqlCommand
        Dim sqe As String = "select count(id_panneau) as nbr from MouvementStock group by ID_panneau order by  count(id_panneau) desc"

        mycam = New SqlCommand(sqe, myConnection)
        mycam.CommandType = CommandType.Text
        Dim myValue As Int32 = Convert.ToInt32(mycam.ExecuteScalar())




        lineAdapter.Update(myset, "Mouvementstock")



        Response.Redirect("FinCommande.aspx?id=" + newMvt.ToString())

    End Sub







    ' Protected Sub Button1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click


    'If (Calendrier.Visible = True) Then
    '   Calendrier.Visible = False
    'Else
    '   Calendrier.Visible = True
    'End If
    ' End Sub

    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendrier.SelectionChanged
        '    Dim cellule As calendar = sender

        TextBox3.Text = Calendrier.SelectedDate.ToString()



    End Sub

    ' Protected Sub Button1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
    'Dim curenrDrop As ImageButton = sender
    'Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
    'Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
    'Dim ddc As Calendar = grid.FindControl("Calendrier")

    '   If (ddc.Visible = True) Then
    '     ddc.Visible = False
    '  Else
    '    ddc.Visible = True
    'End If
    'End Sub

    'Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendrier.SelectionChanged
    'Dim cellule As Calendar = sender

    'Dim grid As GridView = (cellule.Parent.Parent)
    'Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
    'Dim ddc As Calendar = grid.FindControl("Calendrier")
    'Dim ddd As TextBox = grid.FindControl("TextBox3")


    '  ddd.Text = ddc.SelectedDate.ToString()
    '   ddc.Visible = False


    'End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs)

    End Sub


    Protected Sub gvContacts_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvContacts.EditIndex = e.NewEditIndex




    End Sub

    Protected Sub gvContacts_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvContacts.EditIndex = -1
        gvContacts.DataBind()


    End Sub


    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        view.ActiveViewIndex = 1
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        view.ActiveViewIndex = 2
        label1.Text = direction.SelectedItem.Text
        label2.Text = NomCompagne.Text
        label3.Text = client.SelectedItem.Text
        label4.Text = Montant.Text
        label5.Text = Calendrier.SelectedDate
        label6.Text = txtNoOfRecord.Text
    End Sub

    Protected Sub check_Click(sender As Object, e As EventArgs)
        '   Dim curenrDrop As Button = sender
        '     Dim grid As GridViewRow = (curenrDrop.Parent.Parent)
        Dim myConnection As SqlConnection = CType(Session("myConnection"), SqlConnection)
        '    Dim ddp As DropDownList = grid.FindControl("panneau")
        '    Dim nbrface As DropDownList = grid.FindControl("nbrface")
        '    Dim disp As Label = grid.FindControl("chifre")
        Dim nomb As Integer = 0
        Dim nombre As Integer = 0
        Dim resultat As Object = New Object()
        Dim mycome As SqlCommand = New SqlCommand()
        '  Dim nub As String = ddp.SelectedValue
        '   Dim riders As SqlCommand
        'mycome = New SqlCommand(somme, myConnection)
        '    mycome.CommandType = CommandType.Text
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
                '     MsgBox("111errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr")
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






            'If (i > 0) Then
            '    ddp = CType(gvContacts.Rows(i - 1).FindControl("panneau"), DropDownList).Text
            'End If

            If ddp = ddpr Then
                nombre = nombre + 1

            End If
            If (ddpr = "") Or (ddpr = "0") Then

                nomb = nomb + 1

            End If






            If (ddnbr.ToString > resultat.ToString) Then
                flag = False
            End If



            



            CType(gvContacts.Rows(i).FindControl("dispo"), Label).Text = resultat.ToString


        Next



        If (nomb <> 0) Or (nombre > 0) Or (flag = False) Then
            Button2.Visible = False
            txtt.Text = "Modifier Votre Commande SVP"
        Else
            check.Visible = False
            Button2.Visible = True
            gvContacts.Enabled = False
            annule.Visible = True
            txtt.Text = ""
        End If

    End Sub

    Protected Sub annule_Click(sender As Object, e As EventArgs)
        Button2.Visible = False
        check.Visible = True
        annule.Visible = False
        gvContacts.Enabled = True
    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        view.ActiveViewIndex = 0
    End Sub

  
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        view.ActiveViewIndex = 1
    End Sub
End Class
