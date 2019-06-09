<%@ Page Title="Tamarflix" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Tamarflix_real._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Tamarflix!
    </h2>
    <p>
        <strong>Here you can download movies ^_^</strong>
    </p>
    <asp:Label runat="server" ID="loginToProceed">
        
    </asp:Label>
    <table>
        <tbody>
            <asp:Repeater ID="MovieRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "MovName") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "MovLength") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "MovGenre") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "AllowedAge") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Release_date") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>' runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
