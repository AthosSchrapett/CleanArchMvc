﻿using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }
    }
}
