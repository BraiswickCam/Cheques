using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

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
            catch (System.FormatException) { throw new FormatException("CashChequeTotal is not a valid double"); }

            try { this.Discount = Convert.ToDouble(values[6]); }
            catch (System.FormatException) { throw new FormatException("Discount is not a valid double"); }

            try { this.Notes50 = Convert.ToDouble(values[7]); }
            catch (System.FormatException) { throw new FormatException("Notes50 is not a valid double"); }

            try { this.Notes20 = Convert.ToDouble(values[8]); }
            catch (System.FormatException) { throw new FormatException("Notes20 is not a valid double"); }

            try { this.Notes10 = Convert.ToDouble(values[9]); }
            catch (System.FormatException) { throw new FormatException("Notes10 is not a valid double"); }

            try { this.Notes5 = Convert.ToDouble(values[10]); }
            catch (System.FormatException) { throw new FormatException("Notes5 is not a valid double"); }

            try { this.Coins2 = Convert.ToDouble(values[11]); }
            catch (System.FormatException) { throw new FormatException("Coins2 is not a valid double"); }

            try { this.Coins1 = Convert.ToDouble(values[12]); }
            catch (System.FormatException) { throw new FormatException("Coins1 is not a valid double"); }

            try { this.Coins50 = Convert.ToDouble(values[13]); }
            catch (System.FormatException) { throw new FormatException("Coins50 is not a valid double"); }

            try { this.Coins20 = Convert.ToDouble(values[14]); }
            catch (System.FormatException) { throw new FormatException("Coins20 is not a valid double"); }

            try { this.Coins10 = Convert.ToDouble(values[15]); }
            catch (System.FormatException) { throw new FormatException("Coins10 is not a valid double"); }

            try { this.Coins5 = Convert.ToDouble(values[16]); }
            catch (System.FormatException) { throw new FormatException("Coins5 is not a valid double"); }

            try { this.CoinsBronze = Convert.ToDouble(values[17]); }
            catch (System.FormatException) { throw new FormatException("CoinsBronze is not a valid double"); }

            try { this.ChequeTotal = Convert.ToDouble(values[18]); }
            catch (System.FormatException) { throw new FormatException("ChequeTotal is not a valid double"); }

            try { this.VisaTotal = Convert.ToDouble(values[19]); }
            catch (System.FormatException) { throw new FormatException("VisaTotal is not a valid double"); }
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
            this.Results = ReadResults(this.Source);
        }

        public BankListReader(string bankListSource)
        {
            this.Source = bankListSource;
            this.Results = ReadResults(this.Source);
        }

        private BankList[] ReadResults(string listSource)
        {
            string read;
            List<BankList> bl = new List<BankList>();
            StreamReader sr = new StreamReader(listSource);
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
    }
}