using System;
using System.Collections.Generic;
using System.Linq;
using RickAndMortyUI.Model;

namespace RickAndMortyUI.Helper
{
    public static class CharacterExtensions
    {
        public static List<string> GetEpisodeIds(this List<Uri> episode)
        {
            return episode.Select(t => t.ToString().Split("/").ToList().Last()).ToList();
        }

        public static string GetLocationIds(this Location location)
        {
            return location.Url.Split('/').ToList().Last();
        }
    }
}