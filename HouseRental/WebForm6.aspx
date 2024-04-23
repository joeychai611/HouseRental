<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="HouseRental.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Test email page</h1><br />
        <asp:TextBox ID="email" placeholder="Enter email address for send a email" runat="server"></asp:TextBox><br />
        <asp:Button ID="sbtBtn" runat="server" Text="Button" OnClick="sbtBtn_Click" />
    </div>

</asp:Content>
