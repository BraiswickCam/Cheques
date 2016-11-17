<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cheques.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p id="testP" runat="server"></p>
    </div>

    <div class="container container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <h2>School List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="schoolList" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
