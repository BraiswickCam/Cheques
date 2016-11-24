<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Cheques.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <style>
        @media screen {
            body {
                margin-top: 15px;
            }
        }

        /*Print formatting*/
        @media print {
            body {
                margin-top: 0px;
            }

            h1 {
                font-size: 26px;
            }

            h2 {
                font-size: 22px;
            }

            table, tr, td {
                padding: 1px !important;
            }
        }
    </style>
</head>
<body>
    <div id="blankFileAlert" class="container-fluid hidden" runat="server">
        <div class="row">
            <div class="col-xs-offset-3 col-xs-6">
                <div class="alert alert-danger" id="mainAlert" runat="server"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-offset-3 col-xs-6">
                <a href="Default.aspx" class="btn btn-info" id="mainAlertHomeButton" runat="server"><span class="glyphicon glyphicon-home"></span> Home</a>
            </div>
        </div>
    </div>
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
            <div class="col-xs-10">
                <h1 id="topTitle" runat="server">Banking Summary</h1>
            </div>
            <div class="col-xs-1">
                <button onclick="window.print();" class="btn btn-warning hidden-print"><span class="glyphicon glyphicon-print"></span> Print</button>
            </div>
            <div class="col-xs-1">
                <a href="Default.aspx" class="btn btn-info hidden-print"><span class="glyphicon glyphicon-home"></span> Home</a>
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
