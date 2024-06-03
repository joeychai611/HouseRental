<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="HouseRental.house1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text d-flex align-itemd-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center d-flex align-items-end justify-content-center">
          	<div class="text">
	            <p class="breadcrumbs mb-2"><span class="mr-2"><a href="home.aspx">Home</a></span>| <span class="mr-2"><a href="houselist.aspx">House</a></span>| <span>House Detail</span></p>
	            <h1 class="mb-4 bread">House Detail</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->   

    <section class="ftco-section" style="margin-left: 15%; margin-right: 20%;">
      <div class="container">
        <div class="row">
          <div class="col-lg-8">
          	<div class="row">
          		<div class="col-md-12 ftco-animate">
          			<div class="single-slider owl-carousel">
          				<div class="item">
          					<div class="room-img" style="background-image: url(images/room-4.jpg);"></div>
          				</div>
          				<div class="item">
          					<div class="room-img" style="background-image: url(images/room-5.jpg);"></div>
          				</div>
          				<div class="item">
          					<div class="room-img" style="background-image: url(images/room-6.jpg);"></div>
          				</div>
          			</div>
          		</div>
                  
          		<div class="col-md-12 room-single mt-4 mb-5 ftco-animate">
                      <tr>
        <td><asp:Label ID="lblStatus" runat="server" ></asp:Label></td><br /><br />
</tr>
<tr>
        <td><h1><asp:Label ID="lblName" runat="server" ></asp:Label></h1></td>
    </tr>
                      <tr>
        <td><asp:Label ID="lblHousetype" runat="server"></asp:Label></td><br /><br />
    </tr>
<tr>
    <tr>
        <h3>
        <td><b>RM </b></td>
        <td><asp:Label ID="lblRentprice" runat="server"></asp:Label></td>
        <td><b> / month </b></td><br /><br />
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
        </h3>
    </tr>
    <hr>
    </hr><br />
        <td><h2><asp:Label ID="lblAddress" runat="server"></asp:Label></h2></td><br />
    </tr>
                      <div class="row">
                            <div class="col-md-6">
    <tr>
        <td><b>Postcode: </b></td>
        <td><asp:Label ID="lblPostcode" runat="server"></asp:Label></td><br /><br />
    </tr>
                        </div>
                          <div class="col-md-6">
<tr>
        <td><b>City: </b></td>
        <td><asp:Label ID="lblCity" runat="server"></asp:Label></td><br /><br />
    </tr>
                              </div>
                          </div><hr>
    </hr><br />
    <tr>
        <td><b>Description: </b></td><br />
        <td><asp:Label ID="lblDescription" runat="server"></asp:Label></td><br /><br />
    </tr>
                      
    <hr>
    </hr><br />
<tr>
        <td><b>Accommodation</b></td><br />
        <td><asp:Label ID="lblAccommodation" runat="server"></asp:Label></td><br /><br />
    </tr>           
    <hr>
    </hr><br />
    
<tr>
        <td><b>Duration</b></td><br />
        <td><asp:Label ID="lblDuration" runat="server"></asp:Label></td><br /><br />
    </tr><hr>
    </hr><br />
                      <tr>
        <td><b>Landlord</b></td><br />
        <td><asp:Label ID="lblLandlord" runat="server"></asp:Label></td><br /><br />
    </tr>
       <button type="button" id="btnShowPopup" runat="server" onclick="btnShowPopup_Click" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">Make Appointment</button>
>>>>>>> 2c705f348bfbddd71134745bb509bc4f3e6ae56d
          		</div>
<!-- ============================================================== -->
<!-- start make appointment  -->
<!-- ============================================================== -->
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">Appointment</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="Date" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Time</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                                    <asp:ListItem Text ="9.00AM - 10.00AM" Value="9.00AM - 10.00AM" />
                                                    <asp:ListItem Text ="10.00AM - 11.00AM" Value="10.00AM - 11.00AM" />
                                                    <asp:ListItem Text ="11.00AM - 12.00PM" Value="11.00AM - 12.00PM" />
                                                    <asp:ListItem Text ="2.00PM - 3.00PM" Value="2.00PM - 3.00PM" />
                                                    <asp:ListItem Text ="3.00PM - 4.00PM" Value="3.00PM - 4.00PM" />
                                                    <asp:ListItem Text ="4.00PM - 5.00PM" Value="4.00PM - 5.00PM" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>House Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Address</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Landlord</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Contact Number</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div> 
                            <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end make appointment  -->
<!-- ============================================================== -->
          		</div>

<!-- ============================================================== -->
<!-- end house details  -->
<!-- ============================================================== -->            	 
          				</div>
          			</div>
          		</div>
          	</div>
    </section>

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        var today = new Date();
        var month = ('0' + (today.getMonth() + 1)).slice(-2);
        var day = ('0' + today.getDate()).slice(-2);
        var year = today.getFullYear();
        var date = year + '-' + month + '-' + day;
        $('[id*=TextBox1]').attr('min', date);
    });
</script>
</asp:Content>
