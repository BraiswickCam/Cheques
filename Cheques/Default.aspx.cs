using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Cheques
{
    public partial class Default : System.Web.UI.Page
    {
        double totalHolder = 0, amountHolder = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            topTitle.InnerHtml = String.Format("Banking Summary - <strong>{0}</strong>", DateTime.Now.ToShortDateString());
            BankListReader blr = new BankListReader();

            schoolList.DataSource = blr.SchoolListTable();
            schoolList.DataBind();

            cashList.DataSource = blr.CashListTable();
            cashList.DataBind();

            visaList.DataSource = blr.VisaListTable();
            visaList.DataBind();

            BankChequeReader bcr = new BankChequeReader();

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
        }

        private void SummaryTable(DataTable _sumTable, int _count, double _sumCount, double _sumTotal)
        {
            HtmlGenericControl row = new HtmlGenericControl("div");
            row.Attributes["class"] = "row";
            batchTables.Controls.Add(row);

            HtmlGenericControl col = new HtmlGenericControl("div");
            col.Attributes["class"] = "col-xs-12";
            row.Controls.Add(col);

            col.Controls.Add(new LiteralControl(String.Format("<h2>CHEQUE BATCH LIST</h2>")));

            GridView gv = new GridView();
            gv.GridLines = GridLines.None;
            gv.ShowFooter = true;
            gv.CssClass = "table table-striped table-condensed";
            gv.DataSource = _sumTable;
            gv.DataBind();
            gv.FooterRow.Cells[0].Text = "<strong>TOTAL</strong>";
            gv.FooterRow.Cells[1].Text = String.Format("<strong>{0}</strong>", _sumCount);
            gv.FooterRow.Cells[2].Text = String.Format("<strong>{0}</strong>", _sumTotal.ToString("C2"));
            col.Controls.Add(gv);
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