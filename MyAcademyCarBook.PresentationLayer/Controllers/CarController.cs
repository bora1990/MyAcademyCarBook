using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using NuGet.Packaging.Signing;
using X.PagedList;


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

        public IActionResult Index2(string p)
        {

            ViewData["CurrentFilter"] = p;

            var values = from x in _carService.TGetAllCarsWithStatusandBrandsandCategory() select x;
            if (!string.IsNullOrEmpty(p))
            {

                values = values.Where(y=>y.Model.Contains(p));
            }
            return View(values.ToList());

     
        }

        public IActionResult CarList(int page=1)
        {
            ViewBag.title1 = "Araç Listesi";
            ViewBag.title2 = "Sizin için Araç Listemiz";

            ViewBag.allcars =_carService.TGetAllCarsWithStatusandBrandsandCategory().ToPagedList(page,3);

            var value = _priceService.TGetListAll();

            ViewBag.allPrices = value;

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

            List<SelectListItem> category = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                             select new SelectListItem
                                             {
                                                 Text = x.Category.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).DistinctBy(x => x.Text).ToList();

           


            List<SelectListItem> status = (from x in _carStatusService.TGetListAll()
                                            select new SelectListItem
                                            {
                                                Text = x.CarStatusName,
                                                Value = x.CarStatusID.ToString()
                                            }


                                            ).ToList();

            ViewBag.s = status;

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

        public IActionResult DeleteCar(int id)
        {
            var value = _carService.TGetByID(id);
            _carService.TDelete(value);
            return RedirectToAction("Index2");
        }

        public IActionResult UpdateCar(int id)
        {
            List<SelectListItem> brands = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName,
                                               Value = x.BrandID.ToString()
                                           }).DistinctBy(x => x.Text).ToList();

            List<SelectListItem> category = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()
                                             select new SelectListItem
                                             {
                                                 Text = x.Category.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).DistinctBy(x => x.Text).ToList();




            List<SelectListItem> status = (from x in _carStatusService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CarStatusName,
                                               Value = x.CarStatusID.ToString()
                                           }


                                            ).ToList();

            ViewBag.s = status;

            ViewBag.b = brands;

            ViewBag.c = category;

            var value=_carService.TGetByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            _carService.TUpdate(car);
            return RedirectToAction("Index2");
        }



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
