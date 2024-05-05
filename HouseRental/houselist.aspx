<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="houselist.aspx.cs" Inherits="HouseRental.houselist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text d-flex align-itemd-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center d-flex align-items-end justify-content-center">
          	<div class="text">
	            <p class="breadcrumbs mb-2"><span class="mr-2"><a href="home.aspx">Home</a></span>| <span>House</span></p>
	            <h1 class="mb-4 bread">House</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->  
    <br />
    <center>
    <asp:TextBox ID="customSearchTextBox" runat="server"></asp:TextBox>

<asp:Button ID="customSearchButton" runat="server" Text="Search"  class="btn btn-primary" OnClick="customSearchButton_Click" /><p></p>

        </center>
    <br />
<asp:Repeater ID="rpQuestions" runat="server">
    <ItemTemplate>
            <div style="border: 1px solid #D3D3D3; background-color: #FFFFFF; margin-left: 20%; margin-right: 20%;"> 
                <div class="row">
                            <div class="col-md-4">
                <tr>
                    <td >

                        <asp:Image ID="image" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[]) Eval("image"))%>' runat="server" style="max-height:100%;max-width:80%; border: 1px solid #D3D3D3;"/>

                    </td>
                    </div>
                    <div class="col-md-8">
                                                    <td>
                                    <b><asp:Label ID="lblname" runat="server" Text='<%#Eval("hname") %>'>
                                    </asp:Label></b><br />
                                </td>
                            
                                <td>
                                    <b><asp:Label ID="lblhousetype" runat="server" class="badge badge-pill badge-info" Text='<%#Eval("housetype") %>'>
                                    </asp:Label></b><br />
                                </td>
                            
                           
                                <td>
                                    <i class="fa-solid fa-location-dot"></i>
                                    <asp:Label ID="Label2" class="text-primary" runat="server" Text='<%#Eval("city") %>'>
                                    </asp:Label><br />
                                </td>
                           
                                <td>
                                    <b>RM <asp:Label ID="Label1" runat="server" Text='<%#Eval("rentprice") %>'>
                                    </asp:Label> /month</b><br />

                                </td>
                            
                                <td>
                                    <i class="fa-solid fa-square-plus"></i>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("accommodation") %>'>
                                    </asp:Label><br />
                                </td>
                            
                                <td>
                                    <br />
                                    <asp:Button class="btn btn-primary rounded" Text="More Details" ID="Button1" runat="server" PostBackUrl='<%# string.Format("~/house.aspx?ID={0}&hname={1}&housetype={2}&address={3}&postcode={4}&city={5}&description={6}&accommodation={7}&rentprice={8}&duration={9}&status={10}&image={11}", HttpUtility.UrlEncode(Eval("ID").ToString()),HttpUtility.UrlEncode(Eval("hname").ToString()),HttpUtility.UrlEncode(Eval("housetype").ToString()),HttpUtility.UrlEncode(Eval("address").ToString()),HttpUtility.UrlEncode(Eval("postcode").ToString()),HttpUtility.UrlEncode(Eval("city").ToString()),HttpUtility.UrlEncode(Eval("description").ToString()),HttpUtility.UrlEncode(Eval("accommodation").ToString()),HttpUtility.UrlEncode(Eval("rentprice").ToString()),HttpUtility.UrlEncode(Eval("duration").ToString()),HttpUtility.UrlEncode(Eval("status").ToString()),HttpUtility.UrlEncode(Eval("image").ToString())) %>'>
                                    </asp:Button>
                                </td>
                            </tr>
                </div>
                    </div>
                </div>
        <br />
        </ItemTemplate>
    
</asp:Repeater>
<!-- ============================================================== -->
<!-- end repeater  -->
<!-- ============================================================== -->   
    <div class="col-lg-12">
                    <div class="room-pagination">
                        <asp:LinkButton ID="LinkButton1" class="fa-solid fa-chevron-left" OnClick="LinkButton1_Click" runat="server"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" class="fa-solid fa-chevron-right" OnClick="LinkButton2_Click" runat="server"></asp:LinkButton>
                    </div>
                </div>
    <br />
</asp:Content>
