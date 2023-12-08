using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
           var values=  _aboutService.TGetListAll();


            return View(values);
        }

        public IActionResult UpdateAbout(int id)
        {
            var value=_aboutService.TGetByID(id);

            return View();
        }

        public IActionResult About()
        {
            var values = _aboutService.TGetListAll();
            return View(values);
        }
    }
}
