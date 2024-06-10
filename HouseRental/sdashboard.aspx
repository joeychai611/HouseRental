<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeBehind="sdashboard.aspx.cs" Inherits="HouseRental.sdashboard" %>
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
	                            <h3 class="mb-2">Student Dashboard</h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
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
	                                        <h5 class="text-muted">Outstanding Balance</h5>
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
				<asp:Calendar ID="Calendar2" runat="server" CssClass="Hide"></asp:Calendar>

				<center>
					<label><h4><b>Upcoming Appointment</b></h4></label>
				<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" ShowGridLines="True" OnDayRender="Calendar1_DayRender" Height="500px" NextPrevFormat="FullMonth" Width="900px">
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TodayDayStyle BackColor="#CCCCCC" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
        </asp:Calendar>
				</center>
        
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
<style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
</asp:Content>

