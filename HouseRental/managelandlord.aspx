<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="managelandlord.aspx.cs" Inherits="HouseRental.managelandlord" %>

     <!-- ============================================================== -->
	    <!-- wrapper  -->
	    <!-- ============================================================== -->
	    <div class="dashboard-wrapper">
	        <div class="dashboard-influence">
	            <div class="container-fluid dashboard-content">

                            <h4 class="modal-title w-100">Landlord</h4>
                        </div>
                        <div class="modal-body">
                             <div class="container">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>                                
                                </div>
                            </div>
                        <div class="col-md-6">
                            <label>Email Address</label>
                                <div class="form-group">

                                </div>
                                </div>
                        </div>

                        <div class="row">
                                <div class="col-md-6">
                            <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>   
                                </div>
                                </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>   
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text ="Male" Value="Male" />
                                        <asp:ListItem Text ="Female" Value="Female" />
                                        </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>User Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" Enabled="False" runat="server">
                                        <asp:ListItem Text ="Landlord" Value="Landlord" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                                </div>
                            </div>
                        </div>
                   </div>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->

					<!-- ============================================================== -->
	               <!-- end content  -->
	               <!-- ============================================================== -->
	                 </div>
	             </div>

</asp:Content>