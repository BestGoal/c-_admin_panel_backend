using System.Collections.Generic;

namespace EventsManagemtns.Models
{
    public class StatusType
    {
        public int id { get; set; }

        public string statusType { get; set; }

        public IList<Status> statuses { get; set; }
    }
}