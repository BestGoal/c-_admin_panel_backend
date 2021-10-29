using EventsManagemtns;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Domain.Models
{
    public class CloseReport
    {
        public int id { get; set; }
        public string report { set; get; }
        public int closedBy { set; get; }
        public DateTime closingDate { set; get; }
        public IList<AttachmentProp> attachments { set; get; }
        
    }
}
