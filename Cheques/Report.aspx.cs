using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace Cheques
{
    public partial class Report : System.Web.UI.Page
    {
        double totalHolder = 0, amountHolder = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = "";
            if (FilesCopied(out error)) GenerateTables();
            else
            {
                form1.Visible = false;
                blankFileAlert.Attributes["class"] = "container-fluid";
                mainAlert.InnerText = error + " Contact support.";
            }
        }

        private bool FilesCopied(out string errorMsg)
        {
            string bankListPath = ConfigurationManager.AppSettings["bankListPath"];
            string bankChqListPath = ConfigurationManager.AppSettings["bankChqListPath"];
            if (File.Exists(bankListPath) && File.Exists(bankChqListPath))
            {
                string backupDir = String.Format("{0}\\{1}", ConfigurationManager.AppSettings["backupPath"], DateTime.Now.ToString("yyyyddMM_HHmmss"));
                Directory.CreateDirectory(backupDir);
                File.Copy(bankListPath, String.Format("{0}\\BANKLIST.TXT", backupDir));
                File.Copy(bankChqListPath, String.Format("{0}\\BANKCHQ.TXT", backupDir));
                errorMsg = "";
                return true;
            }
            else
            {
                if (!File.Exists(bankListPath) && !File.Exists(bankChqListPath))
                {
                    errorMsg = "Both data files are missing!";
                    return false;
                }
                else if (File.Exists(bankChqListPath))
                {
                    errorMsg = "The BANKLIST.TXT file is missing!";
                    return false;
                }
                else
                {
                    errorMsg = "The BANKCHQ.TXT file is missing!";
                    return false;
                }
            }
        }

        private bool GenerateTables()
        {
            topTitle.InnerHtml = String.Format("Banking Summary - <strong>{0}</strong>", DateTime.Now.ToShortDateString());
            BankListReader blr;
            BankChequeReader bcr;
            try { blr = new BankListReader(); }
            catch (BankListException ex)
            {
                reportAlert.Attributes["class"] = "alert alert-danger";
                reportAlert.InnerHtml = String.Format("<strong>ERROR!</strong> The totals for cash/cheque on the following line do not add up correctly!<br/>JobNo: {0}<br/>Booking: {1}<br/>Collection: {2}<br/>School: {3}<br/>Pack: {4}</br>{5}",
                    ex.JobNo, ex.Booking, ex.Collection, ex.School, ex.PackType,
                    "<a href=\"Edit.aspx?mode=list\" class=\"btn btn-danger\"><span class=\"glyphicon glyphicon-wrench\"></span> Fix Errors</a>");
                return false;
            }

            try { bcr = new BankChequeReader(); }
            catch (BankChequeException ex)
            {
                reportAlert.Attributes["class"] = "alert alert-danger";
                reportAlert.InnerHtml = String.Format("<strong>ERROR!</strong> The cheques on the following line do not add up correctly!<br/>JobNo: {0}<br/>Booking: {1}<br/>Collection: {2}<br/>Index {3}<br/>{4}",
                    ex.JobNo, ex.Booking, ex.Collection, ex.Index,
                    "<a href=\"Edit.aspx?mode=chq\" class=\"btn btn-danger\"><span class=\"glyphicon glyphicon-wrench\"></span> Fix Errors</a>");
                return false;
            }

            schoolList.DataSource = blr.SchoolListTable();
            schoolList.RowDataBound += SchoolList_RowDataBound;
            schoolList.DataBind();
            BoldRow(schoolList, schoolList.Rows.Count - 1);

            cashList.DataSource = blr.CashListTable();
            cashList.RowDataBound += CashList_RowDataBound;
            cashList.DataBind();
            BoldRow(cashList, cashList.Rows.Count - 1);

            visaList.DataSource = blr.VisaListTable();
            visaList.RowDataBound += VisaList_RowDataBound;
            visaList.DataBind();
            BoldRow(visaList, visaList.Rows.Count - 1);

            ChqBatch[] cba = bcr.ChequeBatch(bcr.Results);
            int count = 1;
            double sumCount = 0;
            double sumTotal = 0;
            DataTable sumDt = new DataTable();
            sumDt.Columns.Add("Batch", typeof(int));
            sumDt.Columns.Add("Number", typeof(double));
            sumDt.Columns.Add("Total", typeof(double));
            foreach (ChqBatch cb in cba)
            {
                DataTable dt = cb.Table;
                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes["class"] = "row";
                batchTables.Controls.Add(row);

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes["class"] = "col-xs-12";
                row.Controls.Add(col);

                col.Controls.Add(new LiteralControl(String.Format("<h2>CHEQUE LIST Batch No. {0}</h2>", count)));

                GridView gv = new GridView();
                gv.GridLines = GridLines.None;
                gv.ShowFooter = true;
                gv.CssClass = "table table-striped table-condensed";
                gv.DataSource = dt;
                gv.RowDataBound += Gv_RowDataBound;
                gv.DataBind();
                gv.FooterRow.Cells[0].Text = "<strong>TOTAL</strong>";
                gv.FooterRow.Cells[1].Text = String.Format("<strong>{0}</strong>", cb.TotalAmount);
                gv.FooterRow.Cells[2].Text = String.Format("<strong>{0}</strong>", cb.TotalValue.ToString("C2"));
                col.Controls.Add(gv);

                sumDt.Rows.Add(count, cb.TotalAmount, cb.TotalValue);
                sumCount += cb.TotalAmount;
                sumTotal += cb.TotalValue;

                count++;
            }
            SummaryTable(sumDt, count, sumCount, sumTotal);
            return true;
        }

        private void SummaryTable(DataTable _sumTable, int _count, double _sumCount, double _sumTotal)
        {
            HtmlGenericControl row = new HtmlGenericControl("div");
            row.Attributes["class"] = "row";
            batchTables.Controls.Add(row);

            HtmlGenericControl col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-xs-12";
            row.Controls.Add(col);

            GridView gv = new GridView();
            gv.GridLines = GridLines.None;
            gv.ShowFooter = true;
            gv.CssClass = "table table-striped table-condensed";
            gv.DataSource = _sumTable;
            gv.DataBind();
            try
            {
                gv.FooterRow.Cells[0].Text = "<strong>TOTAL</strong>";
                gv.FooterRow.Cells[1].Text = String.Format("<strong>{0}</strong>", _sumCount);
                gv.FooterRow.Cells[2].Text = String.Format("<strong>{0}</strong>", _sumTotal.ToString("C2"));
                col.Controls.Add(new LiteralControl(String.Format("<h2>CHEQUE BATCH LIST</h2>")));
                col.Controls.Add(gv);
            }
            catch (NullReferenceException)
            {
                //form1.Visible = false;
                blankFileAlert.Attributes["class"] = "container-fluid hidden-print";
                mainAlert.Attributes["class"] = "alert alert-warning";
                mainAlert.InnerText = "No cheques found in cheque list! If this is correct, ignore this message, otherwise contact support.";
                mainAlertHomeButton.Visible = false;
            }
            
        }

        private void BoldRow(GridView gv, int rowIndex)
        {
            foreach (DataControlFieldCell fc in gv.Rows[rowIndex].Cells)
            {
                fc.Text = String.Format("<strong>{0}</strong>", fc.Text);
            }
        }

        private void SchoolList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = Convert.ToDouble(e.Row.Cells[3].Text).ToString("C2");
            }
        }

        private void CashList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Convert.ToDouble(e.Row.Cells[1].Text).ToString("C2");
            }
        }

        private void VisaList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDouble(e.Row.Cells[2].Text).ToString("C2");
            }
        }

        private void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = Convert.ToDouble(e.Row.Cells[0].Text).ToString("C2");
                e.Row.Cells[2].Text = Convert.ToDouble(e.Row.Cells[2].Text).ToString("C2");
            }
        }
    }
}