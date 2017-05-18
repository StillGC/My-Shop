<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="MyShop.shop.FileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <b>File Upload</b>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div class="col-lg-6">
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" Style="margin-bottom: 0px" accept=".csv" />
                </div>
                <div class="col-lg-6">
                    <asp:Button runat="server" Text="Upload" ID="button_upload" CssClass="btn btn-primary" OnClick="button_upload_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
