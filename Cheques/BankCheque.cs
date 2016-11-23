using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Configuration;

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

            double checkValue = this.Amount * this.Value;
            if (Math.Round(checkValue, 2) != this.TotalValue)
            {
                throw new BankChequeException("Cheque total does not add up!", this.JobNo, this.Booking, this.Collection, this.Index);
            }
        }
    }

    public class BankChequeReader
    {
        private string source = ConfigurationManager.AppSettings["bankChqListPath"];
        private BankCheque[] results;

        public string Source { get { return source; } private set { source = value; } }
        public BankCheque[] Results { get { return results; } private set { results = value;} }
        public int SplitSize { get { return Convert.ToInt32(ConfigurationManager.AppSettings["batchSize"]); } }

        public BankChequeReader()
        {
            try { this.Results = ReadResults(); }
            catch (BankChequeException ex) { throw ex; }
            this.Results = SortArray();
        }

        public BankChequeReader(string chqListSource)
        {
            this.Source = chqListSource;
            try { this.Results = ReadResults(); }
            catch (BankChequeException ex) { throw ex; }
            this.Results = SortArray();
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
                try { bc.Add(new BankCheque(values)); }
                catch (BankChequeException ex)
                {
                    sr.Dispose();
                    sr.Close();
                    throw ex;
                }
            }
            sr.Dispose();
            sr.Close();
            return bc.ToArray();
        }

        private BankCheque[] SortArray()
        {
            BankCheque[] sorted = this.Results;
            Array.Sort(sorted, delegate (BankCheque x, BankCheque y) { return x.Value.CompareTo(y.Value); });
            return sorted;
        }

        public ChqBatch[] ChequeBatch(BankCheque[] input)
        {
            List<ChqBatch> dtList = new List<ChqBatch>();
            List<Chq> cList = new List<Chq>();
            foreach (BankCheque bl in input)
            {
                for (int i = 0; i < bl.Amount; i++)
                {
                    if (bl.Value != 0)
                    {
                        Chq c = new Chq(bl);
                        cList.Add(c);
                    }
                }
            }
            List<List<Chq>> batchSplit = ListExtensions.ChunkBy<Chq>(cList, this.SplitSize);
            
            foreach (List<Chq> lc in batchSplit)
            {
                double totalValue = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Value", typeof(double));
                dt.Columns.Add("Number", typeof(double));
                dt.Columns.Add("Total", typeof(double));
                double[] holder = new double[2];
                for (int i = 0; i < lc.Count; i++)
                {
                    if (i != 0)
                    {
                        if (holder[0] != lc[i].Value)
                        {
                            dt.Rows.Add(holder[0], holder[1], holder[0] * holder[1]);
                            holder[0] = lc[i].Value;
                            holder[1] = 1;
                            if (i == lc.Count - 1) { dt.Rows.Add(holder[0], holder[1], holder[0] * holder[1]); }
                        }
                        else if (i == lc.Count - 1)
                        {
                            holder[1]++;
                            dt.Rows.Add(holder[0], holder[1], holder[0] * holder[1]);
                        }
                        else
                        {
                            holder[1]++;
                        }
                    }
                    else
                    {
                        holder[0] = lc[i].Value;
                        holder[1] = 1;
                    }
                    totalValue += lc[i].Value;
                }
                
                dtList.Add(new ChqBatch(dt, totalValue, lc.Count));
            }
            return dtList.ToArray();
        }
    }

    public class Chq
    {
        private double _value;
        
        public double Value { get { return _value; } set { _value = value; } }

        public Chq(BankCheque input)
        {
            this.Value = input.Value;
        }
    }

    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }

    public class ChqBatch
    {
        private DataTable _table;
        private double _totalValue;
        private double _totalAmount;

        public DataTable Table { get { return _table; } private set { _table = value; } }
        public double TotalValue { get { return _totalValue; } private set { _totalValue = value; } }
        public double TotalAmount { get { return _totalAmount; } private set { _totalAmount = value; } }

        public ChqBatch(DataTable dt, double totalValue, double totalAmount)
        {
            this.Table = dt;
            this.TotalValue = totalValue;
            this.TotalAmount = totalAmount;
        }
    }
}