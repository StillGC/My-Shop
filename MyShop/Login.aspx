<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyShop.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>My Shop</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Site.css" rel="stylesheet" />
    <script src="js/lib/jquery.min.js"></script>
    <script src="js/lib/bootstrap.min.js"></script>
    <script src="js/lib/bootstrap-notify.min.js"></script>
    <script>
        function ShowAlert(sType, sMensaje) {
            switch (sType) {
                case "success":
                    $.notify({
                        message: sMensaje
                    }, {
                        type: 'success',
                        delay: 1000,
                        timer: 1000,
                        animate: {
                            enter: 'animated fadeInRight',
                            exit: 'animated fadeOutRight'
                        }
                    });
                    break;
                case "warning":
                    $.notify({
                        message: sMensaje
                    }, {
                        type: 'warning',
                        delay: 1000,
                        timer: 1000,
                        animate: {
                            enter: 'animated fadeInRight',
                            exit: 'animated fadeOutRight'
                        }
                    });
                    break;
                case "danger":
                    $.notify({
                        message: sMensaje
                    }, {
                        type: 'danger',
                        delay: 1000,
                        timer: 1000,
                        animate: {
                            enter: 'animated fadeInRight',
                            exit: 'animated fadeOutRight'
                        }
                    });
                    break;
            }
        }

    </script>
</head>
<body>
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">My Shop</a>
            </div>
        </div>
    </nav>
    <form id="form_login" runat="server">
        <div id="container_login" class="container">
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <div class="form-login">
                        <asp:Login ID="Login1" runat="server" OnLoggedIn="Login_LoggedIn" OnLoginError="Login1_LoginError">
                            <LayoutTemplate>
                                <h4>Welcome back.</h4>
                                <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="username" required></asp:TextBox>
                                <br />
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="password" required></asp:TextBox>
                                <br />
                                <div class="wrapper">
                                    <span class="group-btn">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="login" ValidationGroup="Login1" CssClass="btn btn-primary" />
                                    </span>
                                </div>
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
