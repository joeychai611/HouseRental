<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="HouseRental.aboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text d-flex align-itemd-center justify-content-center">
          <div class="col-md-9 ftco-animate text-center d-flex align-items-end justify-content-center">
          	<div class="text">
	            <p class="breadcrumbs mb-2"><span class="mr-2"><a href="home.aspx">Home</a></span>| <span>About Us</span></p>
	            <h1 class="mb-4 bread">About Us</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
    <br />
    <section class="testimony-section">
      <div class="container">
        <div class="row no-gutters ftco-animate justify-content-center">
        	<div class="col-md-5 d-flex">
        		<div class="testimony-img aside-stretch-2" style="background-image: url(images/testimony-img.jpg);"></div>
        	</div>
          <div class="col-md-7 py-5 pl-md-5">
          	<div class="py-md-5">
	          	<div class="heading-section ftco-animate mb-4">
	          		<span class="subheading">House Rental System</span>
			          <h2 class="mb-0">About Us</h2>
			        </div>
	            <div class="carousel-testimony owl-carousel ftco-animate">
	              <div class="item">
	                <div class="testimony-wrap pb-4">
	                  <div class="text">
	                    <p class="mb-3">Focusing on key features that would address the students' need. The system would allow students to browse and search for available properties, view detailed descriptions and photos, and connect directly with landlords through the system. The platform brought together students and landlords, offering a seamless rental experience tha simplified the search process, enhanced communication, and facilitated secure transactions.</p>
                        <br />
                        <p><a href="houselist.aspx" class="btn btn-secondary rounded">Rent Now</a></p>
                      </div>
	                </div>
	              </div>    
	            </div>
	          </div>
          </div>
        </div>
      </div>
    </section>
    <br />
</asp:Content>
