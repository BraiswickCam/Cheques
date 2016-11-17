using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

namespace Cheques
{
    public class BankCheque
    {
        //Variables
        private string jobNo;
        private int booking, collection, index, amount;
        private double _value, totalValue;

        //Properties
        public string JobNo { get { return jobNo; } private set { jobNo = value; } }

        public int Booking { get { return booking; } private set { booking = value; } }
        public int Collection { get { return collection; } private set { collection = value; } }
        public int Index { get { return index; } private set { index = value; } }
        public int Amount { get { return amount; } private set { amount = value; } }

        public double Value { get { return _value; } private set { _value = value; } }
        public double TotalValue { get { return totalValue; } private set { totalValue = value; } }
    
        //Constructor
        public BankCheque(string[] values)
        {
            this.JobNo = values[0];

            try { this.Booking = Convert.ToInt32(values[1]); }
            catch (System.FormatException) { throw new FormatException("Booking is not a valid integer"); }

            try { this.Collection = Convert.ToInt32(values[2]); }
            catch (System.FormatException) { throw new FormatException("Collection is not a valid integer"); }

            try { this.Index = Convert.ToInt32(values[3]); }
            catch (System.FormatException) { throw new FormatException("Index is not a valid integer"); }

            try { this.Value = Convert.ToDouble(values[4]); }
            catch (System.FormatException) { throw new FormatException("Value is not a valid double"); }

            try { this.Amount = Convert.ToInt32(values[5]); }
            catch (System.FormatException) { throw new FormatException("Amount is not a valid integer"); }

            try { this.TotalValue = Convert.ToDouble(values[6]); }
            catch (System.FormatException) { throw new FormatException("TotalValue is not a valid double"); }
        }
    }

    public class BankChequeReader
    {
        private string source = "C:\\chequeTest\\BANKLIST.txt";
        private BankCheque[] results;

        public string Source { get { return source; } private set { source = value; } }
        public BankCheque[] Results { get { return results; } private set { results = value;} }

        public BankChequeReader()
        {
            this.Results = ReadResults();
        }

        public BankChequeReader(string chqListSource)
        {
            this.Source = chqListSource;
            this.Results = ReadResults();
        }

        private BankCheque[] ReadResults()
        {
            string read;
            List<BankCheque> bc = new List<BankCheque>();
            StreamReader sr = new StreamReader(this.Source);
            while ((read = sr.ReadLine()) != null)
            {
                string[] values = read.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                bc.Add(new BankCheque(values));
            }
            sr.Dispose();
            sr.Close();
            return bc.ToArray();
        }

        //NEEDS TESTING!!
        //
        //private BankCheque[] SortArray()
        //{
        //    BankCheque[] sorted = this.Results;
        //    Array.Sort(sorted, delegate (BankCheque x, BankCheque y) { return x.Value.CompareTo(y.Value); });
        //    return sorted;
        //}
    }
}