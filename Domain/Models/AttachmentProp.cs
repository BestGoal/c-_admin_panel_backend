using Domain;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns
{
    public class AttachmentProp
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public string Filename { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
        public ICollection<APT> apts { get; set; }
        public ICollection<CloseReport> reports { get; set; }


    }
}
