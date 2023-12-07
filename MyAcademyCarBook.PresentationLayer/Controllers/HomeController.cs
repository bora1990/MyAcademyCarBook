using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IPriceService _priceService;
        private readonly ICommentService _commentService;

        public HomeController(ICarService carService, ICategoryService categoryService, IBrandService brandService, IPriceService priceService, ICommentService commentService)
        {
            _carService = carService;
            _categoryService = categoryService;
            _brandService = brandService;
            _priceService = priceService;
            _commentService = commentService;
        }
 

        public IActionResult Index()
        {
            var categories = _categoryService.TGetListAll();

            SelectList catList = new SelectList(categories, "CategoryID", "CategoryName");

            ViewBag.Categories = catList;


            var brands= _brandService.TGetListAll();

            SelectList b = new SelectList(brands, "BrandID", "BrandName");

            ViewBag.Brands = b;

            ViewBag.Comments=_commentService.TGetListAll();

            var values=_priceService.TGetListAll();

            return View(values);
        }
   

        [HttpPost]
        public IActionResult Index(int seats, string gears, int year, int brand, int category)
        {
            var categories = _categoryService.TGetListAll();

            SelectList catList = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.Categories = catList;


            var brands = _brandService.TGetListAll();

            SelectList b = new SelectList(brands, "BrandID", "BrandName");

            ViewBag.Brands = b;

            var allCars = _carService.TGetAllCarsWithStatusandBrandsandCategory();
            var filteredCars = allCars.Where(c => c.PersonCount == seats && c.GearType == gears && c.Year == year && c.BrandID == brand && c.CategoryID == category).ToList();

            TempData["filteredCars"] = JsonConvert.SerializeObject(filteredCars, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            //var ids = filteredCars.Select(x => x.CarID).ToList();
            //var values = _priceService.TGetListAll().Where(x => ids.Contains(x.CarID)).ToList();

            return RedirectToAction("Index", "RentACar");
        }


    }
}