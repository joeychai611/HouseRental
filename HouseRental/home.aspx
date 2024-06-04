<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HouseRental.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/i18n/defaults-*.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
        <section class="home-slider owl-carousel">
            <div class="slider-item" style="background-image: url(images/bg_1.jpg);">
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

            <div class="slider-item" style="background-image: url(images/bg_2.jpg);">
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
                    <div class="row" style="width: 3000px !important;">
                        <div class="col-md-3 d-flex py-md-5" style="margin-left: 10%;">
                            <select class="selectpicker" multiple data-width="500px" data-live-search="true">
                                <optgroup label="housetype" data-max-options="1">
                                    <option data-tokens="Apartment">Apartment</option>
                                    <option data-tokens="Terrace">Terrace House</option>
                                    <option data-tokens="Condominium">Condominium</option>
                                </optgroup>
                                <optgroup label="price" data-max-options="1">
                                    <option data-tokens="300">300</option>
                                    <option data-tokens="500">500</option>
                                    <option data-tokens="200">200</option>
                                </optgroup>
                                <optgroup label="city" data-max-options="1">
                                    <option data-tokens="Mount Austin">Mount Austin</option>
                                    <option data-tokens="Johor Bahru">Johor Bahru</option>
                                    <option data-tokens="Skudai">Skudai</option>
                                </optgroup>
                            </select>
                            <button id="searchButton" class="btn btn-primary" style="margin-left: 5%;">Search</button>
                        </div>
                        <script>
                            $(function () {
                                $('.selectpicker').selectpicker();
                            });
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </section>
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
