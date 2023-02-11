using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                await _productService.AddAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();

            var productDTO = await _productService.GetByIdAsync(id);

            if(productDTO == null) return NotFound();

            var categories = await _categoryService.GetCategoriesAsync();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDTO.CategoryId);
            
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(productDTO);
        }
    }
}
