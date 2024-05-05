<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HouseRental.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
	    <section class="home-slider owl-carousel">
	      <div class="slider-item" style="background-image:url(images/bg_1.jpg);">
	      	<div class="overlay"></div>
	        <div class="container">
	          <div class="row no-gutters slider-text align-items-center justify-content-end">
	          <div class="col-md-6 ftco-animate">
	          	<div class="text">
	          		<h2>House Rental</h2>
		            <h1 class="mb-3">Service is the rent we pay for being.</h1>
	            </div>
	          </div>
	        </div>
	        </div>
	      </div>

	      <div class="slider-item" style="background-image:url(images/bg_2.jpg);">
	      	<div class="overlay"></div>
	        <div class="container">
	          <div class="row no-gutters slider-text align-items-center justify-content-end">
	          <div class="col-md-6 ftco-animate">
	          	<div class="text">
	          		<h2>House rental</h2>
		            <h1 class="mb-3">It feels like staying in your own home.</h1>
	            </div>
	          </div>
	        </div>
	        </div>
	      </div>
	    </section>
	  </div>

    <section class="ftco-booking ftco-section ftco-no-pt ftco-no-pb">
    	<div class="container">
    		<div class="row no-gutters">
    			<div class="col-lg-12">
    				<form action="#" class="booking-form aside-stretch">
	        		<div class="row">
	        			<div class="col-md-3 d-flex py-md-5" style="margin-left: 30%;">
	        				<div class="form-group align-self-stretch d-flex align-items-end">
	        					<div class="wrap py-3 px-4">
				    					<input type="text" class="form-control" placeholder="Location">
			    					</div>
			    				</div>
	        			</div>
	        			
	        			<div class="col-md-2 py-md-4">
	        				<div class="form-group d-flex align-self-stretch">
			              <a href="houselist.aspx" class="btn btn-primary py-5 py-md-10 px-4 align-self-stretch d-block"><span>Search House</span></a>
			            </div>
	        			</div>
	        		</div>
	        	</form>
	    		</div>
    		</div>
    	</div>
    </section>

    <center>
    <asp:TextBox ID="customSearchTextBox" runat="server"></asp:TextBox>
<asp:Button ID="customSearchButton" runat="server" Text="Search" OnClick="customSearchButton_Click" /><p></p>
        </center>

		<section class="ftco-section">
      <div class="container">
      	<div class="row justify-content-center mb-5 pb-3">
          <div class="col-md-7 heading-section text-center ftco-animate">
          	<span class="subheading">Welcome to</span>
            <h2 class="mb-4">House Rental System</h2>
          </div>
        </div>  
        <div class="row d-flex">
          <div class="col-md pr-md-1 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services py-4 d-block text-center">
              <div class="d-flex justify-content-center">
              	<div class="icon d-flex align-items-center justify-content-center">
              		<span class="fa-solid fa-location-dot"></span>
              	</div>
              </div>
              <div class="media-body">
                <h3 class="heading mb-3">Strategic Location</h3>
              </div>
            </div>      
          </div>
          <div class="col-md px-md-1 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services active py-4 d-block text-center">
              <div class="d-flex justify-content-center">
              	<div class="icon d-flex align-items-center justify-content-center">
              		<span class="fa-solid fa-lock"></span>
              	</div>
              </div>
              <div class="media-body">
                <h3 class="heading mb-3">Safety and Security</h3>
              </div>
            </div>    
          </div>
          <div class="col-md px-md-1 d-flex align-sel Searchf-stretch ftco-animate">
            <div class="media block-6 services py-4 d-block text-center">
              <div class="d-flex justify-content-center">
              	<div class="icon d-flex align-items-center justify-content-center">
					  <span class="fa-solid fa-suitcase-rolling"></span>
              	</div>
              </div>
              <div class="media-body">
                <h3 class="heading mb-3">Ready to Move</h3>
              </div>
            </div>      
          </div>
          <div class="col-md px-md-1 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services py-4 d-block text-center">
              <div class="d-flex justify-content-center">
              	<div class="icon d-flex align-items-center justify-content-center">
              		<span class="fa-solid fa-money-bill"></span>
              	</div>
              </div>
              <div class="media-body">
                <h3 class="heading mb-3">Affortable Rental</h3>
              </div>
            </div>      
          </div>
          <div class="col-md pl-md-1 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services py-4 d-block text-center">
              <div class="d-flex justify-content-center">
              	<div class="icon d-flex align-items-center justify-content-center">
              		<span class="ion-ios-bed"></span>
              	</div>
              </div>
              <div class="media-body">
                <h3 class="heading mb-3">Cozy Rooms</h3>
              </div>
            </div>      
          </div>
        </div>
      </div>
    </section>
</asp:Content>
