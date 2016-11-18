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
        protected void Page_Load(object sender, EventArgs e)
        {
            BankListReader blr = new BankListReader();
            BankList[] records = blr.Results;
            foreach (BankList bl in records)
            {
                testP.InnerHtml += String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}<br>",
                    bl.JobNo,
                    bl.Booking,
                    bl.Collection,
                    bl.School,
                    bl.PackType,
                    bl.CashChequeTotal,
                    bl.Discount,
                    bl.Notes50,
                    bl.Notes20,
                    bl.Notes10,
                    bl.Notes5,
                    bl.Coins2,
                    bl.Coins1,
                    bl.Coins50,
                    bl.Coins20,
                    bl.Coins10,
                    bl.Coins5,
                    bl.Coins2,
                    bl.CoinsBronze,
                    bl.ChequeTotal,
                    bl.VisaTotal);
            }

            schoolList.DataSource = blr.SchoolListTable();
            schoolList.DataBind();

            cashList.DataSource = blr.CashListTable();
            cashList.DataBind();

            BankChequeReader bcr = new BankChequeReader();

            DataTable[] dta = bcr.ChequeBatch(bcr.Results);
            int count = 1;
            foreach (DataTable dt in dta)
            {
                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes["class"] = "row";
                batchTables.Controls.Add(row);

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes["class"] = "col-xs-12";
                row.Controls.Add(col);

                col.Controls.Add(new LiteralControl(String.Format("<h2>CHEQUE LIST Batch No. {0}</h2>", count)));

                GridView gv = new GridView();
                gv.GridLines = GridLines.None;
                gv.CssClass = "table table-striped";
                gv.DataSource = dt;
                gv.DataBind();
                col.Controls.Add(gv);

                count++;
            }
        }
    }
}