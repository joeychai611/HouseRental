<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="HouseRental.register" %>

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
                                    <h3>Register</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>* Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>* Email Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>* Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>* IC (XXXXXX-XX-XXXX)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>User Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Student" Value="Student" />
                                        <asp:ListItem Text="Landlord" Value="Landlord" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>* Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>* Re-confirm Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^.*(?=.{8,})(?=.*[\d])(?=.*[\W]).*$" ControlToValidate="TextBox5" ErrorMessage="Password must contains at least 8 characters, 1 digit and 1 special character." ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="dvCaptcha">
                        </div>
                        <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                        <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Captcha validation is required." ControlToValidate="txtCaptcha" runat="server" ForeColor="Red" Display="Dynamic" />

                        <br />
                        <div class="form-group">
                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                        </div>
                        <div>
                            Have an account?
                             <a href="login.aspx">Login</a><br>
                        </div>
                    </div>
                </div>
                <br>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowHideDiv() {
            var chkYes = document.getElementById("chkYes");
            var dvPassport = document.getElementById("dvPassport");
            dvPassport.style.display = chkYes.checked ? "block" : "none";
        }
    </script>
    <script type="text/javascript">
        function ShowHideDiv() {
            var chkYes = document.getElementById("chkYes");
            var dvPassport = document.getElementById("dvPassport");
            dvPassport.style.display = chkYes.checked ? "block" : "none";
        }
    </script>

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
