<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HouseRental.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px;">
        <div class="row">
            <div class="col-md-6 mx-auto">
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
                                    <h3>Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Email Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                    <a href="forgotpassword.aspx" style="float: right">Forgot Password? </a>
                                    <br />
                                </div>
                                <div id="dvCaptcha">
                                </div>
                                <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                                <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Captcha validation is required." ControlToValidate="txtCaptcha" runat="server" ForeColor="Red" Display="Dynamic" />
                                <br />
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                                <div>
                                    Don't have an account?
                             <a href="register.aspx">Register</a><br>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" asyncdefer></script>
<script type="text/javascript">
    var onloadCallback = function () {
        grecaptcha.render('dvCaptcha', {
            'sitekey': '6Lf6Y_MpAAAAAFS-KK7s__ylaLbnMwrMfLAxpyG7',
            'callback': function (response) {
                $.ajax({
                    type: "POST",
                    url: "register.aspx/VerifyCaptcha",
                    data: "{response: '" + response + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        var captchaResponse = jQuery.parseJSON(r.d);
                        if (captchaResponse.success) {
                            $("[id*=txtCaptcha]").val(captchaResponse.success);
                            $("[id*=rfvCaptcha]").hide();
                        } else {
                            $("[id*=txtCaptcha]").val("");
                            $("[id*=rfvCaptcha]").show();
                            var error = captchaResponse["error-codes"][0];
                            $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);
                        }
                    }
                });
            }
        });
    };
</script>
</asp:Content>
