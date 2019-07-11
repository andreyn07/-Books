<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Books.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Please Select Genre"></asp:Label> &nbsp

    <asp:DropDownList ID="ddlGenre" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please Select Author"></asp:Label> &nbsp
    <asp:DropDownList ID="ddlAuthor" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Please Select Title"></asp:Label> &nbsp
    <asp:DropDownList ID="ddlTitle" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Date Created"></asp:Label>&nbsp
    <asp:TextBox ID="txtDateCreated" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
