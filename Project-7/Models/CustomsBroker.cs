using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_7.Models.DAL;

namespace Project_7.Models
{
    public class CustomsBroker
    {
        int   id;
        string brokerName;
        string adress;
        string phoneNumber;
        string fax;

        public CustomsBroker(int id, string brokerName, string adress, string phoneNumber, string fax)
        {
            this.id = id;
            this.brokerName = brokerName;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.fax = fax;
        }

        public int Id { get => id; set => id = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }
        public string Adress { get => adress; set => adress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Fax { get => fax; set => fax = value; }



        public CustomsBroker()
        {

        }


        public int InsertBroker()
        {

            DataServices ds = new DataServices();
            return ds.InsertBroker(this);

        }




        public int UpdateBroker()
        {
            DataServices ds = new DataServices();
            return ds.UpdateBroker(this);
        }

        public List<CustomsBroker> ReadBrokers()
        {
            DataServices ds = new DataServices();
            return ds.ReadBrokers();
        }
    }
}