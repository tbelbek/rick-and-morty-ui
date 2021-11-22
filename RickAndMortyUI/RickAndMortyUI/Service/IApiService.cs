using System;
using System.Collections.Generic;
using System.Linq;
using RickAndMortyUI.Helper;
using RickAndMortyUI.Model;

namespace RickAndMortyUI.Service
{
    public interface IApiService
    {
        MainList GetCharsWithEpisodeInfo(int pageNo = 1);
        MainList GetChars(int pageNo = 1);
        List<EpisodeInfo> GetEpisodeInfo(IEnumerable<string> episodeNoList);
        List<LocationInfo> GetLocationInfo(IEnumerable<string> locationNoList);
        IEnumerable<string> ListCleaner(IEnumerable<string> locationNoList);
        List<EpisodeInfo> GetAllEpisodes(MainList chars);
        List<LocationInfo> GetAllLocations(MainList chars);
        List<Character> ProcessApiData(MainList chars, List<EpisodeInfo> episodes, List<LocationInfo> locations);
    }
}