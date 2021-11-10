using System;
using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class SubInfo
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }
    }
}