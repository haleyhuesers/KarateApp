<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="instructor.aspx.cs" Inherits="KarateApp.mywork.instructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            font-size: large;
        }
        .auto-style5 {
            font-size: x-large;
        }
        .auto-style6 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style5">
        Instructor</p>
    <p class="auto-style6">
        First Name:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p class="auto-style6">
        Last Name:
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
    <p class="auto-style4">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </p>
    <p class="auto-style4">
        &nbsp;</p>
    <p class="auto-style4">
        &nbsp;</p>
    <p class="auto-style4">
        &nbsp;</p>
    <p class="auto-style4">
        &nbsp;</p>
</asp:Content>
