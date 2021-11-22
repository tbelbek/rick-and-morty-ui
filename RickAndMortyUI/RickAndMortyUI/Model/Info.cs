using System;
using System.Linq;
using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class Info
    {
        [JsonProperty("count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("pages", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Pages { get; set; }

        [JsonProperty("next", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri Next { get; set; }

        [JsonProperty("prev")] public Uri Prev { get; set; }

        public string CurrentPageNumber { get; set; }
        public string NextPageNumber => GetNextPage();
        public string PreviousPageNumber => GetPreviousPage();

        public string GetPreviousPage()
        {
            return this.Prev?.Query.Split('=').LastOrDefault();
        }

        public string GetNextPage()
        {
            return this.Next?.Query.Split('=').LastOrDefault();
        }
    }
}