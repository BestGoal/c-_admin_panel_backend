using EventsManagemtns;
using System.Collections.Generic;

namespace Domain
{
    public class APT
    {

        public int id { set; get; }
        public string Name { set; get; }
        public IList<Country> TargetedCountries { set; get; }
        public IList<Country> OriginCountries { set; get; }
        public IList<Content> Contents { set; get; }
        public IList<ThreatSignature> ThreatSignatures { set; get; }
        public IList<AlternativeName> AlternativeNames { set; get; }
        public IList<AttachmentProp> Attachments { set; get; }
        public IList<AlternativeName> CompanyNames { set; get; }
        public IList<AlternativeName> TargetSectorNames { set; get; }
        public IList<AlternativeName> ToolsNames { set; get; }
        public string Date { set; get; }
        public int Counter { get; set; }
        public bool DbSuccess { get; set; }
    }
}