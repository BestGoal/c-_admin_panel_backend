using System;

namespace EventsManagemtns
{
    public class Status
    {
        public int Id { set; get; }
        public string StatusString { set; get; }
        public bool isClosing { set; get; }
        public bool isOpen { set; get; }
        public int StatusTypeId { set; get; }

    }
}