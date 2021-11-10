using Newtonsoft.Json;
using RestSharp;

namespace RickAndMortyUI.Helper
{
    public class RequestHelper : IRequestHelper
    {
        /// <summary>
        /// Makes get requests
        /// </summary>
        /// <typeparam name="T">return type of object</typeparam>
        /// <param name="url">request URL</param>
        /// <returns></returns>
        public T Get<T>(string url)
        {
            var client = new RestClient(url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);

        }
    }
}