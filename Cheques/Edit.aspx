<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Cheques.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/spin.js/2.3.2/spin.min.js"></script>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <div id="spinnerDiv"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
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
                    <div class="form-group" id="groupListCashChq" runat="server">
                        <label for="<%=listCashChqTotal.ClientID %>" class="control-label">Cash + Cheque Total</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCashChqTotal" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-btn">
                                <button class="btn btn-info" type="button" onclick="document.getElementById('<%=listCashChqTotal.ClientID %>').value = CalculateTotal();">
                                    <span class="glyphicon glyphicon-refresh"></span> Calculate</button>
                            </div>
                        </div>
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
                    <div class="form-group" id="groupListNotes50" runat="server">
                        <label for="<%=listNotes50.ClientID %>" class="control-label">£50 notes</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listNotes50" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListNotes20" runat="server">
                        <label for="<%=listNotes20.ClientID %>" class="control-label">£20 notes</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listNotes20" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListNotes10" runat="server">
                        <label for="<%=listNotes10.ClientID %>" class="control-label">£10 notes</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listNotes10" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListNotes5" runat="server">
                        <label for="<%=listNotes5.ClientID %>" class="control-label">£5 notes</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listNotes5" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListCoins2" runat="server">
                        <label for="<%=listCoins2.ClientID %>" class="control-label">£2 coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListCoins1" runat="server">
                        <label for="<%=listCoins1.ClientID %>" class="control-label">£1 coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group" id="groupListCoins50" runat="server">
                        <label for="<%=listCoins50.ClientID %>" class="control-label">50p coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins50" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListCoins20" runat="server">
                        <label for="<%=listCoins20.ClientID %>" class="control-label">20p coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins20" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListCoins10" runat="server">
                        <label for="<%=listCoins10.ClientID %>" class="control-label">10p coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins10" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="groupListCoins5" runat="server">
                        <label for="<%=listCoins5.ClientID %>" class="control-label">5p coins</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>
                            <asp:TextBox ID="listCoins5" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
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
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        function CalculateTotal() {
            var notes50 = parseFloat(document.getElementById("<%=listNotes50.ClientID %>").value);
            var notes20 = parseFloat(document.getElementById("<%=listNotes20.ClientID %>").value);
            var notes10 = parseFloat(document.getElementById("<%=listNotes10.ClientID %>").value);
            var notes5 = parseFloat(document.getElementById("<%=listNotes5.ClientID %>").value);
            var coins2 = parseFloat(document.getElementById("<%=listCoins2.ClientID %>").value);
            var coins1 = parseFloat(document.getElementById("<%=listCoins1.ClientID %>").value);
            var coins50 = parseFloat(document.getElementById("<%=listCoins50.ClientID %>").value);
            var coins20 = parseFloat(document.getElementById("<%=listCoins20.ClientID %>").value);
            var coins10 = parseFloat(document.getElementById("<%=listCoins10.ClientID %>").value);
            var coins5 = parseFloat(document.getElementById("<%=listCoins5.ClientID %>").value);
            var coinsBronze = parseFloat(document.getElementById("<%=listCoinsBronze.ClientID %>").value);
            var cheques = parseFloat(document.getElementById("<%=listCheque.ClientID %>").value);
            return parseFloat(notes50 + notes20 + notes10 + notes5 + coins2 + coins1 + coins50 + coins20 + coins10 + coins5 + coinsBronze + cheques).toFixed(2);
        };
    </script>
    <script type="text/javascript">

    window.onload = function () {
        var opts = {
            lines: 14, // The number of lines to draw
            length: 7, // The length of each line
            width: 4, // The line thickness
            radius: 10, // The radius of the inner circle
            color: '#000', // #rgb or #rrggbb
            speed: 1, // Rounds per second
            trail: 60, // Afterglow percentage
            shadow: false // Whether to render a shadow
        };
        var target = document.getElementById('spinnerDiv');
        var spinner = new Spinner(opts);
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(panelLoaded);

        prm.add_beginRequest(panelUpdateRequest);
        function panelLoaded(sender, args) {
            spinner.stop();
        }
        function panelUpdateRequest(sender, args) {                   
            spinner.spin(target);
        }              
    }           

</script>
</body>
</html>
