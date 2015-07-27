<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checklist.aspx.cs" Inherits="StableBase.Checklist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Morning
    </h1>
    <asp:GridView ID="GridViewMorning" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" Font-Size="Large" GridLines="None" ShowHeader="False">
        <Columns>
            <asp:BoundField DataField="HorseName" />
            <asp:BoundField DataField="TaskName" />
            <asp:BoundField DataField="HorseTaskNotes" />
        </Columns>
    </asp:GridView>
    <h1>
        Evening
    </h1>
    <asp:GridView ID="GridViewEvening" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" Font-Size="Large" GridLines="None" ShowHeader="False">
        <Columns>
            <asp:BoundField DataField="HorseName" />
            <asp:BoundField DataField="TaskName" />
            <asp:BoundField DataField="HorseTaskNotes" />
        </Columns>
    </asp:GridView>
</asp:Content>
