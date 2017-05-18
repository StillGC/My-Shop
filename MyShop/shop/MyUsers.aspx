<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyUsers.aspx.cs" Inherits="MyShop.shop.MyUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading clearfix">
            <b>My Users</b>
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-default btn-sm" data-toggle="modal" data-target="#myModal">
                    <i class="fa fa-plus" aria-hidden="true"></i>
                    <span>Add User</span>
                </button>
            </div>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gridview_listusers" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowDeleting="gridview_listusers_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="UserName" Text='<%# Eval("UserName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
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
                    <h4 class="modal-title" id="myModalLabel">Create User</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="input_username" class="col-lg-2 control-label">Username</label>
                        <div class="col-lg-10">
                            <input id="input_username" type="text" runat="server" placeholder="Username" cssclass="form-control" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_password" class="col-lg-2 control-label">Password</label>
                        <div class="col-lg-10">
                            <input id="input_password" type="password" runat="server" placeholder="Password" cssclass="form-control" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_email" class="col-lg-2 control-label">Email</label>
                        <div class="col-lg-10">
                            <input id="input_email" type="text" runat="server" placeholder="Email" cssclass="form-control" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="input_email" class="col-lg-2 control-label">Role</label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="list_role" runat="server" CssClass="form-control" required></asp:DropDownList>
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
