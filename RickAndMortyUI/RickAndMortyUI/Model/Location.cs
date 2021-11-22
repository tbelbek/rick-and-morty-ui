using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}