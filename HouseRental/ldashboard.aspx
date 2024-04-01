<%@ Page Title="" Language="C#" MasterPageFile="~/landlord.master" AutoEventWireup="true" CodeBehind="ldashboard.aspx.cs" Inherits="HouseRental.ldashboard" %>
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
	                            <h3 class="mb-2">Infulencer Dashboard Template </h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="#" class="breadcrumb-link">Dashboard</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Influencer Dashboard Template</li>
	                                    </ol>
	                                </nav>
	                            </div>
	                        </div>
	                    </div>
	                </div>
	                <!-- ============================================================== -->
	                <!-- end pageheader  -->
	                <!-- ============================================================== -->
	                <!-- ============================================================== -->
	                <!-- content  -->
	                <!-- ============================================================== -->
	                    <!-- ============================================================== -->
	                    <!-- widgets   -->
	                    <!-- ============================================================== -->
	                    <div class="row">
	                        <!-- ============================================================== -->
	                        <!-- four widgets   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total views   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Views</h5>
	                                        <h2 class="mb-0"> 10,28,056</h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-info-light mt-1">
	                                        <i class="fa fa-eye fa-fw fa-sm text-info"></i>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end total views   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total followers   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Followers</h5>
	                                        <h2 class="mb-0"> 24,763</h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
	                                        <i class="fa fa-user fa-fw fa-sm text-primary"></i>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end total followers   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- partnerships   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Partnerships</h5>
	                                        <h2 class="mb-0">14</h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-secondary-light mt-1">
	                                        <i class="fa fa-handshake fa-fw fa-sm text-secondary"></i>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end partnerships   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total earned   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Earned</h5>
	                                        <h2 class="mb-0"> $149.00</h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-brand-light mt-1">
	                                        <i class="fa fa-money-bill-alt fa-fw fa-sm text-brand"></i>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end total earned   -->
	                        <!-- ============================================================== -->
	                    </div>
	                    <!-- ============================================================== -->
	                    <!-- end widgets   -->
	                    <!-- ============================================================== -->

	                    <div class="row">
	                        <!-- ============================================================== -->
	                        <!-- campaign activities   -->
	                        <!-- ============================================================== -->
	                        <div class="col-lg-12">
	                            <div class="section-block">
	                                <h3 class="section-title">My Active Campaigns</h3>
	                            </div>
	                            <div class="card">
	                                <div class="campaign-table table-responsive">
	                                    <table class="table">
	                                        <thead>
	                                            <tr class="border-0">
	                                                <th class="border-0">Company</th>
	                                                <th class="border-0">Campaign Name</th>
	                                                <th class="border-0">Social Platform</th>
	                                                <th class="border-0">Min / Max Views</th>
	                                                <th class="border-0">Status</th>
	                                                <th class="border-0">Start Date</th>
	                                                <th class="border-0">Action</th>
	                                            </tr>
	                                        </thead>
	                                        <tbody>
	                                            <tr>
	                                                <td>
	                                                    <div class="m-r-10"><img src="assets/images/dribbble.png" alt="user" width="35"></div>
	                                                </td>
	                                                <td>Fashion E Commerce </td>
	                                                <td>
	                                                    <div class="avatar-group">
	                                                        <span><a href="#"><i class="fab fa-fw fa-facebook-square facebook-color"></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-twitter-square twitter-color"></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-instagram instagram-color"></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-pinterest-square pinterest-color"></i></a></span>
	                                                    </div>
	                                                </td>
	                                                <td>1,00,000 / 1,50,000</td>
	                                                <td>70%</td>
	                                                <td>7 Aug,2018</td>
	                                                <td>
	                                                    <div class="dropdown float-right">
	                                                        <a href="#" class="dropdown-toggle card-drop" data-toggle="dropdown" aria-expanded="true">
	                                                                <i class="mdi mdi-dots-vertical"></i>
	                                                                     </a>
	                                                        <div class="dropdown-menu dropdown-menu-right">
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Sales Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Export Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Profit</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Action</a>
	                                                        </div>
	                                                    </div>
	                                                </td>
	                                            </tr>
	                                            <tr>
	                                                <td>
	                                                    <div class="m-r-10"><img src="assets/images/github.png" alt="user" width="35"></div>
	                                                </td>
	                                                <td>Fitness Products </td>
	                                                <td>
	                                                    <div class="avatar-group">
	                                                        <span><a href="#"><i class="fab fa-fw fa-facebook-square facebook-color "></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-twitter-square twitter-color "></i></a></span>
	                                                    </div>
	                                                </td>
	                                                <td>2,50,000 / 3,50,000</td>
	                                                <td>70%</td>
	                                                <td>10 Aug,2018</td>
	                                                <td>
	                                                    <div class="dropdown float-right">
	                                                        <a href="#" class="dropdown-toggle  card-drop" data-toggle="dropdown" aria-expanded="true">
	                                            <i class="mdi mdi-dots-vertical"></i>
	                                        </a>
	                                                        <div class="dropdown-menu dropdown-menu-right">
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Sales Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Export Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Profit</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Action</a>
	                                                        </div>
	                                                    </div>
	                                                </td>
	                                            </tr>
	                                            <tr>
	                                                <td>
	                                                    <div class="m-r-10"><img src="assets/images/dropbox.png" alt="user" width="35"></div>
	                                                </td>
	                                                <td>Gym Trainer Program </td>
	                                                <td>
	                                                    <div class="avatar-group">
	                                                        <span><a href="#"><i class="fab fa-fw fa-facebook-square facebook-color "></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-pinterest-square pinterest-color "></i></a></span>
	                                                    </div>
	                                                </td>
	                                                <td>3,50,000 / 4,50,000</td>
	                                                <td>70%</td>
	                                                <td>22 Aug,2018</td>
	                                                <td>
	                                                    <div class="dropdown float-right">
	                                                        <a href="#" class="dropdown-toggle  card-drop" data-toggle="dropdown" aria-expanded="true">
	                                            <i class="mdi mdi-dots-vertical"></i>
	                                        </a>
	                                                        <div class="dropdown-menu dropdown-menu-right">
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Sales Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Export Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Profit</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Action</a>
	                                                        </div>
	                                                    </div>
	                                                </td>
	                                            </tr>
	                                            <tr>
	                                                <td>
	                                                    <div class="m-r-10"><img src="assets/images/bitbucket.png" alt="user" width="30"></div>
	                                                </td>
	                                                <td>2018 Top Product </td>
	                                                <td>
	                                                    <div class="avatar-group">
	                                                        <span><a href="#"><i class="fab fa-fw fa-pinterest-square pinterest-color"></i></a></span>
	                                                    </div>
	                                                </td>
	                                                <td>4,50,000 / 5,50,000</td>
	                                                <td>70%</td>
	                                                <td>25 Aug,2018</td>
	                                                <td>
	                                                    <div class="dropdown float-right">
	                                                        <a href="#" class="dropdown-toggle  card-drop" data-toggle="dropdown" aria-expanded="true">
	                                            <i class="mdi mdi-dots-vertical"></i>
	                                        </a>
	                                                        <div class="dropdown-menu dropdown-menu-right">
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Sales Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Export Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Profit</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Action</a>
	                                                        </div>
	                                                    </div>
	                                                </td>
	                                            </tr>
	                                            <tr>
	                                                <td>
	                                                    <div class="m-r-10"><img src="assets/images/mail_chimp.png" alt="user" width="30"></div>
	                                                </td>
	                                                <td>Top Dashboard Sale 2018</td>
	                                                <td>
	                                                    <div class="avatar-group">
	                                                        <span><a href="#"><i class="fab fa-fw fa-facebook-square facebook-color"></i></a></span>
	                                                        <span><a href="#"><i class="fab fa-fw fa-pinterest-square pinterest-color"></i></a></span>
	                                                    </div>
	                                                </td>
	                                                <td>5,50,000 / 6,50,000</td>
	                                                <td>70%</td>
	                                                <td>27 Aug,2018</td>
	                                                <td>
	                                                    <div class="dropdown float-right">
	                                                        <a href="#" class="dropdown-toggle  card-drop" data-toggle="dropdown" aria-expanded="true">
	                                            <i class="mdi mdi-dots-vertical"></i>
	                                        </a>
	                                                        <div class="dropdown-menu dropdown-menu-right">
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Sales Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Export Report</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Profit</a>
	                                                            <!-- item-->
	                                                            <a href="javascript:void(0);" class="dropdown-item">Action</a>
	                                                        </div>
	                                                    </div>
	                                                </td>
	                                            </tr>
	                                        </tbody>
	                                    </table>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end campaign activities   -->
	                        <!-- ============================================================== -->
	                    </div>
	                                    <!-- ============================================================== -->
	                                    <!-- end content  -->
	                                    <!-- ============================================================== -->
	                                </div>
	                            </div>
			</div>
</asp:Content>
