<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskAdmin.aspx.cs" Inherits="StableBase.TaskAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Admin - Tasks</h1>
    <br />
    <asp:LinqDataSource ID="LinqDataSourceTask" runat="server" ContextTypeName="StableBase.StableBaseDataContext" EnableUpdate="True" EntityTypeName="" OrderBy="TaskName" TableName="Tasks">
    </asp:LinqDataSource>
    <asp:GridView ID="GridViewTask" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" DataKeyNames="TaskID" DataSourceID="LinqDataSourceTask" GridLines="None" ShowHeader="False">
        <Columns>
            <asp:BoundField DataField="TaskName" HeaderText="Name" SortExpression="TaskName" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:TextBox ID="TextBoxNewTaskName" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonAddNewTask" runat="server" OnClick="ButtonAddNewTask_Click" Text="Add Task" />
</asp:Content>
