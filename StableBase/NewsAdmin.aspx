<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsAdmin.aspx.cs" Inherits="StableBase.NewsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin - News</h2>
    <asp:Panel ID="PanelAddNews" runat="server">
    
    
    <asp:TextBox ID="TextBoxNews" runat="server" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="ButtonAddNewsItem" runat="server" Text="Add News Item" onclick="ButtonAddNewsItem_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelConfirm" runat="server" Visible="False">
        News item added successfully!
    </asp:Panel>
</asp:Content>
