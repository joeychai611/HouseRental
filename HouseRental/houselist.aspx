<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="houselist.aspx.cs" Inherits="HouseRental.houselist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="margin-top: 50px;">
        <select class="selectpicker" multiple data-width="300px" data-live-search="true">
            <optgroup label="housetype" data-max-options="1">
                <%foreach (var item in HouseType)
                    {%>
                <option data-tokens="<%=item %>"><%=item %></option>
                <%} %>
            </optgroup>
            <optgroup label="rentprice" data-max-options="1">
                <%foreach (var item in RentPriceList)
                    {%>
                <option data-tokens="<%=item %>"><%=item %></option>
                <%} %>
            </optgroup>
            <optgroup label="city" data-max-options="1">
                <%foreach (var item in CityList)
                    {%>
                <option data-tokens="<%=item %>"><%=item %></option>
                <%} %>
            </optgroup>
        </select>

        <asp:TextBox ID="customSearchTextBox" runat="server"></asp:TextBox>
        <button type="button" id="searchButton" class="btn btn-primary">Search</button>
        <script>
            $(function () {
                function getUrlParamsArray() {
                    var params = [];
                    window.location.search.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (str, key, value) {
                        if (key !== "keyword")
                            params.push(decodeURIComponent(value));
                        else
                            $('#<%=customSearchTextBox.ClientID%>').val(decodeURIComponent(value));
                    });
                    return params;
                }
                $('.selectpicker').change(function () {
                    var selections = [];
                    var selectedOptions = $(this).find('option:selected');
                    selectedOptions.each(function () {
                        var optgroupLabel = $(this).parent().attr('label');
                        var optionValue = $(this).val();
                        selections.push({ optgroup: optgroupLabel, value: optionValue });
                    });

                    $(this).data('selections', selections);
                });

                $(".selectpicker").selectpicker("val", getUrlParamsArray()).change();
                $('.selectpicker').selectpicker('refresh');

                $('#searchButton').on('click', function (e) {
                    e.preventDefault();

                    var selections = $('.selectpicker').data('selections') || [];
                    var queryParams = "?";
                    for (var i = 0; i < selections.length; i++) {
                        queryParams += encodeURIComponent(selections[i].optgroup) + "=" + encodeURIComponent(selections[i].value);
                        if (i != selections.length - 1) {
                            queryParams += "&";
                        }
                    }

                    window.location.href = "houselist.aspx" + queryParams + "&keyword=" + $('#<%=customSearchTextBox.ClientID%>').val();
                });
            });
        </script>
    </center>
    <br />
    <asp:Repeater ID="rpQuestions" runat="server">
        <ItemTemplate>
            <div style="border: 1px solid #D3D3D3; background-color: #FFFFFF; margin-left: 20%; margin-right: 20%;">
                <div class="row">
                    <div class="col-md-4">
                        <tr>
                            <td>
                                <asp:Image ID="image" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[]) Eval("image"))%>' runat="server" Style="max-height: 100%; max-width: 80%; border: 1px solid #D3D3D3;" />
                            </td>
                    </div>
                    <div class="col-md-8">
                        <td>
                            <b>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("hname") %>'>
                                </asp:Label></b><br />
                        </td>

                        <td>
                            <b>
                                <asp:Label ID="lblhousetype" runat="server" class="badge badge-pill badge-info" Text='<%#Eval("housetype") %>'>
                                </asp:Label></b><br />
                        </td>


                        <td>
                            <i class="fa-solid fa-location-dot"></i>
                            <asp:Label ID="Label2" class="text-primary" runat="server" Text='<%#Eval("city") %>'>
                            </asp:Label><br />
                        </td>

                        <td>
                            <b>RM
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("rentprice") %>'>
                                </asp:Label>
                                /month</b><br />

                        </td>

                        <td>
                            <i class="fa-solid fa-square-plus"></i>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("accommodation") %>'>
                            </asp:Label><br />
                        </td>

                        <td>
                            <br />
                            <asp:Button class="btn btn-primary rounded" Text="More Details" ID="Button1" runat="server" PostBackUrl='<%# string.Format("~/house.aspx?ID={0}&hname={1}&housetype={2}&address={3}&postcode={4}&city={5}&description={6}&accommodation={7}&rentprice={8}&duration={9}&status={10}&image={11}", HttpUtility.UrlEncode(Eval("ID").ToString()),HttpUtility.UrlEncode(Eval("hname").ToString()),HttpUtility.UrlEncode(Eval("housetype").ToString()),HttpUtility.UrlEncode(Eval("address").ToString()),HttpUtility.UrlEncode(Eval("postcode").ToString()),HttpUtility.UrlEncode(Eval("city").ToString()),HttpUtility.UrlEncode(Eval("description").ToString()),HttpUtility.UrlEncode(Eval("accommodation").ToString()),HttpUtility.UrlEncode(Eval("rentprice").ToString()),HttpUtility.UrlEncode(Eval("duration").ToString()),HttpUtility.UrlEncode(Eval("status").ToString()),HttpUtility.UrlEncode(Eval("image").ToString())) %>'></asp:Button>
                        </td>
                        </tr>
                    </div>
                </div>
            </div>
            <br />
        </ItemTemplate>

    </asp:Repeater>
    <!-- ============================================================== -->
    <!-- end repeater  -->
    <!-- ============================================================== -->
    <div class="col-lg-12">
        <div class="room-pagination">
            <asp:LinkButton ID="LinkButton1" class="fa-solid fa-chevron-left" OnClick="LinkButton1_Click" runat="server"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" class="fa-solid fa-chevron-right" OnClick="LinkButton2_Click" runat="server"></asp:LinkButton>
        </div>
    </div>
    <br />
</asp:Content>
