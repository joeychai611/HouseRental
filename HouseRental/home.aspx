<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HouseRental.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
        <section class="home-slider owl-carousel">
            <div class="slider-item" style="background-image: url(images/bg_2.jpg);">
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

            <div class="slider-item" style="background-image: url(images/image_5.jpg);">
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
                        <div class="col-md-3 d-flex py-md-5" style="margin-left: 15%;">
                            <textarea type="text" id="customSearchTextBox" ></textarea>
                            <button type="button" id="searchButton" class="btn btn-primary">Search</button>
                        </div>
                        <script>
                            $(function () {
                                $('.selectpicker').change(function () {
                                    var selections = [];
                                    var selectedOptions = $(this).find('option:selected');
                                    selectedOptions.each(function () {
                                        var optgroupLabel = $(this).parent().attr('label');
                                        var optionValue = $(this).val();
                                        selections.push({ optgroup: optgroupLabel, value: optionValue });
                                    });

                                    $(this).data('selections', selections);
                                });

                                $('#searchButton').on('click', function (e) {
                                    e.preventDefault();
                                    var selections = $('.selectpicker').data('selections') || [];
                                    var queryParams = "?";
                                    for (var i = 0; i < selections.length; i++) {
                                        queryParams += encodeURIComponent(selections[i].optgroup) + "=" + encodeURIComponent(selections[i].value);
                                        if (i != selections.length - 1) {
                                            queryParams += "&";
                                        }
                                    }
                                    window.location.href = "houselist.aspx" + queryParams + "&keyword=" + $('#customSearchTextBox').val();
                                });
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
