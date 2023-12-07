using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System.Drawing.Drawing2D;
using System.Text.Json;
using System.Windows.Markup;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class RentACarController : Controller
    {
        private readonly IPriceService _priceService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;

        public RentACarController(IPriceService priceService, ICategoryService categoryService, IBrandService brandService, ICarService carService)
        {
            _priceService = priceService;
            _categoryService = categoryService;
            _brandService = brandService;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index(int seats, string gears, int year, int brand, int category)
        {
            var categories = _categoryService.TGetListAll();

            SelectList catList = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.Categories = catList;


            var brands = _brandService.TGetListAll();

            SelectList b = new SelectList(brands, "BrandID", "BrandName");

            ViewBag.Brands = b;

            var allCars = _carService.TGetAllCarsWithStatusandBrandsandCategory();
            var value = allCars.Where(c => c.PersonCount == seats && c.GearType == gears && c.Year == year && c.BrandID == brand && c.CategoryID == category).ToList();

            ViewBag.filterCar = value;

            var ids = value.Select(x => x.CarID).ToList();

            var values = _priceService.TGetListAll().Where(x => ids.Contains(x.CarID)).ToList();

            return View(values);
        }
           
        
    }
}
