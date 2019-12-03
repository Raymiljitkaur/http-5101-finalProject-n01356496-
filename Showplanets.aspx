<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Showplanets.aspx.cs" Inherits="HTTP_FINAL_PROJECT.Showplanets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <ASP:Button class="button" OnClick="Delete_planet"  Text="Delete" runat="server"/> 
   <a  href="updateplanet.aspx?planets_id=<%= Request.QueryString["planets_id"] %>">UPDATE</a>


    <div id="planet" runat="server">
        <h2 >Details for Planets:</h2>
        <h2>PLANET TITLE:</h2> <span id="planets_title" runat="server"></span><br />
        <h2>PLANET DESCRIPTION:</h2> <span id="planets_body" runat="server"></span><br />
      
    </div>
     <asp:Button  class="button" Text="BACK"  runat="server" PostBackUrl="~/planetpages.aspx" />
</asp:Content>
