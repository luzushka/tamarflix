<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuyMovies.aspx.cs" Inherits="Tamarflix_real.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
