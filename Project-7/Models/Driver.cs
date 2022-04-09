using System;
using System.Collections.Generic;
using System.Linq;
using PROJECT_5.Models.DAL;
using System.Web;

namespace PROJECT_5.Models
{
    public class Driver
    {
        int driverID;
        string transportComany;
        string driverFname;
        string driverLname;
        string driverPhone;
        string driverLicense;
        DateTime driverCreateDate;
        DateTime driverUpdateDate;

        public Driver(int driverID, string transportComany, string driverFname, string driverLname, string driverPhone, string driverLicense, DateTime driverCreateDate, DateTime driverUpdateDate)
        {
            this.driverID = driverID;
            this.transportComany = transportComany;
            this.driverFname = driverFname;
            this.driverLname = driverLname;
            this.driverPhone = driverPhone;
            this.driverLicense = driverLicense;
            this.driverCreateDate = driverCreateDate;
            this.driverUpdateDate = driverUpdateDate;
        }

        public int DriverID { get => driverID; set => driverID = value; }
        public string TransportComany { get => transportComany; set => transportComany = value; }
        public string DriverFname { get => driverFname; set => driverFname = value; }
        public string DriverLname { get => driverLname; set => driverLname = value; }
        public string DriverPhone { get => driverPhone; set => driverPhone = value; }
        public string DriverLicense { get => driverLicense; set => driverLicense = value; }
        public DateTime DriverCreateDate { get => driverCreateDate; set => driverCreateDate = value; }
        public DateTime DriverUpdateDate { get => driverUpdateDate; set => driverUpdateDate = value; }
    }
}