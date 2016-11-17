using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        }
    }
}