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
    //Service Class for Supplier Payment Details in data Access Layer
    public class SupplierPaymentDetailsDAL
    {
        //List of type <SupplierPaymentDetails> which will store all Successful Payment history from a Supplier
        public static List<SupplierPaymentDetails> supPDList = new List<SupplierPaymentDetails>();

        

        

        //Method to return recent payments made to different Suppliers
        public List<SupplierPaymentDetails> GetPaymentDetailsDAL()
        {
            return supPDList;
        }

        //To add Supplier Payment Details
        public bool AddSupplierPaymentDAL(SupplierPaymentDetails newSupplier)
        {
            bool supplierPaymentAdded;
            try
            {
                supPDList.Add(newSupplier);
                supplierPaymentAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return supplierPaymentAdded;

        }


        //To Generate a bill by Order ID given to a particular Supplier
        public List<SupplierPaymentDetails> GetBillByOrderIdDAL(long OrderId)
        {
            List<SupplierPaymentDetails> supBillDetails = null;

            try
            {
                foreach (SupplierPaymentDetails item in supPDList)
                {
                    if (item.SupOrderId == OrderId)
                    {
                        supBillDetails.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }

            return supBillDetails;

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