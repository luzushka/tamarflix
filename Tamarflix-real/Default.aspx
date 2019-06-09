<%@ Page Title="Tamarflix" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Tamarflix_real._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Tamarflix!
    </h2>
    <p>
        <strong>Here are your movies ^_^</strong>
    </p>
    <asp:Label runat="server" ID="loginToProceed">
        
    </asp:Label>
    
</asp:Content>
