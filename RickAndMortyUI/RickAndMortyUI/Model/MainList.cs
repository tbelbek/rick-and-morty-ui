using System.Collections.Generic;
using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class MainList
    {
        [JsonProperty("info", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Info Info { get; set; }

        [JsonProperty("results", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Results { get; set; }
    }
}