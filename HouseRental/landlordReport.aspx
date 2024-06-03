<%@ Page Title="" Language="C#" MasterPageFile="~/landlord.master" AutoEventWireup="true" CodeBehind="landlordReport.aspx.cs" Inherits="HouseRental.landlordReport" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
	                            <h3 class="mb-2">Manage Report</h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Manage Report</li>
	                                    </ol>
	                                </nav>
	                            </div>
	                        </div>
	                    </div>
	                </div>
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->
    <asp:Chart runat="server" Width="350px" ID="Chart1">
        <Titles>
            <asp:Title Text="Total Revenue"></asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Line">
             </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Month"></AxisX>
                <AxisY Title="RM"></AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
	                 </div>
	             </div>
</asp:Content>