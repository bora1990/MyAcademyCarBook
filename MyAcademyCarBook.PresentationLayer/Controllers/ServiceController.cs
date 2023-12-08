using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.ValidationRules.ServiceValidation;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()  //UI
		{
            ViewBag.title1 = "Hizmetlerimiz";
            ViewBag.title2 = "Sizin için yapabileceklerimiz ";
            var values = _serviceService.TGetListAll();
			return View(values);
		}

		public IActionResult ServiceList()
		{
			var values = _serviceService.TGetListAll();
			return View(values);
		}

        public IActionResult CreateService()
        {
            return View();
        }

        public IActionResult DeleteService(int id)
        {
            var entity= _serviceService.TGetByID(id);
            _serviceService.TDelete(entity);

            return RedirectToAction("ServiceList");
        }



        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            CreateServiceValidator validationRules = new CreateServiceValidator();
            ValidationResult result = validationRules.Validate(service);

            if (result.IsValid)
            {
                _serviceService.TInsert(service);
                return RedirectToAction("ServiceList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            
            return RedirectToAction("ServiceList");
        }



    }
}
