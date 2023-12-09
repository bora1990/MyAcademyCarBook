using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarStatusController : Controller
    {
        private readonly ICarStatusService _carStatusService;

        public CarStatusController(ICarStatusService carStatusService)
        {
            _carStatusService = carStatusService;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var values=_carStatusService.TGetListAll();
            return View(values);
        }

        public IActionResult CreateCarStatus()  
        { 
        return View();
        }

        [HttpPost]

        public IActionResult CreateCarStatus(CarStatus carStatus)
        {
            _carStatusService.TInsert(carStatus);


            return RedirectToAction("Index");
        }

        public IActionResult RemoveCarStatus(int id) 
        {
            var value=_carStatusService.TGetByID(id);
            _carStatusService.TDelete(value);
            return RedirectToAction("Index");
        
        }

        public IActionResult UpdateCarStatus(int id)
        {
            var value = _carStatusService.TGetByID(id);
            return View(value);
        }
        [HttpPost]

        public IActionResult UpdateCarStatus(CarStatus carStatus)
        {
            _carStatusService.TUpdate(carStatus);

            return RedirectToAction("Index");
        }
    }
}
