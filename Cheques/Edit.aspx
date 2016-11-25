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
        <div class="container-fluid hidden" id="chqErrDiv" runat="server">
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
        <div class="container-fluid hidden" id="listErrDiv" runat="server">
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Job No.: <span id="listJobNoSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Booking: <span id="listBookingSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Collection: <span id="listCollectionSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>School: <span id="listSchoolSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <h3>Pack: <span id="listPackSpan" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <label for="<%=listCashChqTotal.ClientID %>" class="control-label">Cash + Cheque Total</label>
                    <div class="input-group" id="groupListCashChq" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCashChqTotal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listDiscount.ClientID %>" class="control-label">Discount</label>
                    <div class="input-group" id="groupListDiscount" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-2">
                    <label for="<%=listNotes50.ClientID %>" class="control-label">£50 notes</label>
                    <div class="input-group" id="groupListNotes50" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listNotes50" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listNotes20.ClientID %>" class="control-label">£20 notes</label>
                    <div class="input-group" id="groupListNotes20" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listNotes20" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listNotes10.ClientID %>" class="control-label">£10 notes</label>
                    <div class="input-group" id="groupListNotes10" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listNotes10" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listNotes5.ClientID %>" class="control-label">£5 notes</label>
                    <div class="input-group" id="groupListNotes5" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listNotes5" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoins2.ClientID %>" class="control-label">£2 coins</label>
                    <div class="input-group" id="groupListCoins2" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoins1.ClientID %>" class="control-label">£1 coins</label>
                    <div class="input-group" id="groupListCoins1" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <label for="<%=listCoins50.ClientID %>" class="control-label">50p coins</label>
                    <div class="input-group" id="groupListCoins50" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins50" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoins20.ClientID %>" class="control-label">20p coins</label>
                    <div class="input-group" id="groupListCoins20" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins20" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoins10.ClientID %>" class="control-label">10p coins</label>
                    <div class="input-group" id="groupListCoins10" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins10" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoins5.ClientID %>" class="control-label">5p coins</label>
                    <div class="input-group" id="groupListCoins5" runat="server">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoins5" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listCoinsBronze.ClientID %>" class="control-label">Bronze coins</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCoinsBronze" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-offset-4 col-md-4">
                    <label for="<%=listCheque.ClientID %>" class="control-label">Cheque Total</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listCheque" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="<%=listVisa.ClientID %>" class="control-label">Visa Total</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                        <asp:TextBox ID="listVisa" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row text-center top15">
                        <asp:Button ID="listSaveButton" runat="server" CssClass="btn btn-primary" Text="Save Entry" OnClick="listSaveButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
