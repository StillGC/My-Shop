<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="MyShop.shop.MyProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading clearfix">
            <b>My Products</b>
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-default btn-sm" data-toggle="modal" data-target="#myModal">
                    <i class="fa fa-plus" aria-hidden="true"></i>
                    <span>Add Product</span>
                </button>
            </div>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gridview_listproducts" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="id_Product" OnRowDeleting="gridview_listproducts_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id_Product" HeaderText="id_Product" InsertVisible="False" ReadOnly="True" SortExpression="id_Product" Visible="false" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="Rating" SortExpression="Stars">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Stars") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%#GetStars(Eval("Stars")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-primary" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Create Product</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="input_title" class="col-lg-2 control-label">Title</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" runat="server" id="input_title" placeholder="Title" required>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textarea_decription" class="col-lg-2 control-label">Description</label>
                        <div class="col-lg-10">
                            <textarea class="form-control" runat="server" rows="3" id="textarea_decription" placeholder="Description" required></textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_url" class="col-lg-2 control-label">Url</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" runat="server" id="input_url" placeholder="http://example.com" required>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_prince" class="col-lg-2 control-label">Price</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" runat="server" id="input_prince" placeholder="Price" pattern="^\d*$" title="example: 100" required>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_start" class="col-lg-2 control-label">Start</label>
                        <div class="col-lg-10">
                            <input type="text" class="form-control" runat="server" id="input_start" placeholder="Start" pattern="[0-5]" title="example: 0,1,2,3,4,5" maxlength="1" required>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" Text="Save" ID="button_save" CssClass="btn btn-primary" OnClick="button_save_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
