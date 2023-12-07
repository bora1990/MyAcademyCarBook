using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class SepetController : Controller
    {
        private readonly ICarService _carService;

        private readonly IPriceService _priceService;

        public SepetController(ICarService carService, IPriceService priceService)
        {
            _carService = carService;
            _priceService = priceService;
        }

        public IActionResult Index(int id)
        {
            var values=_carService.TGetByIdWithBrand(id);

            ViewBag.Price=_priceService.TGetPricesWithCars().Where(x=>x.CarID==id).FirstOrDefault();

            return View(values);
        }
    }
}
