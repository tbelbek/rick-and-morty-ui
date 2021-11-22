using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RickAndMortyUI.Helper;

namespace RickAndMortyUI.Model
{
    public class Character
    {
        public Character()
        {
            OriginInfo = new LocationInfo();
            LocationInfo = new LocationInfo();
        }


        [JsonProperty("id")]
        public long? Id { get; set; }

        [Display(Name = "Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        [JsonProperty("status")]
        public Status? Status { get; set; }

        [Display(Name = "Species")]
        [JsonProperty("species")]
        public string Species { get; set; }

        [Display(Name = "Type")]
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public Location Origin { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("episode")]
        public List<Uri> Episode { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }

        [Display(Name = "Episodes in")]
        [JsonProperty("episodeInfos")]
        public List<EpisodeInfo> EpisodeInfos { get; set; }

        [JsonProperty("episodeIds")]
        public List<string> EpisodeIds => Episode.GetEpisodeIds();

        [Display(Name = "Location")]
        [JsonProperty("locationInfo")]
        public LocationInfo LocationInfo { get; set; }

        [Display(Name = "Origin")]
        [JsonProperty("originInfo")]
        public LocationInfo OriginInfo { get; set; }



    }
}