using System;
using System.Collections.Generic;
using System.Linq;
using RickAndMortyUI.Helper;
using RickAndMortyUI.Model;

namespace RickAndMortyUI.Service
{
    public class ApiService : IApiService
    {
        /// <summary>
        /// Request helper
        /// </summary>
        private readonly IRequestHelper _requestHelper;

        public ApiService(IRequestHelper requestHelper)
        {
            _requestHelper = requestHelper;
        }

        /// <summary>
        /// Gets characters from api without detail info
        /// </summary>
        /// <param name="pageNo">Page number</param>
        /// <returns></returns>
        public MainList GetChars(int pageNo = 1)
        {
            var url = $"https://rickandmortyapi.com/api/character?page={pageNo}";
            return _requestHelper.Get<MainList>(url);
        }

        /// <summary>
        /// Gets detailed episode info with number list
        /// </summary>
        /// <param name="episodeNoList">episode number list</param>
        /// <returns></returns>
        public List<EpisodeInfo> GetEpisodeInfo(IEnumerable<string> episodeNoList)
        {
            episodeNoList = ListCleaner(episodeNoList);
            var url = $"https://rickandmortyapi.com/api/episode/[{string.Join(",", episodeNoList)}]";
            return _requestHelper.Get<List<EpisodeInfo>>(url);
        }

        /// <summary>
        /// Gets detailed location info with number list
        /// </summary>
        /// <param name="locationNoList">location id list</param>
        /// <returns></returns>
        public List<LocationInfo> GetLocationInfo(IEnumerable<string> locationNoList)
        {
            locationNoList = ListCleaner(locationNoList);
            var url = $"https://rickandmortyapi.com/api/location/[{string.Join(",", locationNoList)}]";
            return _requestHelper.Get<List<LocationInfo>>(url);
        }

        /// <summary>
        /// Processes list for empty items, converts and sorts them.
        /// </summary>
        /// <param name="listToSort"> list to be processed</param>
        /// <returns></returns>
        public IEnumerable<string> ListCleaner(IEnumerable<string> listToSort)
        {
            listToSort = listToSort.Where(t => !string.IsNullOrEmpty(t)).OrderBy(Convert.ToInt32)
                .ToList();
            return listToSort;
        }

        /// <summary>
        /// Gets 20 characters from the page provided with all detailed info.
        /// </summary>
        /// <param name="pageNo">page number</param>
        /// <returns></returns>
        public MainList GetCharsWithEpisodeInfo(int pageNo = 1)
        {
            var chars = GetChars(pageNo);
            var episodes = GetAllEpisodes(chars);
            var locations = GetAllLocations(chars);
            chars.Results = ProcessApiData(chars, episodes, locations);
            chars.Info.CurrentPageNumber = pageNo.ToString();
            return chars;
        }

        /// <summary>
        /// Gets episode infos based on character episode ids
        /// </summary>
        /// <param name="chars">R&M API object including characters</param>
        /// <returns></returns>
        public List<EpisodeInfo> GetAllEpisodes(MainList chars)
        {
            var episodeIds = chars.Results.SelectMany(t => t.EpisodeIds).Distinct();
            var episodes = GetEpisodeInfo(episodeIds.ToList());
            return episodes;
        }

        /// <summary>
        /// Gets episode infos based on character episode ids
        /// </summary>
        /// <param name="chars">R&M API object including character locations</param>
        /// <returns></returns>
        public List<LocationInfo> GetAllLocations(MainList chars)
        {
            var locationIDs = chars.Results.Select(t => t.Location.GetLocationIds()).ToList();
            locationIDs.AddRange(chars.Results.Select(t => t.Origin.GetLocationIds()));
            var locations = GetLocationInfo(locationIDs.Distinct());
            return locations;
        }

        /// <summary>
        /// Matches location and episode info with character profiles.
        /// </summary>
        /// <param name="chars">R&M API object including character summary data</param>
        /// <param name="episodes">Detailed episode list</param>
        /// <param name="locations">Detailed location list</param>
        /// <returns></returns>
        public List<Character> ProcessApiData(MainList chars, List<EpisodeInfo> episodes, List<LocationInfo> locations)
        {
            return chars.Results.Select(t =>
            {
                t.EpisodeInfos = episodes.Where(k => t.EpisodeIds.Contains(k.Id.ToString())).ToList();
                var locationId = t.Location.GetLocationIds();
                var originId = t.Origin.GetLocationIds();
                var location = locations.FirstOrDefault(k => k.Id.ToString() == locationId);
                var origin = locations.FirstOrDefault(k => k.Id.ToString() == originId);
                t.LocationInfo = location ?? new LocationInfo();
                t.OriginInfo = origin ?? new LocationInfo();
                return t;
            }).ToList();
        }
    }
}