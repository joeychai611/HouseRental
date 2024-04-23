<%@ Page Title="" Language="C#" MasterPageFile="~/landing.master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="HouseRental.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                       <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <asp:Image Width="100px" ID="Image1" ImageUrl='<%# String.Format("PhotoHandler.ashx?ID={0}", Eval("ID")) %>' runat="server" />
                        </ItemTemplate>
                           </asp:TemplateField>
                    </Columns>
    </asp:GridView>
</asp:Content>
