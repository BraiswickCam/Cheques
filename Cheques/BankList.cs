using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cheques
{
    public class BankList
    {
        public BankList(string[] values)
        {
            //Move conversions to constructor
        }

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
    }
}