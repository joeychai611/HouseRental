<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="HouseRental.resetpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text d-flex align-itemd-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center d-flex align-items-end justify-content-center">
          	<div class="text">
	            <p class="breadcrumbs mb-2"><span class="mr-2"><a href="home.aspx">Home</a></span>| <span>Profile</span></p>
	            <h1 class="mb-4 bread">User Profile</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <a href="home.aspx" class="fa-solid fa-arrow-left"></a>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Reset Password</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label><br />
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <div class="col">
                        <label>New Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        </div>
                        </asp:PlaceHolder>

                        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                        <div class="col">
                        <label>Confirm New Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                            </asp:PlaceHolder>
                  </div>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server">
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Submit" onClick="Button1_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>
                        </asp:PlaceHolder>
    
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server">
                        <div  style ="text-align:center;">
                        <asp:Label ID="Label2" runat="server" Text="Link is expired."></asp:Label><br /><br /><br />
                            </div>
                    </asp:PlaceHolder>
               </div>
            </div>
         </div>
        </div>
</asp:Content>
