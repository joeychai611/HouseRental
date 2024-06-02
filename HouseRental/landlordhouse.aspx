<%@ Page Title="" Language="C#" MasterPageFile="~/landlord.master" AutoEventWireup="true" CodeBehind="landlordhouse.aspx.cs" Inherits="HouseRental.landlordhouse" %>
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
                            <h3 class="mb-2">Manage House</h3>
                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
                            <div class="page-breadcrumb">
                                <nav aria-label="breadcrumb">
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
	                                    <li class="breadcrumb-item active" aria-current="page">Manage House</li>
	                                </ol>
	                            </nav>
	                        </div>
                        </div>
                    </div>
                </div>
                <button type="button"  id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">Add House</button>
<!-- ============================================================== -->
<!-- end pageheader  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start gridview  -->
<!-- ============================================================== -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [hname], [housetype], [rentprice], [status] FROM [room] WHERE ([userID] = @userID)" DeleteCommand="DELETE FROM [room] WHERE [ID] = @ID" InsertCommand="INSERT INTO [room] ([hname], [housetype], [rentprice], [status]) VALUES (@hname, @housetype, @rentprice, @status)" UpdateCommand="UPDATE [room] SET [hname] = @hname, [housetype] = @housetype, [rentprice] = @rentprice, [status] = @status WHERE [ID] = @ID">
                          <DeleteParameters>
                              <asp:Parameter Name="ID" Type="Int32" />
                          </DeleteParameters>
                          <InsertParameters>
                              <asp:Parameter Name="hname" Type="String" />
                              <asp:Parameter Name="housetype" Type="String" />
                              <asp:Parameter Name="rentprice" Type="String" />
                              <asp:Parameter Name="status" Type="String" />
                          </InsertParameters>
                          <SelectParameters>
                              <asp:SessionParameter Name="userID" SessionField="ID" Type="Int32" />
                          </SelectParameters>
                          <UpdateParameters>
                              <asp:Parameter Name="hname" Type="String" />
                              <asp:Parameter Name="housetype" Type="String" />
                              <asp:Parameter Name="rentprice" Type="String" />
                              <asp:Parameter Name="status" Type="String" />
                              <asp:Parameter Name="ID" Type="Int32" />
                          </UpdateParameters>
                      </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                             <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="false" />
                                <asp:BoundField DataField="hname" HeaderText="Name" SortExpression="hname" />
                                <asp:BoundField DataField="housetype" HeaderText="House Type" SortExpression="housetype" />
								<asp:BoundField DataField="rentprice" HeaderText="Rent Price" SortExpression="rentprice" DataFormatString="RM{0}"/> 
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
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
<!-- ============================================================== -->
<!-- end gridview  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start add house  -->
<!-- ============================================================== -->
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-dialog-scrollable"> 
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">House</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>* House Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>House Type</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                                    <asp:ListItem Text ="Apartment" Value="Apartment" />
                                                    <asp:ListItem Text ="Condominium" Value="Condominium" />
                                                    <asp:ListItem Text ="Terrace House" Value="Terrace House" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>* Address</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>* Postcode</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>* City</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Description</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Facilities</label>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-5">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Air-Conditioning" /><br />
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Washing Machine" /><br />
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="Water Dispenser" />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text="Fan" /><br />
                                                        <asp:CheckBox ID="CheckBox5" runat="server" Text="Dryer" /><br />
                                                        <asp:CheckBox ID="CheckBox6" runat="server" Text="Wifi" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:CheckBox ID="CheckBox7" runat="server" Text="Refrigerator" /> <br /> 
                                                        <asp:CheckBox ID="CheckBox8" runat="server" Text="Cooking" /><br />
                                                        <asp:CheckBox ID="CheckBox9" runat="server" Text="Water Heater" />
                                                    </div>
                                                </div> 
                                            </div>
                                        </div>
                                    </div>
 
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>* Monthly Rent Price</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" Text="RM" TextMode="Number"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>* Duration</label>
                                            <div class="form-group">
                                                <asp:CheckBox ID="CheckBox10" runat="server" Text="6 months" /><br />
                                                <asp:CheckBox ID="CheckBox11" runat="server" Text="1 year" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-8 mx-auto">
                                            <center>
                                               <asp:Label ID="Label1" Text="Image" runat="server"></asp:Label>
                                                <asp:FileUpload ID="fuUpload" AllowMultiple="true" runat="server" />
                                                 <asp:Label ID="Label2" runat="server" />  
                                                <asp:Label ID="Label8" Text="Only JPG, JPEG and PNG files" runat="server"></asp:Label>
                                                <br />
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div> 
                            <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
<!-- ============================================================== -->
<!-- end add house  -->
<!-- ============================================================== -->
<!-- ============================================================== -->
<!-- start edit house  -->
<!-- ============================================================== -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                          <asp:Panel ID="Panel1" runat="server" Style="display:none">
                              <div class="modal-dialog modal-dialog-scrollable">
                    <div class="modal-content">
                        <div class="modal-header text-center">
                            <h4 class="modal-title w-100">House</h4>
                        </div>
                        <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>* House Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>House Type</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                                    <asp:ListItem Text ="Apartment" Value="Apartment" />
                                                    <asp:ListItem Text ="Condominium" Value="Condominium" />
                                                    <asp:ListItem Text ="Terrace House" Value="Terrace House" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Landlord Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" ReadOnly="True"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Email</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" ReadOnly="True"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Address</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Postcode</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="Number"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>City</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Description</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Facilities</label>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-5">
                                                        <asp:CheckBox ID="CheckBox12" runat="server" Text="Air-Conditioning" /><br />
                                                        <asp:CheckBox ID="CheckBox13" runat="server" Text="Washing Machine" /><br />
                                                        <asp:CheckBox ID="CheckBox14" runat="server" Text="Water Dispenser" />
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:CheckBox ID="CheckBox15" runat="server" Text="Fan" /><br />
                                                        <asp:CheckBox ID="CheckBox16" runat="server" Text="Dryer" /><br />
                                                        <asp:CheckBox ID="CheckBox17" runat="server" Text="Wifi" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:CheckBox ID="CheckBox18" runat="server" Text="Refrigerator" /> <br /> 
                                                        <asp:CheckBox ID="CheckBox19" runat="server" Text="Cooking" /><br />
                                                        <asp:CheckBox ID="CheckBox20" runat="server" Text="Water Heater" />
                                                    </div>
                                                </div> 
                                            </div>
                                        </div>
                                    </div>
 
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Monthly Rent Price</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" Text="RM" TextMode="Number"></asp:TextBox> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label>Duration</label>
                                            <div class="form-group">
                                                <asp:CheckBox ID="CheckBox21" runat="server" Text="6 months" /><br />
                                                <asp:CheckBox ID="CheckBox22" runat="server" Text="1 year" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                            <div class="col-8 mx-auto">
                                            <center>
                                                <asp:Label ID="Label4" Text="Image" runat="server"></asp:Label>
                                                <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                                 <asp:Label ID="Label5" runat="server" />  
                                                <asp:Label ID="Label6" Text="Only JPG, JPEG and PNG files" runat="server"></asp:Label>
                                                <br />
                                            </center>
                                        </div>
                                        <div class="col-8 mx-auto">
                                            <center><br />
                                                <asp:Label ID="Label7" Text="Images" runat="server"></asp:Label>
                                                <div class="form-group">
                                                    <asp:ImageButton ID="imgPhoto" OnClientClick ="popimage(this);return false" style="max-height:100%;max-width:80%; border: 1px solid #D3D3D3;" runat="server" />
                                                    <div id="dialog" style="display: none"></div>
                                                    <asp:Label ID="Span1" runat="server"></asp:Label>
                                                     <div id="imagepop" style="display:none;text-align:center;height:80%">
                                                     <asp:Image ID="Image1" runat="server" ClientIDMode="Static" style="height:96%"/>
                                            </div>
                                            </center>
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
                 </div>
                    </asp:Panel>
                    <asp:LinkButton ID="LinkButton1" Style="display:none" runat="server">LinkButton</asp:LinkButton>
                    <asp:Label ID="Label3" Style="display:none" runat="server" Text="Label"></asp:Label>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
					<!-- ============================================================== -->
	               <!-- end content  -->
	               <!-- ============================================================== -->
            </div>
        </div>
    </div>
</asp:Content>
