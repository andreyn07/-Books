<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Genre.aspx.cs" Inherits="Books.Genre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlGenre" runat="server"></asp:DropDownList>
    <br />
    <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
