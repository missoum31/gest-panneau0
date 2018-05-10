Imports System.Data.SqlClient
Imports System.Data



Public Class parc
    Inherits System.Web.UI.Page

    '  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub
    

 




    Sub ChargerListeRegion()
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReader As SqlDataReader
        Dim SQL As String
        myConnection = CType(Session("myConnection"), SqlConnection)
        SQL = "SELECT  * FROM ville where ID_ville=31 or ID_ville=16 or ID_ville=25 "
        If (userName = "anepWest") Then
            SQL = "SELECT * FROM ville where nom = 'Oran'"
        End If
        If (userName = "DirectionEst") Then
            SQL = "SELECT * FROM ville where nom = 'Constantine'"
        End If
        If (userName = "DirectionCentre") Then
            SQL = "SELECT * FROM ville where nom = 'Alger'"
        End If
        myCommand = New SqlCommand(SQL, myConnection)
        myReader = myCommand.ExecuteReader()

        region.DataSource = myReader
        region.DataValueField = "idRegion"
        region.DataTextField = "nom"
        region.DataBind()
        myReader.Close()
    End Sub


    Sub ChargerListeVille()
        Dim myCommand As SqlCommand
        Dim myReaderr As SqlDataReader
        Dim myConnectione As SqlConnection
        Dim RegionID As String

        myConnectione = CType(Session("myConnection"), SqlConnection)
        RegionID = region.SelectedItem.Value
        Dim sqlz As String = "select ID_ville, ville from ville where idRegion =" + RegionID

        '   myCommand = New SqlCommand("EtatVille", myConnectione)
        ' myCommand.CommandType = CommandType.StoredProcedure
        ' myCommand.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegionID
        myCommand = New SqlCommand(sqlz, myConnectione)
        myReaderr = myCommand.ExecuteReader()

        ville.DataSource = myReaderr
        ville.DataValueField = "ID_ville"
        ville.DataTextField = "ville"
        ville.DataBind()
        myReaderr.Close()

    End Sub


    Sub ChargerListeFamilles()
        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myReadere As SqlDataReader
        '        Dim SQL As String
        Dim villeId As String
        myConnection = CType(Session("myConnection"), SqlConnection)
        villeId = ville.SelectedItem.Value
        myCommand = New SqlCommand("EtatPanneau", myConnection)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@villeId", SqlDbType.Int).Value = villeId

        myReadere = myCommand.ExecuteReader()

        ListeFamilles.DataSource = myReadere
        ListeFamilles.DataValueField = "ID_Famillepanneau"
        ListeFamilles.DataTextField = "NomFamille"
        ListeFamilles.DataBind()
        myReadere.Close()

        'Catch e As Exception
        'Response.Redirect("Erreur.aspx?message=" + e.Message)
        'End Try
        ' myConnection.Close()
    End Sub


    Sub AfficherStocksProduits()
        Dim myCommand As SqlCommand
        Dim myRead As SqlDataReader
        Dim myConnection As SqlConnection
        Dim FamilleID As String
        Dim FamilleIdent As String
        myConnection = CType(Session("myConnection"), SqlConnection)



        FamilleID = ListeFamilles.SelectedItem.Value
        FamilleIdent = ville.SelectedItem.Value
        myCommand = New SqlCommand("EtatStock", myConnection)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@FamilleID", SqlDbType.Int).Value = FamilleID


        myCommand.Parameters.Add("@FamilleIdent", SqlDbType.Int).Value = FamilleIdent

        myRead = myCommand.ExecuteReader()

        EtatStocks.DataSource = myRead
        EtatStocks.DataBind()

        myRead.Close()

        'myConnection = CType(Session("myConnection"),SqlConnection)

        'myReader.Close


    End Sub



    


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ChargerListeRegion()
            ChargerListeVille()
            ChargerListeFamilles()
            AfficherStocksProduits()

        End If
    End Sub
    Sub OnFamilleChanged(sender As Object, e As EventArgs)

        AfficherStocksProduits()

    End Sub
    

    ' Sub OnVilleChanged()
    '    ChargerListeVille()
    'End Sub
    'Sub OnPanneauChanged(sender As Object, e As EventArgs)
    '   ChargerListeFamilles()
    '  AfficherStocksProduits()
    'End Sub


    Protected Sub ville_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub OnVilleChanged(sender As Object, e As EventArgs) Handles region.SelectedIndexChanged
        ChargerListeVille()
        ChargerListeFamilles()
        AfficherStocksProduits()
    End Sub

    Protected Sub OnPanneauChanged(sender As Object, e As EventArgs) Handles ville.SelectedIndexChanged
        ChargerListeFamilles()
        AfficherStocksProduits()
    End Sub
End Class