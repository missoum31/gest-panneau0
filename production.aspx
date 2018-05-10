<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="production.aspx.vb" Inherits="GestPanneau.production" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <%@ Register TagPrefix="anep" TagName="NavBar" Src="~/NavBar.ascx" %>
   
               <!-- <h3><%: Title %></h3>-->
                <anep:NavBar id="NavBar" selectedIndex="2" runat="server"></anep:NavBar>
         
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>











<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" >



  <h3> Listes des Interventions:(Page 
            <asp:Label id="NoPage" runat="server">#NoPage#</asp:Label>
            &nbsp;sur 
            <asp:Label id="NbPages" runat="server">#NbPages#</asp:Label>
            ) </h3>
    
    <asp:Repeater id="ListeCommandes" runat="server" OnItemCommand="OnItemCommand" OnItemCreated="OnItemCreated" >
     
<ItemTemplate>
    

   
    <table style="border:1px solid #A55129; background-color:#FFF7E7" >
<tr>
    <td>
         
        
         
        
        
         <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
 
<asp:Image ID="Image1" ImageUrl='<%# Eval("img")%>' runat="server" Width="200px" />
           

        </ContentTemplate>
    </asp:UpdatePanel> 
        
           
    </td>

    <td>
        <table bordercolor="black" cellspacing="0" style="width:550px"  >
<tr bgcolor="#aaaadd">
<td width="170" >
<b><font color="white"> Commande n°
    <%# DataBinder.Eval(Container.DataItem, "ID_Commande") %>
</font></b>
</td>

    


    <td width="300" align="right">
<asp:HyperLink ID="HyperLink1" runat="server"  navigateurl=<%# DataBinder.Eval(Container.DataItem, "ID_Commande", "DetailCommande.aspx?id={0}")%> >

[Détails]</asp:HyperLink>



<asp:LinkButton id="btnDelete"
commandargument='<%# DataBinder.Eval(Container.DataItem,"ID_Commande") %>'
runat="server">[Supprimer]</asp:LinkButton>


</td>

<tr bgcolor="#ffffc0">
<td width="150">Clients : <%# DataBinder.Eval(Container.DataItem, "Client")%></td>
   
<td width="300">

    <b>
</b>
</td>
</tr>
<tr bgcolor="#ffffc0">
       
<td width="150">Date Intervention prévue : </td>
     <%# DataBinder.Eval(Container.DataItem, "Acs") %>
<td width="300">

    <%# DataBinder.Eval(Container.DataItem,"Date_Intervention","{0:d}") %>
   
</td>  </tr>
    <tr bgcolor="#ffffc0">
<td width="150">Type mission  : </td>
<td width="300">
    <%# affichage(DataBinder.Eval(Container.DataItem, "TypeMission"))%>
    </td>
    </tr>
<tr bgcolor="#ffffc0">
<td width="150">mission achevée : </td>
<td width="300">
    
    <%# AfficherBooleen(DataBinder.Eval(Container.DataItem,"Intervention")) %>
</td>
    </tr>
    
    </tr>





</table>

    </td>

</tr>

    </table>










</ItemTemplate>


  
        
        </asp:Repeater>

     <p> 
        <asp:Label ID="ListeVide" runat="server" Text="Label">
        il n'y a aucune commande dans cette liste
        </asp:Label>
    </p>          
     <p>
            <asp:Button id="PagePrecedente" onclick="OnPagePrecedente" runat="server"
             Text=" < "></asp:Button>
            <asp:Button id="PageSuivante" onclick="OnPageSuivante" runat="server"
             Text=" > "></asp:Button>
             <P></P>
            &nbsp;<a href="NouvelleCommande.aspx">
            <asp:Image ID="new" runat="server" ImageAlign="Middle" ImageUrl="images/new.gif" />
            [Nouvelle commande]</a>&nbsp; 
        </p>
        <p>
 </asp:Content>