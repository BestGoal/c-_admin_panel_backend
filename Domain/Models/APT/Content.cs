using System;
using System.Collections.Generic;

namespace EventsManagemtns
{
    public class Content
    {

        public int Id { set; get; }
        public string ContentString { set; get; }
        public string DbStatus { set; get; }
        public string CreatedBy { set; get; }
        public DateTime createdDate { set; get; } = DateTime.Now;

    }
}