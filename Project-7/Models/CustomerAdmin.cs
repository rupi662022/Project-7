using System;
using System.Collections.Generic;
using System.Linq;
using Project_7.Models.DAL;
using System.Web;

namespace Project_7.Models
{
    public class CustomerAdmin
    {
        int adminId;
        string transportComany;
        string fullName;
        string phoneNumber;
        bool isAllowed;
        string isActive;


        public CustomerAdmin(int adminId, string transportComany, string fullName, string phoneNumber, bool isAllowed, string isActive)
        {
            this.AdminId = adminId;
            this.TransportComany = transportComany;
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.IsAllowed = isAllowed;
            this.IsActive = isActive;
        }
        public int AdminId { get => adminId; set => adminId = value; }
        public string TransportComany { get => transportComany; set => transportComany = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsAllowed { get => isAllowed; set => isAllowed = value; }
        public string IsActive { get => isActive; set => isActive = value; }

        public CustomerAdmin()
        {
        }


        //public int InsertCustomerAdmin()
        //{
      
        //    DataServices ds = new DataServices();
        //    return ds.InsertCustomerAdmin(this);

        //}

        //public int DeleteCustomerAdmin()
        //{
        //    DataServices ds = new DataServices();
        //    return ds.DeleteCustomerAdmin(this);
        //}


        //public int UpdateCustomerAdmin()
        //{
        //    DataServices ds = new DataServices();
        //    return ds.UpdateCustomerAdmin(this);
        //}

        public List<CustomerAdmin> ReadCustomerAdmins()
        {
            DataServices ds = new DataServices();
            return ds.ReadCustomerAdmins();
        }

    }
}