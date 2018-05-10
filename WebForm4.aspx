<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebForm4.aspx.vb" Inherits="GestPanneau.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%@ Register TagPrefix="anep" TagName="NavBar" Src="NavBar.ascx" %>
    <anep:NavBar id="NavBar1" SelectedIndex="5" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    <script type="text/javascript">
        function fnShowCalendar(ClientID, width, height) {
            var popup = null;
            settings = 'width=' + width + ',height=' + height + ',location=no,directories=no,menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no,dependent=no';
            popup = window.open('DatePicker.aspx?Ctl=' + ClientID, 'DatePicker', settings);
            popup.focus();
        }
</script>
    <script type="text/javascript">
        function PopupPicker(ctl,w,h)
        {
            var PopupWindow=null;
            settings = 'width=' + w + ',height=' + h + ',location=no,directories=no,menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no, dependent=no';

            PopupWindow=window.open('DatePicker.aspx?Ctl=' + ctl,'DatePicker',settings);
            PopupWindow.focus();
        }
</script>
     


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function fnShowCalendar(ClientID, width, height) {
            var popup = null;
            settings = 'width=' + width + ',height=' + height + ',location=no,directories=no,menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no,dependent=no';
            popup = window.open('DatePicker.aspx?Ctl=' + ClientID, 'DatePicker', settings);
            popup.focus();
        }
</script>
    <script type="text/javascript">
        function PopupPicker(ctl, w, h) {
            var PopupWindow = null;
            settings = 'width=' + w + ',height=' + h + ',location=no,directories=no,menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no, dependent=no';

            PopupWindow = window.open('DatePicker.aspx?Ctl=' + ctl, 'DatePicker', settings);
            PopupWindow.focus();
        }

        function mimicPlaceholder() {
            var myTextBox = document.getElementById('<%= Montant.ClientID%>');
         
            if (myTextBox.value == "le montant") {
             myTextBox.value = "";
             setToBlack(myTextBox);
         }
         else if (myTextBox.value == "") {
             myTextBox.value = "le montant";
             setToGray(myTextBox);
         }
        }


        function cplaceholder() {
            var myTextBox = document.getElementById('<%= NomCompagne.ClientID%>');

            if (myTextBox.value == "Nom Compagne") {
                myTextBox.value = "";
                setToBlack(myTextBox);
            }
            else if (myTextBox.value == "") {
                myTextBox.value = "Nom Compagne";
                setToGray(myTextBox);
            }
        }


</script>


   
    
    <asp:MultiView ID="view" runat="server">
        <asp:View ID="view1" runat="server">
            <div class="container" style="margin-top:-50px;">
        <div class="row">
            <div class="col-md-8">
           
    




               <div class="col-md-12 portlets" style="margin-left:-40px">
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
                                          <div class="form-group">
                                            <label class="control-label col-lg-2" for="tags">Tags</label>
                                            <div class="col-lg-10">
                                             <asp:TextBox ID="NomCompagne" runat="server" Text="Nom Compagne"   class="form-control" ></asp:TextBox>
 <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Merci de saisir un Nom Compagne" ForeColor="red" ValidationExpression="[-]*[A-Z]*[a-z]+" ControlToValidate="NomCompagne">***</asp:RegularExpressionValidator>
                            
         
                
                                            </div>
                                          </div>   
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
                                          <div class="form-group">
                                            <label class="control-label col-lg-2" for="tags">Tags</label>
                                            <div class="col-lg-10">
                                              <asp:TextBox id="Montant" runat="server" Text="le montant" Class="form-control" ></asp:TextBox>
                                  
                            <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Merci de saisir un Montant numérique entière" ForeColor="red" ValidationExpression="[-]*[0-9]+" ControlToValidate="Montant">***</asp:RegularExpressionValidator>
                            
                
                                            </div>
                                          </div>            
                                          <!-- Tags -->
                                          <div class="form-group">
                                            <label class="control-label col-lg-2" for="tags">Tags</label>
                                            <div class="col-lg-10">
                                              <input type="text" class="form-control" id="tags">
                                            </div>
                                          </div>
                                          
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
                <div class="panel-body">
                  <div class="padd">
                    
                      <div class="form quick-post" style="margin-top:-12px;">



<asp:GridView ID="gvContacts" runat="server" 
     

      AutoGenerateColumns="False"  CellPadding="1" BackColor="LightGoldenrodYellow" 
    BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="None" ShowFooter="True">
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
    <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <SortedAscendingCellStyle BackColor="#FAFAE7" />
    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
    <SortedDescendingCellStyle BackColor="#E1DB9C" />
    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
</asp:GridView>

                          <asp:Label  ID="txtt" runat="server" ForeColor="Red" Font-Size="XX-Large"></asp:Label>
       <asp:ValidationSummary ID="vv" runat="server" />

                          </div>  </div>  </div>  </div>  </div>
 <div class="row">
     <div class="col-md-6"><asp:Button ID="Button11" runat="server" Text="<< précédent"  CssClass="btn btn-success"   /></div>
     <div class="col-md-6  col-md-push-4">
        <asp:Panel ID="panel1" runat="server" Visible="false">
            <asp:Button ID="check" runat="server" Text="Check Commande" CommandName="yyy" CssClass="btn btn-danger" OnClick="check_Click" />
        <asp:Button ID="annule" runat="server" Text="Update Commande" CommandName="yyy" CssClass="btn btn-danger" OnClick="annule_Click" />
       
<asp:Button ID="Button2" runat="server" Text="suivant >>" CssClass="btn btn-success" />
                 &nbsp <asp:Label ID="lbmsg" runat="server" ></asp:Label>
            </asp:Panel></div>
     
    </div>

           </asp:View>
           <asp:View ID="view3" runat="server">
              <div class="container" style=" background-image:url(img/bg-11.jpg); font-size:18px; font-style:oblique; font-weight:700">
                  <div class="row">
                      <div class="col-md-4">Nom Direction</div>
             <div class="col-md-8">  <asp:Label ID="label1" runat="server"></asp:Label></div>

               </div>
 <div class="row">
                      <div class="col-md-4">Nom Compagne</div>
             <div class="col-md-8">  <asp:Label ID="label2" runat="server"></asp:Label></div>

               </div>
                   <div class="row">
                      <div class="col-md-4">Nom Client</div>
             <div class="col-md-8">  <asp:Label ID="label3" runat="server"></asp:Label></div>

               </div>
                   <div class="row">
                      <div class="col-md-4">Nom Montant</div>
             <div class="col-md-8">  <asp:Label ID="label4" runat="server"></asp:Label></div>

               </div>
                   <div class="row">
                      <div class="col-md-4">Date Debeut</div>
             <div class="col-md-8">  <asp:Label ID="label5" runat="server"></asp:Label></div>

               </div>
                   <div class="row">
                      <div class="col-md-6">nombre de panneaux</div>
             <div class="col-md-8">  <asp:Label ID="label6" runat="server"></asp:Label></div>

               </div>
                   


                       
   
       
              </div>

              <div class="row">
     <div class="col-md-6"><asp:Button ID="Button1" runat="server" Text="<< précédent"  CssClass="btn btn-success"    /></div>
     <div class="col-md-6 ">
               <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-success"  />
                 </div>
                </div>
          
           </asp:View>
        
    </asp:MultiView>




    
                


                
              
       
   






</asp:Content>
