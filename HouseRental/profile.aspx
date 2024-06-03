<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="HouseRental.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text d-flex align-itemd-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center d-flex align-items-end justify-content-center">
          	<div class="text">
	            <p class="breadcrumbs mb-2"><span class="mr-2"><a href="home.aspx">Home</a></span> <span>Profile</span></p>
	            <h1 class="mb-4 bread">Profile</h1>
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
                                <a href="homepage.aspx">Back</a>
                                <center>
                                    <img width="100px" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>                                
                                </div>
                            </div>
                        <div class="col-md-6">
                            <label>Email Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>   
                                </div>
                                </div>
                        </div>

                        <div class="row">
                                <div class="col-md-6">
                            <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>   
                                </div>
                                </div>
                            <div class="col-md-6">
                                <label>IC</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>   
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text ="Male" Value="Male" />
                                        <asp:ListItem Text ="Female" Value="Female" />
                                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                             <label>User Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" Enabled="False" runat="server">
                                        <asp:ListItem Text ="Student" Value="Student" />
                                        <asp:ListItem Text ="Landlord" Value="Landlord" />
                                         <asp:ListItem Text ="Admin" Value="Admin" />
                                    </asp:DropDownList>
                                </div>

                        </center>
                     </div>
                      <div class="col-8 mx-auto">
                                            <center><br />
                                                <asp:Label ID="Label7" Text="Images" runat="server"></asp:Label>
                                                <div class="form-group">
                                                    <asp:ImageButton ID="imgPhoto" OnClientClick ="popimage(this);return false" style="max-height:100%;max-width:80%; border: 1px solid #D3D3D3;" runat="server" />
                                                    <div id="dialog" style="display: none"></div>
                                            </div>
                                            </center>
                                        </div>
                  </div>


                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
<<<<<<< HEAD
                            <div class="form-group"><br />
                                <asp:Label ID="Label2" Text="Matric Card" runat="server"></asp:Label><br />
                                <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" /><br />
                            <asp:Label ID="Label3" Text="Only JPG, JPEG and PNG files" runat="server"></asp:Label>
                           </div>
                            <br />
                            
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button2" runat="server" Text="Update" OnClick="Button1_Click" />
=======

                            <br />
                            
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
                        </center>
                     </div>
                      <div class="col-8 mx-auto">
                                            <center><br />
                                                <asp:Label ID="Label7" Text="Images" runat="server"></asp:Label>
                                                <div class="form-group">
                                                    <asp:ImageButton ID="imgPhoto" OnClientClick ="popimage(this);return false" style="max-height:100%;max-width:80%; border: 1px solid #D3D3D3;" runat="server" />
                                                    <div id="dialog" style="display: none"></div>
                                            </div>
                                            </center>
                                        </div>
                  </div>
                        <div id="imagepop" style="display:none;text-align:center;height:80%">
                    <asp:Image ID="Image1" runat="server" ClientIDMode="Static" style="height:96%"/>
                </div>
                        <div>
                            <br />
                            <center>
                             <asp:LinkButton ID="changepassword" runat="server" onclick="changepassword_Click">Change Password</asp:LinkButton> 
                            </center>
                         </div>
               </div>
            </div>
                <br>
         </div>
            </div>
        </div>
</asp:Content>
