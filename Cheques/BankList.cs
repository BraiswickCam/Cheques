using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string JobNo { get { return jobNo; } set { jobNo = value; } }
        public string School { get { return school; } set { school = value; } }
        public string PackType { get { return packType; } set { packType = value; } }
        
        //Integers
        public int Booking
        {
            get { return booking; }
            set
            {
                try { booking = Convert.ToInt32(value); }
                catch (System.FormatException) { throw new FormatException("Booking number must be an integer"); }
            }
        }
        public int Collection
        {
            get { return collection; }
            set
            {
                try { collection = Convert.ToInt32(value); }
                catch (System.FormatException) { throw new FormatException("Collection number must be an integer"); }
            }
        }

        //Doubles (money)
        public double Notes50
        {
            get { return notes50; }
            set
            {
                try { notes50 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£50 notes must be a double (decimal number)"); }
            }
        }
        public double Notes20
        {
            get { return notes20; }
            set
            {
                try { notes20 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£20 notes must be a double (decimal number)"); }
            }
        }
        public double Notes10
        {
            get { return notes10; }
            set
            {
                try { notes10 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£10 notes must be a double (decimal number)"); }
            }
        }
        public double Notes5
        {
            get { return notes5; }
            set
            {
                try { notes5 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£5 notes must be a double (decimal number)"); }
            }
        }
        public double Coins2
        {
            get { return coins2; }
            set
            {
                try { coins2 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£2 coins must be a double (decimal number)"); }
            }
        }
        public double Coins1
        {
            get { return coins1; }
            set
            {
                try { coins1 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("£1 coins must be a double (decimal number)"); }
            }
        }
        public double Coins50
        {
            get { return coins50; }
            set
            {
                try { coins50 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("50p coins must be a double (decimal number)"); }
            }
        }
        public double Coins20
        {
            get { return coins20; }
            set
            {
                try { coins20 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("20p coins must be a double (decimal number)"); }
            }
        }
        public double Coins10
        {
            get { return coins10; }
            set
            {
                try { coins10 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("10p coins must be a double (decimal number)"); }
            }
        }
        public double Coins5
        {
            get { return coins5; }
            set
            {
                try { coins5 = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("5p coins must be a double (decimal number)"); }
            }
        }
        public double CoinsBronze
        {
            get { return coinsBronze; }
            set
            {
                try { coinsBronze = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("Bronze coins must be a double (decimal number)"); }
            }
        }
        public double ChequeTotal
        {
            get { return chequeTotal; }
            set
            {
                try { chequeTotal = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("Cheque Total must be a double (decimal number)"); }
            }
        }
        public double VisaTotal
        {
            get { return visaTotal; }
            set
            {
                try { visaTotal = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("Visa Total must be a double (decimal number)"); }
            }
        }
        public double CashChequeTotal
        {
            get { return cashChequeTotal; }
            set
            {
                try { cashChequeTotal = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("Cash and Cheque Total must be a double (decimal number)"); }
            }
        }
        public double Discount
        {
            get { return discount; }
            set
            {
                try { discount = Convert.ToDouble(value); }
                catch (System.FormatException) { throw new FormatException("Discount must be a double (decimal number)"); }
            }
        }
    }
}