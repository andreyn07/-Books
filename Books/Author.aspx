<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="Books.Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:DropDownList ID="ddlAuthor" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label><asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label><asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
