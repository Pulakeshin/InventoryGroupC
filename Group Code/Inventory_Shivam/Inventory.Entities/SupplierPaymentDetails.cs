using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class SupplierPaymentDetails
    {
        private string _supId;

        public string SupId
        {
            get { return _supId; }
            set { _supId = value; }
        }

        private long _supTransactionID;

        public long SupTransactionID
        {
            get { return _supTransactionID; }
            set { _supTransactionID = value; }
        }

        private DateTime _supOrderDate;

        public DateTime SupOrderDate
        {
            get { return _supOrderDate; }
            set { _supOrderDate = value; }
        }
        private string _supBillingAddress;

        public string SupBillingAddress
        {
            get { return _supBillingAddress; }
            set { _supBillingAddress = value; }
        }

        private int _supTotalQuantity;

        public int SupTotalQuantity
        {
            get { return _supTotalQuantity; }
            set { _supTotalQuantity = value; }
        }

        public enum SupPaymentMethod { Cash, Credit_Card, Debit_Card, UPI, Cheque_Payment};

        private double _supPerUnitPrice;

        public double SupPerUnitPrice
        {
            get { return _supPerUnitPrice; }
            set { _supPerUnitPrice = value; }
        }

        private double _supTotalPrice;

        public double SupTotalPrice
        {
            get { return _supTotalPrice; }
            set { _supTotalPrice = value; }
        }

        public SupplierPaymentDetails()
        {
            _supTransactionID = 0;
            _supOrderDate = DateTime.Now;
            _supBillingAddress = string.Empty;
            _supTotalQuantity = 0;
            _supPerUnitPrice = 0.0;
            
        }
    }
}