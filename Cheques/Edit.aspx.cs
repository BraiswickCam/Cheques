using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Cheques
{
    public partial class Edit : System.Web.UI.Page
    {
        public BankChequeReader bcr;
        public BankCheque[] bc;
        public int errorIndex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "chq")
            {
                ChequeEditLoad();
                if (!IsPostBack) ChequeEditPopulate();
            }
        }

        private void ChequeEditLoad()
        {
            errorIndex = -1;
            bcr = new BankChequeReader(false);
            bc = bcr.Results;
            for (int i = 0; i < bc.Length; i++)
            {
                if (bc[i].ErrorOut)
                {
                    errorIndex = i;
                    break;
                }
            }
        }

        private void ChequeEditPopulate()
        {
            for (int i = 0; i < bc.Length; i++)
            {
                if (bc[i].ErrorOut)
                {
                    jobNoSpan.InnerText = bc[i].JobNo;
                    bookingSpan.InnerText = bc[i].Booking.ToString();
                    collectionSpan.InnerText = bc[i].Collection.ToString();
                    indexSpan.InnerText = bc[i].Index.ToString();
                    chqValueText.Text = bc[i].Value.ToString();
                    amountText.Text = bc[i].Amount.ToString();
                    totalValueText.Text = bc[i].TotalValue.ToString();
                    errorIndex = i;
                    break;
                }
            }
        }

        protected void editSaveButton_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }

        protected void SaveEntry()
        {
            bc[errorIndex].Value = Convert.ToDouble(chqValueText.Text);
            bc[errorIndex].Amount = Convert.ToInt32(amountText.Text);
            bc[errorIndex].TotalValue = Convert.ToDouble(totalValueText.Text);
            bcr.Results = bc;
            bcr.WriteResults();
            ChequeEditLoad();
            if (ErrorsCheck()) ChequeEditPopulate();
            else Response.Redirect("Default.aspx");
        }

        protected bool ErrorsCheck()
        {
            if (errorIndex == -1)
            {
                jobNoSpan.InnerText = "NO ERRORS!";
                return false;
            }
            return true;
        }

        protected void listSaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}