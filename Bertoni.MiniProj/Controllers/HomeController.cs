using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bertoni.MiniProj.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bertoni.MiniProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApiHelper apiHelper;
        public HomeController(ILogger<HomeController> logger)
        {
            apiHelper = new ApiHelper();
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var albumList = await apiHelper.GetAlbums();
            if (albumList != null)
            {
                ViewBag.AlbumList = new SelectList(albumList, "Id", "Title");
                return View();
            }
            return new BadRequestResult();
        }

        public async Task<PartialViewResult> _Photos(int id)
        {
            var photos = await apiHelper.GetPhotosByAlbum(id);
            return PartialView(photos);
        }
        public async Task<PartialViewResult> _Comments(int id)
        {
            var comments = await apiHelper.GetCommentsByPhoto(id);
            
            return PartialView(comments);
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}
