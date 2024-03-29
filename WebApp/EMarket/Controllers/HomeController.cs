﻿using Microsoft.AspNetCore.Mvc;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertisements;
using System.Threading.Tasks;
using WebApp.EMarket.Middlewares;
using System.Collections.Generic;

namespace EMarket.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(IAdvertisementService advertisementService, ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _advertisementService = advertisementService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Categories = await _categoryService.GetAllViewModel();

            return View(await _advertisementService.GetAllViewModelHome());
        }

        [HttpGet]
        public async Task<IActionResult> Advertisement(int vmId)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Categories = await _categoryService.GetAllViewModel();

            return View("Advertisement", await _advertisementService.GetByIdViewModel(vmId));
        }

        [HttpPost]
        public async Task<IActionResult> Filter(FilterAdvertisementViewModel filters)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Categories = await _categoryService.GetAllViewModel();

            return View("Index", await _advertisementService.GetAllViewModelWithFilters(filters));
        }
    }
}
