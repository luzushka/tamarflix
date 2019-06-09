<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tamarflix_real.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="Stylesheet" href="~/Styles/Site.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
Login
<br />
<asp:Label ID="Label1" CssClass="invalid-creds" runat="server"></asp:Label>

&nbsp;<table>
<tbody>
<tr>
<td>Username:</td>
<td><asp:TextBox ID="userName" runat="server" /></td>
</tr>
<tr>
<td>Password:</td>
<td><asp:TextBox ID="pwd" TextMode="Password" runat="server" /></td>
</tr>
<tr>
<td>
<asp:Button runat="server" id="btnLogin" Text="Log In" OnClick="btnLogin_Click" />
</td>
</tr>
</tbody>
</table>
</asp:Content>
