﻿using WebApp.Adapter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Adapter.Services;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApp.Adapter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageProcess _imageProcess;

        public HomeController(ILogger<HomeController> logger, IImageProcess imageProcess)
        {
            _logger = logger;
            _imageProcess = imageProcess;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddWaterMark()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWaterMark(IFormFile image)
        {
            if(image is { Length: >= 0 })
            {
                var imageMemoryStream = new MemoryStream();
                await image.CopyToAsync(imageMemoryStream);
                _imageProcess.AddWaterMark("Nurettin Ekiz", image.FileName, imageMemoryStream);

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
