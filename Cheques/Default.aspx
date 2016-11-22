<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cheques.Default" %>

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
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1 class="text-center">Banking Summary</h1></br>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-3 col-md-6 text-center">
                <div class="row">
                    <a href="Report.aspx" class="btn btn-primary"><span class="glyphicon glyphicon-list-alt"></span> Today's Summary</a> <p>Generate today's banking summary.</p></br>
                </div>
                <div class="row">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#finmodal"><span class="glyphicon glyphicon-check"></span> Finalize Day</button> <p>Complete todays banking.</p></br>
                </div>
                <div class="row">
                    <button type="button" id="adminSettings" class="btn btn-danger"><span class="glyphicon glyphicon-cog"></span> Admin Settings</button> <p>Change banking summary config.</p></br>
                </div>
            </div>
            <div class="col-md-offset-3 col-md-6 form-group" id="settingsDiv">
                <div class="row">
                    <div class="col-md-4">BANKLIST.TXT path</div>
                    <div class="col-md-8"><asp:TextBox ID="banklistPathText" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row top15">
                    <div class="col-md-4">BANKCHQ.TXT path</div>
                    <div class="col-md-8"><asp:TextBox ID="bankchqPathText" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row top15">
                    <div class="col-md-4">Back up path</div>
                    <div class="col-md-8"><asp:TextBox ID="backupPathText" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row top15">
                    <div class="col-md-4">Batch split size</div>
                    <div class="col-md-8"><asp:TextBox ID="batchSplitText" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row top15 text-center">
                    <asp:Button ID="saveSettings" runat="server" CssClass="btn btn-primary" Text="Save Settings" OnClick="saveSettings_Click" />
                </div>
            </div>
        </div>
    </div>
        <div id="finmodal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><span class="glyphicon glyphicon-check"></span> Finalize Day</h4>
                    </div>
                    <div class="modal-body">
                        <p><span class="glyphicon glyphicon-alert"></span> <strong>Have you finished banking for the day and printed a summary?</strong></p>
                        <p>If not, finish banking and use the "Today's Summary" button to print your summary before finalizing day.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="finDayButton" runat="server" CssClass="btn btn-danger" Text="Finalize Day" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            $("#settingsDiv").slideUp(0);
            $("#adminSettings").click(function () {
                $("#settingsDiv").slideToggle(800);
            });
        });
    </script>
</body>
</html>
