<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="reserver.aspx.vb" Inherits="GestPanneau.reserver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container" style="margin-top:-20px">
        <div class="row">
         
            
                     
                    <div class="col-md-2">
                    Client:</div>
                        <div class="col-md-9">
                   <asp:DropDownList ID="client" runat="server"></asp:DropDownList>
</div>
          <br /><br />
             <div class="row">
       
     
   <div class="col-md-12">
   inserer:Nombre de panneaux

<asp:TextBox ID="txtNoOfRecord" runat="server"></asp:TextBox> 
<asp:Button ID="btnRow" runat="server" Text="addRow" />
       <asp:TextBox ID="chifre" runat="server"></asp:TextBox>
<asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false"  CellPadding="5">
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
                
                <asp:DropDownList ID="panneau" runat="server"  >

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
</asp:GridView>

    <div style="padding:10px 0px;">
        <asp:Panel ID="panel1" runat="server" Visible="false">
    <asp:Button ID="btnsave" runat="server" Text="Save" />
        &nbsp <asp:Label ID="lbmsg" runat="server" ></asp:Label>
            </asp:Panel>
    </div>

</div>

</div>
            </div>
            </div>


    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="client" HeaderText="client" SortExpression="client" />
            <asp:BoundField DataField="datedebut" HeaderText="datedebut" SortExpression="datedebut" />
            <asp:BoundField DataField="datefin" HeaderText="datefin" SortExpression="datefin" />
            <asp:BoundField DataField="panneau" HeaderText="panneau" SortExpression="panneau" />
            <asp:BoundField DataField="CodePanneau" HeaderText="CodePanneau" SortExpression="CodePanneau" />
            <asp:BoundField DataField="idcompagne" HeaderText="idcompagne" SortExpression="idcompagne" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:missoumConnectionString %>" DeleteCommand="DELETE FROM [reservation] WHERE [id] = @id" InsertCommand="INSERT INTO [reservation] ([client], [datedebut], [datefin], [panneau], [CodePanneau], [idcompagne]) VALUES (@client, @datedebut, @datefin, @panneau, @CodePanneau, @idcompagne)" SelectCommand="SELECT * FROM [reservation]" UpdateCommand="UPDATE [reservation] SET [client] = @client, [datedebut] = @datedebut, [datefin] = @datefin, [panneau] = @panneau, [CodePanneau] = @CodePanneau, [idcompagne] = @idcompagne WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="client" Type="String" />
            <asp:Parameter Name="datedebut" Type="DateTime" />
            <asp:Parameter Name="datefin" Type="DateTime" />
            <asp:Parameter Name="panneau" Type="String" />
            <asp:Parameter Name="CodePanneau" Type="String" />
            <asp:Parameter Name="idcompagne" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="client" Type="String" />
            <asp:Parameter Name="datedebut" Type="DateTime" />
            <asp:Parameter Name="datefin" Type="DateTime" />
            <asp:Parameter Name="panneau" Type="String" />
            <asp:Parameter Name="CodePanneau" Type="String" />
            <asp:Parameter Name="idcompagne" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
