using System;

namespace EventsManagemtns.Controllers
{
    public class Comment
    {
        public int id { get; set; }
        public string commentString { get; set; }
        public Employee commentedBy { get; set; }

        public DateTime commentDate { get; set; }

    }
}