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
        public string mode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "chq")
            {
                mode = "chq";
                chqErrDiv.Attributes["class"] = "container-fluid";
                ChequeEditLoad();
                if (!IsPostBack) ChequeEditPopulate();
            }
            else if (Request.QueryString["mode"] == "list")
            {
                mode = "list";
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

                    if (bl[i].DenomError)
                    {
                        string error = bl[i].DenomFlag;
                        groupListCashChq.Attributes["class"] = "form-group has-error";
                        if (error == "Notes50") groupListNotes50.Attributes["class"] = "form-group has-error";
                        else groupListNotes50.Attributes["class"] = "form-group";
                        if (error == "Notes20") groupListNotes20.Attributes["class"] = "form-group has-error";
                        else groupListNotes20.Attributes["class"] = "form-group";
                        if (error == "Notes10") groupListNotes10.Attributes["class"] = "form-group has-error";
                        else groupListNotes10.Attributes["class"] = "form-group";
                        if (error == "Notes5") groupListNotes5.Attributes["class"] = "form-group has-error";
                        else groupListNotes5.Attributes["class"] = "form-group";
                        if (error == "Coins2") groupListCoins2.Attributes["class"] = "form-group has-error";
                        else groupListCoins2.Attributes["class"] = "form-group";
                        if (error == "Coins1") groupListCoins1.Attributes["class"] = "form-group has-error";
                        else groupListCoins1.Attributes["class"] = "form-group";
                        if (error == "Coins50") groupListCoins50.Attributes["class"] = "form-group has-error";
                        else groupListCoins50.Attributes["class"] = "form-group";
                        if (error == "Coins20") groupListCoins20.Attributes["class"] = "form-group has-error";
                        else groupListCoins20.Attributes["class"] = "form-group";
                        if (error == "Coins10") groupListCoins10.Attributes["class"] = "form-group has-error";
                        else groupListCoins10.Attributes["class"] = "form-group";
                        if (error == "Coins5") groupListCoins5.Attributes["class"] = "form-group has-error";
                        else groupListCoins5.Attributes["class"] = "form-group";
                    }

                    errorIndex = i;
                    break;
                }
            }
        }

        protected void editSaveButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "chq")
            {
                mode = "chq";
                chqErrDiv.Attributes["class"] = "container-fluid";
                ChequeEditLoad();
            }
            else if (Request.QueryString["mode"] == "list")
            {
                mode = "list";
                listErrDiv.Attributes["class"] = "container-fluid";
                ListEditLoad();
            }
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
            bl[errorIndex].CashChequeTotal = SafeConvertToDouble(listCashChqTotal.Text);
            bl[errorIndex].Discount = SafeConvertToDouble(listDiscount.Text);
            bl[errorIndex].Notes50 = SafeConvertToDouble(listNotes50.Text);
            bl[errorIndex].Notes20 = SafeConvertToDouble(listNotes20.Text);
            bl[errorIndex].Notes10 = SafeConvertToDouble(listNotes10.Text);
            bl[errorIndex].Notes5 = SafeConvertToDouble(listNotes5.Text);
            bl[errorIndex].Coins2 = SafeConvertToDouble(listCoins2.Text);
            bl[errorIndex].Coins1 = SafeConvertToDouble(listCoins1.Text);
            bl[errorIndex].Coins50 = SafeConvertToDouble(listCoins50.Text);
            bl[errorIndex].Coins20 = SafeConvertToDouble(listCoins20.Text);
            bl[errorIndex].Coins10 = SafeConvertToDouble(listCoins10.Text);
            bl[errorIndex].Coins5 = SafeConvertToDouble(listCoins5.Text);
            bl[errorIndex].CoinsBronze = SafeConvertToDouble(listCoinsBronze.Text);
            bl[errorIndex].ChequeTotal = SafeConvertToDouble(listCheque.Text);
            bl[errorIndex].VisaTotal = SafeConvertToDouble(listVisa.Text);

            blr.Results = bl;
            blr.WriteResults();
            ListEditLoad();
            if (errorIndex != -1) ListEditPopulate();
            else Response.Redirect("Default.aspx");
        }

        protected double SafeConvertToDouble(string input)
        {
            double output = 0;
            try { output = Convert.ToDouble(input); }
            catch (System.FormatException ex)
            {
                if (String.IsNullOrWhiteSpace(input))
                {
                    output = 0;
                }
                else
                {
                    throw ex;
                }
            }
            return output;
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
            if (Request.QueryString["mode"] == "chq")
            {
                mode = "chq";
                chqErrDiv.Attributes["class"] = "container-fluid";
                ChequeEditLoad();
            }
            else if (Request.QueryString["mode"] == "list")
            {
                mode = "list";
                listErrDiv.Attributes["class"] = "container-fluid";
                ListEditLoad();
            }
            ListSaveEntry();
        }
    }
}