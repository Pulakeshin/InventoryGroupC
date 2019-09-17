using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    //This is a model class for Distributor Payment Details
    public class DistributorPaymentDetails
    {
        //Distributor Id and its Auto-Implemented Property
        private string _disId;

        public string DisId
        {
            get { return _disId; }
            set { _disId = value; }
        }

        //Order Id provided to the distributor while placing order
        private int _disOrderId;

        public int DisOrderId
        {
            get { return _disOrderId; }
            set { _disOrderId = value; }
        }

        //Transaction Id provided to the Distributor when payment is successful
        private long _disTransactionID;

        public long DisTransactionID
        {
            get { return _disTransactionID; }
            set { _disTransactionID = value; }
        }

        //To store the date of order placing
        private DateTime _disOrderDate;

        public DateTime DisOrderDate
        {
            get { return _disOrderDate; }
            set { _disOrderDate = value; }
        }

        
        

        //Total Quamtity of the Order Placed
        private int _disTotalQuantity;

        public int DisTotalQuantity
        {
            get { return _disTotalQuantity; }
            set { _disTotalQuantity = value; }
        }

        //Enumeration to store different  Payment methods
        public enum DisPaymentMethod
        {
            Cash = 0,
            Credit_Card = 1,
            Debit_Card = 2,
            UPI = 3,
            Cheque_Payment = 4
        };

        //To store Per Unit Price of a particular Product
        private double _disPerUnitPrice;

        public double DisPerUnitPrice
        {
            get { return _disPerUnitPrice; }
            set { _disPerUnitPrice = value; }
        }


        //To store Total Price of a particular Product
        private double _disTotalPrice;

        public double DisTotalPrice
        {
            get { return _disTotalPrice; }
            set { _disTotalPrice = value; }
        }


        //Constructor to initialise values to different fields
        public DistributorPaymentDetails()
        {
            _disTransactionID = 0;
            _disOrderDate = DateTime.Now;
            
            _disTotalQuantity = 0;
            _disPerUnitPrice = 0.0;

        }
    }
}