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
        public BankListReader blr;
        public BankList[] bl;
        public int errorIndex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "chq")
            {
                chqErrDiv.Attributes["class"] = "container-fluid";
                ChequeEditLoad();
                if (!IsPostBack) ChequeEditPopulate();
            }
            else if (Request.QueryString["mode"] == "list")
            {
                listErrDiv.Attributes["class"] = "container-fluid";
                ListEditLoad();
                if (!IsPostBack) ListEditPopulate();
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

        private void ListEditLoad()
        {
            errorIndex = -1;
            blr = new BankListReader(false);
            bl = blr.Results;
            for (int i = 0; i < bl.Length; i++)
            {
                if (bl[i].ErrorOut)
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

        private void ListEditPopulate()
        {
            for (int i = 0; i < bl.Length; i++)
            {
                if (bl[i].ErrorOut)
                {
                    listJobNoSpan.InnerText = bl[i].JobNo;
                    listBookingSpan.InnerText = bl[i].Booking.ToString();
                    listCollectionSpan.InnerText = bl[i].Collection.ToString();
                    listSchoolSpan.InnerText = bl[i].School;
                    listPackSpan.InnerText = bl[i].PackType;

                    listCashChqTotal.Text = bl[i].CashChequeTotal.ToString();
                    listDiscount.Text = bl[i].Discount.ToString();
                    listNotes50.Text = bl[i].Notes50.ToString();
                    listNotes20.Text = bl[i].Notes20.ToString();
                    listNotes10.Text = bl[i].Notes10.ToString();
                    listNotes5.Text = bl[i].Notes5.ToString();
                    listCoins2.Text = bl[i].Coins2.ToString();
                    listCoins1.Text = bl[i].Coins1.ToString();
                    listCoins50.Text = bl[i].Coins50.ToString();
                    listCoins20.Text = bl[i].Coins20.ToString();
                    listCoins10.Text = bl[i].Coins10.ToString();
                    listCoins5.Text = bl[i].Coins5.ToString();
                    listCoinsBronze.Text = bl[i].CoinsBronze.ToString();
                    listCheque.Text = bl[i].ChequeTotal.ToString();
                    listVisa.Text = bl[i].VisaTotal.ToString();

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

        protected void ListSaveEntry()
        {
            bl[errorIndex].CashChequeTotal = Convert.ToDouble(listCashChqTotal.Text);
            bl[errorIndex].Discount = Convert.ToDouble(listDiscount.Text);
            bl[errorIndex].Notes50 = Convert.ToDouble(listNotes50.Text);
            bl[errorIndex].Notes20 = Convert.ToDouble(listNotes20.Text);
            bl[errorIndex].Notes10 = Convert.ToDouble(listNotes10.Text);
            bl[errorIndex].Notes5 = Convert.ToDouble(listNotes5.Text);
            bl[errorIndex].Coins2 = Convert.ToDouble(listCoins2.Text);
            bl[errorIndex].Coins1 = Convert.ToDouble(listCoins1.Text);
            bl[errorIndex].Coins50 = Convert.ToDouble(listCoins50.Text);
            bl[errorIndex].Coins20 = Convert.ToDouble(listCoins20.Text);
            bl[errorIndex].Coins10 = Convert.ToDouble(listCoins10.Text);
            bl[errorIndex].Coins5 = Convert.ToDouble(listCoins5.Text);
            bl[errorIndex].CoinsBronze = Convert.ToDouble(listCoinsBronze.Text);
            bl[errorIndex].ChequeTotal = Convert.ToDouble(listCheque.Text);
            bl[errorIndex].VisaTotal = Convert.ToDouble(listVisa.Text);

            blr.Results = bl;
            blr.WriteResults();
            ListEditLoad();
            if (errorIndex != -1) ListEditPopulate();
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
            ListSaveEntry();
        }
    }
}