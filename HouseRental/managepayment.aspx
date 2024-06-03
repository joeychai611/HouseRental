<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeBehind="managepayment.aspx.cs" Inherits="HouseRental.managepayment" %>
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
<!-- pageheader  -->
<!-- ============================================================== -->
	                <div class="row">
	                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
	                        <div class="page-header">
	                            <h3 class="mb-2">Manage Payment</h3>
	                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
	                            <div class="page-breadcrumb">
	                                <nav aria-label="breadcrumb">
	                                    <ol class="breadcrumb">
	                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                        <li class="breadcrumb-item active" aria-current="page">Manage Payment</li>
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
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [details], [total], [date], [status], [studentID] FROM [payment]" DeleteCommand="DELETE FROM [payment] WHERE [ID] = @ID" InsertCommand="INSERT INTO [payment] ([details], [total], [date], [status], [studentID]) VALUES (@details, @total, @date, @status, @studentID)" UpdateCommand="UPDATE [payment] SET [details] = @details, [total] = @total, [date] = @date, [status] = @status, [studentID] = @studentID WHERE [ID] = @ID">
                           <DeleteParameters>
                               <asp:Parameter Name="ID" Type="Int32" />
                           </DeleteParameters>
                           <InsertParameters>
                               <asp:Parameter Name="details" Type="String" />
                               <asp:Parameter Name="total" Type="String" />
                               <asp:Parameter Name="date" Type="String" />
                               <asp:Parameter Name="status" Type="String" />
                               <asp:Parameter Name="studentID" Type="String" />
                           </InsertParameters>
                           <UpdateParameters>
                               <asp:Parameter Name="details" Type="String" />
                               <asp:Parameter Name="total" Type="String" />
                               <asp:Parameter Name="date" Type="String" />
                               <asp:Parameter Name="status" Type="String" />
                               <asp:Parameter Name="studentID" Type="String" />
                               <asp:Parameter Name="ID" Type="Int32" />
                           </UpdateParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="false"/>
                                <asp:BoundField DataField="details" HeaderText="Details" SortExpression="details" />
                                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
								<asp:BoundField DataField="status" HeaderText="Status" SortExpression="status"/> 
                                <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="<img src='images/EditButton.png'>"  >
                                </asp:CommandField>
                                 <asp:TemplateField HeaderText="Receipt">
                                    <ItemTemplate>
                                         <asp:Button Text="View" OnClick="Confirm_View" runat="server" CssClass="btn btn-outline-primary btn-sm" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="details" runat="server" Text='<%# Eval("details") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="150" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="studentID" runat="server" Text='<%# Eval("studentID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="studentID" HeaderText="studentID" SortExpression="studentID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"  />
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
<!-- start show payment  -->
<!-- ============================================================== -->
                    <div class="modal fade" id="myCModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <div class="container">
                                    <div style ="text-align:center;color:green;">
                                        <asp:Label ID="label15" runat="server" Cssclass="fa-solid fa-circle-check fa-2xl" style="color: #1ac793;" />
                                       <br />
                                       <h4><asp:Label ID="label14" runat="server" Text="Payment Successful" style="color: green;" /></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <div style ="text-align:center;color:red;">
                                        <asp:Label ID="label7" runat="server" Text="Your payment is still outstanding." />
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <asp:Label ID="Label8" Text="Payment Date" runat="server" />
                                        </div>
                                        <div class="col-5">
                                            <asp:Label ID="Label1" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <asp:Label ID="Label9" Text="Detail" runat="server" />
                                        </div>
                                        <div class="col-5">
                                            <asp:Label ID="Label2" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <asp:Label ID="Label10" Text="Payment Type" runat="server" />
                                        </div>
                                        <div class="col-5"> 
                                            <asp:Label ID="Label4" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <asp:Label ID="Label11" Text="Amount Paid" runat="server" />
                                        </div>
                                        <div class="col-5"> 
                                            <asp:Label ID="Label12" Text="RM" runat="server" />
                                            <asp:Label ID="Label5" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <asp:Label ID="Label13" Text="Transaction ID" runat="server" />
                                        </div>
                                        <div class="col-5">
                                            <asp:Label ID="Label6" runat="server" />
                                        </div>
                                    </div>

                                            <asp:Label ID="Label16" runat="server" Visible="false" />

                                </div>
                            </div> 
                            <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end show payment  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start edit contract  -->
<!-- ============================================================== -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                          <asp:Panel ID="Panel1" runat="server" Style="display:none">
                              <div class="modal-dialog modal-dialog-scrollable">
                    <div class="modal-content">
                        <div class="modal-header text-center">
                            <h4 class="modal-title w-100">Make Payment</h4>
                        </div>
                        <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" ReadOnly="true" ></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Details</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" ReadOnly="true" ></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" TextMode="Date" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <label>Price (RM)</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" Text="RM" runat="server" ReadOnly="true" ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <label>Late Fee (RM)</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" Text="RM" runat="server" ReadOnly="true" ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <label>Total (RM)</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" Text="RM" runat="server" ReadOnly="true" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" Visible="false" ></asp:TextBox>
	                            </div>
                            </div> 
                        <div class="modal-footer">
                            <button type="button" ID="Button3" class="btn btn-default" data-dismiss="modal">Close</button>                   
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                    </asp:Panel>
                    <asp:LinkButton ID="LinkButton1" Style="display:none" runat="server">LinkButton</asp:LinkButton>
                    <asp:Label ID="Label3" Style="display:none" runat="server" Text="Label"></asp:Label>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
<!-- ============================================================== -->
<!-- end edit payment -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- end content  -->
<!-- ============================================================== -->
	                 </div>
	             </div>
    <script type='text/javascript'>
    function openCModal() {
        $('[id*=myCModal]').modal('show');
    }
    </script>
<style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
</asp:Content>
