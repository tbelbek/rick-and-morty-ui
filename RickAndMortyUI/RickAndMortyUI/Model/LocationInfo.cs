using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class LocationInfo : SubInfo
    {
        public LocationInfo()
        {
            Dimension = "unknown";
            Residents = new List<Uri>();
            Type = "unknown";
            Name = "unknown";
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("residents")]
        public List<Uri> Residents { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} - Dimension: {Dimension} - Residents: {Residents.Count}";
        }
    }
}