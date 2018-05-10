<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NouvelleCommande.aspx.vb" Inherits="GestPanneau.NouvelleCommande" %>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>






<asp:Content ID="Content5" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>








<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">



    <h4>Saisie d'une nouvelle commande </h4>   nbr de panneau 
    
    
    
     <div style="padding:10px 0px;">
        <asp:Panel ID="panel1" runat="server" Visible="false">
        &nbsp 
            </asp:Panel>
    </div>
    
     <b>Dtabase Records</b>
    
    
    
    
    
    
    













    
    
    
    
    
    
    <table bordercolor:"black">
<tr bgcolor:"#aaaadd">
<td width:"381" colspan="2">
<font color:"white">
    
   <b>En-tete de la commande</b></font>
    </td>
    </tr>
    <tr>
    <td style="width: 150px">Anep cs:</td>
        <td style="width: 222px">
  
            <asp:DropDownList id="direction" runat="server">
            
            </asp:DropDownList>
        
        </td>
        <td style="width: 150px">Anep cs:</td>
        <td style="width: 222px">
  
            <asp:DropDownList id="clients" runat="server"
                            >
            
            
            </asp:DropDownList>
        
        </td>
            <td>
          <asp:DropDownList ID="type" runat="server"  >
                 <asp:ListItem Value="0">--select--</asp:ListItem>
                <asp:ListItem Value="1">Affichage</asp:ListItem>
                <asp:ListItem Value="2">Désaffichage</asp:ListItem>
                 <asp:ListItem Value="3">Maintenance</asp:ListItem>
                </asp:DropDownList>  </td>
        </tr>
    

         
        <tr>
       <td valign:"top" width="150">Date Intervention deamndée</td>
            <td width:"222"><asp:Calendar id="Calendrier" runat="server"></asp:Calendar></td>
            </tr>        
        </table>
    <br />
    <asp:TextBox ID="txtNoOfRecord" runat="server"></asp:TextBox>  
    <asp:Button ID="btnRow" runat="server" Text="AddRow" />
    
    
    
    
    

    
    
    <asp:Label ID="lbmsg" runat="server" ></asp:Label>
    <br />
<asp:GridView ID="gvContacts" runat="server" 
     

      AutoGenerateColumns="False"  CellPadding="2" BackColor="LightGoldenrodYellow" 
    BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="None">
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
    <Columns>
        <asp:TemplateField HeaderText="N°">
            <ItemTemplate>
                <%#Container.DataItemIndex + 1%>
                </ItemTemplate></asp:TemplateField>
             <asp:TemplateField HeaderText="Famille">
                 <ItemTemplate>
                <asp:DropDownList ID="fpanneau" runat="server" OnSelectedIndexChanged="fpanneau_SelectedIndexChanged"
                                       AutoPostBack="true">
                    
                </asp:DropDownList>
                     <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="Merci de saisir un Montant numérique entière" ForeColor="red" ValidationExpression="[A-Z]*[0-9]+" ControlToValidate="panneau">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Merci de saisir un Montant" ControlToValidate="panneau">*</asp:RequiredFieldValidator>

                </ItemTemplate>
        </asp:TemplateField>
    
        

        <asp:TemplateField HeaderText="Panneau" >
            <ItemTemplate>
                
                <asp:DropDownList ID="panneau" runat="server" >

                </asp:DropDownList>
                
                  <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ForeColor="red" ValidationExpression="[0-9]*" ControlToValidate="panneau">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Merci de choisir un panneau" ControlToValidate="panneau">*</asp:RequiredFieldValidator>

                 </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="nbrface">
             <ItemTemplate>
            <asp:DropDownList ID="nbrface" runat="server"  >
           
               

                <asp:ListItem Value="0">select</asp:ListItem>
                <asp:ListItem Value="1">1 Faces</asp:ListItem>
                <asp:ListItem Value="2">2 Faces</asp:ListItem>
                <asp:ListItem Value="3">3 Faces</asp:ListItem>
                <asp:ListItem Value="4">4 Faces</asp:ListItem>
                <asp:ListItem Value="5">5 Faces</asp:ListItem>
           
               


                </asp:DropDownList>
                  
                  <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Merci de saisir un Montant numérique entière" ForeColor="red" ValidationExpression="[1-5]" ControlToValidate="nbrface">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Merci de saisir un Montant" ControlToValidate="nbrface">*</asp:RequiredFieldValidator>
           


                 </ItemTemplate>
        </asp:TemplateField>
        
    
           
           
        

    </Columns>
    <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <SortedAscendingCellStyle BackColor="#FAFAE7" />
    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
    <SortedDescendingCellStyle BackColor="#E1DB9C" />
    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
</asp:GridView>
   
    
     <div style="padding:10px 0px;">
        <asp:Panel ID="panel2" runat="server" Visible="false">
    <asp:Button ID="btnsave" runat="server" Text="Save" />
        &nbsp <asp:Label ID="Label1" runat="server" ></asp:Label>
            </asp:Panel>
    </div>
    </asp:Content>
