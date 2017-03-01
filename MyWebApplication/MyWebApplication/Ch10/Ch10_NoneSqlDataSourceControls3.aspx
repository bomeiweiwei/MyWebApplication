<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_NoneSqlDataSourceControls3.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_NoneSqlDataSourceControl3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
    <Columns>
        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>
</asp:Content>
