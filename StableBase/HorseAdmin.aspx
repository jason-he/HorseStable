<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HorseAdmin.aspx.cs" Inherits="StableBase.HorseAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h1>
        Admin - Horses
        <asp:LinqDataSource ID="LinqDataSourceHorse" runat="server" ContextTypeName="StableBase.StableBaseDataContext" EntityTypeName="" OrderBy="HorseName" TableName="Horses">
        </asp:LinqDataSource>
    </h1>
    <br />
    Select Horse:
    <asp:DropDownList ID="DropDownListHorse" runat="server" AppendDataBoundItems="True" DataSourceID="LinqDataSourceHorse" DataTextField="HorseName" DataValueField="HorseID" OnSelectedIndexChanged="DropDownListHorse_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Selected="True" Value="0">-- Select a Horse --</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="ButtonAddNewHorse" runat="server" Text="Add New Horse" onclick="ButtonAddNewHorse_Click" Width="100px" />
    <asp:Panel ID="PanelHorseDetails" runat="server" Visible="False">
        <table>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Weight (kg)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseWeight" runat="server" MaxLength="7"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Height (m)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseSize" runat="server" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Picture
                </td>
                <td>
                    <asp:Image ID="ImageHorsePicture" runat="server" BorderStyle="Solid" Height="200px" ImageUrl="~/Images/NoPic.jpg" Width="200px" />
                    <br />
                    <asp:FileUpload ID="FileUploadHorsePicture" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    Riding School Proficiency (0-100)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseRidingSchool" runat="server" MaxLength="5"></asp:TextBox>                 
                </td>
            </tr>
            <tr>
                <td>
                    Show Jumping Proficiency (0-100)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseShowJumping" runat="server" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Dressage Proficiency (0-100)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseDressage" runat="server" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Racing Proficiency (0-100)
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHorseRacing" runat="server" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonSaveNewHorse" runat="server" Text="Add Horse" onclick="ButtonSaveNewHorse_Click" />
        <asp:Button ID="ButtonSave" runat="server" Text="Save Changes" onclick="ButtonSave_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel Changes" onclick="ButtonCancel_Click" />
    </asp:Panel>
</asp:Content>
