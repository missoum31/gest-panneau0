<%@ Page Language="VB" %>
<%@ Register TagPrefix="anep" TagName="NavBar" Src="NavBar.ascx" %>
<%@ Register TagPrefix="anep" Namespace="anep.Controls" Assembly="anep.controls" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.Collections" %>
<%@ import Namespace="System.Data.SqlClient" %>

<script runat="server">

    Dim myConnection As SqlConnection 
    
        Sub RemplirListeAxesAnalyse()    
        
            Dim list As New ArrayList
            list.Add("par région")
            list.Add("par famille de produit")
            ListeAxes.DataSource = list
            ListeAxes.DataBind()
            ListeAxes.SelectedIndex = 0
            
        End Sub
    
        Sub RemplirListeMois()
        
            Dim list As New ArrayList
        list.Add("2015 - Janvier")
        list.Add("2015 - Février")
        list.Add("2015 - Mars")
        list.Add("2015 - Avril")
        list.Add("2015 - Mai")
        list.Add("2015 - Juin")
        list.Add("2015 - Juillet")
        list.Add("2015 - Août")
        list.Add("2015 - Septembre")
        list.Add("2015 - Octobre")
        list.Add("2015 - Novembre")
        list.Add("2015 - Décembre")
        ListeMois.DataSource = list
        ListeMois.DataBind()
        
    End Sub


    Sub Page_Load(sender As Object, e As EventArgs)

        myConnection = CType(Session("myConnection"), SqlConnection)
        '  Dim connStr As String = ConfigurationSettings.AppSettings("ConnectionString")
        ' myConnection = new SqlConnection(connStr)
    
        If (Not IsPostBack) Then
                      
            RemplirListeAxesAnalyse()
            RemplirListeMois()
    
            '    Carte.DataValueField = "Pourcentage"
            '   Carte.DataKeyField   = "ID_Region"
    
            Camembert.DataValueField = "Pourcentage"
            ' Camembert.DataTextField = "NomFamille"
            Camembert.DataTextField = "Region"

    
            ParametrerGraphique()
                 
        End If
             
    End Sub


    Function GetDataSource_Familles(mois As Integer) As DataView
         
        Dim param As String = String.Format("2015{0:D2}", mois)
        myConnection = CType(Session("myConnection"), SqlConnection)
        Dim myAdapter As SqlDataAdapter = New SqlDataAdapter("VentesMensuellesParFamille", myConnection)
        myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        myAdapter.SelectCommand.Parameters.Add("@Mois", SqlDbType.VarChar)
        myAdapter.SelectCommand.Parameters("@Mois").Value = param
    
        Dim myDataTable As New DataTable()
        myAdapter.Fill(myDataTable)
    
        Return myDataTable.DefaultView
             
    End Function

         


         

         
         Sub ParametrerGraphique()
         
             Dim mois As Integer = ListeMois.SelectedIndex+1
             Camembert.DataSource  = GetDataSource_Familles(mois)

               End Sub
               Sub ListeMois_SelectedIndexChanged(sender As Object,e As EventArgs)     
                  ParametrerGraphique()         
         End Sub
               Sub ListeAxes_SelectedIndexChanged(sender As Object,e As EventArgs) 
             ParametrerGraphique()
         End Sub

         


    </script>


<html>
<head>
<title>Analyse des ventes</title>

</head>
<body>
    
<form runat="server">
    

<h3>Répartition du chiffre d'affaire (en %)</h3>
<table bgcolor:"#ffffc0">
<tr><td>Axe d'analyse</td>


<td><asp:DropDownList id="ListeAxes" runat="server"
OnSelectedIndexChanged="ListeAxes_SelectedIndexChanged"
AutoPostBack="True"/>
</td>

</tr>
<tr><td>Période</td>
<td><asp:DropDownList id="ListeMois" runat="server"
OnSelectedIndexChanged="ListeMois_SelectedIndexChanged"
AutoPostBack="True"/>
</td></tr>
</table>
&nbsp;&nbsp; 
<p></p>
  <img src='LoadImage.aspx?path="+path+"&src=camembert.gif' style="width: 14px">
   
    <p></p>
    <p>
    <anep:Camembert id="Camembert" runat="server"/></p>
<a href="AnalyseVentes.aspx">
<p>
 <asp:Image ID="Home" runat="server" ImageAlign="Middle" ImageUrl="images/Home.gif" />Retour au menu principal</a></p>
</form>
</body>
</html>