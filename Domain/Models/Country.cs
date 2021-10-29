using Domain;
using System.Collections;
using System.Collections.Generic;

namespace EventsManagemtns
{
    public class Country
    {

        public int Id { set; get; }
        public string CountryName { set; get; }
        public string Contenant { set; get; }
        public Status Status { set; get; }
        public string dbStatus { set; get; }
        public IList<APT> targeted { set; get; }

        public IList<APT> origin { set; get; }

    }
}