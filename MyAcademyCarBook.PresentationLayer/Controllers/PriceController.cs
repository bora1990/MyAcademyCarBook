using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        private readonly ICarService _carService;  //araba listesini getirmek için eklememiz gerekir.

        public PriceController(IPriceService priceService, ICarService carService)
        {
            _priceService = priceService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values = _priceService.TGetPricesWithCars();
            return View(values);
        }
        public IActionResult CreatePrice()
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithStatusandBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult CreatePrice(Price price)
        {
            _priceService.TInsert(price);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePrice(int id)
        {
            var value = _priceService.TGetByID(id);
            _priceService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePrice(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithStatusandBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();

            ViewBag.v = values;
            var value = _priceService.TGetByID(id);

            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePrice(Price price)
        {
            _priceService.TUpdate(price);
            return RedirectToAction("Index");
        }

    }
}
