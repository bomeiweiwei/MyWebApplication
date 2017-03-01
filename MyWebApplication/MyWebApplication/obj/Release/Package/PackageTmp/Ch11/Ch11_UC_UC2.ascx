<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ch11_UC_UC2.ascx.cs" Inherits="MyWebApplication.Ch11.Ch11_UC_UC2" %>
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
    <DayStyle BackColor="#CCCCCC" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
    <TodayDayStyle BackColor="#999999" ForeColor="White" />
</asp:Calendar>

