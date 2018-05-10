<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="majbadd.aspx.vb" Inherits="GestPanneau.majbadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <%@ Register TagPrefix="anep" TagName="NavBar" Src="NavBar.ascx" %>

               
  
                <anep:NavBar id="NavBar1" SelectedIndex="5" runat="server"></anep:NavBar>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
<div class="row">
    <div class="col-md-6">
      <p style="margin-left:200px">nom de Compagne:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> </p></div>
    <div class="col-md-6">
    Nom du client: <asp:DropDownList id="ListeClient" runat="server">
            
             </asp:DropDownList></div>
    <br />
    nbr de panneau a réserver: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="row">

    <div class="col-md-6">
       

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
            <Columns>

            <asp:boundField DataField="ID_Famillepanneau" HeaderText="ID_Famillepanneau" />
            <asp:BoundField DataField="NomFamille" HeaderText="ID_Famillepanneau" />
               
                    <asp:TemplateField HeaderText="Code">
                     <itemTemplate>

                         <asp:DropDownList ID="ddl" runat="server"></asp:DropDownList>


                </itemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
       

    </div>

     <div class="col-md-6">
       


    </div>

</div>





</asp:Content>
