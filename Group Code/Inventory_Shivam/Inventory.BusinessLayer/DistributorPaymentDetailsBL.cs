﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;
using Inventory.DataAccessLayer;

namespace Inventory.BusinessLayer
{
    public class DistributorDetailsBL
    {
        private static bool ValidateDisPayment(DistributorPaymentDetails disPD)
        {
            StringBuilder sb = new StringBuilder();
            bool validPayment = true;
            if (disPD.DisTransactionID <= 0)
            {
                validPayment = false;
                sb.Append(Environment.NewLine + "Invalid Distributor ID");

            }
            if (disPD.DisId == string.Empty)
            {
                validPayment = false;
                sb.Append(Environment.NewLine + "Distributor Name Required");

            }

            if (validPayment == false)
                throw new InventoryException(sb.ToString());
            return validPayment;
        }


        public static List<DistributorPaymentDetails> GetBillByOrderIdBL(long orderId)
        {
            List<DistributorPaymentDetails> Bill = null;

            try
            {
                DistributorPaymentDetailsDAL billDAL = new DistributorPaymentDetailsDAL();
                Bill = billDAL.GetBillByOrderIdDAL(Bill, orderId);

            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            /*
            catch (Exception ex)
            {
                throw ex;
            }
            */

            return Bill;



        }


        public static bool IncrementPaymentDetailsBL(DistributorPaymentDetails updatepaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                if (ValidateDisPayment(updatepaymentDetails))
                {
                    DistributorPaymentDetailsDAL disPDDAL = new DistributorPaymentDetailsDAL();
                    detailsUpdated = disPDDAL.IncrementPaymentDetailsDAL(updatepaymentDetails);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            /*
            catch (Exception ex)
            {
                throw ex;
            }
            */

            return detailsUpdated;
        }

        public static bool DecrementPaymentDetailsBL(DistributorPaymentDetails updatepaymentDetails)
        {
            bool detailsUpdated = false;
            try
            {
                if (ValidateDisPayment(updatepaymentDetails))
                {
                    DistributorPaymentDetailsDAL supPDDAL = new DistributorPaymentDetailsDAL();
                    detailsUpdated = supPDDAL.DecrementPaymentDetailsDAL(updatepaymentDetails);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            /*
            catch (Exception ex)
            {
                throw ex;
            }
            */

            return detailsUpdated;
        }




    }
}
