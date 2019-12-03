<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="planetpages.aspx.cs" Inherits="HTTP_FINAL_PROJECT.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Button  class="button" Text="Add planet"  runat="server" PostBackUrl="~/addplanet.aspx" />
     <div class="planets_list" runat="server">
        <div class="listitem">
               
            <div class="col1">PLANET NO</div>
            <div class="col2">PLANET TITLE</div>  
        </div>
        <div id="planets_result" runat="server"></div>
       
    </div>
</asp:Content>
