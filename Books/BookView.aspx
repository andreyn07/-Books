<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookView.aspx.cs" Inherits="Books.BookView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label5" runat="server" Text="Book View"></asp:Label>

    <div>
        <asp:Table ID="tblBooks" runat="server" Height="180px" CellSpacing="10">
            <asp:TableRow>
                <asp:TableCell>Genre </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtGenre" runat="server" ReadOnly="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell>Author </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAuthor" runat="server" ReadOnly="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>



            <asp:TableRow>
                <asp:TableCell>Title </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtBookID" runat="server" ReadOnly="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>



            <asp:TableRow>
                <asp:TableCell>Date Created </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDateCreated" runat="server" ReadOnly="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow >
                <asp:TableCell HorizontalAlign ="Center">
                   <asp:Button ID="btnOk" runat="server" Text="OK"  OnClick="btnOk_Click"/>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>
    

</asp:Content>
