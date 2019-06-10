<%@ Page Title="MyCart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="Tamarflix_real.WebForm3" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Your Cart
        </h2>
<asp:Label runat="server" ID="noMovieLabel">You don't have any movies in your cart, wanna buy some?</asp:Label>
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
                <th class="movie-th">
                    Remove
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
                        <td class="movie-td">
                            <asp:Button ID="Button1" runat="server" CommandName="Delete" OnCommand="DeleteButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MovID") %>' Text="Delete"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <br />
    <br />
    <asp:Label runat="server" ID="sumTitleLabel">Your sum is:</asp:Label>
    <asp:Label runat="server" ID="sumNumberLabel" />
    <asp:Label runat="server" ID="Label7"> New Israeli Shekels</asp:Label>
    <br />
    <br />
    <asp:Button ID="Button12" runat="server" CommandName="Buy" OnCommand="BuyNow_Click" Text="Buy Now!"/>
    </asp:Panel>
</asp:Content>
