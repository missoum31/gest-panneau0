Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Web.UI.WebControls.GridView

Public Class production
    Inherits System.Web.UI.Page


    Dim myConnection As SqlConnection


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        myConnection = CType(Session("myConnection"), SqlConnection)

        If (IsPostBack = False) Then
            ViewState("PageIndex") = 0
            ChargerListeCommandes(0)
        End If

        '   If (contex) Then

        '  End If

    End Sub
    Sub ChargerListeCommandes(index As Int32)

        Dim myConnection As SqlConnection
        Dim myAdapter As SqlDataAdapter
        Dim myDataTable As DataTable
        Dim Sql As String
        Dim myPager As PagedDataSource




        myConnection = CType(Session("myConnection"), SqlConnection)


        Sql = "ListeCommandes"
        If (userName = "anepWest") Then
            Sql = "ListeCommande"
        End If
        If (userName = "DirectionEst") Then
            Sql = "ListeCommand"
        End If
        If (userName = "DirectionCentre") Then
            Sql = "ListeComm"
        End If
       

        myAdapter = New SqlDataAdapter(Sql, myConnection)

        myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        myDataTable = New DataTable()
        myAdapter.Fill(myDataTable)
        ListeCommandes.DataSource = myDataTable.DefaultView
        ListeCommandes.DataBind()

        myPager = New PagedDataSource()
        myPager.DataSource = myDataTable.DefaultView


        myPager.AllowPaging = True
        myPager.PageSize = 8
        myPager.CurrentPageIndex = index
        ListeCommandes.DataSource = myPager
        ListeCommandes.DataBind()



        If (ListeCommandes.Items.Count = 0) Then
            ListeVide.Visible = True
        Else
            ListeVide.Visible = False
        End If
        MettreAJourAffichagePagination(myPager.CurrentPageIndex + 1, myPager.PageCount)

    End Sub


    

    Public Sub OnItemCreated(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim myDeleteButton As LinkButton
        If (e.Item.ItemType = ListItemType.Item) Then
            myDeleteButton = e.Item.FindControl("btndelete")
            myDeleteButton.Attributes.Add("onclick", "return confirm('Confirmez-vous la suppression de cette commande ?');")
        End If
    End Sub


    Sub MettreAJourAffichagePagination(NumeroPage As Int32, NombrePages As Int32)

        If (NumeroPage = NombrePages) Then
            PageSuivante.Visible = False
        Else
            PageSuivante.Visible = True
        End If

        If (NumeroPage = 1) Then
            PagePrecedente.Visible = False
        Else
            PagePrecedente.Visible = True
        End If

        NoPage.Text = NumeroPage.ToString()
        NbPages.Text = NombrePages.ToString()

    End Sub


    Sub OnItemCommand(sender As Object, e As RepeaterCommandEventArgs) Handles ListeCommandes.ItemCommand

        Dim SQL As String
        Dim myCommand As SqlCommand

        SQL = "DELETE FROM LigneCommande WHERE ID_Commande = " + e.CommandArgument

        myConnection = CType(Session("myConnection"), SqlConnection)
        myCommand = New SqlCommand(SQL, myConnection)


        myCommand.ExecuteNonQuery()
        SQL = "delete from Commande where ID_Commande not in (select ID_Commande from LigneCommande )"
        myCommand = New SqlCommand(SQL, myConnection)

        myCommand.ExecuteNonQuery()
        ChargerListeCommandes(0)

    End Sub







    Function AfficherBooleen(o As Object) As String
        If (o = True) Then
            Return "Oui"
        Else
            Return "Non"
        End If
    End Function

    Function affichage(o As Integer) As String
        If (o = 1) Then
            Return "Affichage"
        ElseIf (o = 2) Then
            Return "DésAffichage"
        Else : Return "Maintenance"
        End If
    End Function

    Sub OnPageSuivante(ByVal sender As Object, ByVal e As EventArgs)

        ' Récupération de la valeur actuelle de PageIndex
        Dim PageIndex As Int32
        PageIndex = ViewState("PageIndex")

        ' Incrémentation (rq : on est assuré que PageIndex < PageCount grace à MettreAJourAffichage)

        PageIndex = PageIndex + 1

        ' Chargement de la page correspondante
        ChargerListeCommandes(PageIndex)

        ' Sauvegarde de la nouvelle valeur de PageIndex

        ViewState("PageIndex") = PageIndex

    End Sub

    Sub OnPagePrecedente(ByVal sender As Object, ByVal e As EventArgs)

        ' Récupération de la valeur actuelle de PageIndex

        Dim PageIndex As Int32
        PageIndex = ViewState("PageIndex")

        ' Incrémentation (rq : on est assuré que PageIndex > 0 grace à MettreAJourAffichage)

        PageIndex = PageIndex - 1

        ' Chargement de la page correspondante

        ChargerListeCommandes(PageIndex)

        ' Sauvegarde de la nouvelle valeur de PageIndex

        ViewState("PageIndex") = PageIndex

    End Sub




End Class