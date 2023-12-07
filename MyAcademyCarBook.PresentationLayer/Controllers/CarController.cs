﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using NuGet.Packaging.Signing;


namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        private readonly IBrandService _brandService;

        private readonly ICarDetailService _carDetailService;

        private readonly ICarStatusService _carStatusService;

        private readonly ICategoryService _categoryService;

        private readonly IPriceService _priceService;



        public CarController(ICarService carService, IBrandService brandService, ICarDetailService carDetailService, ICarStatusService carStatusService, ICategoryService categoryService, IPriceService priceService)
        {
            _carService = carService;
            _brandService = brandService;
            _carDetailService = carDetailService;
            _carStatusService = carStatusService;
            _categoryService = categoryService;
            _priceService = priceService;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetListAll();
            return View(values);
        }

        public IActionResult Index2()
        {
            var values = _carService.TGetAllCarsWithStatusandBrandsandCategory();
            return View(values);
        }

        public IActionResult CarList()
        {
            ViewBag.title1 = "Araç Listesi";
            ViewBag.title2 = "Sizin için Araç Listemiz";

            ViewBag.allcars =_carService.TGetAllCarsWithStatusandBrandsandCategory().ToList();

            var value = _priceService.TGetListAll();

            ViewBag.allPrices = value;

            // buraya tüm carları mı getiriyordun? evet ama sonra onu viewbagle taşıdım
            return View();
        }

        [HttpGet]
        public IActionResult CreateCar()
        {

            List<SelectListItem> brands = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName,
                                               Value = x.BrandID.ToString()
                                           }).DistinctBy(x => x.Text).ToList();
            //List<SelectListItem> carstatuses = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = x.CarStatus.CarStatusName,
            //                                        Value = x.CarStatusId.ToString()
            //                                    }).ToList();

            List<SelectListItem> category = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                             select new SelectListItem
                                             {
                                                 Text = x.Category.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).DistinctBy(x => x.Text).ToList();




            ViewBag.b = brands;
        
            ViewBag.c = category;

            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {

            _carService.TInsert(car);


            return RedirectToAction("Index2");
        }

        public IActionResult UpdateCar()
        {
            return View();
        }

        //public IActionResult UpdateCar()
        //{
        //    return View();
        //}



        public IActionResult CarDetail(int id)
        {
            ViewBag.title1 = "Araba Detayları";
            ViewBag.title2 = "Son Araç Detayları";
            ViewBag.i = id;

            var value = _carDetailService.TGetCarDetailWithBrand(id);
            ViewBag.b = value.Car.Brand.BrandName;
            ViewBag.m = value.Car.Model;

            ViewBag.v = value.Description;  //id li aracın description ı

            return View(value);
        }



    }
}