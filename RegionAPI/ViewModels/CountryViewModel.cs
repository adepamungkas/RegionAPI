using RegionAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegionAPI.ViewModels
{
    public class CountryViewModel:BaseViewModel
    {
        public override long Id { get; set; }
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Anthem { get; set; }
        public string Emblem { get; set; }
        public string OfficialLanguage { get; set; }
        public string Government { get; set; }
        public string Legislature { get; set; }
        public double Area { get; set; }
        public string Religion { get; set; }
        public string Capital { get; set; }
        public double Population { get; set; }
        public double Currency { get; set; }
        public string CallingCode { get; set; }
        public string Ethnics { get; set; }
    }
}
