<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Books.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Book Name"></asp:Label> &nbsp
    <asp:Label ID="lblBookName" runat="server" Text="Label"></asp:Label>
    <br />
     <asp:Label ID="Label2" runat="server" Text="Book ID"></asp:Label> &nbsp
    <asp:Label ID="lblBookID" runat="server" Text="Book ID"></asp:Label> &nbsp
    
    <br /><br />
    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
    &nbsp
    <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />

    <asp:Label ID="lblAnswer" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>
