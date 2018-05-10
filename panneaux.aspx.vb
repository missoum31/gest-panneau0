Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System
Imports System.Xml.Xsl
Imports GestPanneau.AbderrezakMissoum

Public Class panneaux
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' SetImageUrl()
        End If
        Dim ID As String
        Dim myConnection As SqlConnection
        Dim myReader, myreadere As SqlDataReader
        Dim myCommand, myCommande As SqlCommand
        ID = Request.Params("id")

        myConnection = CType(Session("myConnection"), SqlConnection)

        ' Commande associée à la procédure stockée

        myCommand = New SqlCommand("HistoriqueStocks", myConnection)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@panneauID", SqlDbType.Int).Value = ID
        'myCommand.Parameters("@panneauID").Value = Request.Params("id")

        ' Ouverture de la connexion 

        ' myConnection.Open()



        ' Récupération du nom du produit
        myReader = myCommand.ExecuteReader()
        myReader.Read()
        Nompanneau.Text = myReader.GetString(1)

        myReader.Close()


        ' Paramètrage de la grille de données
        myCommande = New SqlCommand("HistoriqueStocks", myConnection)
        myCommande.CommandType = CommandType.StoredProcedure
        myCommande.Parameters.Add("@panneauID", SqlDbType.Int).Value = ID
        myReadere = myCommand.ExecuteReader()
        'myReader.Read()
        HistoriqueStock.DataSource = myreadere
        HistoriqueStock.DataBind()
        myReadere.Close()

        ' Fermeture de la connexion 

        ' myConnection.Close(


        ID = Request.Params("id")
        Dim mygenerat As googleSingle
        Dim Path As String
        Path = Request.MapPath(Request.ApplicationPath) + "\\xmlPanneauSingle\\"
        mygenerat = New googleSingle(ID, myConnection, Path)
        Dim xslFiles As String
        '   xslFiles = "GenererTel.xsl"
        ' htmlFiles = "ArchiveNext.html"

        xslFiles = "positionGeogSingle" + ID + ".xml"
        mygenerat.genererXmlSingle(xslFiles)
        'mygenerat.genererTel(xslFiles, xslFiles, htmlFiles)




        Dim PopupArgs As String

        PopupArgs = "'scrollbars=no,status=no,resizable=yes,width=500,height=400'"

        voir.NavigateUrl = "javascript:openpopup('xmlPanneauSingle/" + xslFiles + "'," + PopupArgs + ")"
        ' Fax.NavigateUrl = "javascript:openpopup('xmlArch/" + htmlFiles + "'," + PopupArgs + ")"





    End Sub

  




    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '  Dim myConnection As SqlConnection
        Dim sath As String ' ajouter
        Dim extension As String
        Dim name As String
        ' Dim extension As String
        ' Dim sath As String ' ajouter
        sath = Server.MapPath("/imgPanneau/")
        name = ""
        If FileUpload1.HasFile Then
            extension = Path.GetExtension(FileUpload1.FileName)
            If (extension = ".jpg") Or (extension = ".jpeg") Or (extension = ".png") Then

                FileUpload1.SaveAs(sath + FileUpload1.FileName)
                '   name = "~/imgPanneau/" + FileUpload1.FileName
                name = "imgPanneau/" + FileUpload1.FileName
                MsgBox(name)
            End If
        End If
        Dim myconnection As SqlConnection = CType(Session("myconnection"), SqlConnection)

        Dim ID As String = (Request.Params("id"))


        ' Dim myCommand As SqlCommand
        ' Dim myReadere As SqlDataReader
        

        'Dim myset As DataSet = New DataSet()
        Dim adapter As SqlDataAdapter
        Dim SelectSQL As String = "imgInsert"
        '  Dim sqa As String = "select *from mouvementstock where id_panneau =" + ID
        '  Dim upd As String = "UPDATE mouvementStock Set img='" + name + "' WHERE ID_panneau  =" + ID
        Dim sqa As String = "select *from panneau where ID_panneau =" + ID
        Dim upd As String = "UPDATE panneau Set imgs='" + name + "' WHERE ID_panneau  =" + ID

        'adapter = New SqlDataAdapter(sqa, myconnection)  'initialisé le shema de dataAdapter
        'adapter.Fill(myset, "mouvementstock")
        ' adapter.SelectCommand.Parameters.Add("@id_panneau", SqlDbType.Bit, 1, "id_panneau")

        'adapter.SelectCommand.Parameters("@id_panneau").Value = ID

        adapter = New SqlDataAdapter(SelectSQL, myconnection)

        adapter.SelectCommand.CommandType = CommandType.StoredProcedure
        adapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int)
        adapter.SelectCommand.Parameters("@ID").Value = ID


        Dim table As DataTable = New DataTable()
        adapter.Fill(table)


        adapter.UpdateCommand = New SqlCommand(upd, myconnection)
        ' adapter.UpdateCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "DateMouvement")
        adapter.UpdateCommand.Parameters.Add("name", SqlDbType.VarChar, 4, "imgs")
        table.Rows(0)("imgs") = name
        adapter.Update(table)
        ' ------------------------------------------------------
        '  Dim mycommad As SqlCommand
        'mycommad = New SqlCommand("imgInsert", myconnection)
        ' mycommad.CommandType = CommandType.StoredProcedure
        ' mycommad.Parameters.Add("@ID", SqlDbType.Int).Value = ID


        '   adapter = New SqlDataAdapter("imgInsert", myconnection)

        '    adapter.SelectCommand.CommandType = CommandType.StoredProcedure
        '   adapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int)
        '  adapter.SelectCommand.Parameters("@ID").Value = ID

        '-------------------------------------------------------------

        'adapter.UpdateCommand = mycommad
        ' adapter.Update(myset, "mouvementstock")
        ' MsgBox("bien derouler")
        '-------------------------------------------------------

    End Sub

    Protected Sub GridView2_RowDeleting(sender As Object, e As EventArgs) ' GridViewDeletedEventArgs)
        Dim rr As GridViewRow
        Dim i As Integer
        Dim ID As String = Request.Params("id")
        Dim myConnection As SqlConnection
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim linkRemove As LinkButton = DirectCast(sender, LinkButton)



        If (userName <> "ADMINISTRATEUR") Then



            Dim cmd As SqlCommand = New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete from mouvementstock where id_mouvementstock=@id ;"
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = linkRemove.CommandArgument


            HistoriqueStock.DataSource = GetData(cmd)
            HistoriqueStock.DataBind()
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
 
    Protected Sub HistoriqueStock_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class