<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeBehind="paymentGateway.aspx.cs" Inherits="HouseRental.paymentGateway" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
     <!-- ============================================================== -->
	    <!-- wrapper  -->
	    <!-- ============================================================== -->
	    <div class="dashboard-wrapper">
	        <div class="dashboard-influence">
	            <div class="container-fluid dashboard-content"> 
<!-- ============================================================== -->
<!-- pageheader  -->
<!-- ============================================================== -->
	                <div class="row">
	                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
	                        <div class="page-header">
	                            <h3 class="mb-2">Make Payment</h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Payment</li>
	                                    </ol>
	                                </nav>
	                            </div>
	                        </div>
	                    </div>
	                </div>
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->
    <div class="container">
        <div class="row">
            <div class="col-md-8">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Credit Card</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-10">
                                <label>Cardholder Name*</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-10">
                                <label>Card Number*</label>
                                <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox> 
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            
                            <div class="col-md-3">
                                <label>Expiry Date*</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="MM"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label style='color:white'>_</label>
                                <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="YY"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>CVV*</label>
                                <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox> 
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                            </div>
                            <div class="col-4">
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" OnClick="Button2_Click" runat="server" Text="Pay" />
                            </div>
                        </div>


                    </div>
                </div>
                <br>
            </div>

            <div class="col-md-4">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Payment Details</h4>
                                    </center>
                            </div>
                        </div>
                        <hr />
                       <div class="row">
                            <div class="col-4">
                                <label>Detail</label>
                            </div>
                            <div class="col-5">
                                <asp:label ID="Label1" runat="server"></asp:label>  
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <label>Payment</label>
                            </div>
                            <div class="col-5">
                                <label>RM </label>
                                <asp:label ID="Label2" runat="server"></asp:label>  
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <label>Late Fee</label>
                            </div>
                            <div class="col-5">
                                <label>RM </label>
                                <asp:label ID="Label3" runat="server"></asp:label>  
                            </div>
                        </div>

                        <hr />
                        <div class="row">
                            <div class="col-4">
                                <label>Total</label>
                            </div>
                            <div class="col-5">
                                <label>RM </label>
                                <asp:label ID="Label4" runat="server"></asp:label>  
                            </div>
                        </div>


                    </div>
                </div>


            </div>

        </div>
    </div>
<!-- ============================================================== -->
<!-- start show payment  -->
<!-- ============================================================== -->
                    <div class="modal fade" id="myCModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <div class="container">
                                    <div style ="text-align:center;color:green;">
                                        <i class="fa-solid fa-circle-check fa-2xl" style="color: #1ac793;"></i><br />
                                        <h4 style ="text-align:center;color:green;" class="modal-title w-100">Payment Successful</h4>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-6">
                                            <label>Date</label>
                                        </div>
                                        <div class="col-5">
                                            <asp:label ID="Label5" runat="server"></asp:label> 
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <label>Detail</label>
                                        </div>
                                        <div class="col-5">
                                            <asp:label ID="Label6" runat="server"></asp:label> 
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <label>Payment Type</label>
                                        </div>
                                        <div class="col-5"> 
                                            <asp:label ID="Label7" runat="server"></asp:label> 
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <label>Amount Paid</label>
                                        </div>
                                        <div class="col-5"> 
                                            <asp:label ID="Label8" runat="server"></asp:label> 
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <label>Transaction ID</label>
                                        </div>
                                        <div class="col-5">
                                            <asp:label ID="Label9" runat="server"></asp:label> 
                                        </div>
                                    </div>

                                </div>
                            </div> 
                            <div class="modal-footer">
                            <asp:Button id="Button1" class="btn btn-primary" runat="server" OnClick="Button_Click" Text="Done" /> 
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end show payment  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
	                 </div>
	             </div>
    </div>
    <script type='text/javascript'>
    function openCModal() {
        $('[id*=myCModal]').modal('show');
    }
    </script>
</asp:Content>