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
    <asp:Panel runat="server" ID="movieTablePanel">
    <table class="movie-table">
        <thead>
            <tr>
                <th class="movie-th">
                    Name
                </th>
                <th class="movie-th">
                    Length
                </th>
                <th class="movie-th">
                    Genre
                </th>
                <th class="movie-th">
                    Age
                </th>
                <th class="movie-th">
                    Release Date
                </th>
                <th class="movie-th">
                    Price
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="MovieRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="movie-td">
                            <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "MovName") %>' runat="server" />
                        </td>
                        <td class="movie-td">
                            <asp:Label ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem, "MovLength") %>' runat="server" />
                        </td>
                        <td class="movie-td">
                            <asp:Label ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem, "MovGenre") %>' runat="server" />
                        </td>
                        <td class="movie-td">
                            <asp:Label ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem, "AllowedAge") %>' runat="server" />
                        </td>
                        <td class="movie-td">
                            <asp:Label ID="Label5" Text='<%# DataBinder.Eval(Container.DataItem, "Release_date") %>' runat="server" />
                        </td>
                        <td class="movie-td">
                            <asp:Label ID="Label6" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>' runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
