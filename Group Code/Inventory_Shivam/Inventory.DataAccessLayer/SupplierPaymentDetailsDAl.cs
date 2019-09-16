using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Inventory.Entities;
using Inventory.Exceptions;

namespace Inventory.DataAccessLayer
{
    public class SupplierPaymentDetailsDAL
    {
        public static List<SupplierPaymentDetails> supPDList = new List<SupplierPaymentDetails>();

        
        public List<SupplierPaymentDetails> GetPaymentdetailsDAL()
        {
            return supPDList;
        }

       

        public List<SupplierPaymentDetails> GetBillByOrderIdDAL(List<SupplierPaymentDetails> supBillDetails, long OrderId)
        {
            List<SupplierPaymentDetails> check = null ;
            bool flag = false; ;
            try
            {
                foreach (SupplierPaymentDetails item in supBillDetails )
                {
                    if (item.SupTransactionID == OrderId)
                    {
                       flag = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            if (flag)
                return supBillDetails;
            else
                return check;
        }

        public bool IncrementPaymentDetailsDAL(SupplierPaymentDetails updatePaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                for (int i = 0; i < supPDList.Count; i++)
                {
                    if (supPDList[i].SupId == updatePaymentDetails.SupId)
                    {
                        updatePaymentDetails.SupTotalPrice += supPDList[i].SupTotalPrice;
                        updatePaymentDetails.SupTotalQuantity += supPDList[i].SupTotalQuantity;
                        detailsUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return detailsUpdated;

        }

        public bool DecrementPaymentDetailsDAL(SupplierPaymentDetails updatePaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                for (int i = 0; i < supPDList.Count; i++)
                {
                    if (supPDList[i].SupId == updatePaymentDetails.SupId)
                    {
                        updatePaymentDetails.SupTotalPrice -= supPDList[i].SupTotalPrice;
                        updatePaymentDetails.SupTotalQuantity -= supPDList[i].SupTotalQuantity;
                        detailsUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return detailsUpdated;

        }

        


    }
}