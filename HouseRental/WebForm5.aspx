<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="HouseRental.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
     <!-- ============================================================== -->
	    <!-- wrapper  -->
	    <!-- ============================================================== -->
	    <div class="dashboard-wrapper">
	        <div class="dashboard-influence">
	            <div class="container-fluid dashboard-content">
        <!-- ============================================================== -->
        <div class="modal fade" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header text-center">
                            <center>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button></center>
                            <h4 class="modal-title w-100">Student</h4>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>   
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
                                        <asp:ListItem Text ="Student" Value="Student" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>  
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Re-confirm Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>  
                                </div>
                            </div>
                        </div>
                   </div>
              
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Save" OnClick="Button2_Click" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->  

    <button type="button"  id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal"> Add New Student</button>                      
                    <!-- ============================================================== -->
			<div class="card">
               <div class="card-body">
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [name], [email], [contactnum], [dateofbirth], [gender], [accountstatus] FROM [people] WHERE ([usertype] = @usertype)">
                          <SelectParameters>
                              <asp:Parameter DefaultValue="student" Name="usertype" Type="String" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                <asp:BoundField DataField="contactnum" HeaderText="Contact" SortExpression="contactnum" />
								<asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                                <asp:BoundField DataField="accountstatus" HeaderText="Status" SortExpression="accountstatus" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
					<!-- ============================================================== -->
	               <!-- end content  -->
	               <!-- ============================================================== -->
	                 </div>
	             </div>
			</div>
</asp:Content>