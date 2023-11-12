<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="KarateApp.mywork.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
            background-color: #FFFFFF;
        }
        .auto-style5 {
            width: 762px;
            background-color: #FFFFFF;
        }
        .auto-style10 {
            width: 762px;
            height: 228px;
            background-color: #FFFFFF;
        }
        .auto-style11 {
            height: 228px;
            background-color: #FFFFFF;
        }
        .auto-style12 {
            width: 762px;
            height: 58px;
            background-color: #FFFFFF;
        }
        .auto-style14 {
            width: 762px;
            height: 4px;
            background-color: #FFFFFF;
        }
        .auto-style15 {
            height: 4px;
            background-color: #FFFFFF;
        }
        .auto-style18 {
            width: 762px;
            height: 39px;
            background-color: #FFFFFF;
        }
        .auto-style19 {
            width: 279px;
        }
        .auto-style21 {
            width: 393px;
        }
        .auto-style22 {
            width: 333px;
        }
        .auto-style23 {
            background-color: #FFFFFF;
        }
        .auto-style24 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <span class="auto-style24">Administrator</span><br />
        <table class="auto-style4">
            <tr>
                <td class="auto-style10">
                    <asp:GridView ID="membersGridView" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
                </td>
                <td class="auto-style11">
                    <asp:GridView ID="instructorGridView" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
                </td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp; First Name:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="dltMemfNameBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Last Name:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="dltMemlNameBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style15">&nbsp;First Name:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="dltInsfNameBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Last Name:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="dltInslNameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="deleteMemberBtn" runat="server" OnClick="deleteMemberBtn_Click" Text="Delete Member" />
                    &nbsp;</td>
                <td class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="deleteInstructorBtn" runat="server" OnClick="deleteInstructorBtn_Click" Text="Delete Instructor" />
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemfNameBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style18">First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addInsfNameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style18">Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemlNameBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style18">Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addInslNameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Phone Number:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemPhoneBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style23">Phone Number:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addInsPhoneBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemEmailBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addInsUsrNameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemUsrNameBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addInsPwdBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="addMemPwdBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style23">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="addInstructorBtn" runat="server" OnClick="addInstructorBtn_Click" Text="Add Instructor" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="addMemberBtn" runat="server" OnClick="addMemberBtn_Click" Text="Add Member" />
&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">Add Member to Section:</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">Section Name:&nbsp;&nbsp;
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style22">Member:&nbsp;&nbsp;
                    <asp:DropDownList ID="memDropDownList" runat="server" DataSourceID="KarateSqlDataSource" DataTextField="MemberLastName" DataValueField="Member_UserID" Width="146px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="KarateSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [MemberLastName], [Member_UserID] FROM [Member]"></asp:SqlDataSource>
                </td>
                <td class="auto-style21">Instructor:&nbsp;&nbsp;
                    <asp:DropDownList ID="insDropDownList" runat="server" DataSourceID="KarateSqlDataSource2" DataTextField="InstructorLastName" DataValueField="InstructorID" Width="148px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="KarateSqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [InstructorID], [InstructorLastName] FROM [Instructor]"></asp:SqlDataSource>
                </td>
                <td>Fee:&nbsp;&nbsp;
                    <asp:TextBox ID="feeTextBox" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;&nbsp; &nbsp;<asp:Button ID="addToSectionBtn" runat="server" OnClick="addToSectionBtn_Click" Text="Add" />
                </td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
