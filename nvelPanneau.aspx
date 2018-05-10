<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="nvelPanneau.aspx.vb" Inherits="GestPanneau.nvelPanneau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <%@ Register TagPrefix="anep" TagName="NavBar" Src="NavBar.ascx" %>

               
  
                <anep:NavBar id="NavBar1" SelectedIndex="5" runat="server">
</anep:NavBar>
            
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">



</asp:Content>






<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <asp:TextBox ID="nomCompagne" runat="server"></asp:TextBox>
     <script type="text/javascript">
         function fnShowCalendar(ClientID, width, height) {
             var popup = null;
             settings = 'width=' + width + ',height=' + height + ',location=no,directories=no,menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no,dependent=no';
             popup = window.open('DatePicker.aspx?Ctl=' + ClientID, 'DatePicker', settings);
             popup.focus();
         }
</script>




    <div class="container" style="margin-top:-20px">
        <div class="row">
            <div class="col-md-4">
            <div class="col-md-8">
       <div class="col-md-12" >
                     
                    <div class="col-md-3">
                    Client:</div>
                        <div class="col-md-8 col-md-push-2">
                   <asp:DropDownList ID="client" runat="server"></asp:DropDownList>
 
          </div>
             </div>
                           <br />
                    <div class="col-md-12" >
                         <div class="col-md-3">
                            Montant </div>
                              <div class="col-md-9  col-md-push-2">
                            <asp:TextBox id="Montant" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Merci de saisir un Montant numérique entière" ForeColor="red" ValidationExpression="[-]*[0-9]+" ControlToValidate="Montant">***</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Merci de saisir un Montant" ControlToValidate="Montant">***</asp:RequiredFieldValidator>
           </div>   </div>
                


                </div>
                <br /> <br />
        <div class="col-md-12" style="margin-top:50px">
           
            
            
         
                 <div class="col-md-6"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></div>
             
           


        <asp:Calendar ID="Calendrier" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
       </div>
      </div>
   <div class="col-md-8 col-md-push-2">
   inserer:Nombre de panneaux

<asp:TextBox ID="txtNoOfRecord" runat="server"></asp:TextBox> 
<asp:Button ID="btnRow" runat="server" Text="addRow" />
       <asp:TextBox ID="chifre" runat="server"></asp:TextBox>
<asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False"  CellPadding="2" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="None">
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
                
                <asp:DropDownList ID="panneau" runat="server" OnSelectedIndexChanged="panneau_SelectedIndexChanged1" AutoPostBack="true" >

                </asp:DropDownList>
                
                  <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ForeColor="red" ValidationExpression="[0-9]*" ControlToValidate="panneau">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Merci de choisir un panneau" ControlToValidate="panneau">*</asp:RequiredFieldValidator>

                 </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="nbrface">
             <ItemTemplate>
            <asp:DropDownList ID="nbrface" runat="server" AutoPostBack="true" OnSelectedIndexChanged="nbrface_SelectedIndexChanged" >
           
               

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
        
    
            <asp:TemplateField HeaderText="DuteFin" >
            <ItemTemplate>
                <!--mettre ici le code-->
               
               <img ID="ImageButton2"   src="img/calendare.png"
                   onclick="fnShowCalendar('<%# CType(Container, GridViewRow).FindControl("datefin").ClientID%>', 300, 180);" />  
                
                 <asp:TextBox ID="datefin" runat="server"></asp:TextBox> 
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
        <asp:Panel ID="panel1" runat="server" Visible="false">
    <asp:Button ID="btnsave" runat="server" Text="Save" />
        &nbsp <asp:Label ID="lbmsg" runat="server" ></asp:Label>
            </asp:Panel>
    </div>
   
        <b>Dtabase Records</b>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5">
    <Columns>
        <asp:TemplateField HeaderText="SL NO">
            <ItemTemplate>
                <%#Eval("ID")%>
            </ItemTemplate>
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="SL NO">
            <ItemTemplate>
                <%#Eval("FirstName")%>
            </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="First Name">
            <ItemTemplate>
                <%#Eval("LastName")%>
            </ItemTemplate>
        </asp:TemplateField>

             <asp:TemplateField HeaderText="First Name">
            <ItemTemplate>
                <%#Eval("Contacte")%>
            </ItemTemplate>
        </asp:TemplateField>
        


    </Columns>
</asp:GridView>

</div>

</div>    


</asp:Content>
