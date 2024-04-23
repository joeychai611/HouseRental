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
                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>                                
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
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>   
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text ="Male" Value="Male" />
                                        <asp:ListItem Text ="Female" Value="Female" />
                                        </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>User Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" Enabled="False" runat="server">
                                        <asp:ListItem Text ="Student" Value="Student" />
                                        <asp:ListItem Text ="Landlord" Value="Landlord" />
                                         <asp:ListItem Text ="Admin" Value="Admin" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>

                            <br />
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                           </div>
                        </center>
                     </div>
                  </div>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                       <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <asp:Image Width="100px" ID="Image1" ImageUrl='<%# String.Format("PhotoHandler.ashx?ID={0}", Eval("ID")) %>' runat="server" />
                        </ItemTemplate>
                           </asp:TemplateField>
                    </Columns>
    </asp:GridView>

                        <div>
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
