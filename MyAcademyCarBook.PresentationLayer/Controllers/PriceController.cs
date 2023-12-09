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
        [HttpGet]
        public IActionResult CreatePrice()
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();

            ViewBag.v1 = values;

        

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
            var carb = _priceService.TGetPricesWithCars().Where(x => x.PriceID == id).Select(y=>y.Car.Brand.BrandName).FirstOrDefault();

            var ids = _priceService.TGetByID(id).PriceID;

            var carm=_priceService.TGetPricesWithCars().Where(x=>x.PriceID==ids).Select(y=>y.Car.Model).FirstOrDefault();

            var carid = _priceService.TGetByID(id).CarID;

            ViewBag.v1 = carid;





           
            ViewBag.b = carb;
            ViewBag.m= carm;
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
