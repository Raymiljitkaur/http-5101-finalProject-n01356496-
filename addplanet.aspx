<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addplanet.aspx.cs" Inherits="HTTP_FINAL_PROJECT.addplanet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Button  class="button" Text="BACK"  runat="server" PostBackUrl="~/planetpages.aspx" />
    <h2>ADD PLANETS:</h2>
      <div class="formrow">
        <label>PLANET TITLE:</label>
        <asp:TextBox runat="server" ID="planets_title"></asp:TextBox>
    </div>
    <div class="formrow">
        <label>PLANET DESCRIPTION:</label>
        <asp:TextBox runat="server" ID="planets_body"></asp:TextBox>
    </div>

    <asp:Button CssClass="button" Text="ADD PLANET" OnClick="Add_Planet" runat="server" />
    
</asp:Content>
