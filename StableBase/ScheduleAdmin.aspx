<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleAdmin.aspx.cs" Inherits="StableBase.ScheduleAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Admin - Task Schedule
        </h1>
        <br />
    <asp:GridView ID="GridViewHorseTask" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" GridLines="None" ShowHeader="False" DataKeyNames="HorseTaskID" onrowcommand="GridViewHorseTask_RowCommand">
        <Columns>
            <asp:BoundField DataField="HorseName" />
            <asp:BoundField DataField="TaskName" />
            <asp:BoundField DataField="TaskTime" />
            <asp:BoundField DataField="TaskInterval" />
            <asp:BoundField DataField="TaskNotes" />
            <asp:ButtonField CommandName="DeleteTask" Text="Delete" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Panel ID="PanelAddTask" style="border-top: 2px solid black;" runat="server">
        <h2>
            Add Task
        </h2>
        <table>
            <tr>
                <td>
                    Horse&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListHorse" runat="server" DataSourceID="LinqDataSourceHorse" DataTextField="HorseName" DataValueField="HorseID">
                    </asp:DropDownList>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    Task
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListTask" runat="server" DataSourceID="LinqDataSourceTask" DataTextField="TaskName" DataValueField="TaskID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Time
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListIsMorning" runat="server">
                        <asp:ListItem Value="True">Morning</asp:ListItem>
                        <asp:ListItem Value="False">Evening</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    Every Day
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxIsDaily" runat="server" AutoPostBack="True" Checked="True" oncheckedchanged="CheckBoxIsDaily_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    Between
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStartDate" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    and
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxEndDate" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Notes</td>
                <td colspan="4">
                    <asp:TextBox ID="TextBoxTaskNotes" runat="server" Columns="40" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddTask" runat="server" Text="Add Task" onclick="ButtonAddTask_Click" />
        <br />
        &nbsp;
        <asp:LinqDataSource ID="LinqDataSourceHorse" runat="server" ContextTypeName="StableBase.StableBaseDataContext" EntityTypeName="" OrderBy="HorseName" TableName="Horses">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDataSourceTask" runat="server" ContextTypeName="StableBase.StableBaseDataContext" EntityTypeName="" OrderBy="TaskName" TableName="Tasks">
        </asp:LinqDataSource>
    </asp:Panel>
</asp:Content>
