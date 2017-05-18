<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProducts.aspx.cs" Inherits="MyShop.shop.ListProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ListProducts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Repeater runat="server" ID="repeater_listproducts" OnItemCommand="repeater_listproducts_ItemCommand">
            <ItemTemplate>
                <div class="col-md-3 col-sm-6">
                    <span class="thumbnail">
                        <img src='$<%#Eval("Url") %>' onerror="OnErrorImg(this);">
                        <h4><%#Eval("Title") %></h4>
                        <div class="ratings">
                            <%#GetStars(Eval("Stars")) %>
                        </div>
                        <p><%#Eval("Description") %></p>
                        <hr class="line">
                        <div class="row">
                            <div class="col-md-6 col-sm-6">
                                <p class="price">$<%#Eval("Price") %></p>
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <asp:Button ID="button_addcart" runat="server" Text="Add Cart" CssClass="btn btn-primary right" CommandName="Save" UseSubmitBehavior="false" CommandArgument='<%# Eval("IdProduct") + "|" + Eval("Title") + "|" + Eval("Price") + "|" + Eval("Url") %>' />
                            </div>
                        </div>
                    </span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
