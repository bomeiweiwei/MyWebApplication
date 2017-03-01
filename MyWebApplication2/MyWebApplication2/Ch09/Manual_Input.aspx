<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Manual_Input.aspx.cs" Inherits="MyWebApplication2.Ch09.Manual_Input" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    title :
        <asp:TextBox ID="TextBox1" runat="server" Width="182px"></asp:TextBox><br />
        class :
        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple">
            <asp:ListItem Selected="True">科技</asp:ListItem>
            <asp:ListItem>教育</asp:ListItem>
            <asp:ListItem>政治</asp:ListItem>
            <asp:ListItem>娛樂</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>  
        </asp:ListBox><br />
        summary :
        <asp:TextBox ID="TextBox2" runat="server" Width="506px"></asp:TextBox><br />
        article :
        <asp:TextBox ID="TextBox3" runat="server" Height="116px" TextMode="MultiLine" Width="522px"></asp:TextBox><br />
        author :
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Insert Into!" 
            onclick="Button1_Click" /><br />
        <br />
        <hr />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
            Font-Size="X-Small" AllowPaging="True" PageSize="5" 
            EnableSortingAndPagingCallbacks="True" 
            onpageindexchanging="GridView1_PageIndexChanging">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
</asp:Content>
