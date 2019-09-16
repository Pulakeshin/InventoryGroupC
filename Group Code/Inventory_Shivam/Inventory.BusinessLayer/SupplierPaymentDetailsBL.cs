using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;
using Inventory.DataAccessLayer;

namespace Inventory.BusinessLayer
{
    public class SupplierPaymentDetailsBL
    {
        private static bool ValidateSupPayment(SupplierPaymentDetails supPD)
        {
            StringBuilder sb = new StringBuilder();
            bool validPayment = true;
            if (supPD.SupTransactionID <= 0)
            {
                validPayment = false;
                sb.Append(Environment.NewLine + "Invalid Supplier ID");

            }
            if (supPD.SupId == string.Empty)
            {
                validPayment = false;
                sb.Append(Environment.NewLine + "Supplier Name Required");

            }
            
            if (validPayment == false)
                throw new InventoryException(sb.ToString());
            return validPayment;
        }

      
        public static List<SupplierPaymentDetails> GetBillByOrderIdBL(long orderId)
        {
            List<SupplierPaymentDetails> Bill = null;
            
            try
            {
                SupplierPaymentDetailsDAL billDAL = new SupplierPaymentDetailsDAL();
                Bill = billDAL.GetBillByOrderIdDAL(Bill,orderId);
               
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Bill;
            

            
        }

       
        public static bool IncrementPaymentDetailsBL(SupplierPaymentDetails updatepaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                if (ValidateSupPayment(updatepaymentDetails))
                {
                    SupplierPaymentDetailsDAL supPDDAL = new SupplierPaymentDetailsDAL();
                    detailsUpdated = supPDDAL.IncrementPaymentDetailsDAL(updatepaymentDetails);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detailsUpdated;
        }

        public static bool DecrementPaymentDetailsBL(SupplierPaymentDetails updatepaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                if (ValidateSupPayment(updatepaymentDetails))
                {
                    SupplierPaymentDetailsDAL supPDDAL = new SupplierPaymentDetailsDAL();
                    detailsUpdated = supPDDAL.DecrementPaymentDetailsDAL(updatepaymentDetails);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detailsUpdated;
        }


        

    }
}