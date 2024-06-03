<%@ Page Title="" Language="C#" MasterPageFile="~/landlord.master" AutoEventWireup="true" CodeBehind="landlordAppointment.aspx.cs" Inherits="HouseRental.landlordAppointment" %>
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
                            <h3 class="mb-2">Manage Appointment</h3>
                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
                            <div class="page-breadcrumb">
                                <nav aria-label="breadcrumb">
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                    <li class="breadcrumb-item active" aria-current="page">Manage Appointment</li>
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
<!-- start gridview  -->
<!-- ============================================================== -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [appointment_date], [slot], [status] FROM [appointment] WHERE ([landlordID] = @landlordID)">
                          <SelectParameters>
                              <asp:SessionParameter Name="landlordID" SessionField="ID" Type="Int32" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="false"/>
                                <asp:BoundField DataField="appointment_date" HeaderText="Date" SortExpression="appointment_date" />
                                <asp:BoundField DataField="slot" HeaderText="Slot" SortExpression="slot" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="<img src='images/EditButton.png'>"  >
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
<!-- ============================================================== -->
<!-- end gridview  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start edit appointment  -->
<!-- ============================================================== -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                          <asp:Panel ID="Panel1" runat="server" Style="display:none">
                              <div class="modal-dialog modal-dialog-scrollable">
                    <div class="modal-content">
                        <div class="modal-header text-center">
                            <h4 class="modal-title w-100">Appointment</h4>
                        </div>
                        <div class="modal-body">
                                <div class="container">

                                     <div class="row">
                                        <div class="col-md-6">
                                            <label>Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="Date" Enabled="False" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Time</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList1" Enabled="False" runat="server">
                                                    <asp:ListItem Text ="9.00AM - 10.00AM" Value="9.00AM - 10.00AM" />
                                                    <asp:ListItem Text ="10.00AM - 11.00AM" Value="10.00AM - 11.00AM" />
                                                    <asp:ListItem Text ="11.00AM - 12.00PM" Value="11.00AM - 12.00PM" />
                                                    <asp:ListItem Text ="2.00PM - 3.00PM" Value="2.00PM - 3.00PM" />
                                                    <asp:ListItem Text ="3.00PM - 4.00PM" Value="3.00PM - 4.00PM" />
                                                    <asp:ListItem Text ="4.00PM - 5.00PM" Value="4.00PM - 5.00PM" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Student</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Contact Number</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>House Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" ReadOnly="True" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Address</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" ReadOnly="True" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="label2" runat="server" Text="Verify" />
                                        <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" CssClass="badge badge-pill badge-info" >
                                        <asp:ListItem Text ="Approve" Value="Upcoming" Class="badge badge-pill badge-primary" />
                                        <asp:ListItem Text ="Completed" Value="Completed" Class="badge badge-pill badge-success" />
                                        <asp:ListItem Text ="Pending" Value="Pending" Class="badge badge-pill badge-warning"/>
                                        <asp:ListItem Text ="Cancel" Value="Cancelled" Class="badge badge-pill badge-danger"/>
                                        <asp:ListItem Text ="Absent" Value="Absent" Class="badge badge-pill badge-dark"/>
                                        <asp:ListItem Text ="Attended" Value="Attended" Class="badge badge-pill badge-info"/>
                                        </asp:DropDownList>
                                        </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Label ID="label1" runat="server" Text="Cancellation Reason" />
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" ReadOnly="True" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                        </div>
                            </div> 
                        <div class="modal-footer">
                            <button type="button" ID="Button3" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Save" OnClick="Save" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                 </asp:Panel>
                 </div>
                    
                    <asp:LinkButton ID="LinkButton1" Style="display:none" runat="server">LinkButton</asp:LinkButton>
                    <asp:Label ID="Label3" Style="display:none" runat="server" Text="Label"></asp:Label>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
            </div>
        </div>
</asp:Content>
