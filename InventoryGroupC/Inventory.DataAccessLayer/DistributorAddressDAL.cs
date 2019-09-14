using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exceptions;
using System.Data.Common;

namespace Inventory.DataAccessLayer
{
    public class DistributorAddressDAL
    {
        public static List<DistributorAddress> distributorAddressList = new List<DistributorAddress>();

        public bool AddDistributorAddressDAL(DistributorAddress newDistributorAddress)
        {
            bool distributorAddressAdded = false;
            try
            {
                distributorAddressList.Add(newDistributorAddress);
                distributorAddressAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return distributorAddressAdded;

        }

        public List<DistributorAddress> GetAllDistributorAddressDAL()
        {
            return distributorAddressList;
        }

        public DistributorAddress SearchDistributorAddressDAL(int searchDistributorAddressID)
        {
            DistributorAddress searchDistributorAddress = null;
            try
            {
                foreach (DistributorAddress item in distributorAddressList)
                {
                    if (item.DistributorAddressID == searchDistributorAddressID)
                    {
                        searchDistributorAddress = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchDistributorAddress;
        }

        public bool UpdateDistributorAddressDAL(DistributorAddress updateDistributorAddress)
        {
            bool distributorAddressUpdated = false;
            try
            {
                for (int i = 0; i < distributorAddressList.Count; i++)
                {
                    if (distributorAddressList[i].DistributorAddressID == updateDistributorAddress.DistributorAddressID)
                    {
                        updateDistributorAddress.DistributorAddressLine1 = distributorAddressList[i].DistributorAddressLine1;
                        updateDistributorAddress.DistributorAddressLine2 = distributorAddressList[i].DistributorAddressLine2;
                        updateDistributorAddress.DistributorCity = distributorAddressList[i].DistributorCity;
                        updateDistributorAddress.DistributorState = distributorAddressList[i].DistributorState;
                        updateDistributorAddress.DistributorPincode = distributorAddressList[i].DistributorPincode;
                        distributorAddressUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return distributorAddressUpdated;

        }

        public bool DeleteDistributorAddressDAL(int deleteDistributorAddressID)
        {
            bool distributorAddressDeleted = false;
            try
            {
                DistributorAddress deleteDistributorAddress = null;
                foreach (DistributorAddress item in distributorAddressList)
                {
                    if (item.DistributorAddressID == deleteDistributorAddressID)
                    {
                        deleteDistributorAddress = item;
                    }
                }

                if (deleteDistributorAddress != null)
                {
                    distributorAddressList.Remove(deleteDistributorAddress);
                    distributorAddressDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return distributorAddressDeleted;

        }
    }
}
