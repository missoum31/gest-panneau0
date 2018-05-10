<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="parc.aspx.vb" Inherits="GestPanneau.parc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <%@ Register TagPrefix="anep" TagName="NavBar" Src="~/NavBar.ascx" %>
  
               <!-- <h3><%: Title %></h3>-->
                <anep:NavBar id="NavBar" selectedIndex="1" runat="server"></anep:NavBar>
       
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
<h4>Consultation de l'état du Parc par famille de produits</h4>
<table>
<tbody>
<tr>
<td style=" width:60px">Famille</td>
<td>
<asp:DropDownList id="ListeFamilles" runat="server"
                  AutoPostBack="true"
                  onSelectedIndexChanged="OnFamilleChanged"
width="250px">
</asp:DropDownList>
</td>
    <td>
<asp:DropDownList id="region" runat="server"
                  AutoPostBack="true"
                  onSelectedIndexChanged="OnVilleChanged"
width="250px">
</asp:DropDownList>
</td>
<td>
<asp:DropDownList id="ville" runat="server" AutoPostBack="true"
                  onSelectedIndexChanged="OnPanneauChanged"
                 
width="250px">
</asp:DropDownList>
</td>
<td>
 



</td>




</tr>
     
</tbody></table>
<asp:DataGrid id="EtatStocks" runat="server" BorderColor="#999999" CellPadding="2" 
    BorderWidth="1px" HeaderStyle-BackColor="#aaaadd" BackColor="White" 
        BorderStyle="None" GridLines="Vertical" Width="633px" 
        AutoGenerateColumns="False" Height="16px"    >
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
    <Columns>
        <asp:BoundColumn DataField="Code" HeaderText="Code"></asp:BoundColumn>




        <asp:HyperLinkColumn DataNavigateUrlField="ID_panneau" 
            DataNavigateUrlFormatString="panneaux.aspx?id={0}" 
            DataTextField="Designation" HeaderText="Designation"></asp:HyperLinkColumn>




        <asp:BoundColumn DataField="NbrFaceDisponible" HeaderText="nombreFace">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="ID_panneau" HeaderText="ID_panneau">
        </asp:BoundColumn>




    </Columns>
    
<HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"></HeaderStyle>
    
    </asp:DataGrid>   


<div id="wrap">
<div id="resultat"></div>
</div>

    <p></p>

    <p></p>
<a href="DetailClient.aspx?id={0}.aspx">
<asp:Image ID="detail" runat="server" ImageAlign="Middle" ImageUrl="~/Images/detail.gif" />
Detail Commande Client</a>



<p><a href="nvelPanneau.aspx">
<asp:Image ID="update" runat="server" ImageAlign="Middle"  ImageUrl="~/Images/maje.gif" />
MAJ de la Base de Donnee</a></p>
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/obs.js" type="text/javascript"></script>
</asp:Content>
