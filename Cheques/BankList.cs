using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

namespace Cheques
{
    public class BankList
    {
        //Variables
        private string jobNo, school, packType;
        private int booking, collection;
        private double notes50, notes20, notes10, notes5, coins2, coins1, coins50, coins20, coins10, coins5, coinsBronze, chequeTotal, visaTotal, cashChequeTotal, discount;

        //Properties
        //Strings
        public string JobNo { get { return jobNo; } private set { jobNo = value.ToString(); } }
        public string School { get { return school; } private set { school = value; } }
        public string PackType { get { return packType; } private set { packType = value; } }
        
        //Integers
        public int Booking { get { return booking; } private set { booking = value; } }
        public int Collection { get { return collection; } private set { collection = value; } }

        //Doubles (money)
        public double Notes50 { get { return notes50; } private set { notes50 = value; } }
        public double Notes20 { get { return notes20; } private set { notes20 = value; } }
        public double Notes10 { get { return notes10; } private set { notes10 = value; } }
        public double Notes5 { get { return notes5; } private set { notes5 = value; } }
        public double Coins2 { get { return coins2; } private set { coins2 = value; } }
        public double Coins1 { get { return coins1; } private set { coins1 = value; } }
        public double Coins50 { get { return coins50; } private set { coins50 = value; } }
        public double Coins20 { get { return coins20; } private set { coins20 = value; } }
        public double Coins10 { get { return coins10; } private set { coins10 = value; } }
        public double Coins5 { get { return coins5; } private set { coins5 = value; } }
        public double CoinsBronze { get { return coinsBronze; } private set { coinsBronze = value; } }
        public double ChequeTotal { get { return chequeTotal; } private set { chequeTotal = value; } }
        public double VisaTotal { get { return visaTotal; } private set { visaTotal = value; } }
        public double CashChequeTotal { get { return cashChequeTotal; } private set { cashChequeTotal = value; } }
        public double Discount { get { return discount; } private set { discount = value; } }

        //Constructor
        public BankList(string[] values)
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

            try { this.Notes20 = Convert.ToDouble(values[8]); }
            catch (System.FormatException)
            {
                if (values[8] == string.Empty) { this.Notes20 = 0; }
                else { throw new FormatException("Notes20 is not a valid double"); }
            }

            try { this.Notes10 = Convert.ToDouble(values[9]); }
            catch (System.FormatException)
            {
                if (values[9] == string.Empty) { this.Notes10 = 0; }
                else { throw new FormatException("Notes10 is not a valid double"); }
            }

            try { this.Notes5 = Convert.ToDouble(values[10]); }
            catch (System.FormatException)
            {
                if (values[10] == string.Empty) { this.Notes5 = 0; }
                else { throw new FormatException("Notes5 is not a valid double"); }
            }

            try { this.Coins2 = Convert.ToDouble(values[11]); }
            catch (System.FormatException)
            {
                if (values[11] == string.Empty) { this.Coins2 = 0; }
                else { throw new FormatException("Coins2 is not a valid double"); }
            }

            try { this.Coins1 = Convert.ToDouble(values[12]); }
            catch (System.FormatException)
            {
                if (values[12] == string.Empty) { this.Coins1 = 0; }
                else { throw new FormatException("Coins1 is not a valid double"); }
            }

            try { this.Coins50 = Convert.ToDouble(values[13]); }
            catch (System.FormatException)
            {
                if (values[13] == string.Empty) { this.Coins50 = 0; }
                else { throw new FormatException("Coins50 is not a valid double"); }
            }

            try { this.Coins20 = Convert.ToDouble(values[14]); }
            catch (System.FormatException)
            {
                if (values[14] == string.Empty) { this.Coins20 = 0; }
                else { throw new FormatException("Coins20 is not a valid double"); }
            }

            try { this.Coins10 = Convert.ToDouble(values[15]); }
            catch (System.FormatException)
            {
                if (values[15] == string.Empty) { this.Coins10 = 0; }
                else { throw new FormatException("Coins10 is not a valid double"); }
            }

            try { this.Coins5 = Convert.ToDouble(values[16]); }
            catch (System.FormatException)
            {
                if (values[16] == string.Empty) { this.Coins5 = 0; }
                else { throw new FormatException("Coins5 is not a valid double"); }
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
        }
    }

    public class BankListReader
    {
        private string source = "C:\\chequeTest\\BANKLIST.txt";
        private BankList[] results;

        public string Source { get { return source; } private set { source = value; } }
        public BankList[] Results { get { return results; } private set { results = value; } }

        public BankListReader()
        {
            this.Results = ReadResults();
        }

        public BankListReader(string bankListSource)
        {
            this.Source = bankListSource;
            this.Results = ReadResults();
        }

        private BankList[] ReadResults()
        {
            string read;
            List<BankList> bl = new List<BankList>();
            StreamReader sr = new StreamReader(this.Source);
            while ((read = sr.ReadLine()) != null)
            {
                string[] values = read.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                bl.Add(new BankList(values));
            }
            sr.Dispose();
            sr.Close();
            return bl.ToArray();
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
            dt.Columns.Add("Denonmination", typeof(string));
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
    }
}