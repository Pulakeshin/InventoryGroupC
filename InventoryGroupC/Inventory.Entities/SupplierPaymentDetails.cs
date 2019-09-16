using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory.Entities
{
    //This is a model class for Supplier Payment Details
    public class SupplierPaymentDetails
    {

        //Supplier Id and its Auto-Implemented Property
        private string _supId;

        public string SupId
        {
            get { return _supId; }
            set { _supId = value; }
        }

        //Order Id provided to the Supplier while asking for Raw Materials
        private int _supOrderId;

        public int SupOrderId
        {
            get { return _supOrderId; }
            set { _supOrderId = value; }
        }

        //Transaction Id provided to the Supplier when payment is successful
        private long _supTransactionID;

        public long SupTransactionID
        {
            get { return _supTransactionID; }
            set { _supTransactionID = value; }
        }

        //To store order date when the supplier is asked for Raw materials
        private DateTime _supOrderDate;

        public DateTime SupOrderDate
        {
            get { return _supOrderDate; }
            set { _supOrderDate = value; }
        }

        


        //To store Total Quantity of the order asked for
        private int _supTotalQuantity;

        public int SupTotalQuantity
        {
            get { return _supTotalQuantity; }
            set { _supTotalQuantity = value; }
        }


        //Enumeration to store different  Payment methods
        public enum SupPaymentMethod { Cash, Credit_Card, Debit_Card, UPI, Cheque_Payment };


        //To store Per unit price of a particular Raw Material
        private double _supPerUnitPrice;

        public double SupPerUnitPrice
        {
            get { return _supPerUnitPrice; }
            set { _supPerUnitPrice = value; }
        }


        //To store Total Price of a particular Raw Material
        private double _supTotalPrice;

        public double SupTotalPrice
        {
            get { return _supTotalPrice; }
            set { _supTotalPrice = value; }
        }


        //Constructor to initialise values to different fields
        public SupplierPaymentDetails()
        {
            _supTransactionID = 0;
            _supOrderDate = DateTime.Now;
           
            _supTotalQuantity = 0;
            _supPerUnitPrice = 0.0;

        }


    }
}