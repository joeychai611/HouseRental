<%@ Page Title="" Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeBehind="studentAppointment.aspx.cs" Inherits="HouseRental.studentAppointment" %>
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
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [appointment_date], [slot], [status] FROM [appointment] WHERE ([studentID] = @studentID)">
                          <SelectParameters>
                              <asp:SessionParameter Name="studentID" SessionField="ID" Type="Int32" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="false"/>
                                <asp:BoundField DataField="appointment_date" HeaderText="Date" SortExpression="appointment_date" />
                                <asp:BoundField DataField="slot" HeaderText="Slot" SortExpression="slot" />
                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="date" runat="server" Text='<%# Eval("appointment_date") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Slot" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="slot" runat="server" Text='<%# Eval("slot") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="<img src='images/EditButton.png'>"  >
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Cancel">
                                    <ItemTemplate>
                                         <asp:Button Text="Cancel" OnClick="Cancel_Click" runat="server" CssClass="btn btn-outline-danger btn-sm" CommandName="Cancel" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Confirmation">
                                    <ItemTemplate>
                                         <asp:Button Text="Confirm" OnClick="Confirm_Click" runat="server" CssClass="btn btn-outline-primary btn-sm" CommandName="Confirmation" CommandArgument="<%# Container.DataItemIndex %>" />
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
<!-- start cancel appointment  -->
<!-- ============================================================== -->
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">Cancel Appointment</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <div style ="text-align:center;color:red;">
                                        <asp:Label ID="label2" runat="server" Text="You already cancelled this appointment." />
                                        <asp:Label ID="label7" runat="server" Text="Rental confirmed. No need to cancel appointment" />
                                            </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" TextMode="Date" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Time</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList2" Enabled="false" runat="server">
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
                                            <asp:Label ID="label8" runat="server" Text="*Cancellation Reason" />
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox11" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div> 
                            <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Confirm Cancel" OnClick="Cancel"/>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end cancel appointment  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start confirm appointment  -->
<!-- ============================================================== -->
                <div class="modal fade" id="myCModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">Rental Confirmation</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <div style ="text-align:center;color:red;">
                                        <asp:Label ID="label1" runat="server" Text="Once you click the confirm button, the decision cannot be reversed." />
                                        <asp:Label ID="label4" runat="server" Text="You have already completed the rental confirmation." />
                                        <asp:Label ID="label5" runat="server" Text="You missed this appointment before, cannot proceed to the rental confirmation." />
                                        <asp:Label ID="label6" runat="server" Text="Your status is pending. Please wait for verification from the landlord before proceeding with the rental confirmation." />
                                        <asp:Label ID="label9" runat="server" Text="Your status is upcoming. Please attend the appointment before proceeding with the rental confirmation." />
                                    </div>
                                </div>
                            </div> 
                            <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Confirm Rental" OnClick="Confirm"/>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end confirm appointment  -->
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
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="Date" ReadOnly="True" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Time</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList1" Enabled="false" runat="server">
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
                                            <label>Landlord</label>
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

                                        </div>
                            </div> 
                        <div class="modal-footer">
                            <button type="button" ID="Button3" class="btn btn-default" data-dismiss="modal">Close</button>
                            
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
<script type='text/javascript'>
    function openModal() {
        $('[id*=myModal]').modal('show');
    }
        </script>
<script type='text/javascript'>
    function openCModal() {
        $('[id*=myCModal]').modal('show');
    }
</script>
</asp:Content>