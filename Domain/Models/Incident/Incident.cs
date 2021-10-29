using EventsManagemtns.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventsManagemtns.Controllers
{
    public class Incident
    {
        public int id { set; get; }
        public Category category { set; get; }
        public string date { set; get; }
        public string description { set; get; }
        public Organization org { set; get; }
        public Status status { set; get; }
        public string subject { set; get; }
        public Saverity saverity { set; get; }
        public string time { set; get; }
        public Urgancey Urgancey { set; get; }
        public IList<IpAddress> IpAddresses { set; get; }






    }
}