﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoYouNowThese.UI.Models;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
using DoYouNowThese.UI.Utility;
using DoYouNowThese.PROVIDER.TokenOperation;

namespace DoYouNowThese.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        InformationContentProvider informationContentProvider;
        TokenProvider tokenProvider;
        public HomeController(ILogger<HomeController> logger)
        {
            informationContentProvider = new InformationContentProvider();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetJsonPost()
        {
            informationContentProvider = new InformationContentProvider();
            tokenProvider = new TokenProvider();
            string token = string.Empty;
            if (String.IsNullOrEmpty(SessionExtension.GetSessionUserTokeyKey(HttpContext.Session)))
            {
                token = tokenProvider.GetAnonimToken();
            }
            else
            {
                token = SessionExtension.GetSessionUserTokeyKey(HttpContext.Session);
            }
            var data = informationContentProvider.GetInformationContentSingleData(token);
            return Json(data);
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
