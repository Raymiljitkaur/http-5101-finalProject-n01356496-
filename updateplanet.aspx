<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateplanet.aspx.cs" Inherits="HTTP_FINAL_PROJECT.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="planet" runat="server">
         <asp:Button  class="button" Text="BACK"  runat="server" PostBackUrl="~/planetpages.aspx" />
        <h2>UPDATING PLANETS:</h2>
        
        <div>
            <label>PLANET TITLE:</label>
            <asp:TextBox runat="server" ID="planets_title"></asp:TextBox>
        </div>
        <div >
            <label>PLANET DESCRIPTION:</label>
            <asp:TextBox runat="server" ID="planets_body"></asp:TextBox>
        </div>
        

        <asp:Button  class="button" Text="UPDATE PLANET" OnClick="Update_Planet" runat="server" />

    </div>
</asp:Content>
