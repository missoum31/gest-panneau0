<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="panneaux.aspx.vb" Inherits="GestPanneau.panneaux" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <%@ Register TagName="NavBar" TagPrefix="anep" Src="~/NavBar.ascx" %>
       
   
                <anep:NavBar id="NavBar" selectedIndex="1" runat="server"></anep:NavBar>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
      <script>
          function openpopup(popup_url, params) {
              retcode = window.open(popup_url, '', params);
          }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-8">
     <h3><asp:Label id="Nompanneau" runat="server">Label</asp:Label></h3>
        </div>
        <div class="col-md-4">
             <asp:HyperLink ID="voir" runat="server">voir</asp:HyperLink>
            </div>
        </div>
  
    <div class="row">
         <!--   <div class="col-md-8">
            <input type="button" id="lightbox" value="lightBox" />
          </div>-->
       
            <div class="col-md-2">
               <asp:Button  ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File"  />
                </div>
        <div class="col-md-2">
<asp:FileUpload ID="FileUpload1" runat="server" />
     </div>
        </div>
        <div class="row">
      
            
              <div class="col-md-10">
                  <% ID = Request.Params("id")%>
                <script type="text/javascript" src="/9250F51AB2EF468B9A4D5D8318DD6A78/54327060-B92E-4242-A913-ED22E005CEFD/main.js" charset="UTF-8"></script><script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script type="text/javascript" src="js/utile.js"></script>
<script type="text/javascript">
    var url = window.location.search;


    var infowindow;
    var map;
    function createMarker(desciptive, latlng) {
        var marker = new google.maps.Marker({ position: latlng, map: map });
        google.maps.event.addListener(marker, "click", function () {
            if (infowindow) infowindow.close();
            infowindow = new google.maps.InfoWindow({ content: desciptive });
            infowindow.open(map, marker);
        });
        return marker;
    }
    function initialize() {
        var myLatlng = new google.maps.LatLng(34.502030, 4.286041);
        var myOptions = {
            zoom: 7,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            title: 'Click me'
        }
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        downloadUrl("xmlPanneauSingle/positionGeogSingle" + url.substring(url.lastIndexOf("=") + 1) + ".xml", function (data) {
            var markers = data.documentElement.getElementsByTagName("panneau");
            for (var i = 0; i < markers.length; i++) {
                var latlng = new google.maps.LatLng(parseFloat(markers[i].getElementsByTagName("lat")[0].firstChild.nodeValue),

                                                         parseFloat(markers[i].getElementsByTagName("lng")[0].firstChild.nodeValue));
                var marker = createMarker(markers[i].getElementsByTagName("desciptive")[0].firstChild.nodeValue, latlng);
            }
        });

    }








</script>
                  <body onload="initialize()" />
  <div id="map_canvas" style="width:130%; height:500px"></div>
					</div>
                  </div>
             <br />  <br />  <br />  <br />
        <div class="row">
            <div class="col-md-12">
               <asp:DataGrid ID="HistoriqueStock" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingItemStyle BackColor="White" />
    <Columns>
        <asp:BoundColumn DataField="Client" HeaderText="Client" HeaderStyle-Width="150px"></asp:BoundColumn>
        <asp:BoundColumn DataField="Designation" HeaderText="Designation" HeaderStyle-Width="150px" ></asp:BoundColumn>
        <asp:BoundColumn DataField="nbrFaceInitiale" HeaderText="nbrFace" HeaderStyle-Width="150px"></asp:BoundColumn>
        <asp:BoundColumn DataField="Ventes" HeaderText="Ventes" HeaderStyle-Width="70px"></asp:BoundColumn>
        
        <asp:BoundColumn  DataField="lieu" HeaderText="adresse Panneau" HeaderStyle-Width="200px" >

            <HeaderStyle width="200px"></HeaderStyle>
        </asp:BoundColumn>
        <asp:BoundColumn DataField="ville" HeaderText="ville" HeaderStyle-Width="70px" ></asp:BoundColumn>
        <asp:BoundColumn DataField="DatePose" HeaderText="Date Pose"></asp:BoundColumn>
        <asp:BoundColumn DataField="DateFin" HeaderText="DateFin" HeaderStyle-Width="70px"></asp:BoundColumn>
    </Columns>
    <EditItemStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataGrid>

</div>
            </div>
<br/>
       <div class="row">
            <div class="col-md-8">
       <a href="serviceTest.aspx">
<asp:Image ID="maj" runat="server" ImageAlign="Middle" ImageUrl="~/Images/maje.gif" />

MAJ de la base de donnee</a></div>
                <div class="col-md-6">

        <a href="parc.aspx">
</asp:Content>
