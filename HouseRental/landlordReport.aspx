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
					<asp:Label runat="server" ID="lbl"/>
					<center><label><h3><b>Monthly Report</b></h3></label></center>
<!-- widgets   -->
	                    <!-- ============================================================== -->
	                    <div class="row">
	                        <!-- ============================================================== -->
	                        <!-- four widgets   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total followers   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-4 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Appointment</h5>
	                                        <h2><asp:Label ID="label1" runat="server" Text="Appointment" /></h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
	                                        <i class="fa fa-calendar-check fa-fw fa-sm text-primary"></i>
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
	                        <div class="col-xl-4 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Rental</h5>
	                                        <h2><asp:Label ID="label2" runat="server" Text="Rental" /></h2>
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
	                        <div class="col-xl-4 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Earned</h5>
											<h2><asp:Label ID="label3" runat="server" Text="Earned" /></h2>
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
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->
    <asp:Chart runat="server" Width="950px" ID="Chart1" BackColor="Silver" BackImageAlignment="TopRight" BorderlineColor="Silver" BorderlineDashStyle="Solid" BorderlineWidth="2" CssClass="about-author" Height="500px">
        <Titles>
            <asp:Title Text="Total Revenue Per Month"></asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Line">
             </asp:Series>
        </Series>
		<ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Month"></AxisX>
                <AxisY Title="Total">
					<LabelStyle Format="RM ##" />
                </AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
					<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
				
						<asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false">
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True"/>
                                <asp:BoundField DataField="rental" HeaderText="rental" SortExpression="rental" />
                                <asp:BoundField DataField="landlordID" HeaderText="landlordID" SortExpression="landlordID" />
                                <asp:BoundField DataField="studentID" HeaderText="studentID" SortExpression="studentID" />
								<asp:BoundField DataField="status" HeaderText="status" SortExpression="status"/> 
                            </Columns>
                             <EditRowStyle BackColor="#2461BF" />
                             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#EFF3FB" />
                             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#F5F7FB" />
                             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                             <SortedDescendingCellStyle BackColor="#E9EBEF" />
                             <SortedDescendingHeaderStyle BackColor="#4870BE" />
                         </asp:GridView>

				<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false">
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True"/>
                                <asp:BoundField DataField="rental" HeaderText="rental" SortExpression="rental" />
                                <asp:BoundField DataField="landlordID" HeaderText="landlordID" SortExpression="landlordID" />
                                <asp:BoundField DataField="studentID" HeaderText="studentID" SortExpression="studentID" />
								<asp:BoundField DataField="status" HeaderText="status" SortExpression="status"/> 
                            </Columns>
                             <EditRowStyle BackColor="#2461BF" />
                             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#EFF3FB" />
                             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#F5F7FB" />
                             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                             <SortedDescendingCellStyle BackColor="#E9EBEF" />
                             <SortedDescendingHeaderStyle BackColor="#4870BE" />
                         </asp:GridView>

				<asp:GridView class="table table-striped table-bordered" ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView3_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false">
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True"/>
                                <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                                <asp:BoundField DataField="landlordID" HeaderText="landlordID" SortExpression="landlordID" />
                                <asp:BoundField DataField="studentID" HeaderText="studentID" SortExpression="studentID" />
								<asp:BoundField DataField="status" HeaderText="status" SortExpression="status"/> 
								 <asp:TemplateField>
								<ItemTemplate>
                        <asp:Label ID="total" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                         </ItemTemplate>
                </asp:TemplateField>
                            </Columns>
                             <EditRowStyle BackColor="#2461BF" />
                             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#EFF3FB" />
                             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#F5F7FB" />
                             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                             <SortedDescendingCellStyle BackColor="#E9EBEF" />
                             <SortedDescendingHeaderStyle BackColor="#4870BE" />
                         </asp:GridView>
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
	                 </div>
	             </div>
</asp:Content>