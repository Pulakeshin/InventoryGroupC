using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;

namespace Inventory.DataAccessLayer
{
    public class DistributorPaymentDetailsDAL
    {

        public static List<DistributorPaymentDetails> disPDList = new List<DistributorPaymentDetails>();


        public List<DistributorPaymentDetails> GetPaymentdetailsDAL()
        {
            return disPDList;
        }



        public List<DistributorPaymentDetails> GetBillByOrderIdDAL(List<DistributorPaymentDetails> disBillDetails, long OrderId)
        {
            List<DistributorPaymentDetails> check = null;
            bool flag = false; ;
            try
            {
                foreach (DistributorPaymentDetails item in disBillDetails)
                {
                    if (item.DisTransactionID == OrderId)
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
                return disBillDetails;
            else
                return check;
        }

        public bool IncrementPaymentDetailsDAL(DistributorPaymentDetails updatePaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                for (int i = 0; i < disPDList.Count; i++)
                {
                    if (disPDList[i].DisId == updatePaymentDetails.DisId)
                    {
                        updatePaymentDetails.DisTotalPrice += disPDList[i].DisTotalPrice;
                        updatePaymentDetails.DisTotalQuantity += disPDList[i].DisTotalQuantity;
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

        public bool DecrementPaymentDetailsDAL(DistributorPaymentDetails updatePaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                for (int i = 0; i < disPDList.Count; i++)
                {
                    if (disPDList[i].DisId == updatePaymentDetails.DisId)
                    {
                        updatePaymentDetails.DisTotalPrice -= disPDList[i].DisTotalPrice;
                        updatePaymentDetails.DisTotalQuantity -= disPDList[i].DisTotalQuantity;
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
