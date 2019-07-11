<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookSelect.aspx.cs" Inherits="Books.BookSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Genre"></asp:Label>
    &nbsp
    <asp:DropDownList ID="ddlGenre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGenre_SelectedIndexChanged"></asp:DropDownList>
    
    <br />
     
    <asp:Label ID="Label2" runat="server" Text="Author"></asp:Label>
    &nbsp
    <asp:DropDownList ID="ddlAuthor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAuthor_SelectedIndexChanged"></asp:DropDownList>
    &nbsp
   
    <br />
     
    <asp:Label ID="Label3" runat="server" Text="Books"></asp:Label>
    &nbsp
    <asp:DropDownList ID="ddlBooks" runat="server" 
       AutoPostBack="True" OnSelectedIndexChanged="ddlBooks_SelectedIndexChanged"></asp:DropDownList>
    &nbsp
  
    
</asp:Content>
