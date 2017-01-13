<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cheques.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>
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
                    <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#finmodal"><span class="glyphicon glyphicon-alert"></span> Finalize Day</button> <p>Complete todays banking.</p></br>
                </div>
                <div class="row">
                    <button type="button" id="adminSettings" class="btn btn-danger"><span class="glyphicon glyphicon-cog"></span> Admin Settings</button> <p>Change banking summary config.</p></br>
                </div>
            </div>
            <div class="col-md-offset-4 col-md-4" id="settingsDiv">
                <div class="form-group has-feedback" id="path1In">
                    <label for="<%=banklistPathText.ClientID %>" class="control-label">BANKLIST.TXT path</label>
                    <asp:TextBox ID="banklistPathText" runat="server" CssClass="form-control"></asp:TextBox>
                    <span id="path1Icon" class="glyphicon form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback" id="path2In">
                    <label for="<%=bankchqPathText.ClientID %>" class="control-label">BANKCHQ.TXT path</label>
                    <asp:TextBox ID="bankchqPathText" runat="server" CssClass="form-control"></asp:TextBox>
                    <span id="path2Icon" class="glyphicon form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback" id="path3In">
                    <label for="<%=backupPathText.ClientID %>" class="control-label">Back up path</label>
                    <asp:TextBox ID="backupPathText" runat="server" CssClass="form-control"></asp:TextBox>
                    <span id="path3Icon" class="glyphicon form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback" id="batchIn">
                    <label for="<%=batchSplitText.ClientID %>" class="control-label">Batch split size</label>
                    <asp:TextBox ID="batchSplitText" runat="server" CssClass="form-control numeric-only"></asp:TextBox>
                    <span id="batchIcon" class="glyphicon form-control-feedback"></span>
                </div>
                <div class="row top15 text-center">
                    <asp:Button ID="saveSettings" runat="server" CssClass="btn btn-primary savebutton" Text="Save Settings" OnClick="saveSettings_Click" />
                </div>
            </div>
        </div>
    </div>
        <div id="finmodal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><span class="glyphicon glyphicon-alert"></span> Finalize Day</h4>
                    </div>
                    <div class="modal-body">
                        <h3 style="color: #d9534f;"><span class="glyphicon glyphicon-alert"></span> <strong>Have you finished banking for the day and printed a summary?</strong></h3>
                        <p>If not, finish banking and use the "Today's Summary" button to print your summary <strong>before</strong> finalizing day.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="finDayButton" runat="server" CssClass="btn btn-danger" Text="Finalize Day" OnClick="finDayButton_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            var path1 = <%=path1.ToString().ToLower()%>;
            var path2 = <%=path2.ToString().ToLower()%>;
            var path3 = <%=path3.ToString().ToLower()%>;

            var path1Val = document.getElementById("<%=banklistPathText.ClientID %>").value;
            var path2Val = document.getElementById("<%=bankchqPathText.ClientID %>").value;
            var path3Val = document.getElementById("<%=backupPathText.ClientID %>").value;

            var batch1 = document.getElementById("<%=batchSplitText.ClientID %>");
            var batchId = "#" + "<%=batchSplitText.ClientID %>";
            var path1Id = "#" + "<%=banklistPathText.ClientID %>";
            var path2Id = "#" + "<%=bankchqPathText.ClientID %>";
            var path3Id = "#" + "<%=backupPathText.ClientID %>";

            checkFile(path1, "path1");
            checkFile(path2, "path2");
            checkFile(path3, "path3");
            batchNumCheck(batch1);

            $("#settingsDiv").slideUp(0);

            if (path1 == false || path2 == false || path3 == false || $.isNumeric(batch1.value) == false){
                $("#settingsDiv").slideDown(400);
            }

            $("#adminSettings").click(function () {
                $("#settingsDiv").slideToggle(800);
            });

            $(".savebutton").click(function () {
                $("#settingsDiv").slideUp(100);
            });

            $(batchId).keyup(function () {
                batchNumCheck(batch1);
            });

            $(path1Id).keyup(function () {
                pathTyping(path1, "path1", path1Val, "<%=banklistPathText.ClientID %>");
            });

            $(path2Id).keyup(function () {
                pathTyping(path2, "path2", path2Val, "<%=bankchqPathText.ClientID %>");
            });

            $(path3Id).keyup(function () {
                pathTyping(path3, "path3", path3Val, "<%=backupPathText.ClientID %>");
            });
        });

        function checkFile(csharpBool, idStart){
            if(csharpBool == true){
                $("#" + idStart + "In").addClass("has-success");
                $("#" + idStart + "Icon").addClass("glyphicon-ok");
            } else {
                $("#" + idStart + "In").addClass("has-error");
                $("#" + idStart + "Icon").addClass("glyphicon-remove");
            }
        };

        function pathTyping(csharpBool, idStart, origVal, eleId){
            if(csharpBool == true){
                $("#" + idStart + "In").removeClass("has-success");
                $("#" + idStart + "Icon").removeClass("glyphicon-ok");
            } else {
                $("#" + idStart + "In").removeClass("has-error");
                $("#" + idStart + "Icon").removeClass("glyphicon-remove");
            }
            
            $("#" + idStart + "In").addClass("has-warning");
            $("#" + idStart + "Icon").addClass("glyphicon-question-sign");
        };

        function batchNumCheck(batchEle){
            var v = batchEle.value;
            if ($.isNumeric(v) === false) {
                checkFile(false, "batch");
                $("#batchIn").removeClass("has-success");
                $("#batchIcon").removeClass("glyphicon-ok")
                $("#" + "<%=saveSettings.ClientID%>").prop("disabled", true);
            } else {
                checkFile(true, "batch");
                $("#batchIn").removeClass("has-error");
                $("#batchIcon").removeClass("glyphicon-remove");
                $("#" + "<%=saveSettings.ClientID%>").prop("disabled", false);
            }
        };
    </script>
</body>
</html>
