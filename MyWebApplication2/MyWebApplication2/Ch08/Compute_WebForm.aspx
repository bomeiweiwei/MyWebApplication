<%@ Page Title="" Language="C#" MasterPageFile="~/Ch08/Ch08MasterPage.master" AutoEventWireup="true" CodeBehind="Compute_WebForm.aspx.cs" Inherits="MyWebApplication2.Ch08.Compute_WebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h3>WebService</h3>
    <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
    &nbsp;<asp:Label ID="Label1" runat="server" Text="X" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;
    <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
    &nbsp;<asp:Label ID="Label2" runat="server" Text="=" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;
    <asp:Label ID="lblAnswer" runat="server" Text="0" Font-Bold="True" Font-Size="X-Large"></asp:Label><br/>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/><br/>
    <hr />
    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
</asp:Content>
