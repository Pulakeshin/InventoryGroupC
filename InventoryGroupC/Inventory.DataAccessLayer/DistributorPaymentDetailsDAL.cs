using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;

namespace Inventory.DataAccessLayer
{
    //Service Class for Distributor Payment Details in data Access Layer
    public class DistributorPaymentDetailsDAL
    {
        //List of type <DistributorPaymentDetails> which will store all Successful Payment history to a distributor
        public static List<DistributorPaymentDetails> disPDList = new List<DistributorPaymentDetails>();

        

        //Method to return recent payments received from different Distributors
        public List<DistributorPaymentDetails> GetPaymentDetailsDAL()
        {
            return disPDList;
        }

        //To add Distributor Payment Details
        public bool AddDistributorPaymentDAL(DistributorPaymentDetails newPayment)
        {
            bool distributorPaymentAdded;
            try
            {
                disPDList.Add(newPayment);
                distributorPaymentAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return distributorPaymentAdded;

        }

        //To generate a bill by order Id given to a Distributor
        public List<DistributorPaymentDetails> GetBillByOrderIdDAL(long OrderId)
        {
            List<DistributorPaymentDetails> disBillDetails = null;

            try
            {
                foreach (DistributorPaymentDetails item in disPDList)
                {
                    if (item.DisOrderId == OrderId)
                    {
                        disBillDetails.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }

            return disBillDetails;

        }

        //To increment the 
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