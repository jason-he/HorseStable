<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StableBase._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to StableBase!
    </h2>
    <div>
    <h3>News</h3>
        <asp:UpdatePanel ID="UpdatePanelNews" runat="server">
            <ContentTemplate>
                <asp:Label ID="LabelNews" runat="server"></asp:Label>
                <asp:Timer ID="TimerNews" runat="server" Interval="30000" OnTick="TimerNews_Tick">
                </asp:Timer>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerNews" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    <div id="NewsDiv">
    </div>
    </div>
</asp:Content>
