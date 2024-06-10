<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="HouseRental.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
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
                                    <h3>Forgot Password</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="col">
                            <label>Email Address</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-8 mx-auto">
                            <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                                </div>
                            </center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
