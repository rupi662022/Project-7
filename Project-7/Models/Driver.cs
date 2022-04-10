using System;
using System.Collections.Generic;
using System.Linq;
using Project_7.Models.DAL;
using System.Web;

namespace Project_7.Models
{
    public class Driver
    {
        int driverID;
        string transportComany;
        string driverFname;
        string driverLname;
        string driverPhone;
        string driverLicense;
       

        public Driver(int driverID, string transportComany, string driverFname, string driverLname, string driverPhone, string driverLicense)
        {
            this.driverID = driverID;
            this.transportComany = transportComany;
            this.driverFname = driverFname;
            this.driverLname = driverLname;
            this.driverPhone = driverPhone;
            this.driverLicense = driverLicense;
  
        }

        public int DriverID { get => driverID; set => driverID = value; }
        public string TransportComany { get => transportComany; set => transportComany = value; }
        public string DriverFname { get => driverFname; set => driverFname = value; }
        public string DriverLname { get => driverLname; set => driverLname = value; }
        public string DriverPhone { get => driverPhone; set => driverPhone = value; }
        public string DriverLicense { get => driverLicense; set => driverLicense = value; }



        public Driver()
        {
     

        }

        //public int InsertDriver()
        //{
        //    //int res = 0;
        //    DataServices ds = new DataServices();
        //    return ds.InsertDriver(this);
        //    //return res;
        ////}





        //public List<Driver> ReadDrivers()
        //{

        //    DataServices ds = new DataServices();
        //    ds.ReadDrivers();
        //}
        public int UpdateGatePass()
        {
            DataServices ds = new DataServices();
            return ds.UpdateDrivers(this);
        }

        public List<Driver> ReadDrivers()
        {
            DataServices ds = new DataServices();
            return ds.ReadDrivers();
        }
        //public int UpdateDrivers()
        //{
        //    DataServices ds = new DataServices();
        //    return ds.UpdateDrivers(this);
        //}
    }
}