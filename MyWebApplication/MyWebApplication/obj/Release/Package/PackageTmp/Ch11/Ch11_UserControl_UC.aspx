<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_UserControl_UC.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_UserControl_UC" %>

<%@ Register Src="~/Ch11/Ch11_UC_UC1.ascx" TagPrefix="uc1" TagName="Ch11_UC_UC1" %>
<%@ Register Src="~/Ch11/MyUC.ascx" TagPrefix="uc1" TagName="MyUC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
</asp:Calendar>
    <uc1:ch11_uc_uc1 runat="server" id="Ch11_UC_UC1" />
    <uc1:MyUC runat="server" id="MyUC" />
</asp:Content>
