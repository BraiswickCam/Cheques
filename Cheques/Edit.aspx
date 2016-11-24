<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Cheques.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <style>
        .top15 {
            margin-top: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="hidden">
        <asp:GridView ID="errorGrid" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
    </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Job No.: <span id="jobNoSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Booking: <span id="bookingSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Collection: <span id="collectionSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Index: <span id="indexSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <label for="<%=chqValueText.ClientID %>" class="control-label">Cheque Value</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="chqValueText" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=amountText.ClientID %>" class="control-label">Quantity</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-remove"></i></span>
                        <asp:TextBox ID="amountText" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=totalValueText.ClientID %>" class="control-label">Total Value</label>
                    <div class="input-group">
                        <span class="input-group-addon">= <i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="totalValueText" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row text-center top15">
                        <asp:Button ID="editSaveButton" runat="server" CssClass="btn btn-primary" Text="Save Entry" OnClick="editSaveButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
