<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Title.aspx.cs" Inherits="Books.Title" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlTitle" runat="server"></asp:DropDownList>
    <br />
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
