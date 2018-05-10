Public Class NavBar
    Inherits System.Web.UI.UserControl


    Public SelectedIndex As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        userName = Context.User.Identity.Name
        Utilisateur.Text = userName
        Rubrique1.Text = "Accueil"
        Rubrique1.NavigateUrl = "default.aspx"

        Rubrique2.Text = "Panneau"
        Rubrique2.NavigateUrl = "parc.aspx"

        Rubrique3.Text = "Situation"
        Rubrique3.NavigateUrl = "production.aspx"

        '  Rubrique31.Text = "Situations"
        ' Rubrique31.NavigateUrl = "productionOuest.aspx"

        'Rubrique22.NavigateUrl = "productionEst.aspx"
        'Rubrique22.Text = " Situation."

        'Rubrique16.NavigateUrl = "productionCentre.aspx"
        'Rubrique16.Text = " Situation"

        Rubrique4.Text = "Ventes"
        Rubrique4.NavigateUrl = "AnalyseVentes.aspx"

        Rubrique5.Text = "Archive"
        Rubrique5.NavigateUrl = "ArchivesCommande.aspx"


        Rubrique6.Text = "MAJ de la BDD"
        Rubrique6.NavigateUrl = "webform4.aspx"


        Rubrique7.Text = "Réservé Panneau"
        Rubrique7.NavigateUrl = "reservation.aspx"


        Select Case SelectedIndex
            Case 0
                Titre.Text = "Acceuil Intranet"
                Rubrique1.CssClass = "active-rubrique"
            Case 1
                Titre.Text = "Suivi du Parc Panneau"
                Rubrique2.CssClass = "active-rubrique"
            Case 2
                Titre.Text = "Gestion des panneaux"
                Rubrique3.CssClass = "active-rubrique"
            Case 3
                Titre.Text = "Analyse des Ventes"
                Rubrique4.CssClass = "active-rubrique"
            Case 4
                Titre.Text = "Archive"
                Rubrique5.CssClass = "active-rubrique"

            Case 5

                Titre.Text = "Mise A Jour de la Base de Donnee"
                Rubrique6.CssClass = " active-rubrique"
            Case 6
                Titre.Text = "Reservation panneau"
                Rubrique7.CssClass = "active-rubrique"
        End Select




    End Sub



End Class