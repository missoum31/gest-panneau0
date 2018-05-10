<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="reservation.aspx.vb" Inherits="GestPanneau.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%@ Register TagPrefix="anep" TagName="NavBar" Src="NavBar.ascx" %>

                <anep:NavBar id="NavBar1" SelectedIndex="6" runat="server">
</anep:NavBar>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <asp:MultiView ID="view" runat="server">
        <asp:View ID="view1" runat="server">
            <div class="container" style="margin-top:-50px; position:relative">
        <div class="row">
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="chifre"></asp:TextBox>
           

    
              



               <div class="col-md-12 portlets" style="margin-left:-40px; margin-top:-30px; position:absolute">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <div class="pull-left">Quick Post</div>
                  <div class="widget-icons pull-right">
                    <a href="#" class="wminimize"><i class="fa fa-chevron-up"></i></a> 
                    <a href="#" class="wclose"><i class="fa fa-times"></i></a>
                  </div>  
                  <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                  <div class="padd">
                    
                      <div class="form quick-post">
                                      <!-- Edit profile form (not working)-->
                                      <form class="form-horizontal">
                                          <!-- Title -->
                                          <div class="form-group">
                                            <label class="control-label col-lg-2" for="title">Title</label>
                                            <div class="col-lg-10"> 
                                              <asp:DropDownList ID="direction" runat="server" class="form-control"></asp:DropDownList>
                                            

     <asp:CompareValidator id="cvddlMemberGroupe" runat="server" ControlToValidate="direction" ErrorMessage="Please Select One from this ddl" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                          </div>  </div> 
                                          <!-- Content -->
                                        
                                           <!-- Title -->
                                          <div class="form-group">
                                            <label class="control-label col-lg-2" for="title">Title</label>
                                            <div class="col-lg-10"> 
                                            <asp:DropDownList ID="client" runat="server" CssClass="form-control"></asp:DropDownList>
 <asp:CompareValidator id="CompareValidator10" runat="server" ControlToValidate="client" ErrorMessage="Please Select One from this ddl" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                              

                                            </div>
                                          </div>                        
                                          <!-- Cateogry -->
                                         <!-- Content -->
                                                   
                                          <!-- Tags -->
                                       
                                          
                                          <!-- Buttons -->
                                          <div class="form-group">
                                             <!-- Buttons -->
											 <div class="col-lg-offset-2 col-lg-9">
												<button type="submit" class="btn btn-primary">Publish</button>
												<button type="submit" class="btn btn-danger">Save Draft</button>
												<button type="reset" class="btn btn-default">Reset</button>
											 </div>
                                          </div>
                                      </form>
                                    </div>
                  

                  </div>
                  <div class="widget-foot">
                    <!-- Footer goes here -->
                  </div>
                </div>
              </div>
              
            </div>

 </div>  
            
            
             <div class="col-md-4">
           
            
            
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
             
           


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
                
            <div class="row">
                <div class="col-md-8 col-md-push-4">
            <asp:Button ID="btn1" runat="server" Text="suivant >>" CssClass="btn btn-success" />
                </div></div> </div>
        </asp:View>


           <asp:View ID="view2" runat="server">
                <div class="col-md-12 portlets" style="margin-top:-60px">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <div class="pull-left">Saisire le nombre de panneaux liés a la commande</div>
                  <div class="widget-icons pull-right">
                    <a href="#" class="wminimize"><i class="fa fa-chevron-up"></i></a> 
                    <a href="#" class="wclose"><i class="fa fa-times"></i></a>
                  </div>  
                  <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                  <div class="padd">
                    
                      <div class="form quick-post">
                                      <!-- Edit profile form (not working)
                                      <form class="form-horizontal">-->
                                          <!-- Title -->
                                          <div class="form-group">
                                            <label class="control-label col-lg-6" for="title">Nombre de panneaux</label>
                                            <div class="col-lg-6 col-md-pull-3"> 
                                              <asp:TextBox ID="txtNoOfRecord" runat="server"></asp:TextBox> 
                                                 <asp:Button ID="btnRow" runat="server" Text="addRow" CssClass="btn btn-success" />&nbsp;&nbsp;
                                                <br />
                                            </div>
                                          </div>   
                                          <!-- Content -->
                                    
                                           <!-- Title
                                            
                                        
                                      </form> -->

                               
                                    </div>
                

                  </div>
                  <div class="widget-foot">
                    <!-- Footer goes here -->
                  </div>
                </div>
              </div>
              
            </div>


                   <div class="col-md-12 portlets" style="margin-top:-25px" >
              <div class="panel panel-default">
                <div class="panel-heading">
                  <div class="pull-left">Remplire les champs correctement afin d'activer le bouton suivant</div>
                  <div class="widget-icons pull-right">
                    <a href="#" class="wminimize"><i class="fa fa-chevron-up"></i></a> 
                    <a href="#" class="wclose"><i class="fa fa-times"></i></a>
                  </div>  
                  <div class="clearfix"></div>
                </div>
               
                   <asp:GridView ID="GridView1" runat="server" 
     

      AutoGenerateColumns="False"  CellPadding="4" BackColor="White" 
    BorderColor="#DEDFDE" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="True" BorderStyle="None">
    <AlternatingRowStyle BackColor="White" />
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
                  <asp:CompareValidator id="cvddlMemberGroups" runat="server" ControlToValidate="fpanneau" ErrorMessage="***" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    
                </ItemTemplate>
        </asp:TemplateField>
    
        

        <asp:TemplateField HeaderText="Panneau"  >
            <ItemTemplate>
                
                <asp:DropDownList ID="panneau" runat="server"    >

                </asp:DropDownList>
                
                 <asp:CompareValidator id="cvddlMemberGroup" runat="server" ControlToValidate="panneau" ErrorMessage="***" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    
                 </ItemTemplate>
        </asp:TemplateField>
      
        <asp:TemplateField HeaderText="nbrface">
             <ItemTemplate>
            <asp:DropDownList ID="nbrface" runat="server" >
           
               

                <asp:ListItem Value="0">select</asp:ListItem>
                <asp:ListItem Value="1">1 Faces</asp:ListItem>
                <asp:ListItem Value="2">2 Faces</asp:ListItem>
                <asp:ListItem Value="3">3 Faces</asp:ListItem>
                <asp:ListItem Value="4">4 Faces</asp:ListItem>
                <asp:ListItem Value="5">5 Faces</asp:ListItem>
           
               


                </asp:DropDownList>
                  

                  <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ForeColor="red" ValidationExpression="[1-5]" ControlToValidate="nbrface">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator21" runat="server" ControlToValidate="nbrface" InitialValue="select">*</asp:RequiredFieldValidator>
           


                 </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="dispo" runat="server" ></asp:Label>
            </ItemTemplate>

        </asp:TemplateField>

         <asp:TemplateField HeaderText="DuteFin"  >
            <ItemTemplate>
                <!--mettre ici le code-->
               
                
                 <asp:TextBox ID="fff" runat="server"   ></asp:TextBox> 
          
                 
                 
          
                     </ItemTemplate>
            
        </asp:TemplateField>


            <asp:TemplateField HeaderText="DuteFin" >
            <ItemTemplate>
                <!--mettre ici le code-->
               
                <img id="imgCalendar" src="img/calendare.png" height="25px" style="cursor:pointer"
                        onclick="fnShowCalendar('<%# CType(Container, GridViewRow).FindControl("datefin").ClientID%>', 300, 180);" />
                 <asp:TextBox ID="datefin" runat="server" Width="35%"></asp:TextBox> 
          
                    <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="datefin">*</asp:RequiredFieldValidator>
                  <asp:CompareValidator id="dateValidator" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="datefin" ErrorMessage="لا يتوافق مع التاريخ">
</asp:CompareValidator>
              
          
                     </ItemTemplate>
            
        </asp:TemplateField>
          
      
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                       <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#FBFBF2" />
    <SortedAscendingHeaderStyle BackColor="#848384" />
    <SortedDescendingCellStyle BackColor="#EAEAD3" />
    <SortedDescendingHeaderStyle BackColor="#575357" />
</asp:GridView>
 <asp:Label  ID="txtt" runat="server" ForeColor="Red" Font-Size="XX-Large"></asp:Label>

                   <div class="panel-body">
                  <div class="padd">
                      <div class="form quick-post" style="margin-top:-12px;">


                          

       <asp:ValidationSummary ID="vv" runat="server" />

                          </div>  </div>  </div>
 <div class="row">
    
     <div class="col-md-6  col-md-push-4">
        
          
 
         <asp:Panel ID="panel2" runat="server" Visible="false">    
<asp:Button ID="Button2" runat="server" Text="suivant >>" CssClass="btn btn-success" />
                 &nbsp <asp:Label ID="Label6" runat="server" ></asp:Label>
            </asp:Panel></div>
     
    </div>

          
              

          
          
          
    
  
   

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
<div class="row">
    <div class="col-md-2">
        <br />
     <asp:Button ID="prec1" runat="server" Text="<< Précédent" CssClass="btn btn-success" />  </div>
    <div class="col-md-8"> <div style="padding:10px 0px;">
        <asp:Panel ID="panel1" runat="server" Visible="false">
          <div class="col-md-2">
            <asp:Button ID="check" runat="server" Text="Check Commande" CommandName="yyy" CssClass="btn btn-danger" OnClick="check_Click" /> </div> 
         <div class="col-md-4"> <asp:Button ID="annule" runat="server" Text="Update Commande" CommandName="yyy" CssClass="btn btn-danger" OnClick="annule_Click" />
 </div> <div class="col-md-4">  <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-success" /></div>
        &nbsp <asp:Label ID="lbmsg" runat="server" ></asp:Label>
            </asp:Panel>
    </div> 
   </div> </div>
        </asp:View>
    <asp:View ID="view3" runat="server">
       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" 
            AllowPaging="true"
           ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
           <Columns>     
              
               <asp:TemplateField HeaderText="client">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("client") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("client") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="datedebut">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("datedebut") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("datedebut") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="datefin">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("datefin") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("datefin") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="panneau">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Codepanneau") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("Codepanneau") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Codepanneau">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Codepanneau") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("Codepanneau") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>

               
           <asp:TemplateField>
           <ItemTemplate>
        
             

               <asp:LinkButton ID="lnkRemove" runat="server" 
            CommandArgument = '<%# Eval("id")%>' 
         OnClientClick = "return confirm('Do you want to delete?')"
        Text = "Delete" OnClick = "GridView2_RowDeleting"></asp:LinkButton>
    </ItemTemplate>
                 </asp:TemplateField>
               </Columns>
           <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
           <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
           <SortedAscendingCellStyle BackColor="#FDF5AC" />
           <SortedAscendingHeaderStyle BackColor="#4D0000" />
           <SortedDescendingCellStyle BackColor="#FCF6C0" />
           <SortedDescendingHeaderStyle BackColor="#820000" />

       </asp:GridView>
       <br />
      
       <br />

    </asp:View> </asp:MultiView>
        
</asp:Content>
