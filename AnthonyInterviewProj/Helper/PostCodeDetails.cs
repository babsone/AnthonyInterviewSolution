using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnthonyInterviewProj.Helper
{
    public class PostCodeDetails
    {
        [JsonProperty(PropertyName = "post code")]
        public string Postcode { get; set; }
        public string Country { get; set; }

        [JsonProperty(PropertyName = "country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public List<Place> Places { get; set; }
    }
}
