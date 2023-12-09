using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            ViewBag.avgprc = _statisticsService.TAverageCarPrice();

            ViewBag.crcnt = _statisticsService.TCarCount();

            ViewBag.lstcr = _statisticsService.TLastCarBrandName();

            ViewBag.mxprccr = _statisticsService.TMaxPriceCar();


            return View();
        }


    }
}
