using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Configuration;

namespace Cheques
{
    public class BankList
    {
        //Variables
        private string jobNo, school, packType, denomFlag;
        private int booking, collection;
        private double notes50, notes20, notes10, notes5, coins2, coins1, coins50, coins20, coins10, coins5, coinsBronze, chequeTotal, visaTotal, cashChequeTotal, discount;
        private bool errorOut, denomError;

        //Properties
        //Strings
        public string JobNo { get { return jobNo; } private set { jobNo = value.ToString(); } }
        public string School { get { return school; } private set { school = value; } }
        public string PackType { get { return packType; } private set { packType = value; } }
        public string DenomFlag { get { return denomFlag; } set { denomFlag = value; } }
        
        //Integers
        public int Booking { get { return booking; } private set { booking = value; } }
        public int Collection { get { return collection; } private set { collection = value; } }

        //Doubles (money)
        public double Notes50 { get { return notes50; } set { notes50 = value; } }
        public double Notes20 { get { return notes20; } set { notes20 = value; } }
        public double Notes10 { get { return notes10; } set { notes10 = value; } }
        public double Notes5 { get { return notes5; } set { notes5 = value; } }
        public double Coins2 { get { return coins2; } set { coins2 = value; } }
        public double Coins1 { get { return coins1; } set { coins1 = value; } }
        public double Coins50 { get { return coins50; } set { coins50 = value; } }
        public double Coins20 { get { return coins20; } set { coins20 = value; } }
        public double Coins10 { get { return coins10; } set { coins10 = value; } }
        public double Coins5 { get { return coins5; } set { coins5 = value; } }
        public double CoinsBronze { get { return coinsBronze; } set { coinsBronze = value; } }
        public double ChequeTotal { get { return chequeTotal; } set { chequeTotal = value; } }
        public double VisaTotal { get { return visaTotal; } set { visaTotal = value; } }
        public double CashChequeTotal { get { return cashChequeTotal; } set { cashChequeTotal = value; } }
        public double Discount { get { return discount; } set { discount = value; } }

        public bool ErrorOut { get { return errorOut; } private set { errorOut = value; } }
        public bool DenomError { get { return denomError; } private set { denomError = value; } }

        //Constructor
        public BankList(string[] values, bool checkErrors = true)
        {
            this.JobNo = values[0];

            try { this.Booking = Convert.ToInt32(values[1]); }
            catch (System.FormatException) { throw new FormatException("Booking is not a valid integer"); }

            try { this.Collection = Convert.ToInt32(values[2]); }
            catch (System.FormatException) { throw new FormatException("Collection is not a valid integer"); }

            this.School = values[3];
            this.PackType = values[4];

            try { this.CashChequeTotal = Convert.ToDouble(values[5]); }
            catch (System.FormatException)
            {
                if (values[5] == string.Empty) { this.CashChequeTotal = 0; }
                else { throw new FormatException("CashChequeTotal is not a valid double"); }
            }

            try { this.Discount = Convert.ToDouble(values[6]); }
            catch (System.FormatException)
            {
                if (values[6] == string.Empty) { this.Discount = 0; }
                else { throw new FormatException("Discount is not a valid double"); }
            }

            try { this.Notes50 = Convert.ToDouble(values[7]); }
            catch (System.FormatException)
            {
                if (values[7] == string.Empty) { this.Notes50 = 0; }
                else { throw new FormatException("Notes50 is not a valid double"); }
            }
            if (this.Notes50 % 50 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Notes50";
            }

            try { this.Notes20 = Convert.ToDouble(values[8]); }
            catch (System.FormatException)
            {
                if (values[8] == string.Empty) { this.Notes20 = 0; }
                else { throw new FormatException("Notes20 is not a valid double"); }
            }
            if (this.Notes20 % 20 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Notes20";
            }

            try { this.Notes10 = Convert.ToDouble(values[9]); }
            catch (System.FormatException)
            {
                if (values[9] == string.Empty) { this.Notes10 = 0; }
                else { throw new FormatException("Notes10 is not a valid double"); }
            }
            if (this.Notes10 % 10 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Notes10";
            }

            try { this.Notes5 = Convert.ToDouble(values[10]); }
            catch (System.FormatException)
            {
                if (values[10] == string.Empty) { this.Notes5 = 0; }
                else { throw new FormatException("Notes5 is not a valid double"); }
            }
            if (this.Notes5 % 5 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Notes5";
            }

            try { this.Coins2 = Convert.ToDouble(values[11]); }
            catch (System.FormatException)
            {
                if (values[11] == string.Empty) { this.Coins2 = 0; }
                else { throw new FormatException("Coins2 is not a valid double"); }
            }
            if (this.Coins2 % 2 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins2";
            }

            try { this.Coins1 = Convert.ToDouble(values[12]); }
            catch (System.FormatException)
            {
                if (values[12] == string.Empty) { this.Coins1 = 0; }
                else { throw new FormatException("Coins1 is not a valid double"); }
            }
            if (this.Coins1 % 1 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins1";
            }

            try { this.Coins50 = Convert.ToDouble(values[13]); }
            catch (System.FormatException)
            {
                if (values[13] == string.Empty) { this.Coins50 = 0; }
                else { throw new FormatException("Coins50 is not a valid double"); }
            }
            if (Math.Round((this.Coins50 * 100), 2) % 50 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins50";
            }

            try { this.Coins20 = Convert.ToDouble(values[14]); }
            catch (System.FormatException)
            {
                if (values[14] == string.Empty) { this.Coins20 = 0; }
                else { throw new FormatException("Coins20 is not a valid double"); }
            }
            if (Math.Round((this.Coins20 * 100), 2) % 20 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins20";
            }

            try { this.Coins10 = Convert.ToDouble(values[15]); }
            catch (System.FormatException)
            {
                if (values[15] == string.Empty) { this.Coins10 = 0; }
                else { throw new FormatException("Coins10 is not a valid double"); }
            }
            if (Math.Round((this.Coins10 * 100), 2) % 10 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins10";
            }

            try { this.Coins5 = Convert.ToDouble(values[16]); }
            catch (System.FormatException)
            {
                if (values[16] == string.Empty) { this.Coins5 = 0; }
                else { throw new FormatException("Coins5 is not a valid double"); }
            }
            if (Math.Round((this.Coins5 * 100), 2) % 5 != 0)
            {
                this.DenomError = true;
                this.DenomFlag = "Coins5";
            }

            try { this.CoinsBronze = Convert.ToDouble(values[17]); }
            catch (System.FormatException)
            {
                if (values[17] == string.Empty) { this.CoinsBronze = 0; }
                else { throw new FormatException("CoinsBronze is not a valid double"); }
            }

            try { this.ChequeTotal = Convert.ToDouble(values[18]); }
            catch (System.FormatException)
            {
                if (values[18] == string.Empty) { this.ChequeTotal= 0; }
                else { throw new FormatException("ChequeTotal is not a valid double"); }
            }

            try { this.VisaTotal = Convert.ToDouble(values[19]); }
            catch (System.FormatException)
            {
                if (values[19] == string.Empty) { this.VisaTotal = 0; }
                else { throw new FormatException("VisaTotal is not a valid double"); }
            }

            double totalCheck = this.Notes50 + this.Notes20 + this.Notes10 + this.Notes5 + this.Coins2 + this.Coins1 + this.Coins50 + this.Coins20 + this.Coins10 + this.Coins5 + this.CoinsBronze + this.ChequeTotal;
            if (Math.Round(totalCheck, 2) != this.CashChequeTotal)
            {
                if (checkErrors) { throw new BankListException("The total cash and cheque values do not add correctly on this line!", this.JobNo, this.School, this.PackType, this.Collection, this.Booking); }
                else { this.ErrorOut = true; }
            }
            else { this.ErrorOut = false; }
            if (this.DenomError)
            {
                if (checkErrors) { throw new DenominationException("A demonination does not add up correctly!", this.JobNo, this.School, this.PackType, this.Collection, this.Booking, this.DenomFlag); }
                else { this.ErrorOut = true; }
            }
        }
    }

    public class BankListReader
    {
        private string source = ConfigurationManager.AppSettings["bankListPath"];
        private BankList[] results;

        public string Source { get { return source; } private set { source = value; } }
        public BankList[] Results { get { return results; } set { results = value; } }

        public BankListReader(bool checkErrors = true)
        {
            try { this.Results = ReadResults(checkErrors); }
            catch (BankListException ex) { throw ex; }
        }

        public BankListReader(string bankListSource, bool checkErrors = true)
        {
            this.Source = bankListSource;
            try { this.Results = ReadResults(checkErrors); }
            catch (BankListException ex) { throw ex; }
        }

        private BankList[] ReadResults(bool checkErrors)
        {
            string read;
            List<BankList> bl = new List<BankList>();
            StreamReader sr = new StreamReader(this.Source);
            while ((read = sr.ReadLine()) != null)
            {
                var reg = new System.Text.RegularExpressions.Regex("\".*?\"");
                var matches = reg.Matches(read);
                List<string> valueList = new List<string>();
                foreach (var item in matches)
                {
                    valueList.Add(item.ToString());
                }
                string[] values = valueList.ToArray();
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                try { bl.Add(new BankList(values, checkErrors)); }
                catch (BankListException ex)
                {
                    sr.Dispose();
                    sr.Close();
                    throw ex;
                }
                catch (DenominationException ex)
                {
                    sr.Dispose();
                    sr.Close();
                    throw ex;
                }
            }
            sr.Dispose();
            sr.Close();
            return bl.ToArray();
        }

        public void WriteResults()
        {
            StreamWriter sw = new StreamWriter(this.Source, false);
            foreach (BankList bl in this.Results)
            {
                string write = String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\"",
                    bl.JobNo, bl.Booking, bl.Collection, bl.School, bl.PackType,
                    bl.CashChequeTotal, bl.Discount, bl.Notes50, bl.Notes20, bl.Notes10,
                    bl.Notes5, bl.Coins2, bl.Coins1, bl.Coins50, bl.Coins20,
                    bl.Coins10, bl.Coins5, bl.CoinsBronze, bl.ChequeTotal, bl.VisaTotal);
                sw.WriteLine(write);
            }
            sw.Dispose();
            sw.Close();
        }

        public DataTable SchoolListTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Job No.", typeof(string));
            dt.Columns.Add("School Name", typeof(string));
            dt.Columns.Add("Pack", typeof(string));
            dt.Columns.Add("Banked", typeof(double));
            dt.Columns.Add("Discount", typeof(double));

            double grandTotal = 0, grandDiscount = 0;
            foreach (BankList bl in this.Results)
            {
                dt.Rows.Add(new object[] { bl.JobNo, bl.School, bl.PackType, bl.CashChequeTotal, bl.Discount });
                grandTotal += bl.CashChequeTotal;
                grandDiscount += bl.Discount;
            }
            dt.Rows.Add(new object[] { "", "", "TOTAL", grandTotal, grandDiscount });

            return dt;
        }

        public DataTable CashListTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Denomination", typeof(string));
            dt.Columns.Add("Amount", typeof(double));

            double note50Total = 0, note20Total = 0, note10Total = 0, note5Total = 0, coin2Total = 0, coin1Total = 0, coin50Total = 0, coin20Total = 0, coin10Total = 0, coin5Total = 0, coinBronzeTotal = 0, chequeTotal = 0, grandTotal = 0;
            foreach (BankList bl in this.Results)
            {
                note50Total += bl.Notes50;
                note20Total += bl.Notes20;
                note10Total += bl.Notes10;
                note5Total += bl.Notes5;
                coin2Total += bl.Coins2;
                coin1Total += bl.Coins1;
                coin50Total += bl.Coins50;
                coin20Total += bl.Coins20;
                coin10Total += bl.Coins10;
                coin5Total += bl.Coins5;
                coinBronzeTotal += bl.CoinsBronze;
                chequeTotal += bl.ChequeTotal;
                grandTotal += bl.CashChequeTotal;
            }

            dt.Rows.Add(new object[] { "£50", note50Total });
            dt.Rows.Add(new object[] { "£20", note20Total });
            dt.Rows.Add(new object[] { "£10", note10Total });
            dt.Rows.Add(new object[] { "£5", note5Total });
            dt.Rows.Add(new object[] { "£2", coin2Total });
            dt.Rows.Add(new object[] { "£1", coin1Total });
            dt.Rows.Add(new object[] { "50p", coin50Total });
            dt.Rows.Add(new object[] { "20p", coin20Total });
            dt.Rows.Add(new object[] { "10p", coin10Total });
            dt.Rows.Add(new object[] { "5p", coin5Total });
            dt.Rows.Add(new object[] { "Bronze", coinBronzeTotal });
            dt.Rows.Add(new object[] { "Cheques", chequeTotal });
            dt.Rows.Add(new object[] { "TOTAL", grandTotal });

            return dt;
        }

        public DataTable VisaListTable()
        {
            double grandTotal = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Job No", typeof(string));
            dt.Columns.Add("Name of School", typeof(string));
            dt.Columns.Add("VISA", typeof(double));
            foreach (BankList bl in this.Results)
            {
                dt.Rows.Add(bl.JobNo, bl.School, bl.VisaTotal);
                grandTotal += bl.VisaTotal;
            }
            dt.Rows.Add("", "TOTAL", grandTotal);

            return dt;
        }
    }
}