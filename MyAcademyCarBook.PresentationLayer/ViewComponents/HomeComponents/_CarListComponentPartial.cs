using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.Concrete;
using System.ComponentModel;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.HomeComponents
{
	public class _CarListComponentPartial:ViewComponent
	{
		private readonly ICarService _carService;

		private readonly IPriceService _priceService;

		public _CarListComponentPartial(ICarService carService,IPriceService priceService)
		{
			_carService = carService;
			_priceService = priceService;
		}

		public IViewComponentResult Invoke()
		{ 
			var values=_carService.TGetAllCarsWithStatusandBrandsandCategory().TakeLast(3).ToList();

			var p = _priceService.TGetListAll().TakeLast(3).ToList();

			ViewBag.carlist=values;
			ViewBag.price = p;

			return View();
		}
	}
}
