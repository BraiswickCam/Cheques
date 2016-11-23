<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Cheques.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-offset-3 col-md-6">
                    <div class="alert alert-danger hidden" id="reportAlert" runat="server"></div>
                </div>
            </div>
        </div>
    <div class="container container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <h1 id="topTitle" runat="server">Banking Summary</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-lg-12">
                <h2>School List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-lg-12">
                <asp:GridView ID="schoolList" runat="server" CssClass="table table-striped table-condensed" GridLines="None"></asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-lg-12">
                <h2>Cash List</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-lg-12">
                <asp:GridView ID="cashList" runat="server" CssClass="table table-striped table-condensed" GridLines="None"></asp:GridView>
            </div>
        </div>
    </div>
    <div class="container container-fluid" id="batchTables" runat="server">

    </div>
        <div class="container container-fluid">
            <div class="row">
                <div class="col-xs-12">
                    <h2>VISA LIST</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="visaList" runat="server" CssClass="table table-striped table-condensed" GridLines="None"></asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
