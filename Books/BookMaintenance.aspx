<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookMaintenance.aspx.cs" Inherits="Books.BookMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnNewBook" runat="server" Text="Add New Book" OnClick="btnNewBook_Click" /><br />
    
        <asp:DropDownList ID="ddlBook" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddlBook_SelectedIndexChanged"></asp:DropDownList>&nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /> &nbsp
        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /> &nbsp
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />&nbsp
    
    <asp:Panel ID="pnMain" runat="server" AutoPostBack ="true"><br /> 
    <asp:Label ID="Label1" runat="server" Text="Please Select Genre"></asp:Label> &nbsp
    <asp:DropDownList ID="ddlGenre" runat="server" AutoPostBack ="true"></asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Please Select Author"></asp:Label> &nbsp
    <asp:DropDownList ID="ddlAuthor" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Please Select Title"></asp:Label> &nbsp
    <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack ="true"></asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Date Created"></asp:Label>&nbsp
    <asp:TextBox ID="txtDateCreated" runat="server" AutoPostBack="True"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  AutoPostBack ="true"/>
    <br />
    <asp:Label ID="lblAction" runat="server" Text="" Visible ="false"></asp:Label><br />
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
