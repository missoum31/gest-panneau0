<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="suprimer.aspx.vb" Inherits="GestPanneau.suprimer" %>
 <%@ Register TagName="NavBar" TagPrefix="anep" Src="~/NavBar.ascx" %>
       
   
                <anep:NavBar id="NavBar" selectedIndex="0" runat="server"></anep:NavBar>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
    <div class="col-md-12">
    <asp:chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="724px" Height="429px"><Series><asp:Series Name="Series1" ChartType="Bar" XValueMember="client" YValueMembers="montant" YValuesPerPoint="6"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:chart>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:missoumConnectionString %>" SelectCommand="

 select

 MIN(client.Client) as client,min(LEFT(CONVERT(varchar, datePrevu,112),4)) as date

, sum(compagne.Montant) as montant
 from  
 
  MouvementStock 
  inner join Compagne on Compagne.IdCompagne=MouvementStock.id_compagne
  inner join Client on Compagne.id_Client=Client.IdClient
 inner join panneau on MouvementStock.ID_panneau=panneau.ID_panneau
 
 
 
 GROUP BY Client.IdClient, (LEFT(CONVERT(varchar, datePrevu,112),4))
 HAVING  min(LEFT(CONVERT(varchar, datePrevu,112),4)) =2016">
        </asp:SqlDataSource>
        </div>
    </div>
            </div>
    </form>
    
    
</body>

