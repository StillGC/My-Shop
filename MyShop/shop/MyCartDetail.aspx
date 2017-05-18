<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCartDetail.aspx.cs" Inherits="MyShop.shop.MyCartDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <table id="cart" class="table table-hover table-condensed">
            <thead>
                <tr>
                    <th style="width: 50%">Product</th>
                    <th style="width: 10%">Price</th>
                    <th style="width: 8%" class="text-center">Quantity</th>
                    <th style="width: 22%" class="text-center">Subtotal</th>
                    <th style="width: 10%"></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="repeater_mycart" OnItemCommand="repeater_mycart_ItemCommand1">
                    <ItemTemplate>
                        <tr>
                            <td data-th="Product">
                                <div class="row">
                                    <div class="col-sm-2 hidden-xs">
                                        <img src='<%#Eval("Url") %>' alt="..." class="img-responsive" onerror="OnErrorImg(this);" />
                                    </div>
                                    <div class="col-sm-10">
                                        <h4 class="nomargin"><%#Eval("Title") %></h4>
                                    </div>
                                </div>
                            </td>
                            <td data-th="Price">$<%#Eval("Price") %></td>
                            <td data-th="Quantity" class="text-center"><%#Eval("Quantity") %></td>
                            <td data-th="Subtotal" class="text-center">$<%#Eval("SubTotal")%></td>
                            <td class="actions" data-th="">
                                <asp:Button ID="button_addcart" runat="server" Text="DELETE" CssClass="btn btn-danger btn-sm" CommandName="Delete" UseSubmitBehavior="false" CommandArgument='<%# Eval("IdProduct") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td colspan="2"></td>
                    <td class="text-center">
                        <strong id="strong_total" runat="server"></strong>
                    </td>
                    <td>
                        <asp:Button ID="button_checkout" runat="server" Text="Checkout" CssClass="btn btn-success btn-block" OnClick="button_checkout_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>

</asp:Content>
