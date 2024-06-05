<%@ Page Title="" Language="C#" MasterPageFile="~/landlord.master" AutoEventWireup="true" CodeBehind="landlordContract.aspx.cs" Inherits="HouseRental.landlordContract" %>

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
                            <h3 class="mb-2">Manage Contract</h3>
                            <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
                            <div class="page-breadcrumb">
                                <nav aria-label="breadcrumb">
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item"><a href="home.aspx" class="breadcrumb-link">Home</a></li>
                                        <li class="breadcrumb-item active" aria-current="page">Manage Contract</li>
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
                <!-- start generate contract  -->
                <!-- ============================================================== -->
                <button type="button" id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">Generate Contract</button>
                <!-- ============================================================== -->
                <!-- end generate contract  -->
                <!-- ============================================================== -->
                <!-- ============================================================== -->
                <!-- start gridview  -->
                <!-- ============================================================== -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:houserentalDBConnectionString %>" SelectCommand="SELECT [ID], [student_name], [house_name], [date] FROM [contract] WHERE ([landlordID] = @landlordID)" DeleteCommand="DELETE FROM [contract] WHERE [ID] = @ID" InsertCommand="INSERT INTO [contract] ([student_name], [house_name], [date]) VALUES (@student_name, @house_name, @date)" UpdateCommand="UPDATE [contract] SET [student_name] = @student_name, [house_name] = @house_name, [date] = @date WHERE [ID] = @ID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="student_name" Type="String" />
                                    <asp:Parameter Name="house_name" Type="String" />
                                    <asp:Parameter Name="date" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="landlordID" SessionField="ID" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="student_name" Type="String" />
                                    <asp:Parameter Name="house_name" Type="String" />
                                    <asp:Parameter Name="date" Type="String" />
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="false" />
                                        <asp:BoundField DataField="student_name" HeaderText="Student" SortExpression="student_name" />
                                        <asp:BoundField DataField="house_name" HeaderText="House" SortExpression="house_name" />
                                        <asp:BoundField DataField="date" HeaderText="Effective Date" SortExpression="date" />
                                        <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="<img src='images/EditButton.png'>" ShowDeleteButton="True" DeleteText="<img src='images/CancelButton.png'>"></asp:CommandField>
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
                <!-- start add contract  -->
                <!-- ============================================================== -->
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-dialog-scrollable">
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">Generate Contract</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Student Name</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>House Name</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Effective Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Duration</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                                    <asp:ListItem Text="6 months" Value="6 months" />
                                                    <asp:ListItem Text="1 year" Value="1 year" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Deposit (RM)</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
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
                <!-- end add contract  -->
                <!-- ============================================================== -->
                <!-- ============================================================== -->
                <!-- start edit contract  -->
                <!-- ============================================================== -->
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Panel ID="Panel1" runat="server" Style="display: none">
                    <div class="modal-dialog modal-dialog-scrollable">
                        <div class="modal-content">
                            <div class="modal-header text-center">
                                <h4 class="modal-title w-100">Edit Contract</h4>
                            </div>
                            <div class="modal-body">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Student Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>House Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Effective Date</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <label>Duration</label>
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList4" runat="server">
                                                    <asp:ListItem Text="6 months" Value="6 months" />
                                                    <asp:ListItem Text="1 year" Value="1 year" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <label>Deposit (RM)</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" Text="RM" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:Button Text="Generate Contract" class="btn btn-primary" OnClick="GenerateInvoicePDF" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" id="Button3" class="btn btn-default" data-dismiss="modal">Close</button>
                                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Save" OnClick="Save" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton1" Style="display: none" runat="server">LinkButton</asp:LinkButton>
                <asp:Label ID="Label3" Style="display: none" runat="server" Text="Label"></asp:Label>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="LinkButton1" PopupControlID="Panel1" CancelControlID="Button3" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
                <!-- ============================================================== -->
                <!-- end content  -->
                <!-- ============================================================== -->
            </div>
        </div>
    </div>
</asp:Content>
