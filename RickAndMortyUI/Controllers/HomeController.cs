using Microsoft.AspNetCore.Mvc;
using RickAndMortyUI.Service;

namespace RickAndMortyUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiService">Injects API service</param>
        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        /// <summary>
        /// Index page
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        public IActionResult Index(int page = 1)
        {
            var chars = _apiService.GetCharsWithEpisodeInfo(page);

            return View(chars);
        }

        /// <summary>
        /// Error page
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return RedirectToAction("Index");
        }

    }
}
