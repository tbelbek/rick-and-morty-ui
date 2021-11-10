using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RickAndMortyUI.Model
{
    public class EpisodeInfo : SubInfo
    {

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("episode")]
        public string Episode { get; set; }

        [JsonProperty("characters")]
        public List<Uri> Characters { get; set; }

    }
}