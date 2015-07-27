<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horses.aspx.cs" Inherits="StableBase.Horses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .HorseDetailsPanel
        {
            position: absolute;
            width: 215px;
            padding: 20px;
            background-color: White;
            border: 1px solid black;
            top: 30px;
            left: 50%;
            margin-left: -107px;
        }
        .ProficencyBarContainer
        {
            width: 200px;
            height: 15px;
            padding: 5px;
            border: 1px solid black;
        }
        .ProficencyBar
        {
            height: 15px;
            background-color: Green;
        }
        .ScreenMask
        {
	        background-color: #111;
	        display: block;
	        filter: alpha(opacity=65);
	        height: 100%;
	        opacity: 0.65;
	        left: 0px;
	        position: absolute;
	        top: 0px;
	        width: 100%;
	        z-index: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Horses
    </h1>
    <br />
    <asp:LinqDataSource ID="LinqDataSourceHorse" runat="server" ContextTypeName="StableBase.StableBaseDataContext" EntityTypeName="" OrderBy="HorseName" TableName="Horses">
    </asp:LinqDataSource>
    <asp:GridView ID="GridViewHorse" runat="server" AutoGenerateColumns="False" DataKeyNames="HorseID" DataSourceID="LinqDataSourceHorse" ShowHeader="False" CellPadding="5" CellSpacing="2" GridLines="None" OnRowCommand="GridViewHorse_RowCommand" Font-Size="Large">
        <Columns>
            <asp:BoundField DataField="HorseName" HeaderText="HorseName" SortExpression="HorseName" />
            <asp:ButtonField CommandName="ViewDetails" Text="View Details" />
            <asp:ButtonField CommandName="ViewChecklist" Text="View Checklist" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="PanelScreenMask" class="ScreenMask" Visible="false" runat="server">
    </asp:Panel>
    <asp:Panel ID="PanelHorseDetails" class="HorseDetailsPanel" runat="server" Visible="False">
        <div style="font-size: x-large; font-weight: bold;">
            <asp:Label ID="LabelHorseName" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Image ID="ImageHorsePicture" runat="server" BorderStyle="Solid" Height="200px" Width="200px" ImageUrl="~/Images/NoPic.jpg" />
        </div>
        <div>
            Size:
            <asp:Label ID="LabelHorseSize" runat="server"></asp:Label>m
        </div>
        <div>
            Weight:
            <asp:Label ID="LabelHorseWeight" runat="server"></asp:Label>kg
        </div>
        <div>
            Riding School Proficiency:
            <div class="ProficencyBarContainer">
                <asp:Panel ID="PanelRidingSchoolProficiency" class="ProficencyBar" runat="server">
                </asp:Panel>
            </div>
        </div>
        <div>
            Show Jumping Proficiency:
            <div class="ProficencyBarContainer">
                <asp:Panel ID="PanelShowJumpingProficiency" class="ProficencyBar" runat="server">
                </asp:Panel>
            </div>
        </div>
        <div>
            Dressage Proficiency:
            <div class="ProficencyBarContainer">
                <asp:Panel ID="PanelDressageProficiency" class="ProficencyBar" runat="server">
                </asp:Panel>
            </div>
        </div>
        <div>
            Racing Proficiency:
            <div class="ProficencyBarContainer">
                <asp:Panel ID="PanelRacingProficiency" class="ProficencyBar" runat="server">
                </asp:Panel>
            </div>
        </div>
        <br />
        <asp:LinkButton ID="LinkButtonEditHorseDetails" runat="server" onclick="LinkButtonEditHorseDetails_Click">Edit</asp:LinkButton>
        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
        <asp:LinkButton ID="LinkButtonCloseHorseDetailsPanel" runat="server" OnClick="LinkButtonCloseHorseDetailsPanel_Click">Close</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="PanelHorseChecklist" runat="server" class="HorseDetailsPanel" Visible="false">
        <div style="font-size: x-large; font-weight: bold;">
            <asp:Label ID="LabelChecklistHorseName" runat="server"></asp:Label>
        </div>
        <br />
        <div style="font-size: large; font-weight: bold;">
            Morning
        </div>
        <asp:GridView ID="GridViewChecklistMorning" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" GridLines="None" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="TaskName" />
                <asp:BoundField DataField="HorseTaskNotes" />
            </Columns>
        </asp:GridView>
        <br />
        <div style="font-size: large; font-weight: bold;">
            Evening
        </div>
        <asp:GridView ID="GridViewChecklistEvening" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" GridLines="None" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="TaskName" />
                <asp:BoundField DataField="HorseTaskNotes" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:LinkButton ID="LinkButtonEditCheckList" runat="server" onclick="LinkButtonEditCheckList_Click">Edit</asp:LinkButton>
        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
        <asp:LinkButton ID="LinkButtonCloseChecklist" runat="server" OnClick="LinkButtonCloseChecklist_Click">Close</asp:LinkButton>
    </asp:Panel>
</asp:Content>