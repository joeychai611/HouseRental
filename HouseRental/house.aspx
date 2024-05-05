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
        <td><b> / mo </b></td><br /><br />
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
                      <p><a href="#" class="btn btn-secondary rounded">Book Appointment</a></p>
          		</div>

<!-- ============================================================== -->
<!-- end house details  -->
<!-- ============================================================== -->            	
                  <div class="rd-reviews">
                        <h4>Reviews</h4>
                        <div class="review-item">
                            <div class="ri-pic">
                                <img src="img/room/avatar/avatar-1.jpg" alt="">
                            </div>
                            <div class="ri-text">
                                <span>27 Aug 2019</span>
                                <div class="rating">
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star-half-stroke" style="color: #FFD43B;"></i>
                                </div>
                                <h5>Brandon Kelley</h5>
                                <p>Neque porro qui squam est, qui dolorem ipsum quia dolor sit amet, consectetur,
                                    adipisci velit, sed quia non numquam eius modi tempora. incidunt ut labore et dolore
                                    magnam.</p>
                            </div>
                        </div>
                        <div class="review-item">
                            <div class="ri-pic">
                                <img src="img/room/avatar/avatar-2.jpg" alt="">
                            </div>
                            <div class="ri-text">
                                <span>27 Aug 2019</span>
                                <div class="rating">
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star" style="color: #FFD43B;"></i>
                                    <i class="fa-solid fa-star-half-stroke" style="color: #FFD43B;"></i>
                                </div>
                                <h5>Brandon Kelley</h5>
                                <p>Neque porro qui squam est, qui dolorem ipsum quia dolor sit amet, consectetur,
                                    adipisci velit, sed quia non numquam eius modi tempora. incidunt ut labore et dolore
                                    magnam.</p>
                            </div>
                        </div>
                    </div>
<!-- ============================================================== -->
<!-- end review  -->
<!-- ============================================================== -->  
                    
          				</div>
          			</div>
          		</div>
          	</div>
    </section>
</asp:Content>
