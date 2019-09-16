using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class DistributorPaymentDetails
    {
        private string _disId;

        public string DisId
        {
            get { return _disId; }
            set { _disId = value; }
        }
        private long _disTransactionID;

        public long DisTransactionID
        {
            get { return _disTransactionID; }
            set { _disTransactionID = value; }
        }

        private DateTime _disOrderDate;

        public DateTime DisOrderDate
        {
            get { return _disOrderDate; }
            set { _disOrderDate = value; }
        }
        private string _disBillingAddress;

        public string DisBillingAddress
        {
            get { return _disBillingAddress; }
            set { _disBillingAddress = value; }
        }

        private int _disTotalQuantity;

        public int DisTotalQuantity
        {
            get { return _disTotalQuantity; }
            set { _disTotalQuantity = value; }
        }

        public enum DisPaymentMethod { Cash, Credit_Card, Debit_Card, UPI, Cheque_Payment };

        private double _disPerUnitPrice;

        public double DisPerUnitPrice
        {
            get { return _disPerUnitPrice; }
            set { _disPerUnitPrice = value; }
        }

        private double _disTotalPrice;

        public double DisTotalPrice
        {
            get { return _disTotalPrice; }
            set { _disTotalPrice = value; }
        }

        public DistributorPaymentDetails()
        {
            _disTransactionID = 0;
            _disOrderDate = DateTime.Now;
            _disBillingAddress = string.Empty;
            _disTotalQuantity = 0;
            _disPerUnitPrice = 0.0;

        }
    }
}