using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Cheques
{
    public class Exceptions
    {
    }

    [Serializable]
    public class BankListException : Exception
    {
        private string jobNo, school, packType;
        private int collection, booking;

        public string JobNo { get { return jobNo; } set { jobNo = value; } }
        public string School { get { return school; } set { school = value; } }
        public string PackType { get { return packType; } set { packType = value; } }

        public int Collection { get { return collection; } set { collection = value; } }
        public int Booking { get { return booking; } set { booking = value; } }

        public BankListException() { }

        public BankListException(string message) : base(message) { }

        public BankListException(string message, Exception innerException) : base(message, innerException) { }

        public BankListException(string message, string _jobNo, string _school, string _packType, int _collection, int _booking) : base(message)
        {
            this.JobNo = _jobNo;
            this.School = _school;
            this.PackType = _packType;
            this.Collection = _collection;
            this.Booking = _booking;
        }

        protected BankListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info != null)
            {
                this.JobNo = info.GetString("JobNo");
                this.School = info.GetString("School");
                this.PackType = info.GetString("PackType");
                this.Collection = info.GetInt32("Collection");
                this.Booking = info.GetInt32("Booking");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("JobNo", this.JobNo);
                info.AddValue("School", this.School);
                info.AddValue("PackType", this.PackType);
                info.AddValue("Collection", this.Collection);
                info.AddValue("Booking", this.Booking);
            }
        }
    }
}