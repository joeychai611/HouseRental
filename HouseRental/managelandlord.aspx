<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="managelandlord.aspx.cs" Inherits="HouseRental.managelandlord" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
     <!-- ============================================================== -->
	    <!-- wrapper  -->
	    <!-- ============================================================== -->
	    <div class="dashboard-wrapper">
	        <div class="dashboard-influence">
	            <div class="container-fluid dashboard-content">
        <!-- ============================================================== -->    
            <!-- ============================================================== -->
	                <!-- pageheader  -->
	                <!-- ============================================================== -->
	                <div class="row">
	                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
	                        <div class="page-header">
	                            <h3 class="mb-2">Manage Landlord</h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Manage Landlord</li>
	                                    </ol>
	                                </nav>
	                            </div>
	                        </div>
	                    </div>
	                </div>
	                <!-- ============================================================== -->
	                <!-- end pageheader  -->
	                <!-- ============================================================== -->
			<div class="card">
               <div class="card-body">
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [name], [email], [contactnum], [accountstatus] FROM [people] WHERE ([usertype] = @usertype)" DeleteCommand="DELETE FROM [people] WHERE [ID] = @ID" InsertCommand="INSERT INTO [people] ([name], [email], [contactnum], [accountstatus]) VALUES (@name, @email, @contactnum, @accountstatus)" UpdateCommand="UPDATE [people] SET [name] = @name, [email] = @email, [contactnum] = @contactnum, [accountstatus] = @accountstatus WHERE [ID] = @ID">
                          <DeleteParameters>
                              <asp:Parameter Name="ID" Type="Int32" />
                          </DeleteParameters>
                          <SelectParameters>
                              <asp:Parameter DefaultValue="landlord" Name="usertype" Type="String" />
                          </SelectParameters>
                          <UpdateParameters>
                              <asp:Parameter Name="name" Type="String" />
                              <asp:Parameter Name="email" Type="String" />
                              <asp:Parameter Name="contactnum" Type="String" />
                              <asp:Parameter Name="accountstatus" Type="String" />
                              <asp:Parameter Name="ID" Type="Int32" />
                          </UpdateParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
								<asp:BoundField DataField="contactnum" HeaderText="Contact" SortExpression="contactnum" /> 
								<asp:BoundField DataField="accountstatus" HeaderText="Status" SortExpression="accountstatus" />
                                <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="<img src='images/EditButton.png'>" ShowDeleteButton="True" DeleteText="<img src='images/CancelButton.png'>"  >
                                </asp:CommandField>


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
                     </div>
                      <div>  
                <asp:Label ID="lblresult" runat="server"></asp:Label>  
                        
            </div>
                  </div>
               </div>
            </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                          <asp:Panel ID="Panel1" runat="server" Style="display:none">

                     <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header text-center">
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>   
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

                                 <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                            <div class="form-group">
                                <label>Status</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" CssClass="badge badge-pill badge-info">
                                        <asp:ListItem Text ="Active" Value="Active" Class="badge badge-pill badge-success" />
                                        <asp:ListItem Text ="Pending" Value="Pending" Class="badge badge-pill badge-warning"/>
                                        <asp:ListItem Text ="Deactive" Value="Deactive" Class="badge badge-pill badge-danger"/>
                                        </asp:DropDownList>
                                </div>
                           </div>
                            <br />
                        </center>
                     </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" ID="Button2" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Save" OnClick="Save" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
                    </asp:Panel>
                    <asp:LinkButton ID="LinkButton1" Style="display:none" runat="server">LinkButton</asp:LinkButton>
                    <asp:Label ID="Label3" Style="display:none" runat="server" Text="Label"></asp:Label>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button2" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
					<!-- ============================================================== -->
	               <!-- end content  -->
	               <!-- ============================================================== -->
	                 </div>
	             </div>
</asp:Content>